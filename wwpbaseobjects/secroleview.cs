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
namespace GeneXus.Programs.wwpbaseobjects {
   public class secroleview : GXDataArea
   {
      public secroleview( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secroleview( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_SecRoleId ,
                           string aP1_TabCode )
      {
         this.AV10SecRoleId = aP0_SecRoleId;
         this.AV8TabCode = aP1_TabCode;
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
            gxfirstwebparm = GetFirstPar( "SecRoleId");
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
               gxfirstwebparm = GetFirstPar( "SecRoleId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "SecRoleId");
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
         PA362( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START362( ) ;
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
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
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
         GXEncryptionTmp = "wwpbaseobjects.secroleview"+UrlEncode(StringUtil.LTrimStr(AV10SecRoleId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TabCode));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.secroleview") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vSECROLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10SecRoleId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10SecRoleId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTABCODE", StringUtil.RTrim( AV8TabCode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TabCode, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_boolean_hidden_field( context, "vLOADALLTABS", AV11LoadAllTabs);
         GxWebStd.gx_hidden_field( context, "vSELECTEDTABCODE", StringUtil.RTrim( AV12SelectedTabCode));
         GxWebStd.gx_hidden_field( context, "vSECROLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10SecRoleId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10SecRoleId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTABCODE", StringUtil.RTrim( AV8TabCode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TabCode, "")), context));
         GxWebStd.gx_hidden_field( context, "TABS_Activepagecontrolname", StringUtil.RTrim( Tabs_Activepagecontrolname));
         GxWebStd.gx_hidden_field( context, "TABS_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Tabs_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TABS_Class", StringUtil.RTrim( Tabs_Class));
         GxWebStd.gx_hidden_field( context, "TABS_Historymanagement", StringUtil.BoolToStr( Tabs_Historymanagement));
         GxWebStd.gx_hidden_field( context, "TABS_Activepagecontrolname", StringUtil.RTrim( Tabs_Activepagecontrolname));
         GxWebStd.gx_hidden_field( context, "TABS_Activepagecontrolname", StringUtil.RTrim( Tabs_Activepagecontrolname));
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
         if ( ! ( WebComp_Generalwc == null ) )
         {
            WebComp_Generalwc.componentjscripts();
         }
         if ( ! ( WebComp_Secfunctionalityrolewc == null ) )
         {
            WebComp_Secfunctionalityrolewc.componentjscripts();
         }
         if ( ! ( WebComp_Secuserrolewc == null ) )
         {
            WebComp_Secuserrolewc.componentjscripts();
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
            WE362( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT362( ) ;
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
         GXEncryptionTmp = "wwpbaseobjects.secroleview"+UrlEncode(StringUtil.LTrimStr(AV10SecRoleId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TabCode));
         return formatLink("wwpbaseobjects.secroleview") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.SecRoleView" ;
      }

      public override string GetPgmdesc( )
      {
         return "Sec Role View" ;
      }

      protected void WB360( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellWWLinkPanel", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableviewrightitems_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "justify-content:flex-end;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ViewCellRightItem", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblWorkwithlink_Internalname, "WWP_ViewLinkCaption", lblWorkwithlink_Link, "", lblWorkwithlink_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockLink", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/SecRoleView.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellViewTabsPosition TabsWithRightActions", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtableviewcontainer_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellViewTab", "start", "top", "", "", "div");
            /* User Defined Control */
            ucTabs.SetProperty("PageCount", Tabs_Pagecount);
            ucTabs.SetProperty("Class", Tabs_Class);
            ucTabs.SetProperty("HistoryManagement", Tabs_Historymanagement);
            ucTabs.Render(context, "tab", Tabs_Internalname, "TABSContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"title1"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGeneral_title_Internalname, "General", "", "", lblGeneral_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/SecRoleView.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "General") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtablegeneral_Internalname, 1, 0, "px", 0, "px", "TableViewTab", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0025"+"", StringUtil.RTrim( WebComp_Generalwc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0025"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Generalwc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldGeneralwc), StringUtil.Lower( WebComp_Generalwc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0025"+"");
                  }
                  WebComp_Generalwc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldGeneralwc), StringUtil.Lower( WebComp_Generalwc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"title2"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSecfunctionalityrole_title_Internalname, "Functionalities", "", "", lblSecfunctionalityrole_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/SecRoleView.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "SecFunctionalityRole") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtablesecfunctionalityrole_Internalname, 1, 0, "px", 0, "px", "TableViewTab", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0033"+"", StringUtil.RTrim( WebComp_Secfunctionalityrolewc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0033"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Secfunctionalityrolewc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldSecfunctionalityrolewc), StringUtil.Lower( WebComp_Secfunctionalityrolewc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0033"+"");
                  }
                  WebComp_Secfunctionalityrolewc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldSecfunctionalityrolewc), StringUtil.Lower( WebComp_Secfunctionalityrolewc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"title3"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSecuserrole_title_Internalname, "Users", "", "", lblSecuserrole_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/SecRoleView.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "SecUserRole") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel3"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtablesecuserrole_Internalname, 1, 0, "px", 0, "px", "TableViewTab", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0041"+"", StringUtil.RTrim( WebComp_Secuserrolewc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0041"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Secuserrolewc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldSecuserrolewc), StringUtil.Lower( WebComp_Secuserrolewc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0041"+"");
                  }
                  WebComp_Secuserrolewc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldSecuserrolewc), StringUtil.Lower( WebComp_Secuserrolewc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
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
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START362( )
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
         Form.Meta.addItem("description", "Sec Role View", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP360( ) ;
      }

      protected void WS362( )
      {
         START362( ) ;
         EVT362( ) ;
      }

      protected void EVT362( )
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
                           else if ( StringUtil.StrCmp(sEvt, "TABS.TABCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Tabs.Tabchanged */
                              E11362 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E12362 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E13362 ();
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
                        if ( nCmpId == 25 )
                        {
                           OldGeneralwc = cgiGet( "W0025");
                           if ( ( StringUtil.Len( OldGeneralwc) == 0 ) || ( StringUtil.StrCmp(OldGeneralwc, WebComp_Generalwc_Component) != 0 ) )
                           {
                              WebComp_Generalwc = getWebComponent(GetType(), "GeneXus.Programs", OldGeneralwc, new Object[] {context} );
                              WebComp_Generalwc.ComponentInit();
                              WebComp_Generalwc.Name = "OldGeneralwc";
                              WebComp_Generalwc_Component = OldGeneralwc;
                           }
                           if ( StringUtil.Len( WebComp_Generalwc_Component) != 0 )
                           {
                              WebComp_Generalwc.componentprocess("W0025", "", sEvt);
                           }
                           WebComp_Generalwc_Component = OldGeneralwc;
                        }
                        else if ( nCmpId == 33 )
                        {
                           OldSecfunctionalityrolewc = cgiGet( "W0033");
                           if ( ( StringUtil.Len( OldSecfunctionalityrolewc) == 0 ) || ( StringUtil.StrCmp(OldSecfunctionalityrolewc, WebComp_Secfunctionalityrolewc_Component) != 0 ) )
                           {
                              WebComp_Secfunctionalityrolewc = getWebComponent(GetType(), "GeneXus.Programs", OldSecfunctionalityrolewc, new Object[] {context} );
                              WebComp_Secfunctionalityrolewc.ComponentInit();
                              WebComp_Secfunctionalityrolewc.Name = "OldSecfunctionalityrolewc";
                              WebComp_Secfunctionalityrolewc_Component = OldSecfunctionalityrolewc;
                           }
                           if ( StringUtil.Len( WebComp_Secfunctionalityrolewc_Component) != 0 )
                           {
                              WebComp_Secfunctionalityrolewc.componentprocess("W0033", "", sEvt);
                           }
                           WebComp_Secfunctionalityrolewc_Component = OldSecfunctionalityrolewc;
                        }
                        else if ( nCmpId == 41 )
                        {
                           OldSecuserrolewc = cgiGet( "W0041");
                           if ( ( StringUtil.Len( OldSecuserrolewc) == 0 ) || ( StringUtil.StrCmp(OldSecuserrolewc, WebComp_Secuserrolewc_Component) != 0 ) )
                           {
                              WebComp_Secuserrolewc = getWebComponent(GetType(), "GeneXus.Programs", OldSecuserrolewc, new Object[] {context} );
                              WebComp_Secuserrolewc.ComponentInit();
                              WebComp_Secuserrolewc.Name = "OldSecuserrolewc";
                              WebComp_Secuserrolewc_Component = OldSecuserrolewc;
                           }
                           if ( StringUtil.Len( WebComp_Secuserrolewc_Component) != 0 )
                           {
                              WebComp_Secuserrolewc.componentprocess("W0041", "", sEvt);
                           }
                           WebComp_Secuserrolewc_Component = OldSecuserrolewc;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE362( )
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

      protected void PA362( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wwpbaseobjects.secroleview")), "wwpbaseobjects.secroleview") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wwpbaseobjects.secroleview")))) ;
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
                  gxfirstwebparm = GetFirstPar( "SecRoleId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV10SecRoleId = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV10SecRoleId", StringUtil.LTrimStr( (decimal)(AV10SecRoleId), 4, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vSECROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10SecRoleId), "ZZZ9"), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV8TabCode = GetPar( "TabCode");
                        AssignAttri("", false, "AV8TabCode", AV8TabCode);
                        GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TabCode, "")), context));
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
         RF362( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF362( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Generalwc_Component) != 0 )
               {
                  WebComp_Generalwc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Secfunctionalityrolewc_Component) != 0 )
               {
                  WebComp_Secfunctionalityrolewc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Secuserrolewc_Component) != 0 )
               {
                  WebComp_Secuserrolewc.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E13362 ();
            WB360( ) ;
         }
      }

      protected void send_integrity_lvl_hashes362( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP360( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E12362 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Tabs_Activepagecontrolname = cgiGet( "TABS_Activepagecontrolname");
            Tabs_Pagecount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "TABS_Pagecount"), ",", "."), 18, MidpointRounding.ToEven));
            Tabs_Class = cgiGet( "TABS_Class");
            Tabs_Historymanagement = StringUtil.StrToBool( cgiGet( "TABS_Historymanagement"));
            Tabs_Activepagecontrolname = cgiGet( "TABS_Activepagecontrolname");
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
         E12362 ();
         if (returnInSub) return;
      }

      protected void E12362( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         lblWorkwithlink_Link = formatLink("wwpbaseobjects.secroleww") ;
         AssignProp("", false, lblWorkwithlink_Internalname, "Link", lblWorkwithlink_Link, true);
         AV15GXLvl9 = 0;
         /* Using cursor H00362 */
         pr_default.execute(0, new Object[] {AV10SecRoleId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A131SecRoleId = H00362_A131SecRoleId[0];
            A140SecRoleName = H00362_A140SecRoleName[0];
            AV15GXLvl9 = 1;
            Form.Caption = A140SecRoleName;
            AssignProp("", false, "FORM", "Caption", Form.Caption, true);
            AV9Exists = true;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV15GXLvl9 == 0 )
         {
            Form.Caption = "Registro não encontrado";
            AssignProp("", false, "FORM", "Caption", Form.Caption, true);
            AV9Exists = false;
         }
         if ( AV9Exists )
         {
            AV12SelectedTabCode = AV8TabCode;
            AssignAttri("", false, "AV12SelectedTabCode", AV12SelectedTabCode);
            Tabs_Activepagecontrolname = AV12SelectedTabCode;
            ucTabs.SendProperty(context, "", false, Tabs_Internalname, "ActivePageControlName", Tabs_Activepagecontrolname);
            /* Execute user subroutine: 'LOADTABS' */
            S112 ();
            if (returnInSub) return;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E13362( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void E11362( )
      {
         /* Tabs_Tabchanged Routine */
         returnInSub = false;
         AV12SelectedTabCode = Tabs_Activepagecontrolname;
         AssignAttri("", false, "AV12SelectedTabCode", AV12SelectedTabCode);
         AV11LoadAllTabs = false;
         AssignAttri("", false, "AV11LoadAllTabs", AV11LoadAllTabs);
         /* Execute user subroutine: 'LOADTABS' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'LOADTABS' Routine */
         returnInSub = false;
         if ( AV11LoadAllTabs || ( StringUtil.StrCmp(AV12SelectedTabCode, "") == 0 ) || ( StringUtil.StrCmp(AV12SelectedTabCode, "General") == 0 ) )
         {
            /* Object Property */
            if ( true )
            {
               bDynCreated_Generalwc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Generalwc_Component), StringUtil.Lower( "WWPBaseObjects.SecRoleGeneral")) != 0 )
            {
               WebComp_Generalwc = getWebComponent(GetType(), "GeneXus.Programs", "wwpbaseobjects.secrolegeneral", new Object[] {context} );
               WebComp_Generalwc.ComponentInit();
               WebComp_Generalwc.Name = "WWPBaseObjects.SecRoleGeneral";
               WebComp_Generalwc_Component = "WWPBaseObjects.SecRoleGeneral";
            }
            if ( StringUtil.Len( WebComp_Generalwc_Component) != 0 )
            {
               WebComp_Generalwc.setjustcreated();
               WebComp_Generalwc.componentprepare(new Object[] {(string)"W0025",(string)"",(short)AV10SecRoleId});
               WebComp_Generalwc.componentbind(new Object[] {(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Generalwc )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0025"+"");
               WebComp_Generalwc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         if ( AV11LoadAllTabs || ( StringUtil.StrCmp(AV12SelectedTabCode, "SecFunctionalityRole") == 0 ) )
         {
            /* Object Property */
            if ( true )
            {
               bDynCreated_Secfunctionalityrolewc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Secfunctionalityrolewc_Component), StringUtil.Lower( "WWPBaseObjects.SecRoleSecFunctionalityRoleWC")) != 0 )
            {
               WebComp_Secfunctionalityrolewc = getWebComponent(GetType(), "GeneXus.Programs", "wwpbaseobjects.secrolesecfunctionalityrolewc", new Object[] {context} );
               WebComp_Secfunctionalityrolewc.ComponentInit();
               WebComp_Secfunctionalityrolewc.Name = "WWPBaseObjects.SecRoleSecFunctionalityRoleWC";
               WebComp_Secfunctionalityrolewc_Component = "WWPBaseObjects.SecRoleSecFunctionalityRoleWC";
            }
            if ( StringUtil.Len( WebComp_Secfunctionalityrolewc_Component) != 0 )
            {
               WebComp_Secfunctionalityrolewc.setjustcreated();
               WebComp_Secfunctionalityrolewc.componentprepare(new Object[] {(string)"W0033",(string)"",(short)AV10SecRoleId});
               WebComp_Secfunctionalityrolewc.componentbind(new Object[] {(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Secfunctionalityrolewc )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0033"+"");
               WebComp_Secfunctionalityrolewc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         if ( AV11LoadAllTabs || ( StringUtil.StrCmp(AV12SelectedTabCode, "SecUserRole") == 0 ) )
         {
            /* Object Property */
            if ( true )
            {
               bDynCreated_Secuserrolewc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Secuserrolewc_Component), StringUtil.Lower( "WWPBaseObjects.SecRoleSecUserRoleWC")) != 0 )
            {
               WebComp_Secuserrolewc = getWebComponent(GetType(), "GeneXus.Programs", "wwpbaseobjects.secrolesecuserrolewc", new Object[] {context} );
               WebComp_Secuserrolewc.ComponentInit();
               WebComp_Secuserrolewc.Name = "WWPBaseObjects.SecRoleSecUserRoleWC";
               WebComp_Secuserrolewc_Component = "WWPBaseObjects.SecRoleSecUserRoleWC";
            }
            if ( StringUtil.Len( WebComp_Secuserrolewc_Component) != 0 )
            {
               WebComp_Secuserrolewc.setjustcreated();
               WebComp_Secuserrolewc.componentprepare(new Object[] {(string)"W0041",(string)"",(short)AV10SecRoleId});
               WebComp_Secuserrolewc.componentbind(new Object[] {(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Secuserrolewc )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0041"+"");
               WebComp_Secuserrolewc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV10SecRoleId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV10SecRoleId", StringUtil.LTrimStr( (decimal)(AV10SecRoleId), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10SecRoleId), "ZZZ9"), context));
         AV8TabCode = (string)getParm(obj,1);
         AssignAttri("", false, "AV8TabCode", AV8TabCode);
         GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TabCode, "")), context));
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
         PA362( ) ;
         WS362( ) ;
         WE362( ) ;
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
         if ( ! ( WebComp_Generalwc == null ) )
         {
            if ( StringUtil.Len( WebComp_Generalwc_Component) != 0 )
            {
               WebComp_Generalwc.componentthemes();
            }
         }
         if ( ! ( WebComp_Secfunctionalityrolewc == null ) )
         {
            if ( StringUtil.Len( WebComp_Secfunctionalityrolewc_Component) != 0 )
            {
               WebComp_Secfunctionalityrolewc.componentthemes();
            }
         }
         if ( ! ( WebComp_Secuserrolewc == null ) )
         {
            if ( StringUtil.Len( WebComp_Secuserrolewc_Component) != 0 )
            {
               WebComp_Secuserrolewc.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019233753", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/secroleview.js", "?202561019233753", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblWorkwithlink_Internalname = "WORKWITHLINK";
         divTableviewrightitems_Internalname = "TABLEVIEWRIGHTITEMS";
         lblGeneral_title_Internalname = "GENERAL_TITLE";
         divUnnamedtablegeneral_Internalname = "UNNAMEDTABLEGENERAL";
         lblSecfunctionalityrole_title_Internalname = "SECFUNCTIONALITYROLE_TITLE";
         divUnnamedtablesecfunctionalityrole_Internalname = "UNNAMEDTABLESECFUNCTIONALITYROLE";
         lblSecuserrole_title_Internalname = "SECUSERROLE_TITLE";
         divUnnamedtablesecuserrole_Internalname = "UNNAMEDTABLESECUSERROLE";
         Tabs_Internalname = "TABS";
         divUnnamedtableviewcontainer_Internalname = "UNNAMEDTABLEVIEWCONTAINER";
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
         lblWorkwithlink_Link = "";
         Tabs_Historymanagement = Convert.ToBoolean( -1);
         Tabs_Class = "ViewTab Tab";
         Tabs_Pagecount = 3;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Sec Role View";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV10SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV8TabCode","fld":"vTABCODE","hsh":true,"type":"char"}]}""");
         setEventMetadata("TABS.TABCHANGED","""{"handler":"E11362","iparms":[{"av":"Tabs_Activepagecontrolname","ctrl":"TABS","prop":"ActivePageControlName"},{"av":"AV11LoadAllTabs","fld":"vLOADALLTABS","type":"boolean"},{"av":"AV12SelectedTabCode","fld":"vSELECTEDTABCODE","type":"char"},{"av":"AV10SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("TABS.TABCHANGED",""","oparms":[{"av":"AV12SelectedTabCode","fld":"vSELECTEDTABCODE","type":"char"},{"av":"AV11LoadAllTabs","fld":"vLOADALLTABS","type":"boolean"},{"ctrl":"GENERALWC"},{"ctrl":"SECFUNCTIONALITYROLEWC"},{"ctrl":"SECUSERROLEWC"}]}""");
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
         wcpOAV8TabCode = "";
         Tabs_Activepagecontrolname = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV12SelectedTabCode = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblWorkwithlink_Jsonclick = "";
         ucTabs = new GXUserControl();
         lblGeneral_title_Jsonclick = "";
         WebComp_Generalwc_Component = "";
         OldGeneralwc = "";
         lblSecfunctionalityrole_title_Jsonclick = "";
         WebComp_Secfunctionalityrolewc_Component = "";
         OldSecfunctionalityrolewc = "";
         lblSecuserrole_title_Jsonclick = "";
         WebComp_Secuserrolewc_Component = "";
         OldSecuserrolewc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         H00362_A131SecRoleId = new short[1] ;
         H00362_A140SecRoleName = new string[] {""} ;
         A140SecRoleName = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secroleview__default(),
            new Object[][] {
                new Object[] {
               H00362_A131SecRoleId, H00362_A140SecRoleName
               }
            }
         );
         WebComp_Generalwc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Secfunctionalityrolewc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Secuserrolewc = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short AV10SecRoleId ;
      private short wcpOAV10SecRoleId ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short AV15GXLvl9 ;
      private short A131SecRoleId ;
      private short nGXWrapped ;
      private int Tabs_Pagecount ;
      private int idxLst ;
      private string AV8TabCode ;
      private string wcpOAV8TabCode ;
      private string Tabs_Activepagecontrolname ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV12SelectedTabCode ;
      private string Tabs_Class ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTableviewrightitems_Internalname ;
      private string lblWorkwithlink_Internalname ;
      private string lblWorkwithlink_Link ;
      private string lblWorkwithlink_Jsonclick ;
      private string divUnnamedtableviewcontainer_Internalname ;
      private string Tabs_Internalname ;
      private string lblGeneral_title_Internalname ;
      private string lblGeneral_title_Jsonclick ;
      private string divUnnamedtablegeneral_Internalname ;
      private string WebComp_Generalwc_Component ;
      private string OldGeneralwc ;
      private string lblSecfunctionalityrole_title_Internalname ;
      private string lblSecfunctionalityrole_title_Jsonclick ;
      private string divUnnamedtablesecfunctionalityrole_Internalname ;
      private string WebComp_Secfunctionalityrolewc_Component ;
      private string OldSecfunctionalityrolewc ;
      private string lblSecuserrole_title_Internalname ;
      private string lblSecuserrole_title_Jsonclick ;
      private string divUnnamedtablesecuserrole_Internalname ;
      private string WebComp_Secuserrolewc_Component ;
      private string OldSecuserrolewc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV11LoadAllTabs ;
      private bool Tabs_Historymanagement ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV9Exists ;
      private bool bDynCreated_Generalwc ;
      private bool bDynCreated_Secfunctionalityrolewc ;
      private bool bDynCreated_Secuserrolewc ;
      private string A140SecRoleName ;
      private GXWebComponent WebComp_Generalwc ;
      private GXWebComponent WebComp_Secfunctionalityrolewc ;
      private GXWebComponent WebComp_Secuserrolewc ;
      private GXUserControl ucTabs ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private IDataStoreProvider pr_default ;
      private short[] H00362_A131SecRoleId ;
      private string[] H00362_A140SecRoleName ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class secroleview__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00362;
          prmH00362 = new Object[] {
          new ParDef("AV10SecRoleId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00362", "SELECT SecRoleId, SecRoleName FROM SecRole WHERE SecRoleId = :AV10SecRoleId ORDER BY SecRoleId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00362,1, GxCacheFrequency.OFF ,false,true )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
