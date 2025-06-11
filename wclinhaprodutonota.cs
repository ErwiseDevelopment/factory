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
   public class wclinhaprodutonota : GXWebComponent
   {
      public wclinhaprodutonota( )
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

      public wclinhaprodutonota( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_JSON ,
                           bool aP1_IsPermiteSelecionar )
      {
         this.AV12JSON = aP0_JSON;
         this.AV16IsPermiteSelecionar = aP1_IsPermiteSelecionar;
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
         chkavSelecionar = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "JSON");
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
                  AV12JSON = GetPar( "JSON");
                  AssignAttri(sPrefix, false, "AV12JSON", AV12JSON);
                  AV16IsPermiteSelecionar = StringUtil.StrToBool( GetPar( "IsPermiteSelecionar"));
                  AssignAttri(sPrefix, false, "AV16IsPermiteSelecionar", AV16IsPermiteSelecionar);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV12JSON,(bool)AV16IsPermiteSelecionar});
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
                  gxfirstwebparm = GetFirstPar( "JSON");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "JSON");
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
            PA8K2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavNotafiscal_Enabled = 0;
               AssignProp(sPrefix, false, edtavNotafiscal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNotafiscal_Enabled), 5, 0), true);
               edtavCodigo_Enabled = 0;
               AssignProp(sPrefix, false, edtavCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCodigo_Enabled), 5, 0), true);
               edtavDescricao_Enabled = 0;
               AssignProp(sPrefix, false, edtavDescricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDescricao_Enabled), 5, 0), true);
               edtavQuantidade_Enabled = 0;
               AssignProp(sPrefix, false, edtavQuantidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavQuantidade_Enabled), 5, 0), true);
               edtavValorunitario_Enabled = 0;
               AssignProp(sPrefix, false, edtavValorunitario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavValorunitario_Enabled), 5, 0), true);
               edtavValortotal_Enabled = 0;
               AssignProp(sPrefix, false, edtavValortotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavValortotal_Enabled), 5, 0), true);
               WS8K2( ) ;
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
            context.SendWebValue( "Linha produto nota") ;
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
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
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wclinhaprodutonota"+UrlEncode(StringUtil.RTrim(AV12JSON)) + "," + UrlEncode(StringUtil.BoolToStr(AV16IsPermiteSelecionar));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wclinhaprodutonota") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDPRODUTONOTAFISCAL", AV13SdProdutoNotaFiscal);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDPRODUTONOTAFISCAL", AV13SdProdutoNotaFiscal);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSDPRODUTONOTAFISCAL", GetSecureSignedToken( sPrefix, AV13SdProdutoNotaFiscal, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV12JSON", wcpOAV12JSON);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV16IsPermiteSelecionar", wcpOAV16IsPermiteSelecionar);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISMARCAR", AV14isMarcar);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDPRODUTONOTAFISCAL", AV13SdProdutoNotaFiscal);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDPRODUTONOTAFISCAL", AV13SdProdutoNotaFiscal);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSDPRODUTONOTAFISCAL", GetSecureSignedToken( sPrefix, AV13SdProdutoNotaFiscal, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vJSON", AV12JSON);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISPERMITESELECIONAR", AV16IsPermiteSelecionar);
         GxWebStd.gx_hidden_field( context, sPrefix+"vSDPRODUTONOTAFISCAL_Id", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13SdProdutoNotaFiscal.gxTpr_Id), 9, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm8K2( )
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
         return "WcLinhaProdutoNota" ;
      }

      public override string GetPgmdesc( )
      {
         return "Linha produto nota" ;
      }

      protected void WB8K0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wclinhaprodutonota");
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
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "linha", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSelecionar_cell_Internalname, 1, 0, "px", 0, "px", divSelecionar_cell_Class, "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavSelecionar_Internalname, "Selecionar", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavSelecionar_Internalname, StringUtil.BoolToStr( AV5Selecionar), "", "Selecionar", chkavSelecionar.Visible, chkavSelecionar.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(16, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,16);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1 DataContentCellNoLabel", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavNotafiscal_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNotafiscal_Internalname, AV6NotaFiscal, StringUtil.RTrim( context.localUtil.Format( AV6NotaFiscal, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNotafiscal_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavNotafiscal_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WcLinhaProdutoNota.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2 DataContentCellNoLabel", "end", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCodigo_Internalname, "Codigo", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCodigo_Internalname, AV7Codigo, StringUtil.RTrim( context.localUtil.Format( AV7Codigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,23);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCodigo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WcLinhaProdutoNota.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellNoLabel", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDescricao_Internalname, "Descricao", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDescricao_Internalname, AV8Descricao, StringUtil.RTrim( context.localUtil.Format( AV8Descricao, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDescricao_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavDescricao_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WcLinhaProdutoNota.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1 DataContentCellNoLabel", "end", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavQuantidade_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavQuantidade_Internalname, AV9Quantidade, StringUtil.RTrim( context.localUtil.Format( AV9Quantidade, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavQuantidade_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavQuantidade_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WcLinhaProdutoNota.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2 DataContentCellNoLabel", "end", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavValorunitario_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavValorunitario_Internalname, AV10ValorUnitario, StringUtil.RTrim( context.localUtil.Format( AV10ValorUnitario, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavValorunitario_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavValorunitario_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WcLinhaProdutoNota.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2 DataContentCellNoLabel", "end", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavValortotal_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavValortotal_Internalname, AV11ValorTotal, StringUtil.RTrim( context.localUtil.Format( AV11ValorTotal, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavValortotal_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavValortotal_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WcLinhaProdutoNota.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "end", "top", "div");
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

      protected void START8K2( )
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
            Form.Meta.addItem("description", "Linha produto nota", 0) ;
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
               STRUP8K0( ) ;
            }
         }
      }

      protected void WS8K2( )
      {
         START8K2( ) ;
         EVT8K2( ) ;
      }

      protected void EVT8K2( )
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
                                 STRUP8K0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8K0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E118K2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8K0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E128K2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8K0( ) ;
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
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8K0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = chkavSelecionar_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
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

      protected void WE8K2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm8K2( ) ;
            }
         }
      }

      protected void PA8K2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wclinhaprodutonota")), "wclinhaprodutonota") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wclinhaprodutonota")))) ;
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
                     gxfirstwebparm = GetFirstPar( "JSON");
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
               GX_FocusControl = chkavSelecionar_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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
         AV5Selecionar = StringUtil.StrToBool( StringUtil.BoolToStr( AV5Selecionar));
         AssignAttri(sPrefix, false, "AV5Selecionar", AV5Selecionar);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF8K2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavNotafiscal_Enabled = 0;
         AssignProp(sPrefix, false, edtavNotafiscal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNotafiscal_Enabled), 5, 0), true);
         edtavCodigo_Enabled = 0;
         AssignProp(sPrefix, false, edtavCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCodigo_Enabled), 5, 0), true);
         edtavDescricao_Enabled = 0;
         AssignProp(sPrefix, false, edtavDescricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDescricao_Enabled), 5, 0), true);
         edtavQuantidade_Enabled = 0;
         AssignProp(sPrefix, false, edtavQuantidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavQuantidade_Enabled), 5, 0), true);
         edtavValorunitario_Enabled = 0;
         AssignProp(sPrefix, false, edtavValorunitario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavValorunitario_Enabled), 5, 0), true);
         edtavValortotal_Enabled = 0;
         AssignProp(sPrefix, false, edtavValortotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavValortotal_Enabled), 5, 0), true);
      }

      protected void RF8K2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E128K2 ();
            WB8K0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes8K2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDPRODUTONOTAFISCAL", AV13SdProdutoNotaFiscal);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDPRODUTONOTAFISCAL", AV13SdProdutoNotaFiscal);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSDPRODUTONOTAFISCAL", GetSecureSignedToken( sPrefix, AV13SdProdutoNotaFiscal, context));
      }

      protected void before_start_formulas( )
      {
         edtavNotafiscal_Enabled = 0;
         AssignProp(sPrefix, false, edtavNotafiscal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNotafiscal_Enabled), 5, 0), true);
         edtavCodigo_Enabled = 0;
         AssignProp(sPrefix, false, edtavCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCodigo_Enabled), 5, 0), true);
         edtavDescricao_Enabled = 0;
         AssignProp(sPrefix, false, edtavDescricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDescricao_Enabled), 5, 0), true);
         edtavQuantidade_Enabled = 0;
         AssignProp(sPrefix, false, edtavQuantidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavQuantidade_Enabled), 5, 0), true);
         edtavValorunitario_Enabled = 0;
         AssignProp(sPrefix, false, edtavValorunitario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavValorunitario_Enabled), 5, 0), true);
         edtavValortotal_Enabled = 0;
         AssignProp(sPrefix, false, edtavValortotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavValortotal_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP8K0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E118K2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vSDPRODUTONOTAFISCAL"), AV13SdProdutoNotaFiscal);
            /* Read saved values. */
            wcpOAV12JSON = cgiGet( sPrefix+"wcpOAV12JSON");
            wcpOAV16IsPermiteSelecionar = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV16IsPermiteSelecionar"));
            AV14isMarcar = StringUtil.StrToBool( cgiGet( sPrefix+"vISMARCAR"));
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
         E118K2 ();
         if (returnInSub) return;
      }

      protected void E118K2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV13SdProdutoNotaFiscal.FromJSonString(AV12JSON, null);
         AV7Codigo = AV13SdProdutoNotaFiscal.gxTpr_Cprod;
         AssignAttri(sPrefix, false, "AV7Codigo", AV7Codigo);
         AV8Descricao = AV13SdProdutoNotaFiscal.gxTpr_Xprod;
         AssignAttri(sPrefix, false, "AV8Descricao", AV8Descricao);
         AV6NotaFiscal = AV13SdProdutoNotaFiscal.gxTpr_Cnfe;
         AssignAttri(sPrefix, false, "AV6NotaFiscal", AV6NotaFiscal);
         AV9Quantidade = AV13SdProdutoNotaFiscal.gxTpr_Qcom;
         AssignAttri(sPrefix, false, "AV9Quantidade", AV9Quantidade);
         AV5Selecionar = AV13SdProdutoNotaFiscal.gxTpr_Issel;
         AssignAttri(sPrefix, false, "AV5Selecionar", AV5Selecionar);
         AV15Valor = NumberUtil.Val( StringUtil.Trim( AV13SdProdutoNotaFiscal.gxTpr_Vprod), ".");
         AV11ValorTotal = StringUtil.Format( "R$%1", context.localUtil.Format( AV15Valor, "ZZZ,ZZZ,ZZZ,ZZ9.99"), "", "", "", "", "", "", "", "");
         AssignAttri(sPrefix, false, "AV11ValorTotal", AV11ValorTotal);
         AV15Valor = NumberUtil.Val( StringUtil.Trim( AV13SdProdutoNotaFiscal.gxTpr_Vuncom), ".");
         AV10ValorUnitario = StringUtil.Format( "R$%1", context.localUtil.Format( AV15Valor, "ZZZ,ZZZ,ZZZ,ZZ9.99"), "", "", "", "", "", "", "", "");
         AssignAttri(sPrefix, false, "AV10ValorUnitario", AV10ValorUnitario);
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if (returnInSub) return;
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ! ( AV16IsPermiteSelecionar ) )
         {
            chkavSelecionar.Visible = 0;
            AssignProp(sPrefix, false, chkavSelecionar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavSelecionar.Visible), 5, 0), true);
            divSelecionar_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divSelecionar_cell_Internalname, "Class", divSelecionar_cell_Class, true);
         }
         else
         {
            chkavSelecionar.Visible = 1;
            AssignProp(sPrefix, false, chkavSelecionar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavSelecionar.Visible), 5, 0), true);
            divSelecionar_cell_Class = "col-xs-12 col-sm-1 DataContentCellNoLabel";
            AssignProp(sPrefix, false, divSelecionar_cell_Internalname, "Class", divSelecionar_cell_Class, true);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E128K2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV12JSON = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV12JSON", AV12JSON);
         AV16IsPermiteSelecionar = (bool)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV16IsPermiteSelecionar", AV16IsPermiteSelecionar);
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
         PA8K2( ) ;
         WS8K2( ) ;
         WE8K2( ) ;
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
         sCtrlAV12JSON = (string)((string)getParm(obj,0));
         sCtrlAV16IsPermiteSelecionar = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA8K2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wclinhaprodutonota", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA8K2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV12JSON = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV12JSON", AV12JSON);
            AV16IsPermiteSelecionar = (bool)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV16IsPermiteSelecionar", AV16IsPermiteSelecionar);
         }
         wcpOAV12JSON = cgiGet( sPrefix+"wcpOAV12JSON");
         wcpOAV16IsPermiteSelecionar = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV16IsPermiteSelecionar"));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV12JSON, wcpOAV12JSON) != 0 ) || ( AV16IsPermiteSelecionar != wcpOAV16IsPermiteSelecionar ) ) )
         {
            setjustcreated();
         }
         wcpOAV12JSON = AV12JSON;
         wcpOAV16IsPermiteSelecionar = AV16IsPermiteSelecionar;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV12JSON = cgiGet( sPrefix+"AV12JSON_CTRL");
         if ( StringUtil.Len( sCtrlAV12JSON) > 0 )
         {
            AV12JSON = cgiGet( sCtrlAV12JSON);
            AssignAttri(sPrefix, false, "AV12JSON", AV12JSON);
         }
         else
         {
            AV12JSON = cgiGet( sPrefix+"AV12JSON_PARM");
         }
         sCtrlAV16IsPermiteSelecionar = cgiGet( sPrefix+"AV16IsPermiteSelecionar_CTRL");
         if ( StringUtil.Len( sCtrlAV16IsPermiteSelecionar) > 0 )
         {
            AV16IsPermiteSelecionar = StringUtil.StrToBool( cgiGet( sCtrlAV16IsPermiteSelecionar));
            AssignAttri(sPrefix, false, "AV16IsPermiteSelecionar", AV16IsPermiteSelecionar);
         }
         else
         {
            AV16IsPermiteSelecionar = StringUtil.StrToBool( cgiGet( sPrefix+"AV16IsPermiteSelecionar_PARM"));
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
         PA8K2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS8K2( ) ;
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
         WS8K2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV12JSON_PARM", AV12JSON);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV12JSON)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV12JSON_CTRL", StringUtil.RTrim( sCtrlAV12JSON));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV16IsPermiteSelecionar_PARM", StringUtil.BoolToStr( AV16IsPermiteSelecionar));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV16IsPermiteSelecionar)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV16IsPermiteSelecionar_CTRL", StringUtil.RTrim( sCtrlAV16IsPermiteSelecionar));
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
         WE8K2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101963968", true, true);
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
         context.AddJavascriptSource("wclinhaprodutonota.js", "?20256101963968", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         chkavSelecionar.Name = "vSELECIONAR";
         chkavSelecionar.WebTags = "";
         chkavSelecionar.Caption = "Selecionar";
         AssignProp(sPrefix, false, chkavSelecionar_Internalname, "TitleCaption", chkavSelecionar.Caption, true);
         chkavSelecionar.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         chkavSelecionar_Internalname = sPrefix+"vSELECIONAR";
         divSelecionar_cell_Internalname = sPrefix+"SELECIONAR_CELL";
         edtavNotafiscal_Internalname = sPrefix+"vNOTAFISCAL";
         edtavCodigo_Internalname = sPrefix+"vCODIGO";
         edtavDescricao_Internalname = sPrefix+"vDESCRICAO";
         edtavQuantidade_Internalname = sPrefix+"vQUANTIDADE";
         edtavValorunitario_Internalname = sPrefix+"vVALORUNITARIO";
         edtavValortotal_Internalname = sPrefix+"vVALORTOTAL";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
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
         chkavSelecionar.Caption = "Selecionar";
         edtavValortotal_Jsonclick = "";
         edtavValortotal_Enabled = 1;
         edtavValorunitario_Jsonclick = "";
         edtavValorunitario_Enabled = 1;
         edtavQuantidade_Jsonclick = "";
         edtavQuantidade_Enabled = 1;
         edtavDescricao_Jsonclick = "";
         edtavDescricao_Enabled = 1;
         edtavCodigo_Jsonclick = "";
         edtavCodigo_Enabled = 1;
         edtavNotafiscal_Jsonclick = "";
         edtavNotafiscal_Enabled = 1;
         chkavSelecionar.Enabled = 1;
         chkavSelecionar.Visible = 1;
         divSelecionar_cell_Class = "col-xs-12 col-sm-1";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV5Selecionar","fld":"vSELECIONAR","type":"boolean"},{"av":"AV13SdProdutoNotaFiscal","fld":"vSDPRODUTONOTAFISCAL","hsh":true,"type":""}]}""");
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
         wcpOAV12JSON = "";
         AV13SdProdutoNotaFiscal = new SdtSdProdutoNotaFiscal(context);
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV6NotaFiscal = "";
         AV7Codigo = "";
         AV8Descricao = "";
         AV9Quantidade = "";
         AV10ValorUnitario = "";
         AV11ValorTotal = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV12JSON = "";
         sCtrlAV16IsPermiteSelecionar = "";
         /* GeneXus formulas. */
         edtavNotafiscal_Enabled = 0;
         edtavCodigo_Enabled = 0;
         edtavDescricao_Enabled = 0;
         edtavQuantidade_Enabled = 0;
         edtavValorunitario_Enabled = 0;
         edtavValortotal_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int edtavNotafiscal_Enabled ;
      private int edtavCodigo_Enabled ;
      private int edtavDescricao_Enabled ;
      private int edtavQuantidade_Enabled ;
      private int edtavValorunitario_Enabled ;
      private int edtavValortotal_Enabled ;
      private int idxLst ;
      private decimal AV15Valor ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string edtavNotafiscal_Internalname ;
      private string edtavCodigo_Internalname ;
      private string edtavDescricao_Internalname ;
      private string edtavQuantidade_Internalname ;
      private string edtavValorunitario_Internalname ;
      private string edtavValortotal_Internalname ;
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
      private string divSelecionar_cell_Internalname ;
      private string divSelecionar_cell_Class ;
      private string chkavSelecionar_Internalname ;
      private string TempTags ;
      private string edtavNotafiscal_Jsonclick ;
      private string edtavCodigo_Jsonclick ;
      private string edtavDescricao_Jsonclick ;
      private string edtavQuantidade_Jsonclick ;
      private string edtavValorunitario_Jsonclick ;
      private string edtavValortotal_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string sCtrlAV12JSON ;
      private string sCtrlAV16IsPermiteSelecionar ;
      private bool AV16IsPermiteSelecionar ;
      private bool wcpOAV16IsPermiteSelecionar ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14isMarcar ;
      private bool wbLoad ;
      private bool AV5Selecionar ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV12JSON ;
      private string wcpOAV12JSON ;
      private string AV6NotaFiscal ;
      private string AV7Codigo ;
      private string AV8Descricao ;
      private string AV9Quantidade ;
      private string AV10ValorUnitario ;
      private string AV11ValorTotal ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavSelecionar ;
      private SdtSdProdutoNotaFiscal AV13SdProdutoNotaFiscal ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
