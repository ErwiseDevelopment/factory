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
   public class consultaassinantecontrato : GXDataArea
   {
      public consultaassinantecontrato( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public consultaassinantecontrato( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_TrnMode ,
                           int aP1_AssinaturaParticipanteId )
      {
         this.AV8TrnMode = aP0_TrnMode;
         this.AV12AssinaturaParticipanteId = aP1_AssinaturaParticipanteId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavAssinaturaparticipante_assinaturaparticipantestatus = new GXCombobox();
         cmbavAssinaturaparticipante_assinaturaparticipantetipo = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
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
         PA5E2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5E2( ) ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "consultaassinantecontrato"+UrlEncode(StringUtil.RTrim(AV8TrnMode)) + "," + UrlEncode(StringUtil.LTrimStr(AV12AssinaturaParticipanteId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("consultaassinantecontrato") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vTRNMODE", StringUtil.RTrim( AV8TrnMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TrnMode, "")), context));
         GxWebStd.gx_hidden_field( context, "vASSINATURAPARTICIPANTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12AssinaturaParticipanteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vASSINATURAPARTICIPANTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12AssinaturaParticipanteId), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Assinaturaparticipante", AV5AssinaturaParticipante);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Assinaturaparticipante", AV5AssinaturaParticipante);
         }
         GxWebStd.gx_hidden_field( context, "vTRNMODE", StringUtil.RTrim( AV8TrnMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TrnMode, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vCHECKREQUIREDFIELDSRESULT", AV10CheckRequiredFieldsResult);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMESSAGES", AV7Messages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMESSAGES", AV7Messages);
         }
         GxWebStd.gx_hidden_field( context, "vASSINATURAPARTICIPANTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12AssinaturaParticipanteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vASSINATURAPARTICIPANTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12AssinaturaParticipanteId), "ZZZZZZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vASSINATURAPARTICIPANTE", AV5AssinaturaParticipante);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vASSINATURAPARTICIPANTE", AV5AssinaturaParticipante);
         }
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
            WE5E2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5E2( ) ;
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
         GXEncryptionTmp = "consultaassinantecontrato"+UrlEncode(StringUtil.RTrim(AV8TrnMode)) + "," + UrlEncode(StringUtil.LTrimStr(AV12AssinaturaParticipanteId,9,0));
         return formatLink("consultaassinantecontrato") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "ConsultaAssinanteContrato" ;
      }

      public override string GetPgmdesc( )
      {
         return "Consulta Assinante Contrato" ;
      }

      protected void WB5E0( )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavAssinaturaparticipante_participantenome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAssinaturaparticipante_participantenome_Internalname, "Nome", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAssinaturaparticipante_participantenome_Internalname, AV5AssinaturaParticipante.gxTpr_Participantenome, StringUtil.RTrim( context.localUtil.Format( AV5AssinaturaParticipante.gxTpr_Participantenome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAssinaturaparticipante_participantenome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavAssinaturaparticipante_participantenome_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ConsultaAssinanteContrato.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavAssinaturaparticipante_participanteemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAssinaturaparticipante_participanteemail_Internalname, "E-mail", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAssinaturaparticipante_participanteemail_Internalname, AV5AssinaturaParticipante.gxTpr_Participanteemail, StringUtil.RTrim( context.localUtil.Format( AV5AssinaturaParticipante.gxTpr_Participanteemail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAssinaturaparticipante_participanteemail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavAssinaturaparticipante_participanteemail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_ConsultaAssinanteContrato.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavAssinaturaparticipante_participantedocumento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAssinaturaparticipante_participantedocumento_Internalname, "Documento", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAssinaturaparticipante_participantedocumento_Internalname, AV5AssinaturaParticipante.gxTpr_Participantedocumento, StringUtil.RTrim( context.localUtil.Format( AV5AssinaturaParticipante.gxTpr_Participantedocumento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAssinaturaparticipante_participantedocumento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavAssinaturaparticipante_participantedocumento_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ConsultaAssinanteContrato.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavAssinaturaparticipante_assinaturaparticipantestatus_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavAssinaturaparticipante_assinaturaparticipantestatus_Internalname, "Status", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavAssinaturaparticipante_assinaturaparticipantestatus, cmbavAssinaturaparticipante_assinaturaparticipantestatus_Internalname, StringUtil.RTrim( AV5AssinaturaParticipante.gxTpr_Assinaturaparticipantestatus), 1, cmbavAssinaturaparticipante_assinaturaparticipantestatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavAssinaturaparticipante_assinaturaparticipantestatus.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "", true, 0, "HLP_ConsultaAssinanteContrato.htm");
            cmbavAssinaturaparticipante_assinaturaparticipantestatus.CurrentValue = StringUtil.RTrim( AV5AssinaturaParticipante.gxTpr_Assinaturaparticipantestatus);
            AssignProp("", false, cmbavAssinaturaparticipante_assinaturaparticipantestatus_Internalname, "Values", (string)(cmbavAssinaturaparticipante_assinaturaparticipantestatus.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavAssinaturaparticipante_assinaturaparticipantedatavisualizacao_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAssinaturaparticipante_assinaturaparticipantedatavisualizacao_Internalname, "Visualização", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavAssinaturaparticipante_assinaturaparticipantedatavisualizacao_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavAssinaturaparticipante_assinaturaparticipantedatavisualizacao_Internalname, context.localUtil.TToC( AV5AssinaturaParticipante.gxTpr_Assinaturaparticipantedatavisualizacao, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( AV5AssinaturaParticipante.gxTpr_Assinaturaparticipantedatavisualizacao, "99/99/9999 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'por',false,0);"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAssinaturaparticipante_assinaturaparticipantedatavisualizacao_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavAssinaturaparticipante_assinaturaparticipantedatavisualizacao_Enabled, 1, "text", "", 19, "chr", 1, "row", 19, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ConsultaAssinanteContrato.htm");
            GxWebStd.gx_bitmap( context, edtavAssinaturaparticipante_assinaturaparticipantedatavisualizacao_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavAssinaturaparticipante_assinaturaparticipantedatavisualizacao_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ConsultaAssinanteContrato.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavAssinaturaparticipante_assinaturaparticipantedataconclusao_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAssinaturaparticipante_assinaturaparticipantedataconclusao_Internalname, "Assinado em", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavAssinaturaparticipante_assinaturaparticipantedataconclusao_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavAssinaturaparticipante_assinaturaparticipantedataconclusao_Internalname, context.localUtil.TToC( AV5AssinaturaParticipante.gxTpr_Assinaturaparticipantedataconclusao, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( AV5AssinaturaParticipante.gxTpr_Assinaturaparticipantedataconclusao, "99/99/9999 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'por',false,0);"+";gx.evt.onblur(this,42);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAssinaturaparticipante_assinaturaparticipantedataconclusao_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavAssinaturaparticipante_assinaturaparticipantedataconclusao_Enabled, 1, "text", "", 19, "chr", 1, "row", 19, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ConsultaAssinanteContrato.htm");
            GxWebStd.gx_bitmap( context, edtavAssinaturaparticipante_assinaturaparticipantedataconclusao_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavAssinaturaparticipante_assinaturaparticipantedataconclusao_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ConsultaAssinanteContrato.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavAssinaturaparticipante_assinaturaparticipantetipo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavAssinaturaparticipante_assinaturaparticipantetipo_Internalname, "Tipo do participante", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavAssinaturaparticipante_assinaturaparticipantetipo, cmbavAssinaturaparticipante_assinaturaparticipantetipo_Internalname, StringUtil.RTrim( AV5AssinaturaParticipante.gxTpr_Assinaturaparticipantetipo), 1, cmbavAssinaturaparticipante_assinaturaparticipantetipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavAssinaturaparticipante_assinaturaparticipantetipo.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "", true, 0, "HLP_ConsultaAssinanteContrato.htm");
            cmbavAssinaturaparticipante_assinaturaparticipantetipo.CurrentValue = StringUtil.RTrim( AV5AssinaturaParticipante.gxTpr_Assinaturaparticipantetipo);
            AssignProp("", false, cmbavAssinaturaparticipante_assinaturaparticipantetipo_Internalname, "Values", (string)(cmbavAssinaturaparticipante_assinaturaparticipantetipo.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavAssinaturaparticipante_assinaturaparticipanteremoteaddres_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAssinaturaparticipante_assinaturaparticipanteremoteaddres_Internalname, "IP", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAssinaturaparticipante_assinaturaparticipanteremoteaddres_Internalname, AV5AssinaturaParticipante.gxTpr_Assinaturaparticipanteremoteaddres, StringUtil.RTrim( context.localUtil.Format( AV5AssinaturaParticipante.gxTpr_Assinaturaparticipanteremoteaddres, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAssinaturaparticipante_assinaturaparticipanteremoteaddres_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavAssinaturaparticipante_assinaturaparticipanteremoteaddres_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ConsultaAssinanteContrato.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavAssinaturaparticipante_assinaturaparticipantegeolocalizacao_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAssinaturaparticipante_assinaturaparticipantegeolocalizacao_Internalname, "Geolocalização", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAssinaturaparticipante_assinaturaparticipantegeolocalizacao_Internalname, AV5AssinaturaParticipante.gxTpr_Assinaturaparticipantegeolocalizacao, StringUtil.RTrim( context.localUtil.Format( AV5AssinaturaParticipante.gxTpr_Assinaturaparticipantegeolocalizacao, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAssinaturaparticipante_assinaturaparticipantegeolocalizacao_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavAssinaturaparticipante_assinaturaparticipantegeolocalizacao_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ConsultaAssinanteContrato.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavAssinaturaparticipante_assinaturaparticipantedispositivo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAssinaturaparticipante_assinaturaparticipantedispositivo_Internalname, "Dispositivo", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAssinaturaparticipante_assinaturaparticipantedispositivo_Internalname, AV5AssinaturaParticipante.gxTpr_Assinaturaparticipantedispositivo, StringUtil.RTrim( context.localUtil.Format( AV5AssinaturaParticipante.gxTpr_Assinaturaparticipantedispositivo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAssinaturaparticipante_assinaturaparticipantedispositivo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavAssinaturaparticipante_assinaturaparticipantedispositivo_Enabled, 1, "text", "", 80, "chr", 1, "row", 90, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ConsultaAssinanteContrato.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavAssinaturaparticipante_assinaturaparticipantecpf_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAssinaturaparticipante_assinaturaparticipantecpf_Internalname, "CPF", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAssinaturaparticipante_assinaturaparticipantecpf_Internalname, AV5AssinaturaParticipante.gxTpr_Assinaturaparticipantecpf, StringUtil.RTrim( context.localUtil.Format( AV5AssinaturaParticipante.gxTpr_Assinaturaparticipantecpf, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,65);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAssinaturaparticipante_assinaturaparticipantecpf_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavAssinaturaparticipante_assinaturaparticipantecpf_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ConsultaAssinanteContrato.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavAssinaturaparticipante_assinaturaparticipanteemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAssinaturaparticipante_assinaturaparticipanteemail_Internalname, "E-mail", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAssinaturaparticipante_assinaturaparticipanteemail_Internalname, AV5AssinaturaParticipante.gxTpr_Assinaturaparticipanteemail, StringUtil.RTrim( context.localUtil.Format( AV5AssinaturaParticipante.gxTpr_Assinaturaparticipanteemail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAssinaturaparticipante_assinaturaparticipanteemail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavAssinaturaparticipante_assinaturaparticipanteemail_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_ConsultaAssinanteContrato.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-md-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavAssinaturaparticipante_assinaturaparticipantenascimento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAssinaturaparticipante_assinaturaparticipantenascimento_Internalname, "Nascimento", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavAssinaturaparticipante_assinaturaparticipantenascimento_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavAssinaturaparticipante_assinaturaparticipantenascimento_Internalname, context.localUtil.Format(AV5AssinaturaParticipante.gxTpr_Assinaturaparticipantenascimento, "99/99/99"), context.localUtil.Format( AV5AssinaturaParticipante.gxTpr_Assinaturaparticipantenascimento, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAssinaturaparticipante_assinaturaparticipantenascimento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavAssinaturaparticipante_assinaturaparticipantenascimento_Enabled, 1, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ConsultaAssinanteContrato.htm");
            GxWebStd.gx_bitmap( context, edtavAssinaturaparticipante_assinaturaparticipantenascimento_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavAssinaturaparticipante_assinaturaparticipantenascimento_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ConsultaAssinanteContrato.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupFixedBottom CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", "Confirmar", bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtnenter_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ConsultaAssinanteContrato.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", "Fechar", bttBtncancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ConsultaAssinanteContrato.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAssinaturaparticipante_assinaturaparticipanteid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5AssinaturaParticipante.gxTpr_Assinaturaparticipanteid), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5AssinaturaParticipante.gxTpr_Assinaturaparticipanteid), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,85);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAssinaturaparticipante_assinaturaparticipanteid_Jsonclick, 0, "Attribute", "", "", "", "", edtavAssinaturaparticipante_assinaturaparticipanteid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ConsultaAssinanteContrato.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAssinaturaparticipante_assinaturaid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5AssinaturaParticipante.gxTpr_Assinaturaid), 10, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5AssinaturaParticipante.gxTpr_Assinaturaid), "ZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAssinaturaparticipante_assinaturaid_Jsonclick, 0, "Attribute", "", "", "", "", edtavAssinaturaparticipante_assinaturaid_Visible, 1, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ConsultaAssinanteContrato.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAssinaturaparticipante_participanteid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5AssinaturaParticipante.gxTpr_Participanteid), 8, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5AssinaturaParticipante.gxTpr_Participanteid), "ZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,87);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAssinaturaparticipante_participanteid_Jsonclick, 0, "Attribute", "", "", "", "", edtavAssinaturaparticipante_participanteid_Visible, 1, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ConsultaAssinanteContrato.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAssinaturaparticipante_assinaturaparticipantekey_Internalname, AV5AssinaturaParticipante.gxTpr_Assinaturaparticipantekey.ToString(), AV5AssinaturaParticipante.gxTpr_Assinaturaparticipantekey.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,88);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAssinaturaparticipante_assinaturaparticipantekey_Jsonclick, 0, "Attribute", "", "", "", "", edtavAssinaturaparticipante_assinaturaparticipantekey_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_ConsultaAssinanteContrato.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START5E2( )
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
         Form.Meta.addItem("description", "Consulta Assinante Contrato", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP5E0( ) ;
      }

      protected void WS5E2( )
      {
         START5E2( ) ;
         EVT5E2( ) ;
      }

      protected void EVT5E2( )
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
                              E115E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E125E2 ();
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
                                    E135E2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E145E2 ();
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

      protected void WE5E2( )
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

      protected void PA5E2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "consultaassinantecontrato")), "consultaassinantecontrato") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "consultaassinantecontrato")))) ;
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
                  gxfirstwebparm = GetFirstPar( "TrnMode");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV8TrnMode = gxfirstwebparm;
                     AssignAttri("", false, "AV8TrnMode", AV8TrnMode);
                     GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TrnMode, "")), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV12AssinaturaParticipanteId = (int)(Math.Round(NumberUtil.Val( GetPar( "AssinaturaParticipanteId"), "."), 18, MidpointRounding.ToEven));
                        AssignAttri("", false, "AV12AssinaturaParticipanteId", StringUtil.LTrimStr( (decimal)(AV12AssinaturaParticipanteId), 9, 0));
                        GxWebStd.gx_hidden_field( context, "gxhash_vASSINATURAPARTICIPANTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12AssinaturaParticipanteId), "ZZZZZZZZ9"), context));
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
               GX_FocusControl = edtavAssinaturaparticipante_participantenome_Internalname;
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
         if ( cmbavAssinaturaparticipante_assinaturaparticipantestatus.ItemCount > 0 )
         {
            AV5AssinaturaParticipante.gxTpr_Assinaturaparticipantestatus = cmbavAssinaturaparticipante_assinaturaparticipantestatus.getValidValue(AV5AssinaturaParticipante.gxTpr_Assinaturaparticipantestatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavAssinaturaparticipante_assinaturaparticipantestatus.CurrentValue = StringUtil.RTrim( AV5AssinaturaParticipante.gxTpr_Assinaturaparticipantestatus);
            AssignProp("", false, cmbavAssinaturaparticipante_assinaturaparticipantestatus_Internalname, "Values", cmbavAssinaturaparticipante_assinaturaparticipantestatus.ToJavascriptSource(), true);
         }
         if ( cmbavAssinaturaparticipante_assinaturaparticipantetipo.ItemCount > 0 )
         {
            AV5AssinaturaParticipante.gxTpr_Assinaturaparticipantetipo = cmbavAssinaturaparticipante_assinaturaparticipantetipo.getValidValue(AV5AssinaturaParticipante.gxTpr_Assinaturaparticipantetipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavAssinaturaparticipante_assinaturaparticipantetipo.CurrentValue = StringUtil.RTrim( AV5AssinaturaParticipante.gxTpr_Assinaturaparticipantetipo);
            AssignProp("", false, cmbavAssinaturaparticipante_assinaturaparticipantetipo_Internalname, "Values", cmbavAssinaturaparticipante_assinaturaparticipantetipo.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF5E2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavAssinaturaparticipante_participantenome_Enabled = 0;
         AssignProp("", false, edtavAssinaturaparticipante_participantenome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAssinaturaparticipante_participantenome_Enabled), 5, 0), true);
         edtavAssinaturaparticipante_participanteemail_Enabled = 0;
         AssignProp("", false, edtavAssinaturaparticipante_participanteemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAssinaturaparticipante_participanteemail_Enabled), 5, 0), true);
         edtavAssinaturaparticipante_participantedocumento_Enabled = 0;
         AssignProp("", false, edtavAssinaturaparticipante_participantedocumento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAssinaturaparticipante_participantedocumento_Enabled), 5, 0), true);
      }

      protected void RF5E2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E125E2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E145E2 ();
            WB5E0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes5E2( )
      {
      }

      protected void before_start_formulas( )
      {
         edtavAssinaturaparticipante_participantenome_Enabled = 0;
         AssignProp("", false, edtavAssinaturaparticipante_participantenome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAssinaturaparticipante_participantenome_Enabled), 5, 0), true);
         edtavAssinaturaparticipante_participanteemail_Enabled = 0;
         AssignProp("", false, edtavAssinaturaparticipante_participanteemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAssinaturaparticipante_participanteemail_Enabled), 5, 0), true);
         edtavAssinaturaparticipante_participantedocumento_Enabled = 0;
         AssignProp("", false, edtavAssinaturaparticipante_participantedocumento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAssinaturaparticipante_participantedocumento_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5E0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E115E2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vASSINATURAPARTICIPANTE"), AV5AssinaturaParticipante);
            ajax_req_read_hidden_sdt(cgiGet( "Assinaturaparticipante"), AV5AssinaturaParticipante);
            /* Read saved values. */
            /* Read variables values. */
            AV5AssinaturaParticipante.gxTpr_Participantenome = cgiGet( edtavAssinaturaparticipante_participantenome_Internalname);
            AV5AssinaturaParticipante.gxTpr_Participanteemail = cgiGet( edtavAssinaturaparticipante_participanteemail_Internalname);
            AV5AssinaturaParticipante.gxTpr_Participantedocumento = cgiGet( edtavAssinaturaparticipante_participantedocumento_Internalname);
            cmbavAssinaturaparticipante_assinaturaparticipantestatus.CurrentValue = cgiGet( cmbavAssinaturaparticipante_assinaturaparticipantestatus_Internalname);
            AV5AssinaturaParticipante.gxTpr_Assinaturaparticipantestatus = cgiGet( cmbavAssinaturaparticipante_assinaturaparticipantestatus_Internalname);
            if ( context.localUtil.VCDateTime( cgiGet( edtavAssinaturaparticipante_assinaturaparticipantedatavisualizacao_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Data visualiazação"}), 1, "ASSINATURAPARTICIPANTE_ASSINATURAPARTICIPANTEDATAVISUALIZACAO");
               GX_FocusControl = edtavAssinaturaparticipante_assinaturaparticipantedatavisualizacao_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5AssinaturaParticipante.gxTpr_Assinaturaparticipantedatavisualizacao = (DateTime)(DateTime.MinValue);
            }
            else
            {
               AV5AssinaturaParticipante.gxTpr_Assinaturaparticipantedatavisualizacao = context.localUtil.CToT( cgiGet( edtavAssinaturaparticipante_assinaturaparticipantedatavisualizacao_Internalname));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtavAssinaturaparticipante_assinaturaparticipantedataconclusao_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Data da conclusão"}), 1, "ASSINATURAPARTICIPANTE_ASSINATURAPARTICIPANTEDATACONCLUSAO");
               GX_FocusControl = edtavAssinaturaparticipante_assinaturaparticipantedataconclusao_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5AssinaturaParticipante.gxTpr_Assinaturaparticipantedataconclusao = (DateTime)(DateTime.MinValue);
            }
            else
            {
               AV5AssinaturaParticipante.gxTpr_Assinaturaparticipantedataconclusao = context.localUtil.CToT( cgiGet( edtavAssinaturaparticipante_assinaturaparticipantedataconclusao_Internalname));
            }
            cmbavAssinaturaparticipante_assinaturaparticipantetipo.CurrentValue = cgiGet( cmbavAssinaturaparticipante_assinaturaparticipantetipo_Internalname);
            AV5AssinaturaParticipante.gxTpr_Assinaturaparticipantetipo = cgiGet( cmbavAssinaturaparticipante_assinaturaparticipantetipo_Internalname);
            AV5AssinaturaParticipante.gxTpr_Assinaturaparticipanteremoteaddres = cgiGet( edtavAssinaturaparticipante_assinaturaparticipanteremoteaddres_Internalname);
            AV5AssinaturaParticipante.gxTpr_Assinaturaparticipantegeolocalizacao = cgiGet( edtavAssinaturaparticipante_assinaturaparticipantegeolocalizacao_Internalname);
            AV5AssinaturaParticipante.gxTpr_Assinaturaparticipantedispositivo = cgiGet( edtavAssinaturaparticipante_assinaturaparticipantedispositivo_Internalname);
            AV5AssinaturaParticipante.gxTpr_Assinaturaparticipantecpf = cgiGet( edtavAssinaturaparticipante_assinaturaparticipantecpf_Internalname);
            AV5AssinaturaParticipante.gxTpr_Assinaturaparticipanteemail = cgiGet( edtavAssinaturaparticipante_assinaturaparticipanteemail_Internalname);
            if ( context.localUtil.VCDate( cgiGet( edtavAssinaturaparticipante_assinaturaparticipantenascimento_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Assinatura Participante Nascimento"}), 1, "ASSINATURAPARTICIPANTE_ASSINATURAPARTICIPANTENASCIMENTO");
               GX_FocusControl = edtavAssinaturaparticipante_assinaturaparticipantenascimento_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5AssinaturaParticipante.gxTpr_Assinaturaparticipantenascimento = DateTime.MinValue;
            }
            else
            {
               AV5AssinaturaParticipante.gxTpr_Assinaturaparticipantenascimento = context.localUtil.CToD( cgiGet( edtavAssinaturaparticipante_assinaturaparticipantenascimento_Internalname), 2);
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavAssinaturaparticipante_assinaturaparticipanteid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavAssinaturaparticipante_assinaturaparticipanteid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ASSINATURAPARTICIPANTE_ASSINATURAPARTICIPANTEID");
               GX_FocusControl = edtavAssinaturaparticipante_assinaturaparticipanteid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5AssinaturaParticipante.gxTpr_Assinaturaparticipanteid = 0;
            }
            else
            {
               AV5AssinaturaParticipante.gxTpr_Assinaturaparticipanteid = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavAssinaturaparticipante_assinaturaparticipanteid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavAssinaturaparticipante_assinaturaid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavAssinaturaparticipante_assinaturaid_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ASSINATURAPARTICIPANTE_ASSINATURAID");
               GX_FocusControl = edtavAssinaturaparticipante_assinaturaid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5AssinaturaParticipante.gxTpr_Assinaturaid = 0;
            }
            else
            {
               AV5AssinaturaParticipante.gxTpr_Assinaturaid = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavAssinaturaparticipante_assinaturaid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavAssinaturaparticipante_participanteid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavAssinaturaparticipante_participanteid_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ASSINATURAPARTICIPANTE_PARTICIPANTEID");
               GX_FocusControl = edtavAssinaturaparticipante_participanteid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5AssinaturaParticipante.gxTpr_Participanteid = 0;
            }
            else
            {
               AV5AssinaturaParticipante.gxTpr_Participanteid = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavAssinaturaparticipante_participanteid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            }
            if ( StringUtil.StrCmp(cgiGet( edtavAssinaturaparticipante_assinaturaparticipantekey_Internalname), "") == 0 )
            {
               AV5AssinaturaParticipante.gxTpr_Assinaturaparticipantekey = Guid.Empty;
            }
            else
            {
               try
               {
                  AV5AssinaturaParticipante.gxTpr_Assinaturaparticipantekey = StringUtil.StrToGuid( cgiGet( edtavAssinaturaparticipante_assinaturaparticipantekey_Internalname));
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "ASSINATURAPARTICIPANTE_ASSINATURAPARTICIPANTEKEY");
                  GX_FocusControl = edtavAssinaturaparticipante_assinaturaparticipantekey_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
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
         E115E2 ();
         if (returnInSub) return;
      }

      protected void E115E2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV9LoadSuccess = true;
         if ( ( ( StringUtil.StrCmp(AV8TrnMode, "DSP") == 0 ) ) || ( ( StringUtil.StrCmp(AV8TrnMode, "INS") == 0 ) ) || ( ( StringUtil.StrCmp(AV8TrnMode, "UPD") == 0 ) ) || ( ( StringUtil.StrCmp(AV8TrnMode, "DLT") == 0 ) ) )
         {
            if ( StringUtil.StrCmp(AV8TrnMode, "INS") != 0 )
            {
               AV5AssinaturaParticipante.Load(AV12AssinaturaParticipanteId);
               AV9LoadSuccess = AV5AssinaturaParticipante.Success();
               if ( ! AV9LoadSuccess )
               {
                  AV7Messages = AV5AssinaturaParticipante.GetMessages();
                  /* Execute user subroutine: 'SHOW MESSAGES' */
                  S112 ();
                  if (returnInSub) return;
               }
               if ( ( StringUtil.StrCmp(AV8TrnMode, "DSP") == 0 ) || ( StringUtil.StrCmp(AV8TrnMode, "DLT") == 0 ) )
               {
                  cmbavAssinaturaparticipante_assinaturaparticipantestatus.Enabled = 0;
                  AssignProp("", false, cmbavAssinaturaparticipante_assinaturaparticipantestatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavAssinaturaparticipante_assinaturaparticipantestatus.Enabled), 5, 0), true);
                  edtavAssinaturaparticipante_assinaturaparticipantedatavisualizacao_Enabled = 0;
                  AssignProp("", false, edtavAssinaturaparticipante_assinaturaparticipantedatavisualizacao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAssinaturaparticipante_assinaturaparticipantedatavisualizacao_Enabled), 5, 0), true);
                  edtavAssinaturaparticipante_assinaturaparticipantedataconclusao_Enabled = 0;
                  AssignProp("", false, edtavAssinaturaparticipante_assinaturaparticipantedataconclusao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAssinaturaparticipante_assinaturaparticipantedataconclusao_Enabled), 5, 0), true);
                  cmbavAssinaturaparticipante_assinaturaparticipantetipo.Enabled = 0;
                  AssignProp("", false, cmbavAssinaturaparticipante_assinaturaparticipantetipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavAssinaturaparticipante_assinaturaparticipantetipo.Enabled), 5, 0), true);
                  edtavAssinaturaparticipante_assinaturaparticipanteremoteaddres_Enabled = 0;
                  AssignProp("", false, edtavAssinaturaparticipante_assinaturaparticipanteremoteaddres_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAssinaturaparticipante_assinaturaparticipanteremoteaddres_Enabled), 5, 0), true);
                  edtavAssinaturaparticipante_assinaturaparticipantegeolocalizacao_Enabled = 0;
                  AssignProp("", false, edtavAssinaturaparticipante_assinaturaparticipantegeolocalizacao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAssinaturaparticipante_assinaturaparticipantegeolocalizacao_Enabled), 5, 0), true);
                  edtavAssinaturaparticipante_assinaturaparticipantedispositivo_Enabled = 0;
                  AssignProp("", false, edtavAssinaturaparticipante_assinaturaparticipantedispositivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAssinaturaparticipante_assinaturaparticipantedispositivo_Enabled), 5, 0), true);
                  edtavAssinaturaparticipante_assinaturaparticipantecpf_Enabled = 0;
                  AssignProp("", false, edtavAssinaturaparticipante_assinaturaparticipantecpf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAssinaturaparticipante_assinaturaparticipantecpf_Enabled), 5, 0), true);
                  edtavAssinaturaparticipante_assinaturaparticipanteemail_Enabled = 0;
                  AssignProp("", false, edtavAssinaturaparticipante_assinaturaparticipanteemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAssinaturaparticipante_assinaturaparticipanteemail_Enabled), 5, 0), true);
                  edtavAssinaturaparticipante_assinaturaparticipantenascimento_Enabled = 0;
                  AssignProp("", false, edtavAssinaturaparticipante_assinaturaparticipantenascimento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAssinaturaparticipante_assinaturaparticipantenascimento_Enabled), 5, 0), true);
               }
            }
         }
         else
         {
            AV9LoadSuccess = false;
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         if ( AV9LoadSuccess )
         {
            if ( StringUtil.StrCmp(AV8TrnMode, "DLT") == 0 )
            {
               GX_msglist.addItem("Confirme a eliminação dos dados.");
            }
         }
         edtavAssinaturaparticipante_assinaturaparticipanteid_Visible = 0;
         AssignProp("", false, edtavAssinaturaparticipante_assinaturaparticipanteid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAssinaturaparticipante_assinaturaparticipanteid_Visible), 5, 0), true);
         edtavAssinaturaparticipante_assinaturaid_Visible = 0;
         AssignProp("", false, edtavAssinaturaparticipante_assinaturaid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAssinaturaparticipante_assinaturaid_Visible), 5, 0), true);
         edtavAssinaturaparticipante_participanteid_Visible = 0;
         AssignProp("", false, edtavAssinaturaparticipante_participanteid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAssinaturaparticipante_participanteid_Visible), 5, 0), true);
         edtavAssinaturaparticipante_assinaturaparticipantekey_Visible = 0;
         AssignProp("", false, edtavAssinaturaparticipante_assinaturaparticipantekey_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAssinaturaparticipante_assinaturaparticipantekey_Visible), 5, 0), true);
      }

      protected void E125E2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E135E2 ();
         if (returnInSub) return;
      }

      protected void E135E2( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV8TrnMode, "DSP") != 0 )
         {
            if ( StringUtil.StrCmp(AV8TrnMode, "DLT") != 0 )
            {
               /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
               S132 ();
               if (returnInSub) return;
            }
            if ( ( StringUtil.StrCmp(AV8TrnMode, "DLT") == 0 ) || AV10CheckRequiredFieldsResult )
            {
               if ( StringUtil.StrCmp(AV8TrnMode, "DLT") == 0 )
               {
                  AV5AssinaturaParticipante.Delete();
               }
               else
               {
                  AV5AssinaturaParticipante.Save();
               }
               if ( AV5AssinaturaParticipante.Success() )
               {
                  /* Execute user subroutine: 'AFTER_TRN' */
                  S142 ();
                  if (returnInSub) return;
               }
               else
               {
                  AV7Messages = AV5AssinaturaParticipante.GetMessages();
                  /* Execute user subroutine: 'SHOW MESSAGES' */
                  S112 ();
                  if (returnInSub) return;
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5AssinaturaParticipante", AV5AssinaturaParticipante);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7Messages", AV7Messages);
      }

      protected void S122( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ( StringUtil.StrCmp(AV8TrnMode, "DSP") != 0 ) ) )
         {
            bttBtnenter_Visible = 0;
            AssignProp("", false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'SHOW MESSAGES' Routine */
         returnInSub = false;
         AV30GXV18 = 1;
         while ( AV30GXV18 <= AV7Messages.Count )
         {
            AV6Message = ((GeneXus.Utils.SdtMessages_Message)AV7Messages.Item(AV30GXV18));
            GX_msglist.addItem(AV6Message.gxTpr_Description);
            AV30GXV18 = (int)(AV30GXV18+1);
         }
      }

      protected void S142( )
      {
         /* 'AFTER_TRN' Routine */
         returnInSub = false;
         context.CommitDataStores("consultaassinantecontrato",pr_default);
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S132( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV10CheckRequiredFieldsResult = true;
         AssignAttri("", false, "AV10CheckRequiredFieldsResult", AV10CheckRequiredFieldsResult);
      }

      protected void nextLoad( )
      {
      }

      protected void E145E2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV8TrnMode = (string)getParm(obj,0);
         AssignAttri("", false, "AV8TrnMode", AV8TrnMode);
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TrnMode, "")), context));
         AV12AssinaturaParticipanteId = Convert.ToInt32(getParm(obj,1));
         AssignAttri("", false, "AV12AssinaturaParticipanteId", StringUtil.LTrimStr( (decimal)(AV12AssinaturaParticipanteId), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vASSINATURAPARTICIPANTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12AssinaturaParticipanteId), "ZZZZZZZZ9"), context));
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
         PA5E2( ) ;
         WS5E2( ) ;
         WE5E2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101925967", true, true);
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
         context.AddJavascriptSource("consultaassinantecontrato.js", "?20256101925967", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavAssinaturaparticipante_assinaturaparticipantestatus.Name = "ASSINATURAPARTICIPANTE_ASSINATURAPARTICIPANTESTATUS";
         cmbavAssinaturaparticipante_assinaturaparticipantestatus.WebTags = "";
         cmbavAssinaturaparticipante_assinaturaparticipantestatus.addItem("Pendente", "Pendente", 0);
         cmbavAssinaturaparticipante_assinaturaparticipantestatus.addItem("Assinado", "Assinado", 0);
         cmbavAssinaturaparticipante_assinaturaparticipantestatus.addItem("Recusado", "Recusado", 0);
         if ( cmbavAssinaturaparticipante_assinaturaparticipantestatus.ItemCount > 0 )
         {
            AV5AssinaturaParticipante.gxTpr_Assinaturaparticipantestatus = cmbavAssinaturaparticipante_assinaturaparticipantestatus.getValidValue(AV5AssinaturaParticipante.gxTpr_Assinaturaparticipantestatus);
         }
         cmbavAssinaturaparticipante_assinaturaparticipantetipo.Name = "ASSINATURAPARTICIPANTE_ASSINATURAPARTICIPANTETIPO";
         cmbavAssinaturaparticipante_assinaturaparticipantetipo.WebTags = "";
         cmbavAssinaturaparticipante_assinaturaparticipantetipo.addItem("Contratado", "Contratada", 0);
         cmbavAssinaturaparticipante_assinaturaparticipantetipo.addItem("Contratante", "Contratante", 0);
         cmbavAssinaturaparticipante_assinaturaparticipantetipo.addItem("Testemunha", "Testemunha", 0);
         cmbavAssinaturaparticipante_assinaturaparticipantetipo.addItem("Sacado", "Sacado", 0);
         if ( cmbavAssinaturaparticipante_assinaturaparticipantetipo.ItemCount > 0 )
         {
            AV5AssinaturaParticipante.gxTpr_Assinaturaparticipantetipo = cmbavAssinaturaparticipante_assinaturaparticipantetipo.getValidValue(AV5AssinaturaParticipante.gxTpr_Assinaturaparticipantetipo);
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavAssinaturaparticipante_participantenome_Internalname = "ASSINATURAPARTICIPANTE_PARTICIPANTENOME";
         edtavAssinaturaparticipante_participanteemail_Internalname = "ASSINATURAPARTICIPANTE_PARTICIPANTEEMAIL";
         edtavAssinaturaparticipante_participantedocumento_Internalname = "ASSINATURAPARTICIPANTE_PARTICIPANTEDOCUMENTO";
         cmbavAssinaturaparticipante_assinaturaparticipantestatus_Internalname = "ASSINATURAPARTICIPANTE_ASSINATURAPARTICIPANTESTATUS";
         edtavAssinaturaparticipante_assinaturaparticipantedatavisualizacao_Internalname = "ASSINATURAPARTICIPANTE_ASSINATURAPARTICIPANTEDATAVISUALIZACAO";
         edtavAssinaturaparticipante_assinaturaparticipantedataconclusao_Internalname = "ASSINATURAPARTICIPANTE_ASSINATURAPARTICIPANTEDATACONCLUSAO";
         cmbavAssinaturaparticipante_assinaturaparticipantetipo_Internalname = "ASSINATURAPARTICIPANTE_ASSINATURAPARTICIPANTETIPO";
         edtavAssinaturaparticipante_assinaturaparticipanteremoteaddres_Internalname = "ASSINATURAPARTICIPANTE_ASSINATURAPARTICIPANTEREMOTEADDRES";
         edtavAssinaturaparticipante_assinaturaparticipantegeolocalizacao_Internalname = "ASSINATURAPARTICIPANTE_ASSINATURAPARTICIPANTEGEOLOCALIZACAO";
         edtavAssinaturaparticipante_assinaturaparticipantedispositivo_Internalname = "ASSINATURAPARTICIPANTE_ASSINATURAPARTICIPANTEDISPOSITIVO";
         edtavAssinaturaparticipante_assinaturaparticipantecpf_Internalname = "ASSINATURAPARTICIPANTE_ASSINATURAPARTICIPANTECPF";
         edtavAssinaturaparticipante_assinaturaparticipanteemail_Internalname = "ASSINATURAPARTICIPANTE_ASSINATURAPARTICIPANTEEMAIL";
         edtavAssinaturaparticipante_assinaturaparticipantenascimento_Internalname = "ASSINATURAPARTICIPANTE_ASSINATURAPARTICIPANTENASCIMENTO";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         edtavAssinaturaparticipante_assinaturaparticipanteid_Internalname = "ASSINATURAPARTICIPANTE_ASSINATURAPARTICIPANTEID";
         edtavAssinaturaparticipante_assinaturaid_Internalname = "ASSINATURAPARTICIPANTE_ASSINATURAID";
         edtavAssinaturaparticipante_participanteid_Internalname = "ASSINATURAPARTICIPANTE_PARTICIPANTEID";
         edtavAssinaturaparticipante_assinaturaparticipantekey_Internalname = "ASSINATURAPARTICIPANTE_ASSINATURAPARTICIPANTEKEY";
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
         edtavAssinaturaparticipante_assinaturaparticipantenascimento_Enabled = 1;
         edtavAssinaturaparticipante_assinaturaparticipanteemail_Enabled = 1;
         edtavAssinaturaparticipante_assinaturaparticipantecpf_Enabled = 1;
         edtavAssinaturaparticipante_assinaturaparticipantedispositivo_Enabled = 1;
         edtavAssinaturaparticipante_assinaturaparticipantegeolocalizacao_Enabled = 1;
         edtavAssinaturaparticipante_assinaturaparticipanteremoteaddres_Enabled = 1;
         cmbavAssinaturaparticipante_assinaturaparticipantetipo.Enabled = 1;
         edtavAssinaturaparticipante_assinaturaparticipantedataconclusao_Enabled = 1;
         edtavAssinaturaparticipante_assinaturaparticipantedatavisualizacao_Enabled = 1;
         cmbavAssinaturaparticipante_assinaturaparticipantestatus.Enabled = 1;
         edtavAssinaturaparticipante_participantedocumento_Enabled = -1;
         edtavAssinaturaparticipante_participanteemail_Enabled = -1;
         edtavAssinaturaparticipante_participantenome_Enabled = -1;
         edtavAssinaturaparticipante_assinaturaparticipantekey_Jsonclick = "";
         edtavAssinaturaparticipante_assinaturaparticipantekey_Visible = 1;
         edtavAssinaturaparticipante_participanteid_Jsonclick = "";
         edtavAssinaturaparticipante_participanteid_Visible = 1;
         edtavAssinaturaparticipante_assinaturaid_Jsonclick = "";
         edtavAssinaturaparticipante_assinaturaid_Visible = 1;
         edtavAssinaturaparticipante_assinaturaparticipanteid_Jsonclick = "";
         edtavAssinaturaparticipante_assinaturaparticipanteid_Visible = 1;
         bttBtnenter_Visible = 1;
         edtavAssinaturaparticipante_assinaturaparticipantenascimento_Jsonclick = "";
         edtavAssinaturaparticipante_assinaturaparticipantenascimento_Enabled = 1;
         edtavAssinaturaparticipante_assinaturaparticipanteemail_Jsonclick = "";
         edtavAssinaturaparticipante_assinaturaparticipanteemail_Enabled = 1;
         edtavAssinaturaparticipante_assinaturaparticipantecpf_Jsonclick = "";
         edtavAssinaturaparticipante_assinaturaparticipantecpf_Enabled = 1;
         edtavAssinaturaparticipante_assinaturaparticipantedispositivo_Jsonclick = "";
         edtavAssinaturaparticipante_assinaturaparticipantedispositivo_Enabled = 1;
         edtavAssinaturaparticipante_assinaturaparticipantegeolocalizacao_Jsonclick = "";
         edtavAssinaturaparticipante_assinaturaparticipantegeolocalizacao_Enabled = 1;
         edtavAssinaturaparticipante_assinaturaparticipanteremoteaddres_Jsonclick = "";
         edtavAssinaturaparticipante_assinaturaparticipanteremoteaddres_Enabled = 1;
         cmbavAssinaturaparticipante_assinaturaparticipantetipo_Jsonclick = "";
         cmbavAssinaturaparticipante_assinaturaparticipantetipo.Enabled = 1;
         edtavAssinaturaparticipante_assinaturaparticipantedataconclusao_Jsonclick = "";
         edtavAssinaturaparticipante_assinaturaparticipantedataconclusao_Enabled = 1;
         edtavAssinaturaparticipante_assinaturaparticipantedatavisualizacao_Jsonclick = "";
         edtavAssinaturaparticipante_assinaturaparticipantedatavisualizacao_Enabled = 1;
         cmbavAssinaturaparticipante_assinaturaparticipantestatus_Jsonclick = "";
         cmbavAssinaturaparticipante_assinaturaparticipantestatus.Enabled = 1;
         edtavAssinaturaparticipante_participantedocumento_Jsonclick = "";
         edtavAssinaturaparticipante_participantedocumento_Enabled = 0;
         edtavAssinaturaparticipante_participanteemail_Jsonclick = "";
         edtavAssinaturaparticipante_participanteemail_Enabled = 0;
         edtavAssinaturaparticipante_participantenome_Jsonclick = "";
         edtavAssinaturaparticipante_participantenome_Enabled = 0;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Consulta Assinante Contrato";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV8TrnMode","fld":"vTRNMODE","hsh":true,"type":"char"},{"av":"AV12AssinaturaParticipanteId","fld":"vASSINATURAPARTICIPANTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"ctrl":"BTNENTER","prop":"Visible"}]}""");
         setEventMetadata("ENTER","""{"handler":"E135E2","iparms":[{"av":"AV8TrnMode","fld":"vTRNMODE","hsh":true,"type":"char"},{"av":"AV10CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"},{"av":"AV5AssinaturaParticipante","fld":"vASSINATURAPARTICIPANTE","type":""},{"av":"AV7Messages","fld":"vMESSAGES","type":""}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV5AssinaturaParticipante","fld":"vASSINATURAPARTICIPANTE","type":""},{"av":"AV7Messages","fld":"vMESSAGES","type":""},{"av":"AV10CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"}]}""");
         setEventMetadata("VALIDV_GXV2","""{"handler":"Validv_Gxv2","iparms":[]}""");
         setEventMetadata("VALIDV_GXV4","""{"handler":"Validv_Gxv4","iparms":[]}""");
         setEventMetadata("VALIDV_GXV7","""{"handler":"Validv_Gxv7","iparms":[]}""");
         setEventMetadata("VALIDV_GXV12","""{"handler":"Validv_Gxv12","iparms":[]}""");
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
         wcpOAV8TrnMode = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV5AssinaturaParticipante = new SdtAssinaturaParticipante(context);
         AV7Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV6Message = new GeneXus.Utils.SdtMessages_Message(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.consultaassinantecontrato__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         edtavAssinaturaparticipante_participantenome_Enabled = 0;
         edtavAssinaturaparticipante_participanteemail_Enabled = 0;
         edtavAssinaturaparticipante_participantedocumento_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int AV12AssinaturaParticipanteId ;
      private int wcpOAV12AssinaturaParticipanteId ;
      private int edtavAssinaturaparticipante_participantenome_Enabled ;
      private int edtavAssinaturaparticipante_participanteemail_Enabled ;
      private int edtavAssinaturaparticipante_participantedocumento_Enabled ;
      private int edtavAssinaturaparticipante_assinaturaparticipantedatavisualizacao_Enabled ;
      private int edtavAssinaturaparticipante_assinaturaparticipantedataconclusao_Enabled ;
      private int edtavAssinaturaparticipante_assinaturaparticipanteremoteaddres_Enabled ;
      private int edtavAssinaturaparticipante_assinaturaparticipantegeolocalizacao_Enabled ;
      private int edtavAssinaturaparticipante_assinaturaparticipantedispositivo_Enabled ;
      private int edtavAssinaturaparticipante_assinaturaparticipantecpf_Enabled ;
      private int edtavAssinaturaparticipante_assinaturaparticipanteemail_Enabled ;
      private int edtavAssinaturaparticipante_assinaturaparticipantenascimento_Enabled ;
      private int bttBtnenter_Visible ;
      private int edtavAssinaturaparticipante_assinaturaparticipanteid_Visible ;
      private int edtavAssinaturaparticipante_assinaturaid_Visible ;
      private int edtavAssinaturaparticipante_participanteid_Visible ;
      private int edtavAssinaturaparticipante_assinaturaparticipantekey_Visible ;
      private int AV30GXV18 ;
      private int idxLst ;
      private string AV8TrnMode ;
      private string wcpOAV8TrnMode ;
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
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string edtavAssinaturaparticipante_participantenome_Internalname ;
      private string TempTags ;
      private string edtavAssinaturaparticipante_participantenome_Jsonclick ;
      private string edtavAssinaturaparticipante_participanteemail_Internalname ;
      private string edtavAssinaturaparticipante_participanteemail_Jsonclick ;
      private string edtavAssinaturaparticipante_participantedocumento_Internalname ;
      private string edtavAssinaturaparticipante_participantedocumento_Jsonclick ;
      private string cmbavAssinaturaparticipante_assinaturaparticipantestatus_Internalname ;
      private string cmbavAssinaturaparticipante_assinaturaparticipantestatus_Jsonclick ;
      private string edtavAssinaturaparticipante_assinaturaparticipantedatavisualizacao_Internalname ;
      private string edtavAssinaturaparticipante_assinaturaparticipantedatavisualizacao_Jsonclick ;
      private string edtavAssinaturaparticipante_assinaturaparticipantedataconclusao_Internalname ;
      private string edtavAssinaturaparticipante_assinaturaparticipantedataconclusao_Jsonclick ;
      private string cmbavAssinaturaparticipante_assinaturaparticipantetipo_Internalname ;
      private string cmbavAssinaturaparticipante_assinaturaparticipantetipo_Jsonclick ;
      private string edtavAssinaturaparticipante_assinaturaparticipanteremoteaddres_Internalname ;
      private string edtavAssinaturaparticipante_assinaturaparticipanteremoteaddres_Jsonclick ;
      private string edtavAssinaturaparticipante_assinaturaparticipantegeolocalizacao_Internalname ;
      private string edtavAssinaturaparticipante_assinaturaparticipantegeolocalizacao_Jsonclick ;
      private string edtavAssinaturaparticipante_assinaturaparticipantedispositivo_Internalname ;
      private string edtavAssinaturaparticipante_assinaturaparticipantedispositivo_Jsonclick ;
      private string edtavAssinaturaparticipante_assinaturaparticipantecpf_Internalname ;
      private string edtavAssinaturaparticipante_assinaturaparticipantecpf_Jsonclick ;
      private string edtavAssinaturaparticipante_assinaturaparticipanteemail_Internalname ;
      private string edtavAssinaturaparticipante_assinaturaparticipanteemail_Jsonclick ;
      private string edtavAssinaturaparticipante_assinaturaparticipantenascimento_Internalname ;
      private string edtavAssinaturaparticipante_assinaturaparticipantenascimento_Jsonclick ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavAssinaturaparticipante_assinaturaparticipanteid_Internalname ;
      private string edtavAssinaturaparticipante_assinaturaparticipanteid_Jsonclick ;
      private string edtavAssinaturaparticipante_assinaturaid_Internalname ;
      private string edtavAssinaturaparticipante_assinaturaid_Jsonclick ;
      private string edtavAssinaturaparticipante_participanteid_Internalname ;
      private string edtavAssinaturaparticipante_participanteid_Jsonclick ;
      private string edtavAssinaturaparticipante_assinaturaparticipantekey_Internalname ;
      private string edtavAssinaturaparticipante_assinaturaparticipantekey_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV10CheckRequiredFieldsResult ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV9LoadSuccess ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavAssinaturaparticipante_assinaturaparticipantestatus ;
      private GXCombobox cmbavAssinaturaparticipante_assinaturaparticipantetipo ;
      private SdtAssinaturaParticipante AV5AssinaturaParticipante ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV7Messages ;
      private GeneXus.Utils.SdtMessages_Message AV6Message ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class consultaassinantecontrato__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

 }

}
