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
   public class operacao : GXDataArea
   {
      public operacao( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public operacao( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_OperacoesId ,
                           string aP1_TrnMode )
      {
         this.AV10OperacoesId = aP0_OperacoesId;
         this.AV12TrnMode = aP1_TrnMode;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavOperacoestipotarifa = new GXCombobox();
         cmbavOperacoesstatus = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "OperacoesId");
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
               gxfirstwebparm = GetFirstPar( "OperacoesId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "OperacoesId");
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
         PAA22( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTA22( ) ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "operacao"+UrlEncode(StringUtil.LTrimStr(AV10OperacoesId,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV12TrnMode));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("operacao") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vOPERACOESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10OperacoesId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTRNMODE", StringUtil.RTrim( AV12TrnMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV12TrnMode, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vTRNMODE", StringUtil.RTrim( AV12TrnMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV12TrnMode, "")), context));
         GxWebStd.gx_hidden_field( context, "DVPANEL_OPERACAO_Width", StringUtil.RTrim( Dvpanel_operacao_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_OPERACAO_Autowidth", StringUtil.BoolToStr( Dvpanel_operacao_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_OPERACAO_Autoheight", StringUtil.BoolToStr( Dvpanel_operacao_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_OPERACAO_Cls", StringUtil.RTrim( Dvpanel_operacao_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_OPERACAO_Title", StringUtil.RTrim( Dvpanel_operacao_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_OPERACAO_Collapsible", StringUtil.BoolToStr( Dvpanel_operacao_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_OPERACAO_Collapsed", StringUtil.BoolToStr( Dvpanel_operacao_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_OPERACAO_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_operacao_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_OPERACAO_Iconposition", StringUtil.RTrim( Dvpanel_operacao_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_OPERACAO_Autoscroll", StringUtil.BoolToStr( Dvpanel_operacao_Autoscroll));
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
         if ( ! ( WebComp_Wcoperacoestitulosww == null ) )
         {
            WebComp_Wcoperacoestitulosww.componentjscripts();
         }
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WEA22( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTA22( ) ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "operacao"+UrlEncode(StringUtil.LTrimStr(AV10OperacoesId,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV12TrnMode));
         return formatLink("operacao") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Operacao" ;
      }

      public override string GetPgmdesc( )
      {
         return "Operação" ;
      }

      protected void WBA20( )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Operacao.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_operacao.SetProperty("Width", Dvpanel_operacao_Width);
            ucDvpanel_operacao.SetProperty("AutoWidth", Dvpanel_operacao_Autowidth);
            ucDvpanel_operacao.SetProperty("AutoHeight", Dvpanel_operacao_Autoheight);
            ucDvpanel_operacao.SetProperty("Cls", Dvpanel_operacao_Cls);
            ucDvpanel_operacao.SetProperty("Title", Dvpanel_operacao_Title);
            ucDvpanel_operacao.SetProperty("Collapsible", Dvpanel_operacao_Collapsible);
            ucDvpanel_operacao.SetProperty("Collapsed", Dvpanel_operacao_Collapsed);
            ucDvpanel_operacao.SetProperty("ShowCollapseIcon", Dvpanel_operacao_Showcollapseicon);
            ucDvpanel_operacao.SetProperty("IconPosition", Dvpanel_operacao_Iconposition);
            ucDvpanel_operacao.SetProperty("AutoScroll", Dvpanel_operacao_Autoscroll);
            ucDvpanel_operacao.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_operacao_Internalname, "DVPANEL_OPERACAOContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_OPERACAOContainer"+"Operacao"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divOperacao_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavOperacoesid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOperacoesid_Internalname, "Identificador", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOperacoesid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10OperacoesId), 9, 0, ",", "")), StringUtil.LTrim( ((edtavOperacoesid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV10OperacoesId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV10OperacoesId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOperacoesid_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavOperacoesid_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Operacao.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavClienterazaosocial_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClienterazaosocial_Internalname, "Prestador", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClienterazaosocial_Internalname, AV5ClienteRazaoSocial, StringUtil.RTrim( context.localUtil.Format( AV5ClienteRazaoSocial, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClienterazaosocial_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavClienterazaosocial_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Operacao.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavOperacoesdata_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOperacoesdata_Internalname, "Data", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavOperacoesdata_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavOperacoesdata_Internalname, context.localUtil.Format(AV6OperacoesData, "99/99/99"), context.localUtil.Format( AV6OperacoesData, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOperacoesdata_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavOperacoesdata_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Operacao.htm");
            GxWebStd.gx_bitmap( context, edtavOperacoesdata_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavOperacoesdata_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Operacao.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavOperacoestaxaefetiva_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOperacoestaxaefetiva_Internalname, "Taxa Efetiva", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOperacoestaxaefetiva_Internalname, StringUtil.LTrim( StringUtil.NToC( AV7OperacoesTaxaEfetiva, 21, 4, ",", "")), StringUtil.LTrim( ((edtavOperacoestaxaefetiva_Enabled!=0) ? context.localUtil.Format( AV7OperacoesTaxaEfetiva, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%") : context.localUtil.Format( AV7OperacoesTaxaEfetiva, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOperacoestaxaefetiva_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavOperacoestaxaefetiva_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Operacao.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavOperacoestaxamora_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOperacoestaxamora_Internalname, "Taxa Mora", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOperacoestaxamora_Internalname, StringUtil.LTrim( StringUtil.NToC( AV8OperacoesTaxaMora, 21, 4, ",", "")), StringUtil.LTrim( ((edtavOperacoestaxamora_Enabled!=0) ? context.localUtil.Format( AV8OperacoesTaxaMora, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%") : context.localUtil.Format( AV8OperacoesTaxaMora, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOperacoestaxamora_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavOperacoestaxamora_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Operacao.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavOperacoesfator_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOperacoesfator_Internalname, "Fator", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOperacoesfator_Internalname, StringUtil.LTrim( StringUtil.NToC( AV13OperacoesFator, 21, 4, ",", "")), StringUtil.LTrim( ((edtavOperacoesfator_Enabled!=0) ? context.localUtil.Format( AV13OperacoesFator, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%") : context.localUtil.Format( AV13OperacoesFator, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOperacoesfator_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavOperacoesfator_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Operacao.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavOperacoestipotarifa_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavOperacoestipotarifa_Internalname, "Tipo da tarifa", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavOperacoestipotarifa, cmbavOperacoestipotarifa_Internalname, StringUtil.RTrim( AV14OperacoesTipoTarifa), 1, cmbavOperacoestipotarifa_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavOperacoestipotarifa.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "", true, 0, "HLP_Operacao.htm");
            cmbavOperacoestipotarifa.CurrentValue = StringUtil.RTrim( AV14OperacoesTipoTarifa);
            AssignProp("", false, cmbavOperacoestipotarifa_Internalname, "Values", (string)(cmbavOperacoestipotarifa.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavOperacoestarifa_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOperacoestarifa_Internalname, "Tarifa", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOperacoestarifa_Internalname, StringUtil.LTrim( StringUtil.NToC( AV15OperacoesTarifa, 15, 2, ",", "")), StringUtil.LTrim( ((edtavOperacoestarifa_Enabled!=0) ? context.localUtil.Format( AV15OperacoesTarifa, "ZZZZZZZZZZZ9.99") : context.localUtil.Format( AV15OperacoesTarifa, "ZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOperacoestarifa_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavOperacoestarifa_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Operacao.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavOperacoesstatus_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavOperacoesstatus_Internalname, "Status", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavOperacoesstatus, cmbavOperacoesstatus_Internalname, StringUtil.RTrim( AV9OperacoesStatus), 1, cmbavOperacoesstatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavOperacoesstatus.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "", true, 0, "HLP_Operacao.htm");
            cmbavOperacoesstatus.CurrentValue = StringUtil.RTrim( AV9OperacoesStatus);
            AssignProp("", false, cmbavOperacoesstatus_Internalname, "Values", (string)(cmbavOperacoesstatus.ToJavascriptSource()), true);
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
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0064"+"", StringUtil.RTrim( WebComp_Wcoperacoestitulosww_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0064"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcoperacoestitulosww_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcoperacoestitulosww), StringUtil.Lower( WebComp_Wcoperacoestitulosww_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0064"+"");
                  }
                  WebComp_Wcoperacoestitulosww.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcoperacoestitulosww), StringUtil.Lower( WebComp_Wcoperacoestitulosww_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
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

      protected void STARTA22( )
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
         Form.Meta.addItem("description", "Operação", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPA20( ) ;
      }

      protected void WSA22( )
      {
         STARTA22( ) ;
         EVTA22( ) ;
      }

      protected void EVTA22( )
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
                              E11A22 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E12A22 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
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
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                        }
                     }
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 64 )
                        {
                           OldWcoperacoestitulosww = cgiGet( "W0064");
                           if ( ( StringUtil.Len( OldWcoperacoestitulosww) == 0 ) || ( StringUtil.StrCmp(OldWcoperacoestitulosww, WebComp_Wcoperacoestitulosww_Component) != 0 ) )
                           {
                              WebComp_Wcoperacoestitulosww = getWebComponent(GetType(), "GeneXus.Programs", OldWcoperacoestitulosww, new Object[] {context} );
                              WebComp_Wcoperacoestitulosww.ComponentInit();
                              WebComp_Wcoperacoestitulosww.Name = "OldWcoperacoestitulosww";
                              WebComp_Wcoperacoestitulosww_Component = OldWcoperacoestitulosww;
                           }
                           if ( StringUtil.Len( WebComp_Wcoperacoestitulosww_Component) != 0 )
                           {
                              WebComp_Wcoperacoestitulosww.componentprocess("W0064", "", sEvt);
                           }
                           WebComp_Wcoperacoestitulosww_Component = OldWcoperacoestitulosww;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WEA22( )
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

      protected void PAA22( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "operacao")), "operacao") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "operacao")))) ;
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
                  gxfirstwebparm = GetFirstPar( "OperacoesId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV10OperacoesId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV10OperacoesId", StringUtil.LTrimStr( (decimal)(AV10OperacoesId), 9, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vOPERACOESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10OperacoesId), "ZZZZZZZZ9"), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV12TrnMode = GetPar( "TrnMode");
                        AssignAttri("", false, "AV12TrnMode", AV12TrnMode);
                        GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV12TrnMode, "")), context));
                     }
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
               GX_FocusControl = edtavClienterazaosocial_Internalname;
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
         if ( cmbavOperacoestipotarifa.ItemCount > 0 )
         {
            AV14OperacoesTipoTarifa = cmbavOperacoestipotarifa.getValidValue(AV14OperacoesTipoTarifa);
            AssignAttri("", false, "AV14OperacoesTipoTarifa", AV14OperacoesTipoTarifa);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavOperacoestipotarifa.CurrentValue = StringUtil.RTrim( AV14OperacoesTipoTarifa);
            AssignProp("", false, cmbavOperacoestipotarifa_Internalname, "Values", cmbavOperacoestipotarifa.ToJavascriptSource(), true);
         }
         if ( cmbavOperacoesstatus.ItemCount > 0 )
         {
            AV9OperacoesStatus = cmbavOperacoesstatus.getValidValue(AV9OperacoesStatus);
            AssignAttri("", false, "AV9OperacoesStatus", AV9OperacoesStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavOperacoesstatus.CurrentValue = StringUtil.RTrim( AV9OperacoesStatus);
            AssignProp("", false, cmbavOperacoesstatus_Internalname, "Values", cmbavOperacoesstatus.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFA22( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavOperacoesid_Enabled = 0;
         AssignProp("", false, edtavOperacoesid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOperacoesid_Enabled), 5, 0), true);
         edtavClienterazaosocial_Enabled = 0;
         AssignProp("", false, edtavClienterazaosocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClienterazaosocial_Enabled), 5, 0), true);
         edtavOperacoesdata_Enabled = 0;
         AssignProp("", false, edtavOperacoesdata_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOperacoesdata_Enabled), 5, 0), true);
         edtavOperacoestaxaefetiva_Enabled = 0;
         AssignProp("", false, edtavOperacoestaxaefetiva_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOperacoestaxaefetiva_Enabled), 5, 0), true);
         edtavOperacoestaxamora_Enabled = 0;
         AssignProp("", false, edtavOperacoestaxamora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOperacoestaxamora_Enabled), 5, 0), true);
         edtavOperacoesfator_Enabled = 0;
         AssignProp("", false, edtavOperacoesfator_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOperacoesfator_Enabled), 5, 0), true);
         cmbavOperacoestipotarifa.Enabled = 0;
         AssignProp("", false, cmbavOperacoestipotarifa_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavOperacoestipotarifa.Enabled), 5, 0), true);
         edtavOperacoestarifa_Enabled = 0;
         AssignProp("", false, edtavOperacoestarifa_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOperacoestarifa_Enabled), 5, 0), true);
         cmbavOperacoesstatus.Enabled = 0;
         AssignProp("", false, cmbavOperacoesstatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavOperacoesstatus.Enabled), 5, 0), true);
      }

      protected void RFA22( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcoperacoestitulosww_Component) != 0 )
               {
                  WebComp_Wcoperacoestitulosww.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E12A22 ();
            WBA20( ) ;
         }
      }

      protected void send_integrity_lvl_hashesA22( )
      {
      }

      protected void before_start_formulas( )
      {
         edtavOperacoesid_Enabled = 0;
         AssignProp("", false, edtavOperacoesid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOperacoesid_Enabled), 5, 0), true);
         edtavClienterazaosocial_Enabled = 0;
         AssignProp("", false, edtavClienterazaosocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClienterazaosocial_Enabled), 5, 0), true);
         edtavOperacoesdata_Enabled = 0;
         AssignProp("", false, edtavOperacoesdata_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOperacoesdata_Enabled), 5, 0), true);
         edtavOperacoestaxaefetiva_Enabled = 0;
         AssignProp("", false, edtavOperacoestaxaefetiva_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOperacoestaxaefetiva_Enabled), 5, 0), true);
         edtavOperacoestaxamora_Enabled = 0;
         AssignProp("", false, edtavOperacoestaxamora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOperacoestaxamora_Enabled), 5, 0), true);
         edtavOperacoesfator_Enabled = 0;
         AssignProp("", false, edtavOperacoesfator_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOperacoesfator_Enabled), 5, 0), true);
         cmbavOperacoestipotarifa.Enabled = 0;
         AssignProp("", false, cmbavOperacoestipotarifa_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavOperacoestipotarifa.Enabled), 5, 0), true);
         edtavOperacoestarifa_Enabled = 0;
         AssignProp("", false, edtavOperacoestarifa_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOperacoestarifa_Enabled), 5, 0), true);
         cmbavOperacoesstatus.Enabled = 0;
         AssignProp("", false, cmbavOperacoesstatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavOperacoesstatus.Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUPA20( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11A22 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Dvpanel_operacao_Width = cgiGet( "DVPANEL_OPERACAO_Width");
            Dvpanel_operacao_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_OPERACAO_Autowidth"));
            Dvpanel_operacao_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_OPERACAO_Autoheight"));
            Dvpanel_operacao_Cls = cgiGet( "DVPANEL_OPERACAO_Cls");
            Dvpanel_operacao_Title = cgiGet( "DVPANEL_OPERACAO_Title");
            Dvpanel_operacao_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_OPERACAO_Collapsible"));
            Dvpanel_operacao_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_OPERACAO_Collapsed"));
            Dvpanel_operacao_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_OPERACAO_Showcollapseicon"));
            Dvpanel_operacao_Iconposition = cgiGet( "DVPANEL_OPERACAO_Iconposition");
            Dvpanel_operacao_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_OPERACAO_Autoscroll"));
            /* Read variables values. */
            AV5ClienteRazaoSocial = StringUtil.Upper( cgiGet( edtavClienterazaosocial_Internalname));
            AssignAttri("", false, "AV5ClienteRazaoSocial", AV5ClienteRazaoSocial);
            if ( context.localUtil.VCDate( cgiGet( edtavOperacoesdata_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Operacoes Data"}), 1, "vOPERACOESDATA");
               GX_FocusControl = edtavOperacoesdata_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6OperacoesData = DateTime.MinValue;
               AssignAttri("", false, "AV6OperacoesData", context.localUtil.Format(AV6OperacoesData, "99/99/99"));
            }
            else
            {
               AV6OperacoesData = context.localUtil.CToD( cgiGet( edtavOperacoesdata_Internalname), 2);
               AssignAttri("", false, "AV6OperacoesData", context.localUtil.Format(AV6OperacoesData, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavOperacoestaxaefetiva_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavOperacoestaxaefetiva_Internalname), ",", ".") > 99999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vOPERACOESTAXAEFETIVA");
               GX_FocusControl = edtavOperacoestaxaefetiva_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7OperacoesTaxaEfetiva = 0;
               AssignAttri("", false, "AV7OperacoesTaxaEfetiva", StringUtil.LTrimStr( AV7OperacoesTaxaEfetiva, 16, 4));
            }
            else
            {
               AV7OperacoesTaxaEfetiva = context.localUtil.CToN( cgiGet( edtavOperacoestaxaefetiva_Internalname), ",", ".");
               AssignAttri("", false, "AV7OperacoesTaxaEfetiva", StringUtil.LTrimStr( AV7OperacoesTaxaEfetiva, 16, 4));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavOperacoestaxamora_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavOperacoestaxamora_Internalname), ",", ".") > 99999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vOPERACOESTAXAMORA");
               GX_FocusControl = edtavOperacoestaxamora_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8OperacoesTaxaMora = 0;
               AssignAttri("", false, "AV8OperacoesTaxaMora", StringUtil.LTrimStr( AV8OperacoesTaxaMora, 16, 4));
            }
            else
            {
               AV8OperacoesTaxaMora = context.localUtil.CToN( cgiGet( edtavOperacoestaxamora_Internalname), ",", ".");
               AssignAttri("", false, "AV8OperacoesTaxaMora", StringUtil.LTrimStr( AV8OperacoesTaxaMora, 16, 4));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavOperacoesfator_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavOperacoesfator_Internalname), ",", ".") > 99999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vOPERACOESFATOR");
               GX_FocusControl = edtavOperacoesfator_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV13OperacoesFator = 0;
               AssignAttri("", false, "AV13OperacoesFator", StringUtil.LTrimStr( AV13OperacoesFator, 16, 4));
            }
            else
            {
               AV13OperacoesFator = context.localUtil.CToN( cgiGet( edtavOperacoesfator_Internalname), ",", ".");
               AssignAttri("", false, "AV13OperacoesFator", StringUtil.LTrimStr( AV13OperacoesFator, 16, 4));
            }
            cmbavOperacoestipotarifa.CurrentValue = cgiGet( cmbavOperacoestipotarifa_Internalname);
            AV14OperacoesTipoTarifa = cgiGet( cmbavOperacoestipotarifa_Internalname);
            AssignAttri("", false, "AV14OperacoesTipoTarifa", AV14OperacoesTipoTarifa);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavOperacoestarifa_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavOperacoestarifa_Internalname), ",", ".") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vOPERACOESTARIFA");
               GX_FocusControl = edtavOperacoestarifa_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV15OperacoesTarifa = 0;
               AssignAttri("", false, "AV15OperacoesTarifa", StringUtil.LTrimStr( AV15OperacoesTarifa, 15, 2));
            }
            else
            {
               AV15OperacoesTarifa = context.localUtil.CToN( cgiGet( edtavOperacoestarifa_Internalname), ",", ".");
               AssignAttri("", false, "AV15OperacoesTarifa", StringUtil.LTrimStr( AV15OperacoesTarifa, 15, 2));
            }
            cmbavOperacoesstatus.CurrentValue = cgiGet( cmbavOperacoesstatus_Internalname);
            AV9OperacoesStatus = cgiGet( cmbavOperacoesstatus_Internalname);
            AssignAttri("", false, "AV9OperacoesStatus", AV9OperacoesStatus);
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
         E11A22 ();
         if (returnInSub) return;
      }

      protected void E11A22( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wcoperacoestitulosww = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcoperacoestitulosww_Component), StringUtil.Lower( "OperacoesTitulosWW")) != 0 )
         {
            WebComp_Wcoperacoestitulosww = getWebComponent(GetType(), "GeneXus.Programs", "operacoestitulosww", new Object[] {context} );
            WebComp_Wcoperacoestitulosww.ComponentInit();
            WebComp_Wcoperacoestitulosww.Name = "OperacoesTitulosWW";
            WebComp_Wcoperacoestitulosww_Component = "OperacoesTitulosWW";
         }
         if ( StringUtil.Len( WebComp_Wcoperacoestitulosww_Component) != 0 )
         {
            WebComp_Wcoperacoestitulosww.setjustcreated();
            WebComp_Wcoperacoestitulosww.componentprepare(new Object[] {(string)"W0064",(string)"",(int)AV10OperacoesId,(string)AV12TrnMode});
            WebComp_Wcoperacoestitulosww.componentbind(new Object[] {(string)"vOPERACOESID",(string)""});
         }
         AV11Operacoes.Load(AV10OperacoesId);
         AV6OperacoesData = AV11Operacoes.gxTpr_Operacoesdata;
         AssignAttri("", false, "AV6OperacoesData", context.localUtil.Format(AV6OperacoesData, "99/99/99"));
         AV9OperacoesStatus = AV11Operacoes.gxTpr_Operacoesstatus;
         AssignAttri("", false, "AV9OperacoesStatus", AV9OperacoesStatus);
         AV7OperacoesTaxaEfetiva = AV11Operacoes.gxTpr_Operacoestaxaefetiva;
         AssignAttri("", false, "AV7OperacoesTaxaEfetiva", StringUtil.LTrimStr( AV7OperacoesTaxaEfetiva, 16, 4));
         AV8OperacoesTaxaMora = AV11Operacoes.gxTpr_Operacoestaxamora;
         AssignAttri("", false, "AV8OperacoesTaxaMora", StringUtil.LTrimStr( AV8OperacoesTaxaMora, 16, 4));
         AV5ClienteRazaoSocial = AV11Operacoes.gxTpr_Clienterazaosocial;
         AssignAttri("", false, "AV5ClienteRazaoSocial", AV5ClienteRazaoSocial);
         AV13OperacoesFator = AV11Operacoes.gxTpr_Operacoesfator;
         AssignAttri("", false, "AV13OperacoesFator", StringUtil.LTrimStr( AV13OperacoesFator, 16, 4));
         AV15OperacoesTarifa = AV11Operacoes.gxTpr_Operacoestarifa;
         AssignAttri("", false, "AV15OperacoesTarifa", StringUtil.LTrimStr( AV15OperacoesTarifa, 15, 2));
         AV14OperacoesTipoTarifa = AV11Operacoes.gxTpr_Operacoestipotarifa;
         AssignAttri("", false, "AV14OperacoesTipoTarifa", AV14OperacoesTipoTarifa);
      }

      protected void nextLoad( )
      {
      }

      protected void E12A22( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV10OperacoesId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV10OperacoesId", StringUtil.LTrimStr( (decimal)(AV10OperacoesId), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vOPERACOESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10OperacoesId), "ZZZZZZZZ9"), context));
         AV12TrnMode = (string)getParm(obj,1);
         AssignAttri("", false, "AV12TrnMode", AV12TrnMode);
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV12TrnMode, "")), context));
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
         PAA22( ) ;
         WSA22( ) ;
         WEA22( ) ;
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
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wcoperacoestitulosww == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcoperacoestitulosww_Component) != 0 )
            {
               WebComp_Wcoperacoestitulosww.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101929999", true, true);
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
         context.AddJavascriptSource("operacao.js", "?20256101929100", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavOperacoestipotarifa.Name = "vOPERACOESTIPOTARIFA";
         cmbavOperacoestipotarifa.WebTags = "";
         cmbavOperacoestipotarifa.addItem("P", "Percentual", 0);
         cmbavOperacoestipotarifa.addItem("V", "Valor", 0);
         if ( cmbavOperacoestipotarifa.ItemCount > 0 )
         {
            AV14OperacoesTipoTarifa = cmbavOperacoestipotarifa.getValidValue(AV14OperacoesTipoTarifa);
            AssignAttri("", false, "AV14OperacoesTipoTarifa", AV14OperacoesTipoTarifa);
         }
         cmbavOperacoesstatus.Name = "vOPERACOESSTATUS";
         cmbavOperacoesstatus.WebTags = "";
         cmbavOperacoesstatus.addItem("PENDENTE", "Pendente", 0);
         cmbavOperacoesstatus.addItem("APROVADA", "Aprovada", 0);
         cmbavOperacoesstatus.addItem("RECUSADA", "Recusada", 0);
         cmbavOperacoesstatus.addItem("LIQUIDADA", "Liquidada", 0);
         if ( cmbavOperacoesstatus.ItemCount > 0 )
         {
            AV9OperacoesStatus = cmbavOperacoesstatus.getValidValue(AV9OperacoesStatus);
            AssignAttri("", false, "AV9OperacoesStatus", AV9OperacoesStatus);
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         edtavOperacoesid_Internalname = "vOPERACOESID";
         edtavClienterazaosocial_Internalname = "vCLIENTERAZAOSOCIAL";
         edtavOperacoesdata_Internalname = "vOPERACOESDATA";
         edtavOperacoestaxaefetiva_Internalname = "vOPERACOESTAXAEFETIVA";
         edtavOperacoestaxamora_Internalname = "vOPERACOESTAXAMORA";
         edtavOperacoesfator_Internalname = "vOPERACOESFATOR";
         cmbavOperacoestipotarifa_Internalname = "vOPERACOESTIPOTARIFA";
         edtavOperacoestarifa_Internalname = "vOPERACOESTARIFA";
         cmbavOperacoesstatus_Internalname = "vOPERACOESSTATUS";
         divOperacao_Internalname = "OPERACAO";
         Dvpanel_operacao_Internalname = "DVPANEL_OPERACAO";
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
         cmbavOperacoesstatus_Jsonclick = "";
         cmbavOperacoesstatus.Enabled = 1;
         edtavOperacoestarifa_Jsonclick = "";
         edtavOperacoestarifa_Enabled = 1;
         cmbavOperacoestipotarifa_Jsonclick = "";
         cmbavOperacoestipotarifa.Enabled = 1;
         edtavOperacoesfator_Jsonclick = "";
         edtavOperacoesfator_Enabled = 1;
         edtavOperacoestaxamora_Jsonclick = "";
         edtavOperacoestaxamora_Enabled = 1;
         edtavOperacoestaxaefetiva_Jsonclick = "";
         edtavOperacoestaxaefetiva_Enabled = 1;
         edtavOperacoesdata_Jsonclick = "";
         edtavOperacoesdata_Enabled = 1;
         edtavClienterazaosocial_Jsonclick = "";
         edtavClienterazaosocial_Enabled = 1;
         edtavOperacoesid_Jsonclick = "";
         edtavOperacoesid_Enabled = 0;
         Dvpanel_operacao_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_operacao_Iconposition = "Right";
         Dvpanel_operacao_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_operacao_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_operacao_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_operacao_Title = "Operação";
         Dvpanel_operacao_Cls = "PanelCard_GrayTitle";
         Dvpanel_operacao_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_operacao_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_operacao_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Operação";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV12TrnMode","fld":"vTRNMODE","hsh":true,"type":"char"},{"av":"AV10OperacoesId","fld":"vOPERACOESID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("VALIDV_OPERACOESSTATUS","""{"handler":"Validv_Operacoesstatus","iparms":[]}""");
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
         wcpOAV12TrnMode = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtn_cancel_Jsonclick = "";
         ucDvpanel_operacao = new GXUserControl();
         AV5ClienteRazaoSocial = "";
         AV6OperacoesData = DateTime.MinValue;
         AV14OperacoesTipoTarifa = "";
         AV9OperacoesStatus = "";
         WebComp_Wcoperacoestitulosww_Component = "";
         OldWcoperacoestitulosww = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV11Operacoes = new SdtOperacoes(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         WebComp_Wcoperacoestitulosww = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
         edtavOperacoesid_Enabled = 0;
         edtavClienterazaosocial_Enabled = 0;
         edtavOperacoesdata_Enabled = 0;
         edtavOperacoestaxaefetiva_Enabled = 0;
         edtavOperacoestaxamora_Enabled = 0;
         edtavOperacoesfator_Enabled = 0;
         cmbavOperacoestipotarifa.Enabled = 0;
         edtavOperacoestarifa_Enabled = 0;
         cmbavOperacoesstatus.Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int AV10OperacoesId ;
      private int wcpOAV10OperacoesId ;
      private int edtavOperacoesid_Enabled ;
      private int edtavClienterazaosocial_Enabled ;
      private int edtavOperacoesdata_Enabled ;
      private int edtavOperacoestaxaefetiva_Enabled ;
      private int edtavOperacoestaxamora_Enabled ;
      private int edtavOperacoesfator_Enabled ;
      private int edtavOperacoestarifa_Enabled ;
      private int idxLst ;
      private decimal AV7OperacoesTaxaEfetiva ;
      private decimal AV8OperacoesTaxaMora ;
      private decimal AV13OperacoesFator ;
      private decimal AV15OperacoesTarifa ;
      private string AV12TrnMode ;
      private string wcpOAV12TrnMode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Dvpanel_operacao_Width ;
      private string Dvpanel_operacao_Cls ;
      private string Dvpanel_operacao_Title ;
      private string Dvpanel_operacao_Iconposition ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_operacao_Internalname ;
      private string divOperacao_Internalname ;
      private string edtavOperacoesid_Internalname ;
      private string edtavOperacoesid_Jsonclick ;
      private string edtavClienterazaosocial_Internalname ;
      private string edtavClienterazaosocial_Jsonclick ;
      private string edtavOperacoesdata_Internalname ;
      private string edtavOperacoesdata_Jsonclick ;
      private string edtavOperacoestaxaefetiva_Internalname ;
      private string edtavOperacoestaxaefetiva_Jsonclick ;
      private string edtavOperacoestaxamora_Internalname ;
      private string edtavOperacoestaxamora_Jsonclick ;
      private string edtavOperacoesfator_Internalname ;
      private string edtavOperacoesfator_Jsonclick ;
      private string cmbavOperacoestipotarifa_Internalname ;
      private string cmbavOperacoestipotarifa_Jsonclick ;
      private string edtavOperacoestarifa_Internalname ;
      private string edtavOperacoestarifa_Jsonclick ;
      private string cmbavOperacoesstatus_Internalname ;
      private string cmbavOperacoesstatus_Jsonclick ;
      private string WebComp_Wcoperacoestitulosww_Component ;
      private string OldWcoperacoestitulosww ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private DateTime AV6OperacoesData ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Dvpanel_operacao_Autowidth ;
      private bool Dvpanel_operacao_Autoheight ;
      private bool Dvpanel_operacao_Collapsible ;
      private bool Dvpanel_operacao_Collapsed ;
      private bool Dvpanel_operacao_Showcollapseicon ;
      private bool Dvpanel_operacao_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool bDynCreated_Wcoperacoestitulosww ;
      private string AV5ClienteRazaoSocial ;
      private string AV14OperacoesTipoTarifa ;
      private string AV9OperacoesStatus ;
      private GXWebComponent WebComp_Wcoperacoestitulosww ;
      private GXUserControl ucDvpanel_operacao ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavOperacoestipotarifa ;
      private GXCombobox cmbavOperacoesstatus ;
      private SdtOperacoes AV11Operacoes ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
