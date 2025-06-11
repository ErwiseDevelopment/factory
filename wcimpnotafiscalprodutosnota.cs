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
   public class wcimpnotafiscalprodutosnota : GXWebComponent
   {
      public wcimpnotafiscalprodutosnota( )
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

      public wcimpnotafiscalprodutosnota( IGxContext context )
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Fgridprodutos") == 0 )
               {
                  gxnrFgridprodutos_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Fgridprodutos") == 0 )
               {
                  gxgrFgridprodutos_refresh_invoke( ) ;
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

      protected void gxnrFgridprodutos_newrow_invoke( )
      {
         nRC_GXsfl_56 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_56"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_56_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_56_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_56_idx = GetPar( "sGXsfl_56_idx");
         sPrefix = GetPar( "sPrefix");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrFgridprodutos_newrow( ) ;
         /* End function gxnrFgridprodutos_newrow_invoke */
      }

      protected void gxgrFgridprodutos_refresh_invoke( )
      {
         AV19IsPermiteSelecionar = StringUtil.StrToBool( GetPar( "IsPermiteSelecionar"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV12Array_SdProdutoNota);
         AV10HasValidationErrors = StringUtil.StrToBool( GetPar( "HasValidationErrors"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV21EmptyWizardData);
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrFgridprodutos_refresh( AV19IsPermiteSelecionar, AV12Array_SdProdutoNota, AV10HasValidationErrors, AV21EmptyWizardData, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrFgridprodutos_refresh_invoke */
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
            PA8Q2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavTotalsel_Enabled = 0;
               AssignProp(sPrefix, false, edtavTotalsel_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTotalsel_Enabled), 5, 0), true);
               WS8Q2( ) ;
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
            context.SendWebValue( "Wc Imp Nota Fiscal Produtos Nota") ;
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
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
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
            GXEncryptionTmp = "wcimpnotafiscalprodutosnota"+UrlEncode(StringUtil.RTrim(AV6WebSessionKey)) + "," + UrlEncode(StringUtil.RTrim(AV8PreviousStep)) + "," + UrlEncode(StringUtil.BoolToStr(AV7GoingBack));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wcimpnotafiscalprodutosnota") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISPERMITESELECIONAR", AV19IsPermiteSelecionar);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISPERMITESELECIONAR", GetSecureSignedToken( sPrefix, AV19IsPermiteSelecionar, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vEMPTYWIZARDDATA", AV21EmptyWizardData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vEMPTYWIZARDDATA", AV21EmptyWizardData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vEMPTYWIZARDDATA", GetSecureSignedToken( sPrefix, AV21EmptyWizardData, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_56", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_56), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6WebSessionKey", wcpOAV6WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8PreviousStep", wcpOAV8PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV7GoingBack", wcpOAV7GoingBack);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISPERMITESELECIONAR", AV19IsPermiteSelecionar);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISPERMITESELECIONAR", GetSecureSignedToken( sPrefix, AV19IsPermiteSelecionar, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vARRAY_SDPRODUTONOTA", AV12Array_SdProdutoNota);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vARRAY_SDPRODUTONOTA", AV12Array_SdProdutoNota);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV6WebSessionKey);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vEMPTYWIZARDDATA", AV21EmptyWizardData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vEMPTYWIZARDDATA", AV21EmptyWizardData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vEMPTYWIZARDDATA", GetSecureSignedToken( sPrefix, AV21EmptyWizardData, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISMARCAR", AV18IsMarcar);
         GxWebStd.gx_hidden_field( context, sPrefix+"vID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17id), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV8PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV7GoingBack);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDPRODUTONOTAFISCAL", AV13sdProdutoNotaFiscal);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDPRODUTONOTAFISCAL", AV13sdProdutoNotaFiscal);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vGXV5", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26GXV5), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGXV4", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25GXV4), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGXV3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24GXV3), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"subFgridprodutos_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridprodutos_Recordcount), 5, 0, ",", "")));
      }

      protected void RenderHtmlCloseForm8Q2( )
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
            if ( ! ( WebComp_Wcwclinhaprodutonota == null ) )
            {
               WebComp_Wcwclinhaprodutonota.componentjscripts();
            }
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
         return "WcImpNotaFiscalProdutosNota" ;
      }

      public override string GetPgmdesc( )
      {
         return "Wc Imp Nota Fiscal Produtos Nota" ;
      }

      protected void WB8Q0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wcimpnotafiscalprodutosnota");
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "table-content-wizard", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablenotasflex_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;flex-wrap:wrap;justify-content:center;align-items:center;align-content:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLabeluploaddataxml_Internalname, "<h3>Itens</h3>", "", "", lblLabeluploaddataxml_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WcImpNotaFiscalProdutosNota.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLabeldescriptionuploaddata_Internalname, "<h4>Itens que compõe da nota fiscal</h4>", "", "", lblLabeldescriptionuploaddata_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WcImpNotaFiscalProdutosNota.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabletotal_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;flex-wrap:wrap-reverse;justify-content:center;align-items:center;align-content:flex-start;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCell DscTop", "start", "top", "", "flex-grow:1;align-self:flex-end;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtabletotalsel_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblocktotalsel_Internalname, "Total", "", "", lblTextblocktotalsel_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WcImpNotaFiscalProdutosNota.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTotalsel_Internalname, "Total Sel", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'" + sGXsfl_56_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTotalsel_Internalname, StringUtil.LTrim( StringUtil.NToC( AV16TotalSel, 18, 2, ",", "")), StringUtil.LTrim( ((edtavTotalsel_Enabled!=0) ? context.localUtil.Format( AV16TotalSel, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV16TotalSel, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,30);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTotalsel_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTotalsel_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Valor", "end", false, "", "HLP_WcImpNotaFiscalProdutosNota.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupGrouped", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnselecionatodos_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(56), 2, 0)+","+"null"+");", "Selecionar Todos", bttBtnselecionatodos_Jsonclick, 7, "Selecionar Todos", "", StyleString, ClassString, bttBtnselecionatodos_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e118q1_client"+"'", TempTags, "", 2, "HLP_WcImpNotaFiscalProdutosNota.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndesmarcartodos_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(56), 2, 0)+","+"null"+");", "Desmarcar Todos", bttBtndesmarcartodos_Jsonclick, 7, "Desmarcar Todos", "", StyleString, ClassString, bttBtndesmarcartodos_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e128q1_client"+"'", TempTags, "", 2, "HLP_WcImpNotaFiscalProdutosNota.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontentline_Internalname, 1, 0, "px", 0, "px", "cabecalho", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTitlenota_Internalname, "<h5><strong>Nota fiscal</strong></h5>", "", "", lblTitlenota_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WcImpNotaFiscalProdutosNota.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "end", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTitlecodigo_Internalname, "<h5><strong>Codigo</strong></h5>", "", "", lblTitlecodigo_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WcImpNotaFiscalProdutosNota.htm");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTitledescricao_Internalname, "<h5><strong>Descrição</strong></h5>", "", "", lblTitledescricao_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WcImpNotaFiscalProdutosNota.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1", "end", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTitlequantidade_Internalname, "<h5><strong>Quantidade</strong></h5>", "", "", lblTitlequantidade_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WcImpNotaFiscalProdutosNota.htm");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "end", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTitleunitario_Internalname, "<h5><strong>Valor Unitário</strong></h5>", "", "", lblTitleunitario_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WcImpNotaFiscalProdutosNota.htm");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "end", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTitletotal_Internalname, "<h5><strong>Total</strong></h5>", "", "", lblTitletotal_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WcImpNotaFiscalProdutosNota.htm");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            FgridprodutosContainer.SetIsFreestyle(true);
            FgridprodutosContainer.SetWrapped(nGXWrapped);
            StartGridControl56( ) ;
         }
         if ( wbEnd == 56 )
         {
            wbEnd = 0;
            nRC_GXsfl_56 = (int)(nGXsfl_56_idx-1);
            if ( FgridprodutosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"FgridprodutosContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Fgridprodutos", FgridprodutosContainer, subFgridprodutos_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"FgridprodutosContainerData", FgridprodutosContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"FgridprodutosContainerData"+"V", FgridprodutosContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"FgridprodutosContainerData"+"V"+"\" value='"+FgridprodutosContainer.GridValuesHidden()+"'/>") ;
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
            ucBtnwizardprevious.SetProperty("TooltipText", Btnwizardprevious_Tooltiptext);
            ucBtnwizardprevious.SetProperty("BeforeIconClass", Btnwizardprevious_Beforeiconclass);
            ucBtnwizardprevious.SetProperty("Caption", Btnwizardprevious_Caption);
            ucBtnwizardprevious.SetProperty("Class", Btnwizardprevious_Class);
            ucBtnwizardprevious.Render(context, "wwp_iconbutton", Btnwizardprevious_Internalname, sPrefix+"BTNWIZARDPREVIOUSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* User Defined Control */
            ucBtnwizardnext.SetProperty("TooltipText", Btnwizardnext_Tooltiptext);
            ucBtnwizardnext.SetProperty("AfterIconClass", Btnwizardnext_Aftericonclass);
            ucBtnwizardnext.SetProperty("Caption", Btnwizardnext_Caption);
            ucBtnwizardnext.SetProperty("Class", Btnwizardnext_Class);
            ucBtnwizardnext.Render(context, "wwp_iconbutton", Btnwizardnext_Internalname, sPrefix+"BTNWIZARDNEXTContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCss_Internalname, "", "", "", lblCss_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WcImpNotaFiscalProdutosNota.htm");
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
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'" + sPrefix + "',false,'" + sGXsfl_56_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavJsonsdprodutosnota_Internalname, AV20JSONSdProdutosNota, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", 0, edtavJsonsdprodutosnota_Visible, 1, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WcImpNotaFiscalProdutosNota.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 56 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( FgridprodutosContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"FgridprodutosContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Fgridprodutos", FgridprodutosContainer, subFgridprodutos_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"FgridprodutosContainerData", FgridprodutosContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"FgridprodutosContainerData"+"V", FgridprodutosContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"FgridprodutosContainerData"+"V"+"\" value='"+FgridprodutosContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START8Q2( )
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
            Form.Meta.addItem("description", "Wc Imp Nota Fiscal Produtos Nota", 0) ;
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
               STRUP8Q0( ) ;
            }
         }
      }

      protected void WS8Q2( )
      {
         START8Q2( ) ;
         EVT8Q2( ) ;
      }

      protected void EVT8Q2( )
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
                                 STRUP8Q0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8Q0( ) ;
                              }
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
                                          E138Q2 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'WIZARDPREVIOUS'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardPrevious' */
                                    E148Q2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavTotalsel_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "FGRIDPRODUTOS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8Q0( ) ;
                              }
                              nGXsfl_56_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_56_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_56_idx), 4, 0), 4, "0");
                              SubsflControlProps_562( ) ;
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
                                          GX_FocusControl = edtavTotalsel_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E158Q2 ();
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
                                          GX_FocusControl = edtavTotalsel_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E168Q2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "FGRIDPRODUTOS.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavTotalsel_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Fgridprodutos.Load */
                                          E178Q2 ();
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP8Q0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavTotalsel_Internalname;
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
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 60 )
                        {
                           sEvtType = StringUtil.Left( sEvt, 4);
                           sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           sCmpCtrl = "W0060" + sEvtType;
                           OldWcwclinhaprodutonota = cgiGet( sPrefix+sCmpCtrl);
                           if ( ( StringUtil.Len( OldWcwclinhaprodutonota) == 0 ) || ( StringUtil.StrCmp(OldWcwclinhaprodutonota, WebComp_GX_Process_Component) != 0 ) )
                           {
                              WebComp_GX_Process = getWebComponent(GetType(), "GeneXus.Programs", OldWcwclinhaprodutonota, new Object[] {context} );
                              WebComp_GX_Process.ComponentInit();
                              WebComp_GX_Process.Name = "OldWcwclinhaprodutonota";
                              WebComp_GX_Process_Component = OldWcwclinhaprodutonota;
                           }
                           if ( StringUtil.Len( WebComp_GX_Process_Component) != 0 )
                           {
                              WebComp_GX_Process.componentprocess(sPrefix+"W0060", sEvtType, sEvt);
                           }
                           nGXsfl_56_webc_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                           WebCompHandler = "Wcwclinhaprodutonota";
                           WebComp_GX_Process_Component = OldWcwclinhaprodutonota;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE8Q2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm8Q2( ) ;
            }
         }
      }

      protected void PA8Q2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wcimpnotafiscalprodutosnota")), "wcimpnotafiscalprodutosnota") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wcimpnotafiscalprodutosnota")))) ;
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
               GX_FocusControl = edtavTotalsel_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrFgridprodutos_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_562( ) ;
         while ( nGXsfl_56_idx <= nRC_GXsfl_56 )
         {
            sendrow_562( ) ;
            nGXsfl_56_idx = ((subFgridprodutos_Islastpage==1)&&(nGXsfl_56_idx+1>subFgridprodutos_fnc_Recordsperpage( )) ? 1 : nGXsfl_56_idx+1);
            sGXsfl_56_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_56_idx), 4, 0), 4, "0");
            SubsflControlProps_562( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( FgridprodutosContainer)) ;
         /* End function gxnrFgridprodutos_newrow */
      }

      protected void gxgrFgridprodutos_refresh( bool AV19IsPermiteSelecionar ,
                                                GXBaseCollection<SdtSdProdutoNotaFiscal> AV12Array_SdProdutoNota ,
                                                bool AV10HasValidationErrors ,
                                                SdtWcImpNotaFiscalData AV21EmptyWizardData ,
                                                string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         FGRIDPRODUTOS_nCurrentRecord = 0;
         RF8Q2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrFgridprodutos_refresh */
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
         RF8Q2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavTotalsel_Enabled = 0;
         AssignProp(sPrefix, false, edtavTotalsel_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTotalsel_Enabled), 5, 0), true);
      }

      protected void RF8Q2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            FgridprodutosContainer.ClearRows();
         }
         wbStart = 56;
         /* Execute user event: Refresh */
         E168Q2 ();
         nGXsfl_56_idx = 1;
         sGXsfl_56_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_56_idx), 4, 0), 4, "0");
         SubsflControlProps_562( ) ;
         bGXsfl_56_Refreshing = true;
         FgridprodutosContainer.AddObjectProperty("GridName", "Fgridprodutos");
         FgridprodutosContainer.AddObjectProperty("CmpContext", sPrefix);
         FgridprodutosContainer.AddObjectProperty("InMasterPage", "false");
         FgridprodutosContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         FgridprodutosContainer.AddObjectProperty("Class", "FreeStyleGrid");
         FgridprodutosContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         FgridprodutosContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         FgridprodutosContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridprodutos_Backcolorstyle), 1, 0, ".", "")));
         FgridprodutosContainer.PageSize = subFgridprodutos_fnc_Recordsperpage( );
         if ( subFgridprodutos_Islastpage != 0 )
         {
            FGRIDPRODUTOS_nFirstRecordOnPage = (long)(subFgridprodutos_fnc_Recordcount( )-subFgridprodutos_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, sPrefix+"FGRIDPRODUTOS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(FGRIDPRODUTOS_nFirstRecordOnPage), 15, 0, ".", "")));
            FgridprodutosContainer.AddObjectProperty("FGRIDPRODUTOS_nFirstRecordOnPage", FGRIDPRODUTOS_nFirstRecordOnPage);
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_GX_Process_Component) != 0 )
               {
                  WebComp_GX_Process.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcwclinhaprodutonota_Component) != 0 )
               {
                  WebComp_Wcwclinhaprodutonota.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_562( ) ;
            /* Execute user event: Fgridprodutos.Load */
            E178Q2 ();
            wbEnd = 56;
            WB8Q0( ) ;
         }
         bGXsfl_56_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes8Q2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISPERMITESELECIONAR", AV19IsPermiteSelecionar);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISPERMITESELECIONAR", GetSecureSignedToken( sPrefix, AV19IsPermiteSelecionar, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vEMPTYWIZARDDATA", AV21EmptyWizardData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vEMPTYWIZARDDATA", AV21EmptyWizardData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vEMPTYWIZARDDATA", GetSecureSignedToken( sPrefix, AV21EmptyWizardData, context));
      }

      protected int subFgridprodutos_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subFgridprodutos_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subFgridprodutos_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subFgridprodutos_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         edtavTotalsel_Enabled = 0;
         AssignProp(sPrefix, false, edtavTotalsel_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTotalsel_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP8Q0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E158Q2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vSDPRODUTONOTAFISCAL"), AV13sdProdutoNotaFiscal);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vARRAY_SDPRODUTONOTA"), AV12Array_SdProdutoNota);
            /* Read saved values. */
            nRC_GXsfl_56 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_56"), ",", "."), 18, MidpointRounding.ToEven));
            wcpOAV6WebSessionKey = cgiGet( sPrefix+"wcpOAV6WebSessionKey");
            wcpOAV8PreviousStep = cgiGet( sPrefix+"wcpOAV8PreviousStep");
            wcpOAV7GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV7GoingBack"));
            AV18IsMarcar = StringUtil.StrToBool( cgiGet( sPrefix+"vISMARCAR"));
            AV17id = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vID"), ",", "."), 18, MidpointRounding.ToEven));
            AV26GXV5 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGXV5"), ",", "."), 18, MidpointRounding.ToEven));
            AV25GXV4 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGXV4"), ",", "."), 18, MidpointRounding.ToEven));
            AV24GXV3 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGXV3"), ",", "."), 18, MidpointRounding.ToEven));
            subFgridprodutos_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"subFgridprodutos_Recordcount"), ",", "."), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTotalsel_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTotalsel_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTOTALSEL");
               GX_FocusControl = edtavTotalsel_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV16TotalSel = 0;
               AssignAttri(sPrefix, false, "AV16TotalSel", StringUtil.LTrimStr( AV16TotalSel, 18, 2));
            }
            else
            {
               AV16TotalSel = context.localUtil.CToN( cgiGet( edtavTotalsel_Internalname), ",", ".");
               AssignAttri(sPrefix, false, "AV16TotalSel", StringUtil.LTrimStr( AV16TotalSel, 18, 2));
            }
            AV20JSONSdProdutosNota = cgiGet( edtavJsonsdprodutosnota_Internalname);
            AssignAttri(sPrefix, false, "AV20JSONSdProdutosNota", AV20JSONSdProdutosNota);
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
         E158Q2 ();
         if (returnInSub) return;
      }

      protected void E158Q2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
         edtavJsonsdprodutosnota_Visible = 0;
         AssignProp(sPrefix, false, edtavJsonsdprodutosnota_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavJsonsdprodutosnota_Visible), 5, 0), true);
         AV16TotalSel = 0;
         AssignAttri(sPrefix, false, "AV16TotalSel", StringUtil.LTrimStr( AV16TotalSel, 18, 2));
         AV12Array_SdProdutoNota.FromJSonString(AV11WizardData.gxTpr_Importarxml.gxTpr_Jsonsdprodutosnota, null);
         AV19IsPermiteSelecionar = false;
         AssignAttri(sPrefix, false, "AV19IsPermiteSelecionar", AV19IsPermiteSelecionar);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISPERMITESELECIONAR", GetSecureSignedToken( sPrefix, AV19IsPermiteSelecionar, context));
         if ( ! AV19IsPermiteSelecionar )
         {
            AV22GXV1 = 1;
            while ( AV22GXV1 <= AV12Array_SdProdutoNota.Count )
            {
               AV13sdProdutoNotaFiscal = ((SdtSdProdutoNotaFiscal)AV12Array_SdProdutoNota.Item(AV22GXV1));
               AV13sdProdutoNotaFiscal.gxTpr_Issel = true;
               AV16TotalSel = (decimal)(AV16TotalSel+(NumberUtil.Val( StringUtil.Trim( AV13sdProdutoNotaFiscal.gxTpr_Vprod), ".")));
               AssignAttri(sPrefix, false, "AV16TotalSel", StringUtil.LTrimStr( AV16TotalSel, 18, 2));
               AV22GXV1 = (int)(AV22GXV1+1);
            }
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11WizardData.gxTpr_Importarxml.gxTpr_Jsonsdnotafiscal)) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wcimpnotafiscal"+UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.RTrim("ImportarXML")) + "," + UrlEncode(StringUtil.BoolToStr(false));
            CallWebObject(formatLink("wcimpnotafiscal") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
      }

      protected void E168Q2( )
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

      private void E178Q2( )
      {
         /* Fgridprodutos_Load Routine */
         returnInSub = false;
         AV23GXV2 = 1;
         while ( AV23GXV2 <= AV12Array_SdProdutoNota.Count )
         {
            AV13sdProdutoNotaFiscal = ((SdtSdProdutoNotaFiscal)AV12Array_SdProdutoNota.Item(AV23GXV2));
            AV14JSON = AV13sdProdutoNotaFiscal.ToJSonString(false, true);
            /* Object Property */
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               bDynCreated_Wcwclinhaprodutonota = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcwclinhaprodutonota_Component), StringUtil.Lower( "WcLinhaProdutoNota")) != 0 )
            {
               WebComp_Wcwclinhaprodutonota = getWebComponent(GetType(), "GeneXus.Programs", "wclinhaprodutonota", new Object[] {context} );
               WebComp_Wcwclinhaprodutonota.ComponentInit();
               WebComp_Wcwclinhaprodutonota.Name = "WcLinhaProdutoNota";
               WebComp_Wcwclinhaprodutonota_Component = "WcLinhaProdutoNota";
            }
            if ( StringUtil.Len( WebComp_Wcwclinhaprodutonota_Component) != 0 )
            {
               WebComp_Wcwclinhaprodutonota.setjustcreated();
               WebComp_Wcwclinhaprodutonota.componentprepare(new Object[] {(string)sPrefix+"W0060",(string)sGXsfl_56_idx,(string)AV14JSON,(bool)AV19IsPermiteSelecionar});
               WebComp_Wcwclinhaprodutonota.componentbind(new Object[] {(string)"",(string)""});
            }
            if ( ! bGXsfl_56_Refreshing )
            {
               if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wcwclinhaprodutonota )
               {
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0060"+sGXsfl_56_idx);
                  WebComp_Wcwclinhaprodutonota.componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 56;
            }
            sendrow_562( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_56_Refreshing )
            {
               DoAjaxLoad(56, FgridprodutosRow);
            }
            AV23GXV2 = (int)(AV23GXV2+1);
         }
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E138Q2 ();
         if (returnInSub) return;
      }

      protected void E138Q2( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( (Convert.ToDecimal(0)==AV16TotalSel) )
         {
            GXt_char1 = "Selecione algum item para continuar";
            new message(context ).gxep_erro( ref  GXt_char1) ;
         }
         else
         {
            AV20JSONSdProdutosNota = AV12Array_SdProdutoNota.ToJSonString(false);
            AssignAttri(sPrefix, false, "AV20JSONSdProdutosNota", AV20JSONSdProdutosNota);
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
               GXEncryptionTmp = "wcimpnotafiscal"+UrlEncode(StringUtil.RTrim("ProdutosNota")) + "," + UrlEncode(StringUtil.RTrim("Revisao")) + "," + UrlEncode(StringUtil.BoolToStr(false));
               CallWebObject(formatLink("wcimpnotafiscal") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
               context.wjLocDisableFrm = 1;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11WizardData", AV11WizardData);
      }

      protected void E148Q2( )
      {
         /* 'WizardPrevious' Routine */
         returnInSub = false;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wcimpnotafiscal"+UrlEncode(StringUtil.RTrim("ProdutosNota")) + "," + UrlEncode(StringUtil.RTrim("ImportarXML")) + "," + UrlEncode(StringUtil.BoolToStr(true));
         CallWebObject(formatLink("wcimpnotafiscal") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S122( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( AV19IsPermiteSelecionar ) )
         {
            bttBtnselecionatodos_Visible = 0;
            AssignProp(sPrefix, false, bttBtnselecionatodos_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnselecionatodos_Visible), 5, 0), true);
         }
         if ( ! ( AV19IsPermiteSelecionar ) )
         {
            bttBtndesmarcartodos_Visible = 0;
            AssignProp(sPrefix, false, bttBtndesmarcartodos_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtndesmarcartodos_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'LOADVARIABLESFROMWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV20JSONSdProdutosNota = AV11WizardData.gxTpr_Produtosnota.gxTpr_Jsonsdprodutosnota;
         AssignAttri(sPrefix, false, "AV20JSONSdProdutosNota", AV20JSONSdProdutosNota);
         AV16TotalSel = AV11WizardData.gxTpr_Produtosnota.gxTpr_Totalsel;
         AssignAttri(sPrefix, false, "AV16TotalSel", StringUtil.LTrimStr( AV16TotalSel, 18, 2));
      }

      protected void S132( )
      {
         /* 'SAVEVARIABLESTOWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV11WizardData.gxTpr_Produtosnota.gxTpr_Jsonsdprodutosnota = AV20JSONSdProdutosNota;
         AV11WizardData.gxTpr_Produtosnota.gxTpr_Totalsel = AV16TotalSel;
         AV11WizardData.gxTpr_Revisao.gxTpr_Propostaid = AV21EmptyWizardData.gxTpr_Revisao.gxTpr_Propostaid;
         AV5WebSession.Set(AV6WebSessionKey, AV11WizardData.ToJSonString(false, true));
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
         PA8Q2( ) ;
         WS8Q2( ) ;
         WE8Q2( ) ;
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
         PA8Q2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wcimpnotafiscalprodutosnota", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA8Q2( ) ;
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
         PA8Q2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS8Q2( ) ;
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
         WS8Q2( ) ;
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
         WE8Q2( ) ;
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
         if ( ! ( WebComp_GX_Process == null ) )
         {
            WebComp_GX_Process.componentjscripts();
         }
         if ( ! ( WebComp_Wcwclinhaprodutonota == null ) )
         {
            WebComp_Wcwclinhaprodutonota.componentjscripts();
         }
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wcwclinhaprodutonota == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcwclinhaprodutonota_Component) != 0 )
            {
               WebComp_Wcwclinhaprodutonota.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101963791", true, true);
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
         context.AddJavascriptSource("wcimpnotafiscalprodutosnota.js", "?20256101963791", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_562( )
      {
      }

      protected void SubsflControlProps_fel_562( )
      {
      }

      protected void sendrow_562( )
      {
         sGXsfl_56_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_56_idx), 4, 0), 4, "0");
         SubsflControlProps_562( ) ;
         WB8Q0( ) ;
         FgridprodutosRow = GXWebRow.GetNew(context,FgridprodutosContainer);
         if ( subFgridprodutos_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subFgridprodutos_Backstyle = 0;
            if ( StringUtil.StrCmp(subFgridprodutos_Class, "") != 0 )
            {
               subFgridprodutos_Linesclass = subFgridprodutos_Class+"Odd";
            }
         }
         else if ( subFgridprodutos_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subFgridprodutos_Backstyle = 0;
            subFgridprodutos_Backcolor = subFgridprodutos_Allbackcolor;
            if ( StringUtil.StrCmp(subFgridprodutos_Class, "") != 0 )
            {
               subFgridprodutos_Linesclass = subFgridprodutos_Class+"Uniform";
            }
         }
         else if ( subFgridprodutos_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subFgridprodutos_Backstyle = 1;
            if ( StringUtil.StrCmp(subFgridprodutos_Class, "") != 0 )
            {
               subFgridprodutos_Linesclass = subFgridprodutos_Class+"Odd";
            }
            subFgridprodutos_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subFgridprodutos_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subFgridprodutos_Backstyle = 1;
            subFgridprodutos_Backcolor = (int)(0xFFFFFF);
            if ( StringUtil.StrCmp(subFgridprodutos_Class, "") != 0 )
            {
               subFgridprodutos_Linesclass = subFgridprodutos_Class+"Odd";
            }
         }
         /* Start of Columns property logic. */
         /* Div Control */
         FgridprodutosRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divFgridprodutoslayouttable_Internalname+"_"+sGXsfl_56_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         FgridprodutosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FgridprodutosRow.AddRenderProperties(FgridprodutosColumn);
         /* Div Control */
         FgridprodutosRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         FgridprodutosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FgridprodutosRow.AddRenderProperties(FgridprodutosColumn);
         /* Div Control */
         FgridprodutosRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         FgridprodutosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FgridprodutosRow.AddRenderProperties(FgridprodutosColumn);
         /* WebComponent */
         GxWebStd.gx_hidden_field( context, sPrefix+"W0060"+sGXsfl_56_idx, StringUtil.RTrim( WebComp_Wcwclinhaprodutonota_Component));
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gxwebcomponent"+" gxwebcomponent-loading");
         context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0060"+sGXsfl_56_idx+"\""+"") ;
         context.WriteHtmlText( ">") ;
         if ( bGXsfl_56_Refreshing )
         {
            if ( StringUtil.Len( WebComp_Wcwclinhaprodutonota_Component) != 0 )
            {
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StringSearch( sPrefix+"W0060"+sGXsfl_56_idx, cgiGet( "_EventName"), 1) != 0 ) )
               {
                  if ( 1 != 0 )
                  {
                     if ( StringUtil.Len( WebComp_Wcwclinhaprodutonota_Component) != 0 )
                     {
                        WebComp_Wcwclinhaprodutonota.componentstart();
                     }
                  }
               }
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldWcwclinhaprodutonota), StringUtil.Lower( WebComp_Wcwclinhaprodutonota_Component)) != 0 ) )
               {
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0060"+sGXsfl_56_idx);
               }
               WebComp_Wcwclinhaprodutonota.componentdraw();
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldWcwclinhaprodutonota), StringUtil.Lower( WebComp_Wcwclinhaprodutonota_Component)) != 0 ) )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
            }
         }
         context.WriteHtmlText( "</div>") ;
         WebComp_Wcwclinhaprodutonota_Component = "";
         WebComp_Wcwclinhaprodutonota.componentjscripts();
         FgridprodutosRow.AddColumnProperties("webcomp", -1, isAjaxCallMode( ), new Object[] {(string)"Wcwclinhaprodutonota"});
         FgridprodutosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FgridprodutosRow.AddRenderProperties(FgridprodutosColumn);
         FgridprodutosRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FgridprodutosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FgridprodutosRow.AddRenderProperties(FgridprodutosColumn);
         FgridprodutosRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FgridprodutosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FgridprodutosRow.AddRenderProperties(FgridprodutosColumn);
         FgridprodutosRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FgridprodutosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FgridprodutosRow.AddRenderProperties(FgridprodutosColumn);
         send_integrity_lvl_hashes8Q2( ) ;
         /* End of Columns property logic. */
         FgridprodutosContainer.AddRow(FgridprodutosRow);
         nGXsfl_56_idx = ((subFgridprodutos_Islastpage==1)&&(nGXsfl_56_idx+1>subFgridprodutos_fnc_Recordsperpage( )) ? 1 : nGXsfl_56_idx+1);
         sGXsfl_56_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_56_idx), 4, 0), 4, "0");
         SubsflControlProps_562( ) ;
         /* End function sendrow_562 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl56( )
      {
         if ( FgridprodutosContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"FgridprodutosContainer"+"DivS\" data-gxgridid=\"56\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subFgridprodutos_Internalname, subFgridprodutos_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            FgridprodutosContainer.AddObjectProperty("GridName", "Fgridprodutos");
         }
         else
         {
            FgridprodutosContainer.AddObjectProperty("GridName", "Fgridprodutos");
            FgridprodutosContainer.AddObjectProperty("Header", subFgridprodutos_Header);
            FgridprodutosContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            FgridprodutosContainer.AddObjectProperty("Class", "FreeStyleGrid");
            FgridprodutosContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            FgridprodutosContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            FgridprodutosContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridprodutos_Backcolorstyle), 1, 0, ".", "")));
            FgridprodutosContainer.AddObjectProperty("CmpContext", sPrefix);
            FgridprodutosContainer.AddObjectProperty("InMasterPage", "false");
            FgridprodutosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridprodutosContainer.AddColumnProperties(FgridprodutosColumn);
            FgridprodutosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridprodutosContainer.AddColumnProperties(FgridprodutosColumn);
            FgridprodutosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridprodutosContainer.AddColumnProperties(FgridprodutosColumn);
            FgridprodutosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridprodutosContainer.AddColumnProperties(FgridprodutosColumn);
            FgridprodutosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridprodutosContainer.AddColumnProperties(FgridprodutosColumn);
            FgridprodutosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridprodutosContainer.AddColumnProperties(FgridprodutosColumn);
            FgridprodutosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridprodutosContainer.AddColumnProperties(FgridprodutosColumn);
            FgridprodutosContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridprodutos_Selectedindex), 4, 0, ".", "")));
            FgridprodutosContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridprodutos_Allowselection), 1, 0, ".", "")));
            FgridprodutosContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridprodutos_Selectioncolor), 9, 0, ".", "")));
            FgridprodutosContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridprodutos_Allowhovering), 1, 0, ".", "")));
            FgridprodutosContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridprodutos_Hoveringcolor), 9, 0, ".", "")));
            FgridprodutosContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridprodutos_Allowcollapsing), 1, 0, ".", "")));
            FgridprodutosContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridprodutos_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblLabeluploaddataxml_Internalname = sPrefix+"LABELUPLOADDATAXML";
         lblLabeldescriptionuploaddata_Internalname = sPrefix+"LABELDESCRIPTIONUPLOADDATA";
         divTablenotasflex_Internalname = sPrefix+"TABLENOTASFLEX";
         lblTextblocktotalsel_Internalname = sPrefix+"TEXTBLOCKTOTALSEL";
         edtavTotalsel_Internalname = sPrefix+"vTOTALSEL";
         divUnnamedtabletotalsel_Internalname = sPrefix+"UNNAMEDTABLETOTALSEL";
         divTabletotal_Internalname = sPrefix+"TABLETOTAL";
         bttBtnselecionatodos_Internalname = sPrefix+"BTNSELECIONATODOS";
         bttBtndesmarcartodos_Internalname = sPrefix+"BTNDESMARCARTODOS";
         lblTitlenota_Internalname = sPrefix+"TITLENOTA";
         lblTitlecodigo_Internalname = sPrefix+"TITLECODIGO";
         lblTitledescricao_Internalname = sPrefix+"TITLEDESCRICAO";
         lblTitlequantidade_Internalname = sPrefix+"TITLEQUANTIDADE";
         lblTitleunitario_Internalname = sPrefix+"TITLEUNITARIO";
         lblTitletotal_Internalname = sPrefix+"TITLETOTAL";
         divTablecontentline_Internalname = sPrefix+"TABLECONTENTLINE";
         divFgridprodutoslayouttable_Internalname = sPrefix+"FGRIDPRODUTOSLAYOUTTABLE";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         Btnwizardprevious_Internalname = sPrefix+"BTNWIZARDPREVIOUS";
         Btnwizardnext_Internalname = sPrefix+"BTNWIZARDNEXT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         lblCss_Internalname = sPrefix+"CSS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavJsonsdprodutosnota_Internalname = sPrefix+"vJSONSDPRODUTOSNOTA";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subFgridprodutos_Internalname = sPrefix+"FGRIDPRODUTOS";
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
         subFgridprodutos_Allowcollapsing = 0;
         subFgridprodutos_Class = "FreeStyleGrid";
         subFgridprodutos_Backcolorstyle = 0;
         edtavJsonsdprodutosnota_Visible = 1;
         Btnwizardnext_Class = "Button ButtonWizard";
         Btnwizardnext_Caption = "Próximo";
         Btnwizardnext_Aftericonclass = "fas fa-arrow-right";
         Btnwizardnext_Tooltiptext = "";
         Btnwizardprevious_Class = "BtnDefault ButtonWizard";
         Btnwizardprevious_Caption = "Anterior";
         Btnwizardprevious_Beforeiconclass = "fas fa-arrow-left";
         Btnwizardprevious_Tooltiptext = "";
         bttBtndesmarcartodos_Visible = 1;
         bttBtnselecionatodos_Visible = 1;
         edtavTotalsel_Jsonclick = "";
         edtavTotalsel_Enabled = 1;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"FGRIDPRODUTOS_nFirstRecordOnPage","type":"int"},{"av":"FGRIDPRODUTOS_nEOF","type":"int"},{"av":"AV12Array_SdProdutoNota","fld":"vARRAY_SDPRODUTONOTA","type":""},{"av":"sPrefix","type":"char"},{"av":"AV19IsPermiteSelecionar","fld":"vISPERMITESELECIONAR","hsh":true,"type":"boolean"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true,"type":"boolean"},{"av":"AV21EmptyWizardData","fld":"vEMPTYWIZARDDATA","hsh":true,"type":""}]""");
         setEventMetadata("REFRESH",""","oparms":[{"ctrl":"BTNSELECIONATODOS","prop":"Visible"},{"ctrl":"BTNDESMARCARTODOS","prop":"Visible"}]}""");
         setEventMetadata("FGRIDPRODUTOS.LOAD","""{"handler":"E178Q2","iparms":[{"av":"AV12Array_SdProdutoNota","fld":"vARRAY_SDPRODUTONOTA","type":""},{"av":"AV19IsPermiteSelecionar","fld":"vISPERMITESELECIONAR","hsh":true,"type":"boolean"}]""");
         setEventMetadata("FGRIDPRODUTOS.LOAD",""","oparms":[{"ctrl":"WCWCLINHAPRODUTONOTA"}]}""");
         setEventMetadata("ENTER","""{"handler":"E138Q2","iparms":[{"av":"AV16TotalSel","fld":"vTOTALSEL","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV12Array_SdProdutoNota","fld":"vARRAY_SDPRODUTONOTA","type":""},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true,"type":"boolean"},{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY","type":"svchar"},{"av":"AV20JSONSdProdutosNota","fld":"vJSONSDPRODUTOSNOTA","type":"vchar"},{"av":"AV21EmptyWizardData","fld":"vEMPTYWIZARDDATA","hsh":true,"type":""}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV20JSONSdProdutosNota","fld":"vJSONSDPRODUTOSNOTA","type":"vchar"},{"av":"AV11WizardData","fld":"vWIZARDDATA","type":""}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E148Q2","iparms":[]}""");
         setEventMetadata("'DOSELECIONATODOS'","""{"handler":"E118Q1","iparms":[{"av":"AV12Array_SdProdutoNota","fld":"vARRAY_SDPRODUTONOTA","type":""}]""");
         setEventMetadata("'DOSELECIONATODOS'",""","oparms":[{"av":"AV16TotalSel","fld":"vTOTALSEL","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV12Array_SdProdutoNota","fld":"vARRAY_SDPRODUTONOTA","type":""}]}""");
         setEventMetadata("'DODESMARCARTODOS'","""{"handler":"E128Q1","iparms":[{"av":"AV12Array_SdProdutoNota","fld":"vARRAY_SDPRODUTONOTA","type":""}]""");
         setEventMetadata("'DODESMARCARTODOS'",""","oparms":[{"av":"AV16TotalSel","fld":"vTOTALSEL","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV12Array_SdProdutoNota","fld":"vARRAY_SDPRODUTONOTA","type":""}]}""");
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
         AV12Array_SdProdutoNota = new GXBaseCollection<SdtSdProdutoNotaFiscal>( context, "SdProdutoNotaFiscal", "Factory21");
         AV21EmptyWizardData = new SdtWcImpNotaFiscalData(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV13sdProdutoNotaFiscal = new SdtSdProdutoNotaFiscal(context);
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         lblLabeluploaddataxml_Jsonclick = "";
         lblLabeldescriptionuploaddata_Jsonclick = "";
         lblTextblocktotalsel_Jsonclick = "";
         TempTags = "";
         bttBtnselecionatodos_Jsonclick = "";
         bttBtndesmarcartodos_Jsonclick = "";
         lblTitlenota_Jsonclick = "";
         lblTitlecodigo_Jsonclick = "";
         lblTitledescricao_Jsonclick = "";
         lblTitlequantidade_Jsonclick = "";
         lblTitleunitario_Jsonclick = "";
         lblTitletotal_Jsonclick = "";
         FgridprodutosContainer = new GXWebGrid( context);
         sStyleString = "";
         ucBtnwizardprevious = new GXUserControl();
         ucBtnwizardnext = new GXUserControl();
         lblCss_Jsonclick = "";
         AV20JSONSdProdutosNota = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         OldWcwclinhaprodutonota = "";
         sCmpCtrl = "";
         WebComp_GX_Process_Component = "";
         GXDecQS = "";
         WebComp_Wcwclinhaprodutonota_Component = "";
         AV11WizardData = new SdtWcImpNotaFiscalData(context);
         AV14JSON = "";
         FgridprodutosRow = new GXWebRow();
         GXt_char1 = "";
         AV5WebSession = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV6WebSessionKey = "";
         sCtrlAV8PreviousStep = "";
         sCtrlAV7GoingBack = "";
         subFgridprodutos_Linesclass = "";
         FgridprodutosColumn = new GXWebColumn();
         subFgridprodutos_Header = "";
         WebComp_GX_Process = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wcwclinhaprodutonota = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
         edtavTotalsel_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short subFgridprodutos_Backcolorstyle ;
      private short gxcookieaux ;
      private short FGRIDPRODUTOS_nEOF ;
      private short nGXWrapped ;
      private short subFgridprodutos_Backstyle ;
      private short subFgridprodutos_Allowselection ;
      private short subFgridprodutos_Allowhovering ;
      private short subFgridprodutos_Allowcollapsing ;
      private short subFgridprodutos_Collapsed ;
      private int nRC_GXsfl_56 ;
      private int subFgridprodutos_Recordcount ;
      private int nGXsfl_56_idx=1 ;
      private int edtavTotalsel_Enabled ;
      private int AV17id ;
      private int AV26GXV5 ;
      private int AV25GXV4 ;
      private int AV24GXV3 ;
      private int bttBtnselecionatodos_Visible ;
      private int bttBtndesmarcartodos_Visible ;
      private int edtavJsonsdprodutosnota_Visible ;
      private int nGXsfl_56_webc_idx=0 ;
      private int subFgridprodutos_Islastpage ;
      private int AV22GXV1 ;
      private int AV23GXV2 ;
      private int idxLst ;
      private int subFgridprodutos_Backcolor ;
      private int subFgridprodutos_Allbackcolor ;
      private int subFgridprodutos_Selectedindex ;
      private int subFgridprodutos_Selectioncolor ;
      private int subFgridprodutos_Hoveringcolor ;
      private long FGRIDPRODUTOS_nCurrentRecord ;
      private long FGRIDPRODUTOS_nFirstRecordOnPage ;
      private decimal AV16TotalSel ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_56_idx="0001" ;
      private string edtavTotalsel_Internalname ;
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
      private string divTablecontent_Internalname ;
      private string divTablenotasflex_Internalname ;
      private string lblLabeluploaddataxml_Internalname ;
      private string lblLabeluploaddataxml_Jsonclick ;
      private string lblLabeldescriptionuploaddata_Internalname ;
      private string lblLabeldescriptionuploaddata_Jsonclick ;
      private string divTabletotal_Internalname ;
      private string divUnnamedtabletotalsel_Internalname ;
      private string lblTextblocktotalsel_Internalname ;
      private string lblTextblocktotalsel_Jsonclick ;
      private string TempTags ;
      private string edtavTotalsel_Jsonclick ;
      private string bttBtnselecionatodos_Internalname ;
      private string bttBtnselecionatodos_Jsonclick ;
      private string bttBtndesmarcartodos_Internalname ;
      private string bttBtndesmarcartodos_Jsonclick ;
      private string divTablecontentline_Internalname ;
      private string lblTitlenota_Internalname ;
      private string lblTitlenota_Jsonclick ;
      private string lblTitlecodigo_Internalname ;
      private string lblTitlecodigo_Jsonclick ;
      private string lblTitledescricao_Internalname ;
      private string lblTitledescricao_Jsonclick ;
      private string lblTitlequantidade_Internalname ;
      private string lblTitlequantidade_Jsonclick ;
      private string lblTitleunitario_Internalname ;
      private string lblTitleunitario_Jsonclick ;
      private string lblTitletotal_Internalname ;
      private string lblTitletotal_Jsonclick ;
      private string sStyleString ;
      private string subFgridprodutos_Internalname ;
      private string divTableactions_Internalname ;
      private string Btnwizardprevious_Tooltiptext ;
      private string Btnwizardprevious_Beforeiconclass ;
      private string Btnwizardprevious_Caption ;
      private string Btnwizardprevious_Class ;
      private string Btnwizardprevious_Internalname ;
      private string Btnwizardnext_Tooltiptext ;
      private string Btnwizardnext_Aftericonclass ;
      private string Btnwizardnext_Caption ;
      private string Btnwizardnext_Class ;
      private string Btnwizardnext_Internalname ;
      private string lblCss_Internalname ;
      private string lblCss_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavJsonsdprodutosnota_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string OldWcwclinhaprodutonota ;
      private string sCmpCtrl ;
      private string WebComp_GX_Process_Component ;
      private string WebCompHandler="" ;
      private string GXDecQS ;
      private string WebComp_Wcwclinhaprodutonota_Component ;
      private string GXt_char1 ;
      private string sCtrlAV6WebSessionKey ;
      private string sCtrlAV8PreviousStep ;
      private string sCtrlAV7GoingBack ;
      private string subFgridprodutos_Class ;
      private string subFgridprodutos_Linesclass ;
      private string divFgridprodutoslayouttable_Internalname ;
      private string subFgridprodutos_Header ;
      private bool AV7GoingBack ;
      private bool wcpOAV7GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV19IsPermiteSelecionar ;
      private bool AV10HasValidationErrors ;
      private bool AV18IsMarcar ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_56_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wcwclinhaprodutonota ;
      private string AV20JSONSdProdutosNota ;
      private string AV14JSON ;
      private string AV6WebSessionKey ;
      private string AV8PreviousStep ;
      private string wcpOAV6WebSessionKey ;
      private string wcpOAV8PreviousStep ;
      private IGxSession AV5WebSession ;
      private GXWebComponent WebComp_Wcwclinhaprodutonota ;
      private GXWebGrid FgridprodutosContainer ;
      private GXWebRow FgridprodutosRow ;
      private GXWebColumn FgridprodutosColumn ;
      private GXUserControl ucBtnwizardprevious ;
      private GXUserControl ucBtnwizardnext ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSdProdutoNotaFiscal> AV12Array_SdProdutoNota ;
      private SdtWcImpNotaFiscalData AV21EmptyWizardData ;
      private SdtSdProdutoNotaFiscal AV13sdProdutoNotaFiscal ;
      private GXWebComponent WebComp_GX_Process ;
      private SdtWcImpNotaFiscalData AV11WizardData ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
