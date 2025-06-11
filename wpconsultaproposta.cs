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
   public class wpconsultaproposta : GXDataArea
   {
      public wpconsultaproposta( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpconsultaproposta( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_PropostaId )
      {
         this.AV5PropostaId = aP0_PropostaId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavClientepixtipo = new GXCombobox();
         cmbavConveniovencimentoano = new GXCombobox();
         cmbavConveniovencimentomes = new GXCombobox();
         cmbavDocumentoobrigatorio = new GXCombobox();
         cmbavPropostadocumentosstatus = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "PropostaId");
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
               gxfirstwebparm = GetFirstPar( "PropostaId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "PropostaId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Griddocumentos") == 0 )
            {
               gxnrGriddocumentos_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Griddocumentos") == 0 )
            {
               gxgrGriddocumentos_refresh_invoke( ) ;
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
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGriddocumentos_newrow_invoke( )
      {
         nRC_GXsfl_166 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_166"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_166_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_166_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_166_idx = GetPar( "sGXsfl_166_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGriddocumentos_newrow( ) ;
         /* End function gxnrGriddocumentos_newrow_invoke */
      }

      protected void gxgrGriddocumentos_refresh_invoke( )
      {
         subGriddocumentos_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGriddocumentos_Rows"), "."), 18, MidpointRounding.ToEven));
         A323PropostaId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaId"), "."), 18, MidpointRounding.ToEven));
         n323PropostaId = false;
         AV5PropostaId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaId"), "."), 18, MidpointRounding.ToEven));
         A415PropostaDocumentosAnexo = GetPar( "PropostaDocumentosAnexo");
         n415PropostaDocumentosAnexo = false;
         A406DocumentosDescricao = GetPar( "DocumentosDescricao");
         n406DocumentosDescricao = false;
         A405DocumentosId = (int)(Math.Round(NumberUtil.Val( GetPar( "DocumentosId"), "."), 18, MidpointRounding.ToEven));
         n405DocumentosId = false;
         A417PropostaDocumentosAnexoFileType = GetPar( "PropostaDocumentosAnexoFileType");
         n417PropostaDocumentosAnexoFileType = false;
         A579PropostaDocumentosStatus = GetPar( "PropostaDocumentosStatus");
         n579PropostaDocumentosStatus = false;
         A416PropostaDocumentosAnexoName = GetPar( "PropostaDocumentosAnexoName");
         n416PropostaDocumentosAnexoName = false;
         A414PropostaDocumentosId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaDocumentosId"), "."), 18, MidpointRounding.ToEven));
         AV47PropostaResponsavelId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaResponsavelId"), "."), 18, MidpointRounding.ToEven));
         AV46PropostaPacienteClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaPacienteClienteId"), "."), 18, MidpointRounding.ToEven));
         AV58PropostaClinicaId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaClinicaId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGriddocumentos_refresh( subGriddocumentos_Rows, A323PropostaId, AV5PropostaId, A415PropostaDocumentosAnexo, A406DocumentosDescricao, A405DocumentosId, A417PropostaDocumentosAnexoFileType, A579PropostaDocumentosStatus, A416PropostaDocumentosAnexoName, A414PropostaDocumentosId, AV47PropostaResponsavelId, AV46PropostaPacienteClienteId, AV58PropostaClinicaId) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGriddocumentos_refresh_invoke */
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
         PA5S2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5S2( ) ;
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
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wpconsultaproposta"+UrlEncode(StringUtil.LTrimStr(AV5PropostaId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpconsultaproposta") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPROPOSTARESPONSAVELID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV47PropostaResponsavelId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTARESPONSAVELID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV47PropostaResponsavelId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPROPOSTAPACIENTECLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV46PropostaPacienteClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAPACIENTECLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV46PropostaPacienteClienteId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPROPOSTACLINICAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV58PropostaClinicaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTACLINICAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV58PropostaClinicaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5PropostaId), "ZZZZZZZZ9"), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_166", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_166), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5PropostaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "PROPOSTADOCUMENTOSANEXO", A415PropostaDocumentosAnexo);
         GxWebStd.gx_hidden_field( context, "DOCUMENTOSDESCRICAO", A406DocumentosDescricao);
         GxWebStd.gx_hidden_field( context, "DOCUMENTOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A405DocumentosId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PROPOSTADOCUMENTOSANEXOFILETYPE", A417PropostaDocumentosAnexoFileType);
         GxWebStd.gx_hidden_field( context, "PROPOSTADOCUMENTOSSTATUS", A579PropostaDocumentosStatus);
         GxWebStd.gx_hidden_field( context, "PROPOSTADOCUMENTOSANEXONAME", A416PropostaDocumentosAnexoName);
         GxWebStd.gx_hidden_field( context, "PROPOSTADOCUMENTOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A414PropostaDocumentosId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPROPOSTARESPONSAVELID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV47PropostaResponsavelId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTARESPONSAVELID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV47PropostaResponsavelId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPROPOSTAPACIENTECLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV46PropostaPacienteClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAPACIENTECLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV46PropostaPacienteClienteId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPROPOSTACLINICAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV58PropostaClinicaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTACLINICAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV58PropostaClinicaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "GRIDDOCUMENTOS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDDOCUMENTOS_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRIDDOCUMENTOS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDDOCUMENTOS_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "subGriddocumentos_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddocumentos_Recordcount), 5, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRIDDOCUMENTOS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddocumentos_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS1_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gxuitabspanel_tabs1_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS1_Class", StringUtil.RTrim( Gxuitabspanel_tabs1_Class));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS1_Historymanagement", StringUtil.BoolToStr( Gxuitabspanel_tabs1_Historymanagement));
         GxWebStd.gx_hidden_field( context, "NOVAJANELA_Target", StringUtil.RTrim( Novajanela_Target));
         GxWebStd.gx_hidden_field( context, "GRIDDOCUMENTOS_EMPOWERER_Gridinternalname", StringUtil.RTrim( Griddocumentos_empowerer_Gridinternalname));
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
         if ( ! ( WebComp_Wcwctitulosproposta == null ) )
         {
            WebComp_Wcwctitulosproposta.componentjscripts();
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
            WE5S2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5S2( ) ;
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
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wpconsultaproposta"+UrlEncode(StringUtil.LTrimStr(AV5PropostaId,9,0));
         return formatLink("wpconsultaproposta") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WpConsultaProposta" ;
      }

      public override string GetPgmdesc( )
      {
         return "Proposta" ;
      }

      protected void WB5S0( )
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
            ucGxuitabspanel_tabs1.SetProperty("PageCount", Gxuitabspanel_tabs1_Pagecount);
            ucGxuitabspanel_tabs1.SetProperty("Class", Gxuitabspanel_tabs1_Class);
            ucGxuitabspanel_tabs1.SetProperty("HistoryManagement", Gxuitabspanel_tabs1_Historymanagement);
            ucGxuitabspanel_tabs1.Render(context, "tab", Gxuitabspanel_tabs1_Internalname, "GXUITABSPANEL_TABS1Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"title1"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTab1_title_Internalname, "Proposta", "", "", lblTab1_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WpConsultaProposta.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Tab1") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup3_Internalname, "Clinica", 1, 0, "px", 0, "px", "Group", "", "HLP_WpConsultaProposta.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableclinica_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblConsultarclinica_Internalname, "<i class=\"fas fa-magnifying-glass\"></i>", "", "", lblConsultarclinica_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOCONSULTARCLINICA\\'."+"'", "", "TextBlock", 5, "", 1, 1, 0, 1, "HLP_WpConsultaProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavClinicaclienterazaosocial_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClinicaclienterazaosocial_Internalname, "Nome", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'" + sGXsfl_166_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClinicaclienterazaosocial_Internalname, AV55ClinicaClienteRazaoSocial, StringUtil.RTrim( context.localUtil.Format( AV55ClinicaClienteRazaoSocial, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClinicaclienterazaosocial_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavClinicaclienterazaosocial_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpConsultaProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavClinicaclientedocumento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClinicaclientedocumento_Internalname, "Documento", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_166_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClinicaclientedocumento_Internalname, AV56ClinicaClienteDocumento, StringUtil.RTrim( context.localUtil.Format( AV56ClinicaClienteDocumento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClinicaclientedocumento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavClinicaclientedocumento_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpConsultaProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavClinicacontatoemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClinicacontatoemail_Internalname, "E-mail", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'" + sGXsfl_166_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClinicacontatoemail_Internalname, AV57ClinicaContatoEmail, StringUtil.RTrim( context.localUtil.Format( AV57ClinicaContatoEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClinicacontatoemail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavClinicacontatoemail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WpConsultaProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup4_Internalname, "Paciente", 1, 0, "px", 0, "px", "Group", "", "HLP_WpConsultaProposta.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecliente_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblConsultarcliente_Internalname, "<i class=\"fas fa-magnifying-glass\"></i>", "", "", lblConsultarcliente_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOCONSULTARCLIENTE\\'."+"'", "", "TextBlock", 5, "", 1, 1, 0, 1, "HLP_WpConsultaProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavClienterazaosocial_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClienterazaosocial_Internalname, "Nome", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'" + sGXsfl_166_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClienterazaosocial_Internalname, AV26ClienteRazaoSocial, StringUtil.RTrim( context.localUtil.Format( AV26ClienteRazaoSocial, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClienterazaosocial_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavClienterazaosocial_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpConsultaProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavClientedocumento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientedocumento_Internalname, "Documento", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'" + sGXsfl_166_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientedocumento_Internalname, AV27ClienteDocumento, StringUtil.RTrim( context.localUtil.Format( AV27ClienteDocumento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientedocumento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavClientedocumento_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpConsultaProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavContatoemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContatoemail_Internalname, "E-mail", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'" + sGXsfl_166_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContatoemail_Internalname, AV28ContatoEmail, StringUtil.RTrim( context.localUtil.Format( AV28ContatoEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContatoemail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavContatoemail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WpConsultaProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontentresponsavel_Internalname, divTablecontentresponsavel_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup8_Internalname, "Responsável", 1, 0, "px", 0, "px", "Group", "", "HLP_WpConsultaProposta.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablerespnosavel_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblConsultarresponsavel_Internalname, "<i class=\"fas fa-magnifying-glass\"></i>", "", "", lblConsultarresponsavel_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOCONSULTARRESPONSAVEL\\'."+"'", "", "TextBlock", 5, "", 1, 1, 0, 1, "HLP_WpConsultaProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResponsavelclienterazaosocial_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelclienterazaosocial_Internalname, "Nome", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'" + sGXsfl_166_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelclienterazaosocial_Internalname, AV23ResponsavelClienteRazaoSocial, StringUtil.RTrim( context.localUtil.Format( AV23ResponsavelClienteRazaoSocial, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,77);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelclienterazaosocial_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavResponsavelclienterazaosocial_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpConsultaProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResponsavelclientedocumento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelclientedocumento_Internalname, "Documento", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'" + sGXsfl_166_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelclientedocumento_Internalname, AV24ResponsavelClienteDocumento, StringUtil.RTrim( context.localUtil.Format( AV24ResponsavelClienteDocumento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelclientedocumento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavResponsavelclientedocumento_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpConsultaProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResponsavelcontatoemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelcontatoemail_Internalname, "E-mail", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'" + sGXsfl_166_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelcontatoemail_Internalname, AV25ResponsavelContatoEmail, StringUtil.RTrim( context.localUtil.Format( AV25ResponsavelContatoEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelcontatoemail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavResponsavelcontatoemail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WpConsultaProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup5_Internalname, "Conta / PIX", 1, 0, "px", 0, "px", "Group", "", "HLP_WpConsultaProposta.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableconta_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablebanco_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavBanconome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavBanconome_Internalname, "Banco", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'" + sGXsfl_166_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavBanconome_Internalname, AV42BancoNome, StringUtil.RTrim( context.localUtil.Format( AV42BancoNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,97);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavBanconome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavBanconome_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpConsultaProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavContaagencia_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContaagencia_Internalname, "Agência", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'" + sGXsfl_166_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContaagencia_Internalname, AV21ContaAgencia, StringUtil.RTrim( context.localUtil.Format( AV21ContaAgencia, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContaagencia_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavContaagencia_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpConsultaProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavContanumero_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContanumero_Internalname, "Número", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'" + sGXsfl_166_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContanumero_Internalname, AV22ContaNumero, StringUtil.RTrim( context.localUtil.Format( AV22ContaNumero, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,106);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContanumero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavContanumero_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpConsultaProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablepix_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavClientepixtipo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavClientepixtipo_Internalname, "Tipo da chave pix", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'" + sGXsfl_166_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavClientepixtipo, cmbavClientepixtipo_Internalname, StringUtil.RTrim( AV18ClientePixTipo), 1, cmbavClientepixtipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavClientepixtipo.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,113);\"", "", true, 0, "HLP_WpConsultaProposta.htm");
            cmbavClientepixtipo.CurrentValue = StringUtil.RTrim( AV18ClientePixTipo);
            AssignProp("", false, cmbavClientepixtipo_Internalname, "Values", (string)(cmbavClientepixtipo.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavClientepix_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientepix_Internalname, "Chave pix", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 117,'',false,'" + sGXsfl_166_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientepix_Internalname, AV19ClientePix, StringUtil.RTrim( context.localUtil.Format( AV19ClientePix, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,117);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientepix_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavClientepix_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpConsultaProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup6_Internalname, "Proposta", 1, 0, "px", 0, "px", "Group", "", "HLP_WpConsultaProposta.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableproposta_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavProcedimentosmedicosdescricao_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProcedimentosmedicosdescricao_Internalname, "Procedimento", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'',false,'" + sGXsfl_166_idx + "',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavProcedimentosmedicosdescricao_Internalname, AV43ProcedimentosMedicosDescricao, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,126);\"", 0, 1, edtavProcedimentosmedicosdescricao_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WpConsultaProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPropostavalor_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostavalor_Internalname, "Valor", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 130,'',false,'" + sGXsfl_166_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostavalor_Internalname, StringUtil.LTrim( StringUtil.NToC( AV12PropostaValor, 18, 2, ",", "")), StringUtil.LTrim( ((edtavPropostavalor_Enabled!=0) ? context.localUtil.Format( AV12PropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV12PropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,130);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostavalor_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavPropostavalor_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpConsultaProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPropostadescricao_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostadescricao_Internalname, "Descrição", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 135,'',false,'" + sGXsfl_166_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostadescricao_Internalname, AV13PropostaDescricao, StringUtil.RTrim( context.localUtil.Format( AV13PropostaDescricao, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,135);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostadescricao_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavPropostadescricao_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpConsultaProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavConveniodescricao_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavConveniodescricao_Internalname, "Convênio", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 139,'',false,'" + sGXsfl_166_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConveniodescricao_Internalname, AV44ConvenioDescricao, StringUtil.RTrim( context.localUtil.Format( AV44ConvenioDescricao, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,139);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConveniodescricao_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavConveniodescricao_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpConsultaProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavConveniocategoriadescricao_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavConveniocategoriadescricao_Internalname, "Categoria", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 144,'',false,'" + sGXsfl_166_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConveniocategoriadescricao_Internalname, AV45ConvenioCategoriaDescricao, StringUtil.RTrim( context.localUtil.Format( AV45ConvenioCategoriaDescricao, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,144);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConveniocategoriadescricao_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavConveniocategoriadescricao_Enabled, 0, "text", "", 70, "chr", 1, "row", 70, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpConsultaProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedconveniovencimentoano_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockconveniovencimentoano_Internalname, "Ano vencimento carteira", "", "", lblTextblockconveniovencimentoano_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpConsultaProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            wb_table1_151_5S2( true) ;
         }
         else
         {
            wb_table1_151_5S2( false) ;
         }
         return  ;
      }

      protected void wb_table1_151_5S2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup7_Internalname, "Documentos", 1, 0, "px", 0, "px", "Group", "", "HLP_WpConsultaProposta.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledocumentos_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 HasGridEmpowerer", "start", "top", "", "", "div");
            /*  Grid Control  */
            GriddocumentosContainer.SetWrapped(nGXWrapped);
            StartGridControl166( ) ;
         }
         if ( wbEnd == 166 )
         {
            wbEnd = 0;
            nRC_GXsfl_166 = (int)(nGXsfl_166_idx-1);
            if ( GriddocumentosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GriddocumentosContainer.AddObjectProperty("GRIDDOCUMENTOS_nEOF", GRIDDOCUMENTOS_nEOF);
               GriddocumentosContainer.AddObjectProperty("GRIDDOCUMENTOS_nFirstRecordOnPage", GRIDDOCUMENTOS_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GriddocumentosContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Griddocumentos", GriddocumentosContainer, subGriddocumentos_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GriddocumentosContainerData", GriddocumentosContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GriddocumentosContainerData"+"V", GriddocumentosContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GriddocumentosContainerData"+"V"+"\" value='"+GriddocumentosContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"title2"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTab2_title_Internalname, "Títulos", "", "", lblTab2_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WpConsultaProposta.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Tab2") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"panel2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0183"+"", StringUtil.RTrim( WebComp_Wcwctitulosproposta_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0183"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_166_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wcwctitulosproposta_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwctitulosproposta), StringUtil.Lower( WebComp_Wcwctitulosproposta_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0183"+"");
                     }
                     WebComp_Wcwctitulosproposta.componentdraw();
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwctitulosproposta), StringUtil.Lower( WebComp_Wcwctitulosproposta_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspEndCmp();
                     }
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupFixedBottom CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 188,'',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(166), 3, 0)+","+"null"+");", "Fechar", bttBtncancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpConsultaProposta.htm");
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
            /* User Defined Control */
            ucNovajanela.Render(context, "innewwindow", Novajanela_Internalname, "NOVAJANELAContainer");
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
            /* User Defined Control */
            ucGriddocumentos_empowerer.Render(context, "wwp.gridempowerer", Griddocumentos_empowerer_Internalname, "GRIDDOCUMENTOS_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 166 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GriddocumentosContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GriddocumentosContainer.AddObjectProperty("GRIDDOCUMENTOS_nEOF", GRIDDOCUMENTOS_nEOF);
                  GriddocumentosContainer.AddObjectProperty("GRIDDOCUMENTOS_nFirstRecordOnPage", GRIDDOCUMENTOS_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GriddocumentosContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Griddocumentos", GriddocumentosContainer, subGriddocumentos_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GriddocumentosContainerData", GriddocumentosContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GriddocumentosContainerData"+"V", GriddocumentosContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GriddocumentosContainerData"+"V"+"\" value='"+GriddocumentosContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START5S2( )
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
         Form.Meta.addItem("description", "Proposta", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP5S0( ) ;
      }

      protected void WS5S2( )
      {
         START5S2( ) ;
         EVT5S2( ) ;
      }

      protected void EVT5S2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "'DOCONSULTARRESPONSAVEL'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoConsultarResponsavel' */
                              E115S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOCONSULTARCLIENTE'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoConsultarCliente' */
                              E125S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOCONSULTARCLINICA'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoConsultarClinica' */
                              E135S2 ();
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDDOCUMENTOSPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRIDDOCUMENTOSPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgriddocumentos_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgriddocumentos_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgriddocumentos_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgriddocumentos_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "GRIDDOCUMENTOS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 21), "VADICIONARANEXO.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 21), "VADICIONARANEXO.CLICK") == 0 ) )
                           {
                              nGXsfl_166_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_166_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_166_idx), 4, 0), 4, "0");
                              SubsflControlProps_1662( ) ;
                              AV29AdicionarAnexo = cgiGet( edtavAdicionaranexo_Internalname);
                              AssignAttri("", false, edtavAdicionaranexo_Internalname, AV29AdicionarAnexo);
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavDocumentosid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavDocumentosid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vDOCUMENTOSID");
                                 GX_FocusControl = edtavDocumentosid_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV36DocumentosId = 0;
                                 AssignAttri("", false, edtavDocumentosid_Internalname, StringUtil.LTrimStr( (decimal)(AV36DocumentosId), 9, 0));
                              }
                              else
                              {
                                 AV36DocumentosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavDocumentosid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                                 AssignAttri("", false, edtavDocumentosid_Internalname, StringUtil.LTrimStr( (decimal)(AV36DocumentosId), 9, 0));
                              }
                              AV37DocumentosDescricao = cgiGet( edtavDocumentosdescricao_Internalname);
                              AssignAttri("", false, edtavDocumentosdescricao_Internalname, AV37DocumentosDescricao);
                              cmbavDocumentoobrigatorio.Name = cmbavDocumentoobrigatorio_Internalname;
                              cmbavDocumentoobrigatorio.CurrentValue = cgiGet( cmbavDocumentoobrigatorio_Internalname);
                              AV38DocumentoObrigatorio = StringUtil.StrToBool( cgiGet( cmbavDocumentoobrigatorio_Internalname));
                              AssignAttri("", false, cmbavDocumentoobrigatorio_Internalname, AV38DocumentoObrigatorio);
                              AV49PropostaDocumentosAnexoName = cgiGet( edtavPropostadocumentosanexoname_Internalname);
                              AssignAttri("", false, edtavPropostadocumentosanexoname_Internalname, AV49PropostaDocumentosAnexoName);
                              AV39Documento = cgiGet( edtavDocumento_Internalname);
                              AssignProp("", false, edtavDocumento_Internalname, "URL", context.PathToRelativeUrl( AV39Documento), !bGXsfl_166_Refreshing);
                              AV40Extensao = cgiGet( edtavExtensao_Internalname);
                              AssignAttri("", false, edtavExtensao_Internalname, AV40Extensao);
                              cmbavPropostadocumentosstatus.Name = cmbavPropostadocumentosstatus_Internalname;
                              cmbavPropostadocumentosstatus.CurrentValue = cgiGet( cmbavPropostadocumentosstatus_Internalname);
                              AV41PropostaDocumentosStatus = cgiGet( cmbavPropostadocumentosstatus_Internalname);
                              AssignAttri("", false, cmbavPropostadocumentosstatus_Internalname, AV41PropostaDocumentosStatus);
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavPropostadocumentosid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPropostadocumentosid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPROPOSTADOCUMENTOSID");
                                 GX_FocusControl = edtavPropostadocumentosid_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV54PropostaDocumentosId = 0;
                                 AssignAttri("", false, edtavPropostadocumentosid_Internalname, StringUtil.LTrimStr( (decimal)(AV54PropostaDocumentosId), 9, 0));
                                 GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTADOCUMENTOSID"+"_"+sGXsfl_166_idx, GetSecureSignedToken( sGXsfl_166_idx, context.localUtil.Format( (decimal)(AV54PropostaDocumentosId), "ZZZZZZZZ9"), context));
                              }
                              else
                              {
                                 AV54PropostaDocumentosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavPropostadocumentosid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                                 AssignAttri("", false, edtavPropostadocumentosid_Internalname, StringUtil.LTrimStr( (decimal)(AV54PropostaDocumentosId), 9, 0));
                                 GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTADOCUMENTOSID"+"_"+sGXsfl_166_idx, GetSecureSignedToken( sGXsfl_166_idx, context.localUtil.Format( (decimal)(AV54PropostaDocumentosId), "ZZZZZZZZ9"), context));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E145S2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E155S2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDDOCUMENTOS.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Griddocumentos.Load */
                                    E165S2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VADICIONARANEXO.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E175S2 ();
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
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
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
                        if ( nCmpId == 183 )
                        {
                           OldWcwctitulosproposta = cgiGet( "W0183");
                           if ( ( StringUtil.Len( OldWcwctitulosproposta) == 0 ) || ( StringUtil.StrCmp(OldWcwctitulosproposta, WebComp_Wcwctitulosproposta_Component) != 0 ) )
                           {
                              WebComp_Wcwctitulosproposta = getWebComponent(GetType(), "GeneXus.Programs", OldWcwctitulosproposta, new Object[] {context} );
                              WebComp_Wcwctitulosproposta.ComponentInit();
                              WebComp_Wcwctitulosproposta.Name = "OldWcwctitulosproposta";
                              WebComp_Wcwctitulosproposta_Component = OldWcwctitulosproposta;
                           }
                           if ( StringUtil.Len( WebComp_Wcwctitulosproposta_Component) != 0 )
                           {
                              WebComp_Wcwctitulosproposta.componentprocess("W0183", "", sEvt);
                           }
                           WebComp_Wcwctitulosproposta_Component = OldWcwctitulosproposta;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE5S2( )
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

      protected void PA5S2( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpconsultaproposta")), "wpconsultaproposta") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpconsultaproposta")))) ;
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
                  gxfirstwebparm = GetFirstPar( "PropostaId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV5PropostaId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV5PropostaId", StringUtil.LTrimStr( (decimal)(AV5PropostaId), 9, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5PropostaId), "ZZZZZZZZ9"), context));
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
               GX_FocusControl = edtavClinicaclienterazaosocial_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGriddocumentos_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1662( ) ;
         while ( nGXsfl_166_idx <= nRC_GXsfl_166 )
         {
            sendrow_1662( ) ;
            nGXsfl_166_idx = ((subGriddocumentos_Islastpage==1)&&(nGXsfl_166_idx+1>subGriddocumentos_fnc_Recordsperpage( )) ? 1 : nGXsfl_166_idx+1);
            sGXsfl_166_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_166_idx), 4, 0), 4, "0");
            SubsflControlProps_1662( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GriddocumentosContainer)) ;
         /* End function gxnrGriddocumentos_newrow */
      }

      protected void gxgrGriddocumentos_refresh( int subGriddocumentos_Rows ,
                                                 int A323PropostaId ,
                                                 int AV5PropostaId ,
                                                 string A415PropostaDocumentosAnexo ,
                                                 string A406DocumentosDescricao ,
                                                 int A405DocumentosId ,
                                                 string A417PropostaDocumentosAnexoFileType ,
                                                 string A579PropostaDocumentosStatus ,
                                                 string A416PropostaDocumentosAnexoName ,
                                                 int A414PropostaDocumentosId ,
                                                 int AV47PropostaResponsavelId ,
                                                 int AV46PropostaPacienteClienteId ,
                                                 int AV58PropostaClinicaId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDDOCUMENTOS_nCurrentRecord = 0;
         RF5S2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGriddocumentos_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTADOCUMENTOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV54PropostaDocumentosId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPROPOSTADOCUMENTOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV54PropostaDocumentosId), 9, 0, ".", "")));
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
         if ( cmbavClientepixtipo.ItemCount > 0 )
         {
            AV18ClientePixTipo = cmbavClientepixtipo.getValidValue(AV18ClientePixTipo);
            AssignAttri("", false, "AV18ClientePixTipo", AV18ClientePixTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavClientepixtipo.CurrentValue = StringUtil.RTrim( AV18ClientePixTipo);
            AssignProp("", false, cmbavClientepixtipo_Internalname, "Values", cmbavClientepixtipo.ToJavascriptSource(), true);
         }
         if ( cmbavConveniovencimentoano.ItemCount > 0 )
         {
            AV16ConvenioVencimentoAno = (short)(Math.Round(NumberUtil.Val( cmbavConveniovencimentoano.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV16ConvenioVencimentoAno), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV16ConvenioVencimentoAno", StringUtil.LTrimStr( (decimal)(AV16ConvenioVencimentoAno), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavConveniovencimentoano.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16ConvenioVencimentoAno), 4, 0));
            AssignProp("", false, cmbavConveniovencimentoano_Internalname, "Values", cmbavConveniovencimentoano.ToJavascriptSource(), true);
         }
         if ( cmbavConveniovencimentomes.ItemCount > 0 )
         {
            AV17ConvenioVencimentoMes = (short)(Math.Round(NumberUtil.Val( cmbavConveniovencimentomes.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV17ConvenioVencimentoMes), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV17ConvenioVencimentoMes", StringUtil.LTrimStr( (decimal)(AV17ConvenioVencimentoMes), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavConveniovencimentomes.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17ConvenioVencimentoMes), 4, 0));
            AssignProp("", false, cmbavConveniovencimentomes_Internalname, "Values", cmbavConveniovencimentomes.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF5S2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavClinicaclienterazaosocial_Enabled = 0;
         AssignProp("", false, edtavClinicaclienterazaosocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClinicaclienterazaosocial_Enabled), 5, 0), true);
         edtavClinicaclientedocumento_Enabled = 0;
         AssignProp("", false, edtavClinicaclientedocumento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClinicaclientedocumento_Enabled), 5, 0), true);
         edtavClinicacontatoemail_Enabled = 0;
         AssignProp("", false, edtavClinicacontatoemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClinicacontatoemail_Enabled), 5, 0), true);
         edtavClienterazaosocial_Enabled = 0;
         AssignProp("", false, edtavClienterazaosocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClienterazaosocial_Enabled), 5, 0), true);
         edtavClientedocumento_Enabled = 0;
         AssignProp("", false, edtavClientedocumento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientedocumento_Enabled), 5, 0), true);
         edtavContatoemail_Enabled = 0;
         AssignProp("", false, edtavContatoemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavContatoemail_Enabled), 5, 0), true);
         edtavResponsavelclienterazaosocial_Enabled = 0;
         AssignProp("", false, edtavResponsavelclienterazaosocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelclienterazaosocial_Enabled), 5, 0), true);
         edtavResponsavelclientedocumento_Enabled = 0;
         AssignProp("", false, edtavResponsavelclientedocumento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelclientedocumento_Enabled), 5, 0), true);
         edtavResponsavelcontatoemail_Enabled = 0;
         AssignProp("", false, edtavResponsavelcontatoemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelcontatoemail_Enabled), 5, 0), true);
         edtavBanconome_Enabled = 0;
         AssignProp("", false, edtavBanconome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavBanconome_Enabled), 5, 0), true);
         edtavContaagencia_Enabled = 0;
         AssignProp("", false, edtavContaagencia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavContaagencia_Enabled), 5, 0), true);
         edtavContanumero_Enabled = 0;
         AssignProp("", false, edtavContanumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavContanumero_Enabled), 5, 0), true);
         cmbavClientepixtipo.Enabled = 0;
         AssignProp("", false, cmbavClientepixtipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavClientepixtipo.Enabled), 5, 0), true);
         edtavClientepix_Enabled = 0;
         AssignProp("", false, edtavClientepix_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientepix_Enabled), 5, 0), true);
         edtavProcedimentosmedicosdescricao_Enabled = 0;
         AssignProp("", false, edtavProcedimentosmedicosdescricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavProcedimentosmedicosdescricao_Enabled), 5, 0), true);
         edtavPropostavalor_Enabled = 0;
         AssignProp("", false, edtavPropostavalor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostavalor_Enabled), 5, 0), true);
         edtavPropostadescricao_Enabled = 0;
         AssignProp("", false, edtavPropostadescricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostadescricao_Enabled), 5, 0), true);
         edtavConveniodescricao_Enabled = 0;
         AssignProp("", false, edtavConveniodescricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavConveniodescricao_Enabled), 5, 0), true);
         edtavConveniocategoriadescricao_Enabled = 0;
         AssignProp("", false, edtavConveniocategoriadescricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavConveniocategoriadescricao_Enabled), 5, 0), true);
         cmbavConveniovencimentoano.Enabled = 0;
         AssignProp("", false, cmbavConveniovencimentoano_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavConveniovencimentoano.Enabled), 5, 0), true);
         cmbavConveniovencimentomes.Enabled = 0;
         AssignProp("", false, cmbavConveniovencimentomes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavConveniovencimentomes.Enabled), 5, 0), true);
         edtavAdicionaranexo_Enabled = 0;
         edtavDocumentosid_Enabled = 0;
         edtavDocumentosdescricao_Enabled = 0;
         cmbavDocumentoobrigatorio.Enabled = 0;
         edtavPropostadocumentosanexoname_Enabled = 0;
         edtavDocumento_Enabled = 0;
         edtavExtensao_Enabled = 0;
         cmbavPropostadocumentosstatus.Enabled = 0;
         edtavPropostadocumentosid_Enabled = 0;
      }

      protected void RF5S2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GriddocumentosContainer.ClearRows();
         }
         wbStart = 166;
         /* Execute user event: Refresh */
         E155S2 ();
         nGXsfl_166_idx = 1;
         sGXsfl_166_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_166_idx), 4, 0), 4, "0");
         SubsflControlProps_1662( ) ;
         bGXsfl_166_Refreshing = true;
         GriddocumentosContainer.AddObjectProperty("GridName", "Griddocumentos");
         GriddocumentosContainer.AddObjectProperty("CmpContext", "");
         GriddocumentosContainer.AddObjectProperty("InMasterPage", "false");
         GriddocumentosContainer.AddObjectProperty("Class", "GridWithBorderColor WorkWith");
         GriddocumentosContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GriddocumentosContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GriddocumentosContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddocumentos_Backcolorstyle), 1, 0, ".", "")));
         GriddocumentosContainer.PageSize = subGriddocumentos_fnc_Recordsperpage( );
         if ( subGriddocumentos_Islastpage != 0 )
         {
            GRIDDOCUMENTOS_nFirstRecordOnPage = (long)(subGriddocumentos_fnc_Recordcount( )-subGriddocumentos_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, "GRIDDOCUMENTOS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDDOCUMENTOS_nFirstRecordOnPage), 15, 0, ".", "")));
            GriddocumentosContainer.AddObjectProperty("GRIDDOCUMENTOS_nFirstRecordOnPage", GRIDDOCUMENTOS_nFirstRecordOnPage);
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcwctitulosproposta_Component) != 0 )
               {
                  WebComp_Wcwctitulosproposta.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1662( ) ;
            /* Execute user event: Griddocumentos.Load */
            E165S2 ();
            if ( ( subGriddocumentos_Islastpage == 0 ) && ( GRIDDOCUMENTOS_nCurrentRecord > 0 ) && ( GRIDDOCUMENTOS_nGridOutOfScope == 0 ) && ( nGXsfl_166_idx == 1 ) )
            {
               GRIDDOCUMENTOS_nCurrentRecord = 0;
               GRIDDOCUMENTOS_nGridOutOfScope = 1;
               subgriddocumentos_firstpage( ) ;
               /* Execute user event: Griddocumentos.Load */
               E165S2 ();
            }
            wbEnd = 166;
            WB5S0( ) ;
         }
         bGXsfl_166_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes5S2( )
      {
         GxWebStd.gx_hidden_field( context, "vPROPOSTARESPONSAVELID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV47PropostaResponsavelId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTARESPONSAVELID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV47PropostaResponsavelId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPROPOSTAPACIENTECLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV46PropostaPacienteClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAPACIENTECLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV46PropostaPacienteClienteId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPROPOSTACLINICAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV58PropostaClinicaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTACLINICAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV58PropostaClinicaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTADOCUMENTOSID"+"_"+sGXsfl_166_idx, GetSecureSignedToken( sGXsfl_166_idx, context.localUtil.Format( (decimal)(AV54PropostaDocumentosId), "ZZZZZZZZ9"), context));
      }

      protected int subGriddocumentos_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGriddocumentos_fnc_Recordcount( )
      {
         return (int)(((subGriddocumentos_Recordcount==0) ? GRIDDOCUMENTOS_nFirstRecordOnPage+1 : subGriddocumentos_Recordcount)) ;
      }

      protected int subGriddocumentos_fnc_Recordsperpage( )
      {
         if ( subGriddocumentos_Rows > 0 )
         {
            return subGriddocumentos_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGriddocumentos_fnc_Currentpage( )
      {
         return (int)(((subGriddocumentos_Islastpage==1) ? NumberUtil.Int( (long)(Math.Round(subGriddocumentos_fnc_Recordcount( )/ (decimal)(subGriddocumentos_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+((((int)((subGriddocumentos_fnc_Recordcount( )) % (subGriddocumentos_fnc_Recordsperpage( ))))==0) ? 0 : 1) : NumberUtil.Int( (long)(Math.Round(GRIDDOCUMENTOS_nFirstRecordOnPage/ (decimal)(subGriddocumentos_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1)) ;
      }

      protected short subgriddocumentos_firstpage( )
      {
         GRIDDOCUMENTOS_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRIDDOCUMENTOS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDDOCUMENTOS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGriddocumentos_refresh( subGriddocumentos_Rows, A323PropostaId, AV5PropostaId, A415PropostaDocumentosAnexo, A406DocumentosDescricao, A405DocumentosId, A417PropostaDocumentosAnexoFileType, A579PropostaDocumentosStatus, A416PropostaDocumentosAnexoName, A414PropostaDocumentosId, AV47PropostaResponsavelId, AV46PropostaPacienteClienteId, AV58PropostaClinicaId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgriddocumentos_nextpage( )
      {
         if ( GRIDDOCUMENTOS_nEOF == 0 )
         {
            GRIDDOCUMENTOS_nFirstRecordOnPage = (long)(GRIDDOCUMENTOS_nFirstRecordOnPage+subGriddocumentos_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRIDDOCUMENTOS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDDOCUMENTOS_nFirstRecordOnPage), 15, 0, ".", "")));
         GriddocumentosContainer.AddObjectProperty("GRIDDOCUMENTOS_nFirstRecordOnPage", GRIDDOCUMENTOS_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGriddocumentos_refresh( subGriddocumentos_Rows, A323PropostaId, AV5PropostaId, A415PropostaDocumentosAnexo, A406DocumentosDescricao, A405DocumentosId, A417PropostaDocumentosAnexoFileType, A579PropostaDocumentosStatus, A416PropostaDocumentosAnexoName, A414PropostaDocumentosId, AV47PropostaResponsavelId, AV46PropostaPacienteClienteId, AV58PropostaClinicaId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDDOCUMENTOS_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgriddocumentos_previouspage( )
      {
         if ( GRIDDOCUMENTOS_nFirstRecordOnPage >= subGriddocumentos_fnc_Recordsperpage( ) )
         {
            GRIDDOCUMENTOS_nFirstRecordOnPage = (long)(GRIDDOCUMENTOS_nFirstRecordOnPage-subGriddocumentos_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDDOCUMENTOS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDDOCUMENTOS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGriddocumentos_refresh( subGriddocumentos_Rows, A323PropostaId, AV5PropostaId, A415PropostaDocumentosAnexo, A406DocumentosDescricao, A405DocumentosId, A417PropostaDocumentosAnexoFileType, A579PropostaDocumentosStatus, A416PropostaDocumentosAnexoName, A414PropostaDocumentosId, AV47PropostaResponsavelId, AV46PropostaPacienteClienteId, AV58PropostaClinicaId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgriddocumentos_lastpage( )
      {
         subGriddocumentos_Islastpage = 1;
         if ( isFullAjaxMode( ) )
         {
            gxgrGriddocumentos_refresh( subGriddocumentos_Rows, A323PropostaId, AV5PropostaId, A415PropostaDocumentosAnexo, A406DocumentosDescricao, A405DocumentosId, A417PropostaDocumentosAnexoFileType, A579PropostaDocumentosStatus, A416PropostaDocumentosAnexoName, A414PropostaDocumentosId, AV47PropostaResponsavelId, AV46PropostaPacienteClienteId, AV58PropostaClinicaId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgriddocumentos_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDDOCUMENTOS_nFirstRecordOnPage = (long)(subGriddocumentos_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDDOCUMENTOS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDDOCUMENTOS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDDOCUMENTOS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGriddocumentos_refresh( subGriddocumentos_Rows, A323PropostaId, AV5PropostaId, A415PropostaDocumentosAnexo, A406DocumentosDescricao, A405DocumentosId, A417PropostaDocumentosAnexoFileType, A579PropostaDocumentosStatus, A416PropostaDocumentosAnexoName, A414PropostaDocumentosId, AV47PropostaResponsavelId, AV46PropostaPacienteClienteId, AV58PropostaClinicaId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtavClinicaclienterazaosocial_Enabled = 0;
         AssignProp("", false, edtavClinicaclienterazaosocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClinicaclienterazaosocial_Enabled), 5, 0), true);
         edtavClinicaclientedocumento_Enabled = 0;
         AssignProp("", false, edtavClinicaclientedocumento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClinicaclientedocumento_Enabled), 5, 0), true);
         edtavClinicacontatoemail_Enabled = 0;
         AssignProp("", false, edtavClinicacontatoemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClinicacontatoemail_Enabled), 5, 0), true);
         edtavClienterazaosocial_Enabled = 0;
         AssignProp("", false, edtavClienterazaosocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClienterazaosocial_Enabled), 5, 0), true);
         edtavClientedocumento_Enabled = 0;
         AssignProp("", false, edtavClientedocumento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientedocumento_Enabled), 5, 0), true);
         edtavContatoemail_Enabled = 0;
         AssignProp("", false, edtavContatoemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavContatoemail_Enabled), 5, 0), true);
         edtavResponsavelclienterazaosocial_Enabled = 0;
         AssignProp("", false, edtavResponsavelclienterazaosocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelclienterazaosocial_Enabled), 5, 0), true);
         edtavResponsavelclientedocumento_Enabled = 0;
         AssignProp("", false, edtavResponsavelclientedocumento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelclientedocumento_Enabled), 5, 0), true);
         edtavResponsavelcontatoemail_Enabled = 0;
         AssignProp("", false, edtavResponsavelcontatoemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelcontatoemail_Enabled), 5, 0), true);
         edtavBanconome_Enabled = 0;
         AssignProp("", false, edtavBanconome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavBanconome_Enabled), 5, 0), true);
         edtavContaagencia_Enabled = 0;
         AssignProp("", false, edtavContaagencia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavContaagencia_Enabled), 5, 0), true);
         edtavContanumero_Enabled = 0;
         AssignProp("", false, edtavContanumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavContanumero_Enabled), 5, 0), true);
         cmbavClientepixtipo.Enabled = 0;
         AssignProp("", false, cmbavClientepixtipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavClientepixtipo.Enabled), 5, 0), true);
         edtavClientepix_Enabled = 0;
         AssignProp("", false, edtavClientepix_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientepix_Enabled), 5, 0), true);
         edtavProcedimentosmedicosdescricao_Enabled = 0;
         AssignProp("", false, edtavProcedimentosmedicosdescricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavProcedimentosmedicosdescricao_Enabled), 5, 0), true);
         edtavPropostavalor_Enabled = 0;
         AssignProp("", false, edtavPropostavalor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostavalor_Enabled), 5, 0), true);
         edtavPropostadescricao_Enabled = 0;
         AssignProp("", false, edtavPropostadescricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostadescricao_Enabled), 5, 0), true);
         edtavConveniodescricao_Enabled = 0;
         AssignProp("", false, edtavConveniodescricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavConveniodescricao_Enabled), 5, 0), true);
         edtavConveniocategoriadescricao_Enabled = 0;
         AssignProp("", false, edtavConveniocategoriadescricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavConveniocategoriadescricao_Enabled), 5, 0), true);
         cmbavConveniovencimentoano.Enabled = 0;
         AssignProp("", false, cmbavConveniovencimentoano_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavConveniovencimentoano.Enabled), 5, 0), true);
         cmbavConveniovencimentomes.Enabled = 0;
         AssignProp("", false, cmbavConveniovencimentomes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavConveniovencimentomes.Enabled), 5, 0), true);
         edtavAdicionaranexo_Enabled = 0;
         edtavDocumentosid_Enabled = 0;
         edtavDocumentosdescricao_Enabled = 0;
         cmbavDocumentoobrigatorio.Enabled = 0;
         edtavPropostadocumentosanexoname_Enabled = 0;
         edtavDocumento_Enabled = 0;
         edtavExtensao_Enabled = 0;
         cmbavPropostadocumentosstatus.Enabled = 0;
         edtavPropostadocumentosid_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5S0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E145S2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_166 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_166"), ",", "."), 18, MidpointRounding.ToEven));
            GRIDDOCUMENTOS_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDDOCUMENTOS_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRIDDOCUMENTOS_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDDOCUMENTOS_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            subGriddocumentos_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "subGriddocumentos_Recordcount"), ",", "."), 18, MidpointRounding.ToEven));
            subGriddocumentos_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDDOCUMENTOS_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRIDDOCUMENTOS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddocumentos_Rows), 6, 0, ".", "")));
            Gxuitabspanel_tabs1_Pagecount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GXUITABSPANEL_TABS1_Pagecount"), ",", "."), 18, MidpointRounding.ToEven));
            Gxuitabspanel_tabs1_Class = cgiGet( "GXUITABSPANEL_TABS1_Class");
            Gxuitabspanel_tabs1_Historymanagement = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_TABS1_Historymanagement"));
            Novajanela_Target = cgiGet( "NOVAJANELA_Target");
            Griddocumentos_empowerer_Gridinternalname = cgiGet( "GRIDDOCUMENTOS_EMPOWERER_Gridinternalname");
            /* Read variables values. */
            AV55ClinicaClienteRazaoSocial = StringUtil.Upper( cgiGet( edtavClinicaclienterazaosocial_Internalname));
            AssignAttri("", false, "AV55ClinicaClienteRazaoSocial", AV55ClinicaClienteRazaoSocial);
            AV56ClinicaClienteDocumento = cgiGet( edtavClinicaclientedocumento_Internalname);
            AssignAttri("", false, "AV56ClinicaClienteDocumento", AV56ClinicaClienteDocumento);
            AV57ClinicaContatoEmail = cgiGet( edtavClinicacontatoemail_Internalname);
            AssignAttri("", false, "AV57ClinicaContatoEmail", AV57ClinicaContatoEmail);
            AV26ClienteRazaoSocial = StringUtil.Upper( cgiGet( edtavClienterazaosocial_Internalname));
            AssignAttri("", false, "AV26ClienteRazaoSocial", AV26ClienteRazaoSocial);
            AV27ClienteDocumento = cgiGet( edtavClientedocumento_Internalname);
            AssignAttri("", false, "AV27ClienteDocumento", AV27ClienteDocumento);
            AV28ContatoEmail = cgiGet( edtavContatoemail_Internalname);
            AssignAttri("", false, "AV28ContatoEmail", AV28ContatoEmail);
            AV23ResponsavelClienteRazaoSocial = StringUtil.Upper( cgiGet( edtavResponsavelclienterazaosocial_Internalname));
            AssignAttri("", false, "AV23ResponsavelClienteRazaoSocial", AV23ResponsavelClienteRazaoSocial);
            AV24ResponsavelClienteDocumento = cgiGet( edtavResponsavelclientedocumento_Internalname);
            AssignAttri("", false, "AV24ResponsavelClienteDocumento", AV24ResponsavelClienteDocumento);
            AV25ResponsavelContatoEmail = cgiGet( edtavResponsavelcontatoemail_Internalname);
            AssignAttri("", false, "AV25ResponsavelContatoEmail", AV25ResponsavelContatoEmail);
            AV42BancoNome = cgiGet( edtavBanconome_Internalname);
            AssignAttri("", false, "AV42BancoNome", AV42BancoNome);
            AV21ContaAgencia = cgiGet( edtavContaagencia_Internalname);
            AssignAttri("", false, "AV21ContaAgencia", AV21ContaAgencia);
            AV22ContaNumero = cgiGet( edtavContanumero_Internalname);
            AssignAttri("", false, "AV22ContaNumero", AV22ContaNumero);
            cmbavClientepixtipo.Name = cmbavClientepixtipo_Internalname;
            cmbavClientepixtipo.CurrentValue = cgiGet( cmbavClientepixtipo_Internalname);
            AV18ClientePixTipo = cgiGet( cmbavClientepixtipo_Internalname);
            AssignAttri("", false, "AV18ClientePixTipo", AV18ClientePixTipo);
            AV19ClientePix = cgiGet( edtavClientepix_Internalname);
            AssignAttri("", false, "AV19ClientePix", AV19ClientePix);
            AV43ProcedimentosMedicosDescricao = cgiGet( edtavProcedimentosmedicosdescricao_Internalname);
            AssignAttri("", false, "AV43ProcedimentosMedicosDescricao", AV43ProcedimentosMedicosDescricao);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPropostavalor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPropostavalor_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPROPOSTAVALOR");
               GX_FocusControl = edtavPropostavalor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12PropostaValor = 0;
               AssignAttri("", false, "AV12PropostaValor", StringUtil.LTrimStr( AV12PropostaValor, 18, 2));
            }
            else
            {
               AV12PropostaValor = context.localUtil.CToN( cgiGet( edtavPropostavalor_Internalname), ",", ".");
               AssignAttri("", false, "AV12PropostaValor", StringUtil.LTrimStr( AV12PropostaValor, 18, 2));
            }
            AV13PropostaDescricao = cgiGet( edtavPropostadescricao_Internalname);
            AssignAttri("", false, "AV13PropostaDescricao", AV13PropostaDescricao);
            AV44ConvenioDescricao = cgiGet( edtavConveniodescricao_Internalname);
            AssignAttri("", false, "AV44ConvenioDescricao", AV44ConvenioDescricao);
            AV45ConvenioCategoriaDescricao = cgiGet( edtavConveniocategoriadescricao_Internalname);
            AssignAttri("", false, "AV45ConvenioCategoriaDescricao", AV45ConvenioCategoriaDescricao);
            cmbavConveniovencimentoano.Name = cmbavConveniovencimentoano_Internalname;
            cmbavConveniovencimentoano.CurrentValue = cgiGet( cmbavConveniovencimentoano_Internalname);
            AV16ConvenioVencimentoAno = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavConveniovencimentoano_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV16ConvenioVencimentoAno", StringUtil.LTrimStr( (decimal)(AV16ConvenioVencimentoAno), 4, 0));
            cmbavConveniovencimentomes.Name = cmbavConveniovencimentomes_Internalname;
            cmbavConveniovencimentomes.CurrentValue = cgiGet( cmbavConveniovencimentomes_Internalname);
            AV17ConvenioVencimentoMes = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavConveniovencimentomes_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV17ConvenioVencimentoMes", StringUtil.LTrimStr( (decimal)(AV17ConvenioVencimentoMes), 4, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
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
         E145S2 ();
         if (returnInSub) return;
      }

      protected void E145S2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Using cursor H005S2 */
         pr_default.execute(0, new Object[] {AV5PropostaId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A227ContratoId = H005S2_A227ContratoId[0];
            n227ContratoId = H005S2_n227ContratoId[0];
            A473ContratoClienteId = H005S2_A473ContratoClienteId[0];
            n473ContratoClienteId = H005S2_n473ContratoClienteId[0];
            A376ProcedimentosMedicosId = H005S2_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = H005S2_n376ProcedimentosMedicosId[0];
            A410ConvenioId = H005S2_A410ConvenioId[0];
            n410ConvenioId = H005S2_n410ConvenioId[0];
            A402BancoId = H005S2_A402BancoId[0];
            n402BancoId = H005S2_n402BancoId[0];
            A403BancoNome = H005S2_A403BancoNome[0];
            n403BancoNome = H005S2_n403BancoNome[0];
            A323PropostaId = H005S2_A323PropostaId[0];
            n323PropostaId = H005S2_n323PropostaId[0];
            A652PropostaClinicaDocumento = H005S2_A652PropostaClinicaDocumento[0];
            n652PropostaClinicaDocumento = H005S2_n652PropostaClinicaDocumento[0];
            A643PropostaClinicaNome = H005S2_A643PropostaClinicaNome[0];
            n643PropostaClinicaNome = H005S2_n643PropostaClinicaNome[0];
            A653PropostaClinicaEmail = H005S2_A653PropostaClinicaEmail[0];
            n653PropostaClinicaEmail = H005S2_n653PropostaClinicaEmail[0];
            A642PropostaClinicaId = H005S2_A642PropostaClinicaId[0];
            n642PropostaClinicaId = H005S2_n642PropostaClinicaId[0];
            A553PropostaResponsavelId = H005S2_A553PropostaResponsavelId[0];
            n553PropostaResponsavelId = H005S2_n553PropostaResponsavelId[0];
            A504PropostaPacienteClienteId = H005S2_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = H005S2_n504PropostaPacienteClienteId[0];
            A590PropostaResponsavelConta = H005S2_A590PropostaResponsavelConta[0];
            n590PropostaResponsavelConta = H005S2_n590PropostaResponsavelConta[0];
            A591PropostaResponsavelAgencia = H005S2_A591PropostaResponsavelAgencia[0];
            n591PropostaResponsavelAgencia = H005S2_n591PropostaResponsavelAgencia[0];
            A592PropostaResponsavelTipoPix = H005S2_A592PropostaResponsavelTipoPix[0];
            n592PropostaResponsavelTipoPix = H005S2_n592PropostaResponsavelTipoPix[0];
            A593PropostaResponsavelPIX = H005S2_A593PropostaResponsavelPIX[0];
            n593PropostaResponsavelPIX = H005S2_n593PropostaResponsavelPIX[0];
            A594PropostaResponsavelDepositoTipo = H005S2_A594PropostaResponsavelDepositoTipo[0];
            n594PropostaResponsavelDepositoTipo = H005S2_n594PropostaResponsavelDepositoTipo[0];
            A584PropostaPacienteConta = H005S2_A584PropostaPacienteConta[0];
            n584PropostaPacienteConta = H005S2_n584PropostaPacienteConta[0];
            A585PropostaPacienteAgencia = H005S2_A585PropostaPacienteAgencia[0];
            n585PropostaPacienteAgencia = H005S2_n585PropostaPacienteAgencia[0];
            A586PropostaPacienteTipoPix = H005S2_A586PropostaPacienteTipoPix[0];
            n586PropostaPacienteTipoPix = H005S2_n586PropostaPacienteTipoPix[0];
            A587PropostaPacientePIX = H005S2_A587PropostaPacientePIX[0];
            n587PropostaPacientePIX = H005S2_n587PropostaPacientePIX[0];
            A588PropostaPacienteDepositoTipo = H005S2_A588PropostaPacienteDepositoTipo[0];
            n588PropostaPacienteDepositoTipo = H005S2_n588PropostaPacienteDepositoTipo[0];
            A505PropostaPacienteClienteRazaoSocial = H005S2_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = H005S2_n505PropostaPacienteClienteRazaoSocial[0];
            A540PropostaPacienteClienteDocumento = H005S2_A540PropostaPacienteClienteDocumento[0];
            n540PropostaPacienteClienteDocumento = H005S2_n540PropostaPacienteClienteDocumento[0];
            A541PropostaPacienteContatoEmail = H005S2_A541PropostaPacienteContatoEmail[0];
            n541PropostaPacienteContatoEmail = H005S2_n541PropostaPacienteContatoEmail[0];
            A580PropostaResponsavelDocumento = H005S2_A580PropostaResponsavelDocumento[0];
            n580PropostaResponsavelDocumento = H005S2_n580PropostaResponsavelDocumento[0];
            A581PropostaResponsavelRazaoSocial = H005S2_A581PropostaResponsavelRazaoSocial[0];
            n581PropostaResponsavelRazaoSocial = H005S2_n581PropostaResponsavelRazaoSocial[0];
            A582PropostaResponsavelEmail = H005S2_A582PropostaResponsavelEmail[0];
            n582PropostaResponsavelEmail = H005S2_n582PropostaResponsavelEmail[0];
            A378ProcedimentosMedicosDescricao = H005S2_A378ProcedimentosMedicosDescricao[0];
            n378ProcedimentosMedicosDescricao = H005S2_n378ProcedimentosMedicosDescricao[0];
            A326PropostaValor = H005S2_A326PropostaValor[0];
            n326PropostaValor = H005S2_n326PropostaValor[0];
            A325PropostaDescricao = H005S2_A325PropostaDescricao[0];
            n325PropostaDescricao = H005S2_n325PropostaDescricao[0];
            A494ConvenioCategoriaDescricao = H005S2_A494ConvenioCategoriaDescricao[0];
            n494ConvenioCategoriaDescricao = H005S2_n494ConvenioCategoriaDescricao[0];
            A493ConvenioCategoriaId = H005S2_A493ConvenioCategoriaId[0];
            n493ConvenioCategoriaId = H005S2_n493ConvenioCategoriaId[0];
            A411ConvenioDescricao = H005S2_A411ConvenioDescricao[0];
            n411ConvenioDescricao = H005S2_n411ConvenioDescricao[0];
            A496ConvenioVencimentoAno = H005S2_A496ConvenioVencimentoAno[0];
            n496ConvenioVencimentoAno = H005S2_n496ConvenioVencimentoAno[0];
            A497ConvenioVencimentoMes = H005S2_A497ConvenioVencimentoMes[0];
            n497ConvenioVencimentoMes = H005S2_n497ConvenioVencimentoMes[0];
            A473ContratoClienteId = H005S2_A473ContratoClienteId[0];
            n473ContratoClienteId = H005S2_n473ContratoClienteId[0];
            A402BancoId = H005S2_A402BancoId[0];
            n402BancoId = H005S2_n402BancoId[0];
            A403BancoNome = H005S2_A403BancoNome[0];
            n403BancoNome = H005S2_n403BancoNome[0];
            A378ProcedimentosMedicosDescricao = H005S2_A378ProcedimentosMedicosDescricao[0];
            n378ProcedimentosMedicosDescricao = H005S2_n378ProcedimentosMedicosDescricao[0];
            A652PropostaClinicaDocumento = H005S2_A652PropostaClinicaDocumento[0];
            n652PropostaClinicaDocumento = H005S2_n652PropostaClinicaDocumento[0];
            A643PropostaClinicaNome = H005S2_A643PropostaClinicaNome[0];
            n643PropostaClinicaNome = H005S2_n643PropostaClinicaNome[0];
            A653PropostaClinicaEmail = H005S2_A653PropostaClinicaEmail[0];
            n653PropostaClinicaEmail = H005S2_n653PropostaClinicaEmail[0];
            A590PropostaResponsavelConta = H005S2_A590PropostaResponsavelConta[0];
            n590PropostaResponsavelConta = H005S2_n590PropostaResponsavelConta[0];
            A591PropostaResponsavelAgencia = H005S2_A591PropostaResponsavelAgencia[0];
            n591PropostaResponsavelAgencia = H005S2_n591PropostaResponsavelAgencia[0];
            A592PropostaResponsavelTipoPix = H005S2_A592PropostaResponsavelTipoPix[0];
            n592PropostaResponsavelTipoPix = H005S2_n592PropostaResponsavelTipoPix[0];
            A593PropostaResponsavelPIX = H005S2_A593PropostaResponsavelPIX[0];
            n593PropostaResponsavelPIX = H005S2_n593PropostaResponsavelPIX[0];
            A594PropostaResponsavelDepositoTipo = H005S2_A594PropostaResponsavelDepositoTipo[0];
            n594PropostaResponsavelDepositoTipo = H005S2_n594PropostaResponsavelDepositoTipo[0];
            A580PropostaResponsavelDocumento = H005S2_A580PropostaResponsavelDocumento[0];
            n580PropostaResponsavelDocumento = H005S2_n580PropostaResponsavelDocumento[0];
            A581PropostaResponsavelRazaoSocial = H005S2_A581PropostaResponsavelRazaoSocial[0];
            n581PropostaResponsavelRazaoSocial = H005S2_n581PropostaResponsavelRazaoSocial[0];
            A582PropostaResponsavelEmail = H005S2_A582PropostaResponsavelEmail[0];
            n582PropostaResponsavelEmail = H005S2_n582PropostaResponsavelEmail[0];
            A584PropostaPacienteConta = H005S2_A584PropostaPacienteConta[0];
            n584PropostaPacienteConta = H005S2_n584PropostaPacienteConta[0];
            A585PropostaPacienteAgencia = H005S2_A585PropostaPacienteAgencia[0];
            n585PropostaPacienteAgencia = H005S2_n585PropostaPacienteAgencia[0];
            A586PropostaPacienteTipoPix = H005S2_A586PropostaPacienteTipoPix[0];
            n586PropostaPacienteTipoPix = H005S2_n586PropostaPacienteTipoPix[0];
            A587PropostaPacientePIX = H005S2_A587PropostaPacientePIX[0];
            n587PropostaPacientePIX = H005S2_n587PropostaPacientePIX[0];
            A588PropostaPacienteDepositoTipo = H005S2_A588PropostaPacienteDepositoTipo[0];
            n588PropostaPacienteDepositoTipo = H005S2_n588PropostaPacienteDepositoTipo[0];
            A505PropostaPacienteClienteRazaoSocial = H005S2_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = H005S2_n505PropostaPacienteClienteRazaoSocial[0];
            A540PropostaPacienteClienteDocumento = H005S2_A540PropostaPacienteClienteDocumento[0];
            n540PropostaPacienteClienteDocumento = H005S2_n540PropostaPacienteClienteDocumento[0];
            A541PropostaPacienteContatoEmail = H005S2_A541PropostaPacienteContatoEmail[0];
            n541PropostaPacienteContatoEmail = H005S2_n541PropostaPacienteContatoEmail[0];
            A410ConvenioId = H005S2_A410ConvenioId[0];
            n410ConvenioId = H005S2_n410ConvenioId[0];
            A494ConvenioCategoriaDescricao = H005S2_A494ConvenioCategoriaDescricao[0];
            n494ConvenioCategoriaDescricao = H005S2_n494ConvenioCategoriaDescricao[0];
            A411ConvenioDescricao = H005S2_A411ConvenioDescricao[0];
            n411ConvenioDescricao = H005S2_n411ConvenioDescricao[0];
            AV56ClinicaClienteDocumento = A652PropostaClinicaDocumento;
            AssignAttri("", false, "AV56ClinicaClienteDocumento", AV56ClinicaClienteDocumento);
            AV55ClinicaClienteRazaoSocial = A643PropostaClinicaNome;
            AssignAttri("", false, "AV55ClinicaClienteRazaoSocial", AV55ClinicaClienteRazaoSocial);
            AV57ClinicaContatoEmail = A653PropostaClinicaEmail;
            AssignAttri("", false, "AV57ClinicaContatoEmail", AV57ClinicaContatoEmail);
            AV58PropostaClinicaId = A642PropostaClinicaId;
            AssignAttri("", false, "AV58PropostaClinicaId", StringUtil.LTrimStr( (decimal)(AV58PropostaClinicaId), 9, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTACLINICAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV58PropostaClinicaId), "ZZZZZZZZ9"), context));
            if ( ( A504PropostaPacienteClienteId == A553PropostaResponsavelId ) || H005S2_n553PropostaResponsavelId[0] || (0==A553PropostaResponsavelId) )
            {
               divTablecontentresponsavel_Visible = 0;
               AssignProp("", false, divTablecontentresponsavel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablecontentresponsavel_Visible), 5, 0), true);
               AV42BancoNome = A589PropostaResponsavelBanco;
               AssignAttri("", false, "AV42BancoNome", AV42BancoNome);
               AV22ContaNumero = A590PropostaResponsavelConta;
               AssignAttri("", false, "AV22ContaNumero", AV22ContaNumero);
               AV21ContaAgencia = A591PropostaResponsavelAgencia;
               AssignAttri("", false, "AV21ContaAgencia", AV21ContaAgencia);
               AV18ClientePixTipo = A592PropostaResponsavelTipoPix;
               AssignAttri("", false, "AV18ClientePixTipo", AV18ClientePixTipo);
               AV19ClientePix = A593PropostaResponsavelPIX;
               AssignAttri("", false, "AV19ClientePix", AV19ClientePix);
               AV48ClienteDepositoTipo = A594PropostaResponsavelDepositoTipo;
            }
            else
            {
               AV42BancoNome = A583PropostaPacienteBanco;
               AssignAttri("", false, "AV42BancoNome", AV42BancoNome);
               AV22ContaNumero = A584PropostaPacienteConta;
               AssignAttri("", false, "AV22ContaNumero", AV22ContaNumero);
               AV21ContaAgencia = A585PropostaPacienteAgencia;
               AssignAttri("", false, "AV21ContaAgencia", AV21ContaAgencia);
               AV18ClientePixTipo = A586PropostaPacienteTipoPix;
               AssignAttri("", false, "AV18ClientePixTipo", AV18ClientePixTipo);
               AV19ClientePix = A587PropostaPacientePIX;
               AssignAttri("", false, "AV19ClientePix", AV19ClientePix);
               AV48ClienteDepositoTipo = A588PropostaPacienteDepositoTipo;
            }
            AV26ClienteRazaoSocial = A505PropostaPacienteClienteRazaoSocial;
            AssignAttri("", false, "AV26ClienteRazaoSocial", AV26ClienteRazaoSocial);
            AV27ClienteDocumento = A540PropostaPacienteClienteDocumento;
            AssignAttri("", false, "AV27ClienteDocumento", AV27ClienteDocumento);
            AV28ContatoEmail = A541PropostaPacienteContatoEmail;
            AssignAttri("", false, "AV28ContatoEmail", AV28ContatoEmail);
            AV24ResponsavelClienteDocumento = A580PropostaResponsavelDocumento;
            AssignAttri("", false, "AV24ResponsavelClienteDocumento", AV24ResponsavelClienteDocumento);
            AV23ResponsavelClienteRazaoSocial = A581PropostaResponsavelRazaoSocial;
            AssignAttri("", false, "AV23ResponsavelClienteRazaoSocial", AV23ResponsavelClienteRazaoSocial);
            AV25ResponsavelContatoEmail = A582PropostaResponsavelEmail;
            AssignAttri("", false, "AV25ResponsavelContatoEmail", AV25ResponsavelContatoEmail);
            AV43ProcedimentosMedicosDescricao = A378ProcedimentosMedicosDescricao;
            AssignAttri("", false, "AV43ProcedimentosMedicosDescricao", AV43ProcedimentosMedicosDescricao);
            AV12PropostaValor = A326PropostaValor;
            AssignAttri("", false, "AV12PropostaValor", StringUtil.LTrimStr( AV12PropostaValor, 18, 2));
            AV13PropostaDescricao = A325PropostaDescricao;
            AssignAttri("", false, "AV13PropostaDescricao", AV13PropostaDescricao);
            AV45ConvenioCategoriaDescricao = A494ConvenioCategoriaDescricao;
            AssignAttri("", false, "AV45ConvenioCategoriaDescricao", AV45ConvenioCategoriaDescricao);
            AV15ConvenioCategoriaId = A493ConvenioCategoriaId;
            AV44ConvenioDescricao = A411ConvenioDescricao;
            AssignAttri("", false, "AV44ConvenioDescricao", AV44ConvenioDescricao);
            AV16ConvenioVencimentoAno = A496ConvenioVencimentoAno;
            AssignAttri("", false, "AV16ConvenioVencimentoAno", StringUtil.LTrimStr( (decimal)(AV16ConvenioVencimentoAno), 4, 0));
            AV17ConvenioVencimentoMes = A497ConvenioVencimentoMes;
            AssignAttri("", false, "AV17ConvenioVencimentoMes", StringUtil.LTrimStr( (decimal)(AV17ConvenioVencimentoMes), 4, 0));
            AV46PropostaPacienteClienteId = A504PropostaPacienteClienteId;
            AssignAttri("", false, "AV46PropostaPacienteClienteId", StringUtil.LTrimStr( (decimal)(AV46PropostaPacienteClienteId), 9, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAPACIENTECLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV46PropostaPacienteClienteId), "ZZZZZZZZ9"), context));
            AV47PropostaResponsavelId = A553PropostaResponsavelId;
            AssignAttri("", false, "AV47PropostaResponsavelId", StringUtil.LTrimStr( (decimal)(AV47PropostaResponsavelId), 9, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTARESPONSAVELID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV47PropostaResponsavelId), "ZZZZZZZZ9"), context));
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         Griddocumentos_empowerer_Gridinternalname = subGriddocumentos_Internalname;
         ucGriddocumentos_empowerer.SendProperty(context, "", false, Griddocumentos_empowerer_Internalname, "GridInternalName", Griddocumentos_empowerer_Gridinternalname);
         subGriddocumentos_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRIDDOCUMENTOS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddocumentos_Rows), 6, 0, ".", "")));
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wcwctitulosproposta = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcwctitulosproposta_Component), StringUtil.Lower( "WCTitulosProposta")) != 0 )
         {
            WebComp_Wcwctitulosproposta = getWebComponent(GetType(), "GeneXus.Programs", "wctitulosproposta", new Object[] {context} );
            WebComp_Wcwctitulosproposta.ComponentInit();
            WebComp_Wcwctitulosproposta.Name = "WCTitulosProposta";
            WebComp_Wcwctitulosproposta_Component = "WCTitulosProposta";
         }
         if ( StringUtil.Len( WebComp_Wcwctitulosproposta_Component) != 0 )
         {
            WebComp_Wcwctitulosproposta.setjustcreated();
            WebComp_Wcwctitulosproposta.componentprepare(new Object[] {(string)"W0183",(string)"",(int)AV5PropostaId,(bool)false});
            WebComp_Wcwctitulosproposta.componentbind(new Object[] {(string)"",(string)""});
         }
      }

      protected void E155S2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         cmbavPropostadocumentosstatus_Columnheaderclass = "WWColumn";
         AssignProp("", false, cmbavPropostadocumentosstatus_Internalname, "Columnheaderclass", cmbavPropostadocumentosstatus_Columnheaderclass, !bGXsfl_166_Refreshing);
         /*  Sending Event outputs  */
      }

      private void E165S2( )
      {
         /* Griddocumentos_Load Routine */
         returnInSub = false;
         /* Using cursor H005S3 */
         pr_default.execute(1, new Object[] {AV5PropostaId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A323PropostaId = H005S3_A323PropostaId[0];
            n323PropostaId = H005S3_n323PropostaId[0];
            A406DocumentosDescricao = H005S3_A406DocumentosDescricao[0];
            n406DocumentosDescricao = H005S3_n406DocumentosDescricao[0];
            A405DocumentosId = H005S3_A405DocumentosId[0];
            n405DocumentosId = H005S3_n405DocumentosId[0];
            A417PropostaDocumentosAnexoFileType = H005S3_A417PropostaDocumentosAnexoFileType[0];
            n417PropostaDocumentosAnexoFileType = H005S3_n417PropostaDocumentosAnexoFileType[0];
            A579PropostaDocumentosStatus = H005S3_A579PropostaDocumentosStatus[0];
            n579PropostaDocumentosStatus = H005S3_n579PropostaDocumentosStatus[0];
            A416PropostaDocumentosAnexoName = H005S3_A416PropostaDocumentosAnexoName[0];
            n416PropostaDocumentosAnexoName = H005S3_n416PropostaDocumentosAnexoName[0];
            A414PropostaDocumentosId = H005S3_A414PropostaDocumentosId[0];
            A415PropostaDocumentosAnexo = H005S3_A415PropostaDocumentosAnexo[0];
            n415PropostaDocumentosAnexo = H005S3_n415PropostaDocumentosAnexo[0];
            A406DocumentosDescricao = H005S3_A406DocumentosDescricao[0];
            n406DocumentosDescricao = H005S3_n406DocumentosDescricao[0];
            AV37DocumentosDescricao = A406DocumentosDescricao;
            AssignAttri("", false, edtavDocumentosdescricao_Internalname, AV37DocumentosDescricao);
            AV36DocumentosId = A405DocumentosId;
            AssignAttri("", false, edtavDocumentosid_Internalname, StringUtil.LTrimStr( (decimal)(AV36DocumentosId), 9, 0));
            AV39Documento = A415PropostaDocumentosAnexo;
            AssignAttri("", false, edtavDocumento_Internalname, AV39Documento);
            AV40Extensao = A417PropostaDocumentosAnexoFileType;
            AssignAttri("", false, edtavExtensao_Internalname, AV40Extensao);
            AV41PropostaDocumentosStatus = A579PropostaDocumentosStatus;
            AssignAttri("", false, cmbavPropostadocumentosstatus_Internalname, AV41PropostaDocumentosStatus);
            AV49PropostaDocumentosAnexoName = A416PropostaDocumentosAnexoName;
            AssignAttri("", false, edtavPropostadocumentosanexoname_Internalname, AV49PropostaDocumentosAnexoName);
            AV54PropostaDocumentosId = A414PropostaDocumentosId;
            AssignAttri("", false, edtavPropostadocumentosid_Internalname, StringUtil.LTrimStr( (decimal)(AV54PropostaDocumentosId), 9, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTADOCUMENTOSID"+"_"+sGXsfl_166_idx, GetSecureSignedToken( sGXsfl_166_idx, context.localUtil.Format( (decimal)(AV54PropostaDocumentosId), "ZZZZZZZZ9"), context));
            AV29AdicionarAnexo = "<i class=\"fas fa-download\"></i>";
            AssignAttri("", false, edtavAdicionaranexo_Internalname, AV29AdicionarAnexo);
            if ( StringUtil.StrCmp(AV41PropostaDocumentosStatus, "AGUARDANDO_ANALISE") == 0 )
            {
               cmbavPropostadocumentosstatus_Columnclass = "WWColumn WWColumnTag WWColumnTagInfo WWColumnTagInfoSingleCell";
            }
            else if ( StringUtil.StrCmp(AV41PropostaDocumentosStatus, "APROVADO") == 0 )
            {
               cmbavPropostadocumentosstatus_Columnclass = "WWColumn WWColumnTag WWColumnTagSuccess WWColumnTagSuccessSingleCell";
            }
            else if ( StringUtil.StrCmp(AV41PropostaDocumentosStatus, "REPROVADO") == 0 )
            {
               cmbavPropostadocumentosstatus_Columnclass = "WWColumn WWColumnTag WWColumnTagDanger WWColumnTagDangerSingleCell";
            }
            else
            {
               cmbavPropostadocumentosstatus_Columnclass = "WWColumn";
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 166;
            }
            if ( ( subGriddocumentos_Islastpage == 1 ) || ( subGriddocumentos_Rows == 0 ) || ( ( GRIDDOCUMENTOS_nCurrentRecord >= GRIDDOCUMENTOS_nFirstRecordOnPage ) && ( GRIDDOCUMENTOS_nCurrentRecord < GRIDDOCUMENTOS_nFirstRecordOnPage + subGriddocumentos_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_1662( ) ;
            }
            GRIDDOCUMENTOS_nEOF = (short)(((GRIDDOCUMENTOS_nCurrentRecord<GRIDDOCUMENTOS_nFirstRecordOnPage+subGriddocumentos_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRIDDOCUMENTOS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDDOCUMENTOS_nEOF), 1, 0, ".", "")));
            GRIDDOCUMENTOS_nCurrentRecord = (long)(GRIDDOCUMENTOS_nCurrentRecord+1);
            subGriddocumentos_Recordcount = (int)(GRIDDOCUMENTOS_nCurrentRecord);
            if ( isFullAjaxMode( ) && ! bGXsfl_166_Refreshing )
            {
               DoAjaxLoad(166, GriddocumentosRow);
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         /*  Sending Event outputs  */
         cmbavPropostadocumentosstatus.CurrentValue = StringUtil.RTrim( AV41PropostaDocumentosStatus);
      }

      protected void E115S2( )
      {
         /* 'DoConsultarResponsavel' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wcliente"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(AV47PropostaResponsavelId,9,0));
         CallWebObject(formatLink("wcliente") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E125S2( )
      {
         /* 'DoConsultarCliente' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wcliente"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(AV46PropostaPacienteClienteId,9,0));
         CallWebObject(formatLink("wcliente") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E135S2( )
      {
         /* 'DoConsultarClinica' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wcliente"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(AV58PropostaClinicaId,9,0));
         CallWebObject(formatLink("wcliente") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E175S2( )
      {
         /* Adicionaranexo_Click Routine */
         returnInSub = false;
         AV53PropostaDocumentos = new SdtPropostaDocumentos(context);
         AV53PropostaDocumentos.Load(AV54PropostaDocumentosId);
         AV50GUID = Guid.NewGuid( );
         AV51Source = "./PrivateTempStorage/" + StringUtil.Trim( AV50GUID.ToString()) + ".pdf";
         AV52File = new GxFile(context.GetPhysicalPath());
         AV52File.Source = AV51Source;
         AV52File.FromBase64(context.FileToBase64( AV53PropostaDocumentos.gxTpr_Propostadocumentosanexo));
         AV52File.Create();
         Novajanela_Target = AV51Source;
         ucNovajanela.SendProperty(context, "", false, Novajanela_Internalname, "Target", Novajanela_Target);
         this.executeUsercontrolMethod("", false, "NOVAJANELAContainer", "OpenWindow", "", new Object[] {});
         /*  Sending Event outputs  */
      }

      protected void wb_table1_151_5S2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedconveniovencimentoano_Internalname, tblTablemergedconveniovencimentoano_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavConveniovencimentoano_Internalname, "Convenio Vencimento Ano", "gx-form-item AttributeFLLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 155,'',false,'" + sGXsfl_166_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavConveniovencimentoano, cmbavConveniovencimentoano_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV16ConvenioVencimentoAno), 4, 0)), 1, cmbavConveniovencimentoano_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavConveniovencimentoano.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,155);\"", "", true, 0, "HLP_WpConsultaProposta.htm");
            cmbavConveniovencimentoano.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16ConvenioVencimentoAno), 4, 0));
            AssignProp("", false, cmbavConveniovencimentoano_Internalname, "Values", (string)(cmbavConveniovencimentoano.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCellFL'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+cmbavConveniovencimentomes_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavConveniovencimentomes_Internalname, "Mês vencimento carteira", "gx-form-item AttributeFLLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 159,'',false,'" + sGXsfl_166_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavConveniovencimentomes, cmbavConveniovencimentomes_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV17ConvenioVencimentoMes), 4, 0)), 1, cmbavConveniovencimentomes_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavConveniovencimentomes.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,159);\"", "", true, 0, "HLP_WpConsultaProposta.htm");
            cmbavConveniovencimentomes.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17ConvenioVencimentoMes), 4, 0));
            AssignProp("", false, cmbavConveniovencimentomes_Internalname, "Values", (string)(cmbavConveniovencimentomes.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_151_5S2e( true) ;
         }
         else
         {
            wb_table1_151_5S2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV5PropostaId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV5PropostaId", StringUtil.LTrimStr( (decimal)(AV5PropostaId), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5PropostaId), "ZZZZZZZZ9"), context));
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
         PA5S2( ) ;
         WS5S2( ) ;
         WE5S2( ) ;
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
         if ( ! ( WebComp_Wcwctitulosproposta == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcwctitulosproposta_Component) != 0 )
            {
               WebComp_Wcwctitulosproposta.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019252550", true, true);
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
         context.AddJavascriptSource("wpconsultaproposta.js", "?202561019252550", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1662( )
      {
         edtavAdicionaranexo_Internalname = "vADICIONARANEXO_"+sGXsfl_166_idx;
         edtavDocumentosid_Internalname = "vDOCUMENTOSID_"+sGXsfl_166_idx;
         edtavDocumentosdescricao_Internalname = "vDOCUMENTOSDESCRICAO_"+sGXsfl_166_idx;
         cmbavDocumentoobrigatorio_Internalname = "vDOCUMENTOOBRIGATORIO_"+sGXsfl_166_idx;
         edtavPropostadocumentosanexoname_Internalname = "vPROPOSTADOCUMENTOSANEXONAME_"+sGXsfl_166_idx;
         edtavDocumento_Internalname = "vDOCUMENTO_"+sGXsfl_166_idx;
         edtavExtensao_Internalname = "vEXTENSAO_"+sGXsfl_166_idx;
         cmbavPropostadocumentosstatus_Internalname = "vPROPOSTADOCUMENTOSSTATUS_"+sGXsfl_166_idx;
         edtavPropostadocumentosid_Internalname = "vPROPOSTADOCUMENTOSID_"+sGXsfl_166_idx;
      }

      protected void SubsflControlProps_fel_1662( )
      {
         edtavAdicionaranexo_Internalname = "vADICIONARANEXO_"+sGXsfl_166_fel_idx;
         edtavDocumentosid_Internalname = "vDOCUMENTOSID_"+sGXsfl_166_fel_idx;
         edtavDocumentosdescricao_Internalname = "vDOCUMENTOSDESCRICAO_"+sGXsfl_166_fel_idx;
         cmbavDocumentoobrigatorio_Internalname = "vDOCUMENTOOBRIGATORIO_"+sGXsfl_166_fel_idx;
         edtavPropostadocumentosanexoname_Internalname = "vPROPOSTADOCUMENTOSANEXONAME_"+sGXsfl_166_fel_idx;
         edtavDocumento_Internalname = "vDOCUMENTO_"+sGXsfl_166_fel_idx;
         edtavExtensao_Internalname = "vEXTENSAO_"+sGXsfl_166_fel_idx;
         cmbavPropostadocumentosstatus_Internalname = "vPROPOSTADOCUMENTOSSTATUS_"+sGXsfl_166_fel_idx;
         edtavPropostadocumentosid_Internalname = "vPROPOSTADOCUMENTOSID_"+sGXsfl_166_fel_idx;
      }

      protected void sendrow_1662( )
      {
         sGXsfl_166_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_166_idx), 4, 0), 4, "0");
         SubsflControlProps_1662( ) ;
         WB5S0( ) ;
         if ( ( subGriddocumentos_Rows * 1 == 0 ) || ( nGXsfl_166_idx <= subGriddocumentos_fnc_Recordsperpage( ) * 1 ) )
         {
            GriddocumentosRow = GXWebRow.GetNew(context,GriddocumentosContainer);
            if ( subGriddocumentos_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGriddocumentos_Backstyle = 0;
               if ( StringUtil.StrCmp(subGriddocumentos_Class, "") != 0 )
               {
                  subGriddocumentos_Linesclass = subGriddocumentos_Class+"Odd";
               }
            }
            else if ( subGriddocumentos_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGriddocumentos_Backstyle = 0;
               subGriddocumentos_Backcolor = subGriddocumentos_Allbackcolor;
               if ( StringUtil.StrCmp(subGriddocumentos_Class, "") != 0 )
               {
                  subGriddocumentos_Linesclass = subGriddocumentos_Class+"Uniform";
               }
            }
            else if ( subGriddocumentos_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGriddocumentos_Backstyle = 1;
               if ( StringUtil.StrCmp(subGriddocumentos_Class, "") != 0 )
               {
                  subGriddocumentos_Linesclass = subGriddocumentos_Class+"Odd";
               }
               subGriddocumentos_Backcolor = (int)(0x0);
            }
            else if ( subGriddocumentos_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGriddocumentos_Backstyle = 1;
               if ( ((int)((nGXsfl_166_idx) % (2))) == 0 )
               {
                  subGriddocumentos_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGriddocumentos_Class, "") != 0 )
                  {
                     subGriddocumentos_Linesclass = subGriddocumentos_Class+"Even";
                  }
               }
               else
               {
                  subGriddocumentos_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGriddocumentos_Class, "") != 0 )
                  {
                     subGriddocumentos_Linesclass = subGriddocumentos_Class+"Odd";
                  }
               }
            }
            if ( GriddocumentosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithBorderColor WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_166_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GriddocumentosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 167,'',false,'" + sGXsfl_166_idx + "',166)\"";
            ROClassString = "Attribute";
            GriddocumentosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavAdicionaranexo_Internalname,StringUtil.RTrim( AV29AdicionarAnexo),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,167);\"","'"+""+"'"+",false,"+"'"+"EVADICIONARANEXO.CLICK."+sGXsfl_166_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavAdicionaranexo_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavAdicionaranexo_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)166,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GriddocumentosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GriddocumentosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDocumentosid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV36DocumentosId), 9, 0, ",", "")),StringUtil.LTrim( ((edtavDocumentosid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV36DocumentosId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV36DocumentosId), "ZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDocumentosid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavDocumentosid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)166,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GriddocumentosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 169,'',false,'" + sGXsfl_166_idx + "',166)\"";
            ROClassString = "Attribute";
            GriddocumentosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDocumentosdescricao_Internalname,(string)AV37DocumentosDescricao,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,169);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDocumentosdescricao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavDocumentosdescricao_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)166,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GriddocumentosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( cmbavDocumentoobrigatorio.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vDOCUMENTOOBRIGATORIO_" + sGXsfl_166_idx;
               cmbavDocumentoobrigatorio.Name = GXCCtl;
               cmbavDocumentoobrigatorio.WebTags = "";
               cmbavDocumentoobrigatorio.addItem(StringUtil.BoolToStr( true), "Sim", 0);
               cmbavDocumentoobrigatorio.addItem(StringUtil.BoolToStr( false), "Não", 0);
               if ( cmbavDocumentoobrigatorio.ItemCount > 0 )
               {
                  AV38DocumentoObrigatorio = StringUtil.StrToBool( cmbavDocumentoobrigatorio.getValidValue(StringUtil.BoolToStr( AV38DocumentoObrigatorio)));
                  AssignAttri("", false, cmbavDocumentoobrigatorio_Internalname, AV38DocumentoObrigatorio);
               }
            }
            /* ComboBox */
            GriddocumentosRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavDocumentoobrigatorio,(string)cmbavDocumentoobrigatorio_Internalname,StringUtil.BoolToStr( AV38DocumentoObrigatorio),(short)1,(string)cmbavDocumentoobrigatorio_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"boolean",(string)"",(short)0,cmbavDocumentoobrigatorio.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"",(bool)true,(short)0});
            cmbavDocumentoobrigatorio.CurrentValue = StringUtil.BoolToStr( AV38DocumentoObrigatorio);
            AssignProp("", false, cmbavDocumentoobrigatorio_Internalname, "Values", (string)(cmbavDocumentoobrigatorio.ToJavascriptSource()), !bGXsfl_166_Refreshing);
            /* Subfile cell */
            if ( GriddocumentosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 171,'',false,'" + sGXsfl_166_idx + "',166)\"";
            ROClassString = "Attribute";
            GriddocumentosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavPropostadocumentosanexoname_Internalname,(string)AV49PropostaDocumentosAnexoName,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,171);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavPropostadocumentosanexoname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavPropostadocumentosanexoname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)128,(short)0,(short)0,(short)166,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GriddocumentosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            ClassString = "Attribute";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 172,'',false,'" + sGXsfl_166_idx + "',166)\"";
            edtavDocumento_Filetype = "tmp";
            AssignProp("", false, edtavDocumento_Internalname, "Filetype", edtavDocumento_Filetype, !bGXsfl_166_Refreshing);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39Documento)) )
            {
               gxblobfileaux.Source = AV39Documento;
               if ( ! gxblobfileaux.HasExtension() || ( StringUtil.StrCmp(edtavDocumento_Filetype, "tmp") != 0 ) )
               {
                  gxblobfileaux.SetExtension(StringUtil.Trim( edtavDocumento_Filetype));
               }
               if ( gxblobfileaux.ErrCode == 0 )
               {
                  AV39Documento = gxblobfileaux.GetURI();
                  AssignProp("", false, edtavDocumento_Internalname, "URL", context.PathToRelativeUrl( AV39Documento), !bGXsfl_166_Refreshing);
                  edtavDocumento_Filetype = gxblobfileaux.GetExtension();
                  AssignProp("", false, edtavDocumento_Internalname, "Filetype", edtavDocumento_Filetype, !bGXsfl_166_Refreshing);
               }
               AssignProp("", false, edtavDocumento_Internalname, "URL", context.PathToRelativeUrl( AV39Documento), !bGXsfl_166_Refreshing);
            }
            GriddocumentosRow.AddColumnProperties("blob", 2, isAjaxCallMode( ), new Object[] {(string)edtavDocumento_Internalname,StringUtil.RTrim( AV39Documento),context.PathToRelativeUrl( AV39Documento),(String.IsNullOrEmpty(StringUtil.RTrim( edtavDocumento_Contenttype)) ? context.GetContentType( (String.IsNullOrEmpty(StringUtil.RTrim( edtavDocumento_Filetype)) ? AV39Documento : edtavDocumento_Filetype)) : edtavDocumento_Contenttype),(bool)false,(string)"",(string)edtavDocumento_Parameters,(short)0,(int)edtavDocumento_Enabled,(short)-1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)60,(string)"px",(short)0,(short)0,(short)0,(string)edtavDocumento_Jsonclick,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",""+TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,172);\"",(string)"",(string)""});
            /* Subfile cell */
            if ( GriddocumentosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 173,'',false,'" + sGXsfl_166_idx + "',166)\"";
            ROClassString = "Attribute";
            GriddocumentosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavExtensao_Internalname,(string)AV40Extensao,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,173);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavExtensao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavExtensao_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)166,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GriddocumentosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 174,'',false,'" + sGXsfl_166_idx + "',166)\"";
            if ( ( cmbavPropostadocumentosstatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vPROPOSTADOCUMENTOSSTATUS_" + sGXsfl_166_idx;
               cmbavPropostadocumentosstatus.Name = GXCCtl;
               cmbavPropostadocumentosstatus.WebTags = "";
               cmbavPropostadocumentosstatus.addItem("AGUARDANDO_ANALISE", "Aguardando análise", 0);
               cmbavPropostadocumentosstatus.addItem("APROVADO", "Aprovado", 0);
               cmbavPropostadocumentosstatus.addItem("REPROVADO", "Reprovado", 0);
               if ( cmbavPropostadocumentosstatus.ItemCount > 0 )
               {
                  AV41PropostaDocumentosStatus = cmbavPropostadocumentosstatus.getValidValue(AV41PropostaDocumentosStatus);
                  AssignAttri("", false, cmbavPropostadocumentosstatus_Internalname, AV41PropostaDocumentosStatus);
               }
            }
            /* ComboBox */
            GriddocumentosRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavPropostadocumentosstatus,(string)cmbavPropostadocumentosstatus_Internalname,StringUtil.RTrim( AV41PropostaDocumentosStatus),(short)1,(string)cmbavPropostadocumentosstatus_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,cmbavPropostadocumentosstatus.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)cmbavPropostadocumentosstatus_Columnclass,(string)cmbavPropostadocumentosstatus_Columnheaderclass,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,174);\"",(string)"",(bool)true,(short)0});
            cmbavPropostadocumentosstatus.CurrentValue = StringUtil.RTrim( AV41PropostaDocumentosStatus);
            AssignProp("", false, cmbavPropostadocumentosstatus_Internalname, "Values", (string)(cmbavPropostadocumentosstatus.ToJavascriptSource()), !bGXsfl_166_Refreshing);
            /* Subfile cell */
            if ( GriddocumentosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GriddocumentosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavPropostadocumentosid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV54PropostaDocumentosId), 9, 0, ",", "")),StringUtil.LTrim( ((edtavPropostadocumentosid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV54PropostaDocumentosId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV54PropostaDocumentosId), "ZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavPropostadocumentosid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavPropostadocumentosid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)166,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes5S2( ) ;
            GriddocumentosContainer.AddRow(GriddocumentosRow);
            nGXsfl_166_idx = ((subGriddocumentos_Islastpage==1)&&(nGXsfl_166_idx+1>subGriddocumentos_fnc_Recordsperpage( )) ? 1 : nGXsfl_166_idx+1);
            sGXsfl_166_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_166_idx), 4, 0), 4, "0");
            SubsflControlProps_1662( ) ;
         }
         /* End function sendrow_1662 */
      }

      protected void init_web_controls( )
      {
         cmbavClientepixtipo.Name = "vCLIENTEPIXTIPO";
         cmbavClientepixtipo.WebTags = "";
         cmbavClientepixtipo.addItem("CPF", "CPF", 0);
         cmbavClientepixtipo.addItem("CNPJ", "CNPJ", 0);
         cmbavClientepixtipo.addItem("Telefone", "Telefone", 0);
         cmbavClientepixtipo.addItem("Email", "E-mail", 0);
         cmbavClientepixtipo.addItem("ChaveAleatoria", "Chave aleatória", 0);
         if ( cmbavClientepixtipo.ItemCount > 0 )
         {
            AV18ClientePixTipo = cmbavClientepixtipo.getValidValue(AV18ClientePixTipo);
            AssignAttri("", false, "AV18ClientePixTipo", AV18ClientePixTipo);
         }
         cmbavConveniovencimentoano.Name = "vCONVENIOVENCIMENTOANO";
         cmbavConveniovencimentoano.WebTags = "";
         cmbavConveniovencimentoano.addItem("2024", "2024", 0);
         cmbavConveniovencimentoano.addItem("2025", "2025", 0);
         cmbavConveniovencimentoano.addItem("2026", "2026", 0);
         cmbavConveniovencimentoano.addItem("2027", "2027", 0);
         cmbavConveniovencimentoano.addItem("2028", "2028", 0);
         cmbavConveniovencimentoano.addItem("2029", "2029", 0);
         cmbavConveniovencimentoano.addItem("2030", "2030", 0);
         cmbavConveniovencimentoano.addItem("2031", "2031", 0);
         cmbavConveniovencimentoano.addItem("2032", "2032", 0);
         cmbavConveniovencimentoano.addItem("2033", "2033", 0);
         cmbavConveniovencimentoano.addItem("2034", "2034", 0);
         cmbavConveniovencimentoano.addItem("2035", "2035", 0);
         cmbavConveniovencimentoano.addItem("2036", "2036", 0);
         cmbavConveniovencimentoano.addItem("2037", "2037", 0);
         cmbavConveniovencimentoano.addItem("2038", "2038", 0);
         cmbavConveniovencimentoano.addItem("2039", "2039", 0);
         cmbavConveniovencimentoano.addItem("2040", "2040", 0);
         cmbavConveniovencimentoano.addItem("2041", "2041", 0);
         cmbavConveniovencimentoano.addItem("2042", "2042", 0);
         cmbavConveniovencimentoano.addItem("2043", "2043", 0);
         cmbavConveniovencimentoano.addItem("2044", "2044", 0);
         cmbavConveniovencimentoano.addItem("2045", "2045", 0);
         cmbavConveniovencimentoano.addItem("2046", "2046", 0);
         cmbavConveniovencimentoano.addItem("2047", "2047", 0);
         cmbavConveniovencimentoano.addItem("2048", "2048", 0);
         cmbavConveniovencimentoano.addItem("2049", "2049", 0);
         cmbavConveniovencimentoano.addItem("2050", "2050", 0);
         if ( cmbavConveniovencimentoano.ItemCount > 0 )
         {
            AV16ConvenioVencimentoAno = (short)(Math.Round(NumberUtil.Val( cmbavConveniovencimentoano.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV16ConvenioVencimentoAno), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV16ConvenioVencimentoAno", StringUtil.LTrimStr( (decimal)(AV16ConvenioVencimentoAno), 4, 0));
         }
         cmbavConveniovencimentomes.Name = "vCONVENIOVENCIMENTOMES";
         cmbavConveniovencimentomes.WebTags = "";
         cmbavConveniovencimentomes.addItem("1", "Janeiro", 0);
         cmbavConveniovencimentomes.addItem("2", "Fevereiro", 0);
         cmbavConveniovencimentomes.addItem("3", "Maço", 0);
         cmbavConveniovencimentomes.addItem("4", "Abril", 0);
         cmbavConveniovencimentomes.addItem("5", "Maio", 0);
         cmbavConveniovencimentomes.addItem("6", "Junho", 0);
         cmbavConveniovencimentomes.addItem("7", "Julho", 0);
         cmbavConveniovencimentomes.addItem("8", "Agosto", 0);
         cmbavConveniovencimentomes.addItem("9", "Setembro", 0);
         cmbavConveniovencimentomes.addItem("10", "Outubro", 0);
         cmbavConveniovencimentomes.addItem("11", "Novembro", 0);
         cmbavConveniovencimentomes.addItem("12", "Dezembro", 0);
         if ( cmbavConveniovencimentomes.ItemCount > 0 )
         {
            AV17ConvenioVencimentoMes = (short)(Math.Round(NumberUtil.Val( cmbavConveniovencimentomes.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV17ConvenioVencimentoMes), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV17ConvenioVencimentoMes", StringUtil.LTrimStr( (decimal)(AV17ConvenioVencimentoMes), 4, 0));
         }
         GXCCtl = "vDOCUMENTOOBRIGATORIO_" + sGXsfl_166_idx;
         cmbavDocumentoobrigatorio.Name = GXCCtl;
         cmbavDocumentoobrigatorio.WebTags = "";
         cmbavDocumentoobrigatorio.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbavDocumentoobrigatorio.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbavDocumentoobrigatorio.ItemCount > 0 )
         {
            AV38DocumentoObrigatorio = StringUtil.StrToBool( cmbavDocumentoobrigatorio.getValidValue(StringUtil.BoolToStr( AV38DocumentoObrigatorio)));
            AssignAttri("", false, cmbavDocumentoobrigatorio_Internalname, AV38DocumentoObrigatorio);
         }
         GXCCtl = "vPROPOSTADOCUMENTOSSTATUS_" + sGXsfl_166_idx;
         cmbavPropostadocumentosstatus.Name = GXCCtl;
         cmbavPropostadocumentosstatus.WebTags = "";
         cmbavPropostadocumentosstatus.addItem("AGUARDANDO_ANALISE", "Aguardando análise", 0);
         cmbavPropostadocumentosstatus.addItem("APROVADO", "Aprovado", 0);
         cmbavPropostadocumentosstatus.addItem("REPROVADO", "Reprovado", 0);
         if ( cmbavPropostadocumentosstatus.ItemCount > 0 )
         {
            AV41PropostaDocumentosStatus = cmbavPropostadocumentosstatus.getValidValue(AV41PropostaDocumentosStatus);
            AssignAttri("", false, cmbavPropostadocumentosstatus_Internalname, AV41PropostaDocumentosStatus);
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl166( )
      {
         if ( GriddocumentosContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GriddocumentosContainer"+"DivS\" data-gxgridid=\"166\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGriddocumentos_Internalname, subGriddocumentos_Internalname, "", "GridWithBorderColor WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGriddocumentos_Backcolorstyle == 0 )
            {
               subGriddocumentos_Titlebackstyle = 0;
               if ( StringUtil.Len( subGriddocumentos_Class) > 0 )
               {
                  subGriddocumentos_Linesclass = subGriddocumentos_Class+"Title";
               }
            }
            else
            {
               subGriddocumentos_Titlebackstyle = 1;
               if ( subGriddocumentos_Backcolorstyle == 1 )
               {
                  subGriddocumentos_Titlebackcolor = subGriddocumentos_Allbackcolor;
                  if ( StringUtil.Len( subGriddocumentos_Class) > 0 )
                  {
                     subGriddocumentos_Linesclass = subGriddocumentos_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGriddocumentos_Class) > 0 )
                  {
                     subGriddocumentos_Linesclass = subGriddocumentos_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Documentos Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Descrição") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Obrigatório") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Nome do anexo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Situação") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Proposta Documentos Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GriddocumentosContainer.AddObjectProperty("GridName", "Griddocumentos");
         }
         else
         {
            GriddocumentosContainer.AddObjectProperty("GridName", "Griddocumentos");
            GriddocumentosContainer.AddObjectProperty("Header", subGriddocumentos_Header);
            GriddocumentosContainer.AddObjectProperty("Class", "GridWithBorderColor WorkWith");
            GriddocumentosContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GriddocumentosContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GriddocumentosContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddocumentos_Backcolorstyle), 1, 0, ".", "")));
            GriddocumentosContainer.AddObjectProperty("CmpContext", "");
            GriddocumentosContainer.AddObjectProperty("InMasterPage", "false");
            GriddocumentosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddocumentosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV29AdicionarAnexo)));
            GriddocumentosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavAdicionaranexo_Enabled), 5, 0, ".", "")));
            GriddocumentosContainer.AddColumnProperties(GriddocumentosColumn);
            GriddocumentosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddocumentosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV36DocumentosId), 9, 0, ".", ""))));
            GriddocumentosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDocumentosid_Enabled), 5, 0, ".", "")));
            GriddocumentosContainer.AddColumnProperties(GriddocumentosColumn);
            GriddocumentosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddocumentosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV37DocumentosDescricao));
            GriddocumentosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDocumentosdescricao_Enabled), 5, 0, ".", "")));
            GriddocumentosContainer.AddColumnProperties(GriddocumentosColumn);
            GriddocumentosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddocumentosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( AV38DocumentoObrigatorio)));
            GriddocumentosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavDocumentoobrigatorio.Enabled), 5, 0, ".", "")));
            GriddocumentosContainer.AddColumnProperties(GriddocumentosColumn);
            GriddocumentosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddocumentosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV49PropostaDocumentosAnexoName));
            GriddocumentosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavPropostadocumentosanexoname_Enabled), 5, 0, ".", "")));
            GriddocumentosContainer.AddColumnProperties(GriddocumentosColumn);
            GriddocumentosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddocumentosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV39Documento));
            GriddocumentosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDocumento_Enabled), 5, 0, ".", "")));
            GriddocumentosContainer.AddColumnProperties(GriddocumentosColumn);
            GriddocumentosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddocumentosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV40Extensao));
            GriddocumentosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavExtensao_Enabled), 5, 0, ".", "")));
            GriddocumentosContainer.AddColumnProperties(GriddocumentosColumn);
            GriddocumentosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddocumentosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV41PropostaDocumentosStatus));
            GriddocumentosColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbavPropostadocumentosstatus_Columnclass));
            GriddocumentosColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbavPropostadocumentosstatus_Columnheaderclass));
            GriddocumentosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavPropostadocumentosstatus.Enabled), 5, 0, ".", "")));
            GriddocumentosContainer.AddColumnProperties(GriddocumentosColumn);
            GriddocumentosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddocumentosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV54PropostaDocumentosId), 9, 0, ".", ""))));
            GriddocumentosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavPropostadocumentosid_Enabled), 5, 0, ".", "")));
            GriddocumentosContainer.AddColumnProperties(GriddocumentosColumn);
            GriddocumentosContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddocumentos_Selectedindex), 4, 0, ".", "")));
            GriddocumentosContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddocumentos_Allowselection), 1, 0, ".", "")));
            GriddocumentosContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddocumentos_Selectioncolor), 9, 0, ".", "")));
            GriddocumentosContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddocumentos_Allowhovering), 1, 0, ".", "")));
            GriddocumentosContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddocumentos_Hoveringcolor), 9, 0, ".", "")));
            GriddocumentosContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddocumentos_Allowcollapsing), 1, 0, ".", "")));
            GriddocumentosContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddocumentos_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblTab1_title_Internalname = "TAB1_TITLE";
         lblConsultarclinica_Internalname = "CONSULTARCLINICA";
         edtavClinicaclienterazaosocial_Internalname = "vCLINICACLIENTERAZAOSOCIAL";
         edtavClinicaclientedocumento_Internalname = "vCLINICACLIENTEDOCUMENTO";
         edtavClinicacontatoemail_Internalname = "vCLINICACONTATOEMAIL";
         divTableclinica_Internalname = "TABLECLINICA";
         grpUnnamedgroup3_Internalname = "UNNAMEDGROUP3";
         lblConsultarcliente_Internalname = "CONSULTARCLIENTE";
         edtavClienterazaosocial_Internalname = "vCLIENTERAZAOSOCIAL";
         edtavClientedocumento_Internalname = "vCLIENTEDOCUMENTO";
         edtavContatoemail_Internalname = "vCONTATOEMAIL";
         divTablecliente_Internalname = "TABLECLIENTE";
         grpUnnamedgroup4_Internalname = "UNNAMEDGROUP4";
         lblConsultarresponsavel_Internalname = "CONSULTARRESPONSAVEL";
         edtavResponsavelclienterazaosocial_Internalname = "vRESPONSAVELCLIENTERAZAOSOCIAL";
         edtavResponsavelclientedocumento_Internalname = "vRESPONSAVELCLIENTEDOCUMENTO";
         edtavResponsavelcontatoemail_Internalname = "vRESPONSAVELCONTATOEMAIL";
         divTablerespnosavel_Internalname = "TABLERESPNOSAVEL";
         grpUnnamedgroup8_Internalname = "UNNAMEDGROUP8";
         divTablecontentresponsavel_Internalname = "TABLECONTENTRESPONSAVEL";
         edtavBanconome_Internalname = "vBANCONOME";
         edtavContaagencia_Internalname = "vCONTAAGENCIA";
         edtavContanumero_Internalname = "vCONTANUMERO";
         divTablebanco_Internalname = "TABLEBANCO";
         cmbavClientepixtipo_Internalname = "vCLIENTEPIXTIPO";
         edtavClientepix_Internalname = "vCLIENTEPIX";
         divTablepix_Internalname = "TABLEPIX";
         divTableconta_Internalname = "TABLECONTA";
         grpUnnamedgroup5_Internalname = "UNNAMEDGROUP5";
         edtavProcedimentosmedicosdescricao_Internalname = "vPROCEDIMENTOSMEDICOSDESCRICAO";
         edtavPropostavalor_Internalname = "vPROPOSTAVALOR";
         edtavPropostadescricao_Internalname = "vPROPOSTADESCRICAO";
         edtavConveniodescricao_Internalname = "vCONVENIODESCRICAO";
         edtavConveniocategoriadescricao_Internalname = "vCONVENIOCATEGORIADESCRICAO";
         lblTextblockconveniovencimentoano_Internalname = "TEXTBLOCKCONVENIOVENCIMENTOANO";
         cmbavConveniovencimentoano_Internalname = "vCONVENIOVENCIMENTOANO";
         cmbavConveniovencimentomes_Internalname = "vCONVENIOVENCIMENTOMES";
         tblTablemergedconveniovencimentoano_Internalname = "TABLEMERGEDCONVENIOVENCIMENTOANO";
         divTablesplittedconveniovencimentoano_Internalname = "TABLESPLITTEDCONVENIOVENCIMENTOANO";
         divTableproposta_Internalname = "TABLEPROPOSTA";
         grpUnnamedgroup6_Internalname = "UNNAMEDGROUP6";
         edtavAdicionaranexo_Internalname = "vADICIONARANEXO";
         edtavDocumentosid_Internalname = "vDOCUMENTOSID";
         edtavDocumentosdescricao_Internalname = "vDOCUMENTOSDESCRICAO";
         cmbavDocumentoobrigatorio_Internalname = "vDOCUMENTOOBRIGATORIO";
         edtavPropostadocumentosanexoname_Internalname = "vPROPOSTADOCUMENTOSANEXONAME";
         edtavDocumento_Internalname = "vDOCUMENTO";
         edtavExtensao_Internalname = "vEXTENSAO";
         cmbavPropostadocumentosstatus_Internalname = "vPROPOSTADOCUMENTOSSTATUS";
         edtavPropostadocumentosid_Internalname = "vPROPOSTADOCUMENTOSID";
         divTabledocumentos_Internalname = "TABLEDOCUMENTOS";
         grpUnnamedgroup7_Internalname = "UNNAMEDGROUP7";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         lblTab2_title_Internalname = "TAB2_TITLE";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         Gxuitabspanel_tabs1_Internalname = "GXUITABSPANEL_TABS1";
         bttBtncancel_Internalname = "BTNCANCEL";
         divTablecontent_Internalname = "TABLECONTENT";
         Novajanela_Internalname = "NOVAJANELA";
         divTablemain_Internalname = "TABLEMAIN";
         Griddocumentos_empowerer_Internalname = "GRIDDOCUMENTOS_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGriddocumentos_Internalname = "GRIDDOCUMENTOS";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGriddocumentos_Allowcollapsing = 0;
         subGriddocumentos_Allowselection = 0;
         subGriddocumentos_Header = "";
         edtavPropostadocumentosid_Jsonclick = "";
         edtavPropostadocumentosid_Enabled = 1;
         cmbavPropostadocumentosstatus_Jsonclick = "";
         cmbavPropostadocumentosstatus.Enabled = 1;
         cmbavPropostadocumentosstatus_Columnclass = "WWColumn";
         edtavExtensao_Jsonclick = "";
         edtavExtensao_Enabled = 1;
         edtavDocumento_Jsonclick = "";
         edtavDocumento_Parameters = "";
         edtavDocumento_Contenttype = "";
         edtavDocumento_Filetype = "";
         edtavDocumento_Enabled = 1;
         edtavPropostadocumentosanexoname_Jsonclick = "";
         edtavPropostadocumentosanexoname_Enabled = 1;
         cmbavDocumentoobrigatorio_Jsonclick = "";
         cmbavDocumentoobrigatorio.Enabled = 1;
         edtavDocumentosdescricao_Jsonclick = "";
         edtavDocumentosdescricao_Enabled = 1;
         edtavDocumentosid_Jsonclick = "";
         edtavDocumentosid_Enabled = 1;
         edtavAdicionaranexo_Jsonclick = "";
         edtavAdicionaranexo_Enabled = 1;
         subGriddocumentos_Class = "GridWithBorderColor WorkWith";
         subGriddocumentos_Backcolorstyle = 0;
         cmbavConveniovencimentomes_Jsonclick = "";
         cmbavConveniovencimentomes.Enabled = 1;
         cmbavConveniovencimentoano_Jsonclick = "";
         cmbavConveniovencimentoano.Enabled = 1;
         cmbavPropostadocumentosstatus_Columnheaderclass = "";
         edtavConveniocategoriadescricao_Jsonclick = "";
         edtavConveniocategoriadescricao_Enabled = 1;
         edtavConveniodescricao_Jsonclick = "";
         edtavConveniodescricao_Enabled = 1;
         edtavPropostadescricao_Jsonclick = "";
         edtavPropostadescricao_Enabled = 1;
         edtavPropostavalor_Jsonclick = "";
         edtavPropostavalor_Enabled = 1;
         edtavProcedimentosmedicosdescricao_Enabled = 1;
         edtavClientepix_Jsonclick = "";
         edtavClientepix_Enabled = 1;
         cmbavClientepixtipo_Jsonclick = "";
         cmbavClientepixtipo.Enabled = 1;
         edtavContanumero_Jsonclick = "";
         edtavContanumero_Enabled = 1;
         edtavContaagencia_Jsonclick = "";
         edtavContaagencia_Enabled = 1;
         edtavBanconome_Jsonclick = "";
         edtavBanconome_Enabled = 1;
         edtavResponsavelcontatoemail_Jsonclick = "";
         edtavResponsavelcontatoemail_Enabled = 1;
         edtavResponsavelclientedocumento_Jsonclick = "";
         edtavResponsavelclientedocumento_Enabled = 1;
         edtavResponsavelclienterazaosocial_Jsonclick = "";
         edtavResponsavelclienterazaosocial_Enabled = 1;
         divTablecontentresponsavel_Visible = 1;
         edtavContatoemail_Jsonclick = "";
         edtavContatoemail_Enabled = 1;
         edtavClientedocumento_Jsonclick = "";
         edtavClientedocumento_Enabled = 1;
         edtavClienterazaosocial_Jsonclick = "";
         edtavClienterazaosocial_Enabled = 1;
         edtavClinicacontatoemail_Jsonclick = "";
         edtavClinicacontatoemail_Enabled = 1;
         edtavClinicaclientedocumento_Jsonclick = "";
         edtavClinicaclientedocumento_Enabled = 1;
         edtavClinicaclienterazaosocial_Jsonclick = "";
         edtavClinicaclienterazaosocial_Enabled = 1;
         Novajanela_Target = "";
         Gxuitabspanel_tabs1_Historymanagement = Convert.ToBoolean( 0);
         Gxuitabspanel_tabs1_Class = "Tab";
         Gxuitabspanel_tabs1_Pagecount = 2;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Proposta";
         subGriddocumentos_Rows = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRIDDOCUMENTOS_nFirstRecordOnPage","type":"int"},{"av":"GRIDDOCUMENTOS_nEOF","type":"int"},{"av":"subGriddocumentos_Rows","ctrl":"GRIDDOCUMENTOS","prop":"Rows"},{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A415PropostaDocumentosAnexo","fld":"PROPOSTADOCUMENTOSANEXO","type":"bitstr"},{"av":"A406DocumentosDescricao","fld":"DOCUMENTOSDESCRICAO","type":"svchar"},{"av":"A405DocumentosId","fld":"DOCUMENTOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A417PropostaDocumentosAnexoFileType","fld":"PROPOSTADOCUMENTOSANEXOFILETYPE","type":"svchar"},{"av":"A579PropostaDocumentosStatus","fld":"PROPOSTADOCUMENTOSSTATUS","type":"svchar"},{"av":"A416PropostaDocumentosAnexoName","fld":"PROPOSTADOCUMENTOSANEXONAME","type":"svchar"},{"av":"A414PropostaDocumentosId","fld":"PROPOSTADOCUMENTOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV5PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV47PropostaResponsavelId","fld":"vPROPOSTARESPONSAVELID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV46PropostaPacienteClienteId","fld":"vPROPOSTAPACIENTECLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV58PropostaClinicaId","fld":"vPROPOSTACLINICAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"cmbavPropostadocumentosstatus"}]}""");
         setEventMetadata("GRIDDOCUMENTOS.LOAD","""{"handler":"E165S2","iparms":[{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV5PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A415PropostaDocumentosAnexo","fld":"PROPOSTADOCUMENTOSANEXO","type":"bitstr"},{"av":"A406DocumentosDescricao","fld":"DOCUMENTOSDESCRICAO","type":"svchar"},{"av":"A405DocumentosId","fld":"DOCUMENTOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A417PropostaDocumentosAnexoFileType","fld":"PROPOSTADOCUMENTOSANEXOFILETYPE","type":"svchar"},{"av":"A579PropostaDocumentosStatus","fld":"PROPOSTADOCUMENTOSSTATUS","type":"svchar"},{"av":"A416PropostaDocumentosAnexoName","fld":"PROPOSTADOCUMENTOSANEXONAME","type":"svchar"},{"av":"A414PropostaDocumentosId","fld":"PROPOSTADOCUMENTOSID","pic":"ZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("GRIDDOCUMENTOS.LOAD",""","oparms":[{"av":"AV37DocumentosDescricao","fld":"vDOCUMENTOSDESCRICAO","type":"svchar"},{"av":"AV36DocumentosId","fld":"vDOCUMENTOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV39Documento","fld":"vDOCUMENTO","type":"bitstr"},{"av":"AV40Extensao","fld":"vEXTENSAO","type":"svchar"},{"av":"cmbavPropostadocumentosstatus"},{"av":"AV41PropostaDocumentosStatus","fld":"vPROPOSTADOCUMENTOSSTATUS","type":"svchar"},{"av":"AV49PropostaDocumentosAnexoName","fld":"vPROPOSTADOCUMENTOSANEXONAME","type":"svchar"},{"av":"AV54PropostaDocumentosId","fld":"vPROPOSTADOCUMENTOSID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV29AdicionarAnexo","fld":"vADICIONARANEXO","type":"char"}]}""");
         setEventMetadata("'DOCONSULTARRESPONSAVEL'","""{"handler":"E115S2","iparms":[{"av":"AV47PropostaResponsavelId","fld":"vPROPOSTARESPONSAVELID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("'DOCONSULTARCLIENTE'","""{"handler":"E125S2","iparms":[{"av":"AV46PropostaPacienteClienteId","fld":"vPROPOSTAPACIENTECLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("'DOCONSULTARCLINICA'","""{"handler":"E135S2","iparms":[{"av":"AV58PropostaClinicaId","fld":"vPROPOSTACLINICAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("VADICIONARANEXO.CLICK","""{"handler":"E175S2","iparms":[{"av":"AV54PropostaDocumentosId","fld":"vPROPOSTADOCUMENTOSID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("VADICIONARANEXO.CLICK",""","oparms":[{"av":"Novajanela_Target","ctrl":"NOVAJANELA","prop":"Target"}]}""");
         setEventMetadata("GRIDDOCUMENTOS_FIRSTPAGE","""{"handler":"subgriddocumentos_firstpage","iparms":[{"av":"GRIDDOCUMENTOS_nFirstRecordOnPage","type":"int"},{"av":"GRIDDOCUMENTOS_nEOF","type":"int"},{"av":"subGriddocumentos_Rows","ctrl":"GRIDDOCUMENTOS","prop":"Rows"},{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV5PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A415PropostaDocumentosAnexo","fld":"PROPOSTADOCUMENTOSANEXO","type":"bitstr"},{"av":"A406DocumentosDescricao","fld":"DOCUMENTOSDESCRICAO","type":"svchar"},{"av":"A405DocumentosId","fld":"DOCUMENTOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A417PropostaDocumentosAnexoFileType","fld":"PROPOSTADOCUMENTOSANEXOFILETYPE","type":"svchar"},{"av":"A579PropostaDocumentosStatus","fld":"PROPOSTADOCUMENTOSSTATUS","type":"svchar"},{"av":"A416PropostaDocumentosAnexoName","fld":"PROPOSTADOCUMENTOSANEXONAME","type":"svchar"},{"av":"A414PropostaDocumentosId","fld":"PROPOSTADOCUMENTOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV47PropostaResponsavelId","fld":"vPROPOSTARESPONSAVELID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV46PropostaPacienteClienteId","fld":"vPROPOSTAPACIENTECLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV58PropostaClinicaId","fld":"vPROPOSTACLINICAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("GRIDDOCUMENTOS_FIRSTPAGE",""","oparms":[{"av":"cmbavPropostadocumentosstatus"}]}""");
         setEventMetadata("GRIDDOCUMENTOS_PREVPAGE","""{"handler":"subgriddocumentos_previouspage","iparms":[{"av":"GRIDDOCUMENTOS_nFirstRecordOnPage","type":"int"},{"av":"GRIDDOCUMENTOS_nEOF","type":"int"},{"av":"subGriddocumentos_Rows","ctrl":"GRIDDOCUMENTOS","prop":"Rows"},{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV5PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A415PropostaDocumentosAnexo","fld":"PROPOSTADOCUMENTOSANEXO","type":"bitstr"},{"av":"A406DocumentosDescricao","fld":"DOCUMENTOSDESCRICAO","type":"svchar"},{"av":"A405DocumentosId","fld":"DOCUMENTOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A417PropostaDocumentosAnexoFileType","fld":"PROPOSTADOCUMENTOSANEXOFILETYPE","type":"svchar"},{"av":"A579PropostaDocumentosStatus","fld":"PROPOSTADOCUMENTOSSTATUS","type":"svchar"},{"av":"A416PropostaDocumentosAnexoName","fld":"PROPOSTADOCUMENTOSANEXONAME","type":"svchar"},{"av":"A414PropostaDocumentosId","fld":"PROPOSTADOCUMENTOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV47PropostaResponsavelId","fld":"vPROPOSTARESPONSAVELID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV46PropostaPacienteClienteId","fld":"vPROPOSTAPACIENTECLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV58PropostaClinicaId","fld":"vPROPOSTACLINICAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("GRIDDOCUMENTOS_PREVPAGE",""","oparms":[{"av":"cmbavPropostadocumentosstatus"}]}""");
         setEventMetadata("GRIDDOCUMENTOS_NEXTPAGE","""{"handler":"subgriddocumentos_nextpage","iparms":[{"av":"GRIDDOCUMENTOS_nFirstRecordOnPage","type":"int"},{"av":"GRIDDOCUMENTOS_nEOF","type":"int"},{"av":"subGriddocumentos_Rows","ctrl":"GRIDDOCUMENTOS","prop":"Rows"},{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV5PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A415PropostaDocumentosAnexo","fld":"PROPOSTADOCUMENTOSANEXO","type":"bitstr"},{"av":"A406DocumentosDescricao","fld":"DOCUMENTOSDESCRICAO","type":"svchar"},{"av":"A405DocumentosId","fld":"DOCUMENTOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A417PropostaDocumentosAnexoFileType","fld":"PROPOSTADOCUMENTOSANEXOFILETYPE","type":"svchar"},{"av":"A579PropostaDocumentosStatus","fld":"PROPOSTADOCUMENTOSSTATUS","type":"svchar"},{"av":"A416PropostaDocumentosAnexoName","fld":"PROPOSTADOCUMENTOSANEXONAME","type":"svchar"},{"av":"A414PropostaDocumentosId","fld":"PROPOSTADOCUMENTOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV47PropostaResponsavelId","fld":"vPROPOSTARESPONSAVELID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV46PropostaPacienteClienteId","fld":"vPROPOSTAPACIENTECLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV58PropostaClinicaId","fld":"vPROPOSTACLINICAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("GRIDDOCUMENTOS_NEXTPAGE",""","oparms":[{"av":"cmbavPropostadocumentosstatus"}]}""");
         setEventMetadata("GRIDDOCUMENTOS_LASTPAGE","""{"handler":"subgriddocumentos_lastpage","iparms":[{"av":"GRIDDOCUMENTOS_nFirstRecordOnPage","type":"int"},{"av":"GRIDDOCUMENTOS_nEOF","type":"int"},{"av":"subGriddocumentos_Rows","ctrl":"GRIDDOCUMENTOS","prop":"Rows"},{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV5PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A415PropostaDocumentosAnexo","fld":"PROPOSTADOCUMENTOSANEXO","type":"bitstr"},{"av":"A406DocumentosDescricao","fld":"DOCUMENTOSDESCRICAO","type":"svchar"},{"av":"A405DocumentosId","fld":"DOCUMENTOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A417PropostaDocumentosAnexoFileType","fld":"PROPOSTADOCUMENTOSANEXOFILETYPE","type":"svchar"},{"av":"A579PropostaDocumentosStatus","fld":"PROPOSTADOCUMENTOSSTATUS","type":"svchar"},{"av":"A416PropostaDocumentosAnexoName","fld":"PROPOSTADOCUMENTOSANEXONAME","type":"svchar"},{"av":"A414PropostaDocumentosId","fld":"PROPOSTADOCUMENTOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV47PropostaResponsavelId","fld":"vPROPOSTARESPONSAVELID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV46PropostaPacienteClienteId","fld":"vPROPOSTAPACIENTECLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV58PropostaClinicaId","fld":"vPROPOSTACLINICAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"subGriddocumentos_Recordcount","type":"int"}]""");
         setEventMetadata("GRIDDOCUMENTOS_LASTPAGE",""","oparms":[{"av":"cmbavPropostadocumentosstatus"}]}""");
         setEventMetadata("VALIDV_CLINICACONTATOEMAIL","""{"handler":"Validv_Clinicacontatoemail","iparms":[]}""");
         setEventMetadata("VALIDV_CONTATOEMAIL","""{"handler":"Validv_Contatoemail","iparms":[]}""");
         setEventMetadata("VALIDV_RESPONSAVELCONTATOEMAIL","""{"handler":"Validv_Responsavelcontatoemail","iparms":[]}""");
         setEventMetadata("VALIDV_CLIENTEPIXTIPO","""{"handler":"Validv_Clientepixtipo","iparms":[]}""");
         setEventMetadata("VALIDV_CONVENIOVENCIMENTOANO","""{"handler":"Validv_Conveniovencimentoano","iparms":[]}""");
         setEventMetadata("VALIDV_CONVENIOVENCIMENTOMES","""{"handler":"Validv_Conveniovencimentomes","iparms":[]}""");
         setEventMetadata("VALIDV_PROPOSTADOCUMENTOSSTATUS","""{"handler":"Validv_Propostadocumentosstatus","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Propostadocumentosid","iparms":[]}""");
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
         A415PropostaDocumentosAnexo = "";
         A406DocumentosDescricao = "";
         A417PropostaDocumentosAnexoFileType = "";
         A579PropostaDocumentosStatus = "";
         A416PropostaDocumentosAnexoName = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         Griddocumentos_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucGxuitabspanel_tabs1 = new GXUserControl();
         lblTab1_title_Jsonclick = "";
         lblConsultarclinica_Jsonclick = "";
         TempTags = "";
         AV55ClinicaClienteRazaoSocial = "";
         AV56ClinicaClienteDocumento = "";
         AV57ClinicaContatoEmail = "";
         lblConsultarcliente_Jsonclick = "";
         AV26ClienteRazaoSocial = "";
         AV27ClienteDocumento = "";
         AV28ContatoEmail = "";
         lblConsultarresponsavel_Jsonclick = "";
         AV23ResponsavelClienteRazaoSocial = "";
         AV24ResponsavelClienteDocumento = "";
         AV25ResponsavelContatoEmail = "";
         AV42BancoNome = "";
         AV21ContaAgencia = "";
         AV22ContaNumero = "";
         AV18ClientePixTipo = "";
         AV19ClientePix = "";
         AV43ProcedimentosMedicosDescricao = "";
         AV13PropostaDescricao = "";
         AV44ConvenioDescricao = "";
         AV45ConvenioCategoriaDescricao = "";
         lblTextblockconveniovencimentoano_Jsonclick = "";
         GriddocumentosContainer = new GXWebGrid( context);
         sStyleString = "";
         lblTab2_title_Jsonclick = "";
         WebComp_Wcwctitulosproposta_Component = "";
         OldWcwctitulosproposta = "";
         bttBtncancel_Jsonclick = "";
         ucNovajanela = new GXUserControl();
         ucGriddocumentos_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV29AdicionarAnexo = "";
         AV37DocumentosDescricao = "";
         AV49PropostaDocumentosAnexoName = "";
         AV39Documento = "";
         AV40Extensao = "";
         AV41PropostaDocumentosStatus = "";
         GXDecQS = "";
         H005S2_A227ContratoId = new int[1] ;
         H005S2_n227ContratoId = new bool[] {false} ;
         H005S2_A473ContratoClienteId = new int[1] ;
         H005S2_n473ContratoClienteId = new bool[] {false} ;
         H005S2_A376ProcedimentosMedicosId = new int[1] ;
         H005S2_n376ProcedimentosMedicosId = new bool[] {false} ;
         H005S2_A410ConvenioId = new int[1] ;
         H005S2_n410ConvenioId = new bool[] {false} ;
         H005S2_A402BancoId = new int[1] ;
         H005S2_n402BancoId = new bool[] {false} ;
         H005S2_A403BancoNome = new string[] {""} ;
         H005S2_n403BancoNome = new bool[] {false} ;
         H005S2_A323PropostaId = new int[1] ;
         H005S2_n323PropostaId = new bool[] {false} ;
         H005S2_A652PropostaClinicaDocumento = new string[] {""} ;
         H005S2_n652PropostaClinicaDocumento = new bool[] {false} ;
         H005S2_A643PropostaClinicaNome = new string[] {""} ;
         H005S2_n643PropostaClinicaNome = new bool[] {false} ;
         H005S2_A653PropostaClinicaEmail = new string[] {""} ;
         H005S2_n653PropostaClinicaEmail = new bool[] {false} ;
         H005S2_A642PropostaClinicaId = new int[1] ;
         H005S2_n642PropostaClinicaId = new bool[] {false} ;
         H005S2_A553PropostaResponsavelId = new int[1] ;
         H005S2_n553PropostaResponsavelId = new bool[] {false} ;
         H005S2_A504PropostaPacienteClienteId = new int[1] ;
         H005S2_n504PropostaPacienteClienteId = new bool[] {false} ;
         H005S2_A590PropostaResponsavelConta = new string[] {""} ;
         H005S2_n590PropostaResponsavelConta = new bool[] {false} ;
         H005S2_A591PropostaResponsavelAgencia = new string[] {""} ;
         H005S2_n591PropostaResponsavelAgencia = new bool[] {false} ;
         H005S2_A592PropostaResponsavelTipoPix = new string[] {""} ;
         H005S2_n592PropostaResponsavelTipoPix = new bool[] {false} ;
         H005S2_A593PropostaResponsavelPIX = new string[] {""} ;
         H005S2_n593PropostaResponsavelPIX = new bool[] {false} ;
         H005S2_A594PropostaResponsavelDepositoTipo = new string[] {""} ;
         H005S2_n594PropostaResponsavelDepositoTipo = new bool[] {false} ;
         H005S2_A584PropostaPacienteConta = new string[] {""} ;
         H005S2_n584PropostaPacienteConta = new bool[] {false} ;
         H005S2_A585PropostaPacienteAgencia = new string[] {""} ;
         H005S2_n585PropostaPacienteAgencia = new bool[] {false} ;
         H005S2_A586PropostaPacienteTipoPix = new string[] {""} ;
         H005S2_n586PropostaPacienteTipoPix = new bool[] {false} ;
         H005S2_A587PropostaPacientePIX = new string[] {""} ;
         H005S2_n587PropostaPacientePIX = new bool[] {false} ;
         H005S2_A588PropostaPacienteDepositoTipo = new string[] {""} ;
         H005S2_n588PropostaPacienteDepositoTipo = new bool[] {false} ;
         H005S2_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         H005S2_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         H005S2_A540PropostaPacienteClienteDocumento = new string[] {""} ;
         H005S2_n540PropostaPacienteClienteDocumento = new bool[] {false} ;
         H005S2_A541PropostaPacienteContatoEmail = new string[] {""} ;
         H005S2_n541PropostaPacienteContatoEmail = new bool[] {false} ;
         H005S2_A580PropostaResponsavelDocumento = new string[] {""} ;
         H005S2_n580PropostaResponsavelDocumento = new bool[] {false} ;
         H005S2_A581PropostaResponsavelRazaoSocial = new string[] {""} ;
         H005S2_n581PropostaResponsavelRazaoSocial = new bool[] {false} ;
         H005S2_A582PropostaResponsavelEmail = new string[] {""} ;
         H005S2_n582PropostaResponsavelEmail = new bool[] {false} ;
         H005S2_A378ProcedimentosMedicosDescricao = new string[] {""} ;
         H005S2_n378ProcedimentosMedicosDescricao = new bool[] {false} ;
         H005S2_A326PropostaValor = new decimal[1] ;
         H005S2_n326PropostaValor = new bool[] {false} ;
         H005S2_A325PropostaDescricao = new string[] {""} ;
         H005S2_n325PropostaDescricao = new bool[] {false} ;
         H005S2_A494ConvenioCategoriaDescricao = new string[] {""} ;
         H005S2_n494ConvenioCategoriaDescricao = new bool[] {false} ;
         H005S2_A493ConvenioCategoriaId = new int[1] ;
         H005S2_n493ConvenioCategoriaId = new bool[] {false} ;
         H005S2_A411ConvenioDescricao = new string[] {""} ;
         H005S2_n411ConvenioDescricao = new bool[] {false} ;
         H005S2_A496ConvenioVencimentoAno = new short[1] ;
         H005S2_n496ConvenioVencimentoAno = new bool[] {false} ;
         H005S2_A497ConvenioVencimentoMes = new short[1] ;
         H005S2_n497ConvenioVencimentoMes = new bool[] {false} ;
         A403BancoNome = "";
         A652PropostaClinicaDocumento = "";
         A643PropostaClinicaNome = "";
         A653PropostaClinicaEmail = "";
         A590PropostaResponsavelConta = "";
         A591PropostaResponsavelAgencia = "";
         A592PropostaResponsavelTipoPix = "";
         A593PropostaResponsavelPIX = "";
         A594PropostaResponsavelDepositoTipo = "";
         A584PropostaPacienteConta = "";
         A585PropostaPacienteAgencia = "";
         A586PropostaPacienteTipoPix = "";
         A587PropostaPacientePIX = "";
         A588PropostaPacienteDepositoTipo = "";
         A505PropostaPacienteClienteRazaoSocial = "";
         A540PropostaPacienteClienteDocumento = "";
         A541PropostaPacienteContatoEmail = "";
         A580PropostaResponsavelDocumento = "";
         A581PropostaResponsavelRazaoSocial = "";
         A582PropostaResponsavelEmail = "";
         A378ProcedimentosMedicosDescricao = "";
         A325PropostaDescricao = "";
         A494ConvenioCategoriaDescricao = "";
         A411ConvenioDescricao = "";
         A589PropostaResponsavelBanco = "";
         AV48ClienteDepositoTipo = "";
         A583PropostaPacienteBanco = "";
         H005S3_A323PropostaId = new int[1] ;
         H005S3_n323PropostaId = new bool[] {false} ;
         H005S3_A406DocumentosDescricao = new string[] {""} ;
         H005S3_n406DocumentosDescricao = new bool[] {false} ;
         H005S3_A405DocumentosId = new int[1] ;
         H005S3_n405DocumentosId = new bool[] {false} ;
         H005S3_A417PropostaDocumentosAnexoFileType = new string[] {""} ;
         H005S3_n417PropostaDocumentosAnexoFileType = new bool[] {false} ;
         H005S3_A579PropostaDocumentosStatus = new string[] {""} ;
         H005S3_n579PropostaDocumentosStatus = new bool[] {false} ;
         H005S3_A416PropostaDocumentosAnexoName = new string[] {""} ;
         H005S3_n416PropostaDocumentosAnexoName = new bool[] {false} ;
         H005S3_A414PropostaDocumentosId = new int[1] ;
         H005S3_A415PropostaDocumentosAnexo = new string[] {""} ;
         H005S3_n415PropostaDocumentosAnexo = new bool[] {false} ;
         GriddocumentosRow = new GXWebRow();
         AV53PropostaDocumentos = new SdtPropostaDocumentos(context);
         AV50GUID = Guid.Empty;
         AV51Source = "";
         AV52File = new GxFile(context.GetPhysicalPath());
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGriddocumentos_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         gxblobfileaux = new GxFile(context.GetPhysicalPath());
         GriddocumentosColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpconsultaproposta__default(),
            new Object[][] {
                new Object[] {
               H005S2_A227ContratoId, H005S2_n227ContratoId, H005S2_A473ContratoClienteId, H005S2_n473ContratoClienteId, H005S2_A376ProcedimentosMedicosId, H005S2_n376ProcedimentosMedicosId, H005S2_A410ConvenioId, H005S2_n410ConvenioId, H005S2_A402BancoId, H005S2_n402BancoId,
               H005S2_A403BancoNome, H005S2_n403BancoNome, H005S2_A323PropostaId, H005S2_A652PropostaClinicaDocumento, H005S2_n652PropostaClinicaDocumento, H005S2_A643PropostaClinicaNome, H005S2_n643PropostaClinicaNome, H005S2_A653PropostaClinicaEmail, H005S2_n653PropostaClinicaEmail, H005S2_A642PropostaClinicaId,
               H005S2_n642PropostaClinicaId, H005S2_A553PropostaResponsavelId, H005S2_n553PropostaResponsavelId, H005S2_A504PropostaPacienteClienteId, H005S2_n504PropostaPacienteClienteId, H005S2_A590PropostaResponsavelConta, H005S2_n590PropostaResponsavelConta, H005S2_A591PropostaResponsavelAgencia, H005S2_n591PropostaResponsavelAgencia, H005S2_A592PropostaResponsavelTipoPix,
               H005S2_n592PropostaResponsavelTipoPix, H005S2_A593PropostaResponsavelPIX, H005S2_n593PropostaResponsavelPIX, H005S2_A594PropostaResponsavelDepositoTipo, H005S2_n594PropostaResponsavelDepositoTipo, H005S2_A584PropostaPacienteConta, H005S2_n584PropostaPacienteConta, H005S2_A585PropostaPacienteAgencia, H005S2_n585PropostaPacienteAgencia, H005S2_A586PropostaPacienteTipoPix,
               H005S2_n586PropostaPacienteTipoPix, H005S2_A587PropostaPacientePIX, H005S2_n587PropostaPacientePIX, H005S2_A588PropostaPacienteDepositoTipo, H005S2_n588PropostaPacienteDepositoTipo, H005S2_A505PropostaPacienteClienteRazaoSocial, H005S2_n505PropostaPacienteClienteRazaoSocial, H005S2_A540PropostaPacienteClienteDocumento, H005S2_n540PropostaPacienteClienteDocumento, H005S2_A541PropostaPacienteContatoEmail,
               H005S2_n541PropostaPacienteContatoEmail, H005S2_A580PropostaResponsavelDocumento, H005S2_n580PropostaResponsavelDocumento, H005S2_A581PropostaResponsavelRazaoSocial, H005S2_n581PropostaResponsavelRazaoSocial, H005S2_A582PropostaResponsavelEmail, H005S2_n582PropostaResponsavelEmail, H005S2_A378ProcedimentosMedicosDescricao, H005S2_n378ProcedimentosMedicosDescricao, H005S2_A326PropostaValor,
               H005S2_n326PropostaValor, H005S2_A325PropostaDescricao, H005S2_n325PropostaDescricao, H005S2_A494ConvenioCategoriaDescricao, H005S2_n494ConvenioCategoriaDescricao, H005S2_A493ConvenioCategoriaId, H005S2_n493ConvenioCategoriaId, H005S2_A411ConvenioDescricao, H005S2_n411ConvenioDescricao, H005S2_A496ConvenioVencimentoAno,
               H005S2_n496ConvenioVencimentoAno, H005S2_A497ConvenioVencimentoMes, H005S2_n497ConvenioVencimentoMes
               }
               , new Object[] {
               H005S3_A323PropostaId, H005S3_n323PropostaId, H005S3_A406DocumentosDescricao, H005S3_n406DocumentosDescricao, H005S3_A405DocumentosId, H005S3_n405DocumentosId, H005S3_A417PropostaDocumentosAnexoFileType, H005S3_n417PropostaDocumentosAnexoFileType, H005S3_A579PropostaDocumentosStatus, H005S3_n579PropostaDocumentosStatus,
               H005S3_A416PropostaDocumentosAnexoName, H005S3_n416PropostaDocumentosAnexoName, H005S3_A414PropostaDocumentosId, H005S3_A415PropostaDocumentosAnexo, H005S3_n415PropostaDocumentosAnexo
               }
            }
         );
         WebComp_Wcwctitulosproposta = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
         edtavClinicaclienterazaosocial_Enabled = 0;
         edtavClinicaclientedocumento_Enabled = 0;
         edtavClinicacontatoemail_Enabled = 0;
         edtavClienterazaosocial_Enabled = 0;
         edtavClientedocumento_Enabled = 0;
         edtavContatoemail_Enabled = 0;
         edtavResponsavelclienterazaosocial_Enabled = 0;
         edtavResponsavelclientedocumento_Enabled = 0;
         edtavResponsavelcontatoemail_Enabled = 0;
         edtavBanconome_Enabled = 0;
         edtavContaagencia_Enabled = 0;
         edtavContanumero_Enabled = 0;
         cmbavClientepixtipo.Enabled = 0;
         edtavClientepix_Enabled = 0;
         edtavProcedimentosmedicosdescricao_Enabled = 0;
         edtavPropostavalor_Enabled = 0;
         edtavPropostadescricao_Enabled = 0;
         edtavConveniodescricao_Enabled = 0;
         edtavConveniocategoriadescricao_Enabled = 0;
         cmbavConveniovencimentoano.Enabled = 0;
         cmbavConveniovencimentomes.Enabled = 0;
         edtavAdicionaranexo_Enabled = 0;
         edtavDocumentosid_Enabled = 0;
         edtavDocumentosdescricao_Enabled = 0;
         cmbavDocumentoobrigatorio.Enabled = 0;
         edtavPropostadocumentosanexoname_Enabled = 0;
         edtavDocumento_Enabled = 0;
         edtavExtensao_Enabled = 0;
         cmbavPropostadocumentosstatus.Enabled = 0;
         edtavPropostadocumentosid_Enabled = 0;
      }

      private short GRIDDOCUMENTOS_nEOF ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short AV16ConvenioVencimentoAno ;
      private short AV17ConvenioVencimentoMes ;
      private short subGriddocumentos_Backcolorstyle ;
      private short A496ConvenioVencimentoAno ;
      private short A497ConvenioVencimentoMes ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGriddocumentos_Backstyle ;
      private short subGriddocumentos_Titlebackstyle ;
      private short subGriddocumentos_Allowselection ;
      private short subGriddocumentos_Allowhovering ;
      private short subGriddocumentos_Allowcollapsing ;
      private short subGriddocumentos_Collapsed ;
      private int AV5PropostaId ;
      private int wcpOAV5PropostaId ;
      private int nRC_GXsfl_166 ;
      private int subGriddocumentos_Recordcount ;
      private int subGriddocumentos_Rows ;
      private int nGXsfl_166_idx=1 ;
      private int A323PropostaId ;
      private int A405DocumentosId ;
      private int A414PropostaDocumentosId ;
      private int AV47PropostaResponsavelId ;
      private int AV46PropostaPacienteClienteId ;
      private int AV58PropostaClinicaId ;
      private int Gxuitabspanel_tabs1_Pagecount ;
      private int edtavClinicaclienterazaosocial_Enabled ;
      private int edtavClinicaclientedocumento_Enabled ;
      private int edtavClinicacontatoemail_Enabled ;
      private int edtavClienterazaosocial_Enabled ;
      private int edtavClientedocumento_Enabled ;
      private int edtavContatoemail_Enabled ;
      private int divTablecontentresponsavel_Visible ;
      private int edtavResponsavelclienterazaosocial_Enabled ;
      private int edtavResponsavelclientedocumento_Enabled ;
      private int edtavResponsavelcontatoemail_Enabled ;
      private int edtavBanconome_Enabled ;
      private int edtavContaagencia_Enabled ;
      private int edtavContanumero_Enabled ;
      private int edtavClientepix_Enabled ;
      private int edtavProcedimentosmedicosdescricao_Enabled ;
      private int edtavPropostavalor_Enabled ;
      private int edtavPropostadescricao_Enabled ;
      private int edtavConveniodescricao_Enabled ;
      private int edtavConveniocategoriadescricao_Enabled ;
      private int AV36DocumentosId ;
      private int AV54PropostaDocumentosId ;
      private int subGriddocumentos_Islastpage ;
      private int edtavAdicionaranexo_Enabled ;
      private int edtavDocumentosid_Enabled ;
      private int edtavDocumentosdescricao_Enabled ;
      private int edtavPropostadocumentosanexoname_Enabled ;
      private int edtavDocumento_Enabled ;
      private int edtavExtensao_Enabled ;
      private int edtavPropostadocumentosid_Enabled ;
      private int GRIDDOCUMENTOS_nGridOutOfScope ;
      private int A227ContratoId ;
      private int A473ContratoClienteId ;
      private int A376ProcedimentosMedicosId ;
      private int A410ConvenioId ;
      private int A402BancoId ;
      private int A642PropostaClinicaId ;
      private int A553PropostaResponsavelId ;
      private int A504PropostaPacienteClienteId ;
      private int A493ConvenioCategoriaId ;
      private int AV15ConvenioCategoriaId ;
      private int idxLst ;
      private int subGriddocumentos_Backcolor ;
      private int subGriddocumentos_Allbackcolor ;
      private int subGriddocumentos_Titlebackcolor ;
      private int subGriddocumentos_Selectedindex ;
      private int subGriddocumentos_Selectioncolor ;
      private int subGriddocumentos_Hoveringcolor ;
      private long GRIDDOCUMENTOS_nFirstRecordOnPage ;
      private long GRIDDOCUMENTOS_nCurrentRecord ;
      private decimal AV12PropostaValor ;
      private decimal A326PropostaValor ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_166_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Gxuitabspanel_tabs1_Class ;
      private string Novajanela_Target ;
      private string Griddocumentos_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Gxuitabspanel_tabs1_Internalname ;
      private string lblTab1_title_Internalname ;
      private string lblTab1_title_Jsonclick ;
      private string divUnnamedtable2_Internalname ;
      private string grpUnnamedgroup3_Internalname ;
      private string divTableclinica_Internalname ;
      private string lblConsultarclinica_Internalname ;
      private string lblConsultarclinica_Jsonclick ;
      private string edtavClinicaclienterazaosocial_Internalname ;
      private string TempTags ;
      private string edtavClinicaclienterazaosocial_Jsonclick ;
      private string edtavClinicaclientedocumento_Internalname ;
      private string edtavClinicaclientedocumento_Jsonclick ;
      private string edtavClinicacontatoemail_Internalname ;
      private string edtavClinicacontatoemail_Jsonclick ;
      private string grpUnnamedgroup4_Internalname ;
      private string divTablecliente_Internalname ;
      private string lblConsultarcliente_Internalname ;
      private string lblConsultarcliente_Jsonclick ;
      private string edtavClienterazaosocial_Internalname ;
      private string edtavClienterazaosocial_Jsonclick ;
      private string edtavClientedocumento_Internalname ;
      private string edtavClientedocumento_Jsonclick ;
      private string edtavContatoemail_Internalname ;
      private string edtavContatoemail_Jsonclick ;
      private string divTablecontentresponsavel_Internalname ;
      private string grpUnnamedgroup8_Internalname ;
      private string divTablerespnosavel_Internalname ;
      private string lblConsultarresponsavel_Internalname ;
      private string lblConsultarresponsavel_Jsonclick ;
      private string edtavResponsavelclienterazaosocial_Internalname ;
      private string edtavResponsavelclienterazaosocial_Jsonclick ;
      private string edtavResponsavelclientedocumento_Internalname ;
      private string edtavResponsavelclientedocumento_Jsonclick ;
      private string edtavResponsavelcontatoemail_Internalname ;
      private string edtavResponsavelcontatoemail_Jsonclick ;
      private string grpUnnamedgroup5_Internalname ;
      private string divTableconta_Internalname ;
      private string divTablebanco_Internalname ;
      private string edtavBanconome_Internalname ;
      private string edtavBanconome_Jsonclick ;
      private string edtavContaagencia_Internalname ;
      private string edtavContaagencia_Jsonclick ;
      private string edtavContanumero_Internalname ;
      private string edtavContanumero_Jsonclick ;
      private string divTablepix_Internalname ;
      private string cmbavClientepixtipo_Internalname ;
      private string cmbavClientepixtipo_Jsonclick ;
      private string edtavClientepix_Internalname ;
      private string edtavClientepix_Jsonclick ;
      private string grpUnnamedgroup6_Internalname ;
      private string divTableproposta_Internalname ;
      private string edtavProcedimentosmedicosdescricao_Internalname ;
      private string edtavPropostavalor_Internalname ;
      private string edtavPropostavalor_Jsonclick ;
      private string edtavPropostadescricao_Internalname ;
      private string edtavPropostadescricao_Jsonclick ;
      private string edtavConveniodescricao_Internalname ;
      private string edtavConveniodescricao_Jsonclick ;
      private string edtavConveniocategoriadescricao_Internalname ;
      private string edtavConveniocategoriadescricao_Jsonclick ;
      private string divTablesplittedconveniovencimentoano_Internalname ;
      private string lblTextblockconveniovencimentoano_Internalname ;
      private string lblTextblockconveniovencimentoano_Jsonclick ;
      private string grpUnnamedgroup7_Internalname ;
      private string divTabledocumentos_Internalname ;
      private string sStyleString ;
      private string subGriddocumentos_Internalname ;
      private string lblTab2_title_Internalname ;
      private string lblTab2_title_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string WebComp_Wcwctitulosproposta_Component ;
      private string OldWcwctitulosproposta ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string Novajanela_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Griddocumentos_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV29AdicionarAnexo ;
      private string edtavAdicionaranexo_Internalname ;
      private string edtavDocumentosid_Internalname ;
      private string edtavDocumentosdescricao_Internalname ;
      private string cmbavDocumentoobrigatorio_Internalname ;
      private string edtavPropostadocumentosanexoname_Internalname ;
      private string edtavDocumento_Internalname ;
      private string edtavExtensao_Internalname ;
      private string cmbavPropostadocumentosstatus_Internalname ;
      private string edtavPropostadocumentosid_Internalname ;
      private string GXDecQS ;
      private string cmbavConveniovencimentoano_Internalname ;
      private string cmbavConveniovencimentomes_Internalname ;
      private string cmbavPropostadocumentosstatus_Columnheaderclass ;
      private string cmbavPropostadocumentosstatus_Columnclass ;
      private string tblTablemergedconveniovencimentoano_Internalname ;
      private string cmbavConveniovencimentoano_Jsonclick ;
      private string cmbavConveniovencimentomes_Jsonclick ;
      private string sGXsfl_166_fel_idx="0001" ;
      private string subGriddocumentos_Class ;
      private string subGriddocumentos_Linesclass ;
      private string ROClassString ;
      private string edtavAdicionaranexo_Jsonclick ;
      private string edtavDocumentosid_Jsonclick ;
      private string edtavDocumentosdescricao_Jsonclick ;
      private string GXCCtl ;
      private string cmbavDocumentoobrigatorio_Jsonclick ;
      private string edtavPropostadocumentosanexoname_Jsonclick ;
      private string edtavDocumento_Filetype ;
      private string edtavDocumento_Contenttype ;
      private string edtavDocumento_Parameters ;
      private string edtavDocumento_Jsonclick ;
      private string edtavExtensao_Jsonclick ;
      private string cmbavPropostadocumentosstatus_Jsonclick ;
      private string edtavPropostadocumentosid_Jsonclick ;
      private string subGriddocumentos_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n323PropostaId ;
      private bool n415PropostaDocumentosAnexo ;
      private bool n406DocumentosDescricao ;
      private bool n405DocumentosId ;
      private bool n417PropostaDocumentosAnexoFileType ;
      private bool n579PropostaDocumentosStatus ;
      private bool n416PropostaDocumentosAnexoName ;
      private bool Gxuitabspanel_tabs1_Historymanagement ;
      private bool wbLoad ;
      private bool bGXsfl_166_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool AV38DocumentoObrigatorio ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n227ContratoId ;
      private bool n473ContratoClienteId ;
      private bool n376ProcedimentosMedicosId ;
      private bool n410ConvenioId ;
      private bool n402BancoId ;
      private bool n403BancoNome ;
      private bool n652PropostaClinicaDocumento ;
      private bool n643PropostaClinicaNome ;
      private bool n653PropostaClinicaEmail ;
      private bool n642PropostaClinicaId ;
      private bool n553PropostaResponsavelId ;
      private bool n504PropostaPacienteClienteId ;
      private bool n590PropostaResponsavelConta ;
      private bool n591PropostaResponsavelAgencia ;
      private bool n592PropostaResponsavelTipoPix ;
      private bool n593PropostaResponsavelPIX ;
      private bool n594PropostaResponsavelDepositoTipo ;
      private bool n584PropostaPacienteConta ;
      private bool n585PropostaPacienteAgencia ;
      private bool n586PropostaPacienteTipoPix ;
      private bool n587PropostaPacientePIX ;
      private bool n588PropostaPacienteDepositoTipo ;
      private bool n505PropostaPacienteClienteRazaoSocial ;
      private bool n540PropostaPacienteClienteDocumento ;
      private bool n541PropostaPacienteContatoEmail ;
      private bool n580PropostaResponsavelDocumento ;
      private bool n581PropostaResponsavelRazaoSocial ;
      private bool n582PropostaResponsavelEmail ;
      private bool n378ProcedimentosMedicosDescricao ;
      private bool n326PropostaValor ;
      private bool n325PropostaDescricao ;
      private bool n494ConvenioCategoriaDescricao ;
      private bool n493ConvenioCategoriaId ;
      private bool n411ConvenioDescricao ;
      private bool n496ConvenioVencimentoAno ;
      private bool n497ConvenioVencimentoMes ;
      private bool bDynCreated_Wcwctitulosproposta ;
      private bool gx_refresh_fired ;
      private string AV43ProcedimentosMedicosDescricao ;
      private string A378ProcedimentosMedicosDescricao ;
      private string A406DocumentosDescricao ;
      private string A417PropostaDocumentosAnexoFileType ;
      private string A579PropostaDocumentosStatus ;
      private string A416PropostaDocumentosAnexoName ;
      private string AV55ClinicaClienteRazaoSocial ;
      private string AV56ClinicaClienteDocumento ;
      private string AV57ClinicaContatoEmail ;
      private string AV26ClienteRazaoSocial ;
      private string AV27ClienteDocumento ;
      private string AV28ContatoEmail ;
      private string AV23ResponsavelClienteRazaoSocial ;
      private string AV24ResponsavelClienteDocumento ;
      private string AV25ResponsavelContatoEmail ;
      private string AV42BancoNome ;
      private string AV21ContaAgencia ;
      private string AV22ContaNumero ;
      private string AV18ClientePixTipo ;
      private string AV19ClientePix ;
      private string AV13PropostaDescricao ;
      private string AV44ConvenioDescricao ;
      private string AV45ConvenioCategoriaDescricao ;
      private string AV37DocumentosDescricao ;
      private string AV49PropostaDocumentosAnexoName ;
      private string AV40Extensao ;
      private string AV41PropostaDocumentosStatus ;
      private string A403BancoNome ;
      private string A652PropostaClinicaDocumento ;
      private string A643PropostaClinicaNome ;
      private string A653PropostaClinicaEmail ;
      private string A590PropostaResponsavelConta ;
      private string A591PropostaResponsavelAgencia ;
      private string A592PropostaResponsavelTipoPix ;
      private string A593PropostaResponsavelPIX ;
      private string A594PropostaResponsavelDepositoTipo ;
      private string A584PropostaPacienteConta ;
      private string A585PropostaPacienteAgencia ;
      private string A586PropostaPacienteTipoPix ;
      private string A587PropostaPacientePIX ;
      private string A588PropostaPacienteDepositoTipo ;
      private string A505PropostaPacienteClienteRazaoSocial ;
      private string A540PropostaPacienteClienteDocumento ;
      private string A541PropostaPacienteContatoEmail ;
      private string A580PropostaResponsavelDocumento ;
      private string A581PropostaResponsavelRazaoSocial ;
      private string A582PropostaResponsavelEmail ;
      private string A325PropostaDescricao ;
      private string A494ConvenioCategoriaDescricao ;
      private string A411ConvenioDescricao ;
      private string A589PropostaResponsavelBanco ;
      private string AV48ClienteDepositoTipo ;
      private string A583PropostaPacienteBanco ;
      private string AV51Source ;
      private Guid AV50GUID ;
      private string A415PropostaDocumentosAnexo ;
      private string AV39Documento ;
      private GXWebComponent WebComp_Wcwctitulosproposta ;
      private GxFile gxblobfileaux ;
      private GXWebGrid GriddocumentosContainer ;
      private GXWebRow GriddocumentosRow ;
      private GXWebColumn GriddocumentosColumn ;
      private GXUserControl ucGxuitabspanel_tabs1 ;
      private GXUserControl ucNovajanela ;
      private GXUserControl ucGriddocumentos_empowerer ;
      private GxFile AV52File ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavClientepixtipo ;
      private GXCombobox cmbavConveniovencimentoano ;
      private GXCombobox cmbavConveniovencimentomes ;
      private GXCombobox cmbavDocumentoobrigatorio ;
      private GXCombobox cmbavPropostadocumentosstatus ;
      private IDataStoreProvider pr_default ;
      private int[] H005S2_A227ContratoId ;
      private bool[] H005S2_n227ContratoId ;
      private int[] H005S2_A473ContratoClienteId ;
      private bool[] H005S2_n473ContratoClienteId ;
      private int[] H005S2_A376ProcedimentosMedicosId ;
      private bool[] H005S2_n376ProcedimentosMedicosId ;
      private int[] H005S2_A410ConvenioId ;
      private bool[] H005S2_n410ConvenioId ;
      private int[] H005S2_A402BancoId ;
      private bool[] H005S2_n402BancoId ;
      private string[] H005S2_A403BancoNome ;
      private bool[] H005S2_n403BancoNome ;
      private int[] H005S2_A323PropostaId ;
      private bool[] H005S2_n323PropostaId ;
      private string[] H005S2_A652PropostaClinicaDocumento ;
      private bool[] H005S2_n652PropostaClinicaDocumento ;
      private string[] H005S2_A643PropostaClinicaNome ;
      private bool[] H005S2_n643PropostaClinicaNome ;
      private string[] H005S2_A653PropostaClinicaEmail ;
      private bool[] H005S2_n653PropostaClinicaEmail ;
      private int[] H005S2_A642PropostaClinicaId ;
      private bool[] H005S2_n642PropostaClinicaId ;
      private int[] H005S2_A553PropostaResponsavelId ;
      private bool[] H005S2_n553PropostaResponsavelId ;
      private int[] H005S2_A504PropostaPacienteClienteId ;
      private bool[] H005S2_n504PropostaPacienteClienteId ;
      private string[] H005S2_A590PropostaResponsavelConta ;
      private bool[] H005S2_n590PropostaResponsavelConta ;
      private string[] H005S2_A591PropostaResponsavelAgencia ;
      private bool[] H005S2_n591PropostaResponsavelAgencia ;
      private string[] H005S2_A592PropostaResponsavelTipoPix ;
      private bool[] H005S2_n592PropostaResponsavelTipoPix ;
      private string[] H005S2_A593PropostaResponsavelPIX ;
      private bool[] H005S2_n593PropostaResponsavelPIX ;
      private string[] H005S2_A594PropostaResponsavelDepositoTipo ;
      private bool[] H005S2_n594PropostaResponsavelDepositoTipo ;
      private string[] H005S2_A584PropostaPacienteConta ;
      private bool[] H005S2_n584PropostaPacienteConta ;
      private string[] H005S2_A585PropostaPacienteAgencia ;
      private bool[] H005S2_n585PropostaPacienteAgencia ;
      private string[] H005S2_A586PropostaPacienteTipoPix ;
      private bool[] H005S2_n586PropostaPacienteTipoPix ;
      private string[] H005S2_A587PropostaPacientePIX ;
      private bool[] H005S2_n587PropostaPacientePIX ;
      private string[] H005S2_A588PropostaPacienteDepositoTipo ;
      private bool[] H005S2_n588PropostaPacienteDepositoTipo ;
      private string[] H005S2_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] H005S2_n505PropostaPacienteClienteRazaoSocial ;
      private string[] H005S2_A540PropostaPacienteClienteDocumento ;
      private bool[] H005S2_n540PropostaPacienteClienteDocumento ;
      private string[] H005S2_A541PropostaPacienteContatoEmail ;
      private bool[] H005S2_n541PropostaPacienteContatoEmail ;
      private string[] H005S2_A580PropostaResponsavelDocumento ;
      private bool[] H005S2_n580PropostaResponsavelDocumento ;
      private string[] H005S2_A581PropostaResponsavelRazaoSocial ;
      private bool[] H005S2_n581PropostaResponsavelRazaoSocial ;
      private string[] H005S2_A582PropostaResponsavelEmail ;
      private bool[] H005S2_n582PropostaResponsavelEmail ;
      private string[] H005S2_A378ProcedimentosMedicosDescricao ;
      private bool[] H005S2_n378ProcedimentosMedicosDescricao ;
      private decimal[] H005S2_A326PropostaValor ;
      private bool[] H005S2_n326PropostaValor ;
      private string[] H005S2_A325PropostaDescricao ;
      private bool[] H005S2_n325PropostaDescricao ;
      private string[] H005S2_A494ConvenioCategoriaDescricao ;
      private bool[] H005S2_n494ConvenioCategoriaDescricao ;
      private int[] H005S2_A493ConvenioCategoriaId ;
      private bool[] H005S2_n493ConvenioCategoriaId ;
      private string[] H005S2_A411ConvenioDescricao ;
      private bool[] H005S2_n411ConvenioDescricao ;
      private short[] H005S2_A496ConvenioVencimentoAno ;
      private bool[] H005S2_n496ConvenioVencimentoAno ;
      private short[] H005S2_A497ConvenioVencimentoMes ;
      private bool[] H005S2_n497ConvenioVencimentoMes ;
      private int[] H005S3_A323PropostaId ;
      private bool[] H005S3_n323PropostaId ;
      private string[] H005S3_A406DocumentosDescricao ;
      private bool[] H005S3_n406DocumentosDescricao ;
      private int[] H005S3_A405DocumentosId ;
      private bool[] H005S3_n405DocumentosId ;
      private string[] H005S3_A417PropostaDocumentosAnexoFileType ;
      private bool[] H005S3_n417PropostaDocumentosAnexoFileType ;
      private string[] H005S3_A579PropostaDocumentosStatus ;
      private bool[] H005S3_n579PropostaDocumentosStatus ;
      private string[] H005S3_A416PropostaDocumentosAnexoName ;
      private bool[] H005S3_n416PropostaDocumentosAnexoName ;
      private int[] H005S3_A414PropostaDocumentosId ;
      private string[] H005S3_A415PropostaDocumentosAnexo ;
      private bool[] H005S3_n415PropostaDocumentosAnexo ;
      private SdtPropostaDocumentos AV53PropostaDocumentos ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpconsultaproposta__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH005S2;
          prmH005S2 = new Object[] {
          new ParDef("AV5PropostaId",GXType.Int32,9,0)
          };
          string cmdBufferH005S2;
          cmdBufferH005S2=" SELECT T1.ContratoId, T2.ContratoClienteId AS ContratoClienteId, T1.ProcedimentosMedicosId, T9.ConvenioId, T3.BancoId, T4.BancoNome, T1.PropostaId, T6.ClienteDocumento AS PropostaClinicaDocumento, T6.ClienteRazaoSocial AS PropostaClinicaNome, T6.ContatoEmail AS PropostaClinicaEmail, T1.PropostaClinicaId AS PropostaClinicaId, T1.PropostaResponsavelId AS PropostaResponsavelId, T1.PropostaPacienteClienteId AS PropostaPacienteClienteId, T7.ContaNumero AS PropostaResponsavelConta, T7.ContaAgencia AS PropostaResponsavelAgencia, T7.ClientePixTipo AS PropostaResponsavelTipoPix, T7.ClientePix AS PropostaResponsavelPIX, T7.ClienteDepositoTipo AS PropostaResponsavelDepositoTipo, T8.ContaNumero AS PropostaPacienteConta, T8.ContaAgencia AS PropostaPacienteAgencia, T8.ClientePixTipo AS PropostaPacienteTipoPix, T8.ClientePix AS PropostaPacientePIX, T8.ClienteDepositoTipo AS PropostaPacienteDepositoTipo, T8.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, T8.ClienteDocumento AS PropostaPacienteClienteDocumento, T8.ContatoEmail AS PropostaPacienteContatoEmail, T7.ClienteDocumento AS PropostaResponsavelDocumento, T7.ClienteRazaoSocial AS PropostaResponsavelRazaoSocial, T7.ContatoEmail AS PropostaResponsavelEmail, T5.ProcedimentosMedicosDescricao, T1.PropostaValor, T1.PropostaDescricao, T9.ConvenioCategoriaDescricao, T1.ConvenioCategoriaId, T10.ConvenioDescricao, T1.ConvenioVencimentoAno, T1.ConvenioVencimentoMes FROM (((((((((Proposta T1 LEFT JOIN Contrato T2 ON T2.ContratoId = T1.ContratoId) LEFT JOIN Cliente T3 ON T3.ClienteId = T2.ContratoClienteId) LEFT JOIN Banco T4 ON T4.BancoId = T3.BancoId) LEFT JOIN ProcedimentosMedicos T5 ON T5.ProcedimentosMedicosId = T1.ProcedimentosMedicosId) LEFT JOIN Cliente T6 ON T6.ClienteId = T1.PropostaClinicaId) LEFT JOIN Cliente T7 ON T7.ClienteId "
          + " = T1.PropostaResponsavelId) LEFT JOIN Cliente T8 ON T8.ClienteId = T1.PropostaPacienteClienteId) LEFT JOIN ConvenioCategoria T9 ON T9.ConvenioCategoriaId = T1.ConvenioCategoriaId) LEFT JOIN Convenio T10 ON T10.ConvenioId = T9.ConvenioId) WHERE T1.PropostaId = :AV5PropostaId ORDER BY T1.PropostaId" ;
          Object[] prmH005S3;
          prmH005S3 = new Object[] {
          new ParDef("AV5PropostaId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("H005S2", cmdBufferH005S2,false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005S2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H005S3", "SELECT T1.PropostaId, T2.DocumentosDescricao, T1.DocumentosId, T1.PropostaDocumentosAnexoFileType, T1.PropostaDocumentosStatus, T1.PropostaDocumentosAnexoName, T1.PropostaDocumentosId, T1.PropostaDocumentosAnexo FROM (PropostaDocumentos T1 LEFT JOIN Documentos T2 ON T2.DocumentosId = T1.DocumentosId) WHERE (T1.PropostaId = :AV5PropostaId) AND (Not (T1.PropostaDocumentosAnexo = '') and Not T1.PropostaDocumentosAnexo IS NULL) ORDER BY T1.PropostaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005S3,1, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((int[]) buf[19])[0] = rslt.getInt(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((int[]) buf[21])[0] = rslt.getInt(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((int[]) buf[23])[0] = rslt.getInt(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((string[]) buf[35])[0] = rslt.getVarchar(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((string[]) buf[37])[0] = rslt.getVarchar(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((string[]) buf[41])[0] = rslt.getVarchar(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((string[]) buf[43])[0] = rslt.getVarchar(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((string[]) buf[45])[0] = rslt.getVarchar(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((string[]) buf[47])[0] = rslt.getVarchar(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((string[]) buf[49])[0] = rslt.getVarchar(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((string[]) buf[51])[0] = rslt.getVarchar(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((string[]) buf[53])[0] = rslt.getVarchar(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((string[]) buf[55])[0] = rslt.getVarchar(29);
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((string[]) buf[57])[0] = rslt.getLongVarchar(30);
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                ((decimal[]) buf[59])[0] = rslt.getDecimal(31);
                ((bool[]) buf[60])[0] = rslt.wasNull(31);
                ((string[]) buf[61])[0] = rslt.getVarchar(32);
                ((bool[]) buf[62])[0] = rslt.wasNull(32);
                ((string[]) buf[63])[0] = rslt.getVarchar(33);
                ((bool[]) buf[64])[0] = rslt.wasNull(33);
                ((int[]) buf[65])[0] = rslt.getInt(34);
                ((bool[]) buf[66])[0] = rslt.wasNull(34);
                ((string[]) buf[67])[0] = rslt.getVarchar(35);
                ((bool[]) buf[68])[0] = rslt.wasNull(35);
                ((short[]) buf[69])[0] = rslt.getShort(36);
                ((bool[]) buf[70])[0] = rslt.wasNull(36);
                ((short[]) buf[71])[0] = rslt.getShort(37);
                ((bool[]) buf[72])[0] = rslt.wasNull(37);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                ((string[]) buf[13])[0] = rslt.getBLOBFile(8, "tmp", "");
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
       }
    }

 }

}
