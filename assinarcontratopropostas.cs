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
   public class assinarcontratopropostas : GXDataArea
   {
      public assinarcontratopropostas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("DSAssinatura", true);
      }

      public assinarcontratopropostas( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_PropostaId ,
                           string aP1_PropostaContratoAssinaturaTipo ,
                           int aP2_ReembolsoId )
      {
         this.AV46PropostaId = aP0_PropostaId;
         this.AV47PropostaContratoAssinaturaTipo = aP1_PropostaContratoAssinaturaTipo;
         this.AV50ReembolsoId = aP2_ReembolsoId;
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Freegrid") == 0 )
            {
               gxnrFreegrid_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Freegrid") == 0 )
            {
               gxgrFreegrid_refresh_invoke( ) ;
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

      protected void gxnrFreegrid_newrow_invoke( )
      {
         nRC_GXsfl_64 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_64"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_64_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_64_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_64_idx = GetPar( "sGXsfl_64_idx");
         edtavGridjson_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtavGridjson_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavGridjson_Visible), 5, 0), !bGXsfl_64_Refreshing);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrFreegrid_newrow( ) ;
         /* End function gxnrFreegrid_newrow_invoke */
      }

      protected void gxgrFreegrid_refresh_invoke( )
      {
         edtavGridjson_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtavGridjson_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavGridjson_Visible), 5, 0), !bGXsfl_64_Refreshing);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV10Array_SdParticipantes);
         AV30Tipo = StringUtil.StrToBool( GetPar( "Tipo"));
         AV29StringBase64 = GetPar( "StringBase64");
         AV39ContratoId = (int)(Math.Round(NumberUtil.Val( GetPar( "ContratoId"), "."), 18, MidpointRounding.ToEven));
         AV25ClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "ClienteId"), "."), 18, MidpointRounding.ToEven));
         AV46PropostaId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaId"), "."), 18, MidpointRounding.ToEven));
         AV47PropostaContratoAssinaturaTipo = GetPar( "PropostaContratoAssinaturaTipo");
         AV50ReembolsoId = (int)(Math.Round(NumberUtil.Val( GetPar( "ReembolsoId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrFreegrid_refresh( AV10Array_SdParticipantes, AV30Tipo, AV29StringBase64, AV39ContratoId, AV25ClienteId, AV46PropostaId, AV47PropostaContratoAssinaturaTipo, AV50ReembolsoId) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrFreegrid_refresh_invoke */
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
         PA9X2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START9X2( ) ;
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
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
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
         if ( nGXWrapped != 1 )
         {
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "assinarcontratopropostas"+UrlEncode(StringUtil.LTrimStr(AV46PropostaId,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV47PropostaContratoAssinaturaTipo)) + "," + UrlEncode(StringUtil.LTrimStr(AV50ReembolsoId,9,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("assinarcontratopropostas") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         }
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_boolean_hidden_field( context, "vTIPO", AV30Tipo);
         GxWebStd.gx_hidden_field( context, "gxhash_vTIPO", GetSecureSignedToken( "", AV30Tipo, context));
         GxWebStd.gx_hidden_field( context, "vSTRINGBASE64", AV29StringBase64);
         GxWebStd.gx_hidden_field( context, "gxhash_vSTRINGBASE64", GetSecureSignedToken( "", AV29StringBase64, context));
         GxWebStd.gx_hidden_field( context, "vCONTRATOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39ContratoId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCONTRATOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV39ContratoId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV25ClienteId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV46PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV46PropostaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPROPOSTACONTRATOASSINATURATIPO", AV47PropostaContratoAssinaturaTipo);
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTACONTRATOASSINATURATIPO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV47PropostaContratoAssinaturaTipo, "")), context));
         GxWebStd.gx_hidden_field( context, "vREEMBOLSOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV50ReembolsoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV50ReembolsoId), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_64", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_64), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vLAYOUTCONTRATOID_DATA", AV23LayoutContratoId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vLAYOUTCONTRATOID_DATA", AV23LayoutContratoId_Data);
         }
         GxWebStd.gx_hidden_field( context, "vCORPO", AV8Corpo);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vARRAY_SDPARTICIPANTES", AV10Array_SdParticipantes);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vARRAY_SDPARTICIPANTES", AV10Array_SdParticipantes);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vTIPO", AV30Tipo);
         GxWebStd.gx_hidden_field( context, "gxhash_vTIPO", GetSecureSignedToken( "", AV30Tipo, context));
         GxWebStd.gx_hidden_field( context, "vSTRINGBASE64", AV29StringBase64);
         GxWebStd.gx_hidden_field( context, "gxhash_vSTRINGBASE64", GetSecureSignedToken( "", AV29StringBase64, context));
         GxWebStd.gx_hidden_field( context, "vCONTRATOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39ContratoId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCONTRATOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV39ContratoId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV25ClienteId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vBLOB", AV37Blob);
         GxWebStd.gx_hidden_field( context, "vPROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV46PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV46PropostaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPROPOSTACONTRATOASSINATURATIPO", AV47PropostaContratoAssinaturaTipo);
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTACONTRATOASSINATURATIPO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV47PropostaContratoAssinaturaTipo, "")), context));
         GxWebStd.gx_hidden_field( context, "PROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PROPOSTACONTRATOASSINATURATIPO", A573PropostaContratoAssinaturaTipo);
         GxWebStd.gx_hidden_field( context, "PROPOSTAASSINATURA", StringUtil.LTrim( StringUtil.NToC( (decimal)(A571PropostaAssinatura), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vREEMBOLSOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV50ReembolsoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV50ReembolsoId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "LAYOUTCONTRATOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A154LayoutContratoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "LAYOUTCONTRATOCORPO", A157LayoutContratoCorpo);
         GxWebStd.gx_hidden_field( context, "vJSON", AV12JSON);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAUXSDPARTICIPANTES", AV15AuxSdParticipantes);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAUXSDPARTICIPANTES", AV15AuxSdParticipantes);
         }
         GxWebStd.gx_hidden_field( context, "vGXV5", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV70GXV5), 8, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vISUPDATE", AV19IsUpdate);
         GxWebStd.gx_hidden_field( context, "vI", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16i), 4, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDPARTICIPANTES", AV11SdParticipantes);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDPARTICIPANTES", AV11SdParticipantes);
         }
         GxWebStd.gx_hidden_field( context, "subFreegrid_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreegrid_Recordcount), 5, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "COMBO_LAYOUTCONTRATOID_Cls", StringUtil.RTrim( Combo_layoutcontratoid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_LAYOUTCONTRATOID_Selectedvalue_set", StringUtil.RTrim( Combo_layoutcontratoid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_LAYOUTCONTRATOID_Visible", StringUtil.BoolToStr( Combo_layoutcontratoid_Visible));
         GxWebStd.gx_hidden_field( context, "COMBO_LAYOUTCONTRATOID_Emptyitem", StringUtil.BoolToStr( Combo_layoutcontratoid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "CORPO_Enabled", StringUtil.BoolToStr( Corpo_Enabled));
         GxWebStd.gx_hidden_field( context, "CORPO_Captionclass", StringUtil.RTrim( Corpo_Captionclass));
         GxWebStd.gx_hidden_field( context, "CORPO_Captionstyle", StringUtil.RTrim( Corpo_Captionstyle));
         GxWebStd.gx_hidden_field( context, "CORPO_Captionposition", StringUtil.RTrim( Corpo_Captionposition));
         GxWebStd.gx_hidden_field( context, "FREEGRID_Class", StringUtil.RTrim( subFreegrid_Class));
         GxWebStd.gx_hidden_field( context, "FREEGRID_Flexdirection", StringUtil.RTrim( subFreegrid_Flexdirection));
         GxWebStd.gx_hidden_field( context, "COMBO_LAYOUTCONTRATOID_Selectedvalue_get", StringUtil.RTrim( Combo_layoutcontratoid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "vGRIDJSON_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavGridjson_Visible), 5, 0, ".", "")));
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "</form>") ;
         }
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
            WE9X2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT9X2( ) ;
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
         GXEncryptionTmp = "assinarcontratopropostas"+UrlEncode(StringUtil.LTrimStr(AV46PropostaId,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV47PropostaContratoAssinaturaTipo)) + "," + UrlEncode(StringUtil.LTrimStr(AV50ReembolsoId,9,0));
         return formatLink("assinarcontratopropostas") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "AssinarContratoPropostas" ;
      }

      public override string GetPgmdesc( )
      {
         return "Assinar Contrato" ;
      }

      protected void WB9X0( )
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
            wb_table1_9_9X2( true) ;
         }
         else
         {
            wb_table1_9_9X2( false) ;
         }
         return  ;
      }

      protected void wb_table1_9_9X2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, divTablecontentitens_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divContractpage_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divEditor_Internalname, 1, 0, "px", 0, "px", "editor-section", "start", "top", "", "", "div");
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
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_layoutcontratoid_Internalname, "Layout de contrato (Modelo)", "", "", lblTextblockcombo_layoutcontratoid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_AssinarContratoPropostas.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_layoutcontratoid.SetProperty("Caption", Combo_layoutcontratoid_Caption);
            ucCombo_layoutcontratoid.SetProperty("Cls", Combo_layoutcontratoid_Cls);
            ucCombo_layoutcontratoid.SetProperty("EmptyItem", Combo_layoutcontratoid_Emptyitem);
            ucCombo_layoutcontratoid.SetProperty("DropDownOptionsData", AV23LayoutContratoId_Data);
            ucCombo_layoutcontratoid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_layoutcontratoid_Internalname, "COMBO_LAYOUTCONTRATOIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavNomecontrato_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNomecontrato_Internalname, "Nome", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNomecontrato_Internalname, AV9NomeContrato, StringUtil.RTrim( context.localUtil.Format( AV9NomeContrato, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNomecontrato_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavNomecontrato_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_AssinarContratoPropostas.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontractbody_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CkEditor", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", -1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+Corpo_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCorpo.SetProperty("Attribute", AV8Corpo);
            ucCorpo.SetProperty("CaptionClass", Corpo_Captionclass);
            ucCorpo.SetProperty("CaptionStyle", Corpo_Captionstyle);
            ucCorpo.SetProperty("CaptionPosition", Corpo_Captionposition);
            ucCorpo.Render(context, "fckeditor", Corpo_Internalname, "CORPOContainer");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-md-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLbl_Internalname, 1, 0, "px", 0, "px", "participants-section", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divParticipantestitle_Internalname, 1, 0, "px", 0, "px", "participants-title", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbl_Internalname, "Participantes", "", "", lblLbl_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AssinarContratoPropostas.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            ClassString = "add-button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnadicionarparticipante_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(64), 2, 0)+","+"null"+");", "Adicionar", bttBtnadicionarparticipante_Jsonclick, 5, "Adicionar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOADICIONARPARTICIPANTE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_AssinarContratoPropostas.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            FreegridContainer.SetIsFreestyle(true);
            FreegridContainer.SetWrapped(nGXWrapped);
            StartGridControl64( ) ;
         }
         if ( wbEnd == 64 )
         {
            wbEnd = 0;
            nRC_GXsfl_64 = (int)(nGXsfl_64_idx-1);
            if ( FreegridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"FreegridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Freegrid", FreegridContainer, subFreegrid_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "FreegridContainerData", FreegridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "FreegridContainerData"+"V", FreegridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"FreegridContainerData"+"V"+"\" value='"+FreegridContainer.GridValuesHidden()+"'/>") ;
               }
            }
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
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLayoutcontratoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22LayoutContratoId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV22LayoutContratoId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,95);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLayoutcontratoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavLayoutcontratoid_Visible, 1, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_AssinarContratoPropostas.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 64 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( FreegridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"FreegridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Freegrid", FreegridContainer, subFreegrid_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "FreegridContainerData", FreegridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "FreegridContainerData"+"V", FreegridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"FreegridContainerData"+"V"+"\" value='"+FreegridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START9X2( )
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
         Form.Meta.addItem("description", "Assinar Contrato", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP9X0( ) ;
      }

      protected void WS9X2( )
      {
         START9X2( ) ;
         EVT9X2( ) ;
      }

      protected void EVT9X2( )
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
                              E119X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOENVIARPARAASSINATURA'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoEnviarParaAssinatura' */
                              E129X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOADICIONARPARTICIPANTE'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoAdicionarParticipante' */
                              E139X2 ();
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEDITAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoEditar' */
                              E149X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DORETIRAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoRetirar' */
                              E159X2 ();
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
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "FREEGRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "'DOEDITAR'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 11), "'DORETIRAR'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) )
                           {
                              nGXsfl_64_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
                              SubsflControlProps_642( ) ;
                              AV5NomeParticipante = cgiGet( edtavNomeparticipante_Internalname);
                              AssignAttri("", false, edtavNomeparticipante_Internalname, AV5NomeParticipante);
                              AV14GRIDJSON = cgiGet( edtavGridjson_Internalname);
                              AssignAttri("", false, edtavGridjson_Internalname, AV14GRIDJSON);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E169X2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "FREEGRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Freegrid.Load */
                                    E179X2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DOEDITAR'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoEditar' */
                                    E149X2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DORETIRAR'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoRetirar' */
                                    E159X2 ();
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
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE9X2( )
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

      protected void PA9X2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "assinarcontratopropostas")), "assinarcontratopropostas") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "assinarcontratopropostas")))) ;
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
                     AV46PropostaId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV46PropostaId", StringUtil.LTrimStr( (decimal)(AV46PropostaId), 9, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV46PropostaId), "ZZZZZZZZ9"), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV47PropostaContratoAssinaturaTipo = GetPar( "PropostaContratoAssinaturaTipo");
                        AssignAttri("", false, "AV47PropostaContratoAssinaturaTipo", AV47PropostaContratoAssinaturaTipo);
                        GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTACONTRATOASSINATURATIPO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV47PropostaContratoAssinaturaTipo, "")), context));
                        AV50ReembolsoId = (int)(Math.Round(NumberUtil.Val( GetPar( "ReembolsoId"), "."), 18, MidpointRounding.ToEven));
                        AssignAttri("", false, "AV50ReembolsoId", StringUtil.LTrimStr( (decimal)(AV50ReembolsoId), 9, 0));
                        GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV50ReembolsoId), "ZZZZZZZZ9"), context));
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
               GX_FocusControl = edtavNomecontrato_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrFreegrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_642( ) ;
         while ( nGXsfl_64_idx <= nRC_GXsfl_64 )
         {
            sendrow_642( ) ;
            nGXsfl_64_idx = ((subFreegrid_Islastpage==1)&&(nGXsfl_64_idx+1>subFreegrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_64_idx+1);
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( FreegridContainer)) ;
         /* End function gxnrFreegrid_newrow */
      }

      protected void gxgrFreegrid_refresh( GXBaseCollection<SdtSdParticipantes> AV10Array_SdParticipantes ,
                                           bool AV30Tipo ,
                                           string AV29StringBase64 ,
                                           int AV39ContratoId ,
                                           int AV25ClienteId ,
                                           int AV46PropostaId ,
                                           string AV47PropostaContratoAssinaturaTipo ,
                                           int AV50ReembolsoId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         FREEGRID_nCurrentRecord = 0;
         RF9X2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrFreegrid_refresh */
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
         RF9X2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavNomeparticipante_Enabled = 0;
      }

      protected void RF9X2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            FreegridContainer.ClearRows();
         }
         wbStart = 64;
         nGXsfl_64_idx = 1;
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_642( ) ;
         bGXsfl_64_Refreshing = true;
         FreegridContainer.AddObjectProperty("GridName", "Freegrid");
         FreegridContainer.AddObjectProperty("CmpContext", "");
         FreegridContainer.AddObjectProperty("InMasterPage", "false");
         FreegridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         FreegridContainer.AddObjectProperty("Class", "FreeStyleGrid");
         FreegridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         FreegridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         FreegridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreegrid_Backcolorstyle), 1, 0, ".", "")));
         FreegridContainer.PageSize = subFreegrid_fnc_Recordsperpage( );
         if ( subFreegrid_Islastpage != 0 )
         {
            FREEGRID_nFirstRecordOnPage = (long)(subFreegrid_fnc_Recordcount( )-subFreegrid_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, "FREEGRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(FREEGRID_nFirstRecordOnPage), 15, 0, ".", "")));
            FreegridContainer.AddObjectProperty("FREEGRID_nFirstRecordOnPage", FREEGRID_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_642( ) ;
            /* Execute user event: Freegrid.Load */
            E179X2 ();
            wbEnd = 64;
            WB9X0( ) ;
         }
         bGXsfl_64_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes9X2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, "vTIPO", AV30Tipo);
         GxWebStd.gx_hidden_field( context, "gxhash_vTIPO", GetSecureSignedToken( "", AV30Tipo, context));
         GxWebStd.gx_hidden_field( context, "vSTRINGBASE64", AV29StringBase64);
         GxWebStd.gx_hidden_field( context, "gxhash_vSTRINGBASE64", GetSecureSignedToken( "", AV29StringBase64, context));
         GxWebStd.gx_hidden_field( context, "vCONTRATOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39ContratoId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCONTRATOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV39ContratoId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV25ClienteId), "ZZZZZZZZ9"), context));
      }

      protected int subFreegrid_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subFreegrid_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subFreegrid_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subFreegrid_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         edtavNomeparticipante_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP9X0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E169X2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vLAYOUTCONTRATOID_DATA"), AV23LayoutContratoId_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vAUXSDPARTICIPANTES"), AV15AuxSdParticipantes);
            ajax_req_read_hidden_sdt(cgiGet( "vARRAY_SDPARTICIPANTES"), AV10Array_SdParticipantes);
            ajax_req_read_hidden_sdt(cgiGet( "vSDPARTICIPANTES"), AV11SdParticipantes);
            /* Read saved values. */
            nRC_GXsfl_64 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_64"), ",", "."), 18, MidpointRounding.ToEven));
            AV8Corpo = cgiGet( "vCORPO");
            AssignAttri("", false, "AV8Corpo", AV8Corpo);
            AV70GXV5 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vGXV5"), ",", "."), 18, MidpointRounding.ToEven));
            AV19IsUpdate = StringUtil.StrToBool( cgiGet( "vISUPDATE"));
            AV16i = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vI"), ",", "."), 18, MidpointRounding.ToEven));
            AV12JSON = cgiGet( "vJSON");
            subFreegrid_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "subFreegrid_Recordcount"), ",", "."), 18, MidpointRounding.ToEven));
            Combo_layoutcontratoid_Cls = cgiGet( "COMBO_LAYOUTCONTRATOID_Cls");
            Combo_layoutcontratoid_Selectedvalue_set = cgiGet( "COMBO_LAYOUTCONTRATOID_Selectedvalue_set");
            Combo_layoutcontratoid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_LAYOUTCONTRATOID_Visible"));
            Combo_layoutcontratoid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_LAYOUTCONTRATOID_Emptyitem"));
            Corpo_Enabled = StringUtil.StrToBool( cgiGet( "CORPO_Enabled"));
            Corpo_Captionclass = cgiGet( "CORPO_Captionclass");
            Corpo_Captionstyle = cgiGet( "CORPO_Captionstyle");
            Corpo_Captionposition = cgiGet( "CORPO_Captionposition");
            subFreegrid_Class = cgiGet( "FREEGRID_Class");
            subFreegrid_Flexdirection = cgiGet( "FREEGRID_Flexdirection");
            Combo_layoutcontratoid_Selectedvalue_get = cgiGet( "COMBO_LAYOUTCONTRATOID_Selectedvalue_get");
            /* Read variables values. */
            AV9NomeContrato = cgiGet( edtavNomecontrato_Internalname);
            AssignAttri("", false, "AV9NomeContrato", AV9NomeContrato);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavLayoutcontratoid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavLayoutcontratoid_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vLAYOUTCONTRATOID");
               GX_FocusControl = edtavLayoutcontratoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV22LayoutContratoId = 0;
               AssignAttri("", false, "AV22LayoutContratoId", StringUtil.LTrimStr( (decimal)(AV22LayoutContratoId), 4, 0));
            }
            else
            {
               AV22LayoutContratoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavLayoutcontratoid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV22LayoutContratoId", StringUtil.LTrimStr( (decimal)(AV22LayoutContratoId), 4, 0));
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
         E169X2 ();
         if (returnInSub) return;
      }

      protected void E169X2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV10Array_SdParticipantes = new GXBaseCollection<SdtSdParticipantes>( context, "SdParticipantes", "Factory21");
         edtavLayoutcontratoid_Visible = 0;
         AssignProp("", false, edtavLayoutcontratoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLayoutcontratoid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOLAYOUTCONTRATOID' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S122 ();
         if (returnInSub) return;
         edtavGridjson_Visible = 0;
         AssignProp("", false, edtavGridjson_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavGridjson_Visible), 5, 0), !bGXsfl_64_Refreshing);
         /* Using cursor H009X2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A773EmpresaUtilizaRepresentanteAssinatura = H009X2_A773EmpresaUtilizaRepresentanteAssinatura[0];
            n773EmpresaUtilizaRepresentanteAssinatura = H009X2_n773EmpresaUtilizaRepresentanteAssinatura[0];
            A252EmpresaCNPJ = H009X2_A252EmpresaCNPJ[0];
            n252EmpresaCNPJ = H009X2_n252EmpresaCNPJ[0];
            A470EmpresaEmail = H009X2_A470EmpresaEmail[0];
            n470EmpresaEmail = H009X2_n470EmpresaEmail[0];
            A251EmpresaRazaoSocial = H009X2_A251EmpresaRazaoSocial[0];
            n251EmpresaRazaoSocial = H009X2_n251EmpresaRazaoSocial[0];
            A770EmpresaRepresentanteCPF = H009X2_A770EmpresaRepresentanteCPF[0];
            n770EmpresaRepresentanteCPF = H009X2_n770EmpresaRepresentanteCPF[0];
            A772EmpresaRepresentanteEmail = H009X2_A772EmpresaRepresentanteEmail[0];
            n772EmpresaRepresentanteEmail = H009X2_n772EmpresaRepresentanteEmail[0];
            A771EmpresaRepresentanteNome = H009X2_A771EmpresaRepresentanteNome[0];
            n771EmpresaRepresentanteNome = H009X2_n771EmpresaRepresentanteNome[0];
            AV11SdParticipantes = new SdtSdParticipantes(context);
            AV11SdParticipantes.gxTpr_Assinaturaparticipantetipo = "Contratado";
            AV11SdParticipantes.gxTpr_Participantedocumento = A252EmpresaCNPJ;
            AV11SdParticipantes.gxTpr_Participanteemail = A470EmpresaEmail;
            AV11SdParticipantes.gxTpr_Participantenome = A251EmpresaRazaoSocial;
            AV11SdParticipantes.gxTpr_Participanterepresentantedocumento = A770EmpresaRepresentanteCPF;
            AV11SdParticipantes.gxTpr_Participanterepresentanteemail = A772EmpresaRepresentanteEmail;
            AV11SdParticipantes.gxTpr_Participanterepresentantenome = A771EmpresaRepresentanteNome;
            AV11SdParticipantes.gxTpr_Participantetipopessoa = "JURIDICA";
            AV10Array_SdParticipantes.Add(AV11SdParticipantes, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /* Using cursor H009X3 */
         pr_default.execute(1, new Object[] {AV46PropostaId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A323PropostaId = H009X3_A323PropostaId[0];
            n323PropostaId = H009X3_n323PropostaId[0];
            A504PropostaPacienteClienteId = H009X3_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = H009X3_n504PropostaPacienteClienteId[0];
            A553PropostaResponsavelId = H009X3_A553PropostaResponsavelId[0];
            n553PropostaResponsavelId = H009X3_n553PropostaResponsavelId[0];
            A505PropostaPacienteClienteRazaoSocial = H009X3_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = H009X3_n505PropostaPacienteClienteRazaoSocial[0];
            A328PropostaCratedBy = H009X3_A328PropostaCratedBy[0];
            n328PropostaCratedBy = H009X3_n328PropostaCratedBy[0];
            A505PropostaPacienteClienteRazaoSocial = H009X3_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = H009X3_n505PropostaPacienteClienteRazaoSocial[0];
            AV55PropostaPacienteClienteId = A504PropostaPacienteClienteId;
            AV52ResponsavelClienteId = A553PropostaResponsavelId;
            AssignAttri("", false, "AV52ResponsavelClienteId", StringUtil.LTrimStr( (decimal)(AV52ResponsavelClienteId), 9, 0));
            AV56PropostaPacienteClienteRazaoSocial = A505PropostaPacienteClienteRazaoSocial;
            AV53ClinicaClienteId = A328PropostaCratedBy;
            AssignAttri("", false, "AV53ClinicaClienteId", StringUtil.LTrimStr( (decimal)(AV53ClinicaClienteId), 9, 0));
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         if ( ! ( StringUtil.StrCmp(AV47PropostaContratoAssinaturaTipo, "Documento") == 0 ) )
         {
            /* Using cursor H009X4 */
            pr_default.execute(2);
            while ( (pr_default.getStatus(2) != 101) )
            {
               A398ConfiguracoesLayoutProposta = H009X4_A398ConfiguracoesLayoutProposta[0];
               n398ConfiguracoesLayoutProposta = H009X4_n398ConfiguracoesLayoutProposta[0];
               A564ConfigLayoutPromissoriaClinicaEmprestimo = H009X4_A564ConfigLayoutPromissoriaClinicaEmprestimo[0];
               n564ConfigLayoutPromissoriaClinicaEmprestimo = H009X4_n564ConfigLayoutPromissoriaClinicaEmprestimo[0];
               A565ConfigLayoutPromissoriaClinicaTaxa = H009X4_A565ConfigLayoutPromissoriaClinicaTaxa[0];
               n565ConfigLayoutPromissoriaClinicaTaxa = H009X4_n565ConfigLayoutPromissoriaClinicaTaxa[0];
               A566ConfigLayoutPromissoriaPaciente = H009X4_A566ConfigLayoutPromissoriaPaciente[0];
               n566ConfigLayoutPromissoriaPaciente = H009X4_n566ConfigLayoutPromissoriaPaciente[0];
               A418ConfiguracoesLayoutContratoCorpo = H009X4_A418ConfiguracoesLayoutContratoCorpo[0];
               n418ConfiguracoesLayoutContratoCorpo = H009X4_n418ConfiguracoesLayoutContratoCorpo[0];
               A569ConfigLayoutCorpoPromissoriaPaciente = H009X4_A569ConfigLayoutCorpoPromissoriaPaciente[0];
               n569ConfigLayoutCorpoPromissoriaPaciente = H009X4_n569ConfigLayoutCorpoPromissoriaPaciente[0];
               A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = H009X4_A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo[0];
               n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = H009X4_n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo[0];
               A568ConfigLayoutCorpoPromissoriaClinicaTaxa = H009X4_A568ConfigLayoutCorpoPromissoriaClinicaTaxa[0];
               n568ConfigLayoutCorpoPromissoriaClinicaTaxa = H009X4_n568ConfigLayoutCorpoPromissoriaClinicaTaxa[0];
               A418ConfiguracoesLayoutContratoCorpo = H009X4_A418ConfiguracoesLayoutContratoCorpo[0];
               n418ConfiguracoesLayoutContratoCorpo = H009X4_n418ConfiguracoesLayoutContratoCorpo[0];
               A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = H009X4_A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo[0];
               n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = H009X4_n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo[0];
               A568ConfigLayoutCorpoPromissoriaClinicaTaxa = H009X4_A568ConfigLayoutCorpoPromissoriaClinicaTaxa[0];
               n568ConfigLayoutCorpoPromissoriaClinicaTaxa = H009X4_n568ConfigLayoutCorpoPromissoriaClinicaTaxa[0];
               A569ConfigLayoutCorpoPromissoriaPaciente = H009X4_A569ConfigLayoutCorpoPromissoriaPaciente[0];
               n569ConfigLayoutCorpoPromissoriaPaciente = H009X4_n569ConfigLayoutCorpoPromissoriaPaciente[0];
               if ( StringUtil.StrCmp(AV47PropostaContratoAssinaturaTipo, "Contrato") == 0 )
               {
                  AV9NomeContrato = StringUtil.Format( "PP_%1_%2", StringUtil.LTrimStr( (decimal)(AV46PropostaId), 9, 0), AV56PropostaPacienteClienteRazaoSocial, "", "", "", "", "", "", "");
                  AssignAttri("", false, "AV9NomeContrato", AV9NomeContrato);
                  AV8Corpo = A418ConfiguracoesLayoutContratoCorpo;
                  AssignAttri("", false, "AV8Corpo", AV8Corpo);
               }
               else if ( StringUtil.StrCmp(AV47PropostaContratoAssinaturaTipo, "Nota_promissoria") == 0 )
               {
                  AV9NomeContrato = StringUtil.Format( "Nota Promissória_%1_%2", StringUtil.LTrimStr( (decimal)(AV46PropostaId), 9, 0), AV56PropostaPacienteClienteRazaoSocial, "", "", "", "", "", "", "");
                  AssignAttri("", false, "AV9NomeContrato", AV9NomeContrato);
                  AV8Corpo = A569ConfigLayoutCorpoPromissoriaPaciente;
                  AssignAttri("", false, "AV8Corpo", AV8Corpo);
               }
               else if ( StringUtil.StrCmp(AV47PropostaContratoAssinaturaTipo, "Nota_promissoria_clinica") == 0 )
               {
                  AV9NomeContrato = StringUtil.Format( "Nota Promissória Clinica_%1_%2", StringUtil.LTrimStr( (decimal)(AV46PropostaId), 9, 0), AV56PropostaPacienteClienteRazaoSocial, "", "", "", "", "", "", "");
                  AssignAttri("", false, "AV9NomeContrato", AV9NomeContrato);
                  AV8Corpo = A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo;
                  AssignAttri("", false, "AV8Corpo", AV8Corpo);
               }
               else if ( StringUtil.StrCmp(AV47PropostaContratoAssinaturaTipo, "Nota_promissoria_clinica_taxa") == 0 )
               {
                  AV9NomeContrato = StringUtil.Format( "Nota Promissória Clinica Taxa_%1_%2", StringUtil.LTrimStr( (decimal)(AV46PropostaId), 9, 0), AV56PropostaPacienteClienteRazaoSocial, "", "", "", "", "", "", "");
                  AssignAttri("", false, "AV9NomeContrato", AV9NomeContrato);
                  AV8Corpo = A568ConfigLayoutCorpoPromissoriaClinicaTaxa;
                  AssignAttri("", false, "AV8Corpo", AV8Corpo);
               }
               pr_default.readNext(2);
            }
            pr_default.close(2);
            AV43HTML = AV8Corpo;
            new prtrocataghtml(context ).execute(  AV46PropostaId,  0, ref  AV43HTML) ;
            AV8Corpo = AV43HTML;
            AssignAttri("", false, "AV8Corpo", AV8Corpo);
            AV11SdParticipantes = new SdtSdParticipantes(context);
            AV51IsSemResponsavel = false;
            if ( ( StringUtil.StrCmp(AV47PropostaContratoAssinaturaTipo, "Contrato") == 0 ) || ( StringUtil.StrCmp(AV47PropostaContratoAssinaturaTipo, "Nota_promissoria") == 0 ) )
            {
               /* Using cursor H009X5 */
               pr_default.execute(3, new Object[] {AV52ResponsavelClienteId});
               while ( (pr_default.getStatus(3) != 101) )
               {
                  A168ClienteId = H009X5_A168ClienteId[0];
                  A172ClienteTipoPessoa = H009X5_A172ClienteTipoPessoa[0];
                  n172ClienteTipoPessoa = H009X5_n172ClienteTipoPessoa[0];
                  A169ClienteDocumento = H009X5_A169ClienteDocumento[0];
                  n169ClienteDocumento = H009X5_n169ClienteDocumento[0];
                  A201ContatoEmail = H009X5_A201ContatoEmail[0];
                  n201ContatoEmail = H009X5_n201ContatoEmail[0];
                  A170ClienteRazaoSocial = H009X5_A170ClienteRazaoSocial[0];
                  n170ClienteRazaoSocial = H009X5_n170ClienteRazaoSocial[0];
                  A447ResponsavelCPF = H009X5_A447ResponsavelCPF[0];
                  n447ResponsavelCPF = H009X5_n447ResponsavelCPF[0];
                  A456ResponsavelEmail = H009X5_A456ResponsavelEmail[0];
                  n456ResponsavelEmail = H009X5_n456ResponsavelEmail[0];
                  A436ResponsavelNome = H009X5_A436ResponsavelNome[0];
                  n436ResponsavelNome = H009X5_n436ResponsavelNome[0];
                  if ( StringUtil.StrCmp(A172ClienteTipoPessoa, "JURIDICA") == 0 )
                  {
                     AV11SdParticipantes.gxTpr_Assinaturaparticipantetipo = "Contratante";
                     AV11SdParticipantes.gxTpr_Participantedocumento = A169ClienteDocumento;
                     AV11SdParticipantes.gxTpr_Participanteemail = A201ContatoEmail;
                     AV11SdParticipantes.gxTpr_Participantenome = A170ClienteRazaoSocial;
                     AV11SdParticipantes.gxTpr_Participanterepresentantedocumento = A447ResponsavelCPF;
                     AV11SdParticipantes.gxTpr_Participanterepresentanteemail = A456ResponsavelEmail;
                     AV11SdParticipantes.gxTpr_Participanterepresentantenome = A436ResponsavelNome;
                     AV11SdParticipantes.gxTpr_Participantetipopessoa = "JURIDICA";
                     AV11SdParticipantes.gxTpr_Clienteid = AV55PropostaPacienteClienteId;
                     if ( String.IsNullOrEmpty(StringUtil.RTrim( A447ResponsavelCPF)) )
                     {
                        AV51IsSemResponsavel = true;
                     }
                  }
                  else
                  {
                     AV11SdParticipantes.gxTpr_Participantenome = A170ClienteRazaoSocial;
                     AV11SdParticipantes.gxTpr_Participantedocumento = A169ClienteDocumento;
                     AV11SdParticipantes.gxTpr_Participanteemail = A201ContatoEmail;
                     AV11SdParticipantes.gxTpr_Assinaturaparticipantetipo = "Contratante";
                     AV11SdParticipantes.gxTpr_Clienteid = AV55PropostaPacienteClienteId;
                  }
                  AV11SdParticipantes.gxTpr_Descricao = "Paciente";
                  if ( ! AV51IsSemResponsavel )
                  {
                     AV10Array_SdParticipantes.Add(AV11SdParticipantes, 0);
                  }
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(3);
            }
            if ( ( StringUtil.StrCmp(AV47PropostaContratoAssinaturaTipo, "Contrato") == 0 ) || ( StringUtil.StrCmp(AV47PropostaContratoAssinaturaTipo, "Nota_promissoria_clinica_taxa") == 0 ) || ( StringUtil.StrCmp(AV47PropostaContratoAssinaturaTipo, "Nota_promissoria_clinica") == 0 ) )
            {
               /* Using cursor H009X6 */
               pr_default.execute(4, new Object[] {AV53ClinicaClienteId});
               while ( (pr_default.getStatus(4) != 101) )
               {
                  A133SecUserId = H009X6_A133SecUserId[0];
                  A226SecUserOwnerId = H009X6_A226SecUserOwnerId[0];
                  n226SecUserOwnerId = H009X6_n226SecUserOwnerId[0];
                  AV54secuserownerid = A226SecUserOwnerId;
                  AssignAttri("", false, "AV54secuserownerid", StringUtil.LTrimStr( (decimal)(AV54secuserownerid), 9, 0));
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(4);
               /* Using cursor H009X7 */
               pr_default.execute(5, new Object[] {AV54secuserownerid});
               while ( (pr_default.getStatus(5) != 101) )
               {
                  A168ClienteId = H009X7_A168ClienteId[0];
                  A169ClienteDocumento = H009X7_A169ClienteDocumento[0];
                  n169ClienteDocumento = H009X7_n169ClienteDocumento[0];
                  A201ContatoEmail = H009X7_A201ContatoEmail[0];
                  n201ContatoEmail = H009X7_n201ContatoEmail[0];
                  A170ClienteRazaoSocial = H009X7_A170ClienteRazaoSocial[0];
                  n170ClienteRazaoSocial = H009X7_n170ClienteRazaoSocial[0];
                  A447ResponsavelCPF = H009X7_A447ResponsavelCPF[0];
                  n447ResponsavelCPF = H009X7_n447ResponsavelCPF[0];
                  A456ResponsavelEmail = H009X7_A456ResponsavelEmail[0];
                  n456ResponsavelEmail = H009X7_n456ResponsavelEmail[0];
                  A436ResponsavelNome = H009X7_A436ResponsavelNome[0];
                  n436ResponsavelNome = H009X7_n436ResponsavelNome[0];
                  AV11SdParticipantes = new SdtSdParticipantes(context);
                  AV11SdParticipantes.gxTpr_Assinaturaparticipantetipo = "Testemunha";
                  AV11SdParticipantes.gxTpr_Participantedocumento = A169ClienteDocumento;
                  AV11SdParticipantes.gxTpr_Participanteemail = A201ContatoEmail;
                  AV11SdParticipantes.gxTpr_Participantenome = A170ClienteRazaoSocial;
                  AV11SdParticipantes.gxTpr_Participanterepresentantedocumento = A447ResponsavelCPF;
                  AV11SdParticipantes.gxTpr_Participanterepresentanteemail = A456ResponsavelEmail;
                  AV11SdParticipantes.gxTpr_Participanterepresentantenome = A436ResponsavelNome;
                  AV11SdParticipantes.gxTpr_Participantetipopessoa = "JURIDICA";
                  AV11SdParticipantes.gxTpr_Assinaturaparticipantetipo = ((StringUtil.StrCmp(AV47PropostaContratoAssinaturaTipo, "Contrato")==0) ? "Testemunha" : "Sacado");
                  AV11SdParticipantes.gxTpr_Descricao = "Clinica";
                  AV11SdParticipantes.gxTpr_Clienteid = AV55PropostaPacienteClienteId;
                  AV10Array_SdParticipantes.Add(AV11SdParticipantes, 0);
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(5);
            }
            if ( AV51IsSemResponsavel )
            {
               GXt_char1 = "Cadastre um responsável para continuar.";
               new message(context ).gxep_erro( ref  GXt_char1) ;
            }
         }
      }

      private void E179X2( )
      {
         /* Freegrid_Load Routine */
         returnInSub = false;
         AV63GXV1 = 1;
         while ( AV63GXV1 <= AV10Array_SdParticipantes.Count )
         {
            AV11SdParticipantes = ((SdtSdParticipantes)AV10Array_SdParticipantes.Item(AV63GXV1));
            AV5NomeParticipante = AV11SdParticipantes.gxTpr_Participantenome;
            AssignAttri("", false, edtavNomeparticipante_Internalname, AV5NomeParticipante);
            AV13HTMLLine = StringUtil.Format( "<div class=\"participant-detail\"><span class=\"participant-label\">Função:</span> %1</div>", AV11SdParticipantes.gxTpr_Assinaturaparticipantetipo, "", "", "", "", "", "", "", "");
            if ( StringUtil.StrCmp(AV11SdParticipantes.gxTpr_Participantetipopessoa, "FISICA") == 0 )
            {
               AV13HTMLLine += StringUtil.Format( "<div class=\"participant-detail\"><span class=\"participant-label\">Email:</span> %1</div>", AV11SdParticipantes.gxTpr_Participanteemail, "", "", "", "", "", "", "", "");
               AV13HTMLLine += StringUtil.Format( "<div class=\"participant-detail\"><span class=\"participant-label\">CPF:</span> %1</div>", AV11SdParticipantes.gxTpr_Participantedocumento, "", "", "", "", "", "", "", "");
            }
            else
            {
               AV13HTMLLine += StringUtil.Format( "<div class=\"participant-detail\"><span class=\"participant-label\">Representante:</span> %1</div>", AV11SdParticipantes.gxTpr_Participanterepresentantenome, "", "", "", "", "", "", "", "");
               AV13HTMLLine += StringUtil.Format( "<div class=\"participant-detail\"><span class=\"participant-label\">Email:</span> %1</div>", AV11SdParticipantes.gxTpr_Participanterepresentanteemail, "", "", "", "", "", "", "", "");
               AV13HTMLLine += StringUtil.Format( "<div class=\"participant-detail\"><span class=\"participant-label\">CPF:</span> %1</div>", AV11SdParticipantes.gxTpr_Participanterepresentantedocumento, "", "", "", "", "", "", "", "");
            }
            lblParticipantelabel_Caption = AV13HTMLLine;
            AV14GRIDJSON = AV11SdParticipantes.ToJSonString(false, true);
            AssignAttri("", false, edtavGridjson_Internalname, AV14GRIDJSON);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 64;
            }
            sendrow_642( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_64_Refreshing )
            {
               DoAjaxLoad(64, FreegridRow);
            }
            AV63GXV1 = (int)(AV63GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      protected void E129X2( )
      {
         /* 'DoEnviarParaAssinatura' Routine */
         returnInSub = false;
         AV32IsHasContratante = false;
         AV33IsHasContratado = false;
         AV64GXV2 = 1;
         while ( AV64GXV2 <= AV10Array_SdParticipantes.Count )
         {
            AV11SdParticipantes = ((SdtSdParticipantes)AV10Array_SdParticipantes.Item(AV64GXV2));
            if ( StringUtil.StrCmp(AV11SdParticipantes.gxTpr_Assinaturaparticipantetipo, "Contratado") == 0 )
            {
               AV33IsHasContratado = true;
            }
            if ( StringUtil.StrCmp(AV11SdParticipantes.gxTpr_Assinaturaparticipantetipo, "Contratante") == 0 )
            {
               AV32IsHasContratante = true;
            }
            AV64GXV2 = (int)(AV64GXV2+1);
         }
         if ( ! AV32IsHasContratante )
         {
            GXt_char1 = "É obrigatório ter pelo menos 1 (um) contratante";
            new message(context ).gxep_erro( ref  GXt_char1) ;
         }
         if ( ! AV33IsHasContratado )
         {
            GXt_char1 = "É obrigatório ter pelo menos 1 (um) contratado";
            new message(context ).gxep_erro( ref  GXt_char1) ;
         }
         AV44IsArqOk = true;
         if ( AV30Tipo )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV29StringBase64)) )
            {
               GXt_char1 = "Selecione um arquivo";
               new message(context ).gxep_erro( ref  GXt_char1) ;
               AV44IsArqOk = false;
            }
         }
         else
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV8Corpo)) )
            {
               GXt_char1 = "Não é possivel enviar corpo em branco para assinatura";
               new message(context ).gxep_erro( ref  GXt_char1) ;
               AV44IsArqOk = false;
            }
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9NomeContrato)) )
         {
            GXt_char1 = "Digite o nome do contrato";
            new message(context ).gxep_erro( ref  GXt_char1) ;
         }
         if ( AV33IsHasContratado && AV32IsHasContratante && AV44IsArqOk && ! String.IsNullOrEmpty(StringUtil.RTrim( AV9NomeContrato)) )
         {
            AV38Contrato = new SdtContrato(context);
            AV38Contrato.Load(AV39ContratoId);
            AV38Contrato.gxTpr_Contratonome = AV9NomeContrato;
            AV21GUID = Guid.NewGuid( );
            AV34File.Source = "./PublicTempStorage/"+AV21GUID.ToString()+".html";
            AV34File.Create();
            AV43HTML = "<html><head> <meta charset=\"UTF-8\"> <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\"></head><body>" + AV8Corpo + "</body></html>";
            AV34File.WriteAllText(AV43HTML, "UTF8");
            AV21GUID = Guid.NewGuid( );
            AV35PdfPath = "./PublicTempStorage/" + AV21GUID.ToString() + ".pdf";
            AV36PdfFile.Source = AV35PdfPath;
            new prcriarpdffromhtml(context ).execute(  AV34File.GetAbsoluteName(),  AV36PdfFile.GetAbsoluteName(), out  AV41ErroMsg) ;
            if ( StringUtil.StrCmp(AV41ErroMsg, "PDF gerado com sucesso!") == 0 )
            {
               AV37Blob = AV36PdfFile.GetAbsoluteName();
               AssignAttri("", false, "AV37Blob", AV37Blob);
            }
            AV38Contrato.gxTpr_Contratocorpo = AV8Corpo;
            AV38Contrato.gxTpr_Contratoclienteid = AV25ClienteId;
            AV38Contrato.gxTpr_Contratosituacao = "ColetandoAssinatura";
            AV38Contrato.Save();
            if ( AV38Contrato.Success() )
            {
               AV42AuxArray_SdParticipantes = new GXBaseCollection<SdtSdParticipantes>( context, "SdParticipantes", "Factory21");
               AV65GXV3 = 1;
               while ( AV65GXV3 <= AV10Array_SdParticipantes.Count )
               {
                  AV11SdParticipantes = ((SdtSdParticipantes)AV10Array_SdParticipantes.Item(AV65GXV3));
                  AV11SdParticipantes.gxTpr_Participanteid = 0;
                  AV42AuxArray_SdParticipantes.Add(AV11SdParticipantes, 0);
                  AV65GXV3 = (int)(AV65GXV3+1);
               }
               new prsendsignatureaux(context ).execute(  AV37Blob,  AV9NomeContrato,  AV10Array_SdParticipantes,  AV46PropostaId,  AV47PropostaContratoAssinaturaTipo, out  AV40SdErro, out  AV48PropostaContratoAssinaturaId) ;
               if ( AV40SdErro.gxTpr_Status != 200 )
               {
                  GXt_char1 = AV40SdErro.gxTpr_Msg;
                  new message(context ).gxep_erro( ref  GXt_char1) ;
                  AV40SdErro.gxTpr_Msg = GXt_char1;
               }
               else
               {
                  if ( ! ( StringUtil.StrCmp(AV47PropostaContratoAssinaturaTipo, "Documento") == 0 ) )
                  {
                     /* Using cursor H009X8 */
                     pr_default.execute(6, new Object[] {AV46PropostaId, AV47PropostaContratoAssinaturaTipo});
                     while ( (pr_default.getStatus(6) != 101) )
                     {
                        A573PropostaContratoAssinaturaTipo = H009X8_A573PropostaContratoAssinaturaTipo[0];
                        n573PropostaContratoAssinaturaTipo = H009X8_n573PropostaContratoAssinaturaTipo[0];
                        A323PropostaId = H009X8_A323PropostaId[0];
                        n323PropostaId = H009X8_n323PropostaId[0];
                        A571PropostaAssinatura = H009X8_A571PropostaAssinatura[0];
                        n571PropostaAssinatura = H009X8_n571PropostaAssinatura[0];
                        if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
                        {
                           gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
                        }
                        GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
                        GXEncryptionTmp = "wpassinaturas"+UrlEncode(StringUtil.LTrimStr(A571PropostaAssinatura,10,0));
                        CallWebObject(formatLink("wpassinaturas") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
                        context.wjLocDisableFrm = 1;
                        pr_default.readNext(6);
                     }
                     pr_default.close(6);
                  }
                  else
                  {
                     AV49ReembolsoAssinaturas = new SdtReembolsoAssinaturas(context);
                     AV49ReembolsoAssinaturas.gxTpr_Reembolsoid = AV50ReembolsoId;
                     AV49ReembolsoAssinaturas.gxTpr_Propostacontratoassinaturaid = AV48PropostaContratoAssinaturaId;
                     AV49ReembolsoAssinaturas.gxTpr_Reembolsoassinaturasnome = AV9NomeContrato;
                     AV49ReembolsoAssinaturas.gxTpr_Reembolsoassinaturasemissao = DateTimeUtil.ServerNow( context, pr_default);
                     AV49ReembolsoAssinaturas.Save();
                     if ( AV49ReembolsoAssinaturas.Success() )
                     {
                        context.CommitDataStores("assinarcontratopropostas",pr_default);
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
               GXt_char1 = ((GeneXus.Utils.SdtMessages_Message)AV38Contrato.GetMessages().Item(1)).gxTpr_Description;
               new message(context ).gxep_erro( ref  GXt_char1) ;
               ((GeneXus.Utils.SdtMessages_Message)AV38Contrato.GetMessages().Item(1)).gxTpr_Description = GXt_char1;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10Array_SdParticipantes", AV10Array_SdParticipantes);
      }

      protected void E149X2( )
      {
         /* 'DoEditar' Routine */
         returnInSub = false;
         AV21GUID = Guid.NewGuid( );
         AV20WEBSESSIon.Set(AV21GUID.ToString(), AV10Array_SdParticipantes.ToJSonString(false));
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "novoparticipanteassinatura"+UrlEncode(StringUtil.RTrim(AV14GRIDJSON)) + "," + UrlEncode(StringUtil.RTrim(AV21GUID.ToString()));
         context.PopUp(formatLink("novoparticipanteassinatura") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
      }

      protected void E159X2( )
      {
         /* 'DoRetirar' Routine */
         returnInSub = false;
         AV15AuxSdParticipantes = new SdtSdParticipantes(context);
         AV15AuxSdParticipantes.FromJSonString(AV14GRIDJSON, null);
         AV16i = 0;
         AV67GXV4 = 1;
         while ( AV67GXV4 <= AV10Array_SdParticipantes.Count )
         {
            AV11SdParticipantes = ((SdtSdParticipantes)AV10Array_SdParticipantes.Item(AV67GXV4));
            AV16i = (short)(AV16i+1);
            if ( ( StringUtil.StrCmp(AV11SdParticipantes.gxTpr_Participantedocumento, AV15AuxSdParticipantes.gxTpr_Participantedocumento) == 0 ) && ( StringUtil.StrCmp(AV11SdParticipantes.gxTpr_Participanterepresentantedocumento, AV15AuxSdParticipantes.gxTpr_Participanterepresentantedocumento) == 0 ) )
            {
               AV10Array_SdParticipantes.RemoveItem(AV16i);
               if (true) break;
            }
            AV67GXV4 = (int)(AV67GXV4+1);
         }
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10Array_SdParticipantes", AV10Array_SdParticipantes);
      }

      protected void E139X2( )
      {
         /* 'DoAdicionarParticipante' Routine */
         returnInSub = false;
         AV17InJSON = "";
         AV18Array_JSON = AV10Array_SdParticipantes.ToJSonString(false);
         AV21GUID = Guid.NewGuid( );
         AV20WEBSESSIon.Set(AV21GUID.ToString(), AV10Array_SdParticipantes.ToJSonString(false));
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "novoparticipanteassinatura"+UrlEncode(StringUtil.RTrim(AV17InJSON)) + "," + UrlEncode(StringUtil.RTrim(AV21GUID.ToString()));
         context.PopUp(formatLink("novoparticipanteassinatura") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         context.DoAjaxRefresh();
      }

      protected void E119X2( )
      {
         /* Combo_layoutcontratoid_Onoptionclicked Routine */
         returnInSub = false;
         AV22LayoutContratoId = (short)(Math.Round(NumberUtil.Val( Combo_layoutcontratoid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV22LayoutContratoId", StringUtil.LTrimStr( (decimal)(AV22LayoutContratoId), 4, 0));
         if ( ! (0==AV22LayoutContratoId) )
         {
            /* Using cursor H009X9 */
            pr_default.execute(7, new Object[] {AV22LayoutContratoId});
            while ( (pr_default.getStatus(7) != 101) )
            {
               A154LayoutContratoId = H009X9_A154LayoutContratoId[0];
               A157LayoutContratoCorpo = H009X9_A157LayoutContratoCorpo[0];
               n157LayoutContratoCorpo = H009X9_n157LayoutContratoCorpo[0];
               AV8Corpo = A157LayoutContratoCorpo;
               AssignAttri("", false, "AV8Corpo", AV8Corpo);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(7);
         }
         else
         {
            AV8Corpo = "";
            AssignAttri("", false, "AV8Corpo", AV8Corpo);
         }
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ! ( ( StringUtil.StrCmp(AV47PropostaContratoAssinaturaTipo, "Documento") == 0 ) ) )
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
         /* Using cursor H009X10 */
         pr_default.execute(8);
         while ( (pr_default.getStatus(8) != 101) )
         {
            A906LayoutContratoTipo = H009X10_A906LayoutContratoTipo[0];
            n906LayoutContratoTipo = H009X10_n906LayoutContratoTipo[0];
            A156LayoutContratoStatus = H009X10_A156LayoutContratoStatus[0];
            n156LayoutContratoStatus = H009X10_n156LayoutContratoStatus[0];
            A154LayoutContratoId = H009X10_A154LayoutContratoId[0];
            A155LayoutContratoDescricao = H009X10_A155LayoutContratoDescricao[0];
            n155LayoutContratoDescricao = H009X10_n155LayoutContratoDescricao[0];
            AV24Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV24Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A154LayoutContratoId), 4, 0));
            AV24Combo_DataItem.gxTpr_Title = A155LayoutContratoDescricao;
            AV23LayoutContratoId_Data.Add(AV24Combo_DataItem, 0);
            pr_default.readNext(8);
         }
         pr_default.close(8);
         Combo_layoutcontratoid_Selectedvalue_set = ((0==AV22LayoutContratoId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV22LayoutContratoId), 4, 0)));
         ucCombo_layoutcontratoid.SendProperty(context, "", false, Combo_layoutcontratoid_Internalname, "SelectedValue_set", Combo_layoutcontratoid_Selectedvalue_set);
      }

      protected void wb_table1_9_9X2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedbtn_cancel_Internalname, tblTablemergedbtn_cancel_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 12,'',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(64), 2, 0)+","+"null"+");", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_AssinarContratoPropostas.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenviarparaassinatura_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(64), 2, 0)+","+"null"+");", "Enviar para assinatura", bttBtnenviarparaassinatura_Jsonclick, 5, "Enviar para assinatura", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOENVIARPARAASSINATURA\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_AssinarContratoPropostas.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_9_9X2e( true) ;
         }
         else
         {
            wb_table1_9_9X2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV46PropostaId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV46PropostaId", StringUtil.LTrimStr( (decimal)(AV46PropostaId), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV46PropostaId), "ZZZZZZZZ9"), context));
         AV47PropostaContratoAssinaturaTipo = (string)getParm(obj,1);
         AssignAttri("", false, "AV47PropostaContratoAssinaturaTipo", AV47PropostaContratoAssinaturaTipo);
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTACONTRATOASSINATURATIPO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV47PropostaContratoAssinaturaTipo, "")), context));
         AV50ReembolsoId = Convert.ToInt32(getParm(obj,2));
         AssignAttri("", false, "AV50ReembolsoId", StringUtil.LTrimStr( (decimal)(AV50ReembolsoId), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV50ReembolsoId), "ZZZZZZZZ9"), context));
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
         PA9X2( ) ;
         WS9X2( ) ;
         WE9X2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101929679", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("messages.por.js", "?"+GetCacheInvalidationToken( ), false, true);
            context.AddJavascriptSource("assinarcontratopropostas.js", "?20256101929679", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
            context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
            context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_642( )
      {
         edtavNomeparticipante_Internalname = "vNOMEPARTICIPANTE_"+sGXsfl_64_idx;
         lblParticipantelabel_Internalname = "PARTICIPANTELABEL_"+sGXsfl_64_idx;
         edtavGridjson_Internalname = "vGRIDJSON_"+sGXsfl_64_idx;
      }

      protected void SubsflControlProps_fel_642( )
      {
         edtavNomeparticipante_Internalname = "vNOMEPARTICIPANTE_"+sGXsfl_64_fel_idx;
         lblParticipantelabel_Internalname = "PARTICIPANTELABEL_"+sGXsfl_64_fel_idx;
         edtavGridjson_Internalname = "vGRIDJSON_"+sGXsfl_64_fel_idx;
      }

      protected void sendrow_642( )
      {
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_642( ) ;
         WB9X0( ) ;
         FreegridRow = GXWebRow.GetNew(context,FreegridContainer);
         if ( subFreegrid_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subFreegrid_Backstyle = 0;
            if ( StringUtil.StrCmp(subFreegrid_Class, "") != 0 )
            {
               subFreegrid_Linesclass = subFreegrid_Class+"Odd";
            }
         }
         else if ( subFreegrid_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subFreegrid_Backstyle = 0;
            subFreegrid_Backcolor = subFreegrid_Allbackcolor;
            if ( StringUtil.StrCmp(subFreegrid_Class, "") != 0 )
            {
               subFreegrid_Linesclass = subFreegrid_Class+"Uniform";
            }
         }
         else if ( subFreegrid_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subFreegrid_Backstyle = 1;
            if ( StringUtil.StrCmp(subFreegrid_Class, "") != 0 )
            {
               subFreegrid_Linesclass = subFreegrid_Class+"Odd";
            }
            subFreegrid_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subFreegrid_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subFreegrid_Backstyle = 1;
            subFreegrid_Backcolor = (int)(0xFFFFFF);
            if ( StringUtil.StrCmp(subFreegrid_Class, "") != 0 )
            {
               subFreegrid_Linesclass = subFreegrid_Class+"Odd";
            }
         }
         /* Start of Columns property logic. */
         /* Div Control */
         FreegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divFreegridlayouttable_Internalname+"_"+sGXsfl_64_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"participant-card",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Div Control */
         FreegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Div Control */
         FreegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Div Control */
         FreegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divParticipantenome_Internalname+"_"+sGXsfl_64_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"participant-name",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Div Control */
         FreegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Div Control */
         FreegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Div Control */
         FreegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Attribute/Variable Label */
         FreegridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavNomeparticipante_Internalname,(string)"Nome Participante",(string)"col-sm-3 AttributeFLLabel",(short)0,(bool)true,(string)""});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'" + sGXsfl_64_idx + "',64)\"";
         ROClassString = "AttributeFL";
         FreegridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavNomeparticipante_Internalname,(string)AV5NomeParticipante,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,72);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavNomeparticipante_Jsonclick,(short)0,(string)"AttributeFL",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavNomeparticipante_Enabled,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)100,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         FreegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         FreegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         FreegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Div Control */
         FreegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Div Control */
         FreegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Text block */
         FreegridRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblParticipantelabel_Internalname,(string)lblParticipantelabel_Caption,(string)"",(string)"",(string)lblParticipantelabel_Jsonclick,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)2});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         FreegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         FreegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         FreegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         FreegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         FreegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Div Control */
         FreegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Div Control */
         FreegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Div Control */
         FreegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divParticipanteacoes_Internalname+"_"+sGXsfl_64_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"participant-actions",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Div Control */
         FreegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Div Control */
         FreegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         FreegridRow.AddColumnProperties("button", 2, isAjaxCallMode( ), new Object[] {(string)bttBtneditar_Internalname+"_"+sGXsfl_64_idx,"gx.evt.setGridEvt("+StringUtil.Str( (decimal)(64), 2, 0)+","+"null"+");",(string)"Editar",(string)bttBtneditar_Jsonclick,(short)5,(string)"Editar",(string)"",(string)StyleString,(string)ClassString,(short)1,(short)1,(string)"standard","'"+""+"'"+",false,"+"'"+"E\\'DOEDITAR\\'."+"'",(string)TempTags,(string)"",context.GetButtonType( )});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         FreegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         FreegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Div Control */
         FreegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Div Control */
         FreegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         FreegridRow.AddColumnProperties("button", 2, isAjaxCallMode( ), new Object[] {(string)bttBtnretirar_Internalname+"_"+sGXsfl_64_idx,"gx.evt.setGridEvt("+StringUtil.Str( (decimal)(64), 2, 0)+","+"null"+");",(string)"Retirar",(string)bttBtnretirar_Jsonclick,(short)5,(string)"Retirar",(string)"",(string)StyleString,(string)ClassString,(short)1,(short)1,(string)"standard","'"+""+"'"+",false,"+"'"+"E\\'DORETIRAR\\'."+"'",(string)TempTags,(string)"",context.GetButtonType( )});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         FreegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         FreegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         FreegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         FreegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         FreegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Div Control */
         FreegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Div Control */
         FreegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 Invisible",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Table start */
         FreegridRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblUnnamedtablecontentfsfreegrid_Internalname+"_"+sGXsfl_64_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         FreegridRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         FreegridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Div Control */
         FreegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Attribute/Variable Label */
         FreegridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavGridjson_Internalname,(string)"GRIDJSON",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Multiple line edit */
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         FreegridRow.AddColumnProperties("html_textarea", 1, isAjaxCallMode( ), new Object[] {(string)edtavGridjson_Internalname,(string)AV14GRIDJSON,(string)"",(string)"",(short)0,(int)edtavGridjson_Visible,(short)0,(short)0,(short)80,(string)"chr",(short)10,(string)"row",(short)0,(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"2097152",(short)-1,(short)0,(string)"",(string)"",(short)-1,(bool)true,(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(short)0,(string)""});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         FreegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         if ( FreegridContainer.GetWrapped() == 1 )
         {
            FreegridContainer.CloseTag("cell");
         }
         if ( FreegridContainer.GetWrapped() == 1 )
         {
            FreegridContainer.CloseTag("row");
         }
         if ( FreegridContainer.GetWrapped() == 1 )
         {
            FreegridContainer.CloseTag("table");
         }
         /* End of table */
         FreegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         FreegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         FreegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         send_integrity_lvl_hashes9X2( ) ;
         /* End of Columns property logic. */
         FreegridContainer.AddRow(FreegridRow);
         nGXsfl_64_idx = ((subFreegrid_Islastpage==1)&&(nGXsfl_64_idx+1>subFreegrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_64_idx+1);
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_642( ) ;
         /* End function sendrow_642 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl64( )
      {
         if ( FreegridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"FreegridContainer"+"DivS\" data-gxgridid=\"64\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subFreegrid_Internalname, subFreegrid_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            FreegridContainer.AddObjectProperty("GridName", "Freegrid");
         }
         else
         {
            FreegridContainer.AddObjectProperty("GridName", "Freegrid");
            FreegridContainer.AddObjectProperty("Header", subFreegrid_Header);
            FreegridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            FreegridContainer.AddObjectProperty("Class", "FreeStyleGrid");
            FreegridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            FreegridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            FreegridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreegrid_Backcolorstyle), 1, 0, ".", "")));
            FreegridContainer.AddObjectProperty("CmpContext", "");
            FreegridContainer.AddObjectProperty("InMasterPage", "false");
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV5NomeParticipante));
            FreegridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNomeparticipante_Enabled), 5, 0, ".", "")));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridColumn.AddObjectProperty("Value", lblParticipantelabel_Caption);
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV14GRIDJSON));
            FreegridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavGridjson_Visible), 5, 0, ".", "")));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreegrid_Selectedindex), 4, 0, ".", "")));
            FreegridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreegrid_Allowselection), 1, 0, ".", "")));
            FreegridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreegrid_Selectioncolor), 9, 0, ".", "")));
            FreegridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreegrid_Allowhovering), 1, 0, ".", "")));
            FreegridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreegrid_Hoveringcolor), 9, 0, ".", "")));
            FreegridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreegrid_Allowcollapsing), 1, 0, ".", "")));
            FreegridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreegrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtnenviarparaassinatura_Internalname = "BTNENVIARPARAASSINATURA";
         tblTablemergedbtn_cancel_Internalname = "TABLEMERGEDBTN_CANCEL";
         divTablecontentitens_Internalname = "TABLECONTENTITENS";
         lblTextblockcombo_layoutcontratoid_Internalname = "TEXTBLOCKCOMBO_LAYOUTCONTRATOID";
         Combo_layoutcontratoid_Internalname = "COMBO_LAYOUTCONTRATOID";
         divTablesplittedlayoutcontratoid_Internalname = "TABLESPLITTEDLAYOUTCONTRATOID";
         divCombo_layoutcontratoid_cell_Internalname = "COMBO_LAYOUTCONTRATOID_CELL";
         edtavNomecontrato_Internalname = "vNOMECONTRATO";
         Corpo_Internalname = "CORPO";
         divTablecontractbody_Internalname = "TABLECONTRACTBODY";
         divEditor_Internalname = "EDITOR";
         lblLbl_Internalname = "LBL";
         bttBtnadicionarparticipante_Internalname = "BTNADICIONARPARTICIPANTE";
         divParticipantestitle_Internalname = "PARTICIPANTESTITLE";
         edtavNomeparticipante_Internalname = "vNOMEPARTICIPANTE";
         lblParticipantelabel_Internalname = "PARTICIPANTELABEL";
         divParticipantenome_Internalname = "PARTICIPANTENOME";
         bttBtneditar_Internalname = "BTNEDITAR";
         bttBtnretirar_Internalname = "BTNRETIRAR";
         divParticipanteacoes_Internalname = "PARTICIPANTEACOES";
         edtavGridjson_Internalname = "vGRIDJSON";
         tblUnnamedtablecontentfsfreegrid_Internalname = "UNNAMEDTABLECONTENTFSFREEGRID";
         divFreegridlayouttable_Internalname = "FREEGRIDLAYOUTTABLE";
         divLbl_Internalname = "PARTICIPANTES";
         divContractpage_Internalname = "CONTRACTPAGE";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         edtavLayoutcontratoid_Internalname = "vLAYOUTCONTRATOID";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subFreegrid_Internalname = "FREEGRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("DSAssinatura", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subFreegrid_Allowcollapsing = 0;
         lblParticipantelabel_Caption = "<span class=\"participant-label\">Função:</span>";
         lblParticipantelabel_Caption = "<span class=\"participant-label\">Função:</span>";
         edtavNomeparticipante_Jsonclick = "";
         edtavNomeparticipante_Enabled = 0;
         subFreegrid_Backcolorstyle = 0;
         edtavLayoutcontratoid_Jsonclick = "";
         edtavLayoutcontratoid_Visible = 1;
         Corpo_Enabled = Convert.ToBoolean( 1);
         edtavNomecontrato_Jsonclick = "";
         edtavNomecontrato_Enabled = 1;
         divCombo_layoutcontratoid_cell_Class = "col-xs-12";
         subFreegrid_Flexdirection = "column";
         subFreegrid_Class = "FreeStyleGrid";
         Corpo_Captionposition = "Left";
         Corpo_Captionstyle = "";
         Corpo_Captionclass = "col-sm-3 AttributeLabel";
         Combo_layoutcontratoid_Emptyitem = Convert.ToBoolean( 0);
         Combo_layoutcontratoid_Visible = Convert.ToBoolean( -1);
         Combo_layoutcontratoid_Cls = "ExtendedCombo AttributeFL";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Assinar Contrato";
         edtavGridjson_Visible = 1;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"FREEGRID_nFirstRecordOnPage","type":"int"},{"av":"FREEGRID_nEOF","type":"int"},{"av":"edtavGridjson_Visible","ctrl":"vGRIDJSON","prop":"Visible"},{"av":"AV10Array_SdParticipantes","fld":"vARRAY_SDPARTICIPANTES","type":""},{"av":"AV30Tipo","fld":"vTIPO","hsh":true,"type":"boolean"},{"av":"AV29StringBase64","fld":"vSTRINGBASE64","hsh":true,"type":"vchar"},{"av":"AV39ContratoId","fld":"vCONTRATOID","pic":"ZZZZZ9","hsh":true,"type":"int"},{"av":"AV25ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV46PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV47PropostaContratoAssinaturaTipo","fld":"vPROPOSTACONTRATOASSINATURATIPO","hsh":true,"type":"svchar"},{"av":"AV50ReembolsoId","fld":"vREEMBOLSOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("FREEGRID.LOAD","""{"handler":"E179X2","iparms":[{"av":"AV10Array_SdParticipantes","fld":"vARRAY_SDPARTICIPANTES","type":""}]""");
         setEventMetadata("FREEGRID.LOAD",""","oparms":[{"av":"AV5NomeParticipante","fld":"vNOMEPARTICIPANTE","type":"svchar"},{"av":"lblParticipantelabel_Caption","ctrl":"PARTICIPANTELABEL","prop":"Caption"},{"av":"AV14GRIDJSON","fld":"vGRIDJSON","type":"vchar"}]}""");
         setEventMetadata("'DOENVIARPARAASSINATURA'","""{"handler":"E129X2","iparms":[{"av":"AV10Array_SdParticipantes","fld":"vARRAY_SDPARTICIPANTES","type":""},{"av":"AV30Tipo","fld":"vTIPO","hsh":true,"type":"boolean"},{"av":"AV29StringBase64","fld":"vSTRINGBASE64","hsh":true,"type":"vchar"},{"av":"AV8Corpo","fld":"vCORPO","type":"vchar"},{"av":"AV9NomeContrato","fld":"vNOMECONTRATO","type":"svchar"},{"av":"AV39ContratoId","fld":"vCONTRATOID","pic":"ZZZZZ9","hsh":true,"type":"int"},{"av":"AV25ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV37Blob","fld":"vBLOB","type":"bitstr"},{"av":"AV46PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV47PropostaContratoAssinaturaTipo","fld":"vPROPOSTACONTRATOASSINATURATIPO","hsh":true,"type":"svchar"},{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A573PropostaContratoAssinaturaTipo","fld":"PROPOSTACONTRATOASSINATURATIPO","type":"svchar"},{"av":"A571PropostaAssinatura","fld":"PROPOSTAASSINATURA","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV50ReembolsoId","fld":"vREEMBOLSOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("'DOENVIARPARAASSINATURA'",""","oparms":[{"av":"AV37Blob","fld":"vBLOB","type":"bitstr"},{"av":"AV10Array_SdParticipantes","fld":"vARRAY_SDPARTICIPANTES","type":""}]}""");
         setEventMetadata("'DOEDITAR'","""{"handler":"E149X2","iparms":[{"av":"AV10Array_SdParticipantes","fld":"vARRAY_SDPARTICIPANTES","type":""},{"av":"AV14GRIDJSON","fld":"vGRIDJSON","type":"vchar"}]}""");
         setEventMetadata("'DORETIRAR'","""{"handler":"E159X2","iparms":[{"av":"FREEGRID_nFirstRecordOnPage","type":"int"},{"av":"FREEGRID_nEOF","type":"int"},{"av":"edtavGridjson_Visible","ctrl":"vGRIDJSON","prop":"Visible"},{"av":"AV10Array_SdParticipantes","fld":"vARRAY_SDPARTICIPANTES","type":""},{"av":"AV30Tipo","fld":"vTIPO","hsh":true,"type":"boolean"},{"av":"AV29StringBase64","fld":"vSTRINGBASE64","hsh":true,"type":"vchar"},{"av":"AV39ContratoId","fld":"vCONTRATOID","pic":"ZZZZZ9","hsh":true,"type":"int"},{"av":"AV25ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV46PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV47PropostaContratoAssinaturaTipo","fld":"vPROPOSTACONTRATOASSINATURATIPO","hsh":true,"type":"svchar"},{"av":"AV50ReembolsoId","fld":"vREEMBOLSOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV14GRIDJSON","fld":"vGRIDJSON","type":"vchar"}]""");
         setEventMetadata("'DORETIRAR'",""","oparms":[{"av":"AV10Array_SdParticipantes","fld":"vARRAY_SDPARTICIPANTES","type":""}]}""");
         setEventMetadata("'DOADICIONARPARTICIPANTE'","""{"handler":"E139X2","iparms":[{"av":"FREEGRID_nFirstRecordOnPage","type":"int"},{"av":"FREEGRID_nEOF","type":"int"},{"av":"edtavGridjson_Visible","ctrl":"vGRIDJSON","prop":"Visible"},{"av":"AV10Array_SdParticipantes","fld":"vARRAY_SDPARTICIPANTES","type":""},{"av":"AV30Tipo","fld":"vTIPO","hsh":true,"type":"boolean"},{"av":"AV29StringBase64","fld":"vSTRINGBASE64","hsh":true,"type":"vchar"},{"av":"AV39ContratoId","fld":"vCONTRATOID","pic":"ZZZZZ9","hsh":true,"type":"int"},{"av":"AV25ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV46PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV47PropostaContratoAssinaturaTipo","fld":"vPROPOSTACONTRATOASSINATURATIPO","hsh":true,"type":"svchar"},{"av":"AV50ReembolsoId","fld":"vREEMBOLSOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("COMBO_LAYOUTCONTRATOID.ONOPTIONCLICKED","""{"handler":"E119X2","iparms":[{"av":"Combo_layoutcontratoid_Selectedvalue_get","ctrl":"COMBO_LAYOUTCONTRATOID","prop":"SelectedValue_get"},{"av":"A154LayoutContratoId","fld":"LAYOUTCONTRATOID","pic":"ZZZ9","type":"int"},{"av":"A157LayoutContratoCorpo","fld":"LAYOUTCONTRATOCORPO","type":"vchar"}]""");
         setEventMetadata("COMBO_LAYOUTCONTRATOID.ONOPTIONCLICKED",""","oparms":[{"av":"AV22LayoutContratoId","fld":"vLAYOUTCONTRATOID","pic":"ZZZ9","type":"int"},{"av":"AV8Corpo","fld":"vCORPO","type":"vchar"}]}""");
         setEventMetadata("VALIDV_LAYOUTCONTRATOID","""{"handler":"Validv_Layoutcontratoid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Gridjson","iparms":[]}""");
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
         wcpOAV47PropostaContratoAssinaturaTipo = "";
         Combo_layoutcontratoid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV10Array_SdParticipantes = new GXBaseCollection<SdtSdParticipantes>( context, "SdParticipantes", "Factory21");
         AV29StringBase64 = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV23LayoutContratoId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV8Corpo = "";
         AV37Blob = "";
         A573PropostaContratoAssinaturaTipo = "";
         A157LayoutContratoCorpo = "";
         AV12JSON = "";
         AV15AuxSdParticipantes = new SdtSdParticipantes(context);
         AV11SdParticipantes = new SdtSdParticipantes(context);
         Combo_layoutcontratoid_Selectedvalue_set = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         lblTextblockcombo_layoutcontratoid_Jsonclick = "";
         ucCombo_layoutcontratoid = new GXUserControl();
         Combo_layoutcontratoid_Caption = "";
         TempTags = "";
         AV9NomeContrato = "";
         ucCorpo = new GXUserControl();
         lblLbl_Jsonclick = "";
         bttBtnadicionarparticipante_Jsonclick = "";
         FreegridContainer = new GXWebGrid( context);
         sStyleString = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV5NomeParticipante = "";
         AV14GRIDJSON = "";
         GXDecQS = "";
         H009X2_A249EmpresaId = new int[1] ;
         H009X2_A773EmpresaUtilizaRepresentanteAssinatura = new bool[] {false} ;
         H009X2_n773EmpresaUtilizaRepresentanteAssinatura = new bool[] {false} ;
         H009X2_A252EmpresaCNPJ = new string[] {""} ;
         H009X2_n252EmpresaCNPJ = new bool[] {false} ;
         H009X2_A470EmpresaEmail = new string[] {""} ;
         H009X2_n470EmpresaEmail = new bool[] {false} ;
         H009X2_A251EmpresaRazaoSocial = new string[] {""} ;
         H009X2_n251EmpresaRazaoSocial = new bool[] {false} ;
         H009X2_A770EmpresaRepresentanteCPF = new string[] {""} ;
         H009X2_n770EmpresaRepresentanteCPF = new bool[] {false} ;
         H009X2_A772EmpresaRepresentanteEmail = new string[] {""} ;
         H009X2_n772EmpresaRepresentanteEmail = new bool[] {false} ;
         H009X2_A771EmpresaRepresentanteNome = new string[] {""} ;
         H009X2_n771EmpresaRepresentanteNome = new bool[] {false} ;
         A252EmpresaCNPJ = "";
         A470EmpresaEmail = "";
         A251EmpresaRazaoSocial = "";
         A770EmpresaRepresentanteCPF = "";
         A772EmpresaRepresentanteEmail = "";
         A771EmpresaRepresentanteNome = "";
         H009X3_A323PropostaId = new int[1] ;
         H009X3_n323PropostaId = new bool[] {false} ;
         H009X3_A504PropostaPacienteClienteId = new int[1] ;
         H009X3_n504PropostaPacienteClienteId = new bool[] {false} ;
         H009X3_A553PropostaResponsavelId = new int[1] ;
         H009X3_n553PropostaResponsavelId = new bool[] {false} ;
         H009X3_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         H009X3_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         H009X3_A328PropostaCratedBy = new short[1] ;
         H009X3_n328PropostaCratedBy = new bool[] {false} ;
         A505PropostaPacienteClienteRazaoSocial = "";
         AV56PropostaPacienteClienteRazaoSocial = "";
         H009X4_A299ConfiguracoesId = new int[1] ;
         H009X4_A398ConfiguracoesLayoutProposta = new short[1] ;
         H009X4_n398ConfiguracoesLayoutProposta = new bool[] {false} ;
         H009X4_A564ConfigLayoutPromissoriaClinicaEmprestimo = new short[1] ;
         H009X4_n564ConfigLayoutPromissoriaClinicaEmprestimo = new bool[] {false} ;
         H009X4_A565ConfigLayoutPromissoriaClinicaTaxa = new short[1] ;
         H009X4_n565ConfigLayoutPromissoriaClinicaTaxa = new bool[] {false} ;
         H009X4_A566ConfigLayoutPromissoriaPaciente = new short[1] ;
         H009X4_n566ConfigLayoutPromissoriaPaciente = new bool[] {false} ;
         H009X4_A418ConfiguracoesLayoutContratoCorpo = new string[] {""} ;
         H009X4_n418ConfiguracoesLayoutContratoCorpo = new bool[] {false} ;
         H009X4_A569ConfigLayoutCorpoPromissoriaPaciente = new string[] {""} ;
         H009X4_n569ConfigLayoutCorpoPromissoriaPaciente = new bool[] {false} ;
         H009X4_A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = new string[] {""} ;
         H009X4_n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = new bool[] {false} ;
         H009X4_A568ConfigLayoutCorpoPromissoriaClinicaTaxa = new string[] {""} ;
         H009X4_n568ConfigLayoutCorpoPromissoriaClinicaTaxa = new bool[] {false} ;
         A418ConfiguracoesLayoutContratoCorpo = "";
         A569ConfigLayoutCorpoPromissoriaPaciente = "";
         A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = "";
         A568ConfigLayoutCorpoPromissoriaClinicaTaxa = "";
         AV43HTML = "";
         H009X5_A168ClienteId = new int[1] ;
         H009X5_A172ClienteTipoPessoa = new string[] {""} ;
         H009X5_n172ClienteTipoPessoa = new bool[] {false} ;
         H009X5_A169ClienteDocumento = new string[] {""} ;
         H009X5_n169ClienteDocumento = new bool[] {false} ;
         H009X5_A201ContatoEmail = new string[] {""} ;
         H009X5_n201ContatoEmail = new bool[] {false} ;
         H009X5_A170ClienteRazaoSocial = new string[] {""} ;
         H009X5_n170ClienteRazaoSocial = new bool[] {false} ;
         H009X5_A447ResponsavelCPF = new string[] {""} ;
         H009X5_n447ResponsavelCPF = new bool[] {false} ;
         H009X5_A456ResponsavelEmail = new string[] {""} ;
         H009X5_n456ResponsavelEmail = new bool[] {false} ;
         H009X5_A436ResponsavelNome = new string[] {""} ;
         H009X5_n436ResponsavelNome = new bool[] {false} ;
         A172ClienteTipoPessoa = "";
         A169ClienteDocumento = "";
         A201ContatoEmail = "";
         A170ClienteRazaoSocial = "";
         A447ResponsavelCPF = "";
         A456ResponsavelEmail = "";
         A436ResponsavelNome = "";
         H009X6_A133SecUserId = new short[1] ;
         H009X6_A226SecUserOwnerId = new int[1] ;
         H009X6_n226SecUserOwnerId = new bool[] {false} ;
         H009X7_A168ClienteId = new int[1] ;
         H009X7_A169ClienteDocumento = new string[] {""} ;
         H009X7_n169ClienteDocumento = new bool[] {false} ;
         H009X7_A201ContatoEmail = new string[] {""} ;
         H009X7_n201ContatoEmail = new bool[] {false} ;
         H009X7_A170ClienteRazaoSocial = new string[] {""} ;
         H009X7_n170ClienteRazaoSocial = new bool[] {false} ;
         H009X7_A447ResponsavelCPF = new string[] {""} ;
         H009X7_n447ResponsavelCPF = new bool[] {false} ;
         H009X7_A456ResponsavelEmail = new string[] {""} ;
         H009X7_n456ResponsavelEmail = new bool[] {false} ;
         H009X7_A436ResponsavelNome = new string[] {""} ;
         H009X7_n436ResponsavelNome = new bool[] {false} ;
         AV13HTMLLine = "";
         FreegridRow = new GXWebRow();
         AV38Contrato = new SdtContrato(context);
         AV21GUID = Guid.Empty;
         AV34File = new GxFile(context.GetPhysicalPath());
         AV35PdfPath = "";
         AV36PdfFile = new GxFile(context.GetPhysicalPath());
         AV41ErroMsg = "";
         AV42AuxArray_SdParticipantes = new GXBaseCollection<SdtSdParticipantes>( context, "SdParticipantes", "Factory21");
         AV40SdErro = new SdtSdErro(context);
         H009X8_A572PropostaContratoAssinaturaId = new int[1] ;
         H009X8_A573PropostaContratoAssinaturaTipo = new string[] {""} ;
         H009X8_n573PropostaContratoAssinaturaTipo = new bool[] {false} ;
         H009X8_A323PropostaId = new int[1] ;
         H009X8_n323PropostaId = new bool[] {false} ;
         H009X8_A571PropostaAssinatura = new long[1] ;
         H009X8_n571PropostaAssinatura = new bool[] {false} ;
         AV49ReembolsoAssinaturas = new SdtReembolsoAssinaturas(context);
         GXt_char1 = "";
         AV20WEBSESSIon = context.GetSession();
         AV17InJSON = "";
         AV18Array_JSON = "";
         H009X9_A154LayoutContratoId = new short[1] ;
         H009X9_A157LayoutContratoCorpo = new string[] {""} ;
         H009X9_n157LayoutContratoCorpo = new bool[] {false} ;
         H009X10_A906LayoutContratoTipo = new string[] {""} ;
         H009X10_n906LayoutContratoTipo = new bool[] {false} ;
         H009X10_A156LayoutContratoStatus = new bool[] {false} ;
         H009X10_n156LayoutContratoStatus = new bool[] {false} ;
         H009X10_A154LayoutContratoId = new short[1] ;
         H009X10_A155LayoutContratoDescricao = new string[] {""} ;
         H009X10_n155LayoutContratoDescricao = new bool[] {false} ;
         A906LayoutContratoTipo = "";
         A155LayoutContratoDescricao = "";
         AV24Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         bttBtn_cancel_Jsonclick = "";
         bttBtnenviarparaassinatura_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subFreegrid_Linesclass = "";
         FreegridColumn = new GXWebColumn();
         ROClassString = "";
         lblParticipantelabel_Jsonclick = "";
         bttBtneditar_Jsonclick = "";
         bttBtnretirar_Jsonclick = "";
         subFreegrid_Header = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.assinarcontratopropostas__default(),
            new Object[][] {
                new Object[] {
               H009X2_A249EmpresaId, H009X2_A773EmpresaUtilizaRepresentanteAssinatura, H009X2_n773EmpresaUtilizaRepresentanteAssinatura, H009X2_A252EmpresaCNPJ, H009X2_n252EmpresaCNPJ, H009X2_A470EmpresaEmail, H009X2_n470EmpresaEmail, H009X2_A251EmpresaRazaoSocial, H009X2_n251EmpresaRazaoSocial, H009X2_A770EmpresaRepresentanteCPF,
               H009X2_n770EmpresaRepresentanteCPF, H009X2_A772EmpresaRepresentanteEmail, H009X2_n772EmpresaRepresentanteEmail, H009X2_A771EmpresaRepresentanteNome, H009X2_n771EmpresaRepresentanteNome
               }
               , new Object[] {
               H009X3_A323PropostaId, H009X3_A504PropostaPacienteClienteId, H009X3_n504PropostaPacienteClienteId, H009X3_A553PropostaResponsavelId, H009X3_n553PropostaResponsavelId, H009X3_A505PropostaPacienteClienteRazaoSocial, H009X3_n505PropostaPacienteClienteRazaoSocial, H009X3_A328PropostaCratedBy, H009X3_n328PropostaCratedBy
               }
               , new Object[] {
               H009X4_A299ConfiguracoesId, H009X4_A398ConfiguracoesLayoutProposta, H009X4_n398ConfiguracoesLayoutProposta, H009X4_A564ConfigLayoutPromissoriaClinicaEmprestimo, H009X4_n564ConfigLayoutPromissoriaClinicaEmprestimo, H009X4_A565ConfigLayoutPromissoriaClinicaTaxa, H009X4_n565ConfigLayoutPromissoriaClinicaTaxa, H009X4_A566ConfigLayoutPromissoriaPaciente, H009X4_n566ConfigLayoutPromissoriaPaciente, H009X4_A418ConfiguracoesLayoutContratoCorpo,
               H009X4_n418ConfiguracoesLayoutContratoCorpo, H009X4_A569ConfigLayoutCorpoPromissoriaPaciente, H009X4_n569ConfigLayoutCorpoPromissoriaPaciente, H009X4_A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo, H009X4_n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo, H009X4_A568ConfigLayoutCorpoPromissoriaClinicaTaxa, H009X4_n568ConfigLayoutCorpoPromissoriaClinicaTaxa
               }
               , new Object[] {
               H009X5_A168ClienteId, H009X5_A172ClienteTipoPessoa, H009X5_n172ClienteTipoPessoa, H009X5_A169ClienteDocumento, H009X5_n169ClienteDocumento, H009X5_A201ContatoEmail, H009X5_n201ContatoEmail, H009X5_A170ClienteRazaoSocial, H009X5_n170ClienteRazaoSocial, H009X5_A447ResponsavelCPF,
               H009X5_n447ResponsavelCPF, H009X5_A456ResponsavelEmail, H009X5_n456ResponsavelEmail, H009X5_A436ResponsavelNome, H009X5_n436ResponsavelNome
               }
               , new Object[] {
               H009X6_A133SecUserId, H009X6_A226SecUserOwnerId, H009X6_n226SecUserOwnerId
               }
               , new Object[] {
               H009X7_A168ClienteId, H009X7_A169ClienteDocumento, H009X7_n169ClienteDocumento, H009X7_A201ContatoEmail, H009X7_n201ContatoEmail, H009X7_A170ClienteRazaoSocial, H009X7_n170ClienteRazaoSocial, H009X7_A447ResponsavelCPF, H009X7_n447ResponsavelCPF, H009X7_A456ResponsavelEmail,
               H009X7_n456ResponsavelEmail, H009X7_A436ResponsavelNome, H009X7_n436ResponsavelNome
               }
               , new Object[] {
               H009X8_A572PropostaContratoAssinaturaId, H009X8_A573PropostaContratoAssinaturaTipo, H009X8_n573PropostaContratoAssinaturaTipo, H009X8_A323PropostaId, H009X8_n323PropostaId, H009X8_A571PropostaAssinatura, H009X8_n571PropostaAssinatura
               }
               , new Object[] {
               H009X9_A154LayoutContratoId, H009X9_A157LayoutContratoCorpo, H009X9_n157LayoutContratoCorpo
               }
               , new Object[] {
               H009X10_A906LayoutContratoTipo, H009X10_n906LayoutContratoTipo, H009X10_A156LayoutContratoStatus, H009X10_n156LayoutContratoStatus, H009X10_A154LayoutContratoId, H009X10_A155LayoutContratoDescricao, H009X10_n155LayoutContratoDescricao
               }
            }
         );
         /* GeneXus formulas. */
         edtavNomeparticipante_Enabled = 0;
      }

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
      private short nGXWrapped ;
      private short A154LayoutContratoId ;
      private short AV16i ;
      private short wbEnd ;
      private short wbStart ;
      private short AV22LayoutContratoId ;
      private short nDonePA ;
      private short subFreegrid_Backcolorstyle ;
      private short A328PropostaCratedBy ;
      private short A398ConfiguracoesLayoutProposta ;
      private short A564ConfigLayoutPromissoriaClinicaEmprestimo ;
      private short A565ConfigLayoutPromissoriaClinicaTaxa ;
      private short A566ConfigLayoutPromissoriaPaciente ;
      private short A133SecUserId ;
      private short gxcookieaux ;
      private short FREEGRID_nEOF ;
      private short subFreegrid_Backstyle ;
      private short subFreegrid_Allowselection ;
      private short subFreegrid_Allowhovering ;
      private short subFreegrid_Allowcollapsing ;
      private short subFreegrid_Collapsed ;
      private int AV46PropostaId ;
      private int AV50ReembolsoId ;
      private int wcpOAV46PropostaId ;
      private int wcpOAV50ReembolsoId ;
      private int edtavGridjson_Visible ;
      private int nRC_GXsfl_64 ;
      private int subFreegrid_Recordcount ;
      private int nGXsfl_64_idx=1 ;
      private int AV39ContratoId ;
      private int AV25ClienteId ;
      private int A323PropostaId ;
      private int AV70GXV5 ;
      private int edtavNomecontrato_Enabled ;
      private int edtavLayoutcontratoid_Visible ;
      private int subFreegrid_Islastpage ;
      private int edtavNomeparticipante_Enabled ;
      private int A504PropostaPacienteClienteId ;
      private int A553PropostaResponsavelId ;
      private int AV55PropostaPacienteClienteId ;
      private int AV52ResponsavelClienteId ;
      private int AV53ClinicaClienteId ;
      private int A168ClienteId ;
      private int A226SecUserOwnerId ;
      private int AV54secuserownerid ;
      private int AV63GXV1 ;
      private int AV64GXV2 ;
      private int AV65GXV3 ;
      private int AV48PropostaContratoAssinaturaId ;
      private int AV67GXV4 ;
      private int idxLst ;
      private int subFreegrid_Backcolor ;
      private int subFreegrid_Allbackcolor ;
      private int subFreegrid_Selectedindex ;
      private int subFreegrid_Selectioncolor ;
      private int subFreegrid_Hoveringcolor ;
      private long A571PropostaAssinatura ;
      private long FREEGRID_nCurrentRecord ;
      private long FREEGRID_nFirstRecordOnPage ;
      private string Combo_layoutcontratoid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_64_idx="0001" ;
      private string edtavGridjson_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Combo_layoutcontratoid_Cls ;
      private string Combo_layoutcontratoid_Selectedvalue_set ;
      private string Corpo_Captionclass ;
      private string Corpo_Captionstyle ;
      private string Corpo_Captionposition ;
      private string subFreegrid_Class ;
      private string subFreegrid_Flexdirection ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divTablecontentitens_Internalname ;
      private string divContractpage_Internalname ;
      private string divEditor_Internalname ;
      private string divCombo_layoutcontratoid_cell_Internalname ;
      private string divCombo_layoutcontratoid_cell_Class ;
      private string divTablesplittedlayoutcontratoid_Internalname ;
      private string lblTextblockcombo_layoutcontratoid_Internalname ;
      private string lblTextblockcombo_layoutcontratoid_Jsonclick ;
      private string Combo_layoutcontratoid_Caption ;
      private string Combo_layoutcontratoid_Internalname ;
      private string edtavNomecontrato_Internalname ;
      private string TempTags ;
      private string edtavNomecontrato_Jsonclick ;
      private string divTablecontractbody_Internalname ;
      private string Corpo_Internalname ;
      private string divLbl_Internalname ;
      private string divParticipantestitle_Internalname ;
      private string lblLbl_Internalname ;
      private string lblLbl_Jsonclick ;
      private string bttBtnadicionarparticipante_Internalname ;
      private string bttBtnadicionarparticipante_Jsonclick ;
      private string sStyleString ;
      private string subFreegrid_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavLayoutcontratoid_Internalname ;
      private string edtavLayoutcontratoid_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavNomeparticipante_Internalname ;
      private string GXDecQS ;
      private string lblParticipantelabel_Caption ;
      private string GXt_char1 ;
      private string tblTablemergedbtn_cancel_Internalname ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtnenviarparaassinatura_Internalname ;
      private string bttBtnenviarparaassinatura_Jsonclick ;
      private string lblParticipantelabel_Internalname ;
      private string sGXsfl_64_fel_idx="0001" ;
      private string subFreegrid_Linesclass ;
      private string divFreegridlayouttable_Internalname ;
      private string divParticipantenome_Internalname ;
      private string ROClassString ;
      private string edtavNomeparticipante_Jsonclick ;
      private string lblParticipantelabel_Jsonclick ;
      private string divParticipanteacoes_Internalname ;
      private string bttBtneditar_Internalname ;
      private string bttBtneditar_Jsonclick ;
      private string bttBtnretirar_Internalname ;
      private string bttBtnretirar_Jsonclick ;
      private string tblUnnamedtablecontentfsfreegrid_Internalname ;
      private string subFreegrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_64_Refreshing=false ;
      private bool AV30Tipo ;
      private bool AV19IsUpdate ;
      private bool Combo_layoutcontratoid_Visible ;
      private bool Combo_layoutcontratoid_Emptyitem ;
      private bool Corpo_Enabled ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool A773EmpresaUtilizaRepresentanteAssinatura ;
      private bool n773EmpresaUtilizaRepresentanteAssinatura ;
      private bool n252EmpresaCNPJ ;
      private bool n470EmpresaEmail ;
      private bool n251EmpresaRazaoSocial ;
      private bool n770EmpresaRepresentanteCPF ;
      private bool n772EmpresaRepresentanteEmail ;
      private bool n771EmpresaRepresentanteNome ;
      private bool n323PropostaId ;
      private bool n504PropostaPacienteClienteId ;
      private bool n553PropostaResponsavelId ;
      private bool n505PropostaPacienteClienteRazaoSocial ;
      private bool n328PropostaCratedBy ;
      private bool n398ConfiguracoesLayoutProposta ;
      private bool n564ConfigLayoutPromissoriaClinicaEmprestimo ;
      private bool n565ConfigLayoutPromissoriaClinicaTaxa ;
      private bool n566ConfigLayoutPromissoriaPaciente ;
      private bool n418ConfiguracoesLayoutContratoCorpo ;
      private bool n569ConfigLayoutCorpoPromissoriaPaciente ;
      private bool n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo ;
      private bool n568ConfigLayoutCorpoPromissoriaClinicaTaxa ;
      private bool AV51IsSemResponsavel ;
      private bool n172ClienteTipoPessoa ;
      private bool n169ClienteDocumento ;
      private bool n201ContatoEmail ;
      private bool n170ClienteRazaoSocial ;
      private bool n447ResponsavelCPF ;
      private bool n456ResponsavelEmail ;
      private bool n436ResponsavelNome ;
      private bool n226SecUserOwnerId ;
      private bool AV32IsHasContratante ;
      private bool AV33IsHasContratado ;
      private bool AV44IsArqOk ;
      private bool n573PropostaContratoAssinaturaTipo ;
      private bool n571PropostaAssinatura ;
      private bool n157LayoutContratoCorpo ;
      private bool n906LayoutContratoTipo ;
      private bool A156LayoutContratoStatus ;
      private bool n156LayoutContratoStatus ;
      private bool n155LayoutContratoDescricao ;
      private string AV29StringBase64 ;
      private string AV8Corpo ;
      private string A157LayoutContratoCorpo ;
      private string AV12JSON ;
      private string AV14GRIDJSON ;
      private string A418ConfiguracoesLayoutContratoCorpo ;
      private string A569ConfigLayoutCorpoPromissoriaPaciente ;
      private string A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo ;
      private string A568ConfigLayoutCorpoPromissoriaClinicaTaxa ;
      private string AV43HTML ;
      private string AV13HTMLLine ;
      private string AV17InJSON ;
      private string AV18Array_JSON ;
      private string AV47PropostaContratoAssinaturaTipo ;
      private string wcpOAV47PropostaContratoAssinaturaTipo ;
      private string A573PropostaContratoAssinaturaTipo ;
      private string AV9NomeContrato ;
      private string AV5NomeParticipante ;
      private string A252EmpresaCNPJ ;
      private string A470EmpresaEmail ;
      private string A251EmpresaRazaoSocial ;
      private string A770EmpresaRepresentanteCPF ;
      private string A772EmpresaRepresentanteEmail ;
      private string A771EmpresaRepresentanteNome ;
      private string A505PropostaPacienteClienteRazaoSocial ;
      private string AV56PropostaPacienteClienteRazaoSocial ;
      private string A172ClienteTipoPessoa ;
      private string A169ClienteDocumento ;
      private string A201ContatoEmail ;
      private string A170ClienteRazaoSocial ;
      private string A447ResponsavelCPF ;
      private string A456ResponsavelEmail ;
      private string A436ResponsavelNome ;
      private string AV35PdfPath ;
      private string AV41ErroMsg ;
      private string A906LayoutContratoTipo ;
      private string A155LayoutContratoDescricao ;
      private Guid AV21GUID ;
      private string AV37Blob ;
      private GXWebGrid FreegridContainer ;
      private GXWebRow FreegridRow ;
      private GXWebColumn FreegridColumn ;
      private GXUserControl ucCombo_layoutcontratoid ;
      private GXUserControl ucCorpo ;
      private IGxSession AV20WEBSESSIon ;
      private GxFile AV34File ;
      private GxFile AV36PdfFile ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSdParticipantes> AV10Array_SdParticipantes ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV23LayoutContratoId_Data ;
      private SdtSdParticipantes AV15AuxSdParticipantes ;
      private SdtSdParticipantes AV11SdParticipantes ;
      private IDataStoreProvider pr_default ;
      private int[] H009X2_A249EmpresaId ;
      private bool[] H009X2_A773EmpresaUtilizaRepresentanteAssinatura ;
      private bool[] H009X2_n773EmpresaUtilizaRepresentanteAssinatura ;
      private string[] H009X2_A252EmpresaCNPJ ;
      private bool[] H009X2_n252EmpresaCNPJ ;
      private string[] H009X2_A470EmpresaEmail ;
      private bool[] H009X2_n470EmpresaEmail ;
      private string[] H009X2_A251EmpresaRazaoSocial ;
      private bool[] H009X2_n251EmpresaRazaoSocial ;
      private string[] H009X2_A770EmpresaRepresentanteCPF ;
      private bool[] H009X2_n770EmpresaRepresentanteCPF ;
      private string[] H009X2_A772EmpresaRepresentanteEmail ;
      private bool[] H009X2_n772EmpresaRepresentanteEmail ;
      private string[] H009X2_A771EmpresaRepresentanteNome ;
      private bool[] H009X2_n771EmpresaRepresentanteNome ;
      private int[] H009X3_A323PropostaId ;
      private bool[] H009X3_n323PropostaId ;
      private int[] H009X3_A504PropostaPacienteClienteId ;
      private bool[] H009X3_n504PropostaPacienteClienteId ;
      private int[] H009X3_A553PropostaResponsavelId ;
      private bool[] H009X3_n553PropostaResponsavelId ;
      private string[] H009X3_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] H009X3_n505PropostaPacienteClienteRazaoSocial ;
      private short[] H009X3_A328PropostaCratedBy ;
      private bool[] H009X3_n328PropostaCratedBy ;
      private int[] H009X4_A299ConfiguracoesId ;
      private short[] H009X4_A398ConfiguracoesLayoutProposta ;
      private bool[] H009X4_n398ConfiguracoesLayoutProposta ;
      private short[] H009X4_A564ConfigLayoutPromissoriaClinicaEmprestimo ;
      private bool[] H009X4_n564ConfigLayoutPromissoriaClinicaEmprestimo ;
      private short[] H009X4_A565ConfigLayoutPromissoriaClinicaTaxa ;
      private bool[] H009X4_n565ConfigLayoutPromissoriaClinicaTaxa ;
      private short[] H009X4_A566ConfigLayoutPromissoriaPaciente ;
      private bool[] H009X4_n566ConfigLayoutPromissoriaPaciente ;
      private string[] H009X4_A418ConfiguracoesLayoutContratoCorpo ;
      private bool[] H009X4_n418ConfiguracoesLayoutContratoCorpo ;
      private string[] H009X4_A569ConfigLayoutCorpoPromissoriaPaciente ;
      private bool[] H009X4_n569ConfigLayoutCorpoPromissoriaPaciente ;
      private string[] H009X4_A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo ;
      private bool[] H009X4_n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo ;
      private string[] H009X4_A568ConfigLayoutCorpoPromissoriaClinicaTaxa ;
      private bool[] H009X4_n568ConfigLayoutCorpoPromissoriaClinicaTaxa ;
      private int[] H009X5_A168ClienteId ;
      private string[] H009X5_A172ClienteTipoPessoa ;
      private bool[] H009X5_n172ClienteTipoPessoa ;
      private string[] H009X5_A169ClienteDocumento ;
      private bool[] H009X5_n169ClienteDocumento ;
      private string[] H009X5_A201ContatoEmail ;
      private bool[] H009X5_n201ContatoEmail ;
      private string[] H009X5_A170ClienteRazaoSocial ;
      private bool[] H009X5_n170ClienteRazaoSocial ;
      private string[] H009X5_A447ResponsavelCPF ;
      private bool[] H009X5_n447ResponsavelCPF ;
      private string[] H009X5_A456ResponsavelEmail ;
      private bool[] H009X5_n456ResponsavelEmail ;
      private string[] H009X5_A436ResponsavelNome ;
      private bool[] H009X5_n436ResponsavelNome ;
      private short[] H009X6_A133SecUserId ;
      private int[] H009X6_A226SecUserOwnerId ;
      private bool[] H009X6_n226SecUserOwnerId ;
      private int[] H009X7_A168ClienteId ;
      private string[] H009X7_A169ClienteDocumento ;
      private bool[] H009X7_n169ClienteDocumento ;
      private string[] H009X7_A201ContatoEmail ;
      private bool[] H009X7_n201ContatoEmail ;
      private string[] H009X7_A170ClienteRazaoSocial ;
      private bool[] H009X7_n170ClienteRazaoSocial ;
      private string[] H009X7_A447ResponsavelCPF ;
      private bool[] H009X7_n447ResponsavelCPF ;
      private string[] H009X7_A456ResponsavelEmail ;
      private bool[] H009X7_n456ResponsavelEmail ;
      private string[] H009X7_A436ResponsavelNome ;
      private bool[] H009X7_n436ResponsavelNome ;
      private SdtContrato AV38Contrato ;
      private GXBaseCollection<SdtSdParticipantes> AV42AuxArray_SdParticipantes ;
      private SdtSdErro AV40SdErro ;
      private int[] H009X8_A572PropostaContratoAssinaturaId ;
      private string[] H009X8_A573PropostaContratoAssinaturaTipo ;
      private bool[] H009X8_n573PropostaContratoAssinaturaTipo ;
      private int[] H009X8_A323PropostaId ;
      private bool[] H009X8_n323PropostaId ;
      private long[] H009X8_A571PropostaAssinatura ;
      private bool[] H009X8_n571PropostaAssinatura ;
      private SdtReembolsoAssinaturas AV49ReembolsoAssinaturas ;
      private short[] H009X9_A154LayoutContratoId ;
      private string[] H009X9_A157LayoutContratoCorpo ;
      private bool[] H009X9_n157LayoutContratoCorpo ;
      private string[] H009X10_A906LayoutContratoTipo ;
      private bool[] H009X10_n906LayoutContratoTipo ;
      private bool[] H009X10_A156LayoutContratoStatus ;
      private bool[] H009X10_n156LayoutContratoStatus ;
      private short[] H009X10_A154LayoutContratoId ;
      private string[] H009X10_A155LayoutContratoDescricao ;
      private bool[] H009X10_n155LayoutContratoDescricao ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV24Combo_DataItem ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class assinarcontratopropostas__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH009X2;
          prmH009X2 = new Object[] {
          };
          Object[] prmH009X3;
          prmH009X3 = new Object[] {
          new ParDef("AV46PropostaId",GXType.Int32,9,0)
          };
          Object[] prmH009X4;
          prmH009X4 = new Object[] {
          };
          Object[] prmH009X5;
          prmH009X5 = new Object[] {
          new ParDef("AV52ResponsavelClienteId",GXType.Int32,9,0)
          };
          Object[] prmH009X6;
          prmH009X6 = new Object[] {
          new ParDef("AV53ClinicaClienteId",GXType.Int32,9,0)
          };
          Object[] prmH009X7;
          prmH009X7 = new Object[] {
          new ParDef("AV54secuserownerid",GXType.Int32,9,0)
          };
          Object[] prmH009X8;
          prmH009X8 = new Object[] {
          new ParDef("AV46PropostaId",GXType.Int32,9,0) ,
          new ParDef("AV47PropostaContratoAssinaturaTipo",GXType.VarChar,60,0)
          };
          Object[] prmH009X9;
          prmH009X9 = new Object[] {
          new ParDef("AV22LayoutContratoId",GXType.Int16,4,0)
          };
          Object[] prmH009X10;
          prmH009X10 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H009X2", "SELECT EmpresaId, EmpresaUtilizaRepresentanteAssinatura, EmpresaCNPJ, EmpresaEmail, EmpresaRazaoSocial, EmpresaRepresentanteCPF, EmpresaRepresentanteEmail, EmpresaRepresentanteNome FROM Empresa WHERE EmpresaUtilizaRepresentanteAssinatura ORDER BY EmpresaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009X2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H009X3", "SELECT T1.PropostaId, T1.PropostaPacienteClienteId AS PropostaPacienteClienteId, T1.PropostaResponsavelId, T2.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, T1.PropostaCratedBy FROM (Proposta T1 LEFT JOIN Cliente T2 ON T2.ClienteId = T1.PropostaPacienteClienteId) WHERE T1.PropostaId = :AV46PropostaId ORDER BY T1.PropostaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009X3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H009X4", "SELECT T1.ConfiguracoesId, T1.ConfiguracoesLayoutProposta AS ConfiguracoesLayoutProposta, T1.ConfigLayoutPromissoriaClinicaEmprestimo AS ConfigLayoutPromissoriaClinicaEmprestimo, T1.ConfigLayoutPromissoriaClinicaTaxa AS ConfigLayoutPromissoriaClinicaTaxa, T1.ConfigLayoutPromissoriaPaciente AS ConfigLayoutPromissoriaPaciente, T2.LayoutContratoCorpo AS ConfiguracoesLayoutContratoCorpo, T5.LayoutContratoCorpo AS ConfigLayoutCorpoPromissoriaPaciente, T3.LayoutContratoCorpo AS ConfigLayoutCorpoPromissoriaClinicaEmprestimo, T4.LayoutContratoCorpo AS ConfigLayoutCorpoPromissoriaClinicaTaxa FROM ((((Configuracoes T1 LEFT JOIN LayoutContrato T2 ON T2.LayoutContratoId = T1.ConfiguracoesLayoutProposta) LEFT JOIN LayoutContrato T3 ON T3.LayoutContratoId = T1.ConfigLayoutPromissoriaClinicaEmprestimo) LEFT JOIN LayoutContrato T4 ON T4.LayoutContratoId = T1.ConfigLayoutPromissoriaClinicaTaxa) LEFT JOIN LayoutContrato T5 ON T5.LayoutContratoId = T1.ConfigLayoutPromissoriaPaciente) ORDER BY T1.ConfiguracoesId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009X4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H009X5", "SELECT ClienteId, ClienteTipoPessoa, ClienteDocumento, ContatoEmail, ClienteRazaoSocial, ResponsavelCPF, ResponsavelEmail, ResponsavelNome FROM Cliente WHERE ClienteId = :AV52ResponsavelClienteId ORDER BY ClienteId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009X5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H009X6", "SELECT SecUserId, SecUserOwnerId FROM SecUser WHERE SecUserId = :AV53ClinicaClienteId ORDER BY SecUserId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009X6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H009X7", "SELECT ClienteId, ClienteDocumento, ContatoEmail, ClienteRazaoSocial, ResponsavelCPF, ResponsavelEmail, ResponsavelNome FROM Cliente WHERE ClienteId = :AV54secuserownerid ORDER BY ClienteId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009X7,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H009X8", "SELECT PropostaContratoAssinaturaId, PropostaContratoAssinaturaTipo, PropostaId, PropostaAssinatura FROM PropostaContratoAssinatura WHERE (PropostaId = :AV46PropostaId) AND (PropostaContratoAssinaturaTipo = ( :AV47PropostaContratoAssinaturaTipo)) ORDER BY PropostaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009X8,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H009X9", "SELECT LayoutContratoId, LayoutContratoCorpo FROM LayoutContrato WHERE LayoutContratoId = :AV22LayoutContratoId ORDER BY LayoutContratoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009X9,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H009X10", "SELECT LayoutContratoTipo, LayoutContratoStatus, LayoutContratoId, LayoutContratoDescricao FROM LayoutContrato WHERE (LayoutContratoStatus) AND (LayoutContratoTipo = ( 'C')) ORDER BY LayoutContratoDescricao ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009X10,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
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
             case 3 :
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
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 5 :
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
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((long[]) buf[5])[0] = rslt.getLong(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 8 :
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
