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
   public class popupnovoparticipanteassinatura : GXDataArea
   {
      public popupnovoparticipanteassinatura( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public popupnovoparticipanteassinatura( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_PropostaId )
      {
         this.AV10PropostaId = aP0_PropostaId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavOpcoesproposta = new GXCombobox();
         cmbavAssinaturaparticipantetipo = new GXCombobox();
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
         PA772( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START772( ) ;
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
         GXEncryptionTmp = "popupnovoparticipanteassinatura"+UrlEncode(StringUtil.LTrimStr(AV10PropostaId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("popupnovoparticipanteassinatura") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10PropostaId), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_boolean_hidden_field( context, "vCHECKREQUIREDFIELDSRESULT", AV9CheckRequiredFieldsResult);
         GxWebStd.gx_hidden_field( context, "PROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10PropostaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "PROPOSTARESPONSAVELDOCUMENTO", A580PropostaResponsavelDocumento);
         GxWebStd.gx_hidden_field( context, "PROPOSTARESPONSAVELRAZAOSOCIAL", A581PropostaResponsavelRazaoSocial);
         GxWebStd.gx_hidden_field( context, "PROPOSTARESPONSAVELEMAIL", A582PropostaResponsavelEmail);
         GxWebStd.gx_hidden_field( context, "PROPOSTACLINICAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A642PropostaClinicaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "RESPONSAVELCPF", A447ResponsavelCPF);
         GxWebStd.gx_hidden_field( context, "RESPONSAVELNOME", A436ResponsavelNome);
         GxWebStd.gx_hidden_field( context, "RESPONSAVELEMAIL", A456ResponsavelEmail);
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
            WE772( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT772( ) ;
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
         GXEncryptionTmp = "popupnovoparticipanteassinatura"+UrlEncode(StringUtil.LTrimStr(AV10PropostaId,9,0));
         return formatLink("popupnovoparticipanteassinatura") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "PopUpNovoParticipanteAssinatura" ;
      }

      public override string GetPgmdesc( )
      {
         return "Participante assinatura" ;
      }

      protected void WB770( )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 12,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnconfirmar_Internalname, "", "Confirmar", bttBtnconfirmar_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOCONFIRMAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_PopUpNovoParticipanteAssinatura.htm");
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
            GxWebStd.gx_div_start( context, divOpcoesproposta_cell_Internalname, 1, 0, "px", 0, "px", divOpcoesproposta_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", cmbavOpcoesproposta.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavOpcoesproposta_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavOpcoesproposta_Internalname, "Opções da proposta", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavOpcoesproposta, cmbavOpcoesproposta_Internalname, StringUtil.RTrim( AV11OpcoesProposta), 1, cmbavOpcoesproposta_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", cmbavOpcoesproposta.Visible, cmbavOpcoesproposta.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "", true, 0, "HLP_PopUpNovoParticipanteAssinatura.htm");
            cmbavOpcoesproposta.CurrentValue = StringUtil.RTrim( AV11OpcoesProposta);
            AssignProp("", false, cmbavOpcoesproposta_Internalname, "Values", (string)(cmbavOpcoesproposta.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavAssinaturaparticipantetipo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavAssinaturaparticipantetipo_Internalname, "Tipo", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavAssinaturaparticipantetipo, cmbavAssinaturaparticipantetipo_Internalname, StringUtil.RTrim( AV5AssinaturaParticipanteTipo), 1, cmbavAssinaturaparticipantetipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavAssinaturaparticipantetipo.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "", true, 0, "HLP_PopUpNovoParticipanteAssinatura.htm");
            cmbavAssinaturaparticipantetipo.CurrentValue = StringUtil.RTrim( AV5AssinaturaParticipanteTipo);
            AssignProp("", false, cmbavAssinaturaparticipantetipo_Internalname, "Values", (string)(cmbavAssinaturaparticipantetipo.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNome_Internalname, AV6Nome, StringUtil.RTrim( context.localUtil.Format( AV6Nome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavNome_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_PopUpNovoParticipanteAssinatura.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCpf_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpf_Internalname, "CPF", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCpf_Internalname, AV7CPF, StringUtil.RTrim( context.localUtil.Format( AV7CPF, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpf_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavCpf_Enabled, 1, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_PopUpNovoParticipanteAssinatura.htm");
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
            GxWebStd.gx_label_element( context, edtavEmail_Internalname, "E-mail", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmail_Internalname, AV8Email, StringUtil.RTrim( context.localUtil.Format( AV8Email, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+AV8Email, "", "", "", edtavEmail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_PopUpNovoParticipanteAssinatura.htm");
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
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START772( )
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
         STRUP770( ) ;
      }

      protected void WS772( )
      {
         START772( ) ;
         EVT772( ) ;
      }

      protected void EVT772( )
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
                              E11772 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOCONFIRMAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoConfirmar' */
                              E12772 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VOPCOESPROPOSTA.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E13772 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E14772 ();
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
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE772( )
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

      protected void PA772( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "popupnovoparticipanteassinatura")), "popupnovoparticipanteassinatura") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "popupnovoparticipanteassinatura")))) ;
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
                     AV10PropostaId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV10PropostaId", StringUtil.LTrimStr( (decimal)(AV10PropostaId), 9, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10PropostaId), "ZZZZZZZZ9"), context));
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
               GX_FocusControl = cmbavOpcoesproposta_Internalname;
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
         if ( cmbavOpcoesproposta.ItemCount > 0 )
         {
            AV11OpcoesProposta = cmbavOpcoesproposta.getValidValue(AV11OpcoesProposta);
            AssignAttri("", false, "AV11OpcoesProposta", AV11OpcoesProposta);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavOpcoesproposta.CurrentValue = StringUtil.RTrim( AV11OpcoesProposta);
            AssignProp("", false, cmbavOpcoesproposta_Internalname, "Values", cmbavOpcoesproposta.ToJavascriptSource(), true);
         }
         if ( cmbavAssinaturaparticipantetipo.ItemCount > 0 )
         {
            AV5AssinaturaParticipanteTipo = cmbavAssinaturaparticipantetipo.getValidValue(AV5AssinaturaParticipanteTipo);
            AssignAttri("", false, "AV5AssinaturaParticipanteTipo", AV5AssinaturaParticipanteTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavAssinaturaparticipantetipo.CurrentValue = StringUtil.RTrim( AV5AssinaturaParticipanteTipo);
            AssignProp("", false, cmbavAssinaturaparticipantetipo_Internalname, "Values", cmbavAssinaturaparticipantetipo.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF772( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF772( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E14772 ();
            WB770( ) ;
         }
      }

      protected void send_integrity_lvl_hashes772( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP770( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11772 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            cmbavOpcoesproposta.CurrentValue = cgiGet( cmbavOpcoesproposta_Internalname);
            AV11OpcoesProposta = cgiGet( cmbavOpcoesproposta_Internalname);
            AssignAttri("", false, "AV11OpcoesProposta", AV11OpcoesProposta);
            cmbavAssinaturaparticipantetipo.CurrentValue = cgiGet( cmbavAssinaturaparticipantetipo_Internalname);
            AV5AssinaturaParticipanteTipo = cgiGet( cmbavAssinaturaparticipantetipo_Internalname);
            AssignAttri("", false, "AV5AssinaturaParticipanteTipo", AV5AssinaturaParticipanteTipo);
            AV6Nome = cgiGet( edtavNome_Internalname);
            AssignAttri("", false, "AV6Nome", AV6Nome);
            AV7CPF = cgiGet( edtavCpf_Internalname);
            AssignAttri("", false, "AV7CPF", AV7CPF);
            AV8Email = cgiGet( edtavEmail_Internalname);
            AssignAttri("", false, "AV8Email", AV8Email);
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
         E11772 ();
         if (returnInSub) return;
      }

      protected void E11772( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if (returnInSub) return;
      }

      protected void E12772( )
      {
         /* 'DoConfirmar' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S122 ();
         if (returnInSub) return;
         if ( AV9CheckRequiredFieldsResult )
         {
            this.executeExternalObjectMethod("", false, "GlobalEvents", "WpIniciarAssinatura_NovoParticipante", new Object[] {(string)AV6Nome,(string)AV7CPF,(string)AV8Email,(string)AV5AssinaturaParticipanteTipo}, true);
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV9CheckRequiredFieldsResult = true;
         AssignAttri("", false, "AV9CheckRequiredFieldsResult", AV9CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV6Nome)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Nome", "", "", "", "", "", "", "", ""),  "error",  edtavNome_Internalname,  "true",  ""));
            AV9CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV9CheckRequiredFieldsResult", AV9CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV7CPF)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "CPF", "", "", "", "", "", "", "", ""),  "error",  edtavCpf_Internalname,  "true",  ""));
            AV9CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV9CheckRequiredFieldsResult", AV9CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV8Email)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "E-mail", "", "", "", "", "", "", "", ""),  "error",  edtavEmail_Internalname,  "true",  ""));
            AV9CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV9CheckRequiredFieldsResult", AV9CheckRequiredFieldsResult);
         }
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ! ( ( AV10PropostaId > 0 ) ) )
         {
            cmbavOpcoesproposta.Visible = 0;
            AssignProp("", false, cmbavOpcoesproposta_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavOpcoesproposta.Visible), 5, 0), true);
            divOpcoesproposta_cell_Class = "Invisible";
            AssignProp("", false, divOpcoesproposta_cell_Internalname, "Class", divOpcoesproposta_cell_Class, true);
         }
         else
         {
            cmbavOpcoesproposta.Visible = 1;
            AssignProp("", false, cmbavOpcoesproposta_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavOpcoesproposta.Visible), 5, 0), true);
            divOpcoesproposta_cell_Class = "col-xs-12";
            AssignProp("", false, divOpcoesproposta_cell_Internalname, "Class", divOpcoesproposta_cell_Class, true);
         }
      }

      protected void E13772( )
      {
         /* Opcoesproposta_Controlvaluechanged Routine */
         returnInSub = false;
         AV7CPF = "";
         AssignAttri("", false, "AV7CPF", AV7CPF);
         AV6Nome = "";
         AssignAttri("", false, "AV6Nome", AV6Nome);
         AV8Email = "";
         AssignAttri("", false, "AV8Email", AV8Email);
         edtavCpf_Enabled = 1;
         AssignProp("", false, edtavCpf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCpf_Enabled), 5, 0), true);
         edtavNome_Enabled = 1;
         AssignProp("", false, edtavNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNome_Enabled), 5, 0), true);
         if ( StringUtil.StrCmp(AV11OpcoesProposta, "Paciente") == 0 )
         {
            /* Using cursor H00772 */
            pr_default.execute(0, new Object[] {AV10PropostaId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A553PropostaResponsavelId = H00772_A553PropostaResponsavelId[0];
               n553PropostaResponsavelId = H00772_n553PropostaResponsavelId[0];
               A323PropostaId = H00772_A323PropostaId[0];
               A580PropostaResponsavelDocumento = H00772_A580PropostaResponsavelDocumento[0];
               n580PropostaResponsavelDocumento = H00772_n580PropostaResponsavelDocumento[0];
               A581PropostaResponsavelRazaoSocial = H00772_A581PropostaResponsavelRazaoSocial[0];
               n581PropostaResponsavelRazaoSocial = H00772_n581PropostaResponsavelRazaoSocial[0];
               A582PropostaResponsavelEmail = H00772_A582PropostaResponsavelEmail[0];
               n582PropostaResponsavelEmail = H00772_n582PropostaResponsavelEmail[0];
               A580PropostaResponsavelDocumento = H00772_A580PropostaResponsavelDocumento[0];
               n580PropostaResponsavelDocumento = H00772_n580PropostaResponsavelDocumento[0];
               A581PropostaResponsavelRazaoSocial = H00772_A581PropostaResponsavelRazaoSocial[0];
               n581PropostaResponsavelRazaoSocial = H00772_n581PropostaResponsavelRazaoSocial[0];
               A582PropostaResponsavelEmail = H00772_A582PropostaResponsavelEmail[0];
               n582PropostaResponsavelEmail = H00772_n582PropostaResponsavelEmail[0];
               AV7CPF = A580PropostaResponsavelDocumento;
               AssignAttri("", false, "AV7CPF", AV7CPF);
               AV6Nome = A581PropostaResponsavelRazaoSocial;
               AssignAttri("", false, "AV6Nome", AV6Nome);
               AV8Email = A582PropostaResponsavelEmail;
               AssignAttri("", false, "AV8Email", AV8Email);
               edtavCpf_Enabled = 0;
               AssignProp("", false, edtavCpf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCpf_Enabled), 5, 0), true);
               edtavNome_Enabled = 0;
               AssignProp("", false, edtavNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNome_Enabled), 5, 0), true);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
         }
         else
         {
            if ( StringUtil.StrCmp(AV11OpcoesProposta, "Clinica") == 0 )
            {
               /* Using cursor H00773 */
               pr_default.execute(1, new Object[] {AV10PropostaId});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A323PropostaId = H00773_A323PropostaId[0];
                  A642PropostaClinicaId = H00773_A642PropostaClinicaId[0];
                  n642PropostaClinicaId = H00773_n642PropostaClinicaId[0];
                  AV12PropostaClinicaId = A642PropostaClinicaId;
                  AssignAttri("", false, "AV12PropostaClinicaId", StringUtil.LTrimStr( (decimal)(AV12PropostaClinicaId), 9, 0));
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(1);
               /* Using cursor H00774 */
               pr_default.execute(2, new Object[] {AV12PropostaClinicaId});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A168ClienteId = H00774_A168ClienteId[0];
                  A447ResponsavelCPF = H00774_A447ResponsavelCPF[0];
                  n447ResponsavelCPF = H00774_n447ResponsavelCPF[0];
                  A436ResponsavelNome = H00774_A436ResponsavelNome[0];
                  n436ResponsavelNome = H00774_n436ResponsavelNome[0];
                  A456ResponsavelEmail = H00774_A456ResponsavelEmail[0];
                  n456ResponsavelEmail = H00774_n456ResponsavelEmail[0];
                  AV7CPF = A447ResponsavelCPF;
                  AssignAttri("", false, "AV7CPF", AV7CPF);
                  AV6Nome = A436ResponsavelNome;
                  AssignAttri("", false, "AV6Nome", AV6Nome);
                  AV8Email = A456ResponsavelEmail;
                  AssignAttri("", false, "AV8Email", AV8Email);
                  edtavCpf_Enabled = 0;
                  AssignProp("", false, edtavCpf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCpf_Enabled), 5, 0), true);
                  edtavNome_Enabled = 0;
                  AssignProp("", false, edtavNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNome_Enabled), 5, 0), true);
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(2);
            }
         }
         /*  Sending Event outputs  */
      }

      protected void nextLoad( )
      {
      }

      protected void E14772( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV10PropostaId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV10PropostaId", StringUtil.LTrimStr( (decimal)(AV10PropostaId), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10PropostaId), "ZZZZZZZZ9"), context));
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
         PA772( ) ;
         WS772( ) ;
         WE772( ) ;
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
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019263244", true, true);
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
         context.AddJavascriptSource("popupnovoparticipanteassinatura.js", "?202561019263244", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavOpcoesproposta.Name = "vOPCOESPROPOSTA";
         cmbavOpcoesproposta.WebTags = "";
         cmbavOpcoesproposta.addItem("", "Nenhum", 0);
         cmbavOpcoesproposta.addItem("Paciente", "Paciente", 0);
         cmbavOpcoesproposta.addItem("Clinica", "Clinica", 0);
         if ( cmbavOpcoesproposta.ItemCount > 0 )
         {
            AV11OpcoesProposta = cmbavOpcoesproposta.getValidValue(AV11OpcoesProposta);
            AssignAttri("", false, "AV11OpcoesProposta", AV11OpcoesProposta);
         }
         cmbavAssinaturaparticipantetipo.Name = "vASSINATURAPARTICIPANTETIPO";
         cmbavAssinaturaparticipantetipo.WebTags = "";
         cmbavAssinaturaparticipantetipo.addItem("Contratado", "Contratada", 0);
         cmbavAssinaturaparticipantetipo.addItem("Contratante", "Contratante", 0);
         cmbavAssinaturaparticipantetipo.addItem("Testemunha", "Testemunha", 0);
         cmbavAssinaturaparticipantetipo.addItem("Sacado", "Sacado", 0);
         if ( cmbavAssinaturaparticipantetipo.ItemCount > 0 )
         {
            AV5AssinaturaParticipanteTipo = cmbavAssinaturaparticipantetipo.getValidValue(AV5AssinaturaParticipanteTipo);
            AssignAttri("", false, "AV5AssinaturaParticipanteTipo", AV5AssinaturaParticipanteTipo);
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtnconfirmar_Internalname = "BTNCONFIRMAR";
         cmbavOpcoesproposta_Internalname = "vOPCOESPROPOSTA";
         divOpcoesproposta_cell_Internalname = "OPCOESPROPOSTA_CELL";
         cmbavAssinaturaparticipantetipo_Internalname = "vASSINATURAPARTICIPANTETIPO";
         edtavNome_Internalname = "vNOME";
         edtavCpf_Internalname = "vCPF";
         edtavEmail_Internalname = "vEMAIL";
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
         edtavEmail_Jsonclick = "";
         edtavEmail_Enabled = 1;
         edtavCpf_Jsonclick = "";
         edtavCpf_Enabled = 1;
         edtavNome_Jsonclick = "";
         edtavNome_Enabled = 1;
         cmbavAssinaturaparticipantetipo_Jsonclick = "";
         cmbavAssinaturaparticipantetipo.Enabled = 1;
         cmbavOpcoesproposta_Jsonclick = "";
         cmbavOpcoesproposta.Enabled = 1;
         cmbavOpcoesproposta.Visible = 1;
         divOpcoesproposta_cell_Class = "col-xs-12";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Participante assinatura";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV10PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("'DOCONFIRMAR'","""{"handler":"E12772","iparms":[{"av":"AV9CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"},{"av":"AV6Nome","fld":"vNOME","type":"svchar"},{"av":"AV7CPF","fld":"vCPF","type":"svchar"},{"av":"AV8Email","fld":"vEMAIL","type":"svchar"},{"av":"cmbavAssinaturaparticipantetipo"},{"av":"AV5AssinaturaParticipanteTipo","fld":"vASSINATURAPARTICIPANTETIPO","type":"svchar"}]""");
         setEventMetadata("'DOCONFIRMAR'",""","oparms":[{"av":"AV9CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"}]}""");
         setEventMetadata("VOPCOESPROPOSTA.CONTROLVALUECHANGED","""{"handler":"E13772","iparms":[{"av":"cmbavOpcoesproposta"},{"av":"AV11OpcoesProposta","fld":"vOPCOESPROPOSTA","type":"svchar"},{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV10PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A580PropostaResponsavelDocumento","fld":"PROPOSTARESPONSAVELDOCUMENTO","type":"svchar"},{"av":"A581PropostaResponsavelRazaoSocial","fld":"PROPOSTARESPONSAVELRAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"A582PropostaResponsavelEmail","fld":"PROPOSTARESPONSAVELEMAIL","type":"svchar"},{"av":"A642PropostaClinicaId","fld":"PROPOSTACLINICAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A447ResponsavelCPF","fld":"RESPONSAVELCPF","type":"svchar"},{"av":"A436ResponsavelNome","fld":"RESPONSAVELNOME","type":"svchar"},{"av":"A456ResponsavelEmail","fld":"RESPONSAVELEMAIL","type":"svchar"}]""");
         setEventMetadata("VOPCOESPROPOSTA.CONTROLVALUECHANGED",""","oparms":[{"av":"AV7CPF","fld":"vCPF","type":"svchar"},{"av":"AV6Nome","fld":"vNOME","type":"svchar"},{"av":"AV8Email","fld":"vEMAIL","type":"svchar"},{"av":"edtavCpf_Enabled","ctrl":"vCPF","prop":"Enabled"},{"av":"edtavNome_Enabled","ctrl":"vNOME","prop":"Enabled"},{"av":"AV12PropostaClinicaId","fld":"vPROPOSTACLINICAID","pic":"ZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("VALIDV_ASSINATURAPARTICIPANTETIPO","""{"handler":"Validv_Assinaturaparticipantetipo","iparms":[]}""");
         setEventMetadata("VALIDV_EMAIL","""{"handler":"Validv_Email","iparms":[]}""");
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
         A580PropostaResponsavelDocumento = "";
         A581PropostaResponsavelRazaoSocial = "";
         A582PropostaResponsavelEmail = "";
         A447ResponsavelCPF = "";
         A436ResponsavelNome = "";
         A456ResponsavelEmail = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtnconfirmar_Jsonclick = "";
         AV11OpcoesProposta = "";
         AV5AssinaturaParticipanteTipo = "";
         AV6Nome = "";
         AV7CPF = "";
         AV8Email = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         H00772_A553PropostaResponsavelId = new int[1] ;
         H00772_n553PropostaResponsavelId = new bool[] {false} ;
         H00772_A323PropostaId = new int[1] ;
         H00772_A580PropostaResponsavelDocumento = new string[] {""} ;
         H00772_n580PropostaResponsavelDocumento = new bool[] {false} ;
         H00772_A581PropostaResponsavelRazaoSocial = new string[] {""} ;
         H00772_n581PropostaResponsavelRazaoSocial = new bool[] {false} ;
         H00772_A582PropostaResponsavelEmail = new string[] {""} ;
         H00772_n582PropostaResponsavelEmail = new bool[] {false} ;
         H00773_A323PropostaId = new int[1] ;
         H00773_A642PropostaClinicaId = new int[1] ;
         H00773_n642PropostaClinicaId = new bool[] {false} ;
         H00774_A168ClienteId = new int[1] ;
         H00774_A447ResponsavelCPF = new string[] {""} ;
         H00774_n447ResponsavelCPF = new bool[] {false} ;
         H00774_A436ResponsavelNome = new string[] {""} ;
         H00774_n436ResponsavelNome = new bool[] {false} ;
         H00774_A456ResponsavelEmail = new string[] {""} ;
         H00774_n456ResponsavelEmail = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.popupnovoparticipanteassinatura__default(),
            new Object[][] {
                new Object[] {
               H00772_A553PropostaResponsavelId, H00772_n553PropostaResponsavelId, H00772_A323PropostaId, H00772_A580PropostaResponsavelDocumento, H00772_n580PropostaResponsavelDocumento, H00772_A581PropostaResponsavelRazaoSocial, H00772_n581PropostaResponsavelRazaoSocial, H00772_A582PropostaResponsavelEmail, H00772_n582PropostaResponsavelEmail
               }
               , new Object[] {
               H00773_A323PropostaId, H00773_A642PropostaClinicaId, H00773_n642PropostaClinicaId
               }
               , new Object[] {
               H00774_A168ClienteId, H00774_A447ResponsavelCPF, H00774_n447ResponsavelCPF, H00774_A436ResponsavelNome, H00774_n436ResponsavelNome, H00774_A456ResponsavelEmail, H00774_n456ResponsavelEmail
               }
            }
         );
         /* GeneXus formulas. */
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
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int AV10PropostaId ;
      private int wcpOAV10PropostaId ;
      private int A323PropostaId ;
      private int A642PropostaClinicaId ;
      private int A168ClienteId ;
      private int edtavNome_Enabled ;
      private int edtavCpf_Enabled ;
      private int edtavEmail_Enabled ;
      private int A553PropostaResponsavelId ;
      private int AV12PropostaClinicaId ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string TempTags ;
      private string bttBtnconfirmar_Internalname ;
      private string bttBtnconfirmar_Jsonclick ;
      private string divTablecontent_Internalname ;
      private string divOpcoesproposta_cell_Internalname ;
      private string divOpcoesproposta_cell_Class ;
      private string cmbavOpcoesproposta_Internalname ;
      private string cmbavOpcoesproposta_Jsonclick ;
      private string cmbavAssinaturaparticipantetipo_Internalname ;
      private string cmbavAssinaturaparticipantetipo_Jsonclick ;
      private string edtavNome_Internalname ;
      private string edtavNome_Jsonclick ;
      private string edtavCpf_Internalname ;
      private string edtavCpf_Jsonclick ;
      private string edtavEmail_Internalname ;
      private string edtavEmail_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV9CheckRequiredFieldsResult ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n553PropostaResponsavelId ;
      private bool n580PropostaResponsavelDocumento ;
      private bool n581PropostaResponsavelRazaoSocial ;
      private bool n582PropostaResponsavelEmail ;
      private bool n642PropostaClinicaId ;
      private bool n447ResponsavelCPF ;
      private bool n436ResponsavelNome ;
      private bool n456ResponsavelEmail ;
      private string A580PropostaResponsavelDocumento ;
      private string A581PropostaResponsavelRazaoSocial ;
      private string A582PropostaResponsavelEmail ;
      private string A447ResponsavelCPF ;
      private string A436ResponsavelNome ;
      private string A456ResponsavelEmail ;
      private string AV11OpcoesProposta ;
      private string AV5AssinaturaParticipanteTipo ;
      private string AV6Nome ;
      private string AV7CPF ;
      private string AV8Email ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavOpcoesproposta ;
      private GXCombobox cmbavAssinaturaparticipantetipo ;
      private IDataStoreProvider pr_default ;
      private int[] H00772_A553PropostaResponsavelId ;
      private bool[] H00772_n553PropostaResponsavelId ;
      private int[] H00772_A323PropostaId ;
      private string[] H00772_A580PropostaResponsavelDocumento ;
      private bool[] H00772_n580PropostaResponsavelDocumento ;
      private string[] H00772_A581PropostaResponsavelRazaoSocial ;
      private bool[] H00772_n581PropostaResponsavelRazaoSocial ;
      private string[] H00772_A582PropostaResponsavelEmail ;
      private bool[] H00772_n582PropostaResponsavelEmail ;
      private int[] H00773_A323PropostaId ;
      private int[] H00773_A642PropostaClinicaId ;
      private bool[] H00773_n642PropostaClinicaId ;
      private int[] H00774_A168ClienteId ;
      private string[] H00774_A447ResponsavelCPF ;
      private bool[] H00774_n447ResponsavelCPF ;
      private string[] H00774_A436ResponsavelNome ;
      private bool[] H00774_n436ResponsavelNome ;
      private string[] H00774_A456ResponsavelEmail ;
      private bool[] H00774_n456ResponsavelEmail ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class popupnovoparticipanteassinatura__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00772;
          prmH00772 = new Object[] {
          new ParDef("AV10PropostaId",GXType.Int32,9,0)
          };
          Object[] prmH00773;
          prmH00773 = new Object[] {
          new ParDef("AV10PropostaId",GXType.Int32,9,0)
          };
          Object[] prmH00774;
          prmH00774 = new Object[] {
          new ParDef("AV12PropostaClinicaId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00772", "SELECT T1.PropostaResponsavelId AS PropostaResponsavelId, T1.PropostaId, T2.ClienteDocumento AS PropostaResponsavelDocumento, T2.ClienteRazaoSocial AS PropostaResponsavelRazaoSocial, T2.ContatoEmail AS PropostaResponsavelEmail FROM (Proposta T1 LEFT JOIN Cliente T2 ON T2.ClienteId = T1.PropostaResponsavelId) WHERE T1.PropostaId = :AV10PropostaId ORDER BY T1.PropostaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00772,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H00773", "SELECT PropostaId, PropostaClinicaId FROM Proposta WHERE PropostaId = :AV10PropostaId ORDER BY PropostaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00773,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H00774", "SELECT ClienteId, ResponsavelCPF, ResponsavelNome, ResponsavelEmail FROM Cliente WHERE ClienteId = :AV12PropostaClinicaId ORDER BY ClienteId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00774,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
       }
    }

 }

}
