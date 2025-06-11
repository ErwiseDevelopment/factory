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
   public class seguranca : GXDataArea
   {
      public seguranca( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public seguranca( IGxContext context )
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
         PA4W2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START4W2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("seguranca") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDUSUARIOATIVO_MAINTABLE_Width", StringUtil.RTrim( Dvpanel_cardusuarioativo_maintable_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDUSUARIOATIVO_MAINTABLE_Autowidth", StringUtil.BoolToStr( Dvpanel_cardusuarioativo_maintable_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDUSUARIOATIVO_MAINTABLE_Autoheight", StringUtil.BoolToStr( Dvpanel_cardusuarioativo_maintable_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDUSUARIOATIVO_MAINTABLE_Cls", StringUtil.RTrim( Dvpanel_cardusuarioativo_maintable_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDUSUARIOATIVO_MAINTABLE_Title", StringUtil.RTrim( Dvpanel_cardusuarioativo_maintable_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDUSUARIOATIVO_MAINTABLE_Collapsible", StringUtil.BoolToStr( Dvpanel_cardusuarioativo_maintable_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDUSUARIOATIVO_MAINTABLE_Collapsed", StringUtil.BoolToStr( Dvpanel_cardusuarioativo_maintable_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDUSUARIOATIVO_MAINTABLE_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_cardusuarioativo_maintable_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDUSUARIOATIVO_MAINTABLE_Iconposition", StringUtil.RTrim( Dvpanel_cardusuarioativo_maintable_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDUSUARIOATIVO_MAINTABLE_Autoscroll", StringUtil.BoolToStr( Dvpanel_cardusuarioativo_maintable_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDINATIVO_MAINTABLE_Width", StringUtil.RTrim( Dvpanel_cardinativo_maintable_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDINATIVO_MAINTABLE_Autowidth", StringUtil.BoolToStr( Dvpanel_cardinativo_maintable_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDINATIVO_MAINTABLE_Autoheight", StringUtil.BoolToStr( Dvpanel_cardinativo_maintable_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDINATIVO_MAINTABLE_Cls", StringUtil.RTrim( Dvpanel_cardinativo_maintable_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDINATIVO_MAINTABLE_Title", StringUtil.RTrim( Dvpanel_cardinativo_maintable_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDINATIVO_MAINTABLE_Collapsible", StringUtil.BoolToStr( Dvpanel_cardinativo_maintable_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDINATIVO_MAINTABLE_Collapsed", StringUtil.BoolToStr( Dvpanel_cardinativo_maintable_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDINATIVO_MAINTABLE_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_cardinativo_maintable_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDINATIVO_MAINTABLE_Iconposition", StringUtil.RTrim( Dvpanel_cardinativo_maintable_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARDINATIVO_MAINTABLE_Autoscroll", StringUtil.BoolToStr( Dvpanel_cardinativo_maintable_Autoscroll));
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
         if ( ! ( WebComp_Wcsecuserlogww == null ) )
         {
            WebComp_Wcsecuserlogww.componentjscripts();
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
            WE4W2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT4W2( ) ;
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
         return formatLink("seguranca")  ;
      }

      public override string GetPgmname( )
      {
         return "Seguranca" ;
      }

      public override string GetPgmdesc( )
      {
         return "Segurança" ;
      }

      protected void WB4W0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellMarginTop", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_cardusuarioativo_maintable.SetProperty("Width", Dvpanel_cardusuarioativo_maintable_Width);
            ucDvpanel_cardusuarioativo_maintable.SetProperty("AutoWidth", Dvpanel_cardusuarioativo_maintable_Autowidth);
            ucDvpanel_cardusuarioativo_maintable.SetProperty("AutoHeight", Dvpanel_cardusuarioativo_maintable_Autoheight);
            ucDvpanel_cardusuarioativo_maintable.SetProperty("Cls", Dvpanel_cardusuarioativo_maintable_Cls);
            ucDvpanel_cardusuarioativo_maintable.SetProperty("Title", Dvpanel_cardusuarioativo_maintable_Title);
            ucDvpanel_cardusuarioativo_maintable.SetProperty("Collapsible", Dvpanel_cardusuarioativo_maintable_Collapsible);
            ucDvpanel_cardusuarioativo_maintable.SetProperty("Collapsed", Dvpanel_cardusuarioativo_maintable_Collapsed);
            ucDvpanel_cardusuarioativo_maintable.SetProperty("ShowCollapseIcon", Dvpanel_cardusuarioativo_maintable_Showcollapseicon);
            ucDvpanel_cardusuarioativo_maintable.SetProperty("IconPosition", Dvpanel_cardusuarioativo_maintable_Iconposition);
            ucDvpanel_cardusuarioativo_maintable.SetProperty("AutoScroll", Dvpanel_cardusuarioativo_maintable_Autoscroll);
            ucDvpanel_cardusuarioativo_maintable.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_cardusuarioativo_maintable_Internalname, "DVPANEL_CARDUSUARIOATIVO_MAINTABLEContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_CARDUSUARIOATIVO_MAINTABLEContainer"+"CardUsuarioAtivo_MainTable"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divCardusuarioativo_maintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 SimpleCardIconPadding", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCardusuarioativo_icon_Internalname, "<i class='ProgressCardIconBaseColor fas fa-user' style='font-size: 50px'></i>", "", "", lblCardusuarioativo_icon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_Seguranca.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCardusuarioativo_tableinfo_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;align-items:flex-end;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCardusuarioativo_description_Internalname, "Usuários", "", "", lblCardusuarioativo_description_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockDashboardDescriptionCard", 0, "", 1, 1, 0, 0, "HLP_Seguranca.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCardusuarioativo_value_Internalname, "Card Usuario Ativo_Value", "gx-form-item DashboardNumberCardLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCardusuarioativo_value_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30CardUsuarioAtivo_Value), 10, 0, ",", "")), StringUtil.LTrim( ((edtavCardusuarioativo_value_Enabled!=0) ? context.localUtil.Format( (decimal)(AV30CardUsuarioAtivo_Value), "ZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV30CardUsuarioAtivo_Value), "ZZ,ZZZ,ZZ9"))), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,24);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCardusuarioativo_value_Jsonclick, 0, "DashboardNumberCard", "", "", "", "", 1, edtavCardusuarioativo_value_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "KPINumericValue", "end", false, "", "HLP_Seguranca.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellMarginTop", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_cardinativo_maintable.SetProperty("Width", Dvpanel_cardinativo_maintable_Width);
            ucDvpanel_cardinativo_maintable.SetProperty("AutoWidth", Dvpanel_cardinativo_maintable_Autowidth);
            ucDvpanel_cardinativo_maintable.SetProperty("AutoHeight", Dvpanel_cardinativo_maintable_Autoheight);
            ucDvpanel_cardinativo_maintable.SetProperty("Cls", Dvpanel_cardinativo_maintable_Cls);
            ucDvpanel_cardinativo_maintable.SetProperty("Title", Dvpanel_cardinativo_maintable_Title);
            ucDvpanel_cardinativo_maintable.SetProperty("Collapsible", Dvpanel_cardinativo_maintable_Collapsible);
            ucDvpanel_cardinativo_maintable.SetProperty("Collapsed", Dvpanel_cardinativo_maintable_Collapsed);
            ucDvpanel_cardinativo_maintable.SetProperty("ShowCollapseIcon", Dvpanel_cardinativo_maintable_Showcollapseicon);
            ucDvpanel_cardinativo_maintable.SetProperty("IconPosition", Dvpanel_cardinativo_maintable_Iconposition);
            ucDvpanel_cardinativo_maintable.SetProperty("AutoScroll", Dvpanel_cardinativo_maintable_Autoscroll);
            ucDvpanel_cardinativo_maintable.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_cardinativo_maintable_Internalname, "DVPANEL_CARDINATIVO_MAINTABLEContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_CARDINATIVO_MAINTABLEContainer"+"CardInativo_MainTable"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divCardinativo_maintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 SimpleCardIconPadding", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCardinativo_icon_Internalname, "<i class='ProgressCardIconDanger fas fa-user-large-slash' style='font-size: 50px'></i>", "", "", lblCardinativo_icon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_Seguranca.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCardinativo_tableinfo_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;align-items:flex-end;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCardinativo_description_Internalname, "Inativos", "", "", lblCardinativo_description_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockDashboardDescriptionCard", 0, "", 1, 1, 0, 0, "HLP_Seguranca.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCardinativo_value_Internalname, "Card Inativo_Value", "gx-form-item DashboardNumberCardLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCardinativo_value_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33CardInativo_Value), 10, 0, ",", "")), StringUtil.LTrim( ((edtavCardinativo_value_Enabled!=0) ? context.localUtil.Format( (decimal)(AV33CardInativo_Value), "ZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV33CardInativo_Value), "ZZ,ZZZ,ZZ9"))), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCardinativo_value_Jsonclick, 0, "DashboardNumberCard", "", "", "", "", 1, edtavCardinativo_value_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "KPINumericValue", "end", false, "", "HLP_Seguranca.htm");
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
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, "Histórico de acessos", 1, 0, "px", 0, "px", "Group", "", "HLP_Seguranca.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablehistorico_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0045"+"", StringUtil.RTrim( WebComp_Wcsecuserlogww_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0045"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcsecuserlogww_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcsecuserlogww), StringUtil.Lower( WebComp_Wcsecuserlogww_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0045"+"");
                  }
                  WebComp_Wcsecuserlogww.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcsecuserlogww), StringUtil.Lower( WebComp_Wcsecuserlogww_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
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

      protected void START4W2( )
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
         Form.Meta.addItem("description", "Segurança", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4W0( ) ;
      }

      protected void WS4W2( )
      {
         START4W2( ) ;
         EVT4W2( ) ;
      }

      protected void EVT4W2( )
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
                              E114W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E124W2 ();
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
                        if ( nCmpId == 45 )
                        {
                           OldWcsecuserlogww = cgiGet( "W0045");
                           if ( ( StringUtil.Len( OldWcsecuserlogww) == 0 ) || ( StringUtil.StrCmp(OldWcsecuserlogww, WebComp_Wcsecuserlogww_Component) != 0 ) )
                           {
                              WebComp_Wcsecuserlogww = getWebComponent(GetType(), "GeneXus.Programs", OldWcsecuserlogww, new Object[] {context} );
                              WebComp_Wcsecuserlogww.ComponentInit();
                              WebComp_Wcsecuserlogww.Name = "OldWcsecuserlogww";
                              WebComp_Wcsecuserlogww_Component = OldWcsecuserlogww;
                           }
                           if ( StringUtil.Len( WebComp_Wcsecuserlogww_Component) != 0 )
                           {
                              WebComp_Wcsecuserlogww.componentprocess("W0045", "", sEvt);
                           }
                           WebComp_Wcsecuserlogww_Component = OldWcsecuserlogww;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE4W2( )
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

      protected void PA4W2( )
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
               GX_FocusControl = edtavCardusuarioativo_value_Internalname;
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
         RF4W2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavCardusuarioativo_value_Enabled = 0;
         AssignProp("", false, edtavCardusuarioativo_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCardusuarioativo_value_Enabled), 5, 0), true);
         edtavCardinativo_value_Enabled = 0;
         AssignProp("", false, edtavCardinativo_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCardinativo_value_Enabled), 5, 0), true);
      }

      protected void RF4W2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcsecuserlogww_Component) != 0 )
               {
                  WebComp_Wcsecuserlogww.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E124W2 ();
            WB4W0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes4W2( )
      {
      }

      protected void before_start_formulas( )
      {
         edtavCardusuarioativo_value_Enabled = 0;
         AssignProp("", false, edtavCardusuarioativo_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCardusuarioativo_value_Enabled), 5, 0), true);
         edtavCardinativo_value_Enabled = 0;
         AssignProp("", false, edtavCardinativo_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCardinativo_value_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4W0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E114W2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Dvpanel_cardusuarioativo_maintable_Width = cgiGet( "DVPANEL_CARDUSUARIOATIVO_MAINTABLE_Width");
            Dvpanel_cardusuarioativo_maintable_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDUSUARIOATIVO_MAINTABLE_Autowidth"));
            Dvpanel_cardusuarioativo_maintable_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDUSUARIOATIVO_MAINTABLE_Autoheight"));
            Dvpanel_cardusuarioativo_maintable_Cls = cgiGet( "DVPANEL_CARDUSUARIOATIVO_MAINTABLE_Cls");
            Dvpanel_cardusuarioativo_maintable_Title = cgiGet( "DVPANEL_CARDUSUARIOATIVO_MAINTABLE_Title");
            Dvpanel_cardusuarioativo_maintable_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDUSUARIOATIVO_MAINTABLE_Collapsible"));
            Dvpanel_cardusuarioativo_maintable_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDUSUARIOATIVO_MAINTABLE_Collapsed"));
            Dvpanel_cardusuarioativo_maintable_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDUSUARIOATIVO_MAINTABLE_Showcollapseicon"));
            Dvpanel_cardusuarioativo_maintable_Iconposition = cgiGet( "DVPANEL_CARDUSUARIOATIVO_MAINTABLE_Iconposition");
            Dvpanel_cardusuarioativo_maintable_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDUSUARIOATIVO_MAINTABLE_Autoscroll"));
            Dvpanel_cardinativo_maintable_Width = cgiGet( "DVPANEL_CARDINATIVO_MAINTABLE_Width");
            Dvpanel_cardinativo_maintable_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDINATIVO_MAINTABLE_Autowidth"));
            Dvpanel_cardinativo_maintable_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDINATIVO_MAINTABLE_Autoheight"));
            Dvpanel_cardinativo_maintable_Cls = cgiGet( "DVPANEL_CARDINATIVO_MAINTABLE_Cls");
            Dvpanel_cardinativo_maintable_Title = cgiGet( "DVPANEL_CARDINATIVO_MAINTABLE_Title");
            Dvpanel_cardinativo_maintable_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDINATIVO_MAINTABLE_Collapsible"));
            Dvpanel_cardinativo_maintable_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDINATIVO_MAINTABLE_Collapsed"));
            Dvpanel_cardinativo_maintable_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDINATIVO_MAINTABLE_Showcollapseicon"));
            Dvpanel_cardinativo_maintable_Iconposition = cgiGet( "DVPANEL_CARDINATIVO_MAINTABLE_Iconposition");
            Dvpanel_cardinativo_maintable_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_CARDINATIVO_MAINTABLE_Autoscroll"));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCardusuarioativo_value_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCardusuarioativo_value_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCARDUSUARIOATIVO_VALUE");
               GX_FocusControl = edtavCardusuarioativo_value_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV30CardUsuarioAtivo_Value = 0;
               AssignAttri("", false, "AV30CardUsuarioAtivo_Value", StringUtil.LTrimStr( (decimal)(AV30CardUsuarioAtivo_Value), 8, 0));
            }
            else
            {
               AV30CardUsuarioAtivo_Value = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCardusuarioativo_value_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV30CardUsuarioAtivo_Value", StringUtil.LTrimStr( (decimal)(AV30CardUsuarioAtivo_Value), 8, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCardinativo_value_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCardinativo_value_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCARDINATIVO_VALUE");
               GX_FocusControl = edtavCardinativo_value_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV33CardInativo_Value = 0;
               AssignAttri("", false, "AV33CardInativo_Value", StringUtil.LTrimStr( (decimal)(AV33CardInativo_Value), 8, 0));
            }
            else
            {
               AV33CardInativo_Value = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCardinativo_value_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV33CardInativo_Value", StringUtil.LTrimStr( (decimal)(AV33CardInativo_Value), 8, 0));
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
         E114W2 ();
         if (returnInSub) return;
      }

      protected void E114W2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wcsecuserlogww = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcsecuserlogww_Component), StringUtil.Lower( "SecUserLogWW")) != 0 )
         {
            WebComp_Wcsecuserlogww = getWebComponent(GetType(), "GeneXus.Programs", "secuserlogww", new Object[] {context} );
            WebComp_Wcsecuserlogww.ComponentInit();
            WebComp_Wcsecuserlogww.Name = "SecUserLogWW";
            WebComp_Wcsecuserlogww_Component = "SecUserLogWW";
         }
         if ( StringUtil.Len( WebComp_Wcsecuserlogww_Component) != 0 )
         {
            WebComp_Wcsecuserlogww.setjustcreated();
            WebComp_Wcsecuserlogww.componentprepare(new Object[] {(string)"W0045",(string)""});
            WebComp_Wcsecuserlogww.componentbind(new Object[] {});
         }
         AV32UsuariosAtivos = 0;
         AV31UsuariosInativos = 0;
         /* Using cursor H004W2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A150SecUserStatus = H004W2_A150SecUserStatus[0];
            n150SecUserStatus = H004W2_n150SecUserStatus[0];
            A133SecUserId = H004W2_A133SecUserId[0];
            if ( A150SecUserStatus )
            {
               AV32UsuariosAtivos = (short)(AV32UsuariosAtivos+1);
            }
            else
            {
               AV31UsuariosInativos = (short)(AV31UsuariosInativos+1);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV30CardUsuarioAtivo_Value = AV32UsuariosAtivos;
         AssignAttri("", false, "AV30CardUsuarioAtivo_Value", StringUtil.LTrimStr( (decimal)(AV30CardUsuarioAtivo_Value), 8, 0));
         AV29CardWhiteIcon1_Value = AV31UsuariosInativos;
      }

      protected void nextLoad( )
      {
      }

      protected void E124W2( )
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
         PA4W2( ) ;
         WS4W2( ) ;
         WE4W2( ) ;
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
         if ( ! ( WebComp_Wcsecuserlogww == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcsecuserlogww_Component) != 0 )
            {
               WebComp_Wcsecuserlogww.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101925185", true, true);
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
         context.AddJavascriptSource("seguranca.js", "?20256101925185", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblCardusuarioativo_icon_Internalname = "CARDUSUARIOATIVO_ICON";
         lblCardusuarioativo_description_Internalname = "CARDUSUARIOATIVO_DESCRIPTION";
         edtavCardusuarioativo_value_Internalname = "vCARDUSUARIOATIVO_VALUE";
         divCardusuarioativo_tableinfo_Internalname = "CARDUSUARIOATIVO_TABLEINFO";
         divCardusuarioativo_maintable_Internalname = "CARDUSUARIOATIVO_MAINTABLE";
         Dvpanel_cardusuarioativo_maintable_Internalname = "DVPANEL_CARDUSUARIOATIVO_MAINTABLE";
         lblCardinativo_icon_Internalname = "CARDINATIVO_ICON";
         lblCardinativo_description_Internalname = "CARDINATIVO_DESCRIPTION";
         edtavCardinativo_value_Internalname = "vCARDINATIVO_VALUE";
         divCardinativo_tableinfo_Internalname = "CARDINATIVO_TABLEINFO";
         divCardinativo_maintable_Internalname = "CARDINATIVO_MAINTABLE";
         Dvpanel_cardinativo_maintable_Internalname = "DVPANEL_CARDINATIVO_MAINTABLE";
         divTablehistorico_Internalname = "TABLEHISTORICO";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         divTableshowvalue_Internalname = "TABLESHOWVALUE";
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
         edtavCardinativo_value_Jsonclick = "";
         edtavCardinativo_value_Enabled = 1;
         edtavCardusuarioativo_value_Jsonclick = "";
         edtavCardusuarioativo_value_Enabled = 1;
         Dvpanel_cardinativo_maintable_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_cardinativo_maintable_Iconposition = "Right";
         Dvpanel_cardinativo_maintable_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_cardinativo_maintable_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_cardinativo_maintable_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_cardinativo_maintable_Title = "";
         Dvpanel_cardinativo_maintable_Cls = "PanelNoHeader";
         Dvpanel_cardinativo_maintable_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_cardinativo_maintable_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_cardinativo_maintable_Width = "100%";
         Dvpanel_cardusuarioativo_maintable_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_cardusuarioativo_maintable_Iconposition = "Right";
         Dvpanel_cardusuarioativo_maintable_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_cardusuarioativo_maintable_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_cardusuarioativo_maintable_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_cardusuarioativo_maintable_Title = "";
         Dvpanel_cardusuarioativo_maintable_Cls = "PanelNoHeader";
         Dvpanel_cardusuarioativo_maintable_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_cardusuarioativo_maintable_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_cardusuarioativo_maintable_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Segurança";
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
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ucDvpanel_cardusuarioativo_maintable = new GXUserControl();
         lblCardusuarioativo_icon_Jsonclick = "";
         lblCardusuarioativo_description_Jsonclick = "";
         TempTags = "";
         ucDvpanel_cardinativo_maintable = new GXUserControl();
         lblCardinativo_icon_Jsonclick = "";
         lblCardinativo_description_Jsonclick = "";
         WebComp_Wcsecuserlogww_Component = "";
         OldWcsecuserlogww = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         H004W2_A150SecUserStatus = new bool[] {false} ;
         H004W2_n150SecUserStatus = new bool[] {false} ;
         H004W2_A133SecUserId = new short[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.seguranca__default(),
            new Object[][] {
                new Object[] {
               H004W2_A150SecUserStatus, H004W2_n150SecUserStatus, H004W2_A133SecUserId
               }
            }
         );
         WebComp_Wcsecuserlogww = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
         edtavCardusuarioativo_value_Enabled = 0;
         edtavCardinativo_value_Enabled = 0;
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV32UsuariosAtivos ;
      private short AV31UsuariosInativos ;
      private short A133SecUserId ;
      private short nGXWrapped ;
      private int AV30CardUsuarioAtivo_Value ;
      private int edtavCardusuarioativo_value_Enabled ;
      private int AV33CardInativo_Value ;
      private int edtavCardinativo_value_Enabled ;
      private int AV29CardWhiteIcon1_Value ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Dvpanel_cardusuarioativo_maintable_Width ;
      private string Dvpanel_cardusuarioativo_maintable_Cls ;
      private string Dvpanel_cardusuarioativo_maintable_Title ;
      private string Dvpanel_cardusuarioativo_maintable_Iconposition ;
      private string Dvpanel_cardinativo_maintable_Width ;
      private string Dvpanel_cardinativo_maintable_Cls ;
      private string Dvpanel_cardinativo_maintable_Title ;
      private string Dvpanel_cardinativo_maintable_Iconposition ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTableshowvalue_Internalname ;
      private string Dvpanel_cardusuarioativo_maintable_Internalname ;
      private string divCardusuarioativo_maintable_Internalname ;
      private string lblCardusuarioativo_icon_Internalname ;
      private string lblCardusuarioativo_icon_Jsonclick ;
      private string divCardusuarioativo_tableinfo_Internalname ;
      private string lblCardusuarioativo_description_Internalname ;
      private string lblCardusuarioativo_description_Jsonclick ;
      private string edtavCardusuarioativo_value_Internalname ;
      private string TempTags ;
      private string edtavCardusuarioativo_value_Jsonclick ;
      private string Dvpanel_cardinativo_maintable_Internalname ;
      private string divCardinativo_maintable_Internalname ;
      private string lblCardinativo_icon_Internalname ;
      private string lblCardinativo_icon_Jsonclick ;
      private string divCardinativo_tableinfo_Internalname ;
      private string lblCardinativo_description_Internalname ;
      private string lblCardinativo_description_Jsonclick ;
      private string edtavCardinativo_value_Internalname ;
      private string edtavCardinativo_value_Jsonclick ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTablehistorico_Internalname ;
      private string WebComp_Wcsecuserlogww_Component ;
      private string OldWcsecuserlogww ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Dvpanel_cardusuarioativo_maintable_Autowidth ;
      private bool Dvpanel_cardusuarioativo_maintable_Autoheight ;
      private bool Dvpanel_cardusuarioativo_maintable_Collapsible ;
      private bool Dvpanel_cardusuarioativo_maintable_Collapsed ;
      private bool Dvpanel_cardusuarioativo_maintable_Showcollapseicon ;
      private bool Dvpanel_cardusuarioativo_maintable_Autoscroll ;
      private bool Dvpanel_cardinativo_maintable_Autowidth ;
      private bool Dvpanel_cardinativo_maintable_Autoheight ;
      private bool Dvpanel_cardinativo_maintable_Collapsible ;
      private bool Dvpanel_cardinativo_maintable_Collapsed ;
      private bool Dvpanel_cardinativo_maintable_Showcollapseicon ;
      private bool Dvpanel_cardinativo_maintable_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool bDynCreated_Wcsecuserlogww ;
      private bool A150SecUserStatus ;
      private bool n150SecUserStatus ;
      private GXWebComponent WebComp_Wcsecuserlogww ;
      private GXUserControl ucDvpanel_cardusuarioativo_maintable ;
      private GXUserControl ucDvpanel_cardinativo_maintable ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private bool[] H004W2_A150SecUserStatus ;
      private bool[] H004W2_n150SecUserStatus ;
      private short[] H004W2_A133SecUserId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class seguranca__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH004W2;
          prmH004W2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H004W2", "SELECT SecUserStatus, SecUserId FROM SecUser ORDER BY SecUserId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004W2,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                return;
       }
    }

 }

}
