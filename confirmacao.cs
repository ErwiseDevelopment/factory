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
   public class confirmacao : GXDataArea
   {
      public confirmacao( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public confirmacao( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Parametro )
      {
         this.AV22Parametro = aP0_Parametro;
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
            gxfirstwebparm = GetFirstPar( "Parametro");
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
               gxfirstwebparm = GetFirstPar( "Parametro");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "Parametro");
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
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV22Parametro = gxfirstwebparm;
               AssignAttri("", false, "AV22Parametro", AV22Parametro);
               GxWebStd.gx_hidden_field( context, "gxhash_vPARAMETRO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV22Parametro, "")), context));
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
         PA6S2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START6S2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("confirmacao", new object[] {UrlEncode(StringUtil.RTrim(AV22Parametro))}, new string[] {"Parametro"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vASSINATURAPARTICIPANTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5AssinaturaParticipanteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vASSINATURAPARTICIPANTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5AssinaturaParticipanteId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPARAMETRO", AV22Parametro);
         GxWebStd.gx_hidden_field( context, "gxhash_vPARAMETRO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV22Parametro, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "PARTICIPANTEDOCUMENTO_F", A1006ParticipanteDocumento_F);
         GxWebStd.gx_hidden_field( context, "PARTICIPANTEEMAIL_F", A1005ParticipanteEmail_F);
         GxWebStd.gx_hidden_field( context, "ASSINATURAPARTICIPANTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A242AssinaturaParticipanteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vASSINATURAPARTICIPANTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5AssinaturaParticipanteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vASSINATURAPARTICIPANTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5AssinaturaParticipanteId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vCODIGO", AV8Codigo);
         GxWebStd.gx_hidden_field( context, "PARTICIPANTENOME", A248ParticipanteNome);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vARRAY_EMAIL", AV12Array_Email);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vARRAY_EMAIL", AV12Array_Email);
         }
         GxWebStd.gx_hidden_field( context, "vMESSAGE", AV14message);
         GxWebStd.gx_hidden_field( context, "vPARAMETRO", AV22Parametro);
         GxWebStd.gx_hidden_field( context, "gxhash_vPARAMETRO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV22Parametro, "")), context));
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
            WE6S2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT6S2( ) ;
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
         return formatLink("confirmacao", new object[] {UrlEncode(StringUtil.RTrim(AV22Parametro))}, new string[] {"Parametro"})  ;
      }

      public override string GetPgmname( )
      {
         return "Confirmacao" ;
      }

      public override string GetPgmdesc( )
      {
         return "Confirmação" ;
      }

      protected void WB6S0( )
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
            GxWebStd.gx_div_start( context, divTablelogin_Internalname, 1, 0, "px", 0, "px", "TableLogin2Cols", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTxt_Internalname, "<h3>Confirmação</h3>", "", "", lblTxt_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_Confirmacao.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavAssinaturaparticipanteemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAssinaturaparticipanteemail_Internalname, "E-mail", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAssinaturaparticipanteemail_Internalname, AV6AssinaturaParticipanteEmail, StringUtil.RTrim( context.localUtil.Format( AV6AssinaturaParticipanteEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,18);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAssinaturaparticipanteemail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavAssinaturaparticipanteemail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_Confirmacao.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavAssinaturaparticipantecpf_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAssinaturaparticipantecpf_Internalname, "CPF", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAssinaturaparticipantecpf_Internalname, AV7AssinaturaParticipanteCPF, StringUtil.RTrim( context.localUtil.Format( AV7AssinaturaParticipanteCPF, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,23);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAssinaturaparticipantecpf_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavAssinaturaparticipantecpf_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Confirmacao.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", "Confirmar", bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Confirmacao.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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

      protected void START6S2( )
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
         Form.Meta.addItem("description", "Confirmação", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP6S0( ) ;
      }

      protected void WS6S2( )
      {
         START6S2( ) ;
         EVT6S2( ) ;
      }

      protected void EVT6S2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E116S2 ();
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
                                    E126S2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E136S2 ();
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

      protected void WE6S2( )
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

      protected void PA6S2( )
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
               GX_FocusControl = edtavAssinaturaparticipanteemail_Internalname;
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
         RF6S2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF6S2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E136S2 ();
            WB6S0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes6S2( )
      {
         GxWebStd.gx_hidden_field( context, "vASSINATURAPARTICIPANTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5AssinaturaParticipanteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vASSINATURAPARTICIPANTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5AssinaturaParticipanteId), "ZZZZZZZZ9"), context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP6S0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E116S2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            AV6AssinaturaParticipanteEmail = cgiGet( edtavAssinaturaparticipanteemail_Internalname);
            AssignAttri("", false, "AV6AssinaturaParticipanteEmail", AV6AssinaturaParticipanteEmail);
            AV7AssinaturaParticipanteCPF = cgiGet( edtavAssinaturaparticipantecpf_Internalname);
            AssignAttri("", false, "AV7AssinaturaParticipanteCPF", AV7AssinaturaParticipanteCPF);
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
         E116S2 ();
         if (returnInSub) return;
      }

      protected void E116S2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_char1 = AV23Chave;
         new prchave(context ).execute( out  GXt_char1) ;
         AV23Chave = GXt_char1;
         AV22Parametro = StringUtil.StringReplace( AV22Parametro, " ", "+");
         AssignAttri("", false, "AV22Parametro", AV22Parametro);
         GxWebStd.gx_hidden_field( context, "gxhash_vPARAMETRO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV22Parametro, "")), context));
         AV24AuxParametro = Decrypt64( AV22Parametro, AV23Chave);
         AV5AssinaturaParticipanteId = (int)(Math.Round(NumberUtil.Val( AV24AuxParametro, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV5AssinaturaParticipanteId", StringUtil.LTrimStr( (decimal)(AV5AssinaturaParticipanteId), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vASSINATURAPARTICIPANTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5AssinaturaParticipanteId), "ZZZZZZZZ9"), context));
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E126S2 ();
         if (returnInSub) return;
      }

      protected void E126S2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV26GXLvl22 = 0;
         /* Using cursor H006S2 */
         pr_default.execute(0, new Object[] {AV5AssinaturaParticipanteId, AV6AssinaturaParticipanteEmail, AV7AssinaturaParticipanteCPF});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A233ParticipanteId = H006S2_A233ParticipanteId[0];
            n233ParticipanteId = H006S2_n233ParticipanteId[0];
            A242AssinaturaParticipanteId = H006S2_A242AssinaturaParticipanteId[0];
            A1005ParticipanteEmail_F = H006S2_A1005ParticipanteEmail_F[0];
            A1006ParticipanteDocumento_F = H006S2_A1006ParticipanteDocumento_F[0];
            A248ParticipanteNome = H006S2_A248ParticipanteNome[0];
            n248ParticipanteNome = H006S2_n248ParticipanteNome[0];
            A1001ParticipanteTipoPessoa = H006S2_A1001ParticipanteTipoPessoa[0];
            n1001ParticipanteTipoPessoa = H006S2_n1001ParticipanteTipoPessoa[0];
            A1003ParticipanteRepresentanteEmail = H006S2_A1003ParticipanteRepresentanteEmail[0];
            n1003ParticipanteRepresentanteEmail = H006S2_n1003ParticipanteRepresentanteEmail[0];
            A235ParticipanteEmail = H006S2_A235ParticipanteEmail[0];
            n235ParticipanteEmail = H006S2_n235ParticipanteEmail[0];
            A1004ParticipanteRepresentanteDocumento = H006S2_A1004ParticipanteRepresentanteDocumento[0];
            n1004ParticipanteRepresentanteDocumento = H006S2_n1004ParticipanteRepresentanteDocumento[0];
            A234ParticipanteDocumento = H006S2_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = H006S2_n234ParticipanteDocumento[0];
            A1005ParticipanteEmail_F = H006S2_A1005ParticipanteEmail_F[0];
            A1006ParticipanteDocumento_F = H006S2_A1006ParticipanteDocumento_F[0];
            A248ParticipanteNome = H006S2_A248ParticipanteNome[0];
            n248ParticipanteNome = H006S2_n248ParticipanteNome[0];
            A1001ParticipanteTipoPessoa = H006S2_A1001ParticipanteTipoPessoa[0];
            n1001ParticipanteTipoPessoa = H006S2_n1001ParticipanteTipoPessoa[0];
            A1003ParticipanteRepresentanteEmail = H006S2_A1003ParticipanteRepresentanteEmail[0];
            n1003ParticipanteRepresentanteEmail = H006S2_n1003ParticipanteRepresentanteEmail[0];
            A235ParticipanteEmail = H006S2_A235ParticipanteEmail[0];
            n235ParticipanteEmail = H006S2_n235ParticipanteEmail[0];
            A1004ParticipanteRepresentanteDocumento = H006S2_A1004ParticipanteRepresentanteDocumento[0];
            n1004ParticipanteRepresentanteDocumento = H006S2_n1004ParticipanteRepresentanteDocumento[0];
            A234ParticipanteDocumento = H006S2_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = H006S2_n234ParticipanteDocumento[0];
            AV26GXLvl22 = 1;
            AV15i = 0;
            while ( AV15i < 4 )
            {
               AV16SesNro = (decimal)(NumberUtil.Random( ));
               AV16SesNro = (decimal)(AV16SesNro*10);
               AV18Numero = (short)(Math.Round(AV16SesNro, 18, MidpointRounding.ToEven));
               AV8Codigo = StringUtil.Format( "%1%2", AV8Codigo, StringUtil.LTrimStr( (decimal)(AV18Numero), 4, 0), "", "", "", "", "", "", "");
               AssignAttri("", false, "AV8Codigo", AV8Codigo);
               AV15i = (short)(AV15i+1);
            }
            AV8Codigo = StringUtil.Substring( AV8Codigo, 1, 4);
            AssignAttri("", false, "AV8Codigo", AV8Codigo);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8Codigo)) )
            {
               AV10DateTime = DateTimeUtil.ServerNow( context, pr_default);
               AV10DateTime = DateTimeUtil.TAdd( AV10DateTime, 60*(30));
               AV9AssinaturaParticipanteToken = new SdtAssinaturaParticipanteToken(context);
               AV9AssinaturaParticipanteToken.gxTpr_Assinaturaparticipantetokenexpire = AV10DateTime;
               AV9AssinaturaParticipanteToken.gxTpr_Assinaturaparticipanteid = AV5AssinaturaParticipanteId;
               AV9AssinaturaParticipanteToken.gxTpr_Assinaturaparticipantetokencontent = AV8Codigo;
               AV9AssinaturaParticipanteToken.Save();
               if ( AV9AssinaturaParticipanteToken.Success() )
               {
                  context.CommitDataStores("confirmacao",pr_default);
               }
               else
               {
                  context.RollbackDataStores("confirmacao",pr_default);
                  GXt_char1 = "Ocorreu um erro ao gerar seu código, por favor entre em contato!";
                  new message(context ).gxep_regular( ref  GXt_char1) ;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               new premailotpsignature(context ).execute(  A248ParticipanteNome,  StringUtil.Trim( AV8Codigo), out  AV11HTML) ;
               AV13Email = AV6AssinaturaParticipanteEmail;
               AV12Array_Email.Add(AV13Email, 0);
               new sendemail(context).executeSubmit(  "Código para assinatura",  AV11HTML,  AV12Array_Email, out  AV14message) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               GXEncryptionTmp = "codigo"+UrlEncode(StringUtil.LTrimStr(AV5AssinaturaParticipanteId,9,0));
               CallWebObject(formatLink("codigo") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
               context.wjLocDisableFrm = 1;
            }
            else
            {
               GXt_char1 = "Ocorreu um erro ao gerar seu código, por favor entre em contato!";
               new message(context ).gxep_regular( ref  GXt_char1) ;
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV26GXLvl22 == 0 )
         {
            GXt_char1 = "E-mail ou CPF incorretos, verifique!";
            new message(context ).gxep_regular( ref  GXt_char1) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV12Array_Email", AV12Array_Email);
      }

      protected void nextLoad( )
      {
      }

      protected void E136S2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV22Parametro = (string)getParm(obj,0);
         AssignAttri("", false, "AV22Parametro", AV22Parametro);
         GxWebStd.gx_hidden_field( context, "gxhash_vPARAMETRO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV22Parametro, "")), context));
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
         PA6S2( ) ;
         WS6S2( ) ;
         WE6S2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019261640", true, true);
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
         context.AddJavascriptSource("confirmacao.js", "?202561019261640", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTxt_Internalname = "TXT";
         edtavAssinaturaparticipanteemail_Internalname = "vASSINATURAPARTICIPANTEEMAIL";
         edtavAssinaturaparticipantecpf_Internalname = "vASSINATURAPARTICIPANTECPF";
         bttBtnenter_Internalname = "BTNENTER";
         divTablelogin_Internalname = "TABLELOGIN";
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
         edtavAssinaturaparticipantecpf_Jsonclick = "";
         edtavAssinaturaparticipantecpf_Enabled = 1;
         edtavAssinaturaparticipanteemail_Jsonclick = "";
         edtavAssinaturaparticipanteemail_Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Confirmação";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV5AssinaturaParticipanteId","fld":"vASSINATURAPARTICIPANTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV22Parametro","fld":"vPARAMETRO","hsh":true,"type":"svchar"}]}""");
         setEventMetadata("ENTER","""{"handler":"E126S2","iparms":[{"av":"A1006ParticipanteDocumento_F","fld":"PARTICIPANTEDOCUMENTO_F","type":"svchar"},{"av":"AV7AssinaturaParticipanteCPF","fld":"vASSINATURAPARTICIPANTECPF","type":"svchar"},{"av":"A1005ParticipanteEmail_F","fld":"PARTICIPANTEEMAIL_F","type":"svchar"},{"av":"AV6AssinaturaParticipanteEmail","fld":"vASSINATURAPARTICIPANTEEMAIL","type":"svchar"},{"av":"A242AssinaturaParticipanteId","fld":"ASSINATURAPARTICIPANTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV5AssinaturaParticipanteId","fld":"vASSINATURAPARTICIPANTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV8Codigo","fld":"vCODIGO","type":"svchar"},{"av":"A248ParticipanteNome","fld":"PARTICIPANTENOME","type":"svchar"},{"av":"AV12Array_Email","fld":"vARRAY_EMAIL","type":""},{"av":"AV14message","fld":"vMESSAGE","type":"svchar"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV8Codigo","fld":"vCODIGO","type":"svchar"},{"av":"AV12Array_Email","fld":"vARRAY_EMAIL","type":""},{"av":"AV14message","fld":"vMESSAGE","type":"svchar"}]}""");
         setEventMetadata("VALIDV_ASSINATURAPARTICIPANTEEMAIL","""{"handler":"Validv_Assinaturaparticipanteemail","iparms":[]}""");
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
         wcpOAV22Parametro = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         A1006ParticipanteDocumento_F = "";
         A1005ParticipanteEmail_F = "";
         AV8Codigo = "";
         A248ParticipanteNome = "";
         AV12Array_Email = new GxSimpleCollection<string>();
         AV14message = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         lblTxt_Jsonclick = "";
         TempTags = "";
         AV6AssinaturaParticipanteEmail = "";
         AV7AssinaturaParticipanteCPF = "";
         bttBtnenter_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV23Chave = "";
         AV24AuxParametro = "";
         H006S2_A233ParticipanteId = new int[1] ;
         H006S2_n233ParticipanteId = new bool[] {false} ;
         H006S2_A242AssinaturaParticipanteId = new int[1] ;
         H006S2_A1005ParticipanteEmail_F = new string[] {""} ;
         H006S2_A1006ParticipanteDocumento_F = new string[] {""} ;
         H006S2_A248ParticipanteNome = new string[] {""} ;
         H006S2_n248ParticipanteNome = new bool[] {false} ;
         H006S2_A1001ParticipanteTipoPessoa = new string[] {""} ;
         H006S2_n1001ParticipanteTipoPessoa = new bool[] {false} ;
         H006S2_A1003ParticipanteRepresentanteEmail = new string[] {""} ;
         H006S2_n1003ParticipanteRepresentanteEmail = new bool[] {false} ;
         H006S2_A235ParticipanteEmail = new string[] {""} ;
         H006S2_n235ParticipanteEmail = new bool[] {false} ;
         H006S2_A1004ParticipanteRepresentanteDocumento = new string[] {""} ;
         H006S2_n1004ParticipanteRepresentanteDocumento = new bool[] {false} ;
         H006S2_A234ParticipanteDocumento = new string[] {""} ;
         H006S2_n234ParticipanteDocumento = new bool[] {false} ;
         A1001ParticipanteTipoPessoa = "";
         A1003ParticipanteRepresentanteEmail = "";
         A235ParticipanteEmail = "";
         A1004ParticipanteRepresentanteDocumento = "";
         A234ParticipanteDocumento = "";
         AV10DateTime = (DateTime)(DateTime.MinValue);
         AV9AssinaturaParticipanteToken = new SdtAssinaturaParticipanteToken(context);
         AV11HTML = "";
         AV13Email = "";
         GXEncryptionTmp = "";
         GXt_char1 = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.confirmacao__default(),
            new Object[][] {
                new Object[] {
               H006S2_A233ParticipanteId, H006S2_n233ParticipanteId, H006S2_A242AssinaturaParticipanteId, H006S2_A1005ParticipanteEmail_F, H006S2_A1006ParticipanteDocumento_F, H006S2_A248ParticipanteNome, H006S2_n248ParticipanteNome, H006S2_A1001ParticipanteTipoPessoa, H006S2_n1001ParticipanteTipoPessoa, H006S2_A1003ParticipanteRepresentanteEmail,
               H006S2_n1003ParticipanteRepresentanteEmail, H006S2_A235ParticipanteEmail, H006S2_n235ParticipanteEmail, H006S2_A1004ParticipanteRepresentanteDocumento, H006S2_n1004ParticipanteRepresentanteDocumento, H006S2_A234ParticipanteDocumento, H006S2_n234ParticipanteDocumento
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV26GXLvl22 ;
      private short AV15i ;
      private short AV18Numero ;
      private short nGXWrapped ;
      private int AV5AssinaturaParticipanteId ;
      private int A242AssinaturaParticipanteId ;
      private int edtavAssinaturaparticipanteemail_Enabled ;
      private int edtavAssinaturaparticipantecpf_Enabled ;
      private int A233ParticipanteId ;
      private int idxLst ;
      private decimal AV16SesNro ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablelogin_Internalname ;
      private string lblTxt_Internalname ;
      private string lblTxt_Jsonclick ;
      private string edtavAssinaturaparticipanteemail_Internalname ;
      private string TempTags ;
      private string edtavAssinaturaparticipanteemail_Jsonclick ;
      private string edtavAssinaturaparticipantecpf_Internalname ;
      private string edtavAssinaturaparticipantecpf_Jsonclick ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXEncryptionTmp ;
      private string GXt_char1 ;
      private DateTime AV10DateTime ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n233ParticipanteId ;
      private bool n248ParticipanteNome ;
      private bool n1001ParticipanteTipoPessoa ;
      private bool n1003ParticipanteRepresentanteEmail ;
      private bool n235ParticipanteEmail ;
      private bool n1004ParticipanteRepresentanteDocumento ;
      private bool n234ParticipanteDocumento ;
      private string AV11HTML ;
      private string AV22Parametro ;
      private string wcpOAV22Parametro ;
      private string A1006ParticipanteDocumento_F ;
      private string A1005ParticipanteEmail_F ;
      private string AV8Codigo ;
      private string A248ParticipanteNome ;
      private string AV14message ;
      private string AV6AssinaturaParticipanteEmail ;
      private string AV7AssinaturaParticipanteCPF ;
      private string AV23Chave ;
      private string AV24AuxParametro ;
      private string A1001ParticipanteTipoPessoa ;
      private string A1003ParticipanteRepresentanteEmail ;
      private string A235ParticipanteEmail ;
      private string A1004ParticipanteRepresentanteDocumento ;
      private string A234ParticipanteDocumento ;
      private string AV13Email ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV12Array_Email ;
      private IDataStoreProvider pr_default ;
      private int[] H006S2_A233ParticipanteId ;
      private bool[] H006S2_n233ParticipanteId ;
      private int[] H006S2_A242AssinaturaParticipanteId ;
      private string[] H006S2_A1005ParticipanteEmail_F ;
      private string[] H006S2_A1006ParticipanteDocumento_F ;
      private string[] H006S2_A248ParticipanteNome ;
      private bool[] H006S2_n248ParticipanteNome ;
      private string[] H006S2_A1001ParticipanteTipoPessoa ;
      private bool[] H006S2_n1001ParticipanteTipoPessoa ;
      private string[] H006S2_A1003ParticipanteRepresentanteEmail ;
      private bool[] H006S2_n1003ParticipanteRepresentanteEmail ;
      private string[] H006S2_A235ParticipanteEmail ;
      private bool[] H006S2_n235ParticipanteEmail ;
      private string[] H006S2_A1004ParticipanteRepresentanteDocumento ;
      private bool[] H006S2_n1004ParticipanteRepresentanteDocumento ;
      private string[] H006S2_A234ParticipanteDocumento ;
      private bool[] H006S2_n234ParticipanteDocumento ;
      private SdtAssinaturaParticipanteToken AV9AssinaturaParticipanteToken ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class confirmacao__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmH006S2;
          prmH006S2 = new Object[] {
          new ParDef("AV5AssinaturaParticipanteId",GXType.Int32,9,0) ,
          new ParDef("AV6AssinaturaParticipanteEmail",GXType.VarChar,100,0) ,
          new ParDef("AV7AssinaturaParticipanteCPF",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("H006S2", "SELECT T1.ParticipanteId, T1.AssinaturaParticipanteId, CASE  WHEN COALESCE( T2.ParticipanteTipoPessoa, '') = ( 'JURIDICA') THEN COALESCE( T2.ParticipanteRepresentanteEmail, '') ELSE COALESCE( T2.ParticipanteEmail, '') END AS ParticipanteEmail_F, CASE  WHEN COALESCE( T2.ParticipanteTipoPessoa, '') = ( 'JURIDICA') THEN COALESCE( T2.ParticipanteRepresentanteDocumento, '') ELSE COALESCE( T2.ParticipanteDocumento, '') END AS ParticipanteDocumento_F, T2.ParticipanteNome, T2.ParticipanteTipoPessoa, T2.ParticipanteRepresentanteEmail, T2.ParticipanteEmail, T2.ParticipanteRepresentanteDocumento, T2.ParticipanteDocumento FROM (AssinaturaParticipante T1 LEFT JOIN Participante T2 ON T2.ParticipanteId = T1.ParticipanteId) WHERE (T1.AssinaturaParticipanteId = :AV5AssinaturaParticipanteId) AND (UPPER(CASE  WHEN COALESCE( T2.ParticipanteTipoPessoa, '') = ( 'JURIDICA') THEN COALESCE( T2.ParticipanteRepresentanteEmail, '') ELSE COALESCE( T2.ParticipanteEmail, '') END) = ( UPPER(:AV6AssinaturaParticipanteEmail))) AND (CASE  WHEN COALESCE( T2.ParticipanteTipoPessoa, '') = ( 'JURIDICA') THEN COALESCE( T2.ParticipanteRepresentanteDocumento, '') ELSE COALESCE( T2.ParticipanteDocumento, '') END = ( :AV7AssinaturaParticipanteCPF)) ORDER BY T1.AssinaturaParticipanteId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006S2,1, GxCacheFrequency.OFF ,true,true )
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
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((string[]) buf[9])[0] = rslt.getVarchar(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((string[]) buf[11])[0] = rslt.getVarchar(8);
                ((bool[]) buf[12])[0] = rslt.wasNull(8);
                ((string[]) buf[13])[0] = rslt.getVarchar(9);
                ((bool[]) buf[14])[0] = rslt.wasNull(9);
                ((string[]) buf[15])[0] = rslt.getVarchar(10);
                ((bool[]) buf[16])[0] = rslt.wasNull(10);
                return;
       }
    }

 }

}
