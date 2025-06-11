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
   public class wpconsultapropostac : GXDataArea
   {
      public wpconsultapropostac( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpconsultapropostac( IGxContext context )
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmastercli", "GeneXus.Programs.wwpbaseobjects.workwithplusmastercli", new Object[] {context});
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
         PA5U2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5U2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/UCPropostaConsultaRender.js", "", false, true);
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
         GXEncryptionTmp = "wpconsultapropostac"+UrlEncode(StringUtil.LTrimStr(AV5PropostaId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpconsultapropostac") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5PropostaId), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vPROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5PropostaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "DDC_PARTICIPANTES_Icontype", StringUtil.RTrim( Ddc_participantes_Icontype));
         GxWebStd.gx_hidden_field( context, "DDC_PARTICIPANTES_Icon", StringUtil.RTrim( Ddc_participantes_Icon));
         GxWebStd.gx_hidden_field( context, "DDC_PARTICIPANTES_Componentwidth", StringUtil.LTrim( StringUtil.NToC( (decimal)(Ddc_participantes_Componentwidth), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "UCPROPOSTA_Clientedocumento", StringUtil.RTrim( Ucproposta_Clientedocumento));
         GxWebStd.gx_hidden_field( context, "UCPROPOSTA_Clienterazaosocial", StringUtil.RTrim( Ucproposta_Clienterazaosocial));
         GxWebStd.gx_hidden_field( context, "UCPROPOSTA_Clientenomefantasia", StringUtil.RTrim( Ucproposta_Clientenomefantasia));
         GxWebStd.gx_hidden_field( context, "UCPROPOSTA_Clientetipopessoa", StringUtil.RTrim( Ucproposta_Clientetipopessoa));
         GxWebStd.gx_hidden_field( context, "UCPROPOSTA_Tipoclientedescricao", StringUtil.RTrim( Ucproposta_Tipoclientedescricao));
         GxWebStd.gx_hidden_field( context, "UCPROPOSTA_Enderecocep", StringUtil.RTrim( Ucproposta_Enderecocep));
         GxWebStd.gx_hidden_field( context, "UCPROPOSTA_Enderecologradouro", StringUtil.RTrim( Ucproposta_Enderecologradouro));
         GxWebStd.gx_hidden_field( context, "UCPROPOSTA_Enderecobairro", StringUtil.RTrim( Ucproposta_Enderecobairro));
         GxWebStd.gx_hidden_field( context, "UCPROPOSTA_Enderecocidade", StringUtil.RTrim( Ucproposta_Enderecocidade));
         GxWebStd.gx_hidden_field( context, "UCPROPOSTA_Municipionome", StringUtil.RTrim( Ucproposta_Municipionome));
         GxWebStd.gx_hidden_field( context, "UCPROPOSTA_Municipiouf", StringUtil.RTrim( Ucproposta_Municipiouf));
         GxWebStd.gx_hidden_field( context, "UCPROPOSTA_Endereconumero", StringUtil.RTrim( Ucproposta_Endereconumero));
         GxWebStd.gx_hidden_field( context, "UCPROPOSTA_Enderecocomplemento", StringUtil.RTrim( Ucproposta_Enderecocomplemento));
         GxWebStd.gx_hidden_field( context, "UCPROPOSTA_Contatoemail", StringUtil.RTrim( Ucproposta_Contatoemail));
         GxWebStd.gx_hidden_field( context, "UCPROPOSTA_Contatoddd", StringUtil.RTrim( Ucproposta_Contatoddd));
         GxWebStd.gx_hidden_field( context, "UCPROPOSTA_Contatonumero", StringUtil.RTrim( Ucproposta_Contatonumero));
         GxWebStd.gx_hidden_field( context, "UCPROPOSTA_Contatotelefonenumero", StringUtil.RTrim( Ucproposta_Contatotelefonenumero));
         GxWebStd.gx_hidden_field( context, "UCPROPOSTA_Contatotelefoneddd", StringUtil.RTrim( Ucproposta_Contatotelefoneddd));
         GxWebStd.gx_hidden_field( context, "UCPROPOSTA_Procedimentosmedicos", StringUtil.RTrim( Ucproposta_Procedimentosmedicos));
         GxWebStd.gx_hidden_field( context, "UCPROPOSTA_Propostavalor", StringUtil.RTrim( Ucproposta_Propostavalor));
         GxWebStd.gx_hidden_field( context, "UCPROPOSTA_Propostadescricao", StringUtil.RTrim( Ucproposta_Propostadescricao));
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
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            WebComp_Wwpaux_wc.componentjscripts();
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
            WE5U2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5U2( ) ;
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
         GXEncryptionTmp = "wpconsultapropostac"+UrlEncode(StringUtil.LTrimStr(AV5PropostaId,9,0));
         return formatLink("wpconsultapropostac") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WpConsultaPropostaC" ;
      }

      public override string GetPgmdesc( )
      {
         return "Proposta" ;
      }

      protected void WB5U0( )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "Center", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndownloadpdf_Internalname, "", "Download PDF", bttBtndownloadpdf_Jsonclick, 7, "Download PDF", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e115u1_client"+"'", TempTags, "", 2, "HLP_WpConsultaPropostaC.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "Center", "top", "", "", "div");
            /* User Defined Control */
            ucDdc_participantes.SetProperty("IconType", Ddc_participantes_Icontype);
            ucDdc_participantes.SetProperty("Icon", Ddc_participantes_Icon);
            ucDdc_participantes.SetProperty("Caption", Ddc_participantes_Caption);
            ucDdc_participantes.SetProperty("ComponentWidth", Ddc_participantes_Componentwidth);
            ucDdc_participantes.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_participantes_Internalname, "DDC_PARTICIPANTESContainer");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucUcproposta.Render(context, "ucpropostaconsulta", Ucproposta_Internalname, "UCPROPOSTAContainer");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", "Fechar", bttBtncancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpConsultaPropostaC.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0033"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0033"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0033"+"");
                  }
                  WebComp_Wwpaux_wc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
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
         }
         wbLoad = true;
      }

      protected void START5U2( )
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
         STRUP5U0( ) ;
      }

      protected void WS5U2( )
      {
         START5U2( ) ;
         EVT5U2( ) ;
      }

      protected void EVT5U2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "DDC_PARTICIPANTES.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddc_participantes.Onloadcomponent */
                              E125U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E135U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E145U2 ();
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
                        if ( nCmpId == 33 )
                        {
                           OldWwpaux_wc = cgiGet( "W0033");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0033", "", sEvt);
                           }
                           WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE5U2( )
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

      protected void PA5U2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpconsultapropostac")), "wpconsultapropostac") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpconsultapropostac")))) ;
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
         RF5U2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF5U2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  WebComp_Wwpaux_wc.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E145U2 ();
            WB5U0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes5U2( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5U0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E135U2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Ddc_participantes_Icontype = cgiGet( "DDC_PARTICIPANTES_Icontype");
            Ddc_participantes_Icon = cgiGet( "DDC_PARTICIPANTES_Icon");
            Ddc_participantes_Componentwidth = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DDC_PARTICIPANTES_Componentwidth"), ",", "."), 18, MidpointRounding.ToEven));
            Ucproposta_Clientedocumento = cgiGet( "UCPROPOSTA_Clientedocumento");
            Ucproposta_Clienterazaosocial = cgiGet( "UCPROPOSTA_Clienterazaosocial");
            Ucproposta_Clientenomefantasia = cgiGet( "UCPROPOSTA_Clientenomefantasia");
            Ucproposta_Clientetipopessoa = cgiGet( "UCPROPOSTA_Clientetipopessoa");
            Ucproposta_Tipoclientedescricao = cgiGet( "UCPROPOSTA_Tipoclientedescricao");
            Ucproposta_Enderecocep = cgiGet( "UCPROPOSTA_Enderecocep");
            Ucproposta_Enderecologradouro = cgiGet( "UCPROPOSTA_Enderecologradouro");
            Ucproposta_Enderecobairro = cgiGet( "UCPROPOSTA_Enderecobairro");
            Ucproposta_Enderecocidade = cgiGet( "UCPROPOSTA_Enderecocidade");
            Ucproposta_Municipionome = cgiGet( "UCPROPOSTA_Municipionome");
            Ucproposta_Municipiouf = cgiGet( "UCPROPOSTA_Municipiouf");
            Ucproposta_Endereconumero = cgiGet( "UCPROPOSTA_Endereconumero");
            Ucproposta_Enderecocomplemento = cgiGet( "UCPROPOSTA_Enderecocomplemento");
            Ucproposta_Contatoemail = cgiGet( "UCPROPOSTA_Contatoemail");
            Ucproposta_Contatoddd = cgiGet( "UCPROPOSTA_Contatoddd");
            Ucproposta_Contatonumero = cgiGet( "UCPROPOSTA_Contatonumero");
            Ucproposta_Contatotelefonenumero = cgiGet( "UCPROPOSTA_Contatotelefonenumero");
            Ucproposta_Contatotelefoneddd = cgiGet( "UCPROPOSTA_Contatotelefoneddd");
            Ucproposta_Procedimentosmedicos = cgiGet( "UCPROPOSTA_Procedimentosmedicos");
            Ucproposta_Propostavalor = cgiGet( "UCPROPOSTA_Propostavalor");
            Ucproposta_Propostadescricao = cgiGet( "UCPROPOSTA_Propostadescricao");
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
         E135U2 ();
         if (returnInSub) return;
      }

      protected void E135U2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Using cursor H005U2 */
         pr_default.execute(0, new Object[] {AV5PropostaId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A227ContratoId = H005U2_A227ContratoId[0];
            n227ContratoId = H005U2_n227ContratoId[0];
            A473ContratoClienteId = H005U2_A473ContratoClienteId[0];
            n473ContratoClienteId = H005U2_n473ContratoClienteId[0];
            A619ContratoClienteMunicipioCodigo = H005U2_A619ContratoClienteMunicipioCodigo[0];
            n619ContratoClienteMunicipioCodigo = H005U2_n619ContratoClienteMunicipioCodigo[0];
            A376ProcedimentosMedicosId = H005U2_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = H005U2_n376ProcedimentosMedicosId[0];
            A328PropostaCratedBy = H005U2_A328PropostaCratedBy[0];
            n328PropostaCratedBy = H005U2_n328PropostaCratedBy[0];
            A226SecUserOwnerId = H005U2_A226SecUserOwnerId[0];
            n226SecUserOwnerId = H005U2_n226SecUserOwnerId[0];
            A192TipoClienteId = H005U2_A192TipoClienteId[0];
            n192TipoClienteId = H005U2_n192TipoClienteId[0];
            A323PropostaId = H005U2_A323PropostaId[0];
            A169ClienteDocumento = H005U2_A169ClienteDocumento[0];
            n169ClienteDocumento = H005U2_n169ClienteDocumento[0];
            A171ClienteNomeFantasia = H005U2_A171ClienteNomeFantasia[0];
            n171ClienteNomeFantasia = H005U2_n171ClienteNomeFantasia[0];
            A170ClienteRazaoSocial = H005U2_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = H005U2_n170ClienteRazaoSocial[0];
            A172ClienteTipoPessoa = H005U2_A172ClienteTipoPessoa[0];
            n172ClienteTipoPessoa = H005U2_n172ClienteTipoPessoa[0];
            A193TipoClienteDescricao = H005U2_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = H005U2_n193TipoClienteDescricao[0];
            A182EnderecoCEP = H005U2_A182EnderecoCEP[0];
            n182EnderecoCEP = H005U2_n182EnderecoCEP[0];
            A183EnderecoLogradouro = H005U2_A183EnderecoLogradouro[0];
            n183EnderecoLogradouro = H005U2_n183EnderecoLogradouro[0];
            A184EnderecoBairro = H005U2_A184EnderecoBairro[0];
            n184EnderecoBairro = H005U2_n184EnderecoBairro[0];
            A185EnderecoCidade = H005U2_A185EnderecoCidade[0];
            n185EnderecoCidade = H005U2_n185EnderecoCidade[0];
            A187MunicipioNome = H005U2_A187MunicipioNome[0];
            n187MunicipioNome = H005U2_n187MunicipioNome[0];
            A189MunicipioUF = H005U2_A189MunicipioUF[0];
            n189MunicipioUF = H005U2_n189MunicipioUF[0];
            A190EnderecoNumero = H005U2_A190EnderecoNumero[0];
            n190EnderecoNumero = H005U2_n190EnderecoNumero[0];
            A191EnderecoComplemento = H005U2_A191EnderecoComplemento[0];
            n191EnderecoComplemento = H005U2_n191EnderecoComplemento[0];
            A201ContatoEmail = H005U2_A201ContatoEmail[0];
            n201ContatoEmail = H005U2_n201ContatoEmail[0];
            A198ContatoDDD = H005U2_A198ContatoDDD[0];
            n198ContatoDDD = H005U2_n198ContatoDDD[0];
            A200ContatoNumero = H005U2_A200ContatoNumero[0];
            n200ContatoNumero = H005U2_n200ContatoNumero[0];
            A202ContatoTelefoneNumero = H005U2_A202ContatoTelefoneNumero[0];
            n202ContatoTelefoneNumero = H005U2_n202ContatoTelefoneNumero[0];
            A203ContatoTelefoneDDD = H005U2_A203ContatoTelefoneDDD[0];
            n203ContatoTelefoneDDD = H005U2_n203ContatoTelefoneDDD[0];
            A378ProcedimentosMedicosDescricao = H005U2_A378ProcedimentosMedicosDescricao[0];
            n378ProcedimentosMedicosDescricao = H005U2_n378ProcedimentosMedicosDescricao[0];
            A377ProcedimentosMedicosNome = H005U2_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = H005U2_n377ProcedimentosMedicosNome[0];
            A326PropostaValor = H005U2_A326PropostaValor[0];
            n326PropostaValor = H005U2_n326PropostaValor[0];
            A325PropostaDescricao = H005U2_A325PropostaDescricao[0];
            n325PropostaDescricao = H005U2_n325PropostaDescricao[0];
            A473ContratoClienteId = H005U2_A473ContratoClienteId[0];
            n473ContratoClienteId = H005U2_n473ContratoClienteId[0];
            A619ContratoClienteMunicipioCodigo = H005U2_A619ContratoClienteMunicipioCodigo[0];
            n619ContratoClienteMunicipioCodigo = H005U2_n619ContratoClienteMunicipioCodigo[0];
            A192TipoClienteId = H005U2_A192TipoClienteId[0];
            n192TipoClienteId = H005U2_n192TipoClienteId[0];
            A171ClienteNomeFantasia = H005U2_A171ClienteNomeFantasia[0];
            n171ClienteNomeFantasia = H005U2_n171ClienteNomeFantasia[0];
            A185EnderecoCidade = H005U2_A185EnderecoCidade[0];
            n185EnderecoCidade = H005U2_n185EnderecoCidade[0];
            A201ContatoEmail = H005U2_A201ContatoEmail[0];
            n201ContatoEmail = H005U2_n201ContatoEmail[0];
            A198ContatoDDD = H005U2_A198ContatoDDD[0];
            n198ContatoDDD = H005U2_n198ContatoDDD[0];
            A200ContatoNumero = H005U2_A200ContatoNumero[0];
            n200ContatoNumero = H005U2_n200ContatoNumero[0];
            A202ContatoTelefoneNumero = H005U2_A202ContatoTelefoneNumero[0];
            n202ContatoTelefoneNumero = H005U2_n202ContatoTelefoneNumero[0];
            A203ContatoTelefoneDDD = H005U2_A203ContatoTelefoneDDD[0];
            n203ContatoTelefoneDDD = H005U2_n203ContatoTelefoneDDD[0];
            A187MunicipioNome = H005U2_A187MunicipioNome[0];
            n187MunicipioNome = H005U2_n187MunicipioNome[0];
            A189MunicipioUF = H005U2_A189MunicipioUF[0];
            n189MunicipioUF = H005U2_n189MunicipioUF[0];
            A193TipoClienteDescricao = H005U2_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = H005U2_n193TipoClienteDescricao[0];
            A378ProcedimentosMedicosDescricao = H005U2_A378ProcedimentosMedicosDescricao[0];
            n378ProcedimentosMedicosDescricao = H005U2_n378ProcedimentosMedicosDescricao[0];
            A377ProcedimentosMedicosNome = H005U2_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = H005U2_n377ProcedimentosMedicosNome[0];
            A226SecUserOwnerId = H005U2_A226SecUserOwnerId[0];
            n226SecUserOwnerId = H005U2_n226SecUserOwnerId[0];
            A169ClienteDocumento = H005U2_A169ClienteDocumento[0];
            n169ClienteDocumento = H005U2_n169ClienteDocumento[0];
            A170ClienteRazaoSocial = H005U2_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = H005U2_n170ClienteRazaoSocial[0];
            A172ClienteTipoPessoa = H005U2_A172ClienteTipoPessoa[0];
            n172ClienteTipoPessoa = H005U2_n172ClienteTipoPessoa[0];
            A182EnderecoCEP = H005U2_A182EnderecoCEP[0];
            n182EnderecoCEP = H005U2_n182EnderecoCEP[0];
            A183EnderecoLogradouro = H005U2_A183EnderecoLogradouro[0];
            n183EnderecoLogradouro = H005U2_n183EnderecoLogradouro[0];
            A184EnderecoBairro = H005U2_A184EnderecoBairro[0];
            n184EnderecoBairro = H005U2_n184EnderecoBairro[0];
            A190EnderecoNumero = H005U2_A190EnderecoNumero[0];
            n190EnderecoNumero = H005U2_n190EnderecoNumero[0];
            A191EnderecoComplemento = H005U2_A191EnderecoComplemento[0];
            n191EnderecoComplemento = H005U2_n191EnderecoComplemento[0];
            Ucproposta_Clientedocumento = A169ClienteDocumento;
            ucUcproposta.SendProperty(context, "", false, Ucproposta_Internalname, "ClienteDocumento", Ucproposta_Clientedocumento);
            Ucproposta_Clientenomefantasia = A171ClienteNomeFantasia;
            ucUcproposta.SendProperty(context, "", false, Ucproposta_Internalname, "ClienteNomeFantasia", Ucproposta_Clientenomefantasia);
            Ucproposta_Clienterazaosocial = A170ClienteRazaoSocial;
            ucUcproposta.SendProperty(context, "", false, Ucproposta_Internalname, "ClienteRazaoSocial", Ucproposta_Clienterazaosocial);
            Ucproposta_Clientetipopessoa = A172ClienteTipoPessoa;
            ucUcproposta.SendProperty(context, "", false, Ucproposta_Internalname, "ClienteTipoPessoa", Ucproposta_Clientetipopessoa);
            Ucproposta_Tipoclientedescricao = A193TipoClienteDescricao;
            ucUcproposta.SendProperty(context, "", false, Ucproposta_Internalname, "TipoClienteDescricao", Ucproposta_Tipoclientedescricao);
            Ucproposta_Enderecocep = A182EnderecoCEP;
            ucUcproposta.SendProperty(context, "", false, Ucproposta_Internalname, "EnderecoCEP", Ucproposta_Enderecocep);
            Ucproposta_Enderecologradouro = A183EnderecoLogradouro;
            ucUcproposta.SendProperty(context, "", false, Ucproposta_Internalname, "EnderecoLogradouro", Ucproposta_Enderecologradouro);
            Ucproposta_Enderecobairro = A184EnderecoBairro;
            ucUcproposta.SendProperty(context, "", false, Ucproposta_Internalname, "EnderecoBairro", Ucproposta_Enderecobairro);
            Ucproposta_Enderecocidade = A185EnderecoCidade;
            ucUcproposta.SendProperty(context, "", false, Ucproposta_Internalname, "EnderecoCidade", Ucproposta_Enderecocidade);
            Ucproposta_Municipionome = A187MunicipioNome;
            ucUcproposta.SendProperty(context, "", false, Ucproposta_Internalname, "MunicipioNome", Ucproposta_Municipionome);
            Ucproposta_Municipiouf = A189MunicipioUF;
            ucUcproposta.SendProperty(context, "", false, Ucproposta_Internalname, "MunicipioUF", Ucproposta_Municipiouf);
            Ucproposta_Endereconumero = A190EnderecoNumero;
            ucUcproposta.SendProperty(context, "", false, Ucproposta_Internalname, "EnderecoNumero", Ucproposta_Endereconumero);
            Ucproposta_Enderecocomplemento = A191EnderecoComplemento;
            ucUcproposta.SendProperty(context, "", false, Ucproposta_Internalname, "EnderecoComplemento", Ucproposta_Enderecocomplemento);
            Ucproposta_Contatoemail = A201ContatoEmail;
            ucUcproposta.SendProperty(context, "", false, Ucproposta_Internalname, "ContatoEmail", Ucproposta_Contatoemail);
            Ucproposta_Contatoddd = StringUtil.Str( (decimal)(A198ContatoDDD), 4, 0);
            ucUcproposta.SendProperty(context, "", false, Ucproposta_Internalname, "ContatoDDD", Ucproposta_Contatoddd);
            Ucproposta_Contatonumero = StringUtil.Str( (decimal)(A200ContatoNumero), 18, 0);
            ucUcproposta.SendProperty(context, "", false, Ucproposta_Internalname, "ContatoNumero", Ucproposta_Contatonumero);
            Ucproposta_Contatotelefonenumero = StringUtil.Str( (decimal)(A202ContatoTelefoneNumero), 18, 0);
            ucUcproposta.SendProperty(context, "", false, Ucproposta_Internalname, "ContatoTelefoneNumero", Ucproposta_Contatotelefonenumero);
            Ucproposta_Contatotelefoneddd = StringUtil.Str( (decimal)(A203ContatoTelefoneDDD), 4, 0);
            ucUcproposta.SendProperty(context, "", false, Ucproposta_Internalname, "ContatoTelefoneDDD", Ucproposta_Contatotelefoneddd);
            Ucproposta_Procedimentosmedicos = StringUtil.Format( "%1 - %2", A377ProcedimentosMedicosNome, A378ProcedimentosMedicosDescricao, "", "", "", "", "", "", "");
            ucUcproposta.SendProperty(context, "", false, Ucproposta_Internalname, "ProcedimentosMedicos", Ucproposta_Procedimentosmedicos);
            Ucproposta_Propostavalor = StringUtil.Format( "R$ %1", context.localUtil.Format( A326PropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"), "", "", "", "", "", "", "", "");
            ucUcproposta.SendProperty(context, "", false, Ucproposta_Internalname, "PropostaValor", Ucproposta_Propostavalor);
            Ucproposta_Propostadescricao = A325PropostaDescricao;
            ucUcproposta.SendProperty(context, "", false, Ucproposta_Internalname, "PropostaDescricao", Ucproposta_Propostadescricao);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
      }

      protected void E125U2( )
      {
         /* Ddc_participantes_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WcPropostaDocumento")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wcpropostadocumento", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WcPropostaDocumento";
            WebComp_Wwpaux_wc_Component = "WcPropostaDocumento";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0033",(string)"",(int)AV5PropostaId});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0033"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void nextLoad( )
      {
      }

      protected void E145U2( )
      {
         /* Load Routine */
         returnInSub = false;
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
         PA5U2( ) ;
         WS5U2( ) ;
         WE5U2( ) ;
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
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
            {
               WebComp_Wwpaux_wc.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019252170", true, true);
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
         context.AddJavascriptSource("wpconsultapropostac.js", "?202561019252171", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/UCPropostaConsultaRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtndownloadpdf_Internalname = "BTNDOWNLOADPDF";
         Ddc_participantes_Internalname = "DDC_PARTICIPANTES";
         divTableheader_Internalname = "TABLEHEADER";
         Ucproposta_Internalname = "UCPROPOSTA";
         bttBtncancel_Internalname = "BTNCANCEL";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC";
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
         Ddc_participantes_Caption = "";
         Ucproposta_Propostadescricao = "";
         Ucproposta_Propostavalor = "";
         Ucproposta_Procedimentosmedicos = "";
         Ucproposta_Contatotelefoneddd = "";
         Ucproposta_Contatotelefonenumero = "";
         Ucproposta_Contatonumero = "";
         Ucproposta_Contatoddd = "";
         Ucproposta_Contatoemail = "";
         Ucproposta_Enderecocomplemento = "";
         Ucproposta_Endereconumero = "";
         Ucproposta_Municipiouf = "";
         Ucproposta_Municipionome = "";
         Ucproposta_Enderecocidade = "";
         Ucproposta_Enderecobairro = "";
         Ucproposta_Enderecologradouro = "";
         Ucproposta_Enderecocep = "";
         Ucproposta_Tipoclientedescricao = "";
         Ucproposta_Clientetipopessoa = "";
         Ucproposta_Clientenomefantasia = "";
         Ucproposta_Clienterazaosocial = "";
         Ucproposta_Clientedocumento = "";
         Ddc_participantes_Componentwidth = 735;
         Ddc_participantes_Icon = "fas fa-folder";
         Ddc_participantes_Icontype = "FontIcon";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Proposta";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV5PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("'DODOWNLOADPDF'","""{"handler":"E115U1","iparms":[]}""");
         setEventMetadata("DDC_PARTICIPANTES.ONLOADCOMPONENT","""{"handler":"E125U2","iparms":[{"av":"AV5PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("DDC_PARTICIPANTES.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
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
         TempTags = "";
         bttBtndownloadpdf_Jsonclick = "";
         ucDdc_participantes = new GXUserControl();
         ucUcproposta = new GXUserControl();
         bttBtncancel_Jsonclick = "";
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         H005U2_A227ContratoId = new int[1] ;
         H005U2_n227ContratoId = new bool[] {false} ;
         H005U2_A473ContratoClienteId = new int[1] ;
         H005U2_n473ContratoClienteId = new bool[] {false} ;
         H005U2_A619ContratoClienteMunicipioCodigo = new string[] {""} ;
         H005U2_n619ContratoClienteMunicipioCodigo = new bool[] {false} ;
         H005U2_A376ProcedimentosMedicosId = new int[1] ;
         H005U2_n376ProcedimentosMedicosId = new bool[] {false} ;
         H005U2_A328PropostaCratedBy = new short[1] ;
         H005U2_n328PropostaCratedBy = new bool[] {false} ;
         H005U2_A226SecUserOwnerId = new int[1] ;
         H005U2_n226SecUserOwnerId = new bool[] {false} ;
         H005U2_A192TipoClienteId = new short[1] ;
         H005U2_n192TipoClienteId = new bool[] {false} ;
         H005U2_A323PropostaId = new int[1] ;
         H005U2_A169ClienteDocumento = new string[] {""} ;
         H005U2_n169ClienteDocumento = new bool[] {false} ;
         H005U2_A171ClienteNomeFantasia = new string[] {""} ;
         H005U2_n171ClienteNomeFantasia = new bool[] {false} ;
         H005U2_A170ClienteRazaoSocial = new string[] {""} ;
         H005U2_n170ClienteRazaoSocial = new bool[] {false} ;
         H005U2_A172ClienteTipoPessoa = new string[] {""} ;
         H005U2_n172ClienteTipoPessoa = new bool[] {false} ;
         H005U2_A193TipoClienteDescricao = new string[] {""} ;
         H005U2_n193TipoClienteDescricao = new bool[] {false} ;
         H005U2_A182EnderecoCEP = new string[] {""} ;
         H005U2_n182EnderecoCEP = new bool[] {false} ;
         H005U2_A183EnderecoLogradouro = new string[] {""} ;
         H005U2_n183EnderecoLogradouro = new bool[] {false} ;
         H005U2_A184EnderecoBairro = new string[] {""} ;
         H005U2_n184EnderecoBairro = new bool[] {false} ;
         H005U2_A185EnderecoCidade = new string[] {""} ;
         H005U2_n185EnderecoCidade = new bool[] {false} ;
         H005U2_A187MunicipioNome = new string[] {""} ;
         H005U2_n187MunicipioNome = new bool[] {false} ;
         H005U2_A189MunicipioUF = new string[] {""} ;
         H005U2_n189MunicipioUF = new bool[] {false} ;
         H005U2_A190EnderecoNumero = new string[] {""} ;
         H005U2_n190EnderecoNumero = new bool[] {false} ;
         H005U2_A191EnderecoComplemento = new string[] {""} ;
         H005U2_n191EnderecoComplemento = new bool[] {false} ;
         H005U2_A201ContatoEmail = new string[] {""} ;
         H005U2_n201ContatoEmail = new bool[] {false} ;
         H005U2_A198ContatoDDD = new short[1] ;
         H005U2_n198ContatoDDD = new bool[] {false} ;
         H005U2_A200ContatoNumero = new long[1] ;
         H005U2_n200ContatoNumero = new bool[] {false} ;
         H005U2_A202ContatoTelefoneNumero = new long[1] ;
         H005U2_n202ContatoTelefoneNumero = new bool[] {false} ;
         H005U2_A203ContatoTelefoneDDD = new short[1] ;
         H005U2_n203ContatoTelefoneDDD = new bool[] {false} ;
         H005U2_A378ProcedimentosMedicosDescricao = new string[] {""} ;
         H005U2_n378ProcedimentosMedicosDescricao = new bool[] {false} ;
         H005U2_A377ProcedimentosMedicosNome = new string[] {""} ;
         H005U2_n377ProcedimentosMedicosNome = new bool[] {false} ;
         H005U2_A326PropostaValor = new decimal[1] ;
         H005U2_n326PropostaValor = new bool[] {false} ;
         H005U2_A325PropostaDescricao = new string[] {""} ;
         H005U2_n325PropostaDescricao = new bool[] {false} ;
         A619ContratoClienteMunicipioCodigo = "";
         A169ClienteDocumento = "";
         A171ClienteNomeFantasia = "";
         A170ClienteRazaoSocial = "";
         A172ClienteTipoPessoa = "";
         A193TipoClienteDescricao = "";
         A182EnderecoCEP = "";
         A183EnderecoLogradouro = "";
         A184EnderecoBairro = "";
         A185EnderecoCidade = "";
         A187MunicipioNome = "";
         A189MunicipioUF = "";
         A190EnderecoNumero = "";
         A191EnderecoComplemento = "";
         A201ContatoEmail = "";
         A378ProcedimentosMedicosDescricao = "";
         A377ProcedimentosMedicosNome = "";
         A325PropostaDescricao = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpconsultapropostac__default(),
            new Object[][] {
                new Object[] {
               H005U2_A227ContratoId, H005U2_n227ContratoId, H005U2_A473ContratoClienteId, H005U2_n473ContratoClienteId, H005U2_A619ContratoClienteMunicipioCodigo, H005U2_n619ContratoClienteMunicipioCodigo, H005U2_A376ProcedimentosMedicosId, H005U2_n376ProcedimentosMedicosId, H005U2_A328PropostaCratedBy, H005U2_n328PropostaCratedBy,
               H005U2_A226SecUserOwnerId, H005U2_n226SecUserOwnerId, H005U2_A192TipoClienteId, H005U2_n192TipoClienteId, H005U2_A323PropostaId, H005U2_A169ClienteDocumento, H005U2_n169ClienteDocumento, H005U2_A171ClienteNomeFantasia, H005U2_n171ClienteNomeFantasia, H005U2_A170ClienteRazaoSocial,
               H005U2_n170ClienteRazaoSocial, H005U2_A172ClienteTipoPessoa, H005U2_n172ClienteTipoPessoa, H005U2_A193TipoClienteDescricao, H005U2_n193TipoClienteDescricao, H005U2_A182EnderecoCEP, H005U2_n182EnderecoCEP, H005U2_A183EnderecoLogradouro, H005U2_n183EnderecoLogradouro, H005U2_A184EnderecoBairro,
               H005U2_n184EnderecoBairro, H005U2_A185EnderecoCidade, H005U2_n185EnderecoCidade, H005U2_A187MunicipioNome, H005U2_n187MunicipioNome, H005U2_A189MunicipioUF, H005U2_n189MunicipioUF, H005U2_A190EnderecoNumero, H005U2_n190EnderecoNumero, H005U2_A191EnderecoComplemento,
               H005U2_n191EnderecoComplemento, H005U2_A201ContatoEmail, H005U2_n201ContatoEmail, H005U2_A198ContatoDDD, H005U2_n198ContatoDDD, H005U2_A200ContatoNumero, H005U2_n200ContatoNumero, H005U2_A202ContatoTelefoneNumero, H005U2_n202ContatoTelefoneNumero, H005U2_A203ContatoTelefoneDDD,
               H005U2_n203ContatoTelefoneDDD, H005U2_A378ProcedimentosMedicosDescricao, H005U2_n378ProcedimentosMedicosDescricao, H005U2_A377ProcedimentosMedicosNome, H005U2_n377ProcedimentosMedicosNome, H005U2_A326PropostaValor, H005U2_n326PropostaValor, H005U2_A325PropostaDescricao, H005U2_n325PropostaDescricao
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
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
      private short A328PropostaCratedBy ;
      private short A192TipoClienteId ;
      private short A198ContatoDDD ;
      private short A203ContatoTelefoneDDD ;
      private short nGXWrapped ;
      private int AV5PropostaId ;
      private int wcpOAV5PropostaId ;
      private int Ddc_participantes_Componentwidth ;
      private int A227ContratoId ;
      private int A473ContratoClienteId ;
      private int A376ProcedimentosMedicosId ;
      private int A226SecUserOwnerId ;
      private int A323PropostaId ;
      private int idxLst ;
      private long A200ContatoNumero ;
      private long A202ContatoTelefoneNumero ;
      private decimal A326PropostaValor ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Ddc_participantes_Icontype ;
      private string Ddc_participantes_Icon ;
      private string Ucproposta_Clientedocumento ;
      private string Ucproposta_Clienterazaosocial ;
      private string Ucproposta_Clientenomefantasia ;
      private string Ucproposta_Clientetipopessoa ;
      private string Ucproposta_Tipoclientedescricao ;
      private string Ucproposta_Enderecocep ;
      private string Ucproposta_Enderecologradouro ;
      private string Ucproposta_Enderecobairro ;
      private string Ucproposta_Enderecocidade ;
      private string Ucproposta_Municipionome ;
      private string Ucproposta_Municipiouf ;
      private string Ucproposta_Endereconumero ;
      private string Ucproposta_Enderecocomplemento ;
      private string Ucproposta_Contatoemail ;
      private string Ucproposta_Contatoddd ;
      private string Ucproposta_Contatonumero ;
      private string Ucproposta_Contatotelefonenumero ;
      private string Ucproposta_Contatotelefoneddd ;
      private string Ucproposta_Procedimentosmedicos ;
      private string Ucproposta_Propostavalor ;
      private string Ucproposta_Propostadescricao ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divTableheader_Internalname ;
      private string TempTags ;
      private string bttBtndownloadpdf_Internalname ;
      private string bttBtndownloadpdf_Jsonclick ;
      private string Ddc_participantes_Caption ;
      private string Ddc_participantes_Internalname ;
      private string Ucproposta_Internalname ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n227ContratoId ;
      private bool n473ContratoClienteId ;
      private bool n619ContratoClienteMunicipioCodigo ;
      private bool n376ProcedimentosMedicosId ;
      private bool n328PropostaCratedBy ;
      private bool n226SecUserOwnerId ;
      private bool n192TipoClienteId ;
      private bool n169ClienteDocumento ;
      private bool n171ClienteNomeFantasia ;
      private bool n170ClienteRazaoSocial ;
      private bool n172ClienteTipoPessoa ;
      private bool n193TipoClienteDescricao ;
      private bool n182EnderecoCEP ;
      private bool n183EnderecoLogradouro ;
      private bool n184EnderecoBairro ;
      private bool n185EnderecoCidade ;
      private bool n187MunicipioNome ;
      private bool n189MunicipioUF ;
      private bool n190EnderecoNumero ;
      private bool n191EnderecoComplemento ;
      private bool n201ContatoEmail ;
      private bool n198ContatoDDD ;
      private bool n200ContatoNumero ;
      private bool n202ContatoTelefoneNumero ;
      private bool n203ContatoTelefoneDDD ;
      private bool n378ProcedimentosMedicosDescricao ;
      private bool n377ProcedimentosMedicosNome ;
      private bool n326PropostaValor ;
      private bool n325PropostaDescricao ;
      private bool bDynCreated_Wwpaux_wc ;
      private string A378ProcedimentosMedicosDescricao ;
      private string A619ContratoClienteMunicipioCodigo ;
      private string A169ClienteDocumento ;
      private string A171ClienteNomeFantasia ;
      private string A170ClienteRazaoSocial ;
      private string A172ClienteTipoPessoa ;
      private string A193TipoClienteDescricao ;
      private string A182EnderecoCEP ;
      private string A183EnderecoLogradouro ;
      private string A184EnderecoBairro ;
      private string A185EnderecoCidade ;
      private string A187MunicipioNome ;
      private string A189MunicipioUF ;
      private string A190EnderecoNumero ;
      private string A191EnderecoComplemento ;
      private string A201ContatoEmail ;
      private string A377ProcedimentosMedicosNome ;
      private string A325PropostaDescricao ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXUserControl ucDdc_participantes ;
      private GXUserControl ucUcproposta ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] H005U2_A227ContratoId ;
      private bool[] H005U2_n227ContratoId ;
      private int[] H005U2_A473ContratoClienteId ;
      private bool[] H005U2_n473ContratoClienteId ;
      private string[] H005U2_A619ContratoClienteMunicipioCodigo ;
      private bool[] H005U2_n619ContratoClienteMunicipioCodigo ;
      private int[] H005U2_A376ProcedimentosMedicosId ;
      private bool[] H005U2_n376ProcedimentosMedicosId ;
      private short[] H005U2_A328PropostaCratedBy ;
      private bool[] H005U2_n328PropostaCratedBy ;
      private int[] H005U2_A226SecUserOwnerId ;
      private bool[] H005U2_n226SecUserOwnerId ;
      private short[] H005U2_A192TipoClienteId ;
      private bool[] H005U2_n192TipoClienteId ;
      private int[] H005U2_A323PropostaId ;
      private string[] H005U2_A169ClienteDocumento ;
      private bool[] H005U2_n169ClienteDocumento ;
      private string[] H005U2_A171ClienteNomeFantasia ;
      private bool[] H005U2_n171ClienteNomeFantasia ;
      private string[] H005U2_A170ClienteRazaoSocial ;
      private bool[] H005U2_n170ClienteRazaoSocial ;
      private string[] H005U2_A172ClienteTipoPessoa ;
      private bool[] H005U2_n172ClienteTipoPessoa ;
      private string[] H005U2_A193TipoClienteDescricao ;
      private bool[] H005U2_n193TipoClienteDescricao ;
      private string[] H005U2_A182EnderecoCEP ;
      private bool[] H005U2_n182EnderecoCEP ;
      private string[] H005U2_A183EnderecoLogradouro ;
      private bool[] H005U2_n183EnderecoLogradouro ;
      private string[] H005U2_A184EnderecoBairro ;
      private bool[] H005U2_n184EnderecoBairro ;
      private string[] H005U2_A185EnderecoCidade ;
      private bool[] H005U2_n185EnderecoCidade ;
      private string[] H005U2_A187MunicipioNome ;
      private bool[] H005U2_n187MunicipioNome ;
      private string[] H005U2_A189MunicipioUF ;
      private bool[] H005U2_n189MunicipioUF ;
      private string[] H005U2_A190EnderecoNumero ;
      private bool[] H005U2_n190EnderecoNumero ;
      private string[] H005U2_A191EnderecoComplemento ;
      private bool[] H005U2_n191EnderecoComplemento ;
      private string[] H005U2_A201ContatoEmail ;
      private bool[] H005U2_n201ContatoEmail ;
      private short[] H005U2_A198ContatoDDD ;
      private bool[] H005U2_n198ContatoDDD ;
      private long[] H005U2_A200ContatoNumero ;
      private bool[] H005U2_n200ContatoNumero ;
      private long[] H005U2_A202ContatoTelefoneNumero ;
      private bool[] H005U2_n202ContatoTelefoneNumero ;
      private short[] H005U2_A203ContatoTelefoneDDD ;
      private bool[] H005U2_n203ContatoTelefoneDDD ;
      private string[] H005U2_A378ProcedimentosMedicosDescricao ;
      private bool[] H005U2_n378ProcedimentosMedicosDescricao ;
      private string[] H005U2_A377ProcedimentosMedicosNome ;
      private bool[] H005U2_n377ProcedimentosMedicosNome ;
      private decimal[] H005U2_A326PropostaValor ;
      private bool[] H005U2_n326PropostaValor ;
      private string[] H005U2_A325PropostaDescricao ;
      private bool[] H005U2_n325PropostaDescricao ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpconsultapropostac__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH005U2;
          prmH005U2 = new Object[] {
          new ParDef("AV5PropostaId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("H005U2", "SELECT T1.ContratoId, T2.ContratoClienteId AS ContratoClienteId, T3.MunicipioCodigo AS ContratoClienteMunicipioCodigo, T1.ProcedimentosMedicosId, T1.PropostaCratedBy AS PropostaCratedBy, T7.SecUserOwnerId AS SecUserOwnerId, T3.TipoClienteId, T1.PropostaId, T8.ClienteDocumento, T3.ClienteNomeFantasia, T8.ClienteRazaoSocial, T8.ClienteTipoPessoa, T5.TipoClienteDescricao, T8.EnderecoCEP, T8.EnderecoLogradouro, T8.EnderecoBairro, T3.EnderecoCidade, T4.MunicipioNome, T4.MunicipioUF, T8.EnderecoNumero, T8.EnderecoComplemento, T3.ContatoEmail, T3.ContatoDDD, T3.ContatoNumero, T3.ContatoTelefoneNumero, T3.ContatoTelefoneDDD, T6.ProcedimentosMedicosDescricao, T6.ProcedimentosMedicosNome, T1.PropostaValor, T1.PropostaDescricao FROM (((((((Proposta T1 LEFT JOIN Contrato T2 ON T2.ContratoId = T1.ContratoId) LEFT JOIN Cliente T3 ON T3.ClienteId = T2.ContratoClienteId) LEFT JOIN Municipio T4 ON T4.MunicipioCodigo = T3.MunicipioCodigo) LEFT JOIN TipoCliente T5 ON T5.TipoClienteId = T3.TipoClienteId) LEFT JOIN ProcedimentosMedicos T6 ON T6.ProcedimentosMedicosId = T1.ProcedimentosMedicosId) LEFT JOIN SecUser T7 ON T7.SecUserId = T1.PropostaCratedBy) LEFT JOIN Cliente T8 ON T8.ClienteId = T7.SecUserOwnerId) WHERE T1.PropostaId = :AV5PropostaId ORDER BY T1.PropostaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005U2,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((short[]) buf[8])[0] = rslt.getShort(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((short[]) buf[12])[0] = rslt.getShort(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
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
                ((short[]) buf[43])[0] = rslt.getShort(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((long[]) buf[45])[0] = rslt.getLong(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((long[]) buf[47])[0] = rslt.getLong(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((short[]) buf[49])[0] = rslt.getShort(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((string[]) buf[51])[0] = rslt.getLongVarchar(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((string[]) buf[53])[0] = rslt.getVarchar(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((decimal[]) buf[55])[0] = rslt.getDecimal(29);
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((string[]) buf[57])[0] = rslt.getVarchar(30);
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                return;
       }
    }

 }

}
