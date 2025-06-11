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
   public class wpropostaclinica : GXWebComponent
   {
      public wpropostaclinica( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
      }

      public wpropostaclinica( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WebSessionKey ,
                           string aP1_PreviousStep ,
                           bool aP2_GoingBack )
      {
         this.AV6WebSessionKey = aP0_WebSessionKey;
         this.AV8PreviousStep = aP1_PreviousStep;
         this.AV7GoingBack = aP2_GoingBack;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "WebSessionKey");
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  AV6WebSessionKey = GetPar( "WebSessionKey");
                  AssignAttri(sPrefix, false, "AV6WebSessionKey", AV6WebSessionKey);
                  AV8PreviousStep = GetPar( "PreviousStep");
                  AssignAttri(sPrefix, false, "AV8PreviousStep", AV8PreviousStep);
                  AV7GoingBack = StringUtil.StrToBool( GetPar( "GoingBack"));
                  AssignAttri(sPrefix, false, "AV7GoingBack", AV7GoingBack);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV6WebSessionKey,(string)AV8PreviousStep,(bool)AV7GoingBack});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
                  gxfirstwebparm = GetFirstPar( "WebSessionKey");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "WebSessionKey");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
               {
                  gxnrGrid_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
               {
                  gxgrGrid_refresh_invoke( ) ;
                  return  ;
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
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_20 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_20"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_20_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_20_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_20_idx = GetPar( "sGXsfl_20_idx");
         sPrefix = GetPar( "sPrefix");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid_newrow( ) ;
         /* End function gxnrGrid_newrow_invoke */
      }

      protected void gxgrGrid_refresh_invoke( )
      {
         subGrid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid_Rows"), "."), 18, MidpointRounding.ToEven));
         AV7GoingBack = StringUtil.StrToBool( GetPar( "GoingBack"));
         A174ClienteStatus = StringUtil.StrToBool( GetPar( "ClienteStatus"));
         n174ClienteStatus = false;
         A207TipoClientePortal = StringUtil.StrToBool( GetPar( "TipoClientePortal"));
         n207TipoClientePortal = false;
         A172ClienteTipoPessoa = GetPar( "ClienteTipoPessoa");
         n172ClienteTipoPessoa = false;
         A170ClienteRazaoSocial = GetPar( "ClienteRazaoSocial");
         n170ClienteRazaoSocial = false;
         AV27Filtro = GetPar( "Filtro");
         A169ClienteDocumento = GetPar( "ClienteDocumento");
         n169ClienteDocumento = false;
         A171ClienteNomeFantasia = GetPar( "ClienteNomeFantasia");
         n171ClienteNomeFantasia = false;
         A168ClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "ClienteId"), "."), 18, MidpointRounding.ToEven));
         AV10HasValidationErrors = StringUtil.StrToBool( GetPar( "HasValidationErrors"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV7GoingBack, A174ClienteStatus, A207TipoClientePortal, A172ClienteTipoPessoa, A170ClienteRazaoSocial, AV27Filtro, A169ClienteDocumento, A171ClienteNomeFantasia, A168ClienteId, AV10HasValidationErrors, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA7G2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavSelecionar_Enabled = 0;
               AssignProp(sPrefix, false, edtavSelecionar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSelecionar_Enabled), 5, 0), !bGXsfl_20_Refreshing);
               edtavClienterazaosocial_Enabled = 0;
               AssignProp(sPrefix, false, edtavClienterazaosocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClienterazaosocial_Enabled), 5, 0), !bGXsfl_20_Refreshing);
               edtavClientenomefantasia_Enabled = 0;
               AssignProp(sPrefix, false, edtavClientenomefantasia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientenomefantasia_Enabled), 5, 0), !bGXsfl_20_Refreshing);
               edtavClientedocumento_Enabled = 0;
               AssignProp(sPrefix, false, edtavClientedocumento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientedocumento_Enabled), 5, 0), !bGXsfl_20_Refreshing);
               edtavGridclienteid_Enabled = 0;
               AssignProp(sPrefix, false, edtavGridclienteid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGridclienteid_Enabled), 5, 0), !bGXsfl_20_Refreshing);
               WS7G2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( "WProposta Clinica") ;
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
         }
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
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
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
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wpropostaclinica"+UrlEncode(StringUtil.RTrim(AV6WebSessionKey)) + "," + UrlEncode(StringUtil.RTrim(AV8PreviousStep)) + "," + UrlEncode(StringUtil.BoolToStr(AV7GoingBack));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpropostaclinica") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_20", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_20), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6WebSessionKey", wcpOAV6WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8PreviousStep", wcpOAV8PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV7GoingBack", wcpOAV7GoingBack);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV7GoingBack);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"CLIENTESTATUS", A174ClienteStatus);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"TIPOCLIENTEPORTAL", A207TipoClientePortal);
         GxWebStd.gx_hidden_field( context, sPrefix+"CLIENTETIPOPESSOA", A172ClienteTipoPessoa);
         GxWebStd.gx_hidden_field( context, sPrefix+"CLIENTERAZAOSOCIAL", A170ClienteRazaoSocial);
         GxWebStd.gx_hidden_field( context, sPrefix+"CLIENTEDOCUMENTO", A169ClienteDocumento);
         GxWebStd.gx_hidden_field( context, sPrefix+"CLIENTENOMEFANTASIA", A171ClienteNomeFantasia);
         GxWebStd.gx_hidden_field( context, sPrefix+"CLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV6WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV8PreviousStep);
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"subGrid_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Recordcount), 5, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm7G2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "WPropostaClinica" ;
      }

      public override string GetPgmdesc( )
      {
         return "WProposta Clinica" ;
      }

      protected void WB7G0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wpropostaclinica");
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablegrid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavFiltro_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFiltro_Internalname, "Razão social", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'" + sPrefix + "',false,'" + sGXsfl_20_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFiltro_Internalname, AV27Filtro, StringUtil.RTrim( context.localUtil.Format( AV27Filtro, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,17);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFiltro_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavFiltro_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPropostaClinica.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell HasGridEmpowerer", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl20( ) ;
         }
         if ( wbEnd == 20 )
         {
            wbEnd = 0;
            nRC_GXsfl_20 = (int)(nGXsfl_20_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
               GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 ActionGroupFixedBottomWizard", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;justify-content:space-between;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* User Defined Control */
            ucBtnwizardfirstprevious.SetProperty("TooltipText", Btnwizardfirstprevious_Tooltiptext);
            ucBtnwizardfirstprevious.SetProperty("BeforeIconClass", Btnwizardfirstprevious_Beforeiconclass);
            ucBtnwizardfirstprevious.SetProperty("Caption", Btnwizardfirstprevious_Caption);
            ucBtnwizardfirstprevious.SetProperty("Class", Btnwizardfirstprevious_Class);
            ucBtnwizardfirstprevious.Render(context, "wwp_iconbutton", Btnwizardfirstprevious_Internalname, sPrefix+"BTNWIZARDFIRSTPREVIOUSContainer");
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
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'" + sPrefix + "',false,'" + sGXsfl_20_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClienteid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18ClienteId), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV18ClienteId), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClienteid_Jsonclick, 0, "Attribute", "", "", "", "", edtavClienteid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPropostaClinica.htm");
            /* User Defined Control */
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, sPrefix+"GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 20 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
                  GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START7G2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET 18_0_12-186073", 0) ;
               }
            }
            Form.Meta.addItem("description", "WProposta Clinica", 0) ;
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP7G0( ) ;
            }
         }
      }

      protected void WS7G2( )
      {
         START7G2( ) ;
         EVT7G2( ) ;
      }

      protected void EVT7G2( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'WIZARDPREVIOUS'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardPrevious' */
                                    E117G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavSelecionar_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7G0( ) ;
                              }
                              sEvt = cgiGet( sPrefix+"GRIDPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "VSELECIONAR.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "VSELECIONAR.CLICK") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7G0( ) ;
                              }
                              nGXsfl_20_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
                              SubsflControlProps_202( ) ;
                              AV16Selecionar = cgiGet( edtavSelecionar_Internalname);
                              AssignAttri(sPrefix, false, edtavSelecionar_Internalname, AV16Selecionar);
                              AV13ClienteRazaoSocial = StringUtil.Upper( cgiGet( edtavClienterazaosocial_Internalname));
                              AssignAttri(sPrefix, false, edtavClienterazaosocial_Internalname, AV13ClienteRazaoSocial);
                              GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCLIENTERAZAOSOCIAL"+"_"+sGXsfl_20_idx, GetSecureSignedToken( sPrefix+sGXsfl_20_idx, StringUtil.RTrim( context.localUtil.Format( AV13ClienteRazaoSocial, "@!")), context));
                              AV14ClienteNomeFantasia = StringUtil.Upper( cgiGet( edtavClientenomefantasia_Internalname));
                              AssignAttri(sPrefix, false, edtavClientenomefantasia_Internalname, AV14ClienteNomeFantasia);
                              GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCLIENTENOMEFANTASIA"+"_"+sGXsfl_20_idx, GetSecureSignedToken( sPrefix+sGXsfl_20_idx, StringUtil.RTrim( context.localUtil.Format( AV14ClienteNomeFantasia, "@!")), context));
                              AV15ClienteDocumento = cgiGet( edtavClientedocumento_Internalname);
                              AssignAttri(sPrefix, false, edtavClientedocumento_Internalname, AV15ClienteDocumento);
                              GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCLIENTEDOCUMENTO"+"_"+sGXsfl_20_idx, GetSecureSignedToken( sPrefix+sGXsfl_20_idx, StringUtil.RTrim( context.localUtil.Format( AV15ClienteDocumento, "")), context));
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavGridclienteid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavGridclienteid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vGRIDCLIENTEID");
                                 GX_FocusControl = edtavGridclienteid_Internalname;
                                 AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV19GridClienteId = 0;
                                 AssignAttri(sPrefix, false, edtavGridclienteid_Internalname, StringUtil.LTrimStr( (decimal)(AV19GridClienteId), 9, 0));
                                 GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vGRIDCLIENTEID"+"_"+sGXsfl_20_idx, GetSecureSignedToken( sPrefix+sGXsfl_20_idx, context.localUtil.Format( (decimal)(AV19GridClienteId), "ZZZZZZZZ9"), context));
                              }
                              else
                              {
                                 AV19GridClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavGridclienteid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                                 AssignAttri(sPrefix, false, edtavGridclienteid_Internalname, StringUtil.LTrimStr( (decimal)(AV19GridClienteId), 9, 0));
                                 GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vGRIDCLIENTEID"+"_"+sGXsfl_20_idx, GetSecureSignedToken( sPrefix+sGXsfl_20_idx, context.localUtil.Format( (decimal)(AV19GridClienteId), "ZZZZZZZZ9"), context));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSelecionar_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E127G2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSelecionar_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E137G2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSelecionar_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Grid.Load */
                                          E147G2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          if ( ! wbErr )
                                          {
                                             Rfr0gs = false;
                                             if ( ! Rfr0gs )
                                             {
                                                /* Execute user event: Enter */
                                                E157G2 ();
                                             }
                                             dynload_actions( ) ;
                                          }
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VSELECIONAR.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSelecionar_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E167G2 ();
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP7G0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSelecionar_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                       }
                                    }
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE7G2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm7G2( ) ;
            }
         }
      }

      protected void PA7G2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            if ( StringUtil.Len( sPrefix) == 0 )
            {
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpropostaclinica")), "wpropostaclinica") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpropostaclinica")))) ;
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
            }
            if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               if ( StringUtil.Len( sPrefix) == 0 )
               {
                  if ( nGotPars == 0 )
                  {
                     entryPointCalled = false;
                     gxfirstwebparm = GetFirstPar( "WebSessionKey");
                     toggleJsOutput = isJsOutputEnabled( );
                     if ( context.isSpaRequest( ) )
                     {
                        disableJsOutput();
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
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavFiltro_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_202( ) ;
         while ( nGXsfl_20_idx <= nRC_GXsfl_20 )
         {
            sendrow_202( ) ;
            nGXsfl_20_idx = ((subGrid_Islastpage==1)&&(nGXsfl_20_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_20_idx+1);
            sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
            SubsflControlProps_202( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       bool AV7GoingBack ,
                                       bool A174ClienteStatus ,
                                       bool A207TipoClientePortal ,
                                       string A172ClienteTipoPessoa ,
                                       string A170ClienteRazaoSocial ,
                                       string AV27Filtro ,
                                       string A169ClienteDocumento ,
                                       string A171ClienteNomeFantasia ,
                                       int A168ClienteId ,
                                       bool AV10HasValidationErrors ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF7G2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCLIENTERAZAOSOCIAL", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV13ClienteRazaoSocial, "@!")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCLIENTERAZAOSOCIAL", AV13ClienteRazaoSocial);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCLIENTENOMEFANTASIA", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV14ClienteNomeFantasia, "@!")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCLIENTENOMEFANTASIA", AV14ClienteNomeFantasia);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCLIENTEDOCUMENTO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV15ClienteDocumento, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCLIENTEDOCUMENTO", AV15ClienteDocumento);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vGRIDCLIENTEID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV19GridClienteId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19GridClienteId), 9, 0, ".", "")));
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
         RF7G2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavSelecionar_Enabled = 0;
         edtavClienterazaosocial_Enabled = 0;
         edtavClientenomefantasia_Enabled = 0;
         edtavClientedocumento_Enabled = 0;
         edtavGridclienteid_Enabled = 0;
      }

      protected void RF7G2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 20;
         /* Execute user event: Refresh */
         E137G2 ();
         nGXsfl_20_idx = 1;
         sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
         SubsflControlProps_202( ) ;
         bGXsfl_20_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", sPrefix);
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithBorderColor WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         if ( subGrid_Islastpage != 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordcount( )-subGrid_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
            GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_202( ) ;
            /* Execute user event: Grid.Load */
            E147G2 ();
            if ( ( subGrid_Islastpage == 0 ) && ( GRID_nCurrentRecord > 0 ) && ( GRID_nGridOutOfScope == 0 ) && ( nGXsfl_20_idx == 1 ) )
            {
               GRID_nCurrentRecord = 0;
               GRID_nGridOutOfScope = 1;
               subgrid_firstpage( ) ;
               /* Execute user event: Grid.Load */
               E147G2 ();
            }
            wbEnd = 20;
            WB7G0( ) ;
         }
         bGXsfl_20_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes7G2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCLIENTERAZAOSOCIAL"+"_"+sGXsfl_20_idx, GetSecureSignedToken( sPrefix+sGXsfl_20_idx, StringUtil.RTrim( context.localUtil.Format( AV13ClienteRazaoSocial, "@!")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCLIENTENOMEFANTASIA"+"_"+sGXsfl_20_idx, GetSecureSignedToken( sPrefix+sGXsfl_20_idx, StringUtil.RTrim( context.localUtil.Format( AV14ClienteNomeFantasia, "@!")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCLIENTEDOCUMENTO"+"_"+sGXsfl_20_idx, GetSecureSignedToken( sPrefix+sGXsfl_20_idx, StringUtil.RTrim( context.localUtil.Format( AV15ClienteDocumento, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vGRIDCLIENTEID"+"_"+sGXsfl_20_idx, GetSecureSignedToken( sPrefix+sGXsfl_20_idx, context.localUtil.Format( (decimal)(AV19GridClienteId), "ZZZZZZZZ9"), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         return (int)(((subGrid_Recordcount==0) ? GRID_nFirstRecordOnPage+1 : subGrid_Recordcount)) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(((subGrid_Islastpage==1) ? NumberUtil.Int( (long)(Math.Round(subGrid_fnc_Recordcount( )/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+((((int)((subGrid_fnc_Recordcount( )) % (subGrid_fnc_Recordsperpage( ))))==0) ? 0 : 1) : NumberUtil.Int( (long)(Math.Round(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1)) ;
      }

      protected short subgrid_firstpage( )
      {
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV7GoingBack, A174ClienteStatus, A207TipoClientePortal, A172ClienteTipoPessoa, A170ClienteRazaoSocial, AV27Filtro, A169ClienteDocumento, A171ClienteNomeFantasia, A168ClienteId, AV10HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV7GoingBack, A174ClienteStatus, A207TipoClientePortal, A172ClienteTipoPessoa, A170ClienteRazaoSocial, AV27Filtro, A169ClienteDocumento, A171ClienteNomeFantasia, A168ClienteId, AV10HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV7GoingBack, A174ClienteStatus, A207TipoClientePortal, A172ClienteTipoPessoa, A170ClienteRazaoSocial, AV27Filtro, A169ClienteDocumento, A171ClienteNomeFantasia, A168ClienteId, AV10HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         subGrid_Islastpage = 1;
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV7GoingBack, A174ClienteStatus, A207TipoClientePortal, A172ClienteTipoPessoa, A170ClienteRazaoSocial, AV27Filtro, A169ClienteDocumento, A171ClienteNomeFantasia, A168ClienteId, AV10HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV7GoingBack, A174ClienteStatus, A207TipoClientePortal, A172ClienteTipoPessoa, A170ClienteRazaoSocial, AV27Filtro, A169ClienteDocumento, A171ClienteNomeFantasia, A168ClienteId, AV10HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtavSelecionar_Enabled = 0;
         edtavClienterazaosocial_Enabled = 0;
         edtavClientenomefantasia_Enabled = 0;
         edtavClientedocumento_Enabled = 0;
         edtavGridclienteid_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP7G0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E127G2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_20 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_20"), ",", "."), 18, MidpointRounding.ToEven));
            wcpOAV6WebSessionKey = cgiGet( sPrefix+"wcpOAV6WebSessionKey");
            wcpOAV8PreviousStep = cgiGet( sPrefix+"wcpOAV8PreviousStep");
            wcpOAV7GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV7GoingBack"));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            subGrid_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"subGrid_Recordcount"), ",", "."), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV27Filtro = cgiGet( edtavFiltro_Internalname);
            AssignAttri(sPrefix, false, "AV27Filtro", AV27Filtro);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavClienteid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavClienteid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCLIENTEID");
               GX_FocusControl = edtavClienteid_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV18ClienteId = 0;
               AssignAttri(sPrefix, false, "AV18ClienteId", StringUtil.LTrimStr( (decimal)(AV18ClienteId), 9, 0));
            }
            else
            {
               AV18ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavClienteid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV18ClienteId", StringUtil.LTrimStr( (decimal)(AV18ClienteId), 9, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E127G2 ();
         if (returnInSub) return;
      }

      protected void E127G2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
         edtavClienteid_Visible = 0;
         AssignProp(sPrefix, false, edtavClienteid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClienteid_Visible), 5, 0), true);
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, sPrefix, false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         subGrid_Rows = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
      }

      protected void E137G2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      private void E147G2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV27Filtro ,
                                              A170ClienteRazaoSocial ,
                                              A174ClienteStatus ,
                                              A207TipoClientePortal ,
                                              A172ClienteTipoPessoa } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV27Filtro = StringUtil.Concat( StringUtil.RTrim( AV27Filtro), "%", "");
         /* Using cursor H007G2 */
         pr_default.execute(0, new Object[] {lV27Filtro});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A192TipoClienteId = H007G2_A192TipoClienteId[0];
            n192TipoClienteId = H007G2_n192TipoClienteId[0];
            A170ClienteRazaoSocial = H007G2_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = H007G2_n170ClienteRazaoSocial[0];
            A172ClienteTipoPessoa = H007G2_A172ClienteTipoPessoa[0];
            n172ClienteTipoPessoa = H007G2_n172ClienteTipoPessoa[0];
            A207TipoClientePortal = H007G2_A207TipoClientePortal[0];
            n207TipoClientePortal = H007G2_n207TipoClientePortal[0];
            A174ClienteStatus = H007G2_A174ClienteStatus[0];
            n174ClienteStatus = H007G2_n174ClienteStatus[0];
            A169ClienteDocumento = H007G2_A169ClienteDocumento[0];
            n169ClienteDocumento = H007G2_n169ClienteDocumento[0];
            A171ClienteNomeFantasia = H007G2_A171ClienteNomeFantasia[0];
            n171ClienteNomeFantasia = H007G2_n171ClienteNomeFantasia[0];
            A168ClienteId = H007G2_A168ClienteId[0];
            A207TipoClientePortal = H007G2_A207TipoClientePortal[0];
            n207TipoClientePortal = H007G2_n207TipoClientePortal[0];
            AV15ClienteDocumento = A169ClienteDocumento;
            AssignAttri(sPrefix, false, edtavClientedocumento_Internalname, AV15ClienteDocumento);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCLIENTEDOCUMENTO"+"_"+sGXsfl_20_idx, GetSecureSignedToken( sPrefix+sGXsfl_20_idx, StringUtil.RTrim( context.localUtil.Format( AV15ClienteDocumento, "")), context));
            AV14ClienteNomeFantasia = A171ClienteNomeFantasia;
            AssignAttri(sPrefix, false, edtavClientenomefantasia_Internalname, AV14ClienteNomeFantasia);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCLIENTENOMEFANTASIA"+"_"+sGXsfl_20_idx, GetSecureSignedToken( sPrefix+sGXsfl_20_idx, StringUtil.RTrim( context.localUtil.Format( AV14ClienteNomeFantasia, "@!")), context));
            AV13ClienteRazaoSocial = A170ClienteRazaoSocial;
            AssignAttri(sPrefix, false, edtavClienterazaosocial_Internalname, AV13ClienteRazaoSocial);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCLIENTERAZAOSOCIAL"+"_"+sGXsfl_20_idx, GetSecureSignedToken( sPrefix+sGXsfl_20_idx, StringUtil.RTrim( context.localUtil.Format( AV13ClienteRazaoSocial, "@!")), context));
            AV19GridClienteId = A168ClienteId;
            AssignAttri(sPrefix, false, edtavGridclienteid_Internalname, StringUtil.LTrimStr( (decimal)(AV19GridClienteId), 9, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vGRIDCLIENTEID"+"_"+sGXsfl_20_idx, GetSecureSignedToken( sPrefix+sGXsfl_20_idx, context.localUtil.Format( (decimal)(AV19GridClienteId), "ZZZZZZZZ9"), context));
            AV16Selecionar = "<i class=\"fas fa-check\"></i>";
            AssignAttri(sPrefix, false, edtavSelecionar_Internalname, AV16Selecionar);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 20;
            }
            if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_202( ) ;
            }
            GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
            subGrid_Recordcount = (int)(GRID_nCurrentRecord);
            if ( isFullAjaxMode( ) && ! bGXsfl_20_Refreshing )
            {
               DoAjaxLoad(20, GridRow);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E157G2 ();
         if (returnInSub) return;
      }

      protected void E157G2( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( ! AV10HasValidationErrors )
         {
            /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
            S132 ();
            if (returnInSub) return;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wproposta"+UrlEncode(StringUtil.RTrim("Clinica")) + "," + UrlEncode(StringUtil.RTrim("NovoCliente")) + "," + UrlEncode(StringUtil.BoolToStr(false));
            CallWebObject(formatLink("wproposta") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         /*  Sending Event outputs  */
      }

      protected void E117G2( )
      {
         /* 'WizardPrevious' Routine */
         returnInSub = false;
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S122( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ! AV7GoingBack ) )
         {
            Btnwizardfirstprevious_Visible = false;
            ucBtnwizardfirstprevious.SendProperty(context, sPrefix, false, Btnwizardfirstprevious_Internalname, "Visible", StringUtil.BoolToStr( Btnwizardfirstprevious_Visible));
         }
      }

      protected void S112( )
      {
         /* 'LOADVARIABLESFROMWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV27Filtro = AV11WizardData.gxTpr_Clinica.gxTpr_Filtro;
         AssignAttri(sPrefix, false, "AV27Filtro", AV27Filtro);
         AV18ClienteId = AV11WizardData.gxTpr_Clinica.gxTpr_Clienteid;
         AssignAttri(sPrefix, false, "AV18ClienteId", StringUtil.LTrimStr( (decimal)(AV18ClienteId), 9, 0));
      }

      protected void S132( )
      {
         /* 'SAVEVARIABLESTOWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV11WizardData.gxTpr_Clinica.gxTpr_Filtro = AV27Filtro;
         AV11WizardData.gxTpr_Clinica.gxTpr_Clienteid = AV18ClienteId;
         AV11WizardData.gxTpr_Clinica.gxTpr_Grid.Clear();
         /* Start For Each Line in Grid */
         nRC_GXsfl_20 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_20"), ",", "."), 18, MidpointRounding.ToEven));
         nGXsfl_20_fel_idx = 0;
         while ( nGXsfl_20_fel_idx < nRC_GXsfl_20 )
         {
            nGXsfl_20_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_20_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_20_fel_idx+1);
            sGXsfl_20_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_fel_idx), 4, 0), 4, "0");
            SubsflControlProps_fel_202( ) ;
            AV16Selecionar = cgiGet( edtavSelecionar_Internalname);
            AV13ClienteRazaoSocial = StringUtil.Upper( cgiGet( edtavClienterazaosocial_Internalname));
            AV14ClienteNomeFantasia = StringUtil.Upper( cgiGet( edtavClientenomefantasia_Internalname));
            AV15ClienteDocumento = cgiGet( edtavClientedocumento_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavGridclienteid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavGridclienteid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vGRIDCLIENTEID");
               GX_FocusControl = edtavGridclienteid_Internalname;
               wbErr = true;
               AV19GridClienteId = 0;
            }
            else
            {
               AV19GridClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavGridclienteid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            }
            AV17GridItem = new SdtWPropostaData_Clinica_GridItem(context);
            AV17GridItem.gxTpr_Clienterazaosocial = AV13ClienteRazaoSocial;
            AV17GridItem.gxTpr_Clientenomefantasia = AV14ClienteNomeFantasia;
            AV17GridItem.gxTpr_Clientedocumento = AV15ClienteDocumento;
            AV17GridItem.gxTpr_Gridclienteid = AV19GridClienteId;
            AV11WizardData.gxTpr_Clinica.gxTpr_Grid.Add(AV17GridItem, 0);
            /* End For Each Line */
         }
         if ( nGXsfl_20_fel_idx == 0 )
         {
            nGXsfl_20_idx = 1;
            sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
            SubsflControlProps_202( ) ;
         }
         nGXsfl_20_fel_idx = 1;
         AV5WebSession.Set(AV6WebSessionKey, AV11WizardData.ToJSonString(false, true));
      }

      protected void E167G2( )
      {
         /* Selecionar_Click Routine */
         returnInSub = false;
         new getclinicataxbyclienteid(context ).execute(  AV19GridClienteId, out  AV20ContratoTaxa, out  AV21ContratoSLA, out  AV22ContratoJurosMora, out  AV23ContratoIOFMinimo) ;
         if ( (Convert.ToDecimal(0)==AV20ContratoTaxa) )
         {
            GX_msglist.addItem("Nenhum contrato assinado para definição de valores, por favor entre em contato!");
         }
         else
         {
            AV18ClienteId = AV19GridClienteId;
            AssignAttri(sPrefix, false, "AV18ClienteId", StringUtil.LTrimStr( (decimal)(AV18ClienteId), 9, 0));
            if ( ! AV10HasValidationErrors )
            {
               /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
               S132 ();
               if (returnInSub) return;
               if ( StringUtil.Len( sPrefix) == 0 )
               {
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
                  {
                     gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
                  }
               }
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               GXEncryptionTmp = "wproposta"+UrlEncode(StringUtil.RTrim("Clinica")) + "," + UrlEncode(StringUtil.RTrim("NovoCliente")) + "," + UrlEncode(StringUtil.BoolToStr(false));
               CallWebObject(formatLink("wproposta") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
               context.wjLocDisableFrm = 1;
            }
         }
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV6WebSessionKey = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV6WebSessionKey", AV6WebSessionKey);
         AV8PreviousStep = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV8PreviousStep", AV8PreviousStep);
         AV7GoingBack = (bool)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV7GoingBack", AV7GoingBack);
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
         PA7G2( ) ;
         WS7G2( ) ;
         WE7G2( ) ;
         cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected override EncryptionType GetEncryptionType( )
      {
         return EncryptionType.SESSION ;
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlAV6WebSessionKey = (string)((string)getParm(obj,0));
         sCtrlAV8PreviousStep = (string)((string)getParm(obj,1));
         sCtrlAV7GoingBack = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA7G2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wpropostaclinica", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA7G2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV6WebSessionKey = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV6WebSessionKey", AV6WebSessionKey);
            AV8PreviousStep = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV8PreviousStep", AV8PreviousStep);
            AV7GoingBack = (bool)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV7GoingBack", AV7GoingBack);
         }
         wcpOAV6WebSessionKey = cgiGet( sPrefix+"wcpOAV6WebSessionKey");
         wcpOAV8PreviousStep = cgiGet( sPrefix+"wcpOAV8PreviousStep");
         wcpOAV7GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV7GoingBack"));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV6WebSessionKey, wcpOAV6WebSessionKey) != 0 ) || ( StringUtil.StrCmp(AV8PreviousStep, wcpOAV8PreviousStep) != 0 ) || ( AV7GoingBack != wcpOAV7GoingBack ) ) )
         {
            setjustcreated();
         }
         wcpOAV6WebSessionKey = AV6WebSessionKey;
         wcpOAV8PreviousStep = AV8PreviousStep;
         wcpOAV7GoingBack = AV7GoingBack;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV6WebSessionKey = cgiGet( sPrefix+"AV6WebSessionKey_CTRL");
         if ( StringUtil.Len( sCtrlAV6WebSessionKey) > 0 )
         {
            AV6WebSessionKey = cgiGet( sCtrlAV6WebSessionKey);
            AssignAttri(sPrefix, false, "AV6WebSessionKey", AV6WebSessionKey);
         }
         else
         {
            AV6WebSessionKey = cgiGet( sPrefix+"AV6WebSessionKey_PARM");
         }
         sCtrlAV8PreviousStep = cgiGet( sPrefix+"AV8PreviousStep_CTRL");
         if ( StringUtil.Len( sCtrlAV8PreviousStep) > 0 )
         {
            AV8PreviousStep = cgiGet( sCtrlAV8PreviousStep);
            AssignAttri(sPrefix, false, "AV8PreviousStep", AV8PreviousStep);
         }
         else
         {
            AV8PreviousStep = cgiGet( sPrefix+"AV8PreviousStep_PARM");
         }
         sCtrlAV7GoingBack = cgiGet( sPrefix+"AV7GoingBack_CTRL");
         if ( StringUtil.Len( sCtrlAV7GoingBack) > 0 )
         {
            AV7GoingBack = StringUtil.StrToBool( cgiGet( sCtrlAV7GoingBack));
            AssignAttri(sPrefix, false, "AV7GoingBack", AV7GoingBack);
         }
         else
         {
            AV7GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"AV7GoingBack_PARM"));
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA7G2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS7G2( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS7G2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV6WebSessionKey_PARM", AV6WebSessionKey);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV6WebSessionKey)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV6WebSessionKey_CTRL", StringUtil.RTrim( sCtrlAV6WebSessionKey));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8PreviousStep_PARM", AV8PreviousStep);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8PreviousStep)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8PreviousStep_CTRL", StringUtil.RTrim( sCtrlAV8PreviousStep));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7GoingBack_PARM", StringUtil.BoolToStr( AV7GoingBack));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7GoingBack)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7GoingBack_CTRL", StringUtil.RTrim( sCtrlAV7GoingBack));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE7G2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101964282", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         CloseStyles();
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("wpropostaclinica.js", "?20256101964282", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_202( )
      {
         edtavSelecionar_Internalname = sPrefix+"vSELECIONAR_"+sGXsfl_20_idx;
         edtavClienterazaosocial_Internalname = sPrefix+"vCLIENTERAZAOSOCIAL_"+sGXsfl_20_idx;
         edtavClientenomefantasia_Internalname = sPrefix+"vCLIENTENOMEFANTASIA_"+sGXsfl_20_idx;
         edtavClientedocumento_Internalname = sPrefix+"vCLIENTEDOCUMENTO_"+sGXsfl_20_idx;
         edtavGridclienteid_Internalname = sPrefix+"vGRIDCLIENTEID_"+sGXsfl_20_idx;
      }

      protected void SubsflControlProps_fel_202( )
      {
         edtavSelecionar_Internalname = sPrefix+"vSELECIONAR_"+sGXsfl_20_fel_idx;
         edtavClienterazaosocial_Internalname = sPrefix+"vCLIENTERAZAOSOCIAL_"+sGXsfl_20_fel_idx;
         edtavClientenomefantasia_Internalname = sPrefix+"vCLIENTENOMEFANTASIA_"+sGXsfl_20_fel_idx;
         edtavClientedocumento_Internalname = sPrefix+"vCLIENTEDOCUMENTO_"+sGXsfl_20_fel_idx;
         edtavGridclienteid_Internalname = sPrefix+"vGRIDCLIENTEID_"+sGXsfl_20_fel_idx;
      }

      protected void sendrow_202( )
      {
         sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
         SubsflControlProps_202( ) ;
         WB7G0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_20_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0x0);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_20_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithBorderColor WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_20_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'" + sPrefix + "',false,'" + sGXsfl_20_idx + "',20)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSelecionar_Internalname,StringUtil.RTrim( AV16Selecionar),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVSELECIONAR.CLICK."+sGXsfl_20_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSelecionar_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavSelecionar_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)20,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'" + sPrefix + "',false,'" + sGXsfl_20_idx + "',20)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavClienterazaosocial_Internalname,(string)AV13ClienteRazaoSocial,StringUtil.RTrim( context.localUtil.Format( AV13ClienteRazaoSocial, "@!")),TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,22);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavClienterazaosocial_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavClienterazaosocial_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)20,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'" + sPrefix + "',false,'" + sGXsfl_20_idx + "',20)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavClientenomefantasia_Internalname,(string)AV14ClienteNomeFantasia,StringUtil.RTrim( context.localUtil.Format( AV14ClienteNomeFantasia, "@!")),TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,23);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavClientenomefantasia_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavClientenomefantasia_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)20,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'" + sGXsfl_20_idx + "',20)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavClientedocumento_Internalname,(string)AV15ClienteDocumento,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavClientedocumento_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavClientedocumento_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)20,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavGridclienteid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19GridClienteId), 9, 0, ",", "")),StringUtil.LTrim( ((edtavGridclienteid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV19GridClienteId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV19GridClienteId), "ZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavGridclienteid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavGridclienteid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)20,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes7G2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_20_idx = ((subGrid_Islastpage==1)&&(nGXsfl_20_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_20_idx+1);
            sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
            SubsflControlProps_202( ) ;
         }
         /* End function sendrow_202 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl20( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"20\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "GridWithBorderColor WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid_Backcolorstyle == 0 )
            {
               subGrid_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid_Class) > 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Title";
               }
            }
            else
            {
               subGrid_Titlebackstyle = 1;
               if ( subGrid_Backcolorstyle == 1 )
               {
                  subGrid_Titlebackcolor = subGrid_Allbackcolor;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Razão social") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Nome fantasia") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Documento") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Cliente Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "GridWithBorderColor WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", sPrefix);
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV16Selecionar)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSelecionar_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV13ClienteRazaoSocial));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavClienterazaosocial_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV14ClienteNomeFantasia));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavClientenomefantasia_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV15ClienteDocumento));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavClientedocumento_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19GridClienteId), 9, 0, ".", ""))));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavGridclienteid_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         edtavFiltro_Internalname = sPrefix+"vFILTRO";
         edtavSelecionar_Internalname = sPrefix+"vSELECIONAR";
         edtavClienterazaosocial_Internalname = sPrefix+"vCLIENTERAZAOSOCIAL";
         edtavClientenomefantasia_Internalname = sPrefix+"vCLIENTENOMEFANTASIA";
         edtavClientedocumento_Internalname = sPrefix+"vCLIENTEDOCUMENTO";
         edtavGridclienteid_Internalname = sPrefix+"vGRIDCLIENTEID";
         divTablegrid_Internalname = sPrefix+"TABLEGRID";
         Btnwizardfirstprevious_Internalname = sPrefix+"BTNWIZARDFIRSTPREVIOUS";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavClienteid_Internalname = sPrefix+"vCLIENTEID";
         Grid_empowerer_Internalname = sPrefix+"GRID_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGrid_Internalname = sPrefix+"GRID";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         edtavGridclienteid_Jsonclick = "";
         edtavGridclienteid_Enabled = 1;
         edtavClientedocumento_Jsonclick = "";
         edtavClientedocumento_Enabled = 1;
         edtavClientenomefantasia_Jsonclick = "";
         edtavClientenomefantasia_Enabled = 1;
         edtavClienterazaosocial_Jsonclick = "";
         edtavClienterazaosocial_Enabled = 1;
         edtavSelecionar_Jsonclick = "";
         edtavSelecionar_Enabled = 1;
         subGrid_Class = "GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         Btnwizardfirstprevious_Visible = Convert.ToBoolean( -1);
         edtavClienteid_Jsonclick = "";
         edtavClienteid_Visible = 1;
         Btnwizardfirstprevious_Class = "BtnDefault ButtonWizard";
         Btnwizardfirstprevious_Caption = "Fechar";
         Btnwizardfirstprevious_Beforeiconclass = "fas fa-arrow-left";
         Btnwizardfirstprevious_Tooltiptext = "";
         edtavFiltro_Jsonclick = "";
         edtavFiltro_Enabled = 1;
         subGrid_Rows = 0;
         context.GX_msglist.DisplayMode = 1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"A174ClienteStatus","fld":"CLIENTESTATUS","type":"boolean"},{"av":"A207TipoClientePortal","fld":"TIPOCLIENTEPORTAL","type":"boolean"},{"av":"A172ClienteTipoPessoa","fld":"CLIENTETIPOPESSOA","type":"svchar"},{"av":"A170ClienteRazaoSocial","fld":"CLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV27Filtro","fld":"vFILTRO","type":"svchar"},{"av":"A169ClienteDocumento","fld":"CLIENTEDOCUMENTO","type":"svchar"},{"av":"A171ClienteNomeFantasia","fld":"CLIENTENOMEFANTASIA","pic":"@!","type":"svchar"},{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV7GoingBack","fld":"vGOINGBACK","type":"boolean"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true,"type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"Btnwizardfirstprevious_Visible","ctrl":"BTNWIZARDFIRSTPREVIOUS","prop":"Visible"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E147G2","iparms":[{"av":"A174ClienteStatus","fld":"CLIENTESTATUS","type":"boolean"},{"av":"A207TipoClientePortal","fld":"TIPOCLIENTEPORTAL","type":"boolean"},{"av":"A172ClienteTipoPessoa","fld":"CLIENTETIPOPESSOA","type":"svchar"},{"av":"A170ClienteRazaoSocial","fld":"CLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV27Filtro","fld":"vFILTRO","type":"svchar"},{"av":"A169ClienteDocumento","fld":"CLIENTEDOCUMENTO","type":"svchar"},{"av":"A171ClienteNomeFantasia","fld":"CLIENTENOMEFANTASIA","pic":"@!","type":"svchar"},{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV15ClienteDocumento","fld":"vCLIENTEDOCUMENTO","hsh":true,"type":"svchar"},{"av":"AV14ClienteNomeFantasia","fld":"vCLIENTENOMEFANTASIA","pic":"@!","hsh":true,"type":"svchar"},{"av":"AV13ClienteRazaoSocial","fld":"vCLIENTERAZAOSOCIAL","pic":"@!","hsh":true,"type":"svchar"},{"av":"AV19GridClienteId","fld":"vGRIDCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV16Selecionar","fld":"vSELECIONAR","type":"char"}]}""");
         setEventMetadata("ENTER","""{"handler":"E157G2","iparms":[{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true,"type":"boolean"},{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY","type":"svchar"},{"av":"AV27Filtro","fld":"vFILTRO","type":"svchar"},{"av":"AV18ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV13ClienteRazaoSocial","fld":"vCLIENTERAZAOSOCIAL","grid":20,"pic":"@!","hsh":true,"type":"svchar"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"nRC_GXsfl_20","ctrl":"GRID","prop":"GridRC","grid":20,"type":"int"},{"av":"AV14ClienteNomeFantasia","fld":"vCLIENTENOMEFANTASIA","grid":20,"pic":"@!","hsh":true,"type":"svchar"},{"av":"AV15ClienteDocumento","fld":"vCLIENTEDOCUMENTO","grid":20,"hsh":true,"type":"svchar"},{"av":"AV19GridClienteId","fld":"vGRIDCLIENTEID","grid":20,"pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E117G2","iparms":[]}""");
         setEventMetadata("VSELECIONAR.CLICK","""{"handler":"E167G2","iparms":[{"av":"AV19GridClienteId","fld":"vGRIDCLIENTEID","grid":20,"pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"nRC_GXsfl_20","ctrl":"GRID","prop":"GridRC","grid":20,"type":"int"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true,"type":"boolean"},{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY","type":"svchar"},{"av":"AV27Filtro","fld":"vFILTRO","type":"svchar"},{"av":"AV18ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV13ClienteRazaoSocial","fld":"vCLIENTERAZAOSOCIAL","grid":20,"pic":"@!","hsh":true,"type":"svchar"},{"av":"AV14ClienteNomeFantasia","fld":"vCLIENTENOMEFANTASIA","grid":20,"pic":"@!","hsh":true,"type":"svchar"},{"av":"AV15ClienteDocumento","fld":"vCLIENTEDOCUMENTO","grid":20,"hsh":true,"type":"svchar"}]""");
         setEventMetadata("VSELECIONAR.CLICK",""","oparms":[{"av":"AV18ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("GRID_FIRSTPAGE","""{"handler":"subgrid_firstpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"A174ClienteStatus","fld":"CLIENTESTATUS","type":"boolean"},{"av":"A207TipoClientePortal","fld":"TIPOCLIENTEPORTAL","type":"boolean"},{"av":"A172ClienteTipoPessoa","fld":"CLIENTETIPOPESSOA","type":"svchar"},{"av":"A170ClienteRazaoSocial","fld":"CLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV27Filtro","fld":"vFILTRO","type":"svchar"},{"av":"A169ClienteDocumento","fld":"CLIENTEDOCUMENTO","type":"svchar"},{"av":"A171ClienteNomeFantasia","fld":"CLIENTENOMEFANTASIA","pic":"@!","type":"svchar"},{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true,"type":"boolean"},{"av":"sPrefix","type":"char"},{"av":"AV7GoingBack","fld":"vGOINGBACK","type":"boolean"}]""");
         setEventMetadata("GRID_FIRSTPAGE",""","oparms":[{"av":"Btnwizardfirstprevious_Visible","ctrl":"BTNWIZARDFIRSTPREVIOUS","prop":"Visible"}]}""");
         setEventMetadata("GRID_PREVPAGE","""{"handler":"subgrid_previouspage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"A174ClienteStatus","fld":"CLIENTESTATUS","type":"boolean"},{"av":"A207TipoClientePortal","fld":"TIPOCLIENTEPORTAL","type":"boolean"},{"av":"A172ClienteTipoPessoa","fld":"CLIENTETIPOPESSOA","type":"svchar"},{"av":"A170ClienteRazaoSocial","fld":"CLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV27Filtro","fld":"vFILTRO","type":"svchar"},{"av":"A169ClienteDocumento","fld":"CLIENTEDOCUMENTO","type":"svchar"},{"av":"A171ClienteNomeFantasia","fld":"CLIENTENOMEFANTASIA","pic":"@!","type":"svchar"},{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true,"type":"boolean"},{"av":"sPrefix","type":"char"},{"av":"AV7GoingBack","fld":"vGOINGBACK","type":"boolean"}]""");
         setEventMetadata("GRID_PREVPAGE",""","oparms":[{"av":"Btnwizardfirstprevious_Visible","ctrl":"BTNWIZARDFIRSTPREVIOUS","prop":"Visible"}]}""");
         setEventMetadata("GRID_NEXTPAGE","""{"handler":"subgrid_nextpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"A174ClienteStatus","fld":"CLIENTESTATUS","type":"boolean"},{"av":"A207TipoClientePortal","fld":"TIPOCLIENTEPORTAL","type":"boolean"},{"av":"A172ClienteTipoPessoa","fld":"CLIENTETIPOPESSOA","type":"svchar"},{"av":"A170ClienteRazaoSocial","fld":"CLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV27Filtro","fld":"vFILTRO","type":"svchar"},{"av":"A169ClienteDocumento","fld":"CLIENTEDOCUMENTO","type":"svchar"},{"av":"A171ClienteNomeFantasia","fld":"CLIENTENOMEFANTASIA","pic":"@!","type":"svchar"},{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true,"type":"boolean"},{"av":"sPrefix","type":"char"},{"av":"AV7GoingBack","fld":"vGOINGBACK","type":"boolean"}]""");
         setEventMetadata("GRID_NEXTPAGE",""","oparms":[{"av":"Btnwizardfirstprevious_Visible","ctrl":"BTNWIZARDFIRSTPREVIOUS","prop":"Visible"}]}""");
         setEventMetadata("GRID_LASTPAGE","""{"handler":"subgrid_lastpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"A174ClienteStatus","fld":"CLIENTESTATUS","type":"boolean"},{"av":"A207TipoClientePortal","fld":"TIPOCLIENTEPORTAL","type":"boolean"},{"av":"A172ClienteTipoPessoa","fld":"CLIENTETIPOPESSOA","type":"svchar"},{"av":"A170ClienteRazaoSocial","fld":"CLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV27Filtro","fld":"vFILTRO","type":"svchar"},{"av":"A169ClienteDocumento","fld":"CLIENTEDOCUMENTO","type":"svchar"},{"av":"A171ClienteNomeFantasia","fld":"CLIENTENOMEFANTASIA","pic":"@!","type":"svchar"},{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true,"type":"boolean"},{"av":"sPrefix","type":"char"},{"av":"AV7GoingBack","fld":"vGOINGBACK","type":"boolean"},{"av":"subGrid_Recordcount","type":"int"}]""");
         setEventMetadata("GRID_LASTPAGE",""","oparms":[{"av":"Btnwizardfirstprevious_Visible","ctrl":"BTNWIZARDFIRSTPREVIOUS","prop":"Visible"}]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Gridclienteid","iparms":[]}""");
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
         wcpOAV6WebSessionKey = "";
         wcpOAV8PreviousStep = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         A172ClienteTipoPessoa = "";
         A170ClienteRazaoSocial = "";
         AV27Filtro = "";
         A169ClienteDocumento = "";
         A171ClienteNomeFantasia = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucBtnwizardfirstprevious = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV16Selecionar = "";
         AV13ClienteRazaoSocial = "";
         AV14ClienteNomeFantasia = "";
         AV15ClienteDocumento = "";
         GXDecQS = "";
         Grid_empowerer_Gridinternalname = "";
         lV27Filtro = "";
         H007G2_A192TipoClienteId = new short[1] ;
         H007G2_n192TipoClienteId = new bool[] {false} ;
         H007G2_A170ClienteRazaoSocial = new string[] {""} ;
         H007G2_n170ClienteRazaoSocial = new bool[] {false} ;
         H007G2_A172ClienteTipoPessoa = new string[] {""} ;
         H007G2_n172ClienteTipoPessoa = new bool[] {false} ;
         H007G2_A207TipoClientePortal = new bool[] {false} ;
         H007G2_n207TipoClientePortal = new bool[] {false} ;
         H007G2_A174ClienteStatus = new bool[] {false} ;
         H007G2_n174ClienteStatus = new bool[] {false} ;
         H007G2_A169ClienteDocumento = new string[] {""} ;
         H007G2_n169ClienteDocumento = new bool[] {false} ;
         H007G2_A171ClienteNomeFantasia = new string[] {""} ;
         H007G2_n171ClienteNomeFantasia = new bool[] {false} ;
         H007G2_A168ClienteId = new int[1] ;
         GridRow = new GXWebRow();
         AV11WizardData = new SdtWPropostaData(context);
         AV5WebSession = context.GetSession();
         AV17GridItem = new SdtWPropostaData_Clinica_GridItem(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV6WebSessionKey = "";
         sCtrlAV8PreviousStep = "";
         sCtrlAV7GoingBack = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpropostaclinica__default(),
            new Object[][] {
                new Object[] {
               H007G2_A192TipoClienteId, H007G2_n192TipoClienteId, H007G2_A170ClienteRazaoSocial, H007G2_n170ClienteRazaoSocial, H007G2_A172ClienteTipoPessoa, H007G2_n172ClienteTipoPessoa, H007G2_A207TipoClientePortal, H007G2_n207TipoClientePortal, H007G2_A174ClienteStatus, H007G2_n174ClienteStatus,
               H007G2_A169ClienteDocumento, H007G2_n169ClienteDocumento, H007G2_A171ClienteNomeFantasia, H007G2_n171ClienteNomeFantasia, H007G2_A168ClienteId
               }
            }
         );
         /* GeneXus formulas. */
         edtavSelecionar_Enabled = 0;
         edtavClienterazaosocial_Enabled = 0;
         edtavClientenomefantasia_Enabled = 0;
         edtavClientedocumento_Enabled = 0;
         edtavGridclienteid_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short A192TipoClienteId ;
      private short gxcookieaux ;
      private short AV21ContratoSLA ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int nRC_GXsfl_20 ;
      private int subGrid_Recordcount ;
      private int subGrid_Rows ;
      private int nGXsfl_20_idx=1 ;
      private int A168ClienteId ;
      private int edtavSelecionar_Enabled ;
      private int edtavClienterazaosocial_Enabled ;
      private int edtavClientenomefantasia_Enabled ;
      private int edtavClientedocumento_Enabled ;
      private int edtavGridclienteid_Enabled ;
      private int edtavFiltro_Enabled ;
      private int AV18ClienteId ;
      private int edtavClienteid_Visible ;
      private int AV19GridClienteId ;
      private int subGrid_Islastpage ;
      private int GRID_nGridOutOfScope ;
      private int nGXsfl_20_fel_idx=1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private decimal AV20ContratoTaxa ;
      private decimal AV22ContratoJurosMora ;
      private decimal AV23ContratoIOFMinimo ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_20_idx="0001" ;
      private string edtavSelecionar_Internalname ;
      private string edtavClienterazaosocial_Internalname ;
      private string edtavClientenomefantasia_Internalname ;
      private string edtavClientedocumento_Internalname ;
      private string edtavGridclienteid_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablegrid_Internalname ;
      private string edtavFiltro_Internalname ;
      private string TempTags ;
      private string edtavFiltro_Jsonclick ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string divTableactions_Internalname ;
      private string Btnwizardfirstprevious_Tooltiptext ;
      private string Btnwizardfirstprevious_Beforeiconclass ;
      private string Btnwizardfirstprevious_Caption ;
      private string Btnwizardfirstprevious_Class ;
      private string Btnwizardfirstprevious_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavClienteid_Internalname ;
      private string edtavClienteid_Jsonclick ;
      private string Grid_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV16Selecionar ;
      private string GXDecQS ;
      private string Grid_empowerer_Gridinternalname ;
      private string sGXsfl_20_fel_idx="0001" ;
      private string sCtrlAV6WebSessionKey ;
      private string sCtrlAV8PreviousStep ;
      private string sCtrlAV7GoingBack ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavSelecionar_Jsonclick ;
      private string edtavClienterazaosocial_Jsonclick ;
      private string edtavClientenomefantasia_Jsonclick ;
      private string edtavClientedocumento_Jsonclick ;
      private string edtavGridclienteid_Jsonclick ;
      private string subGrid_Header ;
      private bool AV7GoingBack ;
      private bool wcpOAV7GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool A174ClienteStatus ;
      private bool n174ClienteStatus ;
      private bool A207TipoClientePortal ;
      private bool n207TipoClientePortal ;
      private bool n172ClienteTipoPessoa ;
      private bool n170ClienteRazaoSocial ;
      private bool n169ClienteDocumento ;
      private bool n171ClienteNomeFantasia ;
      private bool AV10HasValidationErrors ;
      private bool bGXsfl_20_Refreshing=false ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool n192TipoClienteId ;
      private bool Btnwizardfirstprevious_Visible ;
      private string AV6WebSessionKey ;
      private string AV8PreviousStep ;
      private string wcpOAV6WebSessionKey ;
      private string wcpOAV8PreviousStep ;
      private string A172ClienteTipoPessoa ;
      private string A170ClienteRazaoSocial ;
      private string AV27Filtro ;
      private string A169ClienteDocumento ;
      private string A171ClienteNomeFantasia ;
      private string AV13ClienteRazaoSocial ;
      private string AV14ClienteNomeFantasia ;
      private string AV15ClienteDocumento ;
      private string lV27Filtro ;
      private IGxSession AV5WebSession ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucBtnwizardfirstprevious ;
      private GXUserControl ucGrid_empowerer ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] H007G2_A192TipoClienteId ;
      private bool[] H007G2_n192TipoClienteId ;
      private string[] H007G2_A170ClienteRazaoSocial ;
      private bool[] H007G2_n170ClienteRazaoSocial ;
      private string[] H007G2_A172ClienteTipoPessoa ;
      private bool[] H007G2_n172ClienteTipoPessoa ;
      private bool[] H007G2_A207TipoClientePortal ;
      private bool[] H007G2_n207TipoClientePortal ;
      private bool[] H007G2_A174ClienteStatus ;
      private bool[] H007G2_n174ClienteStatus ;
      private string[] H007G2_A169ClienteDocumento ;
      private bool[] H007G2_n169ClienteDocumento ;
      private string[] H007G2_A171ClienteNomeFantasia ;
      private bool[] H007G2_n171ClienteNomeFantasia ;
      private int[] H007G2_A168ClienteId ;
      private SdtWPropostaData AV11WizardData ;
      private SdtWPropostaData_Clinica_GridItem AV17GridItem ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpropostaclinica__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H007G2( IGxContext context ,
                                             string AV27Filtro ,
                                             string A170ClienteRazaoSocial ,
                                             bool A174ClienteStatus ,
                                             bool A207TipoClientePortal ,
                                             string A172ClienteTipoPessoa )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.TipoClienteId, T1.ClienteRazaoSocial, T1.ClienteTipoPessoa, T2.TipoClientePortal, T1.ClienteStatus, T1.ClienteDocumento, T1.ClienteNomeFantasia, T1.ClienteId FROM (Cliente T1 LEFT JOIN TipoCliente T2 ON T2.TipoClienteId = T1.TipoClienteId)";
         AddWhere(sWhereString, "(T1.ClienteStatus)");
         AddWhere(sWhereString, "(T2.TipoClientePortal)");
         AddWhere(sWhereString, "(T1.ClienteTipoPessoa = ( 'JURIDICA'))");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27Filtro)) )
         {
            AddWhere(sWhereString, "(UPPER(T1.ClienteRazaoSocial) like '%' || UPPER(:lV27Filtro) || '%')");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ClienteId";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H007G2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (bool)dynConstraints[2] , (bool)dynConstraints[3] , (string)dynConstraints[4] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmH007G2;
          prmH007G2 = new Object[] {
          new ParDef("lV27Filtro",GXType.VarChar,150,0)
          };
          def= new CursorDef[] {
              new CursorDef("H007G2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007G2,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((bool[]) buf[6])[0] = rslt.getBool(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((bool[]) buf[8])[0] = rslt.getBool(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
                return;
       }
    }

 }

}
