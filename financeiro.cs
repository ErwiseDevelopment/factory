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
   public class financeiro : GXDataArea
   {
      public financeiro( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public financeiro( IGxContext context )
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
         nRC_GXsfl_27 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_27"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_27_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_27_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_27_idx = GetPar( "sGXsfl_27_idx");
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
         AV36Competencia = (int)(Math.Round(NumberUtil.Val( GetPar( "Competencia"), "."), 18, MidpointRounding.ToEven));
         AV24Visible = StringUtil.StrToBool( GetPar( "Visible"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV34SdDashboardFinanceiroCards);
         Gx_date = context.localUtil.ParseDateParm( GetPar( "Gx_date"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrFreegrid_refresh( AV36Competencia, AV24Visible, AV34SdDashboardFinanceiroCards, Gx_date) ;
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
         PA072( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START072( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("financeiro") +"\">") ;
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDDASHBOARDFINANCEIROCARDS", AV34SdDashboardFinanceiroCards);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDDASHBOARDFINANCEIROCARDS", AV34SdDashboardFinanceiroCards);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vSDDASHBOARDFINANCEIROCARDS", GetSecureSignedToken( "", AV34SdDashboardFinanceiroCards, context));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_27", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_27), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDDASHBOARDFINANCEIROCARDS", AV34SdDashboardFinanceiroCards);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDDASHBOARDFINANCEIROCARDS", AV34SdDashboardFinanceiroCards);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vSDDASHBOARDFINANCEIROCARDS", GetSecureSignedToken( "", AV34SdDashboardFinanceiroCards, context));
         GxWebStd.gx_hidden_field( context, "vANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV38Ano), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37Mes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vCOMPETENCIA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV36Competencia), 6, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vVISIBLE", AV24Visible);
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GxWebStd.gx_hidden_field( context, "subFreegrid_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreegrid_Recordcount), 5, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "DDC_MODULES_Caption", StringUtil.RTrim( Ddc_modules_Caption));
         GxWebStd.gx_hidden_field( context, "DDC_MODULES_Cls", StringUtil.RTrim( Ddc_modules_Cls));
         GxWebStd.gx_hidden_field( context, "DDC_MODULES_Componentwidth", StringUtil.LTrim( StringUtil.NToC( (decimal)(Ddc_modules_Componentwidth), 9, 0, ".", "")));
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
         if ( ! ( WebComp_Wcwccardvalue == null ) )
         {
            WebComp_Wcwccardvalue.componentjscripts();
         }
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            WebComp_Wwpaux_wc.componentjscripts();
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
            WE072( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT072( ) ;
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
         return formatLink("financeiro")  ;
      }

      public override string GetPgmname( )
      {
         return "Financeiro" ;
      }

      public override string GetPgmdesc( )
      {
         return "Financeiro" ;
      }

      protected void WB070( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecompetencia_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "justify-content:center;align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "hidden-xs", "start", "top", "", "align-self:center;", "div");
            /* User Defined Control */
            ucDdc_modules.SetProperty("Caption", Ddc_modules_Caption);
            ucDdc_modules.SetProperty("Cls", Ddc_modules_Cls);
            ucDdc_modules.SetProperty("ComponentWidth", Ddc_modules_Componentwidth);
            ucDdc_modules.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_modules_Internalname, "DDC_MODULESContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableshowvalue_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table1_17_072( true) ;
         }
         else
         {
            wb_table1_17_072( false) ;
         }
         return  ;
      }

      protected void wb_table1_17_072e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecards_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            FreegridContainer.SetIsFreestyle(true);
            FreegridContainer.SetWrapped(nGXWrapped);
            StartGridControl27( ) ;
         }
         if ( wbEnd == 27 )
         {
            wbEnd = 0;
            nRC_GXsfl_27 = (int)(nGXsfl_27_idx-1);
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0036"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0036"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_27_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0036"+"");
                     }
                     WebComp_Wwpaux_wc.componentdraw();
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
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
         }
         if ( wbEnd == 27 )
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

      protected void START072( )
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
         Form.Meta.addItem("description", "Financeiro", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP070( ) ;
      }

      protected void WS072( )
      {
         START072( ) ;
         EVT072( ) ;
      }

      protected void EVT072( )
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
                           else if ( StringUtil.StrCmp(sEvt, "DDC_MODULES.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddc_modules.Onloadcomponent */
                              E11072 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS.FINANCEIROREFRESH_COMPETENCIA") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E12072 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "FREEGRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_27_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_27_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_27_idx), 4, 0), 4, "0");
                              SubsflControlProps_272( ) ;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E13072 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "FREEGRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Freegrid.Load */
                                    E14072 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E15072 ();
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
                           OldWwpaux_wc = cgiGet( "W0036");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0036", "", sEvt);
                           }
                           WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                        }
                        else if ( nCmpId == 31 )
                        {
                           sEvtType = StringUtil.Left( sEvt, 4);
                           sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           sCmpCtrl = "W0031" + sEvtType;
                           OldWcwccardvalue = cgiGet( sCmpCtrl);
                           if ( ( StringUtil.Len( OldWcwccardvalue) == 0 ) || ( StringUtil.StrCmp(OldWcwccardvalue, WebComp_GX_Process_Component) != 0 ) )
                           {
                              WebComp_GX_Process = getWebComponent(GetType(), "GeneXus.Programs", OldWcwccardvalue, new Object[] {context} );
                              WebComp_GX_Process.ComponentInit();
                              WebComp_GX_Process.Name = "OldWcwccardvalue";
                              WebComp_GX_Process_Component = OldWcwccardvalue;
                           }
                           if ( StringUtil.Len( WebComp_GX_Process_Component) != 0 )
                           {
                              WebComp_GX_Process.componentprocess("W0031", sEvtType, sEvt);
                           }
                           nGXsfl_27_webc_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                           WebCompHandler = "Wcwccardvalue";
                           WebComp_GX_Process_Component = OldWcwccardvalue;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE072( )
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

      protected void PA072( )
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
         SubsflControlProps_272( ) ;
         while ( nGXsfl_27_idx <= nRC_GXsfl_27 )
         {
            sendrow_272( ) ;
            nGXsfl_27_idx = ((subFreegrid_Islastpage==1)&&(nGXsfl_27_idx+1>subFreegrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_27_idx+1);
            sGXsfl_27_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_27_idx), 4, 0), 4, "0");
            SubsflControlProps_272( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( FreegridContainer)) ;
         /* End function gxnrFreegrid_newrow */
      }

      protected void gxgrFreegrid_refresh( int AV36Competencia ,
                                           bool AV24Visible ,
                                           GXBaseCollection<SdtSdDashboardFinanceiroCards_Item> AV34SdDashboardFinanceiroCards ,
                                           DateTime Gx_date )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         FREEGRID_nCurrentRecord = 0;
         RF072( ) ;
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
         RF072( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      protected void RF072( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            FreegridContainer.ClearRows();
         }
         wbStart = 27;
         /* Execute user event: Refresh */
         E15072 ();
         nGXsfl_27_idx = 1;
         sGXsfl_27_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_27_idx), 4, 0), 4, "0");
         SubsflControlProps_272( ) ;
         bGXsfl_27_Refreshing = true;
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
               if ( StringUtil.Len( WebComp_Wcwccardvalue_Component) != 0 )
               {
                  WebComp_Wcwccardvalue.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  WebComp_Wwpaux_wc.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_272( ) ;
            /* Execute user event: Freegrid.Load */
            E14072 ();
            wbEnd = 27;
            WB070( ) ;
         }
         bGXsfl_27_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes072( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDDASHBOARDFINANCEIROCARDS", AV34SdDashboardFinanceiroCards);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDDASHBOARDFINANCEIROCARDS", AV34SdDashboardFinanceiroCards);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vSDDASHBOARDFINANCEIROCARDS", GetSecureSignedToken( "", AV34SdDashboardFinanceiroCards, context));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
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
         Gx_date = DateTimeUtil.Today( context);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP070( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E13072 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_27 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_27"), ",", "."), 18, MidpointRounding.ToEven));
            AV24Visible = StringUtil.StrToBool( cgiGet( "vVISIBLE"));
            subFreegrid_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "subFreegrid_Recordcount"), ",", "."), 18, MidpointRounding.ToEven));
            Ddc_modules_Caption = cgiGet( "DDC_MODULES_Caption");
            Ddc_modules_Cls = cgiGet( "DDC_MODULES_Cls");
            Ddc_modules_Componentwidth = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DDC_MODULES_Componentwidth"), ",", "."), 18, MidpointRounding.ToEven));
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
         E13072 ();
         if (returnInSub) return;
      }

      protected void E13072( )
      {
         /* Start Routine */
         returnInSub = false;
         AV37Mes = (short)(DateTimeUtil.Month( Gx_date));
         AssignAttri("", false, "AV37Mes", StringUtil.LTrimStr( (decimal)(AV37Mes), 4, 0));
         AV38Ano = (short)(DateTimeUtil.Year( Gx_date));
         AssignAttri("", false, "AV38Ano", StringUtil.LTrimStr( (decimal)(AV38Ano), 4, 0));
         AV36Competencia = (int)(AV38Ano*100+AV37Mes);
         AssignAttri("", false, "AV36Competencia", StringUtil.LTrimStr( (decimal)(AV36Competencia), 6, 0));
         AV39CompetenciaDate = Gx_date;
         Ddc_modules_Caption = StringUtil.Upper( StringUtil.Substring( DateTimeUtil.CMonth( AV39CompetenciaDate, "por"), 1, 3));
         ucDdc_modules.SendProperty(context, "", false, Ddc_modules_Internalname, "Caption", Ddc_modules_Caption);
         /* Execute user subroutine: 'SHOWHIDEEYE' */
         S112 ();
         if (returnInSub) return;
      }

      private void E14072( )
      {
         /* Freegrid_Load Routine */
         returnInSub = false;
         AV42GXV1 = 1;
         while ( AV42GXV1 <= AV34SdDashboardFinanceiroCards.Count )
         {
            AV35SdDashboardFinanceiroCardsItem = ((SdtSdDashboardFinanceiroCards_Item)AV34SdDashboardFinanceiroCards.Item(AV42GXV1));
            /* Object Property */
            if ( true )
            {
               bDynCreated_Wcwccardvalue = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcwccardvalue_Component), StringUtil.Lower( "WcCardValue")) != 0 )
            {
               WebComp_Wcwccardvalue = getWebComponent(GetType(), "GeneXus.Programs", "wccardvalue", new Object[] {context} );
               WebComp_Wcwccardvalue.ComponentInit();
               WebComp_Wcwccardvalue.Name = "WcCardValue";
               WebComp_Wcwccardvalue_Component = "WcCardValue";
            }
            if ( StringUtil.Len( WebComp_Wcwccardvalue_Component) != 0 )
            {
               WebComp_Wcwccardvalue.setjustcreated();
               WebComp_Wcwccardvalue.componentprepare(new Object[] {(string)"W0031",(string)sGXsfl_27_idx,(SdtSdDashboardFinanceiroCards_Item)AV35SdDashboardFinanceiroCardsItem});
               WebComp_Wcwccardvalue.componentbind(new Object[] {(string)""});
            }
            if ( ! bGXsfl_27_Refreshing )
            {
               if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wcwccardvalue )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0031"+sGXsfl_27_idx);
                  WebComp_Wcwccardvalue.componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 27;
            }
            sendrow_272( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_27_Refreshing )
            {
               DoAjaxLoad(27, FreegridRow);
            }
            AV42GXV1 = (int)(AV42GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      protected void E11072( )
      {
         /* Ddc_modules_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WcYear")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wcyear", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WcYear";
            WebComp_Wwpaux_wc_Component = "WcYear";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0036",(string)"",(short)AV38Ano,(short)AV37Mes});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0036"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E15072( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new prcardsdashboardfinanceiro(context ).execute(  AV36Competencia,  AV24Visible, out  AV34SdDashboardFinanceiroCards) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV34SdDashboardFinanceiroCards", AV34SdDashboardFinanceiroCards);
      }

      protected void E12072( )
      {
         /* General\GlobalEvents_Financeirorefresh_competencia Routine */
         returnInSub = false;
         AV36Competencia = (int)(AV38Ano*100+AV37Mes);
         AssignAttri("", false, "AV36Competencia", StringUtil.LTrimStr( (decimal)(AV36Competencia), 6, 0));
         AV39CompetenciaDate = context.localUtil.YMDToD( AV38Ano, AV37Mes, 1);
         if ( AV38Ano != DateTimeUtil.Year( Gx_date) )
         {
            Ddc_modules_Caption = StringUtil.Format( "%1 - %2", StringUtil.Upper( StringUtil.Substring( DateTimeUtil.CMonth( AV39CompetenciaDate, "por"), 1, 3)), StringUtil.LTrimStr( (decimal)(AV38Ano), 4, 0), "", "", "", "", "", "", "");
            ucDdc_modules.SendProperty(context, "", false, Ddc_modules_Internalname, "Caption", Ddc_modules_Caption);
         }
         else
         {
            Ddc_modules_Caption = StringUtil.Upper( StringUtil.Substring( DateTimeUtil.CMonth( AV39CompetenciaDate, "por"), 1, 3));
            ucDdc_modules.SendProperty(context, "", false, Ddc_modules_Internalname, "Caption", Ddc_modules_Caption);
         }
         this.executeUsercontrolMethod("", false, "DDC_MODULESContainer", "Close", "", new Object[] {});
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV34SdDashboardFinanceiroCards", AV34SdDashboardFinanceiroCards);
      }

      protected void S112( )
      {
         /* 'SHOWHIDEEYE' Routine */
         returnInSub = false;
         if ( AV24Visible )
         {
            lblVisualizar_Caption = "<i class='fas fa-eye-slash' title='Visualizar valores' style='font-size: 24px'></i>";
            AssignProp("", false, lblVisualizar_Internalname, "Caption", lblVisualizar_Caption, true);
            lblLblshow_Caption = "Esconder valores";
            AssignProp("", false, lblLblshow_Internalname, "Caption", lblLblshow_Caption, true);
         }
         else
         {
            lblVisualizar_Caption = "<i class='fas fa-eye' title='Visualizar valores' style='font-size: 24px'></i>";
            AssignProp("", false, lblVisualizar_Internalname, "Caption", lblVisualizar_Caption, true);
            lblLblshow_Caption = "Exibir valores";
            AssignProp("", false, lblLblshow_Internalname, "Caption", lblLblshow_Caption, true);
         }
      }

      protected void wb_table1_17_072( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedlblshow_Internalname, tblTablemergedlblshow_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblshow_Internalname, lblLblshow_Caption, "", "", lblLblshow_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockNotAuthorized", 0, "", 1, 1, 0, 0, "HLP_Financeiro.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblVisualizar_Internalname, lblVisualizar_Caption, "", "", lblVisualizar_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_Financeiro.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_17_072e( true) ;
         }
         else
         {
            wb_table1_17_072e( false) ;
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
         PA072( ) ;
         WS072( ) ;
         WE072( ) ;
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
         if ( ! ( WebComp_Wcwccardvalue == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcwccardvalue_Component) != 0 )
            {
               WebComp_Wcwccardvalue.componentthemes();
            }
         }
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
            {
               WebComp_Wwpaux_wc.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019223723", true, true);
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
         context.AddJavascriptSource("financeiro.js", "?202561019223724", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_272( )
      {
      }

      protected void SubsflControlProps_fel_272( )
      {
      }

      protected void sendrow_272( )
      {
         sGXsfl_27_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_27_idx), 4, 0), 4, "0");
         SubsflControlProps_272( ) ;
         WB070( ) ;
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
            if ( ((int)((nGXsfl_27_idx) % (2))) == 0 )
            {
               subFreegrid_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subFreegrid_Class, "") != 0 )
               {
                  subFreegrid_Linesclass = subFreegrid_Class+"Even";
               }
            }
            else
            {
               subFreegrid_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subFreegrid_Class, "") != 0 )
               {
                  subFreegrid_Linesclass = subFreegrid_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( FreegridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subFreegrid_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_27_idx+"\">") ;
         }
         /* Div Control */
         FreegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divMainlayout_Internalname+"_"+sGXsfl_27_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"CellMarginTop",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FreegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FreegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* WebComponent */
         GxWebStd.gx_hidden_field( context, "W0031"+sGXsfl_27_idx, StringUtil.RTrim( WebComp_Wcwccardvalue_Component));
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gxwebcomponent"+" gxwebcomponent-loading");
         context.WriteHtmlText( " id=\""+"gxHTMLWrpW0031"+sGXsfl_27_idx+"\""+"") ;
         context.WriteHtmlText( ">") ;
         if ( bGXsfl_27_Refreshing )
         {
            if ( StringUtil.Len( WebComp_Wcwccardvalue_Component) != 0 )
            {
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StringSearch( "W0031"+sGXsfl_27_idx, cgiGet( "_EventName"), 1) != 0 ) )
               {
                  if ( 1 != 0 )
                  {
                     if ( StringUtil.Len( WebComp_Wcwccardvalue_Component) != 0 )
                     {
                        WebComp_Wcwccardvalue.componentstart();
                     }
                  }
               }
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldWcwccardvalue), StringUtil.Lower( WebComp_Wcwccardvalue_Component)) != 0 ) )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0031"+sGXsfl_27_idx);
               }
               WebComp_Wcwccardvalue.componentdraw();
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldWcwccardvalue), StringUtil.Lower( WebComp_Wcwccardvalue_Component)) != 0 ) )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
            }
         }
         context.WriteHtmlText( "</div>") ;
         WebComp_Wcwccardvalue_Component = "";
         WebComp_Wcwccardvalue.componentjscripts();
         FreegridRow.AddColumnProperties("webcomp", -1, isAjaxCallMode( ), new Object[] {(string)"Wcwccardvalue"});
         FreegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FreegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FreegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         send_integrity_lvl_hashes072( ) ;
         /* End of Columns property logic. */
         FreegridContainer.AddRow(FreegridRow);
         nGXsfl_27_idx = ((subFreegrid_Islastpage==1)&&(nGXsfl_27_idx+1>subFreegrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_27_idx+1);
         sGXsfl_27_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_27_idx), 4, 0), 4, "0");
         SubsflControlProps_272( ) ;
         /* End function sendrow_272 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl27( )
      {
         if ( FreegridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"FreegridContainer"+"DivS\" data-gxgridid=\"27\">") ;
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
         Ddc_modules_Internalname = "DDC_MODULES";
         divTablecompetencia_Internalname = "TABLECOMPETENCIA";
         lblLblshow_Internalname = "LBLSHOW";
         lblVisualizar_Internalname = "VISUALIZAR";
         tblTablemergedlblshow_Internalname = "TABLEMERGEDLBLSHOW";
         divTableshowvalue_Internalname = "TABLESHOWVALUE";
         divMainlayout_Internalname = "MAINLAYOUT";
         divTablecards_Internalname = "TABLECARDS";
         divTablemain_Internalname = "TABLEMAIN";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subFreegrid_Internalname = "FREEGRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subFreegrid_Allowcollapsing = 0;
         subFreegrid_Class = "FreeStyleGrid";
         lblLblshow_Caption = "Mostrar valores";
         lblVisualizar_Caption = "<i class='fas fa-eye-slash' title='Visualizar valores' style='font-size: 24px'></i>";
         subFreegrid_Backcolorstyle = 0;
         Ddc_modules_Componentwidth = 450;
         Ddc_modules_Cls = "ModulesMenuButtonDark";
         Ddc_modules_Caption = "SET";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Financeiro";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"FREEGRID_nFirstRecordOnPage","type":"int"},{"av":"FREEGRID_nEOF","type":"int"},{"av":"AV36Competencia","fld":"vCOMPETENCIA","pic":"ZZZZZ9","type":"int"},{"av":"AV24Visible","fld":"vVISIBLE","type":"boolean"},{"av":"AV34SdDashboardFinanceiroCards","fld":"vSDDASHBOARDFINANCEIROCARDS","hsh":true,"type":""},{"av":"Gx_date","fld":"vTODAY","hsh":true,"type":"date"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV34SdDashboardFinanceiroCards","fld":"vSDDASHBOARDFINANCEIROCARDS","hsh":true,"type":""}]}""");
         setEventMetadata("FREEGRID.LOAD","""{"handler":"E14072","iparms":[{"av":"AV34SdDashboardFinanceiroCards","fld":"vSDDASHBOARDFINANCEIROCARDS","hsh":true,"type":""}]""");
         setEventMetadata("FREEGRID.LOAD",""","oparms":[{"ctrl":"WCWCCARDVALUE"}]}""");
         setEventMetadata("DDC_MODULES.ONLOADCOMPONENT","""{"handler":"E11072","iparms":[{"av":"AV38Ano","fld":"vANO","pic":"ZZZ9","type":"int"},{"av":"AV37Mes","fld":"vMES","pic":"ZZZ9","type":"int"}]""");
         setEventMetadata("DDC_MODULES.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("GLOBALEVENTS.FINANCEIROREFRESH_COMPETENCIA","""{"handler":"E12072","iparms":[{"av":"FREEGRID_nFirstRecordOnPage","type":"int"},{"av":"FREEGRID_nEOF","type":"int"},{"av":"AV36Competencia","fld":"vCOMPETENCIA","pic":"ZZZZZ9","type":"int"},{"av":"AV24Visible","fld":"vVISIBLE","type":"boolean"},{"av":"AV34SdDashboardFinanceiroCards","fld":"vSDDASHBOARDFINANCEIROCARDS","hsh":true,"type":""},{"av":"Gx_date","fld":"vTODAY","hsh":true,"type":"date"},{"av":"AV37Mes","fld":"vMES","pic":"ZZZ9","type":"int"},{"av":"AV38Ano","fld":"vANO","pic":"ZZZ9","type":"int"}]""");
         setEventMetadata("GLOBALEVENTS.FINANCEIROREFRESH_COMPETENCIA",""","oparms":[{"av":"AV36Competencia","fld":"vCOMPETENCIA","pic":"ZZZZZ9","type":"int"},{"av":"Ddc_modules_Caption","ctrl":"DDC_MODULES","prop":"Caption"},{"av":"AV34SdDashboardFinanceiroCards","fld":"vSDDASHBOARDFINANCEIROCARDS","hsh":true,"type":""}]}""");
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
         AV34SdDashboardFinanceiroCards = new GXBaseCollection<SdtSdDashboardFinanceiroCards_Item>( context, "Item", "Factory21");
         Gx_date = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ucDdc_modules = new GXUserControl();
         FreegridContainer = new GXWebGrid( context);
         sStyleString = "";
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         OldWcwccardvalue = "";
         sCmpCtrl = "";
         WebComp_GX_Process_Component = "";
         WebComp_Wcwccardvalue_Component = "";
         AV39CompetenciaDate = DateTime.MinValue;
         AV35SdDashboardFinanceiroCardsItem = new SdtSdDashboardFinanceiroCards_Item(context);
         FreegridRow = new GXWebRow();
         lblLblshow_Jsonclick = "";
         lblVisualizar_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subFreegrid_Linesclass = "";
         subFreegrid_Header = "";
         FreegridColumn = new GXWebColumn();
         WebComp_GX_Process = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wcwccardvalue = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short AV38Ano ;
      private short AV37Mes ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subFreegrid_Backcolorstyle ;
      private short FREEGRID_nEOF ;
      private short nGXWrapped ;
      private short subFreegrid_Backstyle ;
      private short subFreegrid_Allowselection ;
      private short subFreegrid_Allowhovering ;
      private short subFreegrid_Allowcollapsing ;
      private short subFreegrid_Collapsed ;
      private int nRC_GXsfl_27 ;
      private int subFreegrid_Recordcount ;
      private int nGXsfl_27_idx=1 ;
      private int AV36Competencia ;
      private int Ddc_modules_Componentwidth ;
      private int nGXsfl_27_webc_idx=0 ;
      private int subFreegrid_Islastpage ;
      private int AV42GXV1 ;
      private int idxLst ;
      private int subFreegrid_Backcolor ;
      private int subFreegrid_Allbackcolor ;
      private int subFreegrid_Selectedindex ;
      private int subFreegrid_Selectioncolor ;
      private int subFreegrid_Hoveringcolor ;
      private long FREEGRID_nCurrentRecord ;
      private long FREEGRID_nFirstRecordOnPage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_27_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Ddc_modules_Caption ;
      private string Ddc_modules_Cls ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTablecompetencia_Internalname ;
      private string Ddc_modules_Internalname ;
      private string divTableshowvalue_Internalname ;
      private string divTablecards_Internalname ;
      private string sStyleString ;
      private string subFreegrid_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string OldWcwccardvalue ;
      private string sCmpCtrl ;
      private string WebComp_GX_Process_Component ;
      private string WebCompHandler="" ;
      private string WebComp_Wcwccardvalue_Component ;
      private string lblVisualizar_Caption ;
      private string lblVisualizar_Internalname ;
      private string lblLblshow_Caption ;
      private string lblLblshow_Internalname ;
      private string tblTablemergedlblshow_Internalname ;
      private string lblLblshow_Jsonclick ;
      private string lblVisualizar_Jsonclick ;
      private string subFreegrid_Class ;
      private string subFreegrid_Linesclass ;
      private string divMainlayout_Internalname ;
      private string subFreegrid_Header ;
      private DateTime Gx_date ;
      private DateTime AV39CompetenciaDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV24Visible ;
      private bool wbLoad ;
      private bool bGXsfl_27_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool bDynCreated_Wcwccardvalue ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool gx_refresh_fired ;
      private GXWebComponent WebComp_Wcwccardvalue ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXWebGrid FreegridContainer ;
      private GXWebRow FreegridRow ;
      private GXWebColumn FreegridColumn ;
      private GXUserControl ucDdc_modules ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSdDashboardFinanceiroCards_Item> AV34SdDashboardFinanceiroCards ;
      private GXWebComponent WebComp_GX_Process ;
      private SdtSdDashboardFinanceiroCards_Item AV35SdDashboardFinanceiroCardsItem ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
