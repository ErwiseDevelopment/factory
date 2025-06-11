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
   public class wpconsultadetalhada : GXDataArea
   {
      public wpconsultadetalhada( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpconsultadetalhada( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_SerasaId )
      {
         this.AV32SerasaId = aP0_SerasaId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavSerasarecomendacaovenda = new GXCombobox();
         cmbavSerasacodnivelrisco = new GXCombobox();
         cmbavSerasapolitica = new GXCombobox();
         cmbavSerasabaixocomprometimento = new GXCombobox();
         cmbavSerasacpfregular = new GXCombobox();
         cmbavSerasaretricaoativa = new GXCombobox();
         cmbavSerasarecomendacompleto = new GXCombobox();
         cmbavSerasaparticipacaosocietaria = new GXCombobox();
         cmbavSerasaprotestoativo = new GXCombobox();
         cmbavSerasarendaestimada = new GXCombobox();
         cmbavSerasaanotacoescompletas = new GXCombobox();
         cmbavSerasaanotacoesconsultaspc = new GXCombobox();
         cmbavSerasaconsultasdetalhadas = new GXCombobox();
         cmbavSerasahistoricopagamentopf = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "SerasaId");
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
               gxfirstwebparm = GetFirstPar( "SerasaId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "SerasaId");
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
         PA842( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START842( ) ;
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
         GXEncryptionTmp = "wpconsultadetalhada"+UrlEncode(StringUtil.LTrimStr(AV32SerasaId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpconsultadetalhada") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vSERASAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32SerasaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSERASAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV32SerasaId), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"WpConsultaDetalhada");
         forbiddenHiddens.Add("SerasaRecomendacaoVenda", StringUtil.RTrim( context.localUtil.Format( AV6SerasaRecomendacaoVenda, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("wpconsultadetalhada:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vSERASAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32SerasaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSERASAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV32SerasaId), "ZZZZZZZZ9"), context));
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
         if ( ! ( WebComp_Wcserasaenderecosww == null ) )
         {
            WebComp_Wcserasaenderecosww.componentjscripts();
         }
         if ( ! ( WebComp_Wcserasachequesww == null ) )
         {
            WebComp_Wcserasachequesww.componentjscripts();
         }
         if ( ! ( WebComp_Wcserasaacoesww == null ) )
         {
            WebComp_Wcserasaacoesww.componentjscripts();
         }
         if ( ! ( WebComp_Wcserasaocorrenciasww == null ) )
         {
            WebComp_Wcserasaocorrenciasww.componentjscripts();
         }
         if ( ! ( WebComp_Wcserasaprotestosww == null ) )
         {
            WebComp_Wcserasaprotestosww.componentjscripts();
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
            WE842( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT842( ) ;
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
         GXEncryptionTmp = "wpconsultadetalhada"+UrlEncode(StringUtil.LTrimStr(AV32SerasaId,9,0));
         return formatLink("wpconsultadetalhada") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WpConsultaDetalhada" ;
      }

      public override string GetPgmdesc( )
      {
         return "Consulta detalhada" ;
      }

      protected void WB840( )
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
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpConsultaDetalhada.htm");
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
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavClienterazaosocial_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClienterazaosocial_Internalname, "Nome", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClienterazaosocial_Internalname, AV39ClienteRazaoSocial, StringUtil.RTrim( context.localUtil.Format( AV39ClienteRazaoSocial, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,23);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClienterazaosocial_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavClienterazaosocial_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpConsultaDetalhada.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSerasanumeroproposta_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSerasanumeroproposta_Internalname, "Número da proposta", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSerasanumeroproposta_Internalname, AV5SerasaNumeroProposta, StringUtil.RTrim( context.localUtil.Format( AV5SerasaNumeroProposta, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSerasanumeroproposta_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSerasanumeroproposta_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpConsultaDetalhada.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedserasarecomendacaovenda_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockserasarecomendacaovenda_Internalname, "Recomendação de venda", "", "", lblTextblockserasarecomendacaovenda_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpConsultaDetalhada.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            wb_table1_35_842( true) ;
         }
         else
         {
            wb_table1_35_842( false) ;
         }
         return  ;
      }

      protected void wb_table1_35_842e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavSerasacodnivelrisco_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavSerasacodnivelrisco_Internalname, "Nível de risco", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavSerasacodnivelrisco, cmbavSerasacodnivelrisco_Internalname, StringUtil.Trim( StringUtil.Str( AV33SerasaCodNivelRisco, 15, 2)), 1, cmbavSerasacodnivelrisco_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "decimal", "", 1, cmbavSerasacodnivelrisco.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "", true, 0, "HLP_WpConsultaDetalhada.htm");
            cmbavSerasacodnivelrisco.CurrentValue = StringUtil.Trim( StringUtil.Str( AV33SerasaCodNivelRisco, 15, 2));
            AssignProp("", false, cmbavSerasacodnivelrisco_Internalname, "Values", (string)(cmbavSerasacodnivelrisco.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSerasascore_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSerasascore_Internalname, "Score", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSerasascore_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20SerasaScore), 4, 0, ",", "")), StringUtil.LTrim( ((edtavSerasascore_Enabled!=0) ? context.localUtil.Format( (decimal)(AV20SerasaScore), "ZZZ9") : context.localUtil.Format( (decimal)(AV20SerasaScore), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSerasascore_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSerasascore_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpConsultaDetalhada.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSerasamensagemscore_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSerasamensagemscore_Internalname, "Mensagem score", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavSerasamensagemscore_Internalname, AV21SerasaMensagemScore, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"", 0, 1, edtavSerasamensagemscore_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "250", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WpConsultaDetalhada.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSerasatipovenda_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSerasatipovenda_Internalname, "Tipo de venda", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSerasatipovenda_Internalname, AV8SerasaTipoVenda, StringUtil.RTrim( context.localUtil.Format( AV8SerasaTipoVenda, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSerasatipovenda_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSerasatipovenda_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpConsultaDetalhada.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavSerasapolitica_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavSerasapolitica_Internalname, "Política", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavSerasapolitica, cmbavSerasapolitica_Internalname, StringUtil.Trim( StringUtil.Str( AV9SerasaPolitica, 15, 2)), 1, cmbavSerasapolitica_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "decimal", "", 1, cmbavSerasapolitica.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "", true, 0, "HLP_WpConsultaDetalhada.htm");
            cmbavSerasapolitica.CurrentValue = StringUtil.Trim( StringUtil.Str( AV9SerasaPolitica, 15, 2));
            AssignProp("", false, cmbavSerasapolitica_Internalname, "Values", (string)(cmbavSerasapolitica.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavSerasabaixocomprometimento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavSerasabaixocomprometimento_Internalname, "Baixo comprometimento", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavSerasabaixocomprometimento, cmbavSerasabaixocomprometimento_Internalname, StringUtil.BoolToStr( AV12SerasaBaixoComprometimento), 1, cmbavSerasabaixocomprometimento_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbavSerasabaixocomprometimento.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "", true, 0, "HLP_WpConsultaDetalhada.htm");
            cmbavSerasabaixocomprometimento.CurrentValue = StringUtil.BoolToStr( AV12SerasaBaixoComprometimento);
            AssignProp("", false, cmbavSerasabaixocomprometimento_Internalname, "Values", (string)(cmbavSerasabaixocomprometimento.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavSerasacpfregular_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavSerasacpfregular_Internalname, "CPF Regular", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavSerasacpfregular, cmbavSerasacpfregular_Internalname, StringUtil.BoolToStr( AV14SerasaCpfRegular), 1, cmbavSerasacpfregular_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbavSerasacpfregular.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "", true, 0, "HLP_WpConsultaDetalhada.htm");
            cmbavSerasacpfregular.CurrentValue = StringUtil.BoolToStr( AV14SerasaCpfRegular);
            AssignProp("", false, cmbavSerasacpfregular_Internalname, "Values", (string)(cmbavSerasacpfregular.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavSerasaretricaoativa_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavSerasaretricaoativa_Internalname, "Restrição ativa", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavSerasaretricaoativa, cmbavSerasaretricaoativa_Internalname, StringUtil.BoolToStr( AV15SerasaRetricaoAtiva), 1, cmbavSerasaretricaoativa_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbavSerasaretricaoativa.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"", "", true, 0, "HLP_WpConsultaDetalhada.htm");
            cmbavSerasaretricaoativa.CurrentValue = StringUtil.BoolToStr( AV15SerasaRetricaoAtiva);
            AssignProp("", false, cmbavSerasaretricaoativa_Internalname, "Values", (string)(cmbavSerasaretricaoativa.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSerasadatanascimento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSerasadatanascimento_Internalname, "Data de nascimento", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavSerasadatanascimento_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavSerasadatanascimento_Internalname, context.localUtil.Format(AV17SerasaDataNascimento, "99/99/99"), context.localUtil.Format( AV17SerasaDataNascimento, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,82);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSerasadatanascimento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSerasadatanascimento_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpConsultaDetalhada.htm");
            GxWebStd.gx_bitmap( context, edtavSerasadatanascimento_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavSerasadatanascimento_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WpConsultaDetalhada.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSerasamensagemrendaestimada_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSerasamensagemrendaestimada_Internalname, "Mensagem da renda estimada", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavSerasamensagemrendaestimada_Internalname, AV19SerasaMensagemRendaEstimada, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"", 0, 1, edtavSerasamensagemrendaestimada_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "250", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WpConsultaDetalhada.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSerasasituacaocpf_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSerasasituacaocpf_Internalname, "Situação do CPF", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSerasasituacaocpf_Internalname, AV22SerasaSituacaoCPF, StringUtil.RTrim( context.localUtil.Format( AV22SerasaSituacaoCPF, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSerasasituacaocpf_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSerasasituacaocpf_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpConsultaDetalhada.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavSerasarecomendacompleto_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavSerasarecomendacompleto_Internalname, "Recomenda completo", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavSerasarecomendacompleto, cmbavSerasarecomendacompleto_Internalname, StringUtil.BoolToStr( AV23SerasaRecomendaCompleto), 1, cmbavSerasarecomendacompleto_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbavSerasarecomendacompleto.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "", true, 0, "HLP_WpConsultaDetalhada.htm");
            cmbavSerasarecomendacompleto.CurrentValue = StringUtil.BoolToStr( AV23SerasaRecomendaCompleto);
            AssignProp("", false, cmbavSerasarecomendacompleto_Internalname, "Values", (string)(cmbavSerasarecomendacompleto.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSerasanomemae_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSerasanomemae_Internalname, "Nome da mãe", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSerasanomemae_Internalname, AV24SerasaNomeMae, StringUtil.RTrim( context.localUtil.Format( AV24SerasaNomeMae, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,100);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSerasanomemae_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSerasanomemae_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpConsultaDetalhada.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSerasagenero_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSerasagenero_Internalname, "Genero", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSerasagenero_Internalname, AV25SerasaGenero, StringUtil.RTrim( context.localUtil.Format( AV25SerasaGenero, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,105);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSerasagenero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSerasagenero_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpConsultaDetalhada.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSerasagrafia_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSerasagrafia_Internalname, "Grafia", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSerasagrafia_Internalname, AV26SerasaGrafia, StringUtil.RTrim( context.localUtil.Format( AV26SerasaGrafia, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,109);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSerasagrafia_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSerasagrafia_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpConsultaDetalhada.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavSerasaparticipacaosocietaria_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavSerasaparticipacaosocietaria_Internalname, "Participação societária", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavSerasaparticipacaosocietaria, cmbavSerasaparticipacaosocietaria_Internalname, StringUtil.BoolToStr( AV27SerasaParticipacaoSocietaria), 1, cmbavSerasaparticipacaosocietaria_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbavSerasaparticipacaosocietaria.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,114);\"", "", true, 0, "HLP_WpConsultaDetalhada.htm");
            cmbavSerasaparticipacaosocietaria.CurrentValue = StringUtil.BoolToStr( AV27SerasaParticipacaoSocietaria);
            AssignProp("", false, cmbavSerasaparticipacaosocietaria_Internalname, "Values", (string)(cmbavSerasaparticipacaosocietaria.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavSerasaprotestoativo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavSerasaprotestoativo_Internalname, "Protesto ativo", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavSerasaprotestoativo, cmbavSerasaprotestoativo_Internalname, StringUtil.BoolToStr( AV28SerasaProtestoAtivo), 1, cmbavSerasaprotestoativo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbavSerasaprotestoativo.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,118);\"", "", true, 0, "HLP_WpConsultaDetalhada.htm");
            cmbavSerasaprotestoativo.CurrentValue = StringUtil.BoolToStr( AV28SerasaProtestoAtivo);
            AssignProp("", false, cmbavSerasaprotestoativo_Internalname, "Values", (string)(cmbavSerasaprotestoativo.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavSerasarendaestimada_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavSerasarendaestimada_Internalname, "Serasa Renda Estimada", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 123,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavSerasarendaestimada, cmbavSerasarendaestimada_Internalname, StringUtil.BoolToStr( AV29SerasaRendaEstimada), 1, cmbavSerasarendaestimada_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbavSerasarendaestimada.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,123);\"", "", true, 0, "HLP_WpConsultaDetalhada.htm");
            cmbavSerasarendaestimada.CurrentValue = StringUtil.BoolToStr( AV29SerasaRendaEstimada);
            AssignProp("", false, cmbavSerasarendaestimada_Internalname, "Values", (string)(cmbavSerasarendaestimada.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSerasavalorlimiterecomendado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSerasavalorlimiterecomendado_Internalname, "Valor limite recomendado", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 127,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSerasavalorlimiterecomendado_Internalname, StringUtil.LTrim( StringUtil.NToC( AV31SerasaValorLimiteRecomendado, 18, 2, ",", "")), StringUtil.LTrim( ((edtavSerasavalorlimiterecomendado_Enabled!=0) ? context.localUtil.Format( AV31SerasaValorLimiteRecomendado, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV31SerasaValorLimiteRecomendado, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,127);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSerasavalorlimiterecomendado_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSerasavalorlimiterecomendado_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpConsultaDetalhada.htm");
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
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup2_Internalname, "Endereços", 1, 0, "px", 0, "px", grpUnnamedgroup2_Class, "", "HLP_WpConsultaDetalhada.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableenderecos_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0134"+"", StringUtil.RTrim( WebComp_Wcserasaenderecosww_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0134"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcserasaenderecosww_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcserasaenderecosww), StringUtil.Lower( WebComp_Wcserasaenderecosww_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0134"+"");
                  }
                  WebComp_Wcserasaenderecosww.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcserasaenderecosww), StringUtil.Lower( WebComp_Wcserasaenderecosww_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
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
            GxWebStd.gx_group_start( context, grpUnnamedgroup3_Internalname, "Cheques", 1, 0, "px", 0, "px", grpUnnamedgroup3_Class, "", "HLP_WpConsultaDetalhada.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecheques_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0141"+"", StringUtil.RTrim( WebComp_Wcserasachequesww_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0141"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcserasachequesww_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcserasachequesww), StringUtil.Lower( WebComp_Wcserasachequesww_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0141"+"");
                  }
                  WebComp_Wcserasachequesww.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcserasachequesww), StringUtil.Lower( WebComp_Wcserasachequesww_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
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
            GxWebStd.gx_group_start( context, grpUnnamedgroup4_Internalname, "Ações", 1, 0, "px", 0, "px", grpUnnamedgroup4_Class, "", "HLP_WpConsultaDetalhada.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableacoes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0148"+"", StringUtil.RTrim( WebComp_Wcserasaacoesww_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0148"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcserasaacoesww_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcserasaacoesww), StringUtil.Lower( WebComp_Wcserasaacoesww_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0148"+"");
                  }
                  WebComp_Wcserasaacoesww.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcserasaacoesww), StringUtil.Lower( WebComp_Wcserasaacoesww_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
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
            GxWebStd.gx_group_start( context, grpUnnamedgroup5_Internalname, "Ocorrências", 1, 0, "px", 0, "px", grpUnnamedgroup5_Class, "", "HLP_WpConsultaDetalhada.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableocorrencias_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0155"+"", StringUtil.RTrim( WebComp_Wcserasaocorrenciasww_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0155"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcserasaocorrenciasww_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcserasaocorrenciasww), StringUtil.Lower( WebComp_Wcserasaocorrenciasww_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0155"+"");
                  }
                  WebComp_Wcserasaocorrenciasww.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcserasaocorrenciasww), StringUtil.Lower( WebComp_Wcserasaocorrenciasww_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
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
            GxWebStd.gx_group_start( context, grpUnnamedgroup6_Internalname, "Protestos", 1, 0, "px", 0, "px", grpUnnamedgroup6_Class, "", "HLP_WpConsultaDetalhada.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableprotestos_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0162"+"", StringUtil.RTrim( WebComp_Wcserasaprotestosww_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0162"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcserasaprotestosww_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcserasaprotestosww), StringUtil.Lower( WebComp_Wcserasaprotestosww_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0162"+"");
                  }
                  WebComp_Wcserasaprotestosww.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcserasaprotestosww), StringUtil.Lower( WebComp_Wcserasaprotestosww_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
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
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 166,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSerasatiporecomendacao_Internalname, AV7SerasaTipoRecomendacao, StringUtil.RTrim( context.localUtil.Format( AV7SerasaTipoRecomendacao, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,166);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSerasatiporecomendacao_Jsonclick, 0, "Attribute", "", "", "", "", edtavSerasatiporecomendacao_Visible, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpConsultaDetalhada.htm");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 167,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavSerasaanotacoescompletas, cmbavSerasaanotacoescompletas_Internalname, StringUtil.BoolToStr( AV10SerasaAnotacoesCompletas), 1, cmbavSerasaanotacoescompletas_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", cmbavSerasaanotacoescompletas.Visible, 1, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,167);\"", "", true, 0, "HLP_WpConsultaDetalhada.htm");
            cmbavSerasaanotacoescompletas.CurrentValue = StringUtil.BoolToStr( AV10SerasaAnotacoesCompletas);
            AssignProp("", false, cmbavSerasaanotacoescompletas_Internalname, "Values", (string)(cmbavSerasaanotacoescompletas.ToJavascriptSource()), true);
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 168,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavSerasaanotacoesconsultaspc, cmbavSerasaanotacoesconsultaspc_Internalname, StringUtil.BoolToStr( AV11SerasaAnotacoesConsultaSPC), 1, cmbavSerasaanotacoesconsultaspc_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", cmbavSerasaanotacoesconsultaspc.Visible, 1, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,168);\"", "", true, 0, "HLP_WpConsultaDetalhada.htm");
            cmbavSerasaanotacoesconsultaspc.CurrentValue = StringUtil.BoolToStr( AV11SerasaAnotacoesConsultaSPC);
            AssignProp("", false, cmbavSerasaanotacoesconsultaspc_Internalname, "Values", (string)(cmbavSerasaanotacoesconsultaspc.ToJavascriptSource()), true);
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 169,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavSerasaconsultasdetalhadas, cmbavSerasaconsultasdetalhadas_Internalname, StringUtil.BoolToStr( AV13SerasaConsultasDetalhadas), 1, cmbavSerasaconsultasdetalhadas_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", cmbavSerasaconsultasdetalhadas.Visible, 1, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,169);\"", "", true, 0, "HLP_WpConsultaDetalhada.htm");
            cmbavSerasaconsultasdetalhadas.CurrentValue = StringUtil.BoolToStr( AV13SerasaConsultasDetalhadas);
            AssignProp("", false, cmbavSerasaconsultasdetalhadas_Internalname, "Values", (string)(cmbavSerasaconsultasdetalhadas.ToJavascriptSource()), true);
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 170,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavSerasahistoricopagamentopf, cmbavSerasahistoricopagamentopf_Internalname, StringUtil.BoolToStr( AV16SerasaHistoricoPagamentoPF), 1, cmbavSerasahistoricopagamentopf_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", cmbavSerasahistoricopagamentopf.Visible, 1, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,170);\"", "", true, 0, "HLP_WpConsultaDetalhada.htm");
            cmbavSerasahistoricopagamentopf.CurrentValue = StringUtil.BoolToStr( AV16SerasaHistoricoPagamentoPF);
            AssignProp("", false, cmbavSerasahistoricopagamentopf_Internalname, "Values", (string)(cmbavSerasahistoricopagamentopf.ToJavascriptSource()), true);
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 171,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSerasafaixaderendaestimada_Internalname, StringUtil.LTrim( StringUtil.NToC( AV18SerasaFaixaDeRendaEstimada, 15, 2, ",", "")), StringUtil.LTrim( context.localUtil.Format( AV18SerasaFaixaDeRendaEstimada, "ZZZZZZZZZZZ9.99")), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,171);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSerasafaixaderendaestimada_Jsonclick, 0, "Attribute", "", "", "", "", edtavSerasafaixaderendaestimada_Visible, 1, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpConsultaDetalhada.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 172,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSerasataxa_Internalname, StringUtil.LTrim( StringUtil.NToC( AV30SerasaTaxa, 15, 2, ",", "")), StringUtil.LTrim( context.localUtil.Format( AV30SerasaTaxa, "ZZZZZZZZZZZ9.99")), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,172);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSerasataxa_Jsonclick, 0, "Attribute", "", "", "", "", edtavSerasataxa_Visible, 1, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpConsultaDetalhada.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START842( )
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
         Form.Meta.addItem("description", "Consulta detalhada", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP840( ) ;
      }

      protected void WS842( )
      {
         START842( ) ;
         EVT842( ) ;
      }

      protected void EVT842( )
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
                              E11842 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E12842 ();
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
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 134 )
                        {
                           OldWcserasaenderecosww = cgiGet( "W0134");
                           if ( ( StringUtil.Len( OldWcserasaenderecosww) == 0 ) || ( StringUtil.StrCmp(OldWcserasaenderecosww, WebComp_Wcserasaenderecosww_Component) != 0 ) )
                           {
                              WebComp_Wcserasaenderecosww = getWebComponent(GetType(), "GeneXus.Programs", OldWcserasaenderecosww, new Object[] {context} );
                              WebComp_Wcserasaenderecosww.ComponentInit();
                              WebComp_Wcserasaenderecosww.Name = "OldWcserasaenderecosww";
                              WebComp_Wcserasaenderecosww_Component = OldWcserasaenderecosww;
                           }
                           if ( StringUtil.Len( WebComp_Wcserasaenderecosww_Component) != 0 )
                           {
                              WebComp_Wcserasaenderecosww.componentprocess("W0134", "", sEvt);
                           }
                           WebComp_Wcserasaenderecosww_Component = OldWcserasaenderecosww;
                        }
                        else if ( nCmpId == 141 )
                        {
                           OldWcserasachequesww = cgiGet( "W0141");
                           if ( ( StringUtil.Len( OldWcserasachequesww) == 0 ) || ( StringUtil.StrCmp(OldWcserasachequesww, WebComp_Wcserasachequesww_Component) != 0 ) )
                           {
                              WebComp_Wcserasachequesww = getWebComponent(GetType(), "GeneXus.Programs", OldWcserasachequesww, new Object[] {context} );
                              WebComp_Wcserasachequesww.ComponentInit();
                              WebComp_Wcserasachequesww.Name = "OldWcserasachequesww";
                              WebComp_Wcserasachequesww_Component = OldWcserasachequesww;
                           }
                           if ( StringUtil.Len( WebComp_Wcserasachequesww_Component) != 0 )
                           {
                              WebComp_Wcserasachequesww.componentprocess("W0141", "", sEvt);
                           }
                           WebComp_Wcserasachequesww_Component = OldWcserasachequesww;
                        }
                        else if ( nCmpId == 148 )
                        {
                           OldWcserasaacoesww = cgiGet( "W0148");
                           if ( ( StringUtil.Len( OldWcserasaacoesww) == 0 ) || ( StringUtil.StrCmp(OldWcserasaacoesww, WebComp_Wcserasaacoesww_Component) != 0 ) )
                           {
                              WebComp_Wcserasaacoesww = getWebComponent(GetType(), "GeneXus.Programs", OldWcserasaacoesww, new Object[] {context} );
                              WebComp_Wcserasaacoesww.ComponentInit();
                              WebComp_Wcserasaacoesww.Name = "OldWcserasaacoesww";
                              WebComp_Wcserasaacoesww_Component = OldWcserasaacoesww;
                           }
                           if ( StringUtil.Len( WebComp_Wcserasaacoesww_Component) != 0 )
                           {
                              WebComp_Wcserasaacoesww.componentprocess("W0148", "", sEvt);
                           }
                           WebComp_Wcserasaacoesww_Component = OldWcserasaacoesww;
                        }
                        else if ( nCmpId == 155 )
                        {
                           OldWcserasaocorrenciasww = cgiGet( "W0155");
                           if ( ( StringUtil.Len( OldWcserasaocorrenciasww) == 0 ) || ( StringUtil.StrCmp(OldWcserasaocorrenciasww, WebComp_Wcserasaocorrenciasww_Component) != 0 ) )
                           {
                              WebComp_Wcserasaocorrenciasww = getWebComponent(GetType(), "GeneXus.Programs", OldWcserasaocorrenciasww, new Object[] {context} );
                              WebComp_Wcserasaocorrenciasww.ComponentInit();
                              WebComp_Wcserasaocorrenciasww.Name = "OldWcserasaocorrenciasww";
                              WebComp_Wcserasaocorrenciasww_Component = OldWcserasaocorrenciasww;
                           }
                           if ( StringUtil.Len( WebComp_Wcserasaocorrenciasww_Component) != 0 )
                           {
                              WebComp_Wcserasaocorrenciasww.componentprocess("W0155", "", sEvt);
                           }
                           WebComp_Wcserasaocorrenciasww_Component = OldWcserasaocorrenciasww;
                        }
                        else if ( nCmpId == 162 )
                        {
                           OldWcserasaprotestosww = cgiGet( "W0162");
                           if ( ( StringUtil.Len( OldWcserasaprotestosww) == 0 ) || ( StringUtil.StrCmp(OldWcserasaprotestosww, WebComp_Wcserasaprotestosww_Component) != 0 ) )
                           {
                              WebComp_Wcserasaprotestosww = getWebComponent(GetType(), "GeneXus.Programs", OldWcserasaprotestosww, new Object[] {context} );
                              WebComp_Wcserasaprotestosww.ComponentInit();
                              WebComp_Wcserasaprotestosww.Name = "OldWcserasaprotestosww";
                              WebComp_Wcserasaprotestosww_Component = OldWcserasaprotestosww;
                           }
                           if ( StringUtil.Len( WebComp_Wcserasaprotestosww_Component) != 0 )
                           {
                              WebComp_Wcserasaprotestosww.componentprocess("W0162", "", sEvt);
                           }
                           WebComp_Wcserasaprotestosww_Component = OldWcserasaprotestosww;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE842( )
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

      protected void PA842( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpconsultadetalhada")), "wpconsultadetalhada") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpconsultadetalhada")))) ;
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
                  gxfirstwebparm = GetFirstPar( "SerasaId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV32SerasaId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV32SerasaId", StringUtil.LTrimStr( (decimal)(AV32SerasaId), 9, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vSERASAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV32SerasaId), "ZZZZZZZZ9"), context));
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
               GX_FocusControl = edtavClienterazaosocial_Internalname;
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
         if ( cmbavSerasarecomendacaovenda.ItemCount > 0 )
         {
            AV6SerasaRecomendacaoVenda = cmbavSerasarecomendacaovenda.getValidValue(AV6SerasaRecomendacaoVenda);
            AssignAttri("", false, "AV6SerasaRecomendacaoVenda", AV6SerasaRecomendacaoVenda);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavSerasarecomendacaovenda.CurrentValue = StringUtil.RTrim( AV6SerasaRecomendacaoVenda);
            AssignProp("", false, cmbavSerasarecomendacaovenda_Internalname, "Values", cmbavSerasarecomendacaovenda.ToJavascriptSource(), true);
         }
         if ( cmbavSerasacodnivelrisco.ItemCount > 0 )
         {
            AV33SerasaCodNivelRisco = NumberUtil.Val( cmbavSerasacodnivelrisco.getValidValue(StringUtil.Trim( StringUtil.Str( AV33SerasaCodNivelRisco, 15, 2))), ".");
            AssignAttri("", false, "AV33SerasaCodNivelRisco", StringUtil.LTrimStr( AV33SerasaCodNivelRisco, 15, 2));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavSerasacodnivelrisco.CurrentValue = StringUtil.Trim( StringUtil.Str( AV33SerasaCodNivelRisco, 15, 2));
            AssignProp("", false, cmbavSerasacodnivelrisco_Internalname, "Values", cmbavSerasacodnivelrisco.ToJavascriptSource(), true);
         }
         if ( cmbavSerasapolitica.ItemCount > 0 )
         {
            AV9SerasaPolitica = NumberUtil.Val( cmbavSerasapolitica.getValidValue(StringUtil.Trim( StringUtil.Str( AV9SerasaPolitica, 15, 2))), ".");
            AssignAttri("", false, "AV9SerasaPolitica", StringUtil.LTrimStr( AV9SerasaPolitica, 15, 2));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavSerasapolitica.CurrentValue = StringUtil.Trim( StringUtil.Str( AV9SerasaPolitica, 15, 2));
            AssignProp("", false, cmbavSerasapolitica_Internalname, "Values", cmbavSerasapolitica.ToJavascriptSource(), true);
         }
         if ( cmbavSerasabaixocomprometimento.ItemCount > 0 )
         {
            AV12SerasaBaixoComprometimento = StringUtil.StrToBool( cmbavSerasabaixocomprometimento.getValidValue(StringUtil.BoolToStr( AV12SerasaBaixoComprometimento)));
            AssignAttri("", false, "AV12SerasaBaixoComprometimento", AV12SerasaBaixoComprometimento);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavSerasabaixocomprometimento.CurrentValue = StringUtil.BoolToStr( AV12SerasaBaixoComprometimento);
            AssignProp("", false, cmbavSerasabaixocomprometimento_Internalname, "Values", cmbavSerasabaixocomprometimento.ToJavascriptSource(), true);
         }
         if ( cmbavSerasacpfregular.ItemCount > 0 )
         {
            AV14SerasaCpfRegular = StringUtil.StrToBool( cmbavSerasacpfregular.getValidValue(StringUtil.BoolToStr( AV14SerasaCpfRegular)));
            AssignAttri("", false, "AV14SerasaCpfRegular", AV14SerasaCpfRegular);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavSerasacpfregular.CurrentValue = StringUtil.BoolToStr( AV14SerasaCpfRegular);
            AssignProp("", false, cmbavSerasacpfregular_Internalname, "Values", cmbavSerasacpfregular.ToJavascriptSource(), true);
         }
         if ( cmbavSerasaretricaoativa.ItemCount > 0 )
         {
            AV15SerasaRetricaoAtiva = StringUtil.StrToBool( cmbavSerasaretricaoativa.getValidValue(StringUtil.BoolToStr( AV15SerasaRetricaoAtiva)));
            AssignAttri("", false, "AV15SerasaRetricaoAtiva", AV15SerasaRetricaoAtiva);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavSerasaretricaoativa.CurrentValue = StringUtil.BoolToStr( AV15SerasaRetricaoAtiva);
            AssignProp("", false, cmbavSerasaretricaoativa_Internalname, "Values", cmbavSerasaretricaoativa.ToJavascriptSource(), true);
         }
         if ( cmbavSerasarecomendacompleto.ItemCount > 0 )
         {
            AV23SerasaRecomendaCompleto = StringUtil.StrToBool( cmbavSerasarecomendacompleto.getValidValue(StringUtil.BoolToStr( AV23SerasaRecomendaCompleto)));
            AssignAttri("", false, "AV23SerasaRecomendaCompleto", AV23SerasaRecomendaCompleto);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavSerasarecomendacompleto.CurrentValue = StringUtil.BoolToStr( AV23SerasaRecomendaCompleto);
            AssignProp("", false, cmbavSerasarecomendacompleto_Internalname, "Values", cmbavSerasarecomendacompleto.ToJavascriptSource(), true);
         }
         if ( cmbavSerasaparticipacaosocietaria.ItemCount > 0 )
         {
            AV27SerasaParticipacaoSocietaria = StringUtil.StrToBool( cmbavSerasaparticipacaosocietaria.getValidValue(StringUtil.BoolToStr( AV27SerasaParticipacaoSocietaria)));
            AssignAttri("", false, "AV27SerasaParticipacaoSocietaria", AV27SerasaParticipacaoSocietaria);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavSerasaparticipacaosocietaria.CurrentValue = StringUtil.BoolToStr( AV27SerasaParticipacaoSocietaria);
            AssignProp("", false, cmbavSerasaparticipacaosocietaria_Internalname, "Values", cmbavSerasaparticipacaosocietaria.ToJavascriptSource(), true);
         }
         if ( cmbavSerasaprotestoativo.ItemCount > 0 )
         {
            AV28SerasaProtestoAtivo = StringUtil.StrToBool( cmbavSerasaprotestoativo.getValidValue(StringUtil.BoolToStr( AV28SerasaProtestoAtivo)));
            AssignAttri("", false, "AV28SerasaProtestoAtivo", AV28SerasaProtestoAtivo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavSerasaprotestoativo.CurrentValue = StringUtil.BoolToStr( AV28SerasaProtestoAtivo);
            AssignProp("", false, cmbavSerasaprotestoativo_Internalname, "Values", cmbavSerasaprotestoativo.ToJavascriptSource(), true);
         }
         if ( cmbavSerasarendaestimada.ItemCount > 0 )
         {
            AV29SerasaRendaEstimada = StringUtil.StrToBool( cmbavSerasarendaestimada.getValidValue(StringUtil.BoolToStr( AV29SerasaRendaEstimada)));
            AssignAttri("", false, "AV29SerasaRendaEstimada", AV29SerasaRendaEstimada);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavSerasarendaestimada.CurrentValue = StringUtil.BoolToStr( AV29SerasaRendaEstimada);
            AssignProp("", false, cmbavSerasarendaestimada_Internalname, "Values", cmbavSerasarendaestimada.ToJavascriptSource(), true);
         }
         if ( cmbavSerasaanotacoescompletas.ItemCount > 0 )
         {
            AV10SerasaAnotacoesCompletas = StringUtil.StrToBool( cmbavSerasaanotacoescompletas.getValidValue(StringUtil.BoolToStr( AV10SerasaAnotacoesCompletas)));
            AssignAttri("", false, "AV10SerasaAnotacoesCompletas", AV10SerasaAnotacoesCompletas);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavSerasaanotacoescompletas.CurrentValue = StringUtil.BoolToStr( AV10SerasaAnotacoesCompletas);
            AssignProp("", false, cmbavSerasaanotacoescompletas_Internalname, "Values", cmbavSerasaanotacoescompletas.ToJavascriptSource(), true);
         }
         if ( cmbavSerasaanotacoesconsultaspc.ItemCount > 0 )
         {
            AV11SerasaAnotacoesConsultaSPC = StringUtil.StrToBool( cmbavSerasaanotacoesconsultaspc.getValidValue(StringUtil.BoolToStr( AV11SerasaAnotacoesConsultaSPC)));
            AssignAttri("", false, "AV11SerasaAnotacoesConsultaSPC", AV11SerasaAnotacoesConsultaSPC);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavSerasaanotacoesconsultaspc.CurrentValue = StringUtil.BoolToStr( AV11SerasaAnotacoesConsultaSPC);
            AssignProp("", false, cmbavSerasaanotacoesconsultaspc_Internalname, "Values", cmbavSerasaanotacoesconsultaspc.ToJavascriptSource(), true);
         }
         if ( cmbavSerasaconsultasdetalhadas.ItemCount > 0 )
         {
            AV13SerasaConsultasDetalhadas = StringUtil.StrToBool( cmbavSerasaconsultasdetalhadas.getValidValue(StringUtil.BoolToStr( AV13SerasaConsultasDetalhadas)));
            AssignAttri("", false, "AV13SerasaConsultasDetalhadas", AV13SerasaConsultasDetalhadas);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavSerasaconsultasdetalhadas.CurrentValue = StringUtil.BoolToStr( AV13SerasaConsultasDetalhadas);
            AssignProp("", false, cmbavSerasaconsultasdetalhadas_Internalname, "Values", cmbavSerasaconsultasdetalhadas.ToJavascriptSource(), true);
         }
         if ( cmbavSerasahistoricopagamentopf.ItemCount > 0 )
         {
            AV16SerasaHistoricoPagamentoPF = StringUtil.StrToBool( cmbavSerasahistoricopagamentopf.getValidValue(StringUtil.BoolToStr( AV16SerasaHistoricoPagamentoPF)));
            AssignAttri("", false, "AV16SerasaHistoricoPagamentoPF", AV16SerasaHistoricoPagamentoPF);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavSerasahistoricopagamentopf.CurrentValue = StringUtil.BoolToStr( AV16SerasaHistoricoPagamentoPF);
            AssignProp("", false, cmbavSerasahistoricopagamentopf_Internalname, "Values", cmbavSerasahistoricopagamentopf.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF842( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavClienterazaosocial_Enabled = 0;
         AssignProp("", false, edtavClienterazaosocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClienterazaosocial_Enabled), 5, 0), true);
         edtavSerasanumeroproposta_Enabled = 0;
         AssignProp("", false, edtavSerasanumeroproposta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSerasanumeroproposta_Enabled), 5, 0), true);
         cmbavSerasarecomendacaovenda.Enabled = 0;
         AssignProp("", false, cmbavSerasarecomendacaovenda_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSerasarecomendacaovenda.Enabled), 5, 0), true);
         cmbavSerasacodnivelrisco.Enabled = 0;
         AssignProp("", false, cmbavSerasacodnivelrisco_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSerasacodnivelrisco.Enabled), 5, 0), true);
         edtavSerasascore_Enabled = 0;
         AssignProp("", false, edtavSerasascore_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSerasascore_Enabled), 5, 0), true);
         edtavSerasamensagemscore_Enabled = 0;
         AssignProp("", false, edtavSerasamensagemscore_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSerasamensagemscore_Enabled), 5, 0), true);
         edtavSerasatipovenda_Enabled = 0;
         AssignProp("", false, edtavSerasatipovenda_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSerasatipovenda_Enabled), 5, 0), true);
         cmbavSerasapolitica.Enabled = 0;
         AssignProp("", false, cmbavSerasapolitica_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSerasapolitica.Enabled), 5, 0), true);
         cmbavSerasabaixocomprometimento.Enabled = 0;
         AssignProp("", false, cmbavSerasabaixocomprometimento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSerasabaixocomprometimento.Enabled), 5, 0), true);
         cmbavSerasacpfregular.Enabled = 0;
         AssignProp("", false, cmbavSerasacpfregular_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSerasacpfregular.Enabled), 5, 0), true);
         cmbavSerasaretricaoativa.Enabled = 0;
         AssignProp("", false, cmbavSerasaretricaoativa_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSerasaretricaoativa.Enabled), 5, 0), true);
         edtavSerasadatanascimento_Enabled = 0;
         AssignProp("", false, edtavSerasadatanascimento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSerasadatanascimento_Enabled), 5, 0), true);
         edtavSerasamensagemrendaestimada_Enabled = 0;
         AssignProp("", false, edtavSerasamensagemrendaestimada_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSerasamensagemrendaestimada_Enabled), 5, 0), true);
         edtavSerasasituacaocpf_Enabled = 0;
         AssignProp("", false, edtavSerasasituacaocpf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSerasasituacaocpf_Enabled), 5, 0), true);
         cmbavSerasarecomendacompleto.Enabled = 0;
         AssignProp("", false, cmbavSerasarecomendacompleto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSerasarecomendacompleto.Enabled), 5, 0), true);
         edtavSerasanomemae_Enabled = 0;
         AssignProp("", false, edtavSerasanomemae_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSerasanomemae_Enabled), 5, 0), true);
         edtavSerasagenero_Enabled = 0;
         AssignProp("", false, edtavSerasagenero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSerasagenero_Enabled), 5, 0), true);
         edtavSerasagrafia_Enabled = 0;
         AssignProp("", false, edtavSerasagrafia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSerasagrafia_Enabled), 5, 0), true);
         cmbavSerasaparticipacaosocietaria.Enabled = 0;
         AssignProp("", false, cmbavSerasaparticipacaosocietaria_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSerasaparticipacaosocietaria.Enabled), 5, 0), true);
         cmbavSerasaprotestoativo.Enabled = 0;
         AssignProp("", false, cmbavSerasaprotestoativo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSerasaprotestoativo.Enabled), 5, 0), true);
         cmbavSerasarendaestimada.Enabled = 0;
         AssignProp("", false, cmbavSerasarendaestimada_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSerasarendaestimada.Enabled), 5, 0), true);
         edtavSerasavalorlimiterecomendado_Enabled = 0;
         AssignProp("", false, edtavSerasavalorlimiterecomendado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSerasavalorlimiterecomendado_Enabled), 5, 0), true);
      }

      protected void RF842( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcserasaenderecosww_Component) != 0 )
               {
                  WebComp_Wcserasaenderecosww.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcserasachequesww_Component) != 0 )
               {
                  WebComp_Wcserasachequesww.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcserasaacoesww_Component) != 0 )
               {
                  WebComp_Wcserasaacoesww.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcserasaocorrenciasww_Component) != 0 )
               {
                  WebComp_Wcserasaocorrenciasww.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcserasaprotestosww_Component) != 0 )
               {
                  WebComp_Wcserasaprotestosww.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E12842 ();
            WB840( ) ;
         }
      }

      protected void send_integrity_lvl_hashes842( )
      {
      }

      protected void before_start_formulas( )
      {
         edtavClienterazaosocial_Enabled = 0;
         AssignProp("", false, edtavClienterazaosocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClienterazaosocial_Enabled), 5, 0), true);
         edtavSerasanumeroproposta_Enabled = 0;
         AssignProp("", false, edtavSerasanumeroproposta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSerasanumeroproposta_Enabled), 5, 0), true);
         cmbavSerasarecomendacaovenda.Enabled = 0;
         AssignProp("", false, cmbavSerasarecomendacaovenda_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSerasarecomendacaovenda.Enabled), 5, 0), true);
         cmbavSerasacodnivelrisco.Enabled = 0;
         AssignProp("", false, cmbavSerasacodnivelrisco_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSerasacodnivelrisco.Enabled), 5, 0), true);
         edtavSerasascore_Enabled = 0;
         AssignProp("", false, edtavSerasascore_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSerasascore_Enabled), 5, 0), true);
         edtavSerasamensagemscore_Enabled = 0;
         AssignProp("", false, edtavSerasamensagemscore_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSerasamensagemscore_Enabled), 5, 0), true);
         edtavSerasatipovenda_Enabled = 0;
         AssignProp("", false, edtavSerasatipovenda_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSerasatipovenda_Enabled), 5, 0), true);
         cmbavSerasapolitica.Enabled = 0;
         AssignProp("", false, cmbavSerasapolitica_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSerasapolitica.Enabled), 5, 0), true);
         cmbavSerasabaixocomprometimento.Enabled = 0;
         AssignProp("", false, cmbavSerasabaixocomprometimento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSerasabaixocomprometimento.Enabled), 5, 0), true);
         cmbavSerasacpfregular.Enabled = 0;
         AssignProp("", false, cmbavSerasacpfregular_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSerasacpfregular.Enabled), 5, 0), true);
         cmbavSerasaretricaoativa.Enabled = 0;
         AssignProp("", false, cmbavSerasaretricaoativa_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSerasaretricaoativa.Enabled), 5, 0), true);
         edtavSerasadatanascimento_Enabled = 0;
         AssignProp("", false, edtavSerasadatanascimento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSerasadatanascimento_Enabled), 5, 0), true);
         edtavSerasamensagemrendaestimada_Enabled = 0;
         AssignProp("", false, edtavSerasamensagemrendaestimada_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSerasamensagemrendaestimada_Enabled), 5, 0), true);
         edtavSerasasituacaocpf_Enabled = 0;
         AssignProp("", false, edtavSerasasituacaocpf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSerasasituacaocpf_Enabled), 5, 0), true);
         cmbavSerasarecomendacompleto.Enabled = 0;
         AssignProp("", false, cmbavSerasarecomendacompleto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSerasarecomendacompleto.Enabled), 5, 0), true);
         edtavSerasanomemae_Enabled = 0;
         AssignProp("", false, edtavSerasanomemae_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSerasanomemae_Enabled), 5, 0), true);
         edtavSerasagenero_Enabled = 0;
         AssignProp("", false, edtavSerasagenero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSerasagenero_Enabled), 5, 0), true);
         edtavSerasagrafia_Enabled = 0;
         AssignProp("", false, edtavSerasagrafia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSerasagrafia_Enabled), 5, 0), true);
         cmbavSerasaparticipacaosocietaria.Enabled = 0;
         AssignProp("", false, cmbavSerasaparticipacaosocietaria_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSerasaparticipacaosocietaria.Enabled), 5, 0), true);
         cmbavSerasaprotestoativo.Enabled = 0;
         AssignProp("", false, cmbavSerasaprotestoativo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSerasaprotestoativo.Enabled), 5, 0), true);
         cmbavSerasarendaestimada.Enabled = 0;
         AssignProp("", false, cmbavSerasarendaestimada_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSerasarendaestimada.Enabled), 5, 0), true);
         edtavSerasavalorlimiterecomendado_Enabled = 0;
         AssignProp("", false, edtavSerasavalorlimiterecomendado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSerasavalorlimiterecomendado_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP840( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11842 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            AV39ClienteRazaoSocial = StringUtil.Upper( cgiGet( edtavClienterazaosocial_Internalname));
            AssignAttri("", false, "AV39ClienteRazaoSocial", AV39ClienteRazaoSocial);
            AV5SerasaNumeroProposta = cgiGet( edtavSerasanumeroproposta_Internalname);
            AssignAttri("", false, "AV5SerasaNumeroProposta", AV5SerasaNumeroProposta);
            cmbavSerasarecomendacaovenda.CurrentValue = cgiGet( cmbavSerasarecomendacaovenda_Internalname);
            AV6SerasaRecomendacaoVenda = cgiGet( cmbavSerasarecomendacaovenda_Internalname);
            AssignAttri("", false, "AV6SerasaRecomendacaoVenda", AV6SerasaRecomendacaoVenda);
            cmbavSerasacodnivelrisco.CurrentValue = cgiGet( cmbavSerasacodnivelrisco_Internalname);
            AV33SerasaCodNivelRisco = NumberUtil.Val( cgiGet( cmbavSerasacodnivelrisco_Internalname), ".");
            AssignAttri("", false, "AV33SerasaCodNivelRisco", StringUtil.LTrimStr( AV33SerasaCodNivelRisco, 15, 2));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSerasascore_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSerasascore_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSERASASCORE");
               GX_FocusControl = edtavSerasascore_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV20SerasaScore = 0;
               AssignAttri("", false, "AV20SerasaScore", StringUtil.LTrimStr( (decimal)(AV20SerasaScore), 4, 0));
            }
            else
            {
               AV20SerasaScore = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavSerasascore_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV20SerasaScore", StringUtil.LTrimStr( (decimal)(AV20SerasaScore), 4, 0));
            }
            AV21SerasaMensagemScore = cgiGet( edtavSerasamensagemscore_Internalname);
            AssignAttri("", false, "AV21SerasaMensagemScore", AV21SerasaMensagemScore);
            AV8SerasaTipoVenda = cgiGet( edtavSerasatipovenda_Internalname);
            AssignAttri("", false, "AV8SerasaTipoVenda", AV8SerasaTipoVenda);
            cmbavSerasapolitica.CurrentValue = cgiGet( cmbavSerasapolitica_Internalname);
            AV9SerasaPolitica = NumberUtil.Val( cgiGet( cmbavSerasapolitica_Internalname), ".");
            AssignAttri("", false, "AV9SerasaPolitica", StringUtil.LTrimStr( AV9SerasaPolitica, 15, 2));
            cmbavSerasabaixocomprometimento.CurrentValue = cgiGet( cmbavSerasabaixocomprometimento_Internalname);
            AV12SerasaBaixoComprometimento = StringUtil.StrToBool( cgiGet( cmbavSerasabaixocomprometimento_Internalname));
            AssignAttri("", false, "AV12SerasaBaixoComprometimento", AV12SerasaBaixoComprometimento);
            cmbavSerasacpfregular.CurrentValue = cgiGet( cmbavSerasacpfregular_Internalname);
            AV14SerasaCpfRegular = StringUtil.StrToBool( cgiGet( cmbavSerasacpfregular_Internalname));
            AssignAttri("", false, "AV14SerasaCpfRegular", AV14SerasaCpfRegular);
            cmbavSerasaretricaoativa.CurrentValue = cgiGet( cmbavSerasaretricaoativa_Internalname);
            AV15SerasaRetricaoAtiva = StringUtil.StrToBool( cgiGet( cmbavSerasaretricaoativa_Internalname));
            AssignAttri("", false, "AV15SerasaRetricaoAtiva", AV15SerasaRetricaoAtiva);
            if ( context.localUtil.VCDate( cgiGet( edtavSerasadatanascimento_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Serasa Data Nascimento"}), 1, "vSERASADATANASCIMENTO");
               GX_FocusControl = edtavSerasadatanascimento_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV17SerasaDataNascimento = DateTime.MinValue;
               AssignAttri("", false, "AV17SerasaDataNascimento", context.localUtil.Format(AV17SerasaDataNascimento, "99/99/99"));
            }
            else
            {
               AV17SerasaDataNascimento = context.localUtil.CToD( cgiGet( edtavSerasadatanascimento_Internalname), 2);
               AssignAttri("", false, "AV17SerasaDataNascimento", context.localUtil.Format(AV17SerasaDataNascimento, "99/99/99"));
            }
            AV19SerasaMensagemRendaEstimada = cgiGet( edtavSerasamensagemrendaestimada_Internalname);
            AssignAttri("", false, "AV19SerasaMensagemRendaEstimada", AV19SerasaMensagemRendaEstimada);
            AV22SerasaSituacaoCPF = cgiGet( edtavSerasasituacaocpf_Internalname);
            AssignAttri("", false, "AV22SerasaSituacaoCPF", AV22SerasaSituacaoCPF);
            cmbavSerasarecomendacompleto.CurrentValue = cgiGet( cmbavSerasarecomendacompleto_Internalname);
            AV23SerasaRecomendaCompleto = StringUtil.StrToBool( cgiGet( cmbavSerasarecomendacompleto_Internalname));
            AssignAttri("", false, "AV23SerasaRecomendaCompleto", AV23SerasaRecomendaCompleto);
            AV24SerasaNomeMae = cgiGet( edtavSerasanomemae_Internalname);
            AssignAttri("", false, "AV24SerasaNomeMae", AV24SerasaNomeMae);
            AV25SerasaGenero = cgiGet( edtavSerasagenero_Internalname);
            AssignAttri("", false, "AV25SerasaGenero", AV25SerasaGenero);
            AV26SerasaGrafia = cgiGet( edtavSerasagrafia_Internalname);
            AssignAttri("", false, "AV26SerasaGrafia", AV26SerasaGrafia);
            cmbavSerasaparticipacaosocietaria.CurrentValue = cgiGet( cmbavSerasaparticipacaosocietaria_Internalname);
            AV27SerasaParticipacaoSocietaria = StringUtil.StrToBool( cgiGet( cmbavSerasaparticipacaosocietaria_Internalname));
            AssignAttri("", false, "AV27SerasaParticipacaoSocietaria", AV27SerasaParticipacaoSocietaria);
            cmbavSerasaprotestoativo.CurrentValue = cgiGet( cmbavSerasaprotestoativo_Internalname);
            AV28SerasaProtestoAtivo = StringUtil.StrToBool( cgiGet( cmbavSerasaprotestoativo_Internalname));
            AssignAttri("", false, "AV28SerasaProtestoAtivo", AV28SerasaProtestoAtivo);
            cmbavSerasarendaestimada.CurrentValue = cgiGet( cmbavSerasarendaestimada_Internalname);
            AV29SerasaRendaEstimada = StringUtil.StrToBool( cgiGet( cmbavSerasarendaestimada_Internalname));
            AssignAttri("", false, "AV29SerasaRendaEstimada", AV29SerasaRendaEstimada);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSerasavalorlimiterecomendado_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSerasavalorlimiterecomendado_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSERASAVALORLIMITERECOMENDADO");
               GX_FocusControl = edtavSerasavalorlimiterecomendado_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV31SerasaValorLimiteRecomendado = 0;
               AssignAttri("", false, "AV31SerasaValorLimiteRecomendado", StringUtil.LTrimStr( AV31SerasaValorLimiteRecomendado, 18, 2));
            }
            else
            {
               AV31SerasaValorLimiteRecomendado = context.localUtil.CToN( cgiGet( edtavSerasavalorlimiterecomendado_Internalname), ",", ".");
               AssignAttri("", false, "AV31SerasaValorLimiteRecomendado", StringUtil.LTrimStr( AV31SerasaValorLimiteRecomendado, 18, 2));
            }
            AV7SerasaTipoRecomendacao = cgiGet( edtavSerasatiporecomendacao_Internalname);
            AssignAttri("", false, "AV7SerasaTipoRecomendacao", AV7SerasaTipoRecomendacao);
            cmbavSerasaanotacoescompletas.CurrentValue = cgiGet( cmbavSerasaanotacoescompletas_Internalname);
            AV10SerasaAnotacoesCompletas = StringUtil.StrToBool( cgiGet( cmbavSerasaanotacoescompletas_Internalname));
            AssignAttri("", false, "AV10SerasaAnotacoesCompletas", AV10SerasaAnotacoesCompletas);
            cmbavSerasaanotacoesconsultaspc.CurrentValue = cgiGet( cmbavSerasaanotacoesconsultaspc_Internalname);
            AV11SerasaAnotacoesConsultaSPC = StringUtil.StrToBool( cgiGet( cmbavSerasaanotacoesconsultaspc_Internalname));
            AssignAttri("", false, "AV11SerasaAnotacoesConsultaSPC", AV11SerasaAnotacoesConsultaSPC);
            cmbavSerasaconsultasdetalhadas.CurrentValue = cgiGet( cmbavSerasaconsultasdetalhadas_Internalname);
            AV13SerasaConsultasDetalhadas = StringUtil.StrToBool( cgiGet( cmbavSerasaconsultasdetalhadas_Internalname));
            AssignAttri("", false, "AV13SerasaConsultasDetalhadas", AV13SerasaConsultasDetalhadas);
            cmbavSerasahistoricopagamentopf.CurrentValue = cgiGet( cmbavSerasahistoricopagamentopf_Internalname);
            AV16SerasaHistoricoPagamentoPF = StringUtil.StrToBool( cgiGet( cmbavSerasahistoricopagamentopf_Internalname));
            AssignAttri("", false, "AV16SerasaHistoricoPagamentoPF", AV16SerasaHistoricoPagamentoPF);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSerasafaixaderendaestimada_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSerasafaixaderendaestimada_Internalname), ",", ".") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSERASAFAIXADERENDAESTIMADA");
               GX_FocusControl = edtavSerasafaixaderendaestimada_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV18SerasaFaixaDeRendaEstimada = 0;
               AssignAttri("", false, "AV18SerasaFaixaDeRendaEstimada", StringUtil.LTrimStr( AV18SerasaFaixaDeRendaEstimada, 15, 2));
            }
            else
            {
               AV18SerasaFaixaDeRendaEstimada = context.localUtil.CToN( cgiGet( edtavSerasafaixaderendaestimada_Internalname), ",", ".");
               AssignAttri("", false, "AV18SerasaFaixaDeRendaEstimada", StringUtil.LTrimStr( AV18SerasaFaixaDeRendaEstimada, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSerasataxa_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSerasataxa_Internalname), ",", ".") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSERASATAXA");
               GX_FocusControl = edtavSerasataxa_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV30SerasaTaxa = 0;
               AssignAttri("", false, "AV30SerasaTaxa", StringUtil.LTrimStr( AV30SerasaTaxa, 15, 2));
            }
            else
            {
               AV30SerasaTaxa = context.localUtil.CToN( cgiGet( edtavSerasataxa_Internalname), ",", ".");
               AssignAttri("", false, "AV30SerasaTaxa", StringUtil.LTrimStr( AV30SerasaTaxa, 15, 2));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"WpConsultaDetalhada");
            AV6SerasaRecomendacaoVenda = cgiGet( cmbavSerasarecomendacaovenda_Internalname);
            AssignAttri("", false, "AV6SerasaRecomendacaoVenda", AV6SerasaRecomendacaoVenda);
            forbiddenHiddens.Add("SerasaRecomendacaoVenda", StringUtil.RTrim( context.localUtil.Format( AV6SerasaRecomendacaoVenda, "")));
            hsh = cgiGet( "hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("wpconsultadetalhada:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               return  ;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E11842 ();
         if (returnInSub) return;
      }

      protected void E11842( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Using cursor H00847 */
         pr_default.execute(0, new Object[] {AV32SerasaId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A168ClienteId = H00847_A168ClienteId[0];
            n168ClienteId = H00847_n168ClienteId[0];
            A662SerasaId = H00847_A662SerasaId[0];
            n662SerasaId = H00847_n662SerasaId[0];
            A170ClienteRazaoSocial = H00847_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = H00847_n170ClienteRazaoSocial[0];
            A678SerasaAnotacoesCompletas = H00847_A678SerasaAnotacoesCompletas[0];
            n678SerasaAnotacoesCompletas = H00847_n678SerasaAnotacoesCompletas[0];
            A680SerasaAnotacoesConsultaSPC = H00847_A680SerasaAnotacoesConsultaSPC[0];
            n680SerasaAnotacoesConsultaSPC = H00847_n680SerasaAnotacoesConsultaSPC[0];
            A674SerasaBaixoComprometimento = H00847_A674SerasaBaixoComprometimento[0];
            n674SerasaBaixoComprometimento = H00847_n674SerasaBaixoComprometimento[0];
            A679SerasaConsultasDetalhadas = H00847_A679SerasaConsultasDetalhadas[0];
            n679SerasaConsultasDetalhadas = H00847_n679SerasaConsultasDetalhadas[0];
            A671SerasaCpfRegular = H00847_A671SerasaCpfRegular[0];
            n671SerasaCpfRegular = H00847_n671SerasaCpfRegular[0];
            A689SerasaDataNascimento = H00847_A689SerasaDataNascimento[0];
            n689SerasaDataNascimento = H00847_n689SerasaDataNascimento[0];
            A676SerasaFaixaDeRendaEstimada = H00847_A676SerasaFaixaDeRendaEstimada[0];
            n676SerasaFaixaDeRendaEstimada = H00847_n676SerasaFaixaDeRendaEstimada[0];
            A690SerasaGenero = H00847_A690SerasaGenero[0];
            n690SerasaGenero = H00847_n690SerasaGenero[0];
            A692SerasaGrafia = H00847_A692SerasaGrafia[0];
            n692SerasaGrafia = H00847_n692SerasaGrafia[0];
            A683SerasaHistoricoPagamentoPF = H00847_A683SerasaHistoricoPagamentoPF[0];
            n683SerasaHistoricoPagamentoPF = H00847_n683SerasaHistoricoPagamentoPF[0];
            A677SerasaMensagemRendaEstimada = H00847_A677SerasaMensagemRendaEstimada[0];
            n677SerasaMensagemRendaEstimada = H00847_n677SerasaMensagemRendaEstimada[0];
            A687SerasaMensagemScore = H00847_A687SerasaMensagemScore[0];
            n687SerasaMensagemScore = H00847_n687SerasaMensagemScore[0];
            A691SerasaNomeMae = H00847_A691SerasaNomeMae[0];
            n691SerasaNomeMae = H00847_n691SerasaNomeMae[0];
            A663SerasaNumeroProposta = H00847_A663SerasaNumeroProposta[0];
            n663SerasaNumeroProposta = H00847_n663SerasaNumeroProposta[0];
            A681SerasaParticipacaoSocietaria = H00847_A681SerasaParticipacaoSocietaria[0];
            n681SerasaParticipacaoSocietaria = H00847_n681SerasaParticipacaoSocietaria[0];
            A664SerasaPolitica = H00847_A664SerasaPolitica[0];
            n664SerasaPolitica = H00847_n664SerasaPolitica[0];
            A673SerasaProtestoAtivo = H00847_A673SerasaProtestoAtivo[0];
            n673SerasaProtestoAtivo = H00847_n673SerasaProtestoAtivo[0];
            A670SerasaRecomendacaoVenda = H00847_A670SerasaRecomendacaoVenda[0];
            n670SerasaRecomendacaoVenda = H00847_n670SerasaRecomendacaoVenda[0];
            A684SerasaRecomendaCompleto = H00847_A684SerasaRecomendaCompleto[0];
            n684SerasaRecomendaCompleto = H00847_n684SerasaRecomendaCompleto[0];
            A682SerasaRendaEstimada = H00847_A682SerasaRendaEstimada[0];
            n682SerasaRendaEstimada = H00847_n682SerasaRendaEstimada[0];
            A672SerasaRetricaoAtiva = H00847_A672SerasaRetricaoAtiva[0];
            n672SerasaRetricaoAtiva = H00847_n672SerasaRetricaoAtiva[0];
            A685SerasaScore = H00847_A685SerasaScore[0];
            n685SerasaScore = H00847_n685SerasaScore[0];
            A688SerasaSituacaoCPF = H00847_A688SerasaSituacaoCPF[0];
            n688SerasaSituacaoCPF = H00847_n688SerasaSituacaoCPF[0];
            A686SerasaTaxa = H00847_A686SerasaTaxa[0];
            n686SerasaTaxa = H00847_n686SerasaTaxa[0];
            A669SerasaTipoRecomendacao = H00847_A669SerasaTipoRecomendacao[0];
            n669SerasaTipoRecomendacao = H00847_n669SerasaTipoRecomendacao[0];
            A666SerasaTipoVenda = H00847_A666SerasaTipoVenda[0];
            n666SerasaTipoVenda = H00847_n666SerasaTipoVenda[0];
            A675SerasaValorLimiteRecomendado = H00847_A675SerasaValorLimiteRecomendado[0];
            n675SerasaValorLimiteRecomendado = H00847_n675SerasaValorLimiteRecomendado[0];
            A668SerasaCodNivelRisco = H00847_A668SerasaCodNivelRisco[0];
            n668SerasaCodNivelRisco = H00847_n668SerasaCodNivelRisco[0];
            A775SerasaCountAcoes_F = H00847_A775SerasaCountAcoes_F[0];
            n775SerasaCountAcoes_F = H00847_n775SerasaCountAcoes_F[0];
            A776SerasaCountEnderecos_F = H00847_A776SerasaCountEnderecos_F[0];
            n776SerasaCountEnderecos_F = H00847_n776SerasaCountEnderecos_F[0];
            A777SerasaCountProtestos_F = H00847_A777SerasaCountProtestos_F[0];
            n777SerasaCountProtestos_F = H00847_n777SerasaCountProtestos_F[0];
            A778SerasaCountOcorrencias_F = H00847_A778SerasaCountOcorrencias_F[0];
            n778SerasaCountOcorrencias_F = H00847_n778SerasaCountOcorrencias_F[0];
            A779SerasaCountCheques_F = H00847_A779SerasaCountCheques_F[0];
            n779SerasaCountCheques_F = H00847_n779SerasaCountCheques_F[0];
            A170ClienteRazaoSocial = H00847_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = H00847_n170ClienteRazaoSocial[0];
            A775SerasaCountAcoes_F = H00847_A775SerasaCountAcoes_F[0];
            n775SerasaCountAcoes_F = H00847_n775SerasaCountAcoes_F[0];
            A776SerasaCountEnderecos_F = H00847_A776SerasaCountEnderecos_F[0];
            n776SerasaCountEnderecos_F = H00847_n776SerasaCountEnderecos_F[0];
            A777SerasaCountProtestos_F = H00847_A777SerasaCountProtestos_F[0];
            n777SerasaCountProtestos_F = H00847_n777SerasaCountProtestos_F[0];
            A778SerasaCountOcorrencias_F = H00847_A778SerasaCountOcorrencias_F[0];
            n778SerasaCountOcorrencias_F = H00847_n778SerasaCountOcorrencias_F[0];
            A779SerasaCountCheques_F = H00847_A779SerasaCountCheques_F[0];
            n779SerasaCountCheques_F = H00847_n779SerasaCountCheques_F[0];
            AV39ClienteRazaoSocial = A170ClienteRazaoSocial;
            AssignAttri("", false, "AV39ClienteRazaoSocial", AV39ClienteRazaoSocial);
            AV10SerasaAnotacoesCompletas = A678SerasaAnotacoesCompletas;
            AssignAttri("", false, "AV10SerasaAnotacoesCompletas", AV10SerasaAnotacoesCompletas);
            AV11SerasaAnotacoesConsultaSPC = A680SerasaAnotacoesConsultaSPC;
            AssignAttri("", false, "AV11SerasaAnotacoesConsultaSPC", AV11SerasaAnotacoesConsultaSPC);
            AV12SerasaBaixoComprometimento = A674SerasaBaixoComprometimento;
            AssignAttri("", false, "AV12SerasaBaixoComprometimento", AV12SerasaBaixoComprometimento);
            AV13SerasaConsultasDetalhadas = A679SerasaConsultasDetalhadas;
            AssignAttri("", false, "AV13SerasaConsultasDetalhadas", AV13SerasaConsultasDetalhadas);
            AV14SerasaCpfRegular = A671SerasaCpfRegular;
            AssignAttri("", false, "AV14SerasaCpfRegular", AV14SerasaCpfRegular);
            AV17SerasaDataNascimento = A689SerasaDataNascimento;
            AssignAttri("", false, "AV17SerasaDataNascimento", context.localUtil.Format(AV17SerasaDataNascimento, "99/99/99"));
            AV18SerasaFaixaDeRendaEstimada = A676SerasaFaixaDeRendaEstimada;
            AssignAttri("", false, "AV18SerasaFaixaDeRendaEstimada", StringUtil.LTrimStr( AV18SerasaFaixaDeRendaEstimada, 15, 2));
            AV25SerasaGenero = A690SerasaGenero;
            AssignAttri("", false, "AV25SerasaGenero", AV25SerasaGenero);
            AV26SerasaGrafia = A692SerasaGrafia;
            AssignAttri("", false, "AV26SerasaGrafia", AV26SerasaGrafia);
            AV16SerasaHistoricoPagamentoPF = A683SerasaHistoricoPagamentoPF;
            AssignAttri("", false, "AV16SerasaHistoricoPagamentoPF", AV16SerasaHistoricoPagamentoPF);
            AV19SerasaMensagemRendaEstimada = A677SerasaMensagemRendaEstimada;
            AssignAttri("", false, "AV19SerasaMensagemRendaEstimada", AV19SerasaMensagemRendaEstimada);
            AV21SerasaMensagemScore = A687SerasaMensagemScore;
            AssignAttri("", false, "AV21SerasaMensagemScore", AV21SerasaMensagemScore);
            AV24SerasaNomeMae = A691SerasaNomeMae;
            AssignAttri("", false, "AV24SerasaNomeMae", AV24SerasaNomeMae);
            AV5SerasaNumeroProposta = A663SerasaNumeroProposta;
            AssignAttri("", false, "AV5SerasaNumeroProposta", AV5SerasaNumeroProposta);
            AV27SerasaParticipacaoSocietaria = A681SerasaParticipacaoSocietaria;
            AssignAttri("", false, "AV27SerasaParticipacaoSocietaria", AV27SerasaParticipacaoSocietaria);
            AV9SerasaPolitica = A664SerasaPolitica;
            AssignAttri("", false, "AV9SerasaPolitica", StringUtil.LTrimStr( AV9SerasaPolitica, 15, 2));
            AV28SerasaProtestoAtivo = A673SerasaProtestoAtivo;
            AssignAttri("", false, "AV28SerasaProtestoAtivo", AV28SerasaProtestoAtivo);
            AV6SerasaRecomendacaoVenda = A670SerasaRecomendacaoVenda;
            AssignAttri("", false, "AV6SerasaRecomendacaoVenda", AV6SerasaRecomendacaoVenda);
            AV23SerasaRecomendaCompleto = A684SerasaRecomendaCompleto;
            AssignAttri("", false, "AV23SerasaRecomendaCompleto", AV23SerasaRecomendaCompleto);
            AV29SerasaRendaEstimada = A682SerasaRendaEstimada;
            AssignAttri("", false, "AV29SerasaRendaEstimada", AV29SerasaRendaEstimada);
            AV15SerasaRetricaoAtiva = A672SerasaRetricaoAtiva;
            AssignAttri("", false, "AV15SerasaRetricaoAtiva", AV15SerasaRetricaoAtiva);
            AV20SerasaScore = A685SerasaScore;
            AssignAttri("", false, "AV20SerasaScore", StringUtil.LTrimStr( (decimal)(AV20SerasaScore), 4, 0));
            AV22SerasaSituacaoCPF = A688SerasaSituacaoCPF;
            AssignAttri("", false, "AV22SerasaSituacaoCPF", AV22SerasaSituacaoCPF);
            AV30SerasaTaxa = A686SerasaTaxa;
            AssignAttri("", false, "AV30SerasaTaxa", StringUtil.LTrimStr( AV30SerasaTaxa, 15, 2));
            AV7SerasaTipoRecomendacao = A669SerasaTipoRecomendacao;
            AssignAttri("", false, "AV7SerasaTipoRecomendacao", AV7SerasaTipoRecomendacao);
            AV8SerasaTipoVenda = A666SerasaTipoVenda;
            AssignAttri("", false, "AV8SerasaTipoVenda", AV8SerasaTipoVenda);
            AV31SerasaValorLimiteRecomendado = A675SerasaValorLimiteRecomendado;
            AssignAttri("", false, "AV31SerasaValorLimiteRecomendado", StringUtil.LTrimStr( AV31SerasaValorLimiteRecomendado, 18, 2));
            AV33SerasaCodNivelRisco = A668SerasaCodNivelRisco;
            AssignAttri("", false, "AV33SerasaCodNivelRisco", StringUtil.LTrimStr( AV33SerasaCodNivelRisco, 15, 2));
            AV34SerasaCountAcoes_F = A775SerasaCountAcoes_F;
            AssignAttri("", false, "AV34SerasaCountAcoes_F", StringUtil.LTrimStr( (decimal)(AV34SerasaCountAcoes_F), 4, 0));
            AV38SerasaCountEnderecos_F = A776SerasaCountEnderecos_F;
            AssignAttri("", false, "AV38SerasaCountEnderecos_F", StringUtil.LTrimStr( (decimal)(AV38SerasaCountEnderecos_F), 4, 0));
            AV37SerasaCountProtestos_F = A777SerasaCountProtestos_F;
            AssignAttri("", false, "AV37SerasaCountProtestos_F", StringUtil.LTrimStr( (decimal)(AV37SerasaCountProtestos_F), 4, 0));
            AV36SerasaCountOcorrencias_F = A778SerasaCountOcorrencias_F;
            AssignAttri("", false, "AV36SerasaCountOcorrencias_F", StringUtil.LTrimStr( (decimal)(AV36SerasaCountOcorrencias_F), 4, 0));
            AV35SerasaCountCheques_F = A779SerasaCountCheques_F;
            AssignAttri("", false, "AV35SerasaCountCheques_F", StringUtil.LTrimStr( (decimal)(AV35SerasaCountCheques_F), 4, 0));
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if (returnInSub) return;
         edtavSerasatiporecomendacao_Visible = 0;
         AssignProp("", false, edtavSerasatiporecomendacao_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSerasatiporecomendacao_Visible), 5, 0), true);
         cmbavSerasaanotacoescompletas.Visible = 0;
         AssignProp("", false, cmbavSerasaanotacoescompletas_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavSerasaanotacoescompletas.Visible), 5, 0), true);
         cmbavSerasaanotacoesconsultaspc.Visible = 0;
         AssignProp("", false, cmbavSerasaanotacoesconsultaspc_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavSerasaanotacoesconsultaspc.Visible), 5, 0), true);
         cmbavSerasaconsultasdetalhadas.Visible = 0;
         AssignProp("", false, cmbavSerasaconsultasdetalhadas_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavSerasaconsultasdetalhadas.Visible), 5, 0), true);
         cmbavSerasahistoricopagamentopf.Visible = 0;
         AssignProp("", false, cmbavSerasahistoricopagamentopf_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavSerasahistoricopagamentopf.Visible), 5, 0), true);
         edtavSerasafaixaderendaestimada_Visible = 0;
         AssignProp("", false, edtavSerasafaixaderendaestimada_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSerasafaixaderendaestimada_Visible), 5, 0), true);
         edtavSerasataxa_Visible = 0;
         AssignProp("", false, edtavSerasataxa_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSerasataxa_Visible), 5, 0), true);
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wcserasaprotestosww = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcserasaprotestosww_Component), StringUtil.Lower( "SerasaProtestosWW")) != 0 )
         {
            WebComp_Wcserasaprotestosww = getWebComponent(GetType(), "GeneXus.Programs", "serasaprotestosww", new Object[] {context} );
            WebComp_Wcserasaprotestosww.ComponentInit();
            WebComp_Wcserasaprotestosww.Name = "SerasaProtestosWW";
            WebComp_Wcserasaprotestosww_Component = "SerasaProtestosWW";
         }
         if ( StringUtil.Len( WebComp_Wcserasaprotestosww_Component) != 0 )
         {
            WebComp_Wcserasaprotestosww.setjustcreated();
            WebComp_Wcserasaprotestosww.componentprepare(new Object[] {(string)"W0162",(string)"",(int)AV32SerasaId});
            WebComp_Wcserasaprotestosww.componentbind(new Object[] {(string)""});
         }
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wcserasaocorrenciasww = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcserasaocorrenciasww_Component), StringUtil.Lower( "SerasaOcorrenciasWW")) != 0 )
         {
            WebComp_Wcserasaocorrenciasww = getWebComponent(GetType(), "GeneXus.Programs", "serasaocorrenciasww", new Object[] {context} );
            WebComp_Wcserasaocorrenciasww.ComponentInit();
            WebComp_Wcserasaocorrenciasww.Name = "SerasaOcorrenciasWW";
            WebComp_Wcserasaocorrenciasww_Component = "SerasaOcorrenciasWW";
         }
         if ( StringUtil.Len( WebComp_Wcserasaocorrenciasww_Component) != 0 )
         {
            WebComp_Wcserasaocorrenciasww.setjustcreated();
            WebComp_Wcserasaocorrenciasww.componentprepare(new Object[] {(string)"W0155",(string)"",(int)AV32SerasaId});
            WebComp_Wcserasaocorrenciasww.componentbind(new Object[] {(string)""});
         }
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wcserasaacoesww = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcserasaacoesww_Component), StringUtil.Lower( "SerasaAcoesWW")) != 0 )
         {
            WebComp_Wcserasaacoesww = getWebComponent(GetType(), "GeneXus.Programs", "serasaacoesww", new Object[] {context} );
            WebComp_Wcserasaacoesww.ComponentInit();
            WebComp_Wcserasaacoesww.Name = "SerasaAcoesWW";
            WebComp_Wcserasaacoesww_Component = "SerasaAcoesWW";
         }
         if ( StringUtil.Len( WebComp_Wcserasaacoesww_Component) != 0 )
         {
            WebComp_Wcserasaacoesww.setjustcreated();
            WebComp_Wcserasaacoesww.componentprepare(new Object[] {(string)"W0148",(string)"",(int)AV32SerasaId});
            WebComp_Wcserasaacoesww.componentbind(new Object[] {(string)""});
         }
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wcserasachequesww = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcserasachequesww_Component), StringUtil.Lower( "SerasaChequesWW")) != 0 )
         {
            WebComp_Wcserasachequesww = getWebComponent(GetType(), "GeneXus.Programs", "serasachequesww", new Object[] {context} );
            WebComp_Wcserasachequesww.ComponentInit();
            WebComp_Wcserasachequesww.Name = "SerasaChequesWW";
            WebComp_Wcserasachequesww_Component = "SerasaChequesWW";
         }
         if ( StringUtil.Len( WebComp_Wcserasachequesww_Component) != 0 )
         {
            WebComp_Wcserasachequesww.setjustcreated();
            WebComp_Wcserasachequesww.componentprepare(new Object[] {(string)"W0141",(string)"",(int)AV32SerasaId});
            WebComp_Wcserasachequesww.componentbind(new Object[] {(string)""});
         }
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wcserasaenderecosww = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcserasaenderecosww_Component), StringUtil.Lower( "SerasaEnderecosWW")) != 0 )
         {
            WebComp_Wcserasaenderecosww = getWebComponent(GetType(), "GeneXus.Programs", "serasaenderecosww", new Object[] {context} );
            WebComp_Wcserasaenderecosww.ComponentInit();
            WebComp_Wcserasaenderecosww.Name = "SerasaEnderecosWW";
            WebComp_Wcserasaenderecosww_Component = "SerasaEnderecosWW";
         }
         if ( StringUtil.Len( WebComp_Wcserasaenderecosww_Component) != 0 )
         {
            WebComp_Wcserasaenderecosww.setjustcreated();
            WebComp_Wcserasaenderecosww.componentprepare(new Object[] {(string)"W0134",(string)"",(int)AV32SerasaId});
            WebComp_Wcserasaenderecosww.componentbind(new Object[] {(string)""});
         }
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ! ( ( AV38SerasaCountEnderecos_F > 0 ) ) )
         {
            grpUnnamedgroup2_Class = "Invisible";
            AssignProp("", false, grpUnnamedgroup2_Internalname, "Class", grpUnnamedgroup2_Class, true);
         }
         else
         {
            grpUnnamedgroup2_Class = "Group";
            AssignProp("", false, grpUnnamedgroup2_Internalname, "Class", grpUnnamedgroup2_Class, true);
         }
         if ( ! ( ( AV35SerasaCountCheques_F > 0 ) ) )
         {
            grpUnnamedgroup3_Class = "Invisible";
            AssignProp("", false, grpUnnamedgroup3_Internalname, "Class", grpUnnamedgroup3_Class, true);
         }
         else
         {
            grpUnnamedgroup3_Class = "Group";
            AssignProp("", false, grpUnnamedgroup3_Internalname, "Class", grpUnnamedgroup3_Class, true);
         }
         if ( ! ( ( AV34SerasaCountAcoes_F > 0 ) ) )
         {
            grpUnnamedgroup4_Class = "Invisible";
            AssignProp("", false, grpUnnamedgroup4_Internalname, "Class", grpUnnamedgroup4_Class, true);
         }
         else
         {
            grpUnnamedgroup4_Class = "Group";
            AssignProp("", false, grpUnnamedgroup4_Internalname, "Class", grpUnnamedgroup4_Class, true);
         }
         if ( ! ( ( AV36SerasaCountOcorrencias_F > 0 ) ) )
         {
            grpUnnamedgroup5_Class = "Invisible";
            AssignProp("", false, grpUnnamedgroup5_Internalname, "Class", grpUnnamedgroup5_Class, true);
         }
         else
         {
            grpUnnamedgroup5_Class = "Group";
            AssignProp("", false, grpUnnamedgroup5_Internalname, "Class", grpUnnamedgroup5_Class, true);
         }
         if ( ! ( ( AV37SerasaCountProtestos_F > 0 ) ) )
         {
            grpUnnamedgroup6_Class = "Invisible";
            AssignProp("", false, grpUnnamedgroup6_Internalname, "Class", grpUnnamedgroup6_Class, true);
         }
         else
         {
            grpUnnamedgroup6_Class = "Group";
            AssignProp("", false, grpUnnamedgroup6_Internalname, "Class", grpUnnamedgroup6_Class, true);
         }
         lblSerasarecomendacaovenda_tags_Caption = "";
         AssignProp("", false, lblSerasarecomendacaovenda_tags_Internalname, "Caption", lblSerasarecomendacaovenda_tags_Caption, true);
         if ( StringUtil.StrCmp(AV6SerasaRecomendacaoVenda, "1") == 0 )
         {
            lblSerasarecomendacaovenda_tags_Caption = lblSerasarecomendacaovenda_tags_Caption+"<span class='AttributeTagSuccess TagAfterText'></span>";
            AssignProp("", false, lblSerasarecomendacaovenda_tags_Internalname, "Caption", lblSerasarecomendacaovenda_tags_Caption, true);
         }
         if ( StringUtil.StrCmp(AV6SerasaRecomendacaoVenda, "2") == 0 )
         {
            lblSerasarecomendacaovenda_tags_Caption = lblSerasarecomendacaovenda_tags_Caption+"<span class='AttributeTagDanger TagAfterText'></span>";
            AssignProp("", false, lblSerasarecomendacaovenda_tags_Internalname, "Caption", lblSerasarecomendacaovenda_tags_Caption, true);
         }
         if ( StringUtil.StrCmp(AV6SerasaRecomendacaoVenda, "3") == 0 )
         {
            lblSerasarecomendacaovenda_tags_Caption = lblSerasarecomendacaovenda_tags_Caption+"<span class='AttributeTagDanger TagAfterText'></span>";
            AssignProp("", false, lblSerasarecomendacaovenda_tags_Internalname, "Caption", lblSerasarecomendacaovenda_tags_Caption, true);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E12842( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_35_842( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedserasarecomendacaovenda_Internalname, tblTablemergedserasarecomendacaovenda_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavSerasarecomendacaovenda_Internalname, "Serasa Recomendacao Venda", "gx-form-item AttributeFLLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavSerasarecomendacaovenda, cmbavSerasarecomendacaovenda_Internalname, StringUtil.RTrim( AV6SerasaRecomendacaoVenda), 1, cmbavSerasarecomendacaovenda_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavSerasarecomendacaovenda.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "", true, 0, "HLP_WpConsultaDetalhada.htm");
            cmbavSerasarecomendacaovenda.CurrentValue = StringUtil.RTrim( AV6SerasaRecomendacaoVenda);
            AssignProp("", false, cmbavSerasarecomendacaovenda_Internalname, "Values", (string)(cmbavSerasarecomendacaovenda.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSerasarecomendacaovenda_tags_Internalname, lblSerasarecomendacaovenda_tags_Caption, "", "", lblSerasarecomendacaovenda_tags_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WpConsultaDetalhada.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_35_842e( true) ;
         }
         else
         {
            wb_table1_35_842e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV32SerasaId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV32SerasaId", StringUtil.LTrimStr( (decimal)(AV32SerasaId), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vSERASAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV32SerasaId), "ZZZZZZZZ9"), context));
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
         PA842( ) ;
         WS842( ) ;
         WE842( ) ;
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
         if ( ! ( WebComp_Wcserasaenderecosww == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcserasaenderecosww_Component) != 0 )
            {
               WebComp_Wcserasaenderecosww.componentthemes();
            }
         }
         if ( ! ( WebComp_Wcserasachequesww == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcserasachequesww_Component) != 0 )
            {
               WebComp_Wcserasachequesww.componentthemes();
            }
         }
         if ( ! ( WebComp_Wcserasaacoesww == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcserasaacoesww_Component) != 0 )
            {
               WebComp_Wcserasaacoesww.componentthemes();
            }
         }
         if ( ! ( WebComp_Wcserasaocorrenciasww == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcserasaocorrenciasww_Component) != 0 )
            {
               WebComp_Wcserasaocorrenciasww.componentthemes();
            }
         }
         if ( ! ( WebComp_Wcserasaprotestosww == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcserasaprotestosww_Component) != 0 )
            {
               WebComp_Wcserasaprotestosww.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019273774", true, true);
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
         context.AddJavascriptSource("wpconsultadetalhada.js", "?202561019273775", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavSerasarecomendacaovenda.Name = "vSERASARECOMENDACAOVENDA";
         cmbavSerasarecomendacaovenda.WebTags = "";
         cmbavSerasarecomendacaovenda.addItem("1", "Aprovada", 0);
         cmbavSerasarecomendacaovenda.addItem("2", "Pendente", 0);
         cmbavSerasarecomendacaovenda.addItem("3", "Declinada", 0);
         if ( cmbavSerasarecomendacaovenda.ItemCount > 0 )
         {
            AV6SerasaRecomendacaoVenda = cmbavSerasarecomendacaovenda.getValidValue(AV6SerasaRecomendacaoVenda);
            AssignAttri("", false, "AV6SerasaRecomendacaoVenda", AV6SerasaRecomendacaoVenda);
         }
         cmbavSerasacodnivelrisco.Name = "vSERASACODNIVELRISCO";
         cmbavSerasacodnivelrisco.WebTags = "";
         cmbavSerasacodnivelrisco.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(1), 15, 2)), "Baixissimo", 0);
         cmbavSerasacodnivelrisco.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(2), 15, 2)), "Baixo", 0);
         cmbavSerasacodnivelrisco.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(3), 15, 2)), "Médio", 0);
         cmbavSerasacodnivelrisco.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(4), 15, 2)), "Alto", 0);
         cmbavSerasacodnivelrisco.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(5), 15, 2)), "Não calculado", 0);
         if ( cmbavSerasacodnivelrisco.ItemCount > 0 )
         {
            AV33SerasaCodNivelRisco = NumberUtil.Val( cmbavSerasacodnivelrisco.getValidValue(StringUtil.Trim( StringUtil.Str( AV33SerasaCodNivelRisco, 15, 2))), ".");
            AssignAttri("", false, "AV33SerasaCodNivelRisco", StringUtil.LTrimStr( AV33SerasaCodNivelRisco, 15, 2));
         }
         cmbavSerasapolitica.Name = "vSERASAPOLITICA";
         cmbavSerasapolitica.WebTags = "";
         cmbavSerasapolitica.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(1), 15, 2)), "Padrão", 0);
         cmbavSerasapolitica.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(2), 15, 2)), "Atacado", 0);
         if ( cmbavSerasapolitica.ItemCount > 0 )
         {
            AV9SerasaPolitica = NumberUtil.Val( cmbavSerasapolitica.getValidValue(StringUtil.Trim( StringUtil.Str( AV9SerasaPolitica, 15, 2))), ".");
            AssignAttri("", false, "AV9SerasaPolitica", StringUtil.LTrimStr( AV9SerasaPolitica, 15, 2));
         }
         cmbavSerasabaixocomprometimento.Name = "vSERASABAIXOCOMPROMETIMENTO";
         cmbavSerasabaixocomprometimento.WebTags = "";
         cmbavSerasabaixocomprometimento.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbavSerasabaixocomprometimento.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbavSerasabaixocomprometimento.ItemCount > 0 )
         {
            AV12SerasaBaixoComprometimento = StringUtil.StrToBool( cmbavSerasabaixocomprometimento.getValidValue(StringUtil.BoolToStr( AV12SerasaBaixoComprometimento)));
            AssignAttri("", false, "AV12SerasaBaixoComprometimento", AV12SerasaBaixoComprometimento);
         }
         cmbavSerasacpfregular.Name = "vSERASACPFREGULAR";
         cmbavSerasacpfregular.WebTags = "";
         cmbavSerasacpfregular.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbavSerasacpfregular.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbavSerasacpfregular.ItemCount > 0 )
         {
            AV14SerasaCpfRegular = StringUtil.StrToBool( cmbavSerasacpfregular.getValidValue(StringUtil.BoolToStr( AV14SerasaCpfRegular)));
            AssignAttri("", false, "AV14SerasaCpfRegular", AV14SerasaCpfRegular);
         }
         cmbavSerasaretricaoativa.Name = "vSERASARETRICAOATIVA";
         cmbavSerasaretricaoativa.WebTags = "";
         cmbavSerasaretricaoativa.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbavSerasaretricaoativa.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbavSerasaretricaoativa.ItemCount > 0 )
         {
            AV15SerasaRetricaoAtiva = StringUtil.StrToBool( cmbavSerasaretricaoativa.getValidValue(StringUtil.BoolToStr( AV15SerasaRetricaoAtiva)));
            AssignAttri("", false, "AV15SerasaRetricaoAtiva", AV15SerasaRetricaoAtiva);
         }
         cmbavSerasarecomendacompleto.Name = "vSERASARECOMENDACOMPLETO";
         cmbavSerasarecomendacompleto.WebTags = "";
         cmbavSerasarecomendacompleto.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbavSerasarecomendacompleto.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbavSerasarecomendacompleto.ItemCount > 0 )
         {
            AV23SerasaRecomendaCompleto = StringUtil.StrToBool( cmbavSerasarecomendacompleto.getValidValue(StringUtil.BoolToStr( AV23SerasaRecomendaCompleto)));
            AssignAttri("", false, "AV23SerasaRecomendaCompleto", AV23SerasaRecomendaCompleto);
         }
         cmbavSerasaparticipacaosocietaria.Name = "vSERASAPARTICIPACAOSOCIETARIA";
         cmbavSerasaparticipacaosocietaria.WebTags = "";
         cmbavSerasaparticipacaosocietaria.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbavSerasaparticipacaosocietaria.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbavSerasaparticipacaosocietaria.ItemCount > 0 )
         {
            AV27SerasaParticipacaoSocietaria = StringUtil.StrToBool( cmbavSerasaparticipacaosocietaria.getValidValue(StringUtil.BoolToStr( AV27SerasaParticipacaoSocietaria)));
            AssignAttri("", false, "AV27SerasaParticipacaoSocietaria", AV27SerasaParticipacaoSocietaria);
         }
         cmbavSerasaprotestoativo.Name = "vSERASAPROTESTOATIVO";
         cmbavSerasaprotestoativo.WebTags = "";
         cmbavSerasaprotestoativo.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbavSerasaprotestoativo.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbavSerasaprotestoativo.ItemCount > 0 )
         {
            AV28SerasaProtestoAtivo = StringUtil.StrToBool( cmbavSerasaprotestoativo.getValidValue(StringUtil.BoolToStr( AV28SerasaProtestoAtivo)));
            AssignAttri("", false, "AV28SerasaProtestoAtivo", AV28SerasaProtestoAtivo);
         }
         cmbavSerasarendaestimada.Name = "vSERASARENDAESTIMADA";
         cmbavSerasarendaestimada.WebTags = "";
         cmbavSerasarendaestimada.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbavSerasarendaestimada.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbavSerasarendaestimada.ItemCount > 0 )
         {
            AV29SerasaRendaEstimada = StringUtil.StrToBool( cmbavSerasarendaestimada.getValidValue(StringUtil.BoolToStr( AV29SerasaRendaEstimada)));
            AssignAttri("", false, "AV29SerasaRendaEstimada", AV29SerasaRendaEstimada);
         }
         cmbavSerasaanotacoescompletas.Name = "vSERASAANOTACOESCOMPLETAS";
         cmbavSerasaanotacoescompletas.WebTags = "";
         cmbavSerasaanotacoescompletas.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbavSerasaanotacoescompletas.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbavSerasaanotacoescompletas.ItemCount > 0 )
         {
            AV10SerasaAnotacoesCompletas = StringUtil.StrToBool( cmbavSerasaanotacoescompletas.getValidValue(StringUtil.BoolToStr( AV10SerasaAnotacoesCompletas)));
            AssignAttri("", false, "AV10SerasaAnotacoesCompletas", AV10SerasaAnotacoesCompletas);
         }
         cmbavSerasaanotacoesconsultaspc.Name = "vSERASAANOTACOESCONSULTASPC";
         cmbavSerasaanotacoesconsultaspc.WebTags = "";
         cmbavSerasaanotacoesconsultaspc.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbavSerasaanotacoesconsultaspc.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbavSerasaanotacoesconsultaspc.ItemCount > 0 )
         {
            AV11SerasaAnotacoesConsultaSPC = StringUtil.StrToBool( cmbavSerasaanotacoesconsultaspc.getValidValue(StringUtil.BoolToStr( AV11SerasaAnotacoesConsultaSPC)));
            AssignAttri("", false, "AV11SerasaAnotacoesConsultaSPC", AV11SerasaAnotacoesConsultaSPC);
         }
         cmbavSerasaconsultasdetalhadas.Name = "vSERASACONSULTASDETALHADAS";
         cmbavSerasaconsultasdetalhadas.WebTags = "";
         cmbavSerasaconsultasdetalhadas.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbavSerasaconsultasdetalhadas.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbavSerasaconsultasdetalhadas.ItemCount > 0 )
         {
            AV13SerasaConsultasDetalhadas = StringUtil.StrToBool( cmbavSerasaconsultasdetalhadas.getValidValue(StringUtil.BoolToStr( AV13SerasaConsultasDetalhadas)));
            AssignAttri("", false, "AV13SerasaConsultasDetalhadas", AV13SerasaConsultasDetalhadas);
         }
         cmbavSerasahistoricopagamentopf.Name = "vSERASAHISTORICOPAGAMENTOPF";
         cmbavSerasahistoricopagamentopf.WebTags = "";
         cmbavSerasahistoricopagamentopf.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbavSerasahistoricopagamentopf.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbavSerasahistoricopagamentopf.ItemCount > 0 )
         {
            AV16SerasaHistoricoPagamentoPF = StringUtil.StrToBool( cmbavSerasahistoricopagamentopf.getValidValue(StringUtil.BoolToStr( AV16SerasaHistoricoPagamentoPF)));
            AssignAttri("", false, "AV16SerasaHistoricoPagamentoPF", AV16SerasaHistoricoPagamentoPF);
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         edtavClienterazaosocial_Internalname = "vCLIENTERAZAOSOCIAL";
         edtavSerasanumeroproposta_Internalname = "vSERASANUMEROPROPOSTA";
         lblTextblockserasarecomendacaovenda_Internalname = "TEXTBLOCKSERASARECOMENDACAOVENDA";
         cmbavSerasarecomendacaovenda_Internalname = "vSERASARECOMENDACAOVENDA";
         lblSerasarecomendacaovenda_tags_Internalname = "SERASARECOMENDACAOVENDA_TAGS";
         tblTablemergedserasarecomendacaovenda_Internalname = "TABLEMERGEDSERASARECOMENDACAOVENDA";
         divTablesplittedserasarecomendacaovenda_Internalname = "TABLESPLITTEDSERASARECOMENDACAOVENDA";
         cmbavSerasacodnivelrisco_Internalname = "vSERASACODNIVELRISCO";
         edtavSerasascore_Internalname = "vSERASASCORE";
         edtavSerasamensagemscore_Internalname = "vSERASAMENSAGEMSCORE";
         edtavSerasatipovenda_Internalname = "vSERASATIPOVENDA";
         cmbavSerasapolitica_Internalname = "vSERASAPOLITICA";
         cmbavSerasabaixocomprometimento_Internalname = "vSERASABAIXOCOMPROMETIMENTO";
         cmbavSerasacpfregular_Internalname = "vSERASACPFREGULAR";
         cmbavSerasaretricaoativa_Internalname = "vSERASARETRICAOATIVA";
         edtavSerasadatanascimento_Internalname = "vSERASADATANASCIMENTO";
         edtavSerasamensagemrendaestimada_Internalname = "vSERASAMENSAGEMRENDAESTIMADA";
         edtavSerasasituacaocpf_Internalname = "vSERASASITUACAOCPF";
         cmbavSerasarecomendacompleto_Internalname = "vSERASARECOMENDACOMPLETO";
         edtavSerasanomemae_Internalname = "vSERASANOMEMAE";
         edtavSerasagenero_Internalname = "vSERASAGENERO";
         edtavSerasagrafia_Internalname = "vSERASAGRAFIA";
         cmbavSerasaparticipacaosocietaria_Internalname = "vSERASAPARTICIPACAOSOCIETARIA";
         cmbavSerasaprotestoativo_Internalname = "vSERASAPROTESTOATIVO";
         cmbavSerasarendaestimada_Internalname = "vSERASARENDAESTIMADA";
         edtavSerasavalorlimiterecomendado_Internalname = "vSERASAVALORLIMITERECOMENDADO";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         divTableenderecos_Internalname = "TABLEENDERECOS";
         grpUnnamedgroup2_Internalname = "UNNAMEDGROUP2";
         divTablecheques_Internalname = "TABLECHEQUES";
         grpUnnamedgroup3_Internalname = "UNNAMEDGROUP3";
         divTableacoes_Internalname = "TABLEACOES";
         grpUnnamedgroup4_Internalname = "UNNAMEDGROUP4";
         divTableocorrencias_Internalname = "TABLEOCORRENCIAS";
         grpUnnamedgroup5_Internalname = "UNNAMEDGROUP5";
         divTableprotestos_Internalname = "TABLEPROTESTOS";
         grpUnnamedgroup6_Internalname = "UNNAMEDGROUP6";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         edtavSerasatiporecomendacao_Internalname = "vSERASATIPORECOMENDACAO";
         cmbavSerasaanotacoescompletas_Internalname = "vSERASAANOTACOESCOMPLETAS";
         cmbavSerasaanotacoesconsultaspc_Internalname = "vSERASAANOTACOESCONSULTASPC";
         cmbavSerasaconsultasdetalhadas_Internalname = "vSERASACONSULTASDETALHADAS";
         cmbavSerasahistoricopagamentopf_Internalname = "vSERASAHISTORICOPAGAMENTOPF";
         edtavSerasafaixaderendaestimada_Internalname = "vSERASAFAIXADERENDAESTIMADA";
         edtavSerasataxa_Internalname = "vSERASATAXA";
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
         cmbavSerasarecomendacaovenda_Jsonclick = "";
         cmbavSerasarecomendacaovenda.Enabled = 1;
         lblSerasarecomendacaovenda_tags_Caption = "";
         edtavSerasataxa_Jsonclick = "";
         edtavSerasataxa_Visible = 1;
         edtavSerasafaixaderendaestimada_Jsonclick = "";
         edtavSerasafaixaderendaestimada_Visible = 1;
         cmbavSerasahistoricopagamentopf_Jsonclick = "";
         cmbavSerasahistoricopagamentopf.Visible = 1;
         cmbavSerasaconsultasdetalhadas_Jsonclick = "";
         cmbavSerasaconsultasdetalhadas.Visible = 1;
         cmbavSerasaanotacoesconsultaspc_Jsonclick = "";
         cmbavSerasaanotacoesconsultaspc.Visible = 1;
         cmbavSerasaanotacoescompletas_Jsonclick = "";
         cmbavSerasaanotacoescompletas.Visible = 1;
         edtavSerasatiporecomendacao_Jsonclick = "";
         edtavSerasatiporecomendacao_Visible = 1;
         grpUnnamedgroup6_Class = "Group";
         grpUnnamedgroup5_Class = "Group";
         grpUnnamedgroup4_Class = "Group";
         grpUnnamedgroup3_Class = "Group";
         grpUnnamedgroup2_Class = "Group";
         edtavSerasavalorlimiterecomendado_Jsonclick = "";
         edtavSerasavalorlimiterecomendado_Enabled = 1;
         cmbavSerasarendaestimada_Jsonclick = "";
         cmbavSerasarendaestimada.Enabled = 1;
         cmbavSerasaprotestoativo_Jsonclick = "";
         cmbavSerasaprotestoativo.Enabled = 1;
         cmbavSerasaparticipacaosocietaria_Jsonclick = "";
         cmbavSerasaparticipacaosocietaria.Enabled = 1;
         edtavSerasagrafia_Jsonclick = "";
         edtavSerasagrafia_Enabled = 1;
         edtavSerasagenero_Jsonclick = "";
         edtavSerasagenero_Enabled = 1;
         edtavSerasanomemae_Jsonclick = "";
         edtavSerasanomemae_Enabled = 1;
         cmbavSerasarecomendacompleto_Jsonclick = "";
         cmbavSerasarecomendacompleto.Enabled = 1;
         edtavSerasasituacaocpf_Jsonclick = "";
         edtavSerasasituacaocpf_Enabled = 1;
         edtavSerasamensagemrendaestimada_Enabled = 1;
         edtavSerasadatanascimento_Jsonclick = "";
         edtavSerasadatanascimento_Enabled = 1;
         cmbavSerasaretricaoativa_Jsonclick = "";
         cmbavSerasaretricaoativa.Enabled = 1;
         cmbavSerasacpfregular_Jsonclick = "";
         cmbavSerasacpfregular.Enabled = 1;
         cmbavSerasabaixocomprometimento_Jsonclick = "";
         cmbavSerasabaixocomprometimento.Enabled = 1;
         cmbavSerasapolitica_Jsonclick = "";
         cmbavSerasapolitica.Enabled = 1;
         edtavSerasatipovenda_Jsonclick = "";
         edtavSerasatipovenda_Enabled = 1;
         edtavSerasamensagemscore_Enabled = 1;
         edtavSerasascore_Jsonclick = "";
         edtavSerasascore_Enabled = 1;
         cmbavSerasacodnivelrisco_Jsonclick = "";
         cmbavSerasacodnivelrisco.Enabled = 1;
         edtavSerasanumeroproposta_Jsonclick = "";
         edtavSerasanumeroproposta_Enabled = 1;
         edtavClienterazaosocial_Jsonclick = "";
         edtavClienterazaosocial_Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Consulta detalhada";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV32SerasaId","fld":"vSERASAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"cmbavSerasarecomendacaovenda"},{"av":"AV6SerasaRecomendacaoVenda","fld":"vSERASARECOMENDACAOVENDA","type":"svchar"}]}""");
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
         forbiddenHiddens = new GXProperties();
         AV6SerasaRecomendacaoVenda = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_cancel_Jsonclick = "";
         AV39ClienteRazaoSocial = "";
         AV5SerasaNumeroProposta = "";
         lblTextblockserasarecomendacaovenda_Jsonclick = "";
         AV21SerasaMensagemScore = "";
         AV8SerasaTipoVenda = "";
         AV17SerasaDataNascimento = DateTime.MinValue;
         AV19SerasaMensagemRendaEstimada = "";
         AV22SerasaSituacaoCPF = "";
         AV24SerasaNomeMae = "";
         AV25SerasaGenero = "";
         AV26SerasaGrafia = "";
         WebComp_Wcserasaenderecosww_Component = "";
         OldWcserasaenderecosww = "";
         WebComp_Wcserasachequesww_Component = "";
         OldWcserasachequesww = "";
         WebComp_Wcserasaacoesww_Component = "";
         OldWcserasaacoesww = "";
         WebComp_Wcserasaocorrenciasww_Component = "";
         OldWcserasaocorrenciasww = "";
         WebComp_Wcserasaprotestosww_Component = "";
         OldWcserasaprotestosww = "";
         AV7SerasaTipoRecomendacao = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         hsh = "";
         H00847_A168ClienteId = new int[1] ;
         H00847_n168ClienteId = new bool[] {false} ;
         H00847_A662SerasaId = new int[1] ;
         H00847_n662SerasaId = new bool[] {false} ;
         H00847_A170ClienteRazaoSocial = new string[] {""} ;
         H00847_n170ClienteRazaoSocial = new bool[] {false} ;
         H00847_A678SerasaAnotacoesCompletas = new bool[] {false} ;
         H00847_n678SerasaAnotacoesCompletas = new bool[] {false} ;
         H00847_A680SerasaAnotacoesConsultaSPC = new bool[] {false} ;
         H00847_n680SerasaAnotacoesConsultaSPC = new bool[] {false} ;
         H00847_A674SerasaBaixoComprometimento = new bool[] {false} ;
         H00847_n674SerasaBaixoComprometimento = new bool[] {false} ;
         H00847_A679SerasaConsultasDetalhadas = new bool[] {false} ;
         H00847_n679SerasaConsultasDetalhadas = new bool[] {false} ;
         H00847_A671SerasaCpfRegular = new bool[] {false} ;
         H00847_n671SerasaCpfRegular = new bool[] {false} ;
         H00847_A689SerasaDataNascimento = new DateTime[] {DateTime.MinValue} ;
         H00847_n689SerasaDataNascimento = new bool[] {false} ;
         H00847_A676SerasaFaixaDeRendaEstimada = new decimal[1] ;
         H00847_n676SerasaFaixaDeRendaEstimada = new bool[] {false} ;
         H00847_A690SerasaGenero = new string[] {""} ;
         H00847_n690SerasaGenero = new bool[] {false} ;
         H00847_A692SerasaGrafia = new string[] {""} ;
         H00847_n692SerasaGrafia = new bool[] {false} ;
         H00847_A683SerasaHistoricoPagamentoPF = new bool[] {false} ;
         H00847_n683SerasaHistoricoPagamentoPF = new bool[] {false} ;
         H00847_A677SerasaMensagemRendaEstimada = new string[] {""} ;
         H00847_n677SerasaMensagemRendaEstimada = new bool[] {false} ;
         H00847_A687SerasaMensagemScore = new string[] {""} ;
         H00847_n687SerasaMensagemScore = new bool[] {false} ;
         H00847_A691SerasaNomeMae = new string[] {""} ;
         H00847_n691SerasaNomeMae = new bool[] {false} ;
         H00847_A663SerasaNumeroProposta = new string[] {""} ;
         H00847_n663SerasaNumeroProposta = new bool[] {false} ;
         H00847_A681SerasaParticipacaoSocietaria = new bool[] {false} ;
         H00847_n681SerasaParticipacaoSocietaria = new bool[] {false} ;
         H00847_A664SerasaPolitica = new decimal[1] ;
         H00847_n664SerasaPolitica = new bool[] {false} ;
         H00847_A673SerasaProtestoAtivo = new bool[] {false} ;
         H00847_n673SerasaProtestoAtivo = new bool[] {false} ;
         H00847_A670SerasaRecomendacaoVenda = new string[] {""} ;
         H00847_n670SerasaRecomendacaoVenda = new bool[] {false} ;
         H00847_A684SerasaRecomendaCompleto = new bool[] {false} ;
         H00847_n684SerasaRecomendaCompleto = new bool[] {false} ;
         H00847_A682SerasaRendaEstimada = new bool[] {false} ;
         H00847_n682SerasaRendaEstimada = new bool[] {false} ;
         H00847_A672SerasaRetricaoAtiva = new bool[] {false} ;
         H00847_n672SerasaRetricaoAtiva = new bool[] {false} ;
         H00847_A685SerasaScore = new short[1] ;
         H00847_n685SerasaScore = new bool[] {false} ;
         H00847_A688SerasaSituacaoCPF = new string[] {""} ;
         H00847_n688SerasaSituacaoCPF = new bool[] {false} ;
         H00847_A686SerasaTaxa = new decimal[1] ;
         H00847_n686SerasaTaxa = new bool[] {false} ;
         H00847_A669SerasaTipoRecomendacao = new string[] {""} ;
         H00847_n669SerasaTipoRecomendacao = new bool[] {false} ;
         H00847_A666SerasaTipoVenda = new string[] {""} ;
         H00847_n666SerasaTipoVenda = new bool[] {false} ;
         H00847_A675SerasaValorLimiteRecomendado = new decimal[1] ;
         H00847_n675SerasaValorLimiteRecomendado = new bool[] {false} ;
         H00847_A668SerasaCodNivelRisco = new decimal[1] ;
         H00847_n668SerasaCodNivelRisco = new bool[] {false} ;
         H00847_A775SerasaCountAcoes_F = new short[1] ;
         H00847_n775SerasaCountAcoes_F = new bool[] {false} ;
         H00847_A776SerasaCountEnderecos_F = new short[1] ;
         H00847_n776SerasaCountEnderecos_F = new bool[] {false} ;
         H00847_A777SerasaCountProtestos_F = new short[1] ;
         H00847_n777SerasaCountProtestos_F = new bool[] {false} ;
         H00847_A778SerasaCountOcorrencias_F = new short[1] ;
         H00847_n778SerasaCountOcorrencias_F = new bool[] {false} ;
         H00847_A779SerasaCountCheques_F = new short[1] ;
         H00847_n779SerasaCountCheques_F = new bool[] {false} ;
         A170ClienteRazaoSocial = "";
         A689SerasaDataNascimento = DateTime.MinValue;
         A690SerasaGenero = "";
         A692SerasaGrafia = "";
         A677SerasaMensagemRendaEstimada = "";
         A687SerasaMensagemScore = "";
         A691SerasaNomeMae = "";
         A663SerasaNumeroProposta = "";
         A670SerasaRecomendacaoVenda = "";
         A688SerasaSituacaoCPF = "";
         A669SerasaTipoRecomendacao = "";
         A666SerasaTipoVenda = "";
         sStyleString = "";
         lblSerasarecomendacaovenda_tags_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpconsultadetalhada__default(),
            new Object[][] {
                new Object[] {
               H00847_A168ClienteId, H00847_n168ClienteId, H00847_A662SerasaId, H00847_A170ClienteRazaoSocial, H00847_n170ClienteRazaoSocial, H00847_A678SerasaAnotacoesCompletas, H00847_n678SerasaAnotacoesCompletas, H00847_A680SerasaAnotacoesConsultaSPC, H00847_n680SerasaAnotacoesConsultaSPC, H00847_A674SerasaBaixoComprometimento,
               H00847_n674SerasaBaixoComprometimento, H00847_A679SerasaConsultasDetalhadas, H00847_n679SerasaConsultasDetalhadas, H00847_A671SerasaCpfRegular, H00847_n671SerasaCpfRegular, H00847_A689SerasaDataNascimento, H00847_n689SerasaDataNascimento, H00847_A676SerasaFaixaDeRendaEstimada, H00847_n676SerasaFaixaDeRendaEstimada, H00847_A690SerasaGenero,
               H00847_n690SerasaGenero, H00847_A692SerasaGrafia, H00847_n692SerasaGrafia, H00847_A683SerasaHistoricoPagamentoPF, H00847_n683SerasaHistoricoPagamentoPF, H00847_A677SerasaMensagemRendaEstimada, H00847_n677SerasaMensagemRendaEstimada, H00847_A687SerasaMensagemScore, H00847_n687SerasaMensagemScore, H00847_A691SerasaNomeMae,
               H00847_n691SerasaNomeMae, H00847_A663SerasaNumeroProposta, H00847_n663SerasaNumeroProposta, H00847_A681SerasaParticipacaoSocietaria, H00847_n681SerasaParticipacaoSocietaria, H00847_A664SerasaPolitica, H00847_n664SerasaPolitica, H00847_A673SerasaProtestoAtivo, H00847_n673SerasaProtestoAtivo, H00847_A670SerasaRecomendacaoVenda,
               H00847_n670SerasaRecomendacaoVenda, H00847_A684SerasaRecomendaCompleto, H00847_n684SerasaRecomendaCompleto, H00847_A682SerasaRendaEstimada, H00847_n682SerasaRendaEstimada, H00847_A672SerasaRetricaoAtiva, H00847_n672SerasaRetricaoAtiva, H00847_A685SerasaScore, H00847_n685SerasaScore, H00847_A688SerasaSituacaoCPF,
               H00847_n688SerasaSituacaoCPF, H00847_A686SerasaTaxa, H00847_n686SerasaTaxa, H00847_A669SerasaTipoRecomendacao, H00847_n669SerasaTipoRecomendacao, H00847_A666SerasaTipoVenda, H00847_n666SerasaTipoVenda, H00847_A675SerasaValorLimiteRecomendado, H00847_n675SerasaValorLimiteRecomendado, H00847_A668SerasaCodNivelRisco,
               H00847_n668SerasaCodNivelRisco, H00847_A775SerasaCountAcoes_F, H00847_n775SerasaCountAcoes_F, H00847_A776SerasaCountEnderecos_F, H00847_n776SerasaCountEnderecos_F, H00847_A777SerasaCountProtestos_F, H00847_n777SerasaCountProtestos_F, H00847_A778SerasaCountOcorrencias_F, H00847_n778SerasaCountOcorrencias_F, H00847_A779SerasaCountCheques_F,
               H00847_n779SerasaCountCheques_F
               }
            }
         );
         WebComp_Wcserasaenderecosww = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wcserasachequesww = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wcserasaacoesww = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wcserasaocorrenciasww = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wcserasaprotestosww = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
         edtavClienterazaosocial_Enabled = 0;
         edtavSerasanumeroproposta_Enabled = 0;
         cmbavSerasarecomendacaovenda.Enabled = 0;
         cmbavSerasacodnivelrisco.Enabled = 0;
         edtavSerasascore_Enabled = 0;
         edtavSerasamensagemscore_Enabled = 0;
         edtavSerasatipovenda_Enabled = 0;
         cmbavSerasapolitica.Enabled = 0;
         cmbavSerasabaixocomprometimento.Enabled = 0;
         cmbavSerasacpfregular.Enabled = 0;
         cmbavSerasaretricaoativa.Enabled = 0;
         edtavSerasadatanascimento_Enabled = 0;
         edtavSerasamensagemrendaestimada_Enabled = 0;
         edtavSerasasituacaocpf_Enabled = 0;
         cmbavSerasarecomendacompleto.Enabled = 0;
         edtavSerasanomemae_Enabled = 0;
         edtavSerasagenero_Enabled = 0;
         edtavSerasagrafia_Enabled = 0;
         cmbavSerasaparticipacaosocietaria.Enabled = 0;
         cmbavSerasaprotestoativo.Enabled = 0;
         cmbavSerasarendaestimada.Enabled = 0;
         edtavSerasavalorlimiterecomendado_Enabled = 0;
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV20SerasaScore ;
      private short nCmpId ;
      private short nDonePA ;
      private short A685SerasaScore ;
      private short A775SerasaCountAcoes_F ;
      private short A776SerasaCountEnderecos_F ;
      private short A777SerasaCountProtestos_F ;
      private short A778SerasaCountOcorrencias_F ;
      private short A779SerasaCountCheques_F ;
      private short AV34SerasaCountAcoes_F ;
      private short AV38SerasaCountEnderecos_F ;
      private short AV37SerasaCountProtestos_F ;
      private short AV36SerasaCountOcorrencias_F ;
      private short AV35SerasaCountCheques_F ;
      private short nGXWrapped ;
      private int AV32SerasaId ;
      private int wcpOAV32SerasaId ;
      private int edtavClienterazaosocial_Enabled ;
      private int edtavSerasanumeroproposta_Enabled ;
      private int edtavSerasascore_Enabled ;
      private int edtavSerasamensagemscore_Enabled ;
      private int edtavSerasatipovenda_Enabled ;
      private int edtavSerasadatanascimento_Enabled ;
      private int edtavSerasamensagemrendaestimada_Enabled ;
      private int edtavSerasasituacaocpf_Enabled ;
      private int edtavSerasanomemae_Enabled ;
      private int edtavSerasagenero_Enabled ;
      private int edtavSerasagrafia_Enabled ;
      private int edtavSerasavalorlimiterecomendado_Enabled ;
      private int edtavSerasatiporecomendacao_Visible ;
      private int edtavSerasafaixaderendaestimada_Visible ;
      private int edtavSerasataxa_Visible ;
      private int A168ClienteId ;
      private int A662SerasaId ;
      private int idxLst ;
      private decimal AV33SerasaCodNivelRisco ;
      private decimal AV9SerasaPolitica ;
      private decimal AV31SerasaValorLimiteRecomendado ;
      private decimal AV18SerasaFaixaDeRendaEstimada ;
      private decimal AV30SerasaTaxa ;
      private decimal A676SerasaFaixaDeRendaEstimada ;
      private decimal A664SerasaPolitica ;
      private decimal A686SerasaTaxa ;
      private decimal A675SerasaValorLimiteRecomendado ;
      private decimal A668SerasaCodNivelRisco ;
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
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string divTablecontent_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string edtavClienterazaosocial_Internalname ;
      private string edtavClienterazaosocial_Jsonclick ;
      private string edtavSerasanumeroproposta_Internalname ;
      private string edtavSerasanumeroproposta_Jsonclick ;
      private string divTablesplittedserasarecomendacaovenda_Internalname ;
      private string lblTextblockserasarecomendacaovenda_Internalname ;
      private string lblTextblockserasarecomendacaovenda_Jsonclick ;
      private string cmbavSerasacodnivelrisco_Internalname ;
      private string cmbavSerasacodnivelrisco_Jsonclick ;
      private string edtavSerasascore_Internalname ;
      private string edtavSerasascore_Jsonclick ;
      private string edtavSerasamensagemscore_Internalname ;
      private string edtavSerasatipovenda_Internalname ;
      private string edtavSerasatipovenda_Jsonclick ;
      private string cmbavSerasapolitica_Internalname ;
      private string cmbavSerasapolitica_Jsonclick ;
      private string cmbavSerasabaixocomprometimento_Internalname ;
      private string cmbavSerasabaixocomprometimento_Jsonclick ;
      private string cmbavSerasacpfregular_Internalname ;
      private string cmbavSerasacpfregular_Jsonclick ;
      private string cmbavSerasaretricaoativa_Internalname ;
      private string cmbavSerasaretricaoativa_Jsonclick ;
      private string edtavSerasadatanascimento_Internalname ;
      private string edtavSerasadatanascimento_Jsonclick ;
      private string edtavSerasamensagemrendaestimada_Internalname ;
      private string edtavSerasasituacaocpf_Internalname ;
      private string edtavSerasasituacaocpf_Jsonclick ;
      private string cmbavSerasarecomendacompleto_Internalname ;
      private string cmbavSerasarecomendacompleto_Jsonclick ;
      private string edtavSerasanomemae_Internalname ;
      private string edtavSerasanomemae_Jsonclick ;
      private string edtavSerasagenero_Internalname ;
      private string edtavSerasagenero_Jsonclick ;
      private string edtavSerasagrafia_Internalname ;
      private string edtavSerasagrafia_Jsonclick ;
      private string cmbavSerasaparticipacaosocietaria_Internalname ;
      private string cmbavSerasaparticipacaosocietaria_Jsonclick ;
      private string cmbavSerasaprotestoativo_Internalname ;
      private string cmbavSerasaprotestoativo_Jsonclick ;
      private string cmbavSerasarendaestimada_Internalname ;
      private string cmbavSerasarendaestimada_Jsonclick ;
      private string edtavSerasavalorlimiterecomendado_Internalname ;
      private string edtavSerasavalorlimiterecomendado_Jsonclick ;
      private string grpUnnamedgroup2_Internalname ;
      private string grpUnnamedgroup2_Class ;
      private string divTableenderecos_Internalname ;
      private string WebComp_Wcserasaenderecosww_Component ;
      private string OldWcserasaenderecosww ;
      private string grpUnnamedgroup3_Internalname ;
      private string grpUnnamedgroup3_Class ;
      private string divTablecheques_Internalname ;
      private string WebComp_Wcserasachequesww_Component ;
      private string OldWcserasachequesww ;
      private string grpUnnamedgroup4_Internalname ;
      private string grpUnnamedgroup4_Class ;
      private string divTableacoes_Internalname ;
      private string WebComp_Wcserasaacoesww_Component ;
      private string OldWcserasaacoesww ;
      private string grpUnnamedgroup5_Internalname ;
      private string grpUnnamedgroup5_Class ;
      private string divTableocorrencias_Internalname ;
      private string WebComp_Wcserasaocorrenciasww_Component ;
      private string OldWcserasaocorrenciasww ;
      private string grpUnnamedgroup6_Internalname ;
      private string grpUnnamedgroup6_Class ;
      private string divTableprotestos_Internalname ;
      private string WebComp_Wcserasaprotestosww_Component ;
      private string OldWcserasaprotestosww ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavSerasatiporecomendacao_Internalname ;
      private string edtavSerasatiporecomendacao_Jsonclick ;
      private string cmbavSerasaanotacoescompletas_Internalname ;
      private string cmbavSerasaanotacoescompletas_Jsonclick ;
      private string cmbavSerasaanotacoesconsultaspc_Internalname ;
      private string cmbavSerasaanotacoesconsultaspc_Jsonclick ;
      private string cmbavSerasaconsultasdetalhadas_Internalname ;
      private string cmbavSerasaconsultasdetalhadas_Jsonclick ;
      private string cmbavSerasahistoricopagamentopf_Internalname ;
      private string cmbavSerasahistoricopagamentopf_Jsonclick ;
      private string edtavSerasafaixaderendaestimada_Internalname ;
      private string edtavSerasafaixaderendaestimada_Jsonclick ;
      private string edtavSerasataxa_Internalname ;
      private string edtavSerasataxa_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string cmbavSerasarecomendacaovenda_Internalname ;
      private string hsh ;
      private string lblSerasarecomendacaovenda_tags_Caption ;
      private string lblSerasarecomendacaovenda_tags_Internalname ;
      private string sStyleString ;
      private string tblTablemergedserasarecomendacaovenda_Internalname ;
      private string cmbavSerasarecomendacaovenda_Jsonclick ;
      private string lblSerasarecomendacaovenda_tags_Jsonclick ;
      private DateTime AV17SerasaDataNascimento ;
      private DateTime A689SerasaDataNascimento ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool AV12SerasaBaixoComprometimento ;
      private bool AV14SerasaCpfRegular ;
      private bool AV15SerasaRetricaoAtiva ;
      private bool AV23SerasaRecomendaCompleto ;
      private bool AV27SerasaParticipacaoSocietaria ;
      private bool AV28SerasaProtestoAtivo ;
      private bool AV29SerasaRendaEstimada ;
      private bool AV10SerasaAnotacoesCompletas ;
      private bool AV11SerasaAnotacoesConsultaSPC ;
      private bool AV13SerasaConsultasDetalhadas ;
      private bool AV16SerasaHistoricoPagamentoPF ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n168ClienteId ;
      private bool n662SerasaId ;
      private bool n170ClienteRazaoSocial ;
      private bool A678SerasaAnotacoesCompletas ;
      private bool n678SerasaAnotacoesCompletas ;
      private bool A680SerasaAnotacoesConsultaSPC ;
      private bool n680SerasaAnotacoesConsultaSPC ;
      private bool A674SerasaBaixoComprometimento ;
      private bool n674SerasaBaixoComprometimento ;
      private bool A679SerasaConsultasDetalhadas ;
      private bool n679SerasaConsultasDetalhadas ;
      private bool A671SerasaCpfRegular ;
      private bool n671SerasaCpfRegular ;
      private bool n689SerasaDataNascimento ;
      private bool n676SerasaFaixaDeRendaEstimada ;
      private bool n690SerasaGenero ;
      private bool n692SerasaGrafia ;
      private bool A683SerasaHistoricoPagamentoPF ;
      private bool n683SerasaHistoricoPagamentoPF ;
      private bool n677SerasaMensagemRendaEstimada ;
      private bool n687SerasaMensagemScore ;
      private bool n691SerasaNomeMae ;
      private bool n663SerasaNumeroProposta ;
      private bool A681SerasaParticipacaoSocietaria ;
      private bool n681SerasaParticipacaoSocietaria ;
      private bool n664SerasaPolitica ;
      private bool A673SerasaProtestoAtivo ;
      private bool n673SerasaProtestoAtivo ;
      private bool n670SerasaRecomendacaoVenda ;
      private bool A684SerasaRecomendaCompleto ;
      private bool n684SerasaRecomendaCompleto ;
      private bool A682SerasaRendaEstimada ;
      private bool n682SerasaRendaEstimada ;
      private bool A672SerasaRetricaoAtiva ;
      private bool n672SerasaRetricaoAtiva ;
      private bool n685SerasaScore ;
      private bool n688SerasaSituacaoCPF ;
      private bool n686SerasaTaxa ;
      private bool n669SerasaTipoRecomendacao ;
      private bool n666SerasaTipoVenda ;
      private bool n675SerasaValorLimiteRecomendado ;
      private bool n668SerasaCodNivelRisco ;
      private bool n775SerasaCountAcoes_F ;
      private bool n776SerasaCountEnderecos_F ;
      private bool n777SerasaCountProtestos_F ;
      private bool n778SerasaCountOcorrencias_F ;
      private bool n779SerasaCountCheques_F ;
      private bool bDynCreated_Wcserasaprotestosww ;
      private bool bDynCreated_Wcserasaocorrenciasww ;
      private bool bDynCreated_Wcserasaacoesww ;
      private bool bDynCreated_Wcserasachequesww ;
      private bool bDynCreated_Wcserasaenderecosww ;
      private string AV6SerasaRecomendacaoVenda ;
      private string AV39ClienteRazaoSocial ;
      private string AV5SerasaNumeroProposta ;
      private string AV21SerasaMensagemScore ;
      private string AV8SerasaTipoVenda ;
      private string AV19SerasaMensagemRendaEstimada ;
      private string AV22SerasaSituacaoCPF ;
      private string AV24SerasaNomeMae ;
      private string AV25SerasaGenero ;
      private string AV26SerasaGrafia ;
      private string AV7SerasaTipoRecomendacao ;
      private string A170ClienteRazaoSocial ;
      private string A690SerasaGenero ;
      private string A692SerasaGrafia ;
      private string A677SerasaMensagemRendaEstimada ;
      private string A687SerasaMensagemScore ;
      private string A691SerasaNomeMae ;
      private string A663SerasaNumeroProposta ;
      private string A670SerasaRecomendacaoVenda ;
      private string A688SerasaSituacaoCPF ;
      private string A669SerasaTipoRecomendacao ;
      private string A666SerasaTipoVenda ;
      private GXWebComponent WebComp_Wcserasaenderecosww ;
      private GXWebComponent WebComp_Wcserasachequesww ;
      private GXWebComponent WebComp_Wcserasaacoesww ;
      private GXWebComponent WebComp_Wcserasaocorrenciasww ;
      private GXWebComponent WebComp_Wcserasaprotestosww ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavSerasarecomendacaovenda ;
      private GXCombobox cmbavSerasacodnivelrisco ;
      private GXCombobox cmbavSerasapolitica ;
      private GXCombobox cmbavSerasabaixocomprometimento ;
      private GXCombobox cmbavSerasacpfregular ;
      private GXCombobox cmbavSerasaretricaoativa ;
      private GXCombobox cmbavSerasarecomendacompleto ;
      private GXCombobox cmbavSerasaparticipacaosocietaria ;
      private GXCombobox cmbavSerasaprotestoativo ;
      private GXCombobox cmbavSerasarendaestimada ;
      private GXCombobox cmbavSerasaanotacoescompletas ;
      private GXCombobox cmbavSerasaanotacoesconsultaspc ;
      private GXCombobox cmbavSerasaconsultasdetalhadas ;
      private GXCombobox cmbavSerasahistoricopagamentopf ;
      private IDataStoreProvider pr_default ;
      private int[] H00847_A168ClienteId ;
      private bool[] H00847_n168ClienteId ;
      private int[] H00847_A662SerasaId ;
      private bool[] H00847_n662SerasaId ;
      private string[] H00847_A170ClienteRazaoSocial ;
      private bool[] H00847_n170ClienteRazaoSocial ;
      private bool[] H00847_A678SerasaAnotacoesCompletas ;
      private bool[] H00847_n678SerasaAnotacoesCompletas ;
      private bool[] H00847_A680SerasaAnotacoesConsultaSPC ;
      private bool[] H00847_n680SerasaAnotacoesConsultaSPC ;
      private bool[] H00847_A674SerasaBaixoComprometimento ;
      private bool[] H00847_n674SerasaBaixoComprometimento ;
      private bool[] H00847_A679SerasaConsultasDetalhadas ;
      private bool[] H00847_n679SerasaConsultasDetalhadas ;
      private bool[] H00847_A671SerasaCpfRegular ;
      private bool[] H00847_n671SerasaCpfRegular ;
      private DateTime[] H00847_A689SerasaDataNascimento ;
      private bool[] H00847_n689SerasaDataNascimento ;
      private decimal[] H00847_A676SerasaFaixaDeRendaEstimada ;
      private bool[] H00847_n676SerasaFaixaDeRendaEstimada ;
      private string[] H00847_A690SerasaGenero ;
      private bool[] H00847_n690SerasaGenero ;
      private string[] H00847_A692SerasaGrafia ;
      private bool[] H00847_n692SerasaGrafia ;
      private bool[] H00847_A683SerasaHistoricoPagamentoPF ;
      private bool[] H00847_n683SerasaHistoricoPagamentoPF ;
      private string[] H00847_A677SerasaMensagemRendaEstimada ;
      private bool[] H00847_n677SerasaMensagemRendaEstimada ;
      private string[] H00847_A687SerasaMensagemScore ;
      private bool[] H00847_n687SerasaMensagemScore ;
      private string[] H00847_A691SerasaNomeMae ;
      private bool[] H00847_n691SerasaNomeMae ;
      private string[] H00847_A663SerasaNumeroProposta ;
      private bool[] H00847_n663SerasaNumeroProposta ;
      private bool[] H00847_A681SerasaParticipacaoSocietaria ;
      private bool[] H00847_n681SerasaParticipacaoSocietaria ;
      private decimal[] H00847_A664SerasaPolitica ;
      private bool[] H00847_n664SerasaPolitica ;
      private bool[] H00847_A673SerasaProtestoAtivo ;
      private bool[] H00847_n673SerasaProtestoAtivo ;
      private string[] H00847_A670SerasaRecomendacaoVenda ;
      private bool[] H00847_n670SerasaRecomendacaoVenda ;
      private bool[] H00847_A684SerasaRecomendaCompleto ;
      private bool[] H00847_n684SerasaRecomendaCompleto ;
      private bool[] H00847_A682SerasaRendaEstimada ;
      private bool[] H00847_n682SerasaRendaEstimada ;
      private bool[] H00847_A672SerasaRetricaoAtiva ;
      private bool[] H00847_n672SerasaRetricaoAtiva ;
      private short[] H00847_A685SerasaScore ;
      private bool[] H00847_n685SerasaScore ;
      private string[] H00847_A688SerasaSituacaoCPF ;
      private bool[] H00847_n688SerasaSituacaoCPF ;
      private decimal[] H00847_A686SerasaTaxa ;
      private bool[] H00847_n686SerasaTaxa ;
      private string[] H00847_A669SerasaTipoRecomendacao ;
      private bool[] H00847_n669SerasaTipoRecomendacao ;
      private string[] H00847_A666SerasaTipoVenda ;
      private bool[] H00847_n666SerasaTipoVenda ;
      private decimal[] H00847_A675SerasaValorLimiteRecomendado ;
      private bool[] H00847_n675SerasaValorLimiteRecomendado ;
      private decimal[] H00847_A668SerasaCodNivelRisco ;
      private bool[] H00847_n668SerasaCodNivelRisco ;
      private short[] H00847_A775SerasaCountAcoes_F ;
      private bool[] H00847_n775SerasaCountAcoes_F ;
      private short[] H00847_A776SerasaCountEnderecos_F ;
      private bool[] H00847_n776SerasaCountEnderecos_F ;
      private short[] H00847_A777SerasaCountProtestos_F ;
      private bool[] H00847_n777SerasaCountProtestos_F ;
      private short[] H00847_A778SerasaCountOcorrencias_F ;
      private bool[] H00847_n778SerasaCountOcorrencias_F ;
      private short[] H00847_A779SerasaCountCheques_F ;
      private bool[] H00847_n779SerasaCountCheques_F ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpconsultadetalhada__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00847;
          prmH00847 = new Object[] {
          new ParDef("AV32SerasaId",GXType.Int32,9,0)
          };
          string cmdBufferH00847;
          cmdBufferH00847=" SELECT T1.ClienteId, T1.SerasaId, T2.ClienteRazaoSocial, T1.SerasaAnotacoesCompletas, T1.SerasaAnotacoesConsultaSPC, T1.SerasaBaixoComprometimento, T1.SerasaConsultasDetalhadas, T1.SerasaCpfRegular, T1.SerasaDataNascimento, T1.SerasaFaixaDeRendaEstimada, T1.SerasaGenero, T1.SerasaGrafia, T1.SerasaHistoricoPagamentoPF, T1.SerasaMensagemRendaEstimada, T1.SerasaMensagemScore, T1.SerasaNomeMae, T1.SerasaNumeroProposta, T1.SerasaParticipacaoSocietaria, T1.SerasaPolitica, T1.SerasaProtestoAtivo, T1.SerasaRecomendacaoVenda, T1.SerasaRecomendaCompleto, T1.SerasaRendaEstimada, T1.SerasaRetricaoAtiva, T1.SerasaScore, T1.SerasaSituacaoCPF, T1.SerasaTaxa, T1.SerasaTipoRecomendacao, T1.SerasaTipoVenda, T1.SerasaValorLimiteRecomendado, T1.SerasaCodNivelRisco, COALESCE( T3.SerasaCountAcoes_F, 0) AS SerasaCountAcoes_F, COALESCE( T4.SerasaCountEnderecos_F, 0) AS SerasaCountEnderecos_F, COALESCE( T5.SerasaCountProtestos_F, 0) AS SerasaCountProtestos_F, COALESCE( T6.SerasaCountOcorrencias_F, 0) AS SerasaCountOcorrencias_F, COALESCE( T7.SerasaCountCheques_F, 0) AS SerasaCountCheques_F FROM ((((((Serasa T1 LEFT JOIN Cliente T2 ON T2.ClienteId = T1.ClienteId) LEFT JOIN LATERAL (SELECT COUNT(*) AS SerasaCountAcoes_F, SerasaId FROM SerasaAcoes WHERE T1.SerasaId = SerasaId GROUP BY SerasaId ) T3 ON T3.SerasaId = T1.SerasaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS SerasaCountEnderecos_F, SerasaId FROM SerasaEnderecos WHERE T1.SerasaId = SerasaId GROUP BY SerasaId ) T4 ON T4.SerasaId = T1.SerasaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS SerasaCountProtestos_F, SerasaId FROM SerasaProtestos WHERE T1.SerasaId = SerasaId GROUP BY SerasaId ) T5 ON T5.SerasaId = T1.SerasaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS SerasaCountOcorrencias_F, SerasaId FROM SerasaOcorrencias WHERE T1.SerasaId = SerasaId GROUP "
          + " BY SerasaId ) T6 ON T6.SerasaId = T1.SerasaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS SerasaCountCheques_F, SerasaId FROM SerasaCheques WHERE T1.SerasaId = SerasaId GROUP BY SerasaId ) T7 ON T7.SerasaId = T1.SerasaId) WHERE T1.SerasaId = :AV32SerasaId ORDER BY T1.SerasaId" ;
          def= new CursorDef[] {
              new CursorDef("H00847", cmdBufferH00847,false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00847,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((bool[]) buf[11])[0] = rslt.getBool(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((bool[]) buf[23])[0] = rslt.getBool(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((bool[]) buf[33])[0] = rslt.getBool(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((decimal[]) buf[35])[0] = rslt.getDecimal(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((bool[]) buf[37])[0] = rslt.getBool(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((bool[]) buf[41])[0] = rslt.getBool(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((bool[]) buf[43])[0] = rslt.getBool(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((bool[]) buf[45])[0] = rslt.getBool(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((short[]) buf[47])[0] = rslt.getShort(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((string[]) buf[49])[0] = rslt.getVarchar(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((decimal[]) buf[51])[0] = rslt.getDecimal(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((string[]) buf[53])[0] = rslt.getVarchar(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((string[]) buf[55])[0] = rslt.getVarchar(29);
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((decimal[]) buf[57])[0] = rslt.getDecimal(30);
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                ((decimal[]) buf[59])[0] = rslt.getDecimal(31);
                ((bool[]) buf[60])[0] = rslt.wasNull(31);
                ((short[]) buf[61])[0] = rslt.getShort(32);
                ((bool[]) buf[62])[0] = rslt.wasNull(32);
                ((short[]) buf[63])[0] = rslt.getShort(33);
                ((bool[]) buf[64])[0] = rslt.wasNull(33);
                ((short[]) buf[65])[0] = rslt.getShort(34);
                ((bool[]) buf[66])[0] = rslt.wasNull(34);
                ((short[]) buf[67])[0] = rslt.getShort(35);
                ((bool[]) buf[68])[0] = rslt.wasNull(35);
                ((short[]) buf[69])[0] = rslt.getShort(36);
                ((bool[]) buf[70])[0] = rslt.wasNull(36);
                return;
       }
    }

 }

}
