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
   public class novoparticipanteassinatura : GXDataArea
   {
      public novoparticipanteassinatura( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public novoparticipanteassinatura( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_JSON ,
                           string aP1_StringGUID )
      {
         this.AV15JSON = aP0_JSON;
         this.AV22StringGUID = aP1_StringGUID;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavTipopessoa = new GXCombobox();
         cmbavTipoassinante = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
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
         PA9S2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START9S2( ) ;
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
         context.AddJavascriptSource("DVelop/DVMessage/pnotify.custom.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVMessage/DVMessageRender.js", "", false, true);
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
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "novoparticipanteassinatura"+UrlEncode(StringUtil.RTrim(AV15JSON)) + "," + UrlEncode(StringUtil.RTrim(AV22StringGUID));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("novoparticipanteassinatura") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vARRAY_SDPARTICIPANTES", AV17Array_SdParticipantes);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vARRAY_SDPARTICIPANTES", AV17Array_SdParticipantes);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vARRAY_SDPARTICIPANTES", GetSecureSignedToken( "", AV17Array_SdParticipantes, context));
         GxWebStd.gx_hidden_field( context, "vJSON", AV15JSON);
         GxWebStd.gx_hidden_field( context, "gxhash_vJSON", GetSecureSignedToken( "", AV15JSON, context));
         GxWebStd.gx_hidden_field( context, "vSTRINGGUID", AV22StringGUID);
         GxWebStd.gx_hidden_field( context, "gxhash_vSTRINGGUID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV22StringGUID, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_boolean_hidden_field( context, "vCHECKREQUIREDFIELDSRESULT", AV12CheckRequiredFieldsResult);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDPARTICIPANTES", AV13SdParticipantes);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDPARTICIPANTES", AV13SdParticipantes);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vARRAY_SDPARTICIPANTES", AV17Array_SdParticipantes);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vARRAY_SDPARTICIPANTES", AV17Array_SdParticipantes);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vARRAY_SDPARTICIPANTES", GetSecureSignedToken( "", AV17Array_SdParticipantes, context));
         GxWebStd.gx_hidden_field( context, "vJSON", AV15JSON);
         GxWebStd.gx_hidden_field( context, "gxhash_vJSON", GetSecureSignedToken( "", AV15JSON, context));
         GxWebStd.gx_hidden_field( context, "vSTRINGGUID", AV22StringGUID);
         GxWebStd.gx_hidden_field( context, "gxhash_vSTRINGGUID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV22StringGUID, "")), context));
         GxWebStd.gx_hidden_field( context, "UCMESSAGE_Width", StringUtil.RTrim( Ucmessage_Width));
         GxWebStd.gx_hidden_field( context, "UCMESSAGE_Minheight", StringUtil.RTrim( Ucmessage_Minheight));
         GxWebStd.gx_hidden_field( context, "UCMESSAGE_Stylingtype", StringUtil.RTrim( Ucmessage_Stylingtype));
         GxWebStd.gx_hidden_field( context, "UCMESSAGE_Stoponerror", StringUtil.BoolToStr( Ucmessage_Stoponerror));
         GxWebStd.gx_hidden_field( context, "UCMESSAGE_Effectin", StringUtil.RTrim( Ucmessage_Effectin));
         GxWebStd.gx_hidden_field( context, "UCMESSAGE_Effectout", StringUtil.RTrim( Ucmessage_Effectout));
         GxWebStd.gx_hidden_field( context, "UCMESSAGE_Animationspeed", StringUtil.LTrim( StringUtil.NToC( (decimal)(Ucmessage_Animationspeed), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "UCMESSAGE_Startposition", StringUtil.RTrim( Ucmessage_Startposition));
         GxWebStd.gx_hidden_field( context, "UCMESSAGE_Nextmessageposition", StringUtil.RTrim( Ucmessage_Nextmessageposition));
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
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE9S2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT9S2( ) ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "novoparticipanteassinatura"+UrlEncode(StringUtil.RTrim(AV15JSON)) + "," + UrlEncode(StringUtil.RTrim(AV22StringGUID));
         return formatLink("novoparticipanteassinatura") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "NovoParticipanteAssinatura" ;
      }

      public override string GetPgmdesc( )
      {
         return "Participante assinatura" ;
      }

      protected void WB9S0( )
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", divTablemain_Height, "px", "TableMain", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", "Confirmar", bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_NovoParticipanteAssinatura.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavNome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNome_Internalname, "Nome", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNome_Internalname, AV5Nome, StringUtil.RTrim( context.localUtil.Format( AV5Nome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,17);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_NovoParticipanteAssinatura.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavTipopessoa_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavTipopessoa_Internalname, "Tipo pessoa", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavTipopessoa, cmbavTipopessoa_Internalname, StringUtil.RTrim( AV6TipoPessoa), 1, cmbavTipopessoa_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavTipopessoa.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "", true, 0, "HLP_NovoParticipanteAssinatura.htm");
            cmbavTipopessoa.CurrentValue = StringUtil.RTrim( AV6TipoPessoa);
            AssignProp("", false, cmbavTipopessoa_Internalname, "Values", (string)(cmbavTipopessoa.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmail_Internalname, "Email", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmail_Internalname, AV7Email, StringUtil.RTrim( context.localUtil.Format( AV7Email, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+AV7Email, "", "", "", edtavEmail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_NovoParticipanteAssinatura.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCpfcnpj_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpfcnpj_Internalname, "CPF/CNPJ", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCpfcnpj_Internalname, AV8CPFCNPJ, StringUtil.RTrim( context.localUtil.Format( AV8CPFCNPJ, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpfcnpj_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavCpfcnpj_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_NovoParticipanteAssinatura.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavTipoassinante_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavTipoassinante_Internalname, "Papel", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavTipoassinante, cmbavTipoassinante_Internalname, StringUtil.RTrim( AV14TipoAssinante), 1, cmbavTipoassinante_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavTipoassinante.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "", true, 0, "HLP_NovoParticipanteAssinatura.htm");
            cmbavTipoassinante.CurrentValue = StringUtil.RTrim( AV14TipoAssinante);
            AssignProp("", false, cmbavTipoassinante_Internalname, "Values", (string)(cmbavTipoassinante.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableresponsavelassinaturajuridica_Internalname, divTableresponsavelassinaturajuridica_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, "Responsável", 1, 0, "px", 0, "px", "Group", "", "HLP_NovoParticipanteAssinatura.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGpresponsavel_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divNomeresponsavel_cell_Internalname, 1, 0, "px", 0, "px", divNomeresponsavel_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavNomeresponsavel_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNomeresponsavel_Internalname, "Nome", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNomeresponsavel_Internalname, AV9NomeResponsavel, StringUtil.RTrim( context.localUtil.Format( AV9NomeResponsavel, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNomeresponsavel_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavNomeresponsavel_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_NovoParticipanteAssinatura.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divEmailresponsavel_cell_Internalname, 1, 0, "px", 0, "px", divEmailresponsavel_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmailresponsavel_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmailresponsavel_Internalname, "Email", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmailresponsavel_Internalname, AV10EmailResponsavel, StringUtil.RTrim( context.localUtil.Format( AV10EmailResponsavel, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+AV10EmailResponsavel, "", "", "", edtavEmailresponsavel_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmailresponsavel_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_NovoParticipanteAssinatura.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCpfresponsavel_cell_Internalname, 1, 0, "px", 0, "px", divCpfresponsavel_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCpfresponsavel_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpfresponsavel_Internalname, "CPF", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCpfresponsavel_Internalname, AV11CPFResponsavel, StringUtil.RTrim( context.localUtil.Format( AV11CPFResponsavel, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpfresponsavel_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavCpfresponsavel_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_NovoParticipanteAssinatura.htm");
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
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucUcmessage.SetProperty("Width", Ucmessage_Width);
            ucUcmessage.SetProperty("MinHeight", Ucmessage_Minheight);
            ucUcmessage.SetProperty("StylingType", Ucmessage_Stylingtype);
            ucUcmessage.SetProperty("StopOnError", Ucmessage_Stoponerror);
            ucUcmessage.SetProperty("EffectIn", Ucmessage_Effectin);
            ucUcmessage.SetProperty("EffectOut", Ucmessage_Effectout);
            ucUcmessage.SetProperty("AnimationSpeed", Ucmessage_Animationspeed);
            ucUcmessage.SetProperty("StartPosition", Ucmessage_Startposition);
            ucUcmessage.SetProperty("NextMessagePosition", Ucmessage_Nextmessageposition);
            ucUcmessage.Render(context, "dvelop.dvmessage", Ucmessage_Internalname, "UCMESSAGEContainer");
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

      protected void START9S2( )
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
         Form.Meta.addItem("description", "Participante assinatura", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP9S0( ) ;
      }

      protected void WS9S2( )
      {
         START9S2( ) ;
         EVT9S2( ) ;
      }

      protected void EVT9S2( )
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
                              E119S2 ();
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
                                    E129S2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VCPFCNPJ.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E139S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VCPFRESPONSAVEL.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E149S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VEMAIL.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E159S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VEMAILRESPONSAVEL.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E169S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E179S2 ();
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

      protected void WE9S2( )
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

      protected void PA9S2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "novoparticipanteassinatura")), "novoparticipanteassinatura") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "novoparticipanteassinatura")))) ;
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
                  gxfirstwebparm = GetFirstPar( "JSON");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV15JSON = gxfirstwebparm;
                     AssignAttri("", false, "AV15JSON", AV15JSON);
                     GxWebStd.gx_hidden_field( context, "gxhash_vJSON", GetSecureSignedToken( "", AV15JSON, context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV22StringGUID = GetPar( "StringGUID");
                        AssignAttri("", false, "AV22StringGUID", AV22StringGUID);
                        GxWebStd.gx_hidden_field( context, "gxhash_vSTRINGGUID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV22StringGUID, "")), context));
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
               GX_FocusControl = edtavNome_Internalname;
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
         if ( cmbavTipopessoa.ItemCount > 0 )
         {
            AV6TipoPessoa = cmbavTipopessoa.getValidValue(AV6TipoPessoa);
            AssignAttri("", false, "AV6TipoPessoa", AV6TipoPessoa);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavTipopessoa.CurrentValue = StringUtil.RTrim( AV6TipoPessoa);
            AssignProp("", false, cmbavTipopessoa_Internalname, "Values", cmbavTipopessoa.ToJavascriptSource(), true);
         }
         if ( cmbavTipoassinante.ItemCount > 0 )
         {
            AV14TipoAssinante = cmbavTipoassinante.getValidValue(AV14TipoAssinante);
            AssignAttri("", false, "AV14TipoAssinante", AV14TipoAssinante);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavTipoassinante.CurrentValue = StringUtil.RTrim( AV14TipoAssinante);
            AssignProp("", false, cmbavTipoassinante_Internalname, "Values", cmbavTipoassinante.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF9S2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF9S2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E179S2 ();
            WB9S0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes9S2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vARRAY_SDPARTICIPANTES", AV17Array_SdParticipantes);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vARRAY_SDPARTICIPANTES", AV17Array_SdParticipantes);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vARRAY_SDPARTICIPANTES", GetSecureSignedToken( "", AV17Array_SdParticipantes, context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP9S0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E119S2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Ucmessage_Width = cgiGet( "UCMESSAGE_Width");
            Ucmessage_Minheight = cgiGet( "UCMESSAGE_Minheight");
            Ucmessage_Stylingtype = cgiGet( "UCMESSAGE_Stylingtype");
            Ucmessage_Stoponerror = StringUtil.StrToBool( cgiGet( "UCMESSAGE_Stoponerror"));
            Ucmessage_Effectin = cgiGet( "UCMESSAGE_Effectin");
            Ucmessage_Effectout = cgiGet( "UCMESSAGE_Effectout");
            Ucmessage_Animationspeed = (int)(Math.Round(context.localUtil.CToN( cgiGet( "UCMESSAGE_Animationspeed"), ",", "."), 18, MidpointRounding.ToEven));
            Ucmessage_Startposition = cgiGet( "UCMESSAGE_Startposition");
            Ucmessage_Nextmessageposition = cgiGet( "UCMESSAGE_Nextmessageposition");
            /* Read variables values. */
            AV5Nome = cgiGet( edtavNome_Internalname);
            AssignAttri("", false, "AV5Nome", AV5Nome);
            cmbavTipopessoa.CurrentValue = cgiGet( cmbavTipopessoa_Internalname);
            AV6TipoPessoa = cgiGet( cmbavTipopessoa_Internalname);
            AssignAttri("", false, "AV6TipoPessoa", AV6TipoPessoa);
            AV7Email = cgiGet( edtavEmail_Internalname);
            AssignAttri("", false, "AV7Email", AV7Email);
            AV8CPFCNPJ = cgiGet( edtavCpfcnpj_Internalname);
            AssignAttri("", false, "AV8CPFCNPJ", AV8CPFCNPJ);
            cmbavTipoassinante.CurrentValue = cgiGet( cmbavTipoassinante_Internalname);
            AV14TipoAssinante = cgiGet( cmbavTipoassinante_Internalname);
            AssignAttri("", false, "AV14TipoAssinante", AV14TipoAssinante);
            AV9NomeResponsavel = cgiGet( edtavNomeresponsavel_Internalname);
            AssignAttri("", false, "AV9NomeResponsavel", AV9NomeResponsavel);
            AV10EmailResponsavel = cgiGet( edtavEmailresponsavel_Internalname);
            AssignAttri("", false, "AV10EmailResponsavel", AV10EmailResponsavel);
            AV11CPFResponsavel = cgiGet( edtavCpfresponsavel_Internalname);
            AssignAttri("", false, "AV11CPFResponsavel", AV11CPFResponsavel);
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
         E119S2 ();
         if (returnInSub) return;
      }

      protected void E119S2( )
      {
         /* Start Routine */
         returnInSub = false;
         divTablemain_Height = 850;
         AssignProp("", false, divTablemain_Internalname, "Height", StringUtil.LTrimStr( (decimal)(divTablemain_Height), 9, 0), true);
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if (returnInSub) return;
         AV16Array_JSON = AV23WEBSESSION.Get(AV22StringGUID);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16Array_JSON)) )
         {
            AV17Array_SdParticipantes = new GXBaseCollection<SdtSdParticipantes>( context, "SdParticipantes", "Factory21");
            AV17Array_SdParticipantes.FromJSonString(AV16Array_JSON, null);
            AV23WEBSESSION.Remove(AV22StringGUID);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15JSON)) )
         {
            AV13SdParticipantes.FromJSonString(AV15JSON, null);
            AV5Nome = AV13SdParticipantes.gxTpr_Participantenome;
            AssignAttri("", false, "AV5Nome", AV5Nome);
            AV8CPFCNPJ = AV13SdParticipantes.gxTpr_Participantedocumento;
            AssignAttri("", false, "AV8CPFCNPJ", AV8CPFCNPJ);
            AV7Email = AV13SdParticipantes.gxTpr_Participanteemail;
            AssignAttri("", false, "AV7Email", AV7Email);
            AV14TipoAssinante = AV13SdParticipantes.gxTpr_Assinaturaparticipantetipo;
            AssignAttri("", false, "AV14TipoAssinante", AV14TipoAssinante);
            AV6TipoPessoa = AV13SdParticipantes.gxTpr_Participantetipopessoa;
            AssignAttri("", false, "AV6TipoPessoa", AV6TipoPessoa);
            AV9NomeResponsavel = AV13SdParticipantes.gxTpr_Participanterepresentantenome;
            AssignAttri("", false, "AV9NomeResponsavel", AV9NomeResponsavel);
            AV10EmailResponsavel = AV13SdParticipantes.gxTpr_Participanterepresentanteemail;
            AssignAttri("", false, "AV10EmailResponsavel", AV10EmailResponsavel);
            AV11CPFResponsavel = AV13SdParticipantes.gxTpr_Participanterepresentantedocumento;
            AssignAttri("", false, "AV11CPFResponsavel", AV11CPFResponsavel);
         }
         if ( StringUtil.StrCmp(AV6TipoPessoa, "JURIDICA") == 0 )
         {
            divTableresponsavelassinaturajuridica_Visible = 1;
            AssignProp("", false, divTableresponsavelassinaturajuridica_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableresponsavelassinaturajuridica_Visible), 5, 0), true);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E129S2 ();
         if (returnInSub) return;
      }

      protected void E129S2( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S122 ();
         if (returnInSub) return;
         if ( AV12CheckRequiredFieldsResult )
         {
            if ( (0==AV13SdParticipantes.gxTpr_Participanteid) )
            {
               AV13SdParticipantes = new SdtSdParticipantes(context);
               AV13SdParticipantes.gxTpr_Participanteid = (int)(AV17Array_SdParticipantes.Count+1);
            }
            AV13SdParticipantes.gxTpr_Participantenome = AV5Nome;
            AV13SdParticipantes.gxTpr_Participantedocumento = AV8CPFCNPJ;
            AV13SdParticipantes.gxTpr_Participanteemail = AV7Email;
            AV13SdParticipantes.gxTpr_Assinaturaparticipantetipo = AV14TipoAssinante;
            AV13SdParticipantes.gxTpr_Participantetipopessoa = AV6TipoPessoa;
            if ( StringUtil.StrCmp(AV6TipoPessoa, "JURIDICA") == 0 )
            {
               AV13SdParticipantes.gxTpr_Participanterepresentantenome = AV9NomeResponsavel;
               AV13SdParticipantes.gxTpr_Participanterepresentanteemail = AV10EmailResponsavel;
               AV13SdParticipantes.gxTpr_Participanterepresentantedocumento = AV11CPFResponsavel;
            }
            this.executeExternalObjectMethod("", false, "GlobalEvents", "AssinarContrato_AdicionarParticipante", new Object[] {AV13SdParticipantes.ToJSonString(false, true)}, true);
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13SdParticipantes", AV13SdParticipantes);
      }

      protected void S122( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV12CheckRequiredFieldsResult = true;
         AssignAttri("", false, "AV12CheckRequiredFieldsResult", AV12CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV5Nome)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Nome", "", "", "", "", "", "", "", ""),  "error",  edtavNome_Internalname,  "true",  ""));
            AV12CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV12CheckRequiredFieldsResult", AV12CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV6TipoPessoa)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Tipo pessoa", "", "", "", "", "", "", "", ""),  "error",  cmbavTipopessoa_Internalname,  "true",  ""));
            AV12CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV12CheckRequiredFieldsResult", AV12CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV7Email)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Email", "", "", "", "", "", "", "", ""),  "error",  edtavEmail_Internalname,  "true",  ""));
            AV12CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV12CheckRequiredFieldsResult", AV12CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV8CPFCNPJ)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "CPF/CNPJ", "", "", "", "", "", "", "", ""),  "error",  edtavCpfcnpj_Internalname,  "true",  ""));
            AV12CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV12CheckRequiredFieldsResult", AV12CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TipoAssinante)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Papel", "", "", "", "", "", "", "", ""),  "error",  cmbavTipoassinante_Internalname,  "true",  ""));
            AV12CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV12CheckRequiredFieldsResult", AV12CheckRequiredFieldsResult);
         }
         if ( ( ( StringUtil.StrCmp(AV6TipoPessoa, "JURIDICA") == 0 ) ) && String.IsNullOrEmpty(StringUtil.RTrim( AV9NomeResponsavel)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Nome", "", "", "", "", "", "", "", ""),  "error",  edtavNomeresponsavel_Internalname,  "true",  ""));
            AV12CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV12CheckRequiredFieldsResult", AV12CheckRequiredFieldsResult);
         }
         if ( ( ( StringUtil.StrCmp(AV6TipoPessoa, "JURIDICA") == 0 ) ) && String.IsNullOrEmpty(StringUtil.RTrim( AV10EmailResponsavel)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Email", "", "", "", "", "", "", "", ""),  "error",  edtavEmailresponsavel_Internalname,  "true",  ""));
            AV12CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV12CheckRequiredFieldsResult", AV12CheckRequiredFieldsResult);
         }
         if ( ( ( StringUtil.StrCmp(AV6TipoPessoa, "JURIDICA") == 0 ) ) && String.IsNullOrEmpty(StringUtil.RTrim( AV11CPFResponsavel)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "CPF", "", "", "", "", "", "", "", ""),  "error",  edtavCpfresponsavel_Internalname,  "true",  ""));
            AV12CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV12CheckRequiredFieldsResult", AV12CheckRequiredFieldsResult);
         }
         /* Execute user subroutine: 'VALIDAEMAIL' */
         S152 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'VALIDACPF' */
         S142 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'VALIDACPFCNPJ' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'VALIDATIPOPARTICIPANTE' */
         S172 ();
         if (returnInSub) return;
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV6TipoPessoa, "JURIDICA") == 0 )
         {
            divNomeresponsavel_cell_Class = "col-xs-12 DataContentCellFL RequiredDataContentCellFL";
            AssignProp("", false, divNomeresponsavel_cell_Internalname, "Class", divNomeresponsavel_cell_Class, true);
         }
         else
         {
            divNomeresponsavel_cell_Class = "col-xs-12 DataContentCellFL";
            AssignProp("", false, divNomeresponsavel_cell_Internalname, "Class", divNomeresponsavel_cell_Class, true);
         }
         if ( StringUtil.StrCmp(AV6TipoPessoa, "JURIDICA") == 0 )
         {
            divEmailresponsavel_cell_Class = "col-xs-12 DataContentCellFL RequiredDataContentCellFL";
            AssignProp("", false, divEmailresponsavel_cell_Internalname, "Class", divEmailresponsavel_cell_Class, true);
         }
         else
         {
            divEmailresponsavel_cell_Class = "col-xs-12 DataContentCellFL";
            AssignProp("", false, divEmailresponsavel_cell_Internalname, "Class", divEmailresponsavel_cell_Class, true);
         }
         if ( StringUtil.StrCmp(AV6TipoPessoa, "JURIDICA") == 0 )
         {
            divCpfresponsavel_cell_Class = "col-xs-12 DataContentCellFL RequiredDataContentCellFL";
            AssignProp("", false, divCpfresponsavel_cell_Internalname, "Class", divCpfresponsavel_cell_Class, true);
         }
         else
         {
            divCpfresponsavel_cell_Class = "col-xs-12 DataContentCellFL";
            AssignProp("", false, divCpfresponsavel_cell_Internalname, "Class", divCpfresponsavel_cell_Class, true);
         }
         divTableresponsavelassinaturajuridica_Visible = (((StringUtil.StrCmp(AV6TipoPessoa, "JURIDICA")==0)) ? 1 : 0);
         AssignProp("", false, divTableresponsavelassinaturajuridica_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableresponsavelassinaturajuridica_Visible), 5, 0), true);
      }

      protected void E139S2( )
      {
         /* Cpfcnpj_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'VALIDACPFCNPJ' */
         S132 ();
         if (returnInSub) return;
         if ( StringUtil.StrCmp(AV6TipoPessoa, "JURIDICA") == 0 )
         {
            AV20AuxCPF = StringUtil.StringReplace( AV8CPFCNPJ, ".", "");
            AV20AuxCPF = StringUtil.StringReplace( AV8CPFCNPJ, "-", "");
            GXt_char1 = "";
            new prvalidcpf(context ).execute(  "FISICA",  AV20AuxCPF, out  AV25IsOK, out  GXt_char1) ;
            if ( ! AV25IsOK )
            {
               GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Documento inválido verifique.",  "error",  edtavEmail_Internalname,  "true",  ""));
            }
         }
         /*  Sending Event outputs  */
      }

      protected void E149S2( )
      {
         /* Cpfresponsavel_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'VALIDACPF' */
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E159S2( )
      {
         /* Email_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'VALIDAEMAIL' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E169S2( )
      {
         /* Emailresponsavel_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'VALIDAEMAILREPRESENTANTE' */
         S162 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S152( )
      {
         /* 'VALIDAEMAIL' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV6TipoPessoa, "JURIDICA") == 0 )
         {
            AV21AuxEmail = StringUtil.Lower( AV10EmailResponsavel);
         }
         else
         {
            AV21AuxEmail = StringUtil.Lower( AV7Email);
         }
         if ( ( StringUtil.StrCmp(StringUtil.Lower( AV10EmailResponsavel), StringUtil.Lower( AV13SdParticipantes.gxTpr_Participanterepresentanteemail)) != 0 ) || ( StringUtil.StrCmp(StringUtil.Lower( AV7Email), StringUtil.Lower( AV13SdParticipantes.gxTpr_Participanteemail)) != 0 ) )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21AuxEmail)) )
            {
               AV26GXV1 = 1;
               while ( AV26GXV1 <= AV17Array_SdParticipantes.Count )
               {
                  AV19AuxSdParticipantes = ((SdtSdParticipantes)AV17Array_SdParticipantes.Item(AV26GXV1));
                  if ( ( StringUtil.StrCmp(AV21AuxEmail, StringUtil.Lower( AV19AuxSdParticipantes.gxTpr_Participanteemail)) == 0 ) || ( StringUtil.StrCmp(AV21AuxEmail, StringUtil.Lower( AV19AuxSdParticipantes.gxTpr_Participanterepresentanteemail)) == 0 ) )
                  {
                     GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Email já esta sendo utilizado para outro participante.",  "error",  edtavEmail_Internalname,  "true",  ""));
                     AV12CheckRequiredFieldsResult = false;
                     AssignAttri("", false, "AV12CheckRequiredFieldsResult", AV12CheckRequiredFieldsResult);
                     if (true) break;
                  }
                  AV26GXV1 = (int)(AV26GXV1+1);
               }
            }
         }
      }

      protected void S162( )
      {
         /* 'VALIDAEMAILREPRESENTANTE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV6TipoPessoa, "JURIDICA") == 0 )
         {
            AV21AuxEmail = AV10EmailResponsavel;
         }
         else
         {
            AV21AuxEmail = AV7Email;
         }
         if ( ( StringUtil.StrCmp(AV10EmailResponsavel, AV13SdParticipantes.gxTpr_Participanterepresentanteemail) != 0 ) || ( StringUtil.StrCmp(AV7Email, AV13SdParticipantes.gxTpr_Participanteemail) != 0 ) )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21AuxEmail)) )
            {
               AV27GXV2 = 1;
               while ( AV27GXV2 <= AV17Array_SdParticipantes.Count )
               {
                  AV19AuxSdParticipantes = ((SdtSdParticipantes)AV17Array_SdParticipantes.Item(AV27GXV2));
                  if ( ( StringUtil.StrCmp(AV21AuxEmail, AV19AuxSdParticipantes.gxTpr_Participanteemail) == 0 ) || ( StringUtil.StrCmp(AV21AuxEmail, AV19AuxSdParticipantes.gxTpr_Participanterepresentanteemail) == 0 ) )
                  {
                     GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Email já esta sendo utilizado para outro participante.",  "error",  edtavEmailresponsavel_Internalname,  "true",  ""));
                     AV12CheckRequiredFieldsResult = false;
                     AssignAttri("", false, "AV12CheckRequiredFieldsResult", AV12CheckRequiredFieldsResult);
                     if (true) break;
                  }
                  AV27GXV2 = (int)(AV27GXV2+1);
               }
            }
         }
      }

      protected void S132( )
      {
         /* 'VALIDACPFCNPJ' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV6TipoPessoa, "JURIDICA") == 0 )
         {
            AV20AuxCPF = AV11CPFResponsavel;
         }
         else
         {
            AV20AuxCPF = AV8CPFCNPJ;
         }
         if ( ( StringUtil.StrCmp(AV11CPFResponsavel, AV13SdParticipantes.gxTpr_Participanterepresentantedocumento) != 0 ) || ( StringUtil.StrCmp(AV8CPFCNPJ, AV13SdParticipantes.gxTpr_Participantedocumento) != 0 ) )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20AuxCPF)) )
            {
               AV28GXV3 = 1;
               while ( AV28GXV3 <= AV17Array_SdParticipantes.Count )
               {
                  AV19AuxSdParticipantes = ((SdtSdParticipantes)AV17Array_SdParticipantes.Item(AV28GXV3));
                  if ( ( StringUtil.StrCmp(AV20AuxCPF, AV19AuxSdParticipantes.gxTpr_Participantedocumento) == 0 ) || ( StringUtil.StrCmp(AV20AuxCPF, AV19AuxSdParticipantes.gxTpr_Participanterepresentantedocumento) == 0 ) )
                  {
                     GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Documento já esta sendo utilizado para outro participante.",  "error",  edtavCpfcnpj_Internalname,  "true",  ""));
                     AV12CheckRequiredFieldsResult = false;
                     AssignAttri("", false, "AV12CheckRequiredFieldsResult", AV12CheckRequiredFieldsResult);
                     if (true) break;
                  }
                  AV28GXV3 = (int)(AV28GXV3+1);
               }
            }
         }
      }

      protected void S172( )
      {
         /* 'VALIDATIPOPARTICIPANTE' Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(AV14TipoAssinante, "Contratado") == 0 ) || ( StringUtil.StrCmp(AV14TipoAssinante, "Contratante") == 0 ) )
         {
            AV29GXV4 = 1;
            while ( AV29GXV4 <= AV17Array_SdParticipantes.Count )
            {
               AV19AuxSdParticipantes = ((SdtSdParticipantes)AV17Array_SdParticipantes.Item(AV29GXV4));
               if ( StringUtil.StrCmp(AV14TipoAssinante, AV19AuxSdParticipantes.gxTpr_Assinaturaparticipantetipo) == 0 )
               {
                  GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Já existe participante desse tipo",  "error",  cmbavTipoassinante_Internalname,  "true",  ""));
                  AV12CheckRequiredFieldsResult = false;
                  AssignAttri("", false, "AV12CheckRequiredFieldsResult", AV12CheckRequiredFieldsResult);
                  if (true) break;
               }
               AV29GXV4 = (int)(AV29GXV4+1);
            }
         }
      }

      protected void S142( )
      {
         /* 'VALIDACPF' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV6TipoPessoa, "JURIDICA") == 0 )
         {
            AV20AuxCPF = AV11CPFResponsavel;
         }
         else
         {
            AV20AuxCPF = AV8CPFCNPJ;
         }
         AV20AuxCPF = StringUtil.StringReplace( AV8CPFCNPJ, ".", "");
         AV20AuxCPF = StringUtil.StringReplace( AV8CPFCNPJ, "-", "");
         GXt_char1 = "";
         new prvalidcpf(context ).execute(  "FISICA",  AV20AuxCPF, out  AV25IsOK, out  GXt_char1) ;
         if ( StringUtil.StrCmp(AV6TipoPessoa, "JURIDICA") == 0 )
         {
            AV20AuxCPF = AV11CPFResponsavel;
         }
         else
         {
            AV20AuxCPF = AV8CPFCNPJ;
         }
         if ( AV25IsOK )
         {
            if ( ( StringUtil.StrCmp(AV11CPFResponsavel, AV13SdParticipantes.gxTpr_Participanterepresentantedocumento) != 0 ) || ( StringUtil.StrCmp(AV8CPFCNPJ, AV13SdParticipantes.gxTpr_Participantedocumento) != 0 ) )
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20AuxCPF)) )
               {
                  AV30GXV5 = 1;
                  while ( AV30GXV5 <= AV17Array_SdParticipantes.Count )
                  {
                     AV19AuxSdParticipantes = ((SdtSdParticipantes)AV17Array_SdParticipantes.Item(AV30GXV5));
                     if ( ( StringUtil.StrCmp(AV20AuxCPF, AV19AuxSdParticipantes.gxTpr_Participantedocumento) == 0 ) || ( StringUtil.StrCmp(AV20AuxCPF, AV19AuxSdParticipantes.gxTpr_Participanterepresentantedocumento) == 0 ) )
                     {
                        GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Documento já esta sendo utilizado para outro participante.",  "error",  edtavCpfresponsavel_Internalname,  "true",  ""));
                        AV12CheckRequiredFieldsResult = false;
                        AssignAttri("", false, "AV12CheckRequiredFieldsResult", AV12CheckRequiredFieldsResult);
                        if (true) break;
                     }
                     AV30GXV5 = (int)(AV30GXV5+1);
                  }
               }
            }
         }
         else
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Documento inválido verifique.",  "error",  edtavCpfresponsavel_Internalname,  "true",  ""));
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E179S2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV15JSON = (string)getParm(obj,0);
         AssignAttri("", false, "AV15JSON", AV15JSON);
         GxWebStd.gx_hidden_field( context, "gxhash_vJSON", GetSecureSignedToken( "", AV15JSON, context));
         AV22StringGUID = (string)getParm(obj,1);
         AssignAttri("", false, "AV22StringGUID", AV22StringGUID);
         GxWebStd.gx_hidden_field( context, "gxhash_vSTRINGGUID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV22StringGUID, "")), context));
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
         PA9S2( ) ;
         WS9S2( ) ;
         WE9S2( ) ;
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
         AddStyleSheetFile("DVelop/DVMessage/DVMessage.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019284456", true, true);
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
         context.AddJavascriptSource("novoparticipanteassinatura.js", "?202561019284456", false, true);
         context.AddJavascriptSource("DVelop/DVMessage/pnotify.custom.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVMessage/DVMessageRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavTipopessoa.Name = "vTIPOPESSOA";
         cmbavTipopessoa.WebTags = "";
         cmbavTipopessoa.addItem("FISICA", "Física", 0);
         cmbavTipopessoa.addItem("JURIDICA", "Jurídica", 0);
         if ( cmbavTipopessoa.ItemCount > 0 )
         {
            AV6TipoPessoa = cmbavTipopessoa.getValidValue(AV6TipoPessoa);
            AssignAttri("", false, "AV6TipoPessoa", AV6TipoPessoa);
         }
         cmbavTipoassinante.Name = "vTIPOASSINANTE";
         cmbavTipoassinante.WebTags = "";
         cmbavTipoassinante.addItem("", "(Nenhum)", 0);
         cmbavTipoassinante.addItem("Contratado", "Contratada", 0);
         cmbavTipoassinante.addItem("Contratante", "Contratante", 0);
         cmbavTipoassinante.addItem("Testemunha", "Testemunha", 0);
         cmbavTipoassinante.addItem("Sacado", "Sacado", 0);
         if ( cmbavTipoassinante.ItemCount > 0 )
         {
            AV14TipoAssinante = cmbavTipoassinante.getValidValue(AV14TipoAssinante);
            AssignAttri("", false, "AV14TipoAssinante", AV14TipoAssinante);
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtnenter_Internalname = "BTNENTER";
         edtavNome_Internalname = "vNOME";
         cmbavTipopessoa_Internalname = "vTIPOPESSOA";
         edtavEmail_Internalname = "vEMAIL";
         edtavCpfcnpj_Internalname = "vCPFCNPJ";
         cmbavTipoassinante_Internalname = "vTIPOASSINANTE";
         edtavNomeresponsavel_Internalname = "vNOMERESPONSAVEL";
         divNomeresponsavel_cell_Internalname = "NOMERESPONSAVEL_CELL";
         edtavEmailresponsavel_Internalname = "vEMAILRESPONSAVEL";
         divEmailresponsavel_cell_Internalname = "EMAILRESPONSAVEL_CELL";
         edtavCpfresponsavel_Internalname = "vCPFRESPONSAVEL";
         divCpfresponsavel_cell_Internalname = "CPFRESPONSAVEL_CELL";
         divGpresponsavel_Internalname = "GPRESPONSAVEL";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         divTableresponsavelassinaturajuridica_Internalname = "TABLERESPONSAVELASSINATURAJURIDICA";
         divTablecontent_Internalname = "TABLECONTENT";
         Ucmessage_Internalname = "UCMESSAGE";
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
         edtavCpfresponsavel_Jsonclick = "";
         edtavCpfresponsavel_Enabled = 1;
         divCpfresponsavel_cell_Class = "col-xs-12";
         edtavEmailresponsavel_Jsonclick = "";
         edtavEmailresponsavel_Enabled = 1;
         divEmailresponsavel_cell_Class = "col-xs-12";
         edtavNomeresponsavel_Jsonclick = "";
         edtavNomeresponsavel_Enabled = 1;
         divNomeresponsavel_cell_Class = "col-xs-12";
         divTableresponsavelassinaturajuridica_Visible = 1;
         cmbavTipoassinante_Jsonclick = "";
         cmbavTipoassinante.Enabled = 1;
         edtavCpfcnpj_Jsonclick = "";
         edtavCpfcnpj_Enabled = 1;
         edtavEmail_Jsonclick = "";
         edtavEmail_Enabled = 1;
         cmbavTipopessoa_Jsonclick = "";
         cmbavTipopessoa.Enabled = 1;
         edtavNome_Jsonclick = "";
         edtavNome_Enabled = 1;
         divTablemain_Height = 0;
         Ucmessage_Nextmessageposition = "down";
         Ucmessage_Startposition = "TopRight";
         Ucmessage_Animationspeed = 300;
         Ucmessage_Effectout = "slide";
         Ucmessage_Effectin = "slide";
         Ucmessage_Stoponerror = Convert.ToBoolean( -1);
         Ucmessage_Stylingtype = "fontawesome";
         Ucmessage_Minheight = "16";
         Ucmessage_Width = "500";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Participante assinatura";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV17Array_SdParticipantes","fld":"vARRAY_SDPARTICIPANTES","hsh":true,"type":""},{"av":"AV15JSON","fld":"vJSON","hsh":true,"type":"vchar"},{"av":"AV22StringGUID","fld":"vSTRINGGUID","hsh":true,"type":"svchar"}]}""");
         setEventMetadata("ENTER","""{"handler":"E129S2","iparms":[{"av":"AV12CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"},{"av":"AV13SdParticipantes","fld":"vSDPARTICIPANTES","type":""},{"av":"AV17Array_SdParticipantes","fld":"vARRAY_SDPARTICIPANTES","hsh":true,"type":""},{"av":"AV5Nome","fld":"vNOME","type":"svchar"},{"av":"AV8CPFCNPJ","fld":"vCPFCNPJ","type":"svchar"},{"av":"AV7Email","fld":"vEMAIL","type":"svchar"},{"av":"cmbavTipoassinante"},{"av":"AV14TipoAssinante","fld":"vTIPOASSINANTE","type":"svchar"},{"av":"cmbavTipopessoa"},{"av":"AV6TipoPessoa","fld":"vTIPOPESSOA","type":"svchar"},{"av":"AV9NomeResponsavel","fld":"vNOMERESPONSAVEL","type":"svchar"},{"av":"AV10EmailResponsavel","fld":"vEMAILRESPONSAVEL","type":"svchar"},{"av":"AV11CPFResponsavel","fld":"vCPFRESPONSAVEL","type":"svchar"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV13SdParticipantes","fld":"vSDPARTICIPANTES","type":""},{"av":"AV12CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"}]}""");
         setEventMetadata("VCPFCNPJ.CONTROLVALUECHANGED","""{"handler":"E139S2","iparms":[{"av":"cmbavTipopessoa"},{"av":"AV6TipoPessoa","fld":"vTIPOPESSOA","type":"svchar"},{"av":"AV8CPFCNPJ","fld":"vCPFCNPJ","type":"svchar"},{"av":"AV11CPFResponsavel","fld":"vCPFRESPONSAVEL","type":"svchar"},{"av":"AV13SdParticipantes","fld":"vSDPARTICIPANTES","type":""},{"av":"AV17Array_SdParticipantes","fld":"vARRAY_SDPARTICIPANTES","hsh":true,"type":""}]""");
         setEventMetadata("VCPFCNPJ.CONTROLVALUECHANGED",""","oparms":[{"av":"AV12CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"}]}""");
         setEventMetadata("VCPFRESPONSAVEL.CONTROLVALUECHANGED","""{"handler":"E149S2","iparms":[{"av":"cmbavTipopessoa"},{"av":"AV6TipoPessoa","fld":"vTIPOPESSOA","type":"svchar"},{"av":"AV11CPFResponsavel","fld":"vCPFRESPONSAVEL","type":"svchar"},{"av":"AV8CPFCNPJ","fld":"vCPFCNPJ","type":"svchar"},{"av":"AV13SdParticipantes","fld":"vSDPARTICIPANTES","type":""},{"av":"AV17Array_SdParticipantes","fld":"vARRAY_SDPARTICIPANTES","hsh":true,"type":""}]""");
         setEventMetadata("VCPFRESPONSAVEL.CONTROLVALUECHANGED",""","oparms":[{"av":"AV12CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"}]}""");
         setEventMetadata("VEMAIL.CONTROLVALUECHANGED","""{"handler":"E159S2","iparms":[{"av":"cmbavTipopessoa"},{"av":"AV6TipoPessoa","fld":"vTIPOPESSOA","type":"svchar"},{"av":"AV10EmailResponsavel","fld":"vEMAILRESPONSAVEL","type":"svchar"},{"av":"AV7Email","fld":"vEMAIL","type":"svchar"},{"av":"AV13SdParticipantes","fld":"vSDPARTICIPANTES","type":""},{"av":"AV17Array_SdParticipantes","fld":"vARRAY_SDPARTICIPANTES","hsh":true,"type":""}]""");
         setEventMetadata("VEMAIL.CONTROLVALUECHANGED",""","oparms":[{"av":"AV12CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"}]}""");
         setEventMetadata("VEMAILRESPONSAVEL.CONTROLVALUECHANGED","""{"handler":"E169S2","iparms":[{"av":"cmbavTipopessoa"},{"av":"AV6TipoPessoa","fld":"vTIPOPESSOA","type":"svchar"},{"av":"AV10EmailResponsavel","fld":"vEMAILRESPONSAVEL","type":"svchar"},{"av":"AV7Email","fld":"vEMAIL","type":"svchar"},{"av":"AV13SdParticipantes","fld":"vSDPARTICIPANTES","type":""},{"av":"AV17Array_SdParticipantes","fld":"vARRAY_SDPARTICIPANTES","hsh":true,"type":""}]""");
         setEventMetadata("VEMAILRESPONSAVEL.CONTROLVALUECHANGED",""","oparms":[{"av":"AV12CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"}]}""");
         setEventMetadata("VALIDV_TIPOPESSOA","""{"handler":"Validv_Tipopessoa","iparms":[]}""");
         setEventMetadata("VALIDV_EMAIL","""{"handler":"Validv_Email","iparms":[]}""");
         setEventMetadata("VALIDV_TIPOASSINANTE","""{"handler":"Validv_Tipoassinante","iparms":[]}""");
         setEventMetadata("VALIDV_EMAILRESPONSAVEL","""{"handler":"Validv_Emailresponsavel","iparms":[]}""");
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
         wcpOAV15JSON = "";
         wcpOAV22StringGUID = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV17Array_SdParticipantes = new GXBaseCollection<SdtSdParticipantes>( context, "SdParticipantes", "Factory21");
         AV13SdParticipantes = new SdtSdParticipantes(context);
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnenter_Jsonclick = "";
         AV5Nome = "";
         AV6TipoPessoa = "";
         AV7Email = "";
         AV8CPFCNPJ = "";
         AV14TipoAssinante = "";
         AV9NomeResponsavel = "";
         AV10EmailResponsavel = "";
         AV11CPFResponsavel = "";
         ucUcmessage = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV16Array_JSON = "";
         AV23WEBSESSION = context.GetSession();
         AV20AuxCPF = "";
         AV21AuxEmail = "";
         AV19AuxSdParticipantes = new SdtSdParticipantes(context);
         GXt_char1 = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         /* GeneXus formulas. */
      }

      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int Ucmessage_Animationspeed ;
      private int divTablemain_Height ;
      private int edtavNome_Enabled ;
      private int edtavEmail_Enabled ;
      private int edtavCpfcnpj_Enabled ;
      private int divTableresponsavelassinaturajuridica_Visible ;
      private int edtavNomeresponsavel_Enabled ;
      private int edtavEmailresponsavel_Enabled ;
      private int edtavCpfresponsavel_Enabled ;
      private int AV26GXV1 ;
      private int AV27GXV2 ;
      private int AV28GXV3 ;
      private int AV29GXV4 ;
      private int AV30GXV5 ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Ucmessage_Width ;
      private string Ucmessage_Minheight ;
      private string Ucmessage_Stylingtype ;
      private string Ucmessage_Effectin ;
      private string Ucmessage_Effectout ;
      private string Ucmessage_Startposition ;
      private string Ucmessage_Nextmessageposition ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string divTablecontent_Internalname ;
      private string edtavNome_Internalname ;
      private string edtavNome_Jsonclick ;
      private string cmbavTipopessoa_Internalname ;
      private string cmbavTipopessoa_Jsonclick ;
      private string edtavEmail_Internalname ;
      private string edtavEmail_Jsonclick ;
      private string edtavCpfcnpj_Internalname ;
      private string edtavCpfcnpj_Jsonclick ;
      private string cmbavTipoassinante_Internalname ;
      private string cmbavTipoassinante_Jsonclick ;
      private string divTableresponsavelassinaturajuridica_Internalname ;
      private string grpUnnamedgroup1_Internalname ;
      private string divGpresponsavel_Internalname ;
      private string divNomeresponsavel_cell_Internalname ;
      private string divNomeresponsavel_cell_Class ;
      private string edtavNomeresponsavel_Internalname ;
      private string edtavNomeresponsavel_Jsonclick ;
      private string divEmailresponsavel_cell_Internalname ;
      private string divEmailresponsavel_cell_Class ;
      private string edtavEmailresponsavel_Internalname ;
      private string edtavEmailresponsavel_Jsonclick ;
      private string divCpfresponsavel_cell_Internalname ;
      private string divCpfresponsavel_cell_Class ;
      private string edtavCpfresponsavel_Internalname ;
      private string edtavCpfresponsavel_Jsonclick ;
      private string Ucmessage_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string GXt_char1 ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV12CheckRequiredFieldsResult ;
      private bool Ucmessage_Stoponerror ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV25IsOK ;
      private string AV15JSON ;
      private string wcpOAV15JSON ;
      private string AV16Array_JSON ;
      private string AV22StringGUID ;
      private string wcpOAV22StringGUID ;
      private string AV5Nome ;
      private string AV6TipoPessoa ;
      private string AV7Email ;
      private string AV8CPFCNPJ ;
      private string AV14TipoAssinante ;
      private string AV9NomeResponsavel ;
      private string AV10EmailResponsavel ;
      private string AV11CPFResponsavel ;
      private string AV20AuxCPF ;
      private string AV21AuxEmail ;
      private IGxSession AV23WEBSESSION ;
      private GXUserControl ucUcmessage ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavTipopessoa ;
      private GXCombobox cmbavTipoassinante ;
      private GXBaseCollection<SdtSdParticipantes> AV17Array_SdParticipantes ;
      private SdtSdParticipantes AV13SdParticipantes ;
      private SdtSdParticipantes AV19AuxSdParticipantes ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
