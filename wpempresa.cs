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
   public class wpempresa : GXWebComponent
   {
      public wpempresa( )
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

      public wpempresa( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_TrnMode ,
                           int aP1_EmpresaId )
      {
         this.AV12TrnMode = aP0_TrnMode;
         this.AV16EmpresaId = aP1_EmpresaId;
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
         cmbavEmpresa_empresapixtipo = new GXCombobox();
         cmbavEmpresa_empresautilizarepresentanteassinatura = new GXCombobox();
         cmbavEmpresa_empresasede = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "TrnMode");
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
                  AV12TrnMode = GetPar( "TrnMode");
                  AssignAttri(sPrefix, false, "AV12TrnMode", AV12TrnMode);
                  AV16EmpresaId = (int)(Math.Round(NumberUtil.Val( GetPar( "EmpresaId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV16EmpresaId", StringUtil.LTrimStr( (decimal)(AV16EmpresaId), 9, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV12TrnMode,(int)AV16EmpresaId});
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
                  gxfirstwebparm = GetFirstPar( "TrnMode");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "TrnMode");
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
            PA822( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavMunicipionome_Enabled = 0;
               AssignProp(sPrefix, false, edtavMunicipionome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMunicipionome_Enabled), 5, 0), true);
               edtavMunicipiouf_Enabled = 0;
               AssignProp(sPrefix, false, edtavMunicipiouf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMunicipiouf_Enabled), 5, 0), true);
               edtavRepresentantemunicipionome_Enabled = 0;
               AssignProp(sPrefix, false, edtavRepresentantemunicipionome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRepresentantemunicipionome_Enabled), 5, 0), true);
               edtavRepresentantemunicipiouf_Enabled = 0;
               AssignProp(sPrefix, false, edtavRepresentantemunicipiouf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRepresentantemunicipiouf_Enabled), 5, 0), true);
               WS822( ) ;
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
            context.SendWebValue( "Wp Empresa") ;
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
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
            context.WriteHtmlText( " "+"class=\"form-horizontal FormWithFixedActions\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wpempresa"+UrlEncode(StringUtil.RTrim(AV12TrnMode)) + "," + UrlEncode(StringUtil.LTrimStr(AV16EmpresaId,9,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("wpempresa") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal FormWithFixedActions", true);
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
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal FormWithFixedActions" : Form.Class)+"-fx");
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vPROFISSAOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31ProfissaoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROFISSAOID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV31ProfissaoId), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Empresa", AV5Empresa);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Empresa", AV5Empresa);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vEMPRESA_EMPRESABANCOID_DATA", AV7Empresa_EmpresaBancoId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vEMPRESA_EMPRESABANCOID_DATA", AV7Empresa_EmpresaBancoId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vEMPRESA_EMPRESAREPRESENTANTEPROFISSAO_DATA", AV17Empresa_EmpresaRepresentanteProfissao_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vEMPRESA_EMPRESAREPRESENTANTEPROFISSAO_DATA", AV17Empresa_EmpresaRepresentanteProfissao_Data);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV12TrnMode", StringUtil.RTrim( wcpOAV12TrnMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV16EmpresaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV16EmpresaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTRNMODE", StringUtil.RTrim( AV12TrnMode));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vCHECKREQUIREDFIELDSRESULT", AV14CheckRequiredFieldsResult);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vMESSAGES", AV11Messages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vMESSAGES", AV11Messages);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vPROFISSAOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31ProfissaoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROFISSAOID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV31ProfissaoId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"PROFISSAONOME", A441ProfissaoNome);
         GxWebStd.gx_hidden_field( context, sPrefix+"PROFISSAOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A440ProfissaoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vEMPRESAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16EmpresaId), 9, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vEMPRESA", AV5Empresa);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vEMPRESA", AV5Empresa);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_EMPRESA_EMPRESABANCOID_Cls", StringUtil.RTrim( Combo_empresa_empresabancoid_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_EMPRESA_EMPRESABANCOID_Selectedvalue_set", StringUtil.RTrim( Combo_empresa_empresabancoid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_EMPRESA_EMPRESABANCOID_Enabled", StringUtil.BoolToStr( Combo_empresa_empresabancoid_Enabled));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_EMPRESA_EMPRESABANCOID_Emptyitem", StringUtil.BoolToStr( Combo_empresa_empresabancoid_Emptyitem));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_EMPRESA_EMPRESABANCOID_Htmltemplate", StringUtil.RTrim( Combo_empresa_empresabancoid_Htmltemplate));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_EMPRESA_EMPRESAREPRESENTANTEPROFISSAO_Cls", StringUtil.RTrim( Combo_empresa_empresarepresentanteprofissao_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_EMPRESA_EMPRESAREPRESENTANTEPROFISSAO_Selectedvalue_set", StringUtil.RTrim( Combo_empresa_empresarepresentanteprofissao_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_EMPRESA_EMPRESAREPRESENTANTEPROFISSAO_Enabled", StringUtil.BoolToStr( Combo_empresa_empresarepresentanteprofissao_Enabled));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_EMPRESA_EMPRESAREPRESENTANTEPROFISSAO_Emptyitem", StringUtil.BoolToStr( Combo_empresa_empresarepresentanteprofissao_Emptyitem));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_EMPRESA_EMPRESAREPRESENTANTEPROFISSAO_Includeaddnewoption", StringUtil.BoolToStr( Combo_empresa_empresarepresentanteprofissao_Includeaddnewoption));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXUITABSPANEL_TABS1_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gxuitabspanel_tabs1_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXUITABSPANEL_TABS1_Class", StringUtil.RTrim( Gxuitabspanel_tabs1_Class));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXUITABSPANEL_TABS1_Historymanagement", StringUtil.BoolToStr( Gxuitabspanel_tabs1_Historymanagement));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_EMPRESA_EMPRESAREPRESENTANTEPROFISSAO_Selectedvalue_get", StringUtil.RTrim( Combo_empresa_empresarepresentanteprofissao_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_EMPRESA_EMPRESABANCOID_Selectedvalue_get", StringUtil.RTrim( Combo_empresa_empresabancoid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_EMPRESA_EMPRESAREPRESENTANTEPROFISSAO_Selectedvalue_get", StringUtil.RTrim( Combo_empresa_empresarepresentanteprofissao_Selectedvalue_get));
      }

      protected void RenderHtmlCloseForm822( )
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
         return "WpEmpresa" ;
      }

      public override string GetPgmdesc( )
      {
         return "Wp Empresa" ;
      }

      protected void WB820( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wpempresa");
               context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
               context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
               context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
               context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
               context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 15,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", "Salvar informações da empresa", bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtnenter_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGxuitabspanel_tabs1.SetProperty("PageCount", Gxuitabspanel_tabs1_Pagecount);
            ucGxuitabspanel_tabs1.SetProperty("Class", Gxuitabspanel_tabs1_Class);
            ucGxuitabspanel_tabs1.SetProperty("HistoryManagement", Gxuitabspanel_tabs1_Historymanagement);
            ucGxuitabspanel_tabs1.Render(context, "tab", Gxuitabspanel_tabs1_Internalname, sPrefix+"GXUITABSPANEL_TABS1Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_TABS1Container"+"title1"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblInfo_title_Internalname, "Informações gerais", "", "", lblInfo_title_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WpEmpresa.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Info") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_TABS1Container"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmpresa_empresanomefantasia_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmpresa_empresanomefantasia_Internalname, "Nome fantasia", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresa_empresanomefantasia_Internalname, AV5Empresa.gxTpr_Empresanomefantasia, StringUtil.RTrim( context.localUtil.Format( AV5Empresa.gxTpr_Empresanomefantasia, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresa_empresanomefantasia_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmpresa_empresanomefantasia_Enabled, 1, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmpresa_empresarazaosocial_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmpresa_empresarazaosocial_Internalname, "Razão social", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresa_empresarazaosocial_Internalname, AV5Empresa.gxTpr_Empresarazaosocial, StringUtil.RTrim( context.localUtil.Format( AV5Empresa.gxTpr_Empresarazaosocial, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresa_empresarazaosocial_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmpresa_empresarazaosocial_Enabled, 1, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmpresa_empresacnpj_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmpresa_empresacnpj_Internalname, "CNPJ", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresa_empresacnpj_Internalname, AV5Empresa.gxTpr_Empresacnpj, StringUtil.RTrim( context.localUtil.Format( AV5Empresa.gxTpr_Empresacnpj, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresa_empresacnpj_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmpresa_empresacnpj_Enabled, 1, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedempresa_empresabancoid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_empresa_empresabancoid_Internalname, "Banco", "", "", lblTextblockcombo_empresa_empresabancoid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_empresa_empresabancoid.SetProperty("Caption", Combo_empresa_empresabancoid_Caption);
            ucCombo_empresa_empresabancoid.SetProperty("Cls", Combo_empresa_empresabancoid_Cls);
            ucCombo_empresa_empresabancoid.SetProperty("EmptyItem", Combo_empresa_empresabancoid_Emptyitem);
            ucCombo_empresa_empresabancoid.SetProperty("DropDownOptionsData", AV7Empresa_EmpresaBancoId_Data);
            ucCombo_empresa_empresabancoid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_empresa_empresabancoid_Internalname, sPrefix+"COMBO_EMPRESA_EMPRESABANCOIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmpresa_empresaagencia_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmpresa_empresaagencia_Internalname, "Agência", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresa_empresaagencia_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Empresa.gxTpr_Empresaagencia), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5Empresa.gxTpr_Empresaagencia), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,49);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresa_empresaagencia_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmpresa_empresaagencia_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmpresa_empresaagenciadigito_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmpresa_empresaagenciadigito_Internalname, "Dígito", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresa_empresaagenciadigito_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Empresa.gxTpr_Empresaagenciadigito), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5Empresa.gxTpr_Empresaagenciadigito), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,53);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresa_empresaagenciadigito_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmpresa_empresaagenciadigito_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmpresa_empresaconta_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmpresa_empresaconta_Internalname, "Conta", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresa_empresaconta_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Empresa.gxTpr_Empresaconta), 8, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5Empresa.gxTpr_Empresaconta), "ZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,58);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresa_empresaconta_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmpresa_empresaconta_Enabled, 1, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavEmpresa_empresapixtipo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavEmpresa_empresapixtipo_Internalname, "Tipo do pix", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavEmpresa_empresapixtipo, cmbavEmpresa_empresapixtipo_Internalname, StringUtil.RTrim( AV5Empresa.gxTpr_Empresapixtipo), 1, cmbavEmpresa_empresapixtipo_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavEmpresa_empresapixtipo.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "", true, 0, "HLP_WpEmpresa.htm");
            cmbavEmpresa_empresapixtipo.CurrentValue = StringUtil.RTrim( AV5Empresa.gxTpr_Empresapixtipo);
            AssignProp(sPrefix, false, cmbavEmpresa_empresapixtipo_Internalname, "Values", (string)(cmbavEmpresa_empresapixtipo.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmpresa_empresapix_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmpresa_empresapix_Internalname, "Chave pix", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresa_empresapix_Internalname, AV5Empresa.gxTpr_Empresapix, StringUtil.RTrim( context.localUtil.Format( AV5Empresa.gxTpr_Empresapix, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresa_empresapix_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmpresa_empresapix_Enabled, 1, "text", "", 70, "chr", 1, "row", 70, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmpresa_empresaemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmpresa_empresaemail_Internalname, "Email", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresa_empresaemail_Internalname, AV5Empresa.gxTpr_Empresaemail, StringUtil.RTrim( context.localUtil.Format( AV5Empresa.gxTpr_Empresaemail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,72);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresa_empresaemail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmpresa_empresaemail_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WpEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_TABS1Container"+"title2"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblEndereco_title_Internalname, "Endereço", "", "", lblEndereco_title_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WpEmpresa.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Endereco") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_TABS1Container"+"panel2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmpresa_empresacep_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmpresa_empresacep_Internalname, "CEP", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresa_empresacep_Internalname, AV5Empresa.gxTpr_Empresacep, StringUtil.RTrim( context.localUtil.Format( AV5Empresa.gxTpr_Empresacep, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,82);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresa_empresacep_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmpresa_empresacep_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmpresa_empresalogradouro_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmpresa_empresalogradouro_Internalname, "Logradouro", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresa_empresalogradouro_Internalname, AV5Empresa.gxTpr_Empresalogradouro, StringUtil.RTrim( context.localUtil.Format( AV5Empresa.gxTpr_Empresalogradouro, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,86);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresa_empresalogradouro_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmpresa_empresalogradouro_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmpresa_empresalogradouronumero_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmpresa_empresalogradouronumero_Internalname, "Número", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresa_empresalogradouronumero_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Empresa.gxTpr_Empresalogradouronumero), 10, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5Empresa.gxTpr_Empresalogradouronumero), "ZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,91);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresa_empresalogradouronumero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmpresa_empresalogradouronumero_Enabled, 1, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmpresa_empresabairro_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmpresa_empresabairro_Internalname, "Bairro", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresa_empresabairro_Internalname, AV5Empresa.gxTpr_Empresabairro, StringUtil.RTrim( context.localUtil.Format( AV5Empresa.gxTpr_Empresabairro, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,95);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresa_empresabairro_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmpresa_empresabairro_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedmunicipionome_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockmunicipionome_Internalname, "Municipio", "", "", lblTextblockmunicipionome_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            wb_table1_103_822( true) ;
         }
         else
         {
            wb_table1_103_822( false) ;
         }
         return  ;
      }

      protected void wb_table1_103_822e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmpresa_empresacomplemento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmpresa_empresacomplemento_Internalname, "Complemento", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 115,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresa_empresacomplemento_Internalname, AV5Empresa.gxTpr_Empresacomplemento, StringUtil.RTrim( context.localUtil.Format( AV5Empresa.gxTpr_Empresacomplemento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,115);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresa_empresacomplemento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmpresa_empresacomplemento_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_TABS1Container"+"title3"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblRepresentante_title_Internalname, "Representante", "", "", lblRepresentante_title_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WpEmpresa.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Representante") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_TABS1Container"+"panel3"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 col-md-4 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmpresa_empresarepresentantecpf_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmpresa_empresarepresentantecpf_Internalname, "CPF", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 125,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresa_empresarepresentantecpf_Internalname, AV5Empresa.gxTpr_Empresarepresentantecpf, StringUtil.RTrim( context.localUtil.Format( AV5Empresa.gxTpr_Empresarepresentantecpf, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,125);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresa_empresarepresentantecpf_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmpresa_empresarepresentantecpf_Enabled, 1, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 col-md-8 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmpresa_empresarepresentantenome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmpresa_empresarepresentantenome_Internalname, "Nome", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 129,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresa_empresarepresentantenome_Internalname, AV5Empresa.gxTpr_Empresarepresentantenome, StringUtil.RTrim( context.localUtil.Format( AV5Empresa.gxTpr_Empresarepresentantenome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,129);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresa_empresarepresentantenome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmpresa_empresarepresentantenome_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmpresa_empresarepresentanteemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmpresa_empresarepresentanteemail_Internalname, "E-mail", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 134,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresa_empresarepresentanteemail_Internalname, AV5Empresa.gxTpr_Empresarepresentanteemail, StringUtil.RTrim( context.localUtil.Format( AV5Empresa.gxTpr_Empresarepresentanteemail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,134);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresa_empresarepresentanteemail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmpresa_empresarepresentanteemail_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WpEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmpresa_empresarepresentantenacionalidade_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmpresa_empresarepresentantenacionalidade_Internalname, "Nacionalidade", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 138,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresa_empresarepresentantenacionalidade_Internalname, AV5Empresa.gxTpr_Empresarepresentantenacionalidade, StringUtil.RTrim( context.localUtil.Format( AV5Empresa.gxTpr_Empresarepresentantenacionalidade, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,138);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresa_empresarepresentantenacionalidade_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmpresa_empresarepresentantenacionalidade_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedempresa_empresarepresentanteprofissao_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_empresa_empresarepresentanteprofissao_Internalname, "Profissão", "", "", lblTextblockcombo_empresa_empresarepresentanteprofissao_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_empresa_empresarepresentanteprofissao.SetProperty("Caption", Combo_empresa_empresarepresentanteprofissao_Caption);
            ucCombo_empresa_empresarepresentanteprofissao.SetProperty("Cls", Combo_empresa_empresarepresentanteprofissao_Cls);
            ucCombo_empresa_empresarepresentanteprofissao.SetProperty("EmptyItem", Combo_empresa_empresarepresentanteprofissao_Emptyitem);
            ucCombo_empresa_empresarepresentanteprofissao.SetProperty("IncludeAddNewOption", Combo_empresa_empresarepresentanteprofissao_Includeaddnewoption);
            ucCombo_empresa_empresarepresentanteprofissao.SetProperty("DropDownOptionsData", AV17Empresa_EmpresaRepresentanteProfissao_Data);
            ucCombo_empresa_empresarepresentanteprofissao.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_empresa_empresarepresentanteprofissao_Internalname, sPrefix+"COMBO_EMPRESA_EMPRESAREPRESENTANTEPROFISSAOContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavEmpresa_empresautilizarepresentanteassinatura_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavEmpresa_empresautilizarepresentanteassinatura_Internalname, "Utilizar representante nas assinaturas", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 150,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavEmpresa_empresautilizarepresentanteassinatura, cmbavEmpresa_empresautilizarepresentanteassinatura_Internalname, StringUtil.BoolToStr( AV5Empresa.gxTpr_Empresautilizarepresentanteassinatura), 1, cmbavEmpresa_empresautilizarepresentanteassinatura_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbavEmpresa_empresautilizarepresentanteassinatura.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,150);\"", "", true, 0, "HLP_WpEmpresa.htm");
            cmbavEmpresa_empresautilizarepresentanteassinatura.CurrentValue = StringUtil.BoolToStr( AV5Empresa.gxTpr_Empresautilizarepresentanteassinatura);
            AssignProp(sPrefix, false, cmbavEmpresa_empresautilizarepresentanteassinatura_Internalname, "Values", (string)(cmbavEmpresa_empresautilizarepresentanteassinatura.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 col-md-4 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmpresa_empresarepresentantecep_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmpresa_empresarepresentantecep_Internalname, "CEP", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 155,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresa_empresarepresentantecep_Internalname, AV5Empresa.gxTpr_Empresarepresentantecep, StringUtil.RTrim( context.localUtil.Format( AV5Empresa.gxTpr_Empresarepresentantecep, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,155);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresa_empresarepresentantecep_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmpresa_empresarepresentantecep_Enabled, 1, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 col-md-8 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmpresa_empresarepresentantelogradouro_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmpresa_empresarepresentantelogradouro_Internalname, "Logradouro", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 159,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresa_empresarepresentantelogradouro_Internalname, AV5Empresa.gxTpr_Empresarepresentantelogradouro, StringUtil.RTrim( context.localUtil.Format( AV5Empresa.gxTpr_Empresarepresentantelogradouro, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,159);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresa_empresarepresentantelogradouro_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmpresa_empresarepresentantelogradouro_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 col-md-3 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmpresa_empresarepresentantenumero_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmpresa_empresarepresentantenumero_Internalname, "Número", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 164,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresa_empresarepresentantenumero_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Empresa.gxTpr_Empresarepresentantenumero), 10, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5Empresa.gxTpr_Empresarepresentantenumero), "ZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,164);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresa_empresarepresentantenumero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmpresa_empresarepresentantenumero_Enabled, 1, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 col-md-9 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmpresa_empresarepresentantebairro_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmpresa_empresarepresentantebairro_Internalname, "Bairro", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 168,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresa_empresarepresentantebairro_Internalname, AV5Empresa.gxTpr_Empresarepresentantebairro, StringUtil.RTrim( context.localUtil.Format( AV5Empresa.gxTpr_Empresarepresentantebairro, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,168);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresa_empresarepresentantebairro_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmpresa_empresarepresentantebairro_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmpresa_empresarepresentantecomplemento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmpresa_empresarepresentantecomplemento_Internalname, "Complemento", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 173,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresa_empresarepresentantecomplemento_Internalname, AV5Empresa.gxTpr_Empresarepresentantecomplemento, StringUtil.RTrim( context.localUtil.Format( AV5Empresa.gxTpr_Empresarepresentantecomplemento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,173);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresa_empresarepresentantecomplemento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmpresa_empresarepresentantecomplemento_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedrepresentantemunicipionome_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockrepresentantemunicipionome_Internalname, "Municipio", "", "", lblTextblockrepresentantemunicipionome_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            wb_table2_180_822( true) ;
         }
         else
         {
            wb_table2_180_822( false) ;
         }
         return  ;
      }

      protected void wb_table2_180_822e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 col-md-3 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmpresa_empresarepresentantetelefoneddd_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmpresa_empresarepresentantetelefoneddd_Internalname, "DDD", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 193,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresa_empresarepresentantetelefoneddd_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Empresa.gxTpr_Empresarepresentantetelefoneddd), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5Empresa.gxTpr_Empresarepresentantetelefoneddd), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,193);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresa_empresarepresentantetelefoneddd_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmpresa_empresarepresentantetelefoneddd_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmpresa_empresarepresentantetelefone_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmpresa_empresarepresentantetelefone_Internalname, "Telefone", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 197,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresa_empresarepresentantetelefone_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Empresa.gxTpr_Empresarepresentantetelefone), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5Empresa.gxTpr_Empresarepresentantetelefone), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,197);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresa_empresarepresentantetelefone_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmpresa_empresarepresentantetelefone_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpEmpresa.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 201,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresa_empresarepresentantemunicipio_Internalname, AV5Empresa.gxTpr_Empresarepresentantemunicipio, StringUtil.RTrim( context.localUtil.Format( AV5Empresa.gxTpr_Empresarepresentantemunicipio, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,201);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresa_empresarepresentantemunicipio_Jsonclick, 0, "Attribute", "", "", "", "", edtavEmpresa_empresarepresentantemunicipio_Visible, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpEmpresa.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 202,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresa_municipiocodigo_Internalname, AV5Empresa.gxTpr_Municipiocodigo, StringUtil.RTrim( context.localUtil.Format( AV5Empresa.gxTpr_Municipiocodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,202);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresa_municipiocodigo_Jsonclick, 0, "Attribute", "", "", "", "", edtavEmpresa_municipiocodigo_Visible, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpEmpresa.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 203,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresa_empresaid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Empresa.gxTpr_Empresaid), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5Empresa.gxTpr_Empresaid), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,203);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresa_empresaid_Jsonclick, 0, "Attribute", "", "", "", "", edtavEmpresa_empresaid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpEmpresa.htm");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 204,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavEmpresa_empresasede, cmbavEmpresa_empresasede_Internalname, StringUtil.BoolToStr( AV5Empresa.gxTpr_Empresasede), 1, cmbavEmpresa_empresasede_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "boolean", "", cmbavEmpresa_empresasede.Visible, 1, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,204);\"", "", true, 0, "HLP_WpEmpresa.htm");
            cmbavEmpresa_empresasede.CurrentValue = StringUtil.BoolToStr( AV5Empresa.gxTpr_Empresasede);
            AssignProp(sPrefix, false, cmbavEmpresa_empresasede_Internalname, "Values", (string)(cmbavEmpresa_empresasede.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START822( )
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
            Form.Meta.addItem("description", "Wp Empresa", 0) ;
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
               STRUP820( ) ;
            }
         }
      }

      protected void WS822( )
      {
         START822( ) ;
         EVT822( ) ;
      }

      protected void EVT822( )
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
                                 STRUP820( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_EMPRESA_EMPRESAREPRESENTANTEPROFISSAO.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP820( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Combo_empresa_empresarepresentanteprofissao.Onoptionclicked */
                                    E11822 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP820( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E12822 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP820( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E13822 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP820( ) ;
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
                                          E14822 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "EMPRESA_EMPRESACEP.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP820( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Empresa_empresacep.Controlvaluechanged */
                                    E15822 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "EMPRESA_EMPRESAREPRESENTANTECEP.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP820( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Empresa_empresarepresentantecep.Controlvaluechanged */
                                    E16822 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP820( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E17822 ();
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP820( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavEmpresa_empresanomefantasia_Internalname;
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

      protected void WE822( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm822( ) ;
            }
         }
      }

      protected void PA822( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpempresa")), "wpempresa") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpempresa")))) ;
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
                     gxfirstwebparm = GetFirstPar( "TrnMode");
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
               GX_FocusControl = edtavEmpresa_empresanomefantasia_Internalname;
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
         if ( cmbavEmpresa_empresapixtipo.ItemCount > 0 )
         {
            AV5Empresa.gxTpr_Empresapixtipo = cmbavEmpresa_empresapixtipo.getValidValue(AV5Empresa.gxTpr_Empresapixtipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavEmpresa_empresapixtipo.CurrentValue = StringUtil.RTrim( AV5Empresa.gxTpr_Empresapixtipo);
            AssignProp(sPrefix, false, cmbavEmpresa_empresapixtipo_Internalname, "Values", cmbavEmpresa_empresapixtipo.ToJavascriptSource(), true);
         }
         if ( cmbavEmpresa_empresautilizarepresentanteassinatura.ItemCount > 0 )
         {
            AV5Empresa.gxTpr_Empresautilizarepresentanteassinatura = StringUtil.StrToBool( cmbavEmpresa_empresautilizarepresentanteassinatura.getValidValue(StringUtil.BoolToStr( AV5Empresa.gxTpr_Empresautilizarepresentanteassinatura)));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavEmpresa_empresautilizarepresentanteassinatura.CurrentValue = StringUtil.BoolToStr( AV5Empresa.gxTpr_Empresautilizarepresentanteassinatura);
            AssignProp(sPrefix, false, cmbavEmpresa_empresautilizarepresentanteassinatura_Internalname, "Values", cmbavEmpresa_empresautilizarepresentanteassinatura.ToJavascriptSource(), true);
         }
         if ( cmbavEmpresa_empresasede.ItemCount > 0 )
         {
            AV5Empresa.gxTpr_Empresasede = StringUtil.StrToBool( cmbavEmpresa_empresasede.getValidValue(StringUtil.BoolToStr( AV5Empresa.gxTpr_Empresasede)));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavEmpresa_empresasede.CurrentValue = StringUtil.BoolToStr( AV5Empresa.gxTpr_Empresasede);
            AssignProp(sPrefix, false, cmbavEmpresa_empresasede_Internalname, "Values", cmbavEmpresa_empresasede.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF822( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavMunicipionome_Enabled = 0;
         AssignProp(sPrefix, false, edtavMunicipionome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMunicipionome_Enabled), 5, 0), true);
         edtavMunicipiouf_Enabled = 0;
         AssignProp(sPrefix, false, edtavMunicipiouf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMunicipiouf_Enabled), 5, 0), true);
         edtavRepresentantemunicipionome_Enabled = 0;
         AssignProp(sPrefix, false, edtavRepresentantemunicipionome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRepresentantemunicipionome_Enabled), 5, 0), true);
         edtavRepresentantemunicipiouf_Enabled = 0;
         AssignProp(sPrefix, false, edtavRepresentantemunicipiouf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRepresentantemunicipiouf_Enabled), 5, 0), true);
      }

      protected void RF822( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E13822 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E17822 ();
            WB820( ) ;
         }
      }

      protected void send_integrity_lvl_hashes822( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPROFISSAOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31ProfissaoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROFISSAOID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV31ProfissaoId), "ZZZZZZZZ9"), context));
      }

      protected void before_start_formulas( )
      {
         edtavMunicipionome_Enabled = 0;
         AssignProp(sPrefix, false, edtavMunicipionome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMunicipionome_Enabled), 5, 0), true);
         edtavMunicipiouf_Enabled = 0;
         AssignProp(sPrefix, false, edtavMunicipiouf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMunicipiouf_Enabled), 5, 0), true);
         edtavRepresentantemunicipionome_Enabled = 0;
         AssignProp(sPrefix, false, edtavRepresentantemunicipionome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRepresentantemunicipionome_Enabled), 5, 0), true);
         edtavRepresentantemunicipiouf_Enabled = 0;
         AssignProp(sPrefix, false, edtavRepresentantemunicipiouf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRepresentantemunicipiouf_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP820( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E12822 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vEMPRESA"), AV5Empresa);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Empresa"), AV5Empresa);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vEMPRESA_EMPRESABANCOID_DATA"), AV7Empresa_EmpresaBancoId_Data);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vEMPRESA_EMPRESAREPRESENTANTEPROFISSAO_DATA"), AV17Empresa_EmpresaRepresentanteProfissao_Data);
            /* Read saved values. */
            wcpOAV12TrnMode = cgiGet( sPrefix+"wcpOAV12TrnMode");
            wcpOAV16EmpresaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV16EmpresaId"), ",", "."), 18, MidpointRounding.ToEven));
            Combo_empresa_empresabancoid_Cls = cgiGet( sPrefix+"COMBO_EMPRESA_EMPRESABANCOID_Cls");
            Combo_empresa_empresabancoid_Selectedvalue_set = cgiGet( sPrefix+"COMBO_EMPRESA_EMPRESABANCOID_Selectedvalue_set");
            Combo_empresa_empresabancoid_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_EMPRESA_EMPRESABANCOID_Enabled"));
            Combo_empresa_empresabancoid_Emptyitem = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_EMPRESA_EMPRESABANCOID_Emptyitem"));
            Combo_empresa_empresabancoid_Htmltemplate = cgiGet( sPrefix+"COMBO_EMPRESA_EMPRESABANCOID_Htmltemplate");
            Combo_empresa_empresarepresentanteprofissao_Cls = cgiGet( sPrefix+"COMBO_EMPRESA_EMPRESAREPRESENTANTEPROFISSAO_Cls");
            Combo_empresa_empresarepresentanteprofissao_Selectedvalue_set = cgiGet( sPrefix+"COMBO_EMPRESA_EMPRESAREPRESENTANTEPROFISSAO_Selectedvalue_set");
            Combo_empresa_empresarepresentanteprofissao_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_EMPRESA_EMPRESAREPRESENTANTEPROFISSAO_Enabled"));
            Combo_empresa_empresarepresentanteprofissao_Emptyitem = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_EMPRESA_EMPRESAREPRESENTANTEPROFISSAO_Emptyitem"));
            Combo_empresa_empresarepresentanteprofissao_Includeaddnewoption = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_EMPRESA_EMPRESAREPRESENTANTEPROFISSAO_Includeaddnewoption"));
            Gxuitabspanel_tabs1_Pagecount = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GXUITABSPANEL_TABS1_Pagecount"), ",", "."), 18, MidpointRounding.ToEven));
            Gxuitabspanel_tabs1_Class = cgiGet( sPrefix+"GXUITABSPANEL_TABS1_Class");
            Gxuitabspanel_tabs1_Historymanagement = StringUtil.StrToBool( cgiGet( sPrefix+"GXUITABSPANEL_TABS1_Historymanagement"));
            Combo_empresa_empresarepresentanteprofissao_Selectedvalue_get = cgiGet( sPrefix+"COMBO_EMPRESA_EMPRESAREPRESENTANTEPROFISSAO_Selectedvalue_get");
            /* Read variables values. */
            AV5Empresa.gxTpr_Empresanomefantasia = cgiGet( edtavEmpresa_empresanomefantasia_Internalname);
            AV5Empresa.gxTpr_Empresarazaosocial = cgiGet( edtavEmpresa_empresarazaosocial_Internalname);
            AV5Empresa.gxTpr_Empresacnpj = cgiGet( edtavEmpresa_empresacnpj_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavEmpresa_empresaagencia_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavEmpresa_empresaagencia_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "EMPRESA_EMPRESAAGENCIA");
               GX_FocusControl = edtavEmpresa_empresaagencia_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5Empresa.gxTpr_Empresaagencia = 0;
            }
            else
            {
               AV5Empresa.gxTpr_Empresaagencia = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavEmpresa_empresaagencia_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavEmpresa_empresaagenciadigito_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavEmpresa_empresaagenciadigito_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "EMPRESA_EMPRESAAGENCIADIGITO");
               GX_FocusControl = edtavEmpresa_empresaagenciadigito_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5Empresa.gxTpr_Empresaagenciadigito = 0;
            }
            else
            {
               AV5Empresa.gxTpr_Empresaagenciadigito = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavEmpresa_empresaagenciadigito_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavEmpresa_empresaconta_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavEmpresa_empresaconta_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "EMPRESA_EMPRESACONTA");
               GX_FocusControl = edtavEmpresa_empresaconta_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5Empresa.gxTpr_Empresaconta = 0;
            }
            else
            {
               AV5Empresa.gxTpr_Empresaconta = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavEmpresa_empresaconta_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            }
            cmbavEmpresa_empresapixtipo.CurrentValue = cgiGet( cmbavEmpresa_empresapixtipo_Internalname);
            AV5Empresa.gxTpr_Empresapixtipo = cgiGet( cmbavEmpresa_empresapixtipo_Internalname);
            AV5Empresa.gxTpr_Empresapix = cgiGet( edtavEmpresa_empresapix_Internalname);
            AV5Empresa.gxTpr_Empresaemail = cgiGet( edtavEmpresa_empresaemail_Internalname);
            AV5Empresa.gxTpr_Empresacep = cgiGet( edtavEmpresa_empresacep_Internalname);
            AV5Empresa.gxTpr_Empresalogradouro = cgiGet( edtavEmpresa_empresalogradouro_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavEmpresa_empresalogradouronumero_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavEmpresa_empresalogradouronumero_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "EMPRESA_EMPRESALOGRADOURONUMERO");
               GX_FocusControl = edtavEmpresa_empresalogradouronumero_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5Empresa.gxTpr_Empresalogradouronumero = 0;
            }
            else
            {
               AV5Empresa.gxTpr_Empresalogradouronumero = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavEmpresa_empresalogradouronumero_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            }
            AV5Empresa.gxTpr_Empresabairro = cgiGet( edtavEmpresa_empresabairro_Internalname);
            AV19MunicipioNome = StringUtil.Upper( cgiGet( edtavMunicipionome_Internalname));
            AssignAttri(sPrefix, false, "AV19MunicipioNome", AV19MunicipioNome);
            AV20MunicipioUF = StringUtil.Upper( cgiGet( edtavMunicipiouf_Internalname));
            AssignAttri(sPrefix, false, "AV20MunicipioUF", AV20MunicipioUF);
            AV5Empresa.gxTpr_Empresacomplemento = cgiGet( edtavEmpresa_empresacomplemento_Internalname);
            AV5Empresa.gxTpr_Empresarepresentantecpf = cgiGet( edtavEmpresa_empresarepresentantecpf_Internalname);
            AV5Empresa.gxTpr_Empresarepresentantenome = cgiGet( edtavEmpresa_empresarepresentantenome_Internalname);
            AV5Empresa.gxTpr_Empresarepresentanteemail = cgiGet( edtavEmpresa_empresarepresentanteemail_Internalname);
            AV5Empresa.gxTpr_Empresarepresentantenacionalidade = cgiGet( edtavEmpresa_empresarepresentantenacionalidade_Internalname);
            cmbavEmpresa_empresautilizarepresentanteassinatura.CurrentValue = cgiGet( cmbavEmpresa_empresautilizarepresentanteassinatura_Internalname);
            AV5Empresa.gxTpr_Empresautilizarepresentanteassinatura = StringUtil.StrToBool( cgiGet( cmbavEmpresa_empresautilizarepresentanteassinatura_Internalname));
            AV5Empresa.gxTpr_Empresarepresentantecep = cgiGet( edtavEmpresa_empresarepresentantecep_Internalname);
            AV5Empresa.gxTpr_Empresarepresentantelogradouro = cgiGet( edtavEmpresa_empresarepresentantelogradouro_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavEmpresa_empresarepresentantenumero_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavEmpresa_empresarepresentantenumero_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "EMPRESA_EMPRESAREPRESENTANTENUMERO");
               GX_FocusControl = edtavEmpresa_empresarepresentantenumero_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5Empresa.gxTpr_Empresarepresentantenumero = 0;
            }
            else
            {
               AV5Empresa.gxTpr_Empresarepresentantenumero = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavEmpresa_empresarepresentantenumero_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            }
            AV5Empresa.gxTpr_Empresarepresentantebairro = cgiGet( edtavEmpresa_empresarepresentantebairro_Internalname);
            AV5Empresa.gxTpr_Empresarepresentantecomplemento = cgiGet( edtavEmpresa_empresarepresentantecomplemento_Internalname);
            AV27RepresentanteMunicipioNome = StringUtil.Upper( cgiGet( edtavRepresentantemunicipionome_Internalname));
            AssignAttri(sPrefix, false, "AV27RepresentanteMunicipioNome", AV27RepresentanteMunicipioNome);
            AV28RepresentanteMunicipioUF = StringUtil.Upper( cgiGet( edtavRepresentantemunicipiouf_Internalname));
            AssignAttri(sPrefix, false, "AV28RepresentanteMunicipioUF", AV28RepresentanteMunicipioUF);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavEmpresa_empresarepresentantetelefoneddd_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavEmpresa_empresarepresentantetelefoneddd_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "EMPRESA_EMPRESAREPRESENTANTETELEFONEDDD");
               GX_FocusControl = edtavEmpresa_empresarepresentantetelefoneddd_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5Empresa.gxTpr_Empresarepresentantetelefoneddd = 0;
            }
            else
            {
               AV5Empresa.gxTpr_Empresarepresentantetelefoneddd = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavEmpresa_empresarepresentantetelefoneddd_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavEmpresa_empresarepresentantetelefone_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavEmpresa_empresarepresentantetelefone_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "EMPRESA_EMPRESAREPRESENTANTETELEFONE");
               GX_FocusControl = edtavEmpresa_empresarepresentantetelefone_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5Empresa.gxTpr_Empresarepresentantetelefone = 0;
            }
            else
            {
               AV5Empresa.gxTpr_Empresarepresentantetelefone = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavEmpresa_empresarepresentantetelefone_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            }
            AV5Empresa.gxTpr_Empresarepresentantemunicipio = cgiGet( edtavEmpresa_empresarepresentantemunicipio_Internalname);
            AV5Empresa.gxTpr_Municipiocodigo = cgiGet( edtavEmpresa_municipiocodigo_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavEmpresa_empresaid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavEmpresa_empresaid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "EMPRESA_EMPRESAID");
               GX_FocusControl = edtavEmpresa_empresaid_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5Empresa.gxTpr_Empresaid = 0;
            }
            else
            {
               AV5Empresa.gxTpr_Empresaid = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavEmpresa_empresaid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            }
            cmbavEmpresa_empresasede.CurrentValue = cgiGet( cmbavEmpresa_empresasede_Internalname);
            AV5Empresa.gxTpr_Empresasede = StringUtil.StrToBool( cgiGet( cmbavEmpresa_empresasede_Internalname));
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
         E12822 ();
         if (returnInSub) return;
      }

      protected void E12822( )
      {
         /* Start Routine */
         returnInSub = false;
         AV13LoadSuccess = true;
         if ( ( ( StringUtil.StrCmp(AV12TrnMode, "DSP") == 0 ) ) || ( ( StringUtil.StrCmp(AV12TrnMode, "INS") == 0 ) ) || ( ( StringUtil.StrCmp(AV12TrnMode, "UPD") == 0 ) ) || ( ( StringUtil.StrCmp(AV12TrnMode, "DLT") == 0 ) ) )
         {
            if ( StringUtil.StrCmp(AV12TrnMode, "INS") != 0 )
            {
               AV5Empresa.Load(AV16EmpresaId);
               AV13LoadSuccess = AV5Empresa.Success();
               if ( ! AV13LoadSuccess )
               {
                  AV11Messages = AV5Empresa.GetMessages();
                  /* Execute user subroutine: 'SHOW MESSAGES' */
                  S112 ();
                  if (returnInSub) return;
               }
               if ( ( StringUtil.StrCmp(AV12TrnMode, "DSP") == 0 ) || ( StringUtil.StrCmp(AV12TrnMode, "DLT") == 0 ) )
               {
                  edtavEmpresa_empresarepresentantecpf_Enabled = 0;
                  AssignProp(sPrefix, false, edtavEmpresa_empresarepresentantecpf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresa_empresarepresentantecpf_Enabled), 5, 0), true);
                  edtavEmpresa_empresarepresentantenome_Enabled = 0;
                  AssignProp(sPrefix, false, edtavEmpresa_empresarepresentantenome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresa_empresarepresentantenome_Enabled), 5, 0), true);
                  edtavEmpresa_empresarepresentanteemail_Enabled = 0;
                  AssignProp(sPrefix, false, edtavEmpresa_empresarepresentanteemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresa_empresarepresentanteemail_Enabled), 5, 0), true);
                  edtavEmpresa_empresarepresentantenacionalidade_Enabled = 0;
                  AssignProp(sPrefix, false, edtavEmpresa_empresarepresentantenacionalidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresa_empresarepresentantenacionalidade_Enabled), 5, 0), true);
                  Combo_empresa_empresarepresentanteprofissao_Enabled = false;
                  ucCombo_empresa_empresarepresentanteprofissao.SendProperty(context, sPrefix, false, Combo_empresa_empresarepresentanteprofissao_Internalname, "Enabled", StringUtil.BoolToStr( Combo_empresa_empresarepresentanteprofissao_Enabled));
                  cmbavEmpresa_empresautilizarepresentanteassinatura.Enabled = 0;
                  AssignProp(sPrefix, false, cmbavEmpresa_empresautilizarepresentanteassinatura_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavEmpresa_empresautilizarepresentanteassinatura.Enabled), 5, 0), true);
                  edtavEmpresa_empresarepresentantecep_Enabled = 0;
                  AssignProp(sPrefix, false, edtavEmpresa_empresarepresentantecep_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresa_empresarepresentantecep_Enabled), 5, 0), true);
                  edtavEmpresa_empresarepresentantelogradouro_Enabled = 0;
                  AssignProp(sPrefix, false, edtavEmpresa_empresarepresentantelogradouro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresa_empresarepresentantelogradouro_Enabled), 5, 0), true);
                  edtavEmpresa_empresarepresentantenumero_Enabled = 0;
                  AssignProp(sPrefix, false, edtavEmpresa_empresarepresentantenumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresa_empresarepresentantenumero_Enabled), 5, 0), true);
                  edtavEmpresa_empresarepresentantebairro_Enabled = 0;
                  AssignProp(sPrefix, false, edtavEmpresa_empresarepresentantebairro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresa_empresarepresentantebairro_Enabled), 5, 0), true);
                  edtavEmpresa_empresarepresentantecomplemento_Enabled = 0;
                  AssignProp(sPrefix, false, edtavEmpresa_empresarepresentantecomplemento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresa_empresarepresentantecomplemento_Enabled), 5, 0), true);
                  edtavEmpresa_empresarepresentantetelefoneddd_Enabled = 0;
                  AssignProp(sPrefix, false, edtavEmpresa_empresarepresentantetelefoneddd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresa_empresarepresentantetelefoneddd_Enabled), 5, 0), true);
                  edtavEmpresa_empresarepresentantetelefone_Enabled = 0;
                  AssignProp(sPrefix, false, edtavEmpresa_empresarepresentantetelefone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresa_empresarepresentantetelefone_Enabled), 5, 0), true);
                  edtavEmpresa_empresacep_Enabled = 0;
                  AssignProp(sPrefix, false, edtavEmpresa_empresacep_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresa_empresacep_Enabled), 5, 0), true);
                  edtavEmpresa_empresalogradouro_Enabled = 0;
                  AssignProp(sPrefix, false, edtavEmpresa_empresalogradouro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresa_empresalogradouro_Enabled), 5, 0), true);
                  edtavEmpresa_empresalogradouronumero_Enabled = 0;
                  AssignProp(sPrefix, false, edtavEmpresa_empresalogradouronumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresa_empresalogradouronumero_Enabled), 5, 0), true);
                  edtavEmpresa_empresabairro_Enabled = 0;
                  AssignProp(sPrefix, false, edtavEmpresa_empresabairro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresa_empresabairro_Enabled), 5, 0), true);
                  edtavEmpresa_empresacomplemento_Enabled = 0;
                  AssignProp(sPrefix, false, edtavEmpresa_empresacomplemento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresa_empresacomplemento_Enabled), 5, 0), true);
                  edtavEmpresa_empresanomefantasia_Enabled = 0;
                  AssignProp(sPrefix, false, edtavEmpresa_empresanomefantasia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresa_empresanomefantasia_Enabled), 5, 0), true);
                  edtavEmpresa_empresarazaosocial_Enabled = 0;
                  AssignProp(sPrefix, false, edtavEmpresa_empresarazaosocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresa_empresarazaosocial_Enabled), 5, 0), true);
                  edtavEmpresa_empresacnpj_Enabled = 0;
                  AssignProp(sPrefix, false, edtavEmpresa_empresacnpj_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresa_empresacnpj_Enabled), 5, 0), true);
                  Combo_empresa_empresabancoid_Enabled = false;
                  ucCombo_empresa_empresabancoid.SendProperty(context, sPrefix, false, Combo_empresa_empresabancoid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_empresa_empresabancoid_Enabled));
                  edtavEmpresa_empresaagencia_Enabled = 0;
                  AssignProp(sPrefix, false, edtavEmpresa_empresaagencia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresa_empresaagencia_Enabled), 5, 0), true);
                  edtavEmpresa_empresaagenciadigito_Enabled = 0;
                  AssignProp(sPrefix, false, edtavEmpresa_empresaagenciadigito_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresa_empresaagenciadigito_Enabled), 5, 0), true);
                  edtavEmpresa_empresaconta_Enabled = 0;
                  AssignProp(sPrefix, false, edtavEmpresa_empresaconta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresa_empresaconta_Enabled), 5, 0), true);
                  cmbavEmpresa_empresapixtipo.Enabled = 0;
                  AssignProp(sPrefix, false, cmbavEmpresa_empresapixtipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavEmpresa_empresapixtipo.Enabled), 5, 0), true);
                  edtavEmpresa_empresapix_Enabled = 0;
                  AssignProp(sPrefix, false, edtavEmpresa_empresapix_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresa_empresapix_Enabled), 5, 0), true);
                  edtavEmpresa_empresaemail_Enabled = 0;
                  AssignProp(sPrefix, false, edtavEmpresa_empresaemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresa_empresaemail_Enabled), 5, 0), true);
               }
            }
         }
         else
         {
            AV13LoadSuccess = false;
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         if ( AV13LoadSuccess )
         {
            if ( StringUtil.StrCmp(AV12TrnMode, "DLT") == 0 )
            {
               GX_msglist.addItem("Confirme a eliminação dos dados.");
            }
         }
         GXt_char1 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and subtitle", out  GXt_char1) ;
         Combo_empresa_empresabancoid_Htmltemplate = GXt_char1;
         ucCombo_empresa_empresabancoid.SendProperty(context, sPrefix, false, Combo_empresa_empresabancoid_Internalname, "HTMLTemplate", Combo_empresa_empresabancoid_Htmltemplate);
         /* Execute user subroutine: 'LOADCOMBOEMPRESA_EMPRESABANCOID' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOEMPRESA_EMPRESAREPRESENTANTEPROFISSAO' */
         S132 ();
         if (returnInSub) return;
         edtavEmpresa_empresarepresentantemunicipio_Visible = 0;
         AssignProp(sPrefix, false, edtavEmpresa_empresarepresentantemunicipio_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavEmpresa_empresarepresentantemunicipio_Visible), 5, 0), true);
         edtavEmpresa_municipiocodigo_Visible = 0;
         AssignProp(sPrefix, false, edtavEmpresa_municipiocodigo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavEmpresa_municipiocodigo_Visible), 5, 0), true);
         edtavEmpresa_empresaid_Visible = 0;
         AssignProp(sPrefix, false, edtavEmpresa_empresaid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavEmpresa_empresaid_Visible), 5, 0), true);
         cmbavEmpresa_empresasede.Visible = 0;
         AssignProp(sPrefix, false, cmbavEmpresa_empresasede_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavEmpresa_empresasede.Visible), 5, 0), true);
         AV19MunicipioNome = AV5Empresa.gxTpr_Municipionome;
         AssignAttri(sPrefix, false, "AV19MunicipioNome", AV19MunicipioNome);
         AV20MunicipioUF = AV5Empresa.gxTpr_Municipiouf;
         AssignAttri(sPrefix, false, "AV20MunicipioUF", AV20MunicipioUF);
         AV27RepresentanteMunicipioNome = AV5Empresa.gxTpr_Empresarepresentantemunicipionome;
         AssignAttri(sPrefix, false, "AV27RepresentanteMunicipioNome", AV27RepresentanteMunicipioNome);
         AV28RepresentanteMunicipioUF = AV5Empresa.gxTpr_Empresarepresentantemunicipiouf;
         AssignAttri(sPrefix, false, "AV28RepresentanteMunicipioUF", AV28RepresentanteMunicipioUF);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV5Empresa.gxTpr_Municipiocodigo)) )
         {
            edtavEmpresa_empresalogradouro_Enabled = 0;
            AssignProp(sPrefix, false, edtavEmpresa_empresalogradouro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresa_empresalogradouro_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV5Empresa.gxTpr_Empresarepresentantecep)) )
         {
            edtavEmpresa_empresarepresentantelogradouro_Enabled = 0;
            AssignProp(sPrefix, false, edtavEmpresa_empresarepresentantelogradouro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresa_empresarepresentantelogradouro_Enabled), 5, 0), true);
         }
      }

      protected void E13822( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E14822 ();
         if (returnInSub) return;
      }

      protected void E14822( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV12TrnMode, "DSP") != 0 )
         {
            if ( StringUtil.StrCmp(AV12TrnMode, "DLT") != 0 )
            {
               /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
               S152 ();
               if (returnInSub) return;
            }
            if ( ( StringUtil.StrCmp(AV12TrnMode, "DLT") == 0 ) || AV14CheckRequiredFieldsResult )
            {
               if ( StringUtil.StrCmp(AV12TrnMode, "DLT") == 0 )
               {
                  AV5Empresa.Delete();
               }
               else
               {
                  AV5Empresa.Save();
               }
               if ( AV5Empresa.Success() )
               {
                  /* Execute user subroutine: 'AFTER_TRN' */
                  S162 ();
                  if (returnInSub) return;
               }
               else
               {
                  AV11Messages = AV5Empresa.GetMessages();
                  /* Execute user subroutine: 'SHOW MESSAGES' */
                  S112 ();
                  if (returnInSub) return;
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV5Empresa", AV5Empresa);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11Messages", AV11Messages);
      }

      protected void E11822( )
      {
         /* Combo_empresa_empresarepresentanteprofissao_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Combo_empresa_empresarepresentanteprofissao_Selectedvalue_get, "<#NEW#>") == 0 )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "profissao"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
            context.PopUp(formatLink("profissao") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         }
         else if ( StringUtil.StrCmp(Combo_empresa_empresarepresentanteprofissao_Selectedvalue_get, "<#POPUP_CLOSED#>") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOEMPRESA_EMPRESAREPRESENTANTEPROFISSAO' */
            S132 ();
            if (returnInSub) return;
            AV29ComboSelectedValue = AV30Session.Get("PROFISSAOID");
            AV30Session.Remove("PROFISSAOID");
            Combo_empresa_empresarepresentanteprofissao_Selectedvalue_set = AV29ComboSelectedValue;
            ucCombo_empresa_empresarepresentanteprofissao.SendProperty(context, sPrefix, false, Combo_empresa_empresarepresentanteprofissao_Internalname, "SelectedValue_set", Combo_empresa_empresarepresentanteprofissao_Selectedvalue_set);
            AV5Empresa.gxTpr_Empresarepresentanteprofissao = (int)(Math.Round(NumberUtil.Val( AV29ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         }
         else
         {
            AV5Empresa.gxTpr_Empresarepresentanteprofissao = (int)(Math.Round(NumberUtil.Val( Combo_empresa_empresarepresentanteprofissao_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            /* Execute user subroutine: 'LOADCOMBOEMPRESA_EMPRESAREPRESENTANTEPROFISSAO' */
            S132 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV5Empresa", AV5Empresa);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV17Empresa_EmpresaRepresentanteProfissao_Data", AV17Empresa_EmpresaRepresentanteProfissao_Data);
      }

      protected void S142( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ( StringUtil.StrCmp(AV12TrnMode, "DSP") != 0 ) ) )
         {
            bttBtnenter_Visible = 0;
            AssignProp(sPrefix, false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'LOADCOMBOEMPRESA_EMPRESAREPRESENTANTEPROFISSAO' Routine */
         returnInSub = false;
         AV17Empresa_EmpresaRepresentanteProfissao_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         /* Using cursor H00822 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A440ProfissaoId = H00822_A440ProfissaoId[0];
            A441ProfissaoNome = H00822_A441ProfissaoNome[0];
            n441ProfissaoNome = H00822_n441ProfissaoNome[0];
            AV8Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV8Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A440ProfissaoId), 9, 0));
            AV8Combo_DataItem.gxTpr_Title = A441ProfissaoNome;
            AV17Empresa_EmpresaRepresentanteProfissao_Data.Add(AV8Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         Combo_empresa_empresarepresentanteprofissao_Selectedvalue_set = ((0==AV5Empresa.gxTpr_Empresarepresentanteprofissao) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV5Empresa.gxTpr_Empresarepresentanteprofissao), 9, 0)));
         ucCombo_empresa_empresarepresentanteprofissao.SendProperty(context, sPrefix, false, Combo_empresa_empresarepresentanteprofissao_Internalname, "SelectedValue_set", Combo_empresa_empresarepresentanteprofissao_Selectedvalue_set);
      }

      protected void S122( )
      {
         /* 'LOADCOMBOEMPRESA_EMPRESABANCOID' Routine */
         returnInSub = false;
         /* Using cursor H00823 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A402BancoId = H00823_A402BancoId[0];
            A404BancoCodigo = H00823_A404BancoCodigo[0];
            n404BancoCodigo = H00823_n404BancoCodigo[0];
            A403BancoNome = H00823_A403BancoNome[0];
            n403BancoNome = H00823_n403BancoNome[0];
            AV8Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV8Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A402BancoId), 9, 0));
            AV6ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV6ComboTitles.Add(A403BancoNome, 0);
            AV6ComboTitles.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(A404BancoCodigo), "ZZZZZZZZ9")), 0);
            AV8Combo_DataItem.gxTpr_Title = AV6ComboTitles.ToJSonString(false);
            AV7Empresa_EmpresaBancoId_Data.Add(AV8Combo_DataItem, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         Combo_empresa_empresabancoid_Selectedvalue_set = ((0==AV5Empresa.gxTpr_Empresabancoid) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV5Empresa.gxTpr_Empresabancoid), 9, 0)));
         ucCombo_empresa_empresabancoid.SendProperty(context, sPrefix, false, Combo_empresa_empresabancoid_Internalname, "SelectedValue_set", Combo_empresa_empresabancoid_Selectedvalue_set);
      }

      protected void S112( )
      {
         /* 'SHOW MESSAGES' Routine */
         returnInSub = false;
         AV64GXV31 = 1;
         while ( AV64GXV31 <= AV11Messages.Count )
         {
            AV10Message = ((GeneXus.Utils.SdtMessages_Message)AV11Messages.Item(AV64GXV31));
            GX_msglist.addItem(AV10Message.gxTpr_Description);
            AV64GXV31 = (int)(AV64GXV31+1);
         }
      }

      protected void S162( )
      {
         /* 'AFTER_TRN' Routine */
         returnInSub = false;
         context.CommitDataStores("wpempresa",pr_default);
         GXt_char1 = "Dados gravados com sucesso!";
         new message(context ).gxep_sucesso( ref  GXt_char1) ;
      }

      protected void S152( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV14CheckRequiredFieldsResult = true;
         AssignAttri(sPrefix, false, "AV14CheckRequiredFieldsResult", AV14CheckRequiredFieldsResult);
      }

      protected void E15822( )
      {
         /* Empresa_empresacep_Controlvaluechanged Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV5Empresa.gxTpr_Empresacep)) )
         {
            AV19MunicipioNome = "";
            AssignAttri(sPrefix, false, "AV19MunicipioNome", AV19MunicipioNome);
            AV20MunicipioUF = "";
            AssignAttri(sPrefix, false, "AV20MunicipioUF", AV20MunicipioUF);
            AV21CEP = StringUtil.StringReplace( AV5Empresa.gxTpr_Empresacep, "-", "");
            AV21CEP = StringUtil.StringReplace( AV21CEP, ".", "");
            AV22EnderecoCompleto = new GeneXus.Programs.myobjects.viacep.SdtEnderecoCompleto(context);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21CEP)) )
            {
               new GeneXus.Programs.myobjects.viacep.cepparaendereco(context ).execute(  AV21CEP, out  AV23ModeloRetorno, out  AV24Mensagem) ;
               AV22EnderecoCompleto.FromJSonString(AV23ModeloRetorno, null);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22EnderecoCompleto.gxTpr_Cep)) )
            {
               GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "",  "error",  edtavEmpresa_empresacep_Internalname,  "true",  ""));
               AV5Empresa.gxTpr_Empresalogradouro = AV22EnderecoCompleto.gxTpr_Logradouro;
               AV5Empresa.gxTpr_Municipiocodigo = AV22EnderecoCompleto.gxTpr_Ibge;
               AV5Empresa.gxTpr_Empresabairro = AV22EnderecoCompleto.gxTpr_Bairro;
               AV19MunicipioNome = AV22EnderecoCompleto.gxTpr_Localidade;
               AssignAttri(sPrefix, false, "AV19MunicipioNome", AV19MunicipioNome);
               AV20MunicipioUF = AV22EnderecoCompleto.gxTpr_Uf;
               AssignAttri(sPrefix, false, "AV20MunicipioUF", AV20MunicipioUF);
               AV26Municipio.Load(AV5Empresa.gxTpr_Municipiocodigo);
               if ( AV26Municipio.Fail() )
               {
                  AV26Municipio.gxTpr_Municipionome = AV22EnderecoCompleto.gxTpr_Localidade;
                  AV26Municipio.gxTpr_Municipiouf = AV22EnderecoCompleto.gxTpr_Uf;
                  AV26Municipio.Save();
                  if ( AV26Municipio.Success() )
                  {
                     context.CommitDataStores("wpempresa",pr_default);
                  }
               }
               edtavEmpresa_empresalogradouro_Enabled = 0;
               AssignProp(sPrefix, false, edtavEmpresa_empresalogradouro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresa_empresalogradouro_Enabled), 5, 0), true);
            }
            else
            {
               GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "CEP não encontrato",  "error",  edtavEmpresa_empresacep_Internalname,  "true",  ""));
               AV5Empresa.gxTpr_Empresalogradouro = "";
               AV5Empresa.gxTpr_Empresabairro = "";
               AV5Empresa.gxTpr_Municipiocodigo = "";
               edtavEmpresa_empresalogradouro_Enabled = 1;
               AssignProp(sPrefix, false, edtavEmpresa_empresalogradouro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresa_empresalogradouro_Enabled), 5, 0), true);
            }
         }
         else
         {
            AV5Empresa.gxTpr_Empresalogradouro = "";
            AV5Empresa.gxTpr_Empresabairro = "";
            AV5Empresa.gxTpr_Municipiocodigo = "";
            edtavEmpresa_empresalogradouro_Enabled = 1;
            AssignProp(sPrefix, false, edtavEmpresa_empresalogradouro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresa_empresalogradouro_Enabled), 5, 0), true);
            AV19MunicipioNome = "";
            AssignAttri(sPrefix, false, "AV19MunicipioNome", AV19MunicipioNome);
            AV20MunicipioUF = "";
            AssignAttri(sPrefix, false, "AV20MunicipioUF", AV20MunicipioUF);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV5Empresa", AV5Empresa);
      }

      protected void E16822( )
      {
         /* Empresa_empresarepresentantecep_Controlvaluechanged Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV5Empresa.gxTpr_Empresarepresentantecep)) )
         {
            AV27RepresentanteMunicipioNome = "";
            AssignAttri(sPrefix, false, "AV27RepresentanteMunicipioNome", AV27RepresentanteMunicipioNome);
            AV28RepresentanteMunicipioUF = "";
            AssignAttri(sPrefix, false, "AV28RepresentanteMunicipioUF", AV28RepresentanteMunicipioUF);
            AV21CEP = StringUtil.StringReplace( AV5Empresa.gxTpr_Empresarepresentantecep, "-", "");
            AV21CEP = StringUtil.StringReplace( AV21CEP, ".", "");
            AV22EnderecoCompleto = new GeneXus.Programs.myobjects.viacep.SdtEnderecoCompleto(context);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21CEP)) )
            {
               new GeneXus.Programs.myobjects.viacep.cepparaendereco(context ).execute(  AV21CEP, out  AV23ModeloRetorno, out  AV24Mensagem) ;
               AV22EnderecoCompleto.FromJSonString(AV23ModeloRetorno, null);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22EnderecoCompleto.gxTpr_Cep)) )
            {
               GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "",  "error",  edtavEmpresa_empresarepresentantecep_Internalname,  "true",  ""));
               AV5Empresa.gxTpr_Empresarepresentantelogradouro = AV22EnderecoCompleto.gxTpr_Logradouro;
               AV5Empresa.gxTpr_Empresarepresentantemunicipio = AV22EnderecoCompleto.gxTpr_Ibge;
               AV5Empresa.gxTpr_Empresarepresentantebairro = AV22EnderecoCompleto.gxTpr_Bairro;
               AV27RepresentanteMunicipioNome = AV22EnderecoCompleto.gxTpr_Localidade;
               AssignAttri(sPrefix, false, "AV27RepresentanteMunicipioNome", AV27RepresentanteMunicipioNome);
               AV28RepresentanteMunicipioUF = AV22EnderecoCompleto.gxTpr_Uf;
               AssignAttri(sPrefix, false, "AV28RepresentanteMunicipioUF", AV28RepresentanteMunicipioUF);
               AV26Municipio.Load(AV5Empresa.gxTpr_Empresarepresentantemunicipio);
               if ( AV26Municipio.Fail() )
               {
                  AV26Municipio.gxTpr_Municipionome = AV22EnderecoCompleto.gxTpr_Localidade;
                  AV26Municipio.gxTpr_Municipiouf = AV22EnderecoCompleto.gxTpr_Uf;
                  AV26Municipio.Save();
                  if ( AV26Municipio.Success() )
                  {
                     context.CommitDataStores("wpempresa",pr_default);
                  }
               }
               edtavEmpresa_empresarepresentantelogradouro_Enabled = 0;
               AssignProp(sPrefix, false, edtavEmpresa_empresarepresentantelogradouro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresa_empresarepresentantelogradouro_Enabled), 5, 0), true);
            }
            else
            {
               GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "CEP não encontrato",  "error",  edtavEmpresa_empresacep_Internalname,  "true",  ""));
               AV5Empresa.gxTpr_Empresalogradouro = "";
               AV5Empresa.gxTpr_Empresabairro = "";
               AV5Empresa.gxTpr_Municipiocodigo = "";
               edtavEmpresa_empresarepresentantelogradouro_Enabled = 1;
               AssignProp(sPrefix, false, edtavEmpresa_empresarepresentantelogradouro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresa_empresarepresentantelogradouro_Enabled), 5, 0), true);
            }
         }
         else
         {
            AV5Empresa.gxTpr_Empresarepresentantelogradouro = "";
            AV5Empresa.gxTpr_Empresarepresentantebairro = "";
            AV5Empresa.gxTpr_Empresarepresentantemunicipio = "";
            edtavEmpresa_empresarepresentantelogradouro_Enabled = 1;
            AssignProp(sPrefix, false, edtavEmpresa_empresarepresentantelogradouro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresa_empresarepresentantelogradouro_Enabled), 5, 0), true);
            AV27RepresentanteMunicipioNome = "";
            AssignAttri(sPrefix, false, "AV27RepresentanteMunicipioNome", AV27RepresentanteMunicipioNome);
            AV28RepresentanteMunicipioUF = "";
            AssignAttri(sPrefix, false, "AV28RepresentanteMunicipioUF", AV28RepresentanteMunicipioUF);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV5Empresa", AV5Empresa);
      }

      protected void nextLoad( )
      {
      }

      protected void E17822( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table2_180_822( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedrepresentantemunicipionome_Internalname, tblTablemergedrepresentantemunicipionome_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRepresentantemunicipionome_Internalname, "Representante Municipio Nome", "gx-form-item AttributeFLLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 184,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRepresentantemunicipionome_Internalname, AV27RepresentanteMunicipioNome, StringUtil.RTrim( context.localUtil.Format( AV27RepresentanteMunicipioNome, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,184);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRepresentantemunicipionome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavRepresentantemunicipionome_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCellFL'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+edtavRepresentantemunicipiouf_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRepresentantemunicipiouf_Internalname, "UF", "gx-form-item AttributeFLLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 188,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRepresentantemunicipiouf_Internalname, AV28RepresentanteMunicipioUF, StringUtil.RTrim( context.localUtil.Format( AV28RepresentanteMunicipioUF, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,188);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRepresentantemunicipiouf_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavRepresentantemunicipiouf_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_180_822e( true) ;
         }
         else
         {
            wb_table2_180_822e( false) ;
         }
      }

      protected void wb_table1_103_822( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedmunicipionome_Internalname, tblTablemergedmunicipionome_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMunicipionome_Internalname, "Municipio Nome", "gx-form-item AttributeFLLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMunicipionome_Internalname, AV19MunicipioNome, StringUtil.RTrim( context.localUtil.Format( AV19MunicipioNome, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,107);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMunicipionome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavMunicipionome_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCellFL'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+edtavMunicipiouf_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMunicipiouf_Internalname, "UF", "gx-form-item AttributeFLLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMunicipiouf_Internalname, AV20MunicipioUF, StringUtil.RTrim( context.localUtil.Format( AV20MunicipioUF, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,111);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMunicipiouf_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavMunicipiouf_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_103_822e( true) ;
         }
         else
         {
            wb_table1_103_822e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV12TrnMode = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV12TrnMode", AV12TrnMode);
         AV16EmpresaId = Convert.ToInt32(getParm(obj,1));
         AssignAttri(sPrefix, false, "AV16EmpresaId", StringUtil.LTrimStr( (decimal)(AV16EmpresaId), 9, 0));
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
         PA822( ) ;
         WS822( ) ;
         WE822( ) ;
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
         sCtrlAV12TrnMode = (string)((string)getParm(obj,0));
         sCtrlAV16EmpresaId = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA822( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wpempresa", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA822( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV12TrnMode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV12TrnMode", AV12TrnMode);
            AV16EmpresaId = Convert.ToInt32(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV16EmpresaId", StringUtil.LTrimStr( (decimal)(AV16EmpresaId), 9, 0));
         }
         wcpOAV12TrnMode = cgiGet( sPrefix+"wcpOAV12TrnMode");
         wcpOAV16EmpresaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV16EmpresaId"), ",", "."), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV12TrnMode, wcpOAV12TrnMode) != 0 ) || ( AV16EmpresaId != wcpOAV16EmpresaId ) ) )
         {
            setjustcreated();
         }
         wcpOAV12TrnMode = AV12TrnMode;
         wcpOAV16EmpresaId = AV16EmpresaId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV12TrnMode = cgiGet( sPrefix+"AV12TrnMode_CTRL");
         if ( StringUtil.Len( sCtrlAV12TrnMode) > 0 )
         {
            AV12TrnMode = cgiGet( sCtrlAV12TrnMode);
            AssignAttri(sPrefix, false, "AV12TrnMode", AV12TrnMode);
         }
         else
         {
            AV12TrnMode = cgiGet( sPrefix+"AV12TrnMode_PARM");
         }
         sCtrlAV16EmpresaId = cgiGet( sPrefix+"AV16EmpresaId_CTRL");
         if ( StringUtil.Len( sCtrlAV16EmpresaId) > 0 )
         {
            AV16EmpresaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV16EmpresaId), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV16EmpresaId", StringUtil.LTrimStr( (decimal)(AV16EmpresaId), 9, 0));
         }
         else
         {
            AV16EmpresaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV16EmpresaId_PARM"), ",", "."), 18, MidpointRounding.ToEven));
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
         PA822( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS822( ) ;
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
         WS822( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV12TrnMode_PARM", StringUtil.RTrim( AV12TrnMode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV12TrnMode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV12TrnMode_CTRL", StringUtil.RTrim( sCtrlAV12TrnMode));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV16EmpresaId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16EmpresaId), 9, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV16EmpresaId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV16EmpresaId_CTRL", StringUtil.RTrim( sCtrlAV16EmpresaId));
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
         WE822( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019174221", true, true);
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
         context.AddJavascriptSource("wpempresa.js", "?202561019174222", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
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
         cmbavEmpresa_empresapixtipo.Name = "EMPRESA_EMPRESAPIXTIPO";
         cmbavEmpresa_empresapixtipo.WebTags = "";
         cmbavEmpresa_empresapixtipo.addItem("CPF", "CPF", 0);
         cmbavEmpresa_empresapixtipo.addItem("CNPJ", "CNPJ", 0);
         cmbavEmpresa_empresapixtipo.addItem("Telefone", "Telefone", 0);
         cmbavEmpresa_empresapixtipo.addItem("Email", "E-mail", 0);
         cmbavEmpresa_empresapixtipo.addItem("ChaveAleatoria", "Chave aleatória", 0);
         if ( cmbavEmpresa_empresapixtipo.ItemCount > 0 )
         {
         }
         cmbavEmpresa_empresautilizarepresentanteassinatura.Name = "EMPRESA_EMPRESAUTILIZAREPRESENTANTEASSINATURA";
         cmbavEmpresa_empresautilizarepresentanteassinatura.WebTags = "";
         cmbavEmpresa_empresautilizarepresentanteassinatura.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbavEmpresa_empresautilizarepresentanteassinatura.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbavEmpresa_empresautilizarepresentanteassinatura.ItemCount > 0 )
         {
         }
         cmbavEmpresa_empresasede.Name = "EMPRESA_EMPRESASEDE";
         cmbavEmpresa_empresasede.WebTags = "";
         cmbavEmpresa_empresasede.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbavEmpresa_empresasede.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbavEmpresa_empresasede.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtnenter_Internalname = sPrefix+"BTNENTER";
         lblInfo_title_Internalname = sPrefix+"INFO_TITLE";
         edtavEmpresa_empresanomefantasia_Internalname = sPrefix+"EMPRESA_EMPRESANOMEFANTASIA";
         edtavEmpresa_empresarazaosocial_Internalname = sPrefix+"EMPRESA_EMPRESARAZAOSOCIAL";
         edtavEmpresa_empresacnpj_Internalname = sPrefix+"EMPRESA_EMPRESACNPJ";
         lblTextblockcombo_empresa_empresabancoid_Internalname = sPrefix+"TEXTBLOCKCOMBO_EMPRESA_EMPRESABANCOID";
         Combo_empresa_empresabancoid_Internalname = sPrefix+"COMBO_EMPRESA_EMPRESABANCOID";
         divTablesplittedempresa_empresabancoid_Internalname = sPrefix+"TABLESPLITTEDEMPRESA_EMPRESABANCOID";
         edtavEmpresa_empresaagencia_Internalname = sPrefix+"EMPRESA_EMPRESAAGENCIA";
         edtavEmpresa_empresaagenciadigito_Internalname = sPrefix+"EMPRESA_EMPRESAAGENCIADIGITO";
         edtavEmpresa_empresaconta_Internalname = sPrefix+"EMPRESA_EMPRESACONTA";
         cmbavEmpresa_empresapixtipo_Internalname = sPrefix+"EMPRESA_EMPRESAPIXTIPO";
         edtavEmpresa_empresapix_Internalname = sPrefix+"EMPRESA_EMPRESAPIX";
         edtavEmpresa_empresaemail_Internalname = sPrefix+"EMPRESA_EMPRESAEMAIL";
         divUnnamedtable3_Internalname = sPrefix+"UNNAMEDTABLE3";
         lblEndereco_title_Internalname = sPrefix+"ENDERECO_TITLE";
         edtavEmpresa_empresacep_Internalname = sPrefix+"EMPRESA_EMPRESACEP";
         edtavEmpresa_empresalogradouro_Internalname = sPrefix+"EMPRESA_EMPRESALOGRADOURO";
         edtavEmpresa_empresalogradouronumero_Internalname = sPrefix+"EMPRESA_EMPRESALOGRADOURONUMERO";
         edtavEmpresa_empresabairro_Internalname = sPrefix+"EMPRESA_EMPRESABAIRRO";
         lblTextblockmunicipionome_Internalname = sPrefix+"TEXTBLOCKMUNICIPIONOME";
         edtavMunicipionome_Internalname = sPrefix+"vMUNICIPIONOME";
         edtavMunicipiouf_Internalname = sPrefix+"vMUNICIPIOUF";
         tblTablemergedmunicipionome_Internalname = sPrefix+"TABLEMERGEDMUNICIPIONOME";
         divTablesplittedmunicipionome_Internalname = sPrefix+"TABLESPLITTEDMUNICIPIONOME";
         edtavEmpresa_empresacomplemento_Internalname = sPrefix+"EMPRESA_EMPRESACOMPLEMENTO";
         divUnnamedtable2_Internalname = sPrefix+"UNNAMEDTABLE2";
         lblRepresentante_title_Internalname = sPrefix+"REPRESENTANTE_TITLE";
         edtavEmpresa_empresarepresentantecpf_Internalname = sPrefix+"EMPRESA_EMPRESAREPRESENTANTECPF";
         edtavEmpresa_empresarepresentantenome_Internalname = sPrefix+"EMPRESA_EMPRESAREPRESENTANTENOME";
         edtavEmpresa_empresarepresentanteemail_Internalname = sPrefix+"EMPRESA_EMPRESAREPRESENTANTEEMAIL";
         edtavEmpresa_empresarepresentantenacionalidade_Internalname = sPrefix+"EMPRESA_EMPRESAREPRESENTANTENACIONALIDADE";
         lblTextblockcombo_empresa_empresarepresentanteprofissao_Internalname = sPrefix+"TEXTBLOCKCOMBO_EMPRESA_EMPRESAREPRESENTANTEPROFISSAO";
         Combo_empresa_empresarepresentanteprofissao_Internalname = sPrefix+"COMBO_EMPRESA_EMPRESAREPRESENTANTEPROFISSAO";
         divTablesplittedempresa_empresarepresentanteprofissao_Internalname = sPrefix+"TABLESPLITTEDEMPRESA_EMPRESAREPRESENTANTEPROFISSAO";
         cmbavEmpresa_empresautilizarepresentanteassinatura_Internalname = sPrefix+"EMPRESA_EMPRESAUTILIZAREPRESENTANTEASSINATURA";
         edtavEmpresa_empresarepresentantecep_Internalname = sPrefix+"EMPRESA_EMPRESAREPRESENTANTECEP";
         edtavEmpresa_empresarepresentantelogradouro_Internalname = sPrefix+"EMPRESA_EMPRESAREPRESENTANTELOGRADOURO";
         edtavEmpresa_empresarepresentantenumero_Internalname = sPrefix+"EMPRESA_EMPRESAREPRESENTANTENUMERO";
         edtavEmpresa_empresarepresentantebairro_Internalname = sPrefix+"EMPRESA_EMPRESAREPRESENTANTEBAIRRO";
         edtavEmpresa_empresarepresentantecomplemento_Internalname = sPrefix+"EMPRESA_EMPRESAREPRESENTANTECOMPLEMENTO";
         lblTextblockrepresentantemunicipionome_Internalname = sPrefix+"TEXTBLOCKREPRESENTANTEMUNICIPIONOME";
         edtavRepresentantemunicipionome_Internalname = sPrefix+"vREPRESENTANTEMUNICIPIONOME";
         edtavRepresentantemunicipiouf_Internalname = sPrefix+"vREPRESENTANTEMUNICIPIOUF";
         tblTablemergedrepresentantemunicipionome_Internalname = sPrefix+"TABLEMERGEDREPRESENTANTEMUNICIPIONOME";
         divTablesplittedrepresentantemunicipionome_Internalname = sPrefix+"TABLESPLITTEDREPRESENTANTEMUNICIPIONOME";
         edtavEmpresa_empresarepresentantetelefoneddd_Internalname = sPrefix+"EMPRESA_EMPRESAREPRESENTANTETELEFONEDDD";
         edtavEmpresa_empresarepresentantetelefone_Internalname = sPrefix+"EMPRESA_EMPRESAREPRESENTANTETELEFONE";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         Gxuitabspanel_tabs1_Internalname = sPrefix+"GXUITABSPANEL_TABS1";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavEmpresa_empresarepresentantemunicipio_Internalname = sPrefix+"EMPRESA_EMPRESAREPRESENTANTEMUNICIPIO";
         edtavEmpresa_municipiocodigo_Internalname = sPrefix+"EMPRESA_MUNICIPIOCODIGO";
         edtavEmpresa_empresaid_Internalname = sPrefix+"EMPRESA_EMPRESAID";
         cmbavEmpresa_empresasede_Internalname = sPrefix+"EMPRESA_EMPRESASEDE";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
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
         edtavMunicipiouf_Jsonclick = "";
         edtavMunicipiouf_Enabled = 1;
         edtavMunicipionome_Jsonclick = "";
         edtavMunicipionome_Enabled = 1;
         edtavRepresentantemunicipiouf_Jsonclick = "";
         edtavRepresentantemunicipiouf_Enabled = 1;
         edtavRepresentantemunicipionome_Jsonclick = "";
         edtavRepresentantemunicipionome_Enabled = 1;
         edtavEmpresa_empresaemail_Enabled = 1;
         edtavEmpresa_empresapix_Enabled = 1;
         cmbavEmpresa_empresapixtipo.Enabled = 1;
         edtavEmpresa_empresaconta_Enabled = 1;
         edtavEmpresa_empresaagenciadigito_Enabled = 1;
         edtavEmpresa_empresaagencia_Enabled = 1;
         edtavEmpresa_empresacnpj_Enabled = 1;
         edtavEmpresa_empresarazaosocial_Enabled = 1;
         edtavEmpresa_empresanomefantasia_Enabled = 1;
         edtavEmpresa_empresacomplemento_Enabled = 1;
         edtavEmpresa_empresabairro_Enabled = 1;
         edtavEmpresa_empresalogradouronumero_Enabled = 1;
         edtavEmpresa_empresalogradouro_Enabled = 1;
         edtavEmpresa_empresacep_Enabled = 1;
         edtavEmpresa_empresarepresentantetelefone_Enabled = 1;
         edtavEmpresa_empresarepresentantetelefoneddd_Enabled = 1;
         edtavEmpresa_empresarepresentantecomplemento_Enabled = 1;
         edtavEmpresa_empresarepresentantebairro_Enabled = 1;
         edtavEmpresa_empresarepresentantenumero_Enabled = 1;
         edtavEmpresa_empresarepresentantelogradouro_Enabled = 1;
         edtavEmpresa_empresarepresentantecep_Enabled = 1;
         cmbavEmpresa_empresautilizarepresentanteassinatura.Enabled = 1;
         edtavEmpresa_empresarepresentantenacionalidade_Enabled = 1;
         edtavEmpresa_empresarepresentanteemail_Enabled = 1;
         edtavEmpresa_empresarepresentantenome_Enabled = 1;
         edtavEmpresa_empresarepresentantecpf_Enabled = 1;
         cmbavEmpresa_empresasede_Jsonclick = "";
         cmbavEmpresa_empresasede.Visible = 1;
         edtavEmpresa_empresaid_Jsonclick = "";
         edtavEmpresa_empresaid_Visible = 1;
         edtavEmpresa_municipiocodigo_Jsonclick = "";
         edtavEmpresa_municipiocodigo_Visible = 1;
         edtavEmpresa_empresarepresentantemunicipio_Jsonclick = "";
         edtavEmpresa_empresarepresentantemunicipio_Visible = 1;
         edtavEmpresa_empresarepresentantetelefone_Jsonclick = "";
         edtavEmpresa_empresarepresentantetelefone_Enabled = 1;
         edtavEmpresa_empresarepresentantetelefoneddd_Jsonclick = "";
         edtavEmpresa_empresarepresentantetelefoneddd_Enabled = 1;
         edtavEmpresa_empresarepresentantecomplemento_Jsonclick = "";
         edtavEmpresa_empresarepresentantecomplemento_Enabled = 1;
         edtavEmpresa_empresarepresentantebairro_Jsonclick = "";
         edtavEmpresa_empresarepresentantebairro_Enabled = 1;
         edtavEmpresa_empresarepresentantenumero_Jsonclick = "";
         edtavEmpresa_empresarepresentantenumero_Enabled = 1;
         edtavEmpresa_empresarepresentantelogradouro_Jsonclick = "";
         edtavEmpresa_empresarepresentantelogradouro_Enabled = 1;
         edtavEmpresa_empresarepresentantecep_Jsonclick = "";
         edtavEmpresa_empresarepresentantecep_Enabled = 1;
         cmbavEmpresa_empresautilizarepresentanteassinatura_Jsonclick = "";
         cmbavEmpresa_empresautilizarepresentanteassinatura.Enabled = 1;
         edtavEmpresa_empresarepresentantenacionalidade_Jsonclick = "";
         edtavEmpresa_empresarepresentantenacionalidade_Enabled = 1;
         edtavEmpresa_empresarepresentanteemail_Jsonclick = "";
         edtavEmpresa_empresarepresentanteemail_Enabled = 1;
         edtavEmpresa_empresarepresentantenome_Jsonclick = "";
         edtavEmpresa_empresarepresentantenome_Enabled = 1;
         edtavEmpresa_empresarepresentantecpf_Jsonclick = "";
         edtavEmpresa_empresarepresentantecpf_Enabled = 1;
         edtavEmpresa_empresacomplemento_Jsonclick = "";
         edtavEmpresa_empresacomplemento_Enabled = 1;
         edtavEmpresa_empresabairro_Jsonclick = "";
         edtavEmpresa_empresabairro_Enabled = 1;
         edtavEmpresa_empresalogradouronumero_Jsonclick = "";
         edtavEmpresa_empresalogradouronumero_Enabled = 1;
         edtavEmpresa_empresalogradouro_Jsonclick = "";
         edtavEmpresa_empresalogradouro_Enabled = 1;
         edtavEmpresa_empresacep_Jsonclick = "";
         edtavEmpresa_empresacep_Enabled = 1;
         edtavEmpresa_empresaemail_Jsonclick = "";
         edtavEmpresa_empresaemail_Enabled = 1;
         edtavEmpresa_empresapix_Jsonclick = "";
         edtavEmpresa_empresapix_Enabled = 1;
         cmbavEmpresa_empresapixtipo_Jsonclick = "";
         cmbavEmpresa_empresapixtipo.Enabled = 1;
         edtavEmpresa_empresaconta_Jsonclick = "";
         edtavEmpresa_empresaconta_Enabled = 1;
         edtavEmpresa_empresaagenciadigito_Jsonclick = "";
         edtavEmpresa_empresaagenciadigito_Enabled = 1;
         edtavEmpresa_empresaagencia_Jsonclick = "";
         edtavEmpresa_empresaagencia_Enabled = 1;
         edtavEmpresa_empresacnpj_Jsonclick = "";
         edtavEmpresa_empresacnpj_Enabled = 1;
         edtavEmpresa_empresarazaosocial_Jsonclick = "";
         edtavEmpresa_empresarazaosocial_Enabled = 1;
         edtavEmpresa_empresanomefantasia_Jsonclick = "";
         edtavEmpresa_empresanomefantasia_Enabled = 1;
         bttBtnenter_Visible = 1;
         Gxuitabspanel_tabs1_Historymanagement = Convert.ToBoolean( 0);
         Gxuitabspanel_tabs1_Class = "Tab";
         Gxuitabspanel_tabs1_Pagecount = 3;
         Combo_empresa_empresarepresentanteprofissao_Includeaddnewoption = Convert.ToBoolean( -1);
         Combo_empresa_empresarepresentanteprofissao_Emptyitem = Convert.ToBoolean( 0);
         Combo_empresa_empresarepresentanteprofissao_Enabled = Convert.ToBoolean( -1);
         Combo_empresa_empresarepresentanteprofissao_Cls = "ExtendedCombo AttributeFL";
         Combo_empresa_empresabancoid_Htmltemplate = "";
         Combo_empresa_empresabancoid_Emptyitem = Convert.ToBoolean( 0);
         Combo_empresa_empresabancoid_Enabled = Convert.ToBoolean( -1);
         Combo_empresa_empresabancoid_Cls = "ExtendedCombo AttributeFL ExtendedComboTitleAndSubtitle";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV12TrnMode","fld":"vTRNMODE","type":"char"},{"av":"AV31ProfissaoId","fld":"vPROFISSAOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"ctrl":"BTNENTER","prop":"Visible"}]}""");
         setEventMetadata("ENTER","""{"handler":"E14822","iparms":[{"av":"AV12TrnMode","fld":"vTRNMODE","type":"char"},{"av":"AV14CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"},{"av":"AV5Empresa","fld":"vEMPRESA","type":""},{"av":"AV11Messages","fld":"vMESSAGES","type":""}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV5Empresa","fld":"vEMPRESA","type":""},{"av":"AV11Messages","fld":"vMESSAGES","type":""},{"av":"AV14CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"}]}""");
         setEventMetadata("COMBO_EMPRESA_EMPRESAREPRESENTANTEPROFISSAO.ONOPTIONCLICKED","""{"handler":"E11822","iparms":[{"av":"Combo_empresa_empresarepresentanteprofissao_Selectedvalue_get","ctrl":"COMBO_EMPRESA_EMPRESAREPRESENTANTEPROFISSAO","prop":"SelectedValue_get"},{"av":"AV31ProfissaoId","fld":"vPROFISSAOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV5Empresa","fld":"vEMPRESA","type":""},{"av":"A441ProfissaoNome","fld":"PROFISSAONOME","pic":"@!","type":"svchar"},{"av":"A440ProfissaoId","fld":"PROFISSAOID","pic":"ZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("COMBO_EMPRESA_EMPRESAREPRESENTANTEPROFISSAO.ONOPTIONCLICKED",""","oparms":[{"av":"Combo_empresa_empresarepresentanteprofissao_Selectedvalue_set","ctrl":"COMBO_EMPRESA_EMPRESAREPRESENTANTEPROFISSAO","prop":"SelectedValue_set"},{"av":"AV5Empresa","fld":"vEMPRESA","type":""},{"av":"AV17Empresa_EmpresaRepresentanteProfissao_Data","fld":"vEMPRESA_EMPRESAREPRESENTANTEPROFISSAO_DATA","type":""}]}""");
         setEventMetadata("EMPRESA_EMPRESACEP.CONTROLVALUECHANGED","""{"handler":"E15822","iparms":[{"av":"AV5Empresa","fld":"vEMPRESA","type":""}]""");
         setEventMetadata("EMPRESA_EMPRESACEP.CONTROLVALUECHANGED",""","oparms":[{"av":"AV19MunicipioNome","fld":"vMUNICIPIONOME","pic":"@!","type":"svchar"},{"av":"AV20MunicipioUF","fld":"vMUNICIPIOUF","pic":"@!","type":"svchar"},{"av":"AV5Empresa","fld":"vEMPRESA","type":""},{"ctrl":"EMPRESA_EMPRESALOGRADOURO","prop":"Enabled"}]}""");
         setEventMetadata("EMPRESA_EMPRESAREPRESENTANTECEP.CONTROLVALUECHANGED","""{"handler":"E16822","iparms":[{"av":"AV5Empresa","fld":"vEMPRESA","type":""}]""");
         setEventMetadata("EMPRESA_EMPRESAREPRESENTANTECEP.CONTROLVALUECHANGED",""","oparms":[{"av":"AV27RepresentanteMunicipioNome","fld":"vREPRESENTANTEMUNICIPIONOME","pic":"@!","type":"svchar"},{"av":"AV28RepresentanteMunicipioUF","fld":"vREPRESENTANTEMUNICIPIOUF","pic":"@!","type":"svchar"},{"av":"AV5Empresa","fld":"vEMPRESA","type":""},{"ctrl":"EMPRESA_EMPRESAREPRESENTANTELOGRADOURO","prop":"Enabled"}]}""");
         setEventMetadata("VALIDV_GXV7","""{"handler":"Validv_Gxv7","iparms":[]}""");
         setEventMetadata("VALIDV_GXV9","""{"handler":"Validv_Gxv9","iparms":[]}""");
         setEventMetadata("VALIDV_GXV17","""{"handler":"Validv_Gxv17","iparms":[]}""");
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
         Combo_empresa_empresarepresentanteprofissao_Selectedvalue_get = "";
         Combo_empresa_empresabancoid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV5Empresa = new SdtEmpresa(context);
         AV7Empresa_EmpresaBancoId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV17Empresa_EmpresaRepresentanteProfissao_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV11Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         A441ProfissaoNome = "";
         Combo_empresa_empresabancoid_Selectedvalue_set = "";
         Combo_empresa_empresarepresentanteprofissao_Selectedvalue_set = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtnenter_Jsonclick = "";
         ucGxuitabspanel_tabs1 = new GXUserControl();
         lblInfo_title_Jsonclick = "";
         lblTextblockcombo_empresa_empresabancoid_Jsonclick = "";
         ucCombo_empresa_empresabancoid = new GXUserControl();
         Combo_empresa_empresabancoid_Caption = "";
         lblEndereco_title_Jsonclick = "";
         lblTextblockmunicipionome_Jsonclick = "";
         lblRepresentante_title_Jsonclick = "";
         lblTextblockcombo_empresa_empresarepresentanteprofissao_Jsonclick = "";
         ucCombo_empresa_empresarepresentanteprofissao = new GXUserControl();
         Combo_empresa_empresarepresentanteprofissao_Caption = "";
         lblTextblockrepresentantemunicipionome_Jsonclick = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV19MunicipioNome = "";
         AV20MunicipioUF = "";
         AV27RepresentanteMunicipioNome = "";
         AV28RepresentanteMunicipioUF = "";
         AV29ComboSelectedValue = "";
         AV30Session = context.GetSession();
         H00822_A440ProfissaoId = new int[1] ;
         H00822_A441ProfissaoNome = new string[] {""} ;
         H00822_n441ProfissaoNome = new bool[] {false} ;
         AV8Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         H00823_A402BancoId = new int[1] ;
         H00823_A404BancoCodigo = new int[1] ;
         H00823_n404BancoCodigo = new bool[] {false} ;
         H00823_A403BancoNome = new string[] {""} ;
         H00823_n403BancoNome = new bool[] {false} ;
         A403BancoNome = "";
         AV6ComboTitles = new GxSimpleCollection<string>();
         AV10Message = new GeneXus.Utils.SdtMessages_Message(context);
         GXt_char1 = "";
         AV21CEP = "";
         AV22EnderecoCompleto = new GeneXus.Programs.myobjects.viacep.SdtEnderecoCompleto(context);
         AV23ModeloRetorno = "";
         AV24Mensagem = "";
         AV26Municipio = new SdtMunicipio(context);
         sStyleString = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV12TrnMode = "";
         sCtrlAV16EmpresaId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpempresa__default(),
            new Object[][] {
                new Object[] {
               H00822_A440ProfissaoId, H00822_A441ProfissaoNome, H00822_n441ProfissaoNome
               }
               , new Object[] {
               H00823_A402BancoId, H00823_A404BancoCodigo, H00823_n404BancoCodigo, H00823_A403BancoNome, H00823_n403BancoNome
               }
            }
         );
         /* GeneXus formulas. */
         edtavMunicipionome_Enabled = 0;
         edtavMunicipiouf_Enabled = 0;
         edtavRepresentantemunicipionome_Enabled = 0;
         edtavRepresentantemunicipiouf_Enabled = 0;
      }

      private short nRcdExists_4 ;
      private short nIsMod_4 ;
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
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int AV16EmpresaId ;
      private int wcpOAV16EmpresaId ;
      private int edtavMunicipionome_Enabled ;
      private int edtavMunicipiouf_Enabled ;
      private int edtavRepresentantemunicipionome_Enabled ;
      private int edtavRepresentantemunicipiouf_Enabled ;
      private int AV31ProfissaoId ;
      private int A440ProfissaoId ;
      private int Gxuitabspanel_tabs1_Pagecount ;
      private int bttBtnenter_Visible ;
      private int edtavEmpresa_empresanomefantasia_Enabled ;
      private int edtavEmpresa_empresarazaosocial_Enabled ;
      private int edtavEmpresa_empresacnpj_Enabled ;
      private int edtavEmpresa_empresaagencia_Enabled ;
      private int edtavEmpresa_empresaagenciadigito_Enabled ;
      private int edtavEmpresa_empresaconta_Enabled ;
      private int edtavEmpresa_empresapix_Enabled ;
      private int edtavEmpresa_empresaemail_Enabled ;
      private int edtavEmpresa_empresacep_Enabled ;
      private int edtavEmpresa_empresalogradouro_Enabled ;
      private int edtavEmpresa_empresalogradouronumero_Enabled ;
      private int edtavEmpresa_empresabairro_Enabled ;
      private int edtavEmpresa_empresacomplemento_Enabled ;
      private int edtavEmpresa_empresarepresentantecpf_Enabled ;
      private int edtavEmpresa_empresarepresentantenome_Enabled ;
      private int edtavEmpresa_empresarepresentanteemail_Enabled ;
      private int edtavEmpresa_empresarepresentantenacionalidade_Enabled ;
      private int edtavEmpresa_empresarepresentantecep_Enabled ;
      private int edtavEmpresa_empresarepresentantelogradouro_Enabled ;
      private int edtavEmpresa_empresarepresentantenumero_Enabled ;
      private int edtavEmpresa_empresarepresentantebairro_Enabled ;
      private int edtavEmpresa_empresarepresentantecomplemento_Enabled ;
      private int edtavEmpresa_empresarepresentantetelefoneddd_Enabled ;
      private int edtavEmpresa_empresarepresentantetelefone_Enabled ;
      private int edtavEmpresa_empresarepresentantemunicipio_Visible ;
      private int edtavEmpresa_municipiocodigo_Visible ;
      private int edtavEmpresa_empresaid_Visible ;
      private int A402BancoId ;
      private int A404BancoCodigo ;
      private int AV64GXV31 ;
      private int idxLst ;
      private string AV12TrnMode ;
      private string wcpOAV12TrnMode ;
      private string Combo_empresa_empresarepresentanteprofissao_Selectedvalue_get ;
      private string Combo_empresa_empresabancoid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string edtavMunicipionome_Internalname ;
      private string edtavMunicipiouf_Internalname ;
      private string edtavRepresentantemunicipionome_Internalname ;
      private string edtavRepresentantemunicipiouf_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Combo_empresa_empresabancoid_Cls ;
      private string Combo_empresa_empresabancoid_Selectedvalue_set ;
      private string Combo_empresa_empresabancoid_Htmltemplate ;
      private string Combo_empresa_empresarepresentanteprofissao_Cls ;
      private string Combo_empresa_empresarepresentanteprofissao_Selectedvalue_set ;
      private string Gxuitabspanel_tabs1_Class ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string TempTags ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string Gxuitabspanel_tabs1_Internalname ;
      private string lblInfo_title_Internalname ;
      private string lblInfo_title_Jsonclick ;
      private string divUnnamedtable3_Internalname ;
      private string edtavEmpresa_empresanomefantasia_Internalname ;
      private string edtavEmpresa_empresanomefantasia_Jsonclick ;
      private string edtavEmpresa_empresarazaosocial_Internalname ;
      private string edtavEmpresa_empresarazaosocial_Jsonclick ;
      private string edtavEmpresa_empresacnpj_Internalname ;
      private string edtavEmpresa_empresacnpj_Jsonclick ;
      private string divTablesplittedempresa_empresabancoid_Internalname ;
      private string lblTextblockcombo_empresa_empresabancoid_Internalname ;
      private string lblTextblockcombo_empresa_empresabancoid_Jsonclick ;
      private string Combo_empresa_empresabancoid_Caption ;
      private string Combo_empresa_empresabancoid_Internalname ;
      private string edtavEmpresa_empresaagencia_Internalname ;
      private string edtavEmpresa_empresaagencia_Jsonclick ;
      private string edtavEmpresa_empresaagenciadigito_Internalname ;
      private string edtavEmpresa_empresaagenciadigito_Jsonclick ;
      private string edtavEmpresa_empresaconta_Internalname ;
      private string edtavEmpresa_empresaconta_Jsonclick ;
      private string cmbavEmpresa_empresapixtipo_Internalname ;
      private string cmbavEmpresa_empresapixtipo_Jsonclick ;
      private string edtavEmpresa_empresapix_Internalname ;
      private string edtavEmpresa_empresapix_Jsonclick ;
      private string edtavEmpresa_empresaemail_Internalname ;
      private string edtavEmpresa_empresaemail_Jsonclick ;
      private string lblEndereco_title_Internalname ;
      private string lblEndereco_title_Jsonclick ;
      private string divUnnamedtable2_Internalname ;
      private string edtavEmpresa_empresacep_Internalname ;
      private string edtavEmpresa_empresacep_Jsonclick ;
      private string edtavEmpresa_empresalogradouro_Internalname ;
      private string edtavEmpresa_empresalogradouro_Jsonclick ;
      private string edtavEmpresa_empresalogradouronumero_Internalname ;
      private string edtavEmpresa_empresalogradouronumero_Jsonclick ;
      private string edtavEmpresa_empresabairro_Internalname ;
      private string edtavEmpresa_empresabairro_Jsonclick ;
      private string divTablesplittedmunicipionome_Internalname ;
      private string lblTextblockmunicipionome_Internalname ;
      private string lblTextblockmunicipionome_Jsonclick ;
      private string edtavEmpresa_empresacomplemento_Internalname ;
      private string edtavEmpresa_empresacomplemento_Jsonclick ;
      private string lblRepresentante_title_Internalname ;
      private string lblRepresentante_title_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string edtavEmpresa_empresarepresentantecpf_Internalname ;
      private string edtavEmpresa_empresarepresentantecpf_Jsonclick ;
      private string edtavEmpresa_empresarepresentantenome_Internalname ;
      private string edtavEmpresa_empresarepresentantenome_Jsonclick ;
      private string edtavEmpresa_empresarepresentanteemail_Internalname ;
      private string edtavEmpresa_empresarepresentanteemail_Jsonclick ;
      private string edtavEmpresa_empresarepresentantenacionalidade_Internalname ;
      private string edtavEmpresa_empresarepresentantenacionalidade_Jsonclick ;
      private string divTablesplittedempresa_empresarepresentanteprofissao_Internalname ;
      private string lblTextblockcombo_empresa_empresarepresentanteprofissao_Internalname ;
      private string lblTextblockcombo_empresa_empresarepresentanteprofissao_Jsonclick ;
      private string Combo_empresa_empresarepresentanteprofissao_Caption ;
      private string Combo_empresa_empresarepresentanteprofissao_Internalname ;
      private string cmbavEmpresa_empresautilizarepresentanteassinatura_Internalname ;
      private string cmbavEmpresa_empresautilizarepresentanteassinatura_Jsonclick ;
      private string edtavEmpresa_empresarepresentantecep_Internalname ;
      private string edtavEmpresa_empresarepresentantecep_Jsonclick ;
      private string edtavEmpresa_empresarepresentantelogradouro_Internalname ;
      private string edtavEmpresa_empresarepresentantelogradouro_Jsonclick ;
      private string edtavEmpresa_empresarepresentantenumero_Internalname ;
      private string edtavEmpresa_empresarepresentantenumero_Jsonclick ;
      private string edtavEmpresa_empresarepresentantebairro_Internalname ;
      private string edtavEmpresa_empresarepresentantebairro_Jsonclick ;
      private string edtavEmpresa_empresarepresentantecomplemento_Internalname ;
      private string edtavEmpresa_empresarepresentantecomplemento_Jsonclick ;
      private string divTablesplittedrepresentantemunicipionome_Internalname ;
      private string lblTextblockrepresentantemunicipionome_Internalname ;
      private string lblTextblockrepresentantemunicipionome_Jsonclick ;
      private string edtavEmpresa_empresarepresentantetelefoneddd_Internalname ;
      private string edtavEmpresa_empresarepresentantetelefoneddd_Jsonclick ;
      private string edtavEmpresa_empresarepresentantetelefone_Internalname ;
      private string edtavEmpresa_empresarepresentantetelefone_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavEmpresa_empresarepresentantemunicipio_Internalname ;
      private string edtavEmpresa_empresarepresentantemunicipio_Jsonclick ;
      private string edtavEmpresa_municipiocodigo_Internalname ;
      private string edtavEmpresa_municipiocodigo_Jsonclick ;
      private string edtavEmpresa_empresaid_Internalname ;
      private string edtavEmpresa_empresaid_Jsonclick ;
      private string cmbavEmpresa_empresasede_Internalname ;
      private string cmbavEmpresa_empresasede_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string GXt_char1 ;
      private string sStyleString ;
      private string tblTablemergedrepresentantemunicipionome_Internalname ;
      private string edtavRepresentantemunicipionome_Jsonclick ;
      private string edtavRepresentantemunicipiouf_Jsonclick ;
      private string tblTablemergedmunicipionome_Internalname ;
      private string edtavMunicipionome_Jsonclick ;
      private string edtavMunicipiouf_Jsonclick ;
      private string sCtrlAV12TrnMode ;
      private string sCtrlAV16EmpresaId ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14CheckRequiredFieldsResult ;
      private bool Combo_empresa_empresabancoid_Enabled ;
      private bool Combo_empresa_empresabancoid_Emptyitem ;
      private bool Combo_empresa_empresarepresentanteprofissao_Enabled ;
      private bool Combo_empresa_empresarepresentanteprofissao_Emptyitem ;
      private bool Combo_empresa_empresarepresentanteprofissao_Includeaddnewoption ;
      private bool Gxuitabspanel_tabs1_Historymanagement ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV13LoadSuccess ;
      private bool n441ProfissaoNome ;
      private bool n404BancoCodigo ;
      private bool n403BancoNome ;
      private string AV23ModeloRetorno ;
      private string A441ProfissaoNome ;
      private string AV19MunicipioNome ;
      private string AV20MunicipioUF ;
      private string AV27RepresentanteMunicipioNome ;
      private string AV28RepresentanteMunicipioUF ;
      private string AV29ComboSelectedValue ;
      private string A403BancoNome ;
      private string AV21CEP ;
      private string AV24Mensagem ;
      private IGxSession AV30Session ;
      private GXUserControl ucGxuitabspanel_tabs1 ;
      private GXUserControl ucCombo_empresa_empresabancoid ;
      private GXUserControl ucCombo_empresa_empresarepresentanteprofissao ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavEmpresa_empresapixtipo ;
      private GXCombobox cmbavEmpresa_empresautilizarepresentanteassinatura ;
      private GXCombobox cmbavEmpresa_empresasede ;
      private SdtEmpresa AV5Empresa ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV7Empresa_EmpresaBancoId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV17Empresa_EmpresaRepresentanteProfissao_Data ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV11Messages ;
      private IDataStoreProvider pr_default ;
      private int[] H00822_A440ProfissaoId ;
      private string[] H00822_A441ProfissaoNome ;
      private bool[] H00822_n441ProfissaoNome ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV8Combo_DataItem ;
      private int[] H00823_A402BancoId ;
      private int[] H00823_A404BancoCodigo ;
      private bool[] H00823_n404BancoCodigo ;
      private string[] H00823_A403BancoNome ;
      private bool[] H00823_n403BancoNome ;
      private GxSimpleCollection<string> AV6ComboTitles ;
      private GeneXus.Utils.SdtMessages_Message AV10Message ;
      private GeneXus.Programs.myobjects.viacep.SdtEnderecoCompleto AV22EnderecoCompleto ;
      private SdtMunicipio AV26Municipio ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpempresa__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00822;
          prmH00822 = new Object[] {
          };
          Object[] prmH00823;
          prmH00823 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H00822", "SELECT ProfissaoId, ProfissaoNome FROM Profissao ORDER BY ProfissaoNome ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00822,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00823", "SELECT BancoId, BancoCodigo, BancoNome FROM Banco ORDER BY BancoNome ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00823,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
       }
    }

 }

}
