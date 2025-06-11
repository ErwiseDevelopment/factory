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
namespace GeneXus.Programs.wwpbaseobjects {
   public class wwp_wcmodules : GXWebComponent
   {
      public wwp_wcmodules( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
      }

      public wwp_wcmodules( IGxContext context )
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

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridhomemodulessdts") == 0 )
               {
                  gxnrGridhomemodulessdts_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridhomemodulessdts") == 0 )
               {
                  gxgrGridhomemodulessdts_refresh_invoke( ) ;
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
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      protected void gxnrGridhomemodulessdts_newrow_invoke( )
      {
         nRC_GXsfl_12 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_12"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_12_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_12_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_12_idx = GetPar( "sGXsfl_12_idx");
         sPrefix = GetPar( "sPrefix");
         edtavOptionlink_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavOptionlink_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOptionlink_Visible), 5, 0), !bGXsfl_12_Refreshing);
         edtavSistema_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavSistema_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSistema_Visible), 5, 0), !bGXsfl_12_Refreshing);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridhomemodulessdts_newrow( ) ;
         /* End function gxnrGridhomemodulessdts_newrow_invoke */
      }

      protected void gxgrGridhomemodulessdts_refresh_invoke( )
      {
         edtavOptionlink_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavOptionlink_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOptionlink_Visible), 5, 0), !bGXsfl_12_Refreshing);
         edtavSistema_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavSistema_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSistema_Visible), 5, 0), !bGXsfl_12_Refreshing);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV5HomeModulesSDT);
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridhomemodulessdts_refresh( AV5HomeModulesSDT, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridhomemodulessdts_refresh_invoke */
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA092( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavOptiontitle_Enabled = 0;
               AssignProp(sPrefix, false, edtavOptiontitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOptiontitle_Enabled), 5, 0), !bGXsfl_12_Refreshing);
               WS092( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( "WWP_WCModules") ;
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
         }
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
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
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.wwp_wcmodules") +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vHOMEMODULESSDT", AV5HomeModulesSDT);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vHOMEMODULESSDT", AV5HomeModulesSDT);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHOMEMODULESSDT", GetSecureSignedToken( sPrefix, AV5HomeModulesSDT, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_12", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_12), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vHOMEMODULESSDT", AV5HomeModulesSDT);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vHOMEMODULESSDT", AV5HomeModulesSDT);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHOMEMODULESSDT", GetSecureSignedToken( sPrefix, AV5HomeModulesSDT, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"subGridhomemodulessdts_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridhomemodulessdts_Recordcount), 5, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDHOMEMODULESSDTS_Class", StringUtil.RTrim( subGridhomemodulessdts_Class));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDHOMEMODULESSDTS_Flexwrap", StringUtil.RTrim( subGridhomemodulessdts_Flexwrap));
         GxWebStd.gx_hidden_field( context, sPrefix+"vOPTIONLINK_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavOptionlink_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSISTEMA_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSistema_Visible), 5, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm092( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            if ( ! ( WebComp_Layoutprogressbarwc == null ) )
            {
               WebComp_Layoutprogressbarwc.componentjscripts();
            }
            if ( ! ( WebComp_Layoutprogresscirclewc == null ) )
            {
               WebComp_Layoutprogresscirclewc.componentjscripts();
            }
            if ( ! ( WebComp_Layoutcustomwcwc == null ) )
            {
               WebComp_Layoutcustomwcwc.componentjscripts();
            }
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.WWP_WCModules" ;
      }

      public override string GetPgmdesc( )
      {
         return "WWP_WCModules" ;
      }

      protected void WB090( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wwpbaseobjects.wwp_wcmodules");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridhomemodulessdtsContainer.SetIsFreestyle(true);
            GridhomemodulessdtsContainer.SetWrapped(nGXWrapped);
            StartGridControl12( ) ;
         }
         if ( wbEnd == 12 )
         {
            wbEnd = 0;
            nRC_GXsfl_12 = (int)(nGXsfl_12_idx-1);
            if ( GridhomemodulessdtsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV15GXV1 = nGXsfl_12_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridhomemodulessdtsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridhomemodulessdts", GridhomemodulessdtsContainer, subGridhomemodulessdts_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridhomemodulessdtsContainerData", GridhomemodulessdtsContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridhomemodulessdtsContainerData"+"V", GridhomemodulessdtsContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridhomemodulessdtsContainerData"+"V"+"\" value='"+GridhomemodulessdtsContainer.GridValuesHidden()+"'/>") ;
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
         }
         if ( wbEnd == 12 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridhomemodulessdtsContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV15GXV1 = nGXsfl_12_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridhomemodulessdtsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridhomemodulessdts", GridhomemodulessdtsContainer, subGridhomemodulessdts_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridhomemodulessdtsContainerData", GridhomemodulessdtsContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridhomemodulessdtsContainerData"+"V", GridhomemodulessdtsContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridhomemodulessdtsContainerData"+"V"+"\" value='"+GridhomemodulessdtsContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START092( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET 18_0_12-186073", 0) ;
               }
            }
            Form.Meta.addItem("description", "WWP_WCModules", 0) ;
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP090( ) ;
            }
         }
      }

      protected void WS092( )
      {
         START092( ) ;
         EVT092( ) ;
      }

      protected void EVT092( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP090( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDHOMEMODULESSDTSLAYOUTTABLE.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP090( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridhomemodulessdtslayouttable.Click */
                                    E11092 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP090( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 24), "GRIDHOMEMODULESSDTS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 36), "GRIDHOMEMODULESSDTSLAYOUTTABLE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP090( ) ;
                              }
                              nGXsfl_12_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
                              SubsflControlProps_122( ) ;
                              AV6OptionLink = cgiGet( edtavOptionlink_Internalname);
                              AssignAttri(sPrefix, false, edtavOptionlink_Internalname, AV6OptionLink);
                              AV12Sistema = cgiGet( edtavSistema_Internalname);
                              AssignAttri(sPrefix, false, edtavSistema_Internalname, AV12Sistema);
                              AV7OptionTitle = cgiGet( edtavOptiontitle_Internalname);
                              AssignAttri(sPrefix, false, edtavOptiontitle_Internalname, AV7OptionTitle);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          /* Execute user event: Start */
                                          E12092 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDHOMEMODULESSDTS.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          /* Execute user event: Gridhomemodulessdts.Load */
                                          E13092 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDHOMEMODULESSDTSLAYOUTTABLE.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          /* Execute user event: Gridhomemodulessdtslayouttable.Click */
                                          E11092 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          if ( ! wbErr )
                                          {
                                             Rfr0gs = false;
                                             if ( ! Rfr0gs )
                                             {
                                             }
                                             dynload_actions( ) ;
                                          }
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP090( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                       }
                                    }
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
                        if ( nCmpId == 36 )
                        {
                           sEvtType = StringUtil.Left( sEvt, 4);
                           sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           sCmpCtrl = "W0036" + sEvtType;
                           OldLayoutprogressbarwc = cgiGet( sPrefix+sCmpCtrl);
                           if ( ( StringUtil.Len( OldLayoutprogressbarwc) == 0 ) || ( StringUtil.StrCmp(OldLayoutprogressbarwc, WebComp_GX_Process_Component) != 0 ) )
                           {
                              WebComp_GX_Process = getWebComponent(GetType(), "GeneXus.Programs", OldLayoutprogressbarwc, new Object[] {context} );
                              WebComp_GX_Process.ComponentInit();
                              WebComp_GX_Process.Name = "OldLayoutprogressbarwc";
                              WebComp_GX_Process_Component = OldLayoutprogressbarwc;
                           }
                           if ( StringUtil.Len( WebComp_GX_Process_Component) != 0 )
                           {
                              WebComp_GX_Process.componentprocess(sPrefix+"W0036", sEvtType, sEvt);
                           }
                           nGXsfl_12_webc_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                           WebCompHandler = "Layoutprogressbarwc";
                           WebComp_GX_Process_Component = OldLayoutprogressbarwc;
                        }
                        else if ( nCmpId == 41 )
                        {
                           sEvtType = StringUtil.Left( sEvt, 4);
                           sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           sCmpCtrl = "W0041" + sEvtType;
                           OldLayoutprogresscirclewc = cgiGet( sPrefix+sCmpCtrl);
                           if ( ( StringUtil.Len( OldLayoutprogresscirclewc) == 0 ) || ( StringUtil.StrCmp(OldLayoutprogresscirclewc, WebComp_GX_Process_Component) != 0 ) )
                           {
                              WebComp_GX_Process = getWebComponent(GetType(), "GeneXus.Programs", OldLayoutprogresscirclewc, new Object[] {context} );
                              WebComp_GX_Process.ComponentInit();
                              WebComp_GX_Process.Name = "OldLayoutprogresscirclewc";
                              WebComp_GX_Process_Component = OldLayoutprogresscirclewc;
                           }
                           if ( StringUtil.Len( WebComp_GX_Process_Component) != 0 )
                           {
                              WebComp_GX_Process.componentprocess(sPrefix+"W0041", sEvtType, sEvt);
                           }
                           nGXsfl_12_webc_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                           WebCompHandler = "Layoutprogresscirclewc";
                           WebComp_GX_Process_Component = OldLayoutprogresscirclewc;
                        }
                        else if ( nCmpId == 46 )
                        {
                           sEvtType = StringUtil.Left( sEvt, 4);
                           sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           sCmpCtrl = "W0046" + sEvtType;
                           OldLayoutcustomwcwc = cgiGet( sPrefix+sCmpCtrl);
                           if ( ( StringUtil.Len( OldLayoutcustomwcwc) == 0 ) || ( StringUtil.StrCmp(OldLayoutcustomwcwc, WebComp_GX_Process_Component) != 0 ) )
                           {
                              WebComp_GX_Process = getWebComponent(GetType(), "GeneXus.Programs", OldLayoutcustomwcwc, new Object[] {context} );
                              WebComp_GX_Process.ComponentInit();
                              WebComp_GX_Process.Name = "OldLayoutcustomwcwc";
                              WebComp_GX_Process_Component = OldLayoutcustomwcwc;
                           }
                           if ( StringUtil.Len( WebComp_GX_Process_Component) != 0 )
                           {
                              WebComp_GX_Process.componentprocess(sPrefix+"W0046", sEvtType, sEvt);
                           }
                           nGXsfl_12_webc_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                           WebCompHandler = "Layoutcustomwcwc";
                           WebComp_GX_Process_Component = OldLayoutcustomwcwc;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE092( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm092( ) ;
            }
         }
      }

      protected void PA092( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridhomemodulessdts_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_122( ) ;
         while ( nGXsfl_12_idx <= nRC_GXsfl_12 )
         {
            sendrow_122( ) ;
            nGXsfl_12_idx = ((subGridhomemodulessdts_Islastpage==1)&&(nGXsfl_12_idx+1>subGridhomemodulessdts_fnc_Recordsperpage( )) ? 1 : nGXsfl_12_idx+1);
            sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
            SubsflControlProps_122( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridhomemodulessdtsContainer)) ;
         /* End function gxnrGridhomemodulessdts_newrow */
      }

      protected void gxgrGridhomemodulessdts_refresh( GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem> AV5HomeModulesSDT ,
                                                      string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDHOMEMODULESSDTS_nCurrentRecord = 0;
         RF092( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridhomemodulessdts_refresh */
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
         RF092( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavOptiontitle_Enabled = 0;
      }

      protected void RF092( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridhomemodulessdtsContainer.ClearRows();
         }
         wbStart = 12;
         nGXsfl_12_idx = 1;
         sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
         SubsflControlProps_122( ) ;
         bGXsfl_12_Refreshing = true;
         GridhomemodulessdtsContainer.AddObjectProperty("GridName", "Gridhomemodulessdts");
         GridhomemodulessdtsContainer.AddObjectProperty("CmpContext", sPrefix);
         GridhomemodulessdtsContainer.AddObjectProperty("InMasterPage", "false");
         GridhomemodulessdtsContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         GridhomemodulessdtsContainer.AddObjectProperty("Class", "FreeStyleGrid");
         GridhomemodulessdtsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridhomemodulessdtsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridhomemodulessdtsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridhomemodulessdts_Backcolorstyle), 1, 0, ".", "")));
         GridhomemodulessdtsContainer.PageSize = subGridhomemodulessdts_fnc_Recordsperpage( );
         if ( subGridhomemodulessdts_Islastpage != 0 )
         {
            GRIDHOMEMODULESSDTS_nFirstRecordOnPage = (long)(subGridhomemodulessdts_fnc_Recordcount( )-subGridhomemodulessdts_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDHOMEMODULESSDTS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDHOMEMODULESSDTS_nFirstRecordOnPage), 15, 0, ".", "")));
            GridhomemodulessdtsContainer.AddObjectProperty("GRIDHOMEMODULESSDTS_nFirstRecordOnPage", GRIDHOMEMODULESSDTS_nFirstRecordOnPage);
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_GX_Process_Component) != 0 )
               {
                  WebComp_GX_Process.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Layoutprogressbarwc_Component) != 0 )
               {
                  WebComp_Layoutprogressbarwc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Layoutprogresscirclewc_Component) != 0 )
               {
                  WebComp_Layoutprogresscirclewc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               WebComp_Layoutcustomwcwc.componentstart();
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_122( ) ;
            /* Execute user event: Gridhomemodulessdts.Load */
            E13092 ();
            wbEnd = 12;
            WB090( ) ;
         }
         bGXsfl_12_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes092( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vHOMEMODULESSDT", AV5HomeModulesSDT);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vHOMEMODULESSDT", AV5HomeModulesSDT);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHOMEMODULESSDT", GetSecureSignedToken( sPrefix, AV5HomeModulesSDT, context));
      }

      protected int subGridhomemodulessdts_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGridhomemodulessdts_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGridhomemodulessdts_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGridhomemodulessdts_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         edtavOptiontitle_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP090( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E12092 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_12 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_12"), ",", "."), 18, MidpointRounding.ToEven));
            subGridhomemodulessdts_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"subGridhomemodulessdts_Recordcount"), ",", "."), 18, MidpointRounding.ToEven));
            subGridhomemodulessdts_Class = cgiGet( sPrefix+"GRIDHOMEMODULESSDTS_Class");
            subGridhomemodulessdts_Flexwrap = cgiGet( sPrefix+"GRIDHOMEMODULESSDTS_Flexwrap");
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
         E12092 ();
         if (returnInSub) return;
      }

      protected void E12092( )
      {
         /* Start Routine */
         returnInSub = false;
         edtavOptionlink_Visible = 0;
         AssignProp(sPrefix, false, edtavOptionlink_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOptionlink_Visible), 5, 0), !bGXsfl_12_Refreshing);
         edtavOptionlink_Visible = 0;
         AssignProp(sPrefix, false, edtavOptionlink_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOptionlink_Visible), 5, 0), !bGXsfl_12_Refreshing);
         edtavOptionlink_Visible = 0;
         AssignProp(sPrefix, false, edtavOptionlink_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOptionlink_Visible), 5, 0), !bGXsfl_12_Refreshing);
         edtavSistema_Visible = 0;
         AssignProp(sPrefix, false, edtavSistema_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSistema_Visible), 5, 0), !bGXsfl_12_Refreshing);
         edtavOptionlink_Visible = 0;
         AssignProp(sPrefix, false, edtavOptionlink_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOptionlink_Visible), 5, 0), !bGXsfl_12_Refreshing);
         AV5HomeModulesSDT = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem>( context, "HomeModulesSDTItem", "Factory21");
         GXt_objcol_SdtDVelop_Menu_Item1 = AV13DVelop_Menu;
         new GeneXus.Programs.wwpbaseobjects.menuoptionsdataseguranca(context ).execute( out  GXt_objcol_SdtDVelop_Menu_Item1) ;
         AV13DVelop_Menu = GXt_objcol_SdtDVelop_Menu_Item1;
         AV14InDVelop_Menu.FromJSonString(AV13DVelop_Menu.ToJSonString(false), null);
         AV13DVelop_Menu = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "Factory21");
         new pfuncmenu(context ).execute(  AV14InDVelop_Menu, ref  AV13DVelop_Menu) ;
         if ( AV13DVelop_Menu.Count > 0 )
         {
            AV8HomeModulesSDTItem = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
            AV8HomeModulesSDTItem.gxTpr_Optiontitle = "Segurança";
            AV8HomeModulesSDTItem.gxTpr_Optioniconthemeclass = "fa fa-key";
            AV8HomeModulesSDTItem.gxTpr_Optiontype = 1;
            AV8HomeModulesSDTItem.gxTpr_Optionsize = 1;
            AV8HomeModulesSDTItem.gxTpr_Dmsistema = "Seguranca";
            AV8HomeModulesSDTItem.gxTpr_Optionwclink = formatLink("seguranca") ;
            AV5HomeModulesSDT.Add(AV8HomeModulesSDTItem, 0);
         }
         GXt_objcol_SdtDVelop_Menu_Item1 = AV13DVelop_Menu;
         new GeneXus.Programs.wwpbaseobjects.menuoptionsdatavendas(context ).execute( out  GXt_objcol_SdtDVelop_Menu_Item1) ;
         AV13DVelop_Menu = GXt_objcol_SdtDVelop_Menu_Item1;
         AV14InDVelop_Menu.FromJSonString(AV13DVelop_Menu.ToJSonString(false), null);
         AV13DVelop_Menu = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "Factory21");
         new pfuncmenu(context ).execute(  AV14InDVelop_Menu, ref  AV13DVelop_Menu) ;
         if ( AV13DVelop_Menu.Count > 0 )
         {
            AV8HomeModulesSDTItem = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
            AV8HomeModulesSDTItem.gxTpr_Optiontitle = "Comercial";
            AV8HomeModulesSDTItem.gxTpr_Optioniconthemeclass = "fas fa-solid fa-money-bills";
            AV8HomeModulesSDTItem.gxTpr_Optiontype = 1;
            AV8HomeModulesSDTItem.gxTpr_Optionsize = 1;
            AV8HomeModulesSDTItem.gxTpr_Dmsistema = "Vendas";
            AV8HomeModulesSDTItem.gxTpr_Optionwclink = formatLink("vendas") ;
            AV5HomeModulesSDT.Add(AV8HomeModulesSDTItem, 0);
         }
         GXt_objcol_SdtDVelop_Menu_Item1 = AV13DVelop_Menu;
         new GeneXus.Programs.wwpbaseobjects.menuoptionsdatacontratos(context ).execute( out  GXt_objcol_SdtDVelop_Menu_Item1) ;
         AV13DVelop_Menu = GXt_objcol_SdtDVelop_Menu_Item1;
         AV14InDVelop_Menu.FromJSonString(AV13DVelop_Menu.ToJSonString(false), null);
         AV13DVelop_Menu = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "Factory21");
         new pfuncmenu(context ).execute(  AV14InDVelop_Menu, ref  AV13DVelop_Menu) ;
         if ( AV13DVelop_Menu.Count > 0 )
         {
            AV8HomeModulesSDTItem = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
            AV8HomeModulesSDTItem.gxTpr_Optiontitle = "Contratos";
            AV8HomeModulesSDTItem.gxTpr_Optioniconthemeclass = "fa-solid fa-file-signature";
            AV8HomeModulesSDTItem.gxTpr_Optiontype = 1;
            AV8HomeModulesSDTItem.gxTpr_Optionsize = 1;
            AV8HomeModulesSDTItem.gxTpr_Optionwclink = formatLink("contratos") ;
            AV8HomeModulesSDTItem.gxTpr_Dmsistema = "Contratos";
            AV5HomeModulesSDT.Add(AV8HomeModulesSDTItem, 0);
         }
         GXt_objcol_SdtDVelop_Menu_Item1 = AV13DVelop_Menu;
         new GeneXus.Programs.wwpbaseobjects.menuoptionsdata(context ).execute( out  GXt_objcol_SdtDVelop_Menu_Item1) ;
         AV13DVelop_Menu = GXt_objcol_SdtDVelop_Menu_Item1;
         AV14InDVelop_Menu.FromJSonString(AV13DVelop_Menu.ToJSonString(false), null);
         AV13DVelop_Menu = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "Factory21");
         new pfuncmenu(context ).execute(  AV14InDVelop_Menu, ref  AV13DVelop_Menu) ;
         if ( AV13DVelop_Menu.Count > 0 )
         {
            AV8HomeModulesSDTItem = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
            AV8HomeModulesSDTItem.gxTpr_Optiontitle = "Financeiro";
            AV8HomeModulesSDTItem.gxTpr_Optioniconthemeclass = "fa-solid fa-money-bill-trend-up";
            AV8HomeModulesSDTItem.gxTpr_Optiontype = 1;
            AV8HomeModulesSDTItem.gxTpr_Optionsize = 1;
            AV8HomeModulesSDTItem.gxTpr_Optionwclink = formatLink("financeiro") ;
            AV8HomeModulesSDTItem.gxTpr_Dmsistema = "Financeiro";
            AV5HomeModulesSDT.Add(AV8HomeModulesSDTItem, 0);
         }
      }

      private void E13092( )
      {
         /* Gridhomemodulessdts_Load Routine */
         returnInSub = false;
         AV15GXV1 = 1;
         while ( AV15GXV1 <= AV5HomeModulesSDT.Count )
         {
            AV5HomeModulesSDT.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem)AV5HomeModulesSDT.Item(AV15GXV1));
            AV6OptionLink = ((GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem)(AV5HomeModulesSDT.CurrentItem)).gxTpr_Optionwclink;
            AssignAttri(sPrefix, false, edtavOptionlink_Internalname, AV6OptionLink);
            if ( ((GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem)(AV5HomeModulesSDT.CurrentItem)).gxTpr_Optiontype == 1 )
            {
               lblLayoutoptionandtitleoptionicon_Caption = StringUtil.Format( "<i class='CardsMenuIcon %1' style='font-size: 40px'></i>", ((GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem)(AV5HomeModulesSDT.CurrentItem)).gxTpr_Optioniconthemeclass, "", "", "", "", "", "", "", "");
               AV7OptionTitle = ((GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem)(AV5HomeModulesSDT.CurrentItem)).gxTpr_Optiontitle;
               AssignAttri(sPrefix, false, edtavOptiontitle_Internalname, AV7OptionTitle);
            }
            divLayoutoptionandtitletablecell_Visible = 0;
            AssignProp(sPrefix, false, divLayoutoptionandtitletablecell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLayoutoptionandtitletablecell_Visible), 5, 0), !bGXsfl_12_Refreshing);
            divLayoutprogressbartablecell_Visible = 0;
            AssignProp(sPrefix, false, divLayoutprogressbartablecell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLayoutprogressbartablecell_Visible), 5, 0), !bGXsfl_12_Refreshing);
            divLayoutprogresscircletablecell_Visible = 0;
            AssignProp(sPrefix, false, divLayoutprogresscircletablecell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLayoutprogresscircletablecell_Visible), 5, 0), !bGXsfl_12_Refreshing);
            divLayoutcustomwctablecell_Visible = 0;
            AssignProp(sPrefix, false, divLayoutcustomwctablecell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLayoutcustomwctablecell_Visible), 5, 0), !bGXsfl_12_Refreshing);
            if ( ((GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem)(AV5HomeModulesSDT.CurrentItem)).gxTpr_Optiontype == 2 )
            {
               divLayoutprogressbartablecell_Visible = 1;
               AssignProp(sPrefix, false, divLayoutprogressbartablecell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLayoutprogressbartablecell_Visible), 5, 0), !bGXsfl_12_Refreshing);
               /* Object Property */
               if ( StringUtil.Len( sPrefix) == 0 )
               {
                  bDynCreated_Layoutprogressbarwc = true;
               }
               if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Layoutprogressbarwc_Component), StringUtil.Lower( "WWPBaseObjects.HomeProgressBarWC")) != 0 )
               {
                  WebComp_Layoutprogressbarwc = getWebComponent(GetType(), "GeneXus.Programs", "wwpbaseobjects.homeprogressbarwc", new Object[] {context} );
                  WebComp_Layoutprogressbarwc.ComponentInit();
                  WebComp_Layoutprogressbarwc.Name = "WWPBaseObjects.HomeProgressBarWC";
                  WebComp_Layoutprogressbarwc_Component = "WWPBaseObjects.HomeProgressBarWC";
               }
               if ( StringUtil.Len( WebComp_Layoutprogressbarwc_Component) != 0 )
               {
                  WebComp_Layoutprogressbarwc.setjustcreated();
                  WebComp_Layoutprogressbarwc.componentprepare(new Object[] {(string)sPrefix+"W0036",(string)sGXsfl_12_idx,((GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem)(AV5HomeModulesSDT.CurrentItem)).gxTpr_Optiontitle,((GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem)(AV5HomeModulesSDT.CurrentItem)).gxTpr_Optiondescription,((GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem)(AV5HomeModulesSDT.CurrentItem)).gxTpr_Optionprogressvalue});
                  WebComp_Layoutprogressbarwc.componentbind(new Object[] {(string)"",(string)"",(string)""});
               }
               if ( ! bGXsfl_12_Refreshing )
               {
                  if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Layoutprogressbarwc )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0036"+sGXsfl_12_idx);
                     WebComp_Layoutprogressbarwc.componentdraw();
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
            }
            else if ( ((GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem)(AV5HomeModulesSDT.CurrentItem)).gxTpr_Optiontype == 3 )
            {
               divLayoutprogresscircletablecell_Visible = 1;
               AssignProp(sPrefix, false, divLayoutprogresscircletablecell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLayoutprogresscircletablecell_Visible), 5, 0), !bGXsfl_12_Refreshing);
               /* Object Property */
               if ( StringUtil.Len( sPrefix) == 0 )
               {
                  bDynCreated_Layoutprogresscirclewc = true;
               }
               if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Layoutprogresscirclewc_Component), StringUtil.Lower( "WWPBaseObjects.HomeProgressBarCircleWC")) != 0 )
               {
                  WebComp_Layoutprogresscirclewc = getWebComponent(GetType(), "GeneXus.Programs", "wwpbaseobjects.homeprogressbarcirclewc", new Object[] {context} );
                  WebComp_Layoutprogresscirclewc.ComponentInit();
                  WebComp_Layoutprogresscirclewc.Name = "WWPBaseObjects.HomeProgressBarCircleWC";
                  WebComp_Layoutprogresscirclewc_Component = "WWPBaseObjects.HomeProgressBarCircleWC";
               }
               if ( StringUtil.Len( WebComp_Layoutprogresscirclewc_Component) != 0 )
               {
                  WebComp_Layoutprogresscirclewc.setjustcreated();
                  WebComp_Layoutprogresscirclewc.componentprepare(new Object[] {(string)sPrefix+"W0041",(string)sGXsfl_12_idx,((GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem)(AV5HomeModulesSDT.CurrentItem)).gxTpr_Optiontitle,((GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem)(AV5HomeModulesSDT.CurrentItem)).gxTpr_Optionprogressvalue});
                  WebComp_Layoutprogresscirclewc.componentbind(new Object[] {(string)"",(string)""});
               }
               if ( ! bGXsfl_12_Refreshing )
               {
                  if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Layoutprogresscirclewc )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0041"+sGXsfl_12_idx);
                     WebComp_Layoutprogresscirclewc.componentdraw();
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
            }
            else if ( ((GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem)(AV5HomeModulesSDT.CurrentItem)).gxTpr_Optiontype == 4 )
            {
               divLayoutcustomwctablecell_Visible = 1;
               AssignProp(sPrefix, false, divLayoutcustomwctablecell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLayoutcustomwctablecell_Visible), 5, 0), !bGXsfl_12_Refreshing);
            }
            else
            {
               divLayoutoptionandtitletablecell_Visible = 1;
               AssignProp(sPrefix, false, divLayoutoptionandtitletablecell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLayoutoptionandtitletablecell_Visible), 5, 0), !bGXsfl_12_Refreshing);
            }
            AV6OptionLink = ((GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem)(AV5HomeModulesSDT.CurrentItem)).gxTpr_Optionwclink;
            AssignAttri(sPrefix, false, edtavOptionlink_Internalname, AV6OptionLink);
            AV12Sistema = ((GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem)(AV5HomeModulesSDT.CurrentItem)).gxTpr_Dmsistema;
            AssignAttri(sPrefix, false, edtavSistema_Internalname, AV12Sistema);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 12;
            }
            sendrow_122( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_12_Refreshing )
            {
               DoAjaxLoad(12, GridhomemodulessdtsRow);
            }
            AV15GXV1 = (int)(AV15GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      protected void E11092( )
      {
         /* Gridhomemodulessdtslayouttable_Click Routine */
         returnInSub = false;
         AV11WEBSESSION.Set("DmSistema", AV12Sistema);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV6OptionLink)) )
         {
            CallWebObject(formatLink(AV6OptionLink) );
            context.wjLocDisableFrm = 0;
         }
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
         PA092( ) ;
         WS092( ) ;
         WE092( ) ;
         cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected override EncryptionType GetEncryptionType( )
      {
         return EncryptionType.SESSION ;
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA092( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wwpbaseobjects\\wwp_wcmodules", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA092( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
         }
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA092( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS092( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS092( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE092( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
         if ( ! ( WebComp_GX_Process == null ) )
         {
            WebComp_GX_Process.componentjscripts();
         }
         if ( ! ( WebComp_Layoutprogressbarwc == null ) )
         {
            WebComp_Layoutprogressbarwc.componentjscripts();
         }
         if ( ! ( WebComp_Layoutprogresscirclewc == null ) )
         {
            WebComp_Layoutprogresscirclewc.componentjscripts();
         }
         if ( ! ( WebComp_Layoutcustomwcwc == null ) )
         {
            WebComp_Layoutcustomwcwc.componentjscripts();
         }
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Layoutprogressbarwc == null ) )
         {
            if ( StringUtil.Len( WebComp_Layoutprogressbarwc_Component) != 0 )
            {
               WebComp_Layoutprogressbarwc.componentthemes();
            }
         }
         if ( ! ( WebComp_Layoutprogresscirclewc == null ) )
         {
            if ( StringUtil.Len( WebComp_Layoutprogresscirclewc_Component) != 0 )
            {
               WebComp_Layoutprogresscirclewc.componentthemes();
            }
         }
         if ( ! ( WebComp_Layoutcustomwcwc == null ) )
         {
            WebComp_Layoutcustomwcwc.componentthemes();
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101965799", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         CloseStyles();
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("wwpbaseobjects/wwp_wcmodules.js", "?20256101965799", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_122( )
      {
         edtavOptionlink_Internalname = sPrefix+"vOPTIONLINK_"+sGXsfl_12_idx;
         edtavSistema_Internalname = sPrefix+"vSISTEMA_"+sGXsfl_12_idx;
         lblLayoutoptionandtitleoptionicon_Internalname = sPrefix+"LAYOUTOPTIONANDTITLEOPTIONICON_"+sGXsfl_12_idx;
         edtavOptiontitle_Internalname = sPrefix+"vOPTIONTITLE_"+sGXsfl_12_idx;
      }

      protected void SubsflControlProps_fel_122( )
      {
         edtavOptionlink_Internalname = sPrefix+"vOPTIONLINK_"+sGXsfl_12_fel_idx;
         edtavSistema_Internalname = sPrefix+"vSISTEMA_"+sGXsfl_12_fel_idx;
         lblLayoutoptionandtitleoptionicon_Internalname = sPrefix+"LAYOUTOPTIONANDTITLEOPTIONICON_"+sGXsfl_12_fel_idx;
         edtavOptiontitle_Internalname = sPrefix+"vOPTIONTITLE_"+sGXsfl_12_fel_idx;
      }

      protected void sendrow_122( )
      {
         sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
         SubsflControlProps_122( ) ;
         WB090( ) ;
         GridhomemodulessdtsRow = GXWebRow.GetNew(context,GridhomemodulessdtsContainer);
         if ( subGridhomemodulessdts_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridhomemodulessdts_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridhomemodulessdts_Class, "") != 0 )
            {
               subGridhomemodulessdts_Linesclass = subGridhomemodulessdts_Class+"Odd";
            }
         }
         else if ( subGridhomemodulessdts_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridhomemodulessdts_Backstyle = 0;
            subGridhomemodulessdts_Backcolor = subGridhomemodulessdts_Allbackcolor;
            if ( StringUtil.StrCmp(subGridhomemodulessdts_Class, "") != 0 )
            {
               subGridhomemodulessdts_Linesclass = subGridhomemodulessdts_Class+"Uniform";
            }
         }
         else if ( subGridhomemodulessdts_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridhomemodulessdts_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridhomemodulessdts_Class, "") != 0 )
            {
               subGridhomemodulessdts_Linesclass = subGridhomemodulessdts_Class+"Odd";
            }
            subGridhomemodulessdts_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subGridhomemodulessdts_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridhomemodulessdts_Backstyle = 1;
            subGridhomemodulessdts_Backcolor = (int)(0xFFFFFF);
            if ( StringUtil.StrCmp(subGridhomemodulessdts_Class, "") != 0 )
            {
               subGridhomemodulessdts_Linesclass = subGridhomemodulessdts_Class+"Odd";
            }
         }
         /* Start of Columns property logic. */
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divGridhomemodulessdtslayouttable_Internalname+"_"+sGXsfl_12_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Flex",(string)"start",(string)"top",(string)" "+"data-gx-flex"+" ",(string)"",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Invisible",(string)"start",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Table start */
         GridhomemodulessdtsRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblUnnamedtablecontentfsgridhomemodulessdts_Internalname+"_"+sGXsfl_12_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Attribute/Variable Label */
         GridhomemodulessdtsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavOptionlink_Internalname,(string)"Option Link",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Multiple line edit */
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GridhomemodulessdtsRow.AddColumnProperties("html_textarea", 1, isAjaxCallMode( ), new Object[] {(string)edtavOptionlink_Internalname,(string)AV6OptionLink,(string)"",(string)"",(short)0,(int)edtavOptionlink_Visible,(short)0,(short)0,(short)80,(string)"chr",(short)3,(string)"row",(short)0,(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"200",(short)-1,(short)0,(string)"",(string)"",(short)-1,(bool)true,(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(short)0,(string)""});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         if ( GridhomemodulessdtsContainer.GetWrapped() == 1 )
         {
            GridhomemodulessdtsContainer.CloseTag("cell");
         }
         GridhomemodulessdtsRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Attribute/Variable Label */
         GridhomemodulessdtsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavSistema_Internalname,(string)"Sistema",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Single line edit */
         ROClassString = "Attribute";
         GridhomemodulessdtsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSistema_Internalname,(string)AV12Sistema,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSistema_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtavSistema_Visible,(short)0,(short)0,(string)"text",(string)"",(short)40,(string)"chr",(short)1,(string)"row",(short)40,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         if ( GridhomemodulessdtsContainer.GetWrapped() == 1 )
         {
            GridhomemodulessdtsContainer.CloseTag("cell");
         }
         if ( GridhomemodulessdtsContainer.GetWrapped() == 1 )
         {
            GridhomemodulessdtsContainer.CloseTag("row");
         }
         if ( GridhomemodulessdtsContainer.GetWrapped() == 1 )
         {
            GridhomemodulessdtsContainer.CloseTag("table");
         }
         /* End of table */
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divLayoutoptionandtitletablecell_Internalname+"_"+sGXsfl_12_idx,(int)divLayoutoptionandtitletablecell_Visible,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"start",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divLayoutoptionandtitletable_Internalname+"_"+sGXsfl_12_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"TableCardsMenu",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"Center",(string)"top",(string)"",(string)"",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Text block */
         GridhomemodulessdtsRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblLayoutoptionandtitleoptionicon_Internalname,(string)lblLayoutoptionandtitleoptionicon_Caption,(string)"",(string)"",(string)lblLayoutoptionandtitleoptionicon_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)2});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"Center",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 AttributeCardsMenuTitleCell",(string)"Center",(string)"top",(string)"",(string)"",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Attribute/Variable Label */
         GridhomemodulessdtsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavOptiontitle_Internalname,(string)"Option Title",(string)"col-sm-3 AttributeCardsMenuTitleLabel",(short)0,(bool)true,(string)""});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'" + sPrefix + "',false,'" + sGXsfl_12_idx + "',12)\"";
         ROClassString = "AttributeCardsMenuTitle";
         GridhomemodulessdtsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavOptiontitle_Internalname,(string)AV7OptionTitle,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavOptiontitle_Jsonclick,(short)0,(string)"AttributeCardsMenuTitle",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavOptiontitle_Enabled,(short)0,(string)"text",(string)"",(short)40,(string)"chr",(short)1,(string)"row",(short)40,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"Center",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divLayoutprogressbartablecell_Internalname+"_"+sGXsfl_12_idx,(int)divLayoutprogressbartablecell_Visible,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"start",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divLayoutprogressbartable_Internalname+"_"+sGXsfl_12_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"TableCardsMenu",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* WebComponent */
         GxWebStd.gx_hidden_field( context, sPrefix+"W0036"+sGXsfl_12_idx, StringUtil.RTrim( WebComp_Layoutprogressbarwc_Component));
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gxwebcomponent"+" gxwebcomponent-loading");
         context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0036"+sGXsfl_12_idx+"\""+"") ;
         context.WriteHtmlText( ">") ;
         if ( bGXsfl_12_Refreshing )
         {
            if ( StringUtil.Len( WebComp_Layoutprogressbarwc_Component) != 0 )
            {
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StringSearch( sPrefix+"W0036"+sGXsfl_12_idx, cgiGet( "_EventName"), 1) != 0 ) )
               {
                  if ( 1 != 0 )
                  {
                     if ( StringUtil.Len( WebComp_Layoutprogressbarwc_Component) != 0 )
                     {
                        WebComp_Layoutprogressbarwc.componentstart();
                     }
                  }
               }
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldLayoutprogressbarwc), StringUtil.Lower( WebComp_Layoutprogressbarwc_Component)) != 0 ) )
               {
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0036"+sGXsfl_12_idx);
               }
               WebComp_Layoutprogressbarwc.componentdraw();
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldLayoutprogressbarwc), StringUtil.Lower( WebComp_Layoutprogressbarwc_Component)) != 0 ) )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
            }
         }
         context.WriteHtmlText( "</div>") ;
         WebComp_Layoutprogressbarwc_Component = "";
         WebComp_Layoutprogressbarwc.componentjscripts();
         GridhomemodulessdtsRow.AddColumnProperties("webcomp", -1, isAjaxCallMode( ), new Object[] {(string)"Layoutprogressbarwc"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divLayoutprogresscircletablecell_Internalname+"_"+sGXsfl_12_idx,(int)divLayoutprogresscircletablecell_Visible,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"start",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divLayoutprogresscircletable_Internalname+"_"+sGXsfl_12_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"TableCardsMenu",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* WebComponent */
         GxWebStd.gx_hidden_field( context, sPrefix+"W0041"+sGXsfl_12_idx, StringUtil.RTrim( WebComp_Layoutprogresscirclewc_Component));
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gxwebcomponent"+" gxwebcomponent-loading");
         context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0041"+sGXsfl_12_idx+"\""+"") ;
         context.WriteHtmlText( ">") ;
         if ( bGXsfl_12_Refreshing )
         {
            if ( StringUtil.Len( WebComp_Layoutprogresscirclewc_Component) != 0 )
            {
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StringSearch( sPrefix+"W0041"+sGXsfl_12_idx, cgiGet( "_EventName"), 1) != 0 ) )
               {
                  if ( 1 != 0 )
                  {
                     if ( StringUtil.Len( WebComp_Layoutprogresscirclewc_Component) != 0 )
                     {
                        WebComp_Layoutprogresscirclewc.componentstart();
                     }
                  }
               }
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldLayoutprogresscirclewc), StringUtil.Lower( WebComp_Layoutprogresscirclewc_Component)) != 0 ) )
               {
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0041"+sGXsfl_12_idx);
               }
               WebComp_Layoutprogresscirclewc.componentdraw();
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldLayoutprogresscirclewc), StringUtil.Lower( WebComp_Layoutprogresscirclewc_Component)) != 0 ) )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
            }
         }
         context.WriteHtmlText( "</div>") ;
         WebComp_Layoutprogresscirclewc_Component = "";
         WebComp_Layoutprogresscirclewc.componentjscripts();
         GridhomemodulessdtsRow.AddColumnProperties("webcomp", -1, isAjaxCallMode( ), new Object[] {(string)"Layoutprogresscirclewc"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divLayoutcustomwctablecell_Internalname+"_"+sGXsfl_12_idx,(int)divLayoutcustomwctablecell_Visible,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"start",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divLayoutcustomwctable_Internalname+"_"+sGXsfl_12_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"TableCardsMenu",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         sendrow_12230( ) ;
      }

      protected void sendrow_12230( )
      {
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* WebComponent */
         GxWebStd.gx_hidden_field( context, sPrefix+"W0046"+sGXsfl_12_idx, StringUtil.RTrim( WebComp_Layoutcustomwcwc_Component));
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gxwebcomponent"+" gxwebcomponent-loading");
         context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0046"+sGXsfl_12_idx+"\""+"") ;
         context.WriteHtmlText( ">") ;
         if ( bGXsfl_12_Refreshing )
         {
            if ( ! context.isAjaxRequest( ) || ( StringUtil.StringSearch( sPrefix+"W0046"+sGXsfl_12_idx, cgiGet( "_EventName"), 1) != 0 ) )
            {
               if ( 1 != 0 )
               {
                  WebComp_Layoutcustomwcwc.componentstart();
               }
            }
            if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldLayoutcustomwcwc), StringUtil.Lower( WebComp_Layoutcustomwcwc_Component)) != 0 ) )
            {
               context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0046"+sGXsfl_12_idx);
            }
            WebComp_Layoutcustomwcwc.componentdraw();
            if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldLayoutcustomwcwc), StringUtil.Lower( WebComp_Layoutcustomwcwc_Component)) != 0 ) )
            {
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         context.WriteHtmlText( "</div>") ;
         WebComp_Layoutcustomwcwc_Component = "";
         WebComp_Layoutcustomwcwc.componentjscripts();
         GridhomemodulessdtsRow.AddColumnProperties("webcomp", -1, isAjaxCallMode( ), new Object[] {(string)"Layoutcustomwcwc"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         send_integrity_lvl_hashes092( ) ;
         /* End of Columns property logic. */
         GridhomemodulessdtsContainer.AddRow(GridhomemodulessdtsRow);
         nGXsfl_12_idx = ((subGridhomemodulessdts_Islastpage==1)&&(nGXsfl_12_idx+1>subGridhomemodulessdts_fnc_Recordsperpage( )) ? 1 : nGXsfl_12_idx+1);
         sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
         SubsflControlProps_122( ) ;
         /* End function sendrow_122 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl12( )
      {
         if ( GridhomemodulessdtsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridhomemodulessdtsContainer"+"DivS\" data-gxgridid=\"12\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridhomemodulessdts_Internalname, subGridhomemodulessdts_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            GridhomemodulessdtsContainer.AddObjectProperty("GridName", "Gridhomemodulessdts");
         }
         else
         {
            GridhomemodulessdtsContainer.AddObjectProperty("GridName", "Gridhomemodulessdts");
            GridhomemodulessdtsContainer.AddObjectProperty("Header", subGridhomemodulessdts_Header);
            GridhomemodulessdtsContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            GridhomemodulessdtsContainer.AddObjectProperty("Class", "FreeStyleGrid");
            GridhomemodulessdtsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridhomemodulessdtsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridhomemodulessdtsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridhomemodulessdts_Backcolorstyle), 1, 0, ".", "")));
            GridhomemodulessdtsContainer.AddObjectProperty("CmpContext", sPrefix);
            GridhomemodulessdtsContainer.AddObjectProperty("InMasterPage", "false");
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV6OptionLink));
            GridhomemodulessdtsColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavOptionlink_Visible), 5, 0, ".", "")));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV12Sistema));
            GridhomemodulessdtsColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSistema_Visible), 5, 0, ".", "")));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsColumn.AddObjectProperty("Value", lblLayoutoptionandtitleoptionicon_Caption);
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV7OptionTitle));
            GridhomemodulessdtsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavOptiontitle_Enabled), 5, 0, ".", "")));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
            GridhomemodulessdtsContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridhomemodulessdts_Selectedindex), 4, 0, ".", "")));
            GridhomemodulessdtsContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridhomemodulessdts_Allowselection), 1, 0, ".", "")));
            GridhomemodulessdtsContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridhomemodulessdts_Selectioncolor), 9, 0, ".", "")));
            GridhomemodulessdtsContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridhomemodulessdts_Allowhovering), 1, 0, ".", "")));
            GridhomemodulessdtsContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridhomemodulessdts_Hoveringcolor), 9, 0, ".", "")));
            GridhomemodulessdtsContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridhomemodulessdts_Allowcollapsing), 1, 0, ".", "")));
            GridhomemodulessdtsContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridhomemodulessdts_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         edtavOptionlink_Internalname = sPrefix+"vOPTIONLINK";
         edtavSistema_Internalname = sPrefix+"vSISTEMA";
         tblUnnamedtablecontentfsgridhomemodulessdts_Internalname = sPrefix+"UNNAMEDTABLECONTENTFSGRIDHOMEMODULESSDTS";
         lblLayoutoptionandtitleoptionicon_Internalname = sPrefix+"LAYOUTOPTIONANDTITLEOPTIONICON";
         edtavOptiontitle_Internalname = sPrefix+"vOPTIONTITLE";
         divLayoutoptionandtitletable_Internalname = sPrefix+"LAYOUTOPTIONANDTITLETABLE";
         divLayoutoptionandtitletablecell_Internalname = sPrefix+"LAYOUTOPTIONANDTITLETABLECELL";
         divLayoutprogressbartable_Internalname = sPrefix+"LAYOUTPROGRESSBARTABLE";
         divLayoutprogressbartablecell_Internalname = sPrefix+"LAYOUTPROGRESSBARTABLECELL";
         divLayoutprogresscircletable_Internalname = sPrefix+"LAYOUTPROGRESSCIRCLETABLE";
         divLayoutprogresscircletablecell_Internalname = sPrefix+"LAYOUTPROGRESSCIRCLETABLECELL";
         divLayoutcustomwctable_Internalname = sPrefix+"LAYOUTCUSTOMWCTABLE";
         divLayoutcustomwctablecell_Internalname = sPrefix+"LAYOUTCUSTOMWCTABLECELL";
         divGridhomemodulessdtslayouttable_Internalname = sPrefix+"GRIDHOMEMODULESSDTSLAYOUTTABLE";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGridhomemodulessdts_Internalname = sPrefix+"GRIDHOMEMODULESSDTS";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         subGridhomemodulessdts_Allowcollapsing = 0;
         lblLayoutoptionandtitleoptionicon_Caption = "<i class='CardsMenuIcon fa fa-home' style='font-size: 40px'></i>";
         divLayoutcustomwctablecell_Visible = 1;
         divLayoutprogresscircletablecell_Visible = 1;
         divLayoutprogressbartablecell_Visible = 1;
         edtavOptiontitle_Jsonclick = "";
         edtavOptiontitle_Enabled = 0;
         lblLayoutoptionandtitleoptionicon_Caption = "<i class='CardsMenuIcon fa fa-home' style='font-size: 40px'></i>";
         divLayoutoptionandtitletablecell_Visible = 1;
         edtavSistema_Jsonclick = "";
         subGridhomemodulessdts_Backcolorstyle = 0;
         subGridhomemodulessdts_Flexwrap = "wrap";
         subGridhomemodulessdts_Class = "FreeStyleGrid";
         edtavSistema_Visible = 1;
         edtavOptionlink_Visible = 1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRIDHOMEMODULESSDTS_nFirstRecordOnPage","type":"int"},{"av":"GRIDHOMEMODULESSDTS_nEOF","type":"int"},{"av":"edtavOptionlink_Visible","ctrl":"vOPTIONLINK","prop":"Visible"},{"av":"edtavSistema_Visible","ctrl":"vSISTEMA","prop":"Visible"},{"av":"sPrefix","type":"char"},{"av":"AV5HomeModulesSDT","fld":"vHOMEMODULESSDT","hsh":true,"type":""}]}""");
         setEventMetadata("GRIDHOMEMODULESSDTS.LOAD","""{"handler":"E13092","iparms":[{"av":"AV5HomeModulesSDT","fld":"vHOMEMODULESSDT","hsh":true,"type":""}]""");
         setEventMetadata("GRIDHOMEMODULESSDTS.LOAD",""","oparms":[{"av":"AV6OptionLink","fld":"vOPTIONLINK","type":"svchar"},{"av":"lblLayoutoptionandtitleoptionicon_Caption","ctrl":"LAYOUTOPTIONANDTITLEOPTIONICON","prop":"Caption"},{"av":"AV7OptionTitle","fld":"vOPTIONTITLE","type":"svchar"},{"av":"divLayoutoptionandtitletablecell_Visible","ctrl":"LAYOUTOPTIONANDTITLETABLECELL","prop":"Visible"},{"av":"divLayoutprogressbartablecell_Visible","ctrl":"LAYOUTPROGRESSBARTABLECELL","prop":"Visible"},{"av":"divLayoutprogresscircletablecell_Visible","ctrl":"LAYOUTPROGRESSCIRCLETABLECELL","prop":"Visible"},{"av":"divLayoutcustomwctablecell_Visible","ctrl":"LAYOUTCUSTOMWCTABLECELL","prop":"Visible"},{"ctrl":"LAYOUTPROGRESSBARWC"},{"ctrl":"LAYOUTPROGRESSCIRCLEWC"},{"av":"AV12Sistema","fld":"vSISTEMA","type":"svchar"}]}""");
         setEventMetadata("GRIDHOMEMODULESSDTSLAYOUTTABLE.CLICK","""{"handler":"E11092","iparms":[{"av":"AV12Sistema","fld":"vSISTEMA","type":"svchar"},{"av":"AV6OptionLink","fld":"vOPTIONLINK","type":"svchar"}]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Optiontitle","iparms":[]}""");
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
         sPrefix = "";
         AV5HomeModulesSDT = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem>( context, "HomeModulesSDTItem", "Factory21");
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         GridhomemodulessdtsContainer = new GXWebGrid( context);
         sStyleString = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV6OptionLink = "";
         AV12Sistema = "";
         AV7OptionTitle = "";
         OldLayoutprogressbarwc = "";
         sCmpCtrl = "";
         WebComp_GX_Process_Component = "";
         OldLayoutprogresscirclewc = "";
         OldLayoutcustomwcwc = "";
         WebComp_Layoutprogressbarwc_Component = "";
         WebComp_Layoutprogresscirclewc_Component = "";
         AV13DVelop_Menu = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "Factory21");
         AV14InDVelop_Menu = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "Factory21");
         AV8HomeModulesSDTItem = new GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem(context);
         GXt_objcol_SdtDVelop_Menu_Item1 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "Factory21");
         GridhomemodulessdtsRow = new GXWebRow();
         AV11WEBSESSION = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGridhomemodulessdts_Linesclass = "";
         GridhomemodulessdtsColumn = new GXWebColumn();
         ClassString = "";
         StyleString = "";
         ROClassString = "";
         lblLayoutoptionandtitleoptionicon_Jsonclick = "";
         TempTags = "";
         WebComp_Layoutcustomwcwc_Component = "";
         subGridhomemodulessdts_Header = "";
         WebComp_GX_Process = new GeneXus.Http.GXNullWebComponent();
         WebComp_Layoutprogressbarwc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Layoutprogresscirclewc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Layoutcustomwcwc = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
         edtavOptiontitle_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGridhomemodulessdts_Backcolorstyle ;
      private short nGXWrapped ;
      private short subGridhomemodulessdts_Backstyle ;
      private short subGridhomemodulessdts_Allowselection ;
      private short subGridhomemodulessdts_Allowhovering ;
      private short subGridhomemodulessdts_Allowcollapsing ;
      private short subGridhomemodulessdts_Collapsed ;
      private short GRIDHOMEMODULESSDTS_nEOF ;
      private int edtavOptionlink_Visible ;
      private int edtavSistema_Visible ;
      private int nRC_GXsfl_12 ;
      private int subGridhomemodulessdts_Recordcount ;
      private int nGXsfl_12_idx=1 ;
      private int edtavOptiontitle_Enabled ;
      private int AV15GXV1 ;
      private int nGXsfl_12_webc_idx=0 ;
      private int subGridhomemodulessdts_Islastpage ;
      private int divLayoutoptionandtitletablecell_Visible ;
      private int divLayoutprogressbartablecell_Visible ;
      private int divLayoutprogresscircletablecell_Visible ;
      private int divLayoutcustomwctablecell_Visible ;
      private int idxLst ;
      private int subGridhomemodulessdts_Backcolor ;
      private int subGridhomemodulessdts_Allbackcolor ;
      private int subGridhomemodulessdts_Selectedindex ;
      private int subGridhomemodulessdts_Selectioncolor ;
      private int subGridhomemodulessdts_Hoveringcolor ;
      private long GRIDHOMEMODULESSDTS_nCurrentRecord ;
      private long GRIDHOMEMODULESSDTS_nFirstRecordOnPage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_12_idx="0001" ;
      private string edtavOptionlink_Internalname ;
      private string edtavSistema_Internalname ;
      private string edtavOptiontitle_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string subGridhomemodulessdts_Class ;
      private string subGridhomemodulessdts_Flexwrap ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTablecontent_Internalname ;
      private string sStyleString ;
      private string subGridhomemodulessdts_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string OldLayoutprogressbarwc ;
      private string sCmpCtrl ;
      private string WebComp_GX_Process_Component ;
      private string WebCompHandler="" ;
      private string OldLayoutprogresscirclewc ;
      private string OldLayoutcustomwcwc ;
      private string WebComp_Layoutprogressbarwc_Component ;
      private string WebComp_Layoutprogresscirclewc_Component ;
      private string lblLayoutoptionandtitleoptionicon_Caption ;
      private string divLayoutoptionandtitletablecell_Internalname ;
      private string divLayoutprogressbartablecell_Internalname ;
      private string divLayoutprogresscircletablecell_Internalname ;
      private string divLayoutcustomwctablecell_Internalname ;
      private string lblLayoutoptionandtitleoptionicon_Internalname ;
      private string sGXsfl_12_fel_idx="0001" ;
      private string subGridhomemodulessdts_Linesclass ;
      private string divGridhomemodulessdtslayouttable_Internalname ;
      private string tblUnnamedtablecontentfsgridhomemodulessdts_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string ROClassString ;
      private string edtavSistema_Jsonclick ;
      private string divLayoutoptionandtitletable_Internalname ;
      private string lblLayoutoptionandtitleoptionicon_Jsonclick ;
      private string TempTags ;
      private string edtavOptiontitle_Jsonclick ;
      private string divLayoutprogressbartable_Internalname ;
      private string divLayoutprogresscircletable_Internalname ;
      private string divLayoutcustomwctable_Internalname ;
      private string WebComp_Layoutcustomwcwc_Component ;
      private string subGridhomemodulessdts_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_12_Refreshing=false ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool bDynCreated_Layoutprogressbarwc ;
      private bool bDynCreated_Layoutprogresscirclewc ;
      private string AV6OptionLink ;
      private string AV12Sistema ;
      private string AV7OptionTitle ;
      private GXWebComponent WebComp_Layoutprogressbarwc ;
      private GXWebComponent WebComp_Layoutprogresscirclewc ;
      private GXWebComponent WebComp_Layoutcustomwcwc ;
      private GXWebGrid GridhomemodulessdtsContainer ;
      private GXWebRow GridhomemodulessdtsRow ;
      private GXWebColumn GridhomemodulessdtsColumn ;
      private GXWebForm Form ;
      private IGxSession AV11WEBSESSION ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem> AV5HomeModulesSDT ;
      private GXWebComponent WebComp_GX_Process ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> AV13DVelop_Menu ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> AV14InDVelop_Menu ;
      private GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem AV8HomeModulesSDTItem ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> GXt_objcol_SdtDVelop_Menu_Item1 ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
