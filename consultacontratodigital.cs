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
   public class consultacontratodigital : GXDataArea
   {
      public consultacontratodigital( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public consultacontratodigital( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
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
            gxfirstwebparm = GetNextPar( );
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
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpageempty", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpageempty", new Object[] {context});
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
         PA592( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START592( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("consultacontratodigital") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vAHASH", AV13AHash);
         GxWebStd.gx_hidden_field( context, "gxhash_vAHASH", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV13AHash, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "ASSINATURATOKEN", A365AssinaturaToken);
         GxWebStd.gx_hidden_field( context, "ASSINATURAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A238AssinaturaId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vAHASH", AV13AHash);
         GxWebStd.gx_hidden_field( context, "gxhash_vAHASH", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV13AHash, "")), context));
         GXCCtlgxBlob = "vBLOB" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, AV6Blob);
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
            WE592( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT592( ) ;
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
         return formatLink("consultacontratodigital")  ;
      }

      public override string GetPgmname( )
      {
         return "ConsultaContratoDigital" ;
      }

      public override string GetPgmdesc( )
      {
         return "Consulta Contrato Digital" ;
      }

      protected void WB590( )
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
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;justify-content:center;align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbldigitalvalidator_Internalname, "<h1>Validador do contrato</h1>", "", "", lblLbldigitalvalidator_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_ConsultaContratoDigital.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcarregarcontrato_Internalname, "<h3>Carregar contrato assinado</h3>", "", "", lblLblcarregarcontrato_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_ConsultaContratoDigital.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblButtonupload_Internalname, lblButtonupload_Caption, "", "", lblButtonupload_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_ConsultaContratoDigital.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblhash_Internalname, "<h3>Carregar com hash</h3>", "", "", lblLblhash_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_ConsultaContratoDigital.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCellFL", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavHash_Internalname, "Hash", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavHash_Internalname, AV7Hash, StringUtil.RTrim( context.localUtil.Format( AV7Hash, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,23);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavHash_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavHash_Enabled, 0, "text", "", 80, "chr", 1, "row", 102, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_ConsultaContratoDigital.htm");
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
            ClassString = "Image";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
            edtavBlob_Filetype = "tmp";
            AssignProp("", false, edtavBlob_Internalname, "Filetype", edtavBlob_Filetype, true);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV6Blob)) )
            {
               gxblobfileaux.Source = AV6Blob;
               if ( ! gxblobfileaux.HasExtension() || ( StringUtil.StrCmp(edtavBlob_Filetype, "tmp") != 0 ) )
               {
                  gxblobfileaux.SetExtension(StringUtil.Trim( edtavBlob_Filetype));
               }
               if ( gxblobfileaux.ErrCode == 0 )
               {
                  AV6Blob = gxblobfileaux.GetURI();
                  AssignProp("", false, edtavBlob_Internalname, "URL", context.PathToRelativeUrl( AV6Blob), true);
                  edtavBlob_Filetype = gxblobfileaux.GetExtension();
                  AssignProp("", false, edtavBlob_Internalname, "Filetype", edtavBlob_Filetype, true);
               }
               AssignProp("", false, edtavBlob_Internalname, "URL", context.PathToRelativeUrl( AV6Blob), true);
            }
            GxWebStd.gx_blob_field( context, edtavBlob_Internalname, StringUtil.RTrim( AV6Blob), context.PathToRelativeUrl( AV6Blob), (String.IsNullOrEmpty(StringUtil.RTrim( edtavBlob_Contenttype)) ? context.GetContentType( (String.IsNullOrEmpty(StringUtil.RTrim( edtavBlob_Filetype)) ? AV6Blob : edtavBlob_Filetype)) : edtavBlob_Contenttype), false, "", edtavBlob_Parameters, 0, 1, edtavBlob_Visible, "", "", 0, -1, 250, "px", 60, "px", 0, 0, 0, edtavBlob_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", StyleString, ClassString, "", "", ""+TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "", "", "HLP_ConsultaContratoDigital.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START592( )
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
         Form.Meta.addItem("description", "Consulta Contrato Digital", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP590( ) ;
      }

      protected void WS592( )
      {
         START592( ) ;
         EVT592( ) ;
      }

      protected void EVT592( )
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
                              E11592 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VBLOB.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E12592 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VHASH.CONTROLVALUECHANGING") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E13592 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E14592 ();
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
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE592( )
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

      protected void PA592( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
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
               GX_FocusControl = edtavHash_Internalname;
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF592( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF592( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E14592 ();
            WB590( ) ;
         }
      }

      protected void send_integrity_lvl_hashes592( )
      {
         GxWebStd.gx_hidden_field( context, "vAHASH", AV13AHash);
         GxWebStd.gx_hidden_field( context, "gxhash_vAHASH", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV13AHash, "")), context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP590( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11592 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV6Blob)) )
            {
               GXCCtlgxBlob = "vBLOB" + "_gxBlob";
               AV6Blob = cgiGet( GXCCtlgxBlob);
            }
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
         E11592 ();
         if (returnInSub) return;
      }

      protected void E11592( )
      {
         /* Start Routine */
         returnInSub = false;
         edtavBlob_Visible = 0;
         AssignProp("", false, edtavBlob_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBlob_Visible), 5, 0), true);
         lblButtonupload_Caption = StringUtil.Format( "<label for=\"%1\" style=\"background: #28a745; display: inline-block; padding: 10px 20px; color: white; border: none; border-radius: 4px; cursor: pointer; font-size: 16px; transition: background-color 0.3s ease;\"onmouseover=\"this.style.backgroundColor=", edtavBlob_Internalname, "", "", "", "", "", "", "", "")+"'"+"#218838"+"'"+";\" onmouseout=\"this.style.backgroundColor="+"'"+"#28a745"+"'"+";\"onmousedown=\"this.style.backgroundColor="+"'"+"#1e7e34"+"'"+";\"onmouseup=\"this.style.backgroundColor="+"'"+"#218838"+"'"+";\"><i class=\"fa-solid fa-upload\"></i> Escolher arquivo</label>";
         AssignProp("", false, lblButtonupload_Internalname, "Caption", lblButtonupload_Caption, true);
      }

      protected void E12592( )
      {
         /* Blob_Controlvaluechanged Routine */
         returnInSub = false;
         AV9checksum = AV10ChecksumCreator.generatechecksum(context.FileToBase64( AV6Blob), "BASE64", "SHA256");
         GXt_char1 = AV11Chave;
         new prchave(context ).execute( out  GXt_char1) ;
         AV11Chave = GXt_char1;
         AV12AssinaturaToken = AV9checksum;
         AssignAttri("", false, "AV12AssinaturaToken", AV12AssinaturaToken);
         /* Using cursor H00592 */
         pr_default.execute(0, new Object[] {AV12AssinaturaToken});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A365AssinaturaToken = H00592_A365AssinaturaToken[0];
            n365AssinaturaToken = H00592_n365AssinaturaToken[0];
            A238AssinaturaId = H00592_A238AssinaturaId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "verify"+UrlEncode(StringUtil.LTrimStr(A238AssinaturaId,10,0));
            CallWebObject(formatLink("verify") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /*  Sending Event outputs  */
      }

      protected void E13592( )
      {
         /* Hash_Controlvaluechanging Routine */
         returnInSub = false;
         AV8AuxHash = AV7Hash;
         AssignAttri("", false, "AV8AuxHash", AV8AuxHash);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8AuxHash)) )
         {
            /* Using cursor H00593 */
            pr_default.execute(1, new Object[] {AV8AuxHash});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A365AssinaturaToken = H00593_A365AssinaturaToken[0];
               n365AssinaturaToken = H00593_n365AssinaturaToken[0];
               A238AssinaturaId = H00593_A238AssinaturaId[0];
               if ( StringUtil.Len( AV7Hash) == 64 )
               {
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
                  {
                     gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
                  }
                  GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
                  GXEncryptionTmp = "verify"+UrlEncode(StringUtil.LTrimStr(A238AssinaturaId,10,0));
                  CallWebObject(formatLink("verify") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
                  context.wjLocDisableFrm = 1;
               }
               pr_default.readNext(1);
            }
            pr_default.close(1);
         }
         /*  Sending Event outputs  */
      }

      protected void nextLoad( )
      {
      }

      protected void E14592( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
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
         PA592( ) ;
         WS592( ) ;
         WE592( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025610192531", true, true);
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
         context.AddJavascriptSource("consultacontratodigital.js", "?2025610192531", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblLbldigitalvalidator_Internalname = "LBLDIGITALVALIDATOR";
         lblLblcarregarcontrato_Internalname = "LBLCARREGARCONTRATO";
         lblButtonupload_Internalname = "BUTTONUPLOAD";
         lblLblhash_Internalname = "LBLHASH";
         edtavHash_Internalname = "vHASH";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         edtavBlob_Internalname = "vBLOB";
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
         edtavBlob_Jsonclick = "";
         edtavBlob_Parameters = "";
         edtavBlob_Contenttype = "";
         edtavBlob_Filetype = "";
         edtavBlob_Visible = 1;
         edtavHash_Jsonclick = "";
         edtavHash_Enabled = 1;
         lblButtonupload_Caption = "<label style=\"background: #28a745; display: inline-block; padding: 10px 20px; color: white; border: none; border-radius: 4px; cursor: pointer; font-size: 16px; transition: background-color 0.3s ease;\"onmouseover=\"this.style.backgroundColor='#218838';\" onmouseout=\"this.style.backgroundColor='#28a745';\"onmousedown=\"this.style.backgroundColor='#1e7e34';\"onmouseup=\"this.style.backgroundColor='#218838';\"><i class=\"fa-solid fa-upload\"></i> Escolher arquivo</label>";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Consulta Contrato Digital";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV13AHash","fld":"vAHASH","hsh":true,"type":"svchar"}]}""");
         setEventMetadata("VBLOB.CONTROLVALUECHANGED","""{"handler":"E12592","iparms":[{"av":"AV6Blob","fld":"vBLOB","type":"bitstr"},{"av":"A365AssinaturaToken","fld":"ASSINATURATOKEN","type":"svchar"},{"av":"A238AssinaturaId","fld":"ASSINATURAID","pic":"ZZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("VBLOB.CONTROLVALUECHANGED",""","oparms":[{"av":"AV12AssinaturaToken","fld":"vASSINATURATOKEN","type":"svchar"}]}""");
         setEventMetadata("VHASH.CONTROLVALUECHANGING","""{"handler":"E13592","iparms":[{"av":"AV13AHash","fld":"vAHASH","hsh":true,"type":"svchar"},{"av":"AV7Hash","fld":"vHASH","type":"svchar"},{"av":"A365AssinaturaToken","fld":"ASSINATURATOKEN","type":"svchar"},{"av":"A238AssinaturaId","fld":"ASSINATURAID","pic":"ZZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("VHASH.CONTROLVALUECHANGING",""","oparms":[{"av":"AV8AuxHash","fld":"vAUXHASH","type":"svchar"}]}""");
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
         AV13AHash = "";
         GXKey = "";
         A365AssinaturaToken = "";
         GXCCtlgxBlob = "";
         AV6Blob = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         lblLbldigitalvalidator_Jsonclick = "";
         lblLblcarregarcontrato_Jsonclick = "";
         lblButtonupload_Jsonclick = "";
         lblLblhash_Jsonclick = "";
         TempTags = "";
         AV7Hash = "";
         gxblobfileaux = new GxFile(context.GetPhysicalPath());
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV9checksum = "";
         AV10ChecksumCreator = new GeneXus.Programs.genexuscryptography.SdtChecksumCreator(context);
         AV11Chave = "";
         GXt_char1 = "";
         AV12AssinaturaToken = "";
         H00592_A365AssinaturaToken = new string[] {""} ;
         H00592_n365AssinaturaToken = new bool[] {false} ;
         H00592_A238AssinaturaId = new long[1] ;
         GXEncryptionTmp = "";
         AV8AuxHash = "";
         H00593_A365AssinaturaToken = new string[] {""} ;
         H00593_n365AssinaturaToken = new bool[] {false} ;
         H00593_A238AssinaturaId = new long[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.consultacontratodigital__default(),
            new Object[][] {
                new Object[] {
               H00592_A365AssinaturaToken, H00592_n365AssinaturaToken, H00592_A238AssinaturaId
               }
               , new Object[] {
               H00593_A365AssinaturaToken, H00593_n365AssinaturaToken, H00593_A238AssinaturaId
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
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavHash_Enabled ;
      private int edtavBlob_Visible ;
      private int idxLst ;
      private long A238AssinaturaId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXCCtlgxBlob ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string lblLbldigitalvalidator_Internalname ;
      private string lblLbldigitalvalidator_Jsonclick ;
      private string lblLblcarregarcontrato_Internalname ;
      private string lblLblcarregarcontrato_Jsonclick ;
      private string lblButtonupload_Internalname ;
      private string lblButtonupload_Caption ;
      private string lblButtonupload_Jsonclick ;
      private string lblLblhash_Internalname ;
      private string lblLblhash_Jsonclick ;
      private string edtavHash_Internalname ;
      private string TempTags ;
      private string edtavHash_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavBlob_Filetype ;
      private string edtavBlob_Internalname ;
      private string edtavBlob_Contenttype ;
      private string edtavBlob_Parameters ;
      private string edtavBlob_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXt_char1 ;
      private string GXEncryptionTmp ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n365AssinaturaToken ;
      private string AV13AHash ;
      private string A365AssinaturaToken ;
      private string AV7Hash ;
      private string AV9checksum ;
      private string AV11Chave ;
      private string AV12AssinaturaToken ;
      private string AV8AuxHash ;
      private string AV6Blob ;
      private GxFile gxblobfileaux ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.genexuscryptography.SdtChecksumCreator AV10ChecksumCreator ;
      private IDataStoreProvider pr_default ;
      private string[] H00592_A365AssinaturaToken ;
      private bool[] H00592_n365AssinaturaToken ;
      private long[] H00592_A238AssinaturaId ;
      private string[] H00593_A365AssinaturaToken ;
      private bool[] H00593_n365AssinaturaToken ;
      private long[] H00593_A238AssinaturaId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class consultacontratodigital__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00592;
          prmH00592 = new Object[] {
          new ParDef("AV12AssinaturaToken",GXType.VarChar,512,0)
          };
          Object[] prmH00593;
          prmH00593 = new Object[] {
          new ParDef("AV8AuxHash",GXType.VarChar,256,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00592", "SELECT AssinaturaToken, AssinaturaId FROM Assinatura WHERE AssinaturaToken = ( :AV12AssinaturaToken) ORDER BY AssinaturaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00592,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00593", "SELECT AssinaturaToken, AssinaturaId FROM Assinatura WHERE AssinaturaToken = ( :AV8AuxHash) ORDER BY AssinaturaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00593,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                return;
       }
    }

 }

}
