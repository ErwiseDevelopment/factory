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
   public class recover : GXDataArea
   {
      public recover( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("DSLogin", true);
      }

      public recover( IGxContext context )
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
         PA3O2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3O2( ) ;
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
         context.WriteHtmlText( " "+"class=\"form-horizontal no-overflow\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal no-overflow\" data-gx-class=\"form-horizontal no-overflow\" novalidate action=\""+formatLink("recover") +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal no-overflow", true);
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
         GxWebStd.gx_hidden_field( context, "vMESSAGE", AV15message);
         GxWebStd.gx_hidden_field( context, "vTHENDATETIME", context.localUtil.TToC( AV24ThenDateTime, 10, 8, 0, 0, "/", ":", " "));
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
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal no-overflow" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE3O2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3O2( ) ;
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
         return formatLink("recover")  ;
      }

      public override string GetPgmname( )
      {
         return "Recover" ;
      }

      public override string GetPgmdesc( )
      {
         return "Log in" ;
      }

      protected void WB3O0( )
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
            GxWebStd.gx_label_ctrl( context, lblTeste_Internalname, lblTeste_Caption, "", "", lblTeste_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_Recover.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablerec_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Static images/pictures */
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgLogo_gximage, "")==0) ? "GX_Image_LogoOld_Class" : "GX_Image_"+imgLogo_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "ca23d2de-3cea-40f3-a4ae-7986a087ac7f", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgLogo_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Recover.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSignin_Internalname, "<h1>Esqueci minha senha</h1>", "", "", lblSignin_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_Recover.htm");
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
            GxWebStd.gx_div_start( context, divTableemail_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblemail_Internalname, "<div style=\"padding-bottom: 1rem !important;\"><span style=\"font-size: 16px; \">Usuário</span></div>", "", "", lblLblemail_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_Recover.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecusername_Internalname, "Sec User Name", "col-sm-3 AttributeFLLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecusername_Internalname, AV9SecUserName, StringUtil.RTrim( context.localUtil.Format( AV9SecUserName, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecusername_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSecusername_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Recover.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblemailerror_Internalname, lblLblemailerror_Caption, "", "", lblLblemailerror_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "login-message", 0, "", 1, 1, 0, 0, "HLP_Recover.htm");
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
            GxWebStd.gx_div_start( context, divTablesenha_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsenha_Internalname, "<div style=\"padding-bottom: 1rem !important;\"><span style=\"font-size: 16px; \">E-mail</span></div>", "", "", lblLblsenha_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_Recover.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecuseremail_Internalname, AV19SecUserEmail, StringUtil.RTrim( context.localUtil.Format( AV19SecUserEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecuseremail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSecuseremail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_Recover.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsenhaerror_Internalname, lblLblsenhaerror_Caption, "", "", lblLblsenhaerror_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "login-message", 0, "", 1, 1, 0, 0, "HLP_Recover.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
            ClassString = "login-button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", bttBtnenter_Caption, bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, 1, bttBtnenter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Recover.htm");
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
            GxWebStd.gx_div_start( context, divTablemessage_Internalname, divTablemessage_Visible, 0, "px", 0, "px", "login-content", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table1_63_3O2( true) ;
         }
         else
         {
            wb_table1_63_3O2( false) ;
         }
         return  ;
      }

      protected void wb_table1_63_3O2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'',0)\"";
            ClassString = "login-button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnvoltar_Internalname, "", "Voltar", bttBtnvoltar_Jsonclick, 5, "Voltar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOVOLTAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Recover.htm");
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

      protected void START3O2( )
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
         Form.Meta.addItem("description", "Log in", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3O0( ) ;
      }

      protected void WS3O2( )
      {
         START3O2( ) ;
         EVT3O2( ) ;
      }

      protected void EVT3O2( )
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
                              E113O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E123O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOVOLTAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoVoltar' */
                              E133O2 ();
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
                                    E143O2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "TABLESENDAGAIN.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Tablesendagain.Click */
                              E153O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E163O2 ();
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

      protected void WE3O2( )
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

      protected void PA3O2( )
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
               GX_FocusControl = edtavSecusername_Internalname;
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
         RF3O2( ) ;
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

      protected void RF3O2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E163O2 ();
            WB3O0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes3O2( )
      {
      }

      protected void before_start_formulas( )
      {
         edtavSenagainmessage_Enabled = 0;
         AssignProp("", false, edtavSenagainmessage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSenagainmessage_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3O0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E123O2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Timer_Tickinterval = (int)(Math.Round(context.localUtil.CToN( cgiGet( "TIMER_Tickinterval"), ",", "."), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            AV9SecUserName = StringUtil.Upper( cgiGet( edtavSecusername_Internalname));
            AssignAttri("", false, "AV9SecUserName", AV9SecUserName);
            AV19SecUserEmail = cgiGet( edtavSecuseremail_Internalname);
            AssignAttri("", false, "AV19SecUserEmail", AV19SecUserEmail);
            AV20SenAgainMessage = cgiGet( edtavSenagainmessage_Internalname);
            AssignAttri("", false, "AV20SenAgainMessage", AV20SenAgainMessage);
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
         E123O2 ();
         if (returnInSub) return;
      }

      protected void E123O2( )
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
            CallWebObject(formatLink("financeiro") );
            context.wjLocDisableFrm = 1;
         }
         AV16File.Source = "index.html";
         AV16File.OpenRead("");
         while ( ! AV16File.Eof )
         {
            lblTeste_Caption = lblTeste_Caption+AV16File.ReadLine();
            AssignProp("", false, lblTeste_Internalname, "Caption", lblTeste_Caption, true);
         }
         AV16File.Close();
         divTablesendagain_Visible = 0;
         AssignProp("", false, divTablesendagain_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesendagain_Visible), 5, 0), true);
         divTablemessage_Visible = 0;
         AssignProp("", false, divTablemessage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablemessage_Visible), 5, 0), true);
         Timer_Tickinterval = 1;
         ucTimer.SendProperty(context, "", false, Timer_Internalname, "TickInterval", StringUtil.LTrimStr( (decimal)(Timer_Tickinterval), 9, 0));
      }

      protected void E133O2( )
      {
         /* 'DoVoltar' Routine */
         returnInSub = false;
         CallWebObject(formatLink("login") );
         context.wjLocDisableFrm = 1;
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E143O2 ();
         if (returnInSub) return;
      }

      protected void E143O2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV18IsOk = true;
         lblLblemailerror_Caption = "";
         AssignProp("", false, lblLblemailerror_Internalname, "Caption", lblLblemailerror_Caption, true);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9SecUserName)) )
         {
            lblLblemailerror_Caption = "Preencha o usuário";
            AssignProp("", false, lblLblemailerror_Internalname, "Caption", lblLblemailerror_Caption, true);
            AV18IsOk = false;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV19SecUserEmail)) )
         {
            lblLblsenhaerror_Caption = "Preencha o seu e-mail";
            AssignProp("", false, lblLblsenhaerror_Internalname, "Caption", lblLblsenhaerror_Caption, true);
            AV18IsOk = false;
         }
         if ( AV18IsOk )
         {
            bttBtnenter_Enabled = 0;
            AssignProp("", false, bttBtnenter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtnenter_Enabled), 5, 0), true);
            bttBtnenter_Caption = "";
            AssignProp("", false, bttBtnenter_Internalname, "Caption", bttBtnenter_Caption, true);
            new prrecoverpassword(context).executeSubmit(  AV9SecUserName,  AV19SecUserEmail, out  AV15message) ;
            divTablemessage_Visible = 1;
            AssignProp("", false, divTablemessage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablemessage_Visible), 5, 0), true);
            divTablelogin_Visible = 0;
            AssignProp("", false, divTablelogin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablelogin_Visible), 5, 0), true);
            AV22NowDateTime = DateTimeUtil.ServerNow( context, pr_default);
            AV24ThenDateTime = DateTimeUtil.TAdd( AV22NowDateTime, 40);
            AssignAttri("", false, "AV24ThenDateTime", context.localUtil.TToC( AV24ThenDateTime, 10, 8, 0, 3, "/", ":", " "));
            AV25Tempo = (short)(DateTimeUtil.TDiff( AV24ThenDateTime, AV22NowDateTime));
            AV20SenAgainMessage = StringUtil.Format( "E-mail enviado para %1. Aguarde %2 segundos", AV19SecUserEmail, StringUtil.LTrimStr( (decimal)(((AV25Tempo<=0) ? 0 : AV25Tempo)), 9, 0), "", "", "", "", "", "", "");
            AssignAttri("", false, "AV20SenAgainMessage", AV20SenAgainMessage);
            this.executeUsercontrolMethod("", false, "TIMERContainer", "Start", "", new Object[] {});
         }
         /*  Sending Event outputs  */
      }

      protected void E113O2( )
      {
         /* Timer_Tick Routine */
         returnInSub = false;
         AV22NowDateTime = DateTimeUtil.ServerNow( context, pr_default);
         AV25Tempo = (short)(DateTimeUtil.TDiff( AV24ThenDateTime, AV22NowDateTime));
         AV20SenAgainMessage = StringUtil.Format( "E-mail enviado para %1. Aguarde %2 segundos", AV19SecUserEmail, StringUtil.LTrimStr( (decimal)(AV25Tempo), 4, 0), "", "", "", "", "", "", "");
         AssignAttri("", false, "AV20SenAgainMessage", AV20SenAgainMessage);
         if ( AV25Tempo <= 0 )
         {
            AV20SenAgainMessage = StringUtil.Format( "E-mail enviado para %1", AV19SecUserEmail, "", "", "", "", "", "", "", "");
            AssignAttri("", false, "AV20SenAgainMessage", AV20SenAgainMessage);
            divTablesendagain_Visible = 1;
            AssignProp("", false, divTablesendagain_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesendagain_Visible), 5, 0), true);
            this.executeUsercontrolMethod("", false, "TIMERContainer", "Stop", "", new Object[] {});
         }
         /*  Sending Event outputs  */
      }

      protected void E153O2( )
      {
         /* Tablesendagain_Click Routine */
         returnInSub = false;
         AV22NowDateTime = DateTimeUtil.ServerNow( context, pr_default);
         AV24ThenDateTime = DateTimeUtil.TAdd( AV22NowDateTime, 40);
         AssignAttri("", false, "AV24ThenDateTime", context.localUtil.TToC( AV24ThenDateTime, 10, 8, 0, 3, "/", ":", " "));
         divTablesendagain_Visible = 0;
         AssignProp("", false, divTablesendagain_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesendagain_Visible), 5, 0), true);
         this.executeUsercontrolMethod("", false, "TIMERContainer", "Start", "", new Object[] {});
         /*  Sending Event outputs  */
      }

      protected void nextLoad( )
      {
      }

      protected void E163O2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_63_3O2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedsenagainmessage_Internalname, tblTablemergedsenagainmessage_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSenagainmessage_Internalname, "Sen Again Message", "gx-form-item recover-messageLabel", 0, true, "width: 25%;");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
            ClassString = "recover-message";
            StyleString = "";
            ClassString = "recover-message";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavSenagainmessage_Internalname, AV20SenAgainMessage, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"", 0, 1, edtavSenagainmessage_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Recover.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesendagain_Internalname, divTablesendagain_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "<span style=\"margin-left:3px; \">enviar novamente</span>", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_Recover.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_63_3O2e( true) ;
         }
         else
         {
            wb_table1_63_3O2e( false) ;
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
         PA3O2( ) ;
         WS3O2( ) ;
         WE3O2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019235056", true, true);
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
         context.AddJavascriptSource("recover.js", "?202561019235056", false, true);
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
         edtavSecusername_Internalname = "vSECUSERNAME";
         lblLblemailerror_Internalname = "LBLEMAILERROR";
         divTableemail_Internalname = "TABLEEMAIL";
         lblLblsenha_Internalname = "LBLSENHA";
         edtavSecuseremail_Internalname = "vSECUSEREMAIL";
         lblLblsenhaerror_Internalname = "LBLSENHAERROR";
         divTablesenha_Internalname = "TABLESENHA";
         bttBtnenter_Internalname = "BTNENTER";
         divTablelogin_Internalname = "TABLELOGIN";
         divTablerec_Internalname = "TABLEREC";
         edtavSenagainmessage_Internalname = "vSENAGAINMESSAGE";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         divTablesendagain_Internalname = "TABLESENDAGAIN";
         tblTablemergedsenagainmessage_Internalname = "TABLEMERGEDSENAGAINMESSAGE";
         bttBtnvoltar_Internalname = "BTNVOLTAR";
         divTablemessage_Internalname = "TABLEMESSAGE";
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
         divTablesendagain_Visible = 1;
         edtavSenagainmessage_Enabled = 1;
         divTablemessage_Visible = 1;
         bttBtnenter_Caption = "Redefinir senha";
         bttBtnenter_Enabled = 1;
         lblLblsenhaerror_Caption = "";
         edtavSecuseremail_Jsonclick = "";
         edtavSecuseremail_Enabled = 1;
         lblLblemailerror_Caption = "";
         edtavSecusername_Jsonclick = "";
         edtavSecusername_Enabled = 1;
         divTablelogin_Visible = 1;
         lblTeste_Caption = "";
         divLayoutmaintable_Class = "Table";
         Timer_Tickinterval = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Log in";
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
         setEventMetadata("'DOVOLTAR'","""{"handler":"E133O2","iparms":[]}""");
         setEventMetadata("ENTER","""{"handler":"E143O2","iparms":[{"av":"AV9SecUserName","fld":"vSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV19SecUserEmail","fld":"vSECUSEREMAIL","type":"svchar"},{"av":"AV15message","fld":"vMESSAGE","type":"svchar"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"lblLblemailerror_Caption","ctrl":"LBLEMAILERROR","prop":"Caption"},{"av":"lblLblsenhaerror_Caption","ctrl":"LBLSENHAERROR","prop":"Caption"},{"ctrl":"BTNENTER","prop":"Enabled"},{"ctrl":"BTNENTER","prop":"Caption"},{"av":"AV15message","fld":"vMESSAGE","type":"svchar"},{"av":"AV19SecUserEmail","fld":"vSECUSEREMAIL","type":"svchar"},{"av":"AV9SecUserName","fld":"vSECUSERNAME","pic":"@!","type":"svchar"},{"av":"divTablemessage_Visible","ctrl":"TABLEMESSAGE","prop":"Visible"},{"av":"divTablelogin_Visible","ctrl":"TABLELOGIN","prop":"Visible"},{"av":"AV24ThenDateTime","fld":"vTHENDATETIME","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV20SenAgainMessage","fld":"vSENAGAINMESSAGE","type":"svchar"}]}""");
         setEventMetadata("TIMER.TICK","""{"handler":"E113O2","iparms":[{"av":"AV24ThenDateTime","fld":"vTHENDATETIME","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV19SecUserEmail","fld":"vSECUSEREMAIL","type":"svchar"}]""");
         setEventMetadata("TIMER.TICK",""","oparms":[{"av":"AV20SenAgainMessage","fld":"vSENAGAINMESSAGE","type":"svchar"},{"av":"divTablesendagain_Visible","ctrl":"TABLESENDAGAIN","prop":"Visible"}]}""");
         setEventMetadata("TABLESENDAGAIN.CLICK","""{"handler":"E153O2","iparms":[]""");
         setEventMetadata("TABLESENDAGAIN.CLICK",""","oparms":[{"av":"AV24ThenDateTime","fld":"vTHENDATETIME","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"divTablesendagain_Visible","ctrl":"TABLESENDAGAIN","prop":"Visible"}]}""");
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
         AV15message = "";
         AV24ThenDateTime = (DateTime)(DateTime.MinValue);
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
         AV9SecUserName = "";
         lblLblemailerror_Jsonclick = "";
         lblLblsenha_Jsonclick = "";
         AV19SecUserEmail = "";
         lblLblsenhaerror_Jsonclick = "";
         bttBtnenter_Jsonclick = "";
         bttBtnvoltar_Jsonclick = "";
         ucTimer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV20SenAgainMessage = "";
         AV13Context = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtWWPContext1 = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV16File = new GxFile(context.GetPhysicalPath());
         AV22NowDateTime = (DateTime)(DateTime.MinValue);
         sStyleString = "";
         lblTextblock1_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.recover__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         edtavSenagainmessage_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV25Tempo ;
      private short nGXWrapped ;
      private int Timer_Tickinterval ;
      private int divTablelogin_Visible ;
      private int edtavSecusername_Enabled ;
      private int edtavSecuseremail_Enabled ;
      private int bttBtnenter_Enabled ;
      private int divTablemessage_Visible ;
      private int edtavSenagainmessage_Enabled ;
      private int divTablesendagain_Visible ;
      private int idxLst ;
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
      private string lblTeste_Caption ;
      private string lblTeste_Jsonclick ;
      private string divTableright_Internalname ;
      private string divTablerec_Internalname ;
      private string ClassString ;
      private string imgLogo_gximage ;
      private string StyleString ;
      private string sImgUrl ;
      private string imgLogo_Internalname ;
      private string lblSignin_Internalname ;
      private string lblSignin_Jsonclick ;
      private string divTablelogin_Internalname ;
      private string divTableemail_Internalname ;
      private string lblLblemail_Internalname ;
      private string lblLblemail_Jsonclick ;
      private string edtavSecusername_Internalname ;
      private string TempTags ;
      private string edtavSecusername_Jsonclick ;
      private string lblLblemailerror_Internalname ;
      private string lblLblemailerror_Caption ;
      private string lblLblemailerror_Jsonclick ;
      private string divTablesenha_Internalname ;
      private string lblLblsenha_Internalname ;
      private string lblLblsenha_Jsonclick ;
      private string edtavSecuseremail_Internalname ;
      private string edtavSecuseremail_Jsonclick ;
      private string lblLblsenhaerror_Internalname ;
      private string lblLblsenhaerror_Caption ;
      private string lblLblsenhaerror_Jsonclick ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Caption ;
      private string bttBtnenter_Jsonclick ;
      private string divTablemessage_Internalname ;
      private string bttBtnvoltar_Internalname ;
      private string bttBtnvoltar_Jsonclick ;
      private string Timer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavSenagainmessage_Internalname ;
      private string divTablesendagain_Internalname ;
      private string sStyleString ;
      private string tblTablemergedsenagainmessage_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private DateTime AV24ThenDateTime ;
      private DateTime AV22NowDateTime ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV18IsOk ;
      private string AV15message ;
      private string AV9SecUserName ;
      private string AV19SecUserEmail ;
      private string AV20SenAgainMessage ;
      private GXUserControl ucTimer ;
      private GxFile AV16File ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV13Context ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext GXt_SdtWWPContext1 ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class recover__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

 }

}
