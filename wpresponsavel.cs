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
   public class wpresponsavel : GXDataArea
   {
      public wpresponsavel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpresponsavel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_TrnMode ,
                           int aP1_ClienteId )
      {
         this.AV40TrnMode = aP0_TrnMode;
         this.AV34ClienteId = aP1_ClienteId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavResponsavelestadocivil = new GXCombobox();
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
         PA6A2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START6A2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         GXEncryptionTmp = "wpresponsavel"+UrlEncode(StringUtil.RTrim(AV40TrnMode)) + "," + UrlEncode(StringUtil.LTrimStr(AV34ClienteId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpresponsavel") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vTRNMODE", StringUtil.RTrim( AV40TrnMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV40TrnMode, "")), context));
         GxWebStd.gx_hidden_field( context, "vCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV34ClienteId), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vRESPONSAVELNACIONALIDADE_DATA", AV23ResponsavelNacionalidade_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vRESPONSAVELNACIONALIDADE_DATA", AV23ResponsavelNacionalidade_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vRESPONSAVELPROFISSAO_DATA", AV25ResponsavelProfissao_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vRESPONSAVELPROFISSAO_DATA", AV25ResponsavelProfissao_Data);
         }
         GxWebStd.gx_hidden_field( context, "PROFISSAOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A440ProfissaoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PROFISSAONOME", A441ProfissaoNome);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vENDERECOCOMPLETO", AV29EnderecoCompleto);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vENDERECOCOMPLETO", AV29EnderecoCompleto);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCLIENTE", AV35Cliente);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCLIENTE", AV35Cliente);
         }
         GxWebStd.gx_hidden_field( context, "vTRNMODE", StringUtil.RTrim( AV40TrnMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV40TrnMode, "")), context));
         GxWebStd.gx_hidden_field( context, "vCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV34ClienteId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "COMBO_RESPONSAVELNACIONALIDADE_Cls", StringUtil.RTrim( Combo_responsavelnacionalidade_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_RESPONSAVELNACIONALIDADE_Selectedvalue_set", StringUtil.RTrim( Combo_responsavelnacionalidade_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_RESPONSAVELNACIONALIDADE_Enabled", StringUtil.BoolToStr( Combo_responsavelnacionalidade_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_RESPONSAVELNACIONALIDADE_Emptyitem", StringUtil.BoolToStr( Combo_responsavelnacionalidade_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_RESPONSAVELPROFISSAO_Cls", StringUtil.RTrim( Combo_responsavelprofissao_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_RESPONSAVELPROFISSAO_Selectedvalue_set", StringUtil.RTrim( Combo_responsavelprofissao_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_RESPONSAVELPROFISSAO_Enabled", StringUtil.BoolToStr( Combo_responsavelprofissao_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_RESPONSAVELPROFISSAO_Emptyitem", StringUtil.BoolToStr( Combo_responsavelprofissao_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_RESPONSAVELPROFISSAO_Includeaddnewoption", StringUtil.BoolToStr( Combo_responsavelprofissao_Includeaddnewoption));
         GxWebStd.gx_hidden_field( context, "COMBO_RESPONSAVELPROFISSAO_Selectedvalue_get", StringUtil.RTrim( Combo_responsavelprofissao_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_RESPONSAVELNACIONALIDADE_Selectedvalue_get", StringUtil.RTrim( Combo_responsavelnacionalidade_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_RESPONSAVELPROFISSAO_Selectedvalue_get", StringUtil.RTrim( Combo_responsavelprofissao_Selectedvalue_get));
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
            WE6A2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT6A2( ) ;
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
         GXEncryptionTmp = "wpresponsavel"+UrlEncode(StringUtil.RTrim(AV40TrnMode)) + "," + UrlEncode(StringUtil.LTrimStr(AV34ClienteId,9,0));
         return formatLink("wpresponsavel") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WpResponsavel" ;
      }

      public override string GetPgmdesc( )
      {
         return "Responsável" ;
      }

      protected void WB6A0( )
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
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, "Responsável", 1, 0, "px", 0, "px", "Group", "", "HLP_WpResponsavel.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableresponsavel_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResponsavelcpf_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelcpf_Internalname, "CPF", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelcpf_Internalname, AV5ResponsavelCPF, StringUtil.RTrim( context.localUtil.Format( AV5ResponsavelCPF, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelcpf_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavResponsavelcpf_Enabled, 1, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpResponsavel.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResponsavelnome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelnome_Internalname, "Nome", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelnome_Internalname, AV6ResponsavelNome, StringUtil.RTrim( context.localUtil.Format( AV6ResponsavelNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelnome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavResponsavelnome_Enabled, 1, "text", "", 80, "chr", 1, "row", 90, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpResponsavel.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedresponsavelnacionalidade_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_responsavelnacionalidade_Internalname, "Nacionalidade", "", "", lblTextblockcombo_responsavelnacionalidade_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpResponsavel.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_responsavelnacionalidade.SetProperty("Caption", Combo_responsavelnacionalidade_Caption);
            ucCombo_responsavelnacionalidade.SetProperty("Cls", Combo_responsavelnacionalidade_Cls);
            ucCombo_responsavelnacionalidade.SetProperty("EmptyItem", Combo_responsavelnacionalidade_Emptyitem);
            ucCombo_responsavelnacionalidade.SetProperty("DropDownOptionsData", AV23ResponsavelNacionalidade_Data);
            ucCombo_responsavelnacionalidade.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_responsavelnacionalidade_Internalname, "COMBO_RESPONSAVELNACIONALIDADEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavResponsavelestadocivil_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavResponsavelestadocivil_Internalname, "Estado civil", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavResponsavelestadocivil, cmbavResponsavelestadocivil_Internalname, StringUtil.RTrim( AV8ResponsavelEstadoCivil), 1, cmbavResponsavelestadocivil_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavResponsavelestadocivil.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "", true, 0, "HLP_WpResponsavel.htm");
            cmbavResponsavelestadocivil.CurrentValue = StringUtil.RTrim( AV8ResponsavelEstadoCivil);
            AssignProp("", false, cmbavResponsavelestadocivil_Internalname, "Values", (string)(cmbavResponsavelestadocivil.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedresponsavelprofissao_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_responsavelprofissao_Internalname, "Profissão", "", "", lblTextblockcombo_responsavelprofissao_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpResponsavel.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_responsavelprofissao.SetProperty("Caption", Combo_responsavelprofissao_Caption);
            ucCombo_responsavelprofissao.SetProperty("Cls", Combo_responsavelprofissao_Cls);
            ucCombo_responsavelprofissao.SetProperty("EmptyItem", Combo_responsavelprofissao_Emptyitem);
            ucCombo_responsavelprofissao.SetProperty("IncludeAddNewOption", Combo_responsavelprofissao_Includeaddnewoption);
            ucCombo_responsavelprofissao.SetProperty("DropDownOptionsData", AV25ResponsavelProfissao_Data);
            ucCombo_responsavelprofissao.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_responsavelprofissao_Internalname, "COMBO_RESPONSAVELPROFISSAOContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup2_Internalname, "Endereço", 1, 0, "px", 0, "px", "Group", "", "HLP_WpResponsavel.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableresponsavelendereco_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResponsavelcep_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelcep_Internalname, "CEP", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelcep_Internalname, AV13ResponsavelCEP, StringUtil.RTrim( context.localUtil.Format( AV13ResponsavelCEP, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelcep_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavResponsavelcep_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpResponsavel.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResponsavellogradouro_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavellogradouro_Internalname, "Logradouro", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavellogradouro_Internalname, AV14ResponsavelLogradouro, StringUtil.RTrim( context.localUtil.Format( AV14ResponsavelLogradouro, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavellogradouro_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavResponsavellogradouro_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpResponsavel.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResponsavellogradouronumero_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavellogradouronumero_Internalname, "Número", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavellogradouronumero_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15ResponsavelLogradouroNumero), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV15ResponsavelLogradouroNumero), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavellogradouronumero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavResponsavellogradouronumero_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpResponsavel.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResponsavelbairro_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelbairro_Internalname, "Bairro", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelbairro_Internalname, AV16ResponsavelBairro, StringUtil.RTrim( context.localUtil.Format( AV16ResponsavelBairro, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelbairro_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavResponsavelbairro_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpResponsavel.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResponsavelcomplemento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelcomplemento_Internalname, "Complemento", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelcomplemento_Internalname, AV17ResponsavelComplemento, StringUtil.RTrim( context.localUtil.Format( AV17ResponsavelComplemento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,72);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelcomplemento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavResponsavelcomplemento_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpResponsavel.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResponsavelcidade_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelcidade_Internalname, "Cidade", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelcidade_Internalname, AV18ResponsavelCidade, StringUtil.RTrim( context.localUtil.Format( AV18ResponsavelCidade, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelcidade_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavResponsavelcidade_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpResponsavel.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavRepsonsavelmunicipiouf_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRepsonsavelmunicipiouf_Internalname, "UF", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRepsonsavelmunicipiouf_Internalname, AV21RepsonsavelMunicipioUF, StringUtil.RTrim( context.localUtil.Format( AV21RepsonsavelMunicipioUF, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRepsonsavelmunicipiouf_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavRepsonsavelmunicipiouf_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpResponsavel.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup3_Internalname, "Contato", 1, 0, "px", 0, "px", "Group", "", "HLP_WpResponsavel.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableresponsavelcontato_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResponsavelemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelemail_Internalname, "E-mail", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelemail_Internalname, AV10ResponsavelEmail, StringUtil.RTrim( context.localUtil.Format( AV10ResponsavelEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,90);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelemail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavResponsavelemail_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WpResponsavel.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResponsavelddd_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelddd_Internalname, "DDD", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelddd_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11ResponsavelDDD), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV11ResponsavelDDD), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,95);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelddd_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavResponsavelddd_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpResponsavel.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResponsavelnumero_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelnumero_Internalname, "Número", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelnumero_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12ResponsavelNumero), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV12ResponsavelNumero), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelnumero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavResponsavelnumero_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpResponsavel.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", "Confirmar", bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtnenter_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpResponsavel.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", "Fechar", bttBtncancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpResponsavel.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelnacionalidade_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ResponsavelNacionalidade), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV7ResponsavelNacionalidade), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,110);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelnacionalidade_Jsonclick, 0, "Attribute", "", "", "", "", edtavResponsavelnacionalidade_Visible, edtavResponsavelnacionalidade_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpResponsavel.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelprofissao_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9ResponsavelProfissao), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV9ResponsavelProfissao), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,111);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelprofissao_Jsonclick, 0, "Attribute", "", "", "", "", edtavResponsavelprofissao_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpResponsavel.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelmunicipio_Internalname, AV19ResponsavelMunicipio, StringUtil.RTrim( context.localUtil.Format( AV19ResponsavelMunicipio, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,112);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelmunicipio_Jsonclick, 0, "Attribute", "", "", "", "", edtavResponsavelmunicipio_Visible, edtavResponsavelmunicipio_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpResponsavel.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRepsonsavelmunicipionome_Internalname, AV20RepsonsavelMunicipioNome, StringUtil.RTrim( context.localUtil.Format( AV20RepsonsavelMunicipioNome, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,113);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRepsonsavelmunicipionome_Jsonclick, 0, "Attribute", "", "", "", "", edtavRepsonsavelmunicipionome_Visible, 1, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpResponsavel.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START6A2( )
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
         Form.Meta.addItem("description", "Responsável", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP6A0( ) ;
      }

      protected void WS6A2( )
      {
         START6A2( ) ;
         EVT6A2( ) ;
      }

      protected void EVT6A2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_RESPONSAVELPROFISSAO.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_responsavelprofissao.Onoptionclicked */
                              E116A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E126A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VRESPONSAVELCPF.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E136A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VRESPONSAVELCEP.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E146A2 ();
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
                                    E156A2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E166A2 ();
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

      protected void WE6A2( )
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

      protected void PA6A2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpresponsavel")), "wpresponsavel") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpresponsavel")))) ;
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
                     AV40TrnMode = gxfirstwebparm;
                     AssignAttri("", false, "AV40TrnMode", AV40TrnMode);
                     GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV40TrnMode, "")), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV34ClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "ClienteId"), "."), 18, MidpointRounding.ToEven));
                        AssignAttri("", false, "AV34ClienteId", StringUtil.LTrimStr( (decimal)(AV34ClienteId), 9, 0));
                        GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV34ClienteId), "ZZZZZZZZ9"), context));
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
               GX_FocusControl = edtavResponsavelcpf_Internalname;
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
         if ( cmbavResponsavelestadocivil.ItemCount > 0 )
         {
            AV8ResponsavelEstadoCivil = cmbavResponsavelestadocivil.getValidValue(AV8ResponsavelEstadoCivil);
            AssignAttri("", false, "AV8ResponsavelEstadoCivil", AV8ResponsavelEstadoCivil);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavResponsavelestadocivil.CurrentValue = StringUtil.RTrim( AV8ResponsavelEstadoCivil);
            AssignProp("", false, cmbavResponsavelestadocivil_Internalname, "Values", cmbavResponsavelestadocivil.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF6A2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavRepsonsavelmunicipiouf_Enabled = 0;
         AssignProp("", false, edtavRepsonsavelmunicipiouf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRepsonsavelmunicipiouf_Enabled), 5, 0), true);
      }

      protected void RF6A2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E166A2 ();
            WB6A0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes6A2( )
      {
      }

      protected void before_start_formulas( )
      {
         edtavRepsonsavelmunicipiouf_Enabled = 0;
         AssignProp("", false, edtavRepsonsavelmunicipiouf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRepsonsavelmunicipiouf_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP6A0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E126A2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vRESPONSAVELNACIONALIDADE_DATA"), AV23ResponsavelNacionalidade_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vRESPONSAVELPROFISSAO_DATA"), AV25ResponsavelProfissao_Data);
            /* Read saved values. */
            Combo_responsavelnacionalidade_Cls = cgiGet( "COMBO_RESPONSAVELNACIONALIDADE_Cls");
            Combo_responsavelnacionalidade_Selectedvalue_set = cgiGet( "COMBO_RESPONSAVELNACIONALIDADE_Selectedvalue_set");
            Combo_responsavelnacionalidade_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_RESPONSAVELNACIONALIDADE_Enabled"));
            Combo_responsavelnacionalidade_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_RESPONSAVELNACIONALIDADE_Emptyitem"));
            Combo_responsavelprofissao_Cls = cgiGet( "COMBO_RESPONSAVELPROFISSAO_Cls");
            Combo_responsavelprofissao_Selectedvalue_set = cgiGet( "COMBO_RESPONSAVELPROFISSAO_Selectedvalue_set");
            Combo_responsavelprofissao_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_RESPONSAVELPROFISSAO_Enabled"));
            Combo_responsavelprofissao_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_RESPONSAVELPROFISSAO_Emptyitem"));
            Combo_responsavelprofissao_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_RESPONSAVELPROFISSAO_Includeaddnewoption"));
            Combo_responsavelprofissao_Selectedvalue_get = cgiGet( "COMBO_RESPONSAVELPROFISSAO_Selectedvalue_get");
            /* Read variables values. */
            AV5ResponsavelCPF = cgiGet( edtavResponsavelcpf_Internalname);
            AssignAttri("", false, "AV5ResponsavelCPF", AV5ResponsavelCPF);
            AV6ResponsavelNome = cgiGet( edtavResponsavelnome_Internalname);
            AssignAttri("", false, "AV6ResponsavelNome", AV6ResponsavelNome);
            cmbavResponsavelestadocivil.CurrentValue = cgiGet( cmbavResponsavelestadocivil_Internalname);
            AV8ResponsavelEstadoCivil = cgiGet( cmbavResponsavelestadocivil_Internalname);
            AssignAttri("", false, "AV8ResponsavelEstadoCivil", AV8ResponsavelEstadoCivil);
            AV13ResponsavelCEP = cgiGet( edtavResponsavelcep_Internalname);
            AssignAttri("", false, "AV13ResponsavelCEP", AV13ResponsavelCEP);
            AV14ResponsavelLogradouro = cgiGet( edtavResponsavellogradouro_Internalname);
            AssignAttri("", false, "AV14ResponsavelLogradouro", AV14ResponsavelLogradouro);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavResponsavellogradouronumero_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavResponsavellogradouronumero_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vRESPONSAVELLOGRADOURONUMERO");
               GX_FocusControl = edtavResponsavellogradouronumero_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV15ResponsavelLogradouroNumero = 0;
               AssignAttri("", false, "AV15ResponsavelLogradouroNumero", StringUtil.LTrimStr( (decimal)(AV15ResponsavelLogradouroNumero), 9, 0));
            }
            else
            {
               AV15ResponsavelLogradouroNumero = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavResponsavellogradouronumero_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV15ResponsavelLogradouroNumero", StringUtil.LTrimStr( (decimal)(AV15ResponsavelLogradouroNumero), 9, 0));
            }
            AV16ResponsavelBairro = cgiGet( edtavResponsavelbairro_Internalname);
            AssignAttri("", false, "AV16ResponsavelBairro", AV16ResponsavelBairro);
            AV17ResponsavelComplemento = cgiGet( edtavResponsavelcomplemento_Internalname);
            AssignAttri("", false, "AV17ResponsavelComplemento", AV17ResponsavelComplemento);
            AV18ResponsavelCidade = cgiGet( edtavResponsavelcidade_Internalname);
            AssignAttri("", false, "AV18ResponsavelCidade", AV18ResponsavelCidade);
            AV21RepsonsavelMunicipioUF = StringUtil.Upper( cgiGet( edtavRepsonsavelmunicipiouf_Internalname));
            AssignAttri("", false, "AV21RepsonsavelMunicipioUF", AV21RepsonsavelMunicipioUF);
            AV10ResponsavelEmail = cgiGet( edtavResponsavelemail_Internalname);
            AssignAttri("", false, "AV10ResponsavelEmail", AV10ResponsavelEmail);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavResponsavelddd_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavResponsavelddd_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vRESPONSAVELDDD");
               GX_FocusControl = edtavResponsavelddd_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11ResponsavelDDD = 0;
               AssignAttri("", false, "AV11ResponsavelDDD", StringUtil.LTrimStr( (decimal)(AV11ResponsavelDDD), 4, 0));
            }
            else
            {
               AV11ResponsavelDDD = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavResponsavelddd_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11ResponsavelDDD", StringUtil.LTrimStr( (decimal)(AV11ResponsavelDDD), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavResponsavelnumero_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavResponsavelnumero_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vRESPONSAVELNUMERO");
               GX_FocusControl = edtavResponsavelnumero_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12ResponsavelNumero = 0;
               AssignAttri("", false, "AV12ResponsavelNumero", StringUtil.LTrimStr( (decimal)(AV12ResponsavelNumero), 9, 0));
            }
            else
            {
               AV12ResponsavelNumero = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavResponsavelnumero_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12ResponsavelNumero", StringUtil.LTrimStr( (decimal)(AV12ResponsavelNumero), 9, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavResponsavelnacionalidade_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavResponsavelnacionalidade_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vRESPONSAVELNACIONALIDADE");
               GX_FocusControl = edtavResponsavelnacionalidade_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7ResponsavelNacionalidade = 0;
               AssignAttri("", false, "AV7ResponsavelNacionalidade", StringUtil.LTrimStr( (decimal)(AV7ResponsavelNacionalidade), 9, 0));
            }
            else
            {
               AV7ResponsavelNacionalidade = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavResponsavelnacionalidade_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7ResponsavelNacionalidade", StringUtil.LTrimStr( (decimal)(AV7ResponsavelNacionalidade), 9, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavResponsavelprofissao_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavResponsavelprofissao_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vRESPONSAVELPROFISSAO");
               GX_FocusControl = edtavResponsavelprofissao_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9ResponsavelProfissao = 0;
               AssignAttri("", false, "AV9ResponsavelProfissao", StringUtil.LTrimStr( (decimal)(AV9ResponsavelProfissao), 9, 0));
            }
            else
            {
               AV9ResponsavelProfissao = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavResponsavelprofissao_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV9ResponsavelProfissao", StringUtil.LTrimStr( (decimal)(AV9ResponsavelProfissao), 9, 0));
            }
            AV19ResponsavelMunicipio = cgiGet( edtavResponsavelmunicipio_Internalname);
            AssignAttri("", false, "AV19ResponsavelMunicipio", AV19ResponsavelMunicipio);
            AV20RepsonsavelMunicipioNome = StringUtil.Upper( cgiGet( edtavRepsonsavelmunicipionome_Internalname));
            AssignAttri("", false, "AV20RepsonsavelMunicipioNome", AV20RepsonsavelMunicipioNome);
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
         E126A2 ();
         if (returnInSub) return;
      }

      protected void E126A2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV35Cliente.Load(AV34ClienteId);
         AV6ResponsavelNome = AV35Cliente.gxTpr_Responsavelnome;
         AssignAttri("", false, "AV6ResponsavelNome", AV6ResponsavelNome);
         AV7ResponsavelNacionalidade = AV35Cliente.gxTpr_Responsavelnacionalidade;
         AssignAttri("", false, "AV7ResponsavelNacionalidade", StringUtil.LTrimStr( (decimal)(AV7ResponsavelNacionalidade), 9, 0));
         AV36ResponsavelNacionalidadeNome = AV35Cliente.gxTpr_Responsavelnacionalidadenome;
         AV8ResponsavelEstadoCivil = AV35Cliente.gxTpr_Responsavelestadocivil;
         AssignAttri("", false, "AV8ResponsavelEstadoCivil", AV8ResponsavelEstadoCivil);
         AV9ResponsavelProfissao = AV35Cliente.gxTpr_Responsavelprofissao;
         AssignAttri("", false, "AV9ResponsavelProfissao", StringUtil.LTrimStr( (decimal)(AV9ResponsavelProfissao), 9, 0));
         AV37ResponsavelProfissaoNome = AV35Cliente.gxTpr_Responsavelprofissaonome;
         AV5ResponsavelCPF = AV35Cliente.gxTpr_Responsavelcpf;
         AssignAttri("", false, "AV5ResponsavelCPF", AV5ResponsavelCPF);
         AV13ResponsavelCEP = AV35Cliente.gxTpr_Responsavelcep;
         AssignAttri("", false, "AV13ResponsavelCEP", AV13ResponsavelCEP);
         AV14ResponsavelLogradouro = AV35Cliente.gxTpr_Responsavellogradouro;
         AssignAttri("", false, "AV14ResponsavelLogradouro", AV14ResponsavelLogradouro);
         AV16ResponsavelBairro = AV35Cliente.gxTpr_Responsavelbairro;
         AssignAttri("", false, "AV16ResponsavelBairro", AV16ResponsavelBairro);
         AV18ResponsavelCidade = AV35Cliente.gxTpr_Responsavelcidade;
         AssignAttri("", false, "AV18ResponsavelCidade", AV18ResponsavelCidade);
         AV19ResponsavelMunicipio = AV35Cliente.gxTpr_Responsavelmunicipio;
         AssignAttri("", false, "AV19ResponsavelMunicipio", AV19ResponsavelMunicipio);
         AV15ResponsavelLogradouroNumero = AV35Cliente.gxTpr_Responsavellogradouronumero;
         AssignAttri("", false, "AV15ResponsavelLogradouroNumero", StringUtil.LTrimStr( (decimal)(AV15ResponsavelLogradouroNumero), 9, 0));
         AV17ResponsavelComplemento = AV35Cliente.gxTpr_Responsavelcomplemento;
         AssignAttri("", false, "AV17ResponsavelComplemento", AV17ResponsavelComplemento);
         AV11ResponsavelDDD = AV35Cliente.gxTpr_Responsavelddd;
         AssignAttri("", false, "AV11ResponsavelDDD", StringUtil.LTrimStr( (decimal)(AV11ResponsavelDDD), 4, 0));
         AV12ResponsavelNumero = AV35Cliente.gxTpr_Responsavelnumero;
         AssignAttri("", false, "AV12ResponsavelNumero", StringUtil.LTrimStr( (decimal)(AV12ResponsavelNumero), 9, 0));
         AV10ResponsavelEmail = AV35Cliente.gxTpr_Responsavelemail;
         AssignAttri("", false, "AV10ResponsavelEmail", AV10ResponsavelEmail);
         edtavResponsavelprofissao_Visible = 0;
         AssignProp("", false, edtavResponsavelprofissao_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResponsavelprofissao_Visible), 5, 0), true);
         edtavResponsavelnacionalidade_Visible = 0;
         AssignProp("", false, edtavResponsavelnacionalidade_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResponsavelnacionalidade_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBORESPONSAVELNACIONALIDADE' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBORESPONSAVELPROFISSAO' */
         S122 ();
         if (returnInSub) return;
         edtavResponsavelmunicipio_Visible = 0;
         AssignProp("", false, edtavResponsavelmunicipio_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResponsavelmunicipio_Visible), 5, 0), true);
         edtavRepsonsavelmunicipionome_Visible = 0;
         AssignProp("", false, edtavRepsonsavelmunicipionome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavRepsonsavelmunicipionome_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV40TrnMode, "DSP") == 0 )
         {
            edtavResponsavelnome_Enabled = 0;
            AssignProp("", false, edtavResponsavelnome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelnome_Enabled), 5, 0), true);
            edtavResponsavelnacionalidade_Enabled = 0;
            AssignProp("", false, edtavResponsavelnacionalidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelnacionalidade_Enabled), 5, 0), true);
            cmbavResponsavelestadocivil.Enabled = 0;
            AssignProp("", false, cmbavResponsavelestadocivil_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavResponsavelestadocivil.Enabled), 5, 0), true);
            edtavResponsavelcpf_Enabled = 0;
            AssignProp("", false, edtavResponsavelcpf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelcpf_Enabled), 5, 0), true);
            edtavResponsavelcep_Enabled = 0;
            AssignProp("", false, edtavResponsavelcep_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelcep_Enabled), 5, 0), true);
            edtavResponsavellogradouro_Enabled = 0;
            AssignProp("", false, edtavResponsavellogradouro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavellogradouro_Enabled), 5, 0), true);
            edtavResponsavelbairro_Enabled = 0;
            AssignProp("", false, edtavResponsavelbairro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelbairro_Enabled), 5, 0), true);
            edtavResponsavelcidade_Enabled = 0;
            AssignProp("", false, edtavResponsavelcidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelcidade_Enabled), 5, 0), true);
            edtavResponsavelmunicipio_Enabled = 0;
            AssignProp("", false, edtavResponsavelmunicipio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelmunicipio_Enabled), 5, 0), true);
            edtavResponsavellogradouronumero_Enabled = 0;
            AssignProp("", false, edtavResponsavellogradouronumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavellogradouronumero_Enabled), 5, 0), true);
            edtavResponsavelcomplemento_Enabled = 0;
            AssignProp("", false, edtavResponsavelcomplemento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelcomplemento_Enabled), 5, 0), true);
            edtavResponsavelddd_Enabled = 0;
            AssignProp("", false, edtavResponsavelddd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelddd_Enabled), 5, 0), true);
            edtavResponsavelnumero_Enabled = 0;
            AssignProp("", false, edtavResponsavelnumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelnumero_Enabled), 5, 0), true);
            edtavResponsavelemail_Enabled = 0;
            AssignProp("", false, edtavResponsavelemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelemail_Enabled), 5, 0), true);
            Combo_responsavelprofissao_Enabled = false;
            ucCombo_responsavelprofissao.SendProperty(context, "", false, Combo_responsavelprofissao_Internalname, "Enabled", StringUtil.BoolToStr( Combo_responsavelprofissao_Enabled));
            Combo_responsavelnacionalidade_Enabled = false;
            ucCombo_responsavelnacionalidade.SendProperty(context, "", false, Combo_responsavelnacionalidade_Internalname, "Enabled", StringUtil.BoolToStr( Combo_responsavelnacionalidade_Enabled));
            bttBtnenter_Visible = 0;
            AssignProp("", false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
         }
      }

      protected void E116A2( )
      {
         /* Combo_responsavelprofissao_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Combo_responsavelprofissao_Selectedvalue_get, "<#NEW#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "profissao"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
            context.PopUp(formatLink("profissao") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         }
         else if ( StringUtil.StrCmp(Combo_responsavelprofissao_Selectedvalue_get, "<#POPUP_CLOSED#>") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBORESPONSAVELPROFISSAO' */
            S122 ();
            if (returnInSub) return;
            AV26ComboSelectedValue = AV27Session.Get("PROFISSAOID");
            AV27Session.Remove("PROFISSAOID");
            Combo_responsavelprofissao_Selectedvalue_set = AV26ComboSelectedValue;
            ucCombo_responsavelprofissao.SendProperty(context, "", false, Combo_responsavelprofissao_Internalname, "SelectedValue_set", Combo_responsavelprofissao_Selectedvalue_set);
            AV9ResponsavelProfissao = (int)(Math.Round(NumberUtil.Val( AV26ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV9ResponsavelProfissao", StringUtil.LTrimStr( (decimal)(AV9ResponsavelProfissao), 9, 0));
         }
         else
         {
            AV9ResponsavelProfissao = (int)(Math.Round(NumberUtil.Val( Combo_responsavelprofissao_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV9ResponsavelProfissao", StringUtil.LTrimStr( (decimal)(AV9ResponsavelProfissao), 9, 0));
            /* Execute user subroutine: 'LOADCOMBORESPONSAVELPROFISSAO' */
            S122 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25ResponsavelProfissao_Data", AV25ResponsavelProfissao_Data);
      }

      protected void S152( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV22CheckRequiredFieldsResult = true;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV5ResponsavelCPF)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "CPF", "", "", "", "", "", "", "", ""),  "error",  edtavResponsavelcpf_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV6ResponsavelNome)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Nome", "", "", "", "", "", "", "", ""),  "error",  edtavResponsavelnome_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
         }
         if ( (0==AV7ResponsavelNacionalidade) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Nacionalidade", "", "", "", "", "", "", "", ""),  "error",  Combo_responsavelnacionalidade_Ddointernalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV8ResponsavelEstadoCivil)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Estado civil", "", "", "", "", "", "", "", ""),  "error",  cmbavResponsavelestadocivil_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
         }
         if ( (0==AV9ResponsavelProfissao) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Profissão", "", "", "", "", "", "", "", ""),  "error",  Combo_responsavelprofissao_Ddointernalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13ResponsavelCEP)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "CEP", "", "", "", "", "", "", "", ""),  "error",  edtavResponsavelcep_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14ResponsavelLogradouro)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Logradouro", "", "", "", "", "", "", "", ""),  "error",  edtavResponsavellogradouro_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
         }
         if ( (0==AV15ResponsavelLogradouroNumero) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Número", "", "", "", "", "", "", "", ""),  "error",  edtavResponsavellogradouronumero_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16ResponsavelBairro)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Bairro", "", "", "", "", "", "", "", ""),  "error",  edtavResponsavelbairro_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17ResponsavelComplemento)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Complemento", "", "", "", "", "", "", "", ""),  "error",  edtavResponsavelcomplemento_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18ResponsavelCidade)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Cidade", "", "", "", "", "", "", "", ""),  "error",  edtavResponsavelcidade_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV10ResponsavelEmail)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "E-mail", "", "", "", "", "", "", "", ""),  "error",  edtavResponsavelemail_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
         }
         if ( (0==AV11ResponsavelDDD) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "DDD", "", "", "", "", "", "", "", ""),  "error",  edtavResponsavelddd_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
         }
         if ( (0==AV12ResponsavelNumero) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Número", "", "", "", "", "", "", "", ""),  "error",  edtavResponsavelnumero_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
         }
         /* Execute user subroutine: 'VALIDACPF' */
         S132 ();
         if (returnInSub) return;
      }

      protected void S122( )
      {
         /* 'LOADCOMBORESPONSAVELPROFISSAO' Routine */
         returnInSub = false;
         AV25ResponsavelProfissao_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         /* Using cursor H006A2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A440ProfissaoId = H006A2_A440ProfissaoId[0];
            A441ProfissaoNome = H006A2_A441ProfissaoNome[0];
            n441ProfissaoNome = H006A2_n441ProfissaoNome[0];
            AV24Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV24Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A440ProfissaoId), 9, 0));
            AV24Combo_DataItem.gxTpr_Title = A441ProfissaoNome;
            AV25ResponsavelProfissao_Data.Add(AV24Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         Combo_responsavelprofissao_Selectedvalue_set = ((0==AV9ResponsavelProfissao) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV9ResponsavelProfissao), 9, 0)));
         ucCombo_responsavelprofissao.SendProperty(context, "", false, Combo_responsavelprofissao_Internalname, "SelectedValue_set", Combo_responsavelprofissao_Selectedvalue_set);
      }

      protected void S112( )
      {
         /* 'LOADCOMBORESPONSAVELNACIONALIDADE' Routine */
         returnInSub = false;
         /* Using cursor H006A3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A434NacionalidadeId = H006A3_A434NacionalidadeId[0];
            A435NacionalidadeNome = H006A3_A435NacionalidadeNome[0];
            n435NacionalidadeNome = H006A3_n435NacionalidadeNome[0];
            AV24Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV24Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A434NacionalidadeId), 9, 0));
            AV24Combo_DataItem.gxTpr_Title = A435NacionalidadeNome;
            AV23ResponsavelNacionalidade_Data.Add(AV24Combo_DataItem, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         Combo_responsavelnacionalidade_Selectedvalue_set = ((0==AV7ResponsavelNacionalidade) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV7ResponsavelNacionalidade), 9, 0)));
         ucCombo_responsavelnacionalidade.SendProperty(context, "", false, Combo_responsavelnacionalidade_Internalname, "SelectedValue_set", Combo_responsavelnacionalidade_Selectedvalue_set);
      }

      protected void E136A2( )
      {
         /* Responsavelcpf_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'VALIDACPF' */
         S132 ();
         if (returnInSub) return;
      }

      protected void E146A2( )
      {
         /* Responsavelcep_Controlvaluechanged Routine */
         returnInSub = false;
         AV31MunicipioNome = "";
         AV32MunicipioUF = "";
         AV13ResponsavelCEP = StringUtil.StringReplace( AV13ResponsavelCEP, "-", "");
         AssignAttri("", false, "AV13ResponsavelCEP", AV13ResponsavelCEP);
         AV29EnderecoCompleto = new GeneXus.Programs.myobjects.viacep.SdtEnderecoCompleto(context);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13ResponsavelCEP)) )
         {
            new GeneXus.Programs.myobjects.viacep.cepparaendereco(context ).execute(  AV13ResponsavelCEP, out  AV30ModeloRetorno, out  AV33Mensagem) ;
            AV29EnderecoCompleto.FromJSonString(AV30ModeloRetorno, null);
            /* Execute user subroutine: 'VALIDACEP' */
            S142 ();
            if (returnInSub) return;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29EnderecoCompleto.gxTpr_Cep)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "",  "error",  edtavResponsavelnumero_Internalname,  "true",  ""));
         }
         AV16ResponsavelBairro = AV29EnderecoCompleto.gxTpr_Bairro;
         AssignAttri("", false, "AV16ResponsavelBairro", AV16ResponsavelBairro);
         AV18ResponsavelCidade = AV29EnderecoCompleto.gxTpr_Localidade;
         AssignAttri("", false, "AV18ResponsavelCidade", AV18ResponsavelCidade);
         AV14ResponsavelLogradouro = AV29EnderecoCompleto.gxTpr_Logradouro;
         AssignAttri("", false, "AV14ResponsavelLogradouro", AV14ResponsavelLogradouro);
         AV19ResponsavelMunicipio = AV29EnderecoCompleto.gxTpr_Ibge;
         AssignAttri("", false, "AV19ResponsavelMunicipio", AV19ResponsavelMunicipio);
         AV38IsAchou = false;
         AV20RepsonsavelMunicipioNome = AV29EnderecoCompleto.gxTpr_Localidade;
         AssignAttri("", false, "AV20RepsonsavelMunicipioNome", AV20RepsonsavelMunicipioNome);
         AV21RepsonsavelMunicipioUF = AV29EnderecoCompleto.gxTpr_Uf;
         AssignAttri("", false, "AV21RepsonsavelMunicipioUF", AV21RepsonsavelMunicipioUF);
         AV39Municipio.Load(AV19ResponsavelMunicipio);
         if ( AV39Municipio.Fail() )
         {
            AV39Municipio.gxTpr_Municipionome = AV29EnderecoCompleto.gxTpr_Localidade;
            AV39Municipio.gxTpr_Municipiouf = AV29EnderecoCompleto.gxTpr_Uf;
            AV39Municipio.Save();
            if ( AV39Municipio.Success() )
            {
               context.CommitDataStores("wpresponsavel",pr_default);
            }
         }
         edtavResponsavelbairro_Enabled = ((String.IsNullOrEmpty(StringUtil.RTrim( AV29EnderecoCompleto.gxTpr_Bairro)) ? true : false) ? 1 : 0);
         AssignProp("", false, edtavResponsavelbairro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelbairro_Enabled), 5, 0), true);
         edtavResponsavelcidade_Enabled = ((String.IsNullOrEmpty(StringUtil.RTrim( AV29EnderecoCompleto.gxTpr_Localidade)) ? true : false) ? 1 : 0);
         AssignProp("", false, edtavResponsavelcidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelcidade_Enabled), 5, 0), true);
         edtavResponsavellogradouro_Enabled = ((String.IsNullOrEmpty(StringUtil.RTrim( AV29EnderecoCompleto.gxTpr_Logradouro)) ? true : false) ? 1 : 0);
         AssignProp("", false, edtavResponsavellogradouro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavellogradouro_Enabled), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV29EnderecoCompleto", AV29EnderecoCompleto);
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E156A2 ();
         if (returnInSub) return;
      }

      protected void E156A2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV35Cliente.gxTpr_Responsavelnome = AV6ResponsavelNome;
         AV35Cliente.gxTpr_Responsavelnacionalidade = AV7ResponsavelNacionalidade;
         AV35Cliente.gxTpr_Responsavelestadocivil = AV8ResponsavelEstadoCivil;
         AV35Cliente.gxTpr_Responsavelprofissao = AV9ResponsavelProfissao;
         AV35Cliente.gxTpr_Responsavelcpf = AV5ResponsavelCPF;
         AV35Cliente.gxTpr_Responsavelcep = AV13ResponsavelCEP;
         AV35Cliente.gxTpr_Responsavellogradouro = AV14ResponsavelLogradouro;
         AV35Cliente.gxTpr_Responsavelbairro = AV16ResponsavelBairro;
         AV35Cliente.gxTpr_Responsavelcidade = AV18ResponsavelCidade;
         AV35Cliente.gxTpr_Responsavelmunicipio = AV19ResponsavelMunicipio;
         AV35Cliente.gxTpr_Responsavellogradouronumero = AV15ResponsavelLogradouroNumero;
         AV35Cliente.gxTpr_Responsavelcomplemento = AV17ResponsavelComplemento;
         AV35Cliente.gxTpr_Responsavelddd = AV11ResponsavelDDD;
         AV35Cliente.gxTpr_Responsavelnumero = AV12ResponsavelNumero;
         AV35Cliente.gxTpr_Responsavelemail = AV10ResponsavelEmail;
         AV35Cliente.Save();
         if ( AV35Cliente.Success() )
         {
            context.CommitDataStores("wpresponsavel",pr_default);
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         else
         {
            GXt_char1 = ((GeneXus.Utils.SdtMessages_Message)AV35Cliente.GetMessages().Item(1)).gxTpr_Description;
            new message(context ).gxep_erro( ref  GXt_char1) ;
            ((GeneXus.Utils.SdtMessages_Message)AV35Cliente.GetMessages().Item(1)).gxTpr_Description = GXt_char1;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35Cliente", AV35Cliente);
      }

      protected void S132( )
      {
         /* 'VALIDACPF' Routine */
         returnInSub = false;
         GXt_char1 = "";
         new prvalidcpf(context ).execute(  "FISICA",  AV5ResponsavelCPF, out  AV28IsOK, out  GXt_char1) ;
         if ( ! AV28IsOK )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Documento inválido, verifique!",  "error",  edtavResponsavelcpf_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
         }
      }

      protected void S142( )
      {
         /* 'VALIDACEP' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV29EnderecoCompleto.gxTpr_Cep)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "CEP não encontrado",  "error",  edtavResponsavelcep_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E166A2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV40TrnMode = (string)getParm(obj,0);
         AssignAttri("", false, "AV40TrnMode", AV40TrnMode);
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV40TrnMode, "")), context));
         AV34ClienteId = Convert.ToInt32(getParm(obj,1));
         AssignAttri("", false, "AV34ClienteId", StringUtil.LTrimStr( (decimal)(AV34ClienteId), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV34ClienteId), "ZZZZZZZZ9"), context));
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
         PA6A2( ) ;
         WS6A2( ) ;
         WE6A2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025610192614", true, true);
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
         context.AddJavascriptSource("wpresponsavel.js", "?2025610192615", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavResponsavelestadocivil.Name = "vRESPONSAVELESTADOCIVIL";
         cmbavResponsavelestadocivil.WebTags = "";
         cmbavResponsavelestadocivil.addItem("SOLTEIRO", "Solteiro(a)", 0);
         cmbavResponsavelestadocivil.addItem("CASADO", "Casado(a)", 0);
         cmbavResponsavelestadocivil.addItem("DIVORCIADO", "Divorciado(a)", 0);
         cmbavResponsavelestadocivil.addItem("VIUVO", "Viúvo(a)", 0);
         cmbavResponsavelestadocivil.addItem("SEPARADO", "Separado(a)", 0);
         cmbavResponsavelestadocivil.addItem("UNIAO_ESTAVEL", "União Estável", 0);
         if ( cmbavResponsavelestadocivil.ItemCount > 0 )
         {
            AV8ResponsavelEstadoCivil = cmbavResponsavelestadocivil.getValidValue(AV8ResponsavelEstadoCivil);
            AssignAttri("", false, "AV8ResponsavelEstadoCivil", AV8ResponsavelEstadoCivil);
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavResponsavelcpf_Internalname = "vRESPONSAVELCPF";
         edtavResponsavelnome_Internalname = "vRESPONSAVELNOME";
         lblTextblockcombo_responsavelnacionalidade_Internalname = "TEXTBLOCKCOMBO_RESPONSAVELNACIONALIDADE";
         Combo_responsavelnacionalidade_Internalname = "COMBO_RESPONSAVELNACIONALIDADE";
         divTablesplittedresponsavelnacionalidade_Internalname = "TABLESPLITTEDRESPONSAVELNACIONALIDADE";
         cmbavResponsavelestadocivil_Internalname = "vRESPONSAVELESTADOCIVIL";
         lblTextblockcombo_responsavelprofissao_Internalname = "TEXTBLOCKCOMBO_RESPONSAVELPROFISSAO";
         Combo_responsavelprofissao_Internalname = "COMBO_RESPONSAVELPROFISSAO";
         divTablesplittedresponsavelprofissao_Internalname = "TABLESPLITTEDRESPONSAVELPROFISSAO";
         edtavResponsavelcep_Internalname = "vRESPONSAVELCEP";
         edtavResponsavellogradouro_Internalname = "vRESPONSAVELLOGRADOURO";
         edtavResponsavellogradouronumero_Internalname = "vRESPONSAVELLOGRADOURONUMERO";
         edtavResponsavelbairro_Internalname = "vRESPONSAVELBAIRRO";
         edtavResponsavelcomplemento_Internalname = "vRESPONSAVELCOMPLEMENTO";
         edtavResponsavelcidade_Internalname = "vRESPONSAVELCIDADE";
         edtavRepsonsavelmunicipiouf_Internalname = "vREPSONSAVELMUNICIPIOUF";
         divTableresponsavelendereco_Internalname = "TABLERESPONSAVELENDERECO";
         grpUnnamedgroup2_Internalname = "UNNAMEDGROUP2";
         edtavResponsavelemail_Internalname = "vRESPONSAVELEMAIL";
         edtavResponsavelddd_Internalname = "vRESPONSAVELDDD";
         edtavResponsavelnumero_Internalname = "vRESPONSAVELNUMERO";
         divTableresponsavelcontato_Internalname = "TABLERESPONSAVELCONTATO";
         grpUnnamedgroup3_Internalname = "UNNAMEDGROUP3";
         divTableresponsavel_Internalname = "TABLERESPONSAVEL";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         edtavResponsavelnacionalidade_Internalname = "vRESPONSAVELNACIONALIDADE";
         edtavResponsavelprofissao_Internalname = "vRESPONSAVELPROFISSAO";
         edtavResponsavelmunicipio_Internalname = "vRESPONSAVELMUNICIPIO";
         edtavRepsonsavelmunicipionome_Internalname = "vREPSONSAVELMUNICIPIONOME";
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
         edtavRepsonsavelmunicipionome_Jsonclick = "";
         edtavRepsonsavelmunicipionome_Visible = 1;
         edtavResponsavelmunicipio_Jsonclick = "";
         edtavResponsavelmunicipio_Enabled = 1;
         edtavResponsavelmunicipio_Visible = 1;
         edtavResponsavelprofissao_Jsonclick = "";
         edtavResponsavelprofissao_Visible = 1;
         edtavResponsavelnacionalidade_Jsonclick = "";
         edtavResponsavelnacionalidade_Enabled = 1;
         edtavResponsavelnacionalidade_Visible = 1;
         bttBtnenter_Visible = 1;
         edtavResponsavelnumero_Jsonclick = "";
         edtavResponsavelnumero_Enabled = 1;
         edtavResponsavelddd_Jsonclick = "";
         edtavResponsavelddd_Enabled = 1;
         edtavResponsavelemail_Jsonclick = "";
         edtavResponsavelemail_Enabled = 1;
         edtavRepsonsavelmunicipiouf_Jsonclick = "";
         edtavRepsonsavelmunicipiouf_Enabled = 1;
         edtavResponsavelcidade_Jsonclick = "";
         edtavResponsavelcidade_Enabled = 1;
         edtavResponsavelcomplemento_Jsonclick = "";
         edtavResponsavelcomplemento_Enabled = 1;
         edtavResponsavelbairro_Jsonclick = "";
         edtavResponsavelbairro_Enabled = 1;
         edtavResponsavellogradouronumero_Jsonclick = "";
         edtavResponsavellogradouronumero_Enabled = 1;
         edtavResponsavellogradouro_Jsonclick = "";
         edtavResponsavellogradouro_Enabled = 1;
         edtavResponsavelcep_Jsonclick = "";
         edtavResponsavelcep_Enabled = 1;
         cmbavResponsavelestadocivil_Jsonclick = "";
         cmbavResponsavelestadocivil.Enabled = 1;
         edtavResponsavelnome_Jsonclick = "";
         edtavResponsavelnome_Enabled = 1;
         edtavResponsavelcpf_Jsonclick = "";
         edtavResponsavelcpf_Enabled = 1;
         Combo_responsavelprofissao_Includeaddnewoption = Convert.ToBoolean( -1);
         Combo_responsavelprofissao_Emptyitem = Convert.ToBoolean( 0);
         Combo_responsavelprofissao_Enabled = Convert.ToBoolean( -1);
         Combo_responsavelprofissao_Cls = "ExtendedCombo AttributeFL";
         Combo_responsavelnacionalidade_Emptyitem = Convert.ToBoolean( 0);
         Combo_responsavelnacionalidade_Enabled = Convert.ToBoolean( -1);
         Combo_responsavelnacionalidade_Cls = "ExtendedCombo AttributeFL";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Responsável";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV40TrnMode","fld":"vTRNMODE","hsh":true,"type":"char"},{"av":"AV34ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("COMBO_RESPONSAVELPROFISSAO.ONOPTIONCLICKED","""{"handler":"E116A2","iparms":[{"av":"Combo_responsavelprofissao_Selectedvalue_get","ctrl":"COMBO_RESPONSAVELPROFISSAO","prop":"SelectedValue_get"},{"av":"A440ProfissaoId","fld":"PROFISSAOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A441ProfissaoNome","fld":"PROFISSAONOME","pic":"@!","type":"svchar"},{"av":"AV9ResponsavelProfissao","fld":"vRESPONSAVELPROFISSAO","pic":"ZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("COMBO_RESPONSAVELPROFISSAO.ONOPTIONCLICKED",""","oparms":[{"av":"Combo_responsavelprofissao_Selectedvalue_set","ctrl":"COMBO_RESPONSAVELPROFISSAO","prop":"SelectedValue_set"},{"av":"AV9ResponsavelProfissao","fld":"vRESPONSAVELPROFISSAO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV25ResponsavelProfissao_Data","fld":"vRESPONSAVELPROFISSAO_DATA","type":""}]}""");
         setEventMetadata("VRESPONSAVELCPF.CONTROLVALUECHANGED","""{"handler":"E136A2","iparms":[{"av":"AV5ResponsavelCPF","fld":"vRESPONSAVELCPF","type":"svchar"}]}""");
         setEventMetadata("VRESPONSAVELCEP.CONTROLVALUECHANGED","""{"handler":"E146A2","iparms":[{"av":"AV13ResponsavelCEP","fld":"vRESPONSAVELCEP","type":"svchar"},{"av":"AV29EnderecoCompleto","fld":"vENDERECOCOMPLETO","type":""}]""");
         setEventMetadata("VRESPONSAVELCEP.CONTROLVALUECHANGED",""","oparms":[{"av":"AV13ResponsavelCEP","fld":"vRESPONSAVELCEP","type":"svchar"},{"av":"AV29EnderecoCompleto","fld":"vENDERECOCOMPLETO","type":""},{"av":"AV16ResponsavelBairro","fld":"vRESPONSAVELBAIRRO","type":"svchar"},{"av":"AV18ResponsavelCidade","fld":"vRESPONSAVELCIDADE","type":"svchar"},{"av":"AV14ResponsavelLogradouro","fld":"vRESPONSAVELLOGRADOURO","type":"svchar"},{"av":"AV19ResponsavelMunicipio","fld":"vRESPONSAVELMUNICIPIO","type":"svchar"},{"av":"AV20RepsonsavelMunicipioNome","fld":"vREPSONSAVELMUNICIPIONOME","pic":"@!","type":"svchar"},{"av":"AV21RepsonsavelMunicipioUF","fld":"vREPSONSAVELMUNICIPIOUF","pic":"@!","type":"svchar"},{"av":"edtavResponsavelbairro_Enabled","ctrl":"vRESPONSAVELBAIRRO","prop":"Enabled"},{"av":"edtavResponsavelcidade_Enabled","ctrl":"vRESPONSAVELCIDADE","prop":"Enabled"},{"av":"edtavResponsavellogradouro_Enabled","ctrl":"vRESPONSAVELLOGRADOURO","prop":"Enabled"}]}""");
         setEventMetadata("ENTER","""{"handler":"E156A2","iparms":[{"av":"AV6ResponsavelNome","fld":"vRESPONSAVELNOME","type":"svchar"},{"av":"AV35Cliente","fld":"vCLIENTE","type":""},{"av":"AV7ResponsavelNacionalidade","fld":"vRESPONSAVELNACIONALIDADE","pic":"ZZZZZZZZ9","type":"int"},{"av":"cmbavResponsavelestadocivil"},{"av":"AV8ResponsavelEstadoCivil","fld":"vRESPONSAVELESTADOCIVIL","type":"svchar"},{"av":"AV9ResponsavelProfissao","fld":"vRESPONSAVELPROFISSAO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV5ResponsavelCPF","fld":"vRESPONSAVELCPF","type":"svchar"},{"av":"AV13ResponsavelCEP","fld":"vRESPONSAVELCEP","type":"svchar"},{"av":"AV14ResponsavelLogradouro","fld":"vRESPONSAVELLOGRADOURO","type":"svchar"},{"av":"AV16ResponsavelBairro","fld":"vRESPONSAVELBAIRRO","type":"svchar"},{"av":"AV18ResponsavelCidade","fld":"vRESPONSAVELCIDADE","type":"svchar"},{"av":"AV19ResponsavelMunicipio","fld":"vRESPONSAVELMUNICIPIO","type":"svchar"},{"av":"AV15ResponsavelLogradouroNumero","fld":"vRESPONSAVELLOGRADOURONUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV17ResponsavelComplemento","fld":"vRESPONSAVELCOMPLEMENTO","type":"svchar"},{"av":"AV11ResponsavelDDD","fld":"vRESPONSAVELDDD","pic":"ZZZ9","type":"int"},{"av":"AV12ResponsavelNumero","fld":"vRESPONSAVELNUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV10ResponsavelEmail","fld":"vRESPONSAVELEMAIL","type":"svchar"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV35Cliente","fld":"vCLIENTE","type":""}]}""");
         setEventMetadata("VALIDV_RESPONSAVELESTADOCIVIL","""{"handler":"Validv_Responsavelestadocivil","iparms":[]}""");
         setEventMetadata("VALIDV_RESPONSAVELEMAIL","""{"handler":"Validv_Responsavelemail","iparms":[]}""");
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
         wcpOAV40TrnMode = "";
         Combo_responsavelprofissao_Selectedvalue_get = "";
         Combo_responsavelnacionalidade_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV23ResponsavelNacionalidade_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV25ResponsavelProfissao_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A441ProfissaoNome = "";
         AV29EnderecoCompleto = new GeneXus.Programs.myobjects.viacep.SdtEnderecoCompleto(context);
         AV35Cliente = new SdtCliente(context);
         Combo_responsavelnacionalidade_Selectedvalue_set = "";
         Combo_responsavelprofissao_Selectedvalue_set = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV5ResponsavelCPF = "";
         AV6ResponsavelNome = "";
         lblTextblockcombo_responsavelnacionalidade_Jsonclick = "";
         ucCombo_responsavelnacionalidade = new GXUserControl();
         Combo_responsavelnacionalidade_Caption = "";
         AV8ResponsavelEstadoCivil = "";
         lblTextblockcombo_responsavelprofissao_Jsonclick = "";
         ucCombo_responsavelprofissao = new GXUserControl();
         Combo_responsavelprofissao_Caption = "";
         AV13ResponsavelCEP = "";
         AV14ResponsavelLogradouro = "";
         AV16ResponsavelBairro = "";
         AV17ResponsavelComplemento = "";
         AV18ResponsavelCidade = "";
         AV21RepsonsavelMunicipioUF = "";
         AV10ResponsavelEmail = "";
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         AV19ResponsavelMunicipio = "";
         AV20RepsonsavelMunicipioNome = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV36ResponsavelNacionalidadeNome = "";
         AV37ResponsavelProfissaoNome = "";
         AV26ComboSelectedValue = "";
         AV27Session = context.GetSession();
         Combo_responsavelnacionalidade_Ddointernalname = "";
         Combo_responsavelprofissao_Ddointernalname = "";
         H006A2_A440ProfissaoId = new int[1] ;
         H006A2_A441ProfissaoNome = new string[] {""} ;
         H006A2_n441ProfissaoNome = new bool[] {false} ;
         AV24Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         H006A3_A434NacionalidadeId = new int[1] ;
         H006A3_A435NacionalidadeNome = new string[] {""} ;
         H006A3_n435NacionalidadeNome = new bool[] {false} ;
         A435NacionalidadeNome = "";
         AV31MunicipioNome = "";
         AV32MunicipioUF = "";
         AV30ModeloRetorno = "";
         AV33Mensagem = "";
         AV39Municipio = new SdtMunicipio(context);
         GXt_char1 = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpresponsavel__default(),
            new Object[][] {
                new Object[] {
               H006A2_A440ProfissaoId, H006A2_A441ProfissaoNome, H006A2_n441ProfissaoNome
               }
               , new Object[] {
               H006A3_A434NacionalidadeId, H006A3_A435NacionalidadeNome, H006A3_n435NacionalidadeNome
               }
            }
         );
         /* GeneXus formulas. */
         edtavRepsonsavelmunicipiouf_Enabled = 0;
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
      private short AV11ResponsavelDDD ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int AV34ClienteId ;
      private int wcpOAV34ClienteId ;
      private int A440ProfissaoId ;
      private int edtavResponsavelcpf_Enabled ;
      private int edtavResponsavelnome_Enabled ;
      private int edtavResponsavelcep_Enabled ;
      private int edtavResponsavellogradouro_Enabled ;
      private int AV15ResponsavelLogradouroNumero ;
      private int edtavResponsavellogradouronumero_Enabled ;
      private int edtavResponsavelbairro_Enabled ;
      private int edtavResponsavelcomplemento_Enabled ;
      private int edtavResponsavelcidade_Enabled ;
      private int edtavRepsonsavelmunicipiouf_Enabled ;
      private int edtavResponsavelemail_Enabled ;
      private int edtavResponsavelddd_Enabled ;
      private int AV12ResponsavelNumero ;
      private int edtavResponsavelnumero_Enabled ;
      private int bttBtnenter_Visible ;
      private int AV7ResponsavelNacionalidade ;
      private int edtavResponsavelnacionalidade_Visible ;
      private int edtavResponsavelnacionalidade_Enabled ;
      private int AV9ResponsavelProfissao ;
      private int edtavResponsavelprofissao_Visible ;
      private int edtavResponsavelmunicipio_Visible ;
      private int edtavResponsavelmunicipio_Enabled ;
      private int edtavRepsonsavelmunicipionome_Visible ;
      private int A434NacionalidadeId ;
      private int idxLst ;
      private string AV40TrnMode ;
      private string wcpOAV40TrnMode ;
      private string Combo_responsavelprofissao_Selectedvalue_get ;
      private string Combo_responsavelnacionalidade_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Combo_responsavelnacionalidade_Cls ;
      private string Combo_responsavelnacionalidade_Selectedvalue_set ;
      private string Combo_responsavelprofissao_Cls ;
      private string Combo_responsavelprofissao_Selectedvalue_set ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTableresponsavel_Internalname ;
      private string edtavResponsavelcpf_Internalname ;
      private string TempTags ;
      private string edtavResponsavelcpf_Jsonclick ;
      private string edtavResponsavelnome_Internalname ;
      private string edtavResponsavelnome_Jsonclick ;
      private string divTablesplittedresponsavelnacionalidade_Internalname ;
      private string lblTextblockcombo_responsavelnacionalidade_Internalname ;
      private string lblTextblockcombo_responsavelnacionalidade_Jsonclick ;
      private string Combo_responsavelnacionalidade_Caption ;
      private string Combo_responsavelnacionalidade_Internalname ;
      private string cmbavResponsavelestadocivil_Internalname ;
      private string cmbavResponsavelestadocivil_Jsonclick ;
      private string divTablesplittedresponsavelprofissao_Internalname ;
      private string lblTextblockcombo_responsavelprofissao_Internalname ;
      private string lblTextblockcombo_responsavelprofissao_Jsonclick ;
      private string Combo_responsavelprofissao_Caption ;
      private string Combo_responsavelprofissao_Internalname ;
      private string grpUnnamedgroup2_Internalname ;
      private string divTableresponsavelendereco_Internalname ;
      private string edtavResponsavelcep_Internalname ;
      private string edtavResponsavelcep_Jsonclick ;
      private string edtavResponsavellogradouro_Internalname ;
      private string edtavResponsavellogradouro_Jsonclick ;
      private string edtavResponsavellogradouronumero_Internalname ;
      private string edtavResponsavellogradouronumero_Jsonclick ;
      private string edtavResponsavelbairro_Internalname ;
      private string edtavResponsavelbairro_Jsonclick ;
      private string edtavResponsavelcomplemento_Internalname ;
      private string edtavResponsavelcomplemento_Jsonclick ;
      private string edtavResponsavelcidade_Internalname ;
      private string edtavResponsavelcidade_Jsonclick ;
      private string edtavRepsonsavelmunicipiouf_Internalname ;
      private string edtavRepsonsavelmunicipiouf_Jsonclick ;
      private string grpUnnamedgroup3_Internalname ;
      private string divTableresponsavelcontato_Internalname ;
      private string edtavResponsavelemail_Internalname ;
      private string edtavResponsavelemail_Jsonclick ;
      private string edtavResponsavelddd_Internalname ;
      private string edtavResponsavelddd_Jsonclick ;
      private string edtavResponsavelnumero_Internalname ;
      private string edtavResponsavelnumero_Jsonclick ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavResponsavelnacionalidade_Internalname ;
      private string edtavResponsavelnacionalidade_Jsonclick ;
      private string edtavResponsavelprofissao_Internalname ;
      private string edtavResponsavelprofissao_Jsonclick ;
      private string edtavResponsavelmunicipio_Internalname ;
      private string edtavResponsavelmunicipio_Jsonclick ;
      private string edtavRepsonsavelmunicipionome_Internalname ;
      private string edtavRepsonsavelmunicipionome_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string Combo_responsavelnacionalidade_Ddointernalname ;
      private string Combo_responsavelprofissao_Ddointernalname ;
      private string GXt_char1 ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Combo_responsavelnacionalidade_Enabled ;
      private bool Combo_responsavelnacionalidade_Emptyitem ;
      private bool Combo_responsavelprofissao_Enabled ;
      private bool Combo_responsavelprofissao_Emptyitem ;
      private bool Combo_responsavelprofissao_Includeaddnewoption ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV22CheckRequiredFieldsResult ;
      private bool n441ProfissaoNome ;
      private bool n435NacionalidadeNome ;
      private bool AV38IsAchou ;
      private bool AV28IsOK ;
      private string AV30ModeloRetorno ;
      private string A441ProfissaoNome ;
      private string AV5ResponsavelCPF ;
      private string AV6ResponsavelNome ;
      private string AV8ResponsavelEstadoCivil ;
      private string AV13ResponsavelCEP ;
      private string AV14ResponsavelLogradouro ;
      private string AV16ResponsavelBairro ;
      private string AV17ResponsavelComplemento ;
      private string AV18ResponsavelCidade ;
      private string AV21RepsonsavelMunicipioUF ;
      private string AV10ResponsavelEmail ;
      private string AV19ResponsavelMunicipio ;
      private string AV20RepsonsavelMunicipioNome ;
      private string AV36ResponsavelNacionalidadeNome ;
      private string AV37ResponsavelProfissaoNome ;
      private string AV26ComboSelectedValue ;
      private string A435NacionalidadeNome ;
      private string AV31MunicipioNome ;
      private string AV32MunicipioUF ;
      private string AV33Mensagem ;
      private IGxSession AV27Session ;
      private GXUserControl ucCombo_responsavelnacionalidade ;
      private GXUserControl ucCombo_responsavelprofissao ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavResponsavelestadocivil ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV23ResponsavelNacionalidade_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV25ResponsavelProfissao_Data ;
      private GeneXus.Programs.myobjects.viacep.SdtEnderecoCompleto AV29EnderecoCompleto ;
      private SdtCliente AV35Cliente ;
      private IDataStoreProvider pr_default ;
      private int[] H006A2_A440ProfissaoId ;
      private string[] H006A2_A441ProfissaoNome ;
      private bool[] H006A2_n441ProfissaoNome ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV24Combo_DataItem ;
      private int[] H006A3_A434NacionalidadeId ;
      private string[] H006A3_A435NacionalidadeNome ;
      private bool[] H006A3_n435NacionalidadeNome ;
      private SdtMunicipio AV39Municipio ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpresponsavel__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH006A2;
          prmH006A2 = new Object[] {
          };
          Object[] prmH006A3;
          prmH006A3 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H006A2", "SELECT ProfissaoId, ProfissaoNome FROM Profissao ORDER BY ProfissaoNome ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006A2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H006A3", "SELECT NacionalidadeId, NacionalidadeNome FROM Nacionalidade ORDER BY NacionalidadeNome ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006A3,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

 }

}
