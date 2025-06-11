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
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class recoverpassword : GXDataArea
   {
      public recoverpassword( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("DSLogin", true);
      }

      public recoverpassword( IGxContext context )
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

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpageempty", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpageempty", new Object[] {context});
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
         PA7E2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START7E2( ) ;
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
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Chronometer/ChronometerRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("recoverpassword") +"\">") ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_boolean_hidden_field( context, "vISEMAILENVIADO", AV46IsEmailEnviado);
         GxWebStd.gx_hidden_field( context, "SECUSEREMAIL", A144SecUserEmail);
         GxWebStd.gx_hidden_field( context, "SECUSERPASSWORD", A142SecUserPassword);
         GxWebStd.gx_hidden_field( context, "SECUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vISCODIGOVERIFICADO", AV47IsCodigoVerificado);
         GxWebStd.gx_hidden_field( context, "TEMPORARYCODEDATETIME", context.localUtil.TToC( A216TemporaryCodeDateTime, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "TEMPORARYCODEEMAIL", A217TemporaryCodeEmail);
         GxWebStd.gx_hidden_field( context, "TEMPORARYCODECONTENT", A215TemporaryCodeContent);
         GxWebStd.gx_hidden_field( context, "vSECUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19SecUserId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vSTRING", AV17String);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vARRAY_EMAIL", AV35Array_Email);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vARRAY_EMAIL", AV35Array_Email);
         }
         GxWebStd.gx_hidden_field( context, "vMESSAGE", AV15message);
         GxWebStd.gx_hidden_field( context, "vTHENDATETIME", context.localUtil.TToC( AV28ThenDateTime, 10, 8, 0, 0, "/", ":", " "));
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
            WE7E2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT7E2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("recoverpassword")  ;
      }

      public override string GetPgmname( )
      {
         return "RecoverPassword" ;
      }

      public override string GetPgmdesc( )
      {
         return "Primeiro acesso" ;
      }

      protected void WB7E0( )
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", divLayoutmaintable_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "login-left-side", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableleft_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblImgleft_Internalname, lblImgleft_Caption, "", "", lblImgleft_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_RecoverPassword.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "login-container", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableright_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table1_18_7E2( true) ;
         }
         else
         {
            wb_table1_18_7E2( false) ;
         }
         return  ;
      }

      protected void wb_table1_18_7E2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSignin_Internalname, "<h3>Primeiro acesso</h3>", "", "", lblSignin_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_RecoverPassword.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablelogin_Internalname, 1, 0, "px", 0, "px", "login-content", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 login-input", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableemail_Internalname, divTableemail_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblemail_Internalname, "<div style=\"padding-bottom: 1rem !important;\"><span style=\"font-size: 16px; \">E-mail</span></div>", "", "", lblLblemail_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_RecoverPassword.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecuseremail_Internalname, "Sec User Email", "col-sm-3 AttributeFLLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecuseremail_Internalname, AV41SecUserEmail, StringUtil.RTrim( context.localUtil.Format( AV41SecUserEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecuseremail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSecuseremail_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "", "start", true, "", "HLP_RecoverPassword.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblemailerror_Internalname, lblLblemailerror_Caption, "", "", lblLblemailerror_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "login-message", 0, "", lblLblemailerror_Visible, 1, 0, 0, "HLP_RecoverPassword.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 login-input", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecodigo_Internalname, divTablecodigo_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcodigo_Internalname, lblLblcodigo_Caption, "", "", lblLblcodigo_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_RecoverPassword.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCodigoverificador_Internalname, "Codigo Verificador", "col-sm-3 AttributeFLLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCodigoverificador_Internalname, AV42CodigoVerificador, StringUtil.RTrim( context.localUtil.Format( AV42CodigoVerificador, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCodigoverificador_Jsonclick, 0, "AttributeFL", "", "", "", "", edtavCodigoverificador_Visible, edtavCodigoverificador_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_RecoverPassword.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSenha_Internalname, "Senha", "col-sm-3 AttributeFLLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSenha_Internalname, AV48Senha, StringUtil.RTrim( context.localUtil.Format( AV48Senha, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSenha_Jsonclick, 0, "AttributeFL", "", "", "", "", edtavSenha_Visible, edtavSenha_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, -1, 0, 0, 0, 0, 0, true, "", "start", true, "", "HLP_RecoverPassword.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsenhaerror_Internalname, lblLblsenhaerror_Caption, "", "", lblLblsenhaerror_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "login-message", 0, "", lblLblsenhaerror_Visible, 1, 0, 0, "HLP_RecoverPassword.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
            ClassString = "login-button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntentarnovamente_Internalname, "", bttBtntentarnovamente_Caption, bttBtntentarnovamente_Jsonclick, 5, "Tentar novamente em 30 segundos", "", StyleString, ClassString, bttBtntentarnovamente_Visible, bttBtntentarnovamente_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOTENTARNOVAMENTE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_RecoverPassword.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
            ClassString = "login-button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", "Confirmar", bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_RecoverPassword.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            /* User Defined Control */
            ucTimer.Render(context, "wwp.chronometer", Timer_Internalname, "TIMERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START7E2( )
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
         Form.Meta.addItem("description", "Primeiro acesso", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP7E0( ) ;
      }

      protected void WS7E2( )
      {
         START7E2( ) ;
         EVT7E2( ) ;
      }

      protected void EVT7E2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "TIMER.TICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Timer.Tick */
                              E117E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E127E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                    /* Execute user event: Enter */
                                    E137E2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOTENTARNOVAMENTE'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoTentarNovamente' */
                              E147E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOVOLTAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoVoltar' */
                              E157E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E167E2 ();
                              /* No code required for Cancel button. It is implemented as the Reset button. */
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
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE7E2( )
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

      protected void PA7E2( )
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
               GX_FocusControl = edtavSecuseremail_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF7E2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF7E2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E167E2 ();
            WB7E0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes7E2( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP7E0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E127E2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            AV41SecUserEmail = cgiGet( edtavSecuseremail_Internalname);
            AssignAttri("", false, "AV41SecUserEmail", AV41SecUserEmail);
            AV42CodigoVerificador = cgiGet( edtavCodigoverificador_Internalname);
            AssignAttri("", false, "AV42CodigoVerificador", AV42CodigoVerificador);
            AV48Senha = cgiGet( edtavSenha_Internalname);
            AssignAttri("", false, "AV48Senha", AV48Senha);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E127E2 ();
         if (returnInSub) return;
      }

      protected void E127E2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = "MainContainer";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         GXt_SdtWWPContext1 = AV13Context;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  GXt_SdtWWPContext1) ;
         AV13Context = GXt_SdtWWPContext1;
         if ( ! (0==AV13Context.gxTpr_Userid) )
         {
            AV20SecUser.Load(AV13Context.gxTpr_Userid);
            if ( AV20SecUser.gxTpr_Secuserclienteacesso )
            {
               CallWebObject(formatLink("homecli") );
               context.wjLocDisableFrm = 1;
            }
            else
            {
               CallWebObject(formatLink("financeiro") );
               context.wjLocDisableFrm = 1;
            }
         }
         divTablecodigo_Visible = 0;
         AssignProp("", false, divTablecodigo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablecodigo_Visible), 5, 0), true);
         AV43Configuracoes.Load(1);
         AV45Source = "resources/" + StringUtil.Trim( AV43Configuracoes.gxTpr_Configuracoesimagemloginnome) + "." + StringUtil.Trim( AV43Configuracoes.gxTpr_Configuracoesimagemloginextencao);
         AV16File.Source = AV45Source;
         AV16File.FromBase64(context.FileToBase64( AV43Configuracoes.gxTpr_Configuracoesimagemlogin));
         AV16File.Create();
         AV44Color = AV43Configuracoes.gxTpr_Configuracoesimagemloginbackground;
         lblImgleft_Caption = StringUtil.Format( "<div style=\"margin-left: -15px; display: flex; flex-direction: column; justify-content: center; align-items: center; background-color: %2; height: 100vh;\"><img src=\"%1\" style=\"width: 100%; height: 100%; object-fit: contain;\"></img></div>", AV45Source, (String.IsNullOrEmpty(StringUtil.RTrim( AV44Color)) ? "#fff" : AV44Color), "", "", "", "", "", "", "");
         AssignProp("", false, lblImgleft_Internalname, "Caption", lblImgleft_Caption, true);
         edtavSenha_Visible = 0;
         AssignProp("", false, edtavSenha_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSenha_Visible), 5, 0), true);
         AV46IsEmailEnviado = false;
         AssignAttri("", false, "AV46IsEmailEnviado", AV46IsEmailEnviado);
         AV47IsCodigoVerificado = false;
         AssignAttri("", false, "AV47IsCodigoVerificado", AV47IsCodigoVerificado);
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E137E2 ();
         if (returnInSub) return;
      }

      protected void E137E2( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( ! AV46IsEmailEnviado )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV41SecUserEmail)) )
            {
               lblLblemailerror_Caption = "Digite seu e-mail";
               AssignProp("", false, lblLblemailerror_Internalname, "Caption", lblLblemailerror_Caption, true);
               lblLblemailerror_Visible = 1;
               AssignProp("", false, lblLblemailerror_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblLblemailerror_Visible), 5, 0), true);
            }
            else
            {
               lblLblemailerror_Visible = 0;
               AssignProp("", false, lblLblemailerror_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblLblemailerror_Visible), 5, 0), true);
               AV40IsEmailExists = false;
               /* Using cursor H007E2 */
               pr_default.execute(0, new Object[] {AV41SecUserEmail});
               while ( (pr_default.getStatus(0) != 101) )
               {
                  A142SecUserPassword = H007E2_A142SecUserPassword[0];
                  n142SecUserPassword = H007E2_n142SecUserPassword[0];
                  A144SecUserEmail = H007E2_A144SecUserEmail[0];
                  n144SecUserEmail = H007E2_n144SecUserEmail[0];
                  A133SecUserId = H007E2_A133SecUserId[0];
                  AV19SecUserId = A133SecUserId;
                  AssignAttri("", false, "AV19SecUserId", StringUtil.LTrimStr( (decimal)(AV19SecUserId), 4, 0));
                  AV40IsEmailExists = true;
                  pr_default.readNext(0);
               }
               pr_default.close(0);
               if ( AV40IsEmailExists )
               {
                  AV46IsEmailEnviado = true;
                  AssignAttri("", false, "AV46IsEmailEnviado", AV46IsEmailEnviado);
                  /* Execute user subroutine: 'ENVIAREMAIL' */
                  S112 ();
                  if (returnInSub) return;
               }
               else
               {
                  lblLblemailerror_Caption = "e-mail não encontrado";
                  AssignProp("", false, lblLblemailerror_Internalname, "Caption", lblLblemailerror_Caption, true);
                  lblLblemailerror_Visible = 1;
                  AssignProp("", false, lblLblemailerror_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblLblemailerror_Visible), 5, 0), true);
               }
            }
         }
         else
         {
            if ( ! AV47IsCodigoVerificado )
            {
               AV18IsOk = true;
               AV38Code = StringUtil.Trim( AV42CodigoVerificador);
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV38Code)) || ( StringUtil.Len( AV38Code) < 4 ) )
               {
                  lblLblsenhaerror_Caption = "Preencha o código completo";
                  AssignProp("", false, lblLblsenhaerror_Internalname, "Caption", lblLblsenhaerror_Caption, true);
                  AV18IsOk = false;
               }
               if ( AV18IsOk )
               {
                  AV7Pass = AV12Hashing.dohash("SHA256", AV38Code);
                  /* Using cursor H007E3 */
                  pr_default.execute(1, new Object[] {AV41SecUserEmail});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A217TemporaryCodeEmail = H007E3_A217TemporaryCodeEmail[0];
                     n217TemporaryCodeEmail = H007E3_n217TemporaryCodeEmail[0];
                     A215TemporaryCodeContent = H007E3_A215TemporaryCodeContent[0];
                     n215TemporaryCodeContent = H007E3_n215TemporaryCodeContent[0];
                     A216TemporaryCodeDateTime = H007E3_A216TemporaryCodeDateTime[0];
                     n216TemporaryCodeDateTime = H007E3_n216TemporaryCodeDateTime[0];
                     AV39TemporaryCodeContent = A215TemporaryCodeContent;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     pr_default.readNext(1);
                  }
                  pr_default.close(1);
                  if ( StringUtil.StrCmp(AV39TemporaryCodeContent, AV7Pass) != 0 )
                  {
                     AV18IsOk = false;
                     lblLblsenhaerror_Caption = "Código incorreto";
                     AssignProp("", false, lblLblsenhaerror_Internalname, "Caption", lblLblsenhaerror_Caption, true);
                  }
                  if ( AV18IsOk )
                  {
                     lblLblcodigo_Caption = "<div style=\"padding-bottom: 1rem !important;\"><span style=\"font-size: 16px; \">Senha</span></div>";
                     AssignProp("", false, lblLblcodigo_Internalname, "Caption", lblLblcodigo_Caption, true);
                     edtavSenha_Visible = 1;
                     AssignProp("", false, edtavSenha_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSenha_Visible), 5, 0), true);
                     edtavCodigoverificador_Visible = 0;
                     AssignProp("", false, edtavCodigoverificador_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCodigoverificador_Visible), 5, 0), true);
                     bttBtntentarnovamente_Visible = 0;
                     AssignProp("", false, bttBtntentarnovamente_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntentarnovamente_Visible), 5, 0), true);
                     divTableemail_Visible = 1;
                     AssignProp("", false, divTableemail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableemail_Visible), 5, 0), true);
                     edtavSecuseremail_Enabled = 0;
                     AssignProp("", false, edtavSecuseremail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSecuseremail_Enabled), 5, 0), true);
                     AV47IsCodigoVerificado = true;
                     AssignAttri("", false, "AV47IsCodigoVerificado", AV47IsCodigoVerificado);
                  }
               }
            }
            else
            {
               AV18IsOk = true;
               lblLblsenhaerror_Visible = 0;
               AssignProp("", false, lblLblsenhaerror_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblLblsenhaerror_Visible), 5, 0), true);
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Senha)) )
               {
                  lblLblsenhaerror_Caption = "Digite sua senha";
                  AssignProp("", false, lblLblsenhaerror_Internalname, "Caption", lblLblsenhaerror_Caption, true);
                  lblLblsenhaerror_Visible = 1;
                  AssignProp("", false, lblLblsenhaerror_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblLblsenhaerror_Visible), 5, 0), true);
                  AV18IsOk = false;
               }
               if ( AV18IsOk )
               {
                  AV7Pass = AV12Hashing.dohash("SHA256", AV48Senha);
                  AV20SecUser.Load(AV19SecUserId);
                  AV20SecUser.gxTpr_Secuserpassword = AV7Pass;
                  AV20SecUser.Save();
                  if ( AV20SecUser.Success() )
                  {
                     context.CommitDataStores("recoverpassword",pr_default);
                     AV11WebSession.Set("Recoverpass", "Senha atualizada com sucesso");
                     CallWebObject(formatLink("login") );
                     context.wjLocDisableFrm = 1;
                  }
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35Array_Email", AV35Array_Email);
      }

      protected void E147E2( )
      {
         /* 'DoTentarNovamente' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ENVIAREMAIL' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35Array_Email", AV35Array_Email);
      }

      protected void E157E2( )
      {
         /* 'DoVoltar' Routine */
         returnInSub = false;
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E117E2( )
      {
         /* Timer_Tick Routine */
         returnInSub = false;
         AV26NowDateTime = DateTimeUtil.ServerNow( context, pr_default);
         AV27Tempo = (short)(DateTimeUtil.TDiff( AV28ThenDateTime, AV26NowDateTime));
         bttBtntentarnovamente_Caption = StringUtil.Format( "Tente novamente em %1", StringUtil.LTrimStr( (decimal)(AV27Tempo), 4, 0), "", "", "", "", "", "", "", "");
         AssignProp("", false, bttBtntentarnovamente_Internalname, "Caption", bttBtntentarnovamente_Caption, true);
         if ( AV27Tempo <= 0 )
         {
            bttBtntentarnovamente_Caption = StringUtil.Format( "Tente novamente", "", "", "", "", "", "", "", "", "");
            AssignProp("", false, bttBtntentarnovamente_Internalname, "Caption", bttBtntentarnovamente_Caption, true);
            bttBtntentarnovamente_Enabled = 1;
            AssignProp("", false, bttBtntentarnovamente_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntentarnovamente_Enabled), 5, 0), true);
            this.executeUsercontrolMethod("", false, "TIMERContainer", "Stop", "", new Object[] {});
         }
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'ENVIAREMAIL' Routine */
         returnInSub = false;
         AV51I = 0;
         while ( AV51I <= 2 )
         {
            AV31Codigo = (decimal)(NumberUtil.Random( )*100);
            AV17String += StringUtil.Trim( StringUtil.Str( NumberUtil.Round( AV31Codigo, 0), 10, 0));
            AssignAttri("", false, "AV17String", AV17String);
            AV51I = (short)(AV51I+1);
            AV51I = (short)(AV51I+1);
         }
         AV17String = StringUtil.PadL( AV17String, 4, "0");
         AssignAttri("", false, "AV17String", AV17String);
         AV7Pass = AV12Hashing.dohash("SHA256", AV17String);
         AV33DateTime = DateTimeUtil.ServerNow( context, pr_default);
         AV33DateTime = DateTimeUtil.TAdd( AV33DateTime, 60*(30));
         AV32TemporaryCode = new SdtTemporaryCode(context);
         AV32TemporaryCode.gxTpr_Temporarycodecontent = AV7Pass;
         AV32TemporaryCode.gxTpr_Temporarycodedatetime = AV33DateTime;
         AV32TemporaryCode.gxTpr_Temporarycodeemail = AV41SecUserEmail;
         AV32TemporaryCode.gxTpr_Temporarycodeused = false;
         AV32TemporaryCode.Save();
         if ( AV32TemporaryCode.Success() )
         {
            context.CommitDataStores("recoverpassword",pr_default);
            lblLblemailerror_Visible = 0;
            AssignProp("", false, lblLblemailerror_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblLblemailerror_Visible), 5, 0), true);
            divTableemail_Visible = 0;
            AssignProp("", false, divTableemail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableemail_Visible), 5, 0), true);
            bttBtntentarnovamente_Enabled = 0;
            AssignProp("", false, bttBtntentarnovamente_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntentarnovamente_Enabled), 5, 0), true);
            divTablecodigo_Visible = 1;
            AssignProp("", false, divTablecodigo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablecodigo_Visible), 5, 0), true);
            AV26NowDateTime = DateTimeUtil.ServerNow( context, pr_default);
            AV28ThenDateTime = DateTimeUtil.TAdd( AV26NowDateTime, 40);
            AssignAttri("", false, "AV28ThenDateTime", context.localUtil.TToC( AV28ThenDateTime, 10, 8, 0, 3, "/", ":", " "));
            AV27Tempo = (short)(DateTimeUtil.TDiff( AV28ThenDateTime, AV26NowDateTime));
            GXt_char2 = AV34FirstHTML;
            new emailrecuperarsenha(context ).execute(  AV17String, out  GXt_char2) ;
            AV34FirstHTML = GXt_char2;
            AV35Array_Email.Add(AV41SecUserEmail, 0);
            new sendemail(context).executeSubmit(  "Recuperar senha",  AV34FirstHTML,  AV35Array_Email, out  AV15message) ;
            this.executeUsercontrolMethod("", false, "TIMERContainer", "Start", "", new Object[] {});
         }
         else
         {
            lblLblemailerror_Caption = ((GeneXus.Utils.SdtMessages_Message)AV32TemporaryCode.GetMessages().Item(1)).gxTpr_Description;
            AssignProp("", false, lblLblemailerror_Internalname, "Caption", lblLblemailerror_Caption, true);
            lblLblemailerror_Visible = 1;
            AssignProp("", false, lblLblemailerror_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblLblemailerror_Visible), 5, 0), true);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E167E2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_18_7E2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedlogologin_Internalname, tblTablemergedlogologin_Internalname, "", "TableMerged", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Static images/pictures */
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgLogologin_gximage, "")==0) ? "GX_Image_LogoLogin_Class" : "GX_Image_"+imgLogologin_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "e9edf59f-db45-4e16-b6a6-2c2b6611a4a3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgLogologin_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_RecoverPassword.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTxtlogo_Internalname, "<h1 style=\"letter-spacing: 5px;font-family:sans-serif; color:white;\">Erwise</h1>", "", "", lblTxtlogo_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_RecoverPassword.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_18_7E2e( true) ;
         }
         else
         {
            wb_table1_18_7E2e( false) ;
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
         PA7E2( ) ;
         WS7E2( ) ;
         WE7E2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019264554", true, true);
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
         context.AddJavascriptSource("recoverpassword.js", "?202561019264555", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Chronometer/ChronometerRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblImgleft_Internalname = "IMGLEFT";
         divTableleft_Internalname = "TABLELEFT";
         imgLogologin_Internalname = "LOGOLOGIN";
         lblTxtlogo_Internalname = "TXTLOGO";
         tblTablemergedlogologin_Internalname = "TABLEMERGEDLOGOLOGIN";
         lblSignin_Internalname = "SIGNIN";
         lblLblemail_Internalname = "LBLEMAIL";
         edtavSecuseremail_Internalname = "vSECUSEREMAIL";
         lblLblemailerror_Internalname = "LBLEMAILERROR";
         divTableemail_Internalname = "TABLEEMAIL";
         lblLblcodigo_Internalname = "LBLCODIGO";
         edtavCodigoverificador_Internalname = "vCODIGOVERIFICADOR";
         edtavSenha_Internalname = "vSENHA";
         lblLblsenhaerror_Internalname = "LBLSENHAERROR";
         bttBtntentarnovamente_Internalname = "BTNTENTARNOVAMENTE";
         divTablecodigo_Internalname = "TABLECODIGO";
         bttBtnenter_Internalname = "BTNENTER";
         divTablelogin_Internalname = "TABLELOGIN";
         divTableright_Internalname = "TABLERIGHT";
         divTablecontent_Internalname = "TABLECONTENT";
         Timer_Internalname = "TIMER";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("DSLogin", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         bttBtntentarnovamente_Caption = "Tentar novamente em 30 segundos";
         bttBtntentarnovamente_Enabled = 1;
         bttBtntentarnovamente_Visible = 1;
         lblLblsenhaerror_Caption = "";
         lblLblsenhaerror_Visible = 1;
         edtavSenha_Jsonclick = "";
         edtavSenha_Enabled = 1;
         edtavSenha_Visible = 1;
         edtavCodigoverificador_Jsonclick = "";
         edtavCodigoverificador_Enabled = 1;
         edtavCodigoverificador_Visible = 1;
         lblLblcodigo_Caption = "<div style=\"padding-bottom: 1rem !important;\"><span style=\"font-size: 16px; \">Código</span></div>";
         divTablecodigo_Visible = 1;
         lblLblemailerror_Caption = "";
         lblLblemailerror_Visible = 1;
         edtavSecuseremail_Jsonclick = "";
         edtavSecuseremail_Enabled = 1;
         divTableemail_Visible = 1;
         lblImgleft_Caption = "<div style=\"height: 100vh;background-color: gainsboro;\"><span>imagem aqui</span></div>";
         divLayoutmaintable_Class = "Table";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Primeiro acesso";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
         setEventMetadata("ENTER","""{"handler":"E137E2","iparms":[{"av":"AV46IsEmailEnviado","fld":"vISEMAILENVIADO","type":"boolean"},{"av":"AV41SecUserEmail","fld":"vSECUSEREMAIL","type":"svchar"},{"av":"A144SecUserEmail","fld":"SECUSEREMAIL","type":"svchar"},{"av":"A142SecUserPassword","fld":"SECUSERPASSWORD","type":"svchar"},{"av":"A133SecUserId","fld":"SECUSERID","pic":"ZZZ9","type":"int"},{"av":"AV47IsCodigoVerificado","fld":"vISCODIGOVERIFICADO","type":"boolean"},{"av":"AV42CodigoVerificador","fld":"vCODIGOVERIFICADOR","type":"svchar"},{"av":"A216TemporaryCodeDateTime","fld":"TEMPORARYCODEDATETIME","pic":"99/99/99 99:99","type":"dtime"},{"av":"A217TemporaryCodeEmail","fld":"TEMPORARYCODEEMAIL","type":"svchar"},{"av":"A215TemporaryCodeContent","fld":"TEMPORARYCODECONTENT","type":"svchar"},{"av":"AV48Senha","fld":"vSENHA","type":"svchar"},{"av":"AV19SecUserId","fld":"vSECUSERID","pic":"ZZZ9","type":"int"},{"av":"AV17String","fld":"vSTRING","type":"vchar"},{"av":"AV35Array_Email","fld":"vARRAY_EMAIL","type":""},{"av":"AV15message","fld":"vMESSAGE","type":"svchar"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"lblLblemailerror_Caption","ctrl":"LBLEMAILERROR","prop":"Caption"},{"av":"AV19SecUserId","fld":"vSECUSERID","pic":"ZZZ9","type":"int"},{"av":"AV46IsEmailEnviado","fld":"vISEMAILENVIADO","type":"boolean"},{"av":"lblLblemailerror_Visible","ctrl":"LBLEMAILERROR","prop":"Visible"},{"av":"lblLblsenhaerror_Caption","ctrl":"LBLSENHAERROR","prop":"Caption"},{"av":"lblLblcodigo_Caption","ctrl":"LBLCODIGO","prop":"Caption"},{"av":"edtavSenha_Visible","ctrl":"vSENHA","prop":"Visible"},{"av":"edtavCodigoverificador_Visible","ctrl":"vCODIGOVERIFICADOR","prop":"Visible"},{"ctrl":"BTNTENTARNOVAMENTE","prop":"Visible"},{"av":"divTableemail_Visible","ctrl":"TABLEEMAIL","prop":"Visible"},{"av":"edtavSecuseremail_Enabled","ctrl":"vSECUSEREMAIL","prop":"Enabled"},{"av":"AV47IsCodigoVerificado","fld":"vISCODIGOVERIFICADO","type":"boolean"},{"av":"lblLblsenhaerror_Visible","ctrl":"LBLSENHAERROR","prop":"Visible"},{"av":"AV17String","fld":"vSTRING","type":"vchar"},{"ctrl":"BTNTENTARNOVAMENTE","prop":"Enabled"},{"av":"divTablecodigo_Visible","ctrl":"TABLECODIGO","prop":"Visible"},{"av":"AV28ThenDateTime","fld":"vTHENDATETIME","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV35Array_Email","fld":"vARRAY_EMAIL","type":""},{"av":"AV15message","fld":"vMESSAGE","type":"svchar"}]}""");
         setEventMetadata("'DOTENTARNOVAMENTE'","""{"handler":"E147E2","iparms":[{"av":"AV17String","fld":"vSTRING","type":"vchar"},{"av":"AV41SecUserEmail","fld":"vSECUSEREMAIL","type":"svchar"},{"av":"AV35Array_Email","fld":"vARRAY_EMAIL","type":""},{"av":"AV15message","fld":"vMESSAGE","type":"svchar"}]""");
         setEventMetadata("'DOTENTARNOVAMENTE'",""","oparms":[{"av":"AV17String","fld":"vSTRING","type":"vchar"},{"av":"divTableemail_Visible","ctrl":"TABLEEMAIL","prop":"Visible"},{"ctrl":"BTNTENTARNOVAMENTE","prop":"Enabled"},{"av":"divTablecodigo_Visible","ctrl":"TABLECODIGO","prop":"Visible"},{"av":"AV28ThenDateTime","fld":"vTHENDATETIME","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV35Array_Email","fld":"vARRAY_EMAIL","type":""},{"av":"AV15message","fld":"vMESSAGE","type":"svchar"},{"av":"lblLblemailerror_Caption","ctrl":"LBLEMAILERROR","prop":"Caption"},{"av":"lblLblemailerror_Visible","ctrl":"LBLEMAILERROR","prop":"Visible"}]}""");
         setEventMetadata("'DOVOLTAR'","""{"handler":"E157E2","iparms":[]}""");
         setEventMetadata("TIMER.TICK","""{"handler":"E117E2","iparms":[{"av":"AV28ThenDateTime","fld":"vTHENDATETIME","pic":"99/99/9999 99:99:99","type":"dtime"}]""");
         setEventMetadata("TIMER.TICK",""","oparms":[{"ctrl":"BTNTENTARNOVAMENTE","prop":"Caption"},{"ctrl":"BTNTENTARNOVAMENTE","prop":"Enabled"}]}""");
         setEventMetadata("VALIDV_SECUSEREMAIL","""{"handler":"Validv_Secuseremail","iparms":[]}""");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         A144SecUserEmail = "";
         A142SecUserPassword = "";
         A216TemporaryCodeDateTime = (DateTime)(DateTime.MinValue);
         A217TemporaryCodeEmail = "";
         A215TemporaryCodeContent = "";
         AV17String = "";
         AV35Array_Email = new GxSimpleCollection<string>();
         AV15message = "";
         AV28ThenDateTime = (DateTime)(DateTime.MinValue);
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblImgleft_Jsonclick = "";
         lblSignin_Jsonclick = "";
         lblLblemail_Jsonclick = "";
         TempTags = "";
         AV41SecUserEmail = "";
         lblLblemailerror_Jsonclick = "";
         lblLblcodigo_Jsonclick = "";
         AV42CodigoVerificador = "";
         AV48Senha = "";
         lblLblsenhaerror_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         bttBtntentarnovamente_Jsonclick = "";
         bttBtnenter_Jsonclick = "";
         ucTimer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV13Context = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtWWPContext1 = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV20SecUser = new SdtSecUser(context);
         AV43Configuracoes = new SdtConfiguracoes(context);
         AV45Source = "";
         AV16File = new GxFile(context.GetPhysicalPath());
         AV44Color = "";
         H007E2_A142SecUserPassword = new string[] {""} ;
         H007E2_n142SecUserPassword = new bool[] {false} ;
         H007E2_A144SecUserEmail = new string[] {""} ;
         H007E2_n144SecUserEmail = new bool[] {false} ;
         H007E2_A133SecUserId = new short[1] ;
         AV38Code = "";
         AV7Pass = "";
         AV12Hashing = new GeneXus.Programs.genexuscryptography.SdtHashing(context);
         H007E3_A214TemporaryCodeId = new int[1] ;
         H007E3_A217TemporaryCodeEmail = new string[] {""} ;
         H007E3_n217TemporaryCodeEmail = new bool[] {false} ;
         H007E3_A215TemporaryCodeContent = new string[] {""} ;
         H007E3_n215TemporaryCodeContent = new bool[] {false} ;
         H007E3_A216TemporaryCodeDateTime = new DateTime[] {DateTime.MinValue} ;
         H007E3_n216TemporaryCodeDateTime = new bool[] {false} ;
         AV39TemporaryCodeContent = "";
         AV11WebSession = context.GetSession();
         AV26NowDateTime = (DateTime)(DateTime.MinValue);
         AV33DateTime = (DateTime)(DateTime.MinValue);
         AV32TemporaryCode = new SdtTemporaryCode(context);
         AV34FirstHTML = "";
         GXt_char2 = "";
         sStyleString = "";
         imgLogologin_gximage = "";
         sImgUrl = "";
         lblTxtlogo_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.recoverpassword__default(),
            new Object[][] {
                new Object[] {
               H007E2_A142SecUserPassword, H007E2_n142SecUserPassword, H007E2_A144SecUserEmail, H007E2_n144SecUserEmail, H007E2_A133SecUserId
               }
               , new Object[] {
               H007E3_A214TemporaryCodeId, H007E3_A217TemporaryCodeEmail, H007E3_n217TemporaryCodeEmail, H007E3_A215TemporaryCodeContent, H007E3_n215TemporaryCodeContent, H007E3_A216TemporaryCodeDateTime, H007E3_n216TemporaryCodeDateTime
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short A133SecUserId ;
      private short AV19SecUserId ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV27Tempo ;
      private short AV51I ;
      private short nGXWrapped ;
      private int divTableemail_Visible ;
      private int edtavSecuseremail_Enabled ;
      private int lblLblemailerror_Visible ;
      private int divTablecodigo_Visible ;
      private int edtavCodigoverificador_Visible ;
      private int edtavCodigoverificador_Enabled ;
      private int edtavSenha_Visible ;
      private int edtavSenha_Enabled ;
      private int lblLblsenhaerror_Visible ;
      private int bttBtntentarnovamente_Visible ;
      private int bttBtntentarnovamente_Enabled ;
      private int idxLst ;
      private decimal AV31Codigo ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string divTablecontent_Internalname ;
      private string divTableleft_Internalname ;
      private string lblImgleft_Internalname ;
      private string lblImgleft_Caption ;
      private string lblImgleft_Jsonclick ;
      private string divTableright_Internalname ;
      private string lblSignin_Internalname ;
      private string lblSignin_Jsonclick ;
      private string divTablelogin_Internalname ;
      private string divTableemail_Internalname ;
      private string lblLblemail_Internalname ;
      private string lblLblemail_Jsonclick ;
      private string edtavSecuseremail_Internalname ;
      private string TempTags ;
      private string edtavSecuseremail_Jsonclick ;
      private string lblLblemailerror_Internalname ;
      private string lblLblemailerror_Caption ;
      private string lblLblemailerror_Jsonclick ;
      private string divTablecodigo_Internalname ;
      private string lblLblcodigo_Internalname ;
      private string lblLblcodigo_Caption ;
      private string lblLblcodigo_Jsonclick ;
      private string edtavCodigoverificador_Internalname ;
      private string edtavCodigoverificador_Jsonclick ;
      private string edtavSenha_Internalname ;
      private string edtavSenha_Jsonclick ;
      private string lblLblsenhaerror_Internalname ;
      private string lblLblsenhaerror_Caption ;
      private string lblLblsenhaerror_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtntentarnovamente_Internalname ;
      private string bttBtntentarnovamente_Caption ;
      private string bttBtntentarnovamente_Jsonclick ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string Timer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXt_char2 ;
      private string sStyleString ;
      private string tblTablemergedlogologin_Internalname ;
      private string imgLogologin_gximage ;
      private string sImgUrl ;
      private string imgLogologin_Internalname ;
      private string lblTxtlogo_Internalname ;
      private string lblTxtlogo_Jsonclick ;
      private DateTime A216TemporaryCodeDateTime ;
      private DateTime AV28ThenDateTime ;
      private DateTime AV26NowDateTime ;
      private DateTime AV33DateTime ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV46IsEmailEnviado ;
      private bool AV47IsCodigoVerificado ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV40IsEmailExists ;
      private bool n142SecUserPassword ;
      private bool n144SecUserEmail ;
      private bool AV18IsOk ;
      private bool n217TemporaryCodeEmail ;
      private bool n215TemporaryCodeContent ;
      private bool n216TemporaryCodeDateTime ;
      private string AV17String ;
      private string AV34FirstHTML ;
      private string A144SecUserEmail ;
      private string A142SecUserPassword ;
      private string A217TemporaryCodeEmail ;
      private string A215TemporaryCodeContent ;
      private string AV15message ;
      private string AV41SecUserEmail ;
      private string AV42CodigoVerificador ;
      private string AV48Senha ;
      private string AV45Source ;
      private string AV44Color ;
      private string AV38Code ;
      private string AV7Pass ;
      private string AV39TemporaryCodeContent ;
      private GXUserControl ucTimer ;
      private IGxSession AV11WebSession ;
      private GxFile AV16File ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV35Array_Email ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV13Context ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext GXt_SdtWWPContext1 ;
      private SdtSecUser AV20SecUser ;
      private SdtConfiguracoes AV43Configuracoes ;
      private IDataStoreProvider pr_default ;
      private string[] H007E2_A142SecUserPassword ;
      private bool[] H007E2_n142SecUserPassword ;
      private string[] H007E2_A144SecUserEmail ;
      private bool[] H007E2_n144SecUserEmail ;
      private short[] H007E2_A133SecUserId ;
      private GeneXus.Programs.genexuscryptography.SdtHashing AV12Hashing ;
      private int[] H007E3_A214TemporaryCodeId ;
      private string[] H007E3_A217TemporaryCodeEmail ;
      private bool[] H007E3_n217TemporaryCodeEmail ;
      private string[] H007E3_A215TemporaryCodeContent ;
      private bool[] H007E3_n215TemporaryCodeContent ;
      private DateTime[] H007E3_A216TemporaryCodeDateTime ;
      private bool[] H007E3_n216TemporaryCodeDateTime ;
      private SdtTemporaryCode AV32TemporaryCode ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class recoverpassword__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmH007E2;
          prmH007E2 = new Object[] {
          new ParDef("AV41SecUserEmail",GXType.VarChar,100,0)
          };
          Object[] prmH007E3;
          prmH007E3 = new Object[] {
          new ParDef("AV41SecUserEmail",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H007E2", "SELECT SecUserPassword, SecUserEmail, SecUserId FROM SecUser WHERE (UPPER(SecUserEmail) = ( UPPER(:AV41SecUserEmail))) AND (Not (char_length(trim(trailing ' ' from SecUserPassword))=0) and Not SecUserPassword IS NULL) ORDER BY SecUserEmail ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007E2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H007E3", "SELECT TemporaryCodeId, TemporaryCodeEmail, TemporaryCodeContent, TemporaryCodeDateTime FROM TemporaryCode WHERE TemporaryCodeEmail = ( :AV41SecUserEmail) ORDER BY TemporaryCodeDateTime DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007E3,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((short[]) buf[4])[0] = rslt.getShort(3);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
       }
    }

 }

}
