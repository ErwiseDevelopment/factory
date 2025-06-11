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
   public class wpiniciarassinatura : GXDataArea
   {
      public wpiniciarassinatura( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpiniciarassinatura( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_ContratoId )
      {
         this.AV5ContratoId = aP0_ContratoId;
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
            gxfirstwebparm = GetFirstPar( "ContratoId");
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
               gxfirstwebparm = GetFirstPar( "ContratoId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "ContratoId");
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
         nRC_GXsfl_32 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_32"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_32_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_32_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_32_idx = GetPar( "sGXsfl_32_idx");
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
         AV5ContratoId = (int)(Math.Round(NumberUtil.Val( GetPar( "ContratoId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV14Array_SdParticipantes, AV31IsSemResponsavel, AV5ContratoId) ;
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
         PA6E2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START6E2( ) ;
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
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
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
         GXEncryptionTmp = "wpiniciarassinatura"+UrlEncode(StringUtil.LTrimStr(AV5ContratoId,6,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpiniciarassinatura") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vCONTRATOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5ContratoId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCONTRATOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5ContratoId), "ZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_32", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_32), 8, 0, ",", "")));
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCONTRATO", AV6Contrato);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCONTRATO", AV6Contrato);
         }
         GxWebStd.gx_hidden_field( context, "vCONTRATOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5ContratoId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCONTRATOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5ContratoId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vGLOBALASSINATURAPARTICIPANTETIPO", AV27GlobalAssinaturaParticipanteTipo);
         GxWebStd.gx_hidden_field( context, "vGLOBALEMAIL", AV26GlobalEmail);
         GxWebStd.gx_hidden_field( context, "vGLOBALCPF", AV29GlobalCPF);
         GxWebStd.gx_hidden_field( context, "vGLOBALNOME", AV28GlobalNome);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDPARTICIPANTES", AV15SdParticipantes);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDPARTICIPANTES", AV15SdParticipantes);
         }
         GxWebStd.gx_hidden_field( context, "vGXV2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39GXV2), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "subGrid1_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Recordcount), 5, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CONTRATOCORPO_Enabled", StringUtil.BoolToStr( Contratocorpo_Enabled));
         GxWebStd.gx_hidden_field( context, "CONTRATOCORPO_Captionclass", StringUtil.RTrim( Contratocorpo_Captionclass));
         GxWebStd.gx_hidden_field( context, "CONTRATOCORPO_Captionstyle", StringUtil.RTrim( Contratocorpo_Captionstyle));
         GxWebStd.gx_hidden_field( context, "CONTRATOCORPO_Captionposition", StringUtil.RTrim( Contratocorpo_Captionposition));
         GxWebStd.gx_hidden_field( context, "GRID1_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid1_empowerer_Gridinternalname));
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
            WE6E2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT6E2( ) ;
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
         GXEncryptionTmp = "wpiniciarassinatura"+UrlEncode(StringUtil.LTrimStr(AV5ContratoId,6,0));
         return formatLink("wpiniciarassinatura") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WpIniciarAssinatura" ;
      }

      public override string GetPgmdesc( )
      {
         return "Iniciar assinatura" ;
      }

      protected void WB6E0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavContratonome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContratonome_Internalname, "Nome do contrato", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'" + sGXsfl_32_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContratonome_Internalname, AV8ContratoNome, StringUtil.RTrim( context.localUtil.Format( AV8ContratoNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,19);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContratonome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavContratonome_Enabled, 0, "text", "", 80, "chr", 1, "row", 125, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpIniciarAssinatura.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnaddpart_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(32), 2, 0)+","+"null"+");", "Adicionar participante", bttBtnaddpart_Jsonclick, 5, "Adicionar participante", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOADDPART\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpIniciarAssinatura.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 HasGridEmpowerer", "start", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl32( ) ;
         }
         if ( wbEnd == 32 )
         {
            wbEnd = 0;
            nRC_GXsfl_32 = (int)(nGXsfl_32_idx-1);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(32), 2, 0)+","+"null"+");", "Confirmar", bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpIniciarAssinatura.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(32), 2, 0)+","+"null"+");", "Fechar", bttBtncancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpIniciarAssinatura.htm");
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
            /* User Defined Control */
            ucGrid1_empowerer.Render(context, "wwp.gridempowerer", Grid1_empowerer_Internalname, "GRID1_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 32 )
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

      protected void START6E2( )
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
         Form.Meta.addItem("description", "Iniciar assinatura", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP6E0( ) ;
      }

      protected void WS6E2( )
      {
         START6E2( ) ;
         EVT6E2( ) ;
      }

      protected void EVT6E2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "'DOADDPART'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoAddPart' */
                              E116E2 ();
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
                                    E126E2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS.WPINICIARASSINATURA_NOVOPARTICIPANTE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E136E2 ();
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
                              nGXsfl_32_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_32_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_32_idx), 4, 0), 4, "0");
                              SubsflControlProps_322( ) ;
                              AV13Retirar = cgiGet( edtavRetirar_Internalname);
                              AssignAttri("", false, edtavRetirar_Internalname, AV13Retirar);
                              AV7Nome = cgiGet( edtavNome_Internalname);
                              AssignAttri("", false, edtavNome_Internalname, AV7Nome);
                              AV10ParticipanteDocumento = cgiGet( edtavParticipantedocumento_Internalname);
                              AssignAttri("", false, edtavParticipantedocumento_Internalname, AV10ParticipanteDocumento);
                              GxWebStd.gx_hidden_field( context, "gxhash_vPARTICIPANTEDOCUMENTO"+"_"+sGXsfl_32_idx, GetSecureSignedToken( sGXsfl_32_idx, StringUtil.RTrim( context.localUtil.Format( AV10ParticipanteDocumento, "")), context));
                              AV11ParticipanteEmail = cgiGet( edtavParticipanteemail_Internalname);
                              AssignAttri("", false, edtavParticipanteemail_Internalname, AV11ParticipanteEmail);
                              cmbavAssinaturaparticipantetipo.Name = cmbavAssinaturaparticipantetipo_Internalname;
                              cmbavAssinaturaparticipantetipo.CurrentValue = cgiGet( cmbavAssinaturaparticipantetipo_Internalname);
                              AV12AssinaturaParticipanteTipo = cgiGet( cmbavAssinaturaparticipantetipo_Internalname);
                              AssignAttri("", false, cmbavAssinaturaparticipantetipo_Internalname, AV12AssinaturaParticipanteTipo);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E146E2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID1.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid1.Load */
                                    E156E2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VRETIRAR.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E166E2 ();
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

      protected void WE6E2( )
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

      protected void PA6E2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpiniciarassinatura")), "wpiniciarassinatura") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpiniciarassinatura")))) ;
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
                  gxfirstwebparm = GetFirstPar( "ContratoId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV5ContratoId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV5ContratoId", StringUtil.LTrimStr( (decimal)(AV5ContratoId), 6, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vCONTRATOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5ContratoId), "ZZZZZ9"), context));
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
         SubsflControlProps_322( ) ;
         while ( nGXsfl_32_idx <= nRC_GXsfl_32 )
         {
            sendrow_322( ) ;
            nGXsfl_32_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_32_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_32_idx+1);
            sGXsfl_32_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_32_idx), 4, 0), 4, "0");
            SubsflControlProps_322( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        GXBaseCollection<SdtSdParticipantes> AV14Array_SdParticipantes ,
                                        bool AV31IsSemResponsavel ,
                                        int AV5ContratoId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF6E2( ) ;
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
         RF6E2( ) ;
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
      }

      protected void RF6E2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 32;
         nGXsfl_32_idx = 1;
         sGXsfl_32_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_32_idx), 4, 0), 4, "0");
         SubsflControlProps_322( ) ;
         bGXsfl_32_Refreshing = true;
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
            SubsflControlProps_322( ) ;
            /* Execute user event: Grid1.Load */
            E156E2 ();
            if ( ( subGrid1_Islastpage == 0 ) && ( GRID1_nCurrentRecord > 0 ) && ( GRID1_nGridOutOfScope == 0 ) && ( nGXsfl_32_idx == 1 ) )
            {
               GRID1_nCurrentRecord = 0;
               GRID1_nGridOutOfScope = 1;
               subgrid1_firstpage( ) ;
               /* Execute user event: Grid1.Load */
               E156E2 ();
            }
            wbEnd = 32;
            WB6E0( ) ;
         }
         bGXsfl_32_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes6E2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vPARTICIPANTEDOCUMENTO"+"_"+sGXsfl_32_idx, GetSecureSignedToken( sGXsfl_32_idx, StringUtil.RTrim( context.localUtil.Format( AV10ParticipanteDocumento, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISSEMRESPONSAVEL", AV31IsSemResponsavel);
         GxWebStd.gx_hidden_field( context, "gxhash_vISSEMRESPONSAVEL", GetSecureSignedToken( "", AV31IsSemResponsavel, context));
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
            gxgrGrid1_refresh( subGrid1_Rows, AV14Array_SdParticipantes, AV31IsSemResponsavel, AV5ContratoId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV14Array_SdParticipantes, AV31IsSemResponsavel, AV5ContratoId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV14Array_SdParticipantes, AV31IsSemResponsavel, AV5ContratoId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_lastpage( )
      {
         subGrid1_Islastpage = 1;
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV14Array_SdParticipantes, AV31IsSemResponsavel, AV5ContratoId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV14Array_SdParticipantes, AV31IsSemResponsavel, AV5ContratoId) ;
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
         fix_multi_value_controls( ) ;
      }

      protected void STRUP6E0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E146E2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vSDPARTICIPANTES"), AV15SdParticipantes);
            ajax_req_read_hidden_sdt(cgiGet( "vARRAY_SDPARTICIPANTES"), AV14Array_SdParticipantes);
            /* Read saved values. */
            nRC_GXsfl_32 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_32"), ",", "."), 18, MidpointRounding.ToEven));
            AV9ContratoCorpo = cgiGet( "vCONTRATOCORPO");
            AssignAttri("", false, "AV9ContratoCorpo", AV9ContratoCorpo);
            AV39GXV2 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vGXV2"), ",", "."), 18, MidpointRounding.ToEven));
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            subGrid1_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "subGrid1_Recordcount"), ",", "."), 18, MidpointRounding.ToEven));
            subGrid1_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
            Contratocorpo_Enabled = StringUtil.StrToBool( cgiGet( "CONTRATOCORPO_Enabled"));
            Contratocorpo_Captionclass = cgiGet( "CONTRATOCORPO_Captionclass");
            Contratocorpo_Captionstyle = cgiGet( "CONTRATOCORPO_Captionstyle");
            Contratocorpo_Captionposition = cgiGet( "CONTRATOCORPO_Captionposition");
            Grid1_empowerer_Gridinternalname = cgiGet( "GRID1_EMPOWERER_Gridinternalname");
            /* Read variables values. */
            AV8ContratoNome = cgiGet( edtavContratonome_Internalname);
            AssignAttri("", false, "AV8ContratoNome", AV8ContratoNome);
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
         E146E2 ();
         if (returnInSub) return;
      }

      protected void E146E2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtWWPContext1 = AV33WWPContext;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  GXt_SdtWWPContext1) ;
         AV33WWPContext = GXt_SdtWWPContext1;
         AV6Contrato.Load(AV5ContratoId);
         AV8ContratoNome = AV6Contrato.gxTpr_Contratonome;
         AssignAttri("", false, "AV8ContratoNome", AV8ContratoNome);
         AV9ContratoCorpo = AV6Contrato.gxTpr_Contratocorpo;
         AssignAttri("", false, "AV9ContratoCorpo", AV9ContratoCorpo);
         Grid1_empowerer_Gridinternalname = subGrid1_Internalname;
         ucGrid1_empowerer.SendProperty(context, "", false, Grid1_empowerer_Internalname, "GridInternalName", Grid1_empowerer_Gridinternalname);
         subGrid1_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
         AV14Array_SdParticipantes = new GXBaseCollection<SdtSdParticipantes>( context, "SdParticipantes", "Factory21");
         AV15SdParticipantes = new SdtSdParticipantes(context);
         /* Using cursor H006E2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A773EmpresaUtilizaRepresentanteAssinatura = H006E2_A773EmpresaUtilizaRepresentanteAssinatura[0];
            n773EmpresaUtilizaRepresentanteAssinatura = H006E2_n773EmpresaUtilizaRepresentanteAssinatura[0];
            A771EmpresaRepresentanteNome = H006E2_A771EmpresaRepresentanteNome[0];
            n771EmpresaRepresentanteNome = H006E2_n771EmpresaRepresentanteNome[0];
            A770EmpresaRepresentanteCPF = H006E2_A770EmpresaRepresentanteCPF[0];
            n770EmpresaRepresentanteCPF = H006E2_n770EmpresaRepresentanteCPF[0];
            A772EmpresaRepresentanteEmail = H006E2_A772EmpresaRepresentanteEmail[0];
            n772EmpresaRepresentanteEmail = H006E2_n772EmpresaRepresentanteEmail[0];
            AV15SdParticipantes.gxTpr_Participantenome = A771EmpresaRepresentanteNome;
            AV15SdParticipantes.gxTpr_Participantedocumento = A770EmpresaRepresentanteCPF;
            AV15SdParticipantes.gxTpr_Participanteemail = A772EmpresaRepresentanteEmail;
            AV15SdParticipantes.gxTpr_Assinaturaparticipantetipo = "Contratado";
            AV14Array_SdParticipantes.Add(AV15SdParticipantes, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV15SdParticipantes = new SdtSdParticipantes(context);
         AV31IsSemResponsavel = false;
         AssignAttri("", false, "AV31IsSemResponsavel", AV31IsSemResponsavel);
         GxWebStd.gx_hidden_field( context, "gxhash_vISSEMRESPONSAVEL", GetSecureSignedToken( "", AV31IsSemResponsavel, context));
         /* Using cursor H006E3 */
         pr_default.execute(1, new Object[] {AV6Contrato.gxTpr_Contratoclienteid});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A168ClienteId = H006E3_A168ClienteId[0];
            A172ClienteTipoPessoa = H006E3_A172ClienteTipoPessoa[0];
            n172ClienteTipoPessoa = H006E3_n172ClienteTipoPessoa[0];
            A436ResponsavelNome = H006E3_A436ResponsavelNome[0];
            n436ResponsavelNome = H006E3_n436ResponsavelNome[0];
            A447ResponsavelCPF = H006E3_A447ResponsavelCPF[0];
            n447ResponsavelCPF = H006E3_n447ResponsavelCPF[0];
            A456ResponsavelEmail = H006E3_A456ResponsavelEmail[0];
            n456ResponsavelEmail = H006E3_n456ResponsavelEmail[0];
            A170ClienteRazaoSocial = H006E3_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = H006E3_n170ClienteRazaoSocial[0];
            A169ClienteDocumento = H006E3_A169ClienteDocumento[0];
            n169ClienteDocumento = H006E3_n169ClienteDocumento[0];
            A201ContatoEmail = H006E3_A201ContatoEmail[0];
            n201ContatoEmail = H006E3_n201ContatoEmail[0];
            if ( StringUtil.StrCmp(A172ClienteTipoPessoa, "JURIDICA") == 0 )
            {
               AV15SdParticipantes.gxTpr_Participantenome = A436ResponsavelNome;
               AV15SdParticipantes.gxTpr_Participantedocumento = A447ResponsavelCPF;
               AV15SdParticipantes.gxTpr_Participanteemail = A456ResponsavelEmail;
               AV15SdParticipantes.gxTpr_Assinaturaparticipantetipo = "Contratante";
               AV15SdParticipantes.gxTpr_Clienteid = AV6Contrato.gxTpr_Contratoclienteid;
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
               AV15SdParticipantes.gxTpr_Clienteid = AV6Contrato.gxTpr_Contratoclienteid;
            }
            if ( ! AV31IsSemResponsavel )
            {
               AV14Array_SdParticipantes.Add(AV15SdParticipantes, 0);
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         if ( AV31IsSemResponsavel )
         {
            GXt_char2 = "Cadastre um responsável para continuar.";
            new message(context ).gxep_erro( ref  GXt_char2) ;
         }
         /* Using cursor H006E4 */
         pr_default.execute(2, new Object[] {AV33WWPContext.gxTpr_Userid});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A133SecUserId = H006E4_A133SecUserId[0];
            n133SecUserId = H006E4_n133SecUserId[0];
            A479ConfiguracoesTestemunhasNome = H006E4_A479ConfiguracoesTestemunhasNome[0];
            n479ConfiguracoesTestemunhasNome = H006E4_n479ConfiguracoesTestemunhasNome[0];
            A480ConfiguracoesTestemunhasDocumento = H006E4_A480ConfiguracoesTestemunhasDocumento[0];
            n480ConfiguracoesTestemunhasDocumento = H006E4_n480ConfiguracoesTestemunhasDocumento[0];
            A481ConfiguracoesTestemunhasEmail = H006E4_A481ConfiguracoesTestemunhasEmail[0];
            n481ConfiguracoesTestemunhasEmail = H006E4_n481ConfiguracoesTestemunhasEmail[0];
            AV15SdParticipantes = new SdtSdParticipantes(context);
            AV15SdParticipantes.gxTpr_Participantenome = A479ConfiguracoesTestemunhasNome;
            AV15SdParticipantes.gxTpr_Participantedocumento = A480ConfiguracoesTestemunhasDocumento;
            AV15SdParticipantes.gxTpr_Participanteemail = A481ConfiguracoesTestemunhasEmail;
            AV15SdParticipantes.gxTpr_Assinaturaparticipantetipo = "Testemunha";
            AV15SdParticipantes.gxTpr_Clienteid = AV6Contrato.gxTpr_Contratoclienteid;
            AV14Array_SdParticipantes.Add(AV15SdParticipantes, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      private void E156E2( )
      {
         /* Grid1_Load Routine */
         returnInSub = false;
         AV38GXV1 = 1;
         while ( AV38GXV1 <= AV14Array_SdParticipantes.Count )
         {
            AV15SdParticipantes = ((SdtSdParticipantes)AV14Array_SdParticipantes.Item(AV38GXV1));
            AV7Nome = AV15SdParticipantes.gxTpr_Participantenome;
            AssignAttri("", false, edtavNome_Internalname, AV7Nome);
            AV10ParticipanteDocumento = AV15SdParticipantes.gxTpr_Participantedocumento;
            AssignAttri("", false, edtavParticipantedocumento_Internalname, AV10ParticipanteDocumento);
            GxWebStd.gx_hidden_field( context, "gxhash_vPARTICIPANTEDOCUMENTO"+"_"+sGXsfl_32_idx, GetSecureSignedToken( sGXsfl_32_idx, StringUtil.RTrim( context.localUtil.Format( AV10ParticipanteDocumento, "")), context));
            AV11ParticipanteEmail = AV15SdParticipantes.gxTpr_Participanteemail;
            AssignAttri("", false, edtavParticipanteemail_Internalname, AV11ParticipanteEmail);
            AV12AssinaturaParticipanteTipo = AV15SdParticipantes.gxTpr_Assinaturaparticipantetipo;
            AssignAttri("", false, cmbavAssinaturaparticipantetipo_Internalname, AV12AssinaturaParticipanteTipo);
            cmbavAssinaturaparticipantetipo.Enabled = 1;
            AV13Retirar = "<i class=\"fas fa-times\"></i>";
            AssignAttri("", false, edtavRetirar_Internalname, AV13Retirar);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 32;
            }
            if ( ( subGrid1_Islastpage == 1 ) || ( subGrid1_Rows == 0 ) || ( ( GRID1_nCurrentRecord >= GRID1_nFirstRecordOnPage ) && ( GRID1_nCurrentRecord < GRID1_nFirstRecordOnPage + subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_322( ) ;
            }
            GRID1_nEOF = (short)(((GRID1_nCurrentRecord<GRID1_nFirstRecordOnPage+subGrid1_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
            subGrid1_Recordcount = (int)(GRID1_nCurrentRecord);
            if ( isFullAjaxMode( ) && ! bGXsfl_32_Refreshing )
            {
               DoAjaxLoad(32, Grid1Row);
            }
            AV38GXV1 = (int)(AV38GXV1+1);
         }
         /*  Sending Event outputs  */
         cmbavAssinaturaparticipantetipo.CurrentValue = StringUtil.RTrim( AV12AssinaturaParticipanteTipo);
      }

      protected void E116E2( )
      {
         /* 'DoAddPart' Routine */
         returnInSub = false;
         context.PopUp(formatLink("popupnovoparticipanteassinatura") , new Object[] {});
         context.DoAjaxRefresh();
      }

      protected void E166E2( )
      {
         /* Retirar_Click Routine */
         returnInSub = false;
         AV16index = 0;
         AV40GXV3 = 1;
         while ( AV40GXV3 <= AV14Array_SdParticipantes.Count )
         {
            AV15SdParticipantes = ((SdtSdParticipantes)AV14Array_SdParticipantes.Item(AV40GXV3));
            AV16index = (short)(AV16index+1);
            if ( ( StringUtil.StrCmp(AV15SdParticipantes.gxTpr_Participantedocumento, AV10ParticipanteDocumento) == 0 ) && ( StringUtil.StrCmp(AV15SdParticipantes.gxTpr_Assinaturaparticipantetipo, AV12AssinaturaParticipanteTipo) == 0 ) )
            {
               AV14Array_SdParticipantes.RemoveItem(AV16index);
               context.DoAjaxRefresh();
               if (true) break;
            }
            AV40GXV3 = (int)(AV40GXV3+1);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14Array_SdParticipantes", AV14Array_SdParticipantes);
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E126E2 ();
         if (returnInSub) return;
      }

      protected void E126E2( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( ! AV31IsSemResponsavel )
         {
            AV19GUID = Guid.NewGuid( );
            AV20File.Source = "./PublicTempStorage/"+AV19GUID.ToString()+".html";
            AV20File.Create();
            AV24HTML = "<html><head> <meta charset=\"UTF-8\"> <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\"></head><body>" + AV9ContratoCorpo + "</body></html>";
            AV20File.WriteAllText(AV24HTML, "UTF8");
            AV19GUID = Guid.NewGuid( );
            AV21PdfPath = "./PublicTempStorage/" + AV19GUID.ToString() + ".pdf";
            AV22PdfFile.Source = AV21PdfPath;
            new prcriarpdffromhtml(context ).execute(  AV20File.GetAbsoluteName(),  AV22PdfFile.GetAbsoluteName(), out  AV34ErroMsg) ;
            if ( StringUtil.StrCmp(AV34ErroMsg, "PDF gerado com sucesso!") == 0 )
            {
               AV18Blob = AV22PdfFile.GetAbsoluteName();
               AV18Blob = AV22PdfFile.GetAbsoluteName();
               AV6Contrato.gxTpr_Contratosituacao = "ColetandoAssinatura";
               AV6Contrato.Save();
               if ( AV6Contrato.Success() )
               {
                  new prsendsignaturewithcontract(context ).execute(  AV18Blob,  AV5ContratoId,  AV14Array_SdParticipantes, out  AV17SdErro) ;
                  if ( AV17SdErro.gxTpr_Status != 200 )
                  {
                     GXt_char2 = AV17SdErro.gxTpr_Msg;
                     new message(context ).gxep_erro( ref  GXt_char2) ;
                     AV17SdErro.gxTpr_Msg = GXt_char2;
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
                  GXt_char2 = ((GeneXus.Utils.SdtMessages_Message)AV6Contrato.GetMessages().Item(1)).gxTpr_Description;
                  new message(context ).gxep_erro( ref  GXt_char2) ;
                  ((GeneXus.Utils.SdtMessages_Message)AV6Contrato.GetMessages().Item(1)).gxTpr_Description = GXt_char2;
               }
            }
            else
            {
               GXt_char3 = "Cadastre um responsável para continuar.";
               new message(context ).gxep_erro( ref  GXt_char3) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6Contrato", AV6Contrato);
      }

      protected void E136E2( )
      {
         /* General\GlobalEvents_Wpiniciarassinatura_novoparticipante Routine */
         returnInSub = false;
         AV30IsExists = false;
         AV41GXV4 = 1;
         while ( AV41GXV4 <= AV14Array_SdParticipantes.Count )
         {
            AV15SdParticipantes = ((SdtSdParticipantes)AV14Array_SdParticipantes.Item(AV41GXV4));
            if ( ( StringUtil.StrCmp(AV15SdParticipantes.gxTpr_Participantedocumento, AV29GlobalCPF) == 0 ) || ( StringUtil.StrCmp(AV15SdParticipantes.gxTpr_Participanteemail, AV26GlobalEmail) == 0 ) )
            {
               AV30IsExists = true;
               if (true) break;
            }
            AV41GXV4 = (int)(AV41GXV4+1);
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
            GXt_char3 = "Já existe esse participante no contrato";
            new message(context ).gxep_erro( ref  GXt_char3) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14Array_SdParticipantes", AV14Array_SdParticipantes);
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV5ContratoId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV5ContratoId", StringUtil.LTrimStr( (decimal)(AV5ContratoId), 6, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vCONTRATOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5ContratoId), "ZZZZZ9"), context));
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
         PA6E2( ) ;
         WS6E2( ) ;
         WE6E2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019261193", true, true);
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
         context.AddJavascriptSource("wpiniciarassinatura.js", "?202561019261193", false, true);
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_322( )
      {
         edtavRetirar_Internalname = "vRETIRAR_"+sGXsfl_32_idx;
         edtavNome_Internalname = "vNOME_"+sGXsfl_32_idx;
         edtavParticipantedocumento_Internalname = "vPARTICIPANTEDOCUMENTO_"+sGXsfl_32_idx;
         edtavParticipanteemail_Internalname = "vPARTICIPANTEEMAIL_"+sGXsfl_32_idx;
         cmbavAssinaturaparticipantetipo_Internalname = "vASSINATURAPARTICIPANTETIPO_"+sGXsfl_32_idx;
      }

      protected void SubsflControlProps_fel_322( )
      {
         edtavRetirar_Internalname = "vRETIRAR_"+sGXsfl_32_fel_idx;
         edtavNome_Internalname = "vNOME_"+sGXsfl_32_fel_idx;
         edtavParticipantedocumento_Internalname = "vPARTICIPANTEDOCUMENTO_"+sGXsfl_32_fel_idx;
         edtavParticipanteemail_Internalname = "vPARTICIPANTEEMAIL_"+sGXsfl_32_fel_idx;
         cmbavAssinaturaparticipantetipo_Internalname = "vASSINATURAPARTICIPANTETIPO_"+sGXsfl_32_fel_idx;
      }

      protected void sendrow_322( )
      {
         sGXsfl_32_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_32_idx), 4, 0), 4, "0");
         SubsflControlProps_322( ) ;
         WB6E0( ) ;
         if ( ( subGrid1_Rows * 1 == 0 ) || ( nGXsfl_32_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_32_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_32_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'" + sGXsfl_32_idx + "',32)\"";
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavRetirar_Internalname,StringUtil.RTrim( AV13Retirar),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"","'"+""+"'"+",false,"+"'"+"EVRETIRAR.CLICK."+sGXsfl_32_idx+"'",(string)"",(string)"",(string)"Retirar",(string)"",(string)edtavRetirar_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavRetirar_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)32,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'" + sGXsfl_32_idx + "',32)\"";
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavNome_Internalname,(string)AV7Nome,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavNome_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)32,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'" + sGXsfl_32_idx + "',32)\"";
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavParticipantedocumento_Internalname,(string)AV10ParticipanteDocumento,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavParticipantedocumento_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavParticipantedocumento_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)32,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_32_idx + "',32)\"";
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavParticipanteemail_Internalname,(string)AV11ParticipanteEmail,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavParticipanteemail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavParticipanteemail_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)32,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'" + sGXsfl_32_idx + "',32)\"";
            GXCCtl = "vASSINATURAPARTICIPANTETIPO_" + sGXsfl_32_idx;
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
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavAssinaturaparticipantetipo,(string)cmbavAssinaturaparticipantetipo_Internalname,StringUtil.RTrim( AV12AssinaturaParticipanteTipo),(short)1,(string)cmbavAssinaturaparticipantetipo_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,cmbavAssinaturaparticipantetipo.Enabled,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"",(string)"",(bool)true,(short)0});
            cmbavAssinaturaparticipantetipo.CurrentValue = StringUtil.RTrim( AV12AssinaturaParticipanteTipo);
            AssignProp("", false, cmbavAssinaturaparticipantetipo_Internalname, "Values", (string)(cmbavAssinaturaparticipantetipo.ToJavascriptSource()), !bGXsfl_32_Refreshing);
            send_integrity_lvl_hashes6E2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_32_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_32_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_32_idx+1);
            sGXsfl_32_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_32_idx), 4, 0), 4, "0");
            SubsflControlProps_322( ) ;
         }
         /* End function sendrow_322 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vASSINATURAPARTICIPANTETIPO_" + sGXsfl_32_idx;
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

      protected void StartGridControl32( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"32\">") ;
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
         edtavContratonome_Internalname = "vCONTRATONOME";
         Contratocorpo_Internalname = "CONTRATOCORPO";
         divTablecontrato_Internalname = "TABLECONTRATO";
         bttBtnaddpart_Internalname = "BTNADDPART";
         edtavRetirar_Internalname = "vRETIRAR";
         edtavNome_Internalname = "vNOME";
         edtavParticipantedocumento_Internalname = "vPARTICIPANTEDOCUMENTO";
         edtavParticipanteemail_Internalname = "vPARTICIPANTEEMAIL";
         cmbavAssinaturaparticipantetipo_Internalname = "vASSINATURAPARTICIPANTETIPO";
         divTableparticipantes_Internalname = "TABLEPARTICIPANTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         divTablemain_Internalname = "TABLEMAIN";
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
         Contratocorpo_Enabled = Convert.ToBoolean( 1);
         edtavContratonome_Jsonclick = "";
         edtavContratonome_Enabled = 1;
         Contratocorpo_Captionposition = "Left";
         Contratocorpo_Captionstyle = "";
         Contratocorpo_Captionclass = " AttributeLabel";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Iniciar assinatura";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID1_nFirstRecordOnPage","type":"int"},{"av":"GRID1_nEOF","type":"int"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV14Array_SdParticipantes","fld":"vARRAY_SDPARTICIPANTES","type":""},{"av":"AV31IsSemResponsavel","fld":"vISSEMRESPONSAVEL","hsh":true,"type":"boolean"},{"av":"AV5ContratoId","fld":"vCONTRATOID","pic":"ZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("GRID1.LOAD","""{"handler":"E156E2","iparms":[{"av":"AV14Array_SdParticipantes","fld":"vARRAY_SDPARTICIPANTES","type":""}]""");
         setEventMetadata("GRID1.LOAD",""","oparms":[{"av":"AV7Nome","fld":"vNOME","type":"svchar"},{"av":"AV10ParticipanteDocumento","fld":"vPARTICIPANTEDOCUMENTO","hsh":true,"type":"svchar"},{"av":"AV11ParticipanteEmail","fld":"vPARTICIPANTEEMAIL","type":"svchar"},{"av":"cmbavAssinaturaparticipantetipo"},{"av":"AV12AssinaturaParticipanteTipo","fld":"vASSINATURAPARTICIPANTETIPO","type":"svchar"},{"av":"AV13Retirar","fld":"vRETIRAR","type":"char"}]}""");
         setEventMetadata("'DOADDPART'","""{"handler":"E116E2","iparms":[{"av":"GRID1_nFirstRecordOnPage","type":"int"},{"av":"GRID1_nEOF","type":"int"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV14Array_SdParticipantes","fld":"vARRAY_SDPARTICIPANTES","type":""},{"av":"AV31IsSemResponsavel","fld":"vISSEMRESPONSAVEL","hsh":true,"type":"boolean"},{"av":"AV5ContratoId","fld":"vCONTRATOID","pic":"ZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("VRETIRAR.CLICK","""{"handler":"E166E2","iparms":[{"av":"GRID1_nFirstRecordOnPage","type":"int"},{"av":"GRID1_nEOF","type":"int"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV14Array_SdParticipantes","fld":"vARRAY_SDPARTICIPANTES","type":""},{"av":"AV31IsSemResponsavel","fld":"vISSEMRESPONSAVEL","hsh":true,"type":"boolean"},{"av":"AV5ContratoId","fld":"vCONTRATOID","pic":"ZZZZZ9","hsh":true,"type":"int"},{"av":"AV10ParticipanteDocumento","fld":"vPARTICIPANTEDOCUMENTO","hsh":true,"type":"svchar"},{"av":"cmbavAssinaturaparticipantetipo"},{"av":"AV12AssinaturaParticipanteTipo","fld":"vASSINATURAPARTICIPANTETIPO","type":"svchar"}]""");
         setEventMetadata("VRETIRAR.CLICK",""","oparms":[{"av":"AV14Array_SdParticipantes","fld":"vARRAY_SDPARTICIPANTES","type":""}]}""");
         setEventMetadata("ENTER","""{"handler":"E126E2","iparms":[{"av":"AV31IsSemResponsavel","fld":"vISSEMRESPONSAVEL","hsh":true,"type":"boolean"},{"av":"AV9ContratoCorpo","fld":"vCONTRATOCORPO","type":"vchar"},{"av":"AV6Contrato","fld":"vCONTRATO","type":""},{"av":"AV5ContratoId","fld":"vCONTRATOID","pic":"ZZZZZ9","hsh":true,"type":"int"},{"av":"AV14Array_SdParticipantes","fld":"vARRAY_SDPARTICIPANTES","type":""}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV6Contrato","fld":"vCONTRATO","type":""}]}""");
         setEventMetadata("GLOBALEVENTS.WPINICIARASSINATURA_NOVOPARTICIPANTE","""{"handler":"E136E2","iparms":[{"av":"AV27GlobalAssinaturaParticipanteTipo","fld":"vGLOBALASSINATURAPARTICIPANTETIPO","type":"svchar"},{"av":"AV26GlobalEmail","fld":"vGLOBALEMAIL","type":"svchar"},{"av":"AV29GlobalCPF","fld":"vGLOBALCPF","type":"svchar"},{"av":"AV28GlobalNome","fld":"vGLOBALNOME","type":"svchar"},{"av":"AV14Array_SdParticipantes","fld":"vARRAY_SDPARTICIPANTES","type":""},{"av":"AV6Contrato","fld":"vCONTRATO","type":""}]""");
         setEventMetadata("GLOBALEVENTS.WPINICIARASSINATURA_NOVOPARTICIPANTE",""","oparms":[{"av":"AV14Array_SdParticipantes","fld":"vARRAY_SDPARTICIPANTES","type":""}]}""");
         setEventMetadata("GRID1_FIRSTPAGE","""{"handler":"subgrid1_firstpage","iparms":[{"av":"GRID1_nFirstRecordOnPage","type":"int"},{"av":"GRID1_nEOF","type":"int"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV14Array_SdParticipantes","fld":"vARRAY_SDPARTICIPANTES","type":""},{"av":"AV31IsSemResponsavel","fld":"vISSEMRESPONSAVEL","hsh":true,"type":"boolean"},{"av":"AV5ContratoId","fld":"vCONTRATOID","pic":"ZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("GRID1_PREVPAGE","""{"handler":"subgrid1_previouspage","iparms":[{"av":"GRID1_nFirstRecordOnPage","type":"int"},{"av":"GRID1_nEOF","type":"int"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV14Array_SdParticipantes","fld":"vARRAY_SDPARTICIPANTES","type":""},{"av":"AV31IsSemResponsavel","fld":"vISSEMRESPONSAVEL","hsh":true,"type":"boolean"},{"av":"AV5ContratoId","fld":"vCONTRATOID","pic":"ZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("GRID1_NEXTPAGE","""{"handler":"subgrid1_nextpage","iparms":[{"av":"GRID1_nFirstRecordOnPage","type":"int"},{"av":"GRID1_nEOF","type":"int"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV14Array_SdParticipantes","fld":"vARRAY_SDPARTICIPANTES","type":""},{"av":"AV31IsSemResponsavel","fld":"vISSEMRESPONSAVEL","hsh":true,"type":"boolean"},{"av":"AV5ContratoId","fld":"vCONTRATOID","pic":"ZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("GRID1_LASTPAGE","""{"handler":"subgrid1_lastpage","iparms":[{"av":"GRID1_nFirstRecordOnPage","type":"int"},{"av":"GRID1_nEOF","type":"int"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV14Array_SdParticipantes","fld":"vARRAY_SDPARTICIPANTES","type":""},{"av":"AV31IsSemResponsavel","fld":"vISSEMRESPONSAVEL","hsh":true,"type":"boolean"},{"av":"AV5ContratoId","fld":"vCONTRATOID","pic":"ZZZZZ9","hsh":true,"type":"int"},{"av":"subGrid1_Recordcount","type":"int"}]}""");
         setEventMetadata("VALIDV_PARTICIPANTEEMAIL","""{"handler":"Validv_Participanteemail","iparms":[]}""");
         setEventMetadata("VALIDV_ASSINATURAPARTICIPANTETIPO","""{"handler":"Validv_Assinaturaparticipantetipo","iparms":[]}""");
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
         AV14Array_SdParticipantes = new GXBaseCollection<SdtSdParticipantes>( context, "SdParticipantes", "Factory21");
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV9ContratoCorpo = "";
         AV6Contrato = new SdtContrato(context);
         AV27GlobalAssinaturaParticipanteTipo = "";
         AV26GlobalEmail = "";
         AV29GlobalCPF = "";
         AV28GlobalNome = "";
         AV15SdParticipantes = new SdtSdParticipantes(context);
         Grid1_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
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
         GXDecQS = "";
         AV33WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtWWPContext1 = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         H006E2_A249EmpresaId = new int[1] ;
         H006E2_A773EmpresaUtilizaRepresentanteAssinatura = new bool[] {false} ;
         H006E2_n773EmpresaUtilizaRepresentanteAssinatura = new bool[] {false} ;
         H006E2_A771EmpresaRepresentanteNome = new string[] {""} ;
         H006E2_n771EmpresaRepresentanteNome = new bool[] {false} ;
         H006E2_A770EmpresaRepresentanteCPF = new string[] {""} ;
         H006E2_n770EmpresaRepresentanteCPF = new bool[] {false} ;
         H006E2_A772EmpresaRepresentanteEmail = new string[] {""} ;
         H006E2_n772EmpresaRepresentanteEmail = new bool[] {false} ;
         A771EmpresaRepresentanteNome = "";
         A770EmpresaRepresentanteCPF = "";
         A772EmpresaRepresentanteEmail = "";
         H006E3_A168ClienteId = new int[1] ;
         H006E3_A172ClienteTipoPessoa = new string[] {""} ;
         H006E3_n172ClienteTipoPessoa = new bool[] {false} ;
         H006E3_A436ResponsavelNome = new string[] {""} ;
         H006E3_n436ResponsavelNome = new bool[] {false} ;
         H006E3_A447ResponsavelCPF = new string[] {""} ;
         H006E3_n447ResponsavelCPF = new bool[] {false} ;
         H006E3_A456ResponsavelEmail = new string[] {""} ;
         H006E3_n456ResponsavelEmail = new bool[] {false} ;
         H006E3_A170ClienteRazaoSocial = new string[] {""} ;
         H006E3_n170ClienteRazaoSocial = new bool[] {false} ;
         H006E3_A169ClienteDocumento = new string[] {""} ;
         H006E3_n169ClienteDocumento = new bool[] {false} ;
         H006E3_A201ContatoEmail = new string[] {""} ;
         H006E3_n201ContatoEmail = new bool[] {false} ;
         A172ClienteTipoPessoa = "";
         A436ResponsavelNome = "";
         A447ResponsavelCPF = "";
         A456ResponsavelEmail = "";
         A170ClienteRazaoSocial = "";
         A169ClienteDocumento = "";
         A201ContatoEmail = "";
         H006E4_A478ConfiguracoesTestemunhasId = new int[1] ;
         H006E4_A133SecUserId = new short[1] ;
         H006E4_n133SecUserId = new bool[] {false} ;
         H006E4_A479ConfiguracoesTestemunhasNome = new string[] {""} ;
         H006E4_n479ConfiguracoesTestemunhasNome = new bool[] {false} ;
         H006E4_A480ConfiguracoesTestemunhasDocumento = new string[] {""} ;
         H006E4_n480ConfiguracoesTestemunhasDocumento = new bool[] {false} ;
         H006E4_A481ConfiguracoesTestemunhasEmail = new string[] {""} ;
         H006E4_n481ConfiguracoesTestemunhasEmail = new bool[] {false} ;
         A479ConfiguracoesTestemunhasNome = "";
         A480ConfiguracoesTestemunhasDocumento = "";
         A481ConfiguracoesTestemunhasEmail = "";
         Grid1Row = new GXWebRow();
         AV19GUID = Guid.Empty;
         AV20File = new GxFile(context.GetPhysicalPath());
         AV24HTML = "";
         AV21PdfPath = "";
         AV22PdfFile = new GxFile(context.GetPhysicalPath());
         AV34ErroMsg = "";
         AV18Blob = "";
         AV17SdErro = new SdtSdErro(context);
         GXt_char2 = "";
         GXt_char3 = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpiniciarassinatura__default(),
            new Object[][] {
                new Object[] {
               H006E2_A249EmpresaId, H006E2_A773EmpresaUtilizaRepresentanteAssinatura, H006E2_n773EmpresaUtilizaRepresentanteAssinatura, H006E2_A771EmpresaRepresentanteNome, H006E2_n771EmpresaRepresentanteNome, H006E2_A770EmpresaRepresentanteCPF, H006E2_n770EmpresaRepresentanteCPF, H006E2_A772EmpresaRepresentanteEmail, H006E2_n772EmpresaRepresentanteEmail
               }
               , new Object[] {
               H006E3_A168ClienteId, H006E3_A172ClienteTipoPessoa, H006E3_n172ClienteTipoPessoa, H006E3_A436ResponsavelNome, H006E3_n436ResponsavelNome, H006E3_A447ResponsavelCPF, H006E3_n447ResponsavelCPF, H006E3_A456ResponsavelEmail, H006E3_n456ResponsavelEmail, H006E3_A170ClienteRazaoSocial,
               H006E3_n170ClienteRazaoSocial, H006E3_A169ClienteDocumento, H006E3_n169ClienteDocumento, H006E3_A201ContatoEmail, H006E3_n201ContatoEmail
               }
               , new Object[] {
               H006E4_A478ConfiguracoesTestemunhasId, H006E4_A133SecUserId, H006E4_n133SecUserId, H006E4_A479ConfiguracoesTestemunhasNome, H006E4_n479ConfiguracoesTestemunhasNome, H006E4_A480ConfiguracoesTestemunhasDocumento, H006E4_n480ConfiguracoesTestemunhasDocumento, H006E4_A481ConfiguracoesTestemunhasEmail, H006E4_n481ConfiguracoesTestemunhasEmail
               }
            }
         );
         /* GeneXus formulas. */
         edtavRetirar_Enabled = 0;
         edtavNome_Enabled = 0;
         edtavParticipantedocumento_Enabled = 0;
         edtavParticipanteemail_Enabled = 0;
         cmbavAssinaturaparticipantetipo.Enabled = 0;
      }

      private short GRID1_nEOF ;
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
      private short subGrid1_Backcolorstyle ;
      private short A133SecUserId ;
      private short AV16index ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private int AV5ContratoId ;
      private int wcpOAV5ContratoId ;
      private int nRC_GXsfl_32 ;
      private int subGrid1_Recordcount ;
      private int subGrid1_Rows ;
      private int nGXsfl_32_idx=1 ;
      private int AV39GXV2 ;
      private int edtavContratonome_Enabled ;
      private int subGrid1_Islastpage ;
      private int edtavRetirar_Enabled ;
      private int edtavNome_Enabled ;
      private int edtavParticipantedocumento_Enabled ;
      private int edtavParticipanteemail_Enabled ;
      private int GRID1_nGridOutOfScope ;
      private int A168ClienteId ;
      private int AV38GXV1 ;
      private int AV40GXV3 ;
      private int AV41GXV4 ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long GRID1_nFirstRecordOnPage ;
      private long GRID1_nCurrentRecord ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_32_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Contratocorpo_Captionclass ;
      private string Contratocorpo_Captionstyle ;
      private string Contratocorpo_Captionposition ;
      private string Grid1_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divTablecontrato_Internalname ;
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
      private string GXDecQS ;
      private string GXt_char2 ;
      private string GXt_char3 ;
      private string sGXsfl_32_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string ROClassString ;
      private string edtavRetirar_Jsonclick ;
      private string edtavNome_Jsonclick ;
      private string edtavParticipantedocumento_Jsonclick ;
      private string edtavParticipanteemail_Jsonclick ;
      private string GXCCtl ;
      private string cmbavAssinaturaparticipantetipo_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV31IsSemResponsavel ;
      private bool Contratocorpo_Enabled ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_32_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool A773EmpresaUtilizaRepresentanteAssinatura ;
      private bool n773EmpresaUtilizaRepresentanteAssinatura ;
      private bool n771EmpresaRepresentanteNome ;
      private bool n770EmpresaRepresentanteCPF ;
      private bool n772EmpresaRepresentanteEmail ;
      private bool n172ClienteTipoPessoa ;
      private bool n436ResponsavelNome ;
      private bool n447ResponsavelCPF ;
      private bool n456ResponsavelEmail ;
      private bool n170ClienteRazaoSocial ;
      private bool n169ClienteDocumento ;
      private bool n201ContatoEmail ;
      private bool n133SecUserId ;
      private bool n479ConfiguracoesTestemunhasNome ;
      private bool n480ConfiguracoesTestemunhasDocumento ;
      private bool n481ConfiguracoesTestemunhasEmail ;
      private bool AV30IsExists ;
      private string AV9ContratoCorpo ;
      private string AV24HTML ;
      private string AV27GlobalAssinaturaParticipanteTipo ;
      private string AV26GlobalEmail ;
      private string AV29GlobalCPF ;
      private string AV28GlobalNome ;
      private string AV8ContratoNome ;
      private string AV7Nome ;
      private string AV10ParticipanteDocumento ;
      private string AV11ParticipanteEmail ;
      private string AV12AssinaturaParticipanteTipo ;
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
      private string AV34ErroMsg ;
      private Guid AV19GUID ;
      private string AV18Blob ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXUserControl ucContratocorpo ;
      private GXUserControl ucGrid1_empowerer ;
      private GxFile AV20File ;
      private GxFile AV22PdfFile ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavAssinaturaparticipantetipo ;
      private GXBaseCollection<SdtSdParticipantes> AV14Array_SdParticipantes ;
      private SdtContrato AV6Contrato ;
      private SdtSdParticipantes AV15SdParticipantes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV33WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext GXt_SdtWWPContext1 ;
      private IDataStoreProvider pr_default ;
      private int[] H006E2_A249EmpresaId ;
      private bool[] H006E2_A773EmpresaUtilizaRepresentanteAssinatura ;
      private bool[] H006E2_n773EmpresaUtilizaRepresentanteAssinatura ;
      private string[] H006E2_A771EmpresaRepresentanteNome ;
      private bool[] H006E2_n771EmpresaRepresentanteNome ;
      private string[] H006E2_A770EmpresaRepresentanteCPF ;
      private bool[] H006E2_n770EmpresaRepresentanteCPF ;
      private string[] H006E2_A772EmpresaRepresentanteEmail ;
      private bool[] H006E2_n772EmpresaRepresentanteEmail ;
      private int[] H006E3_A168ClienteId ;
      private string[] H006E3_A172ClienteTipoPessoa ;
      private bool[] H006E3_n172ClienteTipoPessoa ;
      private string[] H006E3_A436ResponsavelNome ;
      private bool[] H006E3_n436ResponsavelNome ;
      private string[] H006E3_A447ResponsavelCPF ;
      private bool[] H006E3_n447ResponsavelCPF ;
      private string[] H006E3_A456ResponsavelEmail ;
      private bool[] H006E3_n456ResponsavelEmail ;
      private string[] H006E3_A170ClienteRazaoSocial ;
      private bool[] H006E3_n170ClienteRazaoSocial ;
      private string[] H006E3_A169ClienteDocumento ;
      private bool[] H006E3_n169ClienteDocumento ;
      private string[] H006E3_A201ContatoEmail ;
      private bool[] H006E3_n201ContatoEmail ;
      private int[] H006E4_A478ConfiguracoesTestemunhasId ;
      private short[] H006E4_A133SecUserId ;
      private bool[] H006E4_n133SecUserId ;
      private string[] H006E4_A479ConfiguracoesTestemunhasNome ;
      private bool[] H006E4_n479ConfiguracoesTestemunhasNome ;
      private string[] H006E4_A480ConfiguracoesTestemunhasDocumento ;
      private bool[] H006E4_n480ConfiguracoesTestemunhasDocumento ;
      private string[] H006E4_A481ConfiguracoesTestemunhasEmail ;
      private bool[] H006E4_n481ConfiguracoesTestemunhasEmail ;
      private SdtSdErro AV17SdErro ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpiniciarassinatura__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH006E2;
          prmH006E2 = new Object[] {
          };
          Object[] prmH006E3;
          prmH006E3 = new Object[] {
          new ParDef("AV6Contr_1Contratoclienteid",GXType.Int32,9,0)
          };
          Object[] prmH006E4;
          prmH006E4 = new Object[] {
          new ParDef("AV33WWPContext__Userid",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H006E2", "SELECT EmpresaId, EmpresaUtilizaRepresentanteAssinatura, EmpresaRepresentanteNome, EmpresaRepresentanteCPF, EmpresaRepresentanteEmail FROM Empresa WHERE EmpresaUtilizaRepresentanteAssinatura ORDER BY EmpresaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006E2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H006E3", "SELECT ClienteId, ClienteTipoPessoa, ResponsavelNome, ResponsavelCPF, ResponsavelEmail, ClienteRazaoSocial, ClienteDocumento, ContatoEmail FROM Cliente WHERE ClienteId = :AV6Contr_1Contratoclienteid ORDER BY ClienteId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006E3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H006E4", "SELECT ConfiguracoesTestemunhasId, SecUserId, ConfiguracoesTestemunhasNome, ConfiguracoesTestemunhasDocumento, ConfiguracoesTestemunhasEmail FROM ConfiguracoesTestemunhas WHERE SecUserId = :AV33WWPContext__Userid ORDER BY SecUserId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006E4,100, GxCacheFrequency.OFF ,false,false )
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
                return;
             case 1 :
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
             case 2 :
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
       }
    }

 }

}
