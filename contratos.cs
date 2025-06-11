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
   public class contratos : GXDataArea
   {
      public contratos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public contratos( IGxContext context )
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
         PA4V2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START4V2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("contratos") +"\">") ;
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
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"Contratos");
         forbiddenHiddens.Add("CardContratosProximoVencimento_Value", context.localUtil.Format( (decimal)(AV30CardContratosProximoVencimento_Value), "ZZ,ZZZ,ZZ9"));
         forbiddenHiddens.Add("CardContratosAssinando_Value", context.localUtil.Format( (decimal)(AV29CardContratosAssinando_Value), "ZZ,ZZZ,ZZ9"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("contratos:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vELEMENTS", AV14Elements);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vELEMENTS", AV14Elements);
         }
         GxWebStd.gx_hidden_field( context, "vPARAMETERS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15Parameters), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vITEMCLICKDATA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16ItemClickData), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vITEMDOUBLECLICKDATA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17ItemDoubleClickData), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vDRAGANDDROPDATA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18DragAndDropData), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vFILTERCHANGEDDATA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19FilterChangedData), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vITEMEXPANDDATA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20ItemExpandData), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vITEMCOLLAPSEDATA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21ItemCollapseData), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDCONTRATOSVIGENTES_MAINTABLE_Width", StringUtil.RTrim( Dvpanel_cardcontratosvigentes_maintable_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDCONTRATOSVIGENTES_MAINTABLE_Autowidth", StringUtil.BoolToStr( Dvpanel_cardcontratosvigentes_maintable_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDCONTRATOSVIGENTES_MAINTABLE_Autoheight", StringUtil.BoolToStr( Dvpanel_cardcontratosvigentes_maintable_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDCONTRATOSVIGENTES_MAINTABLE_Cls", StringUtil.RTrim( Dvpanel_cardcontratosvigentes_maintable_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDCONTRATOSVIGENTES_MAINTABLE_Title", StringUtil.RTrim( Dvpanel_cardcontratosvigentes_maintable_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDCONTRATOSVIGENTES_MAINTABLE_Collapsible", StringUtil.BoolToStr( Dvpanel_cardcontratosvigentes_maintable_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDCONTRATOSVIGENTES_MAINTABLE_Collapsed", StringUtil.BoolToStr( Dvpanel_cardcontratosvigentes_maintable_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDCONTRATOSVIGENTES_MAINTABLE_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_cardcontratosvigentes_maintable_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDCONTRATOSVIGENTES_MAINTABLE_Iconposition", StringUtil.RTrim( Dvpanel_cardcontratosvigentes_maintable_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDCONTRATOSVIGENTES_MAINTABLE_Autoscroll", StringUtil.BoolToStr( Dvpanel_cardcontratosvigentes_maintable_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDCONTRATOSPROXIMOVENCIMENTO_MAINTABLE_Width", StringUtil.RTrim( Dvpanel_cardcontratosproximovencimento_maintable_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDCONTRATOSPROXIMOVENCIMENTO_MAINTABLE_Autowidth", StringUtil.BoolToStr( Dvpanel_cardcontratosproximovencimento_maintable_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDCONTRATOSPROXIMOVENCIMENTO_MAINTABLE_Autoheight", StringUtil.BoolToStr( Dvpanel_cardcontratosproximovencimento_maintable_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDCONTRATOSPROXIMOVENCIMENTO_MAINTABLE_Cls", StringUtil.RTrim( Dvpanel_cardcontratosproximovencimento_maintable_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDCONTRATOSPROXIMOVENCIMENTO_MAINTABLE_Title", StringUtil.RTrim( Dvpanel_cardcontratosproximovencimento_maintable_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDCONTRATOSPROXIMOVENCIMENTO_MAINTABLE_Collapsible", StringUtil.BoolToStr( Dvpanel_cardcontratosproximovencimento_maintable_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDCONTRATOSPROXIMOVENCIMENTO_MAINTABLE_Collapsed", StringUtil.BoolToStr( Dvpanel_cardcontratosproximovencimento_maintable_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDCONTRATOSPROXIMOVENCIMENTO_MAINTABLE_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_cardcontratosproximovencimento_maintable_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDCONTRATOSPROXIMOVENCIMENTO_MAINTABLE_Iconposition", StringUtil.RTrim( Dvpanel_cardcontratosproximovencimento_maintable_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDCONTRATOSPROXIMOVENCIMENTO_MAINTABLE_Autoscroll", StringUtil.BoolToStr( Dvpanel_cardcontratosproximovencimento_maintable_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDCONTRATOSASSINANDO_MAINTABLE_Width", StringUtil.RTrim( Dvpanel_cardcontratosassinando_maintable_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDCONTRATOSASSINANDO_MAINTABLE_Autowidth", StringUtil.BoolToStr( Dvpanel_cardcontratosassinando_maintable_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDCONTRATOSASSINANDO_MAINTABLE_Autoheight", StringUtil.BoolToStr( Dvpanel_cardcontratosassinando_maintable_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDCONTRATOSASSINANDO_MAINTABLE_Cls", StringUtil.RTrim( Dvpanel_cardcontratosassinando_maintable_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDCONTRATOSASSINANDO_MAINTABLE_Title", StringUtil.RTrim( Dvpanel_cardcontratosassinando_maintable_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDCONTRATOSASSINANDO_MAINTABLE_Collapsible", StringUtil.BoolToStr( Dvpanel_cardcontratosassinando_maintable_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDCONTRATOSASSINANDO_MAINTABLE_Collapsed", StringUtil.BoolToStr( Dvpanel_cardcontratosassinando_maintable_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDCONTRATOSASSINANDO_MAINTABLE_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_cardcontratosassinando_maintable_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDCONTRATOSASSINANDO_MAINTABLE_Iconposition", StringUtil.RTrim( Dvpanel_cardcontratosassinando_maintable_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDCONTRATOSASSINANDO_MAINTABLE_Autoscroll", StringUtil.BoolToStr( Dvpanel_cardcontratosassinando_maintable_Autoscroll));
         GxWebStd.gx_hidden_field( context, "QV_Objectcall", StringUtil.RTrim( Qv_Objectcall));
         GxWebStd.gx_hidden_field( context, "QV_Objectcall", StringUtil.RTrim( Qv_Objectcall));
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
         if ( ! ( WebComp_Wcwcassinaturas == null ) )
         {
            WebComp_Wcwcassinaturas.componentjscripts();
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
            WE4V2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT4V2( ) ;
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
         return formatLink("contratos")  ;
      }

      public override string GetPgmname( )
      {
         return "Contratos" ;
      }

      public override string GetPgmdesc( )
      {
         return "Contratos" ;
      }

      protected void WB4V0( )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecards_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 CellMarginTop", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_cardcontratosvigentes_maintable.SetProperty("Width", Dvpanel_cardcontratosvigentes_maintable_Width);
            ucDvpanel_cardcontratosvigentes_maintable.SetProperty("AutoWidth", Dvpanel_cardcontratosvigentes_maintable_Autowidth);
            ucDvpanel_cardcontratosvigentes_maintable.SetProperty("AutoHeight", Dvpanel_cardcontratosvigentes_maintable_Autoheight);
            ucDvpanel_cardcontratosvigentes_maintable.SetProperty("Cls", Dvpanel_cardcontratosvigentes_maintable_Cls);
            ucDvpanel_cardcontratosvigentes_maintable.SetProperty("Title", Dvpanel_cardcontratosvigentes_maintable_Title);
            ucDvpanel_cardcontratosvigentes_maintable.SetProperty("Collapsible", Dvpanel_cardcontratosvigentes_maintable_Collapsible);
            ucDvpanel_cardcontratosvigentes_maintable.SetProperty("Collapsed", Dvpanel_cardcontratosvigentes_maintable_Collapsed);
            ucDvpanel_cardcontratosvigentes_maintable.SetProperty("ShowCollapseIcon", Dvpanel_cardcontratosvigentes_maintable_Showcollapseicon);
            ucDvpanel_cardcontratosvigentes_maintable.SetProperty("IconPosition", Dvpanel_cardcontratosvigentes_maintable_Iconposition);
            ucDvpanel_cardcontratosvigentes_maintable.SetProperty("AutoScroll", Dvpanel_cardcontratosvigentes_maintable_Autoscroll);
            ucDvpanel_cardcontratosvigentes_maintable.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_cardcontratosvigentes_maintable_Internalname, "DVPANEL_CARDCONTRATOSVIGENTES_MAINTABLEContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_CARDCONTRATOSVIGENTES_MAINTABLEContainer"+"CardContratosVigentes_MainTable"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divCardcontratosvigentes_maintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 SimpleCardIconPadding", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCardcontratosvigentes_icon_Internalname, "<i class='ProgressCardIconBaseColor fas fa-file-signature' style='font-size: 50px'></i>", "", "", lblCardcontratosvigentes_icon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_Contratos.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCardcontratosvigentes_tableinfo_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;align-items:flex-end;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCardcontratosvigentes_description_Internalname, "Contratos vigêntes", "", "", lblCardcontratosvigentes_description_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockDashboardDescriptionCard", 0, "", 1, 1, 0, 0, "HLP_Contratos.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCardcontratosvigentes_value_Internalname, "Card Contratos Vigentes_Value", "gx-form-item DashboardNumberCardLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCardcontratosvigentes_value_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31CardContratosVigentes_Value), 10, 0, ",", "")), StringUtil.LTrim( ((edtavCardcontratosvigentes_value_Enabled!=0) ? context.localUtil.Format( (decimal)(AV31CardContratosVigentes_Value), "ZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV31CardContratosVigentes_Value), "ZZ,ZZZ,ZZ9"))), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,24);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCardcontratosvigentes_value_Jsonclick, 0, "DashboardNumberCard", "", "", "", "", 1, edtavCardcontratosvigentes_value_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "KPINumericValue", "end", false, "", "HLP_Contratos.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 CellMarginTop", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_cardcontratosproximovencimento_maintable.SetProperty("Width", Dvpanel_cardcontratosproximovencimento_maintable_Width);
            ucDvpanel_cardcontratosproximovencimento_maintable.SetProperty("AutoWidth", Dvpanel_cardcontratosproximovencimento_maintable_Autowidth);
            ucDvpanel_cardcontratosproximovencimento_maintable.SetProperty("AutoHeight", Dvpanel_cardcontratosproximovencimento_maintable_Autoheight);
            ucDvpanel_cardcontratosproximovencimento_maintable.SetProperty("Cls", Dvpanel_cardcontratosproximovencimento_maintable_Cls);
            ucDvpanel_cardcontratosproximovencimento_maintable.SetProperty("Title", Dvpanel_cardcontratosproximovencimento_maintable_Title);
            ucDvpanel_cardcontratosproximovencimento_maintable.SetProperty("Collapsible", Dvpanel_cardcontratosproximovencimento_maintable_Collapsible);
            ucDvpanel_cardcontratosproximovencimento_maintable.SetProperty("Collapsed", Dvpanel_cardcontratosproximovencimento_maintable_Collapsed);
            ucDvpanel_cardcontratosproximovencimento_maintable.SetProperty("ShowCollapseIcon", Dvpanel_cardcontratosproximovencimento_maintable_Showcollapseicon);
            ucDvpanel_cardcontratosproximovencimento_maintable.SetProperty("IconPosition", Dvpanel_cardcontratosproximovencimento_maintable_Iconposition);
            ucDvpanel_cardcontratosproximovencimento_maintable.SetProperty("AutoScroll", Dvpanel_cardcontratosproximovencimento_maintable_Autoscroll);
            ucDvpanel_cardcontratosproximovencimento_maintable.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_cardcontratosproximovencimento_maintable_Internalname, "DVPANEL_CARDCONTRATOSPROXIMOVENCIMENTO_MAINTABLEContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_CARDCONTRATOSPROXIMOVENCIMENTO_MAINTABLEContainer"+"CardContratosProximoVencimento_MainTable"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divCardcontratosproximovencimento_maintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 SimpleCardIconPadding", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCardcontratosproximovencimento_icon_Internalname, "<i class='ProgressCardIconDanger fas fa-file-contract' style='font-size: 50px'></i>", "", "", lblCardcontratosproximovencimento_icon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_Contratos.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCardcontratosproximovencimento_tableinfo_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;align-items:flex-end;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCardcontratosproximovencimento_description_Internalname, "Contratos vencendo", "", "", lblCardcontratosproximovencimento_description_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockDashboardDescriptionCard", 0, "", 1, 1, 0, 0, "HLP_Contratos.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCardcontratosproximovencimento_value_Internalname, "Card Contratos Proximo Vencimento_Value", "gx-form-item DashboardNumberCardLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCardcontratosproximovencimento_value_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30CardContratosProximoVencimento_Value), 10, 0, ",", "")), StringUtil.LTrim( ((edtavCardcontratosproximovencimento_value_Enabled!=0) ? context.localUtil.Format( (decimal)(AV30CardContratosProximoVencimento_Value), "ZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV30CardContratosProximoVencimento_Value), "ZZ,ZZZ,ZZ9"))), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCardcontratosproximovencimento_value_Jsonclick, 0, "DashboardNumberCard", "", "", "", "", 1, edtavCardcontratosproximovencimento_value_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "KPINumericValue", "end", false, "", "HLP_Contratos.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 CellMarginTop", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_cardcontratosassinando_maintable.SetProperty("Width", Dvpanel_cardcontratosassinando_maintable_Width);
            ucDvpanel_cardcontratosassinando_maintable.SetProperty("AutoWidth", Dvpanel_cardcontratosassinando_maintable_Autowidth);
            ucDvpanel_cardcontratosassinando_maintable.SetProperty("AutoHeight", Dvpanel_cardcontratosassinando_maintable_Autoheight);
            ucDvpanel_cardcontratosassinando_maintable.SetProperty("Cls", Dvpanel_cardcontratosassinando_maintable_Cls);
            ucDvpanel_cardcontratosassinando_maintable.SetProperty("Title", Dvpanel_cardcontratosassinando_maintable_Title);
            ucDvpanel_cardcontratosassinando_maintable.SetProperty("Collapsible", Dvpanel_cardcontratosassinando_maintable_Collapsible);
            ucDvpanel_cardcontratosassinando_maintable.SetProperty("Collapsed", Dvpanel_cardcontratosassinando_maintable_Collapsed);
            ucDvpanel_cardcontratosassinando_maintable.SetProperty("ShowCollapseIcon", Dvpanel_cardcontratosassinando_maintable_Showcollapseicon);
            ucDvpanel_cardcontratosassinando_maintable.SetProperty("IconPosition", Dvpanel_cardcontratosassinando_maintable_Iconposition);
            ucDvpanel_cardcontratosassinando_maintable.SetProperty("AutoScroll", Dvpanel_cardcontratosassinando_maintable_Autoscroll);
            ucDvpanel_cardcontratosassinando_maintable.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_cardcontratosassinando_maintable_Internalname, "DVPANEL_CARDCONTRATOSASSINANDO_MAINTABLEContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_CARDCONTRATOSASSINANDO_MAINTABLEContainer"+"CardContratosAssinando_MainTable"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divCardcontratosassinando_maintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 SimpleCardIconPadding", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCardcontratosassinando_icon_Internalname, "<i class='ProgressCardIconInfo fas fa-signature' style='font-size: 50px'></i>", "", "", lblCardcontratosassinando_icon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_Contratos.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCardcontratosassinando_tableinfo_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;align-items:flex-end;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCardcontratosassinando_description_Internalname, "Contratos em assinatura", "", "", lblCardcontratosassinando_description_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockDashboardDescriptionCard", 0, "", 1, 1, 0, 0, "HLP_Contratos.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCardcontratosassinando_value_Internalname, "Card Contratos Assinando_Value", "gx-form-item DashboardNumberCardLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCardcontratosassinando_value_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29CardContratosAssinando_Value), 10, 0, ",", "")), StringUtil.LTrim( ((edtavCardcontratosassinando_value_Enabled!=0) ? context.localUtil.Format( (decimal)(AV29CardContratosAssinando_Value), "ZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV29CardContratosAssinando_Value), "ZZ,ZZZ,ZZ9"))), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCardcontratosassinando_value_Jsonclick, 0, "DashboardNumberCard", "", "", "", "", 1, edtavCardcontratosassinando_value_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "KPINumericValue", "end", false, "", "HLP_Contratos.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucQv.SetProperty("Elements", AV14Elements);
            ucQv.SetProperty("Parameters", AV15Parameters);
            ucQv.SetProperty("Title", Qv_Title);
            ucQv.SetProperty("ItemClickData", AV16ItemClickData);
            ucQv.SetProperty("ItemDoubleClickData", AV17ItemDoubleClickData);
            ucQv.SetProperty("DragAndDropData", AV18DragAndDropData);
            ucQv.SetProperty("FilterChangedData", AV19FilterChangedData);
            ucQv.SetProperty("ItemExpandData", AV20ItemExpandData);
            ucQv.SetProperty("ItemCollapseData", AV21ItemCollapseData);
            ucQv.Render(context, "queryviewer", Qv_Internalname, "QVContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0057"+"", StringUtil.RTrim( WebComp_Wcwcassinaturas_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0057"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcwcassinaturas_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwcassinaturas), StringUtil.Lower( WebComp_Wcwcassinaturas_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0057"+"");
                  }
                  WebComp_Wcwcassinaturas.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwcassinaturas), StringUtil.Lower( WebComp_Wcwcassinaturas_Component)) != 0 )
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
         }
         wbLoad = true;
      }

      protected void START4V2( )
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
         Form.Meta.addItem("description", "Contratos", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4V0( ) ;
      }

      protected void WS4V2( )
      {
         START4V2( ) ;
         EVT4V2( ) ;
      }

      protected void EVT4V2( )
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
                              E114V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "CARDCONTRATOSVIGENTES_MAINTABLE.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Cardcontratosvigentes_maintable.Click */
                              E124V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "CARDCONTRATOSASSINANDO_MAINTABLE.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Cardcontratosassinando_maintable.Click */
                              E134V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "CARDCONTRATOSPROXIMOVENCIMENTO_MAINTABLE.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Cardcontratosproximovencimento_maintable.Click */
                              E144V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E154V2 ();
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
                        if ( nCmpId == 57 )
                        {
                           OldWcwcassinaturas = cgiGet( "W0057");
                           if ( ( StringUtil.Len( OldWcwcassinaturas) == 0 ) || ( StringUtil.StrCmp(OldWcwcassinaturas, WebComp_Wcwcassinaturas_Component) != 0 ) )
                           {
                              WebComp_Wcwcassinaturas = getWebComponent(GetType(), "GeneXus.Programs", OldWcwcassinaturas, new Object[] {context} );
                              WebComp_Wcwcassinaturas.ComponentInit();
                              WebComp_Wcwcassinaturas.Name = "OldWcwcassinaturas";
                              WebComp_Wcwcassinaturas_Component = OldWcwcassinaturas;
                           }
                           if ( StringUtil.Len( WebComp_Wcwcassinaturas_Component) != 0 )
                           {
                              WebComp_Wcwcassinaturas.componentprocess("W0057", "", sEvt);
                           }
                           WebComp_Wcwcassinaturas_Component = OldWcwcassinaturas;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE4V2( )
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

      protected void PA4V2( )
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
               GX_FocusControl = edtavCardcontratosvigentes_value_Internalname;
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
         RF4V2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
         edtavCardcontratosvigentes_value_Enabled = 0;
         AssignProp("", false, edtavCardcontratosvigentes_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCardcontratosvigentes_value_Enabled), 5, 0), true);
         edtavCardcontratosproximovencimento_value_Enabled = 0;
         AssignProp("", false, edtavCardcontratosproximovencimento_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCardcontratosproximovencimento_value_Enabled), 5, 0), true);
         edtavCardcontratosassinando_value_Enabled = 0;
         AssignProp("", false, edtavCardcontratosassinando_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCardcontratosassinando_value_Enabled), 5, 0), true);
      }

      protected void RF4V2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcwcassinaturas_Component) != 0 )
               {
                  WebComp_Wcwcassinaturas.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E154V2 ();
            WB4V0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes4V2( )
      {
      }

      protected void before_start_formulas( )
      {
         Gx_date = DateTimeUtil.Today( context);
         edtavCardcontratosvigentes_value_Enabled = 0;
         AssignProp("", false, edtavCardcontratosvigentes_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCardcontratosvigentes_value_Enabled), 5, 0), true);
         edtavCardcontratosproximovencimento_value_Enabled = 0;
         AssignProp("", false, edtavCardcontratosproximovencimento_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCardcontratosproximovencimento_value_Enabled), 5, 0), true);
         edtavCardcontratosassinando_value_Enabled = 0;
         AssignProp("", false, edtavCardcontratosassinando_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCardcontratosassinando_value_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4V0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E114V2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vELEMENTS"), AV14Elements);
            /* Read saved values. */
            AV15Parameters = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vPARAMETERS"), ",", "."), 18, MidpointRounding.ToEven));
            AV16ItemClickData = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vITEMCLICKDATA"), ",", "."), 18, MidpointRounding.ToEven));
            AV17ItemDoubleClickData = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vITEMDOUBLECLICKDATA"), ",", "."), 18, MidpointRounding.ToEven));
            AV18DragAndDropData = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vDRAGANDDROPDATA"), ",", "."), 18, MidpointRounding.ToEven));
            AV19FilterChangedData = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vFILTERCHANGEDDATA"), ",", "."), 18, MidpointRounding.ToEven));
            AV20ItemExpandData = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vITEMEXPANDDATA"), ",", "."), 18, MidpointRounding.ToEven));
            AV21ItemCollapseData = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vITEMCOLLAPSEDATA"), ",", "."), 18, MidpointRounding.ToEven));
            Dvpanel_cardcontratosvigentes_maintable_Width = cgiGet( "DVPANEL_CARDCONTRATOSVIGENTES_MAINTABLE_Width");
            Dvpanel_cardcontratosvigentes_maintable_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDCONTRATOSVIGENTES_MAINTABLE_Autowidth"));
            Dvpanel_cardcontratosvigentes_maintable_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDCONTRATOSVIGENTES_MAINTABLE_Autoheight"));
            Dvpanel_cardcontratosvigentes_maintable_Cls = cgiGet( "DVPANEL_CARDCONTRATOSVIGENTES_MAINTABLE_Cls");
            Dvpanel_cardcontratosvigentes_maintable_Title = cgiGet( "DVPANEL_CARDCONTRATOSVIGENTES_MAINTABLE_Title");
            Dvpanel_cardcontratosvigentes_maintable_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDCONTRATOSVIGENTES_MAINTABLE_Collapsible"));
            Dvpanel_cardcontratosvigentes_maintable_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDCONTRATOSVIGENTES_MAINTABLE_Collapsed"));
            Dvpanel_cardcontratosvigentes_maintable_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDCONTRATOSVIGENTES_MAINTABLE_Showcollapseicon"));
            Dvpanel_cardcontratosvigentes_maintable_Iconposition = cgiGet( "DVPANEL_CARDCONTRATOSVIGENTES_MAINTABLE_Iconposition");
            Dvpanel_cardcontratosvigentes_maintable_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDCONTRATOSVIGENTES_MAINTABLE_Autoscroll"));
            Dvpanel_cardcontratosproximovencimento_maintable_Width = cgiGet( "DVPANEL_CARDCONTRATOSPROXIMOVENCIMENTO_MAINTABLE_Width");
            Dvpanel_cardcontratosproximovencimento_maintable_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDCONTRATOSPROXIMOVENCIMENTO_MAINTABLE_Autowidth"));
            Dvpanel_cardcontratosproximovencimento_maintable_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDCONTRATOSPROXIMOVENCIMENTO_MAINTABLE_Autoheight"));
            Dvpanel_cardcontratosproximovencimento_maintable_Cls = cgiGet( "DVPANEL_CARDCONTRATOSPROXIMOVENCIMENTO_MAINTABLE_Cls");
            Dvpanel_cardcontratosproximovencimento_maintable_Title = cgiGet( "DVPANEL_CARDCONTRATOSPROXIMOVENCIMENTO_MAINTABLE_Title");
            Dvpanel_cardcontratosproximovencimento_maintable_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDCONTRATOSPROXIMOVENCIMENTO_MAINTABLE_Collapsible"));
            Dvpanel_cardcontratosproximovencimento_maintable_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDCONTRATOSPROXIMOVENCIMENTO_MAINTABLE_Collapsed"));
            Dvpanel_cardcontratosproximovencimento_maintable_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDCONTRATOSPROXIMOVENCIMENTO_MAINTABLE_Showcollapseicon"));
            Dvpanel_cardcontratosproximovencimento_maintable_Iconposition = cgiGet( "DVPANEL_CARDCONTRATOSPROXIMOVENCIMENTO_MAINTABLE_Iconposition");
            Dvpanel_cardcontratosproximovencimento_maintable_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDCONTRATOSPROXIMOVENCIMENTO_MAINTABLE_Autoscroll"));
            Dvpanel_cardcontratosassinando_maintable_Width = cgiGet( "DVPANEL_CARDCONTRATOSASSINANDO_MAINTABLE_Width");
            Dvpanel_cardcontratosassinando_maintable_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDCONTRATOSASSINANDO_MAINTABLE_Autowidth"));
            Dvpanel_cardcontratosassinando_maintable_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDCONTRATOSASSINANDO_MAINTABLE_Autoheight"));
            Dvpanel_cardcontratosassinando_maintable_Cls = cgiGet( "DVPANEL_CARDCONTRATOSASSINANDO_MAINTABLE_Cls");
            Dvpanel_cardcontratosassinando_maintable_Title = cgiGet( "DVPANEL_CARDCONTRATOSASSINANDO_MAINTABLE_Title");
            Dvpanel_cardcontratosassinando_maintable_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDCONTRATOSASSINANDO_MAINTABLE_Collapsible"));
            Dvpanel_cardcontratosassinando_maintable_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDCONTRATOSASSINANDO_MAINTABLE_Collapsed"));
            Dvpanel_cardcontratosassinando_maintable_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDCONTRATOSASSINANDO_MAINTABLE_Showcollapseicon"));
            Dvpanel_cardcontratosassinando_maintable_Iconposition = cgiGet( "DVPANEL_CARDCONTRATOSASSINANDO_MAINTABLE_Iconposition");
            Dvpanel_cardcontratosassinando_maintable_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDCONTRATOSASSINANDO_MAINTABLE_Autoscroll"));
            Qv_Objectcall = cgiGet( "QV_Objectcall");
            Qv_Objectcall = cgiGet( "QV_Objectcall");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCardcontratosvigentes_value_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCardcontratosvigentes_value_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCARDCONTRATOSVIGENTES_VALUE");
               GX_FocusControl = edtavCardcontratosvigentes_value_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV31CardContratosVigentes_Value = 0;
               AssignAttri("", false, "AV31CardContratosVigentes_Value", StringUtil.LTrimStr( (decimal)(AV31CardContratosVigentes_Value), 8, 0));
            }
            else
            {
               AV31CardContratosVigentes_Value = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCardcontratosvigentes_value_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV31CardContratosVigentes_Value", StringUtil.LTrimStr( (decimal)(AV31CardContratosVigentes_Value), 8, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCardcontratosproximovencimento_value_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCardcontratosproximovencimento_value_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCARDCONTRATOSPROXIMOVENCIMENTO_VALUE");
               GX_FocusControl = edtavCardcontratosproximovencimento_value_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV30CardContratosProximoVencimento_Value = 0;
               AssignAttri("", false, "AV30CardContratosProximoVencimento_Value", StringUtil.LTrimStr( (decimal)(AV30CardContratosProximoVencimento_Value), 8, 0));
            }
            else
            {
               AV30CardContratosProximoVencimento_Value = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCardcontratosproximovencimento_value_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV30CardContratosProximoVencimento_Value", StringUtil.LTrimStr( (decimal)(AV30CardContratosProximoVencimento_Value), 8, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCardcontratosassinando_value_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCardcontratosassinando_value_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCARDCONTRATOSASSINANDO_VALUE");
               GX_FocusControl = edtavCardcontratosassinando_value_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV29CardContratosAssinando_Value = 0;
               AssignAttri("", false, "AV29CardContratosAssinando_Value", StringUtil.LTrimStr( (decimal)(AV29CardContratosAssinando_Value), 8, 0));
            }
            else
            {
               AV29CardContratosAssinando_Value = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCardcontratosassinando_value_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV29CardContratosAssinando_Value", StringUtil.LTrimStr( (decimal)(AV29CardContratosAssinando_Value), 8, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"Contratos");
            AV30CardContratosProximoVencimento_Value = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCardcontratosproximovencimento_value_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV30CardContratosProximoVencimento_Value", StringUtil.LTrimStr( (decimal)(AV30CardContratosProximoVencimento_Value), 8, 0));
            forbiddenHiddens.Add("CardContratosProximoVencimento_Value", context.localUtil.Format( (decimal)(AV30CardContratosProximoVencimento_Value), "ZZ,ZZZ,ZZ9"));
            AV29CardContratosAssinando_Value = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCardcontratosassinando_value_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV29CardContratosAssinando_Value", StringUtil.LTrimStr( (decimal)(AV29CardContratosAssinando_Value), 8, 0));
            forbiddenHiddens.Add("CardContratosAssinando_Value", context.localUtil.Format( (decimal)(AV29CardContratosAssinando_Value), "ZZ,ZZZ,ZZ9"));
            hsh = cgiGet( "hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("contratos:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               return  ;
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
         E114V2 ();
         if (returnInSub) return;
      }

      protected void E114V2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV32Data = DateTimeUtil.DAdd( Gx_date, (30));
         AV31CardContratosVigentes_Value = 0;
         AssignAttri("", false, "AV31CardContratosVigentes_Value", StringUtil.LTrimStr( (decimal)(AV31CardContratosVigentes_Value), 8, 0));
         /* Using cursor H004V2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A227ContratoId = H004V2_A227ContratoId[0];
            n227ContratoId = H004V2_n227ContratoId[0];
            A361ContratoComVigencia = H004V2_A361ContratoComVigencia[0];
            n361ContratoComVigencia = H004V2_n361ContratoComVigencia[0];
            A363ContratoDataFinal = H004V2_A363ContratoDataFinal[0];
            n363ContratoDataFinal = H004V2_n363ContratoDataFinal[0];
            A239AssinaturaStatus = H004V2_A239AssinaturaStatus[0];
            n239AssinaturaStatus = H004V2_n239AssinaturaStatus[0];
            A238AssinaturaId = H004V2_A238AssinaturaId[0];
            A361ContratoComVigencia = H004V2_A361ContratoComVigencia[0];
            n361ContratoComVigencia = H004V2_n361ContratoComVigencia[0];
            A363ContratoDataFinal = H004V2_A363ContratoDataFinal[0];
            n363ContratoDataFinal = H004V2_n363ContratoDataFinal[0];
            if ( ( StringUtil.StrCmp(A239AssinaturaStatus, "ASSINADO") == 0 ) && ( ( DateTimeUtil.ResetTime ( A363ContratoDataFinal ) >= DateTimeUtil.ResetTime ( Gx_date ) ) || ! A361ContratoComVigencia ) )
            {
               AV31CardContratosVigentes_Value = (int)(AV31CardContratosVigentes_Value+1);
               AssignAttri("", false, "AV31CardContratosVigentes_Value", StringUtil.LTrimStr( (decimal)(AV31CardContratosVigentes_Value), 8, 0));
            }
            if ( ( StringUtil.StrCmp(A239AssinaturaStatus, "ASSINADO") == 0 ) && ( DateTimeUtil.ResetTime ( A363ContratoDataFinal ) <= DateTimeUtil.ResetTime ( AV32Data ) ) && A361ContratoComVigencia )
            {
               AV30CardContratosProximoVencimento_Value = (int)(AV30CardContratosProximoVencimento_Value+1);
               AssignAttri("", false, "AV30CardContratosProximoVencimento_Value", StringUtil.LTrimStr( (decimal)(AV30CardContratosProximoVencimento_Value), 8, 0));
            }
            if ( ( StringUtil.StrCmp(A239AssinaturaStatus, "ENVIADO") == 0 ) && ( ( DateTimeUtil.ResetTime ( A363ContratoDataFinal ) >= DateTimeUtil.ResetTime ( Gx_date ) ) || ! A361ContratoComVigencia ) )
            {
               AV29CardContratosAssinando_Value = (int)(AV29CardContratosAssinando_Value+1);
               AssignAttri("", false, "AV29CardContratosAssinando_Value", StringUtil.LTrimStr( (decimal)(AV29CardContratosAssinando_Value), 8, 0));
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         Qv_Objectcall = "[ \""+"query"+"\", \""+StringUtil.JSONEncode( "QvTotalContratoAssinadosPorMes")+"\", \""+StringUtil.JSONEncode( StringUtil.Str( (decimal)(DateTimeUtil.Year( Gx_date)), 9, 0))+"\" ]";
         ucQv.SendProperty(context, "", false, Qv_Internalname, "Object", Qv_Objectcall);
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wcwcassinaturas = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcwcassinaturas_Component), StringUtil.Lower( "WcAssinaturas")) != 0 )
         {
            WebComp_Wcwcassinaturas = getWebComponent(GetType(), "GeneXus.Programs", "wcassinaturas", new Object[] {context} );
            WebComp_Wcwcassinaturas.ComponentInit();
            WebComp_Wcwcassinaturas.Name = "WcAssinaturas";
            WebComp_Wcwcassinaturas_Component = "WcAssinaturas";
         }
         if ( StringUtil.Len( WebComp_Wcwcassinaturas_Component) != 0 )
         {
            WebComp_Wcwcassinaturas.setjustcreated();
            WebComp_Wcwcassinaturas.componentprepare(new Object[] {(string)"W0057",(string)""});
            WebComp_Wcwcassinaturas.componentbind(new Object[] {});
         }
      }

      protected void E124V2( )
      {
         /* Cardcontratosvigentes_maintable_Click Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "assinaturaww"+UrlEncode(StringUtil.RTrim("ASSINADO")) + "," + UrlEncode(StringUtil.BoolToStr(true));
         CallWebObject(formatLink("assinaturaww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E134V2( )
      {
         /* Cardcontratosassinando_maintable_Click Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "assinaturaww"+UrlEncode(StringUtil.RTrim("ENVIADO")) + "," + UrlEncode(StringUtil.BoolToStr(true));
         CallWebObject(formatLink("assinaturaww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E144V2( )
      {
         /* Cardcontratosproximovencimento_maintable_Click Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "assinaturaww"+UrlEncode(StringUtil.RTrim("ASSINADO")) + "," + UrlEncode(StringUtil.BoolToStr(false));
         CallWebObject(formatLink("assinaturaww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void nextLoad( )
      {
      }

      protected void E154V2( )
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
         PA4V2( ) ;
         WS4V2( ) ;
         WE4V2( ) ;
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
         if ( ! ( WebComp_Wcwcassinaturas == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcwcassinaturas_Component) != 0 )
            {
               WebComp_Wcwcassinaturas.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019245990", true, true);
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
         context.AddJavascriptSource("contratos.js", "?202561019245991", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblCardcontratosvigentes_icon_Internalname = "CARDCONTRATOSVIGENTES_ICON";
         lblCardcontratosvigentes_description_Internalname = "CARDCONTRATOSVIGENTES_DESCRIPTION";
         edtavCardcontratosvigentes_value_Internalname = "vCARDCONTRATOSVIGENTES_VALUE";
         divCardcontratosvigentes_tableinfo_Internalname = "CARDCONTRATOSVIGENTES_TABLEINFO";
         divCardcontratosvigentes_maintable_Internalname = "CARDCONTRATOSVIGENTES_MAINTABLE";
         Dvpanel_cardcontratosvigentes_maintable_Internalname = "DVPANEL_CARDCONTRATOSVIGENTES_MAINTABLE";
         lblCardcontratosproximovencimento_icon_Internalname = "CARDCONTRATOSPROXIMOVENCIMENTO_ICON";
         lblCardcontratosproximovencimento_description_Internalname = "CARDCONTRATOSPROXIMOVENCIMENTO_DESCRIPTION";
         edtavCardcontratosproximovencimento_value_Internalname = "vCARDCONTRATOSPROXIMOVENCIMENTO_VALUE";
         divCardcontratosproximovencimento_tableinfo_Internalname = "CARDCONTRATOSPROXIMOVENCIMENTO_TABLEINFO";
         divCardcontratosproximovencimento_maintable_Internalname = "CARDCONTRATOSPROXIMOVENCIMENTO_MAINTABLE";
         Dvpanel_cardcontratosproximovencimento_maintable_Internalname = "DVPANEL_CARDCONTRATOSPROXIMOVENCIMENTO_MAINTABLE";
         lblCardcontratosassinando_icon_Internalname = "CARDCONTRATOSASSINANDO_ICON";
         lblCardcontratosassinando_description_Internalname = "CARDCONTRATOSASSINANDO_DESCRIPTION";
         edtavCardcontratosassinando_value_Internalname = "vCARDCONTRATOSASSINANDO_VALUE";
         divCardcontratosassinando_tableinfo_Internalname = "CARDCONTRATOSASSINANDO_TABLEINFO";
         divCardcontratosassinando_maintable_Internalname = "CARDCONTRATOSASSINANDO_MAINTABLE";
         Dvpanel_cardcontratosassinando_maintable_Internalname = "DVPANEL_CARDCONTRATOSASSINANDO_MAINTABLE";
         divTablecards_Internalname = "TABLECARDS";
         Qv_Internalname = "QV";
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
         Qv_Title = "";
         edtavCardcontratosassinando_value_Jsonclick = "";
         edtavCardcontratosassinando_value_Enabled = 1;
         edtavCardcontratosproximovencimento_value_Jsonclick = "";
         edtavCardcontratosproximovencimento_value_Enabled = 1;
         edtavCardcontratosvigentes_value_Jsonclick = "";
         edtavCardcontratosvigentes_value_Enabled = 1;
         Qv_Objectcall = "";
         Dvpanel_cardcontratosassinando_maintable_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_cardcontratosassinando_maintable_Iconposition = "Right";
         Dvpanel_cardcontratosassinando_maintable_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_cardcontratosassinando_maintable_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_cardcontratosassinando_maintable_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_cardcontratosassinando_maintable_Title = "";
         Dvpanel_cardcontratosassinando_maintable_Cls = "PanelNoHeader";
         Dvpanel_cardcontratosassinando_maintable_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_cardcontratosassinando_maintable_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_cardcontratosassinando_maintable_Width = "100%";
         Dvpanel_cardcontratosproximovencimento_maintable_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_cardcontratosproximovencimento_maintable_Iconposition = "Right";
         Dvpanel_cardcontratosproximovencimento_maintable_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_cardcontratosproximovencimento_maintable_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_cardcontratosproximovencimento_maintable_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_cardcontratosproximovencimento_maintable_Title = "";
         Dvpanel_cardcontratosproximovencimento_maintable_Cls = "PanelNoHeader";
         Dvpanel_cardcontratosproximovencimento_maintable_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_cardcontratosproximovencimento_maintable_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_cardcontratosproximovencimento_maintable_Width = "100%";
         Dvpanel_cardcontratosvigentes_maintable_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_cardcontratosvigentes_maintable_Iconposition = "Right";
         Dvpanel_cardcontratosvigentes_maintable_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_cardcontratosvigentes_maintable_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_cardcontratosvigentes_maintable_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_cardcontratosvigentes_maintable_Title = "";
         Dvpanel_cardcontratosvigentes_maintable_Cls = "PanelNoHeader";
         Dvpanel_cardcontratosvigentes_maintable_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_cardcontratosvigentes_maintable_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_cardcontratosvigentes_maintable_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Contratos";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV30CardContratosProximoVencimento_Value","fld":"vCARDCONTRATOSPROXIMOVENCIMENTO_VALUE","pic":"ZZ,ZZZ,ZZ9","type":"int"},{"av":"AV29CardContratosAssinando_Value","fld":"vCARDCONTRATOSASSINANDO_VALUE","pic":"ZZ,ZZZ,ZZ9","type":"int"}]}""");
         setEventMetadata("CARDCONTRATOSVIGENTES_MAINTABLE.CLICK","""{"handler":"E124V2","iparms":[]}""");
         setEventMetadata("CARDCONTRATOSASSINANDO_MAINTABLE.CLICK","""{"handler":"E134V2","iparms":[]}""");
         setEventMetadata("CARDCONTRATOSPROXIMOVENCIMENTO_MAINTABLE.CLICK","""{"handler":"E144V2","iparms":[]}""");
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
         forbiddenHiddens = new GXProperties();
         AV14Elements = new GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element>( context, "Element", "GeneXus.Reporting");
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ucDvpanel_cardcontratosvigentes_maintable = new GXUserControl();
         lblCardcontratosvigentes_icon_Jsonclick = "";
         lblCardcontratosvigentes_description_Jsonclick = "";
         TempTags = "";
         ucDvpanel_cardcontratosproximovencimento_maintable = new GXUserControl();
         lblCardcontratosproximovencimento_icon_Jsonclick = "";
         lblCardcontratosproximovencimento_description_Jsonclick = "";
         ucDvpanel_cardcontratosassinando_maintable = new GXUserControl();
         lblCardcontratosassinando_icon_Jsonclick = "";
         lblCardcontratosassinando_description_Jsonclick = "";
         ucQv = new GXUserControl();
         WebComp_Wcwcassinaturas_Component = "";
         OldWcwcassinaturas = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         Gx_date = DateTime.MinValue;
         hsh = "";
         AV32Data = DateTime.MinValue;
         H004V2_A227ContratoId = new int[1] ;
         H004V2_n227ContratoId = new bool[] {false} ;
         H004V2_A361ContratoComVigencia = new bool[] {false} ;
         H004V2_n361ContratoComVigencia = new bool[] {false} ;
         H004V2_A363ContratoDataFinal = new DateTime[] {DateTime.MinValue} ;
         H004V2_n363ContratoDataFinal = new bool[] {false} ;
         H004V2_A239AssinaturaStatus = new string[] {""} ;
         H004V2_n239AssinaturaStatus = new bool[] {false} ;
         H004V2_A238AssinaturaId = new long[1] ;
         A363ContratoDataFinal = DateTime.MinValue;
         A239AssinaturaStatus = "";
         GXEncryptionTmp = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contratos__default(),
            new Object[][] {
                new Object[] {
               H004V2_A227ContratoId, H004V2_n227ContratoId, H004V2_A361ContratoComVigencia, H004V2_n361ContratoComVigencia, H004V2_A363ContratoDataFinal, H004V2_n363ContratoDataFinal, H004V2_A239AssinaturaStatus, H004V2_n239AssinaturaStatus, H004V2_A238AssinaturaId
               }
            }
         );
         WebComp_Wcwcassinaturas = new GeneXus.Http.GXNullWebComponent();
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
         edtavCardcontratosvigentes_value_Enabled = 0;
         edtavCardcontratosproximovencimento_value_Enabled = 0;
         edtavCardcontratosassinando_value_Enabled = 0;
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short AV15Parameters ;
      private short AV16ItemClickData ;
      private short AV17ItemDoubleClickData ;
      private short AV18DragAndDropData ;
      private short AV19FilterChangedData ;
      private short AV20ItemExpandData ;
      private short AV21ItemCollapseData ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int AV30CardContratosProximoVencimento_Value ;
      private int AV29CardContratosAssinando_Value ;
      private int AV31CardContratosVigentes_Value ;
      private int edtavCardcontratosvigentes_value_Enabled ;
      private int edtavCardcontratosproximovencimento_value_Enabled ;
      private int edtavCardcontratosassinando_value_Enabled ;
      private int A227ContratoId ;
      private int idxLst ;
      private long A238AssinaturaId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Dvpanel_cardcontratosvigentes_maintable_Width ;
      private string Dvpanel_cardcontratosvigentes_maintable_Cls ;
      private string Dvpanel_cardcontratosvigentes_maintable_Title ;
      private string Dvpanel_cardcontratosvigentes_maintable_Iconposition ;
      private string Dvpanel_cardcontratosproximovencimento_maintable_Width ;
      private string Dvpanel_cardcontratosproximovencimento_maintable_Cls ;
      private string Dvpanel_cardcontratosproximovencimento_maintable_Title ;
      private string Dvpanel_cardcontratosproximovencimento_maintable_Iconposition ;
      private string Dvpanel_cardcontratosassinando_maintable_Width ;
      private string Dvpanel_cardcontratosassinando_maintable_Cls ;
      private string Dvpanel_cardcontratosassinando_maintable_Title ;
      private string Dvpanel_cardcontratosassinando_maintable_Iconposition ;
      private string Qv_Objectcall ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTablecards_Internalname ;
      private string Dvpanel_cardcontratosvigentes_maintable_Internalname ;
      private string divCardcontratosvigentes_maintable_Internalname ;
      private string lblCardcontratosvigentes_icon_Internalname ;
      private string lblCardcontratosvigentes_icon_Jsonclick ;
      private string divCardcontratosvigentes_tableinfo_Internalname ;
      private string lblCardcontratosvigentes_description_Internalname ;
      private string lblCardcontratosvigentes_description_Jsonclick ;
      private string edtavCardcontratosvigentes_value_Internalname ;
      private string TempTags ;
      private string edtavCardcontratosvigentes_value_Jsonclick ;
      private string Dvpanel_cardcontratosproximovencimento_maintable_Internalname ;
      private string divCardcontratosproximovencimento_maintable_Internalname ;
      private string lblCardcontratosproximovencimento_icon_Internalname ;
      private string lblCardcontratosproximovencimento_icon_Jsonclick ;
      private string divCardcontratosproximovencimento_tableinfo_Internalname ;
      private string lblCardcontratosproximovencimento_description_Internalname ;
      private string lblCardcontratosproximovencimento_description_Jsonclick ;
      private string edtavCardcontratosproximovencimento_value_Internalname ;
      private string edtavCardcontratosproximovencimento_value_Jsonclick ;
      private string Dvpanel_cardcontratosassinando_maintable_Internalname ;
      private string divCardcontratosassinando_maintable_Internalname ;
      private string lblCardcontratosassinando_icon_Internalname ;
      private string lblCardcontratosassinando_icon_Jsonclick ;
      private string divCardcontratosassinando_tableinfo_Internalname ;
      private string lblCardcontratosassinando_description_Internalname ;
      private string lblCardcontratosassinando_description_Jsonclick ;
      private string edtavCardcontratosassinando_value_Internalname ;
      private string edtavCardcontratosassinando_value_Jsonclick ;
      private string Qv_Title ;
      private string Qv_Internalname ;
      private string WebComp_Wcwcassinaturas_Component ;
      private string OldWcwcassinaturas ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string hsh ;
      private string GXEncryptionTmp ;
      private DateTime Gx_date ;
      private DateTime AV32Data ;
      private DateTime A363ContratoDataFinal ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Dvpanel_cardcontratosvigentes_maintable_Autowidth ;
      private bool Dvpanel_cardcontratosvigentes_maintable_Autoheight ;
      private bool Dvpanel_cardcontratosvigentes_maintable_Collapsible ;
      private bool Dvpanel_cardcontratosvigentes_maintable_Collapsed ;
      private bool Dvpanel_cardcontratosvigentes_maintable_Showcollapseicon ;
      private bool Dvpanel_cardcontratosvigentes_maintable_Autoscroll ;
      private bool Dvpanel_cardcontratosproximovencimento_maintable_Autowidth ;
      private bool Dvpanel_cardcontratosproximovencimento_maintable_Autoheight ;
      private bool Dvpanel_cardcontratosproximovencimento_maintable_Collapsible ;
      private bool Dvpanel_cardcontratosproximovencimento_maintable_Collapsed ;
      private bool Dvpanel_cardcontratosproximovencimento_maintable_Showcollapseicon ;
      private bool Dvpanel_cardcontratosproximovencimento_maintable_Autoscroll ;
      private bool Dvpanel_cardcontratosassinando_maintable_Autowidth ;
      private bool Dvpanel_cardcontratosassinando_maintable_Autoheight ;
      private bool Dvpanel_cardcontratosassinando_maintable_Collapsible ;
      private bool Dvpanel_cardcontratosassinando_maintable_Collapsed ;
      private bool Dvpanel_cardcontratosassinando_maintable_Showcollapseicon ;
      private bool Dvpanel_cardcontratosassinando_maintable_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n227ContratoId ;
      private bool A361ContratoComVigencia ;
      private bool n361ContratoComVigencia ;
      private bool n363ContratoDataFinal ;
      private bool n239AssinaturaStatus ;
      private bool bDynCreated_Wcwcassinaturas ;
      private string A239AssinaturaStatus ;
      private GXWebComponent WebComp_Wcwcassinaturas ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_cardcontratosvigentes_maintable ;
      private GXUserControl ucDvpanel_cardcontratosproximovencimento_maintable ;
      private GXUserControl ucDvpanel_cardcontratosassinando_maintable ;
      private GXUserControl ucQv ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element> AV14Elements ;
      private IDataStoreProvider pr_default ;
      private int[] H004V2_A227ContratoId ;
      private bool[] H004V2_n227ContratoId ;
      private bool[] H004V2_A361ContratoComVigencia ;
      private bool[] H004V2_n361ContratoComVigencia ;
      private DateTime[] H004V2_A363ContratoDataFinal ;
      private bool[] H004V2_n363ContratoDataFinal ;
      private string[] H004V2_A239AssinaturaStatus ;
      private bool[] H004V2_n239AssinaturaStatus ;
      private long[] H004V2_A238AssinaturaId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class contratos__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH004V2;
          prmH004V2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H004V2", "SELECT T1.ContratoId, T2.ContratoComVigencia, T2.ContratoDataFinal, T1.AssinaturaStatus, T1.AssinaturaId FROM (Assinatura T1 LEFT JOIN Contrato T2 ON T2.ContratoId = T1.ContratoId) ORDER BY T1.AssinaturaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004V2,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((long[]) buf[8])[0] = rslt.getLong(5);
                return;
       }
    }

 }

}
