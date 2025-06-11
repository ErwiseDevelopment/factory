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
   public class assinarcontrato : GXDataArea
   {
      public assinarcontrato( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("DSAssinatura", true);
      }

      public assinarcontrato( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_ClienteId )
      {
         this.AV25ClienteId = aP0_ClienteId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavTipo = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "ClienteId");
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
               gxfirstwebparm = GetFirstPar( "ClienteId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "ClienteId");
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
         nRC_GXsfl_77 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_77"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_77_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_77_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_77_idx = GetPar( "sGXsfl_77_idx");
         edtavGridjson_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtavGridjson_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavGridjson_Visible), 5, 0), !bGXsfl_77_Refreshing);
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
         AssignProp("", false, edtavGridjson_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavGridjson_Visible), 5, 0), !bGXsfl_77_Refreshing);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV10Array_SdParticipantes);
         AV40ContratoId = (int)(Math.Round(NumberUtil.Val( GetPar( "ContratoId"), "."), 18, MidpointRounding.ToEven));
         AV25ClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "ClienteId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrFreegrid_refresh( AV10Array_SdParticipantes, AV40ContratoId, AV25ClienteId) ;
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
         PA9R2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START9R2( ) ;
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
         context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
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
         GXEncryptionTmp = "assinarcontrato"+UrlEncode(StringUtil.LTrimStr(AV25ClienteId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("assinarcontrato") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vCONTRATOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40ContratoId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCONTRATOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV40ContratoId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV25ClienteId), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_77", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_77), 8, 0, ",", "")));
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUPLOADEDFILES", AV26UploadedFiles);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUPLOADEDFILES", AV26UploadedFiles);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFAILEDFILES", AV27FailedFiles);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFAILEDFILES", AV27FailedFiles);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vARRAY_SDPARTICIPANTES", AV10Array_SdParticipantes);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vARRAY_SDPARTICIPANTES", AV10Array_SdParticipantes);
         }
         GxWebStd.gx_hidden_field( context, "vSTRINGBASE64", AV29StringBase64);
         GxWebStd.gx_hidden_field( context, "vCONTRATOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40ContratoId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCONTRATOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV40ContratoId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV25ClienteId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vBLOB", AV37Blob);
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
         GxWebStd.gx_hidden_field( context, "vGXV6", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV58GXV6), 8, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, "COMBO_LAYOUTCONTRATOID_Emptyitemtext", StringUtil.RTrim( Combo_layoutcontratoid_Emptyitemtext));
         GxWebStd.gx_hidden_field( context, "CORPO_Enabled", StringUtil.BoolToStr( Corpo_Enabled));
         GxWebStd.gx_hidden_field( context, "CORPO_Captionclass", StringUtil.RTrim( Corpo_Captionclass));
         GxWebStd.gx_hidden_field( context, "CORPO_Captionstyle", StringUtil.RTrim( Corpo_Captionstyle));
         GxWebStd.gx_hidden_field( context, "CORPO_Captionposition", StringUtil.RTrim( Corpo_Captionposition));
         GxWebStd.gx_hidden_field( context, "FILEUPLOADER_Autoupload", StringUtil.BoolToStr( Fileuploader_Autoupload));
         GxWebStd.gx_hidden_field( context, "FILEUPLOADER_Hideadditionalbuttons", StringUtil.BoolToStr( Fileuploader_Hideadditionalbuttons));
         GxWebStd.gx_hidden_field( context, "FILEUPLOADER_Enableuploadedfilecanceling", StringUtil.BoolToStr( Fileuploader_Enableuploadedfilecanceling));
         GxWebStd.gx_hidden_field( context, "FILEUPLOADER_Maxnumberoffiles", StringUtil.LTrim( StringUtil.NToC( (decimal)(Fileuploader_Maxnumberoffiles), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FILEUPLOADER_Autodisableaddingfiles", StringUtil.BoolToStr( Fileuploader_Autodisableaddingfiles));
         GxWebStd.gx_hidden_field( context, "FILEUPLOADER_Acceptedfiletypes", StringUtil.RTrim( Fileuploader_Acceptedfiletypes));
         GxWebStd.gx_hidden_field( context, "FILEUPLOADER_Customfiletypes", StringUtil.RTrim( Fileuploader_Customfiletypes));
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
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
         if ( ! ( WebComp_Wcwcpdfiframe == null ) )
         {
            WebComp_Wcwcpdfiframe.componentjscripts();
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
            WE9R2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT9R2( ) ;
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
         GXEncryptionTmp = "assinarcontrato"+UrlEncode(StringUtil.LTrimStr(AV25ClienteId,9,0));
         return formatLink("assinarcontrato") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "AssinarContrato" ;
      }

      public override string GetPgmdesc( )
      {
         return "Contrato" ;
      }

      protected void WB9R0( )
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
            wb_table1_9_9R2( true) ;
         }
         else
         {
            wb_table1_9_9R2( false) ;
         }
         return  ;
      }

      protected void wb_table1_9_9R2e( bool wbgen )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavTipo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavTipo_Internalname, "Tipo de contrato", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'" + sGXsfl_77_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavTipo, cmbavTipo_Internalname, StringUtil.BoolToStr( AV30Tipo), 1, cmbavTipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbavTipo.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "", true, 0, "HLP_AssinarContrato.htm");
            cmbavTipo.CurrentValue = StringUtil.BoolToStr( AV30Tipo);
            AssignProp("", false, cmbavTipo_Internalname, "Values", (string)(cmbavTipo.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedlayoutcontratoid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_layoutcontratoid_Internalname, "Layout do contrato (Modelo)", "", "", lblTextblockcombo_layoutcontratoid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", lblTextblockcombo_layoutcontratoid_Visible, 1, 0, 0, "HLP_AssinarContrato.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_layoutcontratoid.SetProperty("Caption", Combo_layoutcontratoid_Caption);
            ucCombo_layoutcontratoid.SetProperty("Cls", Combo_layoutcontratoid_Cls);
            ucCombo_layoutcontratoid.SetProperty("EmptyItemText", Combo_layoutcontratoid_Emptyitemtext);
            ucCombo_layoutcontratoid.SetProperty("DropDownOptionsData", AV23LayoutContratoId_Data);
            ucCombo_layoutcontratoid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_layoutcontratoid_Internalname, "COMBO_LAYOUTCONTRATOIDContainer");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavNomecontrato_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNomecontrato_Internalname, "Nome", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_77_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNomecontrato_Internalname, AV9NomeContrato, StringUtil.RTrim( context.localUtil.Format( AV9NomeContrato, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNomecontrato_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavNomecontrato_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_AssinarContrato.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontractbody_Internalname, divTablecontractbody_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontractfile_Internalname, divTablecontractfile_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucFileuploader.SetProperty("AutoUpload", Fileuploader_Autoupload);
            ucFileuploader.SetProperty("HideAdditionalButtons", Fileuploader_Hideadditionalbuttons);
            ucFileuploader.SetProperty("TooltipText", Fileuploader_Tooltiptext);
            ucFileuploader.SetProperty("EnableUploadedFileCanceling", Fileuploader_Enableuploadedfilecanceling);
            ucFileuploader.SetProperty("MaxNumberOfFiles", Fileuploader_Maxnumberoffiles);
            ucFileuploader.SetProperty("AutoDisableAddingFiles", Fileuploader_Autodisableaddingfiles);
            ucFileuploader.SetProperty("AcceptedFileTypes", Fileuploader_Acceptedfiletypes);
            ucFileuploader.SetProperty("CustomFileTypes", Fileuploader_Customfiletypes);
            ucFileuploader.SetProperty("UploadedFiles", AV26UploadedFiles);
            ucFileuploader.SetProperty("FailedFiles", AV27FailedFiles);
            ucFileuploader.Render(context, "fileupload", Fileuploader_Internalname, "FILEUPLOADERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0063"+"", StringUtil.RTrim( WebComp_Wcwcpdfiframe_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0063"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_77_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wcwcpdfiframe_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwcpdfiframe), StringUtil.Lower( WebComp_Wcwcpdfiframe_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0063"+"");
                     }
                     WebComp_Wcwcpdfiframe.componentdraw();
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwcpdfiframe), StringUtil.Lower( WebComp_Wcwcpdfiframe_Component)) != 0 )
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
            GxWebStd.gx_label_ctrl( context, lblLbl_Internalname, "Participantes", "", "", lblLbl_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AssinarContrato.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
            ClassString = "add-button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnadicionarparticipante_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(77), 2, 0)+","+"null"+");", "Adicionar", bttBtnadicionarparticipante_Jsonclick, 5, "Adicionar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOADICIONARPARTICIPANTE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_AssinarContrato.htm");
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
            StartGridControl77( ) ;
         }
         if ( wbEnd == 77 )
         {
            wbEnd = 0;
            nRC_GXsfl_77 = (int)(nGXsfl_77_idx-1);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'" + sGXsfl_77_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLayoutcontratoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22LayoutContratoId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV22LayoutContratoId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,108);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLayoutcontratoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavLayoutcontratoid_Visible, 1, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_AssinarContrato.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 77 )
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

      protected void START9R2( )
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
         Form.Meta.addItem("description", "Contrato", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP9R0( ) ;
      }

      protected void WS9R2( )
      {
         START9R2( ) ;
         EVT9R2( ) ;
      }

      protected void EVT9R2( )
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
                              E119R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "FILEUPLOADER.UPLOADCOMPLETE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Fileuploader.Uploadcomplete */
                              E129R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOENVIARPARAASSINATURA'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoEnviarParaAssinatura' */
                              E139R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOADICIONARPARTICIPANTE'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoAdicionarParticipante' */
                              E149R2 ();
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEDITAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoEditar' */
                              E159R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DORETIRAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoRetirar' */
                              E169R2 ();
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
                              nGXsfl_77_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_77_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_77_idx), 4, 0), 4, "0");
                              SubsflControlProps_772( ) ;
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
                                    E179R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "FREEGRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Freegrid.Load */
                                    E189R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DOEDITAR'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoEditar' */
                                    E159R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DORETIRAR'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoRetirar' */
                                    E169R2 ();
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
                        if ( nCmpId == 63 )
                        {
                           OldWcwcpdfiframe = cgiGet( "W0063");
                           if ( ( StringUtil.Len( OldWcwcpdfiframe) == 0 ) || ( StringUtil.StrCmp(OldWcwcpdfiframe, WebComp_Wcwcpdfiframe_Component) != 0 ) )
                           {
                              WebComp_Wcwcpdfiframe = getWebComponent(GetType(), "GeneXus.Programs", OldWcwcpdfiframe, new Object[] {context} );
                              WebComp_Wcwcpdfiframe.ComponentInit();
                              WebComp_Wcwcpdfiframe.Name = "OldWcwcpdfiframe";
                              WebComp_Wcwcpdfiframe_Component = OldWcwcpdfiframe;
                           }
                           if ( StringUtil.Len( WebComp_Wcwcpdfiframe_Component) != 0 )
                           {
                              WebComp_Wcwcpdfiframe.componentprocess("W0063", "", sEvt);
                           }
                           WebComp_Wcwcpdfiframe_Component = OldWcwcpdfiframe;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE9R2( )
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

      protected void PA9R2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "assinarcontrato")), "assinarcontrato") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "assinarcontrato")))) ;
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
                  gxfirstwebparm = GetFirstPar( "ClienteId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV25ClienteId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV25ClienteId", StringUtil.LTrimStr( (decimal)(AV25ClienteId), 9, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV25ClienteId), "ZZZZZZZZ9"), context));
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
               GX_FocusControl = cmbavTipo_Internalname;
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
         SubsflControlProps_772( ) ;
         while ( nGXsfl_77_idx <= nRC_GXsfl_77 )
         {
            sendrow_772( ) ;
            nGXsfl_77_idx = ((subFreegrid_Islastpage==1)&&(nGXsfl_77_idx+1>subFreegrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_77_idx+1);
            sGXsfl_77_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_77_idx), 4, 0), 4, "0");
            SubsflControlProps_772( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( FreegridContainer)) ;
         /* End function gxnrFreegrid_newrow */
      }

      protected void gxgrFreegrid_refresh( GXBaseCollection<SdtSdParticipantes> AV10Array_SdParticipantes ,
                                           int AV40ContratoId ,
                                           int AV25ClienteId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         FREEGRID_nCurrentRecord = 0;
         RF9R2( ) ;
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
         if ( cmbavTipo.ItemCount > 0 )
         {
            AV30Tipo = StringUtil.StrToBool( cmbavTipo.getValidValue(StringUtil.BoolToStr( AV30Tipo)));
            AssignAttri("", false, "AV30Tipo", AV30Tipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavTipo.CurrentValue = StringUtil.BoolToStr( AV30Tipo);
            AssignProp("", false, cmbavTipo_Internalname, "Values", cmbavTipo.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF9R2( ) ;
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

      protected void RF9R2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            FreegridContainer.ClearRows();
         }
         wbStart = 77;
         nGXsfl_77_idx = 1;
         sGXsfl_77_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_77_idx), 4, 0), 4, "0");
         SubsflControlProps_772( ) ;
         bGXsfl_77_Refreshing = true;
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
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcwcpdfiframe_Component) != 0 )
               {
                  WebComp_Wcwcpdfiframe.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_772( ) ;
            /* Execute user event: Freegrid.Load */
            E189R2 ();
            wbEnd = 77;
            WB9R0( ) ;
         }
         bGXsfl_77_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes9R2( )
      {
         GxWebStd.gx_hidden_field( context, "vCONTRATOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40ContratoId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCONTRATOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV40ContratoId), "ZZZZZ9"), context));
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

      protected void STRUP9R0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E179R2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vLAYOUTCONTRATOID_DATA"), AV23LayoutContratoId_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vUPLOADEDFILES"), AV26UploadedFiles);
            ajax_req_read_hidden_sdt(cgiGet( "vFAILEDFILES"), AV27FailedFiles);
            ajax_req_read_hidden_sdt(cgiGet( "vAUXSDPARTICIPANTES"), AV15AuxSdParticipantes);
            ajax_req_read_hidden_sdt(cgiGet( "vARRAY_SDPARTICIPANTES"), AV10Array_SdParticipantes);
            ajax_req_read_hidden_sdt(cgiGet( "vSDPARTICIPANTES"), AV11SdParticipantes);
            /* Read saved values. */
            nRC_GXsfl_77 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_77"), ",", "."), 18, MidpointRounding.ToEven));
            AV8Corpo = cgiGet( "vCORPO");
            AV58GXV6 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vGXV6"), ",", "."), 18, MidpointRounding.ToEven));
            AV19IsUpdate = StringUtil.StrToBool( cgiGet( "vISUPDATE"));
            AV16i = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vI"), ",", "."), 18, MidpointRounding.ToEven));
            AV12JSON = cgiGet( "vJSON");
            subFreegrid_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "subFreegrid_Recordcount"), ",", "."), 18, MidpointRounding.ToEven));
            Combo_layoutcontratoid_Cls = cgiGet( "COMBO_LAYOUTCONTRATOID_Cls");
            Combo_layoutcontratoid_Selectedvalue_set = cgiGet( "COMBO_LAYOUTCONTRATOID_Selectedvalue_set");
            Combo_layoutcontratoid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_LAYOUTCONTRATOID_Visible"));
            Combo_layoutcontratoid_Emptyitemtext = cgiGet( "COMBO_LAYOUTCONTRATOID_Emptyitemtext");
            Corpo_Enabled = StringUtil.StrToBool( cgiGet( "CORPO_Enabled"));
            Corpo_Captionclass = cgiGet( "CORPO_Captionclass");
            Corpo_Captionstyle = cgiGet( "CORPO_Captionstyle");
            Corpo_Captionposition = cgiGet( "CORPO_Captionposition");
            Fileuploader_Autoupload = StringUtil.StrToBool( cgiGet( "FILEUPLOADER_Autoupload"));
            Fileuploader_Hideadditionalbuttons = StringUtil.StrToBool( cgiGet( "FILEUPLOADER_Hideadditionalbuttons"));
            Fileuploader_Enableuploadedfilecanceling = StringUtil.StrToBool( cgiGet( "FILEUPLOADER_Enableuploadedfilecanceling"));
            Fileuploader_Maxnumberoffiles = (int)(Math.Round(context.localUtil.CToN( cgiGet( "FILEUPLOADER_Maxnumberoffiles"), ",", "."), 18, MidpointRounding.ToEven));
            Fileuploader_Autodisableaddingfiles = StringUtil.StrToBool( cgiGet( "FILEUPLOADER_Autodisableaddingfiles"));
            Fileuploader_Acceptedfiletypes = cgiGet( "FILEUPLOADER_Acceptedfiletypes");
            Fileuploader_Customfiletypes = cgiGet( "FILEUPLOADER_Customfiletypes");
            subFreegrid_Class = cgiGet( "FREEGRID_Class");
            subFreegrid_Flexdirection = cgiGet( "FREEGRID_Flexdirection");
            Combo_layoutcontratoid_Selectedvalue_get = cgiGet( "COMBO_LAYOUTCONTRATOID_Selectedvalue_get");
            /* Read variables values. */
            cmbavTipo.Name = cmbavTipo_Internalname;
            cmbavTipo.CurrentValue = cgiGet( cmbavTipo_Internalname);
            AV30Tipo = StringUtil.StrToBool( cgiGet( cmbavTipo_Internalname));
            AssignAttri("", false, "AV30Tipo", AV30Tipo);
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
         E179R2 ();
         if (returnInSub) return;
      }

      protected void E179R2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtWWPContext1 = AV48WWPContext;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  GXt_SdtWWPContext1) ;
         AV48WWPContext = GXt_SdtWWPContext1;
         AV10Array_SdParticipantes = new GXBaseCollection<SdtSdParticipantes>( context, "SdParticipantes", "Factory21");
         edtavLayoutcontratoid_Visible = 0;
         AssignProp("", false, edtavLayoutcontratoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLayoutcontratoid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOLAYOUTCONTRATOID' */
         S112 ();
         if (returnInSub) return;
         edtavGridjson_Visible = 0;
         AssignProp("", false, edtavGridjson_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavGridjson_Visible), 5, 0), !bGXsfl_77_Refreshing);
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wcwcpdfiframe = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcwcpdfiframe_Component), StringUtil.Lower( "WcPdfIframe")) != 0 )
         {
            WebComp_Wcwcpdfiframe = getWebComponent(GetType(), "GeneXus.Programs", "wcpdfiframe", new Object[] {context} );
            WebComp_Wcwcpdfiframe.ComponentInit();
            WebComp_Wcwcpdfiframe.Name = "WcPdfIframe";
            WebComp_Wcwcpdfiframe_Component = "WcPdfIframe";
         }
         if ( StringUtil.Len( WebComp_Wcwcpdfiframe_Component) != 0 )
         {
            WebComp_Wcwcpdfiframe.setjustcreated();
            WebComp_Wcwcpdfiframe.componentprepare(new Object[] {(string)"W0063",(string)"",(string)AV31Base64});
            WebComp_Wcwcpdfiframe.componentbind(new Object[] {(string)""});
         }
         if ( AV30Tipo )
         {
            divTablecontractfile_Visible = 1;
            AssignProp("", false, divTablecontractfile_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablecontractfile_Visible), 5, 0), true);
            divTablecontractbody_Visible = 0;
            AssignProp("", false, divTablecontractbody_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablecontractbody_Visible), 5, 0), true);
            lblTextblockcombo_layoutcontratoid_Visible = 0;
            AssignProp("", false, lblTextblockcombo_layoutcontratoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTextblockcombo_layoutcontratoid_Visible), 5, 0), true);
            Combo_layoutcontratoid_Visible = false;
            ucCombo_layoutcontratoid.SendProperty(context, "", false, Combo_layoutcontratoid_Internalname, "Visible", StringUtil.BoolToStr( Combo_layoutcontratoid_Visible));
         }
         else
         {
            divTablecontractfile_Visible = 0;
            AssignProp("", false, divTablecontractfile_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablecontractfile_Visible), 5, 0), true);
            divTablecontractbody_Visible = 1;
            AssignProp("", false, divTablecontractbody_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablecontractbody_Visible), 5, 0), true);
            lblTextblockcombo_layoutcontratoid_Visible = 1;
            AssignProp("", false, lblTextblockcombo_layoutcontratoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTextblockcombo_layoutcontratoid_Visible), 5, 0), true);
            Combo_layoutcontratoid_Visible = true;
            ucCombo_layoutcontratoid.SendProperty(context, "", false, Combo_layoutcontratoid_Internalname, "Visible", StringUtil.BoolToStr( Combo_layoutcontratoid_Visible));
         }
         /* Using cursor H009R2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A773EmpresaUtilizaRepresentanteAssinatura = H009R2_A773EmpresaUtilizaRepresentanteAssinatura[0];
            n773EmpresaUtilizaRepresentanteAssinatura = H009R2_n773EmpresaUtilizaRepresentanteAssinatura[0];
            A252EmpresaCNPJ = H009R2_A252EmpresaCNPJ[0];
            n252EmpresaCNPJ = H009R2_n252EmpresaCNPJ[0];
            A470EmpresaEmail = H009R2_A470EmpresaEmail[0];
            n470EmpresaEmail = H009R2_n470EmpresaEmail[0];
            A251EmpresaRazaoSocial = H009R2_A251EmpresaRazaoSocial[0];
            n251EmpresaRazaoSocial = H009R2_n251EmpresaRazaoSocial[0];
            A770EmpresaRepresentanteCPF = H009R2_A770EmpresaRepresentanteCPF[0];
            n770EmpresaRepresentanteCPF = H009R2_n770EmpresaRepresentanteCPF[0];
            A772EmpresaRepresentanteEmail = H009R2_A772EmpresaRepresentanteEmail[0];
            n772EmpresaRepresentanteEmail = H009R2_n772EmpresaRepresentanteEmail[0];
            A771EmpresaRepresentanteNome = H009R2_A771EmpresaRepresentanteNome[0];
            n771EmpresaRepresentanteNome = H009R2_n771EmpresaRepresentanteNome[0];
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
         /* Using cursor H009R3 */
         pr_default.execute(1, new Object[] {AV48WWPContext.gxTpr_Userid});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A133SecUserId = H009R3_A133SecUserId[0];
            n133SecUserId = H009R3_n133SecUserId[0];
            A479ConfiguracoesTestemunhasNome = H009R3_A479ConfiguracoesTestemunhasNome[0];
            n479ConfiguracoesTestemunhasNome = H009R3_n479ConfiguracoesTestemunhasNome[0];
            A480ConfiguracoesTestemunhasDocumento = H009R3_A480ConfiguracoesTestemunhasDocumento[0];
            n480ConfiguracoesTestemunhasDocumento = H009R3_n480ConfiguracoesTestemunhasDocumento[0];
            A481ConfiguracoesTestemunhasEmail = H009R3_A481ConfiguracoesTestemunhasEmail[0];
            n481ConfiguracoesTestemunhasEmail = H009R3_n481ConfiguracoesTestemunhasEmail[0];
            AV11SdParticipantes = new SdtSdParticipantes(context);
            AV11SdParticipantes.gxTpr_Participantenome = A479ConfiguracoesTestemunhasNome;
            AV11SdParticipantes.gxTpr_Participantedocumento = A480ConfiguracoesTestemunhasDocumento;
            AV11SdParticipantes.gxTpr_Participanteemail = A481ConfiguracoesTestemunhasEmail;
            AV11SdParticipantes.gxTpr_Assinaturaparticipantetipo = "Testemunha";
            AV11SdParticipantes.gxTpr_Clienteid = AV38Contrato.gxTpr_Contratoclienteid;
            AV11SdParticipantes.gxTpr_Participantetipopessoa = "FISICA";
            AV10Array_SdParticipantes.Add(AV11SdParticipantes, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      private void E189R2( )
      {
         /* Freegrid_Load Routine */
         returnInSub = false;
         AV51GXV1 = 1;
         while ( AV51GXV1 <= AV10Array_SdParticipantes.Count )
         {
            AV11SdParticipantes = ((SdtSdParticipantes)AV10Array_SdParticipantes.Item(AV51GXV1));
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
               wbStart = 77;
            }
            sendrow_772( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_77_Refreshing )
            {
               DoAjaxLoad(77, FreegridRow);
            }
            AV51GXV1 = (int)(AV51GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      protected void E139R2( )
      {
         /* 'DoEnviarParaAssinatura' Routine */
         returnInSub = false;
         AV32IsHasContratante = false;
         AV33IsHasContratado = false;
         AV52GXV2 = 1;
         while ( AV52GXV2 <= AV10Array_SdParticipantes.Count )
         {
            AV11SdParticipantes = ((SdtSdParticipantes)AV10Array_SdParticipantes.Item(AV52GXV2));
            if ( StringUtil.StrCmp(AV11SdParticipantes.gxTpr_Assinaturaparticipantetipo, "Contratado") == 0 )
            {
               AV33IsHasContratado = true;
            }
            if ( StringUtil.StrCmp(AV11SdParticipantes.gxTpr_Assinaturaparticipantetipo, "Contratante") == 0 )
            {
               AV32IsHasContratante = true;
            }
            AV52GXV2 = (int)(AV52GXV2+1);
         }
         if ( ! AV32IsHasContratante )
         {
            GXt_char2 = "É obrigatório ter pelo menos 1 (um) contratante";
            new message(context ).gxep_erro( ref  GXt_char2) ;
         }
         if ( ! AV33IsHasContratado )
         {
            GXt_char2 = "É obrigatório ter pelo menos 1 (um) contratado";
            new message(context ).gxep_erro( ref  GXt_char2) ;
         }
         AV47IsArqOk = true;
         if ( AV30Tipo )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV29StringBase64)) )
            {
               GXt_char2 = "Selecione um arquivo";
               new message(context ).gxep_erro( ref  GXt_char2) ;
               AV47IsArqOk = false;
            }
         }
         else
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV8Corpo)) )
            {
               GXt_char2 = "Não é possivel enviar corpo em branco para assinatura";
               new message(context ).gxep_erro( ref  GXt_char2) ;
               AV47IsArqOk = false;
            }
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9NomeContrato)) )
         {
            GXt_char2 = "Digite o nome do contrato";
            new message(context ).gxep_erro( ref  GXt_char2) ;
         }
         if ( AV33IsHasContratado && AV32IsHasContratante && AV47IsArqOk && ! String.IsNullOrEmpty(StringUtil.RTrim( AV9NomeContrato)) )
         {
            AV38Contrato = new SdtContrato(context);
            AV38Contrato.Load(AV40ContratoId);
            AV38Contrato.gxTpr_Contratonome = AV9NomeContrato;
            if ( AV30Tipo )
            {
               AV21GUID = Guid.NewGuid( );
               AV34File.Source = "./PublicTempStorage/"+AV21GUID.ToString()+".pdf";
               AV34File.Create();
               AV34File.FromBase64(AV29StringBase64);
               AV37Blob=context.FileFromBase64( AV29StringBase64) ;
            }
            else
            {
               AV21GUID = Guid.NewGuid( );
               AV34File.Source = "./PublicTempStorage/"+AV21GUID.ToString()+".html";
               AV34File.Create();
               AV45HTML = "<html><head> <meta charset=\"UTF-8\"> <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\"></head><body>" + AV8Corpo + "</body></html>";
               AV34File.WriteAllText(AV45HTML, "UTF8");
               AV21GUID = Guid.NewGuid( );
               AV35PdfPath = "./PublicTempStorage/" + AV21GUID.ToString() + ".pdf";
               AV36PdfFile.Source = AV35PdfPath;
               new prcriarpdffromhtml(context ).execute(  AV34File.GetAbsoluteName(),  AV36PdfFile.GetAbsoluteName(), out  AV42ErroMsg) ;
               if ( StringUtil.StrCmp(AV42ErroMsg, "PDF gerado com sucesso!") == 0 )
               {
                  AV37Blob = AV36PdfFile.GetAbsoluteName();
                  AssignAttri("", false, "AV37Blob", AV37Blob);
               }
               AV38Contrato.gxTpr_Contratocorpo = AV8Corpo;
            }
            AV38Contrato.gxTpr_Contratoclienteid = AV25ClienteId;
            AV38Contrato.gxTpr_Contratosituacao = "ColetandoAssinatura";
            AV38Contrato.Save();
            if ( AV38Contrato.Success() )
            {
               AV44AuxArray_SdParticipantes = new GXBaseCollection<SdtSdParticipantes>( context, "SdParticipantes", "Factory21");
               AV53GXV3 = 1;
               while ( AV53GXV3 <= AV10Array_SdParticipantes.Count )
               {
                  AV11SdParticipantes = ((SdtSdParticipantes)AV10Array_SdParticipantes.Item(AV53GXV3));
                  AV11SdParticipantes.gxTpr_Participanteid = 0;
                  AV44AuxArray_SdParticipantes.Add(AV11SdParticipantes, 0);
                  AV53GXV3 = (int)(AV53GXV3+1);
               }
               new prsendsignaturecliente(context ).execute(  AV37Blob,  AV9NomeContrato,  AV10Array_SdParticipantes,  AV38Contrato.gxTpr_Contratoid, out  AV41SdErro) ;
               if ( AV41SdErro.gxTpr_Status != 200 )
               {
                  GXt_char2 = AV41SdErro.gxTpr_Msg;
                  new message(context ).gxep_erro( ref  GXt_char2) ;
                  AV41SdErro.gxTpr_Msg = GXt_char2;
               }
               else
               {
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
               GXt_char2 = ((GeneXus.Utils.SdtMessages_Message)AV38Contrato.GetMessages().Item(1)).gxTpr_Description;
               new message(context ).gxep_erro( ref  GXt_char2) ;
               ((GeneXus.Utils.SdtMessages_Message)AV38Contrato.GetMessages().Item(1)).gxTpr_Description = GXt_char2;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38Contrato", AV38Contrato);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10Array_SdParticipantes", AV10Array_SdParticipantes);
      }

      protected void E159R2( )
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

      protected void E169R2( )
      {
         /* 'DoRetirar' Routine */
         returnInSub = false;
         AV15AuxSdParticipantes = new SdtSdParticipantes(context);
         AV15AuxSdParticipantes.FromJSonString(AV14GRIDJSON, null);
         AV16i = 0;
         AV54GXV4 = 1;
         while ( AV54GXV4 <= AV10Array_SdParticipantes.Count )
         {
            AV11SdParticipantes = ((SdtSdParticipantes)AV10Array_SdParticipantes.Item(AV54GXV4));
            AV16i = (short)(AV16i+1);
            if ( ( StringUtil.StrCmp(AV11SdParticipantes.gxTpr_Participantedocumento, AV15AuxSdParticipantes.gxTpr_Participantedocumento) == 0 ) && ( StringUtil.StrCmp(AV11SdParticipantes.gxTpr_Participanterepresentantedocumento, AV15AuxSdParticipantes.gxTpr_Participanterepresentantedocumento) == 0 ) )
            {
               AV10Array_SdParticipantes.RemoveItem(AV16i);
               if (true) break;
            }
            AV54GXV4 = (int)(AV54GXV4+1);
         }
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10Array_SdParticipantes", AV10Array_SdParticipantes);
      }

      protected void E149R2( )
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

      protected void E119R2( )
      {
         /* Combo_layoutcontratoid_Onoptionclicked Routine */
         returnInSub = false;
         AV22LayoutContratoId = (short)(Math.Round(NumberUtil.Val( Combo_layoutcontratoid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV22LayoutContratoId", StringUtil.LTrimStr( (decimal)(AV22LayoutContratoId), 4, 0));
         if ( ! (0==AV22LayoutContratoId) )
         {
            /* Using cursor H009R4 */
            pr_default.execute(2, new Object[] {AV22LayoutContratoId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A154LayoutContratoId = H009R4_A154LayoutContratoId[0];
               A157LayoutContratoCorpo = H009R4_A157LayoutContratoCorpo[0];
               n157LayoutContratoCorpo = H009R4_n157LayoutContratoCorpo[0];
               AV8Corpo = A157LayoutContratoCorpo;
               AssignAttri("", false, "AV8Corpo", AV8Corpo);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
         }
         else
         {
            AV8Corpo = "";
            AssignAttri("", false, "AV8Corpo", AV8Corpo);
         }
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'LOADCOMBOLAYOUTCONTRATOID' Routine */
         returnInSub = false;
         /* Using cursor H009R5 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            A906LayoutContratoTipo = H009R5_A906LayoutContratoTipo[0];
            n906LayoutContratoTipo = H009R5_n906LayoutContratoTipo[0];
            A154LayoutContratoId = H009R5_A154LayoutContratoId[0];
            A155LayoutContratoDescricao = H009R5_A155LayoutContratoDescricao[0];
            n155LayoutContratoDescricao = H009R5_n155LayoutContratoDescricao[0];
            AV24Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV24Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A154LayoutContratoId), 4, 0));
            AV24Combo_DataItem.gxTpr_Title = A155LayoutContratoDescricao;
            AV23LayoutContratoId_Data.Add(AV24Combo_DataItem, 0);
            pr_default.readNext(3);
         }
         pr_default.close(3);
         Combo_layoutcontratoid_Selectedvalue_set = ((0==AV22LayoutContratoId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV22LayoutContratoId), 4, 0)));
         ucCombo_layoutcontratoid.SendProperty(context, "", false, Combo_layoutcontratoid_Internalname, "SelectedValue_set", Combo_layoutcontratoid_Selectedvalue_set);
      }

      protected void E129R2( )
      {
         /* Fileuploader_Uploadcomplete Routine */
         returnInSub = false;
         AV29StringBase64 = "";
         AssignAttri("", false, "AV29StringBase64", AV29StringBase64);
         AV57GXV5 = 1;
         while ( AV57GXV5 <= AV26UploadedFiles.Count )
         {
            AV28FileUploadData = ((SdtFileUploadData)AV26UploadedFiles.Item(AV57GXV5));
            AV29StringBase64 = context.FileToBase64( AV28FileUploadData.gxTpr_File);
            AssignAttri("", false, "AV29StringBase64", AV29StringBase64);
            AV57GXV5 = (int)(AV57GXV5+1);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29StringBase64)) )
         {
            /* Object Property */
            if ( true )
            {
               bDynCreated_Wcwcpdfiframe = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcwcpdfiframe_Component), StringUtil.Lower( "WcPdfIframe")) != 0 )
            {
               WebComp_Wcwcpdfiframe = getWebComponent(GetType(), "GeneXus.Programs", "wcpdfiframe", new Object[] {context} );
               WebComp_Wcwcpdfiframe.ComponentInit();
               WebComp_Wcwcpdfiframe.Name = "WcPdfIframe";
               WebComp_Wcwcpdfiframe_Component = "WcPdfIframe";
            }
            if ( StringUtil.Len( WebComp_Wcwcpdfiframe_Component) != 0 )
            {
               WebComp_Wcwcpdfiframe.setjustcreated();
               WebComp_Wcwcpdfiframe.componentprepare(new Object[] {(string)"W0063",(string)"",(string)AV29StringBase64});
               WebComp_Wcwcpdfiframe.componentbind(new Object[] {(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wcwcpdfiframe )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0063"+"");
               WebComp_Wcwcpdfiframe.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         /*  Sending Event outputs  */
      }

      protected void wb_table1_9_9R2( bool wbgen )
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
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(77), 2, 0)+","+"null"+");", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_AssinarContrato.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenviarparaassinatura_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(77), 2, 0)+","+"null"+");", "Enviar para assinatura", bttBtnenviarparaassinatura_Jsonclick, 5, "Enviar para assinatura", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOENVIARPARAASSINATURA\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_AssinarContrato.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_9_9R2e( true) ;
         }
         else
         {
            wb_table1_9_9R2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV25ClienteId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV25ClienteId", StringUtil.LTrimStr( (decimal)(AV25ClienteId), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV25ClienteId), "ZZZZZZZZ9"), context));
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
         PA9R2( ) ;
         WS9R2( ) ;
         WE9R2( ) ;
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
         AddStyleSheetFile("FileUpload/fileupload.min.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wcwcpdfiframe == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcwcpdfiframe_Component) != 0 )
            {
               WebComp_Wcwcpdfiframe.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101928498", true, true);
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
         context.AddJavascriptSource("assinarcontrato.js", "?20256101928498", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
         context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_772( )
      {
         edtavNomeparticipante_Internalname = "vNOMEPARTICIPANTE_"+sGXsfl_77_idx;
         lblParticipantelabel_Internalname = "PARTICIPANTELABEL_"+sGXsfl_77_idx;
         edtavGridjson_Internalname = "vGRIDJSON_"+sGXsfl_77_idx;
      }

      protected void SubsflControlProps_fel_772( )
      {
         edtavNomeparticipante_Internalname = "vNOMEPARTICIPANTE_"+sGXsfl_77_fel_idx;
         lblParticipantelabel_Internalname = "PARTICIPANTELABEL_"+sGXsfl_77_fel_idx;
         edtavGridjson_Internalname = "vGRIDJSON_"+sGXsfl_77_fel_idx;
      }

      protected void sendrow_772( )
      {
         sGXsfl_77_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_77_idx), 4, 0), 4, "0");
         SubsflControlProps_772( ) ;
         WB9R0( ) ;
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
         FreegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divFreegridlayouttable_Internalname+"_"+sGXsfl_77_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"participant-card",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
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
         FreegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divParticipantenome_Internalname+"_"+sGXsfl_77_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"participant-name",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'" + sGXsfl_77_idx + "',77)\"";
         ROClassString = "AttributeFL";
         FreegridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavNomeparticipante_Internalname,(string)AV5NomeParticipante,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,85);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavNomeparticipante_Jsonclick,(short)0,(string)"AttributeFL",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavNomeparticipante_Enabled,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)100,(short)0,(short)0,(short)77,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
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
         FreegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divParticipanteacoes_Internalname+"_"+sGXsfl_77_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"participant-actions",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         FreegridRow.AddColumnProperties("button", 2, isAjaxCallMode( ), new Object[] {(string)bttBtneditar_Internalname+"_"+sGXsfl_77_idx,"gx.evt.setGridEvt("+StringUtil.Str( (decimal)(77), 2, 0)+","+"null"+");",(string)"Editar",(string)bttBtneditar_Jsonclick,(short)5,(string)"Editar",(string)"",(string)StyleString,(string)ClassString,(short)1,(short)1,(string)"standard","'"+""+"'"+",false,"+"'"+"E\\'DOEDITAR\\'."+"'",(string)TempTags,(string)"",context.GetButtonType( )});
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         FreegridRow.AddColumnProperties("button", 2, isAjaxCallMode( ), new Object[] {(string)bttBtnretirar_Internalname+"_"+sGXsfl_77_idx,"gx.evt.setGridEvt("+StringUtil.Str( (decimal)(77), 2, 0)+","+"null"+");",(string)"Retirar",(string)bttBtnretirar_Jsonclick,(short)5,(string)"Retirar",(string)"",(string)StyleString,(string)ClassString,(short)1,(short)1,(string)"standard","'"+""+"'"+",false,"+"'"+"E\\'DORETIRAR\\'."+"'",(string)TempTags,(string)"",context.GetButtonType( )});
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
         FreegridRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblUnnamedtablecontentfsfreegrid_Internalname+"_"+sGXsfl_77_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
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
         send_integrity_lvl_hashes9R2( ) ;
         /* End of Columns property logic. */
         FreegridContainer.AddRow(FreegridRow);
         nGXsfl_77_idx = ((subFreegrid_Islastpage==1)&&(nGXsfl_77_idx+1>subFreegrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_77_idx+1);
         sGXsfl_77_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_77_idx), 4, 0), 4, "0");
         SubsflControlProps_772( ) ;
         /* End function sendrow_772 */
      }

      protected void init_web_controls( )
      {
         cmbavTipo.Name = "vTIPO";
         cmbavTipo.WebTags = "";
         cmbavTipo.addItem(StringUtil.BoolToStr( false), "Corpo", 0);
         cmbavTipo.addItem(StringUtil.BoolToStr( true), "Arquivo", 0);
         if ( cmbavTipo.ItemCount > 0 )
         {
            AV30Tipo = StringUtil.StrToBool( cmbavTipo.getValidValue(StringUtil.BoolToStr( AV30Tipo)));
            AssignAttri("", false, "AV30Tipo", AV30Tipo);
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl77( )
      {
         if ( FreegridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"FreegridContainer"+"DivS\" data-gxgridid=\"77\">") ;
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
         cmbavTipo_Internalname = "vTIPO";
         lblTextblockcombo_layoutcontratoid_Internalname = "TEXTBLOCKCOMBO_LAYOUTCONTRATOID";
         Combo_layoutcontratoid_Internalname = "COMBO_LAYOUTCONTRATOID";
         divTablesplittedlayoutcontratoid_Internalname = "TABLESPLITTEDLAYOUTCONTRATOID";
         divTablecontentitens_Internalname = "TABLECONTENTITENS";
         edtavNomecontrato_Internalname = "vNOMECONTRATO";
         Corpo_Internalname = "CORPO";
         divTablecontractbody_Internalname = "TABLECONTRACTBODY";
         Fileuploader_Internalname = "FILEUPLOADER";
         divTablecontractfile_Internalname = "TABLECONTRACTFILE";
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
         Fileuploader_Tooltiptext = "";
         divTablecontractfile_Visible = 1;
         Corpo_Enabled = Convert.ToBoolean( 1);
         divTablecontractbody_Visible = 1;
         edtavNomecontrato_Jsonclick = "";
         edtavNomecontrato_Enabled = 1;
         lblTextblockcombo_layoutcontratoid_Visible = 1;
         cmbavTipo_Jsonclick = "";
         cmbavTipo.Enabled = 1;
         subFreegrid_Flexdirection = "column";
         subFreegrid_Class = "FreeStyleGrid";
         Fileuploader_Customfiletypes = "pdf";
         Fileuploader_Acceptedfiletypes = "custom";
         Fileuploader_Autodisableaddingfiles = Convert.ToBoolean( -1);
         Fileuploader_Maxnumberoffiles = 1;
         Fileuploader_Enableuploadedfilecanceling = Convert.ToBoolean( -1);
         Fileuploader_Hideadditionalbuttons = Convert.ToBoolean( -1);
         Fileuploader_Autoupload = Convert.ToBoolean( -1);
         Corpo_Captionposition = "Left";
         Corpo_Captionstyle = "";
         Corpo_Captionclass = "col-sm-3 AttributeLabel";
         Combo_layoutcontratoid_Emptyitemtext = "Nenhum";
         Combo_layoutcontratoid_Visible = Convert.ToBoolean( -1);
         Combo_layoutcontratoid_Cls = "ExtendedCombo AttributeFL";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Contrato";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"FREEGRID_nFirstRecordOnPage","type":"int"},{"av":"FREEGRID_nEOF","type":"int"},{"av":"edtavGridjson_Visible","ctrl":"vGRIDJSON","prop":"Visible"},{"av":"AV10Array_SdParticipantes","fld":"vARRAY_SDPARTICIPANTES","type":""},{"av":"AV40ContratoId","fld":"vCONTRATOID","pic":"ZZZZZ9","hsh":true,"type":"int"},{"av":"AV25ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("FREEGRID.LOAD","""{"handler":"E189R2","iparms":[{"av":"AV10Array_SdParticipantes","fld":"vARRAY_SDPARTICIPANTES","type":""}]""");
         setEventMetadata("FREEGRID.LOAD",""","oparms":[{"av":"AV5NomeParticipante","fld":"vNOMEPARTICIPANTE","type":"svchar"},{"av":"lblParticipantelabel_Caption","ctrl":"PARTICIPANTELABEL","prop":"Caption"},{"av":"AV14GRIDJSON","fld":"vGRIDJSON","type":"vchar"}]}""");
         setEventMetadata("'DOENVIARPARAASSINATURA'","""{"handler":"E139R2","iparms":[{"av":"AV10Array_SdParticipantes","fld":"vARRAY_SDPARTICIPANTES","type":""},{"av":"cmbavTipo"},{"av":"AV30Tipo","fld":"vTIPO","type":"boolean"},{"av":"AV29StringBase64","fld":"vSTRINGBASE64","type":"vchar"},{"av":"AV8Corpo","fld":"vCORPO","type":"vchar"},{"av":"AV9NomeContrato","fld":"vNOMECONTRATO","type":"svchar"},{"av":"AV40ContratoId","fld":"vCONTRATOID","pic":"ZZZZZ9","hsh":true,"type":"int"},{"av":"AV25ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV37Blob","fld":"vBLOB","type":"bitstr"}]""");
         setEventMetadata("'DOENVIARPARAASSINATURA'",""","oparms":[{"av":"AV38Contrato","fld":"vCONTRATO","type":""},{"av":"AV37Blob","fld":"vBLOB","type":"bitstr"},{"av":"AV10Array_SdParticipantes","fld":"vARRAY_SDPARTICIPANTES","type":""}]}""");
         setEventMetadata("'DOEDITAR'","""{"handler":"E159R2","iparms":[{"av":"AV10Array_SdParticipantes","fld":"vARRAY_SDPARTICIPANTES","type":""},{"av":"AV14GRIDJSON","fld":"vGRIDJSON","type":"vchar"}]}""");
         setEventMetadata("'DORETIRAR'","""{"handler":"E169R2","iparms":[{"av":"FREEGRID_nFirstRecordOnPage","type":"int"},{"av":"FREEGRID_nEOF","type":"int"},{"av":"edtavGridjson_Visible","ctrl":"vGRIDJSON","prop":"Visible"},{"av":"AV10Array_SdParticipantes","fld":"vARRAY_SDPARTICIPANTES","type":""},{"av":"AV40ContratoId","fld":"vCONTRATOID","pic":"ZZZZZ9","hsh":true,"type":"int"},{"av":"AV25ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV14GRIDJSON","fld":"vGRIDJSON","type":"vchar"}]""");
         setEventMetadata("'DORETIRAR'",""","oparms":[{"av":"AV10Array_SdParticipantes","fld":"vARRAY_SDPARTICIPANTES","type":""}]}""");
         setEventMetadata("'DOADICIONARPARTICIPANTE'","""{"handler":"E149R2","iparms":[{"av":"FREEGRID_nFirstRecordOnPage","type":"int"},{"av":"FREEGRID_nEOF","type":"int"},{"av":"edtavGridjson_Visible","ctrl":"vGRIDJSON","prop":"Visible"},{"av":"AV10Array_SdParticipantes","fld":"vARRAY_SDPARTICIPANTES","type":""},{"av":"AV40ContratoId","fld":"vCONTRATOID","pic":"ZZZZZ9","hsh":true,"type":"int"},{"av":"AV25ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("COMBO_LAYOUTCONTRATOID.ONOPTIONCLICKED","""{"handler":"E119R2","iparms":[{"av":"Combo_layoutcontratoid_Selectedvalue_get","ctrl":"COMBO_LAYOUTCONTRATOID","prop":"SelectedValue_get"},{"av":"A154LayoutContratoId","fld":"LAYOUTCONTRATOID","pic":"ZZZ9","type":"int"},{"av":"A157LayoutContratoCorpo","fld":"LAYOUTCONTRATOCORPO","type":"vchar"}]""");
         setEventMetadata("COMBO_LAYOUTCONTRATOID.ONOPTIONCLICKED",""","oparms":[{"av":"AV22LayoutContratoId","fld":"vLAYOUTCONTRATOID","pic":"ZZZ9","type":"int"},{"av":"AV8Corpo","fld":"vCORPO","type":"vchar"}]}""");
         setEventMetadata("FILEUPLOADER.UPLOADCOMPLETE","""{"handler":"E129R2","iparms":[{"av":"AV26UploadedFiles","fld":"vUPLOADEDFILES","type":""}]""");
         setEventMetadata("FILEUPLOADER.UPLOADCOMPLETE",""","oparms":[{"av":"AV29StringBase64","fld":"vSTRINGBASE64","type":"vchar"},{"ctrl":"WCWCPDFIFRAME"}]}""");
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

      public override bool UploadEnabled( )
      {
         return true ;
      }

      public override void initialize( )
      {
         Combo_layoutcontratoid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV10Array_SdParticipantes = new GXBaseCollection<SdtSdParticipantes>( context, "SdParticipantes", "Factory21");
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV23LayoutContratoId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV8Corpo = "";
         AV26UploadedFiles = new GXBaseCollection<SdtFileUploadData>( context, "FileUploadData", "Factory21");
         AV27FailedFiles = new GXBaseCollection<SdtFileUploadData>( context, "FileUploadData", "Factory21");
         AV29StringBase64 = "";
         AV37Blob = "";
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
         TempTags = "";
         lblTextblockcombo_layoutcontratoid_Jsonclick = "";
         ucCombo_layoutcontratoid = new GXUserControl();
         Combo_layoutcontratoid_Caption = "";
         AV9NomeContrato = "";
         ucCorpo = new GXUserControl();
         ucFileuploader = new GXUserControl();
         WebComp_Wcwcpdfiframe_Component = "";
         OldWcwcpdfiframe = "";
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
         AV48WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtWWPContext1 = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV31Base64 = "";
         H009R2_A249EmpresaId = new int[1] ;
         H009R2_A773EmpresaUtilizaRepresentanteAssinatura = new bool[] {false} ;
         H009R2_n773EmpresaUtilizaRepresentanteAssinatura = new bool[] {false} ;
         H009R2_A252EmpresaCNPJ = new string[] {""} ;
         H009R2_n252EmpresaCNPJ = new bool[] {false} ;
         H009R2_A470EmpresaEmail = new string[] {""} ;
         H009R2_n470EmpresaEmail = new bool[] {false} ;
         H009R2_A251EmpresaRazaoSocial = new string[] {""} ;
         H009R2_n251EmpresaRazaoSocial = new bool[] {false} ;
         H009R2_A770EmpresaRepresentanteCPF = new string[] {""} ;
         H009R2_n770EmpresaRepresentanteCPF = new bool[] {false} ;
         H009R2_A772EmpresaRepresentanteEmail = new string[] {""} ;
         H009R2_n772EmpresaRepresentanteEmail = new bool[] {false} ;
         H009R2_A771EmpresaRepresentanteNome = new string[] {""} ;
         H009R2_n771EmpresaRepresentanteNome = new bool[] {false} ;
         A252EmpresaCNPJ = "";
         A470EmpresaEmail = "";
         A251EmpresaRazaoSocial = "";
         A770EmpresaRepresentanteCPF = "";
         A772EmpresaRepresentanteEmail = "";
         A771EmpresaRepresentanteNome = "";
         H009R3_A478ConfiguracoesTestemunhasId = new int[1] ;
         H009R3_A133SecUserId = new short[1] ;
         H009R3_n133SecUserId = new bool[] {false} ;
         H009R3_A479ConfiguracoesTestemunhasNome = new string[] {""} ;
         H009R3_n479ConfiguracoesTestemunhasNome = new bool[] {false} ;
         H009R3_A480ConfiguracoesTestemunhasDocumento = new string[] {""} ;
         H009R3_n480ConfiguracoesTestemunhasDocumento = new bool[] {false} ;
         H009R3_A481ConfiguracoesTestemunhasEmail = new string[] {""} ;
         H009R3_n481ConfiguracoesTestemunhasEmail = new bool[] {false} ;
         A479ConfiguracoesTestemunhasNome = "";
         A480ConfiguracoesTestemunhasDocumento = "";
         A481ConfiguracoesTestemunhasEmail = "";
         AV38Contrato = new SdtContrato(context);
         AV13HTMLLine = "";
         FreegridRow = new GXWebRow();
         AV21GUID = Guid.Empty;
         AV34File = new GxFile(context.GetPhysicalPath());
         AV45HTML = "";
         AV35PdfPath = "";
         AV36PdfFile = new GxFile(context.GetPhysicalPath());
         AV42ErroMsg = "";
         AV44AuxArray_SdParticipantes = new GXBaseCollection<SdtSdParticipantes>( context, "SdParticipantes", "Factory21");
         AV41SdErro = new SdtSdErro(context);
         GXt_char2 = "";
         AV20WEBSESSIon = context.GetSession();
         AV17InJSON = "";
         AV18Array_JSON = "";
         H009R4_A154LayoutContratoId = new short[1] ;
         H009R4_A157LayoutContratoCorpo = new string[] {""} ;
         H009R4_n157LayoutContratoCorpo = new bool[] {false} ;
         H009R5_A906LayoutContratoTipo = new string[] {""} ;
         H009R5_n906LayoutContratoTipo = new bool[] {false} ;
         H009R5_A154LayoutContratoId = new short[1] ;
         H009R5_A155LayoutContratoDescricao = new string[] {""} ;
         H009R5_n155LayoutContratoDescricao = new bool[] {false} ;
         A906LayoutContratoTipo = "";
         A155LayoutContratoDescricao = "";
         AV24Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV28FileUploadData = new SdtFileUploadData(context);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.assinarcontrato__default(),
            new Object[][] {
                new Object[] {
               H009R2_A249EmpresaId, H009R2_A773EmpresaUtilizaRepresentanteAssinatura, H009R2_n773EmpresaUtilizaRepresentanteAssinatura, H009R2_A252EmpresaCNPJ, H009R2_n252EmpresaCNPJ, H009R2_A470EmpresaEmail, H009R2_n470EmpresaEmail, H009R2_A251EmpresaRazaoSocial, H009R2_n251EmpresaRazaoSocial, H009R2_A770EmpresaRepresentanteCPF,
               H009R2_n770EmpresaRepresentanteCPF, H009R2_A772EmpresaRepresentanteEmail, H009R2_n772EmpresaRepresentanteEmail, H009R2_A771EmpresaRepresentanteNome, H009R2_n771EmpresaRepresentanteNome
               }
               , new Object[] {
               H009R3_A478ConfiguracoesTestemunhasId, H009R3_A133SecUserId, H009R3_n133SecUserId, H009R3_A479ConfiguracoesTestemunhasNome, H009R3_n479ConfiguracoesTestemunhasNome, H009R3_A480ConfiguracoesTestemunhasDocumento, H009R3_n480ConfiguracoesTestemunhasDocumento, H009R3_A481ConfiguracoesTestemunhasEmail, H009R3_n481ConfiguracoesTestemunhasEmail
               }
               , new Object[] {
               H009R4_A154LayoutContratoId, H009R4_A157LayoutContratoCorpo, H009R4_n157LayoutContratoCorpo
               }
               , new Object[] {
               H009R5_A906LayoutContratoTipo, H009R5_n906LayoutContratoTipo, H009R5_A154LayoutContratoId, H009R5_A155LayoutContratoDescricao, H009R5_n155LayoutContratoDescricao
               }
            }
         );
         WebComp_Wcwcpdfiframe = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
         edtavNomeparticipante_Enabled = 0;
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
      private short A154LayoutContratoId ;
      private short AV16i ;
      private short wbEnd ;
      private short wbStart ;
      private short AV22LayoutContratoId ;
      private short nCmpId ;
      private short nDonePA ;
      private short subFreegrid_Backcolorstyle ;
      private short A133SecUserId ;
      private short gxcookieaux ;
      private short FREEGRID_nEOF ;
      private short nGXWrapped ;
      private short subFreegrid_Backstyle ;
      private short subFreegrid_Allowselection ;
      private short subFreegrid_Allowhovering ;
      private short subFreegrid_Allowcollapsing ;
      private short subFreegrid_Collapsed ;
      private int AV25ClienteId ;
      private int wcpOAV25ClienteId ;
      private int edtavGridjson_Visible ;
      private int nRC_GXsfl_77 ;
      private int subFreegrid_Recordcount ;
      private int nGXsfl_77_idx=1 ;
      private int AV40ContratoId ;
      private int AV58GXV6 ;
      private int Fileuploader_Maxnumberoffiles ;
      private int lblTextblockcombo_layoutcontratoid_Visible ;
      private int edtavNomecontrato_Enabled ;
      private int divTablecontractbody_Visible ;
      private int divTablecontractfile_Visible ;
      private int edtavLayoutcontratoid_Visible ;
      private int subFreegrid_Islastpage ;
      private int edtavNomeparticipante_Enabled ;
      private int AV51GXV1 ;
      private int AV52GXV2 ;
      private int AV53GXV3 ;
      private int AV54GXV4 ;
      private int AV57GXV5 ;
      private int idxLst ;
      private int subFreegrid_Backcolor ;
      private int subFreegrid_Allbackcolor ;
      private int subFreegrid_Selectedindex ;
      private int subFreegrid_Selectioncolor ;
      private int subFreegrid_Hoveringcolor ;
      private long FREEGRID_nCurrentRecord ;
      private long FREEGRID_nFirstRecordOnPage ;
      private string Combo_layoutcontratoid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_77_idx="0001" ;
      private string edtavGridjson_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Combo_layoutcontratoid_Cls ;
      private string Combo_layoutcontratoid_Selectedvalue_set ;
      private string Combo_layoutcontratoid_Emptyitemtext ;
      private string Corpo_Captionclass ;
      private string Corpo_Captionstyle ;
      private string Corpo_Captionposition ;
      private string Fileuploader_Acceptedfiletypes ;
      private string Fileuploader_Customfiletypes ;
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
      private string cmbavTipo_Internalname ;
      private string TempTags ;
      private string cmbavTipo_Jsonclick ;
      private string divTablesplittedlayoutcontratoid_Internalname ;
      private string lblTextblockcombo_layoutcontratoid_Internalname ;
      private string lblTextblockcombo_layoutcontratoid_Jsonclick ;
      private string Combo_layoutcontratoid_Caption ;
      private string Combo_layoutcontratoid_Internalname ;
      private string divContractpage_Internalname ;
      private string divEditor_Internalname ;
      private string edtavNomecontrato_Internalname ;
      private string edtavNomecontrato_Jsonclick ;
      private string divTablecontractbody_Internalname ;
      private string Corpo_Internalname ;
      private string divTablecontractfile_Internalname ;
      private string Fileuploader_Tooltiptext ;
      private string Fileuploader_Internalname ;
      private string WebComp_Wcwcpdfiframe_Component ;
      private string OldWcwcpdfiframe ;
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
      private string GXt_char2 ;
      private string tblTablemergedbtn_cancel_Internalname ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtnenviarparaassinatura_Internalname ;
      private string bttBtnenviarparaassinatura_Jsonclick ;
      private string lblParticipantelabel_Internalname ;
      private string sGXsfl_77_fel_idx="0001" ;
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
      private bool bGXsfl_77_Refreshing=false ;
      private bool AV19IsUpdate ;
      private bool Combo_layoutcontratoid_Visible ;
      private bool Corpo_Enabled ;
      private bool Fileuploader_Autoupload ;
      private bool Fileuploader_Hideadditionalbuttons ;
      private bool Fileuploader_Enableuploadedfilecanceling ;
      private bool Fileuploader_Autodisableaddingfiles ;
      private bool wbLoad ;
      private bool AV30Tipo ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool bDynCreated_Wcwcpdfiframe ;
      private bool A773EmpresaUtilizaRepresentanteAssinatura ;
      private bool n773EmpresaUtilizaRepresentanteAssinatura ;
      private bool n252EmpresaCNPJ ;
      private bool n470EmpresaEmail ;
      private bool n251EmpresaRazaoSocial ;
      private bool n770EmpresaRepresentanteCPF ;
      private bool n772EmpresaRepresentanteEmail ;
      private bool n771EmpresaRepresentanteNome ;
      private bool n133SecUserId ;
      private bool n479ConfiguracoesTestemunhasNome ;
      private bool n480ConfiguracoesTestemunhasDocumento ;
      private bool n481ConfiguracoesTestemunhasEmail ;
      private bool AV32IsHasContratante ;
      private bool AV33IsHasContratado ;
      private bool AV47IsArqOk ;
      private bool n157LayoutContratoCorpo ;
      private bool n906LayoutContratoTipo ;
      private bool n155LayoutContratoDescricao ;
      private string AV8Corpo ;
      private string AV29StringBase64 ;
      private string A157LayoutContratoCorpo ;
      private string AV12JSON ;
      private string AV14GRIDJSON ;
      private string AV31Base64 ;
      private string AV13HTMLLine ;
      private string AV45HTML ;
      private string AV17InJSON ;
      private string AV18Array_JSON ;
      private string AV9NomeContrato ;
      private string AV5NomeParticipante ;
      private string A252EmpresaCNPJ ;
      private string A470EmpresaEmail ;
      private string A251EmpresaRazaoSocial ;
      private string A770EmpresaRepresentanteCPF ;
      private string A772EmpresaRepresentanteEmail ;
      private string A771EmpresaRepresentanteNome ;
      private string A479ConfiguracoesTestemunhasNome ;
      private string A480ConfiguracoesTestemunhasDocumento ;
      private string A481ConfiguracoesTestemunhasEmail ;
      private string AV35PdfPath ;
      private string AV42ErroMsg ;
      private string A906LayoutContratoTipo ;
      private string A155LayoutContratoDescricao ;
      private Guid AV21GUID ;
      private string AV37Blob ;
      private GXWebComponent WebComp_Wcwcpdfiframe ;
      private GXWebGrid FreegridContainer ;
      private GXWebRow FreegridRow ;
      private GXWebColumn FreegridColumn ;
      private GXUserControl ucCombo_layoutcontratoid ;
      private GXUserControl ucCorpo ;
      private GXUserControl ucFileuploader ;
      private IGxSession AV20WEBSESSIon ;
      private GxFile AV34File ;
      private GxFile AV36PdfFile ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavTipo ;
      private GXBaseCollection<SdtSdParticipantes> AV10Array_SdParticipantes ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV23LayoutContratoId_Data ;
      private GXBaseCollection<SdtFileUploadData> AV26UploadedFiles ;
      private GXBaseCollection<SdtFileUploadData> AV27FailedFiles ;
      private SdtSdParticipantes AV15AuxSdParticipantes ;
      private SdtSdParticipantes AV11SdParticipantes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV48WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext GXt_SdtWWPContext1 ;
      private IDataStoreProvider pr_default ;
      private int[] H009R2_A249EmpresaId ;
      private bool[] H009R2_A773EmpresaUtilizaRepresentanteAssinatura ;
      private bool[] H009R2_n773EmpresaUtilizaRepresentanteAssinatura ;
      private string[] H009R2_A252EmpresaCNPJ ;
      private bool[] H009R2_n252EmpresaCNPJ ;
      private string[] H009R2_A470EmpresaEmail ;
      private bool[] H009R2_n470EmpresaEmail ;
      private string[] H009R2_A251EmpresaRazaoSocial ;
      private bool[] H009R2_n251EmpresaRazaoSocial ;
      private string[] H009R2_A770EmpresaRepresentanteCPF ;
      private bool[] H009R2_n770EmpresaRepresentanteCPF ;
      private string[] H009R2_A772EmpresaRepresentanteEmail ;
      private bool[] H009R2_n772EmpresaRepresentanteEmail ;
      private string[] H009R2_A771EmpresaRepresentanteNome ;
      private bool[] H009R2_n771EmpresaRepresentanteNome ;
      private int[] H009R3_A478ConfiguracoesTestemunhasId ;
      private short[] H009R3_A133SecUserId ;
      private bool[] H009R3_n133SecUserId ;
      private string[] H009R3_A479ConfiguracoesTestemunhasNome ;
      private bool[] H009R3_n479ConfiguracoesTestemunhasNome ;
      private string[] H009R3_A480ConfiguracoesTestemunhasDocumento ;
      private bool[] H009R3_n480ConfiguracoesTestemunhasDocumento ;
      private string[] H009R3_A481ConfiguracoesTestemunhasEmail ;
      private bool[] H009R3_n481ConfiguracoesTestemunhasEmail ;
      private SdtContrato AV38Contrato ;
      private GXBaseCollection<SdtSdParticipantes> AV44AuxArray_SdParticipantes ;
      private SdtSdErro AV41SdErro ;
      private short[] H009R4_A154LayoutContratoId ;
      private string[] H009R4_A157LayoutContratoCorpo ;
      private bool[] H009R4_n157LayoutContratoCorpo ;
      private string[] H009R5_A906LayoutContratoTipo ;
      private bool[] H009R5_n906LayoutContratoTipo ;
      private short[] H009R5_A154LayoutContratoId ;
      private string[] H009R5_A155LayoutContratoDescricao ;
      private bool[] H009R5_n155LayoutContratoDescricao ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV24Combo_DataItem ;
      private SdtFileUploadData AV28FileUploadData ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class assinarcontrato__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH009R2;
          prmH009R2 = new Object[] {
          };
          Object[] prmH009R3;
          prmH009R3 = new Object[] {
          new ParDef("AV48WWPContext__Userid",GXType.Int16,4,0)
          };
          Object[] prmH009R4;
          prmH009R4 = new Object[] {
          new ParDef("AV22LayoutContratoId",GXType.Int16,4,0)
          };
          Object[] prmH009R5;
          prmH009R5 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H009R2", "SELECT EmpresaId, EmpresaUtilizaRepresentanteAssinatura, EmpresaCNPJ, EmpresaEmail, EmpresaRazaoSocial, EmpresaRepresentanteCPF, EmpresaRepresentanteEmail, EmpresaRepresentanteNome FROM Empresa WHERE EmpresaUtilizaRepresentanteAssinatura ORDER BY EmpresaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009R2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H009R3", "SELECT ConfiguracoesTestemunhasId, SecUserId, ConfiguracoesTestemunhasNome, ConfiguracoesTestemunhasDocumento, ConfiguracoesTestemunhasEmail FROM ConfiguracoesTestemunhas WHERE SecUserId = :AV48WWPContext__Userid ORDER BY SecUserId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009R3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H009R4", "SELECT LayoutContratoId, LayoutContratoCorpo FROM LayoutContrato WHERE LayoutContratoId = :AV22LayoutContratoId ORDER BY LayoutContratoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009R4,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H009R5", "SELECT LayoutContratoTipo, LayoutContratoId, LayoutContratoDescricao FROM LayoutContrato WHERE LayoutContratoTipo = ( 'C') ORDER BY LayoutContratoDescricao ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009R5,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
       }
    }

 }

}
