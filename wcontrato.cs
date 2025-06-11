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
   public class wcontrato : GXDataArea
   {
      public wcontrato( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wcontrato( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_ClienteId ,
                           int aP1_ContratoId ,
                           string aP2_TrnMode )
      {
         this.AV21ClienteId = aP0_ClienteId;
         this.AV22ContratoId = aP1_ContratoId;
         this.AV28TrnMode = aP2_TrnMode;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkavContratocomvigencia = new GXCheckbox();
         chkavContratoassinado = new GXCheckbox();
         chkavTipocontrato = new GXCheckbox();
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
         PA6B2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START6B2( ) ;
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
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
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
         GXEncryptionTmp = "wcontrato"+UrlEncode(StringUtil.LTrimStr(AV21ClienteId,9,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV22ContratoId,6,0)) + "," + UrlEncode(StringUtil.RTrim(AV28TrnMode));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wcontrato") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV21ClienteId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vCONTRATOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22ContratoId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCONTRATOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV22ContratoId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTRNMODE", StringUtil.RTrim( AV28TrnMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV28TrnMode, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vCONTRATOCORPO", AV30ContratoCorpo);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vLAYOUTCONTRATOID_DATA", AV7LayoutContratoId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vLAYOUTCONTRATOID_DATA", AV7LayoutContratoId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUPLOADEDFILES", AV10UploadedFiles);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUPLOADEDFILES", AV10UploadedFiles);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFAILEDFILES", AV11FailedFiles);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFAILEDFILES", AV11FailedFiles);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vCHECKREQUIREDFIELDSRESULT", AV29CheckRequiredFieldsResult);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCONTRATO", AV23Contrato);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCONTRATO", AV23Contrato);
         }
         GxWebStd.gx_hidden_field( context, "vBLOB", AV9Blob);
         GxWebStd.gx_hidden_field( context, "vCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV21ClienteId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vCONTRATOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22ContratoId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCONTRATOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV22ContratoId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTRNMODE", StringUtil.RTrim( AV28TrnMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV28TrnMode, "")), context));
         GxWebStd.gx_hidden_field( context, "CONTRATOCORPO_Enabled", StringUtil.BoolToStr( Contratocorpo_Enabled));
         GxWebStd.gx_hidden_field( context, "CONTRATOCORPO_Captionclass", StringUtil.RTrim( Contratocorpo_Captionclass));
         GxWebStd.gx_hidden_field( context, "CONTRATOCORPO_Captionstyle", StringUtil.RTrim( Contratocorpo_Captionstyle));
         GxWebStd.gx_hidden_field( context, "CONTRATOCORPO_Captionposition", StringUtil.RTrim( Contratocorpo_Captionposition));
         GxWebStd.gx_hidden_field( context, "COMBO_LAYOUTCONTRATOID_Cls", StringUtil.RTrim( Combo_layoutcontratoid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_LAYOUTCONTRATOID_Selectedvalue_set", StringUtil.RTrim( Combo_layoutcontratoid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_LAYOUTCONTRATOID_Emptyitem", StringUtil.BoolToStr( Combo_layoutcontratoid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "FILE_Maxnumberoffiles", StringUtil.LTrim( StringUtil.NToC( (decimal)(File_Maxnumberoffiles), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FILE_Acceptedfiletypes", StringUtil.RTrim( File_Acceptedfiletypes));
         GxWebStd.gx_hidden_field( context, "FILE_Customfiletypes", StringUtil.RTrim( File_Customfiletypes));
         GxWebStd.gx_hidden_field( context, "COMBO_LAYOUTCONTRATOID_Selectedvalue_get", StringUtil.RTrim( Combo_layoutcontratoid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_LAYOUTCONTRATOID_Ddointernalname", StringUtil.RTrim( Combo_layoutcontratoid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, "COMBO_LAYOUTCONTRATOID_Ddointernalname", StringUtil.RTrim( Combo_layoutcontratoid_Ddointernalname));
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
            WE6B2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT6B2( ) ;
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
         GXEncryptionTmp = "wcontrato"+UrlEncode(StringUtil.LTrimStr(AV21ClienteId,9,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV22ContratoId,6,0)) + "," + UrlEncode(StringUtil.RTrim(AV28TrnMode));
         return formatLink("wcontrato") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WContrato" ;
      }

      public override string GetPgmdesc( )
      {
         return "Contrato" ;
      }

      protected void WB6B0( )
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
            GxWebStd.gx_div_start( context, divTablecontratofields_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavContratonome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContratonome_Internalname, "Nome do contrato", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContratonome_Internalname, AV13ContratoNome, StringUtil.RTrim( context.localUtil.Format( AV13ContratoNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,17);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContratonome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavContratonome_Enabled, 1, "text", "", 80, "chr", 1, "row", 125, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WContrato.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavContratocomvigencia_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavContratocomvigencia_Internalname, "Contrato com vigência", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavContratocomvigencia_Internalname, StringUtil.BoolToStr( AV14ContratoComVigencia), "", "Contrato com vigência", 1, chkavContratocomvigencia.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(21, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,21);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divContratodatainicial_cell_Internalname, 1, 0, "px", 0, "px", divContratodatainicial_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavContratodatainicial_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavContratodatainicial_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContratodatainicial_Internalname, "Data inicial", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavContratodatainicial_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavContratodatainicial_Internalname, context.localUtil.Format(AV15ContratoDataInicial, "99/99/99"), context.localUtil.Format( AV15ContratoDataInicial, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContratodatainicial_Jsonclick, 0, "AttributeFL", "", "", "", "", edtavContratodatainicial_Visible, edtavContratodatainicial_Enabled, 1, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WContrato.htm");
            GxWebStd.gx_bitmap( context, edtavContratodatainicial_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtavContratodatainicial_Visible==0)||(edtavContratodatainicial_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WContrato.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divContratodatafinal_cell_Internalname, 1, 0, "px", 0, "px", divContratodatafinal_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavContratodatafinal_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavContratodatafinal_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContratodatafinal_Internalname, "Data final", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavContratodatafinal_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavContratodatafinal_Internalname, context.localUtil.Format(AV16ContratoDataFinal, "99/99/99"), context.localUtil.Format( AV16ContratoDataFinal, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContratodatafinal_Jsonclick, 0, "AttributeFL", "", "", "", "", edtavContratodatafinal_Visible, edtavContratodatafinal_Enabled, 1, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WContrato.htm");
            GxWebStd.gx_bitmap( context, edtavContratodatafinal_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtavContratodatafinal_Visible==0)||(edtavContratodatafinal_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WContrato.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavContratoiofminimo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContratoiofminimo_Internalname, "% IOF minímo", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContratoiofminimo_Internalname, StringUtil.LTrim( StringUtil.NToC( AV17ContratoIOFMinimo, 21, 4, ",", "")), StringUtil.LTrim( context.localUtil.Format( AV17ContratoIOFMinimo, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContratoiofminimo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavContratoiofminimo_Enabled, 1, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WContrato.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavContratotaxa_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContratotaxa_Internalname, "% Taxa", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContratotaxa_Internalname, StringUtil.LTrim( StringUtil.NToC( AV18ContratoTaxa, 21, 4, ",", "")), StringUtil.LTrim( context.localUtil.Format( AV18ContratoTaxa, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContratotaxa_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavContratotaxa_Enabled, 1, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WContrato.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavContratojurosmora_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContratojurosmora_Internalname, "% Juros mora", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContratojurosmora_Internalname, StringUtil.LTrim( StringUtil.NToC( AV19ContratoJurosMora, 21, 4, ",", "")), StringUtil.LTrim( context.localUtil.Format( AV19ContratoJurosMora, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContratojurosmora_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavContratojurosmora_Enabled, 1, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WContrato.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavContratosla_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContratosla_Internalname, "SLA (dias) cobrança taxa", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContratosla_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20ContratoSLA), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV20ContratoSLA), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContratosla_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavContratosla_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WContrato.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontratocorpo_Internalname, divTablecontratocorpo_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divContratocorpofck_Internalname, 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", -1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+Contratocorpo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, Contratocorpo_Internalname, "Contrato Corpo", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* User Defined Control */
            ucContratocorpo.SetProperty("Attribute", AV30ContratoCorpo);
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
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTxtcorpo_Internalname, lblTxtcorpo_Caption, "", "", lblTxtcorpo_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", lblTxtcorpo_Visible, 1, 0, 2, "HLP_WContrato.htm");
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
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, divTablecontent_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablelayoutfield_Internalname, divTablelayoutfield_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedlayoutcontratoid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_layoutcontratoid_Internalname, "Layout", "", "", lblTextblockcombo_layoutcontratoid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WContrato.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_layoutcontratoid.SetProperty("Caption", Combo_layoutcontratoid_Caption);
            ucCombo_layoutcontratoid.SetProperty("Cls", Combo_layoutcontratoid_Cls);
            ucCombo_layoutcontratoid.SetProperty("EmptyItem", Combo_layoutcontratoid_Emptyitem);
            ucCombo_layoutcontratoid.SetProperty("DropDownOptionsData", AV7LayoutContratoId_Data);
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
            GxWebStd.gx_div_start( context, divTableblob_Internalname, divTableblob_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucFile.SetProperty("TooltipText", File_Tooltiptext);
            ucFile.SetProperty("MaxNumberOfFiles", File_Maxnumberoffiles);
            ucFile.SetProperty("AcceptedFileTypes", File_Acceptedfiletypes);
            ucFile.SetProperty("CustomFileTypes", File_Customfiletypes);
            ucFile.SetProperty("UploadedFiles", AV10UploadedFiles);
            ucFile.SetProperty("FailedFiles", AV11FailedFiles);
            ucFile.Render(context, "fileupload", File_Internalname, "FILEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavContratoassinado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavContratoassinado_Internalname, "Contrato assinado", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavContratoassinado_Internalname, StringUtil.BoolToStr( AV24ContratoAssinado), "", "Contrato assinado", 1, chkavContratoassinado.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(84, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,84);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", "Confirmar", bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WContrato.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", "Fechar", bttBtncancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WContrato.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLayoutcontratoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6LayoutContratoId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV6LayoutContratoId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,95);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLayoutcontratoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavLayoutcontratoid_Visible, 1, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WContrato.htm");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTipocontrato_Internalname, StringUtil.BoolToStr( AV5TipoContrato), "", "", chkavTipocontrato.Visible, 1, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(96, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,96);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START6B2( )
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
         STRUP6B0( ) ;
      }

      protected void WS6B2( )
      {
         START6B2( ) ;
         EVT6B2( ) ;
      }

      protected void EVT6B2( )
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
                              E116B2 ();
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
                                    E126B2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E136B2 ();
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

      protected void WE6B2( )
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

      protected void PA6B2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wcontrato")), "wcontrato") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wcontrato")))) ;
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
                     AV21ClienteId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV21ClienteId", StringUtil.LTrimStr( (decimal)(AV21ClienteId), 9, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV21ClienteId), "ZZZZZZZZ9"), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV22ContratoId = (int)(Math.Round(NumberUtil.Val( GetPar( "ContratoId"), "."), 18, MidpointRounding.ToEven));
                        AssignAttri("", false, "AV22ContratoId", StringUtil.LTrimStr( (decimal)(AV22ContratoId), 6, 0));
                        GxWebStd.gx_hidden_field( context, "gxhash_vCONTRATOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV22ContratoId), "ZZZZZ9"), context));
                        AV28TrnMode = GetPar( "TrnMode");
                        AssignAttri("", false, "AV28TrnMode", AV28TrnMode);
                        GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV28TrnMode, "")), context));
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
         AV14ContratoComVigencia = StringUtil.StrToBool( StringUtil.BoolToStr( AV14ContratoComVigencia));
         AssignAttri("", false, "AV14ContratoComVigencia", AV14ContratoComVigencia);
         AV24ContratoAssinado = StringUtil.StrToBool( StringUtil.BoolToStr( AV24ContratoAssinado));
         AssignAttri("", false, "AV24ContratoAssinado", AV24ContratoAssinado);
         AV5TipoContrato = StringUtil.StrToBool( StringUtil.BoolToStr( AV5TipoContrato));
         AssignAttri("", false, "AV5TipoContrato", AV5TipoContrato);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF6B2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF6B2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E136B2 ();
            WB6B0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes6B2( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP6B0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E116B2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vLAYOUTCONTRATOID_DATA"), AV7LayoutContratoId_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vUPLOADEDFILES"), AV10UploadedFiles);
            ajax_req_read_hidden_sdt(cgiGet( "vFAILEDFILES"), AV11FailedFiles);
            /* Read saved values. */
            AV30ContratoCorpo = cgiGet( "vCONTRATOCORPO");
            AssignAttri("", false, "AV30ContratoCorpo", AV30ContratoCorpo);
            Contratocorpo_Enabled = StringUtil.StrToBool( cgiGet( "CONTRATOCORPO_Enabled"));
            Contratocorpo_Captionclass = cgiGet( "CONTRATOCORPO_Captionclass");
            Contratocorpo_Captionstyle = cgiGet( "CONTRATOCORPO_Captionstyle");
            Contratocorpo_Captionposition = cgiGet( "CONTRATOCORPO_Captionposition");
            Combo_layoutcontratoid_Cls = cgiGet( "COMBO_LAYOUTCONTRATOID_Cls");
            Combo_layoutcontratoid_Selectedvalue_set = cgiGet( "COMBO_LAYOUTCONTRATOID_Selectedvalue_set");
            Combo_layoutcontratoid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_LAYOUTCONTRATOID_Emptyitem"));
            File_Maxnumberoffiles = (int)(Math.Round(context.localUtil.CToN( cgiGet( "FILE_Maxnumberoffiles"), ",", "."), 18, MidpointRounding.ToEven));
            File_Acceptedfiletypes = cgiGet( "FILE_Acceptedfiletypes");
            File_Customfiletypes = cgiGet( "FILE_Customfiletypes");
            Combo_layoutcontratoid_Ddointernalname = cgiGet( "COMBO_LAYOUTCONTRATOID_Ddointernalname");
            /* Read variables values. */
            AV13ContratoNome = cgiGet( edtavContratonome_Internalname);
            AssignAttri("", false, "AV13ContratoNome", AV13ContratoNome);
            AV14ContratoComVigencia = StringUtil.StrToBool( cgiGet( chkavContratocomvigencia_Internalname));
            AssignAttri("", false, "AV14ContratoComVigencia", AV14ContratoComVigencia);
            if ( context.localUtil.VCDate( cgiGet( edtavContratodatainicial_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Contrato Data Inicial"}), 1, "vCONTRATODATAINICIAL");
               GX_FocusControl = edtavContratodatainicial_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV15ContratoDataInicial = DateTime.MinValue;
               AssignAttri("", false, "AV15ContratoDataInicial", context.localUtil.Format(AV15ContratoDataInicial, "99/99/99"));
            }
            else
            {
               AV15ContratoDataInicial = context.localUtil.CToD( cgiGet( edtavContratodatainicial_Internalname), 2);
               AssignAttri("", false, "AV15ContratoDataInicial", context.localUtil.Format(AV15ContratoDataInicial, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavContratodatafinal_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Contrato Data Final"}), 1, "vCONTRATODATAFINAL");
               GX_FocusControl = edtavContratodatafinal_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV16ContratoDataFinal = DateTime.MinValue;
               AssignAttri("", false, "AV16ContratoDataFinal", context.localUtil.Format(AV16ContratoDataFinal, "99/99/99"));
            }
            else
            {
               AV16ContratoDataFinal = context.localUtil.CToD( cgiGet( edtavContratodatafinal_Internalname), 2);
               AssignAttri("", false, "AV16ContratoDataFinal", context.localUtil.Format(AV16ContratoDataFinal, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavContratoiofminimo_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavContratoiofminimo_Internalname), ",", ".") > 99999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCONTRATOIOFMINIMO");
               GX_FocusControl = edtavContratoiofminimo_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV17ContratoIOFMinimo = 0;
               AssignAttri("", false, "AV17ContratoIOFMinimo", StringUtil.LTrimStr( AV17ContratoIOFMinimo, 16, 4));
            }
            else
            {
               AV17ContratoIOFMinimo = context.localUtil.CToN( cgiGet( edtavContratoiofminimo_Internalname), ",", ".");
               AssignAttri("", false, "AV17ContratoIOFMinimo", StringUtil.LTrimStr( AV17ContratoIOFMinimo, 16, 4));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavContratotaxa_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavContratotaxa_Internalname), ",", ".") > 99999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCONTRATOTAXA");
               GX_FocusControl = edtavContratotaxa_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV18ContratoTaxa = 0;
               AssignAttri("", false, "AV18ContratoTaxa", StringUtil.LTrimStr( AV18ContratoTaxa, 16, 4));
            }
            else
            {
               AV18ContratoTaxa = context.localUtil.CToN( cgiGet( edtavContratotaxa_Internalname), ",", ".");
               AssignAttri("", false, "AV18ContratoTaxa", StringUtil.LTrimStr( AV18ContratoTaxa, 16, 4));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavContratojurosmora_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavContratojurosmora_Internalname), ",", ".") > 99999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCONTRATOJUROSMORA");
               GX_FocusControl = edtavContratojurosmora_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV19ContratoJurosMora = 0;
               AssignAttri("", false, "AV19ContratoJurosMora", StringUtil.LTrimStr( AV19ContratoJurosMora, 16, 4));
            }
            else
            {
               AV19ContratoJurosMora = context.localUtil.CToN( cgiGet( edtavContratojurosmora_Internalname), ",", ".");
               AssignAttri("", false, "AV19ContratoJurosMora", StringUtil.LTrimStr( AV19ContratoJurosMora, 16, 4));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavContratosla_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavContratosla_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCONTRATOSLA");
               GX_FocusControl = edtavContratosla_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV20ContratoSLA = 0;
               AssignAttri("", false, "AV20ContratoSLA", StringUtil.LTrimStr( (decimal)(AV20ContratoSLA), 4, 0));
            }
            else
            {
               AV20ContratoSLA = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavContratosla_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV20ContratoSLA", StringUtil.LTrimStr( (decimal)(AV20ContratoSLA), 4, 0));
            }
            AV24ContratoAssinado = StringUtil.StrToBool( cgiGet( chkavContratoassinado_Internalname));
            AssignAttri("", false, "AV24ContratoAssinado", AV24ContratoAssinado);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavLayoutcontratoid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavLayoutcontratoid_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vLAYOUTCONTRATOID");
               GX_FocusControl = edtavLayoutcontratoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6LayoutContratoId = 0;
               AssignAttri("", false, "AV6LayoutContratoId", StringUtil.LTrimStr( (decimal)(AV6LayoutContratoId), 4, 0));
            }
            else
            {
               AV6LayoutContratoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavLayoutcontratoid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6LayoutContratoId", StringUtil.LTrimStr( (decimal)(AV6LayoutContratoId), 4, 0));
            }
            AV5TipoContrato = StringUtil.StrToBool( cgiGet( chkavTipocontrato_Internalname));
            AssignAttri("", false, "AV5TipoContrato", AV5TipoContrato);
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
         E116B2 ();
         if (returnInSub) return;
      }

      protected void E116B2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV5TipoContrato = true;
         AssignAttri("", false, "AV5TipoContrato", AV5TipoContrato);
         if ( StringUtil.StrCmp(AV28TrnMode, "DSP") == 0 )
         {
            AV23Contrato.Load(AV22ContratoId);
            AV13ContratoNome = AV23Contrato.gxTpr_Contratonome;
            AssignAttri("", false, "AV13ContratoNome", AV13ContratoNome);
            AV14ContratoComVigencia = AV23Contrato.gxTpr_Contratocomvigencia;
            AssignAttri("", false, "AV14ContratoComVigencia", AV14ContratoComVigencia);
            AV15ContratoDataInicial = AV23Contrato.gxTpr_Contratodatainicial;
            AssignAttri("", false, "AV15ContratoDataInicial", context.localUtil.Format(AV15ContratoDataInicial, "99/99/99"));
            AV16ContratoDataFinal = AV23Contrato.gxTpr_Contratodatafinal;
            AssignAttri("", false, "AV16ContratoDataFinal", context.localUtil.Format(AV16ContratoDataFinal, "99/99/99"));
            AV18ContratoTaxa = AV23Contrato.gxTpr_Contratotaxa;
            AssignAttri("", false, "AV18ContratoTaxa", StringUtil.LTrimStr( AV18ContratoTaxa, 16, 4));
            AV20ContratoSLA = AV23Contrato.gxTpr_Contratosla;
            AssignAttri("", false, "AV20ContratoSLA", StringUtil.LTrimStr( (decimal)(AV20ContratoSLA), 4, 0));
            AV19ContratoJurosMora = AV23Contrato.gxTpr_Contratojurosmora;
            AssignAttri("", false, "AV19ContratoJurosMora", StringUtil.LTrimStr( AV19ContratoJurosMora, 16, 4));
            AV17ContratoIOFMinimo = AV23Contrato.gxTpr_Contratoiofminimo;
            AssignAttri("", false, "AV17ContratoIOFMinimo", StringUtil.LTrimStr( AV17ContratoIOFMinimo, 16, 4));
            AV30ContratoCorpo = AV23Contrato.gxTpr_Contratocorpo;
            AssignAttri("", false, "AV30ContratoCorpo", AV30ContratoCorpo);
            divTablecontent_Visible = 0;
            AssignProp("", false, divTablecontent_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablecontent_Visible), 5, 0), true);
            edtavContratonome_Enabled = 0;
            AssignProp("", false, edtavContratonome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavContratonome_Enabled), 5, 0), true);
            chkavContratocomvigencia.Enabled = 0;
            AssignProp("", false, chkavContratocomvigencia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavContratocomvigencia.Enabled), 5, 0), true);
            edtavContratodatainicial_Enabled = 0;
            AssignProp("", false, edtavContratodatainicial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavContratodatainicial_Enabled), 5, 0), true);
            edtavContratodatafinal_Enabled = 0;
            AssignProp("", false, edtavContratodatafinal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavContratodatafinal_Enabled), 5, 0), true);
            edtavContratotaxa_Enabled = 0;
            AssignProp("", false, edtavContratotaxa_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavContratotaxa_Enabled), 5, 0), true);
            edtavContratosla_Enabled = 0;
            AssignProp("", false, edtavContratosla_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavContratosla_Enabled), 5, 0), true);
            edtavContratojurosmora_Enabled = 0;
            AssignProp("", false, edtavContratojurosmora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavContratojurosmora_Enabled), 5, 0), true);
            edtavContratoiofminimo_Enabled = 0;
            AssignProp("", false, edtavContratoiofminimo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavContratoiofminimo_Enabled), 5, 0), true);
            divTablecontratocorpo_Visible = 0;
            AssignProp("", false, divTablecontratocorpo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablecontratocorpo_Visible), 5, 0), true);
            lblTxtcorpo_Visible = 1;
            AssignProp("", false, lblTxtcorpo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTxtcorpo_Visible), 5, 0), true);
            lblTxtcorpo_Caption = AV30ContratoCorpo;
            AssignProp("", false, lblTxtcorpo_Internalname, "Caption", lblTxtcorpo_Caption, true);
         }
         else if ( StringUtil.StrCmp(AV28TrnMode, "INS") == 0 )
         {
            AV23Contrato.Load(AV22ContratoId);
            if ( AV23Contrato.Fail() )
            {
               AV23Contrato.gxTpr_Contratoclienteid = AV21ClienteId;
            }
            /* Using cursor H006B2 */
            pr_default.execute(0, new Object[] {AV21ClienteId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A168ClienteId = H006B2_A168ClienteId[0];
               A170ClienteRazaoSocial = H006B2_A170ClienteRazaoSocial[0];
               n170ClienteRazaoSocial = H006B2_n170ClienteRazaoSocial[0];
               AV13ContratoNome = A170ClienteRazaoSocial;
               AssignAttri("", false, "AV13ContratoNome", AV13ContratoNome);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            divTablecontratocorpo_Visible = 0;
            AssignProp("", false, divTablecontratocorpo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablecontratocorpo_Visible), 5, 0), true);
            lblTxtcorpo_Visible = 0;
            AssignProp("", false, lblTxtcorpo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTxtcorpo_Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV28TrnMode, "UPD") == 0 )
         {
            AV23Contrato.Load(AV22ContratoId);
            AV13ContratoNome = AV23Contrato.gxTpr_Contratonome;
            AssignAttri("", false, "AV13ContratoNome", AV13ContratoNome);
            AV14ContratoComVigencia = AV23Contrato.gxTpr_Contratocomvigencia;
            AssignAttri("", false, "AV14ContratoComVigencia", AV14ContratoComVigencia);
            AV15ContratoDataInicial = AV23Contrato.gxTpr_Contratodatainicial;
            AssignAttri("", false, "AV15ContratoDataInicial", context.localUtil.Format(AV15ContratoDataInicial, "99/99/99"));
            AV16ContratoDataFinal = AV23Contrato.gxTpr_Contratodatafinal;
            AssignAttri("", false, "AV16ContratoDataFinal", context.localUtil.Format(AV16ContratoDataFinal, "99/99/99"));
            AV18ContratoTaxa = AV23Contrato.gxTpr_Contratotaxa;
            AssignAttri("", false, "AV18ContratoTaxa", StringUtil.LTrimStr( AV18ContratoTaxa, 16, 4));
            AV20ContratoSLA = AV23Contrato.gxTpr_Contratosla;
            AssignAttri("", false, "AV20ContratoSLA", StringUtil.LTrimStr( (decimal)(AV20ContratoSLA), 4, 0));
            AV19ContratoJurosMora = AV23Contrato.gxTpr_Contratojurosmora;
            AssignAttri("", false, "AV19ContratoJurosMora", StringUtil.LTrimStr( AV19ContratoJurosMora, 16, 4));
            AV17ContratoIOFMinimo = AV23Contrato.gxTpr_Contratoiofminimo;
            AssignAttri("", false, "AV17ContratoIOFMinimo", StringUtil.LTrimStr( AV17ContratoIOFMinimo, 16, 4));
            AV30ContratoCorpo = AV23Contrato.gxTpr_Contratocorpo;
            AssignAttri("", false, "AV30ContratoCorpo", AV30ContratoCorpo);
            divTablecontent_Visible = 0;
            AssignProp("", false, divTablecontent_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablecontent_Visible), 5, 0), true);
            divTablecontratocorpo_Visible = 1;
            AssignProp("", false, divTablecontratocorpo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablecontratocorpo_Visible), 5, 0), true);
            lblTxtcorpo_Visible = 0;
            AssignProp("", false, lblTxtcorpo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTxtcorpo_Visible), 5, 0), true);
         }
         edtavLayoutcontratoid_Visible = 0;
         AssignProp("", false, edtavLayoutcontratoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLayoutcontratoid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOLAYOUTCONTRATOID' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S122 ();
         if (returnInSub) return;
         chkavTipocontrato.Visible = 0;
         AssignProp("", false, chkavTipocontrato_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavTipocontrato.Visible), 5, 0), true);
         AV24ContratoAssinado = false;
         AssignAttri("", false, "AV24ContratoAssinado", AV24ContratoAssinado);
         /* Execute user subroutine: 'TIPOCONTRATO' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'CONTRATOCOMVIGENCIA' */
         S142 ();
         if (returnInSub) return;
      }

      protected void S152( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV29CheckRequiredFieldsResult = true;
         AssignAttri("", false, "AV29CheckRequiredFieldsResult", AV29CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13ContratoNome)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Nome do contrato", "", "", "", "", "", "", "", ""),  "error",  edtavContratonome_Internalname,  "true",  ""));
            AV29CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV29CheckRequiredFieldsResult", AV29CheckRequiredFieldsResult);
         }
         if ( ( AV14ContratoComVigencia ) && (DateTime.MinValue==AV15ContratoDataInicial) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Data inicial", "", "", "", "", "", "", "", ""),  "error",  edtavContratodatainicial_Internalname,  "true",  ""));
            AV29CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV29CheckRequiredFieldsResult", AV29CheckRequiredFieldsResult);
         }
         if ( ( AV14ContratoComVigencia ) && (DateTime.MinValue==AV16ContratoDataFinal) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Data final", "", "", "", "", "", "", "", ""),  "error",  edtavContratodatafinal_Internalname,  "true",  ""));
            AV29CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV29CheckRequiredFieldsResult", AV29CheckRequiredFieldsResult);
         }
         if ( (Convert.ToDecimal(0)==AV17ContratoIOFMinimo) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "% IOF minímo", "", "", "", "", "", "", "", ""),  "error",  edtavContratoiofminimo_Internalname,  "true",  ""));
            AV29CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV29CheckRequiredFieldsResult", AV29CheckRequiredFieldsResult);
         }
         if ( (Convert.ToDecimal(0)==AV18ContratoTaxa) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "% Taxa", "", "", "", "", "", "", "", ""),  "error",  edtavContratotaxa_Internalname,  "true",  ""));
            AV29CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV29CheckRequiredFieldsResult", AV29CheckRequiredFieldsResult);
         }
         if ( (Convert.ToDecimal(0)==AV19ContratoJurosMora) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "% Juros mora", "", "", "", "", "", "", "", ""),  "error",  edtavContratojurosmora_Internalname,  "true",  ""));
            AV29CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV29CheckRequiredFieldsResult", AV29CheckRequiredFieldsResult);
         }
         if ( (0==AV20ContratoSLA) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "SLA (dias) cobrança taxa", "", "", "", "", "", "", "", ""),  "error",  edtavContratosla_Internalname,  "true",  ""));
            AV29CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV29CheckRequiredFieldsResult", AV29CheckRequiredFieldsResult);
         }
         if ( (0==AV6LayoutContratoId) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Selecione um layout para continuar",  "error",  Combo_layoutcontratoid_Ddointernalname,  "true",  ""));
            AV29CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV29CheckRequiredFieldsResult", AV29CheckRequiredFieldsResult);
         }
      }

      protected void S122( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( AV14ContratoComVigencia )
         {
            divContratodatainicial_cell_Class = "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL";
            AssignProp("", false, divContratodatainicial_cell_Internalname, "Class", divContratodatainicial_cell_Class, true);
         }
         else
         {
            divContratodatainicial_cell_Class = "col-xs-12 col-sm-6 DataContentCellFL";
            AssignProp("", false, divContratodatainicial_cell_Internalname, "Class", divContratodatainicial_cell_Class, true);
         }
         if ( AV14ContratoComVigencia )
         {
            divContratodatafinal_cell_Class = "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL";
            AssignProp("", false, divContratodatafinal_cell_Internalname, "Class", divContratodatafinal_cell_Class, true);
         }
         else
         {
            divContratodatafinal_cell_Class = "col-xs-12 col-sm-6 DataContentCellFL";
            AssignProp("", false, divContratodatafinal_cell_Internalname, "Class", divContratodatafinal_cell_Class, true);
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOLAYOUTCONTRATOID' Routine */
         returnInSub = false;
         /* Using cursor H006B3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A906LayoutContratoTipo = H006B3_A906LayoutContratoTipo[0];
            n906LayoutContratoTipo = H006B3_n906LayoutContratoTipo[0];
            A156LayoutContratoStatus = H006B3_A156LayoutContratoStatus[0];
            n156LayoutContratoStatus = H006B3_n156LayoutContratoStatus[0];
            A154LayoutContratoId = H006B3_A154LayoutContratoId[0];
            A155LayoutContratoDescricao = H006B3_A155LayoutContratoDescricao[0];
            n155LayoutContratoDescricao = H006B3_n155LayoutContratoDescricao[0];
            AV8Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV8Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A154LayoutContratoId), 4, 0));
            AV8Combo_DataItem.gxTpr_Title = A155LayoutContratoDescricao;
            AV7LayoutContratoId_Data.Add(AV8Combo_DataItem, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         Combo_layoutcontratoid_Selectedvalue_set = ((0==AV6LayoutContratoId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV6LayoutContratoId), 4, 0)));
         ucCombo_layoutcontratoid.SendProperty(context, "", false, Combo_layoutcontratoid_Internalname, "SelectedValue_set", Combo_layoutcontratoid_Selectedvalue_set);
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E126B2 ();
         if (returnInSub) return;
      }

      protected void E126B2( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S152 ();
         if (returnInSub) return;
         if ( AV29CheckRequiredFieldsResult )
         {
            AV23Contrato.gxTpr_Contratonome = AV13ContratoNome;
            AV23Contrato.gxTpr_Contratocomvigencia = AV14ContratoComVigencia;
            AV23Contrato.gxTpr_Contratodatainicial = AV15ContratoDataInicial;
            AV23Contrato.gxTpr_Contratodatafinal = AV16ContratoDataFinal;
            AV23Contrato.gxTpr_Contratotaxa = AV18ContratoTaxa;
            AV23Contrato.gxTpr_Contratosla = AV20ContratoSLA;
            AV23Contrato.gxTpr_Contratojurosmora = AV19ContratoJurosMora;
            AV23Contrato.gxTpr_Contratoiofminimo = AV17ContratoIOFMinimo;
            if ( AV24ContratoAssinado )
            {
               AV25ContratoSituacao = "Assinado";
            }
            else
            {
               AV25ContratoSituacao = "EmElaboracao";
            }
            AV23Contrato.gxTpr_Contratosituacao = AV25ContratoSituacao;
            if ( ! AV5TipoContrato )
            {
               AV23Contrato.gxTpr_Contratoblob = AV9Blob;
            }
            AV23Contrato.Save();
            if ( AV23Contrato.Success() )
            {
               if ( AV5TipoContrato )
               {
                  AV26LayoutContrato.Load(AV6LayoutContratoId);
                  AV27HTML = AV26LayoutContrato.gxTpr_Layoutcontratocorpo;
                  new prtrocataghtml(context ).execute(  0,  AV23Contrato.gxTpr_Contratoid, ref  AV27HTML) ;
                  AV23Contrato.gxTpr_Contratocorpo = AV27HTML;
                  AV23Contrato.Save();
                  if ( AV23Contrato.Success() )
                  {
                     context.CommitDataStores("wcontrato",pr_default);
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
                  context.CommitDataStores("wcontrato",pr_default);
                  context.setWebReturnParms(new Object[] {});
                  context.setWebReturnParmsMetadata(new Object[] {});
                  context.wjLocDisableFrm = 1;
                  context.nUserReturn = 1;
                  returnInSub = true;
                  if (true) return;
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV23Contrato", AV23Contrato);
      }

      protected void S142( )
      {
         /* 'CONTRATOCOMVIGENCIA' Routine */
         returnInSub = false;
         if ( AV14ContratoComVigencia )
         {
            edtavContratodatainicial_Visible = 1;
            AssignProp("", false, edtavContratodatainicial_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContratodatainicial_Visible), 5, 0), true);
            edtavContratodatafinal_Visible = 1;
            AssignProp("", false, edtavContratodatafinal_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContratodatafinal_Visible), 5, 0), true);
         }
         else
         {
            edtavContratodatainicial_Visible = 0;
            AssignProp("", false, edtavContratodatainicial_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContratodatainicial_Visible), 5, 0), true);
            edtavContratodatafinal_Visible = 0;
            AssignProp("", false, edtavContratodatafinal_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContratodatafinal_Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'TIPOCONTRATO' Routine */
         returnInSub = false;
         if ( AV5TipoContrato )
         {
            divTablelayoutfield_Visible = 1;
            AssignProp("", false, divTablelayoutfield_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablelayoutfield_Visible), 5, 0), true);
            divTableblob_Visible = 0;
            AssignProp("", false, divTableblob_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableblob_Visible), 5, 0), true);
         }
         else
         {
            divTablelayoutfield_Visible = 0;
            AssignProp("", false, divTablelayoutfield_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablelayoutfield_Visible), 5, 0), true);
            divTableblob_Visible = 1;
            AssignProp("", false, divTableblob_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableblob_Visible), 5, 0), true);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E136B2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV21ClienteId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV21ClienteId", StringUtil.LTrimStr( (decimal)(AV21ClienteId), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV21ClienteId), "ZZZZZZZZ9"), context));
         AV22ContratoId = Convert.ToInt32(getParm(obj,1));
         AssignAttri("", false, "AV22ContratoId", StringUtil.LTrimStr( (decimal)(AV22ContratoId), 6, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vCONTRATOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV22ContratoId), "ZZZZZ9"), context));
         AV28TrnMode = (string)getParm(obj,2);
         AssignAttri("", false, "AV28TrnMode", AV28TrnMode);
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV28TrnMode, "")), context));
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
         PA6B2( ) ;
         WS6B2( ) ;
         WE6B2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101926965", true, true);
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
         context.AddJavascriptSource("wcontrato.js", "?20256101926965", false, true);
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         chkavContratocomvigencia.Name = "vCONTRATOCOMVIGENCIA";
         chkavContratocomvigencia.WebTags = "";
         chkavContratocomvigencia.Caption = "Contrato com vigência";
         AssignProp("", false, chkavContratocomvigencia_Internalname, "TitleCaption", chkavContratocomvigencia.Caption, true);
         chkavContratocomvigencia.CheckedValue = "false";
         AV14ContratoComVigencia = StringUtil.StrToBool( StringUtil.BoolToStr( AV14ContratoComVigencia));
         AssignAttri("", false, "AV14ContratoComVigencia", AV14ContratoComVigencia);
         chkavContratoassinado.Name = "vCONTRATOASSINADO";
         chkavContratoassinado.WebTags = "";
         chkavContratoassinado.Caption = "Contrato assinado";
         AssignProp("", false, chkavContratoassinado_Internalname, "TitleCaption", chkavContratoassinado.Caption, true);
         chkavContratoassinado.CheckedValue = "false";
         AV24ContratoAssinado = StringUtil.StrToBool( StringUtil.BoolToStr( AV24ContratoAssinado));
         AssignAttri("", false, "AV24ContratoAssinado", AV24ContratoAssinado);
         chkavTipocontrato.Name = "vTIPOCONTRATO";
         chkavTipocontrato.WebTags = "";
         chkavTipocontrato.Caption = "";
         AssignProp("", false, chkavTipocontrato_Internalname, "TitleCaption", chkavTipocontrato.Caption, true);
         chkavTipocontrato.CheckedValue = "false";
         AV5TipoContrato = StringUtil.StrToBool( StringUtil.BoolToStr( AV5TipoContrato));
         AssignAttri("", false, "AV5TipoContrato", AV5TipoContrato);
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavContratonome_Internalname = "vCONTRATONOME";
         chkavContratocomvigencia_Internalname = "vCONTRATOCOMVIGENCIA";
         edtavContratodatainicial_Internalname = "vCONTRATODATAINICIAL";
         divContratodatainicial_cell_Internalname = "CONTRATODATAINICIAL_CELL";
         edtavContratodatafinal_Internalname = "vCONTRATODATAFINAL";
         divContratodatafinal_cell_Internalname = "CONTRATODATAFINAL_CELL";
         edtavContratoiofminimo_Internalname = "vCONTRATOIOFMINIMO";
         edtavContratotaxa_Internalname = "vCONTRATOTAXA";
         edtavContratojurosmora_Internalname = "vCONTRATOJUROSMORA";
         edtavContratosla_Internalname = "vCONTRATOSLA";
         Contratocorpo_Internalname = "CONTRATOCORPO";
         divContratocorpofck_Internalname = "CONTRATOCORPOFCK";
         divTablecontratocorpo_Internalname = "TABLECONTRATOCORPO";
         lblTxtcorpo_Internalname = "TXTCORPO";
         divTablecontratofields_Internalname = "TABLECONTRATOFIELDS";
         lblTextblockcombo_layoutcontratoid_Internalname = "TEXTBLOCKCOMBO_LAYOUTCONTRATOID";
         Combo_layoutcontratoid_Internalname = "COMBO_LAYOUTCONTRATOID";
         divTablesplittedlayoutcontratoid_Internalname = "TABLESPLITTEDLAYOUTCONTRATOID";
         divTablelayoutfield_Internalname = "TABLELAYOUTFIELD";
         File_Internalname = "FILE";
         chkavContratoassinado_Internalname = "vCONTRATOASSINADO";
         divTableblob_Internalname = "TABLEBLOB";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         edtavLayoutcontratoid_Internalname = "vLAYOUTCONTRATOID";
         chkavTipocontrato_Internalname = "vTIPOCONTRATO";
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
         chkavTipocontrato.Caption = "";
         chkavContratoassinado.Caption = "Contrato assinado";
         chkavContratocomvigencia.Caption = "Contrato com vigência";
         chkavTipocontrato.Visible = 1;
         edtavLayoutcontratoid_Jsonclick = "";
         edtavLayoutcontratoid_Visible = 1;
         chkavContratoassinado.Enabled = 1;
         File_Tooltiptext = "";
         divTableblob_Visible = 1;
         divTablelayoutfield_Visible = 1;
         divTablecontent_Visible = 1;
         lblTxtcorpo_Caption = "";
         lblTxtcorpo_Visible = 1;
         Contratocorpo_Enabled = Convert.ToBoolean( 1);
         divTablecontratocorpo_Visible = 1;
         edtavContratosla_Jsonclick = "";
         edtavContratosla_Enabled = 1;
         edtavContratojurosmora_Jsonclick = "";
         edtavContratojurosmora_Enabled = 1;
         edtavContratotaxa_Jsonclick = "";
         edtavContratotaxa_Enabled = 1;
         edtavContratoiofminimo_Jsonclick = "";
         edtavContratoiofminimo_Enabled = 1;
         edtavContratodatafinal_Jsonclick = "";
         edtavContratodatafinal_Enabled = 1;
         edtavContratodatafinal_Visible = 1;
         divContratodatafinal_cell_Class = "col-xs-12 col-sm-6";
         edtavContratodatainicial_Jsonclick = "";
         edtavContratodatainicial_Enabled = 1;
         edtavContratodatainicial_Visible = 1;
         divContratodatainicial_cell_Class = "col-xs-12 col-sm-6";
         chkavContratocomvigencia.Enabled = 1;
         edtavContratonome_Jsonclick = "";
         edtavContratonome_Enabled = 1;
         File_Customfiletypes = "*.pdf";
         File_Acceptedfiletypes = "custom";
         File_Maxnumberoffiles = 1;
         Combo_layoutcontratoid_Emptyitem = Convert.ToBoolean( 0);
         Combo_layoutcontratoid_Cls = "ExtendedCombo AttributeFL";
         Contratocorpo_Captionposition = "Left";
         Contratocorpo_Captionstyle = "";
         Contratocorpo_Captionclass = " AttributeLabel";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Contrato";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV14ContratoComVigencia","fld":"vCONTRATOCOMVIGENCIA","type":"boolean"},{"av":"AV24ContratoAssinado","fld":"vCONTRATOASSINADO","type":"boolean"},{"av":"AV5TipoContrato","fld":"vTIPOCONTRATO","type":"boolean"},{"av":"AV21ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV22ContratoId","fld":"vCONTRATOID","pic":"ZZZZZ9","hsh":true,"type":"int"},{"av":"AV28TrnMode","fld":"vTRNMODE","hsh":true,"type":"char"}]}""");
         setEventMetadata("ENTER","""{"handler":"E126B2","iparms":[{"av":"AV29CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"},{"av":"AV13ContratoNome","fld":"vCONTRATONOME","type":"svchar"},{"av":"AV23Contrato","fld":"vCONTRATO","type":""},{"av":"AV14ContratoComVigencia","fld":"vCONTRATOCOMVIGENCIA","type":"boolean"},{"av":"AV15ContratoDataInicial","fld":"vCONTRATODATAINICIAL","type":"date"},{"av":"AV16ContratoDataFinal","fld":"vCONTRATODATAFINAL","type":"date"},{"av":"AV18ContratoTaxa","fld":"vCONTRATOTAXA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV20ContratoSLA","fld":"vCONTRATOSLA","pic":"ZZZ9","type":"int"},{"av":"AV19ContratoJurosMora","fld":"vCONTRATOJUROSMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV17ContratoIOFMinimo","fld":"vCONTRATOIOFMINIMO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV24ContratoAssinado","fld":"vCONTRATOASSINADO","type":"boolean"},{"av":"AV5TipoContrato","fld":"vTIPOCONTRATO","type":"boolean"},{"av":"AV9Blob","fld":"vBLOB","type":"bitstr"},{"av":"AV6LayoutContratoId","fld":"vLAYOUTCONTRATOID","pic":"ZZZ9","type":"int"},{"av":"Combo_layoutcontratoid_Ddointernalname","ctrl":"COMBO_LAYOUTCONTRATOID","prop":"DDOInternalName"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV23Contrato","fld":"vCONTRATO","type":""},{"av":"AV29CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"}]}""");
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
         wcpOAV28TrnMode = "";
         Combo_layoutcontratoid_Selectedvalue_get = "";
         Combo_layoutcontratoid_Ddointernalname = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV30ContratoCorpo = "";
         AV7LayoutContratoId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV10UploadedFiles = new GXBaseCollection<SdtFileUploadData>( context, "FileUploadData", "Factory21");
         AV11FailedFiles = new GXBaseCollection<SdtFileUploadData>( context, "FileUploadData", "Factory21");
         AV23Contrato = new SdtContrato(context);
         AV9Blob = "";
         Combo_layoutcontratoid_Selectedvalue_set = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV13ContratoNome = "";
         AV15ContratoDataInicial = DateTime.MinValue;
         AV16ContratoDataFinal = DateTime.MinValue;
         ucContratocorpo = new GXUserControl();
         lblTxtcorpo_Jsonclick = "";
         lblTextblockcombo_layoutcontratoid_Jsonclick = "";
         ucCombo_layoutcontratoid = new GXUserControl();
         Combo_layoutcontratoid_Caption = "";
         ucFile = new GXUserControl();
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         H006B2_A168ClienteId = new int[1] ;
         H006B2_A170ClienteRazaoSocial = new string[] {""} ;
         H006B2_n170ClienteRazaoSocial = new bool[] {false} ;
         A170ClienteRazaoSocial = "";
         H006B3_A906LayoutContratoTipo = new string[] {""} ;
         H006B3_n906LayoutContratoTipo = new bool[] {false} ;
         H006B3_A156LayoutContratoStatus = new bool[] {false} ;
         H006B3_n156LayoutContratoStatus = new bool[] {false} ;
         H006B3_A154LayoutContratoId = new short[1] ;
         H006B3_A155LayoutContratoDescricao = new string[] {""} ;
         H006B3_n155LayoutContratoDescricao = new bool[] {false} ;
         A906LayoutContratoTipo = "";
         A155LayoutContratoDescricao = "";
         AV8Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV25ContratoSituacao = "";
         AV26LayoutContrato = new SdtLayoutContrato(context);
         AV27HTML = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wcontrato__default(),
            new Object[][] {
                new Object[] {
               H006B2_A168ClienteId, H006B2_A170ClienteRazaoSocial, H006B2_n170ClienteRazaoSocial
               }
               , new Object[] {
               H006B3_A906LayoutContratoTipo, H006B3_n906LayoutContratoTipo, H006B3_A156LayoutContratoStatus, H006B3_n156LayoutContratoStatus, H006B3_A154LayoutContratoId, H006B3_A155LayoutContratoDescricao, H006B3_n155LayoutContratoDescricao
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV20ContratoSLA ;
      private short AV6LayoutContratoId ;
      private short nDonePA ;
      private short A154LayoutContratoId ;
      private short nGXWrapped ;
      private int AV21ClienteId ;
      private int AV22ContratoId ;
      private int wcpOAV21ClienteId ;
      private int wcpOAV22ContratoId ;
      private int File_Maxnumberoffiles ;
      private int edtavContratonome_Enabled ;
      private int edtavContratodatainicial_Visible ;
      private int edtavContratodatainicial_Enabled ;
      private int edtavContratodatafinal_Visible ;
      private int edtavContratodatafinal_Enabled ;
      private int edtavContratoiofminimo_Enabled ;
      private int edtavContratotaxa_Enabled ;
      private int edtavContratojurosmora_Enabled ;
      private int edtavContratosla_Enabled ;
      private int divTablecontratocorpo_Visible ;
      private int lblTxtcorpo_Visible ;
      private int divTablecontent_Visible ;
      private int divTablelayoutfield_Visible ;
      private int divTableblob_Visible ;
      private int edtavLayoutcontratoid_Visible ;
      private int A168ClienteId ;
      private int idxLst ;
      private decimal AV17ContratoIOFMinimo ;
      private decimal AV18ContratoTaxa ;
      private decimal AV19ContratoJurosMora ;
      private string AV28TrnMode ;
      private string wcpOAV28TrnMode ;
      private string Combo_layoutcontratoid_Selectedvalue_get ;
      private string Combo_layoutcontratoid_Ddointernalname ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Contratocorpo_Captionclass ;
      private string Contratocorpo_Captionstyle ;
      private string Contratocorpo_Captionposition ;
      private string Combo_layoutcontratoid_Cls ;
      private string Combo_layoutcontratoid_Selectedvalue_set ;
      private string File_Acceptedfiletypes ;
      private string File_Customfiletypes ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontratofields_Internalname ;
      private string edtavContratonome_Internalname ;
      private string TempTags ;
      private string edtavContratonome_Jsonclick ;
      private string chkavContratocomvigencia_Internalname ;
      private string divContratodatainicial_cell_Internalname ;
      private string divContratodatainicial_cell_Class ;
      private string edtavContratodatainicial_Internalname ;
      private string edtavContratodatainicial_Jsonclick ;
      private string divContratodatafinal_cell_Internalname ;
      private string divContratodatafinal_cell_Class ;
      private string edtavContratodatafinal_Internalname ;
      private string edtavContratodatafinal_Jsonclick ;
      private string edtavContratoiofminimo_Internalname ;
      private string edtavContratoiofminimo_Jsonclick ;
      private string edtavContratotaxa_Internalname ;
      private string edtavContratotaxa_Jsonclick ;
      private string edtavContratojurosmora_Internalname ;
      private string edtavContratojurosmora_Jsonclick ;
      private string edtavContratosla_Internalname ;
      private string edtavContratosla_Jsonclick ;
      private string divTablecontratocorpo_Internalname ;
      private string divContratocorpofck_Internalname ;
      private string Contratocorpo_Internalname ;
      private string lblTxtcorpo_Internalname ;
      private string lblTxtcorpo_Caption ;
      private string lblTxtcorpo_Jsonclick ;
      private string divTablecontent_Internalname ;
      private string divTablelayoutfield_Internalname ;
      private string divTablesplittedlayoutcontratoid_Internalname ;
      private string lblTextblockcombo_layoutcontratoid_Internalname ;
      private string lblTextblockcombo_layoutcontratoid_Jsonclick ;
      private string Combo_layoutcontratoid_Caption ;
      private string Combo_layoutcontratoid_Internalname ;
      private string divTableblob_Internalname ;
      private string File_Tooltiptext ;
      private string File_Internalname ;
      private string chkavContratoassinado_Internalname ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavLayoutcontratoid_Internalname ;
      private string edtavLayoutcontratoid_Jsonclick ;
      private string chkavTipocontrato_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private DateTime AV15ContratoDataInicial ;
      private DateTime AV16ContratoDataFinal ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV29CheckRequiredFieldsResult ;
      private bool Contratocorpo_Enabled ;
      private bool Combo_layoutcontratoid_Emptyitem ;
      private bool wbLoad ;
      private bool AV14ContratoComVigencia ;
      private bool AV24ContratoAssinado ;
      private bool AV5TipoContrato ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n170ClienteRazaoSocial ;
      private bool n906LayoutContratoTipo ;
      private bool A156LayoutContratoStatus ;
      private bool n156LayoutContratoStatus ;
      private bool n155LayoutContratoDescricao ;
      private string AV30ContratoCorpo ;
      private string AV27HTML ;
      private string AV13ContratoNome ;
      private string A170ClienteRazaoSocial ;
      private string A906LayoutContratoTipo ;
      private string A155LayoutContratoDescricao ;
      private string AV25ContratoSituacao ;
      private string AV9Blob ;
      private GXUserControl ucContratocorpo ;
      private GXUserControl ucCombo_layoutcontratoid ;
      private GXUserControl ucFile ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavContratocomvigencia ;
      private GXCheckbox chkavContratoassinado ;
      private GXCheckbox chkavTipocontrato ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV7LayoutContratoId_Data ;
      private GXBaseCollection<SdtFileUploadData> AV10UploadedFiles ;
      private GXBaseCollection<SdtFileUploadData> AV11FailedFiles ;
      private SdtContrato AV23Contrato ;
      private IDataStoreProvider pr_default ;
      private int[] H006B2_A168ClienteId ;
      private string[] H006B2_A170ClienteRazaoSocial ;
      private bool[] H006B2_n170ClienteRazaoSocial ;
      private string[] H006B3_A906LayoutContratoTipo ;
      private bool[] H006B3_n906LayoutContratoTipo ;
      private bool[] H006B3_A156LayoutContratoStatus ;
      private bool[] H006B3_n156LayoutContratoStatus ;
      private short[] H006B3_A154LayoutContratoId ;
      private string[] H006B3_A155LayoutContratoDescricao ;
      private bool[] H006B3_n155LayoutContratoDescricao ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV8Combo_DataItem ;
      private SdtLayoutContrato AV26LayoutContrato ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wcontrato__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH006B2;
          prmH006B2 = new Object[] {
          new ParDef("AV21ClienteId",GXType.Int32,9,0)
          };
          Object[] prmH006B3;
          prmH006B3 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H006B2", "SELECT ClienteId, ClienteRazaoSocial FROM Cliente WHERE ClienteId = :AV21ClienteId ORDER BY ClienteId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006B2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H006B3", "SELECT LayoutContratoTipo, LayoutContratoStatus, LayoutContratoId, LayoutContratoDescricao FROM LayoutContrato WHERE (LayoutContratoStatus) AND (LayoutContratoTipo = ( 'C')) ORDER BY LayoutContratoDescricao ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006B3,100, GxCacheFrequency.OFF ,false,false )
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
