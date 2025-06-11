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
   public class wpalterarsaldo : GXDataArea
   {
      public wpalterarsaldo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpalterarsaldo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_ContaId )
      {
         this.AV7ContaId = aP0_ContaId;
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
            gxfirstwebparm = GetFirstPar( "ContaId");
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
               gxfirstwebparm = GetFirstPar( "ContaId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "ContaId");
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
         PA672( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START672( ) ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpalterarsaldo"+UrlEncode(StringUtil.LTrimStr(AV7ContaId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpalterarsaldo") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vATUALCONTASALDOATUAL", StringUtil.LTrim( StringUtil.NToC( AV9AtualContaSaldoAtual, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vATUALCONTASALDOATUAL", GetSecureSignedToken( "", context.localUtil.Format( AV9AtualContaSaldoAtual, "ZZZZZZZZZZZZZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "vCONTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ContaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCONTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ContaId), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vATUALCONTASALDOATUAL", StringUtil.LTrim( StringUtil.NToC( AV9AtualContaSaldoAtual, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vATUALCONTASALDOATUAL", GetSecureSignedToken( "", context.localUtil.Format( AV9AtualContaSaldoAtual, "ZZZZZZZZZZZZZZ9.99"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCONTA", AV8Conta);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCONTA", AV8Conta);
         }
         GxWebStd.gx_hidden_field( context, "vTITULOMOVIMENTOVALOR", StringUtil.LTrim( StringUtil.NToC( AV11TituloMovimentoValor, 18, 2, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTITULOMOVIMENTO", AV10SdTituloMovimento);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTITULOMOVIMENTO", AV10SdTituloMovimento);
         }
         GxWebStd.gx_hidden_field( context, "vTITULOMOVIMENTOOPE", AV12TituloMovimentoOpe);
         GxWebStd.gx_hidden_field( context, "vCONTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ContaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCONTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ContaId), "ZZZZZZZZ9"), context));
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
            WE672( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT672( ) ;
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
         GXEncryptionTmp = "wpalterarsaldo"+UrlEncode(StringUtil.LTrimStr(AV7ContaId,9,0));
         return formatLink("wpalterarsaldo") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WpAlterarSaldo" ;
      }

      public override string GetPgmdesc( )
      {
         return "Alterar saldo" ;
      }

      protected void WB670( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 15,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", "Confirmar", bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpAlterarSaldo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavContanomeconta_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContanomeconta_Internalname, "Conta", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContanomeconta_Internalname, AV5ContaNomeConta, StringUtil.RTrim( context.localUtil.Format( AV5ContaNomeConta, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContanomeconta_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavContanomeconta_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpAlterarSaldo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavContasaldoatual_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContasaldoatual_Internalname, "Saldo", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContasaldoatual_Internalname, StringUtil.LTrim( StringUtil.NToC( AV6ContaSaldoAtual, 18, 2, ",", "")), StringUtil.LTrim( ((edtavContasaldoatual_Enabled!=0) ? context.localUtil.Format( AV6ContaSaldoAtual, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV6ContaSaldoAtual, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContasaldoatual_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavContasaldoatual_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpAlterarSaldo.htm");
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
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START672( )
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
         Form.Meta.addItem("description", "Alterar saldo", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP670( ) ;
      }

      protected void WS672( )
      {
         START672( ) ;
         EVT672( ) ;
      }

      protected void EVT672( )
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
                              E11672 ();
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
                                    E12672 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E13672 ();
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

      protected void WE672( )
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

      protected void PA672( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpalterarsaldo")), "wpalterarsaldo") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpalterarsaldo")))) ;
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
                  gxfirstwebparm = GetFirstPar( "ContaId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV7ContaId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV7ContaId", StringUtil.LTrimStr( (decimal)(AV7ContaId), 9, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vCONTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ContaId), "ZZZZZZZZ9"), context));
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
               GX_FocusControl = edtavContanomeconta_Internalname;
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
         RF672( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavContanomeconta_Enabled = 0;
         AssignProp("", false, edtavContanomeconta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavContanomeconta_Enabled), 5, 0), true);
      }

      protected void RF672( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E13672 ();
            WB670( ) ;
         }
      }

      protected void send_integrity_lvl_hashes672( )
      {
         GxWebStd.gx_hidden_field( context, "vATUALCONTASALDOATUAL", StringUtil.LTrim( StringUtil.NToC( AV9AtualContaSaldoAtual, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vATUALCONTASALDOATUAL", GetSecureSignedToken( "", context.localUtil.Format( AV9AtualContaSaldoAtual, "ZZZZZZZZZZZZZZ9.99"), context));
      }

      protected void before_start_formulas( )
      {
         edtavContanomeconta_Enabled = 0;
         AssignProp("", false, edtavContanomeconta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavContanomeconta_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP670( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11672 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            AV5ContaNomeConta = cgiGet( edtavContanomeconta_Internalname);
            AssignAttri("", false, "AV5ContaNomeConta", AV5ContaNomeConta);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavContasaldoatual_Internalname), ",", ".") < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavContasaldoatual_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCONTASALDOATUAL");
               GX_FocusControl = edtavContasaldoatual_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6ContaSaldoAtual = 0;
               AssignAttri("", false, "AV6ContaSaldoAtual", StringUtil.LTrimStr( AV6ContaSaldoAtual, 18, 2));
            }
            else
            {
               AV6ContaSaldoAtual = context.localUtil.CToN( cgiGet( edtavContasaldoatual_Internalname), ",", ".");
               AssignAttri("", false, "AV6ContaSaldoAtual", StringUtil.LTrimStr( AV6ContaSaldoAtual, 18, 2));
            }
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
         E11672 ();
         if (returnInSub) return;
      }

      protected void E11672( )
      {
         /* Start Routine */
         returnInSub = false;
         AV8Conta.Load(AV7ContaId);
         AV6ContaSaldoAtual = AV8Conta.gxTpr_Contasaldoatual;
         AssignAttri("", false, "AV6ContaSaldoAtual", StringUtil.LTrimStr( AV6ContaSaldoAtual, 18, 2));
         AV9AtualContaSaldoAtual = AV8Conta.gxTpr_Contasaldoatual;
         AssignAttri("", false, "AV9AtualContaSaldoAtual", StringUtil.LTrimStr( AV9AtualContaSaldoAtual, 18, 2));
         GxWebStd.gx_hidden_field( context, "gxhash_vATUALCONTASALDOATUAL", GetSecureSignedToken( "", context.localUtil.Format( AV9AtualContaSaldoAtual, "ZZZZZZZZZZZZZZ9.99"), context));
         AV5ContaNomeConta = AV8Conta.gxTpr_Contanomeconta;
         AssignAttri("", false, "AV5ContaNomeConta", AV5ContaNomeConta);
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E12672 ();
         if (returnInSub) return;
      }

      protected void E12672( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( AV6ContaSaldoAtual > AV9AtualContaSaldoAtual )
         {
            AV11TituloMovimentoValor = (decimal)(AV6ContaSaldoAtual-AV9AtualContaSaldoAtual);
            AssignAttri("", false, "AV11TituloMovimentoValor", StringUtil.LTrimStr( AV11TituloMovimentoValor, 18, 2));
            AV12TituloMovimentoOpe = "Entrada";
            AssignAttri("", false, "AV12TituloMovimentoOpe", AV12TituloMovimentoOpe);
            /* Execute user subroutine: 'MOVIMENTO' */
            S112 ();
            if (returnInSub) return;
         }
         else
         {
            AV11TituloMovimentoValor = (decimal)(AV9AtualContaSaldoAtual-AV6ContaSaldoAtual);
            AssignAttri("", false, "AV11TituloMovimentoValor", StringUtil.LTrimStr( AV11TituloMovimentoValor, 18, 2));
            AV12TituloMovimentoOpe = "Saida";
            AssignAttri("", false, "AV12TituloMovimentoOpe", AV12TituloMovimentoOpe);
            /* Execute user subroutine: 'MOVIMENTO' */
            S112 ();
            if (returnInSub) return;
         }
         AV8Conta.gxTpr_Contasaldoatual = AV6ContaSaldoAtual;
         AV8Conta.Save();
         if ( AV8Conta.Success() )
         {
            context.CommitDataStores("wpalterarsaldo",pr_default);
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV8Conta", AV8Conta);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10SdTituloMovimento", AV10SdTituloMovimento);
      }

      protected void S112( )
      {
         /* 'MOVIMENTO' Routine */
         returnInSub = false;
         AV10SdTituloMovimento.gxTpr_Titulomovimentovalor = AV11TituloMovimentoValor;
         AV10SdTituloMovimento.gxTpr_Titulomovimentotipo = "Baixa";
         AV10SdTituloMovimento.gxTpr_Titulomovimentodatacredito = DateTimeUtil.ServerDate( context, pr_default);
         AV10SdTituloMovimento.gxTpr_Titulomovimentocreatedat = DateTimeUtil.ServerNow( context, pr_default);
         AV10SdTituloMovimento.gxTpr_Titulomovimentoupdatedat = DateTimeUtil.ServerNow( context, pr_default);
         AV10SdTituloMovimento.gxTpr_Titulomovimentoope = AV12TituloMovimentoOpe;
         AV10SdTituloMovimento.gxTpr_Titulomovimentoconta = AV7ContaId;
         GXt_SdtSdErro1 = new SdtSdErro();
         new prcriartitulomovimento(context ).execute(  AV10SdTituloMovimento, out  GXt_SdtSdErro1) ;
      }

      protected void nextLoad( )
      {
      }

      protected void E13672( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV7ContaId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV7ContaId", StringUtil.LTrimStr( (decimal)(AV7ContaId), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vCONTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ContaId), "ZZZZZZZZ9"), context));
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
         PA672( ) ;
         WS672( ) ;
         WE672( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019255486", true, true);
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
         context.AddJavascriptSource("wpalterarsaldo.js", "?202561019255486", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtnenter_Internalname = "BTNENTER";
         edtavContanomeconta_Internalname = "vCONTANOMECONTA";
         edtavContasaldoatual_Internalname = "vCONTASALDOATUAL";
         divTablecontent_Internalname = "TABLECONTENT";
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
         edtavContasaldoatual_Jsonclick = "";
         edtavContasaldoatual_Enabled = 1;
         edtavContanomeconta_Jsonclick = "";
         edtavContanomeconta_Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Alterar saldo";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV9AtualContaSaldoAtual","fld":"vATUALCONTASALDOATUAL","pic":"ZZZZZZZZZZZZZZ9.99","hsh":true,"type":"decimal"},{"av":"AV7ContaId","fld":"vCONTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("ENTER","""{"handler":"E12672","iparms":[{"av":"AV6ContaSaldoAtual","fld":"vCONTASALDOATUAL","pic":"ZZZZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV9AtualContaSaldoAtual","fld":"vATUALCONTASALDOATUAL","pic":"ZZZZZZZZZZZZZZ9.99","hsh":true,"type":"decimal"},{"av":"AV8Conta","fld":"vCONTA","type":""},{"av":"AV11TituloMovimentoValor","fld":"vTITULOMOVIMENTOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV10SdTituloMovimento","fld":"vSDTITULOMOVIMENTO","type":""},{"av":"AV12TituloMovimentoOpe","fld":"vTITULOMOVIMENTOOPE","type":"svchar"},{"av":"AV7ContaId","fld":"vCONTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV11TituloMovimentoValor","fld":"vTITULOMOVIMENTOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV12TituloMovimentoOpe","fld":"vTITULOMOVIMENTOOPE","type":"svchar"},{"av":"AV8Conta","fld":"vCONTA","type":""},{"av":"AV10SdTituloMovimento","fld":"vSDTITULOMOVIMENTO","type":""}]}""");
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
         AV8Conta = new SdtConta(context);
         AV10SdTituloMovimento = new SdtSdTituloMovimento(context);
         AV12TituloMovimentoOpe = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtnenter_Jsonclick = "";
         AV5ContaNomeConta = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         GXt_SdtSdErro1 = new SdtSdErro(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpalterarsaldo__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         edtavContanomeconta_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int AV7ContaId ;
      private int wcpOAV7ContaId ;
      private int edtavContanomeconta_Enabled ;
      private int edtavContasaldoatual_Enabled ;
      private int idxLst ;
      private decimal AV9AtualContaSaldoAtual ;
      private decimal AV11TituloMovimentoValor ;
      private decimal AV6ContaSaldoAtual ;
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
      private string TempTags ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string edtavContanomeconta_Internalname ;
      private string edtavContanomeconta_Jsonclick ;
      private string edtavContasaldoatual_Internalname ;
      private string edtavContasaldoatual_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV12TituloMovimentoOpe ;
      private string AV5ContaNomeConta ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private SdtConta AV8Conta ;
      private SdtSdTituloMovimento AV10SdTituloMovimento ;
      private IDataStoreProvider pr_default ;
      private SdtSdErro GXt_SdtSdErro1 ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpalterarsaldo__default : DataStoreHelperBase, IDataStoreHelper
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
