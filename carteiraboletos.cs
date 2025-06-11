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
   public class carteiraboletos : GXDataArea
   {
      public carteiraboletos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public carteiraboletos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_CarteiraDeCobrancaId )
      {
         this.AV5CarteiraDeCobrancaId = aP0_CarteiraDeCobrancaId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavCarteiradecobrancastatus = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "CarteiraDeCobrancaId");
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
               gxfirstwebparm = GetFirstPar( "CarteiraDeCobrancaId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "CarteiraDeCobrancaId");
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
         PAAB2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTAB2( ) ;
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
         GXEncryptionTmp = "carteiraboletos"+UrlEncode(StringUtil.LTrimStr(AV5CarteiraDeCobrancaId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("carteiraboletos") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vCARTEIRADECOBRANCAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5CarteiraDeCobrancaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCARTEIRADECOBRANCAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5CarteiraDeCobrancaId), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vCARTEIRADECOBRANCAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5CarteiraDeCobrancaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCARTEIRADECOBRANCAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5CarteiraDeCobrancaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEINFO_Width", StringUtil.RTrim( Dvpanel_tableinfo_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEINFO_Autowidth", StringUtil.BoolToStr( Dvpanel_tableinfo_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEINFO_Autoheight", StringUtil.BoolToStr( Dvpanel_tableinfo_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEINFO_Cls", StringUtil.RTrim( Dvpanel_tableinfo_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEINFO_Title", StringUtil.RTrim( Dvpanel_tableinfo_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEINFO_Collapsible", StringUtil.BoolToStr( Dvpanel_tableinfo_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEINFO_Collapsed", StringUtil.BoolToStr( Dvpanel_tableinfo_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEINFO_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableinfo_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEINFO_Iconposition", StringUtil.RTrim( Dvpanel_tableinfo_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEINFO_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableinfo_Autoscroll));
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
         if ( ! ( WebComp_Wcboletoww == null ) )
         {
            WebComp_Wcboletoww.componentjscripts();
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
            WEAB2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTAB2( ) ;
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
         GXEncryptionTmp = "carteiraboletos"+UrlEncode(StringUtil.LTrimStr(AV5CarteiraDeCobrancaId,9,0));
         return formatLink("carteiraboletos") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "CarteiraBoletos" ;
      }

      public override string GetPgmdesc( )
      {
         return "Boletos na Carteira de Cobrança" ;
      }

      protected void WBAB0( )
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
            /* User Defined Control */
            ucDvpanel_tableinfo.SetProperty("Width", Dvpanel_tableinfo_Width);
            ucDvpanel_tableinfo.SetProperty("AutoWidth", Dvpanel_tableinfo_Autowidth);
            ucDvpanel_tableinfo.SetProperty("AutoHeight", Dvpanel_tableinfo_Autoheight);
            ucDvpanel_tableinfo.SetProperty("Cls", Dvpanel_tableinfo_Cls);
            ucDvpanel_tableinfo.SetProperty("Title", Dvpanel_tableinfo_Title);
            ucDvpanel_tableinfo.SetProperty("Collapsible", Dvpanel_tableinfo_Collapsible);
            ucDvpanel_tableinfo.SetProperty("Collapsed", Dvpanel_tableinfo_Collapsed);
            ucDvpanel_tableinfo.SetProperty("ShowCollapseIcon", Dvpanel_tableinfo_Showcollapseicon);
            ucDvpanel_tableinfo.SetProperty("IconPosition", Dvpanel_tableinfo_Iconposition);
            ucDvpanel_tableinfo.SetProperty("AutoScroll", Dvpanel_tableinfo_Autoscroll);
            ucDvpanel_tableinfo.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableinfo_Internalname, "DVPANEL_TABLEINFOContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEINFOContainer"+"TableInfo"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableinfo_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCarteiradecobrancanome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCarteiradecobrancanome_Internalname, "Carteira de Cobrança", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCarteiradecobrancanome_Internalname, AV7CarteiraDeCobrancaNome, StringUtil.RTrim( context.localUtil.Format( AV7CarteiraDeCobrancaNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCarteiradecobrancanome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavCarteiradecobrancanome_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CarteiraBoletos.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavCarteiradecobrancastatus_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCarteiradecobrancastatus_Internalname, "Status", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCarteiradecobrancastatus, cmbavCarteiradecobrancastatus_Internalname, StringUtil.BoolToStr( AV8CarteiraDeCobrancaStatus), 1, cmbavCarteiradecobrancastatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbavCarteiradecobrancastatus.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "", true, 0, "HLP_CarteiraBoletos.htm");
            cmbavCarteiradecobrancastatus.CurrentValue = StringUtil.BoolToStr( AV8CarteiraDeCobrancaStatus);
            AssignProp("", false, cmbavCarteiradecobrancastatus_Internalname, "Values", (string)(cmbavCarteiradecobrancastatus.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCarteiradecobrancaconvenio_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCarteiradecobrancaconvenio_Internalname, "Convênio", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCarteiradecobrancaconvenio_Internalname, AV11CarteiraDeCobrancaConvenio, StringUtil.RTrim( context.localUtil.Format( AV11CarteiraDeCobrancaConvenio, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCarteiradecobrancaconvenio_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavCarteiradecobrancaconvenio_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CarteiraBoletos.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCarteiradecobrancatotalboletos_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCarteiradecobrancatotalboletos_Internalname, "Total Boletos", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCarteiradecobrancatotalboletos_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9CarteiraDeCobrancaTotalBoletos), 8, 0, ",", "")), StringUtil.LTrim( ((edtavCarteiradecobrancatotalboletos_Enabled!=0) ? context.localUtil.Format( (decimal)(AV9CarteiraDeCobrancaTotalBoletos), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(AV9CarteiraDeCobrancaTotalBoletos), "ZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCarteiradecobrancatotalboletos_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavCarteiradecobrancatotalboletos_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CarteiraBoletos.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCarteiradecobrancatotalboletosregistrados_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCarteiradecobrancatotalboletosregistrados_Internalname, "Boletos Registrados", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCarteiradecobrancatotalboletosregistrados_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14CarteiraDeCobrancaTotalBoletosRegistrados), 8, 0, ",", "")), StringUtil.LTrim( ((edtavCarteiradecobrancatotalboletosregistrados_Enabled!=0) ? context.localUtil.Format( (decimal)(AV14CarteiraDeCobrancaTotalBoletosRegistrados), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(AV14CarteiraDeCobrancaTotalBoletosRegistrados), "ZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCarteiradecobrancatotalboletosregistrados_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavCarteiradecobrancatotalboletosregistrados_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CarteiraBoletos.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCarteiradecobrancatotalboletosexpirados_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCarteiradecobrancatotalboletosexpirados_Internalname, "Boletos Expirados", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCarteiradecobrancatotalboletosexpirados_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10CarteiraDeCobrancaTotalBoletosExpirados), 8, 0, ",", "")), StringUtil.LTrim( ((edtavCarteiradecobrancatotalboletosexpirados_Enabled!=0) ? context.localUtil.Format( (decimal)(AV10CarteiraDeCobrancaTotalBoletosExpirados), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(AV10CarteiraDeCobrancaTotalBoletosExpirados), "ZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCarteiradecobrancatotalboletosexpirados_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavCarteiradecobrancatotalboletosexpirados_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CarteiraBoletos.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCarteiradecobrancatotalboletoscancelados_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCarteiradecobrancatotalboletoscancelados_Internalname, "Boletos Cancelados", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCarteiradecobrancatotalboletoscancelados_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15CarteiraDeCobrancaTotalBoletosCancelados), 8, 0, ",", "")), StringUtil.LTrim( ((edtavCarteiradecobrancatotalboletoscancelados_Enabled!=0) ? context.localUtil.Format( (decimal)(AV15CarteiraDeCobrancaTotalBoletosCancelados), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(AV15CarteiraDeCobrancaTotalBoletosCancelados), "ZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCarteiradecobrancatotalboletoscancelados_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavCarteiradecobrancatotalboletoscancelados_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CarteiraBoletos.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCarteiradecobrancavalortotal_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCarteiradecobrancavalortotal_Internalname, "Valor Total", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCarteiradecobrancavalortotal_Internalname, StringUtil.LTrim( StringUtil.NToC( AV12CarteiraDeCobrancaValorTotal, 18, 2, ",", "")), StringUtil.LTrim( ((edtavCarteiradecobrancavalortotal_Enabled!=0) ? context.localUtil.Format( AV12CarteiraDeCobrancaValorTotal, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV12CarteiraDeCobrancaValorTotal, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCarteiradecobrancavalortotal_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavCarteiradecobrancavalortotal_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CarteiraBoletos.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCarteiradecobrancavalorrecebido_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCarteiradecobrancavalorrecebido_Internalname, "Valor Recebido", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCarteiradecobrancavalorrecebido_Internalname, StringUtil.LTrim( StringUtil.NToC( AV13CarteiraDeCobrancaValorRecebido, 18, 2, ",", "")), StringUtil.LTrim( ((edtavCarteiradecobrancavalorrecebido_Enabled!=0) ? context.localUtil.Format( AV13CarteiraDeCobrancaValorRecebido, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV13CarteiraDeCobrancaValorRecebido, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCarteiradecobrancavalorrecebido_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavCarteiradecobrancavalorrecebido_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CarteiraBoletos.htm");
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
               GxWebStd.gx_hidden_field( context, "W0059"+"", StringUtil.RTrim( WebComp_Wcboletoww_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0059"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcboletoww_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcboletoww), StringUtil.Lower( WebComp_Wcboletoww_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0059"+"");
                  }
                  WebComp_Wcboletoww.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcboletoww), StringUtil.Lower( WebComp_Wcboletoww_Component)) != 0 )
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

      protected void STARTAB2( )
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
         Form.Meta.addItem("description", "Boletos na Carteira de Cobrança", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPAB0( ) ;
      }

      protected void WSAB2( )
      {
         STARTAB2( ) ;
         EVTAB2( ) ;
      }

      protected void EVTAB2( )
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
                              E11AB2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E12AB2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E13AB2 ();
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
                        if ( nCmpId == 59 )
                        {
                           OldWcboletoww = cgiGet( "W0059");
                           if ( ( StringUtil.Len( OldWcboletoww) == 0 ) || ( StringUtil.StrCmp(OldWcboletoww, WebComp_Wcboletoww_Component) != 0 ) )
                           {
                              WebComp_Wcboletoww = getWebComponent(GetType(), "GeneXus.Programs", OldWcboletoww, new Object[] {context} );
                              WebComp_Wcboletoww.ComponentInit();
                              WebComp_Wcboletoww.Name = "OldWcboletoww";
                              WebComp_Wcboletoww_Component = OldWcboletoww;
                           }
                           if ( StringUtil.Len( WebComp_Wcboletoww_Component) != 0 )
                           {
                              WebComp_Wcboletoww.componentprocess("W0059", "", sEvt);
                           }
                           WebComp_Wcboletoww_Component = OldWcboletoww;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WEAB2( )
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

      protected void PAAB2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "carteiraboletos")), "carteiraboletos") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "carteiraboletos")))) ;
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
                  gxfirstwebparm = GetFirstPar( "CarteiraDeCobrancaId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV5CarteiraDeCobrancaId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV5CarteiraDeCobrancaId", StringUtil.LTrimStr( (decimal)(AV5CarteiraDeCobrancaId), 9, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vCARTEIRADECOBRANCAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5CarteiraDeCobrancaId), "ZZZZZZZZ9"), context));
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
               GX_FocusControl = edtavCarteiradecobrancanome_Internalname;
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
         if ( cmbavCarteiradecobrancastatus.ItemCount > 0 )
         {
            AV8CarteiraDeCobrancaStatus = StringUtil.StrToBool( cmbavCarteiradecobrancastatus.getValidValue(StringUtil.BoolToStr( AV8CarteiraDeCobrancaStatus)));
            AssignAttri("", false, "AV8CarteiraDeCobrancaStatus", AV8CarteiraDeCobrancaStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCarteiradecobrancastatus.CurrentValue = StringUtil.BoolToStr( AV8CarteiraDeCobrancaStatus);
            AssignProp("", false, cmbavCarteiradecobrancastatus_Internalname, "Values", cmbavCarteiradecobrancastatus.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFAB2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavCarteiradecobrancanome_Enabled = 0;
         AssignProp("", false, edtavCarteiradecobrancanome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCarteiradecobrancanome_Enabled), 5, 0), true);
         cmbavCarteiradecobrancastatus.Enabled = 0;
         AssignProp("", false, cmbavCarteiradecobrancastatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavCarteiradecobrancastatus.Enabled), 5, 0), true);
         edtavCarteiradecobrancaconvenio_Enabled = 0;
         AssignProp("", false, edtavCarteiradecobrancaconvenio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCarteiradecobrancaconvenio_Enabled), 5, 0), true);
         edtavCarteiradecobrancatotalboletos_Enabled = 0;
         AssignProp("", false, edtavCarteiradecobrancatotalboletos_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCarteiradecobrancatotalboletos_Enabled), 5, 0), true);
         edtavCarteiradecobrancatotalboletosregistrados_Enabled = 0;
         AssignProp("", false, edtavCarteiradecobrancatotalboletosregistrados_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCarteiradecobrancatotalboletosregistrados_Enabled), 5, 0), true);
         edtavCarteiradecobrancatotalboletosexpirados_Enabled = 0;
         AssignProp("", false, edtavCarteiradecobrancatotalboletosexpirados_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCarteiradecobrancatotalboletosexpirados_Enabled), 5, 0), true);
         edtavCarteiradecobrancatotalboletoscancelados_Enabled = 0;
         AssignProp("", false, edtavCarteiradecobrancatotalboletoscancelados_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCarteiradecobrancatotalboletoscancelados_Enabled), 5, 0), true);
         edtavCarteiradecobrancavalortotal_Enabled = 0;
         AssignProp("", false, edtavCarteiradecobrancavalortotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCarteiradecobrancavalortotal_Enabled), 5, 0), true);
         edtavCarteiradecobrancavalorrecebido_Enabled = 0;
         AssignProp("", false, edtavCarteiradecobrancavalorrecebido_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCarteiradecobrancavalorrecebido_Enabled), 5, 0), true);
      }

      protected void RFAB2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E12AB2 ();
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcboletoww_Component) != 0 )
               {
                  WebComp_Wcboletoww.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E13AB2 ();
            WBAB0( ) ;
         }
      }

      protected void send_integrity_lvl_hashesAB2( )
      {
      }

      protected void before_start_formulas( )
      {
         edtavCarteiradecobrancanome_Enabled = 0;
         AssignProp("", false, edtavCarteiradecobrancanome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCarteiradecobrancanome_Enabled), 5, 0), true);
         cmbavCarteiradecobrancastatus.Enabled = 0;
         AssignProp("", false, cmbavCarteiradecobrancastatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavCarteiradecobrancastatus.Enabled), 5, 0), true);
         edtavCarteiradecobrancaconvenio_Enabled = 0;
         AssignProp("", false, edtavCarteiradecobrancaconvenio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCarteiradecobrancaconvenio_Enabled), 5, 0), true);
         edtavCarteiradecobrancatotalboletos_Enabled = 0;
         AssignProp("", false, edtavCarteiradecobrancatotalboletos_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCarteiradecobrancatotalboletos_Enabled), 5, 0), true);
         edtavCarteiradecobrancatotalboletosregistrados_Enabled = 0;
         AssignProp("", false, edtavCarteiradecobrancatotalboletosregistrados_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCarteiradecobrancatotalboletosregistrados_Enabled), 5, 0), true);
         edtavCarteiradecobrancatotalboletosexpirados_Enabled = 0;
         AssignProp("", false, edtavCarteiradecobrancatotalboletosexpirados_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCarteiradecobrancatotalboletosexpirados_Enabled), 5, 0), true);
         edtavCarteiradecobrancatotalboletoscancelados_Enabled = 0;
         AssignProp("", false, edtavCarteiradecobrancatotalboletoscancelados_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCarteiradecobrancatotalboletoscancelados_Enabled), 5, 0), true);
         edtavCarteiradecobrancavalortotal_Enabled = 0;
         AssignProp("", false, edtavCarteiradecobrancavalortotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCarteiradecobrancavalortotal_Enabled), 5, 0), true);
         edtavCarteiradecobrancavalorrecebido_Enabled = 0;
         AssignProp("", false, edtavCarteiradecobrancavalorrecebido_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCarteiradecobrancavalorrecebido_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUPAB0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11AB2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Dvpanel_tableinfo_Width = cgiGet( "DVPANEL_TABLEINFO_Width");
            Dvpanel_tableinfo_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEINFO_Autowidth"));
            Dvpanel_tableinfo_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEINFO_Autoheight"));
            Dvpanel_tableinfo_Cls = cgiGet( "DVPANEL_TABLEINFO_Cls");
            Dvpanel_tableinfo_Title = cgiGet( "DVPANEL_TABLEINFO_Title");
            Dvpanel_tableinfo_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEINFO_Collapsible"));
            Dvpanel_tableinfo_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEINFO_Collapsed"));
            Dvpanel_tableinfo_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEINFO_Showcollapseicon"));
            Dvpanel_tableinfo_Iconposition = cgiGet( "DVPANEL_TABLEINFO_Iconposition");
            Dvpanel_tableinfo_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEINFO_Autoscroll"));
            /* Read variables values. */
            AV7CarteiraDeCobrancaNome = cgiGet( edtavCarteiradecobrancanome_Internalname);
            AssignAttri("", false, "AV7CarteiraDeCobrancaNome", AV7CarteiraDeCobrancaNome);
            cmbavCarteiradecobrancastatus.CurrentValue = cgiGet( cmbavCarteiradecobrancastatus_Internalname);
            AV8CarteiraDeCobrancaStatus = StringUtil.StrToBool( cgiGet( cmbavCarteiradecobrancastatus_Internalname));
            AssignAttri("", false, "AV8CarteiraDeCobrancaStatus", AV8CarteiraDeCobrancaStatus);
            AV11CarteiraDeCobrancaConvenio = cgiGet( edtavCarteiradecobrancaconvenio_Internalname);
            AssignAttri("", false, "AV11CarteiraDeCobrancaConvenio", AV11CarteiraDeCobrancaConvenio);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCarteiradecobrancatotalboletos_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCarteiradecobrancatotalboletos_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCARTEIRADECOBRANCATOTALBOLETOS");
               GX_FocusControl = edtavCarteiradecobrancatotalboletos_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9CarteiraDeCobrancaTotalBoletos = 0;
               AssignAttri("", false, "AV9CarteiraDeCobrancaTotalBoletos", StringUtil.LTrimStr( (decimal)(AV9CarteiraDeCobrancaTotalBoletos), 8, 0));
            }
            else
            {
               AV9CarteiraDeCobrancaTotalBoletos = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCarteiradecobrancatotalboletos_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV9CarteiraDeCobrancaTotalBoletos", StringUtil.LTrimStr( (decimal)(AV9CarteiraDeCobrancaTotalBoletos), 8, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCarteiradecobrancatotalboletosregistrados_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCarteiradecobrancatotalboletosregistrados_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCARTEIRADECOBRANCATOTALBOLETOSREGISTRADOS");
               GX_FocusControl = edtavCarteiradecobrancatotalboletosregistrados_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV14CarteiraDeCobrancaTotalBoletosRegistrados = 0;
               AssignAttri("", false, "AV14CarteiraDeCobrancaTotalBoletosRegistrados", StringUtil.LTrimStr( (decimal)(AV14CarteiraDeCobrancaTotalBoletosRegistrados), 8, 0));
            }
            else
            {
               AV14CarteiraDeCobrancaTotalBoletosRegistrados = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCarteiradecobrancatotalboletosregistrados_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV14CarteiraDeCobrancaTotalBoletosRegistrados", StringUtil.LTrimStr( (decimal)(AV14CarteiraDeCobrancaTotalBoletosRegistrados), 8, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCarteiradecobrancatotalboletosexpirados_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCarteiradecobrancatotalboletosexpirados_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCARTEIRADECOBRANCATOTALBOLETOSEXPIRADOS");
               GX_FocusControl = edtavCarteiradecobrancatotalboletosexpirados_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10CarteiraDeCobrancaTotalBoletosExpirados = 0;
               AssignAttri("", false, "AV10CarteiraDeCobrancaTotalBoletosExpirados", StringUtil.LTrimStr( (decimal)(AV10CarteiraDeCobrancaTotalBoletosExpirados), 8, 0));
            }
            else
            {
               AV10CarteiraDeCobrancaTotalBoletosExpirados = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCarteiradecobrancatotalboletosexpirados_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV10CarteiraDeCobrancaTotalBoletosExpirados", StringUtil.LTrimStr( (decimal)(AV10CarteiraDeCobrancaTotalBoletosExpirados), 8, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCarteiradecobrancatotalboletoscancelados_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCarteiradecobrancatotalboletoscancelados_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCARTEIRADECOBRANCATOTALBOLETOSCANCELADOS");
               GX_FocusControl = edtavCarteiradecobrancatotalboletoscancelados_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV15CarteiraDeCobrancaTotalBoletosCancelados = 0;
               AssignAttri("", false, "AV15CarteiraDeCobrancaTotalBoletosCancelados", StringUtil.LTrimStr( (decimal)(AV15CarteiraDeCobrancaTotalBoletosCancelados), 8, 0));
            }
            else
            {
               AV15CarteiraDeCobrancaTotalBoletosCancelados = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCarteiradecobrancatotalboletoscancelados_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV15CarteiraDeCobrancaTotalBoletosCancelados", StringUtil.LTrimStr( (decimal)(AV15CarteiraDeCobrancaTotalBoletosCancelados), 8, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCarteiradecobrancavalortotal_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCarteiradecobrancavalortotal_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCARTEIRADECOBRANCAVALORTOTAL");
               GX_FocusControl = edtavCarteiradecobrancavalortotal_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12CarteiraDeCobrancaValorTotal = 0;
               AssignAttri("", false, "AV12CarteiraDeCobrancaValorTotal", StringUtil.LTrimStr( AV12CarteiraDeCobrancaValorTotal, 18, 2));
            }
            else
            {
               AV12CarteiraDeCobrancaValorTotal = context.localUtil.CToN( cgiGet( edtavCarteiradecobrancavalortotal_Internalname), ",", ".");
               AssignAttri("", false, "AV12CarteiraDeCobrancaValorTotal", StringUtil.LTrimStr( AV12CarteiraDeCobrancaValorTotal, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCarteiradecobrancavalorrecebido_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCarteiradecobrancavalorrecebido_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCARTEIRADECOBRANCAVALORRECEBIDO");
               GX_FocusControl = edtavCarteiradecobrancavalorrecebido_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV13CarteiraDeCobrancaValorRecebido = 0;
               AssignAttri("", false, "AV13CarteiraDeCobrancaValorRecebido", StringUtil.LTrimStr( AV13CarteiraDeCobrancaValorRecebido, 18, 2));
            }
            else
            {
               AV13CarteiraDeCobrancaValorRecebido = context.localUtil.CToN( cgiGet( edtavCarteiradecobrancavalorrecebido_Internalname), ",", ".");
               AssignAttri("", false, "AV13CarteiraDeCobrancaValorRecebido", StringUtil.LTrimStr( AV13CarteiraDeCobrancaValorRecebido, 18, 2));
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
         E11AB2 ();
         if (returnInSub) return;
      }

      protected void E11AB2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wcboletoww = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcboletoww_Component), StringUtil.Lower( "WcBoletos")) != 0 )
         {
            WebComp_Wcboletoww = getWebComponent(GetType(), "GeneXus.Programs", "wcboletos", new Object[] {context} );
            WebComp_Wcboletoww.ComponentInit();
            WebComp_Wcboletoww.Name = "WcBoletos";
            WebComp_Wcboletoww_Component = "WcBoletos";
         }
         if ( StringUtil.Len( WebComp_Wcboletoww_Component) != 0 )
         {
            WebComp_Wcboletoww.setjustcreated();
            WebComp_Wcboletoww.componentprepare(new Object[] {(string)"W0059",(string)"",(int)AV5CarteiraDeCobrancaId});
            WebComp_Wcboletoww.componentbind(new Object[] {(string)""});
         }
      }

      protected void E12AB2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         AV6CarteiraDeCobranca.Load(AV5CarteiraDeCobrancaId);
         AV7CarteiraDeCobrancaNome = AV6CarteiraDeCobranca.gxTpr_Carteiradecobrancanome;
         AssignAttri("", false, "AV7CarteiraDeCobrancaNome", AV7CarteiraDeCobrancaNome);
         AV11CarteiraDeCobrancaConvenio = AV6CarteiraDeCobranca.gxTpr_Carteiradecobrancaconvenio;
         AssignAttri("", false, "AV11CarteiraDeCobrancaConvenio", AV11CarteiraDeCobrancaConvenio);
         AV8CarteiraDeCobrancaStatus = AV6CarteiraDeCobranca.gxTpr_Carteiradecobrancastatus;
         AssignAttri("", false, "AV8CarteiraDeCobrancaStatus", AV8CarteiraDeCobrancaStatus);
         AV12CarteiraDeCobrancaValorTotal = AV6CarteiraDeCobranca.gxTpr_Carteiradecobrancavalortotal;
         AssignAttri("", false, "AV12CarteiraDeCobrancaValorTotal", StringUtil.LTrimStr( AV12CarteiraDeCobrancaValorTotal, 18, 2));
         AV13CarteiraDeCobrancaValorRecebido = AV6CarteiraDeCobranca.gxTpr_Carteiradecobrancavalorrecebido;
         AssignAttri("", false, "AV13CarteiraDeCobrancaValorRecebido", StringUtil.LTrimStr( AV13CarteiraDeCobrancaValorRecebido, 18, 2));
         AV9CarteiraDeCobrancaTotalBoletos = AV6CarteiraDeCobranca.gxTpr_Carteiradecobrancatotalboletos;
         AssignAttri("", false, "AV9CarteiraDeCobrancaTotalBoletos", StringUtil.LTrimStr( (decimal)(AV9CarteiraDeCobrancaTotalBoletos), 8, 0));
         AV14CarteiraDeCobrancaTotalBoletosRegistrados = AV6CarteiraDeCobranca.gxTpr_Carteiradecobrancatotalboletosregistrados;
         AssignAttri("", false, "AV14CarteiraDeCobrancaTotalBoletosRegistrados", StringUtil.LTrimStr( (decimal)(AV14CarteiraDeCobrancaTotalBoletosRegistrados), 8, 0));
         AV10CarteiraDeCobrancaTotalBoletosExpirados = AV6CarteiraDeCobranca.gxTpr_Carteiradecobrancatotalboletosexpirados;
         AssignAttri("", false, "AV10CarteiraDeCobrancaTotalBoletosExpirados", StringUtil.LTrimStr( (decimal)(AV10CarteiraDeCobrancaTotalBoletosExpirados), 8, 0));
         AV15CarteiraDeCobrancaTotalBoletosCancelados = AV6CarteiraDeCobranca.gxTpr_Carteiradecobrancatotalboletoscancelados;
         AssignAttri("", false, "AV15CarteiraDeCobrancaTotalBoletosCancelados", StringUtil.LTrimStr( (decimal)(AV15CarteiraDeCobrancaTotalBoletosCancelados), 8, 0));
         /*  Sending Event outputs  */
         cmbavCarteiradecobrancastatus.CurrentValue = StringUtil.BoolToStr( AV8CarteiraDeCobrancaStatus);
         AssignProp("", false, cmbavCarteiradecobrancastatus_Internalname, "Values", cmbavCarteiradecobrancastatus.ToJavascriptSource(), true);
      }

      protected void nextLoad( )
      {
      }

      protected void E13AB2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV5CarteiraDeCobrancaId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV5CarteiraDeCobrancaId", StringUtil.LTrimStr( (decimal)(AV5CarteiraDeCobrancaId), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vCARTEIRADECOBRANCAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5CarteiraDeCobrancaId), "ZZZZZZZZ9"), context));
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
         PAAB2( ) ;
         WSAB2( ) ;
         WEAB2( ) ;
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
         if ( ! ( WebComp_Wcboletoww == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcboletoww_Component) != 0 )
            {
               WebComp_Wcboletoww.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019292237", true, true);
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
         context.AddJavascriptSource("carteiraboletos.js", "?202561019292237", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavCarteiradecobrancastatus.Name = "vCARTEIRADECOBRANCASTATUS";
         cmbavCarteiradecobrancastatus.WebTags = "";
         cmbavCarteiradecobrancastatus.addItem(StringUtil.BoolToStr( true), "Ativo", 0);
         cmbavCarteiradecobrancastatus.addItem(StringUtil.BoolToStr( false), "Inativo", 0);
         if ( cmbavCarteiradecobrancastatus.ItemCount > 0 )
         {
            AV8CarteiraDeCobrancaStatus = StringUtil.StrToBool( cmbavCarteiradecobrancastatus.getValidValue(StringUtil.BoolToStr( AV8CarteiraDeCobrancaStatus)));
            AssignAttri("", false, "AV8CarteiraDeCobrancaStatus", AV8CarteiraDeCobrancaStatus);
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavCarteiradecobrancanome_Internalname = "vCARTEIRADECOBRANCANOME";
         cmbavCarteiradecobrancastatus_Internalname = "vCARTEIRADECOBRANCASTATUS";
         edtavCarteiradecobrancaconvenio_Internalname = "vCARTEIRADECOBRANCACONVENIO";
         edtavCarteiradecobrancatotalboletos_Internalname = "vCARTEIRADECOBRANCATOTALBOLETOS";
         edtavCarteiradecobrancatotalboletosregistrados_Internalname = "vCARTEIRADECOBRANCATOTALBOLETOSREGISTRADOS";
         edtavCarteiradecobrancatotalboletosexpirados_Internalname = "vCARTEIRADECOBRANCATOTALBOLETOSEXPIRADOS";
         edtavCarteiradecobrancatotalboletoscancelados_Internalname = "vCARTEIRADECOBRANCATOTALBOLETOSCANCELADOS";
         edtavCarteiradecobrancavalortotal_Internalname = "vCARTEIRADECOBRANCAVALORTOTAL";
         edtavCarteiradecobrancavalorrecebido_Internalname = "vCARTEIRADECOBRANCAVALORRECEBIDO";
         divTableinfo_Internalname = "TABLEINFO";
         Dvpanel_tableinfo_Internalname = "DVPANEL_TABLEINFO";
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
         edtavCarteiradecobrancavalorrecebido_Jsonclick = "";
         edtavCarteiradecobrancavalorrecebido_Enabled = 1;
         edtavCarteiradecobrancavalortotal_Jsonclick = "";
         edtavCarteiradecobrancavalortotal_Enabled = 1;
         edtavCarteiradecobrancatotalboletoscancelados_Jsonclick = "";
         edtavCarteiradecobrancatotalboletoscancelados_Enabled = 1;
         edtavCarteiradecobrancatotalboletosexpirados_Jsonclick = "";
         edtavCarteiradecobrancatotalboletosexpirados_Enabled = 1;
         edtavCarteiradecobrancatotalboletosregistrados_Jsonclick = "";
         edtavCarteiradecobrancatotalboletosregistrados_Enabled = 1;
         edtavCarteiradecobrancatotalboletos_Jsonclick = "";
         edtavCarteiradecobrancatotalboletos_Enabled = 1;
         edtavCarteiradecobrancaconvenio_Jsonclick = "";
         edtavCarteiradecobrancaconvenio_Enabled = 1;
         cmbavCarteiradecobrancastatus_Jsonclick = "";
         cmbavCarteiradecobrancastatus.Enabled = 1;
         edtavCarteiradecobrancanome_Jsonclick = "";
         edtavCarteiradecobrancanome_Enabled = 1;
         Dvpanel_tableinfo_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableinfo_Iconposition = "Right";
         Dvpanel_tableinfo_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableinfo_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableinfo_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_tableinfo_Title = "Informações";
         Dvpanel_tableinfo_Cls = "PanelCard_GrayTitle";
         Dvpanel_tableinfo_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableinfo_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableinfo_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Boletos na Carteira de Cobrança";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV5CarteiraDeCobrancaId","fld":"vCARTEIRADECOBRANCAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV7CarteiraDeCobrancaNome","fld":"vCARTEIRADECOBRANCANOME","type":"svchar"},{"av":"AV11CarteiraDeCobrancaConvenio","fld":"vCARTEIRADECOBRANCACONVENIO","type":"svchar"},{"av":"cmbavCarteiradecobrancastatus"},{"av":"AV8CarteiraDeCobrancaStatus","fld":"vCARTEIRADECOBRANCASTATUS","type":"boolean"},{"av":"AV12CarteiraDeCobrancaValorTotal","fld":"vCARTEIRADECOBRANCAVALORTOTAL","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV13CarteiraDeCobrancaValorRecebido","fld":"vCARTEIRADECOBRANCAVALORRECEBIDO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV9CarteiraDeCobrancaTotalBoletos","fld":"vCARTEIRADECOBRANCATOTALBOLETOS","pic":"ZZZZZZZ9","type":"int"},{"av":"AV14CarteiraDeCobrancaTotalBoletosRegistrados","fld":"vCARTEIRADECOBRANCATOTALBOLETOSREGISTRADOS","pic":"ZZZZZZZ9","type":"int"},{"av":"AV10CarteiraDeCobrancaTotalBoletosExpirados","fld":"vCARTEIRADECOBRANCATOTALBOLETOSEXPIRADOS","pic":"ZZZZZZZ9","type":"int"},{"av":"AV15CarteiraDeCobrancaTotalBoletosCancelados","fld":"vCARTEIRADECOBRANCATOTALBOLETOSCANCELADOS","pic":"ZZZZZZZ9","type":"int"}]}""");
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
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableinfo = new GXUserControl();
         TempTags = "";
         AV7CarteiraDeCobrancaNome = "";
         AV11CarteiraDeCobrancaConvenio = "";
         WebComp_Wcboletoww_Component = "";
         OldWcboletoww = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV6CarteiraDeCobranca = new SdtCarteiraDeCobranca(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         WebComp_Wcboletoww = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
         edtavCarteiradecobrancanome_Enabled = 0;
         cmbavCarteiradecobrancastatus.Enabled = 0;
         edtavCarteiradecobrancaconvenio_Enabled = 0;
         edtavCarteiradecobrancatotalboletos_Enabled = 0;
         edtavCarteiradecobrancatotalboletosregistrados_Enabled = 0;
         edtavCarteiradecobrancatotalboletosexpirados_Enabled = 0;
         edtavCarteiradecobrancatotalboletoscancelados_Enabled = 0;
         edtavCarteiradecobrancavalortotal_Enabled = 0;
         edtavCarteiradecobrancavalorrecebido_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int AV5CarteiraDeCobrancaId ;
      private int wcpOAV5CarteiraDeCobrancaId ;
      private int edtavCarteiradecobrancanome_Enabled ;
      private int edtavCarteiradecobrancaconvenio_Enabled ;
      private int AV9CarteiraDeCobrancaTotalBoletos ;
      private int edtavCarteiradecobrancatotalboletos_Enabled ;
      private int AV14CarteiraDeCobrancaTotalBoletosRegistrados ;
      private int edtavCarteiradecobrancatotalboletosregistrados_Enabled ;
      private int AV10CarteiraDeCobrancaTotalBoletosExpirados ;
      private int edtavCarteiradecobrancatotalboletosexpirados_Enabled ;
      private int AV15CarteiraDeCobrancaTotalBoletosCancelados ;
      private int edtavCarteiradecobrancatotalboletoscancelados_Enabled ;
      private int edtavCarteiradecobrancavalortotal_Enabled ;
      private int edtavCarteiradecobrancavalorrecebido_Enabled ;
      private int idxLst ;
      private decimal AV12CarteiraDeCobrancaValorTotal ;
      private decimal AV13CarteiraDeCobrancaValorRecebido ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Dvpanel_tableinfo_Width ;
      private string Dvpanel_tableinfo_Cls ;
      private string Dvpanel_tableinfo_Title ;
      private string Dvpanel_tableinfo_Iconposition ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tableinfo_Internalname ;
      private string divTableinfo_Internalname ;
      private string edtavCarteiradecobrancanome_Internalname ;
      private string TempTags ;
      private string edtavCarteiradecobrancanome_Jsonclick ;
      private string cmbavCarteiradecobrancastatus_Internalname ;
      private string cmbavCarteiradecobrancastatus_Jsonclick ;
      private string edtavCarteiradecobrancaconvenio_Internalname ;
      private string edtavCarteiradecobrancaconvenio_Jsonclick ;
      private string edtavCarteiradecobrancatotalboletos_Internalname ;
      private string edtavCarteiradecobrancatotalboletos_Jsonclick ;
      private string edtavCarteiradecobrancatotalboletosregistrados_Internalname ;
      private string edtavCarteiradecobrancatotalboletosregistrados_Jsonclick ;
      private string edtavCarteiradecobrancatotalboletosexpirados_Internalname ;
      private string edtavCarteiradecobrancatotalboletosexpirados_Jsonclick ;
      private string edtavCarteiradecobrancatotalboletoscancelados_Internalname ;
      private string edtavCarteiradecobrancatotalboletoscancelados_Jsonclick ;
      private string edtavCarteiradecobrancavalortotal_Internalname ;
      private string edtavCarteiradecobrancavalortotal_Jsonclick ;
      private string edtavCarteiradecobrancavalorrecebido_Internalname ;
      private string edtavCarteiradecobrancavalorrecebido_Jsonclick ;
      private string WebComp_Wcboletoww_Component ;
      private string OldWcboletoww ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Dvpanel_tableinfo_Autowidth ;
      private bool Dvpanel_tableinfo_Autoheight ;
      private bool Dvpanel_tableinfo_Collapsible ;
      private bool Dvpanel_tableinfo_Collapsed ;
      private bool Dvpanel_tableinfo_Showcollapseicon ;
      private bool Dvpanel_tableinfo_Autoscroll ;
      private bool wbLoad ;
      private bool AV8CarteiraDeCobrancaStatus ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool bDynCreated_Wcboletoww ;
      private string AV7CarteiraDeCobrancaNome ;
      private string AV11CarteiraDeCobrancaConvenio ;
      private GXWebComponent WebComp_Wcboletoww ;
      private GXUserControl ucDvpanel_tableinfo ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavCarteiradecobrancastatus ;
      private SdtCarteiraDeCobranca AV6CarteiraDeCobranca ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
