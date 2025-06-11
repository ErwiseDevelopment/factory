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
   public class homec : GXDataArea
   {
      public homec( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public homec( IGxContext context )
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
         PA452( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START452( ) ;
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
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("homec") +"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, "vVISIBLE", AV24Visible);
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Width", StringUtil.RTrim( Dvpanel_tablechart1_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Autowidth", StringUtil.BoolToStr( Dvpanel_tablechart1_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Autoheight", StringUtil.BoolToStr( Dvpanel_tablechart1_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Cls", StringUtil.RTrim( Dvpanel_tablechart1_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Title", StringUtil.RTrim( Dvpanel_tablechart1_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Collapsible", StringUtil.BoolToStr( Dvpanel_tablechart1_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Collapsed", StringUtil.BoolToStr( Dvpanel_tablechart1_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tablechart1_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Iconposition", StringUtil.RTrim( Dvpanel_tablechart1_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Autoscroll", StringUtil.BoolToStr( Dvpanel_tablechart1_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART3_Width", StringUtil.RTrim( Dvpanel_tablechart3_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART3_Autowidth", StringUtil.BoolToStr( Dvpanel_tablechart3_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART3_Autoheight", StringUtil.BoolToStr( Dvpanel_tablechart3_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART3_Cls", StringUtil.RTrim( Dvpanel_tablechart3_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART3_Title", StringUtil.RTrim( Dvpanel_tablechart3_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART3_Collapsible", StringUtil.BoolToStr( Dvpanel_tablechart3_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART3_Collapsed", StringUtil.BoolToStr( Dvpanel_tablechart3_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART3_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tablechart3_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART3_Iconposition", StringUtil.RTrim( Dvpanel_tablechart3_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART3_Autoscroll", StringUtil.BoolToStr( Dvpanel_tablechart3_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Width", StringUtil.RTrim( Dvpanel_tablechart4_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Autowidth", StringUtil.BoolToStr( Dvpanel_tablechart4_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Autoheight", StringUtil.BoolToStr( Dvpanel_tablechart4_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Cls", StringUtil.RTrim( Dvpanel_tablechart4_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Title", StringUtil.RTrim( Dvpanel_tablechart4_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Collapsible", StringUtil.BoolToStr( Dvpanel_tablechart4_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Collapsed", StringUtil.BoolToStr( Dvpanel_tablechart4_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tablechart4_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Iconposition", StringUtil.RTrim( Dvpanel_tablechart4_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Autoscroll", StringUtil.BoolToStr( Dvpanel_tablechart4_Autoscroll));
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
            WE452( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT452( ) ;
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
         return formatLink("homec")  ;
      }

      public override string GetPgmname( )
      {
         return "HomeC" ;
      }

      public override string GetPgmdesc( )
      {
         return "Inicio" ;
      }

      protected void WB450( )
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
            GxWebStd.gx_div_start( context, divTableshowvalue_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table1_12_452( true) ;
         }
         else
         {
            wb_table1_12_452( false) ;
         }
         return  ;
      }

      protected void wb_table1_12_452e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecards_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-md-7 col-lg-8 CellMarginTop", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tablechart1.SetProperty("Width", Dvpanel_tablechart1_Width);
            ucDvpanel_tablechart1.SetProperty("AutoWidth", Dvpanel_tablechart1_Autowidth);
            ucDvpanel_tablechart1.SetProperty("AutoHeight", Dvpanel_tablechart1_Autoheight);
            ucDvpanel_tablechart1.SetProperty("Cls", Dvpanel_tablechart1_Cls);
            ucDvpanel_tablechart1.SetProperty("Title", Dvpanel_tablechart1_Title);
            ucDvpanel_tablechart1.SetProperty("Collapsible", Dvpanel_tablechart1_Collapsible);
            ucDvpanel_tablechart1.SetProperty("Collapsed", Dvpanel_tablechart1_Collapsed);
            ucDvpanel_tablechart1.SetProperty("ShowCollapseIcon", Dvpanel_tablechart1_Showcollapseicon);
            ucDvpanel_tablechart1.SetProperty("IconPosition", Dvpanel_tablechart1_Iconposition);
            ucDvpanel_tablechart1.SetProperty("AutoScroll", Dvpanel_tablechart1_Autoscroll);
            ucDvpanel_tablechart1.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tablechart1_Internalname, "DVPANEL_TABLECHART1Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLECHART1Container"+"TableChart1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablechart1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucUtchartsmootharea.SetProperty("Elements", AV14Elements);
            ucUtchartsmootharea.SetProperty("Parameters", AV15Parameters);
            ucUtchartsmootharea.SetProperty("Title", Utchartsmootharea_Title);
            ucUtchartsmootharea.SetProperty("ItemClickData", AV16ItemClickData);
            ucUtchartsmootharea.SetProperty("ItemDoubleClickData", AV17ItemDoubleClickData);
            ucUtchartsmootharea.SetProperty("DragAndDropData", AV18DragAndDropData);
            ucUtchartsmootharea.SetProperty("FilterChangedData", AV19FilterChangedData);
            ucUtchartsmootharea.SetProperty("ItemExpandData", AV20ItemExpandData);
            ucUtchartsmootharea.SetProperty("ItemCollapseData", AV21ItemCollapseData);
            ucUtchartsmootharea.Render(context, "queryviewer", Utchartsmootharea_Internalname, "UTCHARTSMOOTHAREAContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-md-5 CellMarginTop", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tablechart3.SetProperty("Width", Dvpanel_tablechart3_Width);
            ucDvpanel_tablechart3.SetProperty("AutoWidth", Dvpanel_tablechart3_Autowidth);
            ucDvpanel_tablechart3.SetProperty("AutoHeight", Dvpanel_tablechart3_Autoheight);
            ucDvpanel_tablechart3.SetProperty("Cls", Dvpanel_tablechart3_Cls);
            ucDvpanel_tablechart3.SetProperty("Title", Dvpanel_tablechart3_Title);
            ucDvpanel_tablechart3.SetProperty("Collapsible", Dvpanel_tablechart3_Collapsible);
            ucDvpanel_tablechart3.SetProperty("Collapsed", Dvpanel_tablechart3_Collapsed);
            ucDvpanel_tablechart3.SetProperty("ShowCollapseIcon", Dvpanel_tablechart3_Showcollapseicon);
            ucDvpanel_tablechart3.SetProperty("IconPosition", Dvpanel_tablechart3_Iconposition);
            ucDvpanel_tablechart3.SetProperty("AutoScroll", Dvpanel_tablechart3_Autoscroll);
            ucDvpanel_tablechart3.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tablechart3_Internalname, "DVPANEL_TABLECHART3Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLECHART3Container"+"TableChart3"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablechart3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucUtchartdoughnut.SetProperty("Elements", AV14Elements);
            ucUtchartdoughnut.SetProperty("Parameters", AV15Parameters);
            ucUtchartdoughnut.SetProperty("Title", Utchartdoughnut_Title);
            ucUtchartdoughnut.SetProperty("ItemClickData", AV16ItemClickData);
            ucUtchartdoughnut.SetProperty("ItemDoubleClickData", AV17ItemDoubleClickData);
            ucUtchartdoughnut.SetProperty("DragAndDropData", AV18DragAndDropData);
            ucUtchartdoughnut.SetProperty("FilterChangedData", AV19FilterChangedData);
            ucUtchartdoughnut.SetProperty("ItemExpandData", AV20ItemExpandData);
            ucUtchartdoughnut.SetProperty("ItemCollapseData", AV21ItemCollapseData);
            ucUtchartdoughnut.Render(context, "queryviewer", Utchartdoughnut_Internalname, "UTCHARTDOUGHNUTContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-md-7 CellMarginTop", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tablechart4.SetProperty("Width", Dvpanel_tablechart4_Width);
            ucDvpanel_tablechart4.SetProperty("AutoWidth", Dvpanel_tablechart4_Autowidth);
            ucDvpanel_tablechart4.SetProperty("AutoHeight", Dvpanel_tablechart4_Autoheight);
            ucDvpanel_tablechart4.SetProperty("Cls", Dvpanel_tablechart4_Cls);
            ucDvpanel_tablechart4.SetProperty("Title", Dvpanel_tablechart4_Title);
            ucDvpanel_tablechart4.SetProperty("Collapsible", Dvpanel_tablechart4_Collapsible);
            ucDvpanel_tablechart4.SetProperty("Collapsed", Dvpanel_tablechart4_Collapsed);
            ucDvpanel_tablechart4.SetProperty("ShowCollapseIcon", Dvpanel_tablechart4_Showcollapseicon);
            ucDvpanel_tablechart4.SetProperty("IconPosition", Dvpanel_tablechart4_Iconposition);
            ucDvpanel_tablechart4.SetProperty("AutoScroll", Dvpanel_tablechart4_Autoscroll);
            ucDvpanel_tablechart4.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tablechart4_Internalname, "DVPANEL_TABLECHART4Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLECHART4Container"+"TableChart4"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablechart4_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucUtchartsmoothline.SetProperty("Elements", AV14Elements);
            ucUtchartsmoothline.SetProperty("Parameters", AV15Parameters);
            ucUtchartsmoothline.SetProperty("Title", Utchartsmoothline_Title);
            ucUtchartsmoothline.SetProperty("ItemClickData", AV16ItemClickData);
            ucUtchartsmoothline.SetProperty("ItemDoubleClickData", AV17ItemDoubleClickData);
            ucUtchartsmoothline.SetProperty("DragAndDropData", AV18DragAndDropData);
            ucUtchartsmoothline.SetProperty("FilterChangedData", AV19FilterChangedData);
            ucUtchartsmoothline.SetProperty("ItemExpandData", AV20ItemExpandData);
            ucUtchartsmoothline.SetProperty("ItemCollapseData", AV21ItemCollapseData);
            ucUtchartsmoothline.Render(context, "queryviewer", Utchartsmoothline_Internalname, "UTCHARTSMOOTHLINEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
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

      protected void START452( )
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
         Form.Meta.addItem("description", "Inicio", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP450( ) ;
      }

      protected void WS452( )
      {
         START452( ) ;
         EVT452( ) ;
      }

      protected void EVT452( )
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
                              E11452 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E12452 ();
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
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE452( )
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

      protected void PA452( )
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
         RF452( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF452( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E12452 ();
            WB450( ) ;
         }
      }

      protected void send_integrity_lvl_hashes452( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP450( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11452 ();
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
            AV24Visible = StringUtil.StrToBool( cgiGet( "vVISIBLE"));
            Dvpanel_tablechart1_Width = cgiGet( "DVPANEL_TABLECHART1_Width");
            Dvpanel_tablechart1_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Autowidth"));
            Dvpanel_tablechart1_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Autoheight"));
            Dvpanel_tablechart1_Cls = cgiGet( "DVPANEL_TABLECHART1_Cls");
            Dvpanel_tablechart1_Title = cgiGet( "DVPANEL_TABLECHART1_Title");
            Dvpanel_tablechart1_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Collapsible"));
            Dvpanel_tablechart1_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Collapsed"));
            Dvpanel_tablechart1_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Showcollapseicon"));
            Dvpanel_tablechart1_Iconposition = cgiGet( "DVPANEL_TABLECHART1_Iconposition");
            Dvpanel_tablechart1_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Autoscroll"));
            Dvpanel_tablechart3_Width = cgiGet( "DVPANEL_TABLECHART3_Width");
            Dvpanel_tablechart3_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART3_Autowidth"));
            Dvpanel_tablechart3_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART3_Autoheight"));
            Dvpanel_tablechart3_Cls = cgiGet( "DVPANEL_TABLECHART3_Cls");
            Dvpanel_tablechart3_Title = cgiGet( "DVPANEL_TABLECHART3_Title");
            Dvpanel_tablechart3_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART3_Collapsible"));
            Dvpanel_tablechart3_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART3_Collapsed"));
            Dvpanel_tablechart3_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART3_Showcollapseicon"));
            Dvpanel_tablechart3_Iconposition = cgiGet( "DVPANEL_TABLECHART3_Iconposition");
            Dvpanel_tablechart3_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART3_Autoscroll"));
            Dvpanel_tablechart4_Width = cgiGet( "DVPANEL_TABLECHART4_Width");
            Dvpanel_tablechart4_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART4_Autowidth"));
            Dvpanel_tablechart4_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART4_Autoheight"));
            Dvpanel_tablechart4_Cls = cgiGet( "DVPANEL_TABLECHART4_Cls");
            Dvpanel_tablechart4_Title = cgiGet( "DVPANEL_TABLECHART4_Title");
            Dvpanel_tablechart4_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART4_Collapsible"));
            Dvpanel_tablechart4_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART4_Collapsed"));
            Dvpanel_tablechart4_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART4_Showcollapseicon"));
            Dvpanel_tablechart4_Iconposition = cgiGet( "DVPANEL_TABLECHART4_Iconposition");
            Dvpanel_tablechart4_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART4_Autoscroll"));
            /* Read variables values. */
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
         E11452 ();
         if (returnInSub) return;
      }

      protected void E11452( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_objcol_SdtHomeSampleData_HomeSampleDataItem1 = AV5HomeSampleData;
         new GeneXus.Programs.wwpbaseobjects.gethomesampledata(context ).execute( out  GXt_objcol_SdtHomeSampleData_HomeSampleDataItem1) ;
         AV5HomeSampleData = GXt_objcol_SdtHomeSampleData_HomeSampleDataItem1;
         AV13Axis = new GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element(context);
         AV13Axis.gxTpr_Name = "ProductStatus";
         AV13Axis.gxTpr_Visible = "No";
         AV12Axes.Add(AV13Axis, 0);
         AV13Axis = new GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element(context);
         AV13Axis.gxTpr_Name = "Check";
         AV13Axis.gxTpr_Visible = "No";
         AV12Axes.Add(AV13Axis, 0);
         AV25Valor = "R$ 1.525,00";
         AV26ValorReceber = "R$ 56.526,00";
         AV27ValorTeste = "R$ 198.526,00";
         AV28ValorTeste2 = "R$ 181.265.526,00";
         /* Execute user subroutine: 'SHOWHIDEEYE' */
         S112 ();
         if (returnInSub) return;
      }

      protected void S112( )
      {
         /* 'SHOWHIDEEYE' Routine */
         returnInSub = false;
         if ( AV24Visible )
         {
            lblVisualizar_Visible = 1;
            AssignProp("", false, lblVisualizar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblVisualizar_Visible), 5, 0), true);
            lblVisualizaraberto_Visible = 0;
            AssignProp("", false, lblVisualizaraberto_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblVisualizaraberto_Visible), 5, 0), true);
            lblLblshow_Caption = "Esconder valores";
            AssignProp("", false, lblLblshow_Internalname, "Caption", lblLblshow_Caption, true);
         }
         else
         {
            lblVisualizar_Visible = 0;
            AssignProp("", false, lblVisualizar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblVisualizar_Visible), 5, 0), true);
            lblVisualizaraberto_Visible = 1;
            AssignProp("", false, lblVisualizaraberto_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblVisualizaraberto_Visible), 5, 0), true);
            lblLblshow_Caption = "Exibir valores";
            AssignProp("", false, lblLblshow_Internalname, "Caption", lblLblshow_Caption, true);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E12452( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_12_452( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedlblshow_Internalname, tblTablemergedlblshow_Internalname, "", "TableMerged", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblshow_Internalname, lblLblshow_Caption, "", "", lblLblshow_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockNotAuthorized", 0, "", 1, 1, 0, 0, "HLP_HomeC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblVisualizar_Internalname, "<i class='fas fa-eye-slash' title='Visualizar valores' style='font-size: 24px'></i>", "", "", lblVisualizar_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", lblVisualizar_Visible, 1, 0, 2, "HLP_HomeC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblVisualizaraberto_Internalname, "<i class='fas fa-eye' title='Visualizar valores' style='font-size: 24px'></i>", "", "", lblVisualizaraberto_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", lblVisualizaraberto_Visible, 1, 0, 2, "HLP_HomeC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_12_452e( true) ;
         }
         else
         {
            wb_table1_12_452e( false) ;
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
         PA452( ) ;
         WS452( ) ;
         WE452( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101924178", true, true);
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
         context.AddJavascriptSource("homec.js", "?20256101924179", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
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
         lblLblshow_Internalname = "LBLSHOW";
         lblVisualizar_Internalname = "VISUALIZAR";
         lblVisualizaraberto_Internalname = "VISUALIZARABERTO";
         tblTablemergedlblshow_Internalname = "TABLEMERGEDLBLSHOW";
         divTableshowvalue_Internalname = "TABLESHOWVALUE";
         divTablecards_Internalname = "TABLECARDS";
         Utchartsmootharea_Internalname = "UTCHARTSMOOTHAREA";
         divTablechart1_Internalname = "TABLECHART1";
         Dvpanel_tablechart1_Internalname = "DVPANEL_TABLECHART1";
         Utchartdoughnut_Internalname = "UTCHARTDOUGHNUT";
         divTablechart3_Internalname = "TABLECHART3";
         Dvpanel_tablechart3_Internalname = "DVPANEL_TABLECHART3";
         Utchartsmoothline_Internalname = "UTCHARTSMOOTHLINE";
         divTablechart4_Internalname = "TABLECHART4";
         Dvpanel_tablechart4_Internalname = "DVPANEL_TABLECHART4";
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
         lblVisualizaraberto_Visible = 1;
         lblVisualizar_Visible = 1;
         lblLblshow_Caption = "Mostrar valores";
         Utchartsmoothline_Title = "";
         Utchartdoughnut_Title = "";
         Utchartsmootharea_Title = "";
         Dvpanel_tablechart4_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tablechart4_Iconposition = "Right";
         Dvpanel_tablechart4_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tablechart4_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tablechart4_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_tablechart4_Title = "Task Board";
         Dvpanel_tablechart4_Cls = "PanelCard Panel_BaseColor";
         Dvpanel_tablechart4_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tablechart4_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tablechart4_Width = "100%";
         Dvpanel_tablechart3_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tablechart3_Iconposition = "Right";
         Dvpanel_tablechart3_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tablechart3_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tablechart3_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_tablechart3_Title = "Orders";
         Dvpanel_tablechart3_Cls = "PanelCard Panel_Warning";
         Dvpanel_tablechart3_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tablechart3_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tablechart3_Width = "100%";
         Dvpanel_tablechart1_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tablechart1_Iconposition = "Right";
         Dvpanel_tablechart1_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tablechart1_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tablechart1_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_tablechart1_Title = "Task Board";
         Dvpanel_tablechart1_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_tablechart1_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tablechart1_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tablechart1_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Inicio";
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
         AV14Elements = new GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element>( context, "Element", "GeneXus.Reporting");
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ucDvpanel_tablechart1 = new GXUserControl();
         ucUtchartsmootharea = new GXUserControl();
         ucDvpanel_tablechart3 = new GXUserControl();
         ucUtchartdoughnut = new GXUserControl();
         ucDvpanel_tablechart4 = new GXUserControl();
         ucUtchartsmoothline = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV5HomeSampleData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem>( context, "HomeSampleDataItem", "Factory21");
         GXt_objcol_SdtHomeSampleData_HomeSampleDataItem1 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem>( context, "HomeSampleDataItem", "Factory21");
         AV13Axis = new GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element(context);
         AV12Axes = new GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element>( context, "Element", "GeneXus.Reporting");
         AV25Valor = "";
         AV26ValorReceber = "";
         AV27ValorTeste = "";
         AV28ValorTeste2 = "";
         sStyleString = "";
         lblLblshow_Jsonclick = "";
         lblVisualizar_Jsonclick = "";
         lblVisualizaraberto_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         /* GeneXus formulas. */
      }

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
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int lblVisualizar_Visible ;
      private int lblVisualizaraberto_Visible ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Dvpanel_tablechart1_Width ;
      private string Dvpanel_tablechart1_Cls ;
      private string Dvpanel_tablechart1_Title ;
      private string Dvpanel_tablechart1_Iconposition ;
      private string Dvpanel_tablechart3_Width ;
      private string Dvpanel_tablechart3_Cls ;
      private string Dvpanel_tablechart3_Title ;
      private string Dvpanel_tablechart3_Iconposition ;
      private string Dvpanel_tablechart4_Width ;
      private string Dvpanel_tablechart4_Cls ;
      private string Dvpanel_tablechart4_Title ;
      private string Dvpanel_tablechart4_Iconposition ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTableshowvalue_Internalname ;
      private string divTablecards_Internalname ;
      private string Dvpanel_tablechart1_Internalname ;
      private string divTablechart1_Internalname ;
      private string Utchartsmootharea_Title ;
      private string Utchartsmootharea_Internalname ;
      private string Dvpanel_tablechart3_Internalname ;
      private string divTablechart3_Internalname ;
      private string Utchartdoughnut_Title ;
      private string Utchartdoughnut_Internalname ;
      private string Dvpanel_tablechart4_Internalname ;
      private string divTablechart4_Internalname ;
      private string Utchartsmoothline_Title ;
      private string Utchartsmoothline_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string lblVisualizar_Internalname ;
      private string lblVisualizaraberto_Internalname ;
      private string lblLblshow_Caption ;
      private string lblLblshow_Internalname ;
      private string sStyleString ;
      private string tblTablemergedlblshow_Internalname ;
      private string lblLblshow_Jsonclick ;
      private string lblVisualizar_Jsonclick ;
      private string lblVisualizaraberto_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV24Visible ;
      private bool Dvpanel_tablechart1_Autowidth ;
      private bool Dvpanel_tablechart1_Autoheight ;
      private bool Dvpanel_tablechart1_Collapsible ;
      private bool Dvpanel_tablechart1_Collapsed ;
      private bool Dvpanel_tablechart1_Showcollapseicon ;
      private bool Dvpanel_tablechart1_Autoscroll ;
      private bool Dvpanel_tablechart3_Autowidth ;
      private bool Dvpanel_tablechart3_Autoheight ;
      private bool Dvpanel_tablechart3_Collapsible ;
      private bool Dvpanel_tablechart3_Collapsed ;
      private bool Dvpanel_tablechart3_Showcollapseicon ;
      private bool Dvpanel_tablechart3_Autoscroll ;
      private bool Dvpanel_tablechart4_Autowidth ;
      private bool Dvpanel_tablechart4_Autoheight ;
      private bool Dvpanel_tablechart4_Collapsible ;
      private bool Dvpanel_tablechart4_Collapsed ;
      private bool Dvpanel_tablechart4_Showcollapseicon ;
      private bool Dvpanel_tablechart4_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV25Valor ;
      private string AV26ValorReceber ;
      private string AV27ValorTeste ;
      private string AV28ValorTeste2 ;
      private GXUserControl ucDvpanel_tablechart1 ;
      private GXUserControl ucUtchartsmootharea ;
      private GXUserControl ucDvpanel_tablechart3 ;
      private GXUserControl ucUtchartdoughnut ;
      private GXUserControl ucDvpanel_tablechart4 ;
      private GXUserControl ucUtchartsmoothline ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element> AV14Elements ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem> AV5HomeSampleData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem> GXt_objcol_SdtHomeSampleData_HomeSampleDataItem1 ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element AV13Axis ;
      private GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element> AV12Axes ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
