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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class propostacontratoadmww : GXDataArea
   {
      public propostacontratoadmww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public propostacontratoadmww( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavDynamicfiltersselector1 = new GXCombobox();
         cmbavDynamicfiltersoperator1 = new GXCombobox();
         cmbavDynamicfiltersselector2 = new GXCombobox();
         cmbavDynamicfiltersoperator2 = new GXCombobox();
         cmbavDynamicfiltersselector3 = new GXCombobox();
         cmbavDynamicfiltersoperator3 = new GXCombobox();
         cmbPropostaStatus = new GXCombobox();
         cmbReembolsoStatusAtual_F = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
            gxfirstwebparm_bkp = gxfirstwebparm;
            gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               dyncall( GetNextPar( )) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               gxnrGrid_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
            {
               gxgrGrid_refresh_invoke( ) ;
               return  ;
            }
            else
            {
               if ( ! IsValidAjaxCall( false) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = gxfirstwebparm_bkp;
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_114 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_114"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_114_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_114_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_114_idx = GetPar( "sGXsfl_114_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid_newrow( ) ;
         /* End function gxnrGrid_newrow_invoke */
      }

      protected void gxgrGrid_refresh_invoke( )
      {
         subGrid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid_Rows"), "."), 18, MidpointRounding.ToEven));
         AV13OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV14OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         cmbavDynamicfiltersselector1.FromJSonString( GetNextPar( ));
         AV16DynamicFiltersSelector1 = GetPar( "DynamicFiltersSelector1");
         cmbavDynamicfiltersoperator1.FromJSonString( GetNextPar( ));
         AV17DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator1"), "."), 18, MidpointRounding.ToEven));
         AV18PropostaTitulo1 = GetPar( "PropostaTitulo1");
         AV69ContratoNome1 = GetPar( "ContratoNome1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV20DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV21DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV22PropostaTitulo2 = GetPar( "PropostaTitulo2");
         AV70ContratoNome2 = GetPar( "ContratoNome2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV24DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV25DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV26PropostaTitulo3 = GetPar( "PropostaTitulo3");
         AV71ContratoNome3 = GetPar( "ContratoNome3");
         AV34ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV19DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV23DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV96Pgmname = GetPar( "Pgmname");
         AV15FilterFullText = GetPar( "FilterFullText");
         AV82TFProcedimentosMedicosNome = GetPar( "TFProcedimentosMedicosNome");
         AV83TFProcedimentosMedicosNome_Sel = GetPar( "TFProcedimentosMedicosNome_Sel");
         AV39TFPropostaDescricao = GetPar( "TFPropostaDescricao");
         AV40TFPropostaDescricao_Sel = GetPar( "TFPropostaDescricao_Sel");
         AV41TFPropostaValor = NumberUtil.Val( GetPar( "TFPropostaValor"), ".");
         AV42TFPropostaValor_To = NumberUtil.Val( GetPar( "TFPropostaValor_To"), ".");
         AV65TFContratoNome = GetPar( "TFContratoNome");
         AV66TFContratoNome_Sel = GetPar( "TFContratoNome_Sel");
         AV91TFPropostaPacienteClienteRazaoSocial = GetPar( "TFPropostaPacienteClienteRazaoSocial");
         AV92TFPropostaPacienteClienteRazaoSocial_Sel = GetPar( "TFPropostaPacienteClienteRazaoSocial_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV95TFReembolsoStatusAtual_F_Sels);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridState);
         AV28DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV27DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV84Context);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18PropostaTitulo1, AV69ContratoNome1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22PropostaTitulo2, AV70ContratoNome2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26PropostaTitulo3, AV71ContratoNome3, AV34ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV96Pgmname, AV15FilterFullText, AV82TFProcedimentosMedicosNome, AV83TFProcedimentosMedicosNome_Sel, AV39TFPropostaDescricao, AV40TFPropostaDescricao_Sel, AV41TFPropostaValor, AV42TFPropostaValor_To, AV65TFContratoNome, AV66TFContratoNome_Sel, AV91TFPropostaPacienteClienteRazaoSocial, AV92TFPropostaPacienteClienteRazaoSocial_Sel, AV95TFReembolsoStatusAtual_F_Sels, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, AV84Context) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpage", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpage", new Object[] {context});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         cleanup();
      }

      public override short ExecuteStartEvent( )
      {
         PA7M2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START7M2( ) ;
         }
         return gxajaxcallmode ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         CloseStyles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 133260), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("gxcfg.js", "?"+GetCacheInvalidationToken( ), false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("calendar-pt.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
         {
            context.WriteHtmlText( " dir=\"rtl\" ") ;
         }
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("propostacontratoadmww") +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV96Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV96Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCONTEXT", AV84Context);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCONTEXT", AV84Context);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vCONTEXT", GetSecureSignedToken( "", AV84Context, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV14OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV16DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17DynamicFiltersOperator1), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vPROPOSTATITULO1", AV18PropostaTitulo1);
         GxWebStd.gx_hidden_field( context, "GXH_vCONTRATONOME1", AV69ContratoNome1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV20DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vPROPOSTATITULO2", AV22PropostaTitulo2);
         GxWebStd.gx_hidden_field( context, "GXH_vCONTRATONOME2", AV70ContratoNome2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV24DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vPROPOSTATITULO3", AV26PropostaTitulo3);
         GxWebStd.gx_hidden_field( context, "GXH_vCONTRATONOME3", AV71ContratoNome3);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_114", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_114), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV32ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV32ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV58GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV59GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV60GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV56DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV56DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV19DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV23DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV96Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV96Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFPROCEDIMENTOSMEDICOSNOME", AV82TFProcedimentosMedicosNome);
         GxWebStd.gx_hidden_field( context, "vTFPROCEDIMENTOSMEDICOSNOME_SEL", AV83TFProcedimentosMedicosNome_Sel);
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTADESCRICAO", AV39TFPropostaDescricao);
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTADESCRICAO_SEL", AV40TFPropostaDescricao_Sel);
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTAVALOR", StringUtil.LTrim( StringUtil.NToC( AV41TFPropostaValor, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTAVALOR_TO", StringUtil.LTrim( StringUtil.NToC( AV42TFPropostaValor_To, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFCONTRATONOME", AV65TFContratoNome);
         GxWebStd.gx_hidden_field( context, "vTFCONTRATONOME_SEL", AV66TFContratoNome_Sel);
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL", AV91TFPropostaPacienteClienteRazaoSocial);
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL", AV92TFPropostaPacienteClienteRazaoSocial_Sel);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFREEMBOLSOSTATUSATUAL_F_SELS", AV95TFReembolsoStatusAtual_F_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFREEMBOLSOSTATUSATUAL_F_SELS", AV95TFReembolsoStatusAtual_F_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV10GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV10GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV28DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV27DynamicFiltersRemoving);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCONTEXT", AV84Context);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCONTEXT", AV84Context);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vCONTEXT", GetSecureSignedToken( "", AV84Context, context));
         GxWebStd.gx_hidden_field( context, "vTFREEMBOLSOSTATUSATUAL_F_SELSJSON", AV94TFReembolsoStatusAtual_F_SelsJson);
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icontype", StringUtil.RTrim( Ddo_managefilters_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icon", StringUtil.RTrim( Ddo_managefilters_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Tooltip", StringUtil.RTrim( Ddo_managefilters_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Cls", StringUtil.RTrim( Ddo_managefilters_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Width", StringUtil.RTrim( Dvpanel_tableheader_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Autowidth", StringUtil.BoolToStr( Dvpanel_tableheader_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Autoheight", StringUtil.BoolToStr( Dvpanel_tableheader_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Cls", StringUtil.RTrim( Dvpanel_tableheader_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Title", StringUtil.RTrim( Dvpanel_tableheader_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Collapsible", StringUtil.BoolToStr( Dvpanel_tableheader_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Collapsed", StringUtil.BoolToStr( Dvpanel_tableheader_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableheader_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Iconposition", StringUtil.RTrim( Dvpanel_tableheader_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableheader_Autoscroll));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Class", StringUtil.RTrim( Gridpaginationbar_Class));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridpaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridpaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridpaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridpaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridpaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridpaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridpaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridpaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridpaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Previous", StringUtil.RTrim( Gridpaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Next", StringUtil.RTrim( Gridpaginationbar_Next));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Caption", StringUtil.RTrim( Gridpaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridpaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridpaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_set", StringUtil.RTrim( Ddo_grid_Filteredtextto_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filterisrange", StringUtil.RTrim( Ddo_grid_Filterisrange));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Allowmultipleselection", StringUtil.RTrim( Ddo_grid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistfixedvalues", StringUtil.RTrim( Ddo_grid_Datalistfixedvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE7M2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT7M2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("propostacontratoadmww")  ;
      }

      public override string GetPgmname( )
      {
         return "PropostaContratoAdmWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Propostas" ;
      }

      protected void WB7M0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingBottom", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tableheader.SetProperty("Width", Dvpanel_tableheader_Width);
            ucDvpanel_tableheader.SetProperty("AutoWidth", Dvpanel_tableheader_Autowidth);
            ucDvpanel_tableheader.SetProperty("AutoHeight", Dvpanel_tableheader_Autoheight);
            ucDvpanel_tableheader.SetProperty("Cls", Dvpanel_tableheader_Cls);
            ucDvpanel_tableheader.SetProperty("Title", Dvpanel_tableheader_Title);
            ucDvpanel_tableheader.SetProperty("Collapsible", Dvpanel_tableheader_Collapsible);
            ucDvpanel_tableheader.SetProperty("Collapsed", Dvpanel_tableheader_Collapsed);
            ucDvpanel_tableheader.SetProperty("ShowCollapseIcon", Dvpanel_tableheader_Showcollapseicon);
            ucDvpanel_tableheader.SetProperty("IconPosition", Dvpanel_tableheader_Iconposition);
            ucDvpanel_tableheader.SetProperty("AutoScroll", Dvpanel_tableheader_Autoscroll);
            ucDvpanel_tableheader.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableheader_Internalname, "DVPANEL_TABLEHEADERContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEHEADERContainer"+"TableHeader"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheadercontent_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupColoredActions", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "ButtonExcel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(114), 3, 0)+","+"null"+");", "Excel", bttBtnexport_Jsonclick, 5, "Exportar para Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_PropostaContratoAdmWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablerightheader_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucDdo_managefilters.SetProperty("IconType", Ddo_managefilters_Icontype);
            ucDdo_managefilters.SetProperty("Icon", Ddo_managefilters_Icon);
            ucDdo_managefilters.SetProperty("Caption", Ddo_managefilters_Caption);
            ucDdo_managefilters.SetProperty("Tooltip", Ddo_managefilters_Tooltip);
            ucDdo_managefilters.SetProperty("Cls", Ddo_managefilters_Cls);
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV32ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, "DDO_MANAGEFILTERSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablefilters_Internalname, 1, 0, "px", 0, "px", "TableFilters", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilterfulltext_Internalname, "Filter Full Text", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'" + sGXsfl_114_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_PropostaContratoAdmWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellAdvancedFiltersHidden", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAdvancedfilterscontainer_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;justify-content:flex-end;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfilters_Internalname, 1, 0, "px", 0, "px", "TableDynamicFiltersFlex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DynRowVisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfiltersrow1_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_PropostaContratoAdmWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'" + sGXsfl_114_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV16DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "", true, 0, "HLP_PropostaContratoAdmWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_PropostaContratoAdmWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_43_7M2( true) ;
         }
         else
         {
            wb_table1_43_7M2( false) ;
         }
         return  ;
      }

      protected void wb_table1_43_7M2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfiltersrow2_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_PropostaContratoAdmWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'" + sGXsfl_114_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV20DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "", true, 0, "HLP_PropostaContratoAdmWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_PropostaContratoAdmWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_68_7M2( true) ;
         }
         else
         {
            wb_table2_68_7M2( false) ;
         }
         return  ;
      }

      protected void wb_table2_68_7M2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfiltersrow3_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_PropostaContratoAdmWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'" + sGXsfl_114_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV24DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", "", true, 0, "HLP_PropostaContratoAdmWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_PropostaContratoAdmWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_93_7M2( true) ;
         }
         else
         {
            wb_table3_93_7M2( false) ;
         }
         return  ;
      }

      protected void wb_table3_93_7M2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl114( ) ;
         }
         if ( wbEnd == 114 )
         {
            wbEnd = 0;
            nRC_GXsfl_114 = (int)(nGXsfl_114_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGridpaginationbar.SetProperty("Class", Gridpaginationbar_Class);
            ucGridpaginationbar.SetProperty("ShowFirst", Gridpaginationbar_Showfirst);
            ucGridpaginationbar.SetProperty("ShowPrevious", Gridpaginationbar_Showprevious);
            ucGridpaginationbar.SetProperty("ShowNext", Gridpaginationbar_Shownext);
            ucGridpaginationbar.SetProperty("ShowLast", Gridpaginationbar_Showlast);
            ucGridpaginationbar.SetProperty("PagesToShow", Gridpaginationbar_Pagestoshow);
            ucGridpaginationbar.SetProperty("PagingButtonsPosition", Gridpaginationbar_Pagingbuttonsposition);
            ucGridpaginationbar.SetProperty("PagingCaptionPosition", Gridpaginationbar_Pagingcaptionposition);
            ucGridpaginationbar.SetProperty("EmptyGridClass", Gridpaginationbar_Emptygridclass);
            ucGridpaginationbar.SetProperty("RowsPerPageSelector", Gridpaginationbar_Rowsperpageselector);
            ucGridpaginationbar.SetProperty("RowsPerPageOptions", Gridpaginationbar_Rowsperpageoptions);
            ucGridpaginationbar.SetProperty("Previous", Gridpaginationbar_Previous);
            ucGridpaginationbar.SetProperty("Next", Gridpaginationbar_Next);
            ucGridpaginationbar.SetProperty("Caption", Gridpaginationbar_Caption);
            ucGridpaginationbar.SetProperty("EmptyGridCaption", Gridpaginationbar_Emptygridcaption);
            ucGridpaginationbar.SetProperty("RowsPerPageCaption", Gridpaginationbar_Rowsperpagecaption);
            ucGridpaginationbar.SetProperty("CurrentPage", AV58GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV59GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV60GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, "GRIDPAGINATIONBARContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_PropostaContratoAdmWW.htm");
            /* User Defined Control */
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("FilterIsRange", Ddo_grid_Filterisrange);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("AllowMultipleSelection", Ddo_grid_Allowmultipleselection);
            ucDdo_grid.SetProperty("DataListFixedValues", Ddo_grid_Datalistfixedvalues);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV56DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 114 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START7M2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_12-186073", 0) ;
            }
         }
         Form.Meta.addItem("description", " Propostas", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP7M0( ) ;
      }

      protected void WS7M2( )
      {
         START7M2( ) ;
         EVT7M2( ) ;
      }

      protected void EVT7M2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_MANAGEFILTERS.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_managefilters.Onoptionclicked */
                              E117M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E127M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E137M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E147M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E157M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E167M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E177M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E187M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E197M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E207M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E217M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E227M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E237M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_114_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_114_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_114_idx), 4, 0), 4, "0");
                              SubsflControlProps_1142( ) ;
                              AV93Reembolso = cgiGet( edtavReembolso_Internalname);
                              AssignAttri("", false, edtavReembolso_Internalname, AV93Reembolso);
                              A323PropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n323PropostaId = false;
                              A377ProcedimentosMedicosNome = cgiGet( edtProcedimentosMedicosNome_Internalname);
                              n377ProcedimentosMedicosNome = false;
                              A376ProcedimentosMedicosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtProcedimentosMedicosId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n376ProcedimentosMedicosId = false;
                              A325PropostaDescricao = cgiGet( edtPropostaDescricao_Internalname);
                              n325PropostaDescricao = false;
                              A326PropostaValor = context.localUtil.CToN( cgiGet( edtPropostaValor_Internalname), ",", ".");
                              n326PropostaValor = false;
                              A327PropostaCreatedAt = context.localUtil.CToT( cgiGet( edtPropostaCreatedAt_Internalname), 0);
                              n327PropostaCreatedAt = false;
                              A328PropostaCratedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaCratedBy_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n328PropostaCratedBy = false;
                              cmbPropostaStatus.Name = cmbPropostaStatus_Internalname;
                              cmbPropostaStatus.CurrentValue = cgiGet( cmbPropostaStatus_Internalname);
                              A329PropostaStatus = cgiGet( cmbPropostaStatus_Internalname);
                              n329PropostaStatus = false;
                              A227ContratoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtContratoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n227ContratoId = false;
                              A228ContratoNome = cgiGet( edtContratoNome_Internalname);
                              n228ContratoNome = false;
                              A330PropostaQuantidadeAprovadores = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaQuantidadeAprovadores_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n330PropostaQuantidadeAprovadores = false;
                              A345PropostaReprovacoesPermitidas = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaReprovacoesPermitidas_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n345PropostaReprovacoesPermitidas = false;
                              A341PropostaAprovacoes_F = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaAprovacoes_F_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n341PropostaAprovacoes_F = false;
                              A342PropostaReprovacoes_F = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaReprovacoes_F_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n342PropostaReprovacoes_F = false;
                              A343PropostaAprovacoesRestantes_F = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaAprovacoesRestantes_F_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A505PropostaPacienteClienteRazaoSocial = StringUtil.Upper( cgiGet( edtPropostaPacienteClienteRazaoSocial_Internalname));
                              n505PropostaPacienteClienteRazaoSocial = false;
                              cmbReembolsoStatusAtual_F.Name = cmbReembolsoStatusAtual_F_Internalname;
                              cmbReembolsoStatusAtual_F.CurrentValue = cgiGet( cmbReembolsoStatusAtual_F_Internalname);
                              A548ReembolsoStatusAtual_F = cgiGet( cmbReembolsoStatusAtual_F_Internalname);
                              n548ReembolsoStatusAtual_F = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E247M2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E257M2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E267M2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV13OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV14OrderedDsc )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV16DynamicFiltersSelector1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator1 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV17DynamicFiltersOperator1 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Propostatitulo1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTATITULO1"), AV18PropostaTitulo1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Contratonome1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATONOME1"), AV69ContratoNome1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV20DynamicFiltersSelector2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV21DynamicFiltersOperator2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Propostatitulo2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTATITULO2"), AV22PropostaTitulo2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Contratonome2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATONOME2"), AV70ContratoNome2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV24DynamicFiltersSelector3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV25DynamicFiltersOperator3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Propostatitulo3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTATITULO3"), AV26PropostaTitulo3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Contratonome3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATONOME3"), AV71ContratoNome3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE7M2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA7M2( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            init_web_controls( ) ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavFilterfulltext_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1142( ) ;
         while ( nGXsfl_114_idx <= nRC_GXsfl_114 )
         {
            sendrow_1142( ) ;
            nGXsfl_114_idx = ((subGrid_Islastpage==1)&&(nGXsfl_114_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_114_idx+1);
            sGXsfl_114_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_114_idx), 4, 0), 4, "0");
            SubsflControlProps_1142( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       string AV16DynamicFiltersSelector1 ,
                                       short AV17DynamicFiltersOperator1 ,
                                       string AV18PropostaTitulo1 ,
                                       string AV69ContratoNome1 ,
                                       string AV20DynamicFiltersSelector2 ,
                                       short AV21DynamicFiltersOperator2 ,
                                       string AV22PropostaTitulo2 ,
                                       string AV70ContratoNome2 ,
                                       string AV24DynamicFiltersSelector3 ,
                                       short AV25DynamicFiltersOperator3 ,
                                       string AV26PropostaTitulo3 ,
                                       string AV71ContratoNome3 ,
                                       short AV34ManageFiltersExecutionStep ,
                                       bool AV19DynamicFiltersEnabled2 ,
                                       bool AV23DynamicFiltersEnabled3 ,
                                       string AV96Pgmname ,
                                       string AV15FilterFullText ,
                                       string AV82TFProcedimentosMedicosNome ,
                                       string AV83TFProcedimentosMedicosNome_Sel ,
                                       string AV39TFPropostaDescricao ,
                                       string AV40TFPropostaDescricao_Sel ,
                                       decimal AV41TFPropostaValor ,
                                       decimal AV42TFPropostaValor_To ,
                                       string AV65TFContratoNome ,
                                       string AV66TFContratoNome_Sel ,
                                       string AV91TFPropostaPacienteClienteRazaoSocial ,
                                       string AV92TFPropostaPacienteClienteRazaoSocial_Sel ,
                                       GxSimpleCollection<string> AV95TFReembolsoStatusAtual_F_Sels ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV28DynamicFiltersIgnoreFirst ,
                                       bool AV27DynamicFiltersRemoving ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV84Context )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF7M2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV16DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV16DynamicFiltersSelector1);
            AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV17DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV20DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV20DynamicFiltersSelector2);
            AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV21DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV24DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV24DynamicFiltersSelector3);
            AssignAttri("", false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV25DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF7M2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV96Pgmname = "PropostaContratoAdmWW";
         edtavReembolso_Enabled = 0;
      }

      protected void RF7M2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 114;
         /* Execute user event: Refresh */
         E257M2 ();
         nGXsfl_114_idx = 1;
         sGXsfl_114_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_114_idx), 4, 0), 4, "0");
         SubsflControlProps_1142( ) ;
         bGXsfl_114_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar GridWithBorderColor WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1142( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A548ReembolsoStatusAtual_F ,
                                                 AV122Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels ,
                                                 AV98Propostacontratoadmwwds_2_dynamicfiltersselector1 ,
                                                 AV99Propostacontratoadmwwds_3_dynamicfiltersoperator1 ,
                                                 AV100Propostacontratoadmwwds_4_propostatitulo1 ,
                                                 AV101Propostacontratoadmwwds_5_contratonome1 ,
                                                 AV102Propostacontratoadmwwds_6_dynamicfiltersenabled2 ,
                                                 AV103Propostacontratoadmwwds_7_dynamicfiltersselector2 ,
                                                 AV104Propostacontratoadmwwds_8_dynamicfiltersoperator2 ,
                                                 AV105Propostacontratoadmwwds_9_propostatitulo2 ,
                                                 AV106Propostacontratoadmwwds_10_contratonome2 ,
                                                 AV107Propostacontratoadmwwds_11_dynamicfiltersenabled3 ,
                                                 AV108Propostacontratoadmwwds_12_dynamicfiltersselector3 ,
                                                 AV109Propostacontratoadmwwds_13_dynamicfiltersoperator3 ,
                                                 AV110Propostacontratoadmwwds_14_propostatitulo3 ,
                                                 AV111Propostacontratoadmwwds_15_contratonome3 ,
                                                 AV113Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel ,
                                                 AV112Propostacontratoadmwwds_16_tfprocedimentosmedicosnome ,
                                                 AV115Propostacontratoadmwwds_19_tfpropostadescricao_sel ,
                                                 AV114Propostacontratoadmwwds_18_tfpropostadescricao ,
                                                 AV116Propostacontratoadmwwds_20_tfpropostavalor ,
                                                 AV117Propostacontratoadmwwds_21_tfpropostavalor_to ,
                                                 AV119Propostacontratoadmwwds_23_tfcontratonome_sel ,
                                                 AV118Propostacontratoadmwwds_22_tfcontratonome ,
                                                 AV121Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel ,
                                                 AV120Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial ,
                                                 A324PropostaTitulo ,
                                                 A228ContratoNome ,
                                                 A377ProcedimentosMedicosNome ,
                                                 A325PropostaDescricao ,
                                                 A326PropostaValor ,
                                                 A505PropostaPacienteClienteRazaoSocial ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc ,
                                                 AV97Propostacontratoadmwwds_1_filterfulltext ,
                                                 AV122Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels.Count ,
                                                 A328PropostaCratedBy ,
                                                 AV6WWPContext.gxTpr_Secuserclienteid ,
                                                 A329PropostaStatus } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV97Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV97Propostacontratoadmwwds_1_filterfulltext), "%", "");
            lV97Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV97Propostacontratoadmwwds_1_filterfulltext), "%", "");
            lV97Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV97Propostacontratoadmwwds_1_filterfulltext), "%", "");
            lV97Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV97Propostacontratoadmwwds_1_filterfulltext), "%", "");
            lV97Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV97Propostacontratoadmwwds_1_filterfulltext), "%", "");
            lV97Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV97Propostacontratoadmwwds_1_filterfulltext), "%", "");
            lV97Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV97Propostacontratoadmwwds_1_filterfulltext), "%", "");
            lV97Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV97Propostacontratoadmwwds_1_filterfulltext), "%", "");
            lV97Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV97Propostacontratoadmwwds_1_filterfulltext), "%", "");
            lV100Propostacontratoadmwwds_4_propostatitulo1 = StringUtil.Concat( StringUtil.RTrim( AV100Propostacontratoadmwwds_4_propostatitulo1), "%", "");
            lV100Propostacontratoadmwwds_4_propostatitulo1 = StringUtil.Concat( StringUtil.RTrim( AV100Propostacontratoadmwwds_4_propostatitulo1), "%", "");
            lV101Propostacontratoadmwwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV101Propostacontratoadmwwds_5_contratonome1), "%", "");
            lV101Propostacontratoadmwwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV101Propostacontratoadmwwds_5_contratonome1), "%", "");
            lV105Propostacontratoadmwwds_9_propostatitulo2 = StringUtil.Concat( StringUtil.RTrim( AV105Propostacontratoadmwwds_9_propostatitulo2), "%", "");
            lV105Propostacontratoadmwwds_9_propostatitulo2 = StringUtil.Concat( StringUtil.RTrim( AV105Propostacontratoadmwwds_9_propostatitulo2), "%", "");
            lV106Propostacontratoadmwwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV106Propostacontratoadmwwds_10_contratonome2), "%", "");
            lV106Propostacontratoadmwwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV106Propostacontratoadmwwds_10_contratonome2), "%", "");
            lV110Propostacontratoadmwwds_14_propostatitulo3 = StringUtil.Concat( StringUtil.RTrim( AV110Propostacontratoadmwwds_14_propostatitulo3), "%", "");
            lV110Propostacontratoadmwwds_14_propostatitulo3 = StringUtil.Concat( StringUtil.RTrim( AV110Propostacontratoadmwwds_14_propostatitulo3), "%", "");
            lV111Propostacontratoadmwwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV111Propostacontratoadmwwds_15_contratonome3), "%", "");
            lV111Propostacontratoadmwwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV111Propostacontratoadmwwds_15_contratonome3), "%", "");
            lV112Propostacontratoadmwwds_16_tfprocedimentosmedicosnome = StringUtil.Concat( StringUtil.RTrim( AV112Propostacontratoadmwwds_16_tfprocedimentosmedicosnome), "%", "");
            lV114Propostacontratoadmwwds_18_tfpropostadescricao = StringUtil.Concat( StringUtil.RTrim( AV114Propostacontratoadmwwds_18_tfpropostadescricao), "%", "");
            lV118Propostacontratoadmwwds_22_tfcontratonome = StringUtil.Concat( StringUtil.RTrim( AV118Propostacontratoadmwwds_22_tfcontratonome), "%", "");
            lV120Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV120Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial), "%", "");
            /* Using cursor H007M7 */
            pr_default.execute(0, new Object[] {AV84Context.gxTpr_Userid, AV97Propostacontratoadmwwds_1_filterfulltext, lV97Propostacontratoadmwwds_1_filterfulltext, lV97Propostacontratoadmwwds_1_filterfulltext, lV97Propostacontratoadmwwds_1_filterfulltext, lV97Propostacontratoadmwwds_1_filterfulltext, lV97Propostacontratoadmwwds_1_filterfulltext, lV97Propostacontratoadmwwds_1_filterfulltext, lV97Propostacontratoadmwwds_1_filterfulltext, lV97Propostacontratoadmwwds_1_filterfulltext, lV97Propostacontratoadmwwds_1_filterfulltext, AV122Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels.Count, AV6WWPContext.gxTpr_Secuserclienteid, lV100Propostacontratoadmwwds_4_propostatitulo1, lV100Propostacontratoadmwwds_4_propostatitulo1, lV101Propostacontratoadmwwds_5_contratonome1, lV101Propostacontratoadmwwds_5_contratonome1, lV105Propostacontratoadmwwds_9_propostatitulo2, lV105Propostacontratoadmwwds_9_propostatitulo2, lV106Propostacontratoadmwwds_10_contratonome2, lV106Propostacontratoadmwwds_10_contratonome2, lV110Propostacontratoadmwwds_14_propostatitulo3, lV110Propostacontratoadmwwds_14_propostatitulo3, lV111Propostacontratoadmwwds_15_contratonome3, lV111Propostacontratoadmwwds_15_contratonome3, lV112Propostacontratoadmwwds_16_tfprocedimentosmedicosnome, AV113Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel, lV114Propostacontratoadmwwds_18_tfpropostadescricao, AV115Propostacontratoadmwwds_19_tfpropostadescricao_sel, AV116Propostacontratoadmwwds_20_tfpropostavalor, AV117Propostacontratoadmwwds_21_tfpropostavalor_to, lV118Propostacontratoadmwwds_22_tfcontratonome, AV119Propostacontratoadmwwds_23_tfcontratonome_sel, lV120Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial, AV121Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_114_idx = 1;
            sGXsfl_114_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_114_idx), 4, 0), 4, "0");
            SubsflControlProps_1142( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A504PropostaPacienteClienteId = H007M7_A504PropostaPacienteClienteId[0];
               n504PropostaPacienteClienteId = H007M7_n504PropostaPacienteClienteId[0];
               A324PropostaTitulo = H007M7_A324PropostaTitulo[0];
               n324PropostaTitulo = H007M7_n324PropostaTitulo[0];
               A505PropostaPacienteClienteRazaoSocial = H007M7_A505PropostaPacienteClienteRazaoSocial[0];
               n505PropostaPacienteClienteRazaoSocial = H007M7_n505PropostaPacienteClienteRazaoSocial[0];
               A345PropostaReprovacoesPermitidas = H007M7_A345PropostaReprovacoesPermitidas[0];
               n345PropostaReprovacoesPermitidas = H007M7_n345PropostaReprovacoesPermitidas[0];
               A228ContratoNome = H007M7_A228ContratoNome[0];
               n228ContratoNome = H007M7_n228ContratoNome[0];
               A227ContratoId = H007M7_A227ContratoId[0];
               n227ContratoId = H007M7_n227ContratoId[0];
               A329PropostaStatus = H007M7_A329PropostaStatus[0];
               n329PropostaStatus = H007M7_n329PropostaStatus[0];
               A328PropostaCratedBy = H007M7_A328PropostaCratedBy[0];
               n328PropostaCratedBy = H007M7_n328PropostaCratedBy[0];
               A327PropostaCreatedAt = H007M7_A327PropostaCreatedAt[0];
               n327PropostaCreatedAt = H007M7_n327PropostaCreatedAt[0];
               A326PropostaValor = H007M7_A326PropostaValor[0];
               n326PropostaValor = H007M7_n326PropostaValor[0];
               A325PropostaDescricao = H007M7_A325PropostaDescricao[0];
               n325PropostaDescricao = H007M7_n325PropostaDescricao[0];
               A376ProcedimentosMedicosId = H007M7_A376ProcedimentosMedicosId[0];
               n376ProcedimentosMedicosId = H007M7_n376ProcedimentosMedicosId[0];
               A377ProcedimentosMedicosNome = H007M7_A377ProcedimentosMedicosNome[0];
               n377ProcedimentosMedicosNome = H007M7_n377ProcedimentosMedicosNome[0];
               A323PropostaId = H007M7_A323PropostaId[0];
               n323PropostaId = H007M7_n323PropostaId[0];
               A548ReembolsoStatusAtual_F = H007M7_A548ReembolsoStatusAtual_F[0];
               n548ReembolsoStatusAtual_F = H007M7_n548ReembolsoStatusAtual_F[0];
               A342PropostaReprovacoes_F = H007M7_A342PropostaReprovacoes_F[0];
               n342PropostaReprovacoes_F = H007M7_n342PropostaReprovacoes_F[0];
               A40000GXC1 = H007M7_A40000GXC1[0];
               n40000GXC1 = H007M7_n40000GXC1[0];
               A341PropostaAprovacoes_F = H007M7_A341PropostaAprovacoes_F[0];
               n341PropostaAprovacoes_F = H007M7_n341PropostaAprovacoes_F[0];
               A330PropostaQuantidadeAprovadores = H007M7_A330PropostaQuantidadeAprovadores[0];
               n330PropostaQuantidadeAprovadores = H007M7_n330PropostaQuantidadeAprovadores[0];
               A505PropostaPacienteClienteRazaoSocial = H007M7_A505PropostaPacienteClienteRazaoSocial[0];
               n505PropostaPacienteClienteRazaoSocial = H007M7_n505PropostaPacienteClienteRazaoSocial[0];
               A228ContratoNome = H007M7_A228ContratoNome[0];
               n228ContratoNome = H007M7_n228ContratoNome[0];
               A377ProcedimentosMedicosNome = H007M7_A377ProcedimentosMedicosNome[0];
               n377ProcedimentosMedicosNome = H007M7_n377ProcedimentosMedicosNome[0];
               A548ReembolsoStatusAtual_F = H007M7_A548ReembolsoStatusAtual_F[0];
               n548ReembolsoStatusAtual_F = H007M7_n548ReembolsoStatusAtual_F[0];
               A341PropostaAprovacoes_F = H007M7_A341PropostaAprovacoes_F[0];
               n341PropostaAprovacoes_F = H007M7_n341PropostaAprovacoes_F[0];
               A342PropostaReprovacoes_F = H007M7_A342PropostaReprovacoes_F[0];
               n342PropostaReprovacoes_F = H007M7_n342PropostaReprovacoes_F[0];
               A40000GXC1 = H007M7_A40000GXC1[0];
               n40000GXC1 = H007M7_n40000GXC1[0];
               A343PropostaAprovacoesRestantes_F = (short)(A330PropostaQuantidadeAprovadores-A341PropostaAprovacoes_F);
               /* Execute user event: Grid.Load */
               E267M2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 114;
            WB7M0( ) ;
         }
         bGXsfl_114_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes7M2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV96Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV96Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCONTEXT", AV84Context);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCONTEXT", AV84Context);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vCONTEXT", GetSecureSignedToken( "", AV84Context, context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         AV97Propostacontratoadmwwds_1_filterfulltext = AV15FilterFullText;
         AV98Propostacontratoadmwwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV99Propostacontratoadmwwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV100Propostacontratoadmwwds_4_propostatitulo1 = AV18PropostaTitulo1;
         AV101Propostacontratoadmwwds_5_contratonome1 = AV69ContratoNome1;
         AV102Propostacontratoadmwwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV103Propostacontratoadmwwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV104Propostacontratoadmwwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV105Propostacontratoadmwwds_9_propostatitulo2 = AV22PropostaTitulo2;
         AV106Propostacontratoadmwwds_10_contratonome2 = AV70ContratoNome2;
         AV107Propostacontratoadmwwds_11_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV108Propostacontratoadmwwds_12_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV109Propostacontratoadmwwds_13_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV110Propostacontratoadmwwds_14_propostatitulo3 = AV26PropostaTitulo3;
         AV111Propostacontratoadmwwds_15_contratonome3 = AV71ContratoNome3;
         AV112Propostacontratoadmwwds_16_tfprocedimentosmedicosnome = AV82TFProcedimentosMedicosNome;
         AV113Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel = AV83TFProcedimentosMedicosNome_Sel;
         AV114Propostacontratoadmwwds_18_tfpropostadescricao = AV39TFPropostaDescricao;
         AV115Propostacontratoadmwwds_19_tfpropostadescricao_sel = AV40TFPropostaDescricao_Sel;
         AV116Propostacontratoadmwwds_20_tfpropostavalor = AV41TFPropostaValor;
         AV117Propostacontratoadmwwds_21_tfpropostavalor_to = AV42TFPropostaValor_To;
         AV118Propostacontratoadmwwds_22_tfcontratonome = AV65TFContratoNome;
         AV119Propostacontratoadmwwds_23_tfcontratonome_sel = AV66TFContratoNome_Sel;
         AV120Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial = AV91TFPropostaPacienteClienteRazaoSocial;
         AV121Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel = AV92TFPropostaPacienteClienteRazaoSocial_Sel;
         AV122Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels = AV95TFReembolsoStatusAtual_F_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A548ReembolsoStatusAtual_F ,
                                              AV122Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels ,
                                              AV98Propostacontratoadmwwds_2_dynamicfiltersselector1 ,
                                              AV99Propostacontratoadmwwds_3_dynamicfiltersoperator1 ,
                                              AV100Propostacontratoadmwwds_4_propostatitulo1 ,
                                              AV101Propostacontratoadmwwds_5_contratonome1 ,
                                              AV102Propostacontratoadmwwds_6_dynamicfiltersenabled2 ,
                                              AV103Propostacontratoadmwwds_7_dynamicfiltersselector2 ,
                                              AV104Propostacontratoadmwwds_8_dynamicfiltersoperator2 ,
                                              AV105Propostacontratoadmwwds_9_propostatitulo2 ,
                                              AV106Propostacontratoadmwwds_10_contratonome2 ,
                                              AV107Propostacontratoadmwwds_11_dynamicfiltersenabled3 ,
                                              AV108Propostacontratoadmwwds_12_dynamicfiltersselector3 ,
                                              AV109Propostacontratoadmwwds_13_dynamicfiltersoperator3 ,
                                              AV110Propostacontratoadmwwds_14_propostatitulo3 ,
                                              AV111Propostacontratoadmwwds_15_contratonome3 ,
                                              AV113Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel ,
                                              AV112Propostacontratoadmwwds_16_tfprocedimentosmedicosnome ,
                                              AV115Propostacontratoadmwwds_19_tfpropostadescricao_sel ,
                                              AV114Propostacontratoadmwwds_18_tfpropostadescricao ,
                                              AV116Propostacontratoadmwwds_20_tfpropostavalor ,
                                              AV117Propostacontratoadmwwds_21_tfpropostavalor_to ,
                                              AV119Propostacontratoadmwwds_23_tfcontratonome_sel ,
                                              AV118Propostacontratoadmwwds_22_tfcontratonome ,
                                              AV121Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel ,
                                              AV120Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial ,
                                              A324PropostaTitulo ,
                                              A228ContratoNome ,
                                              A377ProcedimentosMedicosNome ,
                                              A325PropostaDescricao ,
                                              A326PropostaValor ,
                                              A505PropostaPacienteClienteRazaoSocial ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc ,
                                              AV97Propostacontratoadmwwds_1_filterfulltext ,
                                              AV122Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels.Count ,
                                              A328PropostaCratedBy ,
                                              AV6WWPContext.gxTpr_Secuserclienteid ,
                                              A329PropostaStatus } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV97Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV97Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV97Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV97Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV97Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV97Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV97Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV97Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV97Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV97Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV97Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV97Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV97Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV97Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV97Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV97Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV97Propostacontratoadmwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV97Propostacontratoadmwwds_1_filterfulltext), "%", "");
         lV100Propostacontratoadmwwds_4_propostatitulo1 = StringUtil.Concat( StringUtil.RTrim( AV100Propostacontratoadmwwds_4_propostatitulo1), "%", "");
         lV100Propostacontratoadmwwds_4_propostatitulo1 = StringUtil.Concat( StringUtil.RTrim( AV100Propostacontratoadmwwds_4_propostatitulo1), "%", "");
         lV101Propostacontratoadmwwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV101Propostacontratoadmwwds_5_contratonome1), "%", "");
         lV101Propostacontratoadmwwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV101Propostacontratoadmwwds_5_contratonome1), "%", "");
         lV105Propostacontratoadmwwds_9_propostatitulo2 = StringUtil.Concat( StringUtil.RTrim( AV105Propostacontratoadmwwds_9_propostatitulo2), "%", "");
         lV105Propostacontratoadmwwds_9_propostatitulo2 = StringUtil.Concat( StringUtil.RTrim( AV105Propostacontratoadmwwds_9_propostatitulo2), "%", "");
         lV106Propostacontratoadmwwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV106Propostacontratoadmwwds_10_contratonome2), "%", "");
         lV106Propostacontratoadmwwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV106Propostacontratoadmwwds_10_contratonome2), "%", "");
         lV110Propostacontratoadmwwds_14_propostatitulo3 = StringUtil.Concat( StringUtil.RTrim( AV110Propostacontratoadmwwds_14_propostatitulo3), "%", "");
         lV110Propostacontratoadmwwds_14_propostatitulo3 = StringUtil.Concat( StringUtil.RTrim( AV110Propostacontratoadmwwds_14_propostatitulo3), "%", "");
         lV111Propostacontratoadmwwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV111Propostacontratoadmwwds_15_contratonome3), "%", "");
         lV111Propostacontratoadmwwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV111Propostacontratoadmwwds_15_contratonome3), "%", "");
         lV112Propostacontratoadmwwds_16_tfprocedimentosmedicosnome = StringUtil.Concat( StringUtil.RTrim( AV112Propostacontratoadmwwds_16_tfprocedimentosmedicosnome), "%", "");
         lV114Propostacontratoadmwwds_18_tfpropostadescricao = StringUtil.Concat( StringUtil.RTrim( AV114Propostacontratoadmwwds_18_tfpropostadescricao), "%", "");
         lV118Propostacontratoadmwwds_22_tfcontratonome = StringUtil.Concat( StringUtil.RTrim( AV118Propostacontratoadmwwds_22_tfcontratonome), "%", "");
         lV120Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV120Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial), "%", "");
         /* Using cursor H007M13 */
         pr_default.execute(1, new Object[] {AV84Context.gxTpr_Userid, AV97Propostacontratoadmwwds_1_filterfulltext, lV97Propostacontratoadmwwds_1_filterfulltext, lV97Propostacontratoadmwwds_1_filterfulltext, lV97Propostacontratoadmwwds_1_filterfulltext, lV97Propostacontratoadmwwds_1_filterfulltext, lV97Propostacontratoadmwwds_1_filterfulltext, lV97Propostacontratoadmwwds_1_filterfulltext, lV97Propostacontratoadmwwds_1_filterfulltext, lV97Propostacontratoadmwwds_1_filterfulltext, lV97Propostacontratoadmwwds_1_filterfulltext, AV122Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels.Count, AV6WWPContext.gxTpr_Secuserclienteid, lV100Propostacontratoadmwwds_4_propostatitulo1, lV100Propostacontratoadmwwds_4_propostatitulo1, lV101Propostacontratoadmwwds_5_contratonome1, lV101Propostacontratoadmwwds_5_contratonome1, lV105Propostacontratoadmwwds_9_propostatitulo2, lV105Propostacontratoadmwwds_9_propostatitulo2, lV106Propostacontratoadmwwds_10_contratonome2, lV106Propostacontratoadmwwds_10_contratonome2, lV110Propostacontratoadmwwds_14_propostatitulo3, lV110Propostacontratoadmwwds_14_propostatitulo3, lV111Propostacontratoadmwwds_15_contratonome3, lV111Propostacontratoadmwwds_15_contratonome3, lV112Propostacontratoadmwwds_16_tfprocedimentosmedicosnome, AV113Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel, lV114Propostacontratoadmwwds_18_tfpropostadescricao, AV115Propostacontratoadmwwds_19_tfpropostadescricao_sel, AV116Propostacontratoadmwwds_20_tfpropostavalor, AV117Propostacontratoadmwwds_21_tfpropostavalor_to, lV118Propostacontratoadmwwds_22_tfcontratonome, AV119Propostacontratoadmwwds_23_tfcontratonome_sel, lV120Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial, AV121Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel});
         GRID_nRecordCount = H007M13_AGRID_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID_nRecordCount) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         AV97Propostacontratoadmwwds_1_filterfulltext = AV15FilterFullText;
         AV98Propostacontratoadmwwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV99Propostacontratoadmwwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV100Propostacontratoadmwwds_4_propostatitulo1 = AV18PropostaTitulo1;
         AV101Propostacontratoadmwwds_5_contratonome1 = AV69ContratoNome1;
         AV102Propostacontratoadmwwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV103Propostacontratoadmwwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV104Propostacontratoadmwwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV105Propostacontratoadmwwds_9_propostatitulo2 = AV22PropostaTitulo2;
         AV106Propostacontratoadmwwds_10_contratonome2 = AV70ContratoNome2;
         AV107Propostacontratoadmwwds_11_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV108Propostacontratoadmwwds_12_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV109Propostacontratoadmwwds_13_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV110Propostacontratoadmwwds_14_propostatitulo3 = AV26PropostaTitulo3;
         AV111Propostacontratoadmwwds_15_contratonome3 = AV71ContratoNome3;
         AV112Propostacontratoadmwwds_16_tfprocedimentosmedicosnome = AV82TFProcedimentosMedicosNome;
         AV113Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel = AV83TFProcedimentosMedicosNome_Sel;
         AV114Propostacontratoadmwwds_18_tfpropostadescricao = AV39TFPropostaDescricao;
         AV115Propostacontratoadmwwds_19_tfpropostadescricao_sel = AV40TFPropostaDescricao_Sel;
         AV116Propostacontratoadmwwds_20_tfpropostavalor = AV41TFPropostaValor;
         AV117Propostacontratoadmwwds_21_tfpropostavalor_to = AV42TFPropostaValor_To;
         AV118Propostacontratoadmwwds_22_tfcontratonome = AV65TFContratoNome;
         AV119Propostacontratoadmwwds_23_tfcontratonome_sel = AV66TFContratoNome_Sel;
         AV120Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial = AV91TFPropostaPacienteClienteRazaoSocial;
         AV121Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel = AV92TFPropostaPacienteClienteRazaoSocial_Sel;
         AV122Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels = AV95TFReembolsoStatusAtual_F_Sels;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18PropostaTitulo1, AV69ContratoNome1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22PropostaTitulo2, AV70ContratoNome2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26PropostaTitulo3, AV71ContratoNome3, AV34ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV96Pgmname, AV15FilterFullText, AV82TFProcedimentosMedicosNome, AV83TFProcedimentosMedicosNome_Sel, AV39TFPropostaDescricao, AV40TFPropostaDescricao_Sel, AV41TFPropostaValor, AV42TFPropostaValor_To, AV65TFContratoNome, AV66TFContratoNome_Sel, AV91TFPropostaPacienteClienteRazaoSocial, AV92TFPropostaPacienteClienteRazaoSocial_Sel, AV95TFReembolsoStatusAtual_F_Sels, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, AV84Context) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV97Propostacontratoadmwwds_1_filterfulltext = AV15FilterFullText;
         AV98Propostacontratoadmwwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV99Propostacontratoadmwwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV100Propostacontratoadmwwds_4_propostatitulo1 = AV18PropostaTitulo1;
         AV101Propostacontratoadmwwds_5_contratonome1 = AV69ContratoNome1;
         AV102Propostacontratoadmwwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV103Propostacontratoadmwwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV104Propostacontratoadmwwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV105Propostacontratoadmwwds_9_propostatitulo2 = AV22PropostaTitulo2;
         AV106Propostacontratoadmwwds_10_contratonome2 = AV70ContratoNome2;
         AV107Propostacontratoadmwwds_11_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV108Propostacontratoadmwwds_12_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV109Propostacontratoadmwwds_13_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV110Propostacontratoadmwwds_14_propostatitulo3 = AV26PropostaTitulo3;
         AV111Propostacontratoadmwwds_15_contratonome3 = AV71ContratoNome3;
         AV112Propostacontratoadmwwds_16_tfprocedimentosmedicosnome = AV82TFProcedimentosMedicosNome;
         AV113Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel = AV83TFProcedimentosMedicosNome_Sel;
         AV114Propostacontratoadmwwds_18_tfpropostadescricao = AV39TFPropostaDescricao;
         AV115Propostacontratoadmwwds_19_tfpropostadescricao_sel = AV40TFPropostaDescricao_Sel;
         AV116Propostacontratoadmwwds_20_tfpropostavalor = AV41TFPropostaValor;
         AV117Propostacontratoadmwwds_21_tfpropostavalor_to = AV42TFPropostaValor_To;
         AV118Propostacontratoadmwwds_22_tfcontratonome = AV65TFContratoNome;
         AV119Propostacontratoadmwwds_23_tfcontratonome_sel = AV66TFContratoNome_Sel;
         AV120Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial = AV91TFPropostaPacienteClienteRazaoSocial;
         AV121Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel = AV92TFPropostaPacienteClienteRazaoSocial_Sel;
         AV122Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels = AV95TFReembolsoStatusAtual_F_Sels;
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18PropostaTitulo1, AV69ContratoNome1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22PropostaTitulo2, AV70ContratoNome2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26PropostaTitulo3, AV71ContratoNome3, AV34ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV96Pgmname, AV15FilterFullText, AV82TFProcedimentosMedicosNome, AV83TFProcedimentosMedicosNome_Sel, AV39TFPropostaDescricao, AV40TFPropostaDescricao_Sel, AV41TFPropostaValor, AV42TFPropostaValor_To, AV65TFContratoNome, AV66TFContratoNome_Sel, AV91TFPropostaPacienteClienteRazaoSocial, AV92TFPropostaPacienteClienteRazaoSocial_Sel, AV95TFReembolsoStatusAtual_F_Sels, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, AV84Context) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV97Propostacontratoadmwwds_1_filterfulltext = AV15FilterFullText;
         AV98Propostacontratoadmwwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV99Propostacontratoadmwwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV100Propostacontratoadmwwds_4_propostatitulo1 = AV18PropostaTitulo1;
         AV101Propostacontratoadmwwds_5_contratonome1 = AV69ContratoNome1;
         AV102Propostacontratoadmwwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV103Propostacontratoadmwwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV104Propostacontratoadmwwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV105Propostacontratoadmwwds_9_propostatitulo2 = AV22PropostaTitulo2;
         AV106Propostacontratoadmwwds_10_contratonome2 = AV70ContratoNome2;
         AV107Propostacontratoadmwwds_11_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV108Propostacontratoadmwwds_12_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV109Propostacontratoadmwwds_13_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV110Propostacontratoadmwwds_14_propostatitulo3 = AV26PropostaTitulo3;
         AV111Propostacontratoadmwwds_15_contratonome3 = AV71ContratoNome3;
         AV112Propostacontratoadmwwds_16_tfprocedimentosmedicosnome = AV82TFProcedimentosMedicosNome;
         AV113Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel = AV83TFProcedimentosMedicosNome_Sel;
         AV114Propostacontratoadmwwds_18_tfpropostadescricao = AV39TFPropostaDescricao;
         AV115Propostacontratoadmwwds_19_tfpropostadescricao_sel = AV40TFPropostaDescricao_Sel;
         AV116Propostacontratoadmwwds_20_tfpropostavalor = AV41TFPropostaValor;
         AV117Propostacontratoadmwwds_21_tfpropostavalor_to = AV42TFPropostaValor_To;
         AV118Propostacontratoadmwwds_22_tfcontratonome = AV65TFContratoNome;
         AV119Propostacontratoadmwwds_23_tfcontratonome_sel = AV66TFContratoNome_Sel;
         AV120Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial = AV91TFPropostaPacienteClienteRazaoSocial;
         AV121Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel = AV92TFPropostaPacienteClienteRazaoSocial_Sel;
         AV122Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels = AV95TFReembolsoStatusAtual_F_Sels;
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18PropostaTitulo1, AV69ContratoNome1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22PropostaTitulo2, AV70ContratoNome2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26PropostaTitulo3, AV71ContratoNome3, AV34ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV96Pgmname, AV15FilterFullText, AV82TFProcedimentosMedicosNome, AV83TFProcedimentosMedicosNome_Sel, AV39TFPropostaDescricao, AV40TFPropostaDescricao_Sel, AV41TFPropostaValor, AV42TFPropostaValor_To, AV65TFContratoNome, AV66TFContratoNome_Sel, AV91TFPropostaPacienteClienteRazaoSocial, AV92TFPropostaPacienteClienteRazaoSocial_Sel, AV95TFReembolsoStatusAtual_F_Sels, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, AV84Context) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV97Propostacontratoadmwwds_1_filterfulltext = AV15FilterFullText;
         AV98Propostacontratoadmwwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV99Propostacontratoadmwwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV100Propostacontratoadmwwds_4_propostatitulo1 = AV18PropostaTitulo1;
         AV101Propostacontratoadmwwds_5_contratonome1 = AV69ContratoNome1;
         AV102Propostacontratoadmwwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV103Propostacontratoadmwwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV104Propostacontratoadmwwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV105Propostacontratoadmwwds_9_propostatitulo2 = AV22PropostaTitulo2;
         AV106Propostacontratoadmwwds_10_contratonome2 = AV70ContratoNome2;
         AV107Propostacontratoadmwwds_11_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV108Propostacontratoadmwwds_12_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV109Propostacontratoadmwwds_13_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV110Propostacontratoadmwwds_14_propostatitulo3 = AV26PropostaTitulo3;
         AV111Propostacontratoadmwwds_15_contratonome3 = AV71ContratoNome3;
         AV112Propostacontratoadmwwds_16_tfprocedimentosmedicosnome = AV82TFProcedimentosMedicosNome;
         AV113Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel = AV83TFProcedimentosMedicosNome_Sel;
         AV114Propostacontratoadmwwds_18_tfpropostadescricao = AV39TFPropostaDescricao;
         AV115Propostacontratoadmwwds_19_tfpropostadescricao_sel = AV40TFPropostaDescricao_Sel;
         AV116Propostacontratoadmwwds_20_tfpropostavalor = AV41TFPropostaValor;
         AV117Propostacontratoadmwwds_21_tfpropostavalor_to = AV42TFPropostaValor_To;
         AV118Propostacontratoadmwwds_22_tfcontratonome = AV65TFContratoNome;
         AV119Propostacontratoadmwwds_23_tfcontratonome_sel = AV66TFContratoNome_Sel;
         AV120Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial = AV91TFPropostaPacienteClienteRazaoSocial;
         AV121Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel = AV92TFPropostaPacienteClienteRazaoSocial_Sel;
         AV122Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels = AV95TFReembolsoStatusAtual_F_Sels;
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18PropostaTitulo1, AV69ContratoNome1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22PropostaTitulo2, AV70ContratoNome2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26PropostaTitulo3, AV71ContratoNome3, AV34ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV96Pgmname, AV15FilterFullText, AV82TFProcedimentosMedicosNome, AV83TFProcedimentosMedicosNome_Sel, AV39TFPropostaDescricao, AV40TFPropostaDescricao_Sel, AV41TFPropostaValor, AV42TFPropostaValor_To, AV65TFContratoNome, AV66TFContratoNome_Sel, AV91TFPropostaPacienteClienteRazaoSocial, AV92TFPropostaPacienteClienteRazaoSocial_Sel, AV95TFReembolsoStatusAtual_F_Sels, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, AV84Context) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV97Propostacontratoadmwwds_1_filterfulltext = AV15FilterFullText;
         AV98Propostacontratoadmwwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV99Propostacontratoadmwwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV100Propostacontratoadmwwds_4_propostatitulo1 = AV18PropostaTitulo1;
         AV101Propostacontratoadmwwds_5_contratonome1 = AV69ContratoNome1;
         AV102Propostacontratoadmwwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV103Propostacontratoadmwwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV104Propostacontratoadmwwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV105Propostacontratoadmwwds_9_propostatitulo2 = AV22PropostaTitulo2;
         AV106Propostacontratoadmwwds_10_contratonome2 = AV70ContratoNome2;
         AV107Propostacontratoadmwwds_11_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV108Propostacontratoadmwwds_12_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV109Propostacontratoadmwwds_13_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV110Propostacontratoadmwwds_14_propostatitulo3 = AV26PropostaTitulo3;
         AV111Propostacontratoadmwwds_15_contratonome3 = AV71ContratoNome3;
         AV112Propostacontratoadmwwds_16_tfprocedimentosmedicosnome = AV82TFProcedimentosMedicosNome;
         AV113Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel = AV83TFProcedimentosMedicosNome_Sel;
         AV114Propostacontratoadmwwds_18_tfpropostadescricao = AV39TFPropostaDescricao;
         AV115Propostacontratoadmwwds_19_tfpropostadescricao_sel = AV40TFPropostaDescricao_Sel;
         AV116Propostacontratoadmwwds_20_tfpropostavalor = AV41TFPropostaValor;
         AV117Propostacontratoadmwwds_21_tfpropostavalor_to = AV42TFPropostaValor_To;
         AV118Propostacontratoadmwwds_22_tfcontratonome = AV65TFContratoNome;
         AV119Propostacontratoadmwwds_23_tfcontratonome_sel = AV66TFContratoNome_Sel;
         AV120Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial = AV91TFPropostaPacienteClienteRazaoSocial;
         AV121Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel = AV92TFPropostaPacienteClienteRazaoSocial_Sel;
         AV122Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels = AV95TFReembolsoStatusAtual_F_Sels;
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18PropostaTitulo1, AV69ContratoNome1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22PropostaTitulo2, AV70ContratoNome2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26PropostaTitulo3, AV71ContratoNome3, AV34ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV96Pgmname, AV15FilterFullText, AV82TFProcedimentosMedicosNome, AV83TFProcedimentosMedicosNome_Sel, AV39TFPropostaDescricao, AV40TFPropostaDescricao_Sel, AV41TFPropostaValor, AV42TFPropostaValor_To, AV65TFContratoNome, AV66TFContratoNome_Sel, AV91TFPropostaPacienteClienteRazaoSocial, AV92TFPropostaPacienteClienteRazaoSocial_Sel, AV95TFReembolsoStatusAtual_F_Sels, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, AV84Context) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV96Pgmname = "PropostaContratoAdmWW";
         edtavReembolso_Enabled = 0;
         edtPropostaId_Enabled = 0;
         edtProcedimentosMedicosNome_Enabled = 0;
         edtProcedimentosMedicosId_Enabled = 0;
         edtPropostaDescricao_Enabled = 0;
         edtPropostaValor_Enabled = 0;
         edtPropostaCreatedAt_Enabled = 0;
         edtPropostaCratedBy_Enabled = 0;
         cmbPropostaStatus.Enabled = 0;
         edtContratoId_Enabled = 0;
         edtContratoNome_Enabled = 0;
         edtPropostaQuantidadeAprovadores_Enabled = 0;
         edtPropostaReprovacoesPermitidas_Enabled = 0;
         edtPropostaAprovacoes_F_Enabled = 0;
         edtPropostaReprovacoes_F_Enabled = 0;
         edtPropostaAprovacoesRestantes_F_Enabled = 0;
         edtPropostaPacienteClienteRazaoSocial_Enabled = 0;
         cmbReembolsoStatusAtual_F.Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP7M0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E247M2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV32ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV56DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_114 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_114"), ",", "."), 18, MidpointRounding.ToEven));
            AV58GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV59GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV60GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_managefilters_Icontype = cgiGet( "DDO_MANAGEFILTERS_Icontype");
            Ddo_managefilters_Icon = cgiGet( "DDO_MANAGEFILTERS_Icon");
            Ddo_managefilters_Tooltip = cgiGet( "DDO_MANAGEFILTERS_Tooltip");
            Ddo_managefilters_Cls = cgiGet( "DDO_MANAGEFILTERS_Cls");
            Dvpanel_tableheader_Width = cgiGet( "DVPANEL_TABLEHEADER_Width");
            Dvpanel_tableheader_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Autowidth"));
            Dvpanel_tableheader_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Autoheight"));
            Dvpanel_tableheader_Cls = cgiGet( "DVPANEL_TABLEHEADER_Cls");
            Dvpanel_tableheader_Title = cgiGet( "DVPANEL_TABLEHEADER_Title");
            Dvpanel_tableheader_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Collapsible"));
            Dvpanel_tableheader_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Collapsed"));
            Dvpanel_tableheader_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Showcollapseicon"));
            Dvpanel_tableheader_Iconposition = cgiGet( "DVPANEL_TABLEHEADER_Iconposition");
            Dvpanel_tableheader_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Autoscroll"));
            Gridpaginationbar_Class = cgiGet( "GRIDPAGINATIONBAR_Class");
            Gridpaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showfirst"));
            Gridpaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showprevious"));
            Gridpaginationbar_Shownext = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Shownext"));
            Gridpaginationbar_Showlast = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showlast"));
            Gridpaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Pagestoshow"), ",", "."), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Pagingbuttonsposition = cgiGet( "GRIDPAGINATIONBAR_Pagingbuttonsposition");
            Gridpaginationbar_Pagingcaptionposition = cgiGet( "GRIDPAGINATIONBAR_Pagingcaptionposition");
            Gridpaginationbar_Emptygridclass = cgiGet( "GRIDPAGINATIONBAR_Emptygridclass");
            Gridpaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselector"));
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Rowsperpageoptions = cgiGet( "GRIDPAGINATIONBAR_Rowsperpageoptions");
            Gridpaginationbar_Previous = cgiGet( "GRIDPAGINATIONBAR_Previous");
            Gridpaginationbar_Next = cgiGet( "GRIDPAGINATIONBAR_Next");
            Gridpaginationbar_Caption = cgiGet( "GRIDPAGINATIONBAR_Caption");
            Gridpaginationbar_Emptygridcaption = cgiGet( "GRIDPAGINATIONBAR_Emptygridcaption");
            Gridpaginationbar_Rowsperpagecaption = cgiGet( "GRIDPAGINATIONBAR_Rowsperpagecaption");
            Ddo_grid_Caption = cgiGet( "DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( "DDO_GRID_Filteredtext_set");
            Ddo_grid_Filteredtextto_set = cgiGet( "DDO_GRID_Filteredtextto_set");
            Ddo_grid_Selectedvalue_set = cgiGet( "DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( "DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( "DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( "DDO_GRID_Filtertype");
            Ddo_grid_Filterisrange = cgiGet( "DDO_GRID_Filterisrange");
            Ddo_grid_Includedatalist = cgiGet( "DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( "DDO_GRID_Datalisttype");
            Ddo_grid_Allowmultipleselection = cgiGet( "DDO_GRID_Allowmultipleselection");
            Ddo_grid_Datalistfixedvalues = cgiGet( "DDO_GRID_Datalistfixedvalues");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Ddo_grid_Format = cgiGet( "DDO_GRID_Format");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV15FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            cmbavDynamicfiltersselector1.Name = cmbavDynamicfiltersselector1_Internalname;
            cmbavDynamicfiltersselector1.CurrentValue = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AV16DynamicFiltersSelector1 = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
            cmbavDynamicfiltersoperator1.Name = cmbavDynamicfiltersoperator1_Internalname;
            cmbavDynamicfiltersoperator1.CurrentValue = cgiGet( cmbavDynamicfiltersoperator1_Internalname);
            AV17DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator1_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
            AV18PropostaTitulo1 = cgiGet( edtavPropostatitulo1_Internalname);
            AssignAttri("", false, "AV18PropostaTitulo1", AV18PropostaTitulo1);
            AV69ContratoNome1 = cgiGet( edtavContratonome1_Internalname);
            AssignAttri("", false, "AV69ContratoNome1", AV69ContratoNome1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV20DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV21DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
            AV22PropostaTitulo2 = cgiGet( edtavPropostatitulo2_Internalname);
            AssignAttri("", false, "AV22PropostaTitulo2", AV22PropostaTitulo2);
            AV70ContratoNome2 = cgiGet( edtavContratonome2_Internalname);
            AssignAttri("", false, "AV70ContratoNome2", AV70ContratoNome2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV24DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV25DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
            AV26PropostaTitulo3 = cgiGet( edtavPropostatitulo3_Internalname);
            AssignAttri("", false, "AV26PropostaTitulo3", AV26PropostaTitulo3);
            AV71ContratoNome3 = cgiGet( edtavContratonome3_Internalname);
            AssignAttri("", false, "AV71ContratoNome3", AV71ContratoNome3);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV13OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV14OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV16DynamicFiltersSelector1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV17DynamicFiltersOperator1 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTATITULO1"), AV18PropostaTitulo1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATONOME1"), AV69ContratoNome1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV20DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV21DynamicFiltersOperator2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTATITULO2"), AV22PropostaTitulo2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATONOME2"), AV70ContratoNome2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV24DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV25DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROPOSTATITULO3"), AV26PropostaTitulo3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATONOME3"), AV71ContratoNome3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E247M2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E247M2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtWWPContext1 = AV84Context;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  GXt_SdtWWPContext1) ;
         AV84Context = GXt_SdtWWPContext1;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         if ( StringUtil.StrCmp(AV7HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         lblJsdynamicfilters_Caption = "";
         AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         AV16DynamicFiltersSelector1 = "PROPOSTATITULO";
         AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV20DynamicFiltersSelector2 = "PROPOSTATITULO";
         AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV24DynamicFiltersSelector3 = "PROPOSTATITULO";
         AssignAttri("", false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         imgAdddynamicfilters1_Jsonclick = StringUtil.Format( "WWPDynFilterShow_AL('%1', 2, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Jsonclick", imgAdddynamicfilters1_Jsonclick, true);
         imgRemovedynamicfilters1_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Jsonclick", imgRemovedynamicfilters1_Jsonclick, true);
         imgAdddynamicfilters2_Jsonclick = StringUtil.Format( "WWPDynFilterShow_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Jsonclick", imgAdddynamicfilters2_Jsonclick, true);
         imgRemovedynamicfilters2_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Jsonclick", imgRemovedynamicfilters2_Jsonclick, true);
         imgRemovedynamicfilters3_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgRemovedynamicfilters3_Internalname, "Jsonclick", imgRemovedynamicfilters3_Jsonclick, true);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = " Propostas";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV13OrderedBy < 1 )
         {
            AV13OrderedBy = 1;
            AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV56DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV56DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E257M2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         if ( AV34ManageFiltersExecutionStep == 1 )
         {
            AV34ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV34ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV34ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV34ManageFiltersExecutionStep == 2 )
         {
            AV34ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV34ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV34ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         cmbavDynamicfiltersoperator1.removeAllItems();
         if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTATITULO") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Come�a com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Cont�m", 0);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CONTRATONOME") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Come�a com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Cont�m", 0);
         }
         if ( AV19DynamicFiltersEnabled2 )
         {
            cmbavDynamicfiltersoperator2.removeAllItems();
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "PROPOSTATITULO") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Come�a com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Cont�m", 0);
            }
            else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "CONTRATONOME") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Come�a com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Cont�m", 0);
            }
            if ( AV23DynamicFiltersEnabled3 )
            {
               cmbavDynamicfiltersoperator3.removeAllItems();
               if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "PROPOSTATITULO") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Come�a com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Cont�m", 0);
               }
               else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "CONTRATONOME") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Come�a com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Cont�m", 0);
               }
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV58GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV58GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV58GridCurrentPage), 10, 0));
         AV59GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV59GridPageCount", StringUtil.LTrimStr( (decimal)(AV59GridPageCount), 10, 0));
         GXt_char3 = AV60GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV96Pgmname, out  GXt_char3) ;
         AV60GridAppliedFilters = GXt_char3;
         AssignAttri("", false, "AV60GridAppliedFilters", AV60GridAppliedFilters);
         cmbReembolsoStatusAtual_F_Columnheaderclass = "WWColumn hidden-xs";
         AssignProp("", false, cmbReembolsoStatusAtual_F_Internalname, "Columnheaderclass", cmbReembolsoStatusAtual_F_Columnheaderclass, !bGXsfl_114_Refreshing);
         AV97Propostacontratoadmwwds_1_filterfulltext = AV15FilterFullText;
         AV98Propostacontratoadmwwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV99Propostacontratoadmwwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV100Propostacontratoadmwwds_4_propostatitulo1 = AV18PropostaTitulo1;
         AV101Propostacontratoadmwwds_5_contratonome1 = AV69ContratoNome1;
         AV102Propostacontratoadmwwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV103Propostacontratoadmwwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV104Propostacontratoadmwwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV105Propostacontratoadmwwds_9_propostatitulo2 = AV22PropostaTitulo2;
         AV106Propostacontratoadmwwds_10_contratonome2 = AV70ContratoNome2;
         AV107Propostacontratoadmwwds_11_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV108Propostacontratoadmwwds_12_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV109Propostacontratoadmwwds_13_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV110Propostacontratoadmwwds_14_propostatitulo3 = AV26PropostaTitulo3;
         AV111Propostacontratoadmwwds_15_contratonome3 = AV71ContratoNome3;
         AV112Propostacontratoadmwwds_16_tfprocedimentosmedicosnome = AV82TFProcedimentosMedicosNome;
         AV113Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel = AV83TFProcedimentosMedicosNome_Sel;
         AV114Propostacontratoadmwwds_18_tfpropostadescricao = AV39TFPropostaDescricao;
         AV115Propostacontratoadmwwds_19_tfpropostadescricao_sel = AV40TFPropostaDescricao_Sel;
         AV116Propostacontratoadmwwds_20_tfpropostavalor = AV41TFPropostaValor;
         AV117Propostacontratoadmwwds_21_tfpropostavalor_to = AV42TFPropostaValor_To;
         AV118Propostacontratoadmwwds_22_tfcontratonome = AV65TFContratoNome;
         AV119Propostacontratoadmwwds_23_tfcontratonome_sel = AV66TFContratoNome_Sel;
         AV120Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial = AV91TFPropostaPacienteClienteRazaoSocial;
         AV121Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel = AV92TFPropostaPacienteClienteRazaoSocial_Sel;
         AV122Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels = AV95TFReembolsoStatusAtual_F_Sels;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6WWPContext", AV6WWPContext);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ManageFiltersData", AV32ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E127M2( )
      {
         /* Gridpaginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Previous") == 0 )
         {
            subgrid_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Next") == 0 )
         {
            subgrid_nextpage( ) ;
         }
         else
         {
            AV57PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV57PageToGo) ;
         }
      }

      protected void E137M2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E147M2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV13OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            AV14OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProcedimentosMedicosNome") == 0 )
            {
               AV82TFProcedimentosMedicosNome = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV82TFProcedimentosMedicosNome", AV82TFProcedimentosMedicosNome);
               AV83TFProcedimentosMedicosNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV83TFProcedimentosMedicosNome_Sel", AV83TFProcedimentosMedicosNome_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PropostaDescricao") == 0 )
            {
               AV39TFPropostaDescricao = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV39TFPropostaDescricao", AV39TFPropostaDescricao);
               AV40TFPropostaDescricao_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV40TFPropostaDescricao_Sel", AV40TFPropostaDescricao_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PropostaValor") == 0 )
            {
               AV41TFPropostaValor = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV41TFPropostaValor", StringUtil.LTrimStr( AV41TFPropostaValor, 18, 2));
               AV42TFPropostaValor_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV42TFPropostaValor_To", StringUtil.LTrimStr( AV42TFPropostaValor_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ContratoNome") == 0 )
            {
               AV65TFContratoNome = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV65TFContratoNome", AV65TFContratoNome);
               AV66TFContratoNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV66TFContratoNome_Sel", AV66TFContratoNome_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PropostaPacienteClienteRazaoSocial") == 0 )
            {
               AV91TFPropostaPacienteClienteRazaoSocial = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV91TFPropostaPacienteClienteRazaoSocial", AV91TFPropostaPacienteClienteRazaoSocial);
               AV92TFPropostaPacienteClienteRazaoSocial_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV92TFPropostaPacienteClienteRazaoSocial_Sel", AV92TFPropostaPacienteClienteRazaoSocial_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ReembolsoStatusAtual_F") == 0 )
            {
               AV94TFReembolsoStatusAtual_F_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV94TFReembolsoStatusAtual_F_SelsJson", AV94TFReembolsoStatusAtual_F_SelsJson);
               AV95TFReembolsoStatusAtual_F_Sels.FromJSonString(AV94TFReembolsoStatusAtual_F_SelsJson, null);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV95TFReembolsoStatusAtual_F_Sels", AV95TFReembolsoStatusAtual_F_Sels);
      }

      private void E267M2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV89Aprovados = (short)(A40000GXC1);
         AV93Reembolso = "<i class=\"fas fa-rotate-left\"></i>";
         AssignAttri("", false, edtavReembolso_Internalname, AV93Reembolso);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpreembolso"+UrlEncode(StringUtil.LTrimStr(A323PropostaId,9,0));
         edtavReembolso_Link = formatLink("wpreembolso") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         if ( StringUtil.StrCmp(A329PropostaStatus, "PENDENTE") == 0 )
         {
            cmbPropostaStatus_Columnclass = "WWColumn WWColumnTag WWColumnTagWarning WWColumnTagWarningSingleCell";
         }
         else if ( StringUtil.StrCmp(A329PropostaStatus, "EM_ANALISE") == 0 )
         {
            cmbPropostaStatus_Columnclass = "WWColumn WWColumnTag WWColumnTagInfoLight WWColumnTagInfoLightSingleCell";
         }
         else if ( StringUtil.StrCmp(A329PropostaStatus, "APROVADO") == 0 )
         {
            cmbPropostaStatus_Columnclass = "WWColumn WWColumnTag WWColumnTagSuccess WWColumnTagSuccessSingleCell";
         }
         else if ( StringUtil.StrCmp(A329PropostaStatus, "REJEITADO") == 0 )
         {
            cmbPropostaStatus_Columnclass = "WWColumn WWColumnTag WWColumnTagDanger WWColumnTagDangerSingleCell";
         }
         else if ( StringUtil.StrCmp(A329PropostaStatus, "REVISAO") == 0 )
         {
            cmbPropostaStatus_Columnclass = "WWColumn WWColumnTag WWColumnTagWarning WWColumnTagWarningSingleCell";
         }
         else if ( StringUtil.StrCmp(A329PropostaStatus, "CANCELADO") == 0 )
         {
            cmbPropostaStatus_Columnclass = "WWColumn WWColumnTag WWColumnTagDanger WWColumnTagDangerSingleCell";
         }
         else
         {
            cmbPropostaStatus_Columnclass = "WWColumn";
         }
         if ( StringUtil.StrCmp(A548ReembolsoStatusAtual_F, "EM_ANALISE") == 0 )
         {
            cmbReembolsoStatusAtual_F_Columnclass = "WWColumn hidden-xs WWColumnTag WWColumnTagInfo WWColumnTagInfoSingleCell";
         }
         else if ( StringUtil.StrCmp(A548ReembolsoStatusAtual_F, "FINALIZADO") == 0 )
         {
            cmbReembolsoStatusAtual_F_Columnclass = "WWColumn hidden-xs WWColumnTag WWColumnTagSuccess WWColumnTagSuccessSingleCell";
         }
         else if ( StringUtil.StrCmp(A548ReembolsoStatusAtual_F, "REANALISE") == 0 )
         {
            cmbReembolsoStatusAtual_F_Columnclass = "WWColumn hidden-xs WWColumnTag WWColumnTagWarning WWColumnTagWarningSingleCell";
         }
         else if ( StringUtil.StrCmp(A548ReembolsoStatusAtual_F, "") == 0 )
         {
            cmbReembolsoStatusAtual_F_Columnclass = "WWColumn hidden-xs WWColumnTag WWColumnTagInfoLight WWColumnTagInfoLightSingleCell";
         }
         else
         {
            cmbReembolsoStatusAtual_F_Columnclass = "WWColumn hidden-xs";
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 114;
         }
         sendrow_1142( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_114_Refreshing )
         {
            DoAjaxLoad(114, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E197M2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV19DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18PropostaTitulo1, AV69ContratoNome1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22PropostaTitulo2, AV70ContratoNome2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26PropostaTitulo3, AV71ContratoNome3, AV34ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV96Pgmname, AV15FilterFullText, AV82TFProcedimentosMedicosNome, AV83TFProcedimentosMedicosNome_Sel, AV39TFPropostaDescricao, AV40TFPropostaDescricao_Sel, AV41TFPropostaValor, AV42TFPropostaValor_To, AV65TFContratoNome, AV66TFContratoNome_Sel, AV91TFPropostaPacienteClienteRazaoSocial, AV92TFPropostaPacienteClienteRazaoSocial_Sel, AV95TFReembolsoStatusAtual_F_Sels, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, AV84Context) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6WWPContext", AV6WWPContext);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ManageFiltersData", AV32ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E157M2( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV27DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         AV28DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV28DynamicFiltersIgnoreFirst", AV28DynamicFiltersIgnoreFirst);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV27DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         AV28DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV28DynamicFiltersIgnoreFirst", AV28DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18PropostaTitulo1, AV69ContratoNome1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22PropostaTitulo2, AV70ContratoNome2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26PropostaTitulo3, AV71ContratoNome3, AV34ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV96Pgmname, AV15FilterFullText, AV82TFProcedimentosMedicosNome, AV83TFProcedimentosMedicosNome_Sel, AV39TFPropostaDescricao, AV40TFPropostaDescricao_Sel, AV41TFPropostaValor, AV42TFPropostaValor_To, AV65TFContratoNome, AV66TFContratoNome_Sel, AV91TFPropostaPacienteClienteRazaoSocial, AV92TFPropostaPacienteClienteRazaoSocial_Sel, AV95TFReembolsoStatusAtual_F_Sels, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, AV84Context) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6WWPContext", AV6WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ManageFiltersData", AV32ManageFiltersData);
      }

      protected void E207M2( )
      {
         /* Dynamicfiltersselector1_Click Routine */
         returnInSub = false;
         AV17DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
      }

      protected void E217M2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV23DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV23DynamicFiltersEnabled3", AV23DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18PropostaTitulo1, AV69ContratoNome1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22PropostaTitulo2, AV70ContratoNome2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26PropostaTitulo3, AV71ContratoNome3, AV34ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV96Pgmname, AV15FilterFullText, AV82TFProcedimentosMedicosNome, AV83TFProcedimentosMedicosNome_Sel, AV39TFPropostaDescricao, AV40TFPropostaDescricao_Sel, AV41TFPropostaValor, AV42TFPropostaValor_To, AV65TFContratoNome, AV66TFContratoNome_Sel, AV91TFPropostaPacienteClienteRazaoSocial, AV92TFPropostaPacienteClienteRazaoSocial_Sel, AV95TFReembolsoStatusAtual_F_Sels, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, AV84Context) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6WWPContext", AV6WWPContext);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ManageFiltersData", AV32ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E167M2( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV27DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         AV19DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV27DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18PropostaTitulo1, AV69ContratoNome1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22PropostaTitulo2, AV70ContratoNome2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26PropostaTitulo3, AV71ContratoNome3, AV34ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV96Pgmname, AV15FilterFullText, AV82TFProcedimentosMedicosNome, AV83TFProcedimentosMedicosNome_Sel, AV39TFPropostaDescricao, AV40TFPropostaDescricao_Sel, AV41TFPropostaValor, AV42TFPropostaValor_To, AV65TFContratoNome, AV66TFContratoNome_Sel, AV91TFPropostaPacienteClienteRazaoSocial, AV92TFPropostaPacienteClienteRazaoSocial_Sel, AV95TFReembolsoStatusAtual_F_Sels, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, AV84Context) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6WWPContext", AV6WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ManageFiltersData", AV32ManageFiltersData);
      }

      protected void E227M2( )
      {
         /* Dynamicfiltersselector2_Click Routine */
         returnInSub = false;
         AV21DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
      }

      protected void E177M2( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV27DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         AV23DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV23DynamicFiltersEnabled3", AV23DynamicFiltersEnabled3);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV27DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18PropostaTitulo1, AV69ContratoNome1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22PropostaTitulo2, AV70ContratoNome2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26PropostaTitulo3, AV71ContratoNome3, AV34ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV96Pgmname, AV15FilterFullText, AV82TFProcedimentosMedicosNome, AV83TFProcedimentosMedicosNome_Sel, AV39TFPropostaDescricao, AV40TFPropostaDescricao_Sel, AV41TFPropostaValor, AV42TFPropostaValor_To, AV65TFContratoNome, AV66TFContratoNome_Sel, AV91TFPropostaPacienteClienteRazaoSocial, AV92TFPropostaPacienteClienteRazaoSocial_Sel, AV95TFReembolsoStatusAtual_F_Sels, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, AV84Context) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6WWPContext", AV6WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ManageFiltersData", AV32ManageFiltersData);
      }

      protected void E237M2( )
      {
         /* Dynamicfiltersselector3_Click Routine */
         returnInSub = false;
         AV25DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E117M2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S222 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Save#>") == 0 )
         {
            /* Execute user subroutine: 'SAVEGRIDSTATE' */
            S182 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("PropostaContratoAdmWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV96Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV34ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV34ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV34ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("PropostaContratoAdmWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV34ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV34ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV34ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char3 = AV33ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "PropostaContratoAdmWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
            AV33ManageFiltersXml = GXt_char3;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV33ManageFiltersXml)) )
            {
               GX_msglist.addItem("O filtro selecionado n�o existe mais.");
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S222 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV96Pgmname+"GridState",  AV33ManageFiltersXml) ;
               AV10GridState.FromXml(AV33ManageFiltersXml, null, "", "");
               AV13OrderedBy = AV10GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
               AV14OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S172 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S232 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
               S212 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV95TFReembolsoStatusAtual_F_Sels", AV95TFReembolsoStatusAtual_F_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6WWPContext", AV6WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ManageFiltersData", AV32ManageFiltersData);
      }

      protected void E187M2( )
      {
         /* 'DoExport' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new propostacontratoadmwwexport(context ).execute( out  AV29ExcelFilename, out  AV30ErrorMessage) ;
         if ( StringUtil.StrCmp(AV29ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV29ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV30ErrorMessage);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV95TFReembolsoStatusAtual_F_Sels", AV95TFReembolsoStatusAtual_F_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void S172( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV13OrderedBy), 4, 0))+":"+(AV14OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         edtavPropostatitulo1_Visible = 0;
         AssignProp("", false, edtavPropostatitulo1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostatitulo1_Visible), 5, 0), true);
         edtavContratonome1_Visible = 0;
         AssignProp("", false, edtavContratonome1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContratonome1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTATITULO") == 0 )
         {
            edtavPropostatitulo1_Visible = 1;
            AssignProp("", false, edtavPropostatitulo1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostatitulo1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CONTRATONOME") == 0 )
         {
            edtavContratonome1_Visible = 1;
            AssignProp("", false, edtavContratonome1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContratonome1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavPropostatitulo2_Visible = 0;
         AssignProp("", false, edtavPropostatitulo2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostatitulo2_Visible), 5, 0), true);
         edtavContratonome2_Visible = 0;
         AssignProp("", false, edtavContratonome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContratonome2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "PROPOSTATITULO") == 0 )
         {
            edtavPropostatitulo2_Visible = 1;
            AssignProp("", false, edtavPropostatitulo2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostatitulo2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "CONTRATONOME") == 0 )
         {
            edtavContratonome2_Visible = 1;
            AssignProp("", false, edtavContratonome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContratonome2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavPropostatitulo3_Visible = 0;
         AssignProp("", false, edtavPropostatitulo3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostatitulo3_Visible), 5, 0), true);
         edtavContratonome3_Visible = 0;
         AssignProp("", false, edtavContratonome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContratonome3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "PROPOSTATITULO") == 0 )
         {
            edtavPropostatitulo3_Visible = 1;
            AssignProp("", false, edtavPropostatitulo3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostatitulo3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "CONTRATONOME") == 0 )
         {
            edtavContratonome3_Visible = 1;
            AssignProp("", false, edtavContratonome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContratonome3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S202( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV19DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
         AV20DynamicFiltersSelector2 = "PROPOSTATITULO";
         AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         AV21DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AV22PropostaTitulo2 = "";
         AssignAttri("", false, "AV22PropostaTitulo2", AV22PropostaTitulo2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV23DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV23DynamicFiltersEnabled3", AV23DynamicFiltersEnabled3);
         AV24DynamicFiltersSelector3 = "PROPOSTATITULO";
         AssignAttri("", false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
         AV25DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AV26PropostaTitulo3 = "";
         AssignAttri("", false, "AV26PropostaTitulo3", AV26PropostaTitulo3);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV32ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "PropostaContratoAdmWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV32ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S222( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
         AV82TFProcedimentosMedicosNome = "";
         AssignAttri("", false, "AV82TFProcedimentosMedicosNome", AV82TFProcedimentosMedicosNome);
         AV83TFProcedimentosMedicosNome_Sel = "";
         AssignAttri("", false, "AV83TFProcedimentosMedicosNome_Sel", AV83TFProcedimentosMedicosNome_Sel);
         AV39TFPropostaDescricao = "";
         AssignAttri("", false, "AV39TFPropostaDescricao", AV39TFPropostaDescricao);
         AV40TFPropostaDescricao_Sel = "";
         AssignAttri("", false, "AV40TFPropostaDescricao_Sel", AV40TFPropostaDescricao_Sel);
         AV41TFPropostaValor = 0;
         AssignAttri("", false, "AV41TFPropostaValor", StringUtil.LTrimStr( AV41TFPropostaValor, 18, 2));
         AV42TFPropostaValor_To = 0;
         AssignAttri("", false, "AV42TFPropostaValor_To", StringUtil.LTrimStr( AV42TFPropostaValor_To, 18, 2));
         AV65TFContratoNome = "";
         AssignAttri("", false, "AV65TFContratoNome", AV65TFContratoNome);
         AV66TFContratoNome_Sel = "";
         AssignAttri("", false, "AV66TFContratoNome_Sel", AV66TFContratoNome_Sel);
         AV91TFPropostaPacienteClienteRazaoSocial = "";
         AssignAttri("", false, "AV91TFPropostaPacienteClienteRazaoSocial", AV91TFPropostaPacienteClienteRazaoSocial);
         AV92TFPropostaPacienteClienteRazaoSocial_Sel = "";
         AssignAttri("", false, "AV92TFPropostaPacienteClienteRazaoSocial_Sel", AV92TFPropostaPacienteClienteRazaoSocial_Sel);
         AV95TFReembolsoStatusAtual_F_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV16DynamicFiltersSelector1 = "PROPOSTATITULO";
         AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         AV17DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AV18PropostaTitulo1 = "";
         AssignAttri("", false, "AV18PropostaTitulo1", AV18PropostaTitulo1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV10GridState.gxTpr_Dynamicfilters.Clear();
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S162( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV31Session.Get(AV96Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV96Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV31Session.Get(AV96Pgmname+"GridState"), null, "", "");
         }
         AV13OrderedBy = AV10GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
         AV14OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV10GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV10GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV10GridState.gxTpr_Currentpage) ;
      }

      protected void S232( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV123GXV1 = 1;
         while ( AV123GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV123GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROCEDIMENTOSMEDICOSNOME") == 0 )
            {
               AV82TFProcedimentosMedicosNome = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV82TFProcedimentosMedicosNome", AV82TFProcedimentosMedicosNome);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROCEDIMENTOSMEDICOSNOME_SEL") == 0 )
            {
               AV83TFProcedimentosMedicosNome_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV83TFProcedimentosMedicosNome_Sel", AV83TFProcedimentosMedicosNome_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROPOSTADESCRICAO") == 0 )
            {
               AV39TFPropostaDescricao = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV39TFPropostaDescricao", AV39TFPropostaDescricao);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROPOSTADESCRICAO_SEL") == 0 )
            {
               AV40TFPropostaDescricao_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV40TFPropostaDescricao_Sel", AV40TFPropostaDescricao_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROPOSTAVALOR") == 0 )
            {
               AV41TFPropostaValor = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV41TFPropostaValor", StringUtil.LTrimStr( AV41TFPropostaValor, 18, 2));
               AV42TFPropostaValor_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV42TFPropostaValor_To", StringUtil.LTrimStr( AV42TFPropostaValor_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCONTRATONOME") == 0 )
            {
               AV65TFContratoNome = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV65TFContratoNome", AV65TFContratoNome);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCONTRATONOME_SEL") == 0 )
            {
               AV66TFContratoNome_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV66TFContratoNome_Sel", AV66TFContratoNome_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
            {
               AV91TFPropostaPacienteClienteRazaoSocial = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV91TFPropostaPacienteClienteRazaoSocial", AV91TFPropostaPacienteClienteRazaoSocial);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV92TFPropostaPacienteClienteRazaoSocial_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV92TFPropostaPacienteClienteRazaoSocial_Sel", AV92TFPropostaPacienteClienteRazaoSocial_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOSTATUSATUAL_F_SEL") == 0 )
            {
               AV94TFReembolsoStatusAtual_F_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV94TFReembolsoStatusAtual_F_SelsJson", AV94TFReembolsoStatusAtual_F_SelsJson);
               AV95TFReembolsoStatusAtual_F_Sels.FromJSonString(AV94TFReembolsoStatusAtual_F_SelsJson, null);
            }
            AV123GXV1 = (int)(AV123GXV1+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV83TFProcedimentosMedicosNome_Sel)),  AV83TFProcedimentosMedicosNome_Sel, out  GXt_char3) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV40TFPropostaDescricao_Sel)),  AV40TFPropostaDescricao_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV66TFContratoNome_Sel)),  AV66TFContratoNome_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV92TFPropostaPacienteClienteRazaoSocial_Sel)),  AV92TFPropostaPacienteClienteRazaoSocial_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV95TFReembolsoStatusAtual_F_Sels.Count==0),  AV94TFReembolsoStatusAtual_F_SelsJson, out  GXt_char8) ;
         Ddo_grid_Selectedvalue_set = GXt_char3+"|"+GXt_char5+"||"+GXt_char6+"|"+GXt_char7+"|"+GXt_char8;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV82TFProcedimentosMedicosNome)),  AV82TFProcedimentosMedicosNome, out  GXt_char8) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV39TFPropostaDescricao)),  AV39TFPropostaDescricao, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV65TFContratoNome)),  AV65TFContratoNome, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV91TFPropostaPacienteClienteRazaoSocial)),  AV91TFPropostaPacienteClienteRazaoSocial, out  GXt_char5) ;
         Ddo_grid_Filteredtext_set = GXt_char8+"|"+GXt_char7+"|"+((Convert.ToDecimal(0)==AV41TFPropostaValor) ? "" : StringUtil.Str( AV41TFPropostaValor, 18, 2))+"|"+GXt_char6+"|"+GXt_char5+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "||"+((Convert.ToDecimal(0)==AV42TFPropostaValor_To) ? "" : StringUtil.Str( AV42TFPropostaValor_To, 18, 2))+"|||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S212( )
      {
         /* 'LOADDYNFILTERSSTATE' Routine */
         returnInSub = false;
         imgAdddynamicfilters1_Visible = 1;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 0;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         imgAdddynamicfilters2_Visible = 1;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 0;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         if ( AV10GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(1));
            AV16DynamicFiltersSelector1 = AV12GridStateDynamicFilter.gxTpr_Selected;
            AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
            if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTATITULO") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV18PropostaTitulo1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV18PropostaTitulo1", AV18PropostaTitulo1);
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CONTRATONOME") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV69ContratoNome1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV69ContratoNome1", AV69ContratoNome1);
            }
            /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
            S122 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            if ( AV10GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               lblJsdynamicfilters_Caption = "<script type=\"text/javascript\">$(document).ready(function() {";
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
               lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+StringUtil.Format( "WWPDynFilterShow_AL('%1', 2, 0);", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
               imgAdddynamicfilters1_Visible = 0;
               AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
               imgRemovedynamicfilters1_Visible = 1;
               AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
               AV19DynamicFiltersEnabled2 = true;
               AssignAttri("", false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
               AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(2));
               AV20DynamicFiltersSelector2 = AV12GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "PROPOSTATITULO") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
                  AV22PropostaTitulo2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV22PropostaTitulo2", AV22PropostaTitulo2);
               }
               else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "CONTRATONOME") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
                  AV70ContratoNome2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV70ContratoNome2", AV70ContratoNome2);
               }
               /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
               S132 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               if ( AV10GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+StringUtil.Format( "WWPDynFilterShow_AL('%1', 3, 0);", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
                  AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
                  imgAdddynamicfilters2_Visible = 0;
                  AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
                  imgRemovedynamicfilters2_Visible = 1;
                  AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
                  AV23DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV23DynamicFiltersEnabled3", AV23DynamicFiltersEnabled3);
                  AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(3));
                  AV24DynamicFiltersSelector3 = AV12GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "PROPOSTATITULO") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
                     AV26PropostaTitulo3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV26PropostaTitulo3", AV26PropostaTitulo3);
                  }
                  else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "CONTRATONOME") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
                     AV71ContratoNome3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV71ContratoNome3", AV71ContratoNome3);
                  }
                  /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
                  S142 ();
                  if ( returnInSub )
                  {
                     returnInSub = true;
                     if (true) return;
                  }
               }
               lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+"});</script>";
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
            }
         }
         if ( AV27DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S182( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV31Session.Get(AV96Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPROCEDIMENTOSMEDICOSNOME",  "Procedimento",  !String.IsNullOrEmpty(StringUtil.RTrim( AV82TFProcedimentosMedicosNome)),  0,  AV82TFProcedimentosMedicosNome,  AV82TFProcedimentosMedicosNome,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV83TFProcedimentosMedicosNome_Sel)),  AV83TFProcedimentosMedicosNome_Sel,  AV83TFProcedimentosMedicosNome_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPROPOSTADESCRICAO",  "Descri��o",  !String.IsNullOrEmpty(StringUtil.RTrim( AV39TFPropostaDescricao)),  0,  AV39TFPropostaDescricao,  AV39TFPropostaDescricao,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV40TFPropostaDescricao_Sel)),  AV40TFPropostaDescricao_Sel,  AV40TFPropostaDescricao_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFPROPOSTAVALOR",  "Valor",  !((Convert.ToDecimal(0)==AV41TFPropostaValor)&&(Convert.ToDecimal(0)==AV42TFPropostaValor_To)),  0,  StringUtil.Trim( StringUtil.Str( AV41TFPropostaValor, 18, 2)),  ((Convert.ToDecimal(0)==AV41TFPropostaValor) ? "" : StringUtil.Trim( context.localUtil.Format( AV41TFPropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV42TFPropostaValor_To, 18, 2)),  ((Convert.ToDecimal(0)==AV42TFPropostaValor_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV42TFPropostaValor_To, "ZZZ,ZZZ,ZZZ,ZZ9.99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCONTRATONOME",  "Contrato",  !String.IsNullOrEmpty(StringUtil.RTrim( AV65TFContratoNome)),  0,  AV65TFContratoNome,  AV65TFContratoNome,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV66TFContratoNome_Sel)),  AV66TFContratoNome_Sel,  AV66TFContratoNome_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPROPOSTAPACIENTECLIENTERAZAOSOCIAL",  "Paciente",  !String.IsNullOrEmpty(StringUtil.RTrim( AV91TFPropostaPacienteClienteRazaoSocial)),  0,  AV91TFPropostaPacienteClienteRazaoSocial,  AV91TFPropostaPacienteClienteRazaoSocial,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV92TFPropostaPacienteClienteRazaoSocial_Sel)),  AV92TFPropostaPacienteClienteRazaoSocial_Sel,  AV92TFPropostaPacienteClienteRazaoSocial_Sel) ;
         AV64AuxText = ((AV95TFReembolsoStatusAtual_F_Sels.Count==1) ? "["+((string)AV95TFReembolsoStatusAtual_F_Sels.Item(1))+"]" : "V�rios valores");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFREEMBOLSOSTATUSATUAL_F_SEL",  "Situa��o reembolso",  !(AV95TFReembolsoStatusAtual_F_Sels.Count==0),  0,  AV95TFReembolsoStatusAtual_F_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV64AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( AV64AuxText, "[EM_ANALISE]", "Em an�lise"), "[FINALIZADO]", "Finalizado"), "[REANALISE]", "Rean�lise"), "[]", "N�o iniciado")),  false,  "",  "") ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV96Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S192( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV10GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV28DynamicFiltersIgnoreFirst )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV16DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTATITULO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV18PropostaTitulo1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Titulo",  AV17DynamicFiltersOperator1,  AV18PropostaTitulo1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Come�a com"+" "+AV18PropostaTitulo1, "Cont�m"+" "+AV18PropostaTitulo1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CONTRATONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV69ContratoNome1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Contrato Nome",  AV17DynamicFiltersOperator1,  AV69ContratoNome1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Come�a com"+" "+AV69ContratoNome1, "Cont�m"+" "+AV69ContratoNome1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV27DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV19DynamicFiltersEnabled2 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV20DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "PROPOSTATITULO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV22PropostaTitulo2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Titulo",  AV21DynamicFiltersOperator2,  AV22PropostaTitulo2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2+1), 10, 0)), "Come�a com"+" "+AV22PropostaTitulo2, "Cont�m"+" "+AV22PropostaTitulo2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "CONTRATONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV70ContratoNome2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Contrato Nome",  AV21DynamicFiltersOperator2,  AV70ContratoNome2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2+1), 10, 0)), "Come�a com"+" "+AV70ContratoNome2, "Cont�m"+" "+AV70ContratoNome2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV27DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV23DynamicFiltersEnabled3 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV24DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "PROPOSTATITULO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV26PropostaTitulo3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Titulo",  AV25DynamicFiltersOperator3,  AV26PropostaTitulo3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3+1), 10, 0)), "Come�a com"+" "+AV26PropostaTitulo3, "Cont�m"+" "+AV26PropostaTitulo3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "CONTRATONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV71ContratoNome3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Contrato Nome",  AV25DynamicFiltersOperator3,  AV71ContratoNome3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3+1), 10, 0)), "Come�a com"+" "+AV71ContratoNome3, "Cont�m"+" "+AV71ContratoNome3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV27DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
      }

      protected void S152( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV96Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "PropostaContratoAdm";
         AV31Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void S242( )
      {
         /* 'DO APROVAR' Routine */
         returnInSub = false;
         AV88Aprovacao = new SdtAprovacao(context);
         AV88Aprovacao.gxTpr_Aprovadoresid = AV84Context.gxTpr_Userid;
         AV88Aprovacao.gxTpr_Propostaid = AV86PropostaId_Selected;
         AV88Aprovacao.gxTpr_Aprovacaoem = DateTimeUtil.ServerNow( context, pr_default);
         AV88Aprovacao.gxTpr_Aprovacaodecisao = AV87DVelop_ConfirmPanel_Aprovar_Comment;
         AV88Aprovacao.gxTpr_Aprovacaostatus = "APROVADO";
         AV88Aprovacao.Save();
         if ( AV88Aprovacao.Success() )
         {
            context.CommitDataStores("propostacontratoadmww",pr_default);
            GXt_char8 = "Proposta aprovada!";
            new message(context ).gxep_sucesso( ref  GXt_char8) ;
            context.DoAjaxRefresh();
         }
         else
         {
            context.RollbackDataStores("propostacontratoadmww",pr_default);
            new showmessages(context ).execute( ) ;
         }
      }

      protected void wb_table3_93_7M2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfilters3_Internalname, tblTablemergeddynamicfilters3_Internalname, "", "Table", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersoperator3_Internalname, "Dynamic Filters Operator3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'" + sGXsfl_114_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,97);\"", "", true, 0, "HLP_PropostaContratoAdmWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_propostatitulo3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostatitulo3_Internalname, "Proposta Titulo3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'" + sGXsfl_114_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostatitulo3_Internalname, AV26PropostaTitulo3, StringUtil.RTrim( context.localUtil.Format( AV26PropostaTitulo3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,100);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostatitulo3_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostatitulo3_Visible, edtavPropostatitulo3_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_PropostaContratoAdmWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_contratonome3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContratonome3_Internalname, "Contrato Nome3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'" + sGXsfl_114_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContratonome3_Internalname, AV71ContratoNome3, StringUtil.RTrim( context.localUtil.Format( AV71ContratoNome3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,103);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContratonome3_Jsonclick, 0, "Attribute", "", "", "", "", edtavContratonome3_Visible, edtavContratonome3_Enabled, 0, "text", "", 80, "chr", 1, "row", 125, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_PropostaContratoAdmWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_PropostaContratoAdmWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_93_7M2e( true) ;
         }
         else
         {
            wb_table3_93_7M2e( false) ;
         }
      }

      protected void wb_table2_68_7M2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfilters2_Internalname, tblTablemergeddynamicfilters2_Internalname, "", "Table", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersoperator2_Internalname, "Dynamic Filters Operator2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'" + sGXsfl_114_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,72);\"", "", true, 0, "HLP_PropostaContratoAdmWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_propostatitulo2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostatitulo2_Internalname, "Proposta Titulo2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'" + sGXsfl_114_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostatitulo2_Internalname, AV22PropostaTitulo2, StringUtil.RTrim( context.localUtil.Format( AV22PropostaTitulo2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,75);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostatitulo2_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostatitulo2_Visible, edtavPropostatitulo2_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_PropostaContratoAdmWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_contratonome2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContratonome2_Internalname, "Contrato Nome2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'" + sGXsfl_114_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContratonome2_Internalname, AV70ContratoNome2, StringUtil.RTrim( context.localUtil.Format( AV70ContratoNome2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContratonome2_Jsonclick, 0, "Attribute", "", "", "", "", edtavContratonome2_Visible, edtavContratonome2_Enabled, 0, "text", "", 80, "chr", 1, "row", 125, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_PropostaContratoAdmWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_PropostaContratoAdmWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_PropostaContratoAdmWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_68_7M2e( true) ;
         }
         else
         {
            wb_table2_68_7M2e( false) ;
         }
      }

      protected void wb_table1_43_7M2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfilters1_Internalname, tblTablemergeddynamicfilters1_Internalname, "", "Table", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersoperator1_Internalname, "Dynamic Filters Operator1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'" + sGXsfl_114_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "", true, 0, "HLP_PropostaContratoAdmWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_propostatitulo1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostatitulo1_Internalname, "Proposta Titulo1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'" + sGXsfl_114_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostatitulo1_Internalname, AV18PropostaTitulo1, StringUtil.RTrim( context.localUtil.Format( AV18PropostaTitulo1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostatitulo1_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostatitulo1_Visible, edtavPropostatitulo1_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_PropostaContratoAdmWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_contratonome1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContratonome1_Internalname, "Contrato Nome1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'" + sGXsfl_114_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContratonome1_Internalname, AV69ContratoNome1, StringUtil.RTrim( context.localUtil.Format( AV69ContratoNome1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContratonome1_Jsonclick, 0, "Attribute", "", "", "", "", edtavContratonome1_Visible, edtavContratonome1_Enabled, 0, "text", "", 80, "chr", 1, "row", 125, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_PropostaContratoAdmWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_PropostaContratoAdmWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_PropostaContratoAdmWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_43_7M2e( true) ;
         }
         else
         {
            wb_table1_43_7M2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA7M2( ) ;
         WS7M2( ) ;
         WE7M2( ) ;
         cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("DVelop/DVPaginationBar/DVPaginationBar.css", "");
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019272834", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.por.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("propostacontratoadmww.js", "?202561019272835", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1142( )
      {
         edtavReembolso_Internalname = "vREEMBOLSO_"+sGXsfl_114_idx;
         edtPropostaId_Internalname = "PROPOSTAID_"+sGXsfl_114_idx;
         edtProcedimentosMedicosNome_Internalname = "PROCEDIMENTOSMEDICOSNOME_"+sGXsfl_114_idx;
         edtProcedimentosMedicosId_Internalname = "PROCEDIMENTOSMEDICOSID_"+sGXsfl_114_idx;
         edtPropostaDescricao_Internalname = "PROPOSTADESCRICAO_"+sGXsfl_114_idx;
         edtPropostaValor_Internalname = "PROPOSTAVALOR_"+sGXsfl_114_idx;
         edtPropostaCreatedAt_Internalname = "PROPOSTACREATEDAT_"+sGXsfl_114_idx;
         edtPropostaCratedBy_Internalname = "PROPOSTACRATEDBY_"+sGXsfl_114_idx;
         cmbPropostaStatus_Internalname = "PROPOSTASTATUS_"+sGXsfl_114_idx;
         edtContratoId_Internalname = "CONTRATOID_"+sGXsfl_114_idx;
         edtContratoNome_Internalname = "CONTRATONOME_"+sGXsfl_114_idx;
         edtPropostaQuantidadeAprovadores_Internalname = "PROPOSTAQUANTIDADEAPROVADORES_"+sGXsfl_114_idx;
         edtPropostaReprovacoesPermitidas_Internalname = "PROPOSTAREPROVACOESPERMITIDAS_"+sGXsfl_114_idx;
         edtPropostaAprovacoes_F_Internalname = "PROPOSTAAPROVACOES_F_"+sGXsfl_114_idx;
         edtPropostaReprovacoes_F_Internalname = "PROPOSTAREPROVACOES_F_"+sGXsfl_114_idx;
         edtPropostaAprovacoesRestantes_F_Internalname = "PROPOSTAAPROVACOESRESTANTES_F_"+sGXsfl_114_idx;
         edtPropostaPacienteClienteRazaoSocial_Internalname = "PROPOSTAPACIENTECLIENTERAZAOSOCIAL_"+sGXsfl_114_idx;
         cmbReembolsoStatusAtual_F_Internalname = "REEMBOLSOSTATUSATUAL_F_"+sGXsfl_114_idx;
      }

      protected void SubsflControlProps_fel_1142( )
      {
         edtavReembolso_Internalname = "vREEMBOLSO_"+sGXsfl_114_fel_idx;
         edtPropostaId_Internalname = "PROPOSTAID_"+sGXsfl_114_fel_idx;
         edtProcedimentosMedicosNome_Internalname = "PROCEDIMENTOSMEDICOSNOME_"+sGXsfl_114_fel_idx;
         edtProcedimentosMedicosId_Internalname = "PROCEDIMENTOSMEDICOSID_"+sGXsfl_114_fel_idx;
         edtPropostaDescricao_Internalname = "PROPOSTADESCRICAO_"+sGXsfl_114_fel_idx;
         edtPropostaValor_Internalname = "PROPOSTAVALOR_"+sGXsfl_114_fel_idx;
         edtPropostaCreatedAt_Internalname = "PROPOSTACREATEDAT_"+sGXsfl_114_fel_idx;
         edtPropostaCratedBy_Internalname = "PROPOSTACRATEDBY_"+sGXsfl_114_fel_idx;
         cmbPropostaStatus_Internalname = "PROPOSTASTATUS_"+sGXsfl_114_fel_idx;
         edtContratoId_Internalname = "CONTRATOID_"+sGXsfl_114_fel_idx;
         edtContratoNome_Internalname = "CONTRATONOME_"+sGXsfl_114_fel_idx;
         edtPropostaQuantidadeAprovadores_Internalname = "PROPOSTAQUANTIDADEAPROVADORES_"+sGXsfl_114_fel_idx;
         edtPropostaReprovacoesPermitidas_Internalname = "PROPOSTAREPROVACOESPERMITIDAS_"+sGXsfl_114_fel_idx;
         edtPropostaAprovacoes_F_Internalname = "PROPOSTAAPROVACOES_F_"+sGXsfl_114_fel_idx;
         edtPropostaReprovacoes_F_Internalname = "PROPOSTAREPROVACOES_F_"+sGXsfl_114_fel_idx;
         edtPropostaAprovacoesRestantes_F_Internalname = "PROPOSTAAPROVACOESRESTANTES_F_"+sGXsfl_114_fel_idx;
         edtPropostaPacienteClienteRazaoSocial_Internalname = "PROPOSTAPACIENTECLIENTERAZAOSOCIAL_"+sGXsfl_114_fel_idx;
         cmbReembolsoStatusAtual_F_Internalname = "REEMBOLSOSTATUSATUAL_F_"+sGXsfl_114_fel_idx;
      }

      protected void sendrow_1142( )
      {
         sGXsfl_114_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_114_idx), 4, 0), 4, "0");
         SubsflControlProps_1142( ) ;
         WB7M0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_114_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0x0);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_114_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar GridWithBorderColor WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_114_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 115,'',false,'" + sGXsfl_114_idx + "',114)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavReembolso_Internalname,StringUtil.RTrim( AV93Reembolso),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,115);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavReembolso_Link,(string)"",(string)"Reembolso",(string)"",(string)edtavReembolso_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavReembolso_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)114,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A323PropostaId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProcedimentosMedicosNome_Internalname,(string)A377ProcedimentosMedicosNome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProcedimentosMedicosNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)255,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProcedimentosMedicosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A376ProcedimentosMedicosId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A376ProcedimentosMedicosId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProcedimentosMedicosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaDescricao_Internalname,(string)A325PropostaDescricao,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaDescricao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaValor_Internalname,StringUtil.LTrim( StringUtil.NToC( A326PropostaValor, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A326PropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaValor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaCreatedAt_Internalname,context.localUtil.TToC( A327PropostaCreatedAt, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A327PropostaCreatedAt, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaCreatedAt_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaCratedBy_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A328PropostaCratedBy), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A328PropostaCratedBy), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaCratedBy_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( cmbPropostaStatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "PROPOSTASTATUS_" + sGXsfl_114_idx;
               cmbPropostaStatus.Name = GXCCtl;
               cmbPropostaStatus.WebTags = "";
               cmbPropostaStatus.addItem("PENDENTE", "Pendente aprova��o", 0);
               cmbPropostaStatus.addItem("EM_ANALISE", "Em an�lise", 0);
               cmbPropostaStatus.addItem("APROVADO", "Aprovado", 0);
               cmbPropostaStatus.addItem("REJEITADO", "Rejeitado", 0);
               cmbPropostaStatus.addItem("REVISAO", "Revis�o", 0);
               cmbPropostaStatus.addItem("CANCELADO", "Cancelado", 0);
               cmbPropostaStatus.addItem("AGUARDANDO_ASSINATURA", "Aguardando assinatura", 0);
               cmbPropostaStatus.addItem("AnaliseReprovada", "An�lise reprovada", 0);
               if ( cmbPropostaStatus.ItemCount > 0 )
               {
                  A329PropostaStatus = cmbPropostaStatus.getValidValue(A329PropostaStatus);
                  n329PropostaStatus = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbPropostaStatus,(string)cmbPropostaStatus_Internalname,StringUtil.RTrim( A329PropostaStatus),(short)1,(string)cmbPropostaStatus_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)0,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)cmbPropostaStatus_Columnclass,(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbPropostaStatus.CurrentValue = StringUtil.RTrim( A329PropostaStatus);
            AssignProp("", false, cmbPropostaStatus_Internalname, "Values", (string)(cmbPropostaStatus.ToJavascriptSource()), !bGXsfl_114_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtContratoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A227ContratoId), "ZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtContratoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtContratoNome_Internalname,(string)A228ContratoNome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtContratoNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)125,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaQuantidadeAprovadores_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A330PropostaQuantidadeAprovadores), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A330PropostaQuantidadeAprovadores), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaQuantidadeAprovadores_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaReprovacoesPermitidas_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A345PropostaReprovacoesPermitidas), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A345PropostaReprovacoesPermitidas), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaReprovacoesPermitidas_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaAprovacoes_F_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A341PropostaAprovacoes_F), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A341PropostaAprovacoes_F), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaAprovacoes_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaReprovacoes_F_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A342PropostaReprovacoes_F), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A342PropostaReprovacoes_F), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaReprovacoes_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaAprovacoesRestantes_F_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A343PropostaAprovacoesRestantes_F), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A343PropostaAprovacoesRestantes_F), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaAprovacoesRestantes_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaPacienteClienteRazaoSocial_Internalname,(string)A505PropostaPacienteClienteRazaoSocial,StringUtil.RTrim( context.localUtil.Format( A505PropostaPacienteClienteRazaoSocial, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaPacienteClienteRazaoSocial_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            GXCCtl = "REEMBOLSOSTATUSATUAL_F_" + sGXsfl_114_idx;
            cmbReembolsoStatusAtual_F.Name = GXCCtl;
            cmbReembolsoStatusAtual_F.WebTags = "";
            cmbReembolsoStatusAtual_F.addItem("", "", 0);
            cmbReembolsoStatusAtual_F.addItem("EM_ANALISE", "Em an�lise", 0);
            cmbReembolsoStatusAtual_F.addItem("FINALIZADO", "Finalizado", 0);
            cmbReembolsoStatusAtual_F.addItem("REANALISE", "Rean�lise", 0);
            cmbReembolsoStatusAtual_F.addItem("", "N�o iniciado", 0);
            if ( cmbReembolsoStatusAtual_F.ItemCount > 0 )
            {
               A548ReembolsoStatusAtual_F = cmbReembolsoStatusAtual_F.getValidValue(A548ReembolsoStatusAtual_F);
               n548ReembolsoStatusAtual_F = false;
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbReembolsoStatusAtual_F,(string)cmbReembolsoStatusAtual_F_Internalname,StringUtil.RTrim( A548ReembolsoStatusAtual_F),(short)1,(string)cmbReembolsoStatusAtual_F_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,(short)0,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)cmbReembolsoStatusAtual_F_Columnclass,(string)cmbReembolsoStatusAtual_F_Columnheaderclass,(string)"",(string)"",(bool)true,(short)0});
            cmbReembolsoStatusAtual_F.CurrentValue = StringUtil.RTrim( A548ReembolsoStatusAtual_F);
            AssignProp("", false, cmbReembolsoStatusAtual_F_Internalname, "Values", (string)(cmbReembolsoStatusAtual_F.ToJavascriptSource()), !bGXsfl_114_Refreshing);
            send_integrity_lvl_hashes7M2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_114_idx = ((subGrid_Islastpage==1)&&(nGXsfl_114_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_114_idx+1);
            sGXsfl_114_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_114_idx), 4, 0), 4, "0");
            SubsflControlProps_1142( ) ;
         }
         /* End function sendrow_1142 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("PROPOSTATITULO", "Titulo", 0);
         cmbavDynamicfiltersselector1.addItem("CONTRATONOME", "Contrato Nome", 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV16DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV16DynamicFiltersSelector1);
            AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         }
         cmbavDynamicfiltersoperator1.Name = "vDYNAMICFILTERSOPERATOR1";
         cmbavDynamicfiltersoperator1.WebTags = "";
         cmbavDynamicfiltersoperator1.addItem("0", "Come�a com", 0);
         cmbavDynamicfiltersoperator1.addItem("1", "Cont�m", 0);
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV17DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("PROPOSTATITULO", "Titulo", 0);
         cmbavDynamicfiltersselector2.addItem("CONTRATONOME", "Contrato Nome", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV20DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV20DynamicFiltersSelector2);
            AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", "Come�a com", 0);
         cmbavDynamicfiltersoperator2.addItem("1", "Cont�m", 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV21DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("PROPOSTATITULO", "Titulo", 0);
         cmbavDynamicfiltersselector3.addItem("CONTRATONOME", "Contrato Nome", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV24DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV24DynamicFiltersSelector3);
            AssignAttri("", false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", "Come�a com", 0);
         cmbavDynamicfiltersoperator3.addItem("1", "Cont�m", 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV25DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         }
         GXCCtl = "PROPOSTASTATUS_" + sGXsfl_114_idx;
         cmbPropostaStatus.Name = GXCCtl;
         cmbPropostaStatus.WebTags = "";
         cmbPropostaStatus.addItem("PENDENTE", "Pendente aprova��o", 0);
         cmbPropostaStatus.addItem("EM_ANALISE", "Em an�lise", 0);
         cmbPropostaStatus.addItem("APROVADO", "Aprovado", 0);
         cmbPropostaStatus.addItem("REJEITADO", "Rejeitado", 0);
         cmbPropostaStatus.addItem("REVISAO", "Revis�o", 0);
         cmbPropostaStatus.addItem("CANCELADO", "Cancelado", 0);
         cmbPropostaStatus.addItem("AGUARDANDO_ASSINATURA", "Aguardando assinatura", 0);
         cmbPropostaStatus.addItem("AnaliseReprovada", "An�lise reprovada", 0);
         if ( cmbPropostaStatus.ItemCount > 0 )
         {
            A329PropostaStatus = cmbPropostaStatus.getValidValue(A329PropostaStatus);
            n329PropostaStatus = false;
         }
         GXCCtl = "REEMBOLSOSTATUSATUAL_F_" + sGXsfl_114_idx;
         cmbReembolsoStatusAtual_F.Name = GXCCtl;
         cmbReembolsoStatusAtual_F.WebTags = "";
         cmbReembolsoStatusAtual_F.addItem("", "", 0);
         cmbReembolsoStatusAtual_F.addItem("EM_ANALISE", "Em an�lise", 0);
         cmbReembolsoStatusAtual_F.addItem("FINALIZADO", "Finalizado", 0);
         cmbReembolsoStatusAtual_F.addItem("REANALISE", "Rean�lise", 0);
         cmbReembolsoStatusAtual_F.addItem("", "N�o iniciado", 0);
         if ( cmbReembolsoStatusAtual_F.ItemCount > 0 )
         {
            A548ReembolsoStatusAtual_F = cmbReembolsoStatusAtual_F.getValidValue(A548ReembolsoStatusAtual_F);
            n548ReembolsoStatusAtual_F = false;
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl114( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"114\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "GridWithPaginationBar GridWithBorderColor WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid_Backcolorstyle == 0 )
            {
               subGrid_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid_Class) > 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Title";
               }
            }
            else
            {
               subGrid_Titlebackstyle = 1;
               if ( subGrid_Backcolorstyle == 1 )
               {
                  subGrid_Titlebackcolor = subGrid_Allbackcolor;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Procedimento") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Procedimentos Medicos Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Descri��o") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Valor") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Created At") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Crated By") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Status") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Contrato") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Aprova��es min�mas") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Reprovacoes Permitidas") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Aprova��es") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Reprova��es") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Aprova��es restantes") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Paciente") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Situa��o reembolso") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridContainer = new GXWebGrid( context);
            }
            else
            {
               GridContainer.Clear();
            }
            GridContainer.SetWrapped(nGXWrapped);
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "GridWithPaginationBar GridWithBorderColor WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV93Reembolso)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavReembolso_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavReembolso_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A377ProcedimentosMedicosNome));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A376ProcedimentosMedicosId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A325PropostaDescricao));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A326PropostaValor, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A327PropostaCreatedAt, 10, 8, 0, 3, "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A328PropostaCratedBy), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A329PropostaStatus));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbPropostaStatus_Columnclass));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A228ContratoNome));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A330PropostaQuantidadeAprovadores), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A345PropostaReprovacoesPermitidas), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A341PropostaAprovacoes_F), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A342PropostaReprovacoes_F), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A343PropostaAprovacoesRestantes_F), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A505PropostaPacienteClienteRazaoSocial));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A548ReembolsoStatusAtual_F));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbReembolsoStatusAtual_F_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbReembolsoStatusAtual_F_Columnheaderclass));
            GridContainer.AddColumnProperties(GridColumn);
            GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         bttBtnexport_Internalname = "BTNEXPORT";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         divTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         lblDynamicfiltersprefix1_Internalname = "DYNAMICFILTERSPREFIX1";
         cmbavDynamicfiltersselector1_Internalname = "vDYNAMICFILTERSSELECTOR1";
         lblDynamicfiltersmiddle1_Internalname = "DYNAMICFILTERSMIDDLE1";
         cmbavDynamicfiltersoperator1_Internalname = "vDYNAMICFILTERSOPERATOR1";
         edtavPropostatitulo1_Internalname = "vPROPOSTATITULO1";
         cellFilter_propostatitulo1_cell_Internalname = "FILTER_PROPOSTATITULO1_CELL";
         edtavContratonome1_Internalname = "vCONTRATONOME1";
         cellFilter_contratonome1_cell_Internalname = "FILTER_CONTRATONOME1_CELL";
         imgAdddynamicfilters1_Internalname = "ADDDYNAMICFILTERS1";
         cellDynamicfilters_addfilter1_cell_Internalname = "DYNAMICFILTERS_ADDFILTER1_CELL";
         imgRemovedynamicfilters1_Internalname = "REMOVEDYNAMICFILTERS1";
         cellDynamicfilters_removefilter1_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER1_CELL";
         tblTablemergeddynamicfilters1_Internalname = "TABLEMERGEDDYNAMICFILTERS1";
         divTabledynamicfiltersrow1_Internalname = "TABLEDYNAMICFILTERSROW1";
         lblDynamicfiltersprefix2_Internalname = "DYNAMICFILTERSPREFIX2";
         cmbavDynamicfiltersselector2_Internalname = "vDYNAMICFILTERSSELECTOR2";
         lblDynamicfiltersmiddle2_Internalname = "DYNAMICFILTERSMIDDLE2";
         cmbavDynamicfiltersoperator2_Internalname = "vDYNAMICFILTERSOPERATOR2";
         edtavPropostatitulo2_Internalname = "vPROPOSTATITULO2";
         cellFilter_propostatitulo2_cell_Internalname = "FILTER_PROPOSTATITULO2_CELL";
         edtavContratonome2_Internalname = "vCONTRATONOME2";
         cellFilter_contratonome2_cell_Internalname = "FILTER_CONTRATONOME2_CELL";
         imgAdddynamicfilters2_Internalname = "ADDDYNAMICFILTERS2";
         cellDynamicfilters_addfilter2_cell_Internalname = "DYNAMICFILTERS_ADDFILTER2_CELL";
         imgRemovedynamicfilters2_Internalname = "REMOVEDYNAMICFILTERS2";
         cellDynamicfilters_removefilter2_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER2_CELL";
         tblTablemergeddynamicfilters2_Internalname = "TABLEMERGEDDYNAMICFILTERS2";
         divTabledynamicfiltersrow2_Internalname = "TABLEDYNAMICFILTERSROW2";
         lblDynamicfiltersprefix3_Internalname = "DYNAMICFILTERSPREFIX3";
         cmbavDynamicfiltersselector3_Internalname = "vDYNAMICFILTERSSELECTOR3";
         lblDynamicfiltersmiddle3_Internalname = "DYNAMICFILTERSMIDDLE3";
         cmbavDynamicfiltersoperator3_Internalname = "vDYNAMICFILTERSOPERATOR3";
         edtavPropostatitulo3_Internalname = "vPROPOSTATITULO3";
         cellFilter_propostatitulo3_cell_Internalname = "FILTER_PROPOSTATITULO3_CELL";
         edtavContratonome3_Internalname = "vCONTRATONOME3";
         cellFilter_contratonome3_cell_Internalname = "FILTER_CONTRATONOME3_CELL";
         imgRemovedynamicfilters3_Internalname = "REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = "TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = "TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = "TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = "ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = "TABLEHEADER";
         Dvpanel_tableheader_Internalname = "DVPANEL_TABLEHEADER";
         edtavReembolso_Internalname = "vREEMBOLSO";
         edtPropostaId_Internalname = "PROPOSTAID";
         edtProcedimentosMedicosNome_Internalname = "PROCEDIMENTOSMEDICOSNOME";
         edtProcedimentosMedicosId_Internalname = "PROCEDIMENTOSMEDICOSID";
         edtPropostaDescricao_Internalname = "PROPOSTADESCRICAO";
         edtPropostaValor_Internalname = "PROPOSTAVALOR";
         edtPropostaCreatedAt_Internalname = "PROPOSTACREATEDAT";
         edtPropostaCratedBy_Internalname = "PROPOSTACRATEDBY";
         cmbPropostaStatus_Internalname = "PROPOSTASTATUS";
         edtContratoId_Internalname = "CONTRATOID";
         edtContratoNome_Internalname = "CONTRATONOME";
         edtPropostaQuantidadeAprovadores_Internalname = "PROPOSTAQUANTIDADEAPROVADORES";
         edtPropostaReprovacoesPermitidas_Internalname = "PROPOSTAREPROVACOESPERMITIDAS";
         edtPropostaAprovacoes_F_Internalname = "PROPOSTAAPROVACOES_F";
         edtPropostaReprovacoes_F_Internalname = "PROPOSTAREPROVACOES_F";
         edtPropostaAprovacoesRestantes_F_Internalname = "PROPOSTAAPROVACOESRESTANTES_F";
         edtPropostaPacienteClienteRazaoSocial_Internalname = "PROPOSTAPACIENTECLIENTERAZAOSOCIAL";
         cmbReembolsoStatusAtual_F_Internalname = "REEMBOLSOSTATUSATUAL_F";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         lblJsdynamicfilters_Internalname = "JSDYNAMICFILTERS";
         Ddo_grid_Internalname = "DDO_GRID";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         cmbReembolsoStatusAtual_F_Jsonclick = "";
         cmbReembolsoStatusAtual_F_Columnclass = "WWColumn hidden-xs";
         edtPropostaPacienteClienteRazaoSocial_Jsonclick = "";
         edtPropostaAprovacoesRestantes_F_Jsonclick = "";
         edtPropostaReprovacoes_F_Jsonclick = "";
         edtPropostaAprovacoes_F_Jsonclick = "";
         edtPropostaReprovacoesPermitidas_Jsonclick = "";
         edtPropostaQuantidadeAprovadores_Jsonclick = "";
         edtContratoNome_Jsonclick = "";
         edtContratoId_Jsonclick = "";
         cmbPropostaStatus_Jsonclick = "";
         cmbPropostaStatus_Columnclass = "WWColumn";
         edtPropostaCratedBy_Jsonclick = "";
         edtPropostaCreatedAt_Jsonclick = "";
         edtPropostaValor_Jsonclick = "";
         edtPropostaDescricao_Jsonclick = "";
         edtProcedimentosMedicosId_Jsonclick = "";
         edtProcedimentosMedicosNome_Jsonclick = "";
         edtPropostaId_Jsonclick = "";
         edtavReembolso_Jsonclick = "";
         edtavReembolso_Link = "";
         edtavReembolso_Enabled = 0;
         subGrid_Class = "GridWithPaginationBar GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavContratonome1_Jsonclick = "";
         edtavContratonome1_Enabled = 1;
         edtavPropostatitulo1_Jsonclick = "";
         edtavPropostatitulo1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavContratonome2_Jsonclick = "";
         edtavContratonome2_Enabled = 1;
         edtavPropostatitulo2_Jsonclick = "";
         edtavPropostatitulo2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavContratonome3_Jsonclick = "";
         edtavContratonome3_Enabled = 1;
         edtavPropostatitulo3_Jsonclick = "";
         edtavPropostatitulo3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavContratonome3_Visible = 1;
         edtavPropostatitulo3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavContratonome2_Visible = 1;
         edtavPropostatitulo2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavContratonome1_Visible = 1;
         edtavPropostatitulo1_Visible = 1;
         cmbReembolsoStatusAtual_F_Columnheaderclass = "";
         cmbReembolsoStatusAtual_F.Enabled = 0;
         edtPropostaPacienteClienteRazaoSocial_Enabled = 0;
         edtPropostaAprovacoesRestantes_F_Enabled = 0;
         edtPropostaReprovacoes_F_Enabled = 0;
         edtPropostaAprovacoes_F_Enabled = 0;
         edtPropostaReprovacoesPermitidas_Enabled = 0;
         edtPropostaQuantidadeAprovadores_Enabled = 0;
         edtContratoNome_Enabled = 0;
         edtContratoId_Enabled = 0;
         cmbPropostaStatus.Enabled = 0;
         edtPropostaCratedBy_Enabled = 0;
         edtPropostaCreatedAt_Enabled = 0;
         edtPropostaValor_Enabled = 0;
         edtPropostaDescricao_Enabled = 0;
         edtProcedimentosMedicosId_Enabled = 0;
         edtProcedimentosMedicosNome_Enabled = 0;
         edtPropostaId_Enabled = 0;
         subGrid_Sortable = 0;
         lblJsdynamicfilters_Caption = "JSDynamicFilters";
         cmbavDynamicfiltersselector3_Jsonclick = "";
         cmbavDynamicfiltersselector3.Enabled = 1;
         cmbavDynamicfiltersselector2_Jsonclick = "";
         cmbavDynamicfiltersselector2.Enabled = 1;
         cmbavDynamicfiltersselector1_Jsonclick = "";
         cmbavDynamicfiltersselector1.Enabled = 1;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Format = "||18.2|||";
         Ddo_grid_Datalistproc = "PropostaContratoAdmWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|||||EM_ANALISE:Em an�lise,FINALIZADO:Finalizado,REANALISE:Rean�lise,:N�o iniciado";
         Ddo_grid_Allowmultipleselection = "|||||T";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic||Dynamic|Dynamic|FixedValues";
         Ddo_grid_Includedatalist = "T|T||T|T|T";
         Ddo_grid_Filterisrange = "||T|||";
         Ddo_grid_Filtertype = "Character|Character|Numeric|Character|Character|";
         Ddo_grid_Includefilter = "T|T|T|T|T|";
         Ddo_grid_Includesortasc = "T|T|T|T|T|";
         Ddo_grid_Columnssortvalues = "2|3|4|5|6|";
         Ddo_grid_Columnids = "2:ProcedimentosMedicosNome|4:PropostaDescricao|5:PropostaValor|10:ContratoNome|16:PropostaPacienteClienteRazaoSocial|17:ReembolsoStatusAtual_F";
         Ddo_grid_Gridinternalname = "";
         Gridpaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridpaginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Gridpaginationbar_Caption = "P�gina <CURRENT_PAGE> de <TOTAL_PAGES>";
         Gridpaginationbar_Next = "WWP_PagingNextCaption";
         Gridpaginationbar_Previous = "WWP_PagingPreviousCaption";
         Gridpaginationbar_Rowsperpageoptions = "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50";
         Gridpaginationbar_Rowsperpageselectedvalue = 10;
         Gridpaginationbar_Rowsperpageselector = Convert.ToBoolean( -1);
         Gridpaginationbar_Emptygridclass = "PaginationBarEmptyGrid";
         Gridpaginationbar_Pagingcaptionposition = "Left";
         Gridpaginationbar_Pagingbuttonsposition = "Right";
         Gridpaginationbar_Pagestoshow = 5;
         Gridpaginationbar_Showlast = Convert.ToBoolean( 0);
         Gridpaginationbar_Shownext = Convert.ToBoolean( -1);
         Gridpaginationbar_Showprevious = Convert.ToBoolean( -1);
         Gridpaginationbar_Showfirst = Convert.ToBoolean( 0);
         Gridpaginationbar_Class = "PaginationBar";
         Dvpanel_tableheader_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableheader_Iconposition = "Right";
         Dvpanel_tableheader_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableheader_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableheader_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_tableheader_Title = "Op��es";
         Dvpanel_tableheader_Cls = "PanelNoHeader";
         Dvpanel_tableheader_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableheader_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableheader_Width = "100%";
         Ddo_managefilters_Cls = "ManageFilters";
         Ddo_managefilters_Tooltip = "WWP_ManageFiltersTooltip";
         Ddo_managefilters_Icon = "fas fa-filter";
         Ddo_managefilters_Icontype = "FontIcon";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = " Propostas";
         subGrid_Rows = 0;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18PropostaTitulo1","fld":"vPROPOSTATITULO1","type":"svchar"},{"av":"AV69ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22PropostaTitulo2","fld":"vPROPOSTATITULO2","type":"svchar"},{"av":"AV70ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26PropostaTitulo3","fld":"vPROPOSTATITULO3","type":"svchar"},{"av":"AV71ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV96Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV82TFProcedimentosMedicosNome","fld":"vTFPROCEDIMENTOSMEDICOSNOME","type":"svchar"},{"av":"AV83TFProcedimentosMedicosNome_Sel","fld":"vTFPROCEDIMENTOSMEDICOSNOME_SEL","type":"svchar"},{"av":"AV39TFPropostaDescricao","fld":"vTFPROPOSTADESCRICAO","type":"svchar"},{"av":"AV40TFPropostaDescricao_Sel","fld":"vTFPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV41TFPropostaValor","fld":"vTFPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV42TFPropostaValor_To","fld":"vTFPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV65TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV66TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV91TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV92TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV95TFReembolsoStatusAtual_F_Sels","fld":"vTFREEMBOLSOSTATUSATUAL_F_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV84Context","fld":"vCONTEXT","hsh":true,"type":""}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV6WWPContext","fld":"vWWPCONTEXT","type":""},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV58GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV59GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV60GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbReembolsoStatusAtual_F"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E127M2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18PropostaTitulo1","fld":"vPROPOSTATITULO1","type":"svchar"},{"av":"AV69ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22PropostaTitulo2","fld":"vPROPOSTATITULO2","type":"svchar"},{"av":"AV70ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26PropostaTitulo3","fld":"vPROPOSTATITULO3","type":"svchar"},{"av":"AV71ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV96Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV82TFProcedimentosMedicosNome","fld":"vTFPROCEDIMENTOSMEDICOSNOME","type":"svchar"},{"av":"AV83TFProcedimentosMedicosNome_Sel","fld":"vTFPROCEDIMENTOSMEDICOSNOME_SEL","type":"svchar"},{"av":"AV39TFPropostaDescricao","fld":"vTFPROPOSTADESCRICAO","type":"svchar"},{"av":"AV40TFPropostaDescricao_Sel","fld":"vTFPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV41TFPropostaValor","fld":"vTFPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV42TFPropostaValor_To","fld":"vTFPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV65TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV66TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV91TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV92TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV95TFReembolsoStatusAtual_F_Sels","fld":"vTFREEMBOLSOSTATUSATUAL_F_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV84Context","fld":"vCONTEXT","hsh":true,"type":""},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E137M2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18PropostaTitulo1","fld":"vPROPOSTATITULO1","type":"svchar"},{"av":"AV69ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22PropostaTitulo2","fld":"vPROPOSTATITULO2","type":"svchar"},{"av":"AV70ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26PropostaTitulo3","fld":"vPROPOSTATITULO3","type":"svchar"},{"av":"AV71ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV96Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV82TFProcedimentosMedicosNome","fld":"vTFPROCEDIMENTOSMEDICOSNOME","type":"svchar"},{"av":"AV83TFProcedimentosMedicosNome_Sel","fld":"vTFPROCEDIMENTOSMEDICOSNOME_SEL","type":"svchar"},{"av":"AV39TFPropostaDescricao","fld":"vTFPROPOSTADESCRICAO","type":"svchar"},{"av":"AV40TFPropostaDescricao_Sel","fld":"vTFPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV41TFPropostaValor","fld":"vTFPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV42TFPropostaValor_To","fld":"vTFPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV65TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV66TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV91TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV92TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV95TFReembolsoStatusAtual_F_Sels","fld":"vTFREEMBOLSOSTATUSATUAL_F_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV84Context","fld":"vCONTEXT","hsh":true,"type":""},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E147M2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18PropostaTitulo1","fld":"vPROPOSTATITULO1","type":"svchar"},{"av":"AV69ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22PropostaTitulo2","fld":"vPROPOSTATITULO2","type":"svchar"},{"av":"AV70ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26PropostaTitulo3","fld":"vPROPOSTATITULO3","type":"svchar"},{"av":"AV71ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV96Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV82TFProcedimentosMedicosNome","fld":"vTFPROCEDIMENTOSMEDICOSNOME","type":"svchar"},{"av":"AV83TFProcedimentosMedicosNome_Sel","fld":"vTFPROCEDIMENTOSMEDICOSNOME_SEL","type":"svchar"},{"av":"AV39TFPropostaDescricao","fld":"vTFPROPOSTADESCRICAO","type":"svchar"},{"av":"AV40TFPropostaDescricao_Sel","fld":"vTFPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV41TFPropostaValor","fld":"vTFPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV42TFPropostaValor_To","fld":"vTFPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV65TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV66TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV91TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV92TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV95TFReembolsoStatusAtual_F_Sels","fld":"vTFREEMBOLSOSTATUSATUAL_F_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV84Context","fld":"vCONTEXT","hsh":true,"type":""},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV94TFReembolsoStatusAtual_F_SelsJson","fld":"vTFREEMBOLSOSTATUSATUAL_F_SELSJSON","type":"vchar"},{"av":"AV95TFReembolsoStatusAtual_F_Sels","fld":"vTFREEMBOLSOSTATUSATUAL_F_SELS","type":""},{"av":"AV91TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV92TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV65TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV66TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV41TFPropostaValor","fld":"vTFPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV42TFPropostaValor_To","fld":"vTFPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV39TFPropostaDescricao","fld":"vTFPROPOSTADESCRICAO","type":"svchar"},{"av":"AV40TFPropostaDescricao_Sel","fld":"vTFPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV82TFProcedimentosMedicosNome","fld":"vTFPROCEDIMENTOSMEDICOSNOME","type":"svchar"},{"av":"AV83TFProcedimentosMedicosNome_Sel","fld":"vTFPROCEDIMENTOSMEDICOSNOME_SEL","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E267M2","iparms":[{"av":"AV84Context","fld":"vCONTEXT","hsh":true,"type":""},{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"cmbPropostaStatus"},{"av":"A329PropostaStatus","fld":"PROPOSTASTATUS","type":"svchar"},{"av":"cmbReembolsoStatusAtual_F"},{"av":"A548ReembolsoStatusAtual_F","fld":"REEMBOLSOSTATUSATUAL_F","type":"svchar"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"A40000GXC1","fld":"GXC1","pic":"999999999","type":"int"},{"av":"AV93Reembolso","fld":"vREEMBOLSO","type":"char"},{"av":"edtavReembolso_Link","ctrl":"vREEMBOLSO","prop":"Link"},{"av":"cmbPropostaStatus"},{"av":"cmbReembolsoStatusAtual_F"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E197M2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18PropostaTitulo1","fld":"vPROPOSTATITULO1","type":"svchar"},{"av":"AV69ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22PropostaTitulo2","fld":"vPROPOSTATITULO2","type":"svchar"},{"av":"AV70ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26PropostaTitulo3","fld":"vPROPOSTATITULO3","type":"svchar"},{"av":"AV71ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV96Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV82TFProcedimentosMedicosNome","fld":"vTFPROCEDIMENTOSMEDICOSNOME","type":"svchar"},{"av":"AV83TFProcedimentosMedicosNome_Sel","fld":"vTFPROCEDIMENTOSMEDICOSNOME_SEL","type":"svchar"},{"av":"AV39TFPropostaDescricao","fld":"vTFPROPOSTADESCRICAO","type":"svchar"},{"av":"AV40TFPropostaDescricao_Sel","fld":"vTFPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV41TFPropostaValor","fld":"vTFPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV42TFPropostaValor_To","fld":"vTFPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV65TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV66TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV91TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV92TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV95TFReembolsoStatusAtual_F_Sels","fld":"vTFREEMBOLSOSTATUSATUAL_F_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV84Context","fld":"vCONTEXT","hsh":true,"type":""}]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","type":""},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV58GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV59GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV60GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbReembolsoStatusAtual_F"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E157M2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18PropostaTitulo1","fld":"vPROPOSTATITULO1","type":"svchar"},{"av":"AV69ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22PropostaTitulo2","fld":"vPROPOSTATITULO2","type":"svchar"},{"av":"AV70ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26PropostaTitulo3","fld":"vPROPOSTATITULO3","type":"svchar"},{"av":"AV71ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV96Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV82TFProcedimentosMedicosNome","fld":"vTFPROCEDIMENTOSMEDICOSNOME","type":"svchar"},{"av":"AV83TFProcedimentosMedicosNome_Sel","fld":"vTFPROCEDIMENTOSMEDICOSNOME_SEL","type":"svchar"},{"av":"AV39TFPropostaDescricao","fld":"vTFPROPOSTADESCRICAO","type":"svchar"},{"av":"AV40TFPropostaDescricao_Sel","fld":"vTFPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV41TFPropostaValor","fld":"vTFPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV42TFPropostaValor_To","fld":"vTFPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV65TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV66TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV91TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV92TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV95TFReembolsoStatusAtual_F_Sels","fld":"vTFREEMBOLSOSTATUSATUAL_F_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV84Context","fld":"vCONTEXT","hsh":true,"type":""}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22PropostaTitulo2","fld":"vPROPOSTATITULO2","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26PropostaTitulo3","fld":"vPROPOSTATITULO3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18PropostaTitulo1","fld":"vPROPOSTATITULO1","type":"svchar"},{"av":"AV69ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV70ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV71ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"edtavPropostatitulo2_Visible","ctrl":"vPROPOSTATITULO2","prop":"Visible"},{"av":"edtavContratonome2_Visible","ctrl":"vCONTRATONOME2","prop":"Visible"},{"av":"edtavPropostatitulo3_Visible","ctrl":"vPROPOSTATITULO3","prop":"Visible"},{"av":"edtavContratonome3_Visible","ctrl":"vCONTRATONOME3","prop":"Visible"},{"av":"edtavPropostatitulo1_Visible","ctrl":"vPROPOSTATITULO1","prop":"Visible"},{"av":"edtavContratonome1_Visible","ctrl":"vCONTRATONOME1","prop":"Visible"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","type":""},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV58GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV59GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV60GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbReembolsoStatusAtual_F"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E207M2","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"edtavPropostatitulo1_Visible","ctrl":"vPROPOSTATITULO1","prop":"Visible"},{"av":"edtavContratonome1_Visible","ctrl":"vCONTRATONOME1","prop":"Visible"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E217M2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18PropostaTitulo1","fld":"vPROPOSTATITULO1","type":"svchar"},{"av":"AV69ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22PropostaTitulo2","fld":"vPROPOSTATITULO2","type":"svchar"},{"av":"AV70ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26PropostaTitulo3","fld":"vPROPOSTATITULO3","type":"svchar"},{"av":"AV71ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV96Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV82TFProcedimentosMedicosNome","fld":"vTFPROCEDIMENTOSMEDICOSNOME","type":"svchar"},{"av":"AV83TFProcedimentosMedicosNome_Sel","fld":"vTFPROCEDIMENTOSMEDICOSNOME_SEL","type":"svchar"},{"av":"AV39TFPropostaDescricao","fld":"vTFPROPOSTADESCRICAO","type":"svchar"},{"av":"AV40TFPropostaDescricao_Sel","fld":"vTFPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV41TFPropostaValor","fld":"vTFPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV42TFPropostaValor_To","fld":"vTFPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV65TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV66TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV91TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV92TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV95TFReembolsoStatusAtual_F_Sels","fld":"vTFREEMBOLSOSTATUSATUAL_F_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV84Context","fld":"vCONTEXT","hsh":true,"type":""}]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","type":""},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV58GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV59GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV60GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbReembolsoStatusAtual_F"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E167M2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18PropostaTitulo1","fld":"vPROPOSTATITULO1","type":"svchar"},{"av":"AV69ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22PropostaTitulo2","fld":"vPROPOSTATITULO2","type":"svchar"},{"av":"AV70ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26PropostaTitulo3","fld":"vPROPOSTATITULO3","type":"svchar"},{"av":"AV71ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV96Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV82TFProcedimentosMedicosNome","fld":"vTFPROCEDIMENTOSMEDICOSNOME","type":"svchar"},{"av":"AV83TFProcedimentosMedicosNome_Sel","fld":"vTFPROCEDIMENTOSMEDICOSNOME_SEL","type":"svchar"},{"av":"AV39TFPropostaDescricao","fld":"vTFPROPOSTADESCRICAO","type":"svchar"},{"av":"AV40TFPropostaDescricao_Sel","fld":"vTFPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV41TFPropostaValor","fld":"vTFPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV42TFPropostaValor_To","fld":"vTFPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV65TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV66TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV91TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV92TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV95TFReembolsoStatusAtual_F_Sels","fld":"vTFREEMBOLSOSTATUSATUAL_F_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV84Context","fld":"vCONTEXT","hsh":true,"type":""}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22PropostaTitulo2","fld":"vPROPOSTATITULO2","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26PropostaTitulo3","fld":"vPROPOSTATITULO3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18PropostaTitulo1","fld":"vPROPOSTATITULO1","type":"svchar"},{"av":"AV69ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV70ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV71ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"edtavPropostatitulo2_Visible","ctrl":"vPROPOSTATITULO2","prop":"Visible"},{"av":"edtavContratonome2_Visible","ctrl":"vCONTRATONOME2","prop":"Visible"},{"av":"edtavPropostatitulo3_Visible","ctrl":"vPROPOSTATITULO3","prop":"Visible"},{"av":"edtavContratonome3_Visible","ctrl":"vCONTRATONOME3","prop":"Visible"},{"av":"edtavPropostatitulo1_Visible","ctrl":"vPROPOSTATITULO1","prop":"Visible"},{"av":"edtavContratonome1_Visible","ctrl":"vCONTRATONOME1","prop":"Visible"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","type":""},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV58GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV59GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV60GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbReembolsoStatusAtual_F"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E227M2","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"edtavPropostatitulo2_Visible","ctrl":"vPROPOSTATITULO2","prop":"Visible"},{"av":"edtavContratonome2_Visible","ctrl":"vCONTRATONOME2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E177M2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18PropostaTitulo1","fld":"vPROPOSTATITULO1","type":"svchar"},{"av":"AV69ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22PropostaTitulo2","fld":"vPROPOSTATITULO2","type":"svchar"},{"av":"AV70ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26PropostaTitulo3","fld":"vPROPOSTATITULO3","type":"svchar"},{"av":"AV71ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV96Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV82TFProcedimentosMedicosNome","fld":"vTFPROCEDIMENTOSMEDICOSNOME","type":"svchar"},{"av":"AV83TFProcedimentosMedicosNome_Sel","fld":"vTFPROCEDIMENTOSMEDICOSNOME_SEL","type":"svchar"},{"av":"AV39TFPropostaDescricao","fld":"vTFPROPOSTADESCRICAO","type":"svchar"},{"av":"AV40TFPropostaDescricao_Sel","fld":"vTFPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV41TFPropostaValor","fld":"vTFPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV42TFPropostaValor_To","fld":"vTFPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV65TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV66TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV91TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV92TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV95TFReembolsoStatusAtual_F_Sels","fld":"vTFREEMBOLSOSTATUSATUAL_F_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV84Context","fld":"vCONTEXT","hsh":true,"type":""}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22PropostaTitulo2","fld":"vPROPOSTATITULO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26PropostaTitulo3","fld":"vPROPOSTATITULO3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18PropostaTitulo1","fld":"vPROPOSTATITULO1","type":"svchar"},{"av":"AV69ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV70ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV71ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"edtavPropostatitulo2_Visible","ctrl":"vPROPOSTATITULO2","prop":"Visible"},{"av":"edtavContratonome2_Visible","ctrl":"vCONTRATONOME2","prop":"Visible"},{"av":"edtavPropostatitulo3_Visible","ctrl":"vPROPOSTATITULO3","prop":"Visible"},{"av":"edtavContratonome3_Visible","ctrl":"vCONTRATONOME3","prop":"Visible"},{"av":"edtavPropostatitulo1_Visible","ctrl":"vPROPOSTATITULO1","prop":"Visible"},{"av":"edtavContratonome1_Visible","ctrl":"vCONTRATONOME1","prop":"Visible"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","type":""},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV58GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV59GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV60GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbReembolsoStatusAtual_F"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E237M2","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"edtavPropostatitulo3_Visible","ctrl":"vPROPOSTATITULO3","prop":"Visible"},{"av":"edtavContratonome3_Visible","ctrl":"vCONTRATONOME3","prop":"Visible"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E117M2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18PropostaTitulo1","fld":"vPROPOSTATITULO1","type":"svchar"},{"av":"AV69ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22PropostaTitulo2","fld":"vPROPOSTATITULO2","type":"svchar"},{"av":"AV70ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26PropostaTitulo3","fld":"vPROPOSTATITULO3","type":"svchar"},{"av":"AV71ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV96Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV82TFProcedimentosMedicosNome","fld":"vTFPROCEDIMENTOSMEDICOSNOME","type":"svchar"},{"av":"AV83TFProcedimentosMedicosNome_Sel","fld":"vTFPROCEDIMENTOSMEDICOSNOME_SEL","type":"svchar"},{"av":"AV39TFPropostaDescricao","fld":"vTFPROPOSTADESCRICAO","type":"svchar"},{"av":"AV40TFPropostaDescricao_Sel","fld":"vTFPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV41TFPropostaValor","fld":"vTFPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV42TFPropostaValor_To","fld":"vTFPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV65TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV66TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV91TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV92TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV95TFReembolsoStatusAtual_F_Sels","fld":"vTFREEMBOLSOSTATUSATUAL_F_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV84Context","fld":"vCONTEXT","hsh":true,"type":""},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV94TFReembolsoStatusAtual_F_SelsJson","fld":"vTFREEMBOLSOSTATUSATUAL_F_SELSJSON","type":"vchar"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV82TFProcedimentosMedicosNome","fld":"vTFPROCEDIMENTOSMEDICOSNOME","type":"svchar"},{"av":"AV83TFProcedimentosMedicosNome_Sel","fld":"vTFPROCEDIMENTOSMEDICOSNOME_SEL","type":"svchar"},{"av":"AV39TFPropostaDescricao","fld":"vTFPROPOSTADESCRICAO","type":"svchar"},{"av":"AV40TFPropostaDescricao_Sel","fld":"vTFPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV41TFPropostaValor","fld":"vTFPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV42TFPropostaValor_To","fld":"vTFPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV65TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV66TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV91TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV92TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV95TFReembolsoStatusAtual_F_Sels","fld":"vTFREEMBOLSOSTATUSATUAL_F_SELS","type":""},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18PropostaTitulo1","fld":"vPROPOSTATITULO1","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV94TFReembolsoStatusAtual_F_SelsJson","fld":"vTFREEMBOLSOSTATUSATUAL_F_SELSJSON","type":"vchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"AV69ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22PropostaTitulo2","fld":"vPROPOSTATITULO2","type":"svchar"},{"av":"AV70ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26PropostaTitulo3","fld":"vPROPOSTATITULO3","type":"svchar"},{"av":"AV71ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"edtavPropostatitulo1_Visible","ctrl":"vPROPOSTATITULO1","prop":"Visible"},{"av":"edtavContratonome1_Visible","ctrl":"vCONTRATONOME1","prop":"Visible"},{"av":"edtavPropostatitulo2_Visible","ctrl":"vPROPOSTATITULO2","prop":"Visible"},{"av":"edtavContratonome2_Visible","ctrl":"vCONTRATONOME2","prop":"Visible"},{"av":"edtavPropostatitulo3_Visible","ctrl":"vPROPOSTATITULO3","prop":"Visible"},{"av":"edtavContratonome3_Visible","ctrl":"vCONTRATONOME3","prop":"Visible"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","type":""},{"av":"AV58GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV59GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV60GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbReembolsoStatusAtual_F"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("'DOEXPORT'","""{"handler":"E187M2","iparms":[{"av":"AV96Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV83TFProcedimentosMedicosNome_Sel","fld":"vTFPROCEDIMENTOSMEDICOSNOME_SEL","type":"svchar"},{"av":"AV40TFPropostaDescricao_Sel","fld":"vTFPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV66TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV92TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV95TFReembolsoStatusAtual_F_Sels","fld":"vTFREEMBOLSOSTATUSATUAL_F_SELS","type":""},{"av":"AV94TFReembolsoStatusAtual_F_SelsJson","fld":"vTFREEMBOLSOSTATUSATUAL_F_SELSJSON","type":"vchar"},{"av":"AV82TFProcedimentosMedicosNome","fld":"vTFPROCEDIMENTOSMEDICOSNOME","type":"svchar"},{"av":"AV39TFPropostaDescricao","fld":"vTFPROPOSTADESCRICAO","type":"svchar"},{"av":"AV41TFPropostaValor","fld":"vTFPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV65TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV91TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV42TFPropostaValor_To","fld":"vTFPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("'DOEXPORT'",""","oparms":[{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18PropostaTitulo1","fld":"vPROPOSTATITULO1","type":"svchar"},{"av":"AV69ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22PropostaTitulo2","fld":"vPROPOSTATITULO2","type":"svchar"},{"av":"AV70ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26PropostaTitulo3","fld":"vPROPOSTATITULO3","type":"svchar"},{"av":"AV71ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV96Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV82TFProcedimentosMedicosNome","fld":"vTFPROCEDIMENTOSMEDICOSNOME","type":"svchar"},{"av":"AV83TFProcedimentosMedicosNome_Sel","fld":"vTFPROCEDIMENTOSMEDICOSNOME_SEL","type":"svchar"},{"av":"AV39TFPropostaDescricao","fld":"vTFPROPOSTADESCRICAO","type":"svchar"},{"av":"AV40TFPropostaDescricao_Sel","fld":"vTFPROPOSTADESCRICAO_SEL","type":"svchar"},{"av":"AV41TFPropostaValor","fld":"vTFPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV42TFPropostaValor_To","fld":"vTFPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV65TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV66TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV91TFPropostaPacienteClienteRazaoSocial","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV92TFPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV95TFReembolsoStatusAtual_F_Sels","fld":"vTFREEMBOLSOSTATUSATUAL_F_SELS","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV84Context","fld":"vCONTEXT","hsh":true,"type":""},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV94TFReembolsoStatusAtual_F_SelsJson","fld":"vTFREEMBOLSOSTATUSATUAL_F_SELSJSON","type":"vchar"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavPropostatitulo1_Visible","ctrl":"vPROPOSTATITULO1","prop":"Visible"},{"av":"edtavContratonome1_Visible","ctrl":"vCONTRATONOME1","prop":"Visible"},{"av":"edtavPropostatitulo2_Visible","ctrl":"vPROPOSTATITULO2","prop":"Visible"},{"av":"edtavContratonome2_Visible","ctrl":"vCONTRATONOME2","prop":"Visible"},{"av":"edtavPropostatitulo3_Visible","ctrl":"vPROPOSTATITULO3","prop":"Visible"},{"av":"edtavContratonome3_Visible","ctrl":"vCONTRATONOME3","prop":"Visible"}]}""");
         setEventMetadata("VALID_PROPOSTAID","""{"handler":"Valid_Propostaid","iparms":[]}""");
         setEventMetadata("VALID_PROCEDIMENTOSMEDICOSID","""{"handler":"Valid_Procedimentosmedicosid","iparms":[]}""");
         setEventMetadata("VALID_CONTRATOID","""{"handler":"Valid_Contratoid","iparms":[]}""");
         setEventMetadata("VALID_PROPOSTAQUANTIDADEAPROVADORES","""{"handler":"Valid_Propostaquantidadeaprovadores","iparms":[]}""");
         setEventMetadata("VALID_PROPOSTAAPROVACOES_F","""{"handler":"Valid_Propostaaprovacoes_f","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Reembolsostatusatual_f","iparms":[]}""");
         return  ;
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      public override void initialize( )
      {
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Filteredtextto_get = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV16DynamicFiltersSelector1 = "";
         AV18PropostaTitulo1 = "";
         AV69ContratoNome1 = "";
         AV20DynamicFiltersSelector2 = "";
         AV22PropostaTitulo2 = "";
         AV70ContratoNome2 = "";
         AV24DynamicFiltersSelector3 = "";
         AV26PropostaTitulo3 = "";
         AV71ContratoNome3 = "";
         AV96Pgmname = "";
         AV15FilterFullText = "";
         AV82TFProcedimentosMedicosNome = "";
         AV83TFProcedimentosMedicosNome_Sel = "";
         AV39TFPropostaDescricao = "";
         AV40TFPropostaDescricao_Sel = "";
         AV65TFContratoNome = "";
         AV66TFContratoNome_Sel = "";
         AV91TFPropostaPacienteClienteRazaoSocial = "";
         AV92TFPropostaPacienteClienteRazaoSocial_Sel = "";
         AV95TFReembolsoStatusAtual_F_Sels = new GxSimpleCollection<string>();
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV84Context = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV32ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV60GridAppliedFilters = "";
         AV56DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV94TFReembolsoStatusAtual_F_SelsJson = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ucDvpanel_tableheader = new GXUserControl();
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnexport_Jsonclick = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         lblDynamicfiltersprefix1_Jsonclick = "";
         lblDynamicfiltersmiddle1_Jsonclick = "";
         lblDynamicfiltersprefix2_Jsonclick = "";
         lblDynamicfiltersmiddle2_Jsonclick = "";
         lblDynamicfiltersprefix3_Jsonclick = "";
         lblDynamicfiltersmiddle3_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         lblJsdynamicfilters_Jsonclick = "";
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV93Reembolso = "";
         A377ProcedimentosMedicosNome = "";
         A325PropostaDescricao = "";
         A327PropostaCreatedAt = (DateTime)(DateTime.MinValue);
         A329PropostaStatus = "";
         A228ContratoNome = "";
         A505PropostaPacienteClienteRazaoSocial = "";
         A548ReembolsoStatusAtual_F = "";
         AV122Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels = new GxSimpleCollection<string>();
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         lV97Propostacontratoadmwwds_1_filterfulltext = "";
         lV100Propostacontratoadmwwds_4_propostatitulo1 = "";
         lV101Propostacontratoadmwwds_5_contratonome1 = "";
         lV105Propostacontratoadmwwds_9_propostatitulo2 = "";
         lV106Propostacontratoadmwwds_10_contratonome2 = "";
         lV110Propostacontratoadmwwds_14_propostatitulo3 = "";
         lV111Propostacontratoadmwwds_15_contratonome3 = "";
         lV112Propostacontratoadmwwds_16_tfprocedimentosmedicosnome = "";
         lV114Propostacontratoadmwwds_18_tfpropostadescricao = "";
         lV118Propostacontratoadmwwds_22_tfcontratonome = "";
         lV120Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial = "";
         AV98Propostacontratoadmwwds_2_dynamicfiltersselector1 = "";
         AV100Propostacontratoadmwwds_4_propostatitulo1 = "";
         AV101Propostacontratoadmwwds_5_contratonome1 = "";
         AV103Propostacontratoadmwwds_7_dynamicfiltersselector2 = "";
         AV105Propostacontratoadmwwds_9_propostatitulo2 = "";
         AV106Propostacontratoadmwwds_10_contratonome2 = "";
         AV108Propostacontratoadmwwds_12_dynamicfiltersselector3 = "";
         AV110Propostacontratoadmwwds_14_propostatitulo3 = "";
         AV111Propostacontratoadmwwds_15_contratonome3 = "";
         AV113Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel = "";
         AV112Propostacontratoadmwwds_16_tfprocedimentosmedicosnome = "";
         AV115Propostacontratoadmwwds_19_tfpropostadescricao_sel = "";
         AV114Propostacontratoadmwwds_18_tfpropostadescricao = "";
         AV119Propostacontratoadmwwds_23_tfcontratonome_sel = "";
         AV118Propostacontratoadmwwds_22_tfcontratonome = "";
         AV121Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel = "";
         AV120Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial = "";
         A324PropostaTitulo = "";
         AV97Propostacontratoadmwwds_1_filterfulltext = "";
         H007M7_A504PropostaPacienteClienteId = new int[1] ;
         H007M7_n504PropostaPacienteClienteId = new bool[] {false} ;
         H007M7_A324PropostaTitulo = new string[] {""} ;
         H007M7_n324PropostaTitulo = new bool[] {false} ;
         H007M7_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         H007M7_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         H007M7_A345PropostaReprovacoesPermitidas = new short[1] ;
         H007M7_n345PropostaReprovacoesPermitidas = new bool[] {false} ;
         H007M7_A228ContratoNome = new string[] {""} ;
         H007M7_n228ContratoNome = new bool[] {false} ;
         H007M7_A227ContratoId = new int[1] ;
         H007M7_n227ContratoId = new bool[] {false} ;
         H007M7_A329PropostaStatus = new string[] {""} ;
         H007M7_n329PropostaStatus = new bool[] {false} ;
         H007M7_A328PropostaCratedBy = new short[1] ;
         H007M7_n328PropostaCratedBy = new bool[] {false} ;
         H007M7_A327PropostaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         H007M7_n327PropostaCreatedAt = new bool[] {false} ;
         H007M7_A326PropostaValor = new decimal[1] ;
         H007M7_n326PropostaValor = new bool[] {false} ;
         H007M7_A325PropostaDescricao = new string[] {""} ;
         H007M7_n325PropostaDescricao = new bool[] {false} ;
         H007M7_A376ProcedimentosMedicosId = new int[1] ;
         H007M7_n376ProcedimentosMedicosId = new bool[] {false} ;
         H007M7_A377ProcedimentosMedicosNome = new string[] {""} ;
         H007M7_n377ProcedimentosMedicosNome = new bool[] {false} ;
         H007M7_A323PropostaId = new int[1] ;
         H007M7_n323PropostaId = new bool[] {false} ;
         H007M7_A548ReembolsoStatusAtual_F = new string[] {""} ;
         H007M7_n548ReembolsoStatusAtual_F = new bool[] {false} ;
         H007M7_A342PropostaReprovacoes_F = new short[1] ;
         H007M7_n342PropostaReprovacoes_F = new bool[] {false} ;
         H007M7_A40000GXC1 = new int[1] ;
         H007M7_n40000GXC1 = new bool[] {false} ;
         H007M7_A341PropostaAprovacoes_F = new short[1] ;
         H007M7_n341PropostaAprovacoes_F = new bool[] {false} ;
         H007M7_A330PropostaQuantidadeAprovadores = new short[1] ;
         H007M7_n330PropostaQuantidadeAprovadores = new bool[] {false} ;
         H007M13_AGRID_nRecordCount = new long[1] ;
         GXt_SdtWWPContext1 = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV33ManageFiltersXml = "";
         AV29ExcelFilename = "";
         AV30ErrorMessage = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV31Session = context.GetSession();
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char3 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV64AuxText = "";
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV88Aprovacao = new SdtAprovacao(context);
         AV87DVelop_ConfirmPanel_Aprovar_Comment = "";
         GXt_char8 = "";
         imgRemovedynamicfilters3_gximage = "";
         sImgUrl = "";
         imgAdddynamicfilters2_gximage = "";
         imgRemovedynamicfilters2_gximage = "";
         imgAdddynamicfilters1_gximage = "";
         imgRemovedynamicfilters1_gximage = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.propostacontratoadmww__default(),
            new Object[][] {
                new Object[] {
               H007M7_A504PropostaPacienteClienteId, H007M7_n504PropostaPacienteClienteId, H007M7_A324PropostaTitulo, H007M7_n324PropostaTitulo, H007M7_A505PropostaPacienteClienteRazaoSocial, H007M7_n505PropostaPacienteClienteRazaoSocial, H007M7_A345PropostaReprovacoesPermitidas, H007M7_n345PropostaReprovacoesPermitidas, H007M7_A228ContratoNome, H007M7_n228ContratoNome,
               H007M7_A227ContratoId, H007M7_n227ContratoId, H007M7_A329PropostaStatus, H007M7_n329PropostaStatus, H007M7_A328PropostaCratedBy, H007M7_n328PropostaCratedBy, H007M7_A327PropostaCreatedAt, H007M7_n327PropostaCreatedAt, H007M7_A326PropostaValor, H007M7_n326PropostaValor,
               H007M7_A325PropostaDescricao, H007M7_n325PropostaDescricao, H007M7_A376ProcedimentosMedicosId, H007M7_n376ProcedimentosMedicosId, H007M7_A377ProcedimentosMedicosNome, H007M7_n377ProcedimentosMedicosNome, H007M7_A323PropostaId, H007M7_A548ReembolsoStatusAtual_F, H007M7_n548ReembolsoStatusAtual_F, H007M7_A342PropostaReprovacoes_F,
               H007M7_n342PropostaReprovacoes_F, H007M7_A40000GXC1, H007M7_n40000GXC1, H007M7_A341PropostaAprovacoes_F, H007M7_n341PropostaAprovacoes_F, H007M7_A330PropostaQuantidadeAprovadores, H007M7_n330PropostaQuantidadeAprovadores
               }
               , new Object[] {
               H007M13_AGRID_nRecordCount
               }
            }
         );
         AV96Pgmname = "PropostaContratoAdmWW";
         /* GeneXus formulas. */
         AV96Pgmname = "PropostaContratoAdmWW";
         edtavReembolso_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV13OrderedBy ;
      private short AV17DynamicFiltersOperator1 ;
      private short AV21DynamicFiltersOperator2 ;
      private short AV25DynamicFiltersOperator3 ;
      private short AV34ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A328PropostaCratedBy ;
      private short A330PropostaQuantidadeAprovadores ;
      private short A345PropostaReprovacoesPermitidas ;
      private short A341PropostaAprovacoes_F ;
      private short A342PropostaReprovacoes_F ;
      private short A343PropostaAprovacoesRestantes_F ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV6WWPContext_gxTpr_Secuserclienteid ;
      private short AV99Propostacontratoadmwwds_3_dynamicfiltersoperator1 ;
      private short AV104Propostacontratoadmwwds_8_dynamicfiltersoperator2 ;
      private short AV109Propostacontratoadmwwds_13_dynamicfiltersoperator3 ;
      private short AV89Aprovados ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_114 ;
      private int nGXsfl_114_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int A323PropostaId ;
      private int A376ProcedimentosMedicosId ;
      private int A227ContratoId ;
      private int subGrid_Islastpage ;
      private int edtavReembolso_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV122Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels_Count ;
      private int A504PropostaPacienteClienteId ;
      private int A40000GXC1 ;
      private int edtPropostaId_Enabled ;
      private int edtProcedimentosMedicosNome_Enabled ;
      private int edtProcedimentosMedicosId_Enabled ;
      private int edtPropostaDescricao_Enabled ;
      private int edtPropostaValor_Enabled ;
      private int edtPropostaCreatedAt_Enabled ;
      private int edtPropostaCratedBy_Enabled ;
      private int edtContratoId_Enabled ;
      private int edtContratoNome_Enabled ;
      private int edtPropostaQuantidadeAprovadores_Enabled ;
      private int edtPropostaReprovacoesPermitidas_Enabled ;
      private int edtPropostaAprovacoes_F_Enabled ;
      private int edtPropostaReprovacoes_F_Enabled ;
      private int edtPropostaAprovacoesRestantes_F_Enabled ;
      private int edtPropostaPacienteClienteRazaoSocial_Enabled ;
      private int AV57PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavPropostatitulo1_Visible ;
      private int edtavContratonome1_Visible ;
      private int edtavPropostatitulo2_Visible ;
      private int edtavContratonome2_Visible ;
      private int edtavPropostatitulo3_Visible ;
      private int edtavContratonome3_Visible ;
      private int AV123GXV1 ;
      private int AV86PropostaId_Selected ;
      private int edtavPropostatitulo3_Enabled ;
      private int edtavContratonome3_Enabled ;
      private int edtavPropostatitulo2_Enabled ;
      private int edtavContratonome2_Enabled ;
      private int edtavPropostatitulo1_Enabled ;
      private int edtavContratonome1_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV58GridCurrentPage ;
      private long AV59GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal AV41TFPropostaValor ;
      private decimal AV42TFPropostaValor_To ;
      private decimal A326PropostaValor ;
      private decimal AV116Propostacontratoadmwwds_20_tfpropostavalor ;
      private decimal AV117Propostacontratoadmwwds_21_tfpropostavalor_to ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_114_idx="0001" ;
      private string AV96Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Ddo_managefilters_Icontype ;
      private string Ddo_managefilters_Icon ;
      private string Ddo_managefilters_Tooltip ;
      private string Ddo_managefilters_Cls ;
      private string Dvpanel_tableheader_Width ;
      private string Dvpanel_tableheader_Cls ;
      private string Dvpanel_tableheader_Title ;
      private string Dvpanel_tableheader_Iconposition ;
      private string Gridpaginationbar_Class ;
      private string Gridpaginationbar_Pagingbuttonsposition ;
      private string Gridpaginationbar_Pagingcaptionposition ;
      private string Gridpaginationbar_Emptygridclass ;
      private string Gridpaginationbar_Rowsperpageoptions ;
      private string Gridpaginationbar_Previous ;
      private string Gridpaginationbar_Next ;
      private string Gridpaginationbar_Caption ;
      private string Gridpaginationbar_Emptygridcaption ;
      private string Gridpaginationbar_Rowsperpagecaption ;
      private string Ddo_grid_Caption ;
      private string Ddo_grid_Filteredtext_set ;
      private string Ddo_grid_Filteredtextto_set ;
      private string Ddo_grid_Selectedvalue_set ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_grid_Includefilter ;
      private string Ddo_grid_Filtertype ;
      private string Ddo_grid_Filterisrange ;
      private string Ddo_grid_Includedatalist ;
      private string Ddo_grid_Datalisttype ;
      private string Ddo_grid_Allowmultipleselection ;
      private string Ddo_grid_Datalistfixedvalues ;
      private string Ddo_grid_Datalistproc ;
      private string Ddo_grid_Format ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string Dvpanel_tableheader_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnexport_Internalname ;
      private string bttBtnexport_Jsonclick ;
      private string divTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string divTablefilters_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string divAdvancedfilterscontainer_Internalname ;
      private string divTabledynamicfilters_Internalname ;
      private string divTabledynamicfiltersrow1_Internalname ;
      private string lblDynamicfiltersprefix1_Internalname ;
      private string lblDynamicfiltersprefix1_Jsonclick ;
      private string cmbavDynamicfiltersselector1_Internalname ;
      private string cmbavDynamicfiltersselector1_Jsonclick ;
      private string lblDynamicfiltersmiddle1_Internalname ;
      private string lblDynamicfiltersmiddle1_Jsonclick ;
      private string divTabledynamicfiltersrow2_Internalname ;
      private string lblDynamicfiltersprefix2_Internalname ;
      private string lblDynamicfiltersprefix2_Jsonclick ;
      private string cmbavDynamicfiltersselector2_Internalname ;
      private string cmbavDynamicfiltersselector2_Jsonclick ;
      private string lblDynamicfiltersmiddle2_Internalname ;
      private string lblDynamicfiltersmiddle2_Jsonclick ;
      private string divTabledynamicfiltersrow3_Internalname ;
      private string lblDynamicfiltersprefix3_Internalname ;
      private string lblDynamicfiltersprefix3_Jsonclick ;
      private string cmbavDynamicfiltersselector3_Internalname ;
      private string cmbavDynamicfiltersselector3_Jsonclick ;
      private string lblDynamicfiltersmiddle3_Internalname ;
      private string lblDynamicfiltersmiddle3_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string lblJsdynamicfilters_Internalname ;
      private string lblJsdynamicfilters_Caption ;
      private string lblJsdynamicfilters_Jsonclick ;
      private string Ddo_grid_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV93Reembolso ;
      private string edtavReembolso_Internalname ;
      private string edtPropostaId_Internalname ;
      private string edtProcedimentosMedicosNome_Internalname ;
      private string edtProcedimentosMedicosId_Internalname ;
      private string edtPropostaDescricao_Internalname ;
      private string edtPropostaValor_Internalname ;
      private string edtPropostaCreatedAt_Internalname ;
      private string edtPropostaCratedBy_Internalname ;
      private string cmbPropostaStatus_Internalname ;
      private string edtContratoId_Internalname ;
      private string edtContratoNome_Internalname ;
      private string edtPropostaQuantidadeAprovadores_Internalname ;
      private string edtPropostaReprovacoesPermitidas_Internalname ;
      private string edtPropostaAprovacoes_F_Internalname ;
      private string edtPropostaReprovacoes_F_Internalname ;
      private string edtPropostaAprovacoesRestantes_F_Internalname ;
      private string edtPropostaPacienteClienteRazaoSocial_Internalname ;
      private string cmbReembolsoStatusAtual_F_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string edtavPropostatitulo1_Internalname ;
      private string edtavContratonome1_Internalname ;
      private string edtavPropostatitulo2_Internalname ;
      private string edtavContratonome2_Internalname ;
      private string edtavPropostatitulo3_Internalname ;
      private string edtavContratonome3_Internalname ;
      private string imgAdddynamicfilters1_Jsonclick ;
      private string imgAdddynamicfilters1_Internalname ;
      private string imgRemovedynamicfilters1_Jsonclick ;
      private string imgRemovedynamicfilters1_Internalname ;
      private string imgAdddynamicfilters2_Jsonclick ;
      private string imgAdddynamicfilters2_Internalname ;
      private string imgRemovedynamicfilters2_Jsonclick ;
      private string imgRemovedynamicfilters2_Internalname ;
      private string imgRemovedynamicfilters3_Jsonclick ;
      private string imgRemovedynamicfilters3_Internalname ;
      private string cmbReembolsoStatusAtual_F_Columnheaderclass ;
      private string edtavReembolso_Link ;
      private string GXEncryptionTmp ;
      private string cmbPropostaStatus_Columnclass ;
      private string cmbReembolsoStatusAtual_F_Columnclass ;
      private string GXt_char3 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char8 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_propostatitulo3_cell_Internalname ;
      private string edtavPropostatitulo3_Jsonclick ;
      private string cellFilter_contratonome3_cell_Internalname ;
      private string edtavContratonome3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_propostatitulo2_cell_Internalname ;
      private string edtavPropostatitulo2_Jsonclick ;
      private string cellFilter_contratonome2_cell_Internalname ;
      private string edtavContratonome2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_propostatitulo1_cell_Internalname ;
      private string edtavPropostatitulo1_Jsonclick ;
      private string cellFilter_contratonome1_cell_Internalname ;
      private string edtavContratonome1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string sGXsfl_114_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavReembolso_Jsonclick ;
      private string edtPropostaId_Jsonclick ;
      private string edtProcedimentosMedicosNome_Jsonclick ;
      private string edtProcedimentosMedicosId_Jsonclick ;
      private string edtPropostaDescricao_Jsonclick ;
      private string edtPropostaValor_Jsonclick ;
      private string edtPropostaCreatedAt_Jsonclick ;
      private string edtPropostaCratedBy_Jsonclick ;
      private string GXCCtl ;
      private string cmbPropostaStatus_Jsonclick ;
      private string edtContratoId_Jsonclick ;
      private string edtContratoNome_Jsonclick ;
      private string edtPropostaQuantidadeAprovadores_Jsonclick ;
      private string edtPropostaReprovacoesPermitidas_Jsonclick ;
      private string edtPropostaAprovacoes_F_Jsonclick ;
      private string edtPropostaReprovacoes_F_Jsonclick ;
      private string edtPropostaAprovacoesRestantes_F_Jsonclick ;
      private string edtPropostaPacienteClienteRazaoSocial_Jsonclick ;
      private string cmbReembolsoStatusAtual_F_Jsonclick ;
      private string subGrid_Header ;
      private DateTime A327PropostaCreatedAt ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV19DynamicFiltersEnabled2 ;
      private bool AV23DynamicFiltersEnabled3 ;
      private bool AV28DynamicFiltersIgnoreFirst ;
      private bool AV27DynamicFiltersRemoving ;
      private bool Dvpanel_tableheader_Autowidth ;
      private bool Dvpanel_tableheader_Autoheight ;
      private bool Dvpanel_tableheader_Collapsible ;
      private bool Dvpanel_tableheader_Collapsed ;
      private bool Dvpanel_tableheader_Showcollapseicon ;
      private bool Dvpanel_tableheader_Autoscroll ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n323PropostaId ;
      private bool n377ProcedimentosMedicosNome ;
      private bool n376ProcedimentosMedicosId ;
      private bool n325PropostaDescricao ;
      private bool n326PropostaValor ;
      private bool n327PropostaCreatedAt ;
      private bool n328PropostaCratedBy ;
      private bool n329PropostaStatus ;
      private bool n227ContratoId ;
      private bool n228ContratoNome ;
      private bool n330PropostaQuantidadeAprovadores ;
      private bool n345PropostaReprovacoesPermitidas ;
      private bool n341PropostaAprovacoes_F ;
      private bool n342PropostaReprovacoes_F ;
      private bool n505PropostaPacienteClienteRazaoSocial ;
      private bool n548ReembolsoStatusAtual_F ;
      private bool bGXsfl_114_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV102Propostacontratoadmwwds_6_dynamicfiltersenabled2 ;
      private bool AV107Propostacontratoadmwwds_11_dynamicfiltersenabled3 ;
      private bool n504PropostaPacienteClienteId ;
      private bool n324PropostaTitulo ;
      private bool n40000GXC1 ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV94TFReembolsoStatusAtual_F_SelsJson ;
      private string AV33ManageFiltersXml ;
      private string AV87DVelop_ConfirmPanel_Aprovar_Comment ;
      private string AV16DynamicFiltersSelector1 ;
      private string AV18PropostaTitulo1 ;
      private string AV69ContratoNome1 ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV22PropostaTitulo2 ;
      private string AV70ContratoNome2 ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV26PropostaTitulo3 ;
      private string AV71ContratoNome3 ;
      private string AV15FilterFullText ;
      private string AV82TFProcedimentosMedicosNome ;
      private string AV83TFProcedimentosMedicosNome_Sel ;
      private string AV39TFPropostaDescricao ;
      private string AV40TFPropostaDescricao_Sel ;
      private string AV65TFContratoNome ;
      private string AV66TFContratoNome_Sel ;
      private string AV91TFPropostaPacienteClienteRazaoSocial ;
      private string AV92TFPropostaPacienteClienteRazaoSocial_Sel ;
      private string AV60GridAppliedFilters ;
      private string A377ProcedimentosMedicosNome ;
      private string A325PropostaDescricao ;
      private string A329PropostaStatus ;
      private string A228ContratoNome ;
      private string A505PropostaPacienteClienteRazaoSocial ;
      private string A548ReembolsoStatusAtual_F ;
      private string lV97Propostacontratoadmwwds_1_filterfulltext ;
      private string lV100Propostacontratoadmwwds_4_propostatitulo1 ;
      private string lV101Propostacontratoadmwwds_5_contratonome1 ;
      private string lV105Propostacontratoadmwwds_9_propostatitulo2 ;
      private string lV106Propostacontratoadmwwds_10_contratonome2 ;
      private string lV110Propostacontratoadmwwds_14_propostatitulo3 ;
      private string lV111Propostacontratoadmwwds_15_contratonome3 ;
      private string lV112Propostacontratoadmwwds_16_tfprocedimentosmedicosnome ;
      private string lV114Propostacontratoadmwwds_18_tfpropostadescricao ;
      private string lV118Propostacontratoadmwwds_22_tfcontratonome ;
      private string lV120Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial ;
      private string AV98Propostacontratoadmwwds_2_dynamicfiltersselector1 ;
      private string AV100Propostacontratoadmwwds_4_propostatitulo1 ;
      private string AV101Propostacontratoadmwwds_5_contratonome1 ;
      private string AV103Propostacontratoadmwwds_7_dynamicfiltersselector2 ;
      private string AV105Propostacontratoadmwwds_9_propostatitulo2 ;
      private string AV106Propostacontratoadmwwds_10_contratonome2 ;
      private string AV108Propostacontratoadmwwds_12_dynamicfiltersselector3 ;
      private string AV110Propostacontratoadmwwds_14_propostatitulo3 ;
      private string AV111Propostacontratoadmwwds_15_contratonome3 ;
      private string AV113Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel ;
      private string AV112Propostacontratoadmwwds_16_tfprocedimentosmedicosnome ;
      private string AV115Propostacontratoadmwwds_19_tfpropostadescricao_sel ;
      private string AV114Propostacontratoadmwwds_18_tfpropostadescricao ;
      private string AV119Propostacontratoadmwwds_23_tfcontratonome_sel ;
      private string AV118Propostacontratoadmwwds_22_tfcontratonome ;
      private string AV121Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel ;
      private string AV120Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial ;
      private string A324PropostaTitulo ;
      private string AV97Propostacontratoadmwwds_1_filterfulltext ;
      private string AV29ExcelFilename ;
      private string AV30ErrorMessage ;
      private string AV64AuxText ;
      private IGxSession AV31Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GxHttpRequest AV7HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCombobox cmbPropostaStatus ;
      private GXCombobox cmbReembolsoStatusAtual_F ;
      private GxSimpleCollection<string> AV95TFReembolsoStatusAtual_F_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV84Context ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV32ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV56DDO_TitleSettingsIcons ;
      private GxSimpleCollection<string> AV122Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private IDataStoreProvider pr_default ;
      private int[] H007M7_A504PropostaPacienteClienteId ;
      private bool[] H007M7_n504PropostaPacienteClienteId ;
      private string[] H007M7_A324PropostaTitulo ;
      private bool[] H007M7_n324PropostaTitulo ;
      private string[] H007M7_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] H007M7_n505PropostaPacienteClienteRazaoSocial ;
      private short[] H007M7_A345PropostaReprovacoesPermitidas ;
      private bool[] H007M7_n345PropostaReprovacoesPermitidas ;
      private string[] H007M7_A228ContratoNome ;
      private bool[] H007M7_n228ContratoNome ;
      private int[] H007M7_A227ContratoId ;
      private bool[] H007M7_n227ContratoId ;
      private string[] H007M7_A329PropostaStatus ;
      private bool[] H007M7_n329PropostaStatus ;
      private short[] H007M7_A328PropostaCratedBy ;
      private bool[] H007M7_n328PropostaCratedBy ;
      private DateTime[] H007M7_A327PropostaCreatedAt ;
      private bool[] H007M7_n327PropostaCreatedAt ;
      private decimal[] H007M7_A326PropostaValor ;
      private bool[] H007M7_n326PropostaValor ;
      private string[] H007M7_A325PropostaDescricao ;
      private bool[] H007M7_n325PropostaDescricao ;
      private int[] H007M7_A376ProcedimentosMedicosId ;
      private bool[] H007M7_n376ProcedimentosMedicosId ;
      private string[] H007M7_A377ProcedimentosMedicosNome ;
      private bool[] H007M7_n377ProcedimentosMedicosNome ;
      private int[] H007M7_A323PropostaId ;
      private bool[] H007M7_n323PropostaId ;
      private string[] H007M7_A548ReembolsoStatusAtual_F ;
      private bool[] H007M7_n548ReembolsoStatusAtual_F ;
      private short[] H007M7_A342PropostaReprovacoes_F ;
      private bool[] H007M7_n342PropostaReprovacoes_F ;
      private int[] H007M7_A40000GXC1 ;
      private bool[] H007M7_n40000GXC1 ;
      private short[] H007M7_A341PropostaAprovacoes_F ;
      private bool[] H007M7_n341PropostaAprovacoes_F ;
      private short[] H007M7_A330PropostaQuantidadeAprovadores ;
      private bool[] H007M7_n330PropostaQuantidadeAprovadores ;
      private long[] H007M13_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext GXt_SdtWWPContext1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV12GridStateDynamicFilter ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private SdtAprovacao AV88Aprovacao ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class propostacontratoadmww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H007M7( IGxContext context ,
                                             string A548ReembolsoStatusAtual_F ,
                                             GxSimpleCollection<string> AV122Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels ,
                                             string AV98Propostacontratoadmwwds_2_dynamicfiltersselector1 ,
                                             short AV99Propostacontratoadmwwds_3_dynamicfiltersoperator1 ,
                                             string AV100Propostacontratoadmwwds_4_propostatitulo1 ,
                                             string AV101Propostacontratoadmwwds_5_contratonome1 ,
                                             bool AV102Propostacontratoadmwwds_6_dynamicfiltersenabled2 ,
                                             string AV103Propostacontratoadmwwds_7_dynamicfiltersselector2 ,
                                             short AV104Propostacontratoadmwwds_8_dynamicfiltersoperator2 ,
                                             string AV105Propostacontratoadmwwds_9_propostatitulo2 ,
                                             string AV106Propostacontratoadmwwds_10_contratonome2 ,
                                             bool AV107Propostacontratoadmwwds_11_dynamicfiltersenabled3 ,
                                             string AV108Propostacontratoadmwwds_12_dynamicfiltersselector3 ,
                                             short AV109Propostacontratoadmwwds_13_dynamicfiltersoperator3 ,
                                             string AV110Propostacontratoadmwwds_14_propostatitulo3 ,
                                             string AV111Propostacontratoadmwwds_15_contratonome3 ,
                                             string AV113Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel ,
                                             string AV112Propostacontratoadmwwds_16_tfprocedimentosmedicosnome ,
                                             string AV115Propostacontratoadmwwds_19_tfpropostadescricao_sel ,
                                             string AV114Propostacontratoadmwwds_18_tfpropostadescricao ,
                                             decimal AV116Propostacontratoadmwwds_20_tfpropostavalor ,
                                             decimal AV117Propostacontratoadmwwds_21_tfpropostavalor_to ,
                                             string AV119Propostacontratoadmwwds_23_tfcontratonome_sel ,
                                             string AV118Propostacontratoadmwwds_22_tfcontratonome ,
                                             string AV121Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel ,
                                             string AV120Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial ,
                                             string A324PropostaTitulo ,
                                             string A228ContratoNome ,
                                             string A377ProcedimentosMedicosNome ,
                                             string A325PropostaDescricao ,
                                             decimal A326PropostaValor ,
                                             string A505PropostaPacienteClienteRazaoSocial ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             string AV97Propostacontratoadmwwds_1_filterfulltext ,
                                             int AV122Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels_Count ,
                                             short A328PropostaCratedBy ,
                                             short AV6WWPContext_gxTpr_Secuserclienteid ,
                                             string A329PropostaStatus )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[38];
         Object[] GXv_Object10 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.PropostaPacienteClienteId AS PropostaPacienteClienteId, T1.PropostaTitulo, T2.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, T1.PropostaReprovacoesPermitidas, T3.ContratoNome, T1.ContratoId, T1.PropostaStatus, T1.PropostaCratedBy, T1.PropostaCreatedAt, T1.PropostaValor, T1.PropostaDescricao, T1.ProcedimentosMedicosId, T4.ProcedimentosMedicosNome, T1.PropostaId, COALESCE( T5.ReembolsoStatusAtual_F, '') AS ReembolsoStatusAtual_F, COALESCE( T7.PropostaAprovacoes_F, 0) AS PropostaReprovacoes_F, COALESCE( T8.GXC1, 0) AS GXC1, COALESCE( T6.PropostaAprovacoes_F, 0) AS PropostaAprovacoes_F, T1.PropostaQuantidadeAprovadores";
         sFromString = " FROM (((((((Proposta T1 LEFT JOIN Cliente T2 ON T2.ClienteId = T1.PropostaPacienteClienteId) LEFT JOIN Contrato T3 ON T3.ContratoId = T1.ContratoId) LEFT JOIN ProcedimentosMedicos T4 ON T4.ProcedimentosMedicosId = T1.ProcedimentosMedicosId) LEFT JOIN LATERAL (SELECT MIN(T9.ReembolsoEtapaStatus) AS ReembolsoStatusAtual_F, COALESCE( T11.ReembolsoEtapaUltimo_F, DATE '00010101') AS ReembolsoEtapaUltimo_F, T10.ReembolsoPropostaId FROM ((ReembolsoEtapa T9 LEFT JOIN Reembolso T10 ON T10.ReembolsoId = T9.ReembolsoId) LEFT JOIN LATERAL (SELECT MAX(ReembolsoEtapaCreatedAt) AS ReembolsoEtapaUltimo_F, ReembolsoId FROM ReembolsoEtapa WHERE T9.ReembolsoId = ReembolsoId GROUP BY ReembolsoId ) T11 ON T11.ReembolsoId = T9.ReembolsoId) WHERE (T1.PropostaId = T10.ReembolsoPropostaId) AND (T9.ReembolsoEtapaCreatedAt = COALESCE( T11.ReembolsoEtapaUltimo_F, DATE '00010101')) GROUP BY T11.ReembolsoEtapaUltimo_F, T10.ReembolsoPropostaId ) T5 ON T5.ReembolsoPropostaId = T1.PropostaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE (T1.PropostaId = PropostaId) AND (AprovacaoStatus = ( 'APROVADO')) GROUP BY PropostaId ) T6 ON T6.PropostaId = T1.PropostaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE (T1.PropostaId = PropostaId) AND (AprovacaoStatus = ( 'REPROVADO')) GROUP BY PropostaId ) T7 ON T7.PropostaId = T1.PropostaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS GXC1, PropostaId FROM Aprovacao WHERE (T1.PropostaId = PropostaId) AND (AprovadoresId = :AV84Context__Userid) GROUP BY PropostaId ) T8 ON T8.PropostaId = T1.PropostaId)";
         sOrderString = "";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV97Propostacontratoadmwwds_1_filterfulltext))=0) or ( ( T4.ProcedimentosMedicosNome like '%' || :lV97Propostacontratoadmwwds_1_filterfulltext) or ( T1.PropostaDescricao like '%' || :lV97Propostacontratoadmwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.PropostaValor,'999999999999990.99'), 2) like '%' || :lV97Propostacontratoadmwwds_1_filterfulltext) or ( T3.ContratoNome like '%' || :lV97Propostacontratoadmwwds_1_filterfulltext) or ( T2.ClienteRazaoSocial like '%' || :lV97Propostacontratoadmwwds_1_filterfulltext) or ( 'em an�lise' like '%' || LOWER(:lV97Propostacontratoadmwwds_1_filterfulltext) and COALESCE( T5.ReembolsoStatusAtual_F, '') = ( 'EM_ANALISE')) or ( 'finalizado' like '%' || LOWER(:lV97Propostacontratoadmwwds_1_filterfulltext) and COALESCE( T5.ReembolsoStatusAtual_F, '') = ( 'FINALIZADO')) or ( 'rean�lise' like '%' || LOWER(:lV97Propostacontratoadmwwds_1_filterfulltext) and COALESCE( T5.ReembolsoStatusAtual_F, '') = ( 'REANALISE')) or ( 'n�o iniciado' like '%' || LOWER(:lV97Propostacontratoadmwwds_1_filterfulltext) and COALESCE( T5.ReembolsoStatusAtual_F, '') = ( ''))))");
         AddWhere(sWhereString, "(:AV122ProCount <= 0 or ( "+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV122Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels, "COALESCE( T5.ReembolsoStatusAtual_F, '') IN (", ")")+"))");
         AddWhere(sWhereString, "(T1.PropostaCratedBy = :AV6WWPCo_2Secuserclienteid)");
         AddWhere(sWhereString, "(T1.PropostaStatus = ( 'APROVADO'))");
         if ( ( StringUtil.StrCmp(AV98Propostacontratoadmwwds_2_dynamicfiltersselector1, "PROPOSTATITULO") == 0 ) && ( AV99Propostacontratoadmwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Propostacontratoadmwwds_4_propostatitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV100Propostacontratoadmwwds_4_propostatitulo1)");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV98Propostacontratoadmwwds_2_dynamicfiltersselector1, "PROPOSTATITULO") == 0 ) && ( AV99Propostacontratoadmwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Propostacontratoadmwwds_4_propostatitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV100Propostacontratoadmwwds_4_propostatitulo1)");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( ( StringUtil.StrCmp(AV98Propostacontratoadmwwds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV99Propostacontratoadmwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Propostacontratoadmwwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T3.ContratoNome like :lV101Propostacontratoadmwwds_5_contratonome1)");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( ( StringUtil.StrCmp(AV98Propostacontratoadmwwds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV99Propostacontratoadmwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Propostacontratoadmwwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T3.ContratoNome like '%' || :lV101Propostacontratoadmwwds_5_contratonome1)");
         }
         else
         {
            GXv_int9[16] = 1;
         }
         if ( AV102Propostacontratoadmwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV103Propostacontratoadmwwds_7_dynamicfiltersselector2, "PROPOSTATITULO") == 0 ) && ( AV104Propostacontratoadmwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Propostacontratoadmwwds_9_propostatitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV105Propostacontratoadmwwds_9_propostatitulo2)");
         }
         else
         {
            GXv_int9[17] = 1;
         }
         if ( AV102Propostacontratoadmwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV103Propostacontratoadmwwds_7_dynamicfiltersselector2, "PROPOSTATITULO") == 0 ) && ( AV104Propostacontratoadmwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Propostacontratoadmwwds_9_propostatitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV105Propostacontratoadmwwds_9_propostatitulo2)");
         }
         else
         {
            GXv_int9[18] = 1;
         }
         if ( AV102Propostacontratoadmwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV103Propostacontratoadmwwds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV104Propostacontratoadmwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Propostacontratoadmwwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T3.ContratoNome like :lV106Propostacontratoadmwwds_10_contratonome2)");
         }
         else
         {
            GXv_int9[19] = 1;
         }
         if ( AV102Propostacontratoadmwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV103Propostacontratoadmwwds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV104Propostacontratoadmwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Propostacontratoadmwwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T3.ContratoNome like '%' || :lV106Propostacontratoadmwwds_10_contratonome2)");
         }
         else
         {
            GXv_int9[20] = 1;
         }
         if ( AV107Propostacontratoadmwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV108Propostacontratoadmwwds_12_dynamicfiltersselector3, "PROPOSTATITULO") == 0 ) && ( AV109Propostacontratoadmwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Propostacontratoadmwwds_14_propostatitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV110Propostacontratoadmwwds_14_propostatitulo3)");
         }
         else
         {
            GXv_int9[21] = 1;
         }
         if ( AV107Propostacontratoadmwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV108Propostacontratoadmwwds_12_dynamicfiltersselector3, "PROPOSTATITULO") == 0 ) && ( AV109Propostacontratoadmwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Propostacontratoadmwwds_14_propostatitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV110Propostacontratoadmwwds_14_propostatitulo3)");
         }
         else
         {
            GXv_int9[22] = 1;
         }
         if ( AV107Propostacontratoadmwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV108Propostacontratoadmwwds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV109Propostacontratoadmwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Propostacontratoadmwwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T3.ContratoNome like :lV111Propostacontratoadmwwds_15_contratonome3)");
         }
         else
         {
            GXv_int9[23] = 1;
         }
         if ( AV107Propostacontratoadmwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV108Propostacontratoadmwwds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV109Propostacontratoadmwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Propostacontratoadmwwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T3.ContratoNome like '%' || :lV111Propostacontratoadmwwds_15_contratonome3)");
         }
         else
         {
            GXv_int9[24] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV113Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Propostacontratoadmwwds_16_tfprocedimentosmedicosnome)) ) )
         {
            AddWhere(sWhereString, "(T4.ProcedimentosMedicosNome like :lV112Propostacontratoadmwwds_16_tfprocedimentosmedicosnome)");
         }
         else
         {
            GXv_int9[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel)) && ! ( StringUtil.StrCmp(AV113Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.ProcedimentosMedicosNome = ( :AV113Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel))");
         }
         else
         {
            GXv_int9[26] = 1;
         }
         if ( StringUtil.StrCmp(AV113Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T4.ProcedimentosMedicosNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV115Propostacontratoadmwwds_19_tfpropostadescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Propostacontratoadmwwds_18_tfpropostadescricao)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao like :lV114Propostacontratoadmwwds_18_tfpropostadescricao)");
         }
         else
         {
            GXv_int9[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Propostacontratoadmwwds_19_tfpropostadescricao_sel)) && ! ( StringUtil.StrCmp(AV115Propostacontratoadmwwds_19_tfpropostadescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao = ( :AV115Propostacontratoadmwwds_19_tfpropostadescricao_sel))");
         }
         else
         {
            GXv_int9[28] = 1;
         }
         if ( StringUtil.StrCmp(AV115Propostacontratoadmwwds_19_tfpropostadescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao IS NULL or (char_length(trim(trailing ' ' from T1.PropostaDescricao))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV116Propostacontratoadmwwds_20_tfpropostavalor) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor >= :AV116Propostacontratoadmwwds_20_tfpropostavalor)");
         }
         else
         {
            GXv_int9[29] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV117Propostacontratoadmwwds_21_tfpropostavalor_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor <= :AV117Propostacontratoadmwwds_21_tfpropostavalor_to)");
         }
         else
         {
            GXv_int9[30] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV119Propostacontratoadmwwds_23_tfcontratonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Propostacontratoadmwwds_22_tfcontratonome)) ) )
         {
            AddWhere(sWhereString, "(T3.ContratoNome like :lV118Propostacontratoadmwwds_22_tfcontratonome)");
         }
         else
         {
            GXv_int9[31] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Propostacontratoadmwwds_23_tfcontratonome_sel)) && ! ( StringUtil.StrCmp(AV119Propostacontratoadmwwds_23_tfcontratonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ContratoNome = ( :AV119Propostacontratoadmwwds_23_tfcontratonome_sel))");
         }
         else
         {
            GXv_int9[32] = 1;
         }
         if ( StringUtil.StrCmp(AV119Propostacontratoadmwwds_23_tfcontratonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.ContratoNome IS NULL or (char_length(trim(trailing ' ' from T3.ContratoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV121Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial like :lV120Propostacontratoadmwwds_24_tfpropostapacienteclienterazaos)");
         }
         else
         {
            GXv_int9[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV121Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial = ( :AV121Propostacontratoadmwwds_25_tfpropostapacienteclienterazaos))");
         }
         else
         {
            GXv_int9[34] = 1;
         }
         if ( StringUtil.StrCmp(AV121Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T2.ClienteRazaoSocial))=0))");
         }
         if ( AV13OrderedBy == 1 )
         {
            sOrderString += " ORDER BY T1.PropostaId DESC";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T4.ProcedimentosMedicosNome, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T4.ProcedimentosMedicosNome DESC, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.PropostaDescricao, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.PropostaDescricao DESC, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.PropostaValor, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.PropostaValor DESC, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T3.ContratoNome, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T3.ContratoNome DESC, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T2.ClienteRazaoSocial, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.ClienteRazaoSocial DESC, T1.PropostaId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.PropostaId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      protected Object[] conditional_H007M13( IGxContext context ,
                                              string A548ReembolsoStatusAtual_F ,
                                              GxSimpleCollection<string> AV122Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels ,
                                              string AV98Propostacontratoadmwwds_2_dynamicfiltersselector1 ,
                                              short AV99Propostacontratoadmwwds_3_dynamicfiltersoperator1 ,
                                              string AV100Propostacontratoadmwwds_4_propostatitulo1 ,
                                              string AV101Propostacontratoadmwwds_5_contratonome1 ,
                                              bool AV102Propostacontratoadmwwds_6_dynamicfiltersenabled2 ,
                                              string AV103Propostacontratoadmwwds_7_dynamicfiltersselector2 ,
                                              short AV104Propostacontratoadmwwds_8_dynamicfiltersoperator2 ,
                                              string AV105Propostacontratoadmwwds_9_propostatitulo2 ,
                                              string AV106Propostacontratoadmwwds_10_contratonome2 ,
                                              bool AV107Propostacontratoadmwwds_11_dynamicfiltersenabled3 ,
                                              string AV108Propostacontratoadmwwds_12_dynamicfiltersselector3 ,
                                              short AV109Propostacontratoadmwwds_13_dynamicfiltersoperator3 ,
                                              string AV110Propostacontratoadmwwds_14_propostatitulo3 ,
                                              string AV111Propostacontratoadmwwds_15_contratonome3 ,
                                              string AV113Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel ,
                                              string AV112Propostacontratoadmwwds_16_tfprocedimentosmedicosnome ,
                                              string AV115Propostacontratoadmwwds_19_tfpropostadescricao_sel ,
                                              string AV114Propostacontratoadmwwds_18_tfpropostadescricao ,
                                              decimal AV116Propostacontratoadmwwds_20_tfpropostavalor ,
                                              decimal AV117Propostacontratoadmwwds_21_tfpropostavalor_to ,
                                              string AV119Propostacontratoadmwwds_23_tfcontratonome_sel ,
                                              string AV118Propostacontratoadmwwds_22_tfcontratonome ,
                                              string AV121Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel ,
                                              string AV120Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial ,
                                              string A324PropostaTitulo ,
                                              string A228ContratoNome ,
                                              string A377ProcedimentosMedicosNome ,
                                              string A325PropostaDescricao ,
                                              decimal A326PropostaValor ,
                                              string A505PropostaPacienteClienteRazaoSocial ,
                                              short AV13OrderedBy ,
                                              bool AV14OrderedDsc ,
                                              string AV97Propostacontratoadmwwds_1_filterfulltext ,
                                              int AV122Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels_Count ,
                                              short A328PropostaCratedBy ,
                                              short AV6WWPContext_gxTpr_Secuserclienteid ,
                                              string A329PropostaStatus )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[35];
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (((((((Proposta T1 LEFT JOIN Cliente T4 ON T4.ClienteId = T1.PropostaPacienteClienteId) LEFT JOIN Contrato T2 ON T2.ContratoId = T1.ContratoId) LEFT JOIN ProcedimentosMedicos T3 ON T3.ProcedimentosMedicosId = T1.ProcedimentosMedicosId) LEFT JOIN LATERAL (SELECT MIN(T9.ReembolsoEtapaStatus) AS ReembolsoStatusAtual_F, COALESCE( T11.ReembolsoEtapaUltimo_F, DATE '00010101') AS ReembolsoEtapaUltimo_F, T10.ReembolsoPropostaId FROM ((ReembolsoEtapa T9 LEFT JOIN Reembolso T10 ON T10.ReembolsoId = T9.ReembolsoId) LEFT JOIN LATERAL (SELECT MAX(ReembolsoEtapaCreatedAt) AS ReembolsoEtapaUltimo_F, ReembolsoId FROM ReembolsoEtapa WHERE T9.ReembolsoId = ReembolsoId GROUP BY ReembolsoId ) T11 ON T11.ReembolsoId = T9.ReembolsoId) WHERE (T1.PropostaId = T10.ReembolsoPropostaId) AND (T9.ReembolsoEtapaCreatedAt = COALESCE( T11.ReembolsoEtapaUltimo_F, DATE '00010101')) GROUP BY T11.ReembolsoEtapaUltimo_F, T10.ReembolsoPropostaId ) T5 ON T5.ReembolsoPropostaId = T1.PropostaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE (T1.PropostaId = PropostaId) AND (AprovacaoStatus = ( 'APROVADO')) GROUP BY PropostaId ) T6 ON T6.PropostaId = T1.PropostaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE (T1.PropostaId = PropostaId) AND (AprovacaoStatus = ( 'REPROVADO')) GROUP BY PropostaId ) T7 ON T7.PropostaId = T1.PropostaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS GXC1, PropostaId FROM Aprovacao WHERE (T1.PropostaId = PropostaId) AND (AprovadoresId = :AV84Context__Userid) GROUP BY PropostaId ) T8 ON T8.PropostaId = T1.PropostaId)";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV97Propostacontratoadmwwds_1_filterfulltext))=0) or ( ( T3.ProcedimentosMedicosNome like '%' || :lV97Propostacontratoadmwwds_1_filterfulltext) or ( T1.PropostaDescricao like '%' || :lV97Propostacontratoadmwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.PropostaValor,'999999999999990.99'), 2) like '%' || :lV97Propostacontratoadmwwds_1_filterfulltext) or ( T2.ContratoNome like '%' || :lV97Propostacontratoadmwwds_1_filterfulltext) or ( T4.ClienteRazaoSocial like '%' || :lV97Propostacontratoadmwwds_1_filterfulltext) or ( 'em an�lise' like '%' || LOWER(:lV97Propostacontratoadmwwds_1_filterfulltext) and COALESCE( T5.ReembolsoStatusAtual_F, '') = ( 'EM_ANALISE')) or ( 'finalizado' like '%' || LOWER(:lV97Propostacontratoadmwwds_1_filterfulltext) and COALESCE( T5.ReembolsoStatusAtual_F, '') = ( 'FINALIZADO')) or ( 'rean�lise' like '%' || LOWER(:lV97Propostacontratoadmwwds_1_filterfulltext) and COALESCE( T5.ReembolsoStatusAtual_F, '') = ( 'REANALISE')) or ( 'n�o iniciado' like '%' || LOWER(:lV97Propostacontratoadmwwds_1_filterfulltext) and COALESCE( T5.ReembolsoStatusAtual_F, '') = ( ''))))");
         AddWhere(sWhereString, "(:AV122ProCount <= 0 or ( "+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV122Propostacontratoadmwwds_26_tfreembolsostatusatual_f_sels, "COALESCE( T5.ReembolsoStatusAtual_F, '') IN (", ")")+"))");
         AddWhere(sWhereString, "(T1.PropostaCratedBy = :AV6WWPCo_2Secuserclienteid)");
         AddWhere(sWhereString, "(T1.PropostaStatus = ( 'APROVADO'))");
         if ( ( StringUtil.StrCmp(AV98Propostacontratoadmwwds_2_dynamicfiltersselector1, "PROPOSTATITULO") == 0 ) && ( AV99Propostacontratoadmwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Propostacontratoadmwwds_4_propostatitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV100Propostacontratoadmwwds_4_propostatitulo1)");
         }
         else
         {
            GXv_int11[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV98Propostacontratoadmwwds_2_dynamicfiltersselector1, "PROPOSTATITULO") == 0 ) && ( AV99Propostacontratoadmwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Propostacontratoadmwwds_4_propostatitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV100Propostacontratoadmwwds_4_propostatitulo1)");
         }
         else
         {
            GXv_int11[14] = 1;
         }
         if ( ( StringUtil.StrCmp(AV98Propostacontratoadmwwds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV99Propostacontratoadmwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Propostacontratoadmwwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV101Propostacontratoadmwwds_5_contratonome1)");
         }
         else
         {
            GXv_int11[15] = 1;
         }
         if ( ( StringUtil.StrCmp(AV98Propostacontratoadmwwds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV99Propostacontratoadmwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Propostacontratoadmwwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV101Propostacontratoadmwwds_5_contratonome1)");
         }
         else
         {
            GXv_int11[16] = 1;
         }
         if ( AV102Propostacontratoadmwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV103Propostacontratoadmwwds_7_dynamicfiltersselector2, "PROPOSTATITULO") == 0 ) && ( AV104Propostacontratoadmwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Propostacontratoadmwwds_9_propostatitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV105Propostacontratoadmwwds_9_propostatitulo2)");
         }
         else
         {
            GXv_int11[17] = 1;
         }
         if ( AV102Propostacontratoadmwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV103Propostacontratoadmwwds_7_dynamicfiltersselector2, "PROPOSTATITULO") == 0 ) && ( AV104Propostacontratoadmwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Propostacontratoadmwwds_9_propostatitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV105Propostacontratoadmwwds_9_propostatitulo2)");
         }
         else
         {
            GXv_int11[18] = 1;
         }
         if ( AV102Propostacontratoadmwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV103Propostacontratoadmwwds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV104Propostacontratoadmwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Propostacontratoadmwwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV106Propostacontratoadmwwds_10_contratonome2)");
         }
         else
         {
            GXv_int11[19] = 1;
         }
         if ( AV102Propostacontratoadmwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV103Propostacontratoadmwwds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV104Propostacontratoadmwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Propostacontratoadmwwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV106Propostacontratoadmwwds_10_contratonome2)");
         }
         else
         {
            GXv_int11[20] = 1;
         }
         if ( AV107Propostacontratoadmwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV108Propostacontratoadmwwds_12_dynamicfiltersselector3, "PROPOSTATITULO") == 0 ) && ( AV109Propostacontratoadmwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Propostacontratoadmwwds_14_propostatitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like :lV110Propostacontratoadmwwds_14_propostatitulo3)");
         }
         else
         {
            GXv_int11[21] = 1;
         }
         if ( AV107Propostacontratoadmwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV108Propostacontratoadmwwds_12_dynamicfiltersselector3, "PROPOSTATITULO") == 0 ) && ( AV109Propostacontratoadmwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Propostacontratoadmwwds_14_propostatitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaTitulo like '%' || :lV110Propostacontratoadmwwds_14_propostatitulo3)");
         }
         else
         {
            GXv_int11[22] = 1;
         }
         if ( AV107Propostacontratoadmwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV108Propostacontratoadmwwds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV109Propostacontratoadmwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Propostacontratoadmwwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV111Propostacontratoadmwwds_15_contratonome3)");
         }
         else
         {
            GXv_int11[23] = 1;
         }
         if ( AV107Propostacontratoadmwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV108Propostacontratoadmwwds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV109Propostacontratoadmwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Propostacontratoadmwwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV111Propostacontratoadmwwds_15_contratonome3)");
         }
         else
         {
            GXv_int11[24] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV113Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Propostacontratoadmwwds_16_tfprocedimentosmedicosnome)) ) )
         {
            AddWhere(sWhereString, "(T3.ProcedimentosMedicosNome like :lV112Propostacontratoadmwwds_16_tfprocedimentosmedicosnome)");
         }
         else
         {
            GXv_int11[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel)) && ! ( StringUtil.StrCmp(AV113Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ProcedimentosMedicosNome = ( :AV113Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel))");
         }
         else
         {
            GXv_int11[26] = 1;
         }
         if ( StringUtil.StrCmp(AV113Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.ProcedimentosMedicosNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV115Propostacontratoadmwwds_19_tfpropostadescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Propostacontratoadmwwds_18_tfpropostadescricao)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao like :lV114Propostacontratoadmwwds_18_tfpropostadescricao)");
         }
         else
         {
            GXv_int11[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Propostacontratoadmwwds_19_tfpropostadescricao_sel)) && ! ( StringUtil.StrCmp(AV115Propostacontratoadmwwds_19_tfpropostadescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao = ( :AV115Propostacontratoadmwwds_19_tfpropostadescricao_sel))");
         }
         else
         {
            GXv_int11[28] = 1;
         }
         if ( StringUtil.StrCmp(AV115Propostacontratoadmwwds_19_tfpropostadescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.PropostaDescricao IS NULL or (char_length(trim(trailing ' ' from T1.PropostaDescricao))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV116Propostacontratoadmwwds_20_tfpropostavalor) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor >= :AV116Propostacontratoadmwwds_20_tfpropostavalor)");
         }
         else
         {
            GXv_int11[29] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV117Propostacontratoadmwwds_21_tfpropostavalor_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaValor <= :AV117Propostacontratoadmwwds_21_tfpropostavalor_to)");
         }
         else
         {
            GXv_int11[30] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV119Propostacontratoadmwwds_23_tfcontratonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Propostacontratoadmwwds_22_tfcontratonome)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV118Propostacontratoadmwwds_22_tfcontratonome)");
         }
         else
         {
            GXv_int11[31] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Propostacontratoadmwwds_23_tfcontratonome_sel)) && ! ( StringUtil.StrCmp(AV119Propostacontratoadmwwds_23_tfcontratonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome = ( :AV119Propostacontratoadmwwds_23_tfcontratonome_sel))");
         }
         else
         {
            GXv_int11[32] = 1;
         }
         if ( StringUtil.StrCmp(AV119Propostacontratoadmwwds_23_tfcontratonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ContratoNome IS NULL or (char_length(trim(trailing ' ' from T2.ContratoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV121Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Propostacontratoadmwwds_24_tfpropostapacienteclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like :lV120Propostacontratoadmwwds_24_tfpropostapacienteclienterazaos)");
         }
         else
         {
            GXv_int11[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV121Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial = ( :AV121Propostacontratoadmwwds_25_tfpropostapacienteclienterazaos))");
         }
         else
         {
            GXv_int11[34] = 1;
         }
         if ( StringUtil.StrCmp(AV121Propostacontratoadmwwds_25_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T4.ClienteRazaoSocial))=0))");
         }
         scmdbuf += sWhereString;
         if ( AV13OrderedBy == 1 )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object12[0] = scmdbuf;
         GXv_Object12[1] = GXv_int11;
         return GXv_Object12 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H007M7(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (decimal)dynConstraints[20] , (decimal)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (string)dynConstraints[31] , (short)dynConstraints[32] , (bool)dynConstraints[33] , (string)dynConstraints[34] , (int)dynConstraints[35] , (short)dynConstraints[36] , (short)dynConstraints[37] , (string)dynConstraints[38] );
               case 1 :
                     return conditional_H007M13(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (decimal)dynConstraints[20] , (decimal)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (string)dynConstraints[31] , (short)dynConstraints[32] , (bool)dynConstraints[33] , (string)dynConstraints[34] , (int)dynConstraints[35] , (short)dynConstraints[36] , (short)dynConstraints[37] , (string)dynConstraints[38] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH007M7;
          prmH007M7 = new Object[] {
          new ParDef("AV84Context__Userid",GXType.Int16,4,0) ,
          new ParDef("AV97Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV97Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV97Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV97Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV97Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV97Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV97Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV97Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV97Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV97Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV122ProCount",GXType.Int32,9,0) ,
          new ParDef("AV6WWPCo_2Secuserclienteid",GXType.Int16,4,0) ,
          new ParDef("lV100Propostacontratoadmwwds_4_propostatitulo1",GXType.VarChar,150,0) ,
          new ParDef("lV100Propostacontratoadmwwds_4_propostatitulo1",GXType.VarChar,150,0) ,
          new ParDef("lV101Propostacontratoadmwwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV101Propostacontratoadmwwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV105Propostacontratoadmwwds_9_propostatitulo2",GXType.VarChar,150,0) ,
          new ParDef("lV105Propostacontratoadmwwds_9_propostatitulo2",GXType.VarChar,150,0) ,
          new ParDef("lV106Propostacontratoadmwwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV106Propostacontratoadmwwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV110Propostacontratoadmwwds_14_propostatitulo3",GXType.VarChar,150,0) ,
          new ParDef("lV110Propostacontratoadmwwds_14_propostatitulo3",GXType.VarChar,150,0) ,
          new ParDef("lV111Propostacontratoadmwwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV111Propostacontratoadmwwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV112Propostacontratoadmwwds_16_tfprocedimentosmedicosnome",GXType.VarChar,255,0) ,
          new ParDef("AV113Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel",GXType.VarChar,255,0) ,
          new ParDef("lV114Propostacontratoadmwwds_18_tfpropostadescricao",GXType.VarChar,150,0) ,
          new ParDef("AV115Propostacontratoadmwwds_19_tfpropostadescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("AV116Propostacontratoadmwwds_20_tfpropostavalor",GXType.Number,18,2) ,
          new ParDef("AV117Propostacontratoadmwwds_21_tfpropostavalor_to",GXType.Number,18,2) ,
          new ParDef("lV118Propostacontratoadmwwds_22_tfcontratonome",GXType.VarChar,125,0) ,
          new ParDef("AV119Propostacontratoadmwwds_23_tfcontratonome_sel",GXType.VarChar,125,0) ,
          new ParDef("lV120Propostacontratoadmwwds_24_tfpropostapacienteclienterazaos",GXType.VarChar,150,0) ,
          new ParDef("AV121Propostacontratoadmwwds_25_tfpropostapacienteclienterazaos",GXType.VarChar,150,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH007M13;
          prmH007M13 = new Object[] {
          new ParDef("AV84Context__Userid",GXType.Int16,4,0) ,
          new ParDef("AV97Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV97Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV97Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV97Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV97Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV97Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV97Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV97Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV97Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV97Propostacontratoadmwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV122ProCount",GXType.Int32,9,0) ,
          new ParDef("AV6WWPCo_2Secuserclienteid",GXType.Int16,4,0) ,
          new ParDef("lV100Propostacontratoadmwwds_4_propostatitulo1",GXType.VarChar,150,0) ,
          new ParDef("lV100Propostacontratoadmwwds_4_propostatitulo1",GXType.VarChar,150,0) ,
          new ParDef("lV101Propostacontratoadmwwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV101Propostacontratoadmwwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV105Propostacontratoadmwwds_9_propostatitulo2",GXType.VarChar,150,0) ,
          new ParDef("lV105Propostacontratoadmwwds_9_propostatitulo2",GXType.VarChar,150,0) ,
          new ParDef("lV106Propostacontratoadmwwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV106Propostacontratoadmwwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV110Propostacontratoadmwwds_14_propostatitulo3",GXType.VarChar,150,0) ,
          new ParDef("lV110Propostacontratoadmwwds_14_propostatitulo3",GXType.VarChar,150,0) ,
          new ParDef("lV111Propostacontratoadmwwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV111Propostacontratoadmwwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV112Propostacontratoadmwwds_16_tfprocedimentosmedicosnome",GXType.VarChar,255,0) ,
          new ParDef("AV113Propostacontratoadmwwds_17_tfprocedimentosmedicosnome_sel",GXType.VarChar,255,0) ,
          new ParDef("lV114Propostacontratoadmwwds_18_tfpropostadescricao",GXType.VarChar,150,0) ,
          new ParDef("AV115Propostacontratoadmwwds_19_tfpropostadescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("AV116Propostacontratoadmwwds_20_tfpropostavalor",GXType.Number,18,2) ,
          new ParDef("AV117Propostacontratoadmwwds_21_tfpropostavalor_to",GXType.Number,18,2) ,
          new ParDef("lV118Propostacontratoadmwwds_22_tfcontratonome",GXType.VarChar,125,0) ,
          new ParDef("AV119Propostacontratoadmwwds_23_tfcontratonome_sel",GXType.VarChar,125,0) ,
          new ParDef("lV120Propostacontratoadmwwds_24_tfpropostapacienteclienterazaos",GXType.VarChar,150,0) ,
          new ParDef("AV121Propostacontratoadmwwds_25_tfpropostapacienteclienterazaos",GXType.VarChar,150,0)
          };
          def= new CursorDef[] {
              new CursorDef("H007M7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007M7,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H007M13", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007M13,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((short[]) buf[6])[0] = rslt.getShort(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((short[]) buf[14])[0] = rslt.getShort(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((int[]) buf[22])[0] = rslt.getInt(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((int[]) buf[26])[0] = rslt.getInt(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((short[]) buf[29])[0] = rslt.getShort(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((int[]) buf[31])[0] = rslt.getInt(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((short[]) buf[33])[0] = rslt.getShort(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((short[]) buf[35])[0] = rslt.getShort(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
