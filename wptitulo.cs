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
   public class wptitulo : GXDataArea
   {
      public wptitulo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wptitulo( IGxContext context )
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
         cmbavSdtitulo_titulotipo = new GXCombobox();
         chkavSdtitulo_titulodeleted = new GXCheckbox();
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
         PA4R2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START4R2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         context.WriteHtmlText( " "+"class=\"form-horizontal FormWithFixedActions\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("wptitulo") +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal FormWithFixedActions", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "vCATEGORIATITULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22CategoriaTituloId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCATEGORIATITULOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV22CategoriaTituloId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vCONTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23ContaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCONTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV23ContaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Sdtitulo", AV5SdTitulo);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Sdtitulo", AV5SdTitulo);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTITULO_CLIENTEID_DATA", AV8SdTitulo_ClienteId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTITULO_CLIENTEID_DATA", AV8SdTitulo_ClienteId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTITULO_CONTAID_DATA", AV18SdTitulo_ContaId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTITULO_CONTAID_DATA", AV18SdTitulo_ContaId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTITULO_CATEGORIATITULOID_DATA", AV19SdTitulo_CategoriaTituloId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTITULO_CATEGORIATITULOID_DATA", AV19SdTitulo_CategoriaTituloId_Data);
         }
         GxWebStd.gx_hidden_field( context, "vCOMPETENCIADATA", context.localUtil.DToC( AV11CompetenciaData, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vCATEGORIATITULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22CategoriaTituloId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCATEGORIATITULOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV22CategoriaTituloId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "CATEGORIATITULONOME", A427CategoriaTituloNome);
         GxWebStd.gx_boolean_hidden_field( context, "CATEGORIASTATUS", A431CategoriaStatus);
         GxWebStd.gx_hidden_field( context, "CATEGORIATITULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A426CategoriaTituloId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CATEGORIATITULODESCRICAO", A428CategoriaTituloDescricao);
         GxWebStd.gx_hidden_field( context, "vCONTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23ContaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCONTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV23ContaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "CONTANOMECONTA", A424ContaNomeConta);
         GxWebStd.gx_boolean_hidden_field( context, "CONTASTATUS", A430ContaStatus);
         GxWebStd.gx_hidden_field( context, "CONTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A422ContaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CLIENTENOMEFANTASIA", A171ClienteNomeFantasia);
         GxWebStd.gx_boolean_hidden_field( context, "CLIENTESTATUS", A174ClienteStatus);
         GxWebStd.gx_hidden_field( context, "CLIENTERAZAOSOCIAL", A170ClienteRazaoSocial);
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GxWebStd.gx_hidden_field( context, "vCOMPETENCIAANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12CompetenciaAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vCOMPETENCIAMES", StringUtil.LTrim( StringUtil.NToC( AV41Competenciames, 10, 2, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vCHECKREQUIREDFIELDSRESULT", AV6CheckRequiredFieldsResult);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTITULO", AV5SdTitulo);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTITULO", AV5SdTitulo);
         }
         GxWebStd.gx_hidden_field( context, "COMBO_SDTITULO_CLIENTEID_Cls", StringUtil.RTrim( Combo_sdtitulo_clienteid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_SDTITULO_CLIENTEID_Selectedvalue_set", StringUtil.RTrim( Combo_sdtitulo_clienteid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SDTITULO_CLIENTEID_Emptyitem", StringUtil.BoolToStr( Combo_sdtitulo_clienteid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_SDTITULO_CLIENTEID_Includeaddnewoption", StringUtil.BoolToStr( Combo_sdtitulo_clienteid_Includeaddnewoption));
         GxWebStd.gx_hidden_field( context, "COMBO_SDTITULO_CLIENTEID_Htmltemplate", StringUtil.RTrim( Combo_sdtitulo_clienteid_Htmltemplate));
         GxWebStd.gx_hidden_field( context, "COMBO_SDTITULO_CONTAID_Cls", StringUtil.RTrim( Combo_sdtitulo_contaid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_SDTITULO_CONTAID_Selectedvalue_set", StringUtil.RTrim( Combo_sdtitulo_contaid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SDTITULO_CONTAID_Emptyitem", StringUtil.BoolToStr( Combo_sdtitulo_contaid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_SDTITULO_CONTAID_Includeaddnewoption", StringUtil.BoolToStr( Combo_sdtitulo_contaid_Includeaddnewoption));
         GxWebStd.gx_hidden_field( context, "COMBO_SDTITULO_CATEGORIATITULOID_Cls", StringUtil.RTrim( Combo_sdtitulo_categoriatituloid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_SDTITULO_CATEGORIATITULOID_Selectedvalue_set", StringUtil.RTrim( Combo_sdtitulo_categoriatituloid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SDTITULO_CATEGORIATITULOID_Emptyitem", StringUtil.BoolToStr( Combo_sdtitulo_categoriatituloid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_SDTITULO_CATEGORIATITULOID_Includeaddnewoption", StringUtil.BoolToStr( Combo_sdtitulo_categoriatituloid_Includeaddnewoption));
         GxWebStd.gx_hidden_field( context, "COMBO_SDTITULO_CATEGORIATITULOID_Htmltemplate", StringUtil.RTrim( Combo_sdtitulo_categoriatituloid_Htmltemplate));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Width", StringUtil.RTrim( Dvpanel_tableattributes_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autowidth", StringUtil.BoolToStr( Dvpanel_tableattributes_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoheight", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Cls", StringUtil.RTrim( Dvpanel_tableattributes_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Title", StringUtil.RTrim( Dvpanel_tableattributes_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsible", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsed", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableattributes_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Iconposition", StringUtil.RTrim( Dvpanel_tableattributes_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoscroll));
         GxWebStd.gx_hidden_field( context, "COMBO_SDTITULO_CATEGORIATITULOID_Selectedvalue_get", StringUtil.RTrim( Combo_sdtitulo_categoriatituloid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_SDTITULO_CONTAID_Selectedvalue_get", StringUtil.RTrim( Combo_sdtitulo_contaid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_SDTITULO_CLIENTEID_Selectedvalue_get", StringUtil.RTrim( Combo_sdtitulo_clienteid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_SDTITULO_CLIENTEID_Ddointernalname", StringUtil.RTrim( Combo_sdtitulo_clienteid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, "COMBO_SDTITULO_CONTAID_Ddointernalname", StringUtil.RTrim( Combo_sdtitulo_contaid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, "COMBO_SDTITULO_CATEGORIATITULOID_Ddointernalname", StringUtil.RTrim( Combo_sdtitulo_categoriatituloid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, "COMBO_SDTITULO_CATEGORIATITULOID_Selectedvalue_get", StringUtil.RTrim( Combo_sdtitulo_categoriatituloid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_SDTITULO_CONTAID_Selectedvalue_get", StringUtil.RTrim( Combo_sdtitulo_contaid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_SDTITULO_CLIENTEID_Selectedvalue_get", StringUtil.RTrim( Combo_sdtitulo_clienteid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_SDTITULO_CLIENTEID_Ddointernalname", StringUtil.RTrim( Combo_sdtitulo_clienteid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, "COMBO_SDTITULO_CONTAID_Ddointernalname", StringUtil.RTrim( Combo_sdtitulo_contaid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, "COMBO_SDTITULO_CATEGORIATITULOID_Ddointernalname", StringUtil.RTrim( Combo_sdtitulo_categoriatituloid_Ddointernalname));
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
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal FormWithFixedActions" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE4R2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT4R2( ) ;
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
         return formatLink("wptitulo")  ;
      }

      public override string GetPgmname( )
      {
         return "WpTitulo" ;
      }

      public override string GetPgmdesc( )
      {
         return "Título" ;
      }

      protected void WB4R0( )
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
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table TableTransactionTemplate", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransaction TableMainFixedActions", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tableattributes.SetProperty("Width", Dvpanel_tableattributes_Width);
            ucDvpanel_tableattributes.SetProperty("AutoWidth", Dvpanel_tableattributes_Autowidth);
            ucDvpanel_tableattributes.SetProperty("AutoHeight", Dvpanel_tableattributes_Autoheight);
            ucDvpanel_tableattributes.SetProperty("Cls", Dvpanel_tableattributes_Cls);
            ucDvpanel_tableattributes.SetProperty("Title", Dvpanel_tableattributes_Title);
            ucDvpanel_tableattributes.SetProperty("Collapsible", Dvpanel_tableattributes_Collapsible);
            ucDvpanel_tableattributes.SetProperty("Collapsed", Dvpanel_tableattributes_Collapsed);
            ucDvpanel_tableattributes.SetProperty("ShowCollapseIcon", Dvpanel_tableattributes_Showcollapseicon);
            ucDvpanel_tableattributes.SetProperty("IconPosition", Dvpanel_tableattributes_Iconposition);
            ucDvpanel_tableattributes.SetProperty("AutoScroll", Dvpanel_tableattributes_Autoscroll);
            ucDvpanel_tableattributes.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableattributes_Internalname, "DVPANEL_TABLEATTRIBUTESContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEATTRIBUTESContainer"+"TableAttributes"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-md-6 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedsdtitulo_clienteid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_sdtitulo_clienteid_Internalname, "Cliente", "", "", lblTextblockcombo_sdtitulo_clienteid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpTitulo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_sdtitulo_clienteid.SetProperty("Caption", Combo_sdtitulo_clienteid_Caption);
            ucCombo_sdtitulo_clienteid.SetProperty("Cls", Combo_sdtitulo_clienteid_Cls);
            ucCombo_sdtitulo_clienteid.SetProperty("EmptyItem", Combo_sdtitulo_clienteid_Emptyitem);
            ucCombo_sdtitulo_clienteid.SetProperty("IncludeAddNewOption", Combo_sdtitulo_clienteid_Includeaddnewoption);
            ucCombo_sdtitulo_clienteid.SetProperty("DropDownOptionsData", AV8SdTitulo_ClienteId_Data);
            ucCombo_sdtitulo_clienteid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_sdtitulo_clienteid_Internalname, "COMBO_SDTITULO_CLIENTEIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-md-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSdtitulo_titulovalor_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSdtitulo_titulovalor_Internalname, "Valor", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSdtitulo_titulovalor_Internalname, StringUtil.LTrim( StringUtil.NToC( AV5SdTitulo.gxTpr_Titulovalor, 18, 2, ",", "")), StringUtil.LTrim( ((edtavSdtitulo_titulovalor_Enabled!=0) ? context.localUtil.Format( AV5SdTitulo.gxTpr_Titulovalor, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV5SdTitulo.gxTpr_Titulovalor, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSdtitulo_titulovalor_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSdtitulo_titulovalor_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpTitulo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-md-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSdtitulo_titulodesconto_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSdtitulo_titulodesconto_Internalname, "Desconto", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSdtitulo_titulodesconto_Internalname, StringUtil.LTrim( StringUtil.NToC( AV5SdTitulo.gxTpr_Titulodesconto, 18, 2, ",", "")), StringUtil.LTrim( ((edtavSdtitulo_titulodesconto_Enabled!=0) ? context.localUtil.Format( AV5SdTitulo.gxTpr_Titulodesconto, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV5SdTitulo.gxTpr_Titulodesconto, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSdtitulo_titulodesconto_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSdtitulo_titulodesconto_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpTitulo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-md-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSdtitulo_titulovencimento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSdtitulo_titulovencimento_Internalname, "Vencimento", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavSdtitulo_titulovencimento_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavSdtitulo_titulovencimento_Internalname, context.localUtil.Format(AV5SdTitulo.gxTpr_Titulovencimento, "99/99/9999"), context.localUtil.Format( AV5SdTitulo.gxTpr_Titulovencimento, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSdtitulo_titulovencimento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSdtitulo_titulovencimento_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpTitulo.htm");
            GxWebStd.gx_bitmap( context, edtavSdtitulo_titulovencimento_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavSdtitulo_titulovencimento_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WpTitulo.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavSdtitulo_titulotipo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavSdtitulo_titulotipo_Internalname, "Tipo", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavSdtitulo_titulotipo, cmbavSdtitulo_titulotipo_Internalname, StringUtil.RTrim( AV5SdTitulo.gxTpr_Titulotipo), 1, cmbavSdtitulo_titulotipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavSdtitulo_titulotipo.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "", true, 0, "HLP_WpTitulo.htm");
            cmbavSdtitulo_titulotipo.CurrentValue = StringUtil.RTrim( AV5SdTitulo.gxTpr_Titulotipo);
            AssignProp("", false, cmbavSdtitulo_titulotipo_Internalname, "Values", (string)(cmbavSdtitulo_titulotipo.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-md-6 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedsdtitulo_contaid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_sdtitulo_contaid_Internalname, "Conta", "", "", lblTextblockcombo_sdtitulo_contaid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpTitulo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_sdtitulo_contaid.SetProperty("Caption", Combo_sdtitulo_contaid_Caption);
            ucCombo_sdtitulo_contaid.SetProperty("Cls", Combo_sdtitulo_contaid_Cls);
            ucCombo_sdtitulo_contaid.SetProperty("EmptyItem", Combo_sdtitulo_contaid_Emptyitem);
            ucCombo_sdtitulo_contaid.SetProperty("IncludeAddNewOption", Combo_sdtitulo_contaid_Includeaddnewoption);
            ucCombo_sdtitulo_contaid.SetProperty("DropDownOptionsData", AV18SdTitulo_ContaId_Data);
            ucCombo_sdtitulo_contaid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_sdtitulo_contaid_Internalname, "COMBO_SDTITULO_CONTAIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-md-6 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedsdtitulo_categoriatituloid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_sdtitulo_categoriatituloid_Internalname, "Categoria", "", "", lblTextblockcombo_sdtitulo_categoriatituloid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpTitulo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_sdtitulo_categoriatituloid.SetProperty("Caption", Combo_sdtitulo_categoriatituloid_Caption);
            ucCombo_sdtitulo_categoriatituloid.SetProperty("Cls", Combo_sdtitulo_categoriatituloid_Cls);
            ucCombo_sdtitulo_categoriatituloid.SetProperty("EmptyItem", Combo_sdtitulo_categoriatituloid_Emptyitem);
            ucCombo_sdtitulo_categoriatituloid.SetProperty("IncludeAddNewOption", Combo_sdtitulo_categoriatituloid_Includeaddnewoption);
            ucCombo_sdtitulo_categoriatituloid.SetProperty("DropDownOptionsData", AV19SdTitulo_CategoriaTituloId_Data);
            ucCombo_sdtitulo_categoriatituloid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_sdtitulo_categoriatituloid_Internalname, "COMBO_SDTITULO_CATEGORIATITULOIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-md-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCompetencia2_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "align-self:center;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCompetenciaanterior_Internalname, "<i class=\"fas fa-arrow-left\"></i>", "", "", lblCompetenciaanterior_Jsonclick, "'"+""+"'"+",false,"+"'"+"e114r1_client"+"'", "", "TextBlock", 7, "", 1, 1, 0, 1, "HLP_WpTitulo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCellFL", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+edtavDmcompetencia_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDmcompetencia_Internalname, "Competência", "gx-form-item AttributeFLLabel BootstrapTooltipRightLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDmcompetencia_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10DmCompetencia), 7, 0, ",", "")), StringUtil.LTrim( ((edtavDmcompetencia_Enabled!=0) ? context.localUtil.Format( (decimal)(AV10DmCompetencia), "ZZZZ/Z9") : context.localUtil.Format( (decimal)(AV10DmCompetencia), "ZZZZ/Z9"))), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", edtavDmcompetencia_Tooltiptext, "2024/05", edtavDmcompetencia_Jsonclick, 0, "AttributeFL BootstrapTooltipRight", "", "", "", "", 1, edtavDmcompetencia_Enabled, 0, "text", "", 7, "chr", 1, "row", 7, 0, 0, 0, 0, -1, 0, true, "DmCompetencia", "end", false, "", "HLP_WpTitulo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCompetenciaproximo_Internalname, "<i class=\"fas fa-arrow-right\"></i>", "", "", lblCompetenciaproximo_Jsonclick, "'"+""+"'"+",false,"+"'"+"e124r1_client"+"'", "", "TextBlock", 7, "", 1, 1, 0, 1, "HLP_WpTitulo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs hidden-sm hidden-md hidden-lg", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCompetencia_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSdtitulo_titulocompetenciames_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSdtitulo_titulocompetenciames_Internalname, "Mês / Ano Competência", "col-sm-6 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-6 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSdtitulo_titulocompetenciames_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5SdTitulo.gxTpr_Titulocompetenciames), 4, 0, ",", "")), StringUtil.LTrim( ((edtavSdtitulo_titulocompetenciames_Enabled!=0) ? context.localUtil.Format( (decimal)(AV5SdTitulo.gxTpr_Titulocompetenciames), "ZZZ9") : context.localUtil.Format( (decimal)(AV5SdTitulo.gxTpr_Titulocompetenciames), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSdtitulo_titulocompetenciames_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavSdtitulo_titulocompetenciames_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpTitulo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSdtitulo_titulocompetenciaano_Internalname, "Ano", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSdtitulo_titulocompetenciaano_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5SdTitulo.gxTpr_Titulocompetenciaano), 4, 0, ",", "")), StringUtil.LTrim( ((edtavSdtitulo_titulocompetenciaano_Enabled!=0) ? context.localUtil.Format( (decimal)(AV5SdTitulo.gxTpr_Titulocompetenciaano), "ZZZ9") : context.localUtil.Format( (decimal)(AV5SdTitulo.gxTpr_Titulocompetenciaano), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSdtitulo_titulocompetenciaano_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavSdtitulo_titulocompetenciaano_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpTitulo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupFixedBottom CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", "Confirmar", bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpTitulo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", "Fechar", bttBtncancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpTitulo.htm");
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
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavSdtitulo_titulodeleted_Internalname, StringUtil.BoolToStr( AV5SdTitulo.gxTpr_Titulodeleted), "", "", chkavSdtitulo_titulodeleted.Visible, 1, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(90, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,90);\"");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavSdtitulo_tituloprorrogacao_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavSdtitulo_tituloprorrogacao_Internalname, context.localUtil.Format(AV5SdTitulo.gxTpr_Tituloprorrogacao, "99/99/9999"), context.localUtil.Format( AV5SdTitulo.gxTpr_Tituloprorrogacao, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSdtitulo_tituloprorrogacao_Jsonclick, 0, "Attribute", "", "", "", "", edtavSdtitulo_tituloprorrogacao_Visible, 1, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpTitulo.htm");
            GxWebStd.gx_bitmap( context, edtavSdtitulo_tituloprorrogacao_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtavSdtitulo_tituloprorrogacao_Visible==0)||(1==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WpTitulo.htm");
            context.WriteHtmlTextNl( "</div>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSdtitulo_titulocep_Internalname, AV5SdTitulo.gxTpr_Titulocep, StringUtil.RTrim( context.localUtil.Format( AV5SdTitulo.gxTpr_Titulocep, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,92);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSdtitulo_titulocep_Jsonclick, 0, "Attribute", "", "", "", "", edtavSdtitulo_titulocep_Visible, 1, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpTitulo.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSdtitulo_titulologradouro_Internalname, AV5SdTitulo.gxTpr_Titulologradouro, StringUtil.RTrim( context.localUtil.Format( AV5SdTitulo.gxTpr_Titulologradouro, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,93);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSdtitulo_titulologradouro_Jsonclick, 0, "Attribute", "", "", "", "", edtavSdtitulo_titulologradouro_Visible, 1, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpTitulo.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSdtitulo_titulocomplemento_Internalname, AV5SdTitulo.gxTpr_Titulocomplemento, StringUtil.RTrim( context.localUtil.Format( AV5SdTitulo.gxTpr_Titulocomplemento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,94);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSdtitulo_titulocomplemento_Jsonclick, 0, "Attribute", "", "", "", "", edtavSdtitulo_titulocomplemento_Visible, 1, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpTitulo.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSdtitulo_titulobairro_Internalname, AV5SdTitulo.gxTpr_Titulobairro, StringUtil.RTrim( context.localUtil.Format( AV5SdTitulo.gxTpr_Titulobairro, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,95);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSdtitulo_titulobairro_Jsonclick, 0, "Attribute", "", "", "", "", edtavSdtitulo_titulobairro_Visible, 1, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpTitulo.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSdtitulo_titulomunicipio_Internalname, AV5SdTitulo.gxTpr_Titulomunicipio, StringUtil.RTrim( context.localUtil.Format( AV5SdTitulo.gxTpr_Titulomunicipio, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSdtitulo_titulomunicipio_Jsonclick, 0, "Attribute", "", "", "", "", edtavSdtitulo_titulomunicipio_Visible, 1, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpTitulo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START4R2( )
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
         Form.Meta.addItem("description", "Título", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4R0( ) ;
      }

      protected void WS4R2( )
      {
         START4R2( ) ;
         EVT4R2( ) ;
      }

      protected void EVT4R2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_SDTITULO_CLIENTEID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_sdtitulo_clienteid.Onoptionclicked */
                              E134R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_SDTITULO_CONTAID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_sdtitulo_contaid.Onoptionclicked */
                              E144R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_SDTITULO_CATEGORIATITULOID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_sdtitulo_categoriatituloid.Onoptionclicked */
                              E154R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E164R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDMCOMPETENCIA.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E174R2 ();
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
                                    E184R2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E194R2 ();
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

      protected void WE4R2( )
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

      protected void PA4R2( )
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
               GX_FocusControl = edtavSdtitulo_titulovalor_Internalname;
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
         if ( cmbavSdtitulo_titulotipo.ItemCount > 0 )
         {
            AV5SdTitulo.gxTpr_Titulotipo = cmbavSdtitulo_titulotipo.getValidValue(AV5SdTitulo.gxTpr_Titulotipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavSdtitulo_titulotipo.CurrentValue = StringUtil.RTrim( AV5SdTitulo.gxTpr_Titulotipo);
            AssignProp("", false, cmbavSdtitulo_titulotipo_Internalname, "Values", cmbavSdtitulo_titulotipo.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF4R2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      protected void RF4R2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E194R2 ();
            WB4R0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes4R2( )
      {
         GxWebStd.gx_hidden_field( context, "vCATEGORIATITULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22CategoriaTituloId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCATEGORIATITULOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV22CategoriaTituloId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vCONTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23ContaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCONTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV23ContaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
      }

      protected void before_start_formulas( )
      {
         Gx_date = DateTimeUtil.Today( context);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4R0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E164R2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vSDTITULO"), AV5SdTitulo);
            ajax_req_read_hidden_sdt(cgiGet( "Sdtitulo"), AV5SdTitulo);
            ajax_req_read_hidden_sdt(cgiGet( "vSDTITULO_CLIENTEID_DATA"), AV8SdTitulo_ClienteId_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vSDTITULO_CONTAID_DATA"), AV18SdTitulo_ContaId_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vSDTITULO_CATEGORIATITULOID_DATA"), AV19SdTitulo_CategoriaTituloId_Data);
            /* Read saved values. */
            AV41Competenciames = context.localUtil.CToN( cgiGet( "vCOMPETENCIAMES"), ",", ".");
            AssignAttri("", false, "AV41Competenciames", StringUtil.LTrimStr( AV41Competenciames, 10, 2));
            AV12CompetenciaAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vCOMPETENCIAANO"), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV12CompetenciaAno", StringUtil.LTrimStr( (decimal)(AV12CompetenciaAno), 4, 0));
            AV11CompetenciaData = context.localUtil.CToD( cgiGet( "vCOMPETENCIADATA"), 0);
            AssignAttri("", false, "AV11CompetenciaData", context.localUtil.Format(AV11CompetenciaData, "99/99/99"));
            Combo_sdtitulo_clienteid_Cls = cgiGet( "COMBO_SDTITULO_CLIENTEID_Cls");
            Combo_sdtitulo_clienteid_Selectedvalue_set = cgiGet( "COMBO_SDTITULO_CLIENTEID_Selectedvalue_set");
            Combo_sdtitulo_clienteid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_SDTITULO_CLIENTEID_Emptyitem"));
            Combo_sdtitulo_clienteid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_SDTITULO_CLIENTEID_Includeaddnewoption"));
            Combo_sdtitulo_clienteid_Htmltemplate = cgiGet( "COMBO_SDTITULO_CLIENTEID_Htmltemplate");
            Combo_sdtitulo_contaid_Cls = cgiGet( "COMBO_SDTITULO_CONTAID_Cls");
            Combo_sdtitulo_contaid_Selectedvalue_set = cgiGet( "COMBO_SDTITULO_CONTAID_Selectedvalue_set");
            Combo_sdtitulo_contaid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_SDTITULO_CONTAID_Emptyitem"));
            Combo_sdtitulo_contaid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_SDTITULO_CONTAID_Includeaddnewoption"));
            Combo_sdtitulo_categoriatituloid_Cls = cgiGet( "COMBO_SDTITULO_CATEGORIATITULOID_Cls");
            Combo_sdtitulo_categoriatituloid_Selectedvalue_set = cgiGet( "COMBO_SDTITULO_CATEGORIATITULOID_Selectedvalue_set");
            Combo_sdtitulo_categoriatituloid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_SDTITULO_CATEGORIATITULOID_Emptyitem"));
            Combo_sdtitulo_categoriatituloid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_SDTITULO_CATEGORIATITULOID_Includeaddnewoption"));
            Combo_sdtitulo_categoriatituloid_Htmltemplate = cgiGet( "COMBO_SDTITULO_CATEGORIATITULOID_Htmltemplate");
            Dvpanel_tableattributes_Width = cgiGet( "DVPANEL_TABLEATTRIBUTES_Width");
            Dvpanel_tableattributes_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autowidth"));
            Dvpanel_tableattributes_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoheight"));
            Dvpanel_tableattributes_Cls = cgiGet( "DVPANEL_TABLEATTRIBUTES_Cls");
            Dvpanel_tableattributes_Title = cgiGet( "DVPANEL_TABLEATTRIBUTES_Title");
            Dvpanel_tableattributes_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsible"));
            Dvpanel_tableattributes_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsed"));
            Dvpanel_tableattributes_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showcollapseicon"));
            Dvpanel_tableattributes_Iconposition = cgiGet( "DVPANEL_TABLEATTRIBUTES_Iconposition");
            Dvpanel_tableattributes_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoscroll"));
            Combo_sdtitulo_categoriatituloid_Selectedvalue_get = cgiGet( "COMBO_SDTITULO_CATEGORIATITULOID_Selectedvalue_get");
            Combo_sdtitulo_contaid_Selectedvalue_get = cgiGet( "COMBO_SDTITULO_CONTAID_Selectedvalue_get");
            Combo_sdtitulo_clienteid_Selectedvalue_get = cgiGet( "COMBO_SDTITULO_CLIENTEID_Selectedvalue_get");
            Combo_sdtitulo_clienteid_Ddointernalname = cgiGet( "COMBO_SDTITULO_CLIENTEID_Ddointernalname");
            Combo_sdtitulo_contaid_Ddointernalname = cgiGet( "COMBO_SDTITULO_CONTAID_Ddointernalname");
            Combo_sdtitulo_categoriatituloid_Ddointernalname = cgiGet( "COMBO_SDTITULO_CATEGORIATITULOID_Ddointernalname");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSdtitulo_titulovalor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSdtitulo_titulovalor_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SDTITULO_TITULOVALOR");
               GX_FocusControl = edtavSdtitulo_titulovalor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5SdTitulo.gxTpr_Titulovalor = 0;
            }
            else
            {
               AV5SdTitulo.gxTpr_Titulovalor = context.localUtil.CToN( cgiGet( edtavSdtitulo_titulovalor_Internalname), ",", ".");
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSdtitulo_titulodesconto_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSdtitulo_titulodesconto_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SDTITULO_TITULODESCONTO");
               GX_FocusControl = edtavSdtitulo_titulodesconto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5SdTitulo.gxTpr_Titulodesconto = 0;
            }
            else
            {
               AV5SdTitulo.gxTpr_Titulodesconto = context.localUtil.CToN( cgiGet( edtavSdtitulo_titulodesconto_Internalname), ",", ".");
            }
            if ( context.localUtil.VCDate( cgiGet( edtavSdtitulo_titulovencimento_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {""}), 1, "SDTITULO_TITULOVENCIMENTO");
               GX_FocusControl = edtavSdtitulo_titulovencimento_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5SdTitulo.gxTpr_Titulovencimento = DateTime.MinValue;
            }
            else
            {
               AV5SdTitulo.gxTpr_Titulovencimento = context.localUtil.CToD( cgiGet( edtavSdtitulo_titulovencimento_Internalname), 2);
            }
            cmbavSdtitulo_titulotipo.CurrentValue = cgiGet( cmbavSdtitulo_titulotipo_Internalname);
            AV5SdTitulo.gxTpr_Titulotipo = cgiGet( cmbavSdtitulo_titulotipo_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavDmcompetencia_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavDmcompetencia_Internalname), ",", ".") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vDMCOMPETENCIA");
               GX_FocusControl = edtavDmcompetencia_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10DmCompetencia = 0;
               AssignAttri("", false, "AV10DmCompetencia", StringUtil.LTrimStr( (decimal)(AV10DmCompetencia), 6, 0));
            }
            else
            {
               AV10DmCompetencia = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavDmcompetencia_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV10DmCompetencia", StringUtil.LTrimStr( (decimal)(AV10DmCompetencia), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSdtitulo_titulocompetenciames_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSdtitulo_titulocompetenciames_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SDTITULO_TITULOCOMPETENCIAMES");
               GX_FocusControl = edtavSdtitulo_titulocompetenciames_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5SdTitulo.gxTpr_Titulocompetenciames = 0;
            }
            else
            {
               AV5SdTitulo.gxTpr_Titulocompetenciames = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavSdtitulo_titulocompetenciames_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSdtitulo_titulocompetenciaano_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSdtitulo_titulocompetenciaano_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SDTITULO_TITULOCOMPETENCIAANO");
               GX_FocusControl = edtavSdtitulo_titulocompetenciaano_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5SdTitulo.gxTpr_Titulocompetenciaano = 0;
            }
            else
            {
               AV5SdTitulo.gxTpr_Titulocompetenciaano = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavSdtitulo_titulocompetenciaano_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            }
            AV5SdTitulo.gxTpr_Titulodeleted = StringUtil.StrToBool( cgiGet( chkavSdtitulo_titulodeleted_Internalname));
            if ( context.localUtil.VCDate( cgiGet( edtavSdtitulo_tituloprorrogacao_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {""}), 1, "SDTITULO_TITULOPRORROGACAO");
               GX_FocusControl = edtavSdtitulo_tituloprorrogacao_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5SdTitulo.gxTpr_Tituloprorrogacao = DateTime.MinValue;
            }
            else
            {
               AV5SdTitulo.gxTpr_Tituloprorrogacao = context.localUtil.CToD( cgiGet( edtavSdtitulo_tituloprorrogacao_Internalname), 2);
            }
            AV5SdTitulo.gxTpr_Titulocep = cgiGet( edtavSdtitulo_titulocep_Internalname);
            AV5SdTitulo.gxTpr_Titulologradouro = cgiGet( edtavSdtitulo_titulologradouro_Internalname);
            AV5SdTitulo.gxTpr_Titulocomplemento = cgiGet( edtavSdtitulo_titulocomplemento_Internalname);
            AV5SdTitulo.gxTpr_Titulobairro = cgiGet( edtavSdtitulo_titulobairro_Internalname);
            AV5SdTitulo.gxTpr_Titulomunicipio = cgiGet( edtavSdtitulo_titulomunicipio_Internalname);
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
         E164R2 ();
         if (returnInSub) return;
      }

      protected void E164R2( )
      {
         /* Start Routine */
         returnInSub = false;
         edtavDmcompetencia_Tooltiptext = "2024/05";
         AssignProp("", false, edtavDmcompetencia_Internalname, "Tooltiptext", edtavDmcompetencia_Tooltiptext, true);
         GXt_char1 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and subtitle", out  GXt_char1) ;
         Combo_sdtitulo_categoriatituloid_Htmltemplate = GXt_char1;
         ucCombo_sdtitulo_categoriatituloid.SendProperty(context, "", false, Combo_sdtitulo_categoriatituloid_Internalname, "HTMLTemplate", Combo_sdtitulo_categoriatituloid_Htmltemplate);
         GXt_char1 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and subtitle", out  GXt_char1) ;
         Combo_sdtitulo_clienteid_Htmltemplate = GXt_char1;
         ucCombo_sdtitulo_clienteid.SendProperty(context, "", false, Combo_sdtitulo_clienteid_Internalname, "HTMLTemplate", Combo_sdtitulo_clienteid_Htmltemplate);
         /* Execute user subroutine: 'LOADCOMBOSDTITULO_CLIENTEID' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOSDTITULO_CONTAID' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOSDTITULO_CATEGORIATITULOID' */
         S132 ();
         if (returnInSub) return;
         chkavSdtitulo_titulodeleted.Visible = 0;
         AssignProp("", false, chkavSdtitulo_titulodeleted_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavSdtitulo_titulodeleted.Visible), 5, 0), true);
         edtavSdtitulo_tituloprorrogacao_Visible = 0;
         AssignProp("", false, edtavSdtitulo_tituloprorrogacao_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSdtitulo_tituloprorrogacao_Visible), 5, 0), true);
         edtavSdtitulo_titulocep_Visible = 0;
         AssignProp("", false, edtavSdtitulo_titulocep_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSdtitulo_titulocep_Visible), 5, 0), true);
         edtavSdtitulo_titulologradouro_Visible = 0;
         AssignProp("", false, edtavSdtitulo_titulologradouro_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSdtitulo_titulologradouro_Visible), 5, 0), true);
         edtavSdtitulo_titulocomplemento_Visible = 0;
         AssignProp("", false, edtavSdtitulo_titulocomplemento_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSdtitulo_titulocomplemento_Visible), 5, 0), true);
         edtavSdtitulo_titulobairro_Visible = 0;
         AssignProp("", false, edtavSdtitulo_titulobairro_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSdtitulo_titulobairro_Visible), 5, 0), true);
         edtavSdtitulo_titulomunicipio_Visible = 0;
         AssignProp("", false, edtavSdtitulo_titulomunicipio_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSdtitulo_titulomunicipio_Visible), 5, 0), true);
         AV11CompetenciaData = Gx_date;
         AssignAttri("", false, "AV11CompetenciaData", context.localUtil.Format(AV11CompetenciaData, "99/99/99"));
         /* Execute user subroutine: 'AJUSTACOMPETENCIA' */
         S142 ();
         if (returnInSub) return;
      }

      protected void E154R2( )
      {
         /* Combo_sdtitulo_categoriatituloid_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Combo_sdtitulo_categoriatituloid_Selectedvalue_get, "<#NEW#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "categoriatitulo"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(AV22CategoriaTituloId,9,0));
            context.PopUp(formatLink("categoriatitulo") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         }
         else if ( StringUtil.StrCmp(Combo_sdtitulo_categoriatituloid_Selectedvalue_get, "<#POPUP_CLOSED#>") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOSDTITULO_CATEGORIATITULOID' */
            S132 ();
            if (returnInSub) return;
            AV20ComboSelectedValue = AV21Session.Get("CATEGORIATITULOID");
            AV21Session.Remove("CATEGORIATITULOID");
            Combo_sdtitulo_categoriatituloid_Selectedvalue_set = AV20ComboSelectedValue;
            ucCombo_sdtitulo_categoriatituloid.SendProperty(context, "", false, Combo_sdtitulo_categoriatituloid_Internalname, "SelectedValue_set", Combo_sdtitulo_categoriatituloid_Selectedvalue_set);
            AV5SdTitulo.gxTpr_Categoriatituloid = (int)(Math.Round(NumberUtil.Val( AV20ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         }
         else
         {
            AV5SdTitulo.gxTpr_Categoriatituloid = (int)(Math.Round(NumberUtil.Val( Combo_sdtitulo_categoriatituloid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            /* Execute user subroutine: 'LOADCOMBOSDTITULO_CATEGORIATITULOID' */
            S132 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5SdTitulo", AV5SdTitulo);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19SdTitulo_CategoriaTituloId_Data", AV19SdTitulo_CategoriaTituloId_Data);
      }

      protected void E144R2( )
      {
         /* Combo_sdtitulo_contaid_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Combo_sdtitulo_contaid_Selectedvalue_get, "<#NEW#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "conta"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(AV23ContaId,9,0));
            context.PopUp(formatLink("conta") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         }
         else if ( StringUtil.StrCmp(Combo_sdtitulo_contaid_Selectedvalue_get, "<#POPUP_CLOSED#>") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOSDTITULO_CONTAID' */
            S122 ();
            if (returnInSub) return;
            AV20ComboSelectedValue = AV21Session.Get("CONTAID");
            AV21Session.Remove("CONTAID");
            Combo_sdtitulo_contaid_Selectedvalue_set = AV20ComboSelectedValue;
            ucCombo_sdtitulo_contaid.SendProperty(context, "", false, Combo_sdtitulo_contaid_Internalname, "SelectedValue_set", Combo_sdtitulo_contaid_Selectedvalue_set);
            AV5SdTitulo.gxTpr_Contaid = (int)(Math.Round(NumberUtil.Val( AV20ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         }
         else
         {
            AV5SdTitulo.gxTpr_Contaid = (int)(Math.Round(NumberUtil.Val( Combo_sdtitulo_contaid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            /* Execute user subroutine: 'LOADCOMBOSDTITULO_CONTAID' */
            S122 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5SdTitulo", AV5SdTitulo);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18SdTitulo_ContaId_Data", AV18SdTitulo_ContaId_Data);
      }

      protected void E134R2( )
      {
         /* Combo_sdtitulo_clienteid_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Combo_sdtitulo_clienteid_Selectedvalue_get, "<#NEW#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wfornecedor"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
            context.PopUp(formatLink("wfornecedor") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         }
         else if ( StringUtil.StrCmp(Combo_sdtitulo_clienteid_Selectedvalue_get, "<#POPUP_CLOSED#>") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOSDTITULO_CLIENTEID' */
            S112 ();
            if (returnInSub) return;
            AV20ComboSelectedValue = AV21Session.Get("CLIENTEID");
            AV21Session.Remove("CLIENTEID");
            Combo_sdtitulo_clienteid_Selectedvalue_set = AV20ComboSelectedValue;
            ucCombo_sdtitulo_clienteid.SendProperty(context, "", false, Combo_sdtitulo_clienteid_Internalname, "SelectedValue_set", Combo_sdtitulo_clienteid_Selectedvalue_set);
            AV5SdTitulo.gxTpr_Clienteid = (int)(Math.Round(NumberUtil.Val( AV20ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         }
         else
         {
            AV5SdTitulo.gxTpr_Clienteid = (int)(Math.Round(NumberUtil.Val( Combo_sdtitulo_clienteid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            /* Execute user subroutine: 'LOADCOMBOSDTITULO_CLIENTEID' */
            S112 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5SdTitulo", AV5SdTitulo);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV8SdTitulo_ClienteId_Data", AV8SdTitulo_ClienteId_Data);
      }

      protected void S162( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV6CheckRequiredFieldsResult = true;
         AssignAttri("", false, "AV6CheckRequiredFieldsResult", AV6CheckRequiredFieldsResult);
         if ( (0==AV5SdTitulo.gxTpr_Clienteid) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Cliente", "", "", "", "", "", "", "", ""),  "error",  Combo_sdtitulo_clienteid_Ddointernalname,  "true",  ""));
            AV6CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV6CheckRequiredFieldsResult", AV6CheckRequiredFieldsResult);
         }
         if ( (Convert.ToDecimal(0)==AV5SdTitulo.gxTpr_Titulovalor) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Valor", "", "", "", "", "", "", "", ""),  "error",  edtavSdtitulo_titulovalor_Internalname,  "true",  ""));
            AV6CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV6CheckRequiredFieldsResult", AV6CheckRequiredFieldsResult);
         }
         if ( (DateTime.MinValue==AV5SdTitulo.gxTpr_Titulovencimento) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Vencimento", "", "", "", "", "", "", "", ""),  "error",  edtavSdtitulo_titulovencimento_Internalname,  "true",  ""));
            AV6CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV6CheckRequiredFieldsResult", AV6CheckRequiredFieldsResult);
         }
         if ( (0==AV5SdTitulo.gxTpr_Contaid) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Selecione uma conta",  "error",  Combo_sdtitulo_contaid_Ddointernalname,  "true",  ""));
            AV6CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV6CheckRequiredFieldsResult", AV6CheckRequiredFieldsResult);
         }
         if ( (0==AV5SdTitulo.gxTpr_Categoriatituloid) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Selecione uma categoria",  "error",  Combo_sdtitulo_categoriatituloid_Ddointernalname,  "true",  ""));
            AV6CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV6CheckRequiredFieldsResult", AV6CheckRequiredFieldsResult);
         }
         /* Execute user subroutine: 'VALIDACOMPETENCIA' */
         S152 ();
         if (returnInSub) return;
      }

      protected void S132( )
      {
         /* 'LOADCOMBOSDTITULO_CATEGORIATITULOID' Routine */
         returnInSub = false;
         AV19SdTitulo_CategoriaTituloId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         /* Using cursor H004R2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A431CategoriaStatus = H004R2_A431CategoriaStatus[0];
            n431CategoriaStatus = H004R2_n431CategoriaStatus[0];
            A426CategoriaTituloId = H004R2_A426CategoriaTituloId[0];
            A428CategoriaTituloDescricao = H004R2_A428CategoriaTituloDescricao[0];
            n428CategoriaTituloDescricao = H004R2_n428CategoriaTituloDescricao[0];
            A427CategoriaTituloNome = H004R2_A427CategoriaTituloNome[0];
            n427CategoriaTituloNome = H004R2_n427CategoriaTituloNome[0];
            AV9Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV9Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A426CategoriaTituloId), 9, 0));
            AV7ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV7ComboTitles.Add(A427CategoriaTituloNome, 0);
            AV7ComboTitles.Add(A428CategoriaTituloDescricao, 0);
            AV9Combo_DataItem.gxTpr_Title = AV7ComboTitles.ToJSonString(false);
            AV19SdTitulo_CategoriaTituloId_Data.Add(AV9Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         Combo_sdtitulo_categoriatituloid_Selectedvalue_set = ((0==AV5SdTitulo.gxTpr_Categoriatituloid) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV5SdTitulo.gxTpr_Categoriatituloid), 9, 0)));
         ucCombo_sdtitulo_categoriatituloid.SendProperty(context, "", false, Combo_sdtitulo_categoriatituloid_Internalname, "SelectedValue_set", Combo_sdtitulo_categoriatituloid_Selectedvalue_set);
      }

      protected void S122( )
      {
         /* 'LOADCOMBOSDTITULO_CONTAID' Routine */
         returnInSub = false;
         AV18SdTitulo_ContaId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         /* Using cursor H004R3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A430ContaStatus = H004R3_A430ContaStatus[0];
            n430ContaStatus = H004R3_n430ContaStatus[0];
            A422ContaId = H004R3_A422ContaId[0];
            A424ContaNomeConta = H004R3_A424ContaNomeConta[0];
            n424ContaNomeConta = H004R3_n424ContaNomeConta[0];
            AV9Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV9Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A422ContaId), 9, 0));
            AV9Combo_DataItem.gxTpr_Title = A424ContaNomeConta;
            AV18SdTitulo_ContaId_Data.Add(AV9Combo_DataItem, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         Combo_sdtitulo_contaid_Selectedvalue_set = ((0==AV5SdTitulo.gxTpr_Contaid) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV5SdTitulo.gxTpr_Contaid), 9, 0)));
         ucCombo_sdtitulo_contaid.SendProperty(context, "", false, Combo_sdtitulo_contaid_Internalname, "SelectedValue_set", Combo_sdtitulo_contaid_Selectedvalue_set);
      }

      protected void S112( )
      {
         /* 'LOADCOMBOSDTITULO_CLIENTEID' Routine */
         returnInSub = false;
         AV8SdTitulo_ClienteId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         /* Using cursor H004R4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A174ClienteStatus = H004R4_A174ClienteStatus[0];
            n174ClienteStatus = H004R4_n174ClienteStatus[0];
            A168ClienteId = H004R4_A168ClienteId[0];
            A170ClienteRazaoSocial = H004R4_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = H004R4_n170ClienteRazaoSocial[0];
            A171ClienteNomeFantasia = H004R4_A171ClienteNomeFantasia[0];
            n171ClienteNomeFantasia = H004R4_n171ClienteNomeFantasia[0];
            AV9Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV9Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A168ClienteId), 9, 0));
            AV7ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV7ComboTitles.Add(A171ClienteNomeFantasia, 0);
            AV7ComboTitles.Add(A170ClienteRazaoSocial, 0);
            AV9Combo_DataItem.gxTpr_Title = AV7ComboTitles.ToJSonString(false);
            AV8SdTitulo_ClienteId_Data.Add(AV9Combo_DataItem, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         Combo_sdtitulo_clienteid_Selectedvalue_set = ((0==AV5SdTitulo.gxTpr_Clienteid) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV5SdTitulo.gxTpr_Clienteid), 9, 0)));
         ucCombo_sdtitulo_clienteid.SendProperty(context, "", false, Combo_sdtitulo_clienteid_Internalname, "SelectedValue_set", Combo_sdtitulo_clienteid_Selectedvalue_set);
      }

      protected void E174R2( )
      {
         /* Dmcompetencia_Controlvaluechanged Routine */
         returnInSub = false;
         if ( StringUtil.Len( StringUtil.Str( (decimal)(AV10DmCompetencia), 6, 0)) == 5 )
         {
            AV13Ano = (short)(Math.Round(NumberUtil.Val( StringUtil.Substring( StringUtil.Trim( StringUtil.Str( (decimal)(AV10DmCompetencia), 6, 0)), 1, 4), "."), 18, MidpointRounding.ToEven));
            AV14Mes = (short)(Math.Round(NumberUtil.Val( StringUtil.Substring( StringUtil.Trim( StringUtil.Str( (decimal)(AV10DmCompetencia), 6, 0)), 5, 2), "."), 18, MidpointRounding.ToEven));
            AV10DmCompetencia = (int)(AV13Ano*100+AV14Mes);
            AssignAttri("", false, "AV10DmCompetencia", StringUtil.LTrimStr( (decimal)(AV10DmCompetencia), 6, 0));
         }
         /* Execute user subroutine: 'VALIDACOMPETENCIA' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E184R2 ();
         if (returnInSub) return;
      }

      protected void E184R2( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S162 ();
         if (returnInSub) return;
         AV5SdTitulo.gxTpr_Titulocompetenciaano = AV12CompetenciaAno;
         AV5SdTitulo.gxTpr_Titulocompetenciames = (short)(Math.Round(AV41Competenciames, 18, MidpointRounding.ToEven));
         new prgetenderecoclientebyid(context ).execute(  AV5SdTitulo.gxTpr_Clienteid, out  AV16SdEnderecoCliente) ;
         AV5SdTitulo.gxTpr_Titulocep = AV16SdEnderecoCliente.gxTpr_Enderecocep;
         AV5SdTitulo.gxTpr_Titulologradouro = AV16SdEnderecoCliente.gxTpr_Enderecologradouro;
         AV5SdTitulo.gxTpr_Titulocomplemento = AV16SdEnderecoCliente.gxTpr_Enderecocomplemento;
         AV5SdTitulo.gxTpr_Titulobairro = AV16SdEnderecoCliente.gxTpr_Enderecobairro;
         AV5SdTitulo.gxTpr_Titulomunicipio = AV16SdEnderecoCliente.gxTpr_Municipiocodigo;
         AV5SdTitulo.gxTpr_Titulonumeroendereco = AV16SdEnderecoCliente.gxTpr_Endereconumero;
         AV5SdTitulo.gxTpr_Tituloprorrogacao = AV5SdTitulo.gxTpr_Titulovencimento;
         if ( AV6CheckRequiredFieldsResult )
         {
            new prcriartitulo(context ).execute( ref  AV5SdTitulo, out  AV15SdErro) ;
            if ( AV15SdErro.gxTpr_Status == 200 )
            {
               context.CommitDataStores("wptitulo",pr_default);
               AV17WebSession.Set("WpTituloCreate", "Sucesso");
               context.setWebReturnParms(new Object[] {});
               context.setWebReturnParmsMetadata(new Object[] {});
               context.wjLocDisableFrm = 1;
               context.nUserReturn = 1;
               returnInSub = true;
               if (true) return;
            }
            else
            {
               context.RollbackDataStores("wptitulo",pr_default);
               GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Erro",  AV15SdErro.gxTpr_Msg,  "error",  "",  "true",  ""));
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5SdTitulo", AV5SdTitulo);
      }

      protected void S152( )
      {
         /* 'VALIDACOMPETENCIA' Routine */
         returnInSub = false;
         AV13Ano = (short)(Math.Round(NumberUtil.Val( StringUtil.Substring( StringUtil.Trim( StringUtil.Str( (decimal)(AV10DmCompetencia), 6, 0)), 1, 4), "."), 18, MidpointRounding.ToEven));
         AV14Mes = (short)(Math.Round(NumberUtil.Val( StringUtil.Substring( StringUtil.Trim( StringUtil.Str( (decimal)(AV10DmCompetencia), 6, 0)), 5, 2), "."), 18, MidpointRounding.ToEven));
         if ( AV13Ano - DateTimeUtil.Year( Gx_date) > 5 )
         {
            AV6CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV6CheckRequiredFieldsResult", AV6CheckRequiredFieldsResult);
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Selecione um ano dentro de 5 anos após o ano atual",  "error",  edtavDmcompetencia_Internalname,  "false",  ""));
         }
         else
         {
            if ( ( AV14Mes <= 0 ) || ( AV14Mes > 12 ) )
            {
               AV6CheckRequiredFieldsResult = false;
               AssignAttri("", false, "AV6CheckRequiredFieldsResult", AV6CheckRequiredFieldsResult);
               GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "Mês %1 não existe", StringUtil.LTrimStr( (decimal)(AV14Mes), 4, 0), "", "", "", "", "", "", "", ""),  "error",  edtavDmcompetencia_Internalname,  "false",  ""));
            }
            else
            {
               AV11CompetenciaData = context.localUtil.YMDToD( AV13Ano, AV14Mes, 1);
               AssignAttri("", false, "AV11CompetenciaData", context.localUtil.Format(AV11CompetenciaData, "99/99/99"));
            }
         }
      }

      protected void S142( )
      {
         /* 'AJUSTACOMPETENCIA' Routine */
         returnInSub = false;
         AV41Competenciames = (decimal)(DateTimeUtil.Month( AV11CompetenciaData));
         AssignAttri("", false, "AV41Competenciames", StringUtil.LTrimStr( AV41Competenciames, 10, 2));
         AV12CompetenciaAno = (short)(DateTimeUtil.Year( AV11CompetenciaData));
         AssignAttri("", false, "AV12CompetenciaAno", StringUtil.LTrimStr( (decimal)(AV12CompetenciaAno), 4, 0));
         AV10DmCompetencia = (int)(AV12CompetenciaAno*100+AV41Competenciames);
         AssignAttri("", false, "AV10DmCompetencia", StringUtil.LTrimStr( (decimal)(AV10DmCompetencia), 6, 0));
      }

      protected void nextLoad( )
      {
      }

      protected void E194R2( )
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
         PA4R2( ) ;
         WS4R2( ) ;
         WE4R2( ) ;
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
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019245548", true, true);
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
         context.AddJavascriptSource("wptitulo.js", "?202561019245549", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavSdtitulo_titulotipo.Name = "SDTITULO_TITULOTIPO";
         cmbavSdtitulo_titulotipo.WebTags = "";
         cmbavSdtitulo_titulotipo.addItem("DEBITO", "Débito", 0);
         cmbavSdtitulo_titulotipo.addItem("CREDITO", "Crédito", 0);
         if ( cmbavSdtitulo_titulotipo.ItemCount > 0 )
         {
            AV5SdTitulo.gxTpr_Titulotipo = cmbavSdtitulo_titulotipo.getValidValue(AV5SdTitulo.gxTpr_Titulotipo);
         }
         chkavSdtitulo_titulodeleted.Name = "SDTITULO_TITULODELETED";
         chkavSdtitulo_titulodeleted.WebTags = "";
         chkavSdtitulo_titulodeleted.Caption = "";
         AssignProp("", false, chkavSdtitulo_titulodeleted_Internalname, "TitleCaption", chkavSdtitulo_titulodeleted.Caption, true);
         chkavSdtitulo_titulodeleted.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblockcombo_sdtitulo_clienteid_Internalname = "TEXTBLOCKCOMBO_SDTITULO_CLIENTEID";
         Combo_sdtitulo_clienteid_Internalname = "COMBO_SDTITULO_CLIENTEID";
         divTablesplittedsdtitulo_clienteid_Internalname = "TABLESPLITTEDSDTITULO_CLIENTEID";
         edtavSdtitulo_titulovalor_Internalname = "SDTITULO_TITULOVALOR";
         edtavSdtitulo_titulodesconto_Internalname = "SDTITULO_TITULODESCONTO";
         edtavSdtitulo_titulovencimento_Internalname = "SDTITULO_TITULOVENCIMENTO";
         cmbavSdtitulo_titulotipo_Internalname = "SDTITULO_TITULOTIPO";
         lblTextblockcombo_sdtitulo_contaid_Internalname = "TEXTBLOCKCOMBO_SDTITULO_CONTAID";
         Combo_sdtitulo_contaid_Internalname = "COMBO_SDTITULO_CONTAID";
         divTablesplittedsdtitulo_contaid_Internalname = "TABLESPLITTEDSDTITULO_CONTAID";
         lblTextblockcombo_sdtitulo_categoriatituloid_Internalname = "TEXTBLOCKCOMBO_SDTITULO_CATEGORIATITULOID";
         Combo_sdtitulo_categoriatituloid_Internalname = "COMBO_SDTITULO_CATEGORIATITULOID";
         divTablesplittedsdtitulo_categoriatituloid_Internalname = "TABLESPLITTEDSDTITULO_CATEGORIATITULOID";
         lblCompetenciaanterior_Internalname = "COMPETENCIAANTERIOR";
         edtavDmcompetencia_Internalname = "vDMCOMPETENCIA";
         lblCompetenciaproximo_Internalname = "COMPETENCIAPROXIMO";
         divCompetencia2_Internalname = "COMPETENCIA2";
         edtavSdtitulo_titulocompetenciames_Internalname = "SDTITULO_TITULOCOMPETENCIAMES";
         edtavSdtitulo_titulocompetenciaano_Internalname = "SDTITULO_TITULOCOMPETENCIAANO";
         divCompetencia_Internalname = "COMPETENCIA";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         chkavSdtitulo_titulodeleted_Internalname = "SDTITULO_TITULODELETED";
         edtavSdtitulo_tituloprorrogacao_Internalname = "SDTITULO_TITULOPRORROGACAO";
         edtavSdtitulo_titulocep_Internalname = "SDTITULO_TITULOCEP";
         edtavSdtitulo_titulologradouro_Internalname = "SDTITULO_TITULOLOGRADOURO";
         edtavSdtitulo_titulocomplemento_Internalname = "SDTITULO_TITULOCOMPLEMENTO";
         edtavSdtitulo_titulobairro_Internalname = "SDTITULO_TITULOBAIRRO";
         edtavSdtitulo_titulomunicipio_Internalname = "SDTITULO_TITULOMUNICIPIO";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
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
         chkavSdtitulo_titulodeleted.Caption = "";
         edtavSdtitulo_titulomunicipio_Jsonclick = "";
         edtavSdtitulo_titulomunicipio_Visible = 1;
         edtavSdtitulo_titulobairro_Jsonclick = "";
         edtavSdtitulo_titulobairro_Visible = 1;
         edtavSdtitulo_titulocomplemento_Jsonclick = "";
         edtavSdtitulo_titulocomplemento_Visible = 1;
         edtavSdtitulo_titulologradouro_Jsonclick = "";
         edtavSdtitulo_titulologradouro_Visible = 1;
         edtavSdtitulo_titulocep_Jsonclick = "";
         edtavSdtitulo_titulocep_Visible = 1;
         edtavSdtitulo_tituloprorrogacao_Jsonclick = "";
         edtavSdtitulo_tituloprorrogacao_Visible = 1;
         chkavSdtitulo_titulodeleted.Visible = 1;
         edtavSdtitulo_titulocompetenciaano_Jsonclick = "";
         edtavSdtitulo_titulocompetenciaano_Enabled = 1;
         edtavSdtitulo_titulocompetenciames_Jsonclick = "";
         edtavSdtitulo_titulocompetenciames_Enabled = 1;
         edtavDmcompetencia_Jsonclick = "";
         edtavDmcompetencia_Tooltiptext = "";
         edtavDmcompetencia_Enabled = 1;
         cmbavSdtitulo_titulotipo_Jsonclick = "";
         cmbavSdtitulo_titulotipo.Enabled = 1;
         edtavSdtitulo_titulovencimento_Jsonclick = "";
         edtavSdtitulo_titulovencimento_Enabled = 1;
         edtavSdtitulo_titulodesconto_Jsonclick = "";
         edtavSdtitulo_titulodesconto_Enabled = 1;
         edtavSdtitulo_titulovalor_Jsonclick = "";
         edtavSdtitulo_titulovalor_Enabled = 1;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "Informações Gerais";
         Dvpanel_tableattributes_Cls = "PanelCard_GrayTitle";
         Dvpanel_tableattributes_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Width = "100%";
         Combo_sdtitulo_categoriatituloid_Htmltemplate = "";
         Combo_sdtitulo_categoriatituloid_Includeaddnewoption = Convert.ToBoolean( -1);
         Combo_sdtitulo_categoriatituloid_Emptyitem = Convert.ToBoolean( 0);
         Combo_sdtitulo_categoriatituloid_Cls = "ExtendedCombo AttributeFL ExtendedComboTitleAndSubtitle";
         Combo_sdtitulo_contaid_Includeaddnewoption = Convert.ToBoolean( -1);
         Combo_sdtitulo_contaid_Emptyitem = Convert.ToBoolean( 0);
         Combo_sdtitulo_contaid_Cls = "ExtendedCombo AttributeFL";
         Combo_sdtitulo_clienteid_Htmltemplate = "";
         Combo_sdtitulo_clienteid_Includeaddnewoption = Convert.ToBoolean( -1);
         Combo_sdtitulo_clienteid_Emptyitem = Convert.ToBoolean( 0);
         Combo_sdtitulo_clienteid_Cls = "ExtendedCombo AttributeFL ExtendedComboTitleAndSubtitle";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Título";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GXV7","fld":"SDTITULO_TITULODELETED","type":"boolean"},{"av":"AV22CategoriaTituloId","fld":"vCATEGORIATITULOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV23ContaId","fld":"vCONTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"Gx_date","fld":"vTODAY","hsh":true,"type":"date"}]}""");
         setEventMetadata("'DOCOMPETENCIAANTERIOR'","""{"handler":"E114R1","iparms":[{"av":"AV11CompetenciaData","fld":"vCOMPETENCIADATA","type":"date"}]""");
         setEventMetadata("'DOCOMPETENCIAANTERIOR'",""","oparms":[{"av":"AV11CompetenciaData","fld":"vCOMPETENCIADATA","type":"date"},{"av":"AV41Competenciames","fld":"vCOMPETENCIAMES","pic":"9999999.99","type":"decimal"},{"av":"AV12CompetenciaAno","fld":"vCOMPETENCIAANO","pic":"ZZZ9","type":"int"},{"av":"AV10DmCompetencia","fld":"vDMCOMPETENCIA","pic":"ZZZZ/Z9","type":"int"}]}""");
         setEventMetadata("'DOCOMPETENCIAPROXIMO'","""{"handler":"E124R1","iparms":[{"av":"AV11CompetenciaData","fld":"vCOMPETENCIADATA","type":"date"}]""");
         setEventMetadata("'DOCOMPETENCIAPROXIMO'",""","oparms":[{"av":"AV11CompetenciaData","fld":"vCOMPETENCIADATA","type":"date"},{"av":"AV41Competenciames","fld":"vCOMPETENCIAMES","pic":"9999999.99","type":"decimal"},{"av":"AV12CompetenciaAno","fld":"vCOMPETENCIAANO","pic":"ZZZ9","type":"int"},{"av":"AV10DmCompetencia","fld":"vDMCOMPETENCIA","pic":"ZZZZ/Z9","type":"int"}]}""");
         setEventMetadata("COMBO_SDTITULO_CATEGORIATITULOID.ONOPTIONCLICKED","""{"handler":"E154R2","iparms":[{"av":"Combo_sdtitulo_categoriatituloid_Selectedvalue_get","ctrl":"COMBO_SDTITULO_CATEGORIATITULOID","prop":"SelectedValue_get"},{"av":"AV22CategoriaTituloId","fld":"vCATEGORIATITULOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV5SdTitulo","fld":"vSDTITULO","type":""},{"av":"A427CategoriaTituloNome","fld":"CATEGORIATITULONOME","type":"svchar"},{"av":"A431CategoriaStatus","fld":"CATEGORIASTATUS","type":"boolean"},{"av":"A426CategoriaTituloId","fld":"CATEGORIATITULOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A428CategoriaTituloDescricao","fld":"CATEGORIATITULODESCRICAO","type":"svchar"}]""");
         setEventMetadata("COMBO_SDTITULO_CATEGORIATITULOID.ONOPTIONCLICKED",""","oparms":[{"av":"Combo_sdtitulo_categoriatituloid_Selectedvalue_set","ctrl":"COMBO_SDTITULO_CATEGORIATITULOID","prop":"SelectedValue_set"},{"av":"AV5SdTitulo","fld":"vSDTITULO","type":""},{"av":"AV19SdTitulo_CategoriaTituloId_Data","fld":"vSDTITULO_CATEGORIATITULOID_DATA","type":""}]}""");
         setEventMetadata("COMBO_SDTITULO_CONTAID.ONOPTIONCLICKED","""{"handler":"E144R2","iparms":[{"av":"Combo_sdtitulo_contaid_Selectedvalue_get","ctrl":"COMBO_SDTITULO_CONTAID","prop":"SelectedValue_get"},{"av":"AV23ContaId","fld":"vCONTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV5SdTitulo","fld":"vSDTITULO","type":""},{"av":"A424ContaNomeConta","fld":"CONTANOMECONTA","type":"svchar"},{"av":"A430ContaStatus","fld":"CONTASTATUS","type":"boolean"},{"av":"A422ContaId","fld":"CONTAID","pic":"ZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("COMBO_SDTITULO_CONTAID.ONOPTIONCLICKED",""","oparms":[{"av":"Combo_sdtitulo_contaid_Selectedvalue_set","ctrl":"COMBO_SDTITULO_CONTAID","prop":"SelectedValue_set"},{"av":"AV5SdTitulo","fld":"vSDTITULO","type":""},{"av":"AV18SdTitulo_ContaId_Data","fld":"vSDTITULO_CONTAID_DATA","type":""}]}""");
         setEventMetadata("COMBO_SDTITULO_CLIENTEID.ONOPTIONCLICKED","""{"handler":"E134R2","iparms":[{"av":"Combo_sdtitulo_clienteid_Selectedvalue_get","ctrl":"COMBO_SDTITULO_CLIENTEID","prop":"SelectedValue_get"},{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV5SdTitulo","fld":"vSDTITULO","type":""},{"av":"A171ClienteNomeFantasia","fld":"CLIENTENOMEFANTASIA","pic":"@!","type":"svchar"},{"av":"A174ClienteStatus","fld":"CLIENTESTATUS","type":"boolean"},{"av":"A170ClienteRazaoSocial","fld":"CLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"}]""");
         setEventMetadata("COMBO_SDTITULO_CLIENTEID.ONOPTIONCLICKED",""","oparms":[{"av":"Combo_sdtitulo_clienteid_Selectedvalue_set","ctrl":"COMBO_SDTITULO_CLIENTEID","prop":"SelectedValue_set"},{"av":"AV5SdTitulo","fld":"vSDTITULO","type":""},{"av":"AV8SdTitulo_ClienteId_Data","fld":"vSDTITULO_CLIENTEID_DATA","type":""}]}""");
         setEventMetadata("VDMCOMPETENCIA.CONTROLVALUECHANGED","""{"handler":"E174R2","iparms":[{"av":"AV10DmCompetencia","fld":"vDMCOMPETENCIA","pic":"ZZZZ/Z9","type":"int"},{"av":"Gx_date","fld":"vTODAY","hsh":true,"type":"date"}]""");
         setEventMetadata("VDMCOMPETENCIA.CONTROLVALUECHANGED",""","oparms":[{"av":"AV10DmCompetencia","fld":"vDMCOMPETENCIA","pic":"ZZZZ/Z9","type":"int"},{"av":"AV6CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"},{"av":"AV11CompetenciaData","fld":"vCOMPETENCIADATA","type":"date"}]}""");
         setEventMetadata("ENTER","""{"handler":"E184R2","iparms":[{"av":"AV12CompetenciaAno","fld":"vCOMPETENCIAANO","pic":"ZZZ9","type":"int"},{"av":"AV5SdTitulo","fld":"vSDTITULO","type":""},{"av":"AV41Competenciames","fld":"vCOMPETENCIAMES","pic":"9999999.99","type":"decimal"},{"av":"AV6CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"},{"av":"Combo_sdtitulo_clienteid_Ddointernalname","ctrl":"COMBO_SDTITULO_CLIENTEID","prop":"DDOInternalName"},{"av":"Combo_sdtitulo_contaid_Ddointernalname","ctrl":"COMBO_SDTITULO_CONTAID","prop":"DDOInternalName"},{"av":"Combo_sdtitulo_categoriatituloid_Ddointernalname","ctrl":"COMBO_SDTITULO_CATEGORIATITULOID","prop":"DDOInternalName"},{"av":"AV10DmCompetencia","fld":"vDMCOMPETENCIA","pic":"ZZZZ/Z9","type":"int"},{"av":"Gx_date","fld":"vTODAY","hsh":true,"type":"date"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV5SdTitulo","fld":"vSDTITULO","type":""},{"av":"AV6CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"},{"av":"AV11CompetenciaData","fld":"vCOMPETENCIADATA","type":"date"}]}""");
         setEventMetadata("VALIDV_GXV4","""{"handler":"Validv_Gxv4","iparms":[]}""");
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
         Combo_sdtitulo_categoriatituloid_Selectedvalue_get = "";
         Combo_sdtitulo_contaid_Selectedvalue_get = "";
         Combo_sdtitulo_clienteid_Selectedvalue_get = "";
         Combo_sdtitulo_clienteid_Ddointernalname = "";
         Combo_sdtitulo_contaid_Ddointernalname = "";
         Combo_sdtitulo_categoriatituloid_Ddointernalname = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Gx_date = DateTime.MinValue;
         GXKey = "";
         AV5SdTitulo = new SdtSdTitulo(context);
         AV8SdTitulo_ClienteId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV18SdTitulo_ContaId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV19SdTitulo_CategoriaTituloId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV11CompetenciaData = DateTime.MinValue;
         A427CategoriaTituloNome = "";
         A428CategoriaTituloDescricao = "";
         A424ContaNomeConta = "";
         A171ClienteNomeFantasia = "";
         A170ClienteRazaoSocial = "";
         Combo_sdtitulo_clienteid_Selectedvalue_set = "";
         Combo_sdtitulo_contaid_Selectedvalue_set = "";
         Combo_sdtitulo_categoriatituloid_Selectedvalue_set = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         lblTextblockcombo_sdtitulo_clienteid_Jsonclick = "";
         ucCombo_sdtitulo_clienteid = new GXUserControl();
         Combo_sdtitulo_clienteid_Caption = "";
         TempTags = "";
         lblTextblockcombo_sdtitulo_contaid_Jsonclick = "";
         ucCombo_sdtitulo_contaid = new GXUserControl();
         Combo_sdtitulo_contaid_Caption = "";
         lblTextblockcombo_sdtitulo_categoriatituloid_Jsonclick = "";
         ucCombo_sdtitulo_categoriatituloid = new GXUserControl();
         Combo_sdtitulo_categoriatituloid_Caption = "";
         lblCompetenciaanterior_Jsonclick = "";
         lblCompetenciaproximo_Jsonclick = "";
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXt_char1 = "";
         GXEncryptionTmp = "";
         AV20ComboSelectedValue = "";
         AV21Session = context.GetSession();
         H004R2_A431CategoriaStatus = new bool[] {false} ;
         H004R2_n431CategoriaStatus = new bool[] {false} ;
         H004R2_A426CategoriaTituloId = new int[1] ;
         H004R2_A428CategoriaTituloDescricao = new string[] {""} ;
         H004R2_n428CategoriaTituloDescricao = new bool[] {false} ;
         H004R2_A427CategoriaTituloNome = new string[] {""} ;
         H004R2_n427CategoriaTituloNome = new bool[] {false} ;
         AV9Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV7ComboTitles = new GxSimpleCollection<string>();
         H004R3_A430ContaStatus = new bool[] {false} ;
         H004R3_n430ContaStatus = new bool[] {false} ;
         H004R3_A422ContaId = new int[1] ;
         H004R3_A424ContaNomeConta = new string[] {""} ;
         H004R3_n424ContaNomeConta = new bool[] {false} ;
         H004R4_A174ClienteStatus = new bool[] {false} ;
         H004R4_n174ClienteStatus = new bool[] {false} ;
         H004R4_A168ClienteId = new int[1] ;
         H004R4_A170ClienteRazaoSocial = new string[] {""} ;
         H004R4_n170ClienteRazaoSocial = new bool[] {false} ;
         H004R4_A171ClienteNomeFantasia = new string[] {""} ;
         H004R4_n171ClienteNomeFantasia = new bool[] {false} ;
         AV16SdEnderecoCliente = new SdtSdEnderecoCliente(context);
         AV15SdErro = new SdtSdErro(context);
         AV17WebSession = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wptitulo__default(),
            new Object[][] {
                new Object[] {
               H004R2_A431CategoriaStatus, H004R2_n431CategoriaStatus, H004R2_A426CategoriaTituloId, H004R2_A428CategoriaTituloDescricao, H004R2_n428CategoriaTituloDescricao, H004R2_A427CategoriaTituloNome, H004R2_n427CategoriaTituloNome
               }
               , new Object[] {
               H004R3_A430ContaStatus, H004R3_n430ContaStatus, H004R3_A422ContaId, H004R3_A424ContaNomeConta, H004R3_n424ContaNomeConta
               }
               , new Object[] {
               H004R4_A174ClienteStatus, H004R4_n174ClienteStatus, H004R4_A168ClienteId, H004R4_A170ClienteRazaoSocial, H004R4_n170ClienteRazaoSocial, H004R4_A171ClienteNomeFantasia, H004R4_n171ClienteNomeFantasia
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short AV12CompetenciaAno ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV13Ano ;
      private short AV14Mes ;
      private short nGXWrapped ;
      private int AV22CategoriaTituloId ;
      private int AV23ContaId ;
      private int A426CategoriaTituloId ;
      private int A422ContaId ;
      private int A168ClienteId ;
      private int edtavSdtitulo_titulovalor_Enabled ;
      private int edtavSdtitulo_titulodesconto_Enabled ;
      private int edtavSdtitulo_titulovencimento_Enabled ;
      private int AV10DmCompetencia ;
      private int edtavDmcompetencia_Enabled ;
      private int edtavSdtitulo_titulocompetenciames_Enabled ;
      private int edtavSdtitulo_titulocompetenciaano_Enabled ;
      private int edtavSdtitulo_tituloprorrogacao_Visible ;
      private int edtavSdtitulo_titulocep_Visible ;
      private int edtavSdtitulo_titulologradouro_Visible ;
      private int edtavSdtitulo_titulocomplemento_Visible ;
      private int edtavSdtitulo_titulobairro_Visible ;
      private int edtavSdtitulo_titulomunicipio_Visible ;
      private int idxLst ;
      private decimal AV41Competenciames ;
      private string Combo_sdtitulo_categoriatituloid_Selectedvalue_get ;
      private string Combo_sdtitulo_contaid_Selectedvalue_get ;
      private string Combo_sdtitulo_clienteid_Selectedvalue_get ;
      private string Combo_sdtitulo_clienteid_Ddointernalname ;
      private string Combo_sdtitulo_contaid_Ddointernalname ;
      private string Combo_sdtitulo_categoriatituloid_Ddointernalname ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Combo_sdtitulo_clienteid_Cls ;
      private string Combo_sdtitulo_clienteid_Selectedvalue_set ;
      private string Combo_sdtitulo_clienteid_Htmltemplate ;
      private string Combo_sdtitulo_contaid_Cls ;
      private string Combo_sdtitulo_contaid_Selectedvalue_set ;
      private string Combo_sdtitulo_categoriatituloid_Cls ;
      private string Combo_sdtitulo_categoriatituloid_Selectedvalue_set ;
      private string Combo_sdtitulo_categoriatituloid_Htmltemplate ;
      private string Dvpanel_tableattributes_Width ;
      private string Dvpanel_tableattributes_Cls ;
      private string Dvpanel_tableattributes_Title ;
      private string Dvpanel_tableattributes_Iconposition ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tableattributes_Internalname ;
      private string divTableattributes_Internalname ;
      private string divTablesplittedsdtitulo_clienteid_Internalname ;
      private string lblTextblockcombo_sdtitulo_clienteid_Internalname ;
      private string lblTextblockcombo_sdtitulo_clienteid_Jsonclick ;
      private string Combo_sdtitulo_clienteid_Caption ;
      private string Combo_sdtitulo_clienteid_Internalname ;
      private string edtavSdtitulo_titulovalor_Internalname ;
      private string TempTags ;
      private string edtavSdtitulo_titulovalor_Jsonclick ;
      private string edtavSdtitulo_titulodesconto_Internalname ;
      private string edtavSdtitulo_titulodesconto_Jsonclick ;
      private string edtavSdtitulo_titulovencimento_Internalname ;
      private string edtavSdtitulo_titulovencimento_Jsonclick ;
      private string cmbavSdtitulo_titulotipo_Internalname ;
      private string cmbavSdtitulo_titulotipo_Jsonclick ;
      private string divTablesplittedsdtitulo_contaid_Internalname ;
      private string lblTextblockcombo_sdtitulo_contaid_Internalname ;
      private string lblTextblockcombo_sdtitulo_contaid_Jsonclick ;
      private string Combo_sdtitulo_contaid_Caption ;
      private string Combo_sdtitulo_contaid_Internalname ;
      private string divTablesplittedsdtitulo_categoriatituloid_Internalname ;
      private string lblTextblockcombo_sdtitulo_categoriatituloid_Internalname ;
      private string lblTextblockcombo_sdtitulo_categoriatituloid_Jsonclick ;
      private string Combo_sdtitulo_categoriatituloid_Caption ;
      private string Combo_sdtitulo_categoriatituloid_Internalname ;
      private string divCompetencia2_Internalname ;
      private string lblCompetenciaanterior_Internalname ;
      private string lblCompetenciaanterior_Jsonclick ;
      private string edtavDmcompetencia_Internalname ;
      private string edtavDmcompetencia_Tooltiptext ;
      private string edtavDmcompetencia_Jsonclick ;
      private string lblCompetenciaproximo_Internalname ;
      private string lblCompetenciaproximo_Jsonclick ;
      private string divCompetencia_Internalname ;
      private string edtavSdtitulo_titulocompetenciames_Internalname ;
      private string edtavSdtitulo_titulocompetenciames_Jsonclick ;
      private string edtavSdtitulo_titulocompetenciaano_Internalname ;
      private string edtavSdtitulo_titulocompetenciaano_Jsonclick ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string chkavSdtitulo_titulodeleted_Internalname ;
      private string edtavSdtitulo_tituloprorrogacao_Internalname ;
      private string edtavSdtitulo_tituloprorrogacao_Jsonclick ;
      private string edtavSdtitulo_titulocep_Internalname ;
      private string edtavSdtitulo_titulocep_Jsonclick ;
      private string edtavSdtitulo_titulologradouro_Internalname ;
      private string edtavSdtitulo_titulologradouro_Jsonclick ;
      private string edtavSdtitulo_titulocomplemento_Internalname ;
      private string edtavSdtitulo_titulocomplemento_Jsonclick ;
      private string edtavSdtitulo_titulobairro_Internalname ;
      private string edtavSdtitulo_titulobairro_Jsonclick ;
      private string edtavSdtitulo_titulomunicipio_Internalname ;
      private string edtavSdtitulo_titulomunicipio_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXt_char1 ;
      private string GXEncryptionTmp ;
      private DateTime Gx_date ;
      private DateTime AV11CompetenciaData ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool A431CategoriaStatus ;
      private bool A430ContaStatus ;
      private bool A174ClienteStatus ;
      private bool AV6CheckRequiredFieldsResult ;
      private bool Combo_sdtitulo_clienteid_Emptyitem ;
      private bool Combo_sdtitulo_clienteid_Includeaddnewoption ;
      private bool Combo_sdtitulo_contaid_Emptyitem ;
      private bool Combo_sdtitulo_contaid_Includeaddnewoption ;
      private bool Combo_sdtitulo_categoriatituloid_Emptyitem ;
      private bool Combo_sdtitulo_categoriatituloid_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n431CategoriaStatus ;
      private bool n428CategoriaTituloDescricao ;
      private bool n427CategoriaTituloNome ;
      private bool n430ContaStatus ;
      private bool n424ContaNomeConta ;
      private bool n174ClienteStatus ;
      private bool n170ClienteRazaoSocial ;
      private bool n171ClienteNomeFantasia ;
      private string A427CategoriaTituloNome ;
      private string A428CategoriaTituloDescricao ;
      private string A424ContaNomeConta ;
      private string A171ClienteNomeFantasia ;
      private string A170ClienteRazaoSocial ;
      private string AV20ComboSelectedValue ;
      private IGxSession AV21Session ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_sdtitulo_clienteid ;
      private GXUserControl ucCombo_sdtitulo_contaid ;
      private GXUserControl ucCombo_sdtitulo_categoriatituloid ;
      private IGxSession AV17WebSession ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavSdtitulo_titulotipo ;
      private GXCheckbox chkavSdtitulo_titulodeleted ;
      private SdtSdTitulo AV5SdTitulo ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV8SdTitulo_ClienteId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV18SdTitulo_ContaId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV19SdTitulo_CategoriaTituloId_Data ;
      private IDataStoreProvider pr_default ;
      private bool[] H004R2_A431CategoriaStatus ;
      private bool[] H004R2_n431CategoriaStatus ;
      private int[] H004R2_A426CategoriaTituloId ;
      private string[] H004R2_A428CategoriaTituloDescricao ;
      private bool[] H004R2_n428CategoriaTituloDescricao ;
      private string[] H004R2_A427CategoriaTituloNome ;
      private bool[] H004R2_n427CategoriaTituloNome ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV9Combo_DataItem ;
      private GxSimpleCollection<string> AV7ComboTitles ;
      private bool[] H004R3_A430ContaStatus ;
      private bool[] H004R3_n430ContaStatus ;
      private int[] H004R3_A422ContaId ;
      private string[] H004R3_A424ContaNomeConta ;
      private bool[] H004R3_n424ContaNomeConta ;
      private bool[] H004R4_A174ClienteStatus ;
      private bool[] H004R4_n174ClienteStatus ;
      private int[] H004R4_A168ClienteId ;
      private string[] H004R4_A170ClienteRazaoSocial ;
      private bool[] H004R4_n170ClienteRazaoSocial ;
      private string[] H004R4_A171ClienteNomeFantasia ;
      private bool[] H004R4_n171ClienteNomeFantasia ;
      private SdtSdEnderecoCliente AV16SdEnderecoCliente ;
      private SdtSdErro AV15SdErro ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wptitulo__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH004R2;
          prmH004R2 = new Object[] {
          };
          Object[] prmH004R3;
          prmH004R3 = new Object[] {
          };
          Object[] prmH004R4;
          prmH004R4 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H004R2", "SELECT CategoriaStatus, CategoriaTituloId, CategoriaTituloDescricao, CategoriaTituloNome FROM CategoriaTitulo WHERE CategoriaStatus ORDER BY CategoriaTituloNome ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004R2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H004R3", "SELECT ContaStatus, ContaId, ContaNomeConta FROM Conta WHERE ContaStatus ORDER BY ContaNomeConta ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004R3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H004R4", "SELECT ClienteStatus, ClienteId, ClienteRazaoSocial, ClienteNomeFantasia FROM Cliente WHERE ClienteStatus ORDER BY ClienteNomeFantasia ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004R4,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 1 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 2 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
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
