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
namespace GeneXus.Programs.costumer {
   public class home : GXDataArea
   {
      public home( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public home( IGxContext context )
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
         radavPeriodo = new GXRadio();
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.masterpagepfpj", "GeneXus.Programs.wwpbaseobjects.masterpagepfpj", new Object[] {context});
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
         PA902( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START902( ) ;
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
         context.AddJavascriptSource("UserControls/UCCardLimCredRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/UcVisaoGeralVendasRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("costumer.home") +"\">") ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "UCCREDITO_Percent_size", StringUtil.RTrim( Uccredito_Percent_size));
         GxWebStd.gx_hidden_field( context, "UCCREDITO_Available_amount", StringUtil.RTrim( Uccredito_Available_amount));
         GxWebStd.gx_hidden_field( context, "UCCREDITO_Of_amount", StringUtil.RTrim( Uccredito_Of_amount));
         GxWebStd.gx_hidden_field( context, "UCCREDITO_Used_amount", StringUtil.RTrim( Uccredito_Used_amount));
         GxWebStd.gx_hidden_field( context, "UCCREDITO_Percent", StringUtil.RTrim( Uccredito_Percent));
         GxWebStd.gx_hidden_field( context, "UCVENDAGERAL_Monthly_data", StringUtil.RTrim( Ucvendageral_Monthly_data));
         GxWebStd.gx_hidden_field( context, "UCVENDAGERAL_Weekly_data", StringUtil.RTrim( Ucvendageral_Weekly_data));
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
            WE902( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT902( ) ;
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
         return formatLink("costumer.home")  ;
      }

      public override string GetPgmname( )
      {
         return "Costumer.home" ;
      }

      public override string GetPgmdesc( )
      {
         return "Home" ;
      }

      protected void WB900( )
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 col-md-4", "start", "top", "", "", "div");
            /* User Defined Control */
            ucUccredito.Render(context, "uccardlimcred", Uccredito_Internalname, "UCCREDITOContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 col-md-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesalescard_Internalname, 1, 0, "px", 0, "px", "card-dashboard", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesalescardheader_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "justify-content:space-around;align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTxtheadersales_Internalname, "<h3 style=\"font-size: 1.25rem;color: #333;margin: 0;\">Visão Geral de Vendas</h3>", "", "", lblTxtheadersales_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_Costumer/home.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;align-self:flex-end;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", "Periodo", "gx-form-item AttributeFLLabel", 0, true, "width: 25%;");
            /* Radio button */
            ClassString = "AttributeFL";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            GxWebStd.gx_radio_ctrl( context, radavPeriodo, radavPeriodo_Internalname, StringUtil.RTrim( AV36Periodo), "", 1, 1, 0, 0, StyleString, ClassString, "", "", 0, radavPeriodo_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", TempTags+" onclick="+"\""+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,19);\"", "HLP_Costumer/home.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucUcvendageral.Render(context, "ucvisaogeralvendas", Ucvendageral_Internalname, "UCVENDAGERALContainer");
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
         }
         wbLoad = true;
      }

      protected void START902( )
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
         Form.Meta.addItem("description", "Home", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP900( ) ;
      }

      protected void WS902( )
      {
         START902( ) ;
         EVT902( ) ;
      }

      protected void EVT902( )
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
                              E11902 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E12902 ();
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

      protected void WE902( )
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

      protected void PA902( )
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
               GX_FocusControl = radavPeriodo_Internalname;
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
         AssignAttri("", false, "AV36Periodo", AV36Periodo);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF902( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF902( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E12902 ();
            WB900( ) ;
         }
      }

      protected void send_integrity_lvl_hashes902( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP900( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11902 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Uccredito_Percent_size = cgiGet( "UCCREDITO_Percent_size");
            Uccredito_Available_amount = cgiGet( "UCCREDITO_Available_amount");
            Uccredito_Of_amount = cgiGet( "UCCREDITO_Of_amount");
            Uccredito_Used_amount = cgiGet( "UCCREDITO_Used_amount");
            Uccredito_Percent = cgiGet( "UCCREDITO_Percent");
            Ucvendageral_Monthly_data = cgiGet( "UCVENDAGERAL_Monthly_data");
            Ucvendageral_Weekly_data = cgiGet( "UCVENDAGERAL_Weekly_data");
            /* Read variables values. */
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
         E11902 ();
         if (returnInSub) return;
      }

      protected void E11902( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtWWPContext1 = AV31WWPContext;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  GXt_SdtWWPContext1) ;
         AV31WWPContext = GXt_SdtWWPContext1;
         /* Using cursor H00902 */
         pr_default.execute(0, new Object[] {AV31WWPContext.gxTpr_Ownerid});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A168ClienteId = H00902_A168ClienteId[0];
            n168ClienteId = H00902_n168ClienteId[0];
            A857CreditoValor = H00902_A857CreditoValor[0];
            n857CreditoValor = H00902_n857CreditoValor[0];
            A858CreditoVigencia = H00902_A858CreditoVigencia[0];
            n858CreditoVigencia = H00902_n858CreditoVigencia[0];
            AV32CreditoValor = A857CreditoValor;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV33UtilizadoValor = (decimal)(100);
         AV34AvailableValor = (decimal)(AV32CreditoValor-AV33UtilizadoValor);
         Uccredito_Available_amount = context.localUtil.Format( AV34AvailableValor, "ZZZ,ZZZ,ZZZ,ZZ9.99");
         ucUccredito.SendProperty(context, "", false, Uccredito_Internalname, "available_amount", Uccredito_Available_amount);
         Uccredito_Of_amount = context.localUtil.Format( AV32CreditoValor, "ZZZ,ZZZ,ZZZ,ZZ9.99");
         ucUccredito.SendProperty(context, "", false, Uccredito_Internalname, "of_amount", Uccredito_Of_amount);
         Uccredito_Used_amount = context.localUtil.Format( AV33UtilizadoValor, "ZZZ,ZZZ,ZZZ,ZZ9.99");
         ucUccredito.SendProperty(context, "", false, Uccredito_Internalname, "used_amount", Uccredito_Used_amount);
         if ( ! (Convert.ToDecimal(0)==AV33UtilizadoValor) )
         {
            AV35Percentual = (decimal)((AV33UtilizadoValor/ (decimal)(AV32CreditoValor))*100);
            Uccredito_Percent = context.localUtil.Format( AV35Percentual, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%");
            ucUccredito.SendProperty(context, "", false, Uccredito_Internalname, "percent", Uccredito_Percent);
            Uccredito_Percent_size = StringUtil.StringReplace( StringUtil.Str( AV35Percentual, 16, 4), ",", ".");
            ucUccredito.SendProperty(context, "", false, Uccredito_Internalname, "percent_size", Uccredito_Percent_size);
         }
         else
         {
            AV35Percentual = 0;
            Uccredito_Percent = StringUtil.Str( AV35Percentual, 16, 4);
            ucUccredito.SendProperty(context, "", false, Uccredito_Internalname, "percent", Uccredito_Percent);
            Uccredito_Percent_size = StringUtil.StringReplace( StringUtil.Str( AV35Percentual, 16, 4), ",", ".");
            ucUccredito.SendProperty(context, "", false, Uccredito_Internalname, "percent_size", Uccredito_Percent_size);
         }
         AV36Periodo = "mensal";
         AssignAttri("", false, "AV36Periodo", AV36Periodo);
         Ucvendageral_Monthly_data = "[{ label: \"Jan\", sold: 900, returned: 5 },{ label: \"Fev\", sold: 70, returned: 8 },{ label: \"Mar\", sold: 75, returned: 10 },{ label: \"Abr\", sold: 80, returned: 12 },{ label: \"Mai\", sold: 50, returned: 7 },{ label: \"Jun\", sold: 40, returned: 5 }]";
         ucUcvendageral.SendProperty(context, "", false, Ucvendageral_Internalname, "monthly_data", Ucvendageral_Monthly_data);
         Ucvendageral_Weekly_data = "[ { label: \"Semana 1\", sold: 25, returned: 3 }, { label: \"Semana 2\", sold: 30, returned: 4 }, { label: \"Semana 3\", sold: 35, returned: 5 }, { label: \"Semana 4\", sold: 20, returned: 2 }]";
         ucUcvendageral.SendProperty(context, "", false, Ucvendageral_Internalname, "weekly_data", Ucvendageral_Weekly_data);
         this.executeUsercontrolMethod("", false, "UCVENDAGERALContainer", "ChangeView", "", new Object[] {(string)AV36Periodo});
      }

      protected void nextLoad( )
      {
      }

      protected void E12902( )
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
         PA902( ) ;
         WS902( ) ;
         WE902( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019251135", true, true);
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
         context.AddJavascriptSource("costumer/home.js", "?202561019251135", false, true);
         context.AddJavascriptSource("UserControls/UCCardLimCredRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/UcVisaoGeralVendasRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         radavPeriodo.Name = "vPERIODO";
         radavPeriodo.WebTags = "";
         radavPeriodo.addItem("mensal", "Mensal", 0);
         radavPeriodo.addItem("semanal", "Semanal", 0);
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         Uccredito_Internalname = "UCCREDITO";
         lblTxtheadersales_Internalname = "TXTHEADERSALES";
         radavPeriodo_Internalname = "vPERIODO";
         divTablesalescardheader_Internalname = "TABLESALESCARDHEADER";
         Ucvendageral_Internalname = "UCVENDAGERAL";
         divTablesalescard_Internalname = "TABLESALESCARD";
         divTablemain_Internalname = "TABLEMAIN";
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
         radavPeriodo_Jsonclick = "";
         Ucvendageral_Weekly_data = "";
         Ucvendageral_Monthly_data = "";
         Uccredito_Percent = "";
         Uccredito_Used_amount = "";
         Uccredito_Of_amount = "";
         Uccredito_Available_amount = "";
         Uccredito_Percent_size = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Home";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"radavPeriodo"},{"av":"AV36Periodo","fld":"vPERIODO","type":"svchar"}]}""");
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
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ucUccredito = new GXUserControl();
         lblTxtheadersales_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV36Periodo = "";
         ucUcvendageral = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV31WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtWWPContext1 = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         H00902_A856CreditoId = new int[1] ;
         H00902_A168ClienteId = new int[1] ;
         H00902_n168ClienteId = new bool[] {false} ;
         H00902_A857CreditoValor = new decimal[1] ;
         H00902_n857CreditoValor = new bool[] {false} ;
         H00902_A858CreditoVigencia = new DateTime[] {DateTime.MinValue} ;
         H00902_n858CreditoVigencia = new bool[] {false} ;
         A858CreditoVigencia = DateTime.MinValue;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.costumer.home__default(),
            new Object[][] {
                new Object[] {
               H00902_A856CreditoId, H00902_A168ClienteId, H00902_n168ClienteId, H00902_A857CreditoValor, H00902_n857CreditoValor, H00902_A858CreditoVigencia, H00902_n858CreditoVigencia
               }
            }
         );
         /* GeneXus formulas. */
      }

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
      private int A168ClienteId ;
      private int idxLst ;
      private decimal A857CreditoValor ;
      private decimal AV32CreditoValor ;
      private decimal AV33UtilizadoValor ;
      private decimal AV34AvailableValor ;
      private decimal AV35Percentual ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Uccredito_Percent_size ;
      private string Uccredito_Available_amount ;
      private string Uccredito_Of_amount ;
      private string Uccredito_Used_amount ;
      private string Uccredito_Percent ;
      private string Ucvendageral_Monthly_data ;
      private string Ucvendageral_Weekly_data ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string Uccredito_Internalname ;
      private string divTablesalescard_Internalname ;
      private string divTablesalescardheader_Internalname ;
      private string lblTxtheadersales_Internalname ;
      private string lblTxtheadersales_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string TempTags ;
      private string radavPeriodo_Internalname ;
      private string radavPeriodo_Jsonclick ;
      private string Ucvendageral_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private DateTime A858CreditoVigencia ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n168ClienteId ;
      private bool n857CreditoValor ;
      private bool n858CreditoVigencia ;
      private string AV36Periodo ;
      private GXUserControl ucUccredito ;
      private GXUserControl ucUcvendageral ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXRadio radavPeriodo ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV31WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext GXt_SdtWWPContext1 ;
      private IDataStoreProvider pr_default ;
      private int[] H00902_A856CreditoId ;
      private int[] H00902_A168ClienteId ;
      private bool[] H00902_n168ClienteId ;
      private decimal[] H00902_A857CreditoValor ;
      private bool[] H00902_n857CreditoValor ;
      private DateTime[] H00902_A858CreditoVigencia ;
      private bool[] H00902_n858CreditoVigencia ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class home__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00902;
          prmH00902 = new Object[] {
          new ParDef("AV31WWPContext__Ownerid",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00902", "SELECT CreditoId, ClienteId, CreditoValor, CreditoVigencia FROM Credito WHERE ClienteId = :AV31WWPContext__Ownerid ORDER BY CreditoVigencia DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00902,1, GxCacheFrequency.OFF ,false,true )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
       }
    }

 }

}
