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
   public class wpiniciarassinaturaproposta : GXDataArea
   {
      public wpiniciarassinaturaproposta( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpiniciarassinaturaproposta( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_PropostaId ,
                           string aP1_PropostaContratoAssinaturaTipo ,
                           int aP2_ReembolsoId )
      {
         this.AV32PropostaId = aP0_PropostaId;
         this.AV33PropostaContratoAssinaturaTipo = aP1_PropostaContratoAssinaturaTipo;
         this.AV48ReembolsoId = aP2_ReembolsoId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               gxnrGrid1_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid1") == 0 )
            {
               gxgrGrid1_refresh_invoke( ) ;
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

      protected void gxnrGrid1_newrow_invoke( )
      {
         nRC_GXsfl_40 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_40"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_40_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_40_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_40_idx = GetPar( "sGXsfl_40_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid1_newrow( ) ;
         /* End function gxnrGrid1_newrow_invoke */
      }

      protected void gxgrGrid1_refresh_invoke( )
      {
         subGrid1_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid1_Rows"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV14Array_SdParticipantes);
         AV31IsSemResponsavel = StringUtil.StrToBool( GetPar( "IsSemResponsavel"));
         AV32PropostaId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaId"), "."), 18, MidpointRounding.ToEven));
         AV33PropostaContratoAssinaturaTipo = GetPar( "PropostaContratoAssinaturaTipo");
         AV48ReembolsoId = (int)(Math.Round(NumberUtil.Val( GetPar( "ReembolsoId"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV6Contrato);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV14Array_SdParticipantes, AV31IsSemResponsavel, AV32PropostaId, AV33PropostaContratoAssinaturaTipo, AV48ReembolsoId, AV6Contrato) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid1_refresh_invoke */
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
         PA7A2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START7A2( ) ;
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
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
         GXEncryptionTmp = "wpiniciarassinaturaproposta"+UrlEncode(StringUtil.LTrimStr(AV32PropostaId,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV33PropostaContratoAssinaturaTipo)) + "," + UrlEncode(StringUtil.LTrimStr(AV48ReembolsoId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpiniciarassinaturaproposta") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, "vISSEMRESPONSAVEL", AV31IsSemResponsavel);
         GxWebStd.gx_hidden_field( context, "gxhash_vISSEMRESPONSAVEL", GetSecureSignedToken( "", AV31IsSemResponsavel, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCONTRATO", AV6Contrato);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCONTRATO", AV6Contrato);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vCONTRATO", GetSecureSignedToken( "", AV6Contrato, context));
         GxWebStd.gx_hidden_field( context, "vPROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV32PropostaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPROPOSTACONTRATOASSINATURATIPO", AV33PropostaContratoAssinaturaTipo);
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTACONTRATOASSINATURATIPO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV33PropostaContratoAssinaturaTipo, "")), context));
         GxWebStd.gx_hidden_field( context, "vREEMBOLSOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV48ReembolsoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV48ReembolsoId), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_40", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_40), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vLAYOUTCONTRATOID_DATA", AV44LayoutContratoId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vLAYOUTCONTRATOID_DATA", AV44LayoutContratoId_Data);
         }
         GxWebStd.gx_hidden_field( context, "vCONTRATOCORPO", AV9ContratoCorpo);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vARRAY_SDPARTICIPANTES", AV14Array_SdParticipantes);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vARRAY_SDPARTICIPANTES", AV14Array_SdParticipantes);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vISSEMRESPONSAVEL", AV31IsSemResponsavel);
         GxWebStd.gx_hidden_field( context, "gxhash_vISSEMRESPONSAVEL", GetSecureSignedToken( "", AV31IsSemResponsavel, context));
         GxWebStd.gx_hidden_field( context, "vPROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV32PropostaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPROPOSTACONTRATOASSINATURATIPO", AV33PropostaContratoAssinaturaTipo);
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTACONTRATOASSINATURATIPO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV33PropostaContratoAssinaturaTipo, "")), context));
         GxWebStd.gx_hidden_field( context, "PROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PROPOSTACONTRATOASSINATURATIPO", A573PropostaContratoAssinaturaTipo);
         GxWebStd.gx_hidden_field( context, "PROPOSTAASSINATURA", StringUtil.LTrim( StringUtil.NToC( (decimal)(A571PropostaAssinatura), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vREEMBOLSOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV48ReembolsoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV48ReembolsoId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "LAYOUTCONTRATOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A154LayoutContratoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "LAYOUTCONTRATOCORPO", A157LayoutContratoCorpo);
         GxWebStd.gx_hidden_field( context, "vGLOBALASSINATURAPARTICIPANTETIPO", AV27GlobalAssinaturaParticipanteTipo);
         GxWebStd.gx_hidden_field( context, "vGLOBALEMAIL", AV26GlobalEmail);
         GxWebStd.gx_hidden_field( context, "vGLOBALCPF", AV29GlobalCPF);
         GxWebStd.gx_hidden_field( context, "vGLOBALNOME", AV28GlobalNome);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCONTRATO", AV6Contrato);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCONTRATO", AV6Contrato);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vCONTRATO", GetSecureSignedToken( "", AV6Contrato, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDPARTICIPANTES", AV15SdParticipantes);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDPARTICIPANTES", AV15SdParticipantes);
         }
         GxWebStd.gx_hidden_field( context, "vGXV2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV63GXV2), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "subGrid1_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Recordcount), 5, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMBO_LAYOUTCONTRATOID_Cls", StringUtil.RTrim( Combo_layoutcontratoid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_LAYOUTCONTRATOID_Selectedvalue_set", StringUtil.RTrim( Combo_layoutcontratoid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_LAYOUTCONTRATOID_Visible", StringUtil.BoolToStr( Combo_layoutcontratoid_Visible));
         GxWebStd.gx_hidden_field( context, "COMBO_LAYOUTCONTRATOID_Emptyitem", StringUtil.BoolToStr( Combo_layoutcontratoid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "CONTRATOCORPO_Enabled", StringUtil.BoolToStr( Contratocorpo_Enabled));
         GxWebStd.gx_hidden_field( context, "CONTRATOCORPO_Captionclass", StringUtil.RTrim( Contratocorpo_Captionclass));
         GxWebStd.gx_hidden_field( context, "CONTRATOCORPO_Captionstyle", StringUtil.RTrim( Contratocorpo_Captionstyle));
         GxWebStd.gx_hidden_field( context, "CONTRATOCORPO_Captionposition", StringUtil.RTrim( Contratocorpo_Captionposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_ENTER_Title", StringUtil.RTrim( Dvelop_confirmpanel_enter_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_ENTER_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_enter_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_ENTER_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_enter_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_ENTER_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_enter_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_ENTER_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_enter_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_ENTER_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_enter_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_ENTER_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_enter_Confirmtype));
         GxWebStd.gx_hidden_field( context, "GRID1_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid1_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_ENTER_Result", StringUtil.RTrim( Dvelop_confirmpanel_enter_Result));
         GxWebStd.gx_hidden_field( context, "COMBO_LAYOUTCONTRATOID_Selectedvalue_get", StringUtil.RTrim( Combo_layoutcontratoid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_ENTER_Result", StringUtil.RTrim( Dvelop_confirmpanel_enter_Result));
         GxWebStd.gx_hidden_field( context, "COMBO_LAYOUTCONTRATOID_Selectedvalue_get", StringUtil.RTrim( Combo_layoutcontratoid_Selectedvalue_get));
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
            WE7A2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT7A2( ) ;
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
         GXEncryptionTmp = "wpiniciarassinaturaproposta"+UrlEncode(StringUtil.LTrimStr(AV32PropostaId,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV33PropostaContratoAssinaturaTipo)) + "," + UrlEncode(StringUtil.LTrimStr(AV48ReembolsoId,9,0));
         return formatLink("wpiniciarassinaturaproposta") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WpIniciarAssinaturaProposta" ;
      }

      public override string GetPgmdesc( )
      {
         return "Assinatura" ;
      }

      protected void WB7A0( )
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
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontrato_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCombo_layoutcontratoid_cell_Internalname, 1, 0, "px", 0, "px", divCombo_layoutcontratoid_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedlayoutcontratoid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_layoutcontratoid_Internalname, "Layout de contrato", "", "", lblTextblockcombo_layoutcontratoid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpIniciarAssinaturaProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_layoutcontratoid.SetProperty("Caption", Combo_layoutcontratoid_Caption);
            ucCombo_layoutcontratoid.SetProperty("Cls", Combo_layoutcontratoid_Cls);
            ucCombo_layoutcontratoid.SetProperty("EmptyItem", Combo_layoutcontratoid_Emptyitem);
            ucCombo_layoutcontratoid.SetProperty("DropDownOptionsData", AV44LayoutContratoId_Data);
            ucCombo_layoutcontratoid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_layoutcontratoid_Internalname, "COMBO_LAYOUTCONTRATOIDContainer");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavContratonome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContratonome_Internalname, "Nome do contrato", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'" + sGXsfl_40_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContratonome_Internalname, AV8ContratoNome, StringUtil.RTrim( context.localUtil.Format( AV8ContratoNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContratonome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavContratonome_Enabled, 0, "text", "", 80, "chr", 1, "row", 125, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpIniciarAssinaturaProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", -1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+Contratocorpo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, Contratocorpo_Internalname, "Contrato", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* User Defined Control */
            ucContratocorpo.SetProperty("Attribute", AV9ContratoCorpo);
            ucContratocorpo.SetProperty("CaptionClass", Contratocorpo_Captionclass);
            ucContratocorpo.SetProperty("CaptionStyle", Contratocorpo_Captionstyle);
            ucContratocorpo.SetProperty("CaptionPosition", Contratocorpo_Captionposition);
            ucContratocorpo.Render(context, "fckeditor", Contratocorpo_Internalname, "CONTRATOCORPOContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableparticipantes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnaddpart_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(40), 2, 0)+","+"null"+");", "Adicionar participante", bttBtnaddpart_Jsonclick, 5, "Adicionar participante", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOADDPART\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpIniciarAssinaturaProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 HasGridEmpowerer", "start", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl40( ) ;
         }
         if ( wbEnd == 40 )
         {
            wbEnd = 0;
            nRC_GXsfl_40 = (int)(nGXsfl_40_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
               Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
               }
            }
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(40), 2, 0)+","+"null"+");", "Enviar assinatura", bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpIniciarAssinaturaProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(40), 2, 0)+","+"null"+");", "Fechar", bttBtncancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpIniciarAssinaturaProposta.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'" + sGXsfl_40_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLayoutcontratoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43LayoutContratoId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV43LayoutContratoId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,57);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLayoutcontratoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavLayoutcontratoid_Visible, 1, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpIniciarAssinaturaProposta.htm");
            wb_table1_58_7A2( true) ;
         }
         else
         {
            wb_table1_58_7A2( false) ;
         }
         return  ;
      }

      protected void wb_table1_58_7A2e( bool wbgen )
      {
         if ( wbgen )
         {
            /* User Defined Control */
            ucGrid1_empowerer.Render(context, "wwp.gridempowerer", Grid1_empowerer_Internalname, "GRID1_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 40 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
                  Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START7A2( )
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
         Form.Meta.addItem("description", "Assinatura", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP7A0( ) ;
      }

      protected void WS7A2( )
      {
         START7A2( ) ;
         EVT7A2( ) ;
      }

      protected void EVT7A2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_LAYOUTCONTRATOID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_layoutcontratoid.Onoptionclicked */
                              E117A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_ENTER.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Dvelop_confirmpanel_enter.Close */
                              E127A2 ();
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
                                    E137A2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOADDPART'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoAddPart' */
                              E147A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS.WPINICIARASSINATURA_NOVOPARTICIPANTE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E157A2 ();
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRID1PAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid1_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid1_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid1_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid1_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRID1.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "VRETIRAR.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "VRETIRAR.CLICK") == 0 ) )
                           {
                              nGXsfl_40_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
                              SubsflControlProps_402( ) ;
                              AV13Retirar = cgiGet( edtavRetirar_Internalname);
                              AssignAttri("", false, edtavRetirar_Internalname, AV13Retirar);
                              AV7Nome = cgiGet( edtavNome_Internalname);
                              AssignAttri("", false, edtavNome_Internalname, AV7Nome);
                              AV10ParticipanteDocumento = cgiGet( edtavParticipantedocumento_Internalname);
                              AssignAttri("", false, edtavParticipantedocumento_Internalname, AV10ParticipanteDocumento);
                              GxWebStd.gx_hidden_field( context, "gxhash_vPARTICIPANTEDOCUMENTO"+"_"+sGXsfl_40_idx, GetSecureSignedToken( sGXsfl_40_idx, StringUtil.RTrim( context.localUtil.Format( AV10ParticipanteDocumento, "")), context));
                              AV11ParticipanteEmail = cgiGet( edtavParticipanteemail_Internalname);
                              AssignAttri("", false, edtavParticipanteemail_Internalname, AV11ParticipanteEmail);
                              cmbavAssinaturaparticipantetipo.Name = cmbavAssinaturaparticipantetipo_Internalname;
                              cmbavAssinaturaparticipantetipo.CurrentValue = cgiGet( cmbavAssinaturaparticipantetipo_Internalname);
                              AV12AssinaturaParticipanteTipo = cgiGet( cmbavAssinaturaparticipantetipo_Internalname);
                              AssignAttri("", false, cmbavAssinaturaparticipantetipo_Internalname, AV12AssinaturaParticipanteTipo);
                              AV38Desc = cgiGet( edtavDesc_Internalname);
                              AssignAttri("", false, edtavDesc_Internalname, AV38Desc);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E167A2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID1.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid1.Load */
                                    E177A2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VRETIRAR.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E187A2 ();
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
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE7A2( )
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

      protected void PA7A2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpiniciarassinaturaproposta")), "wpiniciarassinaturaproposta") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpiniciarassinaturaproposta")))) ;
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
                     AV32PropostaId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV32PropostaId", StringUtil.LTrimStr( (decimal)(AV32PropostaId), 9, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV32PropostaId), "ZZZZZZZZ9"), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV33PropostaContratoAssinaturaTipo = GetPar( "PropostaContratoAssinaturaTipo");
                        AssignAttri("", false, "AV33PropostaContratoAssinaturaTipo", AV33PropostaContratoAssinaturaTipo);
                        GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTACONTRATOASSINATURATIPO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV33PropostaContratoAssinaturaTipo, "")), context));
                        AV48ReembolsoId = (int)(Math.Round(NumberUtil.Val( GetPar( "ReembolsoId"), "."), 18, MidpointRounding.ToEven));
                        AssignAttri("", false, "AV48ReembolsoId", StringUtil.LTrimStr( (decimal)(AV48ReembolsoId), 9, 0));
                        GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV48ReembolsoId), "ZZZZZZZZ9"), context));
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
               GX_FocusControl = edtavContratonome_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_402( ) ;
         while ( nGXsfl_40_idx <= nRC_GXsfl_40 )
         {
            sendrow_402( ) ;
            nGXsfl_40_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_40_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_40_idx+1);
            sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
            SubsflControlProps_402( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        GXBaseCollection<SdtSdParticipantes> AV14Array_SdParticipantes ,
                                        bool AV31IsSemResponsavel ,
                                        int AV32PropostaId ,
                                        string AV33PropostaContratoAssinaturaTipo ,
                                        int AV48ReembolsoId ,
                                        SdtContrato AV6Contrato )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF7A2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vPARTICIPANTEDOCUMENTO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10ParticipanteDocumento, "")), context));
         GxWebStd.gx_hidden_field( context, "vPARTICIPANTEDOCUMENTO", AV10ParticipanteDocumento);
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
         RF7A2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavRetirar_Enabled = 0;
         edtavNome_Enabled = 0;
         edtavParticipantedocumento_Enabled = 0;
         edtavParticipanteemail_Enabled = 0;
         cmbavAssinaturaparticipantetipo.Enabled = 0;
         edtavDesc_Enabled = 0;
      }

      protected void RF7A2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 40;
         nGXsfl_40_idx = 1;
         sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
         SubsflControlProps_402( ) ;
         bGXsfl_40_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "GridWithBorderColor WorkWith");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         if ( subGrid1_Islastpage != 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(subGrid1_fnc_Recordcount( )-subGrid1_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
            Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_402( ) ;
            /* Execute user event: Grid1.Load */
            E177A2 ();
            if ( ( subGrid1_Islastpage == 0 ) && ( GRID1_nCurrentRecord > 0 ) && ( GRID1_nGridOutOfScope == 0 ) && ( nGXsfl_40_idx == 1 ) )
            {
               GRID1_nCurrentRecord = 0;
               GRID1_nGridOutOfScope = 1;
               subgrid1_firstpage( ) ;
               /* Execute user event: Grid1.Load */
               E177A2 ();
            }
            wbEnd = 40;
            WB7A0( ) ;
         }
         bGXsfl_40_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes7A2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, "vISSEMRESPONSAVEL", AV31IsSemResponsavel);
         GxWebStd.gx_hidden_field( context, "gxhash_vISSEMRESPONSAVEL", GetSecureSignedToken( "", AV31IsSemResponsavel, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vPARTICIPANTEDOCUMENTO"+"_"+sGXsfl_40_idx, GetSecureSignedToken( sGXsfl_40_idx, StringUtil.RTrim( context.localUtil.Format( AV10ParticipanteDocumento, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCONTRATO", AV6Contrato);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCONTRATO", AV6Contrato);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vCONTRATO", GetSecureSignedToken( "", AV6Contrato, context));
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         return (int)(((subGrid1_Recordcount==0) ? GRID1_nFirstRecordOnPage+1 : subGrid1_Recordcount)) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         if ( subGrid1_Rows > 0 )
         {
            return subGrid1_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(((subGrid1_Islastpage==1) ? NumberUtil.Int( (long)(Math.Round(subGrid1_fnc_Recordcount( )/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+((((int)((subGrid1_fnc_Recordcount( )) % (subGrid1_fnc_Recordsperpage( ))))==0) ? 0 : 1) : NumberUtil.Int( (long)(Math.Round(GRID1_nFirstRecordOnPage/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1)) ;
      }

      protected short subgrid1_firstpage( )
      {
         GRID1_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV14Array_SdParticipantes, AV31IsSemResponsavel, AV32PropostaId, AV33PropostaContratoAssinaturaTipo, AV48ReembolsoId, AV6Contrato) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_nextpage( )
      {
         if ( GRID1_nEOF == 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage+subGrid1_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV14Array_SdParticipantes, AV31IsSemResponsavel, AV32PropostaId, AV33PropostaContratoAssinaturaTipo, AV48ReembolsoId, AV6Contrato) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID1_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid1_previouspage( )
      {
         if ( GRID1_nFirstRecordOnPage >= subGrid1_fnc_Recordsperpage( ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage-subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV14Array_SdParticipantes, AV31IsSemResponsavel, AV32PropostaId, AV33PropostaContratoAssinaturaTipo, AV48ReembolsoId, AV6Contrato) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_lastpage( )
      {
         subGrid1_Islastpage = 1;
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV14Array_SdParticipantes, AV31IsSemResponsavel, AV32PropostaId, AV33PropostaContratoAssinaturaTipo, AV48ReembolsoId, AV6Contrato) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid1_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(subGrid1_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV14Array_SdParticipantes, AV31IsSemResponsavel, AV32PropostaId, AV33PropostaContratoAssinaturaTipo, AV48ReembolsoId, AV6Contrato) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtavRetirar_Enabled = 0;
         edtavNome_Enabled = 0;
         edtavParticipantedocumento_Enabled = 0;
         edtavParticipanteemail_Enabled = 0;
         cmbavAssinaturaparticipantetipo.Enabled = 0;
         edtavDesc_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP7A0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E167A2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vLAYOUTCONTRATOID_DATA"), AV44LayoutContratoId_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vSDPARTICIPANTES"), AV15SdParticipantes);
            ajax_req_read_hidden_sdt(cgiGet( "vARRAY_SDPARTICIPANTES"), AV14Array_SdParticipantes);
            /* Read saved values. */
            nRC_GXsfl_40 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_40"), ",", "."), 18, MidpointRounding.ToEven));
            AV9ContratoCorpo = cgiGet( "vCONTRATOCORPO");
            AssignAttri("", false, "AV9ContratoCorpo", AV9ContratoCorpo);
            AV63GXV2 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vGXV2"), ",", "."), 18, MidpointRounding.ToEven));
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            subGrid1_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "subGrid1_Recordcount"), ",", "."), 18, MidpointRounding.ToEven));
            subGrid1_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
            Combo_layoutcontratoid_Cls = cgiGet( "COMBO_LAYOUTCONTRATOID_Cls");
            Combo_layoutcontratoid_Selectedvalue_set = cgiGet( "COMBO_LAYOUTCONTRATOID_Selectedvalue_set");
            Combo_layoutcontratoid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_LAYOUTCONTRATOID_Visible"));
            Combo_layoutcontratoid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_LAYOUTCONTRATOID_Emptyitem"));
            Contratocorpo_Enabled = StringUtil.StrToBool( cgiGet( "CONTRATOCORPO_Enabled"));
            Contratocorpo_Captionclass = cgiGet( "CONTRATOCORPO_Captionclass");
            Contratocorpo_Captionstyle = cgiGet( "CONTRATOCORPO_Captionstyle");
            Contratocorpo_Captionposition = cgiGet( "CONTRATOCORPO_Captionposition");
            Dvelop_confirmpanel_enter_Title = cgiGet( "DVELOP_CONFIRMPANEL_ENTER_Title");
            Dvelop_confirmpanel_enter_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_ENTER_Confirmationtext");
            Dvelop_confirmpanel_enter_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_ENTER_Yesbuttoncaption");
            Dvelop_confirmpanel_enter_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_ENTER_Nobuttoncaption");
            Dvelop_confirmpanel_enter_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_ENTER_Cancelbuttoncaption");
            Dvelop_confirmpanel_enter_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_ENTER_Yesbuttonposition");
            Dvelop_confirmpanel_enter_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_ENTER_Confirmtype");
            Grid1_empowerer_Gridinternalname = cgiGet( "GRID1_EMPOWERER_Gridinternalname");
            Dvelop_confirmpanel_enter_Result = cgiGet( "DVELOP_CONFIRMPANEL_ENTER_Result");
            Combo_layoutcontratoid_Selectedvalue_get = cgiGet( "COMBO_LAYOUTCONTRATOID_Selectedvalue_get");
            /* Read variables values. */
            AV8ContratoNome = cgiGet( edtavContratonome_Internalname);
            AssignAttri("", false, "AV8ContratoNome", AV8ContratoNome);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavLayoutcontratoid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavLayoutcontratoid_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vLAYOUTCONTRATOID");
               GX_FocusControl = edtavLayoutcontratoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV43LayoutContratoId = 0;
               AssignAttri("", false, "AV43LayoutContratoId", StringUtil.LTrimStr( (decimal)(AV43LayoutContratoId), 4, 0));
            }
            else
            {
               AV43LayoutContratoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavLayoutcontratoid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV43LayoutContratoId", StringUtil.LTrimStr( (decimal)(AV43LayoutContratoId), 4, 0));
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
         E167A2 ();
         if (returnInSub) return;
      }

      protected void E167A2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtWWPContext1 = AV42WWPContext;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  GXt_SdtWWPContext1) ;
         AV42WWPContext = GXt_SdtWWPContext1;
         if ( (0==AV48ReembolsoId) )
         {
            /* Using cursor H007A2 */
            pr_default.execute(0, new Object[] {AV32PropostaId, AV33PropostaContratoAssinaturaTipo});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A573PropostaContratoAssinaturaTipo = H007A2_A573PropostaContratoAssinaturaTipo[0];
               n573PropostaContratoAssinaturaTipo = H007A2_n573PropostaContratoAssinaturaTipo[0];
               A323PropostaId = H007A2_A323PropostaId[0];
               n323PropostaId = H007A2_n323PropostaId[0];
               context.setWebReturnParms(new Object[] {});
               context.setWebReturnParmsMetadata(new Object[] {});
               context.wjLocDisableFrm = 1;
               context.nUserReturn = 1;
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
               pr_default.readNext(0);
            }
            pr_default.close(0);
         }
         edtavLayoutcontratoid_Visible = 0;
         AssignProp("", false, edtavLayoutcontratoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLayoutcontratoid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOLAYOUTCONTRATOID' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S122 ();
         if (returnInSub) return;
         Grid1_empowerer_Gridinternalname = subGrid1_Internalname;
         ucGrid1_empowerer.SendProperty(context, "", false, Grid1_empowerer_Internalname, "GridInternalName", Grid1_empowerer_Gridinternalname);
         subGrid1_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
         /* Using cursor H007A3 */
         pr_default.execute(1, new Object[] {AV32PropostaId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A323PropostaId = H007A3_A323PropostaId[0];
            n323PropostaId = H007A3_n323PropostaId[0];
            A504PropostaPacienteClienteId = H007A3_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = H007A3_n504PropostaPacienteClienteId[0];
            A553PropostaResponsavelId = H007A3_A553PropostaResponsavelId[0];
            n553PropostaResponsavelId = H007A3_n553PropostaResponsavelId[0];
            A505PropostaPacienteClienteRazaoSocial = H007A3_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = H007A3_n505PropostaPacienteClienteRazaoSocial[0];
            A328PropostaCratedBy = H007A3_A328PropostaCratedBy[0];
            n328PropostaCratedBy = H007A3_n328PropostaCratedBy[0];
            A505PropostaPacienteClienteRazaoSocial = H007A3_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = H007A3_n505PropostaPacienteClienteRazaoSocial[0];
            AV36PropostaPacienteClienteId = A504PropostaPacienteClienteId;
            AV35ResponsavelClienteId = A553PropostaResponsavelId;
            AssignAttri("", false, "AV35ResponsavelClienteId", StringUtil.LTrimStr( (decimal)(AV35ResponsavelClienteId), 9, 0));
            AV39PropostaPacienteClienteRazaoSocial = A505PropostaPacienteClienteRazaoSocial;
            AV34ClinicaClienteId = A328PropostaCratedBy;
            AssignAttri("", false, "AV34ClinicaClienteId", StringUtil.LTrimStr( (decimal)(AV34ClinicaClienteId), 9, 0));
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         AV14Array_SdParticipantes = new GXBaseCollection<SdtSdParticipantes>( context, "SdParticipantes", "Factory21");
         AV15SdParticipantes = new SdtSdParticipantes(context);
         /* Using cursor H007A4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A773EmpresaUtilizaRepresentanteAssinatura = H007A4_A773EmpresaUtilizaRepresentanteAssinatura[0];
            n773EmpresaUtilizaRepresentanteAssinatura = H007A4_n773EmpresaUtilizaRepresentanteAssinatura[0];
            A771EmpresaRepresentanteNome = H007A4_A771EmpresaRepresentanteNome[0];
            n771EmpresaRepresentanteNome = H007A4_n771EmpresaRepresentanteNome[0];
            A770EmpresaRepresentanteCPF = H007A4_A770EmpresaRepresentanteCPF[0];
            n770EmpresaRepresentanteCPF = H007A4_n770EmpresaRepresentanteCPF[0];
            A772EmpresaRepresentanteEmail = H007A4_A772EmpresaRepresentanteEmail[0];
            n772EmpresaRepresentanteEmail = H007A4_n772EmpresaRepresentanteEmail[0];
            AV15SdParticipantes.gxTpr_Participantenome = A771EmpresaRepresentanteNome;
            AV15SdParticipantes.gxTpr_Participantedocumento = A770EmpresaRepresentanteCPF;
            AV15SdParticipantes.gxTpr_Participanteemail = A772EmpresaRepresentanteEmail;
            AV15SdParticipantes.gxTpr_Assinaturaparticipantetipo = "Contratado";
            AV14Array_SdParticipantes.Add(AV15SdParticipantes, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         if ( ! ( StringUtil.StrCmp(AV33PropostaContratoAssinaturaTipo, "Documento") == 0 ) )
         {
            /* Using cursor H007A5 */
            pr_default.execute(3);
            while ( (pr_default.getStatus(3) != 101) )
            {
               A398ConfiguracoesLayoutProposta = H007A5_A398ConfiguracoesLayoutProposta[0];
               n398ConfiguracoesLayoutProposta = H007A5_n398ConfiguracoesLayoutProposta[0];
               A564ConfigLayoutPromissoriaClinicaEmprestimo = H007A5_A564ConfigLayoutPromissoriaClinicaEmprestimo[0];
               n564ConfigLayoutPromissoriaClinicaEmprestimo = H007A5_n564ConfigLayoutPromissoriaClinicaEmprestimo[0];
               A565ConfigLayoutPromissoriaClinicaTaxa = H007A5_A565ConfigLayoutPromissoriaClinicaTaxa[0];
               n565ConfigLayoutPromissoriaClinicaTaxa = H007A5_n565ConfigLayoutPromissoriaClinicaTaxa[0];
               A566ConfigLayoutPromissoriaPaciente = H007A5_A566ConfigLayoutPromissoriaPaciente[0];
               n566ConfigLayoutPromissoriaPaciente = H007A5_n566ConfigLayoutPromissoriaPaciente[0];
               A418ConfiguracoesLayoutContratoCorpo = H007A5_A418ConfiguracoesLayoutContratoCorpo[0];
               n418ConfiguracoesLayoutContratoCorpo = H007A5_n418ConfiguracoesLayoutContratoCorpo[0];
               A569ConfigLayoutCorpoPromissoriaPaciente = H007A5_A569ConfigLayoutCorpoPromissoriaPaciente[0];
               n569ConfigLayoutCorpoPromissoriaPaciente = H007A5_n569ConfigLayoutCorpoPromissoriaPaciente[0];
               A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = H007A5_A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo[0];
               n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = H007A5_n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo[0];
               A568ConfigLayoutCorpoPromissoriaClinicaTaxa = H007A5_A568ConfigLayoutCorpoPromissoriaClinicaTaxa[0];
               n568ConfigLayoutCorpoPromissoriaClinicaTaxa = H007A5_n568ConfigLayoutCorpoPromissoriaClinicaTaxa[0];
               A418ConfiguracoesLayoutContratoCorpo = H007A5_A418ConfiguracoesLayoutContratoCorpo[0];
               n418ConfiguracoesLayoutContratoCorpo = H007A5_n418ConfiguracoesLayoutContratoCorpo[0];
               A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = H007A5_A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo[0];
               n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = H007A5_n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo[0];
               A568ConfigLayoutCorpoPromissoriaClinicaTaxa = H007A5_A568ConfigLayoutCorpoPromissoriaClinicaTaxa[0];
               n568ConfigLayoutCorpoPromissoriaClinicaTaxa = H007A5_n568ConfigLayoutCorpoPromissoriaClinicaTaxa[0];
               A569ConfigLayoutCorpoPromissoriaPaciente = H007A5_A569ConfigLayoutCorpoPromissoriaPaciente[0];
               n569ConfigLayoutCorpoPromissoriaPaciente = H007A5_n569ConfigLayoutCorpoPromissoriaPaciente[0];
               if ( StringUtil.StrCmp(AV33PropostaContratoAssinaturaTipo, "Contrato") == 0 )
               {
                  AV8ContratoNome = StringUtil.Format( "PP_%1_%2", StringUtil.LTrimStr( (decimal)(AV32PropostaId), 9, 0), AV39PropostaPacienteClienteRazaoSocial, "", "", "", "", "", "", "");
                  AssignAttri("", false, "AV8ContratoNome", AV8ContratoNome);
                  AV9ContratoCorpo = A418ConfiguracoesLayoutContratoCorpo;
                  AssignAttri("", false, "AV9ContratoCorpo", AV9ContratoCorpo);
               }
               else if ( StringUtil.StrCmp(AV33PropostaContratoAssinaturaTipo, "Nota_promissoria") == 0 )
               {
                  AV8ContratoNome = StringUtil.Format( "Nota Promissória_%1_%2", StringUtil.LTrimStr( (decimal)(AV32PropostaId), 9, 0), AV39PropostaPacienteClienteRazaoSocial, "", "", "", "", "", "", "");
                  AssignAttri("", false, "AV8ContratoNome", AV8ContratoNome);
                  AV9ContratoCorpo = A569ConfigLayoutCorpoPromissoriaPaciente;
                  AssignAttri("", false, "AV9ContratoCorpo", AV9ContratoCorpo);
               }
               else if ( StringUtil.StrCmp(AV33PropostaContratoAssinaturaTipo, "Nota_promissoria_clinica") == 0 )
               {
                  AV8ContratoNome = StringUtil.Format( "Nota Promissória Clinica_%1_%2", StringUtil.LTrimStr( (decimal)(AV32PropostaId), 9, 0), AV39PropostaPacienteClienteRazaoSocial, "", "", "", "", "", "", "");
                  AssignAttri("", false, "AV8ContratoNome", AV8ContratoNome);
                  AV9ContratoCorpo = A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo;
                  AssignAttri("", false, "AV9ContratoCorpo", AV9ContratoCorpo);
               }
               else if ( StringUtil.StrCmp(AV33PropostaContratoAssinaturaTipo, "Nota_promissoria_clinica_taxa") == 0 )
               {
                  AV8ContratoNome = StringUtil.Format( "Nota Promissória Clinica Taxa_%1_%2", StringUtil.LTrimStr( (decimal)(AV32PropostaId), 9, 0), AV39PropostaPacienteClienteRazaoSocial, "", "", "", "", "", "", "");
                  AssignAttri("", false, "AV8ContratoNome", AV8ContratoNome);
                  AV9ContratoCorpo = A568ConfigLayoutCorpoPromissoriaClinicaTaxa;
                  AssignAttri("", false, "AV9ContratoCorpo", AV9ContratoCorpo);
               }
               pr_default.readNext(3);
            }
            pr_default.close(3);
            AV24HTML = AV9ContratoCorpo;
            new prtrocataghtml(context ).execute(  AV32PropostaId,  0, ref  AV24HTML) ;
            AV9ContratoCorpo = AV24HTML;
            AssignAttri("", false, "AV9ContratoCorpo", AV9ContratoCorpo);
            AV15SdParticipantes = new SdtSdParticipantes(context);
            AV31IsSemResponsavel = false;
            AssignAttri("", false, "AV31IsSemResponsavel", AV31IsSemResponsavel);
            GxWebStd.gx_hidden_field( context, "gxhash_vISSEMRESPONSAVEL", GetSecureSignedToken( "", AV31IsSemResponsavel, context));
            if ( ( StringUtil.StrCmp(AV33PropostaContratoAssinaturaTipo, "Contrato") == 0 ) || ( StringUtil.StrCmp(AV33PropostaContratoAssinaturaTipo, "Nota_promissoria") == 0 ) )
            {
               /* Using cursor H007A6 */
               pr_default.execute(4, new Object[] {AV35ResponsavelClienteId});
               while ( (pr_default.getStatus(4) != 101) )
               {
                  A168ClienteId = H007A6_A168ClienteId[0];
                  A172ClienteTipoPessoa = H007A6_A172ClienteTipoPessoa[0];
                  n172ClienteTipoPessoa = H007A6_n172ClienteTipoPessoa[0];
                  A436ResponsavelNome = H007A6_A436ResponsavelNome[0];
                  n436ResponsavelNome = H007A6_n436ResponsavelNome[0];
                  A447ResponsavelCPF = H007A6_A447ResponsavelCPF[0];
                  n447ResponsavelCPF = H007A6_n447ResponsavelCPF[0];
                  A456ResponsavelEmail = H007A6_A456ResponsavelEmail[0];
                  n456ResponsavelEmail = H007A6_n456ResponsavelEmail[0];
                  A170ClienteRazaoSocial = H007A6_A170ClienteRazaoSocial[0];
                  n170ClienteRazaoSocial = H007A6_n170ClienteRazaoSocial[0];
                  A169ClienteDocumento = H007A6_A169ClienteDocumento[0];
                  n169ClienteDocumento = H007A6_n169ClienteDocumento[0];
                  A201ContatoEmail = H007A6_A201ContatoEmail[0];
                  n201ContatoEmail = H007A6_n201ContatoEmail[0];
                  if ( StringUtil.StrCmp(A172ClienteTipoPessoa, "JURIDICA") == 0 )
                  {
                     AV15SdParticipantes.gxTpr_Participantenome = A436ResponsavelNome;
                     AV15SdParticipantes.gxTpr_Participantedocumento = A447ResponsavelCPF;
                     AV15SdParticipantes.gxTpr_Participanteemail = A456ResponsavelEmail;
                     AV15SdParticipantes.gxTpr_Assinaturaparticipantetipo = "Contratante";
                     AV15SdParticipantes.gxTpr_Clienteid = AV36PropostaPacienteClienteId;
                     if ( String.IsNullOrEmpty(StringUtil.RTrim( A447ResponsavelCPF)) )
                     {
                        AV31IsSemResponsavel = true;
                        AssignAttri("", false, "AV31IsSemResponsavel", AV31IsSemResponsavel);
                        GxWebStd.gx_hidden_field( context, "gxhash_vISSEMRESPONSAVEL", GetSecureSignedToken( "", AV31IsSemResponsavel, context));
                     }
                  }
                  else
                  {
                     AV15SdParticipantes.gxTpr_Participantenome = A170ClienteRazaoSocial;
                     AV15SdParticipantes.gxTpr_Participantedocumento = A169ClienteDocumento;
                     AV15SdParticipantes.gxTpr_Participanteemail = A201ContatoEmail;
                     AV15SdParticipantes.gxTpr_Assinaturaparticipantetipo = "Contratante";
                     AV15SdParticipantes.gxTpr_Clienteid = AV36PropostaPacienteClienteId;
                  }
                  AV15SdParticipantes.gxTpr_Descricao = "Paciente";
                  if ( ! AV31IsSemResponsavel )
                  {
                     AV14Array_SdParticipantes.Add(AV15SdParticipantes, 0);
                  }
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(4);
            }
            if ( ( StringUtil.StrCmp(AV33PropostaContratoAssinaturaTipo, "Contrato") == 0 ) || ( StringUtil.StrCmp(AV33PropostaContratoAssinaturaTipo, "Nota_promissoria_clinica_taxa") == 0 ) || ( StringUtil.StrCmp(AV33PropostaContratoAssinaturaTipo, "Nota_promissoria_clinica") == 0 ) )
            {
               /* Using cursor H007A7 */
               pr_default.execute(5, new Object[] {AV34ClinicaClienteId});
               while ( (pr_default.getStatus(5) != 101) )
               {
                  A133SecUserId = H007A7_A133SecUserId[0];
                  n133SecUserId = H007A7_n133SecUserId[0];
                  A226SecUserOwnerId = H007A7_A226SecUserOwnerId[0];
                  n226SecUserOwnerId = H007A7_n226SecUserOwnerId[0];
                  AV37secuserownerid = A226SecUserOwnerId;
                  AssignAttri("", false, "AV37secuserownerid", StringUtil.LTrimStr( (decimal)(AV37secuserownerid), 9, 0));
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(5);
               /* Using cursor H007A8 */
               pr_default.execute(6, new Object[] {AV37secuserownerid});
               while ( (pr_default.getStatus(6) != 101) )
               {
                  A168ClienteId = H007A8_A168ClienteId[0];
                  A436ResponsavelNome = H007A8_A436ResponsavelNome[0];
                  n436ResponsavelNome = H007A8_n436ResponsavelNome[0];
                  A447ResponsavelCPF = H007A8_A447ResponsavelCPF[0];
                  n447ResponsavelCPF = H007A8_n447ResponsavelCPF[0];
                  A456ResponsavelEmail = H007A8_A456ResponsavelEmail[0];
                  n456ResponsavelEmail = H007A8_n456ResponsavelEmail[0];
                  AV15SdParticipantes = new SdtSdParticipantes(context);
                  AV15SdParticipantes.gxTpr_Participantenome = A436ResponsavelNome;
                  AV15SdParticipantes.gxTpr_Participantedocumento = A447ResponsavelCPF;
                  AV15SdParticipantes.gxTpr_Participanteemail = A456ResponsavelEmail;
                  AV15SdParticipantes.gxTpr_Assinaturaparticipantetipo = ((StringUtil.StrCmp(AV33PropostaContratoAssinaturaTipo, "Contrato")==0) ? "Testemunha" : "Sacado");
                  AV15SdParticipantes.gxTpr_Descricao = "Clinica";
                  AV15SdParticipantes.gxTpr_Clienteid = AV36PropostaPacienteClienteId;
                  AV14Array_SdParticipantes.Add(AV15SdParticipantes, 0);
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(6);
            }
            if ( AV31IsSemResponsavel )
            {
               GXt_char2 = "Cadastre um responsável para continuar.";
               new message(context ).gxep_erro( ref  GXt_char2) ;
            }
         }
         /* Using cursor H007A9 */
         pr_default.execute(7, new Object[] {AV42WWPContext.gxTpr_Userid});
         while ( (pr_default.getStatus(7) != 101) )
         {
            A133SecUserId = H007A9_A133SecUserId[0];
            n133SecUserId = H007A9_n133SecUserId[0];
            A479ConfiguracoesTestemunhasNome = H007A9_A479ConfiguracoesTestemunhasNome[0];
            n479ConfiguracoesTestemunhasNome = H007A9_n479ConfiguracoesTestemunhasNome[0];
            A480ConfiguracoesTestemunhasDocumento = H007A9_A480ConfiguracoesTestemunhasDocumento[0];
            n480ConfiguracoesTestemunhasDocumento = H007A9_n480ConfiguracoesTestemunhasDocumento[0];
            A481ConfiguracoesTestemunhasEmail = H007A9_A481ConfiguracoesTestemunhasEmail[0];
            n481ConfiguracoesTestemunhasEmail = H007A9_n481ConfiguracoesTestemunhasEmail[0];
            AV15SdParticipantes = new SdtSdParticipantes(context);
            AV15SdParticipantes.gxTpr_Participantenome = A479ConfiguracoesTestemunhasNome;
            AV15SdParticipantes.gxTpr_Participantedocumento = A480ConfiguracoesTestemunhasDocumento;
            AV15SdParticipantes.gxTpr_Participanteemail = A481ConfiguracoesTestemunhasEmail;
            AV15SdParticipantes.gxTpr_Assinaturaparticipantetipo = "Testemunha";
            AV15SdParticipantes.gxTpr_Descricao = "Testemunha padrão";
            AV15SdParticipantes.gxTpr_Clienteid = AV36PropostaPacienteClienteId;
            AV14Array_SdParticipantes.Add(AV15SdParticipantes, 0);
            pr_default.readNext(7);
         }
         pr_default.close(7);
      }

      private void E177A2( )
      {
         /* Grid1_Load Routine */
         returnInSub = false;
         AV59GXV1 = 1;
         while ( AV59GXV1 <= AV14Array_SdParticipantes.Count )
         {
            AV15SdParticipantes = ((SdtSdParticipantes)AV14Array_SdParticipantes.Item(AV59GXV1));
            AV7Nome = AV15SdParticipantes.gxTpr_Participantenome;
            AssignAttri("", false, edtavNome_Internalname, AV7Nome);
            AV10ParticipanteDocumento = AV15SdParticipantes.gxTpr_Participantedocumento;
            AssignAttri("", false, edtavParticipantedocumento_Internalname, AV10ParticipanteDocumento);
            GxWebStd.gx_hidden_field( context, "gxhash_vPARTICIPANTEDOCUMENTO"+"_"+sGXsfl_40_idx, GetSecureSignedToken( sGXsfl_40_idx, StringUtil.RTrim( context.localUtil.Format( AV10ParticipanteDocumento, "")), context));
            AV11ParticipanteEmail = AV15SdParticipantes.gxTpr_Participanteemail;
            AssignAttri("", false, edtavParticipanteemail_Internalname, AV11ParticipanteEmail);
            AV12AssinaturaParticipanteTipo = AV15SdParticipantes.gxTpr_Assinaturaparticipantetipo;
            AssignAttri("", false, cmbavAssinaturaparticipantetipo_Internalname, AV12AssinaturaParticipanteTipo);
            cmbavAssinaturaparticipantetipo.Enabled = 1;
            AV38Desc = AV15SdParticipantes.gxTpr_Descricao;
            AssignAttri("", false, edtavDesc_Internalname, AV38Desc);
            AV13Retirar = "<i class=\"fas fa-times\"></i>";
            AssignAttri("", false, edtavRetirar_Internalname, AV13Retirar);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 40;
            }
            if ( ( subGrid1_Islastpage == 1 ) || ( subGrid1_Rows == 0 ) || ( ( GRID1_nCurrentRecord >= GRID1_nFirstRecordOnPage ) && ( GRID1_nCurrentRecord < GRID1_nFirstRecordOnPage + subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_402( ) ;
            }
            GRID1_nEOF = (short)(((GRID1_nCurrentRecord<GRID1_nFirstRecordOnPage+subGrid1_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
            subGrid1_Recordcount = (int)(GRID1_nCurrentRecord);
            if ( isFullAjaxMode( ) && ! bGXsfl_40_Refreshing )
            {
               DoAjaxLoad(40, Grid1Row);
            }
            AV59GXV1 = (int)(AV59GXV1+1);
         }
         /*  Sending Event outputs  */
         cmbavAssinaturaparticipantetipo.CurrentValue = StringUtil.RTrim( AV12AssinaturaParticipanteTipo);
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E137A2 ();
         if (returnInSub) return;
      }

      protected void E137A2( )
      {
         /* Enter Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "DVELOP_CONFIRMPANEL_ENTERContainer", "Confirm", "", new Object[] {});
      }

      protected void E127A2( )
      {
         /* Dvelop_confirmpanel_enter_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_enter_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO ACTION ENTER' */
            S132 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E147A2( )
      {
         /* 'DoAddPart' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "popupnovoparticipanteassinatura"+UrlEncode(StringUtil.LTrimStr(AV32PropostaId,9,0));
         context.PopUp(formatLink("popupnovoparticipanteassinatura") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         context.DoAjaxRefresh();
      }

      protected void E117A2( )
      {
         /* Combo_layoutcontratoid_Onoptionclicked Routine */
         returnInSub = false;
         AV43LayoutContratoId = (short)(Math.Round(NumberUtil.Val( Combo_layoutcontratoid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV43LayoutContratoId", StringUtil.LTrimStr( (decimal)(AV43LayoutContratoId), 4, 0));
         /* Using cursor H007A10 */
         pr_default.execute(8, new Object[] {AV43LayoutContratoId});
         while ( (pr_default.getStatus(8) != 101) )
         {
            A154LayoutContratoId = H007A10_A154LayoutContratoId[0];
            A157LayoutContratoCorpo = H007A10_A157LayoutContratoCorpo[0];
            n157LayoutContratoCorpo = H007A10_n157LayoutContratoCorpo[0];
            AV24HTML = A157LayoutContratoCorpo;
            new prtrocataghtml(context ).execute(  AV32PropostaId,  0, ref  AV24HTML) ;
            AV9ContratoCorpo = AV24HTML;
            AssignAttri("", false, "AV9ContratoCorpo", AV9ContratoCorpo);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(8);
         /*  Sending Event outputs  */
      }

      protected void S132( )
      {
         /* 'DO ACTION ENTER' Routine */
         returnInSub = false;
         if ( ! AV31IsSemResponsavel )
         {
            AV19GUID = Guid.NewGuid( );
            AV20File.Source = "./PublicTempStorage/"+AV19GUID.ToString()+".html";
            AV20File.Create();
            AV9ContratoCorpo = "<html><head> <meta charset=\"UTF-8\"> <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\"></head><body>" + AV9ContratoCorpo + "</body></html>";
            AssignAttri("", false, "AV9ContratoCorpo", AV9ContratoCorpo);
            AV20File.WriteAllText(AV9ContratoCorpo, "UTF8");
            AV19GUID = Guid.NewGuid( );
            AV21PdfPath = "./PublicTempStorage/" + AV19GUID.ToString() + ".pdf";
            AV22PdfFile.Source = AV21PdfPath;
            new prcriarpdffromhtml(context ).execute(  AV20File.GetAbsoluteName(),  AV22PdfFile.GetAbsoluteName(), out  AV50ErroMsg) ;
            if ( StringUtil.StrCmp(AV50ErroMsg, "PDF gerado com sucesso!") == 0 )
            {
               AV18Blob = AV22PdfFile.GetAbsoluteName();
               AV18Blob = AV22PdfFile.GetAbsoluteName();
               new prsendsignatureaux(context ).execute(  AV18Blob,  AV8ContratoNome,  AV14Array_SdParticipantes,  AV32PropostaId,  AV33PropostaContratoAssinaturaTipo, out  AV17SdErro, out  AV46PropostaContratoAssinaturaId) ;
               if ( AV17SdErro.gxTpr_Status != 200 )
               {
                  GXt_char2 = AV17SdErro.gxTpr_Msg;
                  new message(context ).gxep_erro( ref  GXt_char2) ;
                  AV17SdErro.gxTpr_Msg = GXt_char2;
               }
               else
               {
                  if ( ! ( StringUtil.StrCmp(AV33PropostaContratoAssinaturaTipo, "Documento") == 0 ) )
                  {
                     /* Using cursor H007A11 */
                     pr_default.execute(9, new Object[] {AV32PropostaId, AV33PropostaContratoAssinaturaTipo});
                     while ( (pr_default.getStatus(9) != 101) )
                     {
                        A573PropostaContratoAssinaturaTipo = H007A11_A573PropostaContratoAssinaturaTipo[0];
                        n573PropostaContratoAssinaturaTipo = H007A11_n573PropostaContratoAssinaturaTipo[0];
                        A323PropostaId = H007A11_A323PropostaId[0];
                        n323PropostaId = H007A11_n323PropostaId[0];
                        A571PropostaAssinatura = H007A11_A571PropostaAssinatura[0];
                        n571PropostaAssinatura = H007A11_n571PropostaAssinatura[0];
                        if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
                        {
                           gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
                        }
                        GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
                        GXEncryptionTmp = "wpassinaturas"+UrlEncode(StringUtil.LTrimStr(A571PropostaAssinatura,10,0));
                        CallWebObject(formatLink("wpassinaturas") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
                        context.wjLocDisableFrm = 1;
                        pr_default.readNext(9);
                     }
                     pr_default.close(9);
                  }
                  else
                  {
                     AV47ReembolsoAssinaturas = new SdtReembolsoAssinaturas(context);
                     AV47ReembolsoAssinaturas.gxTpr_Reembolsoid = AV48ReembolsoId;
                     AV47ReembolsoAssinaturas.gxTpr_Propostacontratoassinaturaid = AV46PropostaContratoAssinaturaId;
                     AV47ReembolsoAssinaturas.gxTpr_Reembolsoassinaturasnome = AV8ContratoNome;
                     AV47ReembolsoAssinaturas.gxTpr_Reembolsoassinaturasemissao = DateTimeUtil.ServerNow( context, pr_default);
                     AV47ReembolsoAssinaturas.Save();
                     if ( AV47ReembolsoAssinaturas.Success() )
                     {
                        context.CommitDataStores("wpiniciarassinaturaproposta",pr_default);
                     }
                  }
                  context.setWebReturnParms(new Object[] {});
                  context.setWebReturnParmsMetadata(new Object[] {});
                  context.wjLocDisableFrm = 1;
                  context.nUserReturn = 1;
                  returnInSub = true;
                  if (true) return;
               }
            }
            else
            {
               GXt_char2 = "Cadastre um responsável para continuar.";
               new message(context ).gxep_erro( ref  GXt_char2) ;
            }
         }
      }

      protected void S122( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ! ( ( StringUtil.StrCmp(AV33PropostaContratoAssinaturaTipo, "Documento") == 0 ) ) )
         {
            Combo_layoutcontratoid_Visible = false;
            ucCombo_layoutcontratoid.SendProperty(context, "", false, Combo_layoutcontratoid_Internalname, "Visible", StringUtil.BoolToStr( Combo_layoutcontratoid_Visible));
            divCombo_layoutcontratoid_cell_Class = "Invisible";
            AssignProp("", false, divCombo_layoutcontratoid_cell_Internalname, "Class", divCombo_layoutcontratoid_cell_Class, true);
         }
         else
         {
            Combo_layoutcontratoid_Visible = true;
            ucCombo_layoutcontratoid.SendProperty(context, "", false, Combo_layoutcontratoid_Internalname, "Visible", StringUtil.BoolToStr( Combo_layoutcontratoid_Visible));
            divCombo_layoutcontratoid_cell_Class = "col-xs-12 DataContentCellFL ExtendedComboCell";
            AssignProp("", false, divCombo_layoutcontratoid_cell_Internalname, "Class", divCombo_layoutcontratoid_cell_Class, true);
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOLAYOUTCONTRATOID' Routine */
         returnInSub = false;
         /* Using cursor H007A12 */
         pr_default.execute(10);
         while ( (pr_default.getStatus(10) != 101) )
         {
            A906LayoutContratoTipo = H007A12_A906LayoutContratoTipo[0];
            n906LayoutContratoTipo = H007A12_n906LayoutContratoTipo[0];
            A156LayoutContratoStatus = H007A12_A156LayoutContratoStatus[0];
            n156LayoutContratoStatus = H007A12_n156LayoutContratoStatus[0];
            A154LayoutContratoId = H007A12_A154LayoutContratoId[0];
            A155LayoutContratoDescricao = H007A12_A155LayoutContratoDescricao[0];
            n155LayoutContratoDescricao = H007A12_n155LayoutContratoDescricao[0];
            AV45Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV45Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A154LayoutContratoId), 4, 0));
            AV45Combo_DataItem.gxTpr_Title = A155LayoutContratoDescricao;
            AV44LayoutContratoId_Data.Add(AV45Combo_DataItem, 0);
            pr_default.readNext(10);
         }
         pr_default.close(10);
         Combo_layoutcontratoid_Selectedvalue_set = ((0==AV43LayoutContratoId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV43LayoutContratoId), 4, 0)));
         ucCombo_layoutcontratoid.SendProperty(context, "", false, Combo_layoutcontratoid_Internalname, "SelectedValue_set", Combo_layoutcontratoid_Selectedvalue_set);
      }

      protected void E187A2( )
      {
         /* Retirar_Click Routine */
         returnInSub = false;
         AV16index = 0;
         AV64GXV3 = 1;
         while ( AV64GXV3 <= AV14Array_SdParticipantes.Count )
         {
            AV15SdParticipantes = ((SdtSdParticipantes)AV14Array_SdParticipantes.Item(AV64GXV3));
            AV16index = (short)(AV16index+1);
            if ( ( StringUtil.StrCmp(AV15SdParticipantes.gxTpr_Participantedocumento, AV10ParticipanteDocumento) == 0 ) && ( StringUtil.StrCmp(AV15SdParticipantes.gxTpr_Assinaturaparticipantetipo, AV12AssinaturaParticipanteTipo) == 0 ) )
            {
               AV14Array_SdParticipantes.RemoveItem(AV16index);
               context.DoAjaxRefresh();
               if (true) break;
            }
            AV64GXV3 = (int)(AV64GXV3+1);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14Array_SdParticipantes", AV14Array_SdParticipantes);
      }

      protected void E157A2( )
      {
         /* General\GlobalEvents_Wpiniciarassinatura_novoparticipante Routine */
         returnInSub = false;
         AV30IsExists = false;
         AV65GXV4 = 1;
         while ( AV65GXV4 <= AV14Array_SdParticipantes.Count )
         {
            AV15SdParticipantes = ((SdtSdParticipantes)AV14Array_SdParticipantes.Item(AV65GXV4));
            if ( ( StringUtil.StrCmp(AV15SdParticipantes.gxTpr_Participantedocumento, AV29GlobalCPF) == 0 ) || ( StringUtil.StrCmp(AV15SdParticipantes.gxTpr_Participanteemail, AV26GlobalEmail) == 0 ) )
            {
               AV30IsExists = true;
               if (true) break;
            }
            AV65GXV4 = (int)(AV65GXV4+1);
         }
         if ( ! AV30IsExists )
         {
            AV15SdParticipantes = new SdtSdParticipantes(context);
            AV15SdParticipantes.gxTpr_Participantedocumento = AV29GlobalCPF;
            AV15SdParticipantes.gxTpr_Participanteemail = AV26GlobalEmail;
            AV15SdParticipantes.gxTpr_Assinaturaparticipantetipo = AV27GlobalAssinaturaParticipanteTipo;
            AV15SdParticipantes.gxTpr_Participantenome = AV28GlobalNome;
            AV15SdParticipantes.gxTpr_Clienteid = AV6Contrato.gxTpr_Contratoclienteid;
            AV14Array_SdParticipantes.Add(AV15SdParticipantes, 0);
         }
         else
         {
            GXt_char2 = "Já existe esse participante no contrato";
            new message(context ).gxep_erro( ref  GXt_char2) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14Array_SdParticipantes", AV14Array_SdParticipantes);
      }

      protected void wb_table1_58_7A2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_enter_Internalname, tblTabledvelop_confirmpanel_enter_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_enter.SetProperty("Title", Dvelop_confirmpanel_enter_Title);
            ucDvelop_confirmpanel_enter.SetProperty("ConfirmationText", Dvelop_confirmpanel_enter_Confirmationtext);
            ucDvelop_confirmpanel_enter.SetProperty("YesButtonCaption", Dvelop_confirmpanel_enter_Yesbuttoncaption);
            ucDvelop_confirmpanel_enter.SetProperty("NoButtonCaption", Dvelop_confirmpanel_enter_Nobuttoncaption);
            ucDvelop_confirmpanel_enter.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_enter_Cancelbuttoncaption);
            ucDvelop_confirmpanel_enter.SetProperty("YesButtonPosition", Dvelop_confirmpanel_enter_Yesbuttonposition);
            ucDvelop_confirmpanel_enter.SetProperty("ConfirmType", Dvelop_confirmpanel_enter_Confirmtype);
            ucDvelop_confirmpanel_enter.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_enter_Internalname, "DVELOP_CONFIRMPANEL_ENTERContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVELOP_CONFIRMPANEL_ENTERContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_58_7A2e( true) ;
         }
         else
         {
            wb_table1_58_7A2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV32PropostaId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV32PropostaId", StringUtil.LTrimStr( (decimal)(AV32PropostaId), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV32PropostaId), "ZZZZZZZZ9"), context));
         AV33PropostaContratoAssinaturaTipo = (string)getParm(obj,1);
         AssignAttri("", false, "AV33PropostaContratoAssinaturaTipo", AV33PropostaContratoAssinaturaTipo);
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTACONTRATOASSINATURATIPO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV33PropostaContratoAssinaturaTipo, "")), context));
         AV48ReembolsoId = Convert.ToInt32(getParm(obj,2));
         AssignAttri("", false, "AV48ReembolsoId", StringUtil.LTrimStr( (decimal)(AV48ReembolsoId), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV48ReembolsoId), "ZZZZZZZZ9"), context));
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
         PA7A2( ) ;
         WS7A2( ) ;
         WE7A2( ) ;
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
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019265821", true, true);
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
         context.AddJavascriptSource("wpiniciarassinaturaproposta.js", "?202561019265822", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_402( )
      {
         edtavRetirar_Internalname = "vRETIRAR_"+sGXsfl_40_idx;
         edtavNome_Internalname = "vNOME_"+sGXsfl_40_idx;
         edtavParticipantedocumento_Internalname = "vPARTICIPANTEDOCUMENTO_"+sGXsfl_40_idx;
         edtavParticipanteemail_Internalname = "vPARTICIPANTEEMAIL_"+sGXsfl_40_idx;
         cmbavAssinaturaparticipantetipo_Internalname = "vASSINATURAPARTICIPANTETIPO_"+sGXsfl_40_idx;
         edtavDesc_Internalname = "vDESC_"+sGXsfl_40_idx;
      }

      protected void SubsflControlProps_fel_402( )
      {
         edtavRetirar_Internalname = "vRETIRAR_"+sGXsfl_40_fel_idx;
         edtavNome_Internalname = "vNOME_"+sGXsfl_40_fel_idx;
         edtavParticipantedocumento_Internalname = "vPARTICIPANTEDOCUMENTO_"+sGXsfl_40_fel_idx;
         edtavParticipanteemail_Internalname = "vPARTICIPANTEEMAIL_"+sGXsfl_40_fel_idx;
         cmbavAssinaturaparticipantetipo_Internalname = "vASSINATURAPARTICIPANTETIPO_"+sGXsfl_40_fel_idx;
         edtavDesc_Internalname = "vDESC_"+sGXsfl_40_fel_idx;
      }

      protected void sendrow_402( )
      {
         sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
         SubsflControlProps_402( ) ;
         WB7A0( ) ;
         if ( ( subGrid1_Rows * 1 == 0 ) || ( nGXsfl_40_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
         {
            Grid1Row = GXWebRow.GetNew(context,Grid1Container);
            if ( subGrid1_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid1_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
            else if ( subGrid1_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid1_Backstyle = 0;
               subGrid1_Backcolor = subGrid1_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Uniform";
               }
            }
            else if ( subGrid1_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
               subGrid1_Backcolor = (int)(0x0);
            }
            else if ( subGrid1_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( ((int)((nGXsfl_40_idx) % (2))) == 0 )
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Even";
                  }
               }
               else
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Odd";
                  }
               }
            }
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithBorderColor WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_40_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'" + sGXsfl_40_idx + "',40)\"";
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavRetirar_Internalname,StringUtil.RTrim( AV13Retirar),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"","'"+""+"'"+",false,"+"'"+"EVRETIRAR.CLICK."+sGXsfl_40_idx+"'",(string)"",(string)"",(string)"Retirar",(string)"",(string)edtavRetirar_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavRetirar_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)40,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'" + sGXsfl_40_idx + "',40)\"";
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavNome_Internalname,(string)AV7Nome,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavNome_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)40,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_40_idx + "',40)\"";
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavParticipantedocumento_Internalname,(string)AV10ParticipanteDocumento,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavParticipantedocumento_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavParticipantedocumento_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)40,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'" + sGXsfl_40_idx + "',40)\"";
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavParticipanteemail_Internalname,(string)AV11ParticipanteEmail,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavParticipanteemail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavParticipanteemail_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)40,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_40_idx + "',40)\"";
            GXCCtl = "vASSINATURAPARTICIPANTETIPO_" + sGXsfl_40_idx;
            cmbavAssinaturaparticipantetipo.Name = GXCCtl;
            cmbavAssinaturaparticipantetipo.WebTags = "";
            cmbavAssinaturaparticipantetipo.addItem("Contratado", "Contratada", 0);
            cmbavAssinaturaparticipantetipo.addItem("Contratante", "Contratante", 0);
            cmbavAssinaturaparticipantetipo.addItem("Testemunha", "Testemunha", 0);
            cmbavAssinaturaparticipantetipo.addItem("Sacado", "Sacado", 0);
            if ( cmbavAssinaturaparticipantetipo.ItemCount > 0 )
            {
               AV12AssinaturaParticipanteTipo = cmbavAssinaturaparticipantetipo.getValidValue(AV12AssinaturaParticipanteTipo);
               AssignAttri("", false, cmbavAssinaturaparticipantetipo_Internalname, AV12AssinaturaParticipanteTipo);
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavAssinaturaparticipantetipo,(string)cmbavAssinaturaparticipantetipo_Internalname,StringUtil.RTrim( AV12AssinaturaParticipanteTipo),(short)1,(string)cmbavAssinaturaparticipantetipo_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,cmbavAssinaturaparticipantetipo.Enabled,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"",(string)"",(bool)true,(short)0});
            cmbavAssinaturaparticipantetipo.CurrentValue = StringUtil.RTrim( AV12AssinaturaParticipanteTipo);
            AssignProp("", false, cmbavAssinaturaparticipantetipo_Internalname, "Values", (string)(cmbavAssinaturaparticipantetipo.ToJavascriptSource()), !bGXsfl_40_Refreshing);
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDesc_Internalname,(string)AV38Desc,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDesc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavDesc_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)40,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes7A2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_40_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_40_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_40_idx+1);
            sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
            SubsflControlProps_402( ) ;
         }
         /* End function sendrow_402 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vASSINATURAPARTICIPANTETIPO_" + sGXsfl_40_idx;
         cmbavAssinaturaparticipantetipo.Name = GXCCtl;
         cmbavAssinaturaparticipantetipo.WebTags = "";
         cmbavAssinaturaparticipantetipo.addItem("Contratado", "Contratada", 0);
         cmbavAssinaturaparticipantetipo.addItem("Contratante", "Contratante", 0);
         cmbavAssinaturaparticipantetipo.addItem("Testemunha", "Testemunha", 0);
         cmbavAssinaturaparticipantetipo.addItem("Sacado", "Sacado", 0);
         if ( cmbavAssinaturaparticipantetipo.ItemCount > 0 )
         {
            AV12AssinaturaParticipanteTipo = cmbavAssinaturaparticipantetipo.getValidValue(AV12AssinaturaParticipanteTipo);
            AssignAttri("", false, cmbavAssinaturaparticipantetipo_Internalname, AV12AssinaturaParticipanteTipo);
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl40( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"40\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "GridWithBorderColor WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid1_Backcolorstyle == 0 )
            {
               subGrid1_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid1_Class) > 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Title";
               }
            }
            else
            {
               subGrid1_Titlebackstyle = 1;
               if ( subGrid1_Backcolorstyle == 1 )
               {
                  subGrid1_Titlebackcolor = subGrid1_Allbackcolor;
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Nome") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "CPF") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "E-mail") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Tipo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Grid1Container.AddObjectProperty("GridName", "Grid1");
         }
         else
         {
            Grid1Container.AddObjectProperty("GridName", "Grid1");
            Grid1Container.AddObjectProperty("Header", subGrid1_Header);
            Grid1Container.AddObjectProperty("Class", "GridWithBorderColor WorkWith");
            Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("CmpContext", "");
            Grid1Container.AddObjectProperty("InMasterPage", "false");
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV13Retirar)));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavRetirar_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( AV7Nome));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNome_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( AV10ParticipanteDocumento));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavParticipantedocumento_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( AV11ParticipanteEmail));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavParticipanteemail_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( AV12AssinaturaParticipanteTipo));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavAssinaturaparticipantetipo.Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( AV38Desc));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDesc_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectedindex), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowselection), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectioncolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowhovering), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Hoveringcolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowcollapsing), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblTextblockcombo_layoutcontratoid_Internalname = "TEXTBLOCKCOMBO_LAYOUTCONTRATOID";
         Combo_layoutcontratoid_Internalname = "COMBO_LAYOUTCONTRATOID";
         divTablesplittedlayoutcontratoid_Internalname = "TABLESPLITTEDLAYOUTCONTRATOID";
         divCombo_layoutcontratoid_cell_Internalname = "COMBO_LAYOUTCONTRATOID_CELL";
         edtavContratonome_Internalname = "vCONTRATONOME";
         Contratocorpo_Internalname = "CONTRATOCORPO";
         divTablecontrato_Internalname = "TABLECONTRATO";
         bttBtnaddpart_Internalname = "BTNADDPART";
         edtavRetirar_Internalname = "vRETIRAR";
         edtavNome_Internalname = "vNOME";
         edtavParticipantedocumento_Internalname = "vPARTICIPANTEDOCUMENTO";
         edtavParticipanteemail_Internalname = "vPARTICIPANTEEMAIL";
         cmbavAssinaturaparticipantetipo_Internalname = "vASSINATURAPARTICIPANTETIPO";
         edtavDesc_Internalname = "vDESC";
         divTableparticipantes_Internalname = "TABLEPARTICIPANTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         edtavLayoutcontratoid_Internalname = "vLAYOUTCONTRATOID";
         Dvelop_confirmpanel_enter_Internalname = "DVELOP_CONFIRMPANEL_ENTER";
         tblTabledvelop_confirmpanel_enter_Internalname = "TABLEDVELOP_CONFIRMPANEL_ENTER";
         Grid1_empowerer_Internalname = "GRID1_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         subGrid1_Header = "";
         edtavDesc_Jsonclick = "";
         edtavDesc_Enabled = 1;
         cmbavAssinaturaparticipantetipo_Jsonclick = "";
         cmbavAssinaturaparticipantetipo.Enabled = 1;
         edtavParticipanteemail_Jsonclick = "";
         edtavParticipanteemail_Enabled = 1;
         edtavParticipantedocumento_Jsonclick = "";
         edtavParticipantedocumento_Enabled = 1;
         edtavNome_Jsonclick = "";
         edtavNome_Enabled = 1;
         edtavRetirar_Jsonclick = "";
         edtavRetirar_Enabled = 1;
         subGrid1_Class = "GridWithBorderColor WorkWith";
         subGrid1_Backcolorstyle = 0;
         edtavLayoutcontratoid_Jsonclick = "";
         edtavLayoutcontratoid_Visible = 1;
         Contratocorpo_Enabled = Convert.ToBoolean( 1);
         edtavContratonome_Jsonclick = "";
         edtavContratonome_Enabled = 1;
         divCombo_layoutcontratoid_cell_Class = "col-xs-12";
         Dvelop_confirmpanel_enter_Confirmtype = "1";
         Dvelop_confirmpanel_enter_Yesbuttonposition = "left";
         Dvelop_confirmpanel_enter_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_enter_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_enter_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_enter_Confirmationtext = "Deseja enviar essa contrato para assinatura?";
         Dvelop_confirmpanel_enter_Title = "Assinatura";
         Contratocorpo_Captionposition = "Left";
         Contratocorpo_Captionstyle = "";
         Contratocorpo_Captionclass = " AttributeLabel";
         Combo_layoutcontratoid_Emptyitem = Convert.ToBoolean( 0);
         Combo_layoutcontratoid_Visible = Convert.ToBoolean( -1);
         Combo_layoutcontratoid_Cls = "ExtendedCombo AttributeFL";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Assinatura";
         subGrid1_Rows = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID1_nFirstRecordOnPage","type":"int"},{"av":"GRID1_nEOF","type":"int"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV14Array_SdParticipantes","fld":"vARRAY_SDPARTICIPANTES","type":""},{"av":"AV31IsSemResponsavel","fld":"vISSEMRESPONSAVEL","hsh":true,"type":"boolean"},{"av":"AV32PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV33PropostaContratoAssinaturaTipo","fld":"vPROPOSTACONTRATOASSINATURATIPO","hsh":true,"type":"svchar"},{"av":"AV48ReembolsoId","fld":"vREEMBOLSOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV6Contrato","fld":"vCONTRATO","hsh":true,"type":""}]}""");
         setEventMetadata("GRID1.LOAD","""{"handler":"E177A2","iparms":[{"av":"AV14Array_SdParticipantes","fld":"vARRAY_SDPARTICIPANTES","type":""}]""");
         setEventMetadata("GRID1.LOAD",""","oparms":[{"av":"AV7Nome","fld":"vNOME","type":"svchar"},{"av":"AV10ParticipanteDocumento","fld":"vPARTICIPANTEDOCUMENTO","hsh":true,"type":"svchar"},{"av":"AV11ParticipanteEmail","fld":"vPARTICIPANTEEMAIL","type":"svchar"},{"av":"cmbavAssinaturaparticipantetipo"},{"av":"AV12AssinaturaParticipanteTipo","fld":"vASSINATURAPARTICIPANTETIPO","type":"svchar"},{"av":"AV38Desc","fld":"vDESC","type":"svchar"},{"av":"AV13Retirar","fld":"vRETIRAR","type":"char"}]}""");
         setEventMetadata("ENTER","""{"handler":"E137A2","iparms":[]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_ENTER.CLOSE","""{"handler":"E127A2","iparms":[{"av":"Dvelop_confirmpanel_enter_Result","ctrl":"DVELOP_CONFIRMPANEL_ENTER","prop":"Result"},{"av":"AV31IsSemResponsavel","fld":"vISSEMRESPONSAVEL","hsh":true,"type":"boolean"},{"av":"AV9ContratoCorpo","fld":"vCONTRATOCORPO","type":"vchar"},{"av":"AV8ContratoNome","fld":"vCONTRATONOME","type":"svchar"},{"av":"AV14Array_SdParticipantes","fld":"vARRAY_SDPARTICIPANTES","type":""},{"av":"AV32PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV33PropostaContratoAssinaturaTipo","fld":"vPROPOSTACONTRATOASSINATURATIPO","hsh":true,"type":"svchar"},{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A573PropostaContratoAssinaturaTipo","fld":"PROPOSTACONTRATOASSINATURATIPO","type":"svchar"},{"av":"A571PropostaAssinatura","fld":"PROPOSTAASSINATURA","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV48ReembolsoId","fld":"vREEMBOLSOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_ENTER.CLOSE",""","oparms":[{"av":"AV9ContratoCorpo","fld":"vCONTRATOCORPO","type":"vchar"}]}""");
         setEventMetadata("'DOADDPART'","""{"handler":"E147A2","iparms":[{"av":"GRID1_nFirstRecordOnPage","type":"int"},{"av":"GRID1_nEOF","type":"int"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV14Array_SdParticipantes","fld":"vARRAY_SDPARTICIPANTES","type":""},{"av":"AV31IsSemResponsavel","fld":"vISSEMRESPONSAVEL","hsh":true,"type":"boolean"},{"av":"AV32PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV33PropostaContratoAssinaturaTipo","fld":"vPROPOSTACONTRATOASSINATURATIPO","hsh":true,"type":"svchar"},{"av":"AV48ReembolsoId","fld":"vREEMBOLSOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV6Contrato","fld":"vCONTRATO","hsh":true,"type":""}]}""");
         setEventMetadata("COMBO_LAYOUTCONTRATOID.ONOPTIONCLICKED","""{"handler":"E117A2","iparms":[{"av":"Combo_layoutcontratoid_Selectedvalue_get","ctrl":"COMBO_LAYOUTCONTRATOID","prop":"SelectedValue_get"},{"av":"A154LayoutContratoId","fld":"LAYOUTCONTRATOID","pic":"ZZZ9","type":"int"},{"av":"A157LayoutContratoCorpo","fld":"LAYOUTCONTRATOCORPO","type":"vchar"},{"av":"AV32PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("COMBO_LAYOUTCONTRATOID.ONOPTIONCLICKED",""","oparms":[{"av":"AV43LayoutContratoId","fld":"vLAYOUTCONTRATOID","pic":"ZZZ9","type":"int"},{"av":"AV9ContratoCorpo","fld":"vCONTRATOCORPO","type":"vchar"}]}""");
         setEventMetadata("VRETIRAR.CLICK","""{"handler":"E187A2","iparms":[{"av":"GRID1_nFirstRecordOnPage","type":"int"},{"av":"GRID1_nEOF","type":"int"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV14Array_SdParticipantes","fld":"vARRAY_SDPARTICIPANTES","type":""},{"av":"AV31IsSemResponsavel","fld":"vISSEMRESPONSAVEL","hsh":true,"type":"boolean"},{"av":"AV32PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV33PropostaContratoAssinaturaTipo","fld":"vPROPOSTACONTRATOASSINATURATIPO","hsh":true,"type":"svchar"},{"av":"AV48ReembolsoId","fld":"vREEMBOLSOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV6Contrato","fld":"vCONTRATO","hsh":true,"type":""},{"av":"AV10ParticipanteDocumento","fld":"vPARTICIPANTEDOCUMENTO","hsh":true,"type":"svchar"},{"av":"cmbavAssinaturaparticipantetipo"},{"av":"AV12AssinaturaParticipanteTipo","fld":"vASSINATURAPARTICIPANTETIPO","type":"svchar"}]""");
         setEventMetadata("VRETIRAR.CLICK",""","oparms":[{"av":"AV14Array_SdParticipantes","fld":"vARRAY_SDPARTICIPANTES","type":""}]}""");
         setEventMetadata("GLOBALEVENTS.WPINICIARASSINATURA_NOVOPARTICIPANTE","""{"handler":"E157A2","iparms":[{"av":"AV27GlobalAssinaturaParticipanteTipo","fld":"vGLOBALASSINATURAPARTICIPANTETIPO","type":"svchar"},{"av":"AV26GlobalEmail","fld":"vGLOBALEMAIL","type":"svchar"},{"av":"AV29GlobalCPF","fld":"vGLOBALCPF","type":"svchar"},{"av":"AV28GlobalNome","fld":"vGLOBALNOME","type":"svchar"},{"av":"AV14Array_SdParticipantes","fld":"vARRAY_SDPARTICIPANTES","type":""},{"av":"AV6Contrato","fld":"vCONTRATO","hsh":true,"type":""}]""");
         setEventMetadata("GLOBALEVENTS.WPINICIARASSINATURA_NOVOPARTICIPANTE",""","oparms":[{"av":"AV14Array_SdParticipantes","fld":"vARRAY_SDPARTICIPANTES","type":""}]}""");
         setEventMetadata("GRID1_FIRSTPAGE","""{"handler":"subgrid1_firstpage","iparms":[{"av":"GRID1_nFirstRecordOnPage","type":"int"},{"av":"GRID1_nEOF","type":"int"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV14Array_SdParticipantes","fld":"vARRAY_SDPARTICIPANTES","type":""},{"av":"AV31IsSemResponsavel","fld":"vISSEMRESPONSAVEL","hsh":true,"type":"boolean"},{"av":"AV32PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV33PropostaContratoAssinaturaTipo","fld":"vPROPOSTACONTRATOASSINATURATIPO","hsh":true,"type":"svchar"},{"av":"AV48ReembolsoId","fld":"vREEMBOLSOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV6Contrato","fld":"vCONTRATO","hsh":true,"type":""}]}""");
         setEventMetadata("GRID1_PREVPAGE","""{"handler":"subgrid1_previouspage","iparms":[{"av":"GRID1_nFirstRecordOnPage","type":"int"},{"av":"GRID1_nEOF","type":"int"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV14Array_SdParticipantes","fld":"vARRAY_SDPARTICIPANTES","type":""},{"av":"AV31IsSemResponsavel","fld":"vISSEMRESPONSAVEL","hsh":true,"type":"boolean"},{"av":"AV32PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV33PropostaContratoAssinaturaTipo","fld":"vPROPOSTACONTRATOASSINATURATIPO","hsh":true,"type":"svchar"},{"av":"AV48ReembolsoId","fld":"vREEMBOLSOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV6Contrato","fld":"vCONTRATO","hsh":true,"type":""}]}""");
         setEventMetadata("GRID1_NEXTPAGE","""{"handler":"subgrid1_nextpage","iparms":[{"av":"GRID1_nFirstRecordOnPage","type":"int"},{"av":"GRID1_nEOF","type":"int"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV14Array_SdParticipantes","fld":"vARRAY_SDPARTICIPANTES","type":""},{"av":"AV31IsSemResponsavel","fld":"vISSEMRESPONSAVEL","hsh":true,"type":"boolean"},{"av":"AV32PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV33PropostaContratoAssinaturaTipo","fld":"vPROPOSTACONTRATOASSINATURATIPO","hsh":true,"type":"svchar"},{"av":"AV48ReembolsoId","fld":"vREEMBOLSOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV6Contrato","fld":"vCONTRATO","hsh":true,"type":""}]}""");
         setEventMetadata("GRID1_LASTPAGE","""{"handler":"subgrid1_lastpage","iparms":[{"av":"GRID1_nFirstRecordOnPage","type":"int"},{"av":"GRID1_nEOF","type":"int"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV14Array_SdParticipantes","fld":"vARRAY_SDPARTICIPANTES","type":""},{"av":"AV31IsSemResponsavel","fld":"vISSEMRESPONSAVEL","hsh":true,"type":"boolean"},{"av":"AV32PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV33PropostaContratoAssinaturaTipo","fld":"vPROPOSTACONTRATOASSINATURATIPO","hsh":true,"type":"svchar"},{"av":"AV48ReembolsoId","fld":"vREEMBOLSOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV6Contrato","fld":"vCONTRATO","hsh":true,"type":""},{"av":"subGrid1_Recordcount","type":"int"}]}""");
         setEventMetadata("VALIDV_LAYOUTCONTRATOID","""{"handler":"Validv_Layoutcontratoid","iparms":[]}""");
         setEventMetadata("VALIDV_PARTICIPANTEEMAIL","""{"handler":"Validv_Participanteemail","iparms":[]}""");
         setEventMetadata("VALIDV_ASSINATURAPARTICIPANTETIPO","""{"handler":"Validv_Assinaturaparticipantetipo","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Desc","iparms":[]}""");
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
         wcpOAV33PropostaContratoAssinaturaTipo = "";
         Dvelop_confirmpanel_enter_Result = "";
         Combo_layoutcontratoid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV14Array_SdParticipantes = new GXBaseCollection<SdtSdParticipantes>( context, "SdParticipantes", "Factory21");
         AV6Contrato = new SdtContrato(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV44LayoutContratoId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV9ContratoCorpo = "";
         A573PropostaContratoAssinaturaTipo = "";
         A157LayoutContratoCorpo = "";
         AV27GlobalAssinaturaParticipanteTipo = "";
         AV26GlobalEmail = "";
         AV29GlobalCPF = "";
         AV28GlobalNome = "";
         AV15SdParticipantes = new SdtSdParticipantes(context);
         Combo_layoutcontratoid_Selectedvalue_set = "";
         Grid1_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         lblTextblockcombo_layoutcontratoid_Jsonclick = "";
         ucCombo_layoutcontratoid = new GXUserControl();
         Combo_layoutcontratoid_Caption = "";
         TempTags = "";
         AV8ContratoNome = "";
         ucContratocorpo = new GXUserControl();
         bttBtnaddpart_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         ucGrid1_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV13Retirar = "";
         AV7Nome = "";
         AV10ParticipanteDocumento = "";
         AV11ParticipanteEmail = "";
         AV12AssinaturaParticipanteTipo = "";
         AV38Desc = "";
         GXDecQS = "";
         AV42WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtWWPContext1 = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         H007A2_A572PropostaContratoAssinaturaId = new int[1] ;
         H007A2_A573PropostaContratoAssinaturaTipo = new string[] {""} ;
         H007A2_n573PropostaContratoAssinaturaTipo = new bool[] {false} ;
         H007A2_A323PropostaId = new int[1] ;
         H007A2_n323PropostaId = new bool[] {false} ;
         H007A3_A323PropostaId = new int[1] ;
         H007A3_n323PropostaId = new bool[] {false} ;
         H007A3_A504PropostaPacienteClienteId = new int[1] ;
         H007A3_n504PropostaPacienteClienteId = new bool[] {false} ;
         H007A3_A553PropostaResponsavelId = new int[1] ;
         H007A3_n553PropostaResponsavelId = new bool[] {false} ;
         H007A3_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         H007A3_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         H007A3_A328PropostaCratedBy = new short[1] ;
         H007A3_n328PropostaCratedBy = new bool[] {false} ;
         A505PropostaPacienteClienteRazaoSocial = "";
         AV39PropostaPacienteClienteRazaoSocial = "";
         H007A4_A249EmpresaId = new int[1] ;
         H007A4_A773EmpresaUtilizaRepresentanteAssinatura = new bool[] {false} ;
         H007A4_n773EmpresaUtilizaRepresentanteAssinatura = new bool[] {false} ;
         H007A4_A771EmpresaRepresentanteNome = new string[] {""} ;
         H007A4_n771EmpresaRepresentanteNome = new bool[] {false} ;
         H007A4_A770EmpresaRepresentanteCPF = new string[] {""} ;
         H007A4_n770EmpresaRepresentanteCPF = new bool[] {false} ;
         H007A4_A772EmpresaRepresentanteEmail = new string[] {""} ;
         H007A4_n772EmpresaRepresentanteEmail = new bool[] {false} ;
         A771EmpresaRepresentanteNome = "";
         A770EmpresaRepresentanteCPF = "";
         A772EmpresaRepresentanteEmail = "";
         H007A5_A299ConfiguracoesId = new int[1] ;
         H007A5_A398ConfiguracoesLayoutProposta = new short[1] ;
         H007A5_n398ConfiguracoesLayoutProposta = new bool[] {false} ;
         H007A5_A564ConfigLayoutPromissoriaClinicaEmprestimo = new short[1] ;
         H007A5_n564ConfigLayoutPromissoriaClinicaEmprestimo = new bool[] {false} ;
         H007A5_A565ConfigLayoutPromissoriaClinicaTaxa = new short[1] ;
         H007A5_n565ConfigLayoutPromissoriaClinicaTaxa = new bool[] {false} ;
         H007A5_A566ConfigLayoutPromissoriaPaciente = new short[1] ;
         H007A5_n566ConfigLayoutPromissoriaPaciente = new bool[] {false} ;
         H007A5_A418ConfiguracoesLayoutContratoCorpo = new string[] {""} ;
         H007A5_n418ConfiguracoesLayoutContratoCorpo = new bool[] {false} ;
         H007A5_A569ConfigLayoutCorpoPromissoriaPaciente = new string[] {""} ;
         H007A5_n569ConfigLayoutCorpoPromissoriaPaciente = new bool[] {false} ;
         H007A5_A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = new string[] {""} ;
         H007A5_n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = new bool[] {false} ;
         H007A5_A568ConfigLayoutCorpoPromissoriaClinicaTaxa = new string[] {""} ;
         H007A5_n568ConfigLayoutCorpoPromissoriaClinicaTaxa = new bool[] {false} ;
         A418ConfiguracoesLayoutContratoCorpo = "";
         A569ConfigLayoutCorpoPromissoriaPaciente = "";
         A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = "";
         A568ConfigLayoutCorpoPromissoriaClinicaTaxa = "";
         AV24HTML = "";
         H007A6_A168ClienteId = new int[1] ;
         H007A6_A172ClienteTipoPessoa = new string[] {""} ;
         H007A6_n172ClienteTipoPessoa = new bool[] {false} ;
         H007A6_A436ResponsavelNome = new string[] {""} ;
         H007A6_n436ResponsavelNome = new bool[] {false} ;
         H007A6_A447ResponsavelCPF = new string[] {""} ;
         H007A6_n447ResponsavelCPF = new bool[] {false} ;
         H007A6_A456ResponsavelEmail = new string[] {""} ;
         H007A6_n456ResponsavelEmail = new bool[] {false} ;
         H007A6_A170ClienteRazaoSocial = new string[] {""} ;
         H007A6_n170ClienteRazaoSocial = new bool[] {false} ;
         H007A6_A169ClienteDocumento = new string[] {""} ;
         H007A6_n169ClienteDocumento = new bool[] {false} ;
         H007A6_A201ContatoEmail = new string[] {""} ;
         H007A6_n201ContatoEmail = new bool[] {false} ;
         A172ClienteTipoPessoa = "";
         A436ResponsavelNome = "";
         A447ResponsavelCPF = "";
         A456ResponsavelEmail = "";
         A170ClienteRazaoSocial = "";
         A169ClienteDocumento = "";
         A201ContatoEmail = "";
         H007A7_A133SecUserId = new short[1] ;
         H007A7_n133SecUserId = new bool[] {false} ;
         H007A7_A226SecUserOwnerId = new int[1] ;
         H007A7_n226SecUserOwnerId = new bool[] {false} ;
         H007A8_A168ClienteId = new int[1] ;
         H007A8_A436ResponsavelNome = new string[] {""} ;
         H007A8_n436ResponsavelNome = new bool[] {false} ;
         H007A8_A447ResponsavelCPF = new string[] {""} ;
         H007A8_n447ResponsavelCPF = new bool[] {false} ;
         H007A8_A456ResponsavelEmail = new string[] {""} ;
         H007A8_n456ResponsavelEmail = new bool[] {false} ;
         H007A9_A478ConfiguracoesTestemunhasId = new int[1] ;
         H007A9_A133SecUserId = new short[1] ;
         H007A9_n133SecUserId = new bool[] {false} ;
         H007A9_A479ConfiguracoesTestemunhasNome = new string[] {""} ;
         H007A9_n479ConfiguracoesTestemunhasNome = new bool[] {false} ;
         H007A9_A480ConfiguracoesTestemunhasDocumento = new string[] {""} ;
         H007A9_n480ConfiguracoesTestemunhasDocumento = new bool[] {false} ;
         H007A9_A481ConfiguracoesTestemunhasEmail = new string[] {""} ;
         H007A9_n481ConfiguracoesTestemunhasEmail = new bool[] {false} ;
         A479ConfiguracoesTestemunhasNome = "";
         A480ConfiguracoesTestemunhasDocumento = "";
         A481ConfiguracoesTestemunhasEmail = "";
         Grid1Row = new GXWebRow();
         H007A10_A154LayoutContratoId = new short[1] ;
         H007A10_A157LayoutContratoCorpo = new string[] {""} ;
         H007A10_n157LayoutContratoCorpo = new bool[] {false} ;
         AV19GUID = Guid.Empty;
         AV20File = new GxFile(context.GetPhysicalPath());
         AV21PdfPath = "";
         AV22PdfFile = new GxFile(context.GetPhysicalPath());
         AV50ErroMsg = "";
         AV18Blob = "";
         AV17SdErro = new SdtSdErro(context);
         H007A11_A572PropostaContratoAssinaturaId = new int[1] ;
         H007A11_A573PropostaContratoAssinaturaTipo = new string[] {""} ;
         H007A11_n573PropostaContratoAssinaturaTipo = new bool[] {false} ;
         H007A11_A323PropostaId = new int[1] ;
         H007A11_n323PropostaId = new bool[] {false} ;
         H007A11_A571PropostaAssinatura = new long[1] ;
         H007A11_n571PropostaAssinatura = new bool[] {false} ;
         AV47ReembolsoAssinaturas = new SdtReembolsoAssinaturas(context);
         H007A12_A906LayoutContratoTipo = new string[] {""} ;
         H007A12_n906LayoutContratoTipo = new bool[] {false} ;
         H007A12_A156LayoutContratoStatus = new bool[] {false} ;
         H007A12_n156LayoutContratoStatus = new bool[] {false} ;
         H007A12_A154LayoutContratoId = new short[1] ;
         H007A12_A155LayoutContratoDescricao = new string[] {""} ;
         H007A12_n155LayoutContratoDescricao = new bool[] {false} ;
         A906LayoutContratoTipo = "";
         A155LayoutContratoDescricao = "";
         AV45Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         GXt_char2 = "";
         ucDvelop_confirmpanel_enter = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpiniciarassinaturaproposta__default(),
            new Object[][] {
                new Object[] {
               H007A2_A572PropostaContratoAssinaturaId, H007A2_A573PropostaContratoAssinaturaTipo, H007A2_n573PropostaContratoAssinaturaTipo, H007A2_A323PropostaId, H007A2_n323PropostaId
               }
               , new Object[] {
               H007A3_A323PropostaId, H007A3_A504PropostaPacienteClienteId, H007A3_n504PropostaPacienteClienteId, H007A3_A553PropostaResponsavelId, H007A3_n553PropostaResponsavelId, H007A3_A505PropostaPacienteClienteRazaoSocial, H007A3_n505PropostaPacienteClienteRazaoSocial, H007A3_A328PropostaCratedBy, H007A3_n328PropostaCratedBy
               }
               , new Object[] {
               H007A4_A249EmpresaId, H007A4_A773EmpresaUtilizaRepresentanteAssinatura, H007A4_n773EmpresaUtilizaRepresentanteAssinatura, H007A4_A771EmpresaRepresentanteNome, H007A4_n771EmpresaRepresentanteNome, H007A4_A770EmpresaRepresentanteCPF, H007A4_n770EmpresaRepresentanteCPF, H007A4_A772EmpresaRepresentanteEmail, H007A4_n772EmpresaRepresentanteEmail
               }
               , new Object[] {
               H007A5_A299ConfiguracoesId, H007A5_A398ConfiguracoesLayoutProposta, H007A5_n398ConfiguracoesLayoutProposta, H007A5_A564ConfigLayoutPromissoriaClinicaEmprestimo, H007A5_n564ConfigLayoutPromissoriaClinicaEmprestimo, H007A5_A565ConfigLayoutPromissoriaClinicaTaxa, H007A5_n565ConfigLayoutPromissoriaClinicaTaxa, H007A5_A566ConfigLayoutPromissoriaPaciente, H007A5_n566ConfigLayoutPromissoriaPaciente, H007A5_A418ConfiguracoesLayoutContratoCorpo,
               H007A5_n418ConfiguracoesLayoutContratoCorpo, H007A5_A569ConfigLayoutCorpoPromissoriaPaciente, H007A5_n569ConfigLayoutCorpoPromissoriaPaciente, H007A5_A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo, H007A5_n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo, H007A5_A568ConfigLayoutCorpoPromissoriaClinicaTaxa, H007A5_n568ConfigLayoutCorpoPromissoriaClinicaTaxa
               }
               , new Object[] {
               H007A6_A168ClienteId, H007A6_A172ClienteTipoPessoa, H007A6_n172ClienteTipoPessoa, H007A6_A436ResponsavelNome, H007A6_n436ResponsavelNome, H007A6_A447ResponsavelCPF, H007A6_n447ResponsavelCPF, H007A6_A456ResponsavelEmail, H007A6_n456ResponsavelEmail, H007A6_A170ClienteRazaoSocial,
               H007A6_n170ClienteRazaoSocial, H007A6_A169ClienteDocumento, H007A6_n169ClienteDocumento, H007A6_A201ContatoEmail, H007A6_n201ContatoEmail
               }
               , new Object[] {
               H007A7_A133SecUserId, H007A7_A226SecUserOwnerId, H007A7_n226SecUserOwnerId
               }
               , new Object[] {
               H007A8_A168ClienteId, H007A8_A436ResponsavelNome, H007A8_n436ResponsavelNome, H007A8_A447ResponsavelCPF, H007A8_n447ResponsavelCPF, H007A8_A456ResponsavelEmail, H007A8_n456ResponsavelEmail
               }
               , new Object[] {
               H007A9_A478ConfiguracoesTestemunhasId, H007A9_A133SecUserId, H007A9_n133SecUserId, H007A9_A479ConfiguracoesTestemunhasNome, H007A9_n479ConfiguracoesTestemunhasNome, H007A9_A480ConfiguracoesTestemunhasDocumento, H007A9_n480ConfiguracoesTestemunhasDocumento, H007A9_A481ConfiguracoesTestemunhasEmail, H007A9_n481ConfiguracoesTestemunhasEmail
               }
               , new Object[] {
               H007A10_A154LayoutContratoId, H007A10_A157LayoutContratoCorpo, H007A10_n157LayoutContratoCorpo
               }
               , new Object[] {
               H007A11_A572PropostaContratoAssinaturaId, H007A11_A573PropostaContratoAssinaturaTipo, H007A11_n573PropostaContratoAssinaturaTipo, H007A11_A323PropostaId, H007A11_n323PropostaId, H007A11_A571PropostaAssinatura, H007A11_n571PropostaAssinatura
               }
               , new Object[] {
               H007A12_A906LayoutContratoTipo, H007A12_n906LayoutContratoTipo, H007A12_A156LayoutContratoStatus, H007A12_n156LayoutContratoStatus, H007A12_A154LayoutContratoId, H007A12_A155LayoutContratoDescricao, H007A12_n155LayoutContratoDescricao
               }
            }
         );
         /* GeneXus formulas. */
         edtavRetirar_Enabled = 0;
         edtavNome_Enabled = 0;
         edtavParticipantedocumento_Enabled = 0;
         edtavParticipanteemail_Enabled = 0;
         cmbavAssinaturaparticipantetipo.Enabled = 0;
         edtavDesc_Enabled = 0;
      }

      private short GRID1_nEOF ;
      private short nRcdExists_13 ;
      private short nIsMod_13 ;
      private short nRcdExists_12 ;
      private short nIsMod_12 ;
      private short nRcdExists_11 ;
      private short nIsMod_11 ;
      private short nRcdExists_10 ;
      private short nIsMod_10 ;
      private short nRcdExists_9 ;
      private short nIsMod_9 ;
      private short nRcdExists_8 ;
      private short nIsMod_8 ;
      private short nRcdExists_7 ;
      private short nIsMod_7 ;
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
      private short A154LayoutContratoId ;
      private short wbEnd ;
      private short wbStart ;
      private short AV43LayoutContratoId ;
      private short nDonePA ;
      private short subGrid1_Backcolorstyle ;
      private short A328PropostaCratedBy ;
      private short A398ConfiguracoesLayoutProposta ;
      private short A564ConfigLayoutPromissoriaClinicaEmprestimo ;
      private short A565ConfigLayoutPromissoriaClinicaTaxa ;
      private short A566ConfigLayoutPromissoriaPaciente ;
      private short A133SecUserId ;
      private short gxcookieaux ;
      private short AV16index ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private int AV32PropostaId ;
      private int AV48ReembolsoId ;
      private int wcpOAV32PropostaId ;
      private int wcpOAV48ReembolsoId ;
      private int nRC_GXsfl_40 ;
      private int subGrid1_Recordcount ;
      private int subGrid1_Rows ;
      private int nGXsfl_40_idx=1 ;
      private int A323PropostaId ;
      private int AV63GXV2 ;
      private int edtavContratonome_Enabled ;
      private int edtavLayoutcontratoid_Visible ;
      private int subGrid1_Islastpage ;
      private int edtavRetirar_Enabled ;
      private int edtavNome_Enabled ;
      private int edtavParticipantedocumento_Enabled ;
      private int edtavParticipanteemail_Enabled ;
      private int edtavDesc_Enabled ;
      private int GRID1_nGridOutOfScope ;
      private int A504PropostaPacienteClienteId ;
      private int A553PropostaResponsavelId ;
      private int AV36PropostaPacienteClienteId ;
      private int AV35ResponsavelClienteId ;
      private int AV34ClinicaClienteId ;
      private int A168ClienteId ;
      private int A226SecUserOwnerId ;
      private int AV37secuserownerid ;
      private int AV59GXV1 ;
      private int AV46PropostaContratoAssinaturaId ;
      private int AV64GXV3 ;
      private int AV65GXV4 ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long GRID1_nFirstRecordOnPage ;
      private long A571PropostaAssinatura ;
      private long GRID1_nCurrentRecord ;
      private string Dvelop_confirmpanel_enter_Result ;
      private string Combo_layoutcontratoid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_40_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Combo_layoutcontratoid_Cls ;
      private string Combo_layoutcontratoid_Selectedvalue_set ;
      private string Contratocorpo_Captionclass ;
      private string Contratocorpo_Captionstyle ;
      private string Contratocorpo_Captionposition ;
      private string Dvelop_confirmpanel_enter_Title ;
      private string Dvelop_confirmpanel_enter_Confirmationtext ;
      private string Dvelop_confirmpanel_enter_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_enter_Nobuttoncaption ;
      private string Dvelop_confirmpanel_enter_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_enter_Yesbuttonposition ;
      private string Dvelop_confirmpanel_enter_Confirmtype ;
      private string Grid1_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divTablecontrato_Internalname ;
      private string divCombo_layoutcontratoid_cell_Internalname ;
      private string divCombo_layoutcontratoid_cell_Class ;
      private string divTablesplittedlayoutcontratoid_Internalname ;
      private string lblTextblockcombo_layoutcontratoid_Internalname ;
      private string lblTextblockcombo_layoutcontratoid_Jsonclick ;
      private string Combo_layoutcontratoid_Caption ;
      private string Combo_layoutcontratoid_Internalname ;
      private string edtavContratonome_Internalname ;
      private string TempTags ;
      private string edtavContratonome_Jsonclick ;
      private string Contratocorpo_Internalname ;
      private string divTableparticipantes_Internalname ;
      private string bttBtnaddpart_Internalname ;
      private string bttBtnaddpart_Jsonclick ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavLayoutcontratoid_Internalname ;
      private string edtavLayoutcontratoid_Jsonclick ;
      private string Grid1_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV13Retirar ;
      private string edtavRetirar_Internalname ;
      private string edtavNome_Internalname ;
      private string edtavParticipantedocumento_Internalname ;
      private string edtavParticipanteemail_Internalname ;
      private string cmbavAssinaturaparticipantetipo_Internalname ;
      private string edtavDesc_Internalname ;
      private string GXDecQS ;
      private string GXt_char2 ;
      private string tblTabledvelop_confirmpanel_enter_Internalname ;
      private string Dvelop_confirmpanel_enter_Internalname ;
      private string sGXsfl_40_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string ROClassString ;
      private string edtavRetirar_Jsonclick ;
      private string edtavNome_Jsonclick ;
      private string edtavParticipantedocumento_Jsonclick ;
      private string edtavParticipanteemail_Jsonclick ;
      private string GXCCtl ;
      private string cmbavAssinaturaparticipantetipo_Jsonclick ;
      private string edtavDesc_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV31IsSemResponsavel ;
      private bool Combo_layoutcontratoid_Visible ;
      private bool Combo_layoutcontratoid_Emptyitem ;
      private bool Contratocorpo_Enabled ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_40_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n573PropostaContratoAssinaturaTipo ;
      private bool n323PropostaId ;
      private bool n504PropostaPacienteClienteId ;
      private bool n553PropostaResponsavelId ;
      private bool n505PropostaPacienteClienteRazaoSocial ;
      private bool n328PropostaCratedBy ;
      private bool A773EmpresaUtilizaRepresentanteAssinatura ;
      private bool n773EmpresaUtilizaRepresentanteAssinatura ;
      private bool n771EmpresaRepresentanteNome ;
      private bool n770EmpresaRepresentanteCPF ;
      private bool n772EmpresaRepresentanteEmail ;
      private bool n398ConfiguracoesLayoutProposta ;
      private bool n564ConfigLayoutPromissoriaClinicaEmprestimo ;
      private bool n565ConfigLayoutPromissoriaClinicaTaxa ;
      private bool n566ConfigLayoutPromissoriaPaciente ;
      private bool n418ConfiguracoesLayoutContratoCorpo ;
      private bool n569ConfigLayoutCorpoPromissoriaPaciente ;
      private bool n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo ;
      private bool n568ConfigLayoutCorpoPromissoriaClinicaTaxa ;
      private bool n172ClienteTipoPessoa ;
      private bool n436ResponsavelNome ;
      private bool n447ResponsavelCPF ;
      private bool n456ResponsavelEmail ;
      private bool n170ClienteRazaoSocial ;
      private bool n169ClienteDocumento ;
      private bool n201ContatoEmail ;
      private bool n133SecUserId ;
      private bool n226SecUserOwnerId ;
      private bool n479ConfiguracoesTestemunhasNome ;
      private bool n480ConfiguracoesTestemunhasDocumento ;
      private bool n481ConfiguracoesTestemunhasEmail ;
      private bool n157LayoutContratoCorpo ;
      private bool n571PropostaAssinatura ;
      private bool n906LayoutContratoTipo ;
      private bool A156LayoutContratoStatus ;
      private bool n156LayoutContratoStatus ;
      private bool n155LayoutContratoDescricao ;
      private bool AV30IsExists ;
      private string AV9ContratoCorpo ;
      private string A157LayoutContratoCorpo ;
      private string A418ConfiguracoesLayoutContratoCorpo ;
      private string A569ConfigLayoutCorpoPromissoriaPaciente ;
      private string A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo ;
      private string A568ConfigLayoutCorpoPromissoriaClinicaTaxa ;
      private string AV24HTML ;
      private string AV33PropostaContratoAssinaturaTipo ;
      private string wcpOAV33PropostaContratoAssinaturaTipo ;
      private string A573PropostaContratoAssinaturaTipo ;
      private string AV27GlobalAssinaturaParticipanteTipo ;
      private string AV26GlobalEmail ;
      private string AV29GlobalCPF ;
      private string AV28GlobalNome ;
      private string AV8ContratoNome ;
      private string AV7Nome ;
      private string AV10ParticipanteDocumento ;
      private string AV11ParticipanteEmail ;
      private string AV12AssinaturaParticipanteTipo ;
      private string AV38Desc ;
      private string A505PropostaPacienteClienteRazaoSocial ;
      private string AV39PropostaPacienteClienteRazaoSocial ;
      private string A771EmpresaRepresentanteNome ;
      private string A770EmpresaRepresentanteCPF ;
      private string A772EmpresaRepresentanteEmail ;
      private string A172ClienteTipoPessoa ;
      private string A436ResponsavelNome ;
      private string A447ResponsavelCPF ;
      private string A456ResponsavelEmail ;
      private string A170ClienteRazaoSocial ;
      private string A169ClienteDocumento ;
      private string A201ContatoEmail ;
      private string A479ConfiguracoesTestemunhasNome ;
      private string A480ConfiguracoesTestemunhasDocumento ;
      private string A481ConfiguracoesTestemunhasEmail ;
      private string AV21PdfPath ;
      private string AV50ErroMsg ;
      private string A906LayoutContratoTipo ;
      private string A155LayoutContratoDescricao ;
      private Guid AV19GUID ;
      private string AV18Blob ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXUserControl ucCombo_layoutcontratoid ;
      private GXUserControl ucContratocorpo ;
      private GXUserControl ucGrid1_empowerer ;
      private GXUserControl ucDvelop_confirmpanel_enter ;
      private GxFile AV20File ;
      private GxFile AV22PdfFile ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavAssinaturaparticipantetipo ;
      private GXBaseCollection<SdtSdParticipantes> AV14Array_SdParticipantes ;
      private SdtContrato AV6Contrato ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV44LayoutContratoId_Data ;
      private SdtSdParticipantes AV15SdParticipantes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV42WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext GXt_SdtWWPContext1 ;
      private IDataStoreProvider pr_default ;
      private int[] H007A2_A572PropostaContratoAssinaturaId ;
      private string[] H007A2_A573PropostaContratoAssinaturaTipo ;
      private bool[] H007A2_n573PropostaContratoAssinaturaTipo ;
      private int[] H007A2_A323PropostaId ;
      private bool[] H007A2_n323PropostaId ;
      private int[] H007A3_A323PropostaId ;
      private bool[] H007A3_n323PropostaId ;
      private int[] H007A3_A504PropostaPacienteClienteId ;
      private bool[] H007A3_n504PropostaPacienteClienteId ;
      private int[] H007A3_A553PropostaResponsavelId ;
      private bool[] H007A3_n553PropostaResponsavelId ;
      private string[] H007A3_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] H007A3_n505PropostaPacienteClienteRazaoSocial ;
      private short[] H007A3_A328PropostaCratedBy ;
      private bool[] H007A3_n328PropostaCratedBy ;
      private int[] H007A4_A249EmpresaId ;
      private bool[] H007A4_A773EmpresaUtilizaRepresentanteAssinatura ;
      private bool[] H007A4_n773EmpresaUtilizaRepresentanteAssinatura ;
      private string[] H007A4_A771EmpresaRepresentanteNome ;
      private bool[] H007A4_n771EmpresaRepresentanteNome ;
      private string[] H007A4_A770EmpresaRepresentanteCPF ;
      private bool[] H007A4_n770EmpresaRepresentanteCPF ;
      private string[] H007A4_A772EmpresaRepresentanteEmail ;
      private bool[] H007A4_n772EmpresaRepresentanteEmail ;
      private int[] H007A5_A299ConfiguracoesId ;
      private short[] H007A5_A398ConfiguracoesLayoutProposta ;
      private bool[] H007A5_n398ConfiguracoesLayoutProposta ;
      private short[] H007A5_A564ConfigLayoutPromissoriaClinicaEmprestimo ;
      private bool[] H007A5_n564ConfigLayoutPromissoriaClinicaEmprestimo ;
      private short[] H007A5_A565ConfigLayoutPromissoriaClinicaTaxa ;
      private bool[] H007A5_n565ConfigLayoutPromissoriaClinicaTaxa ;
      private short[] H007A5_A566ConfigLayoutPromissoriaPaciente ;
      private bool[] H007A5_n566ConfigLayoutPromissoriaPaciente ;
      private string[] H007A5_A418ConfiguracoesLayoutContratoCorpo ;
      private bool[] H007A5_n418ConfiguracoesLayoutContratoCorpo ;
      private string[] H007A5_A569ConfigLayoutCorpoPromissoriaPaciente ;
      private bool[] H007A5_n569ConfigLayoutCorpoPromissoriaPaciente ;
      private string[] H007A5_A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo ;
      private bool[] H007A5_n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo ;
      private string[] H007A5_A568ConfigLayoutCorpoPromissoriaClinicaTaxa ;
      private bool[] H007A5_n568ConfigLayoutCorpoPromissoriaClinicaTaxa ;
      private int[] H007A6_A168ClienteId ;
      private string[] H007A6_A172ClienteTipoPessoa ;
      private bool[] H007A6_n172ClienteTipoPessoa ;
      private string[] H007A6_A436ResponsavelNome ;
      private bool[] H007A6_n436ResponsavelNome ;
      private string[] H007A6_A447ResponsavelCPF ;
      private bool[] H007A6_n447ResponsavelCPF ;
      private string[] H007A6_A456ResponsavelEmail ;
      private bool[] H007A6_n456ResponsavelEmail ;
      private string[] H007A6_A170ClienteRazaoSocial ;
      private bool[] H007A6_n170ClienteRazaoSocial ;
      private string[] H007A6_A169ClienteDocumento ;
      private bool[] H007A6_n169ClienteDocumento ;
      private string[] H007A6_A201ContatoEmail ;
      private bool[] H007A6_n201ContatoEmail ;
      private short[] H007A7_A133SecUserId ;
      private bool[] H007A7_n133SecUserId ;
      private int[] H007A7_A226SecUserOwnerId ;
      private bool[] H007A7_n226SecUserOwnerId ;
      private int[] H007A8_A168ClienteId ;
      private string[] H007A8_A436ResponsavelNome ;
      private bool[] H007A8_n436ResponsavelNome ;
      private string[] H007A8_A447ResponsavelCPF ;
      private bool[] H007A8_n447ResponsavelCPF ;
      private string[] H007A8_A456ResponsavelEmail ;
      private bool[] H007A8_n456ResponsavelEmail ;
      private int[] H007A9_A478ConfiguracoesTestemunhasId ;
      private short[] H007A9_A133SecUserId ;
      private bool[] H007A9_n133SecUserId ;
      private string[] H007A9_A479ConfiguracoesTestemunhasNome ;
      private bool[] H007A9_n479ConfiguracoesTestemunhasNome ;
      private string[] H007A9_A480ConfiguracoesTestemunhasDocumento ;
      private bool[] H007A9_n480ConfiguracoesTestemunhasDocumento ;
      private string[] H007A9_A481ConfiguracoesTestemunhasEmail ;
      private bool[] H007A9_n481ConfiguracoesTestemunhasEmail ;
      private short[] H007A10_A154LayoutContratoId ;
      private string[] H007A10_A157LayoutContratoCorpo ;
      private bool[] H007A10_n157LayoutContratoCorpo ;
      private SdtSdErro AV17SdErro ;
      private int[] H007A11_A572PropostaContratoAssinaturaId ;
      private string[] H007A11_A573PropostaContratoAssinaturaTipo ;
      private bool[] H007A11_n573PropostaContratoAssinaturaTipo ;
      private int[] H007A11_A323PropostaId ;
      private bool[] H007A11_n323PropostaId ;
      private long[] H007A11_A571PropostaAssinatura ;
      private bool[] H007A11_n571PropostaAssinatura ;
      private SdtReembolsoAssinaturas AV47ReembolsoAssinaturas ;
      private string[] H007A12_A906LayoutContratoTipo ;
      private bool[] H007A12_n906LayoutContratoTipo ;
      private bool[] H007A12_A156LayoutContratoStatus ;
      private bool[] H007A12_n156LayoutContratoStatus ;
      private short[] H007A12_A154LayoutContratoId ;
      private string[] H007A12_A155LayoutContratoDescricao ;
      private bool[] H007A12_n155LayoutContratoDescricao ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV45Combo_DataItem ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpiniciarassinaturaproposta__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH007A2;
          prmH007A2 = new Object[] {
          new ParDef("AV32PropostaId",GXType.Int32,9,0) ,
          new ParDef("AV33PropostaContratoAssinaturaTipo",GXType.VarChar,60,0)
          };
          Object[] prmH007A3;
          prmH007A3 = new Object[] {
          new ParDef("AV32PropostaId",GXType.Int32,9,0)
          };
          Object[] prmH007A4;
          prmH007A4 = new Object[] {
          };
          Object[] prmH007A5;
          prmH007A5 = new Object[] {
          };
          Object[] prmH007A6;
          prmH007A6 = new Object[] {
          new ParDef("AV35ResponsavelClienteId",GXType.Int32,9,0)
          };
          Object[] prmH007A7;
          prmH007A7 = new Object[] {
          new ParDef("AV34ClinicaClienteId",GXType.Int32,9,0)
          };
          Object[] prmH007A8;
          prmH007A8 = new Object[] {
          new ParDef("AV37secuserownerid",GXType.Int32,9,0)
          };
          Object[] prmH007A9;
          prmH007A9 = new Object[] {
          new ParDef("AV42WWPContext__Userid",GXType.Int16,4,0)
          };
          Object[] prmH007A10;
          prmH007A10 = new Object[] {
          new ParDef("AV43LayoutContratoId",GXType.Int16,4,0)
          };
          Object[] prmH007A11;
          prmH007A11 = new Object[] {
          new ParDef("AV32PropostaId",GXType.Int32,9,0) ,
          new ParDef("AV33PropostaContratoAssinaturaTipo",GXType.VarChar,60,0)
          };
          Object[] prmH007A12;
          prmH007A12 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H007A2", "SELECT PropostaContratoAssinaturaId, PropostaContratoAssinaturaTipo, PropostaId FROM PropostaContratoAssinatura WHERE (PropostaId = :AV32PropostaId) AND (PropostaContratoAssinaturaTipo = ( :AV33PropostaContratoAssinaturaTipo)) ORDER BY PropostaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007A2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H007A3", "SELECT T1.PropostaId, T1.PropostaPacienteClienteId AS PropostaPacienteClienteId, T1.PropostaResponsavelId, T2.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, T1.PropostaCratedBy FROM (Proposta T1 LEFT JOIN Cliente T2 ON T2.ClienteId = T1.PropostaPacienteClienteId) WHERE T1.PropostaId = :AV32PropostaId ORDER BY T1.PropostaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007A3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H007A4", "SELECT EmpresaId, EmpresaUtilizaRepresentanteAssinatura, EmpresaRepresentanteNome, EmpresaRepresentanteCPF, EmpresaRepresentanteEmail FROM Empresa WHERE EmpresaUtilizaRepresentanteAssinatura ORDER BY EmpresaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007A4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H007A5", "SELECT T1.ConfiguracoesId, T1.ConfiguracoesLayoutProposta AS ConfiguracoesLayoutProposta, T1.ConfigLayoutPromissoriaClinicaEmprestimo AS ConfigLayoutPromissoriaClinicaEmprestimo, T1.ConfigLayoutPromissoriaClinicaTaxa AS ConfigLayoutPromissoriaClinicaTaxa, T1.ConfigLayoutPromissoriaPaciente AS ConfigLayoutPromissoriaPaciente, T2.LayoutContratoCorpo AS ConfiguracoesLayoutContratoCorpo, T5.LayoutContratoCorpo AS ConfigLayoutCorpoPromissoriaPaciente, T3.LayoutContratoCorpo AS ConfigLayoutCorpoPromissoriaClinicaEmprestimo, T4.LayoutContratoCorpo AS ConfigLayoutCorpoPromissoriaClinicaTaxa FROM ((((Configuracoes T1 LEFT JOIN LayoutContrato T2 ON T2.LayoutContratoId = T1.ConfiguracoesLayoutProposta) LEFT JOIN LayoutContrato T3 ON T3.LayoutContratoId = T1.ConfigLayoutPromissoriaClinicaEmprestimo) LEFT JOIN LayoutContrato T4 ON T4.LayoutContratoId = T1.ConfigLayoutPromissoriaClinicaTaxa) LEFT JOIN LayoutContrato T5 ON T5.LayoutContratoId = T1.ConfigLayoutPromissoriaPaciente) ORDER BY T1.ConfiguracoesId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007A5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H007A6", "SELECT ClienteId, ClienteTipoPessoa, ResponsavelNome, ResponsavelCPF, ResponsavelEmail, ClienteRazaoSocial, ClienteDocumento, ContatoEmail FROM Cliente WHERE ClienteId = :AV35ResponsavelClienteId ORDER BY ClienteId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007A6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H007A7", "SELECT SecUserId, SecUserOwnerId FROM SecUser WHERE SecUserId = :AV34ClinicaClienteId ORDER BY SecUserId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007A7,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H007A8", "SELECT ClienteId, ResponsavelNome, ResponsavelCPF, ResponsavelEmail FROM Cliente WHERE ClienteId = :AV37secuserownerid ORDER BY ClienteId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007A8,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H007A9", "SELECT ConfiguracoesTestemunhasId, SecUserId, ConfiguracoesTestemunhasNome, ConfiguracoesTestemunhasDocumento, ConfiguracoesTestemunhasEmail FROM ConfiguracoesTestemunhas WHERE SecUserId = :AV42WWPContext__Userid ORDER BY SecUserId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007A9,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H007A10", "SELECT LayoutContratoId, LayoutContratoCorpo FROM LayoutContrato WHERE LayoutContratoId = :AV43LayoutContratoId ORDER BY LayoutContratoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007A10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H007A11", "SELECT PropostaContratoAssinaturaId, PropostaContratoAssinaturaTipo, PropostaId, PropostaAssinatura FROM PropostaContratoAssinatura WHERE (PropostaId = :AV32PropostaId) AND (PropostaContratoAssinaturaTipo = ( :AV33PropostaContratoAssinaturaTipo)) ORDER BY PropostaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007A11,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H007A12", "SELECT LayoutContratoTipo, LayoutContratoStatus, LayoutContratoId, LayoutContratoDescricao FROM LayoutContrato WHERE (LayoutContratoStatus) AND (LayoutContratoTipo = ( 'C')) ORDER BY LayoutContratoDescricao ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007A12,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((short[]) buf[5])[0] = rslt.getShort(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getLongVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getLongVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getLongVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getLongVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((long[]) buf[5])[0] = rslt.getLong(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((short[]) buf[4])[0] = rslt.getShort(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
       }
    }

 }

}
