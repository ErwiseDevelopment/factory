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
   public class codigo : GXDataArea
   {
      public codigo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public codigo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_AssinaturaParticipanteId )
      {
         this.AV6AssinaturaParticipanteId = aP0_AssinaturaParticipanteId;
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
            gxfirstwebparm = GetFirstPar( "AssinaturaParticipanteId");
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
               gxfirstwebparm = GetFirstPar( "AssinaturaParticipanteId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "AssinaturaParticipanteId");
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
         PA712( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START712( ) ;
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
         context.AddJavascriptSource("UserControls/FourDigitsRender.js", "", false, true);
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "codigo"+UrlEncode(StringUtil.LTrimStr(AV6AssinaturaParticipanteId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("codigo") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vALEATCODIGO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7AleatCodigo), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vALEATCODIGO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7AleatCodigo), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vASSINATURAPARTICIPANTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6AssinaturaParticipanteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vASSINATURAPARTICIPANTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV6AssinaturaParticipanteId), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "ASSINATURAPARTICIPANTETOKENID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A554AssinaturaParticipanteTokenId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ASSINATURAPARTICIPANTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A242AssinaturaParticipanteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vASSINATURAPARTICIPANTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6AssinaturaParticipanteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vASSINATURAPARTICIPANTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV6AssinaturaParticipanteId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "ASSINATURAPARTICIPANTETOKENEXPIRE", context.localUtil.TToC( A555AssinaturaParticipanteTokenExpire, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_boolean_hidden_field( context, "ASSINATURAPARTICIPANTETOKENUSED", A556AssinaturaParticipanteTokenUsed);
         GxWebStd.gx_hidden_field( context, "ASSINATURAPARTICIPANTETOKENCONTENT", A557AssinaturaParticipanteTokenContent);
         GxWebStd.gx_hidden_field( context, "vAUXCODIGO", AV21AuxCodigo);
         GxWebStd.gx_hidden_field( context, "PARTICIPANTENOME", A248ParticipanteNome);
         GxWebStd.gx_hidden_field( context, "vALEATCODIGO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7AleatCodigo), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vALEATCODIGO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7AleatCodigo), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "ASSINATURAPARTICIPANTEEMAIL", A351AssinaturaParticipanteEmail);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vARRAY_EMAIL", AV12Array_Email);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vARRAY_EMAIL", AV12Array_Email);
         }
         GxWebStd.gx_hidden_field( context, "vMESSAGE", AV13message);
         GxWebStd.gx_hidden_field( context, "vTIMERDATETIME", context.localUtil.TToC( AV16TimerDateTime, 10, 8, 0, 0, "/", ":", " "));
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
            WE712( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT712( ) ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "codigo"+UrlEncode(StringUtil.LTrimStr(AV6AssinaturaParticipanteId,9,0));
         return formatLink("codigo") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Codigo" ;
      }

      public override string GetPgmdesc( )
      {
         return "Código de confirmação" ;
      }

      protected void WB710( )
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;justify-content:center;align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "TableLogin2Cols", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "<h1>Insira o Código</h1>", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_Codigo.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCodigo_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCodigo_Internalname, AV5Codigo, StringUtil.RTrim( context.localUtil.Format( AV5Codigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,18);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Cole ou digite seu código aqui", edtavCodigo_Jsonclick, 0, "AttributeCardsMenuTitle", "", "", "", "", 1, edtavCodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Codigo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "<p>Enviamos um código para o seu e-mail. Insira-o abaixo para verificar.</p>", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_Codigo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecodigo_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table1_27_712( true) ;
         }
         else
         {
            wb_table1_27_712( false) ;
         }
         return  ;
      }

      protected void wb_table1_27_712e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", "Continuar para assinatura", bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Codigo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucDigits.Render(context, "fourdigits", Digits_Internalname, "DIGITSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucTimer.Render(context, "wwp.chronometer", Timer_Internalname, "TIMERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START712( )
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
         Form.Meta.addItem("description", "Código de confirmação", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP710( ) ;
      }

      protected void WS712( )
      {
         START712( ) ;
         EVT712( ) ;
      }

      protected void EVT712( )
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
                              E11712 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E12712 ();
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
                                    E13712 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOREENVIARCODIGO'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoReenviarCodigo' */
                              E14712 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E15712 ();
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

      protected void WE712( )
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

      protected void PA712( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
            }
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "codigo")), "codigo") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "codigo")))) ;
               }
               else
               {
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               }
            }
            if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               if ( nGotPars == 0 )
               {
                  entryPointCalled = false;
                  gxfirstwebparm = GetFirstPar( "AssinaturaParticipanteId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV6AssinaturaParticipanteId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV6AssinaturaParticipanteId", StringUtil.LTrimStr( (decimal)(AV6AssinaturaParticipanteId), 9, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vASSINATURAPARTICIPANTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV6AssinaturaParticipanteId), "ZZZZZZZZ9"), context));
                  }
                  if ( toggleJsOutput )
                  {
                     if ( context.isSpaRequest( ) )
                     {
                        enableJsOutput();
                     }
                  }
               }
            }
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
               GX_FocusControl = edtavCodigo_Internalname;
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
         RF712( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF712( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E15712 ();
            WB710( ) ;
         }
      }

      protected void send_integrity_lvl_hashes712( )
      {
         GxWebStd.gx_hidden_field( context, "vALEATCODIGO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7AleatCodigo), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vALEATCODIGO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7AleatCodigo), "ZZZ9"), context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP710( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E12712 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Timer_Tickinterval = (int)(Math.Round(context.localUtil.CToN( cgiGet( "TIMER_Tickinterval"), ",", "."), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            AV5Codigo = cgiGet( edtavCodigo_Internalname);
            AssignAttri("", false, "AV5Codigo", AV5Codigo);
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
         E12712 ();
         if (returnInSub) return;
      }

      protected void E12712( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'INICIARTIMER' */
         S112 ();
         if (returnInSub) return;
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E13712 ();
         if (returnInSub) return;
      }

      protected void E13712( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV9DateTime = DateTimeUtil.ServerNow( context, pr_default);
         AssignAttri("", false, "AV9DateTime", context.localUtil.TToC( AV9DateTime, 8, 5, 0, 3, "/", ":", " "));
         AV22GXLvl17 = 0;
         /* Using cursor H00712 */
         pr_default.execute(0, new Object[] {AV9DateTime, AV5Codigo, AV6AssinaturaParticipanteId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A557AssinaturaParticipanteTokenContent = H00712_A557AssinaturaParticipanteTokenContent[0];
            n557AssinaturaParticipanteTokenContent = H00712_n557AssinaturaParticipanteTokenContent[0];
            A556AssinaturaParticipanteTokenUsed = H00712_A556AssinaturaParticipanteTokenUsed[0];
            n556AssinaturaParticipanteTokenUsed = H00712_n556AssinaturaParticipanteTokenUsed[0];
            A555AssinaturaParticipanteTokenExpire = H00712_A555AssinaturaParticipanteTokenExpire[0];
            n555AssinaturaParticipanteTokenExpire = H00712_n555AssinaturaParticipanteTokenExpire[0];
            A242AssinaturaParticipanteId = H00712_A242AssinaturaParticipanteId[0];
            n242AssinaturaParticipanteId = H00712_n242AssinaturaParticipanteId[0];
            A554AssinaturaParticipanteTokenId = H00712_A554AssinaturaParticipanteTokenId[0];
            AV22GXLvl17 = 1;
            AV8AssinaturaParticipanteToken.Load(A554AssinaturaParticipanteTokenId);
            AV8AssinaturaParticipanteToken.gxTpr_Assinaturaparticipantetokenused = true;
            AV8AssinaturaParticipanteToken.Save();
            context.CommitDataStores("codigo",pr_default);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "signature"+UrlEncode(StringUtil.LTrimStr(AV6AssinaturaParticipanteId,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV5Codigo));
            CallWebObject(formatLink("signature") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV22GXLvl17 == 0 )
         {
            GXt_char1 = "Codigo incorreto";
            new message(context ).gxep_erro( ref  GXt_char1) ;
         }
         /*  Sending Event outputs  */
      }

      protected void E14712( )
      {
         /* 'DoReenviarCodigo' Routine */
         returnInSub = false;
         /* Using cursor H00713 */
         pr_default.execute(1, new Object[] {AV6AssinaturaParticipanteId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A233ParticipanteId = H00713_A233ParticipanteId[0];
            n233ParticipanteId = H00713_n233ParticipanteId[0];
            A242AssinaturaParticipanteId = H00713_A242AssinaturaParticipanteId[0];
            n242AssinaturaParticipanteId = H00713_n242AssinaturaParticipanteId[0];
            A248ParticipanteNome = H00713_A248ParticipanteNome[0];
            n248ParticipanteNome = H00713_n248ParticipanteNome[0];
            A351AssinaturaParticipanteEmail = H00713_A351AssinaturaParticipanteEmail[0];
            n351AssinaturaParticipanteEmail = H00713_n351AssinaturaParticipanteEmail[0];
            A248ParticipanteNome = H00713_A248ParticipanteNome[0];
            n248ParticipanteNome = H00713_n248ParticipanteNome[0];
            AV18i = 0;
            while ( AV18i < 4 )
            {
               AV19SesNro = (decimal)(NumberUtil.Random( ));
               AV19SesNro = (decimal)(AV19SesNro*10);
               AV20Numero = (short)(Math.Round(AV19SesNro, 18, MidpointRounding.ToEven));
               AV21AuxCodigo = StringUtil.Format( "%1%2", AV21AuxCodigo, StringUtil.LTrimStr( (decimal)(AV20Numero), 4, 0), "", "", "", "", "", "", "");
               AssignAttri("", false, "AV21AuxCodigo", AV21AuxCodigo);
               AV18i = (short)(AV18i+1);
            }
            AV21AuxCodigo = StringUtil.Substring( AV21AuxCodigo, 1, 4);
            AssignAttri("", false, "AV21AuxCodigo", AV21AuxCodigo);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21AuxCodigo)) )
            {
               AV9DateTime = DateTimeUtil.ServerNow( context, pr_default);
               AssignAttri("", false, "AV9DateTime", context.localUtil.TToC( AV9DateTime, 8, 5, 0, 3, "/", ":", " "));
               AV9DateTime = DateTimeUtil.TAdd( AV9DateTime, 60*(30));
               AssignAttri("", false, "AV9DateTime", context.localUtil.TToC( AV9DateTime, 8, 5, 0, 3, "/", ":", " "));
               AV8AssinaturaParticipanteToken = new SdtAssinaturaParticipanteToken(context);
               AV8AssinaturaParticipanteToken.gxTpr_Assinaturaparticipantetokenexpire = AV9DateTime;
               AV8AssinaturaParticipanteToken.gxTpr_Assinaturaparticipanteid = AV6AssinaturaParticipanteId;
               AV8AssinaturaParticipanteToken.gxTpr_Assinaturaparticipantetokencontent = StringUtil.Trim( AV21AuxCodigo);
               AV8AssinaturaParticipanteToken.Save();
               if ( AV8AssinaturaParticipanteToken.Success() )
               {
                  context.CommitDataStores("codigo",pr_default);
               }
               else
               {
                  context.RollbackDataStores("codigo",pr_default);
                  GXt_char1 = "Ocorreu um erro ao gerar seu código, por favor entre em contato!";
                  new message(context ).gxep_regular( ref  GXt_char1) ;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               AV14ParticipanteNome = A248ParticipanteNome;
               new premailotpsignature(context ).execute(  AV14ParticipanteNome,  StringUtil.Trim( StringUtil.Str( (decimal)(AV7AleatCodigo), 4, 0)), out  AV10HTML) ;
               AV11Email = A351AssinaturaParticipanteEmail;
               AV12Array_Email.Add(AV11Email, 0);
               new sendemail(context).executeSubmit(  "Código para assinatura",  AV10HTML,  AV12Array_Email, out  AV13message) ;
               bttBtnreenviarcodigo_Visible = 0;
               AssignProp("", false, bttBtnreenviarcodigo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnreenviarcodigo_Visible), 5, 0), true);
            }
            else
            {
               GXt_char1 = "Ocorreu um erro ao gerar seu código, por favor entre em contato!";
               new message(context ).gxep_regular( ref  GXt_char1) ;
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         /* Execute user subroutine: 'INICIARTIMER' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV12Array_Email", AV12Array_Email);
      }

      protected void E11712( )
      {
         /* Timer_Tick Routine */
         returnInSub = false;
         AV15NowDateTime = DateTimeUtil.ServerNow( context, pr_default);
         AV17Diferenca = (short)(DateTimeUtil.TDiff( AV16TimerDateTime, AV15NowDateTime));
         if ( AV17Diferenca <= 0 )
         {
            AV17Diferenca = 0;
            lblTextblock3_Caption = StringUtil.Format( "<p class=\"resend-message\">Não recebeu o código? </p>", StringUtil.LTrimStr( (decimal)(AV17Diferenca), 4, 0), "", "", "", "", "", "", "", "");
            AssignProp("", false, lblTextblock3_Internalname, "Caption", lblTextblock3_Caption, true);
            bttBtnreenviarcodigo_Visible = 1;
            AssignProp("", false, bttBtnreenviarcodigo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnreenviarcodigo_Visible), 5, 0), true);
            this.executeUsercontrolMethod("", false, "TIMERContainer", "Stop", "", new Object[] {});
         }
         else
         {
            bttBtnreenviarcodigo_Visible = 0;
            AssignProp("", false, bttBtnreenviarcodigo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnreenviarcodigo_Visible), 5, 0), true);
            lblTextblock3_Caption = StringUtil.Format( "<p class=\"resend-message\">Não recebeu o código? Tente novamente em <span id=\"timer\">%1</span> segundos.</p>", StringUtil.LTrimStr( (decimal)(AV17Diferenca), 4, 0), "", "", "", "", "", "", "", "");
            AssignProp("", false, lblTextblock3_Internalname, "Caption", lblTextblock3_Caption, true);
         }
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'INICIARTIMER' Routine */
         returnInSub = false;
         AV16TimerDateTime = DateTimeUtil.ServerNow( context, pr_default);
         AssignAttri("", false, "AV16TimerDateTime", context.localUtil.TToC( AV16TimerDateTime, 8, 5, 0, 3, "/", ":", " "));
         AV16TimerDateTime = DateTimeUtil.TAdd( AV16TimerDateTime, 30);
         AssignAttri("", false, "AV16TimerDateTime", context.localUtil.TToC( AV16TimerDateTime, 8, 5, 0, 3, "/", ":", " "));
         Timer_Tickinterval = 1;
         ucTimer.SendProperty(context, "", false, Timer_Internalname, "TickInterval", StringUtil.LTrimStr( (decimal)(Timer_Tickinterval), 9, 0));
         this.executeUsercontrolMethod("", false, "TIMERContainer", "Start", "", new Object[] {});
      }

      protected void nextLoad( )
      {
      }

      protected void E15712( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_27_712( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedtextblock3_Internalname, tblTablemergedtextblock3_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, lblTextblock3_Caption, "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_Codigo.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnreenviarcodigo_Internalname, "", "Reenviar código", bttBtnreenviarcodigo_Jsonclick, 5, "Reenviar código", "", StyleString, ClassString, bttBtnreenviarcodigo_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOREENVIARCODIGO\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Codigo.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_27_712e( true) ;
         }
         else
         {
            wb_table1_27_712e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV6AssinaturaParticipanteId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV6AssinaturaParticipanteId", StringUtil.LTrimStr( (decimal)(AV6AssinaturaParticipanteId), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vASSINATURAPARTICIPANTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV6AssinaturaParticipanteId), "ZZZZZZZZ9"), context));
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
         PA712( ) ;
         WS712( ) ;
         WE712( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019261460", true, true);
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
         context.AddJavascriptSource("codigo.js", "?202561019261460", false, true);
         context.AddJavascriptSource("UserControls/FourDigitsRender.js", "", false, true);
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
         lblTextblock1_Internalname = "TEXTBLOCK1";
         edtavCodigo_Internalname = "vCODIGO";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         bttBtnreenviarcodigo_Internalname = "BTNREENVIARCODIGO";
         tblTablemergedtextblock3_Internalname = "TABLEMERGEDTEXTBLOCK3";
         divTablecodigo_Internalname = "TABLECODIGO";
         bttBtnenter_Internalname = "BTNENTER";
         divTablecontent_Internalname = "TABLECONTENT";
         Digits_Internalname = "DIGITS";
         Timer_Internalname = "TIMER";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         bttBtnreenviarcodigo_Visible = 1;
         lblTextblock3_Caption = "<p class=\"resend-message\">Não recebeu o código? Tente novamente em <span id=\"timer\">30</span> segundos.</p>";
         edtavCodigo_Jsonclick = "";
         edtavCodigo_Enabled = 1;
         Timer_Tickinterval = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Código de confirmação";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV6AssinaturaParticipanteId","fld":"vASSINATURAPARTICIPANTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV7AleatCodigo","fld":"vALEATCODIGO","pic":"ZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("ENTER","""{"handler":"E13712","iparms":[{"av":"A554AssinaturaParticipanteTokenId","fld":"ASSINATURAPARTICIPANTETOKENID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A242AssinaturaParticipanteId","fld":"ASSINATURAPARTICIPANTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV6AssinaturaParticipanteId","fld":"vASSINATURAPARTICIPANTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A555AssinaturaParticipanteTokenExpire","fld":"ASSINATURAPARTICIPANTETOKENEXPIRE","pic":"99/99/99 99:99","type":"dtime"},{"av":"A556AssinaturaParticipanteTokenUsed","fld":"ASSINATURAPARTICIPANTETOKENUSED","type":"boolean"},{"av":"A557AssinaturaParticipanteTokenContent","fld":"ASSINATURAPARTICIPANTETOKENCONTENT","type":"svchar"},{"av":"AV5Codigo","fld":"vCODIGO","type":"svchar"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV9DateTime","fld":"vDATETIME","pic":"99/99/99 99:99","type":"dtime"}]}""");
         setEventMetadata("'DOREENVIARCODIGO'","""{"handler":"E14712","iparms":[{"av":"A242AssinaturaParticipanteId","fld":"ASSINATURAPARTICIPANTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV6AssinaturaParticipanteId","fld":"vASSINATURAPARTICIPANTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV21AuxCodigo","fld":"vAUXCODIGO","type":"svchar"},{"av":"A248ParticipanteNome","fld":"PARTICIPANTENOME","type":"svchar"},{"av":"AV7AleatCodigo","fld":"vALEATCODIGO","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"A351AssinaturaParticipanteEmail","fld":"ASSINATURAPARTICIPANTEEMAIL","type":"svchar"},{"av":"AV12Array_Email","fld":"vARRAY_EMAIL","type":""},{"av":"AV13message","fld":"vMESSAGE","type":"svchar"}]""");
         setEventMetadata("'DOREENVIARCODIGO'",""","oparms":[{"av":"AV21AuxCodigo","fld":"vAUXCODIGO","type":"svchar"},{"av":"AV9DateTime","fld":"vDATETIME","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV12Array_Email","fld":"vARRAY_EMAIL","type":""},{"av":"AV13message","fld":"vMESSAGE","type":"svchar"},{"ctrl":"BTNREENVIARCODIGO","prop":"Visible"},{"av":"AV16TimerDateTime","fld":"vTIMERDATETIME","pic":"99/99/99 99:99","type":"dtime"},{"av":"Timer_Tickinterval","ctrl":"TIMER","prop":"TickInterval"}]}""");
         setEventMetadata("TIMER.TICK","""{"handler":"E11712","iparms":[{"av":"AV16TimerDateTime","fld":"vTIMERDATETIME","pic":"99/99/99 99:99","type":"dtime"}]""");
         setEventMetadata("TIMER.TICK",""","oparms":[{"av":"lblTextblock3_Caption","ctrl":"TEXTBLOCK3","prop":"Caption"},{"ctrl":"BTNREENVIARCODIGO","prop":"Visible"}]}""");
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
         GXEncryptionTmp = "";
         A555AssinaturaParticipanteTokenExpire = (DateTime)(DateTime.MinValue);
         A557AssinaturaParticipanteTokenContent = "";
         AV21AuxCodigo = "";
         A248ParticipanteNome = "";
         A351AssinaturaParticipanteEmail = "";
         AV12Array_Email = new GxSimpleCollection<string>();
         AV13message = "";
         AV16TimerDateTime = (DateTime)(DateTime.MinValue);
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         lblTextblock1_Jsonclick = "";
         TempTags = "";
         AV5Codigo = "";
         lblTextblock2_Jsonclick = "";
         bttBtnenter_Jsonclick = "";
         ucDigits = new GXUserControl();
         ucTimer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV9DateTime = (DateTime)(DateTime.MinValue);
         H00712_A557AssinaturaParticipanteTokenContent = new string[] {""} ;
         H00712_n557AssinaturaParticipanteTokenContent = new bool[] {false} ;
         H00712_A556AssinaturaParticipanteTokenUsed = new bool[] {false} ;
         H00712_n556AssinaturaParticipanteTokenUsed = new bool[] {false} ;
         H00712_A555AssinaturaParticipanteTokenExpire = new DateTime[] {DateTime.MinValue} ;
         H00712_n555AssinaturaParticipanteTokenExpire = new bool[] {false} ;
         H00712_A242AssinaturaParticipanteId = new int[1] ;
         H00712_n242AssinaturaParticipanteId = new bool[] {false} ;
         H00712_A554AssinaturaParticipanteTokenId = new int[1] ;
         AV8AssinaturaParticipanteToken = new SdtAssinaturaParticipanteToken(context);
         H00713_A233ParticipanteId = new int[1] ;
         H00713_n233ParticipanteId = new bool[] {false} ;
         H00713_A242AssinaturaParticipanteId = new int[1] ;
         H00713_n242AssinaturaParticipanteId = new bool[] {false} ;
         H00713_A248ParticipanteNome = new string[] {""} ;
         H00713_n248ParticipanteNome = new bool[] {false} ;
         H00713_A351AssinaturaParticipanteEmail = new string[] {""} ;
         H00713_n351AssinaturaParticipanteEmail = new bool[] {false} ;
         AV14ParticipanteNome = "";
         AV10HTML = "";
         AV11Email = "";
         GXt_char1 = "";
         AV15NowDateTime = (DateTime)(DateTime.MinValue);
         sStyleString = "";
         lblTextblock3_Jsonclick = "";
         bttBtnreenviarcodigo_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.codigo__default(),
            new Object[][] {
                new Object[] {
               H00712_A557AssinaturaParticipanteTokenContent, H00712_n557AssinaturaParticipanteTokenContent, H00712_A556AssinaturaParticipanteTokenUsed, H00712_n556AssinaturaParticipanteTokenUsed, H00712_A555AssinaturaParticipanteTokenExpire, H00712_n555AssinaturaParticipanteTokenExpire, H00712_A242AssinaturaParticipanteId, H00712_n242AssinaturaParticipanteId, H00712_A554AssinaturaParticipanteTokenId
               }
               , new Object[] {
               H00713_A233ParticipanteId, H00713_n233ParticipanteId, H00713_A242AssinaturaParticipanteId, H00713_A248ParticipanteNome, H00713_n248ParticipanteNome, H00713_A351AssinaturaParticipanteEmail, H00713_n351AssinaturaParticipanteEmail
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
      private short AV7AleatCodigo ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short AV22GXLvl17 ;
      private short gxcookieaux ;
      private short AV18i ;
      private short AV20Numero ;
      private short AV17Diferenca ;
      private short nGXWrapped ;
      private int AV6AssinaturaParticipanteId ;
      private int wcpOAV6AssinaturaParticipanteId ;
      private int A554AssinaturaParticipanteTokenId ;
      private int A242AssinaturaParticipanteId ;
      private int Timer_Tickinterval ;
      private int edtavCodigo_Enabled ;
      private int A233ParticipanteId ;
      private int bttBtnreenviarcodigo_Visible ;
      private int idxLst ;
      private decimal AV19SesNro ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string edtavCodigo_Internalname ;
      private string TempTags ;
      private string edtavCodigo_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string divTablecodigo_Internalname ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string Digits_Internalname ;
      private string Timer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string bttBtnreenviarcodigo_Internalname ;
      private string GXt_char1 ;
      private string lblTextblock3_Caption ;
      private string lblTextblock3_Internalname ;
      private string sStyleString ;
      private string tblTablemergedtextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string bttBtnreenviarcodigo_Jsonclick ;
      private DateTime A555AssinaturaParticipanteTokenExpire ;
      private DateTime AV16TimerDateTime ;
      private DateTime AV9DateTime ;
      private DateTime AV15NowDateTime ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool A556AssinaturaParticipanteTokenUsed ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n557AssinaturaParticipanteTokenContent ;
      private bool n556AssinaturaParticipanteTokenUsed ;
      private bool n555AssinaturaParticipanteTokenExpire ;
      private bool n242AssinaturaParticipanteId ;
      private bool n233ParticipanteId ;
      private bool n248ParticipanteNome ;
      private bool n351AssinaturaParticipanteEmail ;
      private string AV10HTML ;
      private string A557AssinaturaParticipanteTokenContent ;
      private string AV21AuxCodigo ;
      private string A248ParticipanteNome ;
      private string A351AssinaturaParticipanteEmail ;
      private string AV13message ;
      private string AV5Codigo ;
      private string AV14ParticipanteNome ;
      private string AV11Email ;
      private GXUserControl ucDigits ;
      private GXUserControl ucTimer ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV12Array_Email ;
      private IDataStoreProvider pr_default ;
      private string[] H00712_A557AssinaturaParticipanteTokenContent ;
      private bool[] H00712_n557AssinaturaParticipanteTokenContent ;
      private bool[] H00712_A556AssinaturaParticipanteTokenUsed ;
      private bool[] H00712_n556AssinaturaParticipanteTokenUsed ;
      private DateTime[] H00712_A555AssinaturaParticipanteTokenExpire ;
      private bool[] H00712_n555AssinaturaParticipanteTokenExpire ;
      private int[] H00712_A242AssinaturaParticipanteId ;
      private bool[] H00712_n242AssinaturaParticipanteId ;
      private int[] H00712_A554AssinaturaParticipanteTokenId ;
      private SdtAssinaturaParticipanteToken AV8AssinaturaParticipanteToken ;
      private int[] H00713_A233ParticipanteId ;
      private bool[] H00713_n233ParticipanteId ;
      private int[] H00713_A242AssinaturaParticipanteId ;
      private bool[] H00713_n242AssinaturaParticipanteId ;
      private string[] H00713_A248ParticipanteNome ;
      private bool[] H00713_n248ParticipanteNome ;
      private string[] H00713_A351AssinaturaParticipanteEmail ;
      private bool[] H00713_n351AssinaturaParticipanteEmail ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class codigo__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00712;
          prmH00712 = new Object[] {
          new ParDef("AV9DateTime",GXType.DateTime,8,5) ,
          new ParDef("AV5Codigo",GXType.VarChar,40,0) ,
          new ParDef("AV6AssinaturaParticipanteId",GXType.Int32,9,0)
          };
          Object[] prmH00713;
          prmH00713 = new Object[] {
          new ParDef("AV6AssinaturaParticipanteId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00712", "SELECT AssinaturaParticipanteTokenContent, AssinaturaParticipanteTokenUsed, AssinaturaParticipanteTokenExpire, AssinaturaParticipanteId, AssinaturaParticipanteTokenId FROM AssinaturaParticipanteToken WHERE (AssinaturaParticipanteTokenExpire > :AV9DateTime) AND (Not AssinaturaParticipanteTokenUsed) AND (AssinaturaParticipanteTokenContent = ( RTRIM(LTRIM(:AV5Codigo)))) AND (AssinaturaParticipanteId = :AV6AssinaturaParticipanteId) ORDER BY AssinaturaParticipanteTokenId DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00712,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00713", "SELECT T1.ParticipanteId, T1.AssinaturaParticipanteId, T2.ParticipanteNome, T1.AssinaturaParticipanteEmail FROM (AssinaturaParticipante T1 LEFT JOIN Participante T2 ON T2.ParticipanteId = T1.ParticipanteId) WHERE T1.AssinaturaParticipanteId = :AV6AssinaturaParticipanteId ORDER BY T1.AssinaturaParticipanteId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00713,1, GxCacheFrequency.OFF ,true,true )
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
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
       }
    }

 }

}
