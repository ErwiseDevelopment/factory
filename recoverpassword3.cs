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
   public class recoverpassword3 : GXDataArea
   {
      public recoverpassword3( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("DSLogin", true);
      }

      public recoverpassword3( IGxContext context )
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
         PA4C2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START4C2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("recoverpassword3") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vNEWSTRING", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30NewString), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWSTRING", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV30NewString), "ZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vSECUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19SecUserId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "TEMPORARYCODEDATETIME", context.localUtil.TToC( A216TemporaryCodeDateTime, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "TEMPORARYCODEEMAIL", A217TemporaryCodeEmail);
         GxWebStd.gx_hidden_field( context, "TEMPORARYCODECONTENT", A215TemporaryCodeContent);
         GxWebStd.gx_hidden_field( context, "SECUSEREMAIL", A144SecUserEmail);
         GxWebStd.gx_hidden_field( context, "SECUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, "vNEWSTRING", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30NewString), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWSTRING", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV30NewString), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "TIMER_Tickinterval", StringUtil.LTrim( StringUtil.NToC( (decimal)(Timer_Tickinterval), 9, 0, ".", "")));
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
            WE4C2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT4C2( ) ;
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
         return formatLink("recoverpassword3")  ;
      }

      public override string GetPgmname( )
      {
         return "RecoverPassword3" ;
      }

      public override string GetPgmdesc( )
      {
         return "Primeiro acesso" ;
      }

      protected void WB4C0( )
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "login-left-side", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableleft_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTeste_Internalname, "", "", "", lblTeste_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_RecoverPassword3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            /* Static images/pictures */
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgLogo_gximage, "")==0) ? "GX_Image_LogoOld_Class" : "GX_Image_"+imgLogo_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "ca23d2de-3cea-40f3-a4ae-7986a087ac7f", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgLogo_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_RecoverPassword3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSignin_Internalname, "<h1>Primeiro acesso</h1>", "", "", lblSignin_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_RecoverPassword3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemailcontent_Internalname, divTablemailcontent_Visible, 0, "px", 0, "px", "login-content", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 login-input", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableemail_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblemail_Internalname, "<div style=\"padding-bottom: 1rem !important;\"><span style=\"font-size: 16px; \">E-mail</span></div>", "", "", lblLblemail_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_RecoverPassword3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmail_Internalname, "Email", "col-sm-3 AttributeFLLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmail_Internalname, AV25Email, StringUtil.RTrim( context.localUtil.Format( AV25Email, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_RecoverPassword3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblemailerror_Internalname, lblLblemailerror_Caption, "", "", lblLblemailerror_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "login-message", 0, "", lblLblemailerror_Visible, 1, 0, 0, "HLP_RecoverPassword3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
            ClassString = "login-button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenviaremail_Internalname, "", "Enviar e-mail", bttBtnenviaremail_Jsonclick, 5, "Voltar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOENVIAREMAIL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_RecoverPassword3.htm");
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
            GxWebStd.gx_div_start( context, divTablelogin_Internalname, divTablelogin_Visible, 0, "px", 0, "px", "login-content", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 login-input", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesenha_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;justify-content:center;align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCode_Internalname, "<h3>Insira o código</h3>", "", "", lblCode_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_RecoverPassword3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecode_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "justify-content:space-around;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "inputcode", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavText1_Internalname, "Text1", "gx-form-item inputcodeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavText1_Internalname, StringUtil.RTrim( AV21Text1), StringUtil.RTrim( context.localUtil.Format( AV21Text1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavText1_Jsonclick, 0, "inputcode", "", "", "", "", 1, edtavText1_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_RecoverPassword3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "inputcode", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavText2_Internalname, "Text2", "gx-form-item inputcodeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavText2_Internalname, StringUtil.RTrim( AV22Text2), StringUtil.RTrim( context.localUtil.Format( AV22Text2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavText2_Jsonclick, 0, "inputcode", "", "", "", "", 1, edtavText2_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_RecoverPassword3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "inputcode", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavText3_Internalname, "Text3", "gx-form-item inputcodeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavText3_Internalname, StringUtil.RTrim( AV23Text3), StringUtil.RTrim( context.localUtil.Format( AV23Text3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavText3_Jsonclick, 0, "inputcode", "", "", "", "", 1, edtavText3_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_RecoverPassword3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "inputcode", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavText4_Internalname, "Text4", "gx-form-item inputcodeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavText4_Internalname, StringUtil.RTrim( AV24Text4), StringUtil.RTrim( context.localUtil.Format( AV24Text4, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavText4_Jsonclick, 0, "inputcode", "", "", "", "", 1, edtavText4_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_RecoverPassword3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsenhaerror_Internalname, lblLblsenhaerror_Caption, "", "", lblLblsenhaerror_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "login-message", 0, "", 1, 1, 0, 0, "HLP_RecoverPassword3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSenagainmessage_Internalname, "Sen Again Message", "gx-form-item recover-messageLabel", 0, true, "width: 25%;");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
            ClassString = "recover-message";
            StyleString = "";
            ClassString = "recover-message";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavSenagainmessage_Internalname, AV29SenAgainMessage, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", 0, 1, edtavSenagainmessage_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_RecoverPassword3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesendagain_Internalname, divTablesendagain_Visible, 0, "px", 0, "px", "login-content", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Enviar e-mail novamente", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+"ETEXTBLOCK1.CLICK."+"'", "", "TextBlock", 5, "", 1, 1, 0, 1, "HLP_RecoverPassword3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"";
            ClassString = "login-button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncontinuar_Internalname, "", "Continuar", bttBtncontinuar_Jsonclick, 5, "Voltar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOCONTINUAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_RecoverPassword3.htm");
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
            GxWebStd.gx_div_start( context, divTablenewpasscontent_Internalname, divTablenewpasscontent_Visible, 0, "px", 0, "px", "login-content", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 login-input", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablenewpass_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNewpasslbl_Internalname, "<h3>Crie sua senha</h3>", "", "", lblNewpasslbl_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_RecoverPassword3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblnewpass_Internalname, "<div style=\"padding-bottom: 1rem !important;\"><span style=\"font-size: 16px; \">Senha</span></div>", "", "", lblLblnewpass_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_RecoverPassword3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNewpass_Internalname, "New Pass", "col-sm-3 AttributeFLLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNewpass_Internalname, AV36NewPass, StringUtil.RTrim( context.localUtil.Format( AV36NewPass, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,93);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNewpass_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavNewpass_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, -1, 0, 0, 0, 0, -1, true, "", "start", true, "", "HLP_RecoverPassword3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblnewpasserror_Internalname, lblLblnewpasserror_Caption, "", "", lblLblnewpasserror_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "login-message", 0, "", lblLblnewpasserror_Visible, 1, 0, 0, "HLP_RecoverPassword3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblconfirmnewpass_Internalname, "<div style=\"padding-bottom: 1rem !important;\"><span style=\"font-size: 16px; \">Confirmar Senha</span></div>", "", "", lblLblconfirmnewpass_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_RecoverPassword3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavConfirmnewpass_Internalname, "Confirm New Pass", "col-sm-3 AttributeFLLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConfirmnewpass_Internalname, AV37ConfirmNewPass, StringUtil.RTrim( context.localUtil.Format( AV37ConfirmNewPass, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,103);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConfirmnewpass_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavConfirmnewpass_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, -1, 0, 0, 0, 0, -1, true, "", "start", true, "", "HLP_RecoverPassword3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblconfirmnewpasserror_Internalname, lblLblconfirmnewpasserror_Caption, "", "", lblLblconfirmnewpasserror_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "login-message", 0, "", lblLblconfirmnewpasserror_Visible, 1, 0, 0, "HLP_RecoverPassword3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
            ClassString = "login-button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", "Continuar", bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_RecoverPassword3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'',false,'',0)\"";
            ClassString = "login-button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnvoltar_Internalname, "", "Voltar", bttBtnvoltar_Jsonclick, 5, "Voltar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOVOLTAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_RecoverPassword3.htm");
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

      protected void START4C2( )
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
         STRUP4C0( ) ;
      }

      protected void WS4C2( )
      {
         START4C2( ) ;
         EVT4C2( ) ;
      }

      protected void EVT4C2( )
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
                              E114C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E124C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOVOLTAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoVoltar' */
                              E134C2 ();
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
                                    E144C2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOCONTINUAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoContinuar' */
                              E154C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOENVIAREMAIL'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoEnviarEmail' */
                              E164C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "TEXTBLOCK1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Textblock1.Click */
                              E174C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E184C2 ();
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

      protected void WE4C2( )
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

      protected void PA4C2( )
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
               GX_FocusControl = edtavEmail_Internalname;
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
         RF4C2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavSenagainmessage_Enabled = 0;
         AssignProp("", false, edtavSenagainmessage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSenagainmessage_Enabled), 5, 0), true);
      }

      protected void RF4C2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E184C2 ();
            WB4C0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes4C2( )
      {
         GxWebStd.gx_hidden_field( context, "vNEWSTRING", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30NewString), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWSTRING", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV30NewString), "ZZZ9"), context));
      }

      protected void before_start_formulas( )
      {
         edtavSenagainmessage_Enabled = 0;
         AssignProp("", false, edtavSenagainmessage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSenagainmessage_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4C0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E124C2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Timer_Tickinterval = (int)(Math.Round(context.localUtil.CToN( cgiGet( "TIMER_Tickinterval"), ",", "."), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            AV25Email = cgiGet( edtavEmail_Internalname);
            AssignAttri("", false, "AV25Email", AV25Email);
            AV21Text1 = cgiGet( edtavText1_Internalname);
            AssignAttri("", false, "AV21Text1", AV21Text1);
            AV22Text2 = cgiGet( edtavText2_Internalname);
            AssignAttri("", false, "AV22Text2", AV22Text2);
            AV23Text3 = cgiGet( edtavText3_Internalname);
            AssignAttri("", false, "AV23Text3", AV23Text3);
            AV24Text4 = cgiGet( edtavText4_Internalname);
            AssignAttri("", false, "AV24Text4", AV24Text4);
            AV29SenAgainMessage = cgiGet( edtavSenagainmessage_Internalname);
            AssignAttri("", false, "AV29SenAgainMessage", AV29SenAgainMessage);
            AV36NewPass = cgiGet( edtavNewpass_Internalname);
            AssignAttri("", false, "AV36NewPass", AV36NewPass);
            AV37ConfirmNewPass = cgiGet( edtavConfirmnewpass_Internalname);
            AssignAttri("", false, "AV37ConfirmNewPass", AV37ConfirmNewPass);
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
         E124C2 ();
         if (returnInSub) return;
      }

      protected void E124C2( )
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
         divTablenewpasscontent_Visible = 0;
         AssignProp("", false, divTablenewpasscontent_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablenewpasscontent_Visible), 5, 0), true);
         divTablesendagain_Visible = 0;
         AssignProp("", false, divTablesendagain_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesendagain_Visible), 5, 0), true);
         divTablelogin_Visible = 0;
         AssignProp("", false, divTablelogin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablelogin_Visible), 5, 0), true);
         Timer_Tickinterval = 1;
         ucTimer.SendProperty(context, "", false, Timer_Internalname, "TickInterval", StringUtil.LTrimStr( (decimal)(Timer_Tickinterval), 9, 0));
      }

      protected void E134C2( )
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

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E144C2 ();
         if (returnInSub) return;
      }

      protected void E144C2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV18IsOk = true;
         lblLblnewpasserror_Visible = 0;
         AssignProp("", false, lblLblnewpasserror_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblLblnewpasserror_Visible), 5, 0), true);
         lblLblconfirmnewpasserror_Visible = 0;
         AssignProp("", false, lblLblconfirmnewpasserror_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblLblconfirmnewpasserror_Visible), 5, 0), true);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV36NewPass)) )
         {
            lblLblnewpasserror_Caption = "Digite sua senha";
            AssignProp("", false, lblLblnewpasserror_Internalname, "Caption", lblLblnewpasserror_Caption, true);
            lblLblnewpasserror_Visible = 1;
            AssignProp("", false, lblLblnewpasserror_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblLblnewpasserror_Visible), 5, 0), true);
            AV18IsOk = false;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV37ConfirmNewPass)) && AV18IsOk )
         {
            lblLblconfirmnewpasserror_Caption = "Confirme sua senha";
            AssignProp("", false, lblLblconfirmnewpasserror_Internalname, "Caption", lblLblconfirmnewpasserror_Caption, true);
            lblLblconfirmnewpasserror_Visible = 1;
            AssignProp("", false, lblLblconfirmnewpasserror_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblLblconfirmnewpasserror_Visible), 5, 0), true);
            AV18IsOk = false;
         }
         if ( ( StringUtil.StrCmp(AV36NewPass, AV37ConfirmNewPass) != 0 ) && AV18IsOk )
         {
            lblLblconfirmnewpasserror_Caption = "Senhas não conferem";
            AssignProp("", false, lblLblconfirmnewpasserror_Internalname, "Caption", lblLblconfirmnewpasserror_Caption, true);
            lblLblconfirmnewpasserror_Visible = 1;
            AssignProp("", false, lblLblconfirmnewpasserror_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblLblconfirmnewpasserror_Visible), 5, 0), true);
            AV18IsOk = false;
         }
         if ( AV18IsOk )
         {
            AV7Pass = AV12Hashing.dohash("SHA256", AV36NewPass);
            AV20SecUser.Load(AV19SecUserId);
            AV20SecUser.gxTpr_Secuserpassword = AV7Pass;
            AV20SecUser.Save();
            if ( AV20SecUser.Success() )
            {
               context.CommitDataStores("recoverpassword3",pr_default);
               AV11WebSession.Set("Recoverpass", "Senha criada com sucesso");
               CallWebObject(formatLink("login") );
               context.wjLocDisableFrm = 1;
            }
         }
         /*  Sending Event outputs  */
      }

      protected void E154C2( )
      {
         /* 'DoContinuar' Routine */
         returnInSub = false;
         AV18IsOk = true;
         AV38Code = StringUtil.Format( "%1%2%3%4", AV21Text1, AV22Text2, AV23Text3, AV24Text4, "", "", "", "", "");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV38Code)) || ( StringUtil.Len( AV38Code) < 4 ) )
         {
            lblLblsenhaerror_Caption = "Preencha o código completo";
            AssignProp("", false, lblLblsenhaerror_Internalname, "Caption", lblLblsenhaerror_Caption, true);
            AV18IsOk = false;
         }
         if ( AV18IsOk )
         {
            AV7Pass = AV12Hashing.dohash("SHA256", AV38Code);
            /* Using cursor H004C2 */
            pr_default.execute(0, new Object[] {AV25Email});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A217TemporaryCodeEmail = H004C2_A217TemporaryCodeEmail[0];
               n217TemporaryCodeEmail = H004C2_n217TemporaryCodeEmail[0];
               A215TemporaryCodeContent = H004C2_A215TemporaryCodeContent[0];
               n215TemporaryCodeContent = H004C2_n215TemporaryCodeContent[0];
               A216TemporaryCodeDateTime = H004C2_A216TemporaryCodeDateTime[0];
               n216TemporaryCodeDateTime = H004C2_n216TemporaryCodeDateTime[0];
               AV39TemporaryCodeContent = A215TemporaryCodeContent;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(0);
            }
            pr_default.close(0);
            if ( StringUtil.StrCmp(AV39TemporaryCodeContent, AV7Pass) != 0 )
            {
               AV18IsOk = false;
               lblLblsenhaerror_Caption = "Código incorreto";
               AssignProp("", false, lblLblsenhaerror_Internalname, "Caption", lblLblsenhaerror_Caption, true);
            }
            if ( AV18IsOk )
            {
               divTablelogin_Visible = 0;
               AssignProp("", false, divTablelogin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablelogin_Visible), 5, 0), true);
               divTablenewpasscontent_Visible = 1;
               AssignProp("", false, divTablenewpasscontent_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablenewpasscontent_Visible), 5, 0), true);
            }
         }
         /*  Sending Event outputs  */
      }

      protected void E164C2( )
      {
         /* 'DoEnviarEmail' Routine */
         returnInSub = false;
         lblLblemailerror_Visible = 0;
         AssignProp("", false, lblLblemailerror_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblLblemailerror_Visible), 5, 0), true);
         AV40IsEmailExists = false;
         /* Using cursor H004C3 */
         pr_default.execute(1, new Object[] {AV25Email});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A144SecUserEmail = H004C3_A144SecUserEmail[0];
            n144SecUserEmail = H004C3_n144SecUserEmail[0];
            A133SecUserId = H004C3_A133SecUserId[0];
            AV19SecUserId = A133SecUserId;
            AssignAttri("", false, "AV19SecUserId", StringUtil.LTrimStr( (decimal)(AV19SecUserId), 4, 0));
            AV40IsEmailExists = true;
            pr_default.readNext(1);
         }
         pr_default.close(1);
         if ( AV40IsEmailExists )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV25Email)) )
            {
               lblLblemailerror_Caption = "Digite seu e-mail";
               AssignProp("", false, lblLblemailerror_Internalname, "Caption", lblLblemailerror_Caption, true);
               lblLblemailerror_Visible = 1;
               AssignProp("", false, lblLblemailerror_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblLblemailerror_Visible), 5, 0), true);
            }
            else
            {
               /* Execute user subroutine: 'ENVIAREMAIL' */
               S112 ();
               if (returnInSub) return;
            }
         }
         else
         {
            lblLblemailerror_Caption = "e-mail não encontrado";
            AssignProp("", false, lblLblemailerror_Internalname, "Caption", lblLblemailerror_Caption, true);
            lblLblemailerror_Visible = 1;
            AssignProp("", false, lblLblemailerror_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblLblemailerror_Visible), 5, 0), true);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35Array_Email", AV35Array_Email);
      }

      protected void E114C2( )
      {
         /* Timer_Tick Routine */
         returnInSub = false;
         AV26NowDateTime = DateTimeUtil.ServerNow( context, pr_default);
         AV27Tempo = (short)(DateTimeUtil.TDiff( AV28ThenDateTime, AV26NowDateTime));
         AV29SenAgainMessage = StringUtil.Format( "E-mail enviado para %1.", StringUtil.Lower( AV25Email), "", "", "", "", "", "", "", "") + StringUtil.NewLine( ) + StringUtil.Format( "Aguarde %1 segundos", StringUtil.LTrimStr( (decimal)(AV27Tempo), 4, 0), "", "", "", "", "", "", "", "");
         AssignAttri("", false, "AV29SenAgainMessage", AV29SenAgainMessage);
         if ( AV27Tempo <= 0 )
         {
            AV29SenAgainMessage = StringUtil.Format( "E-mail enviado para %1", StringUtil.Lower( AV25Email), "", "", "", "", "", "", "", "");
            AssignAttri("", false, "AV29SenAgainMessage", AV29SenAgainMessage);
            divTablesendagain_Visible = 1;
            AssignProp("", false, divTablesendagain_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesendagain_Visible), 5, 0), true);
            this.executeUsercontrolMethod("", false, "TIMERContainer", "Stop", "", new Object[] {});
         }
         /*  Sending Event outputs  */
      }

      protected void E174C2( )
      {
         /* Textblock1_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ENVIAREMAIL' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35Array_Email", AV35Array_Email);
      }

      protected void S112( )
      {
         /* 'ENVIAREMAIL' Routine */
         returnInSub = false;
         AV43I = 0;
         while ( AV43I <= 2 )
         {
            AV31Codigo = (decimal)(NumberUtil.Random( )*100);
            AV17String += StringUtil.Trim( StringUtil.Str( NumberUtil.Round( AV31Codigo, 0), 10, 0));
            AssignAttri("", false, "AV17String", AV17String);
            AV43I = (short)(AV43I+1);
            AV43I = (short)(AV43I+1);
         }
         AV17String = StringUtil.PadL( AV17String, 4, "0");
         AssignAttri("", false, "AV17String", AV17String);
         AV7Pass = AV12Hashing.dohash("SHA256", AV17String);
         AV33DateTime = DateTimeUtil.ServerNow( context, pr_default);
         AV33DateTime = DateTimeUtil.TAdd( AV33DateTime, 60*(30));
         AV32TemporaryCode = new SdtTemporaryCode(context);
         AV32TemporaryCode.gxTpr_Temporarycodecontent = AV7Pass;
         AV32TemporaryCode.gxTpr_Temporarycodedatetime = AV33DateTime;
         AV32TemporaryCode.gxTpr_Temporarycodeemail = AV25Email;
         AV32TemporaryCode.gxTpr_Temporarycodeused = false;
         AV32TemporaryCode.Save();
         if ( AV32TemporaryCode.Success() )
         {
            context.CommitDataStores("recoverpassword3",pr_default);
            lblLblemailerror_Visible = 0;
            AssignProp("", false, lblLblemailerror_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblLblemailerror_Visible), 5, 0), true);
            divTablesendagain_Visible = 0;
            AssignProp("", false, divTablesendagain_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesendagain_Visible), 5, 0), true);
            divTablemailcontent_Visible = 0;
            AssignProp("", false, divTablemailcontent_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablemailcontent_Visible), 5, 0), true);
            divTablelogin_Visible = 1;
            AssignProp("", false, divTablelogin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablelogin_Visible), 5, 0), true);
            AV26NowDateTime = DateTimeUtil.ServerNow( context, pr_default);
            AV28ThenDateTime = DateTimeUtil.TAdd( AV26NowDateTime, 40);
            AssignAttri("", false, "AV28ThenDateTime", context.localUtil.TToC( AV28ThenDateTime, 10, 8, 0, 3, "/", ":", " "));
            AV27Tempo = (short)(DateTimeUtil.TDiff( AV28ThenDateTime, AV26NowDateTime));
            AV29SenAgainMessage = StringUtil.Format( "E-mail enviado para %1.", StringUtil.Lower( AV25Email), "", "", "", "", "", "", "", "") + StringUtil.NewLine( ) + StringUtil.Format( "Aguarde %1 segundos", StringUtil.LTrimStr( (decimal)(AV27Tempo), 4, 0), "", "", "", "", "", "", "", "");
            AssignAttri("", false, "AV29SenAgainMessage", AV29SenAgainMessage);
            GXt_char2 = AV34FirstHTML;
            new emailfirstacces(context ).execute(  AV17String, out  GXt_char2) ;
            AV34FirstHTML = GXt_char2;
            AV35Array_Email.Add(AV25Email, 0);
            new sendemail(context).executeSubmit(  "Primeiro acesso",  AV34FirstHTML,  AV35Array_Email, out  AV15message) ;
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

      protected void E184C2( )
      {
         /* Load Routine */
         returnInSub = false;
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
         PA4C2( ) ;
         WS4C2( ) ;
         WE4C2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019242373", true, true);
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
         context.AddJavascriptSource("recoverpassword3.js", "?202561019242374", false, true);
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
         lblTeste_Internalname = "TESTE";
         divTableleft_Internalname = "TABLELEFT";
         imgLogo_Internalname = "LOGO";
         lblSignin_Internalname = "SIGNIN";
         lblLblemail_Internalname = "LBLEMAIL";
         edtavEmail_Internalname = "vEMAIL";
         lblLblemailerror_Internalname = "LBLEMAILERROR";
         divTableemail_Internalname = "TABLEEMAIL";
         bttBtnenviaremail_Internalname = "BTNENVIAREMAIL";
         divTablemailcontent_Internalname = "TABLEMAILCONTENT";
         lblCode_Internalname = "CODE";
         edtavText1_Internalname = "vTEXT1";
         edtavText2_Internalname = "vTEXT2";
         edtavText3_Internalname = "vTEXT3";
         edtavText4_Internalname = "vTEXT4";
         divTablecode_Internalname = "TABLECODE";
         lblLblsenhaerror_Internalname = "LBLSENHAERROR";
         edtavSenagainmessage_Internalname = "vSENAGAINMESSAGE";
         divTablesenha_Internalname = "TABLESENHA";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         divTablesendagain_Internalname = "TABLESENDAGAIN";
         bttBtncontinuar_Internalname = "BTNCONTINUAR";
         divTablelogin_Internalname = "TABLELOGIN";
         lblNewpasslbl_Internalname = "NEWPASSLBL";
         lblLblnewpass_Internalname = "LBLNEWPASS";
         edtavNewpass_Internalname = "vNEWPASS";
         lblLblnewpasserror_Internalname = "LBLNEWPASSERROR";
         lblLblconfirmnewpass_Internalname = "LBLCONFIRMNEWPASS";
         edtavConfirmnewpass_Internalname = "vCONFIRMNEWPASS";
         lblLblconfirmnewpasserror_Internalname = "LBLCONFIRMNEWPASSERROR";
         divTablenewpass_Internalname = "TABLENEWPASS";
         bttBtnenter_Internalname = "BTNENTER";
         divTablenewpasscontent_Internalname = "TABLENEWPASSCONTENT";
         bttBtnvoltar_Internalname = "BTNVOLTAR";
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
         lblLblconfirmnewpasserror_Caption = "";
         lblLblconfirmnewpasserror_Visible = 1;
         edtavConfirmnewpass_Jsonclick = "";
         edtavConfirmnewpass_Enabled = 1;
         lblLblnewpasserror_Caption = "";
         lblLblnewpasserror_Visible = 1;
         edtavNewpass_Jsonclick = "";
         edtavNewpass_Enabled = 1;
         divTablenewpasscontent_Visible = 1;
         divTablesendagain_Visible = 1;
         edtavSenagainmessage_Enabled = 1;
         lblLblsenhaerror_Caption = "";
         edtavText4_Jsonclick = "";
         edtavText4_Enabled = 1;
         edtavText3_Jsonclick = "";
         edtavText3_Enabled = 1;
         edtavText2_Jsonclick = "";
         edtavText2_Enabled = 1;
         edtavText1_Jsonclick = "";
         edtavText1_Enabled = 1;
         divTablelogin_Visible = 1;
         lblLblemailerror_Caption = "";
         lblLblemailerror_Visible = 1;
         edtavEmail_Jsonclick = "";
         edtavEmail_Enabled = 1;
         divTablemailcontent_Visible = 1;
         divLayoutmaintable_Class = "Table";
         Timer_Tickinterval = 1;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV30NewString","fld":"vNEWSTRING","pic":"ZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("'DOVOLTAR'","""{"handler":"E134C2","iparms":[]}""");
         setEventMetadata("ENTER","""{"handler":"E144C2","iparms":[{"av":"AV36NewPass","fld":"vNEWPASS","type":"svchar"},{"av":"AV37ConfirmNewPass","fld":"vCONFIRMNEWPASS","type":"svchar"},{"av":"AV19SecUserId","fld":"vSECUSERID","pic":"ZZZ9","type":"int"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"lblLblnewpasserror_Visible","ctrl":"LBLNEWPASSERROR","prop":"Visible"},{"av":"lblLblconfirmnewpasserror_Visible","ctrl":"LBLCONFIRMNEWPASSERROR","prop":"Visible"},{"av":"lblLblnewpasserror_Caption","ctrl":"LBLNEWPASSERROR","prop":"Caption"},{"av":"lblLblconfirmnewpasserror_Caption","ctrl":"LBLCONFIRMNEWPASSERROR","prop":"Caption"}]}""");
         setEventMetadata("'DOCONTINUAR'","""{"handler":"E154C2","iparms":[{"av":"AV21Text1","fld":"vTEXT1","type":"char"},{"av":"AV22Text2","fld":"vTEXT2","type":"char"},{"av":"AV23Text3","fld":"vTEXT3","type":"char"},{"av":"AV24Text4","fld":"vTEXT4","type":"char"},{"av":"A216TemporaryCodeDateTime","fld":"TEMPORARYCODEDATETIME","pic":"99/99/99 99:99","type":"dtime"},{"av":"A217TemporaryCodeEmail","fld":"TEMPORARYCODEEMAIL","type":"svchar"},{"av":"AV25Email","fld":"vEMAIL","type":"svchar"},{"av":"A215TemporaryCodeContent","fld":"TEMPORARYCODECONTENT","type":"svchar"}]""");
         setEventMetadata("'DOCONTINUAR'",""","oparms":[{"av":"lblLblsenhaerror_Caption","ctrl":"LBLSENHAERROR","prop":"Caption"},{"av":"divTablelogin_Visible","ctrl":"TABLELOGIN","prop":"Visible"},{"av":"divTablenewpasscontent_Visible","ctrl":"TABLENEWPASSCONTENT","prop":"Visible"}]}""");
         setEventMetadata("'DOENVIAREMAIL'","""{"handler":"E164C2","iparms":[{"av":"A144SecUserEmail","fld":"SECUSEREMAIL","type":"svchar"},{"av":"AV25Email","fld":"vEMAIL","type":"svchar"},{"av":"A133SecUserId","fld":"SECUSERID","pic":"ZZZ9","type":"int"},{"av":"AV17String","fld":"vSTRING","type":"vchar"},{"av":"AV35Array_Email","fld":"vARRAY_EMAIL","type":""},{"av":"AV15message","fld":"vMESSAGE","type":"svchar"}]""");
         setEventMetadata("'DOENVIAREMAIL'",""","oparms":[{"av":"lblLblemailerror_Visible","ctrl":"LBLEMAILERROR","prop":"Visible"},{"av":"AV19SecUserId","fld":"vSECUSERID","pic":"ZZZ9","type":"int"},{"av":"lblLblemailerror_Caption","ctrl":"LBLEMAILERROR","prop":"Caption"},{"av":"AV17String","fld":"vSTRING","type":"vchar"},{"av":"divTablesendagain_Visible","ctrl":"TABLESENDAGAIN","prop":"Visible"},{"av":"divTablemailcontent_Visible","ctrl":"TABLEMAILCONTENT","prop":"Visible"},{"av":"divTablelogin_Visible","ctrl":"TABLELOGIN","prop":"Visible"},{"av":"AV28ThenDateTime","fld":"vTHENDATETIME","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV29SenAgainMessage","fld":"vSENAGAINMESSAGE","type":"svchar"},{"av":"AV35Array_Email","fld":"vARRAY_EMAIL","type":""},{"av":"AV15message","fld":"vMESSAGE","type":"svchar"}]}""");
         setEventMetadata("TIMER.TICK","""{"handler":"E114C2","iparms":[{"av":"AV28ThenDateTime","fld":"vTHENDATETIME","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV25Email","fld":"vEMAIL","type":"svchar"}]""");
         setEventMetadata("TIMER.TICK",""","oparms":[{"av":"AV29SenAgainMessage","fld":"vSENAGAINMESSAGE","type":"svchar"},{"av":"divTablesendagain_Visible","ctrl":"TABLESENDAGAIN","prop":"Visible"}]}""");
         setEventMetadata("TEXTBLOCK1.CLICK","""{"handler":"E174C2","iparms":[{"av":"AV17String","fld":"vSTRING","type":"vchar"},{"av":"AV25Email","fld":"vEMAIL","type":"svchar"},{"av":"AV35Array_Email","fld":"vARRAY_EMAIL","type":""},{"av":"AV15message","fld":"vMESSAGE","type":"svchar"}]""");
         setEventMetadata("TEXTBLOCK1.CLICK",""","oparms":[{"av":"AV17String","fld":"vSTRING","type":"vchar"},{"av":"divTablesendagain_Visible","ctrl":"TABLESENDAGAIN","prop":"Visible"},{"av":"divTablemailcontent_Visible","ctrl":"TABLEMAILCONTENT","prop":"Visible"},{"av":"divTablelogin_Visible","ctrl":"TABLELOGIN","prop":"Visible"},{"av":"AV28ThenDateTime","fld":"vTHENDATETIME","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV29SenAgainMessage","fld":"vSENAGAINMESSAGE","type":"svchar"},{"av":"AV35Array_Email","fld":"vARRAY_EMAIL","type":""},{"av":"AV15message","fld":"vMESSAGE","type":"svchar"},{"av":"lblLblemailerror_Caption","ctrl":"LBLEMAILERROR","prop":"Caption"},{"av":"lblLblemailerror_Visible","ctrl":"LBLEMAILERROR","prop":"Visible"}]}""");
         setEventMetadata("VALIDV_EMAIL","""{"handler":"Validv_Email","iparms":[]}""");
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
         A216TemporaryCodeDateTime = (DateTime)(DateTime.MinValue);
         A217TemporaryCodeEmail = "";
         A215TemporaryCodeContent = "";
         A144SecUserEmail = "";
         AV17String = "";
         AV35Array_Email = new GxSimpleCollection<string>();
         AV15message = "";
         AV28ThenDateTime = (DateTime)(DateTime.MinValue);
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTeste_Jsonclick = "";
         ClassString = "";
         imgLogo_gximage = "";
         StyleString = "";
         sImgUrl = "";
         lblSignin_Jsonclick = "";
         lblLblemail_Jsonclick = "";
         TempTags = "";
         AV25Email = "";
         lblLblemailerror_Jsonclick = "";
         bttBtnenviaremail_Jsonclick = "";
         lblCode_Jsonclick = "";
         AV21Text1 = "";
         AV22Text2 = "";
         AV23Text3 = "";
         AV24Text4 = "";
         lblLblsenhaerror_Jsonclick = "";
         AV29SenAgainMessage = "";
         lblTextblock1_Jsonclick = "";
         bttBtncontinuar_Jsonclick = "";
         lblNewpasslbl_Jsonclick = "";
         lblLblnewpass_Jsonclick = "";
         AV36NewPass = "";
         lblLblnewpasserror_Jsonclick = "";
         lblLblconfirmnewpass_Jsonclick = "";
         AV37ConfirmNewPass = "";
         lblLblconfirmnewpasserror_Jsonclick = "";
         bttBtnenter_Jsonclick = "";
         bttBtnvoltar_Jsonclick = "";
         ucTimer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV13Context = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtWWPContext1 = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV20SecUser = new SdtSecUser(context);
         AV7Pass = "";
         AV12Hashing = new GeneXus.Programs.genexuscryptography.SdtHashing(context);
         AV11WebSession = context.GetSession();
         AV38Code = "";
         H004C2_A214TemporaryCodeId = new int[1] ;
         H004C2_A217TemporaryCodeEmail = new string[] {""} ;
         H004C2_n217TemporaryCodeEmail = new bool[] {false} ;
         H004C2_A215TemporaryCodeContent = new string[] {""} ;
         H004C2_n215TemporaryCodeContent = new bool[] {false} ;
         H004C2_A216TemporaryCodeDateTime = new DateTime[] {DateTime.MinValue} ;
         H004C2_n216TemporaryCodeDateTime = new bool[] {false} ;
         AV39TemporaryCodeContent = "";
         H004C3_A144SecUserEmail = new string[] {""} ;
         H004C3_n144SecUserEmail = new bool[] {false} ;
         H004C3_A133SecUserId = new short[1] ;
         AV26NowDateTime = (DateTime)(DateTime.MinValue);
         AV33DateTime = (DateTime)(DateTime.MinValue);
         AV32TemporaryCode = new SdtTemporaryCode(context);
         AV34FirstHTML = "";
         GXt_char2 = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.recoverpassword3__default(),
            new Object[][] {
                new Object[] {
               H004C2_A214TemporaryCodeId, H004C2_A217TemporaryCodeEmail, H004C2_n217TemporaryCodeEmail, H004C2_A215TemporaryCodeContent, H004C2_n215TemporaryCodeContent, H004C2_A216TemporaryCodeDateTime, H004C2_n216TemporaryCodeDateTime
               }
               , new Object[] {
               H004C3_A144SecUserEmail, H004C3_n144SecUserEmail, H004C3_A133SecUserId
               }
            }
         );
         /* GeneXus formulas. */
         edtavSenagainmessage_Enabled = 0;
      }

      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short AV30NewString ;
      private short AV19SecUserId ;
      private short A133SecUserId ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV27Tempo ;
      private short AV43I ;
      private short nGXWrapped ;
      private int Timer_Tickinterval ;
      private int divTablemailcontent_Visible ;
      private int edtavEmail_Enabled ;
      private int lblLblemailerror_Visible ;
      private int divTablelogin_Visible ;
      private int edtavText1_Enabled ;
      private int edtavText2_Enabled ;
      private int edtavText3_Enabled ;
      private int edtavText4_Enabled ;
      private int edtavSenagainmessage_Enabled ;
      private int divTablesendagain_Visible ;
      private int divTablenewpasscontent_Visible ;
      private int edtavNewpass_Enabled ;
      private int lblLblnewpasserror_Visible ;
      private int edtavConfirmnewpass_Enabled ;
      private int lblLblconfirmnewpasserror_Visible ;
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
      private string lblTeste_Internalname ;
      private string lblTeste_Jsonclick ;
      private string divTableright_Internalname ;
      private string ClassString ;
      private string imgLogo_gximage ;
      private string StyleString ;
      private string sImgUrl ;
      private string imgLogo_Internalname ;
      private string lblSignin_Internalname ;
      private string lblSignin_Jsonclick ;
      private string divTablemailcontent_Internalname ;
      private string divTableemail_Internalname ;
      private string lblLblemail_Internalname ;
      private string lblLblemail_Jsonclick ;
      private string edtavEmail_Internalname ;
      private string TempTags ;
      private string edtavEmail_Jsonclick ;
      private string lblLblemailerror_Internalname ;
      private string lblLblemailerror_Caption ;
      private string lblLblemailerror_Jsonclick ;
      private string bttBtnenviaremail_Internalname ;
      private string bttBtnenviaremail_Jsonclick ;
      private string divTablelogin_Internalname ;
      private string divTablesenha_Internalname ;
      private string lblCode_Internalname ;
      private string lblCode_Jsonclick ;
      private string divTablecode_Internalname ;
      private string edtavText1_Internalname ;
      private string AV21Text1 ;
      private string edtavText1_Jsonclick ;
      private string edtavText2_Internalname ;
      private string AV22Text2 ;
      private string edtavText2_Jsonclick ;
      private string edtavText3_Internalname ;
      private string AV23Text3 ;
      private string edtavText3_Jsonclick ;
      private string edtavText4_Internalname ;
      private string AV24Text4 ;
      private string edtavText4_Jsonclick ;
      private string lblLblsenhaerror_Internalname ;
      private string lblLblsenhaerror_Caption ;
      private string lblLblsenhaerror_Jsonclick ;
      private string edtavSenagainmessage_Internalname ;
      private string divTablesendagain_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string bttBtncontinuar_Internalname ;
      private string bttBtncontinuar_Jsonclick ;
      private string divTablenewpasscontent_Internalname ;
      private string divTablenewpass_Internalname ;
      private string lblNewpasslbl_Internalname ;
      private string lblNewpasslbl_Jsonclick ;
      private string lblLblnewpass_Internalname ;
      private string lblLblnewpass_Jsonclick ;
      private string edtavNewpass_Internalname ;
      private string edtavNewpass_Jsonclick ;
      private string lblLblnewpasserror_Internalname ;
      private string lblLblnewpasserror_Caption ;
      private string lblLblnewpasserror_Jsonclick ;
      private string lblLblconfirmnewpass_Internalname ;
      private string lblLblconfirmnewpass_Jsonclick ;
      private string edtavConfirmnewpass_Internalname ;
      private string edtavConfirmnewpass_Jsonclick ;
      private string lblLblconfirmnewpasserror_Internalname ;
      private string lblLblconfirmnewpasserror_Caption ;
      private string lblLblconfirmnewpasserror_Jsonclick ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtnvoltar_Internalname ;
      private string bttBtnvoltar_Jsonclick ;
      private string Timer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXt_char2 ;
      private DateTime A216TemporaryCodeDateTime ;
      private DateTime AV28ThenDateTime ;
      private DateTime AV26NowDateTime ;
      private DateTime AV33DateTime ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV18IsOk ;
      private bool n217TemporaryCodeEmail ;
      private bool n215TemporaryCodeContent ;
      private bool n216TemporaryCodeDateTime ;
      private bool AV40IsEmailExists ;
      private bool n144SecUserEmail ;
      private string AV17String ;
      private string AV34FirstHTML ;
      private string A217TemporaryCodeEmail ;
      private string A215TemporaryCodeContent ;
      private string A144SecUserEmail ;
      private string AV15message ;
      private string AV25Email ;
      private string AV29SenAgainMessage ;
      private string AV36NewPass ;
      private string AV37ConfirmNewPass ;
      private string AV7Pass ;
      private string AV38Code ;
      private string AV39TemporaryCodeContent ;
      private GXUserControl ucTimer ;
      private IGxSession AV11WebSession ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV35Array_Email ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV13Context ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext GXt_SdtWWPContext1 ;
      private SdtSecUser AV20SecUser ;
      private GeneXus.Programs.genexuscryptography.SdtHashing AV12Hashing ;
      private IDataStoreProvider pr_default ;
      private int[] H004C2_A214TemporaryCodeId ;
      private string[] H004C2_A217TemporaryCodeEmail ;
      private bool[] H004C2_n217TemporaryCodeEmail ;
      private string[] H004C2_A215TemporaryCodeContent ;
      private bool[] H004C2_n215TemporaryCodeContent ;
      private DateTime[] H004C2_A216TemporaryCodeDateTime ;
      private bool[] H004C2_n216TemporaryCodeDateTime ;
      private string[] H004C3_A144SecUserEmail ;
      private bool[] H004C3_n144SecUserEmail ;
      private short[] H004C3_A133SecUserId ;
      private SdtTemporaryCode AV32TemporaryCode ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class recoverpassword3__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH004C2;
          prmH004C2 = new Object[] {
          new ParDef("AV25Email",GXType.VarChar,100,0)
          };
          Object[] prmH004C3;
          prmH004C3 = new Object[] {
          new ParDef("AV25Email",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H004C2", "SELECT TemporaryCodeId, TemporaryCodeEmail, TemporaryCodeContent, TemporaryCodeDateTime FROM TemporaryCode WHERE TemporaryCodeEmail = ( :AV25Email) ORDER BY TemporaryCodeDateTime DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004C2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H004C3", "SELECT SecUserEmail, SecUserId FROM SecUser WHERE UPPER(SecUserEmail) = ( UPPER(:AV25Email)) ORDER BY SecUserEmail ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004C3,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                return;
       }
    }

 }

}
