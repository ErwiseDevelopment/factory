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
   public class wpparticipantecontrato : GXDataArea
   {
      public wpparticipantecontrato( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpparticipantecontrato( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_TrnMode ,
                           int aP1_ParticipanteId ,
                           long aP2_AssinaturaId )
      {
         this.AV9TrnMode = aP0_TrnMode;
         this.AV12ParticipanteId = aP1_ParticipanteId;
         this.AV13AssinaturaId = aP2_AssinaturaId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavParticipante_participantetipopessoa = new GXCombobox();
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpageprompt", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpageprompt", new Object[] {context});
            MasterPageObj.setDataArea(this,true);
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
         PA9U2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START9U2( ) ;
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
         context.WriteHtmlText( " "+"class=\"form-horizontal FormNoBackgroundColor\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpparticipantecontrato"+UrlEncode(StringUtil.RTrim(AV9TrnMode)) + "," + UrlEncode(StringUtil.LTrimStr(AV12ParticipanteId,8,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV13AssinaturaId,10,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormNoBackgroundColor\" data-gx-class=\"form-horizontal FormNoBackgroundColor\" novalidate action=\""+formatLink("wpparticipantecontrato") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal FormNoBackgroundColor", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "vTRNMODE", StringUtil.RTrim( AV9TrnMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV9TrnMode, "")), context));
         GxWebStd.gx_hidden_field( context, "vPARTICIPANTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12ParticipanteId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPARTICIPANTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12ParticipanteId), "ZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vASSINATURAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13AssinaturaId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vASSINATURAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13AssinaturaId), "ZZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Participante", AV5Participante);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Participante", AV5Participante);
         }
         GxWebStd.gx_hidden_field( context, "vTRNMODE", StringUtil.RTrim( AV9TrnMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV9TrnMode, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vCHECKREQUIREDFIELDSRESULT", AV6CheckRequiredFieldsResult);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMESSAGES", AV8Messages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMESSAGES", AV8Messages);
         }
         GxWebStd.gx_hidden_field( context, "ASSINATURAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A238AssinaturaId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vASSINATURAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13AssinaturaId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vASSINATURAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13AssinaturaId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "PARTICIPANTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A233ParticipanteId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPARTICIPANTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12ParticipanteId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPARTICIPANTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12ParticipanteId), "ZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "PARTICIPANTEEMAIL_F", A1005ParticipanteEmail_F);
         GxWebStd.gx_hidden_field( context, "PARTICIPANTEDOCUMENTO_F", A1006ParticipanteDocumento_F);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPARTICIPANTE", AV5Participante);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPARTICIPANTE", AV5Participante);
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
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal FormNoBackgroundColor" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE9U2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT9U2( ) ;
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
         GXEncryptionTmp = "wpparticipantecontrato"+UrlEncode(StringUtil.RTrim(AV9TrnMode)) + "," + UrlEncode(StringUtil.LTrimStr(AV12ParticipanteId,8,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV13AssinaturaId,10,0));
         return formatLink("wpparticipantecontrato") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WpParticipanteContrato" ;
      }

      public override string GetPgmdesc( )
      {
         return "ParticipanteContrato" ;
      }

      protected void WB9U0( )
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransactionPopUp", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavParticipante_participantedocumento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavParticipante_participantedocumento_Internalname, "Documento", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavParticipante_participantedocumento_Internalname, AV5Participante.gxTpr_Participantedocumento, StringUtil.RTrim( context.localUtil.Format( AV5Participante.gxTpr_Participantedocumento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,17);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavParticipante_participantedocumento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavParticipante_participantedocumento_Enabled, 1, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpParticipanteContrato.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavParticipante_participantenome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavParticipante_participantenome_Internalname, "Nome", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavParticipante_participantenome_Internalname, AV5Participante.gxTpr_Participantenome, StringUtil.RTrim( context.localUtil.Format( AV5Participante.gxTpr_Participantenome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavParticipante_participantenome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavParticipante_participantenome_Enabled, 1, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpParticipanteContrato.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavParticipante_participanteemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavParticipante_participanteemail_Internalname, "Email", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavParticipante_participanteemail_Internalname, AV5Participante.gxTpr_Participanteemail, StringUtil.RTrim( context.localUtil.Format( AV5Participante.gxTpr_Participanteemail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavParticipante_participanteemail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavParticipante_participanteemail_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WpParticipanteContrato.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavParticipante_participantetipopessoa_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavParticipante_participantetipopessoa_Internalname, "Tipo Pessoa", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavParticipante_participantetipopessoa, cmbavParticipante_participantetipopessoa_Internalname, StringUtil.RTrim( AV5Participante.gxTpr_Participantetipopessoa), 1, cmbavParticipante_participantetipopessoa_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavParticipante_participantetipopessoa.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "", true, 0, "HLP_WpParticipanteContrato.htm");
            cmbavParticipante_participantetipopessoa.CurrentValue = StringUtil.RTrim( AV5Participante.gxTpr_Participantetipopessoa);
            AssignProp("", false, cmbavParticipante_participantetipopessoa_Internalname, "Values", (string)(cmbavParticipante_participantetipopessoa.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablerepresentante_Internalname, divTablerepresentante_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, "Representante", 1, 0, "px", 0, "px", "Group", "", "HLP_WpParticipanteContrato.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divRepr_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divParticipante_participanterepresentantenome_cell_Internalname, 1, 0, "px", 0, "px", divParticipante_participanterepresentantenome_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavParticipante_participanterepresentantenome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavParticipante_participanterepresentantenome_Internalname, "Nome", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavParticipante_participanterepresentantenome_Internalname, AV5Participante.gxTpr_Participanterepresentantenome, StringUtil.RTrim( context.localUtil.Format( AV5Participante.gxTpr_Participanterepresentantenome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavParticipante_participanterepresentantenome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavParticipante_participanterepresentantenome_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpParticipanteContrato.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divParticipante_participanterepresentanteemail_cell_Internalname, 1, 0, "px", 0, "px", divParticipante_participanterepresentanteemail_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavParticipante_participanterepresentanteemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavParticipante_participanterepresentanteemail_Internalname, "Representante Email", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavParticipante_participanterepresentanteemail_Internalname, AV5Participante.gxTpr_Participanterepresentanteemail, StringUtil.RTrim( context.localUtil.Format( AV5Participante.gxTpr_Participanterepresentanteemail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavParticipante_participanterepresentanteemail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavParticipante_participanterepresentanteemail_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WpParticipanteContrato.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divParticipante_participanterepresentantedocumento_cell_Internalname, 1, 0, "px", 0, "px", divParticipante_participanterepresentantedocumento_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavParticipante_participanterepresentantedocumento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavParticipante_participanterepresentantedocumento_Internalname, "Representante Documento", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavParticipante_participanterepresentantedocumento_Internalname, AV5Participante.gxTpr_Participanterepresentantedocumento, StringUtil.RTrim( context.localUtil.Format( AV5Participante.gxTpr_Participanterepresentantedocumento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavParticipante_participanterepresentantedocumento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavParticipante_participanterepresentantedocumento_Enabled, 1, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpParticipanteContrato.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", "Confirmar", bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtnenter_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpParticipanteContrato.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", "Fechar", bttBtncancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpParticipanteContrato.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavParticipante_participanteid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Participante.gxTpr_Participanteid), 8, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5Participante.gxTpr_Participanteid), "ZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,65);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavParticipante_participanteid_Jsonclick, 0, "Attribute", "", "", "", "", edtavParticipante_participanteid_Visible, 1, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpParticipanteContrato.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START9U2( )
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
         Form.Meta.addItem("description", "ParticipanteContrato", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP9U0( ) ;
      }

      protected void WS9U2( )
      {
         START9U2( ) ;
         EVT9U2( ) ;
      }

      protected void EVT9U2( )
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
                              E119U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E129U2 ();
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
                                    E139U2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "PARTICIPANTE_PARTICIPANTEREPRESENTANTEEMAIL.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Participante_participanterepresentanteemail.Controlvaluechanged */
                              E149U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "PARTICIPANTE_PARTICIPANTEEMAIL.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Participante_participanteemail.Controlvaluechanged */
                              E159U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "PARTICIPANTE_PARTICIPANTEDOCUMENTO.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Participante_participantedocumento.Controlvaluechanged */
                              E169U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "PARTICIPANTE_PARTICIPANTEREPRESENTANTEDOCUMENTO.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Participante_participanterepresentantedocumento.Controlvaluechanged */
                              E179U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E189U2 ();
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

      protected void WE9U2( )
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

      protected void PA9U2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpparticipantecontrato")), "wpparticipantecontrato") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpparticipantecontrato")))) ;
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
                     AV9TrnMode = gxfirstwebparm;
                     AssignAttri("", false, "AV9TrnMode", AV9TrnMode);
                     GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV9TrnMode, "")), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV12ParticipanteId = (int)(Math.Round(NumberUtil.Val( GetPar( "ParticipanteId"), "."), 18, MidpointRounding.ToEven));
                        AssignAttri("", false, "AV12ParticipanteId", StringUtil.LTrimStr( (decimal)(AV12ParticipanteId), 8, 0));
                        GxWebStd.gx_hidden_field( context, "gxhash_vPARTICIPANTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12ParticipanteId), "ZZZZZZZ9"), context));
                        AV13AssinaturaId = (long)(Math.Round(NumberUtil.Val( GetPar( "AssinaturaId"), "."), 18, MidpointRounding.ToEven));
                        AssignAttri("", false, "AV13AssinaturaId", StringUtil.LTrimStr( (decimal)(AV13AssinaturaId), 10, 0));
                        GxWebStd.gx_hidden_field( context, "gxhash_vASSINATURAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13AssinaturaId), "ZZZZZZZZZ9"), context));
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
               GX_FocusControl = edtavParticipante_participantedocumento_Internalname;
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
         if ( cmbavParticipante_participantetipopessoa.ItemCount > 0 )
         {
            AV5Participante.gxTpr_Participantetipopessoa = cmbavParticipante_participantetipopessoa.getValidValue(AV5Participante.gxTpr_Participantetipopessoa);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavParticipante_participantetipopessoa.CurrentValue = StringUtil.RTrim( AV5Participante.gxTpr_Participantetipopessoa);
            AssignProp("", false, cmbavParticipante_participantetipopessoa_Internalname, "Values", cmbavParticipante_participantetipopessoa.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF9U2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF9U2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E129U2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E189U2 ();
            WB9U0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes9U2( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP9U0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E119U2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vPARTICIPANTE"), AV5Participante);
            ajax_req_read_hidden_sdt(cgiGet( "Participante"), AV5Participante);
            /* Read saved values. */
            /* Read variables values. */
            AV5Participante.gxTpr_Participantedocumento = cgiGet( edtavParticipante_participantedocumento_Internalname);
            AV5Participante.gxTpr_Participantenome = cgiGet( edtavParticipante_participantenome_Internalname);
            AV5Participante.gxTpr_Participanteemail = cgiGet( edtavParticipante_participanteemail_Internalname);
            cmbavParticipante_participantetipopessoa.CurrentValue = cgiGet( cmbavParticipante_participantetipopessoa_Internalname);
            AV5Participante.gxTpr_Participantetipopessoa = cgiGet( cmbavParticipante_participantetipopessoa_Internalname);
            AV5Participante.gxTpr_Participanterepresentantenome = cgiGet( edtavParticipante_participanterepresentantenome_Internalname);
            AV5Participante.gxTpr_Participanterepresentanteemail = cgiGet( edtavParticipante_participanterepresentanteemail_Internalname);
            AV5Participante.gxTpr_Participanterepresentantedocumento = cgiGet( edtavParticipante_participanterepresentantedocumento_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavParticipante_participanteid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavParticipante_participanteid_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PARTICIPANTE_PARTICIPANTEID");
               GX_FocusControl = edtavParticipante_participanteid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5Participante.gxTpr_Participanteid = 0;
            }
            else
            {
               AV5Participante.gxTpr_Participanteid = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavParticipante_participanteid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
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
         E119U2 ();
         if (returnInSub) return;
      }

      protected void E119U2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV10LoadSuccess = true;
         if ( ( ( StringUtil.StrCmp(AV9TrnMode, "DSP") == 0 ) ) || ( ( StringUtil.StrCmp(AV9TrnMode, "INS") == 0 ) ) || ( ( StringUtil.StrCmp(AV9TrnMode, "UPD") == 0 ) ) || ( ( StringUtil.StrCmp(AV9TrnMode, "DLT") == 0 ) ) )
         {
            if ( StringUtil.StrCmp(AV9TrnMode, "INS") != 0 )
            {
               AV5Participante.Load(AV12ParticipanteId);
               AV10LoadSuccess = AV5Participante.Success();
               if ( ! AV10LoadSuccess )
               {
                  AV8Messages = AV5Participante.GetMessages();
                  /* Execute user subroutine: 'SHOW MESSAGES' */
                  S112 ();
                  if (returnInSub) return;
               }
               if ( ( StringUtil.StrCmp(AV9TrnMode, "DSP") == 0 ) || ( StringUtil.StrCmp(AV9TrnMode, "DLT") == 0 ) )
               {
                  edtavParticipante_participantedocumento_Enabled = 0;
                  AssignProp("", false, edtavParticipante_participantedocumento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavParticipante_participantedocumento_Enabled), 5, 0), true);
                  edtavParticipante_participantenome_Enabled = 0;
                  AssignProp("", false, edtavParticipante_participantenome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavParticipante_participantenome_Enabled), 5, 0), true);
                  edtavParticipante_participanteemail_Enabled = 0;
                  AssignProp("", false, edtavParticipante_participanteemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavParticipante_participanteemail_Enabled), 5, 0), true);
                  cmbavParticipante_participantetipopessoa.Enabled = 0;
                  AssignProp("", false, cmbavParticipante_participantetipopessoa_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavParticipante_participantetipopessoa.Enabled), 5, 0), true);
                  edtavParticipante_participanterepresentantenome_Enabled = 0;
                  AssignProp("", false, edtavParticipante_participanterepresentantenome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavParticipante_participanterepresentantenome_Enabled), 5, 0), true);
                  edtavParticipante_participanterepresentanteemail_Enabled = 0;
                  AssignProp("", false, edtavParticipante_participanterepresentanteemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavParticipante_participanterepresentanteemail_Enabled), 5, 0), true);
                  edtavParticipante_participanterepresentantedocumento_Enabled = 0;
                  AssignProp("", false, edtavParticipante_participanterepresentantedocumento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavParticipante_participanterepresentantedocumento_Enabled), 5, 0), true);
               }
            }
         }
         else
         {
            AV10LoadSuccess = false;
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         if ( AV10LoadSuccess )
         {
            if ( StringUtil.StrCmp(AV9TrnMode, "DLT") == 0 )
            {
               GX_msglist.addItem("Confirme a eliminação dos dados.");
            }
         }
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S122 ();
         if (returnInSub) return;
         edtavParticipante_participanteid_Visible = 0;
         AssignProp("", false, edtavParticipante_participanteid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavParticipante_participanteid_Visible), 5, 0), true);
      }

      protected void E129U2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E139U2 ();
         if (returnInSub) return;
      }

      protected void E139U2( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV9TrnMode, "DSP") != 0 )
         {
            if ( StringUtil.StrCmp(AV9TrnMode, "DLT") != 0 )
            {
               /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
               S142 ();
               if (returnInSub) return;
            }
            if ( ( StringUtil.StrCmp(AV9TrnMode, "DLT") == 0 ) || AV6CheckRequiredFieldsResult )
            {
               if ( StringUtil.StrCmp(AV9TrnMode, "DLT") == 0 )
               {
                  AV5Participante.Delete();
               }
               else
               {
                  AV5Participante.Save();
               }
               if ( AV5Participante.Success() )
               {
                  /* Execute user subroutine: 'AFTER_TRN' */
                  S152 ();
                  if (returnInSub) return;
               }
               else
               {
                  AV8Messages = AV5Participante.GetMessages();
                  /* Execute user subroutine: 'SHOW MESSAGES' */
                  S112 ();
                  if (returnInSub) return;
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5Participante", AV5Participante);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV8Messages", AV8Messages);
      }

      protected void S132( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ( StringUtil.StrCmp(AV9TrnMode, "DSP") != 0 ) ) )
         {
            bttBtnenter_Visible = 0;
            AssignProp("", false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV6CheckRequiredFieldsResult = true;
         AssignAttri("", false, "AV6CheckRequiredFieldsResult", AV6CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV5Participante.gxTpr_Participantedocumento)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Documento", "", "", "", "", "", "", "", ""),  "error",  edtavParticipante_participantedocumento_Internalname,  "true",  ""));
            AV6CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV6CheckRequiredFieldsResult", AV6CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV5Participante.gxTpr_Participantenome)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Nome", "", "", "", "", "", "", "", ""),  "error",  edtavParticipante_participantenome_Internalname,  "true",  ""));
            AV6CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV6CheckRequiredFieldsResult", AV6CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV5Participante.gxTpr_Participanteemail)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Email", "", "", "", "", "", "", "", ""),  "error",  edtavParticipante_participanteemail_Internalname,  "true",  ""));
            AV6CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV6CheckRequiredFieldsResult", AV6CheckRequiredFieldsResult);
         }
         if ( ( ( StringUtil.StrCmp(AV5Participante.gxTpr_Participantetipopessoa, "JURIDICA") == 0 ) ) && String.IsNullOrEmpty(StringUtil.RTrim( AV5Participante.gxTpr_Participanterepresentantenome)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Nome", "", "", "", "", "", "", "", ""),  "error",  edtavParticipante_participanterepresentantenome_Internalname,  "true",  ""));
            AV6CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV6CheckRequiredFieldsResult", AV6CheckRequiredFieldsResult);
         }
         if ( ( ( StringUtil.StrCmp(AV5Participante.gxTpr_Participantetipopessoa, "JURIDICA") == 0 ) ) && String.IsNullOrEmpty(StringUtil.RTrim( AV5Participante.gxTpr_Participanterepresentanteemail)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Representante Email", "", "", "", "", "", "", "", ""),  "error",  edtavParticipante_participanterepresentanteemail_Internalname,  "true",  ""));
            AV6CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV6CheckRequiredFieldsResult", AV6CheckRequiredFieldsResult);
         }
         if ( ( ( StringUtil.StrCmp(AV5Participante.gxTpr_Participantetipopessoa, "JURIDICA") == 0 ) ) && String.IsNullOrEmpty(StringUtil.RTrim( AV5Participante.gxTpr_Participanterepresentantedocumento)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Representante Documento", "", "", "", "", "", "", "", ""),  "error",  edtavParticipante_participanterepresentantedocumento_Internalname,  "true",  ""));
            AV6CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV6CheckRequiredFieldsResult", AV6CheckRequiredFieldsResult);
         }
         /* Execute user subroutine: 'VALIDAEMAIL' */
         S172 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'VALIDAEMAILREPRESENTANTE' */
         S162 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'VALIDADOCUMENTO' */
         S182 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'VALIDADOCUMENTOREPRESENTANTE' */
         S192 ();
         if (returnInSub) return;
      }

      protected void S122( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV5Participante.gxTpr_Participantetipopessoa, "JURIDICA") == 0 )
         {
            divParticipante_participanterepresentantenome_cell_Class = "col-xs-12 DataContentCellFL RequiredDataContentCellFL";
            AssignProp("", false, divParticipante_participanterepresentantenome_cell_Internalname, "Class", divParticipante_participanterepresentantenome_cell_Class, true);
         }
         else
         {
            divParticipante_participanterepresentantenome_cell_Class = "col-xs-12 DataContentCellFL";
            AssignProp("", false, divParticipante_participanterepresentantenome_cell_Internalname, "Class", divParticipante_participanterepresentantenome_cell_Class, true);
         }
         if ( StringUtil.StrCmp(AV5Participante.gxTpr_Participantetipopessoa, "JURIDICA") == 0 )
         {
            divParticipante_participanterepresentanteemail_cell_Class = "col-xs-12 DataContentCellFL RequiredDataContentCellFL";
            AssignProp("", false, divParticipante_participanterepresentanteemail_cell_Internalname, "Class", divParticipante_participanterepresentanteemail_cell_Class, true);
         }
         else
         {
            divParticipante_participanterepresentanteemail_cell_Class = "col-xs-12 DataContentCellFL";
            AssignProp("", false, divParticipante_participanterepresentanteemail_cell_Internalname, "Class", divParticipante_participanterepresentanteemail_cell_Class, true);
         }
         if ( StringUtil.StrCmp(AV5Participante.gxTpr_Participantetipopessoa, "JURIDICA") == 0 )
         {
            divParticipante_participanterepresentantedocumento_cell_Class = "col-xs-12 DataContentCellFL RequiredDataContentCellFL";
            AssignProp("", false, divParticipante_participanterepresentantedocumento_cell_Internalname, "Class", divParticipante_participanterepresentantedocumento_cell_Class, true);
         }
         else
         {
            divParticipante_participanterepresentantedocumento_cell_Class = "col-xs-12 DataContentCellFL";
            AssignProp("", false, divParticipante_participanterepresentantedocumento_cell_Internalname, "Class", divParticipante_participanterepresentantedocumento_cell_Class, true);
         }
         divTablerepresentante_Visible = (((StringUtil.StrCmp(AV5Participante.gxTpr_Participantetipopessoa, "JURIDICA")==0)) ? 1 : 0);
         AssignProp("", false, divTablerepresentante_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablerepresentante_Visible), 5, 0), true);
      }

      protected void S112( )
      {
         /* 'SHOW MESSAGES' Routine */
         returnInSub = false;
         AV22GXV9 = 1;
         while ( AV22GXV9 <= AV8Messages.Count )
         {
            AV7Message = ((GeneXus.Utils.SdtMessages_Message)AV8Messages.Item(AV22GXV9));
            GX_msglist.addItem(AV7Message.gxTpr_Description);
            AV22GXV9 = (int)(AV22GXV9+1);
         }
      }

      protected void S152( )
      {
         /* 'AFTER_TRN' Routine */
         returnInSub = false;
         context.CommitDataStores("wpparticipantecontrato",pr_default);
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E149U2( )
      {
         /* Participante_participanterepresentanteemail_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'VALIDAEMAILREPRESENTANTE' */
         S162 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E159U2( )
      {
         /* Participante_participanteemail_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'VALIDAEMAIL' */
         S172 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E169U2( )
      {
         /* Participante_participantedocumento_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'VALIDADOCUMENTO' */
         S182 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E179U2( )
      {
         /* Participante_participanterepresentantedocumento_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'VALIDADOCUMENTOREPRESENTANTE' */
         S192 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S172( )
      {
         /* 'VALIDAEMAIL' Routine */
         returnInSub = false;
         /* Using cursor H009U2 */
         pr_default.execute(0, new Object[] {AV13AssinaturaId, AV12ParticipanteId, AV5Participante.gxTpr_Participanteemail});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1005ParticipanteEmail_F = H009U2_A1005ParticipanteEmail_F[0];
            A233ParticipanteId = H009U2_A233ParticipanteId[0];
            n233ParticipanteId = H009U2_n233ParticipanteId[0];
            A238AssinaturaId = H009U2_A238AssinaturaId[0];
            n238AssinaturaId = H009U2_n238AssinaturaId[0];
            A1001ParticipanteTipoPessoa = H009U2_A1001ParticipanteTipoPessoa[0];
            n1001ParticipanteTipoPessoa = H009U2_n1001ParticipanteTipoPessoa[0];
            A1003ParticipanteRepresentanteEmail = H009U2_A1003ParticipanteRepresentanteEmail[0];
            n1003ParticipanteRepresentanteEmail = H009U2_n1003ParticipanteRepresentanteEmail[0];
            A235ParticipanteEmail = H009U2_A235ParticipanteEmail[0];
            n235ParticipanteEmail = H009U2_n235ParticipanteEmail[0];
            A1005ParticipanteEmail_F = H009U2_A1005ParticipanteEmail_F[0];
            A1001ParticipanteTipoPessoa = H009U2_A1001ParticipanteTipoPessoa[0];
            n1001ParticipanteTipoPessoa = H009U2_n1001ParticipanteTipoPessoa[0];
            A1003ParticipanteRepresentanteEmail = H009U2_A1003ParticipanteRepresentanteEmail[0];
            n1003ParticipanteRepresentanteEmail = H009U2_n1003ParticipanteRepresentanteEmail[0];
            A235ParticipanteEmail = H009U2_A235ParticipanteEmail[0];
            n235ParticipanteEmail = H009U2_n235ParticipanteEmail[0];
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Esse e-mail já está em uso por outro participante do contrato",  "error",  edtavParticipante_participanteemail_Internalname,  "true",  ""));
            AV6CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV6CheckRequiredFieldsResult", AV6CheckRequiredFieldsResult);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S162( )
      {
         /* 'VALIDAEMAILREPRESENTANTE' Routine */
         returnInSub = false;
         /* Using cursor H009U3 */
         pr_default.execute(1, new Object[] {AV13AssinaturaId, AV12ParticipanteId, AV5Participante.gxTpr_Participanterepresentanteemail});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A1005ParticipanteEmail_F = H009U3_A1005ParticipanteEmail_F[0];
            A233ParticipanteId = H009U3_A233ParticipanteId[0];
            n233ParticipanteId = H009U3_n233ParticipanteId[0];
            A238AssinaturaId = H009U3_A238AssinaturaId[0];
            n238AssinaturaId = H009U3_n238AssinaturaId[0];
            A1001ParticipanteTipoPessoa = H009U3_A1001ParticipanteTipoPessoa[0];
            n1001ParticipanteTipoPessoa = H009U3_n1001ParticipanteTipoPessoa[0];
            A1003ParticipanteRepresentanteEmail = H009U3_A1003ParticipanteRepresentanteEmail[0];
            n1003ParticipanteRepresentanteEmail = H009U3_n1003ParticipanteRepresentanteEmail[0];
            A235ParticipanteEmail = H009U3_A235ParticipanteEmail[0];
            n235ParticipanteEmail = H009U3_n235ParticipanteEmail[0];
            A1005ParticipanteEmail_F = H009U3_A1005ParticipanteEmail_F[0];
            A1001ParticipanteTipoPessoa = H009U3_A1001ParticipanteTipoPessoa[0];
            n1001ParticipanteTipoPessoa = H009U3_n1001ParticipanteTipoPessoa[0];
            A1003ParticipanteRepresentanteEmail = H009U3_A1003ParticipanteRepresentanteEmail[0];
            n1003ParticipanteRepresentanteEmail = H009U3_n1003ParticipanteRepresentanteEmail[0];
            A235ParticipanteEmail = H009U3_A235ParticipanteEmail[0];
            n235ParticipanteEmail = H009U3_n235ParticipanteEmail[0];
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Esse e-mail já está em uso por outro participante do contrato",  "error",  edtavParticipante_participanterepresentanteemail_Internalname,  "true",  ""));
            AV6CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV6CheckRequiredFieldsResult", AV6CheckRequiredFieldsResult);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void S182( )
      {
         /* 'VALIDADOCUMENTO' Routine */
         returnInSub = false;
         /* Using cursor H009U4 */
         pr_default.execute(2, new Object[] {AV13AssinaturaId, AV12ParticipanteId, AV5Participante.gxTpr_Participantedocumento});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A1006ParticipanteDocumento_F = H009U4_A1006ParticipanteDocumento_F[0];
            A233ParticipanteId = H009U4_A233ParticipanteId[0];
            n233ParticipanteId = H009U4_n233ParticipanteId[0];
            A238AssinaturaId = H009U4_A238AssinaturaId[0];
            n238AssinaturaId = H009U4_n238AssinaturaId[0];
            A1001ParticipanteTipoPessoa = H009U4_A1001ParticipanteTipoPessoa[0];
            n1001ParticipanteTipoPessoa = H009U4_n1001ParticipanteTipoPessoa[0];
            A1004ParticipanteRepresentanteDocumento = H009U4_A1004ParticipanteRepresentanteDocumento[0];
            n1004ParticipanteRepresentanteDocumento = H009U4_n1004ParticipanteRepresentanteDocumento[0];
            A234ParticipanteDocumento = H009U4_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = H009U4_n234ParticipanteDocumento[0];
            A1006ParticipanteDocumento_F = H009U4_A1006ParticipanteDocumento_F[0];
            A1001ParticipanteTipoPessoa = H009U4_A1001ParticipanteTipoPessoa[0];
            n1001ParticipanteTipoPessoa = H009U4_n1001ParticipanteTipoPessoa[0];
            A1004ParticipanteRepresentanteDocumento = H009U4_A1004ParticipanteRepresentanteDocumento[0];
            n1004ParticipanteRepresentanteDocumento = H009U4_n1004ParticipanteRepresentanteDocumento[0];
            A234ParticipanteDocumento = H009U4_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = H009U4_n234ParticipanteDocumento[0];
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Este documento já está em uso por outro participante do contrato",  "error",  edtavParticipante_participantedocumento_Internalname,  "true",  ""));
            AV6CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV6CheckRequiredFieldsResult", AV6CheckRequiredFieldsResult);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void S192( )
      {
         /* 'VALIDADOCUMENTOREPRESENTANTE' Routine */
         returnInSub = false;
         /* Using cursor H009U5 */
         pr_default.execute(3, new Object[] {AV13AssinaturaId, AV12ParticipanteId, AV5Participante.gxTpr_Participanterepresentantedocumento});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A1006ParticipanteDocumento_F = H009U5_A1006ParticipanteDocumento_F[0];
            A233ParticipanteId = H009U5_A233ParticipanteId[0];
            n233ParticipanteId = H009U5_n233ParticipanteId[0];
            A238AssinaturaId = H009U5_A238AssinaturaId[0];
            n238AssinaturaId = H009U5_n238AssinaturaId[0];
            A1001ParticipanteTipoPessoa = H009U5_A1001ParticipanteTipoPessoa[0];
            n1001ParticipanteTipoPessoa = H009U5_n1001ParticipanteTipoPessoa[0];
            A1004ParticipanteRepresentanteDocumento = H009U5_A1004ParticipanteRepresentanteDocumento[0];
            n1004ParticipanteRepresentanteDocumento = H009U5_n1004ParticipanteRepresentanteDocumento[0];
            A234ParticipanteDocumento = H009U5_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = H009U5_n234ParticipanteDocumento[0];
            A1006ParticipanteDocumento_F = H009U5_A1006ParticipanteDocumento_F[0];
            A1001ParticipanteTipoPessoa = H009U5_A1001ParticipanteTipoPessoa[0];
            n1001ParticipanteTipoPessoa = H009U5_n1001ParticipanteTipoPessoa[0];
            A1004ParticipanteRepresentanteDocumento = H009U5_A1004ParticipanteRepresentanteDocumento[0];
            n1004ParticipanteRepresentanteDocumento = H009U5_n1004ParticipanteRepresentanteDocumento[0];
            A234ParticipanteDocumento = H009U5_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = H009U5_n234ParticipanteDocumento[0];
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Este documento do representante já está em uso por outro participante do contrato",  "error",  edtavParticipante_participanterepresentantedocumento_Internalname,  "true",  ""));
            AV6CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV6CheckRequiredFieldsResult", AV6CheckRequiredFieldsResult);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void nextLoad( )
      {
      }

      protected void E189U2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV9TrnMode = (string)getParm(obj,0);
         AssignAttri("", false, "AV9TrnMode", AV9TrnMode);
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV9TrnMode, "")), context));
         AV12ParticipanteId = Convert.ToInt32(getParm(obj,1));
         AssignAttri("", false, "AV12ParticipanteId", StringUtil.LTrimStr( (decimal)(AV12ParticipanteId), 8, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vPARTICIPANTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12ParticipanteId), "ZZZZZZZ9"), context));
         AV13AssinaturaId = Convert.ToInt64(getParm(obj,2));
         AssignAttri("", false, "AV13AssinaturaId", StringUtil.LTrimStr( (decimal)(AV13AssinaturaId), 10, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vASSINATURAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13AssinaturaId), "ZZZZZZZZZ9"), context));
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
         PA9U2( ) ;
         WS9U2( ) ;
         WE9U2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019285235", true, true);
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
         context.AddJavascriptSource("wpparticipantecontrato.js", "?202561019285235", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavParticipante_participantetipopessoa.Name = "PARTICIPANTE_PARTICIPANTETIPOPESSOA";
         cmbavParticipante_participantetipopessoa.WebTags = "";
         cmbavParticipante_participantetipopessoa.addItem("FISICA", "Física", 0);
         cmbavParticipante_participantetipopessoa.addItem("JURIDICA", "Jurídica", 0);
         if ( cmbavParticipante_participantetipopessoa.ItemCount > 0 )
         {
            AV5Participante.gxTpr_Participantetipopessoa = cmbavParticipante_participantetipopessoa.getValidValue(AV5Participante.gxTpr_Participantetipopessoa);
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavParticipante_participantedocumento_Internalname = "PARTICIPANTE_PARTICIPANTEDOCUMENTO";
         edtavParticipante_participantenome_Internalname = "PARTICIPANTE_PARTICIPANTENOME";
         edtavParticipante_participanteemail_Internalname = "PARTICIPANTE_PARTICIPANTEEMAIL";
         cmbavParticipante_participantetipopessoa_Internalname = "PARTICIPANTE_PARTICIPANTETIPOPESSOA";
         edtavParticipante_participanterepresentantenome_Internalname = "PARTICIPANTE_PARTICIPANTEREPRESENTANTENOME";
         divParticipante_participanterepresentantenome_cell_Internalname = "PARTICIPANTE_PARTICIPANTEREPRESENTANTENOME_CELL";
         edtavParticipante_participanterepresentanteemail_Internalname = "PARTICIPANTE_PARTICIPANTEREPRESENTANTEEMAIL";
         divParticipante_participanterepresentanteemail_cell_Internalname = "PARTICIPANTE_PARTICIPANTEREPRESENTANTEEMAIL_CELL";
         edtavParticipante_participanterepresentantedocumento_Internalname = "PARTICIPANTE_PARTICIPANTEREPRESENTANTEDOCUMENTO";
         divParticipante_participanterepresentantedocumento_cell_Internalname = "PARTICIPANTE_PARTICIPANTEREPRESENTANTEDOCUMENTO_CELL";
         divRepr_Internalname = "REPR";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         divTablerepresentante_Internalname = "TABLEREPRESENTANTE";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         edtavParticipante_participanteid_Internalname = "PARTICIPANTE_PARTICIPANTEID";
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
         edtavParticipante_participanterepresentantedocumento_Enabled = 1;
         edtavParticipante_participanterepresentanteemail_Enabled = 1;
         edtavParticipante_participanterepresentantenome_Enabled = 1;
         cmbavParticipante_participantetipopessoa.Enabled = 1;
         edtavParticipante_participanteemail_Enabled = 1;
         edtavParticipante_participantenome_Enabled = 1;
         edtavParticipante_participantedocumento_Enabled = 1;
         edtavParticipante_participanteid_Jsonclick = "";
         edtavParticipante_participanteid_Visible = 1;
         bttBtnenter_Visible = 1;
         edtavParticipante_participanterepresentantedocumento_Jsonclick = "";
         edtavParticipante_participanterepresentantedocumento_Enabled = 1;
         divParticipante_participanterepresentantedocumento_cell_Class = "col-xs-12";
         edtavParticipante_participanterepresentanteemail_Jsonclick = "";
         edtavParticipante_participanterepresentanteemail_Enabled = 1;
         divParticipante_participanterepresentanteemail_cell_Class = "col-xs-12";
         edtavParticipante_participanterepresentantenome_Jsonclick = "";
         edtavParticipante_participanterepresentantenome_Enabled = 1;
         divParticipante_participanterepresentantenome_cell_Class = "col-xs-12";
         divTablerepresentante_Visible = 1;
         cmbavParticipante_participantetipopessoa_Jsonclick = "";
         cmbavParticipante_participantetipopessoa.Enabled = 1;
         edtavParticipante_participanteemail_Jsonclick = "";
         edtavParticipante_participanteemail_Enabled = 1;
         edtavParticipante_participantenome_Jsonclick = "";
         edtavParticipante_participantenome_Enabled = 1;
         edtavParticipante_participantedocumento_Jsonclick = "";
         edtavParticipante_participantedocumento_Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "ParticipanteContrato";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV9TrnMode","fld":"vTRNMODE","hsh":true,"type":"char"},{"av":"AV13AssinaturaId","fld":"vASSINATURAID","pic":"ZZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV12ParticipanteId","fld":"vPARTICIPANTEID","pic":"ZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"ctrl":"BTNENTER","prop":"Visible"}]}""");
         setEventMetadata("ENTER","""{"handler":"E139U2","iparms":[{"av":"AV9TrnMode","fld":"vTRNMODE","hsh":true,"type":"char"},{"av":"AV6CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"},{"av":"AV5Participante","fld":"vPARTICIPANTE","type":""},{"av":"AV8Messages","fld":"vMESSAGES","type":""},{"av":"A238AssinaturaId","fld":"ASSINATURAID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV13AssinaturaId","fld":"vASSINATURAID","pic":"ZZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A233ParticipanteId","fld":"PARTICIPANTEID","pic":"ZZZZZZZ9","type":"int"},{"av":"AV12ParticipanteId","fld":"vPARTICIPANTEID","pic":"ZZZZZZZ9","hsh":true,"type":"int"},{"av":"A1005ParticipanteEmail_F","fld":"PARTICIPANTEEMAIL_F","type":"svchar"},{"av":"A1006ParticipanteDocumento_F","fld":"PARTICIPANTEDOCUMENTO_F","type":"svchar"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV5Participante","fld":"vPARTICIPANTE","type":""},{"av":"AV8Messages","fld":"vMESSAGES","type":""},{"av":"AV6CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"}]}""");
         setEventMetadata("PARTICIPANTE_PARTICIPANTEREPRESENTANTEEMAIL.CONTROLVALUECHANGED","""{"handler":"E149U2","iparms":[{"av":"A238AssinaturaId","fld":"ASSINATURAID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV13AssinaturaId","fld":"vASSINATURAID","pic":"ZZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A233ParticipanteId","fld":"PARTICIPANTEID","pic":"ZZZZZZZ9","type":"int"},{"av":"AV12ParticipanteId","fld":"vPARTICIPANTEID","pic":"ZZZZZZZ9","hsh":true,"type":"int"},{"av":"A1005ParticipanteEmail_F","fld":"PARTICIPANTEEMAIL_F","type":"svchar"},{"av":"AV5Participante","fld":"vPARTICIPANTE","type":""}]""");
         setEventMetadata("PARTICIPANTE_PARTICIPANTEREPRESENTANTEEMAIL.CONTROLVALUECHANGED",""","oparms":[{"av":"AV6CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"}]}""");
         setEventMetadata("PARTICIPANTE_PARTICIPANTEEMAIL.CONTROLVALUECHANGED","""{"handler":"E159U2","iparms":[{"av":"A238AssinaturaId","fld":"ASSINATURAID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV13AssinaturaId","fld":"vASSINATURAID","pic":"ZZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A233ParticipanteId","fld":"PARTICIPANTEID","pic":"ZZZZZZZ9","type":"int"},{"av":"AV12ParticipanteId","fld":"vPARTICIPANTEID","pic":"ZZZZZZZ9","hsh":true,"type":"int"},{"av":"A1005ParticipanteEmail_F","fld":"PARTICIPANTEEMAIL_F","type":"svchar"},{"av":"AV5Participante","fld":"vPARTICIPANTE","type":""}]""");
         setEventMetadata("PARTICIPANTE_PARTICIPANTEEMAIL.CONTROLVALUECHANGED",""","oparms":[{"av":"AV6CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"}]}""");
         setEventMetadata("PARTICIPANTE_PARTICIPANTEDOCUMENTO.CONTROLVALUECHANGED","""{"handler":"E169U2","iparms":[{"av":"A238AssinaturaId","fld":"ASSINATURAID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV13AssinaturaId","fld":"vASSINATURAID","pic":"ZZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A233ParticipanteId","fld":"PARTICIPANTEID","pic":"ZZZZZZZ9","type":"int"},{"av":"AV12ParticipanteId","fld":"vPARTICIPANTEID","pic":"ZZZZZZZ9","hsh":true,"type":"int"},{"av":"A1006ParticipanteDocumento_F","fld":"PARTICIPANTEDOCUMENTO_F","type":"svchar"},{"av":"AV5Participante","fld":"vPARTICIPANTE","type":""}]""");
         setEventMetadata("PARTICIPANTE_PARTICIPANTEDOCUMENTO.CONTROLVALUECHANGED",""","oparms":[{"av":"AV6CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"}]}""");
         setEventMetadata("PARTICIPANTE_PARTICIPANTEREPRESENTANTEDOCUMENTO.CONTROLVALUECHANGED","""{"handler":"E179U2","iparms":[{"av":"A238AssinaturaId","fld":"ASSINATURAID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV13AssinaturaId","fld":"vASSINATURAID","pic":"ZZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A233ParticipanteId","fld":"PARTICIPANTEID","pic":"ZZZZZZZ9","type":"int"},{"av":"AV12ParticipanteId","fld":"vPARTICIPANTEID","pic":"ZZZZZZZ9","hsh":true,"type":"int"},{"av":"A1006ParticipanteDocumento_F","fld":"PARTICIPANTEDOCUMENTO_F","type":"svchar"},{"av":"AV5Participante","fld":"vPARTICIPANTE","type":""}]""");
         setEventMetadata("PARTICIPANTE_PARTICIPANTEREPRESENTANTEDOCUMENTO.CONTROLVALUECHANGED",""","oparms":[{"av":"AV6CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"}]}""");
         setEventMetadata("VALIDV_GXV3","""{"handler":"Validv_Gxv3","iparms":[]}""");
         setEventMetadata("VALIDV_GXV4","""{"handler":"Validv_Gxv4","iparms":[]}""");
         setEventMetadata("VALIDV_GXV6","""{"handler":"Validv_Gxv6","iparms":[]}""");
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
         wcpOAV9TrnMode = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV5Participante = new SdtParticipante(context);
         AV8Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         A1005ParticipanteEmail_F = "";
         A1006ParticipanteDocumento_F = "";
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
         AV7Message = new GeneXus.Utils.SdtMessages_Message(context);
         H009U2_A242AssinaturaParticipanteId = new int[1] ;
         H009U2_A1005ParticipanteEmail_F = new string[] {""} ;
         H009U2_A233ParticipanteId = new int[1] ;
         H009U2_n233ParticipanteId = new bool[] {false} ;
         H009U2_A238AssinaturaId = new long[1] ;
         H009U2_n238AssinaturaId = new bool[] {false} ;
         H009U2_A1001ParticipanteTipoPessoa = new string[] {""} ;
         H009U2_n1001ParticipanteTipoPessoa = new bool[] {false} ;
         H009U2_A1003ParticipanteRepresentanteEmail = new string[] {""} ;
         H009U2_n1003ParticipanteRepresentanteEmail = new bool[] {false} ;
         H009U2_A235ParticipanteEmail = new string[] {""} ;
         H009U2_n235ParticipanteEmail = new bool[] {false} ;
         A1001ParticipanteTipoPessoa = "";
         A1003ParticipanteRepresentanteEmail = "";
         A235ParticipanteEmail = "";
         H009U3_A242AssinaturaParticipanteId = new int[1] ;
         H009U3_A1005ParticipanteEmail_F = new string[] {""} ;
         H009U3_A233ParticipanteId = new int[1] ;
         H009U3_n233ParticipanteId = new bool[] {false} ;
         H009U3_A238AssinaturaId = new long[1] ;
         H009U3_n238AssinaturaId = new bool[] {false} ;
         H009U3_A1001ParticipanteTipoPessoa = new string[] {""} ;
         H009U3_n1001ParticipanteTipoPessoa = new bool[] {false} ;
         H009U3_A1003ParticipanteRepresentanteEmail = new string[] {""} ;
         H009U3_n1003ParticipanteRepresentanteEmail = new bool[] {false} ;
         H009U3_A235ParticipanteEmail = new string[] {""} ;
         H009U3_n235ParticipanteEmail = new bool[] {false} ;
         H009U4_A242AssinaturaParticipanteId = new int[1] ;
         H009U4_A1006ParticipanteDocumento_F = new string[] {""} ;
         H009U4_A233ParticipanteId = new int[1] ;
         H009U4_n233ParticipanteId = new bool[] {false} ;
         H009U4_A238AssinaturaId = new long[1] ;
         H009U4_n238AssinaturaId = new bool[] {false} ;
         H009U4_A1001ParticipanteTipoPessoa = new string[] {""} ;
         H009U4_n1001ParticipanteTipoPessoa = new bool[] {false} ;
         H009U4_A1004ParticipanteRepresentanteDocumento = new string[] {""} ;
         H009U4_n1004ParticipanteRepresentanteDocumento = new bool[] {false} ;
         H009U4_A234ParticipanteDocumento = new string[] {""} ;
         H009U4_n234ParticipanteDocumento = new bool[] {false} ;
         A1004ParticipanteRepresentanteDocumento = "";
         A234ParticipanteDocumento = "";
         H009U5_A242AssinaturaParticipanteId = new int[1] ;
         H009U5_A1006ParticipanteDocumento_F = new string[] {""} ;
         H009U5_A233ParticipanteId = new int[1] ;
         H009U5_n233ParticipanteId = new bool[] {false} ;
         H009U5_A238AssinaturaId = new long[1] ;
         H009U5_n238AssinaturaId = new bool[] {false} ;
         H009U5_A1001ParticipanteTipoPessoa = new string[] {""} ;
         H009U5_n1001ParticipanteTipoPessoa = new bool[] {false} ;
         H009U5_A1004ParticipanteRepresentanteDocumento = new string[] {""} ;
         H009U5_n1004ParticipanteRepresentanteDocumento = new bool[] {false} ;
         H009U5_A234ParticipanteDocumento = new string[] {""} ;
         H009U5_n234ParticipanteDocumento = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpparticipantecontrato__default(),
            new Object[][] {
                new Object[] {
               H009U2_A242AssinaturaParticipanteId, H009U2_A1005ParticipanteEmail_F, H009U2_A233ParticipanteId, H009U2_n233ParticipanteId, H009U2_A238AssinaturaId, H009U2_n238AssinaturaId, H009U2_A1001ParticipanteTipoPessoa, H009U2_n1001ParticipanteTipoPessoa, H009U2_A1003ParticipanteRepresentanteEmail, H009U2_n1003ParticipanteRepresentanteEmail,
               H009U2_A235ParticipanteEmail, H009U2_n235ParticipanteEmail
               }
               , new Object[] {
               H009U3_A242AssinaturaParticipanteId, H009U3_A1005ParticipanteEmail_F, H009U3_A233ParticipanteId, H009U3_n233ParticipanteId, H009U3_A238AssinaturaId, H009U3_n238AssinaturaId, H009U3_A1001ParticipanteTipoPessoa, H009U3_n1001ParticipanteTipoPessoa, H009U3_A1003ParticipanteRepresentanteEmail, H009U3_n1003ParticipanteRepresentanteEmail,
               H009U3_A235ParticipanteEmail, H009U3_n235ParticipanteEmail
               }
               , new Object[] {
               H009U4_A242AssinaturaParticipanteId, H009U4_A1006ParticipanteDocumento_F, H009U4_A233ParticipanteId, H009U4_n233ParticipanteId, H009U4_A238AssinaturaId, H009U4_n238AssinaturaId, H009U4_A1001ParticipanteTipoPessoa, H009U4_n1001ParticipanteTipoPessoa, H009U4_A1004ParticipanteRepresentanteDocumento, H009U4_n1004ParticipanteRepresentanteDocumento,
               H009U4_A234ParticipanteDocumento, H009U4_n234ParticipanteDocumento
               }
               , new Object[] {
               H009U5_A242AssinaturaParticipanteId, H009U5_A1006ParticipanteDocumento_F, H009U5_A233ParticipanteId, H009U5_n233ParticipanteId, H009U5_A238AssinaturaId, H009U5_n238AssinaturaId, H009U5_A1001ParticipanteTipoPessoa, H009U5_n1001ParticipanteTipoPessoa, H009U5_A1004ParticipanteRepresentanteDocumento, H009U5_n1004ParticipanteRepresentanteDocumento,
               H009U5_A234ParticipanteDocumento, H009U5_n234ParticipanteDocumento
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short nRcdExists_6 ;
      private short nIsMod_6 ;
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
      private int AV12ParticipanteId ;
      private int wcpOAV12ParticipanteId ;
      private int A233ParticipanteId ;
      private int edtavParticipante_participantedocumento_Enabled ;
      private int edtavParticipante_participantenome_Enabled ;
      private int edtavParticipante_participanteemail_Enabled ;
      private int divTablerepresentante_Visible ;
      private int edtavParticipante_participanterepresentantenome_Enabled ;
      private int edtavParticipante_participanterepresentanteemail_Enabled ;
      private int edtavParticipante_participanterepresentantedocumento_Enabled ;
      private int bttBtnenter_Visible ;
      private int edtavParticipante_participanteid_Visible ;
      private int AV22GXV9 ;
      private int idxLst ;
      private long AV13AssinaturaId ;
      private long wcpOAV13AssinaturaId ;
      private long A238AssinaturaId ;
      private string AV9TrnMode ;
      private string wcpOAV9TrnMode ;
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
      private string divTableattributes_Internalname ;
      private string edtavParticipante_participantedocumento_Internalname ;
      private string TempTags ;
      private string edtavParticipante_participantedocumento_Jsonclick ;
      private string edtavParticipante_participantenome_Internalname ;
      private string edtavParticipante_participantenome_Jsonclick ;
      private string edtavParticipante_participanteemail_Internalname ;
      private string edtavParticipante_participanteemail_Jsonclick ;
      private string cmbavParticipante_participantetipopessoa_Internalname ;
      private string cmbavParticipante_participantetipopessoa_Jsonclick ;
      private string divTablerepresentante_Internalname ;
      private string grpUnnamedgroup1_Internalname ;
      private string divRepr_Internalname ;
      private string divParticipante_participanterepresentantenome_cell_Internalname ;
      private string divParticipante_participanterepresentantenome_cell_Class ;
      private string edtavParticipante_participanterepresentantenome_Internalname ;
      private string edtavParticipante_participanterepresentantenome_Jsonclick ;
      private string divParticipante_participanterepresentanteemail_cell_Internalname ;
      private string divParticipante_participanterepresentanteemail_cell_Class ;
      private string edtavParticipante_participanterepresentanteemail_Internalname ;
      private string edtavParticipante_participanterepresentanteemail_Jsonclick ;
      private string divParticipante_participanterepresentantedocumento_cell_Internalname ;
      private string divParticipante_participanterepresentantedocumento_cell_Class ;
      private string edtavParticipante_participanterepresentantedocumento_Internalname ;
      private string edtavParticipante_participanterepresentantedocumento_Jsonclick ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavParticipante_participanteid_Internalname ;
      private string edtavParticipante_participanteid_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV6CheckRequiredFieldsResult ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV10LoadSuccess ;
      private bool n233ParticipanteId ;
      private bool n238AssinaturaId ;
      private bool n1001ParticipanteTipoPessoa ;
      private bool n1003ParticipanteRepresentanteEmail ;
      private bool n235ParticipanteEmail ;
      private bool n1004ParticipanteRepresentanteDocumento ;
      private bool n234ParticipanteDocumento ;
      private string A1005ParticipanteEmail_F ;
      private string A1006ParticipanteDocumento_F ;
      private string A1001ParticipanteTipoPessoa ;
      private string A1003ParticipanteRepresentanteEmail ;
      private string A235ParticipanteEmail ;
      private string A1004ParticipanteRepresentanteDocumento ;
      private string A234ParticipanteDocumento ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavParticipante_participantetipopessoa ;
      private SdtParticipante AV5Participante ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV8Messages ;
      private GeneXus.Utils.SdtMessages_Message AV7Message ;
      private IDataStoreProvider pr_default ;
      private int[] H009U2_A242AssinaturaParticipanteId ;
      private string[] H009U2_A1005ParticipanteEmail_F ;
      private int[] H009U2_A233ParticipanteId ;
      private bool[] H009U2_n233ParticipanteId ;
      private long[] H009U2_A238AssinaturaId ;
      private bool[] H009U2_n238AssinaturaId ;
      private string[] H009U2_A1001ParticipanteTipoPessoa ;
      private bool[] H009U2_n1001ParticipanteTipoPessoa ;
      private string[] H009U2_A1003ParticipanteRepresentanteEmail ;
      private bool[] H009U2_n1003ParticipanteRepresentanteEmail ;
      private string[] H009U2_A235ParticipanteEmail ;
      private bool[] H009U2_n235ParticipanteEmail ;
      private int[] H009U3_A242AssinaturaParticipanteId ;
      private string[] H009U3_A1005ParticipanteEmail_F ;
      private int[] H009U3_A233ParticipanteId ;
      private bool[] H009U3_n233ParticipanteId ;
      private long[] H009U3_A238AssinaturaId ;
      private bool[] H009U3_n238AssinaturaId ;
      private string[] H009U3_A1001ParticipanteTipoPessoa ;
      private bool[] H009U3_n1001ParticipanteTipoPessoa ;
      private string[] H009U3_A1003ParticipanteRepresentanteEmail ;
      private bool[] H009U3_n1003ParticipanteRepresentanteEmail ;
      private string[] H009U3_A235ParticipanteEmail ;
      private bool[] H009U3_n235ParticipanteEmail ;
      private int[] H009U4_A242AssinaturaParticipanteId ;
      private string[] H009U4_A1006ParticipanteDocumento_F ;
      private int[] H009U4_A233ParticipanteId ;
      private bool[] H009U4_n233ParticipanteId ;
      private long[] H009U4_A238AssinaturaId ;
      private bool[] H009U4_n238AssinaturaId ;
      private string[] H009U4_A1001ParticipanteTipoPessoa ;
      private bool[] H009U4_n1001ParticipanteTipoPessoa ;
      private string[] H009U4_A1004ParticipanteRepresentanteDocumento ;
      private bool[] H009U4_n1004ParticipanteRepresentanteDocumento ;
      private string[] H009U4_A234ParticipanteDocumento ;
      private bool[] H009U4_n234ParticipanteDocumento ;
      private int[] H009U5_A242AssinaturaParticipanteId ;
      private string[] H009U5_A1006ParticipanteDocumento_F ;
      private int[] H009U5_A233ParticipanteId ;
      private bool[] H009U5_n233ParticipanteId ;
      private long[] H009U5_A238AssinaturaId ;
      private bool[] H009U5_n238AssinaturaId ;
      private string[] H009U5_A1001ParticipanteTipoPessoa ;
      private bool[] H009U5_n1001ParticipanteTipoPessoa ;
      private string[] H009U5_A1004ParticipanteRepresentanteDocumento ;
      private bool[] H009U5_n1004ParticipanteRepresentanteDocumento ;
      private string[] H009U5_A234ParticipanteDocumento ;
      private bool[] H009U5_n234ParticipanteDocumento ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpparticipantecontrato__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH009U2;
          prmH009U2 = new Object[] {
          new ParDef("AV13AssinaturaId",GXType.Int64,10,0) ,
          new ParDef("AV12ParticipanteId",GXType.Int32,8,0) ,
          new ParDef("AV5Parti_1Participanteemail",GXType.VarChar,100,0)
          };
          Object[] prmH009U3;
          prmH009U3 = new Object[] {
          new ParDef("AV13AssinaturaId",GXType.Int64,10,0) ,
          new ParDef("AV12ParticipanteId",GXType.Int32,8,0) ,
          new ParDef("AV5Parti_2Participantereprese",GXType.VarChar,100,0)
          };
          Object[] prmH009U4;
          prmH009U4 = new Object[] {
          new ParDef("AV13AssinaturaId",GXType.Int64,10,0) ,
          new ParDef("AV12ParticipanteId",GXType.Int32,8,0) ,
          new ParDef("AV5Parti_3Participantedocumen",GXType.VarChar,14,0)
          };
          Object[] prmH009U5;
          prmH009U5 = new Object[] {
          new ParDef("AV13AssinaturaId",GXType.Int64,10,0) ,
          new ParDef("AV12ParticipanteId",GXType.Int32,8,0) ,
          new ParDef("AV5Parti_4Participantereprese",GXType.VarChar,14,0)
          };
          def= new CursorDef[] {
              new CursorDef("H009U2", "SELECT T1.AssinaturaParticipanteId, CASE  WHEN COALESCE( T2.ParticipanteTipoPessoa, '') = ( 'JURIDICA') THEN COALESCE( T2.ParticipanteRepresentanteEmail, '') ELSE COALESCE( T2.ParticipanteEmail, '') END AS ParticipanteEmail_F, T1.ParticipanteId, T1.AssinaturaId, T2.ParticipanteTipoPessoa, T2.ParticipanteRepresentanteEmail, T2.ParticipanteEmail FROM (AssinaturaParticipante T1 LEFT JOIN Participante T2 ON T2.ParticipanteId = T1.ParticipanteId) WHERE (T1.AssinaturaId = :AV13AssinaturaId) AND (T1.ParticipanteId <> :AV12ParticipanteId) AND (LOWER(CASE  WHEN COALESCE( T2.ParticipanteTipoPessoa, '') = ( 'JURIDICA') THEN COALESCE( T2.ParticipanteRepresentanteEmail, '') ELSE COALESCE( T2.ParticipanteEmail, '') END) = ( :AV5Parti_1Participanteemail)) ORDER BY T1.AssinaturaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009U2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H009U3", "SELECT T1.AssinaturaParticipanteId, CASE  WHEN COALESCE( T2.ParticipanteTipoPessoa, '') = ( 'JURIDICA') THEN COALESCE( T2.ParticipanteRepresentanteEmail, '') ELSE COALESCE( T2.ParticipanteEmail, '') END AS ParticipanteEmail_F, T1.ParticipanteId, T1.AssinaturaId, T2.ParticipanteTipoPessoa, T2.ParticipanteRepresentanteEmail, T2.ParticipanteEmail FROM (AssinaturaParticipante T1 LEFT JOIN Participante T2 ON T2.ParticipanteId = T1.ParticipanteId) WHERE (T1.AssinaturaId = :AV13AssinaturaId) AND (T1.ParticipanteId <> :AV12ParticipanteId) AND (LOWER(CASE  WHEN COALESCE( T2.ParticipanteTipoPessoa, '') = ( 'JURIDICA') THEN COALESCE( T2.ParticipanteRepresentanteEmail, '') ELSE COALESCE( T2.ParticipanteEmail, '') END) = ( :AV5Parti_2Participantereprese)) ORDER BY T1.AssinaturaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009U3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H009U4", "SELECT T1.AssinaturaParticipanteId, CASE  WHEN COALESCE( T2.ParticipanteTipoPessoa, '') = ( 'JURIDICA') THEN COALESCE( T2.ParticipanteRepresentanteDocumento, '') ELSE COALESCE( T2.ParticipanteDocumento, '') END AS ParticipanteDocumento_F, T1.ParticipanteId, T1.AssinaturaId, T2.ParticipanteTipoPessoa, T2.ParticipanteRepresentanteDocumento, T2.ParticipanteDocumento FROM (AssinaturaParticipante T1 LEFT JOIN Participante T2 ON T2.ParticipanteId = T1.ParticipanteId) WHERE (T1.AssinaturaId = :AV13AssinaturaId) AND (T1.ParticipanteId <> :AV12ParticipanteId) AND (LOWER(CASE  WHEN COALESCE( T2.ParticipanteTipoPessoa, '') = ( 'JURIDICA') THEN COALESCE( T2.ParticipanteRepresentanteDocumento, '') ELSE COALESCE( T2.ParticipanteDocumento, '') END) = ( :AV5Parti_3Participantedocumen)) ORDER BY T1.AssinaturaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009U4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H009U5", "SELECT T1.AssinaturaParticipanteId, CASE  WHEN COALESCE( T2.ParticipanteTipoPessoa, '') = ( 'JURIDICA') THEN COALESCE( T2.ParticipanteRepresentanteDocumento, '') ELSE COALESCE( T2.ParticipanteDocumento, '') END AS ParticipanteDocumento_F, T1.ParticipanteId, T1.AssinaturaId, T2.ParticipanteTipoPessoa, T2.ParticipanteRepresentanteDocumento, T2.ParticipanteDocumento FROM (AssinaturaParticipante T1 LEFT JOIN Participante T2 ON T2.ParticipanteId = T1.ParticipanteId) WHERE (T1.AssinaturaId = :AV13AssinaturaId) AND (T1.ParticipanteId <> :AV12ParticipanteId) AND (LOWER(CASE  WHEN COALESCE( T2.ParticipanteTipoPessoa, '') = ( 'JURIDICA') THEN COALESCE( T2.ParticipanteRepresentanteDocumento, '') ELSE COALESCE( T2.ParticipanteDocumento, '') END) = ( :AV5Parti_4Participantereprese)) ORDER BY T1.AssinaturaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009U5,1, GxCacheFrequency.OFF ,false,true )
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
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((string[]) buf[8])[0] = rslt.getVarchar(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((string[]) buf[10])[0] = rslt.getVarchar(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((string[]) buf[8])[0] = rslt.getVarchar(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((string[]) buf[10])[0] = rslt.getVarchar(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((string[]) buf[8])[0] = rslt.getVarchar(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((string[]) buf[10])[0] = rslt.getVarchar(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((string[]) buf[8])[0] = rslt.getVarchar(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((string[]) buf[10])[0] = rslt.getVarchar(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                return;
       }
    }

 }

}
