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
   public class wpcontratosassinatura : GXDataArea
   {
      public wpcontratosassinatura( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpcontratosassinatura( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_PropostaId )
      {
         this.AV9PropostaId = aP0_PropostaId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavPropostacontratoassinaturatipo = new GXCombobox();
         cmbavPropostaassinaturastatus = new GXCombobox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               gxnrGrid_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
            {
               gxgrGrid_refresh_invoke( ) ;
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

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_48 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_48"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_48_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_48_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_48_idx = GetPar( "sGXsfl_48_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid_newrow( ) ;
         /* End function gxnrGrid_newrow_invoke */
      }

      protected void gxgrGrid_refresh_invoke( )
      {
         subGrid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid_Rows"), "."), 18, MidpointRounding.ToEven));
         A573PropostaContratoAssinaturaTipo = GetPar( "PropostaContratoAssinaturaTipo");
         n573PropostaContratoAssinaturaTipo = false;
         A323PropostaId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaId"), "."), 18, MidpointRounding.ToEven));
         n323PropostaId = false;
         AV9PropostaId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaId"), "."), 18, MidpointRounding.ToEven));
         A574PropostaAssinaturaStatus = GetPar( "PropostaAssinaturaStatus");
         n574PropostaAssinaturaStatus = false;
         A571PropostaAssinatura = (long)(Math.Round(NumberUtil.Val( GetPar( "PropostaAssinatura"), "."), 18, MidpointRounding.ToEven));
         n571PropostaAssinatura = false;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, A573PropostaContratoAssinaturaTipo, A323PropostaId, AV9PropostaId, A574PropostaAssinaturaStatus, A571PropostaAssinatura) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
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
         PA792( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START792( ) ;
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
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
            GXEncryptionTmp = "wpcontratosassinatura"+UrlEncode(StringUtil.LTrimStr(AV9PropostaId,9,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpcontratosassinatura") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV9PropostaId), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_48", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_48), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PROPOSTACONTRATOASSINATURATIPO", A573PropostaContratoAssinaturaTipo);
         GxWebStd.gx_hidden_field( context, "PROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV9PropostaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "PROPOSTAASSINATURASTATUS", A574PropostaAssinaturaStatus);
         GxWebStd.gx_hidden_field( context, "PROPOSTAASSINATURA", StringUtil.LTrim( StringUtil.NToC( (decimal)(A571PropostaAssinatura), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "subGrid_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Recordcount), 5, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
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
            WE792( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT792( ) ;
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
         GXEncryptionTmp = "wpcontratosassinatura"+UrlEncode(StringUtil.LTrimStr(AV9PropostaId,9,0));
         return formatLink("wpcontratosassinatura") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WpContratosAssinatura" ;
      }

      public override string GetPgmdesc( )
      {
         return "Contratos x assinaturas" ;
      }

      protected void WB790( )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(48), 2, 0)+","+"null"+");", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpContratosAssinatura.htm");
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
            GxWebStd.gx_div_start( context, divHead_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavProcedimentosmedicosnome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProcedimentosmedicosnome_Internalname, "Procedimento", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'" + sGXsfl_48_idx + "',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavProcedimentosmedicosnome_Internalname, AV10ProcedimentosMedicosNome, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", 0, 1, edtavProcedimentosmedicosnome_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WpContratosAssinatura.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPropostadescricao_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostadescricao_Internalname, "Descrição", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'" + sGXsfl_48_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostadescricao_Internalname, AV11PropostaDescricao, StringUtil.RTrim( context.localUtil.Format( AV11PropostaDescricao, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostadescricao_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavPropostadescricao_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpContratosAssinatura.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPropostavalor_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostavalor_Internalname, "Valor", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'" + sGXsfl_48_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostavalor_Internalname, StringUtil.LTrim( StringUtil.NToC( AV12PropostaValor, 18, 2, ",", "")), StringUtil.LTrim( ((edtavPropostavalor_Enabled!=0) ? context.localUtil.Format( AV12PropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV12PropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostavalor_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavPropostavalor_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpContratosAssinatura.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPropostapacienteclienterazaosocial_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostapacienteclienterazaosocial_Internalname, "Paciente", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'" + sGXsfl_48_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostapacienteclienterazaosocial_Internalname, AV13PropostaPacienteClienteRazaoSocial, StringUtil.RTrim( context.localUtil.Format( AV13PropostaPacienteClienteRazaoSocial, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostapacienteclienterazaosocial_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavPropostapacienteclienterazaosocial_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpContratosAssinatura.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPropostapacienteclientedocumento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostapacienteclientedocumento_Internalname, "CPF", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'" + sGXsfl_48_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostapacienteclientedocumento_Internalname, AV14PropostaPacienteClienteDocumento, StringUtil.RTrim( context.localUtil.Format( AV14PropostaPacienteClienteDocumento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostapacienteclientedocumento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavPropostapacienteclientedocumento_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpContratosAssinatura.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPropostapacientecontatoemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostapacientecontatoemail_Internalname, "E-mail", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'" + sGXsfl_48_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostapacientecontatoemail_Internalname, AV15PropostaPacienteContatoEmail, StringUtil.RTrim( context.localUtil.Format( AV15PropostaPacienteContatoEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostapacientecontatoemail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavPropostapacientecontatoemail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WpContratosAssinatura.htm");
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
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 HasGridEmpowerer", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl48( ) ;
         }
         if ( wbEnd == 48 )
         {
            wbEnd = 0;
            nRC_GXsfl_48 = (int)(nGXsfl_48_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
               GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 48 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
                  GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START792( )
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
         Form.Meta.addItem("description", "Contratos x assinaturas", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP790( ) ;
      }

      protected void WS792( )
      {
         START792( ) ;
         EVT792( ) ;
      }

      protected void EVT792( )
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
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRIDPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 15), "VCONTRATO.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 15), "VCONTRATO.CLICK") == 0 ) )
                           {
                              nGXsfl_48_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx), 4, 0), 4, "0");
                              SubsflControlProps_482( ) ;
                              AV7Contrato = cgiGet( edtavContrato_Internalname);
                              AssignAttri("", false, edtavContrato_Internalname, AV7Contrato);
                              AV17Assinatura = cgiGet( edtavAssinatura_Internalname);
                              AssignAttri("", false, edtavAssinatura_Internalname, AV17Assinatura);
                              cmbavPropostacontratoassinaturatipo.Name = cmbavPropostacontratoassinaturatipo_Internalname;
                              cmbavPropostacontratoassinaturatipo.CurrentValue = cgiGet( cmbavPropostacontratoassinaturatipo_Internalname);
                              AV5PropostaContratoAssinaturaTipo = cgiGet( cmbavPropostacontratoassinaturatipo_Internalname);
                              AssignAttri("", false, cmbavPropostacontratoassinaturatipo_Internalname, AV5PropostaContratoAssinaturaTipo);
                              GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTACONTRATOASSINATURATIPO"+"_"+sGXsfl_48_idx, GetSecureSignedToken( sGXsfl_48_idx, StringUtil.RTrim( context.localUtil.Format( AV5PropostaContratoAssinaturaTipo, "")), context));
                              cmbavPropostaassinaturastatus.Name = cmbavPropostaassinaturastatus_Internalname;
                              cmbavPropostaassinaturastatus.CurrentValue = cgiGet( cmbavPropostaassinaturastatus_Internalname);
                              AV6PropostaAssinaturaStatus = cgiGet( cmbavPropostaassinaturastatus_Internalname);
                              AssignAttri("", false, cmbavPropostaassinaturastatus_Internalname, AV6PropostaAssinaturaStatus);
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavPropostaassinatura_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPropostaassinatura_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPROPOSTAASSINATURA");
                                 GX_FocusControl = edtavPropostaassinatura_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV16PropostaAssinatura = 0;
                                 AssignAttri("", false, edtavPropostaassinatura_Internalname, StringUtil.LTrimStr( (decimal)(AV16PropostaAssinatura), 10, 0));
                              }
                              else
                              {
                                 AV16PropostaAssinatura = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavPropostaassinatura_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                                 AssignAttri("", false, edtavPropostaassinatura_Internalname, StringUtil.LTrimStr( (decimal)(AV16PropostaAssinatura), 10, 0));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E11792 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E12792 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E13792 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VCONTRATO.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E14792 ();
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

      protected void WE792( )
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

      protected void PA792( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpcontratosassinatura")), "wpcontratosassinatura") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpcontratosassinatura")))) ;
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
                     AV9PropostaId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV9PropostaId", StringUtil.LTrimStr( (decimal)(AV9PropostaId), 9, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV9PropostaId), "ZZZZZZZZ9"), context));
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
               GX_FocusControl = edtavProcedimentosmedicosnome_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_482( ) ;
         while ( nGXsfl_48_idx <= nRC_GXsfl_48 )
         {
            sendrow_482( ) ;
            nGXsfl_48_idx = ((subGrid_Islastpage==1)&&(nGXsfl_48_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_48_idx+1);
            sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx), 4, 0), 4, "0");
            SubsflControlProps_482( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string A573PropostaContratoAssinaturaTipo ,
                                       int A323PropostaId ,
                                       int AV9PropostaId ,
                                       string A574PropostaAssinaturaStatus ,
                                       long A571PropostaAssinatura )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF792( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTACONTRATOASSINATURATIPO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV5PropostaContratoAssinaturaTipo, "")), context));
         GxWebStd.gx_hidden_field( context, "vPROPOSTACONTRATOASSINATURATIPO", AV5PropostaContratoAssinaturaTipo);
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
         RF792( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavProcedimentosmedicosnome_Enabled = 0;
         AssignProp("", false, edtavProcedimentosmedicosnome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavProcedimentosmedicosnome_Enabled), 5, 0), true);
         edtavPropostadescricao_Enabled = 0;
         AssignProp("", false, edtavPropostadescricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostadescricao_Enabled), 5, 0), true);
         edtavPropostavalor_Enabled = 0;
         AssignProp("", false, edtavPropostavalor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostavalor_Enabled), 5, 0), true);
         edtavPropostapacienteclienterazaosocial_Enabled = 0;
         AssignProp("", false, edtavPropostapacienteclienterazaosocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostapacienteclienterazaosocial_Enabled), 5, 0), true);
         edtavPropostapacienteclientedocumento_Enabled = 0;
         AssignProp("", false, edtavPropostapacienteclientedocumento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostapacienteclientedocumento_Enabled), 5, 0), true);
         edtavPropostapacientecontatoemail_Enabled = 0;
         AssignProp("", false, edtavPropostapacientecontatoemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostapacientecontatoemail_Enabled), 5, 0), true);
         edtavContrato_Enabled = 0;
         edtavAssinatura_Enabled = 0;
         cmbavPropostacontratoassinaturatipo.Enabled = 0;
         cmbavPropostaassinaturastatus.Enabled = 0;
         edtavPropostaassinatura_Enabled = 0;
      }

      protected void RF792( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 48;
         /* Execute user event: Refresh */
         E12792 ();
         nGXsfl_48_idx = 1;
         sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx), 4, 0), 4, "0");
         SubsflControlProps_482( ) ;
         bGXsfl_48_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithBorderColor WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         if ( subGrid_Islastpage != 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordcount( )-subGrid_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
            GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_482( ) ;
            /* Execute user event: Grid.Load */
            E13792 ();
            if ( ( subGrid_Islastpage == 0 ) && ( GRID_nCurrentRecord > 0 ) && ( GRID_nGridOutOfScope == 0 ) && ( nGXsfl_48_idx == 1 ) )
            {
               GRID_nCurrentRecord = 0;
               GRID_nGridOutOfScope = 1;
               subgrid_firstpage( ) ;
               /* Execute user event: Grid.Load */
               E13792 ();
            }
            wbEnd = 48;
            WB790( ) ;
         }
         bGXsfl_48_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes792( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTACONTRATOASSINATURATIPO"+"_"+sGXsfl_48_idx, GetSecureSignedToken( sGXsfl_48_idx, StringUtil.RTrim( context.localUtil.Format( AV5PropostaContratoAssinaturaTipo, "")), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         return (int)(((subGrid_Recordcount==0) ? GRID_nFirstRecordOnPage+1 : subGrid_Recordcount)) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(((subGrid_Islastpage==1) ? NumberUtil.Int( (long)(Math.Round(subGrid_fnc_Recordcount( )/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+((((int)((subGrid_fnc_Recordcount( )) % (subGrid_fnc_Recordsperpage( ))))==0) ? 0 : 1) : NumberUtil.Int( (long)(Math.Round(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1)) ;
      }

      protected short subgrid_firstpage( )
      {
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, A573PropostaContratoAssinaturaTipo, A323PropostaId, AV9PropostaId, A574PropostaAssinaturaStatus, A571PropostaAssinatura) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, A573PropostaContratoAssinaturaTipo, A323PropostaId, AV9PropostaId, A574PropostaAssinaturaStatus, A571PropostaAssinatura) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, A573PropostaContratoAssinaturaTipo, A323PropostaId, AV9PropostaId, A574PropostaAssinaturaStatus, A571PropostaAssinatura) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         subGrid_Islastpage = 1;
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, A573PropostaContratoAssinaturaTipo, A323PropostaId, AV9PropostaId, A574PropostaAssinaturaStatus, A571PropostaAssinatura) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, A573PropostaContratoAssinaturaTipo, A323PropostaId, AV9PropostaId, A574PropostaAssinaturaStatus, A571PropostaAssinatura) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtavProcedimentosmedicosnome_Enabled = 0;
         AssignProp("", false, edtavProcedimentosmedicosnome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavProcedimentosmedicosnome_Enabled), 5, 0), true);
         edtavPropostadescricao_Enabled = 0;
         AssignProp("", false, edtavPropostadescricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostadescricao_Enabled), 5, 0), true);
         edtavPropostavalor_Enabled = 0;
         AssignProp("", false, edtavPropostavalor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostavalor_Enabled), 5, 0), true);
         edtavPropostapacienteclienterazaosocial_Enabled = 0;
         AssignProp("", false, edtavPropostapacienteclienterazaosocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostapacienteclienterazaosocial_Enabled), 5, 0), true);
         edtavPropostapacienteclientedocumento_Enabled = 0;
         AssignProp("", false, edtavPropostapacienteclientedocumento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostapacienteclientedocumento_Enabled), 5, 0), true);
         edtavPropostapacientecontatoemail_Enabled = 0;
         AssignProp("", false, edtavPropostapacientecontatoemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostapacientecontatoemail_Enabled), 5, 0), true);
         edtavContrato_Enabled = 0;
         edtavAssinatura_Enabled = 0;
         cmbavPropostacontratoassinaturatipo.Enabled = 0;
         cmbavPropostaassinaturastatus.Enabled = 0;
         edtavPropostaassinatura_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP790( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11792 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_48 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_48"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            subGrid_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "subGrid_Recordcount"), ",", "."), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            /* Read variables values. */
            AV10ProcedimentosMedicosNome = cgiGet( edtavProcedimentosmedicosnome_Internalname);
            AssignAttri("", false, "AV10ProcedimentosMedicosNome", AV10ProcedimentosMedicosNome);
            AV11PropostaDescricao = cgiGet( edtavPropostadescricao_Internalname);
            AssignAttri("", false, "AV11PropostaDescricao", AV11PropostaDescricao);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPropostavalor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPropostavalor_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPROPOSTAVALOR");
               GX_FocusControl = edtavPropostavalor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12PropostaValor = 0;
               AssignAttri("", false, "AV12PropostaValor", StringUtil.LTrimStr( AV12PropostaValor, 18, 2));
            }
            else
            {
               AV12PropostaValor = context.localUtil.CToN( cgiGet( edtavPropostavalor_Internalname), ",", ".");
               AssignAttri("", false, "AV12PropostaValor", StringUtil.LTrimStr( AV12PropostaValor, 18, 2));
            }
            AV13PropostaPacienteClienteRazaoSocial = StringUtil.Upper( cgiGet( edtavPropostapacienteclienterazaosocial_Internalname));
            AssignAttri("", false, "AV13PropostaPacienteClienteRazaoSocial", AV13PropostaPacienteClienteRazaoSocial);
            AV14PropostaPacienteClienteDocumento = cgiGet( edtavPropostapacienteclientedocumento_Internalname);
            AssignAttri("", false, "AV14PropostaPacienteClienteDocumento", AV14PropostaPacienteClienteDocumento);
            AV15PropostaPacienteContatoEmail = cgiGet( edtavPropostapacientecontatoemail_Internalname);
            AssignAttri("", false, "AV15PropostaPacienteContatoEmail", AV15PropostaPacienteContatoEmail);
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
         E11792 ();
         if (returnInSub) return;
      }

      protected void E11792( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Using cursor H00792 */
         pr_default.execute(0, new Object[] {AV9PropostaId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A376ProcedimentosMedicosId = H00792_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = H00792_n376ProcedimentosMedicosId[0];
            A504PropostaPacienteClienteId = H00792_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = H00792_n504PropostaPacienteClienteId[0];
            A323PropostaId = H00792_A323PropostaId[0];
            n323PropostaId = H00792_n323PropostaId[0];
            A377ProcedimentosMedicosNome = H00792_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = H00792_n377ProcedimentosMedicosNome[0];
            A325PropostaDescricao = H00792_A325PropostaDescricao[0];
            n325PropostaDescricao = H00792_n325PropostaDescricao[0];
            A540PropostaPacienteClienteDocumento = H00792_A540PropostaPacienteClienteDocumento[0];
            n540PropostaPacienteClienteDocumento = H00792_n540PropostaPacienteClienteDocumento[0];
            A505PropostaPacienteClienteRazaoSocial = H00792_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = H00792_n505PropostaPacienteClienteRazaoSocial[0];
            A541PropostaPacienteContatoEmail = H00792_A541PropostaPacienteContatoEmail[0];
            n541PropostaPacienteContatoEmail = H00792_n541PropostaPacienteContatoEmail[0];
            A326PropostaValor = H00792_A326PropostaValor[0];
            n326PropostaValor = H00792_n326PropostaValor[0];
            A377ProcedimentosMedicosNome = H00792_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = H00792_n377ProcedimentosMedicosNome[0];
            A540PropostaPacienteClienteDocumento = H00792_A540PropostaPacienteClienteDocumento[0];
            n540PropostaPacienteClienteDocumento = H00792_n540PropostaPacienteClienteDocumento[0];
            A505PropostaPacienteClienteRazaoSocial = H00792_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = H00792_n505PropostaPacienteClienteRazaoSocial[0];
            A541PropostaPacienteContatoEmail = H00792_A541PropostaPacienteContatoEmail[0];
            n541PropostaPacienteContatoEmail = H00792_n541PropostaPacienteContatoEmail[0];
            AV10ProcedimentosMedicosNome = A377ProcedimentosMedicosNome;
            AssignAttri("", false, "AV10ProcedimentosMedicosNome", AV10ProcedimentosMedicosNome);
            AV11PropostaDescricao = A325PropostaDescricao;
            AssignAttri("", false, "AV11PropostaDescricao", AV11PropostaDescricao);
            AV14PropostaPacienteClienteDocumento = A540PropostaPacienteClienteDocumento;
            AssignAttri("", false, "AV14PropostaPacienteClienteDocumento", AV14PropostaPacienteClienteDocumento);
            AV13PropostaPacienteClienteRazaoSocial = A505PropostaPacienteClienteRazaoSocial;
            AssignAttri("", false, "AV13PropostaPacienteClienteRazaoSocial", AV13PropostaPacienteClienteRazaoSocial);
            AV15PropostaPacienteContatoEmail = A541PropostaPacienteContatoEmail;
            AssignAttri("", false, "AV15PropostaPacienteContatoEmail", AV15PropostaPacienteContatoEmail);
            AV12PropostaValor = A326PropostaValor;
            AssignAttri("", false, "AV12PropostaValor", StringUtil.LTrimStr( AV12PropostaValor, 18, 2));
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
      }

      protected void E12792( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         cmbavPropostaassinaturastatus_Columnheaderclass = "WWColumn";
         AssignProp("", false, cmbavPropostaassinaturastatus_Internalname, "Columnheaderclass", cmbavPropostaassinaturastatus_Columnheaderclass, !bGXsfl_48_Refreshing);
         /*  Sending Event outputs  */
      }

      private void E13792( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV20GXV2 = 1;
         AV19GXV1 = (GxSimpleCollection<string>)(gxdomaindmtipocontrato.getValues());
         while ( AV20GXV2 <= AV19GXV1.Count )
         {
            AV8DmTipoContrato = ((string)AV19GXV1.Item(AV20GXV2));
            AssignAttri("", false, "AV8DmTipoContrato", AV8DmTipoContrato);
            if ( StringUtil.StrCmp(AV8DmTipoContrato, "Documento") != 0 )
            {
               AV5PropostaContratoAssinaturaTipo = AV8DmTipoContrato;
               AssignAttri("", false, cmbavPropostacontratoassinaturatipo_Internalname, AV5PropostaContratoAssinaturaTipo);
               GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTACONTRATOASSINATURATIPO"+"_"+sGXsfl_48_idx, GetSecureSignedToken( sGXsfl_48_idx, StringUtil.RTrim( context.localUtil.Format( AV5PropostaContratoAssinaturaTipo, "")), context));
               AV6PropostaAssinaturaStatus = "AGUARDANDO_ENVIO";
               AssignAttri("", false, cmbavPropostaassinaturastatus_Internalname, AV6PropostaAssinaturaStatus);
               /* Using cursor H00793 */
               pr_default.execute(1, new Object[] {AV9PropostaId, AV8DmTipoContrato});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A323PropostaId = H00793_A323PropostaId[0];
                  n323PropostaId = H00793_n323PropostaId[0];
                  A573PropostaContratoAssinaturaTipo = H00793_A573PropostaContratoAssinaturaTipo[0];
                  n573PropostaContratoAssinaturaTipo = H00793_n573PropostaContratoAssinaturaTipo[0];
                  A574PropostaAssinaturaStatus = H00793_A574PropostaAssinaturaStatus[0];
                  n574PropostaAssinaturaStatus = H00793_n574PropostaAssinaturaStatus[0];
                  A571PropostaAssinatura = H00793_A571PropostaAssinatura[0];
                  n571PropostaAssinatura = H00793_n571PropostaAssinatura[0];
                  A574PropostaAssinaturaStatus = H00793_A574PropostaAssinaturaStatus[0];
                  n574PropostaAssinaturaStatus = H00793_n574PropostaAssinaturaStatus[0];
                  AV6PropostaAssinaturaStatus = A574PropostaAssinaturaStatus;
                  AssignAttri("", false, cmbavPropostaassinaturastatus_Internalname, AV6PropostaAssinaturaStatus);
                  AV16PropostaAssinatura = A571PropostaAssinatura;
                  AssignAttri("", false, edtavPropostaassinatura_Internalname, StringUtil.LTrimStr( (decimal)(AV16PropostaAssinatura), 10, 0));
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               AV7Contrato = "<i class=\"fas fa-file-contract\"></i>";
               AssignAttri("", false, edtavContrato_Internalname, AV7Contrato);
               if ( StringUtil.StrCmp(AV6PropostaAssinaturaStatus, "AGUARDANDO_ENVIO") == 0 )
               {
                  edtavContrato_Class = "Attribute";
               }
               else
               {
                  edtavContrato_Class = "Invisible";
               }
               AV17Assinatura = "<i class=\"fas fa-magnifying-glass\"></i>";
               AssignAttri("", false, edtavAssinatura_Internalname, AV17Assinatura);
               if ( StringUtil.StrCmp(AV6PropostaAssinaturaStatus, "AGUARDANDO_ENVIO") != 0 )
               {
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
                  {
                     gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
                  }
                  GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
                  GXEncryptionTmp = "wpassinaturas"+UrlEncode(StringUtil.LTrimStr(AV16PropostaAssinatura,10,0));
                  edtavAssinatura_Link = formatLink("wpassinaturas") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                  edtavAssinatura_Class = "Attribute";
               }
               else
               {
                  edtavAssinatura_Link = "";
                  edtavAssinatura_Class = "Invisible";
               }
               if ( StringUtil.StrCmp(AV6PropostaAssinaturaStatus, "ENVIADO") == 0 )
               {
                  cmbavPropostaassinaturastatus_Columnclass = "WWColumn WWColumnTag WWColumnTagInfo WWColumnTagInfoSingleCell";
               }
               else if ( StringUtil.StrCmp(AV6PropostaAssinaturaStatus, "REJEITADO") == 0 )
               {
                  cmbavPropostaassinaturastatus_Columnclass = "WWColumn WWColumnTag WWColumnTagDanger WWColumnTagDangerSingleCell";
               }
               else if ( StringUtil.StrCmp(AV6PropostaAssinaturaStatus, "CANCELADO") == 0 )
               {
                  cmbavPropostaassinaturastatus_Columnclass = "WWColumn WWColumnTag WWColumnTagDanger WWColumnTagDangerSingleCell";
               }
               else if ( StringUtil.StrCmp(AV6PropostaAssinaturaStatus, "ASSINADO") == 0 )
               {
                  cmbavPropostaassinaturastatus_Columnclass = "WWColumn WWColumnTag WWColumnTagSuccess WWColumnTagSuccessSingleCell";
               }
               else if ( StringUtil.StrCmp(AV6PropostaAssinaturaStatus, "AGUARDANDO_ENVIO") == 0 )
               {
                  cmbavPropostaassinaturastatus_Columnclass = "WWColumn WWColumnTag WWColumnTagInfoLight WWColumnTagInfoLightSingleCell";
               }
               else
               {
                  cmbavPropostaassinaturastatus_Columnclass = "WWColumn";
               }
               /* Load Method */
               if ( wbStart != -1 )
               {
                  wbStart = 48;
               }
               if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
               {
                  sendrow_482( ) ;
               }
               GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
               GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
               GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
               subGrid_Recordcount = (int)(GRID_nCurrentRecord);
               if ( isFullAjaxMode( ) && ! bGXsfl_48_Refreshing )
               {
                  DoAjaxLoad(48, GridRow);
               }
            }
            AV20GXV2 = (int)(AV20GXV2+1);
         }
         /*  Sending Event outputs  */
         cmbavPropostacontratoassinaturatipo.CurrentValue = StringUtil.RTrim( AV5PropostaContratoAssinaturaTipo);
         cmbavPropostaassinaturastatus.CurrentValue = StringUtil.RTrim( AV6PropostaAssinaturaStatus);
      }

      protected void E14792( )
      {
         /* Contrato_Click Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "assinarcontratoproposta"+UrlEncode(StringUtil.LTrimStr(AV9PropostaId,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV5PropostaContratoAssinaturaTipo));
         CallWebObject(formatLink("assinarcontratoproposta") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV9PropostaId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV9PropostaId", StringUtil.LTrimStr( (decimal)(AV9PropostaId), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV9PropostaId), "ZZZZZZZZ9"), context));
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
         PA792( ) ;
         WS792( ) ;
         WE792( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019263089", true, true);
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
            context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 133260), false, true);
            context.AddJavascriptSource("wpcontratosassinatura.js", "?202561019263090", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_482( )
      {
         edtavContrato_Internalname = "vCONTRATO_"+sGXsfl_48_idx;
         edtavAssinatura_Internalname = "vASSINATURA_"+sGXsfl_48_idx;
         cmbavPropostacontratoassinaturatipo_Internalname = "vPROPOSTACONTRATOASSINATURATIPO_"+sGXsfl_48_idx;
         cmbavPropostaassinaturastatus_Internalname = "vPROPOSTAASSINATURASTATUS_"+sGXsfl_48_idx;
         edtavPropostaassinatura_Internalname = "vPROPOSTAASSINATURA_"+sGXsfl_48_idx;
      }

      protected void SubsflControlProps_fel_482( )
      {
         edtavContrato_Internalname = "vCONTRATO_"+sGXsfl_48_fel_idx;
         edtavAssinatura_Internalname = "vASSINATURA_"+sGXsfl_48_fel_idx;
         cmbavPropostacontratoassinaturatipo_Internalname = "vPROPOSTACONTRATOASSINATURATIPO_"+sGXsfl_48_fel_idx;
         cmbavPropostaassinaturastatus_Internalname = "vPROPOSTAASSINATURASTATUS_"+sGXsfl_48_fel_idx;
         edtavPropostaassinatura_Internalname = "vPROPOSTAASSINATURA_"+sGXsfl_48_fel_idx;
      }

      protected void sendrow_482( )
      {
         sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx), 4, 0), 4, "0");
         SubsflControlProps_482( ) ;
         WB790( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_48_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0x0);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_48_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithBorderColor WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_48_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_48_idx + "',48)\"";
            ROClassString = edtavContrato_Class;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavContrato_Internalname,StringUtil.RTrim( AV7Contrato),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"","'"+""+"'"+",false,"+"'"+"EVCONTRATO.CLICK."+sGXsfl_48_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavContrato_Jsonclick,(short)5,(string)edtavContrato_Class,(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavContrato_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)48,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'" + sGXsfl_48_idx + "',48)\"";
            ROClassString = edtavAssinatura_Class;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavAssinatura_Internalname,StringUtil.RTrim( AV17Assinatura),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavAssinatura_Link,(string)"",(string)"Vizualizar assinatura",(string)"",(string)edtavAssinatura_Jsonclick,(short)0,(string)edtavAssinatura_Class,(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavAssinatura_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)48,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'" + sGXsfl_48_idx + "',48)\"";
            if ( ( cmbavPropostacontratoassinaturatipo.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vPROPOSTACONTRATOASSINATURATIPO_" + sGXsfl_48_idx;
               cmbavPropostacontratoassinaturatipo.Name = GXCCtl;
               cmbavPropostacontratoassinaturatipo.WebTags = "";
               cmbavPropostacontratoassinaturatipo.addItem("Contrato", "Contrato", 0);
               cmbavPropostacontratoassinaturatipo.addItem("Nota_promissoria", "Nota promissória", 0);
               cmbavPropostacontratoassinaturatipo.addItem("Nota_promissoria_clinica", "Nota promissória clinica", 0);
               cmbavPropostacontratoassinaturatipo.addItem("Nota_promissoria_clinica_taxa", "Nota promissória clinica taxa", 0);
               cmbavPropostacontratoassinaturatipo.addItem("Documento", "Documento", 0);
               if ( cmbavPropostacontratoassinaturatipo.ItemCount > 0 )
               {
                  AV5PropostaContratoAssinaturaTipo = cmbavPropostacontratoassinaturatipo.getValidValue(AV5PropostaContratoAssinaturaTipo);
                  AssignAttri("", false, cmbavPropostacontratoassinaturatipo_Internalname, AV5PropostaContratoAssinaturaTipo);
                  GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTACONTRATOASSINATURATIPO"+"_"+sGXsfl_48_idx, GetSecureSignedToken( sGXsfl_48_idx, StringUtil.RTrim( context.localUtil.Format( AV5PropostaContratoAssinaturaTipo, "")), context));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavPropostacontratoassinaturatipo,(string)cmbavPropostacontratoassinaturatipo_Internalname,StringUtil.RTrim( AV5PropostaContratoAssinaturaTipo),(short)1,(string)cmbavPropostacontratoassinaturatipo_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,cmbavPropostacontratoassinaturatipo.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"",(string)"",(bool)true,(short)0});
            cmbavPropostacontratoassinaturatipo.CurrentValue = StringUtil.RTrim( AV5PropostaContratoAssinaturaTipo);
            AssignProp("", false, cmbavPropostacontratoassinaturatipo_Internalname, "Values", (string)(cmbavPropostacontratoassinaturatipo.ToJavascriptSource()), !bGXsfl_48_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'" + sGXsfl_48_idx + "',48)\"";
            if ( ( cmbavPropostaassinaturastatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vPROPOSTAASSINATURASTATUS_" + sGXsfl_48_idx;
               cmbavPropostaassinaturastatus.Name = GXCCtl;
               cmbavPropostaassinaturastatus.WebTags = "";
               cmbavPropostaassinaturastatus.addItem("ENVIADO", "Enviado", 0);
               cmbavPropostaassinaturastatus.addItem("REJEITADO", "Rejeitado", 0);
               cmbavPropostaassinaturastatus.addItem("CANCELADO", "Cancelado", 0);
               cmbavPropostaassinaturastatus.addItem("ASSINADO", "Assinado", 0);
               cmbavPropostaassinaturastatus.addItem("AGUARDANDO_ENVIO", "Aguardando envio", 0);
               if ( cmbavPropostaassinaturastatus.ItemCount > 0 )
               {
                  AV6PropostaAssinaturaStatus = cmbavPropostaassinaturastatus.getValidValue(AV6PropostaAssinaturaStatus);
                  AssignAttri("", false, cmbavPropostaassinaturastatus_Internalname, AV6PropostaAssinaturaStatus);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavPropostaassinaturastatus,(string)cmbavPropostaassinaturastatus_Internalname,StringUtil.RTrim( AV6PropostaAssinaturaStatus),(short)1,(string)cmbavPropostaassinaturastatus_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,cmbavPropostaassinaturastatus.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)cmbavPropostaassinaturastatus_Columnclass,(string)cmbavPropostaassinaturastatus_Columnheaderclass,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"",(string)"",(bool)true,(short)0});
            cmbavPropostaassinaturastatus.CurrentValue = StringUtil.RTrim( AV6PropostaAssinaturaStatus);
            AssignProp("", false, cmbavPropostaassinaturastatus_Internalname, "Values", (string)(cmbavPropostaassinaturastatus.ToJavascriptSource()), !bGXsfl_48_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavPropostaassinatura_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16PropostaAssinatura), 10, 0, ",", "")),StringUtil.LTrim( ((edtavPropostaassinatura_Enabled!=0) ? context.localUtil.Format( (decimal)(AV16PropostaAssinatura), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV16PropostaAssinatura), "ZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavPropostaassinatura_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavPropostaassinatura_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)48,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes792( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_48_idx = ((subGrid_Islastpage==1)&&(nGXsfl_48_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_48_idx+1);
            sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx), 4, 0), 4, "0");
            SubsflControlProps_482( ) ;
         }
         /* End function sendrow_482 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vPROPOSTACONTRATOASSINATURATIPO_" + sGXsfl_48_idx;
         cmbavPropostacontratoassinaturatipo.Name = GXCCtl;
         cmbavPropostacontratoassinaturatipo.WebTags = "";
         cmbavPropostacontratoassinaturatipo.addItem("Contrato", "Contrato", 0);
         cmbavPropostacontratoassinaturatipo.addItem("Nota_promissoria", "Nota promissória", 0);
         cmbavPropostacontratoassinaturatipo.addItem("Nota_promissoria_clinica", "Nota promissória clinica", 0);
         cmbavPropostacontratoassinaturatipo.addItem("Nota_promissoria_clinica_taxa", "Nota promissória clinica taxa", 0);
         cmbavPropostacontratoassinaturatipo.addItem("Documento", "Documento", 0);
         if ( cmbavPropostacontratoassinaturatipo.ItemCount > 0 )
         {
            AV5PropostaContratoAssinaturaTipo = cmbavPropostacontratoassinaturatipo.getValidValue(AV5PropostaContratoAssinaturaTipo);
            AssignAttri("", false, cmbavPropostacontratoassinaturatipo_Internalname, AV5PropostaContratoAssinaturaTipo);
            GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTACONTRATOASSINATURATIPO"+"_"+sGXsfl_48_idx, GetSecureSignedToken( sGXsfl_48_idx, StringUtil.RTrim( context.localUtil.Format( AV5PropostaContratoAssinaturaTipo, "")), context));
         }
         GXCCtl = "vPROPOSTAASSINATURASTATUS_" + sGXsfl_48_idx;
         cmbavPropostaassinaturastatus.Name = GXCCtl;
         cmbavPropostaassinaturastatus.WebTags = "";
         cmbavPropostaassinaturastatus.addItem("ENVIADO", "Enviado", 0);
         cmbavPropostaassinaturastatus.addItem("REJEITADO", "Rejeitado", 0);
         cmbavPropostaassinaturastatus.addItem("CANCELADO", "Cancelado", 0);
         cmbavPropostaassinaturastatus.addItem("ASSINADO", "Assinado", 0);
         cmbavPropostaassinaturastatus.addItem("AGUARDANDO_ENVIO", "Aguardando envio", 0);
         if ( cmbavPropostaassinaturastatus.ItemCount > 0 )
         {
            AV6PropostaAssinaturaStatus = cmbavPropostaassinaturastatus.getValidValue(AV6PropostaAssinaturaStatus);
            AssignAttri("", false, cmbavPropostaassinaturastatus_Internalname, AV6PropostaAssinaturaStatus);
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl48( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"48\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "GridWithBorderColor WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid_Backcolorstyle == 0 )
            {
               subGrid_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid_Class) > 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Title";
               }
            }
            else
            {
               subGrid_Titlebackstyle = 1;
               if ( subGrid_Backcolorstyle == 1 )
               {
                  subGrid_Titlebackcolor = subGrid_Allbackcolor;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavContrato_Class+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavAssinatura_Class+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Tipo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Situação") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Proposta Assinatura") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "GridWithBorderColor WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV7Contrato)));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavContrato_Class));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavContrato_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV17Assinatura)));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavAssinatura_Class));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavAssinatura_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavAssinatura_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV5PropostaContratoAssinaturaTipo));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavPropostacontratoassinaturatipo.Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV6PropostaAssinaturaStatus));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbavPropostaassinaturastatus_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbavPropostaassinaturastatus_Columnheaderclass));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavPropostaassinaturastatus.Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16PropostaAssinatura), 10, 0, ".", ""))));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavPropostaassinatura_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         edtavProcedimentosmedicosnome_Internalname = "vPROCEDIMENTOSMEDICOSNOME";
         edtavPropostadescricao_Internalname = "vPROPOSTADESCRICAO";
         edtavPropostavalor_Internalname = "vPROPOSTAVALOR";
         edtavPropostapacienteclienterazaosocial_Internalname = "vPROPOSTAPACIENTECLIENTERAZAOSOCIAL";
         edtavPropostapacienteclientedocumento_Internalname = "vPROPOSTAPACIENTECLIENTEDOCUMENTO";
         edtavPropostapacientecontatoemail_Internalname = "vPROPOSTAPACIENTECONTATOEMAIL";
         divHead_Internalname = "HEAD";
         edtavContrato_Internalname = "vCONTRATO";
         edtavAssinatura_Internalname = "vASSINATURA";
         cmbavPropostacontratoassinaturatipo_Internalname = "vPROPOSTACONTRATOASSINATURATIPO";
         cmbavPropostaassinaturastatus_Internalname = "vPROPOSTAASSINATURASTATUS";
         edtavPropostaassinatura_Internalname = "vPROPOSTAASSINATURA";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         edtavPropostaassinatura_Jsonclick = "";
         edtavPropostaassinatura_Enabled = 1;
         cmbavPropostaassinaturastatus_Jsonclick = "";
         cmbavPropostaassinaturastatus.Enabled = 1;
         cmbavPropostaassinaturastatus_Columnclass = "WWColumn";
         cmbavPropostacontratoassinaturatipo_Jsonclick = "";
         cmbavPropostacontratoassinaturatipo.Enabled = 1;
         edtavAssinatura_Jsonclick = "";
         edtavAssinatura_Class = "Attribute";
         edtavAssinatura_Link = "";
         edtavAssinatura_Enabled = 1;
         edtavContrato_Jsonclick = "";
         edtavContrato_Class = "Attribute";
         edtavContrato_Enabled = 1;
         subGrid_Class = "GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         cmbavPropostaassinaturastatus_Columnheaderclass = "";
         edtavPropostapacientecontatoemail_Jsonclick = "";
         edtavPropostapacientecontatoemail_Enabled = 1;
         edtavPropostapacienteclientedocumento_Jsonclick = "";
         edtavPropostapacienteclientedocumento_Enabled = 1;
         edtavPropostapacienteclienterazaosocial_Jsonclick = "";
         edtavPropostapacienteclienterazaosocial_Enabled = 1;
         edtavPropostavalor_Jsonclick = "";
         edtavPropostavalor_Enabled = 1;
         edtavPropostadescricao_Jsonclick = "";
         edtavPropostadescricao_Enabled = 1;
         edtavProcedimentosmedicosnome_Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Contratos x assinaturas";
         subGrid_Rows = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"A573PropostaContratoAssinaturaTipo","fld":"PROPOSTACONTRATOASSINATURATIPO","type":"svchar"},{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A574PropostaAssinaturaStatus","fld":"PROPOSTAASSINATURASTATUS","type":"svchar"},{"av":"A571PropostaAssinatura","fld":"PROPOSTAASSINATURA","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV9PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"cmbavPropostaassinaturastatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E13792","iparms":[{"av":"A573PropostaContratoAssinaturaTipo","fld":"PROPOSTACONTRATOASSINATURATIPO","type":"svchar"},{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV9PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A574PropostaAssinaturaStatus","fld":"PROPOSTAASSINATURASTATUS","type":"svchar"},{"av":"A571PropostaAssinatura","fld":"PROPOSTAASSINATURA","pic":"ZZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV8DmTipoContrato","fld":"vDMTIPOCONTRATO","type":"svchar"},{"av":"cmbavPropostacontratoassinaturatipo"},{"av":"AV5PropostaContratoAssinaturaTipo","fld":"vPROPOSTACONTRATOASSINATURATIPO","hsh":true,"type":"svchar"},{"av":"cmbavPropostaassinaturastatus"},{"av":"AV6PropostaAssinaturaStatus","fld":"vPROPOSTAASSINATURASTATUS","type":"svchar"},{"av":"AV16PropostaAssinatura","fld":"vPROPOSTAASSINATURA","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV7Contrato","fld":"vCONTRATO","type":"char"},{"av":"edtavContrato_Class","ctrl":"vCONTRATO","prop":"Class"},{"av":"AV17Assinatura","fld":"vASSINATURA","type":"char"},{"av":"edtavAssinatura_Link","ctrl":"vASSINATURA","prop":"Link"},{"av":"edtavAssinatura_Class","ctrl":"vASSINATURA","prop":"Class"}]}""");
         setEventMetadata("VCONTRATO.CLICK","""{"handler":"E14792","iparms":[{"av":"AV9PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"cmbavPropostacontratoassinaturatipo"},{"av":"AV5PropostaContratoAssinaturaTipo","fld":"vPROPOSTACONTRATOASSINATURATIPO","hsh":true,"type":"svchar"}]}""");
         setEventMetadata("GRID_FIRSTPAGE","""{"handler":"subgrid_firstpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"A573PropostaContratoAssinaturaTipo","fld":"PROPOSTACONTRATOASSINATURATIPO","type":"svchar"},{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV9PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A574PropostaAssinaturaStatus","fld":"PROPOSTAASSINATURASTATUS","type":"svchar"},{"av":"A571PropostaAssinatura","fld":"PROPOSTAASSINATURA","pic":"ZZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("GRID_FIRSTPAGE",""","oparms":[{"av":"cmbavPropostaassinaturastatus"}]}""");
         setEventMetadata("GRID_PREVPAGE","""{"handler":"subgrid_previouspage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"A573PropostaContratoAssinaturaTipo","fld":"PROPOSTACONTRATOASSINATURATIPO","type":"svchar"},{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV9PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A574PropostaAssinaturaStatus","fld":"PROPOSTAASSINATURASTATUS","type":"svchar"},{"av":"A571PropostaAssinatura","fld":"PROPOSTAASSINATURA","pic":"ZZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("GRID_PREVPAGE",""","oparms":[{"av":"cmbavPropostaassinaturastatus"}]}""");
         setEventMetadata("GRID_NEXTPAGE","""{"handler":"subgrid_nextpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"A573PropostaContratoAssinaturaTipo","fld":"PROPOSTACONTRATOASSINATURATIPO","type":"svchar"},{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV9PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A574PropostaAssinaturaStatus","fld":"PROPOSTAASSINATURASTATUS","type":"svchar"},{"av":"A571PropostaAssinatura","fld":"PROPOSTAASSINATURA","pic":"ZZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("GRID_NEXTPAGE",""","oparms":[{"av":"cmbavPropostaassinaturastatus"}]}""");
         setEventMetadata("GRID_LASTPAGE","""{"handler":"subgrid_lastpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"A573PropostaContratoAssinaturaTipo","fld":"PROPOSTACONTRATOASSINATURATIPO","type":"svchar"},{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV9PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A574PropostaAssinaturaStatus","fld":"PROPOSTAASSINATURASTATUS","type":"svchar"},{"av":"A571PropostaAssinatura","fld":"PROPOSTAASSINATURA","pic":"ZZZZZZZZZ9","type":"int"},{"av":"subGrid_Recordcount","type":"int"}]""");
         setEventMetadata("GRID_LASTPAGE",""","oparms":[{"av":"cmbavPropostaassinaturastatus"}]}""");
         setEventMetadata("VALIDV_PROPOSTAPACIENTECONTATOEMAIL","""{"handler":"Validv_Propostapacientecontatoemail","iparms":[]}""");
         setEventMetadata("VALIDV_PROPOSTACONTRATOASSINATURATIPO","""{"handler":"Validv_Propostacontratoassinaturatipo","iparms":[]}""");
         setEventMetadata("VALIDV_PROPOSTAASSINATURASTATUS","""{"handler":"Validv_Propostaassinaturastatus","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Propostaassinatura","iparms":[]}""");
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
         A573PropostaContratoAssinaturaTipo = "";
         A574PropostaAssinaturaStatus = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtn_cancel_Jsonclick = "";
         AV10ProcedimentosMedicosNome = "";
         AV11PropostaDescricao = "";
         AV13PropostaPacienteClienteRazaoSocial = "";
         AV14PropostaPacienteClienteDocumento = "";
         AV15PropostaPacienteContatoEmail = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGrid_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV7Contrato = "";
         AV17Assinatura = "";
         AV5PropostaContratoAssinaturaTipo = "";
         AV6PropostaAssinaturaStatus = "";
         GXDecQS = "";
         H00792_A376ProcedimentosMedicosId = new int[1] ;
         H00792_n376ProcedimentosMedicosId = new bool[] {false} ;
         H00792_A504PropostaPacienteClienteId = new int[1] ;
         H00792_n504PropostaPacienteClienteId = new bool[] {false} ;
         H00792_A323PropostaId = new int[1] ;
         H00792_n323PropostaId = new bool[] {false} ;
         H00792_A377ProcedimentosMedicosNome = new string[] {""} ;
         H00792_n377ProcedimentosMedicosNome = new bool[] {false} ;
         H00792_A325PropostaDescricao = new string[] {""} ;
         H00792_n325PropostaDescricao = new bool[] {false} ;
         H00792_A540PropostaPacienteClienteDocumento = new string[] {""} ;
         H00792_n540PropostaPacienteClienteDocumento = new bool[] {false} ;
         H00792_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         H00792_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         H00792_A541PropostaPacienteContatoEmail = new string[] {""} ;
         H00792_n541PropostaPacienteContatoEmail = new bool[] {false} ;
         H00792_A326PropostaValor = new decimal[1] ;
         H00792_n326PropostaValor = new bool[] {false} ;
         A377ProcedimentosMedicosNome = "";
         A325PropostaDescricao = "";
         A540PropostaPacienteClienteDocumento = "";
         A505PropostaPacienteClienteRazaoSocial = "";
         A541PropostaPacienteContatoEmail = "";
         AV19GXV1 = new GxSimpleCollection<string>();
         AV8DmTipoContrato = "";
         H00793_A572PropostaContratoAssinaturaId = new int[1] ;
         H00793_A323PropostaId = new int[1] ;
         H00793_n323PropostaId = new bool[] {false} ;
         H00793_A573PropostaContratoAssinaturaTipo = new string[] {""} ;
         H00793_n573PropostaContratoAssinaturaTipo = new bool[] {false} ;
         H00793_A574PropostaAssinaturaStatus = new string[] {""} ;
         H00793_n574PropostaAssinaturaStatus = new bool[] {false} ;
         H00793_A571PropostaAssinatura = new long[1] ;
         H00793_n571PropostaAssinatura = new bool[] {false} ;
         GridRow = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpcontratosassinatura__default(),
            new Object[][] {
                new Object[] {
               H00792_A376ProcedimentosMedicosId, H00792_n376ProcedimentosMedicosId, H00792_A504PropostaPacienteClienteId, H00792_n504PropostaPacienteClienteId, H00792_A323PropostaId, H00792_A377ProcedimentosMedicosNome, H00792_n377ProcedimentosMedicosNome, H00792_A325PropostaDescricao, H00792_n325PropostaDescricao, H00792_A540PropostaPacienteClienteDocumento,
               H00792_n540PropostaPacienteClienteDocumento, H00792_A505PropostaPacienteClienteRazaoSocial, H00792_n505PropostaPacienteClienteRazaoSocial, H00792_A541PropostaPacienteContatoEmail, H00792_n541PropostaPacienteContatoEmail, H00792_A326PropostaValor, H00792_n326PropostaValor
               }
               , new Object[] {
               H00793_A572PropostaContratoAssinaturaId, H00793_A323PropostaId, H00793_n323PropostaId, H00793_A573PropostaContratoAssinaturaTipo, H00793_n573PropostaContratoAssinaturaTipo, H00793_A574PropostaAssinaturaStatus, H00793_n574PropostaAssinaturaStatus, H00793_A571PropostaAssinatura, H00793_n571PropostaAssinatura
               }
            }
         );
         /* GeneXus formulas. */
         edtavProcedimentosmedicosnome_Enabled = 0;
         edtavPropostadescricao_Enabled = 0;
         edtavPropostavalor_Enabled = 0;
         edtavPropostapacienteclienterazaosocial_Enabled = 0;
         edtavPropostapacienteclientedocumento_Enabled = 0;
         edtavPropostapacientecontatoemail_Enabled = 0;
         edtavContrato_Enabled = 0;
         edtavAssinatura_Enabled = 0;
         cmbavPropostacontratoassinaturatipo.Enabled = 0;
         cmbavPropostaassinaturastatus.Enabled = 0;
         edtavPropostaassinatura_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short gxcookieaux ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int AV9PropostaId ;
      private int wcpOAV9PropostaId ;
      private int nRC_GXsfl_48 ;
      private int subGrid_Recordcount ;
      private int subGrid_Rows ;
      private int nGXsfl_48_idx=1 ;
      private int A323PropostaId ;
      private int edtavProcedimentosmedicosnome_Enabled ;
      private int edtavPropostadescricao_Enabled ;
      private int edtavPropostavalor_Enabled ;
      private int edtavPropostapacienteclienterazaosocial_Enabled ;
      private int edtavPropostapacienteclientedocumento_Enabled ;
      private int edtavPropostapacientecontatoemail_Enabled ;
      private int subGrid_Islastpage ;
      private int edtavContrato_Enabled ;
      private int edtavAssinatura_Enabled ;
      private int edtavPropostaassinatura_Enabled ;
      private int GRID_nGridOutOfScope ;
      private int A376ProcedimentosMedicosId ;
      private int A504PropostaPacienteClienteId ;
      private int AV20GXV2 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long A571PropostaAssinatura ;
      private long AV16PropostaAssinatura ;
      private long GRID_nCurrentRecord ;
      private decimal AV12PropostaValor ;
      private decimal A326PropostaValor ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_48_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string divHead_Internalname ;
      private string edtavProcedimentosmedicosnome_Internalname ;
      private string edtavPropostadescricao_Internalname ;
      private string edtavPropostadescricao_Jsonclick ;
      private string edtavPropostavalor_Internalname ;
      private string edtavPropostavalor_Jsonclick ;
      private string edtavPropostapacienteclienterazaosocial_Internalname ;
      private string edtavPropostapacienteclienterazaosocial_Jsonclick ;
      private string edtavPropostapacienteclientedocumento_Internalname ;
      private string edtavPropostapacienteclientedocumento_Jsonclick ;
      private string edtavPropostapacientecontatoemail_Internalname ;
      private string edtavPropostapacientecontatoemail_Jsonclick ;
      private string divTablecontent_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV7Contrato ;
      private string edtavContrato_Internalname ;
      private string AV17Assinatura ;
      private string edtavAssinatura_Internalname ;
      private string cmbavPropostacontratoassinaturatipo_Internalname ;
      private string cmbavPropostaassinaturastatus_Internalname ;
      private string edtavPropostaassinatura_Internalname ;
      private string GXDecQS ;
      private string cmbavPropostaassinaturastatus_Columnheaderclass ;
      private string edtavContrato_Class ;
      private string edtavAssinatura_Link ;
      private string edtavAssinatura_Class ;
      private string cmbavPropostaassinaturastatus_Columnclass ;
      private string sGXsfl_48_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavContrato_Jsonclick ;
      private string edtavAssinatura_Jsonclick ;
      private string GXCCtl ;
      private string cmbavPropostacontratoassinaturatipo_Jsonclick ;
      private string cmbavPropostaassinaturastatus_Jsonclick ;
      private string edtavPropostaassinatura_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n573PropostaContratoAssinaturaTipo ;
      private bool n323PropostaId ;
      private bool n574PropostaAssinaturaStatus ;
      private bool n571PropostaAssinatura ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_48_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n376ProcedimentosMedicosId ;
      private bool n504PropostaPacienteClienteId ;
      private bool n377ProcedimentosMedicosNome ;
      private bool n325PropostaDescricao ;
      private bool n540PropostaPacienteClienteDocumento ;
      private bool n505PropostaPacienteClienteRazaoSocial ;
      private bool n541PropostaPacienteContatoEmail ;
      private bool n326PropostaValor ;
      private bool gx_refresh_fired ;
      private string A573PropostaContratoAssinaturaTipo ;
      private string A574PropostaAssinaturaStatus ;
      private string AV10ProcedimentosMedicosNome ;
      private string AV11PropostaDescricao ;
      private string AV13PropostaPacienteClienteRazaoSocial ;
      private string AV14PropostaPacienteClienteDocumento ;
      private string AV15PropostaPacienteContatoEmail ;
      private string AV5PropostaContratoAssinaturaTipo ;
      private string AV6PropostaAssinaturaStatus ;
      private string A377ProcedimentosMedicosNome ;
      private string A325PropostaDescricao ;
      private string A540PropostaPacienteClienteDocumento ;
      private string A505PropostaPacienteClienteRazaoSocial ;
      private string A541PropostaPacienteContatoEmail ;
      private string AV8DmTipoContrato ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGrid_empowerer ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavPropostacontratoassinaturatipo ;
      private GXCombobox cmbavPropostaassinaturastatus ;
      private IDataStoreProvider pr_default ;
      private int[] H00792_A376ProcedimentosMedicosId ;
      private bool[] H00792_n376ProcedimentosMedicosId ;
      private int[] H00792_A504PropostaPacienteClienteId ;
      private bool[] H00792_n504PropostaPacienteClienteId ;
      private int[] H00792_A323PropostaId ;
      private bool[] H00792_n323PropostaId ;
      private string[] H00792_A377ProcedimentosMedicosNome ;
      private bool[] H00792_n377ProcedimentosMedicosNome ;
      private string[] H00792_A325PropostaDescricao ;
      private bool[] H00792_n325PropostaDescricao ;
      private string[] H00792_A540PropostaPacienteClienteDocumento ;
      private bool[] H00792_n540PropostaPacienteClienteDocumento ;
      private string[] H00792_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] H00792_n505PropostaPacienteClienteRazaoSocial ;
      private string[] H00792_A541PropostaPacienteContatoEmail ;
      private bool[] H00792_n541PropostaPacienteContatoEmail ;
      private decimal[] H00792_A326PropostaValor ;
      private bool[] H00792_n326PropostaValor ;
      private GxSimpleCollection<string> AV19GXV1 ;
      private int[] H00793_A572PropostaContratoAssinaturaId ;
      private int[] H00793_A323PropostaId ;
      private bool[] H00793_n323PropostaId ;
      private string[] H00793_A573PropostaContratoAssinaturaTipo ;
      private bool[] H00793_n573PropostaContratoAssinaturaTipo ;
      private string[] H00793_A574PropostaAssinaturaStatus ;
      private bool[] H00793_n574PropostaAssinaturaStatus ;
      private long[] H00793_A571PropostaAssinatura ;
      private bool[] H00793_n571PropostaAssinatura ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpcontratosassinatura__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00792;
          prmH00792 = new Object[] {
          new ParDef("AV9PropostaId",GXType.Int32,9,0)
          };
          Object[] prmH00793;
          prmH00793 = new Object[] {
          new ParDef("AV9PropostaId",GXType.Int32,9,0) ,
          new ParDef("AV8DmTipoContrato",GXType.VarChar,60,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00792", "SELECT T1.ProcedimentosMedicosId, T1.PropostaPacienteClienteId AS PropostaPacienteClienteId, T1.PropostaId, T2.ProcedimentosMedicosNome, T1.PropostaDescricao, T3.ClienteDocumento AS PropostaPacienteClienteDocumento, T3.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, T3.ContatoEmail AS PropostaPacienteContatoEmail, T1.PropostaValor FROM ((Proposta T1 LEFT JOIN ProcedimentosMedicos T2 ON T2.ProcedimentosMedicosId = T1.ProcedimentosMedicosId) LEFT JOIN Cliente T3 ON T3.ClienteId = T1.PropostaPacienteClienteId) WHERE T1.PropostaId = :AV9PropostaId ORDER BY T1.PropostaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00792,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H00793", "SELECT T1.PropostaContratoAssinaturaId, T1.PropostaId, T1.PropostaContratoAssinaturaTipo, T2.AssinaturaStatus AS PropostaAssinaturaStatus, T1.PropostaAssinatura AS PropostaAssinatura FROM (PropostaContratoAssinatura T1 LEFT JOIN Assinatura T2 ON T2.AssinaturaId = T1.PropostaAssinatura) WHERE (T1.PropostaId = :AV9PropostaId) AND (T1.PropostaContratoAssinaturaTipo = ( :AV8DmTipoContrato)) ORDER BY T1.PropostaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00793,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
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
                ((decimal[]) buf[15])[0] = rslt.getDecimal(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((long[]) buf[7])[0] = rslt.getLong(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
       }
    }

 }

}
