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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class serasaww : GXWebComponent
   {
      public serasaww( )
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

      public serasaww( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ClientesIds ,
                           int aP1_PropostaId )
      {
         this.AV54ClientesIds = aP0_ClientesIds;
         this.AV56PropostaId = aP1_PropostaId;
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
         cmbavDynamicfiltersselector1 = new GXCombobox();
         cmbavDynamicfiltersoperator1 = new GXCombobox();
         cmbavDynamicfiltersselector2 = new GXCombobox();
         cmbavDynamicfiltersoperator2 = new GXCombobox();
         cmbavDynamicfiltersselector3 = new GXCombobox();
         cmbavDynamicfiltersoperator3 = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "ClientesIds");
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
                  AV54ClientesIds = GetPar( "ClientesIds");
                  AssignAttri(sPrefix, false, "AV54ClientesIds", AV54ClientesIds);
                  AV56PropostaId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV56PropostaId", StringUtil.LTrimStr( (decimal)(AV56PropostaId), 9, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV54ClientesIds,(int)AV56PropostaId});
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
                  gxfirstwebparm = GetFirstPar( "ClientesIds");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "ClientesIds");
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
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_107 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_107"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_107_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_107_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_107_idx = GetPar( "sGXsfl_107_idx");
         sPrefix = GetPar( "sPrefix");
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
         AV13OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV14OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV15FilterFullText = GetPar( "FilterFullText");
         cmbavDynamicfiltersselector1.FromJSonString( GetNextPar( ));
         AV16DynamicFiltersSelector1 = GetPar( "DynamicFiltersSelector1");
         cmbavDynamicfiltersoperator1.FromJSonString( GetNextPar( ));
         AV17DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator1"), "."), 18, MidpointRounding.ToEven));
         AV18SerasaNumeroProposta1 = GetPar( "SerasaNumeroProposta1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV20DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV21DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV22SerasaNumeroProposta2 = GetPar( "SerasaNumeroProposta2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV24DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV25DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV26SerasaNumeroProposta3 = GetPar( "SerasaNumeroProposta3");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV55Array_ClienteId);
         AV34ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV62Pgmname = GetPar( "Pgmname");
         AV19DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV23DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV52TFClienteRazaoSocial = GetPar( "TFClienteRazaoSocial");
         AV53TFClienteRazaoSocial_Sel = GetPar( "TFClienteRazaoSocial_Sel");
         AV35TFSerasaNumeroProposta = GetPar( "TFSerasaNumeroProposta");
         AV36TFSerasaNumeroProposta_Sel = GetPar( "TFSerasaNumeroProposta_Sel");
         AV37TFSerasaPolitica = NumberUtil.Val( GetPar( "TFSerasaPolitica"), ".");
         AV38TFSerasaPolitica_To = NumberUtil.Val( GetPar( "TFSerasaPolitica_To"), ".");
         AV39TFSerasaCreatedAt = context.localUtil.ParseDTimeParm( GetPar( "TFSerasaCreatedAt"));
         AV40TFSerasaCreatedAt_To = context.localUtil.ParseDTimeParm( GetPar( "TFSerasaCreatedAt_To"));
         AV44TFSerasaTipoVenda = GetPar( "TFSerasaTipoVenda");
         AV45TFSerasaTipoVenda_Sel = GetPar( "TFSerasaTipoVenda_Sel");
         AV54ClientesIds = GetPar( "ClientesIds");
         AV56PropostaId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaId"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridState);
         AV28DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV27DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         AV59PropostaResponsavelId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaResponsavelId"), "."), 18, MidpointRounding.ToEven));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18SerasaNumeroProposta1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22SerasaNumeroProposta2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26SerasaNumeroProposta3, AV55Array_ClienteId, AV34ManageFiltersExecutionStep, AV62Pgmname, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV52TFClienteRazaoSocial, AV53TFClienteRazaoSocial_Sel, AV35TFSerasaNumeroProposta, AV36TFSerasaNumeroProposta_Sel, AV37TFSerasaPolitica, AV38TFSerasaPolitica_To, AV39TFSerasaCreatedAt, AV40TFSerasaCreatedAt_To, AV44TFSerasaTipoVenda, AV45TFSerasaTipoVenda_Sel, AV54ClientesIds, AV56PropostaId, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, AV59PropostaResponsavelId, sPrefix) ;
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
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA7W2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV62Pgmname = "SerasaWW";
               edtavDisplay_Enabled = 0;
               AssignProp(sPrefix, false, edtavDisplay_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDisplay_Enabled), 5, 0), !bGXsfl_107_Refreshing);
               WS7W2( ) ;
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
            context.SendWebValue( " Serasa") ;
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("calendar-pt.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
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
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "serasaww"+UrlEncode(StringUtil.RTrim(AV54ClientesIds)) + "," + UrlEncode(StringUtil.LTrimStr(AV56PropostaId,9,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("serasaww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV62Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV62Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPROPOSTARESPONSAVELID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV59PropostaResponsavelId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROPOSTARESPONSAVELID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV59PropostaResponsavelId), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDDSC", StringUtil.BoolToStr( AV14OrderedDsc));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vFILTERFULLTEXT", AV15FilterFullText);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSSELECTOR1", AV16DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17DynamicFiltersOperator1), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vSERASANUMEROPROPOSTA1", AV18SerasaNumeroProposta1);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSSELECTOR2", AV20DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vSERASANUMEROPROPOSTA2", AV22SerasaNumeroProposta2);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSSELECTOR3", AV24DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vSERASANUMEROPROPOSTA3", AV26SerasaNumeroProposta3);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_107", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_107), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vMANAGEFILTERSDATA", AV32ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vMANAGEFILTERSDATA", AV32ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV48GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV49GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDAPPLIEDFILTERS", AV50GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV46DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV46DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_SERASACREATEDATAUXDATE", context.localUtil.DToC( AV41DDO_SerasaCreatedAtAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_SERASACREATEDATAUXDATETO", context.localUtil.DToC( AV42DDO_SerasaCreatedAtAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV54ClientesIds", wcpOAV54ClientesIds);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV56PropostaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV56PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV62Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV62Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSENABLED2", AV19DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSENABLED3", AV23DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCLIENTERAZAOSOCIAL", AV52TFClienteRazaoSocial);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCLIENTERAZAOSOCIAL_SEL", AV53TFClienteRazaoSocial_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASANUMEROPROPOSTA", AV35TFSerasaNumeroProposta);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASANUMEROPROPOSTA_SEL", AV36TFSerasaNumeroProposta_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAPOLITICA", StringUtil.LTrim( StringUtil.NToC( AV37TFSerasaPolitica, 15, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAPOLITICA_TO", StringUtil.LTrim( StringUtil.NToC( AV38TFSerasaPolitica_To, 15, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASACREATEDAT", context.localUtil.TToC( AV39TFSerasaCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASACREATEDAT_TO", context.localUtil.TToC( AV40TFSerasaCreatedAt_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASATIPOVENDA", AV44TFSerasaTipoVenda);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASATIPOVENDA_SEL", AV45TFSerasaTipoVenda_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vORDEREDDSC", AV14OrderedDsc);
         GxWebStd.gx_hidden_field( context, sPrefix+"vCLIENTESIDS", AV54ClientesIds);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV56PropostaId), 9, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vGRIDSTATE", AV10GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vGRIDSTATE", AV10GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSIGNOREFIRST", AV28DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSREMOVING", AV27DynamicFiltersRemoving);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPROPOSTARESPONSAVELID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV59PropostaResponsavelId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROPOSTARESPONSAVELID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV59PropostaResponsavelId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTIPO", AV60Tipo);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vARRAY_CLIENTEID", AV55Array_ClienteId);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vARRAY_CLIENTEID", AV55Array_ClienteId);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Icontype", StringUtil.RTrim( Ddo_managefilters_Icontype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Icon", StringUtil.RTrim( Ddo_managefilters_Icon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Tooltip", StringUtil.RTrim( Ddo_managefilters_Tooltip));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Cls", StringUtil.RTrim( Ddo_managefilters_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEHEADER_Width", StringUtil.RTrim( Dvpanel_tableheader_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEHEADER_Autowidth", StringUtil.BoolToStr( Dvpanel_tableheader_Autowidth));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEHEADER_Autoheight", StringUtil.BoolToStr( Dvpanel_tableheader_Autoheight));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEHEADER_Cls", StringUtil.RTrim( Dvpanel_tableheader_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEHEADER_Title", StringUtil.RTrim( Dvpanel_tableheader_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEHEADER_Collapsible", StringUtil.BoolToStr( Dvpanel_tableheader_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEHEADER_Collapsed", StringUtil.BoolToStr( Dvpanel_tableheader_Collapsed));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEHEADER_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableheader_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEHEADER_Iconposition", StringUtil.RTrim( Dvpanel_tableheader_Iconposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEHEADER_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableheader_Autoscroll));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Class", StringUtil.RTrim( Gridpaginationbar_Class));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridpaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridpaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridpaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridpaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridpaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridpaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridpaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridpaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridpaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Previous", StringUtil.RTrim( Gridpaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Next", StringUtil.RTrim( Gridpaginationbar_Next));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Caption", StringUtil.RTrim( Gridpaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridpaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridpaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_set", StringUtil.RTrim( Ddo_grid_Filteredtextto_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filterisrange", StringUtil.RTrim( Ddo_grid_Filterisrange));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_CONSULTASERASA_Title", StringUtil.RTrim( Dvelop_confirmpanel_consultaserasa_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_CONSULTASERASA_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_consultaserasa_Confirmationtext));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_CONSULTASERASA_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_consultaserasa_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_CONSULTASERASA_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_consultaserasa_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_CONSULTASERASA_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_consultaserasa_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_CONSULTASERASA_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_consultaserasa_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_CONSULTASERASA_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_consultaserasa_Confirmtype));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_CONSULTASERASA_Result", StringUtil.RTrim( Dvelop_confirmpanel_consultaserasa_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_CONSULTASERASA_Result", StringUtil.RTrim( Dvelop_confirmpanel_consultaserasa_Result));
      }

      protected void RenderHtmlCloseForm7W2( )
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
         return "SerasaWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Serasa" ;
      }

      protected void WB7W0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "serasaww");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingBottom", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tableheader.SetProperty("Width", Dvpanel_tableheader_Width);
            ucDvpanel_tableheader.SetProperty("AutoWidth", Dvpanel_tableheader_Autowidth);
            ucDvpanel_tableheader.SetProperty("AutoHeight", Dvpanel_tableheader_Autoheight);
            ucDvpanel_tableheader.SetProperty("Cls", Dvpanel_tableheader_Cls);
            ucDvpanel_tableheader.SetProperty("Title", Dvpanel_tableheader_Title);
            ucDvpanel_tableheader.SetProperty("Collapsible", Dvpanel_tableheader_Collapsible);
            ucDvpanel_tableheader.SetProperty("Collapsed", Dvpanel_tableheader_Collapsed);
            ucDvpanel_tableheader.SetProperty("ShowCollapseIcon", Dvpanel_tableheader_Showcollapseicon);
            ucDvpanel_tableheader.SetProperty("IconPosition", Dvpanel_tableheader_Iconposition);
            ucDvpanel_tableheader.SetProperty("AutoScroll", Dvpanel_tableheader_Autoscroll);
            ucDvpanel_tableheader.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableheader_Internalname, sPrefix+"DVPANEL_TABLEHEADERContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVPANEL_TABLEHEADERContainer"+"TableHeader"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheadercontent_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupColoredActions", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnconsultaserasa_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(107), 3, 0)+","+"null"+");", "Nova consulta Serasa", bttBtnconsultaserasa_Jsonclick, 7, "Nova consulta Serasa", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e117w1_client"+"'", TempTags, "", 2, "HLP_SerasaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonExcel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(107), 3, 0)+","+"null"+");", "Excel", bttBtnexport_Jsonclick, 5, "Exportar para Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_SerasaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablerightheader_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucDdo_managefilters.SetProperty("IconType", Ddo_managefilters_Icontype);
            ucDdo_managefilters.SetProperty("Icon", Ddo_managefilters_Icon);
            ucDdo_managefilters.SetProperty("Caption", Ddo_managefilters_Caption);
            ucDdo_managefilters.SetProperty("Tooltip", Ddo_managefilters_Tooltip);
            ucDdo_managefilters.SetProperty("Cls", Ddo_managefilters_Cls);
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV32ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, sPrefix+"DDO_MANAGEFILTERSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablefilters_Internalname, 1, 0, "px", 0, "px", "TableFilters", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilterfulltext_Internalname, "Filter Full Text", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_SerasaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellAdvancedFiltersHidden", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAdvancedfilterscontainer_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;justify-content:flex-end;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfilters_Internalname, 1, 0, "px", 0, "px", "TableDynamicFiltersFlex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DynRowVisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfiltersrow1_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_SerasaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV16DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "", true, 0, "HLP_SerasaWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_SerasaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_45_7W2( true) ;
         }
         else
         {
            wb_table1_45_7W2( false) ;
         }
         return  ;
      }

      protected void wb_table1_45_7W2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfiltersrow2_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_SerasaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV20DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "", true, 0, "HLP_SerasaWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_SerasaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_67_7W2( true) ;
         }
         else
         {
            wb_table2_67_7W2( false) ;
         }
         return  ;
      }

      protected void wb_table2_67_7W2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfiltersrow3_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_SerasaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV24DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,85);\"", "", true, 0, "HLP_SerasaWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_SerasaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_89_7W2( true) ;
         }
         else
         {
            wb_table3_89_7W2( false) ;
         }
         return  ;
      }

      protected void wb_table3_89_7W2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl107( ) ;
         }
         if ( wbEnd == 107 )
         {
            wbEnd = 0;
            nRC_GXsfl_107 = (int)(nGXsfl_107_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGridpaginationbar.SetProperty("Class", Gridpaginationbar_Class);
            ucGridpaginationbar.SetProperty("ShowFirst", Gridpaginationbar_Showfirst);
            ucGridpaginationbar.SetProperty("ShowPrevious", Gridpaginationbar_Showprevious);
            ucGridpaginationbar.SetProperty("ShowNext", Gridpaginationbar_Shownext);
            ucGridpaginationbar.SetProperty("ShowLast", Gridpaginationbar_Showlast);
            ucGridpaginationbar.SetProperty("PagesToShow", Gridpaginationbar_Pagestoshow);
            ucGridpaginationbar.SetProperty("PagingButtonsPosition", Gridpaginationbar_Pagingbuttonsposition);
            ucGridpaginationbar.SetProperty("PagingCaptionPosition", Gridpaginationbar_Pagingcaptionposition);
            ucGridpaginationbar.SetProperty("EmptyGridClass", Gridpaginationbar_Emptygridclass);
            ucGridpaginationbar.SetProperty("RowsPerPageSelector", Gridpaginationbar_Rowsperpageselector);
            ucGridpaginationbar.SetProperty("RowsPerPageOptions", Gridpaginationbar_Rowsperpageoptions);
            ucGridpaginationbar.SetProperty("Previous", Gridpaginationbar_Previous);
            ucGridpaginationbar.SetProperty("Next", Gridpaginationbar_Next);
            ucGridpaginationbar.SetProperty("Caption", Gridpaginationbar_Caption);
            ucGridpaginationbar.SetProperty("EmptyGridCaption", Gridpaginationbar_Emptygridcaption);
            ucGridpaginationbar.SetProperty("RowsPerPageCaption", Gridpaginationbar_Rowsperpagecaption);
            ucGridpaginationbar.SetProperty("CurrentPage", AV48GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV49GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV50GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, sPrefix+"GRIDPAGINATIONBARContainer");
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
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_SerasaWW.htm");
            /* User Defined Control */
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("FilterIsRange", Ddo_grid_Filterisrange);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV46DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, sPrefix+"DDO_GRIDContainer");
            wb_table4_124_7W2( true) ;
         }
         else
         {
            wb_table4_124_7W2( false) ;
         }
         return  ;
      }

      protected void wb_table4_124_7W2e( bool wbgen )
      {
         if ( wbgen )
         {
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, sPrefix+"GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_serasacreatedatauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 131,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_serasacreatedatauxdatetext_Internalname, AV43DDO_SerasaCreatedAtAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV43DDO_SerasaCreatedAtAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,131);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_serasacreatedatauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SerasaWW.htm");
            /* User Defined Control */
            ucTfserasacreatedat_rangepicker.SetProperty("Start Date", AV41DDO_SerasaCreatedAtAuxDate);
            ucTfserasacreatedat_rangepicker.SetProperty("End Date", AV42DDO_SerasaCreatedAtAuxDateTo);
            ucTfserasacreatedat_rangepicker.Render(context, "wwp.daterangepicker", Tfserasacreatedat_rangepicker_Internalname, sPrefix+"TFSERASACREATEDAT_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 107 )
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
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START7W2( )
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
            Form.Meta.addItem("description", " Serasa", 0) ;
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
               STRUP7W0( ) ;
            }
         }
      }

      protected void WS7W2( )
      {
         START7W2( ) ;
         EVT7W2( ) ;
      }

      protected void EVT7W2( )
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
                                 STRUP7W0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "DDO_MANAGEFILTERS.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7W0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_managefilters.Onoptionclicked */
                                    E127W2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7W0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changepage */
                                    E137W2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7W0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changerowsperpage */
                                    E147W2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7W0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_grid.Onoptionclicked */
                                    E157W2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_CONSULTASERASA.CLOSE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7W0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Dvelop_confirmpanel_consultaserasa.Close */
                                    E167W2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7W0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'RemoveDynamicFilters1' */
                                    E177W2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7W0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'RemoveDynamicFilters2' */
                                    E187W2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7W0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'RemoveDynamicFilters3' */
                                    E197W2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7W0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoExport' */
                                    E207W2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7W0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'AddDynamicFilters1' */
                                    E217W2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7W0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E227W2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7W0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'AddDynamicFilters2' */
                                    E237W2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7W0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E247W2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7W0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E257W2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7W0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavFilterfulltext_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7W0( ) ;
                              }
                              nGXsfl_107_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_107_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_107_idx), 4, 0), 4, "0");
                              SubsflControlProps_1072( ) ;
                              AV51Display = cgiGet( edtavDisplay_Internalname);
                              AssignAttri(sPrefix, false, edtavDisplay_Internalname, AV51Display);
                              A662SerasaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSerasaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A168ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n168ClienteId = false;
                              A170ClienteRazaoSocial = StringUtil.Upper( cgiGet( edtClienteRazaoSocial_Internalname));
                              n170ClienteRazaoSocial = false;
                              A663SerasaNumeroProposta = cgiGet( edtSerasaNumeroProposta_Internalname);
                              n663SerasaNumeroProposta = false;
                              A664SerasaPolitica = context.localUtil.CToN( cgiGet( edtSerasaPolitica_Internalname), ",", ".");
                              n664SerasaPolitica = false;
                              A665SerasaCreatedAt = context.localUtil.CToT( cgiGet( edtSerasaCreatedAt_Internalname), 0);
                              n665SerasaCreatedAt = false;
                              A666SerasaTipoVenda = cgiGet( edtSerasaTipoVenda_Internalname);
                              n666SerasaTipoVenda = false;
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
                                          GX_FocusControl = edtavFilterfulltext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E267W2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavFilterfulltext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E277W2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavFilterfulltext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Grid.Load */
                                          E287W2 ();
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
                                             /* Set Refresh If Orderedby Changed */
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV13OrderedBy )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Ordereddsc Changed */
                                             if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV14OrderedDsc )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Filterfulltext Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vFILTERFULLTEXT"), AV15FilterFullText) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Dynamicfiltersselector1 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDYNAMICFILTERSSELECTOR1"), AV16DynamicFiltersSelector1) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Dynamicfiltersoperator1 Changed */
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV17DynamicFiltersOperator1 )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Serasanumeroproposta1 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vSERASANUMEROPROPOSTA1"), AV18SerasaNumeroProposta1) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Dynamicfiltersselector2 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDYNAMICFILTERSSELECTOR2"), AV20DynamicFiltersSelector2) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Dynamicfiltersoperator2 Changed */
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV21DynamicFiltersOperator2 )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Serasanumeroproposta2 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vSERASANUMEROPROPOSTA2"), AV22SerasaNumeroProposta2) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Dynamicfiltersselector3 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDYNAMICFILTERSSELECTOR3"), AV24DynamicFiltersSelector3) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV25DynamicFiltersOperator3 )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Serasanumeroproposta3 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vSERASANUMEROPROPOSTA3"), AV26SerasaNumeroProposta3) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
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
                                       STRUP7W0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavFilterfulltext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE7W2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm7W2( ) ;
            }
         }
      }

      protected void PA7W2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            if ( StringUtil.Len( sPrefix) == 0 )
            {
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "serasaww")), "serasaww") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "serasaww")))) ;
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
            }
            if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               if ( StringUtil.Len( sPrefix) == 0 )
               {
                  if ( nGotPars == 0 )
                  {
                     entryPointCalled = false;
                     gxfirstwebparm = GetFirstPar( "ClientesIds");
                     toggleJsOutput = isJsOutputEnabled( );
                     if ( context.isSpaRequest( ) )
                     {
                        disableJsOutput();
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
            }
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
               GX_FocusControl = edtavFilterfulltext_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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
         SubsflControlProps_1072( ) ;
         while ( nGXsfl_107_idx <= nRC_GXsfl_107 )
         {
            sendrow_1072( ) ;
            nGXsfl_107_idx = ((subGrid_Islastpage==1)&&(nGXsfl_107_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_107_idx+1);
            sGXsfl_107_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_107_idx), 4, 0), 4, "0");
            SubsflControlProps_1072( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       string AV15FilterFullText ,
                                       string AV16DynamicFiltersSelector1 ,
                                       short AV17DynamicFiltersOperator1 ,
                                       string AV18SerasaNumeroProposta1 ,
                                       string AV20DynamicFiltersSelector2 ,
                                       short AV21DynamicFiltersOperator2 ,
                                       string AV22SerasaNumeroProposta2 ,
                                       string AV24DynamicFiltersSelector3 ,
                                       short AV25DynamicFiltersOperator3 ,
                                       string AV26SerasaNumeroProposta3 ,
                                       GxSimpleCollection<int> AV55Array_ClienteId ,
                                       short AV34ManageFiltersExecutionStep ,
                                       string AV62Pgmname ,
                                       bool AV19DynamicFiltersEnabled2 ,
                                       bool AV23DynamicFiltersEnabled3 ,
                                       string AV52TFClienteRazaoSocial ,
                                       string AV53TFClienteRazaoSocial_Sel ,
                                       string AV35TFSerasaNumeroProposta ,
                                       string AV36TFSerasaNumeroProposta_Sel ,
                                       decimal AV37TFSerasaPolitica ,
                                       decimal AV38TFSerasaPolitica_To ,
                                       DateTime AV39TFSerasaCreatedAt ,
                                       DateTime AV40TFSerasaCreatedAt_To ,
                                       string AV44TFSerasaTipoVenda ,
                                       string AV45TFSerasaTipoVenda_Sel ,
                                       string AV54ClientesIds ,
                                       int AV56PropostaId ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV28DynamicFiltersIgnoreFirst ,
                                       bool AV27DynamicFiltersRemoving ,
                                       int AV59PropostaResponsavelId ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF7W2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
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
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV16DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV16DynamicFiltersSelector1);
            AssignAttri(sPrefix, false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV17DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV20DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV20DynamicFiltersSelector2);
            AssignAttri(sPrefix, false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV21DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV24DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV24DynamicFiltersSelector3);
            AssignAttri(sPrefix, false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV25DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF7W2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV62Pgmname = "SerasaWW";
         edtavDisplay_Enabled = 0;
      }

      protected void RF7W2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 107;
         /* Execute user event: Refresh */
         E277W2 ();
         nGXsfl_107_idx = 1;
         sGXsfl_107_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_107_idx), 4, 0), 4, "0");
         SubsflControlProps_1072( ) ;
         bGXsfl_107_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", sPrefix);
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar GridWithBorderColor WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1072( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A168ClienteId ,
                                                 AV55Array_ClienteId ,
                                                 AV63Serasawwds_1_filterfulltext ,
                                                 AV64Serasawwds_2_dynamicfiltersselector1 ,
                                                 AV65Serasawwds_3_dynamicfiltersoperator1 ,
                                                 AV66Serasawwds_4_serasanumeroproposta1 ,
                                                 AV67Serasawwds_5_dynamicfiltersenabled2 ,
                                                 AV68Serasawwds_6_dynamicfiltersselector2 ,
                                                 AV69Serasawwds_7_dynamicfiltersoperator2 ,
                                                 AV70Serasawwds_8_serasanumeroproposta2 ,
                                                 AV71Serasawwds_9_dynamicfiltersenabled3 ,
                                                 AV72Serasawwds_10_dynamicfiltersselector3 ,
                                                 AV73Serasawwds_11_dynamicfiltersoperator3 ,
                                                 AV74Serasawwds_12_serasanumeroproposta3 ,
                                                 AV76Serasawwds_14_tfclienterazaosocial_sel ,
                                                 AV75Serasawwds_13_tfclienterazaosocial ,
                                                 AV78Serasawwds_16_tfserasanumeroproposta_sel ,
                                                 AV77Serasawwds_15_tfserasanumeroproposta ,
                                                 AV79Serasawwds_17_tfserasapolitica ,
                                                 AV80Serasawwds_18_tfserasapolitica_to ,
                                                 AV81Serasawwds_19_tfserasacreatedat ,
                                                 AV82Serasawwds_20_tfserasacreatedat_to ,
                                                 AV84Serasawwds_22_tfserasatipovenda_sel ,
                                                 AV83Serasawwds_21_tfserasatipovenda ,
                                                 A170ClienteRazaoSocial ,
                                                 A663SerasaNumeroProposta ,
                                                 A664SerasaPolitica ,
                                                 A666SerasaTipoVenda ,
                                                 A665SerasaCreatedAt ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE,
                                                 TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV63Serasawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Serasawwds_1_filterfulltext), "%", "");
            lV63Serasawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Serasawwds_1_filterfulltext), "%", "");
            lV63Serasawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Serasawwds_1_filterfulltext), "%", "");
            lV63Serasawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Serasawwds_1_filterfulltext), "%", "");
            lV66Serasawwds_4_serasanumeroproposta1 = StringUtil.Concat( StringUtil.RTrim( AV66Serasawwds_4_serasanumeroproposta1), "%", "");
            lV66Serasawwds_4_serasanumeroproposta1 = StringUtil.Concat( StringUtil.RTrim( AV66Serasawwds_4_serasanumeroproposta1), "%", "");
            lV70Serasawwds_8_serasanumeroproposta2 = StringUtil.Concat( StringUtil.RTrim( AV70Serasawwds_8_serasanumeroproposta2), "%", "");
            lV70Serasawwds_8_serasanumeroproposta2 = StringUtil.Concat( StringUtil.RTrim( AV70Serasawwds_8_serasanumeroproposta2), "%", "");
            lV74Serasawwds_12_serasanumeroproposta3 = StringUtil.Concat( StringUtil.RTrim( AV74Serasawwds_12_serasanumeroproposta3), "%", "");
            lV74Serasawwds_12_serasanumeroproposta3 = StringUtil.Concat( StringUtil.RTrim( AV74Serasawwds_12_serasanumeroproposta3), "%", "");
            lV75Serasawwds_13_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV75Serasawwds_13_tfclienterazaosocial), "%", "");
            lV77Serasawwds_15_tfserasanumeroproposta = StringUtil.Concat( StringUtil.RTrim( AV77Serasawwds_15_tfserasanumeroproposta), "%", "");
            lV83Serasawwds_21_tfserasatipovenda = StringUtil.Concat( StringUtil.RTrim( AV83Serasawwds_21_tfserasatipovenda), "%", "");
            /* Using cursor H007W2 */
            pr_default.execute(0, new Object[] {lV63Serasawwds_1_filterfulltext, lV63Serasawwds_1_filterfulltext, lV63Serasawwds_1_filterfulltext, lV63Serasawwds_1_filterfulltext, lV66Serasawwds_4_serasanumeroproposta1, lV66Serasawwds_4_serasanumeroproposta1, lV70Serasawwds_8_serasanumeroproposta2, lV70Serasawwds_8_serasanumeroproposta2, lV74Serasawwds_12_serasanumeroproposta3, lV74Serasawwds_12_serasanumeroproposta3, lV75Serasawwds_13_tfclienterazaosocial, AV76Serasawwds_14_tfclienterazaosocial_sel, lV77Serasawwds_15_tfserasanumeroproposta, AV78Serasawwds_16_tfserasanumeroproposta_sel, AV79Serasawwds_17_tfserasapolitica, AV80Serasawwds_18_tfserasapolitica_to, AV81Serasawwds_19_tfserasacreatedat, AV82Serasawwds_20_tfserasacreatedat_to, lV83Serasawwds_21_tfserasatipovenda, AV84Serasawwds_22_tfserasatipovenda_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_107_idx = 1;
            sGXsfl_107_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_107_idx), 4, 0), 4, "0");
            SubsflControlProps_1072( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A666SerasaTipoVenda = H007W2_A666SerasaTipoVenda[0];
               n666SerasaTipoVenda = H007W2_n666SerasaTipoVenda[0];
               A665SerasaCreatedAt = H007W2_A665SerasaCreatedAt[0];
               n665SerasaCreatedAt = H007W2_n665SerasaCreatedAt[0];
               A664SerasaPolitica = H007W2_A664SerasaPolitica[0];
               n664SerasaPolitica = H007W2_n664SerasaPolitica[0];
               A663SerasaNumeroProposta = H007W2_A663SerasaNumeroProposta[0];
               n663SerasaNumeroProposta = H007W2_n663SerasaNumeroProposta[0];
               A170ClienteRazaoSocial = H007W2_A170ClienteRazaoSocial[0];
               n170ClienteRazaoSocial = H007W2_n170ClienteRazaoSocial[0];
               A168ClienteId = H007W2_A168ClienteId[0];
               n168ClienteId = H007W2_n168ClienteId[0];
               A662SerasaId = H007W2_A662SerasaId[0];
               A170ClienteRazaoSocial = H007W2_A170ClienteRazaoSocial[0];
               n170ClienteRazaoSocial = H007W2_n170ClienteRazaoSocial[0];
               /* Execute user event: Grid.Load */
               E287W2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 107;
            WB7W0( ) ;
         }
         bGXsfl_107_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes7W2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV62Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV62Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPROPOSTARESPONSAVELID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV59PropostaResponsavelId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROPOSTARESPONSAVELID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV59PropostaResponsavelId), "ZZZZZZZZ9"), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         AV63Serasawwds_1_filterfulltext = AV15FilterFullText;
         AV64Serasawwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV65Serasawwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV66Serasawwds_4_serasanumeroproposta1 = AV18SerasaNumeroProposta1;
         AV67Serasawwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV68Serasawwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV69Serasawwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV70Serasawwds_8_serasanumeroproposta2 = AV22SerasaNumeroProposta2;
         AV71Serasawwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV72Serasawwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV73Serasawwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV74Serasawwds_12_serasanumeroproposta3 = AV26SerasaNumeroProposta3;
         AV75Serasawwds_13_tfclienterazaosocial = AV52TFClienteRazaoSocial;
         AV76Serasawwds_14_tfclienterazaosocial_sel = AV53TFClienteRazaoSocial_Sel;
         AV77Serasawwds_15_tfserasanumeroproposta = AV35TFSerasaNumeroProposta;
         AV78Serasawwds_16_tfserasanumeroproposta_sel = AV36TFSerasaNumeroProposta_Sel;
         AV79Serasawwds_17_tfserasapolitica = AV37TFSerasaPolitica;
         AV80Serasawwds_18_tfserasapolitica_to = AV38TFSerasaPolitica_To;
         AV81Serasawwds_19_tfserasacreatedat = AV39TFSerasaCreatedAt;
         AV82Serasawwds_20_tfserasacreatedat_to = AV40TFSerasaCreatedAt_To;
         AV83Serasawwds_21_tfserasatipovenda = AV44TFSerasaTipoVenda;
         AV84Serasawwds_22_tfserasatipovenda_sel = AV45TFSerasaTipoVenda_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A168ClienteId ,
                                              AV55Array_ClienteId ,
                                              AV63Serasawwds_1_filterfulltext ,
                                              AV64Serasawwds_2_dynamicfiltersselector1 ,
                                              AV65Serasawwds_3_dynamicfiltersoperator1 ,
                                              AV66Serasawwds_4_serasanumeroproposta1 ,
                                              AV67Serasawwds_5_dynamicfiltersenabled2 ,
                                              AV68Serasawwds_6_dynamicfiltersselector2 ,
                                              AV69Serasawwds_7_dynamicfiltersoperator2 ,
                                              AV70Serasawwds_8_serasanumeroproposta2 ,
                                              AV71Serasawwds_9_dynamicfiltersenabled3 ,
                                              AV72Serasawwds_10_dynamicfiltersselector3 ,
                                              AV73Serasawwds_11_dynamicfiltersoperator3 ,
                                              AV74Serasawwds_12_serasanumeroproposta3 ,
                                              AV76Serasawwds_14_tfclienterazaosocial_sel ,
                                              AV75Serasawwds_13_tfclienterazaosocial ,
                                              AV78Serasawwds_16_tfserasanumeroproposta_sel ,
                                              AV77Serasawwds_15_tfserasanumeroproposta ,
                                              AV79Serasawwds_17_tfserasapolitica ,
                                              AV80Serasawwds_18_tfserasapolitica_to ,
                                              AV81Serasawwds_19_tfserasacreatedat ,
                                              AV82Serasawwds_20_tfserasacreatedat_to ,
                                              AV84Serasawwds_22_tfserasatipovenda_sel ,
                                              AV83Serasawwds_21_tfserasatipovenda ,
                                              A170ClienteRazaoSocial ,
                                              A663SerasaNumeroProposta ,
                                              A664SerasaPolitica ,
                                              A666SerasaTipoVenda ,
                                              A665SerasaCreatedAt ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV63Serasawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Serasawwds_1_filterfulltext), "%", "");
         lV63Serasawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Serasawwds_1_filterfulltext), "%", "");
         lV63Serasawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Serasawwds_1_filterfulltext), "%", "");
         lV63Serasawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Serasawwds_1_filterfulltext), "%", "");
         lV66Serasawwds_4_serasanumeroproposta1 = StringUtil.Concat( StringUtil.RTrim( AV66Serasawwds_4_serasanumeroproposta1), "%", "");
         lV66Serasawwds_4_serasanumeroproposta1 = StringUtil.Concat( StringUtil.RTrim( AV66Serasawwds_4_serasanumeroproposta1), "%", "");
         lV70Serasawwds_8_serasanumeroproposta2 = StringUtil.Concat( StringUtil.RTrim( AV70Serasawwds_8_serasanumeroproposta2), "%", "");
         lV70Serasawwds_8_serasanumeroproposta2 = StringUtil.Concat( StringUtil.RTrim( AV70Serasawwds_8_serasanumeroproposta2), "%", "");
         lV74Serasawwds_12_serasanumeroproposta3 = StringUtil.Concat( StringUtil.RTrim( AV74Serasawwds_12_serasanumeroproposta3), "%", "");
         lV74Serasawwds_12_serasanumeroproposta3 = StringUtil.Concat( StringUtil.RTrim( AV74Serasawwds_12_serasanumeroproposta3), "%", "");
         lV75Serasawwds_13_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV75Serasawwds_13_tfclienterazaosocial), "%", "");
         lV77Serasawwds_15_tfserasanumeroproposta = StringUtil.Concat( StringUtil.RTrim( AV77Serasawwds_15_tfserasanumeroproposta), "%", "");
         lV83Serasawwds_21_tfserasatipovenda = StringUtil.Concat( StringUtil.RTrim( AV83Serasawwds_21_tfserasatipovenda), "%", "");
         /* Using cursor H007W3 */
         pr_default.execute(1, new Object[] {lV63Serasawwds_1_filterfulltext, lV63Serasawwds_1_filterfulltext, lV63Serasawwds_1_filterfulltext, lV63Serasawwds_1_filterfulltext, lV66Serasawwds_4_serasanumeroproposta1, lV66Serasawwds_4_serasanumeroproposta1, lV70Serasawwds_8_serasanumeroproposta2, lV70Serasawwds_8_serasanumeroproposta2, lV74Serasawwds_12_serasanumeroproposta3, lV74Serasawwds_12_serasanumeroproposta3, lV75Serasawwds_13_tfclienterazaosocial, AV76Serasawwds_14_tfclienterazaosocial_sel, lV77Serasawwds_15_tfserasanumeroproposta, AV78Serasawwds_16_tfserasanumeroproposta_sel, AV79Serasawwds_17_tfserasapolitica, AV80Serasawwds_18_tfserasapolitica_to, AV81Serasawwds_19_tfserasacreatedat, AV82Serasawwds_20_tfserasacreatedat_to, lV83Serasawwds_21_tfserasatipovenda, AV84Serasawwds_22_tfserasatipovenda_sel});
         GRID_nRecordCount = H007W3_AGRID_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID_nRecordCount) ;
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
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         AV63Serasawwds_1_filterfulltext = AV15FilterFullText;
         AV64Serasawwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV65Serasawwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV66Serasawwds_4_serasanumeroproposta1 = AV18SerasaNumeroProposta1;
         AV67Serasawwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV68Serasawwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV69Serasawwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV70Serasawwds_8_serasanumeroproposta2 = AV22SerasaNumeroProposta2;
         AV71Serasawwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV72Serasawwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV73Serasawwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV74Serasawwds_12_serasanumeroproposta3 = AV26SerasaNumeroProposta3;
         AV75Serasawwds_13_tfclienterazaosocial = AV52TFClienteRazaoSocial;
         AV76Serasawwds_14_tfclienterazaosocial_sel = AV53TFClienteRazaoSocial_Sel;
         AV77Serasawwds_15_tfserasanumeroproposta = AV35TFSerasaNumeroProposta;
         AV78Serasawwds_16_tfserasanumeroproposta_sel = AV36TFSerasaNumeroProposta_Sel;
         AV79Serasawwds_17_tfserasapolitica = AV37TFSerasaPolitica;
         AV80Serasawwds_18_tfserasapolitica_to = AV38TFSerasaPolitica_To;
         AV81Serasawwds_19_tfserasacreatedat = AV39TFSerasaCreatedAt;
         AV82Serasawwds_20_tfserasacreatedat_to = AV40TFSerasaCreatedAt_To;
         AV83Serasawwds_21_tfserasatipovenda = AV44TFSerasaTipoVenda;
         AV84Serasawwds_22_tfserasatipovenda_sel = AV45TFSerasaTipoVenda_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18SerasaNumeroProposta1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22SerasaNumeroProposta2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26SerasaNumeroProposta3, AV55Array_ClienteId, AV34ManageFiltersExecutionStep, AV62Pgmname, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV52TFClienteRazaoSocial, AV53TFClienteRazaoSocial_Sel, AV35TFSerasaNumeroProposta, AV36TFSerasaNumeroProposta_Sel, AV37TFSerasaPolitica, AV38TFSerasaPolitica_To, AV39TFSerasaCreatedAt, AV40TFSerasaCreatedAt_To, AV44TFSerasaTipoVenda, AV45TFSerasaTipoVenda_Sel, AV54ClientesIds, AV56PropostaId, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, AV59PropostaResponsavelId, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV63Serasawwds_1_filterfulltext = AV15FilterFullText;
         AV64Serasawwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV65Serasawwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV66Serasawwds_4_serasanumeroproposta1 = AV18SerasaNumeroProposta1;
         AV67Serasawwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV68Serasawwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV69Serasawwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV70Serasawwds_8_serasanumeroproposta2 = AV22SerasaNumeroProposta2;
         AV71Serasawwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV72Serasawwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV73Serasawwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV74Serasawwds_12_serasanumeroproposta3 = AV26SerasaNumeroProposta3;
         AV75Serasawwds_13_tfclienterazaosocial = AV52TFClienteRazaoSocial;
         AV76Serasawwds_14_tfclienterazaosocial_sel = AV53TFClienteRazaoSocial_Sel;
         AV77Serasawwds_15_tfserasanumeroproposta = AV35TFSerasaNumeroProposta;
         AV78Serasawwds_16_tfserasanumeroproposta_sel = AV36TFSerasaNumeroProposta_Sel;
         AV79Serasawwds_17_tfserasapolitica = AV37TFSerasaPolitica;
         AV80Serasawwds_18_tfserasapolitica_to = AV38TFSerasaPolitica_To;
         AV81Serasawwds_19_tfserasacreatedat = AV39TFSerasaCreatedAt;
         AV82Serasawwds_20_tfserasacreatedat_to = AV40TFSerasaCreatedAt_To;
         AV83Serasawwds_21_tfserasatipovenda = AV44TFSerasaTipoVenda;
         AV84Serasawwds_22_tfserasatipovenda_sel = AV45TFSerasaTipoVenda_Sel;
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18SerasaNumeroProposta1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22SerasaNumeroProposta2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26SerasaNumeroProposta3, AV55Array_ClienteId, AV34ManageFiltersExecutionStep, AV62Pgmname, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV52TFClienteRazaoSocial, AV53TFClienteRazaoSocial_Sel, AV35TFSerasaNumeroProposta, AV36TFSerasaNumeroProposta_Sel, AV37TFSerasaPolitica, AV38TFSerasaPolitica_To, AV39TFSerasaCreatedAt, AV40TFSerasaCreatedAt_To, AV44TFSerasaTipoVenda, AV45TFSerasaTipoVenda_Sel, AV54ClientesIds, AV56PropostaId, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, AV59PropostaResponsavelId, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV63Serasawwds_1_filterfulltext = AV15FilterFullText;
         AV64Serasawwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV65Serasawwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV66Serasawwds_4_serasanumeroproposta1 = AV18SerasaNumeroProposta1;
         AV67Serasawwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV68Serasawwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV69Serasawwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV70Serasawwds_8_serasanumeroproposta2 = AV22SerasaNumeroProposta2;
         AV71Serasawwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV72Serasawwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV73Serasawwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV74Serasawwds_12_serasanumeroproposta3 = AV26SerasaNumeroProposta3;
         AV75Serasawwds_13_tfclienterazaosocial = AV52TFClienteRazaoSocial;
         AV76Serasawwds_14_tfclienterazaosocial_sel = AV53TFClienteRazaoSocial_Sel;
         AV77Serasawwds_15_tfserasanumeroproposta = AV35TFSerasaNumeroProposta;
         AV78Serasawwds_16_tfserasanumeroproposta_sel = AV36TFSerasaNumeroProposta_Sel;
         AV79Serasawwds_17_tfserasapolitica = AV37TFSerasaPolitica;
         AV80Serasawwds_18_tfserasapolitica_to = AV38TFSerasaPolitica_To;
         AV81Serasawwds_19_tfserasacreatedat = AV39TFSerasaCreatedAt;
         AV82Serasawwds_20_tfserasacreatedat_to = AV40TFSerasaCreatedAt_To;
         AV83Serasawwds_21_tfserasatipovenda = AV44TFSerasaTipoVenda;
         AV84Serasawwds_22_tfserasatipovenda_sel = AV45TFSerasaTipoVenda_Sel;
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18SerasaNumeroProposta1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22SerasaNumeroProposta2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26SerasaNumeroProposta3, AV55Array_ClienteId, AV34ManageFiltersExecutionStep, AV62Pgmname, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV52TFClienteRazaoSocial, AV53TFClienteRazaoSocial_Sel, AV35TFSerasaNumeroProposta, AV36TFSerasaNumeroProposta_Sel, AV37TFSerasaPolitica, AV38TFSerasaPolitica_To, AV39TFSerasaCreatedAt, AV40TFSerasaCreatedAt_To, AV44TFSerasaTipoVenda, AV45TFSerasaTipoVenda_Sel, AV54ClientesIds, AV56PropostaId, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, AV59PropostaResponsavelId, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV63Serasawwds_1_filterfulltext = AV15FilterFullText;
         AV64Serasawwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV65Serasawwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV66Serasawwds_4_serasanumeroproposta1 = AV18SerasaNumeroProposta1;
         AV67Serasawwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV68Serasawwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV69Serasawwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV70Serasawwds_8_serasanumeroproposta2 = AV22SerasaNumeroProposta2;
         AV71Serasawwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV72Serasawwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV73Serasawwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV74Serasawwds_12_serasanumeroproposta3 = AV26SerasaNumeroProposta3;
         AV75Serasawwds_13_tfclienterazaosocial = AV52TFClienteRazaoSocial;
         AV76Serasawwds_14_tfclienterazaosocial_sel = AV53TFClienteRazaoSocial_Sel;
         AV77Serasawwds_15_tfserasanumeroproposta = AV35TFSerasaNumeroProposta;
         AV78Serasawwds_16_tfserasanumeroproposta_sel = AV36TFSerasaNumeroProposta_Sel;
         AV79Serasawwds_17_tfserasapolitica = AV37TFSerasaPolitica;
         AV80Serasawwds_18_tfserasapolitica_to = AV38TFSerasaPolitica_To;
         AV81Serasawwds_19_tfserasacreatedat = AV39TFSerasaCreatedAt;
         AV82Serasawwds_20_tfserasacreatedat_to = AV40TFSerasaCreatedAt_To;
         AV83Serasawwds_21_tfserasatipovenda = AV44TFSerasaTipoVenda;
         AV84Serasawwds_22_tfserasatipovenda_sel = AV45TFSerasaTipoVenda_Sel;
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18SerasaNumeroProposta1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22SerasaNumeroProposta2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26SerasaNumeroProposta3, AV55Array_ClienteId, AV34ManageFiltersExecutionStep, AV62Pgmname, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV52TFClienteRazaoSocial, AV53TFClienteRazaoSocial_Sel, AV35TFSerasaNumeroProposta, AV36TFSerasaNumeroProposta_Sel, AV37TFSerasaPolitica, AV38TFSerasaPolitica_To, AV39TFSerasaCreatedAt, AV40TFSerasaCreatedAt_To, AV44TFSerasaTipoVenda, AV45TFSerasaTipoVenda_Sel, AV54ClientesIds, AV56PropostaId, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, AV59PropostaResponsavelId, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV63Serasawwds_1_filterfulltext = AV15FilterFullText;
         AV64Serasawwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV65Serasawwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV66Serasawwds_4_serasanumeroproposta1 = AV18SerasaNumeroProposta1;
         AV67Serasawwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV68Serasawwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV69Serasawwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV70Serasawwds_8_serasanumeroproposta2 = AV22SerasaNumeroProposta2;
         AV71Serasawwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV72Serasawwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV73Serasawwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV74Serasawwds_12_serasanumeroproposta3 = AV26SerasaNumeroProposta3;
         AV75Serasawwds_13_tfclienterazaosocial = AV52TFClienteRazaoSocial;
         AV76Serasawwds_14_tfclienterazaosocial_sel = AV53TFClienteRazaoSocial_Sel;
         AV77Serasawwds_15_tfserasanumeroproposta = AV35TFSerasaNumeroProposta;
         AV78Serasawwds_16_tfserasanumeroproposta_sel = AV36TFSerasaNumeroProposta_Sel;
         AV79Serasawwds_17_tfserasapolitica = AV37TFSerasaPolitica;
         AV80Serasawwds_18_tfserasapolitica_to = AV38TFSerasaPolitica_To;
         AV81Serasawwds_19_tfserasacreatedat = AV39TFSerasaCreatedAt;
         AV82Serasawwds_20_tfserasacreatedat_to = AV40TFSerasaCreatedAt_To;
         AV83Serasawwds_21_tfserasatipovenda = AV44TFSerasaTipoVenda;
         AV84Serasawwds_22_tfserasatipovenda_sel = AV45TFSerasaTipoVenda_Sel;
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18SerasaNumeroProposta1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22SerasaNumeroProposta2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26SerasaNumeroProposta3, AV55Array_ClienteId, AV34ManageFiltersExecutionStep, AV62Pgmname, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV52TFClienteRazaoSocial, AV53TFClienteRazaoSocial_Sel, AV35TFSerasaNumeroProposta, AV36TFSerasaNumeroProposta_Sel, AV37TFSerasaPolitica, AV38TFSerasaPolitica_To, AV39TFSerasaCreatedAt, AV40TFSerasaCreatedAt_To, AV44TFSerasaTipoVenda, AV45TFSerasaTipoVenda_Sel, AV54ClientesIds, AV56PropostaId, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, AV59PropostaResponsavelId, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV62Pgmname = "SerasaWW";
         edtavDisplay_Enabled = 0;
         edtSerasaId_Enabled = 0;
         edtClienteId_Enabled = 0;
         edtClienteRazaoSocial_Enabled = 0;
         edtSerasaNumeroProposta_Enabled = 0;
         edtSerasaPolitica_Enabled = 0;
         edtSerasaCreatedAt_Enabled = 0;
         edtSerasaTipoVenda_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP7W0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E267W2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vMANAGEFILTERSDATA"), AV32ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV46DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_107 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_107"), ",", "."), 18, MidpointRounding.ToEven));
            AV48GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV49GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV50GridAppliedFilters = cgiGet( sPrefix+"vGRIDAPPLIEDFILTERS");
            AV41DDO_SerasaCreatedAtAuxDate = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_SERASACREATEDATAUXDATE"), 0);
            AssignAttri(sPrefix, false, "AV41DDO_SerasaCreatedAtAuxDate", context.localUtil.Format(AV41DDO_SerasaCreatedAtAuxDate, "99/99/99"));
            AV42DDO_SerasaCreatedAtAuxDateTo = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_SERASACREATEDATAUXDATETO"), 0);
            AssignAttri(sPrefix, false, "AV42DDO_SerasaCreatedAtAuxDateTo", context.localUtil.Format(AV42DDO_SerasaCreatedAtAuxDateTo, "99/99/99"));
            wcpOAV54ClientesIds = cgiGet( sPrefix+"wcpOAV54ClientesIds");
            wcpOAV56PropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV56PropostaId"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_managefilters_Icontype = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Icontype");
            Ddo_managefilters_Icon = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Icon");
            Ddo_managefilters_Tooltip = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Tooltip");
            Ddo_managefilters_Cls = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Cls");
            Dvpanel_tableheader_Width = cgiGet( sPrefix+"DVPANEL_TABLEHEADER_Width");
            Dvpanel_tableheader_Autowidth = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEHEADER_Autowidth"));
            Dvpanel_tableheader_Autoheight = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEHEADER_Autoheight"));
            Dvpanel_tableheader_Cls = cgiGet( sPrefix+"DVPANEL_TABLEHEADER_Cls");
            Dvpanel_tableheader_Title = cgiGet( sPrefix+"DVPANEL_TABLEHEADER_Title");
            Dvpanel_tableheader_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEHEADER_Collapsible"));
            Dvpanel_tableheader_Collapsed = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEHEADER_Collapsed"));
            Dvpanel_tableheader_Showcollapseicon = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEHEADER_Showcollapseicon"));
            Dvpanel_tableheader_Iconposition = cgiGet( sPrefix+"DVPANEL_TABLEHEADER_Iconposition");
            Dvpanel_tableheader_Autoscroll = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEHEADER_Autoscroll"));
            Gridpaginationbar_Class = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Class");
            Gridpaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Showfirst"));
            Gridpaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Showprevious"));
            Gridpaginationbar_Shownext = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Shownext"));
            Gridpaginationbar_Showlast = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Showlast"));
            Gridpaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Pagestoshow"), ",", "."), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Pagingbuttonsposition = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Pagingbuttonsposition");
            Gridpaginationbar_Pagingcaptionposition = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Pagingcaptionposition");
            Gridpaginationbar_Emptygridclass = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Emptygridclass");
            Gridpaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselector"));
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Rowsperpageoptions = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageoptions");
            Gridpaginationbar_Previous = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Previous");
            Gridpaginationbar_Next = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Next");
            Gridpaginationbar_Caption = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Caption");
            Gridpaginationbar_Emptygridcaption = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Emptygridcaption");
            Gridpaginationbar_Rowsperpagecaption = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpagecaption");
            Ddo_grid_Caption = cgiGet( sPrefix+"DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( sPrefix+"DDO_GRID_Filteredtext_set");
            Ddo_grid_Filteredtextto_set = cgiGet( sPrefix+"DDO_GRID_Filteredtextto_set");
            Ddo_grid_Selectedvalue_set = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gridinternalname = cgiGet( sPrefix+"DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( sPrefix+"DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( sPrefix+"DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( sPrefix+"DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( sPrefix+"DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( sPrefix+"DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( sPrefix+"DDO_GRID_Filtertype");
            Ddo_grid_Filterisrange = cgiGet( sPrefix+"DDO_GRID_Filterisrange");
            Ddo_grid_Includedatalist = cgiGet( sPrefix+"DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( sPrefix+"DDO_GRID_Datalisttype");
            Ddo_grid_Datalistproc = cgiGet( sPrefix+"DDO_GRID_Datalistproc");
            Ddo_grid_Format = cgiGet( sPrefix+"DDO_GRID_Format");
            Dvelop_confirmpanel_consultaserasa_Title = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_CONSULTASERASA_Title");
            Dvelop_confirmpanel_consultaserasa_Confirmationtext = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_CONSULTASERASA_Confirmationtext");
            Dvelop_confirmpanel_consultaserasa_Yesbuttoncaption = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_CONSULTASERASA_Yesbuttoncaption");
            Dvelop_confirmpanel_consultaserasa_Nobuttoncaption = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_CONSULTASERASA_Nobuttoncaption");
            Dvelop_confirmpanel_consultaserasa_Cancelbuttoncaption = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_CONSULTASERASA_Cancelbuttoncaption");
            Dvelop_confirmpanel_consultaserasa_Yesbuttonposition = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_CONSULTASERASA_Yesbuttonposition");
            Dvelop_confirmpanel_consultaserasa_Confirmtype = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_CONSULTASERASA_Confirmtype");
            Grid_empowerer_Gridinternalname = cgiGet( sPrefix+"GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( sPrefix+"GRID_EMPOWERER_Hastitlesettings"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( sPrefix+"DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_get");
            Ddo_grid_Selectedcolumn = cgiGet( sPrefix+"DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( sPrefix+"DDO_GRID_Filteredtext_get");
            Ddo_grid_Filteredtextto_get = cgiGet( sPrefix+"DDO_GRID_Filteredtextto_get");
            Ddo_managefilters_Activeeventkey = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Dvelop_confirmpanel_consultaserasa_Result = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_CONSULTASERASA_Result");
            /* Read variables values. */
            AV15FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri(sPrefix, false, "AV15FilterFullText", AV15FilterFullText);
            cmbavDynamicfiltersselector1.Name = cmbavDynamicfiltersselector1_Internalname;
            cmbavDynamicfiltersselector1.CurrentValue = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AV16DynamicFiltersSelector1 = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AssignAttri(sPrefix, false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
            cmbavDynamicfiltersoperator1.Name = cmbavDynamicfiltersoperator1_Internalname;
            cmbavDynamicfiltersoperator1.CurrentValue = cgiGet( cmbavDynamicfiltersoperator1_Internalname);
            AV17DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator1_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
            AV18SerasaNumeroProposta1 = cgiGet( edtavSerasanumeroproposta1_Internalname);
            AssignAttri(sPrefix, false, "AV18SerasaNumeroProposta1", AV18SerasaNumeroProposta1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV20DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri(sPrefix, false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV21DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
            AV22SerasaNumeroProposta2 = cgiGet( edtavSerasanumeroproposta2_Internalname);
            AssignAttri(sPrefix, false, "AV22SerasaNumeroProposta2", AV22SerasaNumeroProposta2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV24DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri(sPrefix, false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV25DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
            AV26SerasaNumeroProposta3 = cgiGet( edtavSerasanumeroproposta3_Internalname);
            AssignAttri(sPrefix, false, "AV26SerasaNumeroProposta3", AV26SerasaNumeroProposta3);
            AV43DDO_SerasaCreatedAtAuxDateText = cgiGet( edtavDdo_serasacreatedatauxdatetext_Internalname);
            AssignAttri(sPrefix, false, "AV43DDO_SerasaCreatedAtAuxDateText", AV43DDO_SerasaCreatedAtAuxDateText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV13OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV14OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vFILTERFULLTEXT"), AV15FilterFullText) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDYNAMICFILTERSSELECTOR1"), AV16DynamicFiltersSelector1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV17DynamicFiltersOperator1 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vSERASANUMEROPROPOSTA1"), AV18SerasaNumeroProposta1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDYNAMICFILTERSSELECTOR2"), AV20DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV21DynamicFiltersOperator2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vSERASANUMEROPROPOSTA2"), AV22SerasaNumeroProposta2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDYNAMICFILTERSSELECTOR3"), AV24DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV25DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vSERASANUMEROPROPOSTA3"), AV26SerasaNumeroProposta3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
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
         E267W2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E267W2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV55Array_ClienteId.FromJSonString(AV54ClientesIds, null);
         this.executeUsercontrolMethod(sPrefix, false, "TFSERASACREATEDAT_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_serasacreatedatauxdatetext_Internalname});
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, sPrefix, false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         /* Execute user subroutine: 'LOADSAVEDFILTERS' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         lblJsdynamicfilters_Caption = "";
         AssignProp(sPrefix, false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         AV16DynamicFiltersSelector1 = "SERASANUMEROPROPOSTA";
         AssignAttri(sPrefix, false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV20DynamicFiltersSelector2 = "SERASANUMEROPROPOSTA";
         AssignAttri(sPrefix, false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV24DynamicFiltersSelector3 = "SERASANUMEROPROPOSTA";
         AssignAttri(sPrefix, false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         imgAdddynamicfilters1_Jsonclick = StringUtil.Format( "WWPDynFilterShow_AL('%1', 2, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp(sPrefix, false, imgAdddynamicfilters1_Internalname, "Jsonclick", imgAdddynamicfilters1_Jsonclick, true);
         imgRemovedynamicfilters1_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp(sPrefix, false, imgRemovedynamicfilters1_Internalname, "Jsonclick", imgRemovedynamicfilters1_Jsonclick, true);
         imgAdddynamicfilters2_Jsonclick = StringUtil.Format( "WWPDynFilterShow_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp(sPrefix, false, imgAdddynamicfilters2_Internalname, "Jsonclick", imgAdddynamicfilters2_Jsonclick, true);
         imgRemovedynamicfilters2_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp(sPrefix, false, imgRemovedynamicfilters2_Internalname, "Jsonclick", imgRemovedynamicfilters2_Jsonclick, true);
         imgRemovedynamicfilters3_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp(sPrefix, false, imgRemovedynamicfilters3_Internalname, "Jsonclick", imgRemovedynamicfilters3_Jsonclick, true);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV13OrderedBy < 1 )
         {
            AV13OrderedBy = 1;
            AssignAttri(sPrefix, false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV46DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV46DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, sPrefix, false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
         /* Using cursor H007W4 */
         pr_default.execute(2, new Object[] {AV56PropostaId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A323PropostaId = H007W4_A323PropostaId[0];
            A553PropostaResponsavelId = H007W4_A553PropostaResponsavelId[0];
            n553PropostaResponsavelId = H007W4_n553PropostaResponsavelId[0];
            AV59PropostaResponsavelId = A553PropostaResponsavelId;
            AssignAttri(sPrefix, false, "AV59PropostaResponsavelId", StringUtil.LTrimStr( (decimal)(AV59PropostaResponsavelId), 9, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROPOSTARESPONSAVELID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV59PropostaResponsavelId), "ZZZZZZZZ9"), context));
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
         if ( ! (0==AV59PropostaResponsavelId) )
         {
            Dvelop_confirmpanel_consultaserasa_Confirmationtext = "Prosseguir com esta ação resultará em uma cobrança do Serasa. Recomendamos que você consulte o paciente ou o responsável financeiro antes de continuar.";
            ucDvelop_confirmpanel_consultaserasa.SendProperty(context, sPrefix, false, Dvelop_confirmpanel_consultaserasa_Internalname, "ConfirmationText", Dvelop_confirmpanel_consultaserasa_Confirmationtext);
            Dvelop_confirmpanel_consultaserasa_Yesbuttoncaption = "Paciente";
            ucDvelop_confirmpanel_consultaserasa.SendProperty(context, sPrefix, false, Dvelop_confirmpanel_consultaserasa_Internalname, "YesButtonCaption", Dvelop_confirmpanel_consultaserasa_Yesbuttoncaption);
            Dvelop_confirmpanel_consultaserasa_Nobuttoncaption = "Responsável financeiro";
            ucDvelop_confirmpanel_consultaserasa.SendProperty(context, sPrefix, false, Dvelop_confirmpanel_consultaserasa_Internalname, "NoButtonCaption", Dvelop_confirmpanel_consultaserasa_Nobuttoncaption);
         }
         else
         {
            Dvelop_confirmpanel_consultaserasa_Confirmationtext = "Prosseguir com esta ação resultará em uma cobrança do Serasa. Certifique-se de que o paciente está ciente antes de continuar.";
            ucDvelop_confirmpanel_consultaserasa.SendProperty(context, sPrefix, false, Dvelop_confirmpanel_consultaserasa_Internalname, "ConfirmationText", Dvelop_confirmpanel_consultaserasa_Confirmationtext);
            Dvelop_confirmpanel_consultaserasa_Yesbuttoncaption = "Paciente";
            ucDvelop_confirmpanel_consultaserasa.SendProperty(context, sPrefix, false, Dvelop_confirmpanel_consultaserasa_Internalname, "YesButtonCaption", Dvelop_confirmpanel_consultaserasa_Yesbuttoncaption);
            Dvelop_confirmpanel_consultaserasa_Nobuttoncaption = "Não consultar agora";
            ucDvelop_confirmpanel_consultaserasa.SendProperty(context, sPrefix, false, Dvelop_confirmpanel_consultaserasa_Internalname, "NoButtonCaption", Dvelop_confirmpanel_consultaserasa_Nobuttoncaption);
         }
      }

      protected void E277W2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         if ( AV34ManageFiltersExecutionStep == 1 )
         {
            AV34ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV34ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV34ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV34ManageFiltersExecutionStep == 2 )
         {
            AV34ManageFiltersExecutionStep = 0;
            AssignAttri(sPrefix, false, "AV34ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV34ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV48GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri(sPrefix, false, "AV48GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV48GridCurrentPage), 10, 0));
         AV49GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri(sPrefix, false, "AV49GridPageCount", StringUtil.LTrimStr( (decimal)(AV49GridPageCount), 10, 0));
         GXt_char2 = AV50GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV62Pgmname, out  GXt_char2) ;
         AV50GridAppliedFilters = GXt_char2;
         AssignAttri(sPrefix, false, "AV50GridAppliedFilters", AV50GridAppliedFilters);
         AV63Serasawwds_1_filterfulltext = AV15FilterFullText;
         AV64Serasawwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV65Serasawwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV66Serasawwds_4_serasanumeroproposta1 = AV18SerasaNumeroProposta1;
         AV67Serasawwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV68Serasawwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV69Serasawwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV70Serasawwds_8_serasanumeroproposta2 = AV22SerasaNumeroProposta2;
         AV71Serasawwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV72Serasawwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV73Serasawwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV74Serasawwds_12_serasanumeroproposta3 = AV26SerasaNumeroProposta3;
         AV75Serasawwds_13_tfclienterazaosocial = AV52TFClienteRazaoSocial;
         AV76Serasawwds_14_tfclienterazaosocial_sel = AV53TFClienteRazaoSocial_Sel;
         AV77Serasawwds_15_tfserasanumeroproposta = AV35TFSerasaNumeroProposta;
         AV78Serasawwds_16_tfserasanumeroproposta_sel = AV36TFSerasaNumeroProposta_Sel;
         AV79Serasawwds_17_tfserasapolitica = AV37TFSerasaPolitica;
         AV80Serasawwds_18_tfserasapolitica_to = AV38TFSerasaPolitica_To;
         AV81Serasawwds_19_tfserasacreatedat = AV39TFSerasaCreatedAt;
         AV82Serasawwds_20_tfserasacreatedat_to = AV40TFSerasaCreatedAt_To;
         AV83Serasawwds_21_tfserasatipovenda = AV44TFSerasaTipoVenda;
         AV84Serasawwds_22_tfserasatipovenda_sel = AV45TFSerasaTipoVenda_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32ManageFiltersData", AV32ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
      }

      protected void E137W2( )
      {
         /* Gridpaginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Previous") == 0 )
         {
            subgrid_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Next") == 0 )
         {
            subgrid_nextpage( ) ;
         }
         else
         {
            AV47PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV47PageToGo) ;
         }
      }

      protected void E147W2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E157W2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV13OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            AV14OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri(sPrefix, false, "AV14OrderedDsc", AV14OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ClienteRazaoSocial") == 0 )
            {
               AV52TFClienteRazaoSocial = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV52TFClienteRazaoSocial", AV52TFClienteRazaoSocial);
               AV53TFClienteRazaoSocial_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV53TFClienteRazaoSocial_Sel", AV53TFClienteRazaoSocial_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SerasaNumeroProposta") == 0 )
            {
               AV35TFSerasaNumeroProposta = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV35TFSerasaNumeroProposta", AV35TFSerasaNumeroProposta);
               AV36TFSerasaNumeroProposta_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV36TFSerasaNumeroProposta_Sel", AV36TFSerasaNumeroProposta_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SerasaPolitica") == 0 )
            {
               AV37TFSerasaPolitica = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV37TFSerasaPolitica", StringUtil.LTrimStr( AV37TFSerasaPolitica, 15, 2));
               AV38TFSerasaPolitica_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV38TFSerasaPolitica_To", StringUtil.LTrimStr( AV38TFSerasaPolitica_To, 15, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SerasaCreatedAt") == 0 )
            {
               AV39TFSerasaCreatedAt = context.localUtil.CToT( Ddo_grid_Filteredtext_get, 4);
               AssignAttri(sPrefix, false, "AV39TFSerasaCreatedAt", context.localUtil.TToC( AV39TFSerasaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
               AV40TFSerasaCreatedAt_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri(sPrefix, false, "AV40TFSerasaCreatedAt_To", context.localUtil.TToC( AV40TFSerasaCreatedAt_To, 8, 5, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV40TFSerasaCreatedAt_To) )
               {
                  AV40TFSerasaCreatedAt_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV40TFSerasaCreatedAt_To)), (short)(DateTimeUtil.Month( AV40TFSerasaCreatedAt_To)), (short)(DateTimeUtil.Day( AV40TFSerasaCreatedAt_To)), 23, 59, 59);
                  AssignAttri(sPrefix, false, "AV40TFSerasaCreatedAt_To", context.localUtil.TToC( AV40TFSerasaCreatedAt_To, 8, 5, 0, 3, "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SerasaTipoVenda") == 0 )
            {
               AV44TFSerasaTipoVenda = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV44TFSerasaTipoVenda", AV44TFSerasaTipoVenda);
               AV45TFSerasaTipoVenda_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV45TFSerasaTipoVenda_Sel", AV45TFSerasaTipoVenda_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E287W2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV51Display = "<i class=\"fa fa-search\"></i>";
         AssignAttri(sPrefix, false, edtavDisplay_Internalname, AV51Display);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpconsultaserasa"+UrlEncode(StringUtil.LTrimStr(A662SerasaId,9,0));
         edtavDisplay_Link = formatLink("wpconsultaserasa") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "serasa"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A662SerasaId,9,0));
         edtSerasaNumeroProposta_Link = formatLink("serasa") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 107;
         }
         sendrow_1072( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_107_Refreshing )
         {
            DoAjaxLoad(107, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E217W2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV19DynamicFiltersEnabled2 = true;
         AssignAttri(sPrefix, false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp(sPrefix, false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp(sPrefix, false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E177W2( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV27DynamicFiltersRemoving = true;
         AssignAttri(sPrefix, false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         AV28DynamicFiltersIgnoreFirst = true;
         AssignAttri(sPrefix, false, "AV28DynamicFiltersIgnoreFirst", AV28DynamicFiltersIgnoreFirst);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV27DynamicFiltersRemoving = false;
         AssignAttri(sPrefix, false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         AV28DynamicFiltersIgnoreFirst = false;
         AssignAttri(sPrefix, false, "AV28DynamicFiltersIgnoreFirst", AV28DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18SerasaNumeroProposta1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22SerasaNumeroProposta2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26SerasaNumeroProposta3, AV55Array_ClienteId, AV34ManageFiltersExecutionStep, AV62Pgmname, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV52TFClienteRazaoSocial, AV53TFClienteRazaoSocial_Sel, AV35TFSerasaNumeroProposta, AV36TFSerasaNumeroProposta_Sel, AV37TFSerasaPolitica, AV38TFSerasaPolitica_To, AV39TFSerasaCreatedAt, AV40TFSerasaCreatedAt_To, AV44TFSerasaTipoVenda, AV45TFSerasaTipoVenda_Sel, AV54ClientesIds, AV56PropostaId, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, AV59PropostaResponsavelId, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32ManageFiltersData", AV32ManageFiltersData);
      }

      protected void E227W2( )
      {
         /* Dynamicfiltersselector1_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E237W2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV23DynamicFiltersEnabled3 = true;
         AssignAttri(sPrefix, false, "AV23DynamicFiltersEnabled3", AV23DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp(sPrefix, false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp(sPrefix, false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E187W2( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV27DynamicFiltersRemoving = true;
         AssignAttri(sPrefix, false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         AV19DynamicFiltersEnabled2 = false;
         AssignAttri(sPrefix, false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV27DynamicFiltersRemoving = false;
         AssignAttri(sPrefix, false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18SerasaNumeroProposta1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22SerasaNumeroProposta2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26SerasaNumeroProposta3, AV55Array_ClienteId, AV34ManageFiltersExecutionStep, AV62Pgmname, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV52TFClienteRazaoSocial, AV53TFClienteRazaoSocial_Sel, AV35TFSerasaNumeroProposta, AV36TFSerasaNumeroProposta_Sel, AV37TFSerasaPolitica, AV38TFSerasaPolitica_To, AV39TFSerasaCreatedAt, AV40TFSerasaCreatedAt_To, AV44TFSerasaTipoVenda, AV45TFSerasaTipoVenda_Sel, AV54ClientesIds, AV56PropostaId, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, AV59PropostaResponsavelId, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32ManageFiltersData", AV32ManageFiltersData);
      }

      protected void E247W2( )
      {
         /* Dynamicfiltersselector2_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E197W2( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV27DynamicFiltersRemoving = true;
         AssignAttri(sPrefix, false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         AV23DynamicFiltersEnabled3 = false;
         AssignAttri(sPrefix, false, "AV23DynamicFiltersEnabled3", AV23DynamicFiltersEnabled3);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV27DynamicFiltersRemoving = false;
         AssignAttri(sPrefix, false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18SerasaNumeroProposta1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22SerasaNumeroProposta2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26SerasaNumeroProposta3, AV55Array_ClienteId, AV34ManageFiltersExecutionStep, AV62Pgmname, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV52TFClienteRazaoSocial, AV53TFClienteRazaoSocial_Sel, AV35TFSerasaNumeroProposta, AV36TFSerasaNumeroProposta_Sel, AV37TFSerasaPolitica, AV38TFSerasaPolitica_To, AV39TFSerasaCreatedAt, AV40TFSerasaCreatedAt_To, AV44TFSerasaTipoVenda, AV45TFSerasaTipoVenda_Sel, AV54ClientesIds, AV56PropostaId, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, AV59PropostaResponsavelId, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32ManageFiltersData", AV32ManageFiltersData);
      }

      protected void E257W2( )
      {
         /* Dynamicfiltersselector3_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E127W2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S222 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Save#>") == 0 )
         {
            /* Execute user subroutine: 'SAVEGRIDSTATE' */
            S182 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("SerasaWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV62Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV34ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV34ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV34ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("SerasaWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV34ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV34ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV34ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else
         {
            GXt_char2 = AV33ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "SerasaWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV33ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV33ManageFiltersXml)) )
            {
               GX_msglist.addItem("O filtro selecionado não existe mais.");
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S222 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV62Pgmname+"GridState",  AV33ManageFiltersXml) ;
               AV10GridState.FromXml(AV33ManageFiltersXml, null, "", "");
               AV13OrderedBy = AV10GridState.gxTpr_Orderedby;
               AssignAttri(sPrefix, false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
               AV14OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
               AssignAttri(sPrefix, false, "AV14OrderedDsc", AV14OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S172 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S232 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
               S212 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32ManageFiltersData", AV32ManageFiltersData);
      }

      protected void E167W2( )
      {
         /* Dvelop_confirmpanel_consultaserasa_Close Routine */
         returnInSub = false;
         AV60Tipo = "Paciente";
         AssignAttri(sPrefix, false, "AV60Tipo", AV60Tipo);
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_consultaserasa_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO ACTION CONSULTASERASA' */
            S242 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         if ( ( StringUtil.StrCmp(Dvelop_confirmpanel_consultaserasa_Result, "No") == 0 ) && ! (0==AV59PropostaResponsavelId) )
         {
            AV60Tipo = "Responsavel";
            AssignAttri(sPrefix, false, "AV60Tipo", AV60Tipo);
            /* Execute user subroutine: 'DO ACTION CONSULTASERASA' */
            S242 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32ManageFiltersData", AV32ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
      }

      protected void E207W2( )
      {
         /* 'DoExport' Routine */
         returnInSub = false;
         new serasawwexport(context ).execute( out  AV29ExcelFilename, out  AV30ErrorMessage) ;
         if ( StringUtil.StrCmp(AV29ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV29ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV30ErrorMessage);
         }
      }

      protected void S172( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV13OrderedBy), 4, 0))+":"+(AV14OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         edtavSerasanumeroproposta1_Visible = 0;
         AssignProp(sPrefix, false, edtavSerasanumeroproposta1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSerasanumeroproposta1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "SERASANUMEROPROPOSTA") == 0 )
         {
            edtavSerasanumeroproposta1_Visible = 1;
            AssignProp(sPrefix, false, edtavSerasanumeroproposta1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSerasanumeroproposta1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavSerasanumeroproposta2_Visible = 0;
         AssignProp(sPrefix, false, edtavSerasanumeroproposta2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSerasanumeroproposta2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "SERASANUMEROPROPOSTA") == 0 )
         {
            edtavSerasanumeroproposta2_Visible = 1;
            AssignProp(sPrefix, false, edtavSerasanumeroproposta2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSerasanumeroproposta2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavSerasanumeroproposta3_Visible = 0;
         AssignProp(sPrefix, false, edtavSerasanumeroproposta3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSerasanumeroproposta3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "SERASANUMEROPROPOSTA") == 0 )
         {
            edtavSerasanumeroproposta3_Visible = 1;
            AssignProp(sPrefix, false, edtavSerasanumeroproposta3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSerasanumeroproposta3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S202( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV19DynamicFiltersEnabled2 = false;
         AssignAttri(sPrefix, false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
         AV20DynamicFiltersSelector2 = "SERASANUMEROPROPOSTA";
         AssignAttri(sPrefix, false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         AV21DynamicFiltersOperator2 = 0;
         AssignAttri(sPrefix, false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AV22SerasaNumeroProposta2 = "";
         AssignAttri(sPrefix, false, "AV22SerasaNumeroProposta2", AV22SerasaNumeroProposta2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV23DynamicFiltersEnabled3 = false;
         AssignAttri(sPrefix, false, "AV23DynamicFiltersEnabled3", AV23DynamicFiltersEnabled3);
         AV24DynamicFiltersSelector3 = "SERASANUMEROPROPOSTA";
         AssignAttri(sPrefix, false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
         AV25DynamicFiltersOperator3 = 0;
         AssignAttri(sPrefix, false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AV26SerasaNumeroProposta3 = "";
         AssignAttri(sPrefix, false, "AV26SerasaNumeroProposta3", AV26SerasaNumeroProposta3);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV32ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "SerasaWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV32ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S222( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri(sPrefix, false, "AV15FilterFullText", AV15FilterFullText);
         AV52TFClienteRazaoSocial = "";
         AssignAttri(sPrefix, false, "AV52TFClienteRazaoSocial", AV52TFClienteRazaoSocial);
         AV53TFClienteRazaoSocial_Sel = "";
         AssignAttri(sPrefix, false, "AV53TFClienteRazaoSocial_Sel", AV53TFClienteRazaoSocial_Sel);
         AV35TFSerasaNumeroProposta = "";
         AssignAttri(sPrefix, false, "AV35TFSerasaNumeroProposta", AV35TFSerasaNumeroProposta);
         AV36TFSerasaNumeroProposta_Sel = "";
         AssignAttri(sPrefix, false, "AV36TFSerasaNumeroProposta_Sel", AV36TFSerasaNumeroProposta_Sel);
         AV37TFSerasaPolitica = 0;
         AssignAttri(sPrefix, false, "AV37TFSerasaPolitica", StringUtil.LTrimStr( AV37TFSerasaPolitica, 15, 2));
         AV38TFSerasaPolitica_To = 0;
         AssignAttri(sPrefix, false, "AV38TFSerasaPolitica_To", StringUtil.LTrimStr( AV38TFSerasaPolitica_To, 15, 2));
         AV39TFSerasaCreatedAt = (DateTime)(DateTime.MinValue);
         AssignAttri(sPrefix, false, "AV39TFSerasaCreatedAt", context.localUtil.TToC( AV39TFSerasaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         AV40TFSerasaCreatedAt_To = (DateTime)(DateTime.MinValue);
         AssignAttri(sPrefix, false, "AV40TFSerasaCreatedAt_To", context.localUtil.TToC( AV40TFSerasaCreatedAt_To, 8, 5, 0, 3, "/", ":", " "));
         AV44TFSerasaTipoVenda = "";
         AssignAttri(sPrefix, false, "AV44TFSerasaTipoVenda", AV44TFSerasaTipoVenda);
         AV45TFSerasaTipoVenda_Sel = "";
         AssignAttri(sPrefix, false, "AV45TFSerasaTipoVenda_Sel", AV45TFSerasaTipoVenda_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV16DynamicFiltersSelector1 = "SERASANUMEROPROPOSTA";
         AssignAttri(sPrefix, false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         AV17DynamicFiltersOperator1 = 0;
         AssignAttri(sPrefix, false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AV18SerasaNumeroProposta1 = "";
         AssignAttri(sPrefix, false, "AV18SerasaNumeroProposta1", AV18SerasaNumeroProposta1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV10GridState.gxTpr_Dynamicfilters.Clear();
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S242( )
      {
         /* 'DO ACTION CONSULTASERASA' Routine */
         returnInSub = false;
         new prserasapf(context ).execute(  AV56PropostaId,  AV60Tipo, out  AV58SdConteudoRecomendaPF) ;
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18SerasaNumeroProposta1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22SerasaNumeroProposta2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26SerasaNumeroProposta3, AV55Array_ClienteId, AV34ManageFiltersExecutionStep, AV62Pgmname, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV52TFClienteRazaoSocial, AV53TFClienteRazaoSocial_Sel, AV35TFSerasaNumeroProposta, AV36TFSerasaNumeroProposta_Sel, AV37TFSerasaPolitica, AV38TFSerasaPolitica_To, AV39TFSerasaCreatedAt, AV40TFSerasaCreatedAt_To, AV44TFSerasaTipoVenda, AV45TFSerasaTipoVenda_Sel, AV54ClientesIds, AV56PropostaId, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, AV59PropostaResponsavelId, sPrefix) ;
      }

      protected void S162( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV31Session.Get(AV62Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV62Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV31Session.Get(AV62Pgmname+"GridState"), null, "", "");
         }
         AV13OrderedBy = AV10GridState.gxTpr_Orderedby;
         AssignAttri(sPrefix, false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
         AV14OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
         AssignAttri(sPrefix, false, "AV14OrderedDsc", AV14OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV10GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV10GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV10GridState.gxTpr_Currentpage) ;
      }

      protected void S232( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV85GXV1 = 1;
         while ( AV85GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV85GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL") == 0 )
            {
               AV52TFClienteRazaoSocial = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV52TFClienteRazaoSocial", AV52TFClienteRazaoSocial);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV53TFClienteRazaoSocial_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV53TFClienteRazaoSocial_Sel", AV53TFClienteRazaoSocial_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASANUMEROPROPOSTA") == 0 )
            {
               AV35TFSerasaNumeroProposta = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV35TFSerasaNumeroProposta", AV35TFSerasaNumeroProposta);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASANUMEROPROPOSTA_SEL") == 0 )
            {
               AV36TFSerasaNumeroProposta_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV36TFSerasaNumeroProposta_Sel", AV36TFSerasaNumeroProposta_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASAPOLITICA") == 0 )
            {
               AV37TFSerasaPolitica = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV37TFSerasaPolitica", StringUtil.LTrimStr( AV37TFSerasaPolitica, 15, 2));
               AV38TFSerasaPolitica_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV38TFSerasaPolitica_To", StringUtil.LTrimStr( AV38TFSerasaPolitica_To, 15, 2));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASACREATEDAT") == 0 )
            {
               AV39TFSerasaCreatedAt = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri(sPrefix, false, "AV39TFSerasaCreatedAt", context.localUtil.TToC( AV39TFSerasaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
               AV40TFSerasaCreatedAt_To = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri(sPrefix, false, "AV40TFSerasaCreatedAt_To", context.localUtil.TToC( AV40TFSerasaCreatedAt_To, 8, 5, 0, 3, "/", ":", " "));
               AV41DDO_SerasaCreatedAtAuxDate = DateTimeUtil.ResetTime(AV39TFSerasaCreatedAt);
               AssignAttri(sPrefix, false, "AV41DDO_SerasaCreatedAtAuxDate", context.localUtil.Format(AV41DDO_SerasaCreatedAtAuxDate, "99/99/99"));
               AV42DDO_SerasaCreatedAtAuxDateTo = DateTimeUtil.ResetTime(AV40TFSerasaCreatedAt_To);
               AssignAttri(sPrefix, false, "AV42DDO_SerasaCreatedAtAuxDateTo", context.localUtil.Format(AV42DDO_SerasaCreatedAtAuxDateTo, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASATIPOVENDA") == 0 )
            {
               AV44TFSerasaTipoVenda = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV44TFSerasaTipoVenda", AV44TFSerasaTipoVenda);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASATIPOVENDA_SEL") == 0 )
            {
               AV45TFSerasaTipoVenda_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV45TFSerasaTipoVenda_Sel", AV45TFSerasaTipoVenda_Sel);
            }
            AV85GXV1 = (int)(AV85GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV53TFClienteRazaoSocial_Sel)),  AV53TFClienteRazaoSocial_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV36TFSerasaNumeroProposta_Sel)),  AV36TFSerasaNumeroProposta_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV45TFSerasaTipoVenda_Sel)),  AV45TFSerasaTipoVenda_Sel, out  GXt_char5) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char4+"|||"+GXt_char5;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV52TFClienteRazaoSocial)),  AV52TFClienteRazaoSocial, out  GXt_char5) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV35TFSerasaNumeroProposta)),  AV35TFSerasaNumeroProposta, out  GXt_char4) ;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV44TFSerasaTipoVenda)),  AV44TFSerasaTipoVenda, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char5+"|"+GXt_char4+"|"+((Convert.ToDecimal(0)==AV37TFSerasaPolitica) ? "" : StringUtil.Str( AV37TFSerasaPolitica, 15, 2))+"|"+((DateTime.MinValue==AV39TFSerasaCreatedAt) ? "" : context.localUtil.DToC( AV41DDO_SerasaCreatedAtAuxDate, 4, "/"))+"|"+GXt_char2;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "||"+((Convert.ToDecimal(0)==AV38TFSerasaPolitica_To) ? "" : StringUtil.Str( AV38TFSerasaPolitica_To, 15, 2))+"|"+((DateTime.MinValue==AV40TFSerasaCreatedAt_To) ? "" : context.localUtil.DToC( AV42DDO_SerasaCreatedAtAuxDateTo, 4, "/"))+"|";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S212( )
      {
         /* 'LOADDYNFILTERSSTATE' Routine */
         returnInSub = false;
         imgAdddynamicfilters1_Visible = 1;
         AssignProp(sPrefix, false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 0;
         AssignProp(sPrefix, false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         imgAdddynamicfilters2_Visible = 1;
         AssignProp(sPrefix, false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 0;
         AssignProp(sPrefix, false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         if ( AV10GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(1));
            AV16DynamicFiltersSelector1 = AV12GridStateDynamicFilter.gxTpr_Selected;
            AssignAttri(sPrefix, false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
            if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "SERASANUMEROPROPOSTA") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri(sPrefix, false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV18SerasaNumeroProposta1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV18SerasaNumeroProposta1", AV18SerasaNumeroProposta1);
            }
            /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
            S122 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            if ( AV10GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               lblJsdynamicfilters_Caption = "<script type=\"text/javascript\">$(document).ready(function() {";
               AssignProp(sPrefix, false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
               lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+StringUtil.Format( "WWPDynFilterShow_AL('%1', 2, 0);", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
               imgAdddynamicfilters1_Visible = 0;
               AssignProp(sPrefix, false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
               imgRemovedynamicfilters1_Visible = 1;
               AssignProp(sPrefix, false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
               AV19DynamicFiltersEnabled2 = true;
               AssignAttri(sPrefix, false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
               AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(2));
               AV20DynamicFiltersSelector2 = AV12GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri(sPrefix, false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "SERASANUMEROPROPOSTA") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri(sPrefix, false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
                  AV22SerasaNumeroProposta2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri(sPrefix, false, "AV22SerasaNumeroProposta2", AV22SerasaNumeroProposta2);
               }
               /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
               S132 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               if ( AV10GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+StringUtil.Format( "WWPDynFilterShow_AL('%1', 3, 0);", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
                  AssignProp(sPrefix, false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
                  imgAdddynamicfilters2_Visible = 0;
                  AssignProp(sPrefix, false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
                  imgRemovedynamicfilters2_Visible = 1;
                  AssignProp(sPrefix, false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
                  AV23DynamicFiltersEnabled3 = true;
                  AssignAttri(sPrefix, false, "AV23DynamicFiltersEnabled3", AV23DynamicFiltersEnabled3);
                  AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(3));
                  AV24DynamicFiltersSelector3 = AV12GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri(sPrefix, false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "SERASANUMEROPROPOSTA") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri(sPrefix, false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
                     AV26SerasaNumeroProposta3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri(sPrefix, false, "AV26SerasaNumeroProposta3", AV26SerasaNumeroProposta3);
                  }
                  /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
                  S142 ();
                  if ( returnInSub )
                  {
                     returnInSub = true;
                     if (true) return;
                  }
               }
               lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+"});</script>";
               AssignProp(sPrefix, false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
            }
         }
         if ( AV27DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp(sPrefix, false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S182( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV31Session.Get(AV62Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCLIENTERAZAOSOCIAL",  "Nome",  !String.IsNullOrEmpty(StringUtil.RTrim( AV52TFClienteRazaoSocial)),  0,  AV52TFClienteRazaoSocial,  AV52TFClienteRazaoSocial,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV53TFClienteRazaoSocial_Sel)),  AV53TFClienteRazaoSocial_Sel,  AV53TFClienteRazaoSocial_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFSERASANUMEROPROPOSTA",  "Identificador",  !String.IsNullOrEmpty(StringUtil.RTrim( AV35TFSerasaNumeroProposta)),  0,  AV35TFSerasaNumeroProposta,  AV35TFSerasaNumeroProposta,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV36TFSerasaNumeroProposta_Sel)),  AV36TFSerasaNumeroProposta_Sel,  AV36TFSerasaNumeroProposta_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFSERASAPOLITICA",  "Política",  !((Convert.ToDecimal(0)==AV37TFSerasaPolitica)&&(Convert.ToDecimal(0)==AV38TFSerasaPolitica_To)),  0,  StringUtil.Trim( StringUtil.Str( AV37TFSerasaPolitica, 15, 2)),  ((Convert.ToDecimal(0)==AV37TFSerasaPolitica) ? "" : StringUtil.Trim( context.localUtil.Format( AV37TFSerasaPolitica, "ZZZZZZZZZZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV38TFSerasaPolitica_To, 15, 2)),  ((Convert.ToDecimal(0)==AV38TFSerasaPolitica_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV38TFSerasaPolitica_To, "ZZZZZZZZZZZ9.99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFSERASACREATEDAT",  "Data",  !((DateTime.MinValue==AV39TFSerasaCreatedAt)&&(DateTime.MinValue==AV40TFSerasaCreatedAt_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV39TFSerasaCreatedAt, 8, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV39TFSerasaCreatedAt) ? "" : StringUtil.Trim( context.localUtil.Format( AV39TFSerasaCreatedAt, "99/99/99 99:99"))),  true,  StringUtil.Trim( context.localUtil.TToC( AV40TFSerasaCreatedAt_To, 8, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV40TFSerasaCreatedAt_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV40TFSerasaCreatedAt_To, "99/99/99 99:99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFSERASATIPOVENDA",  "Tipo de venda",  !String.IsNullOrEmpty(StringUtil.RTrim( AV44TFSerasaTipoVenda)),  0,  AV44TFSerasaTipoVenda,  AV44TFSerasaTipoVenda,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV45TFSerasaTipoVenda_Sel)),  AV45TFSerasaTipoVenda_Sel,  AV45TFSerasaTipoVenda_Sel) ;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54ClientesIds)) )
         {
            AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV11GridStateFilterValue.gxTpr_Name = "PARM_&CLIENTESIDS";
            AV11GridStateFilterValue.gxTpr_Value = AV54ClientesIds;
            AV10GridState.gxTpr_Filtervalues.Add(AV11GridStateFilterValue, 0);
         }
         if ( ! (0==AV56PropostaId) )
         {
            AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV11GridStateFilterValue.gxTpr_Name = "PARM_&PROPOSTAID";
            AV11GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV56PropostaId), 9, 0);
            AV10GridState.gxTpr_Filtervalues.Add(AV11GridStateFilterValue, 0);
         }
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV62Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S192( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV10GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV28DynamicFiltersIgnoreFirst )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV16DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "SERASANUMEROPROPOSTA") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV18SerasaNumeroProposta1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Numero Proposta",  AV17DynamicFiltersOperator1,  AV18SerasaNumeroProposta1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV18SerasaNumeroProposta1, "Contém"+" "+AV18SerasaNumeroProposta1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV27DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV19DynamicFiltersEnabled2 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV20DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "SERASANUMEROPROPOSTA") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV22SerasaNumeroProposta2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Numero Proposta",  AV21DynamicFiltersOperator2,  AV22SerasaNumeroProposta2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV22SerasaNumeroProposta2, "Contém"+" "+AV22SerasaNumeroProposta2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV27DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV23DynamicFiltersEnabled3 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV24DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "SERASANUMEROPROPOSTA") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV26SerasaNumeroProposta3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Numero Proposta",  AV25DynamicFiltersOperator3,  AV26SerasaNumeroProposta3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV26SerasaNumeroProposta3, "Contém"+" "+AV26SerasaNumeroProposta3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV27DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
      }

      protected void S152( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV62Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Serasa";
         AV31Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table4_124_7W2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_consultaserasa_Internalname, tblTabledvelop_confirmpanel_consultaserasa_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_consultaserasa.SetProperty("Title", Dvelop_confirmpanel_consultaserasa_Title);
            ucDvelop_confirmpanel_consultaserasa.SetProperty("ConfirmationText", Dvelop_confirmpanel_consultaserasa_Confirmationtext);
            ucDvelop_confirmpanel_consultaserasa.SetProperty("YesButtonCaption", Dvelop_confirmpanel_consultaserasa_Yesbuttoncaption);
            ucDvelop_confirmpanel_consultaserasa.SetProperty("NoButtonCaption", Dvelop_confirmpanel_consultaserasa_Nobuttoncaption);
            ucDvelop_confirmpanel_consultaserasa.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_consultaserasa_Cancelbuttoncaption);
            ucDvelop_confirmpanel_consultaserasa.SetProperty("YesButtonPosition", Dvelop_confirmpanel_consultaserasa_Yesbuttonposition);
            ucDvelop_confirmpanel_consultaserasa.SetProperty("ConfirmType", Dvelop_confirmpanel_consultaserasa_Confirmtype);
            ucDvelop_confirmpanel_consultaserasa.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_consultaserasa_Internalname, sPrefix+"DVELOP_CONFIRMPANEL_CONSULTASERASAContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVELOP_CONFIRMPANEL_CONSULTASERASAContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_124_7W2e( true) ;
         }
         else
         {
            wb_table4_124_7W2e( false) ;
         }
      }

      protected void wb_table3_89_7W2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfilters3_Internalname, tblTablemergeddynamicfilters3_Internalname, "", "Table", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersoperator3_Internalname, "Dynamic Filters Operator3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,93);\"", "", true, 0, "HLP_SerasaWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_serasanumeroproposta3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSerasanumeroproposta3_Internalname, "Serasa Numero Proposta3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSerasanumeroproposta3_Internalname, AV26SerasaNumeroProposta3, StringUtil.RTrim( context.localUtil.Format( AV26SerasaNumeroProposta3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSerasanumeroproposta3_Jsonclick, 0, "Attribute", "", "", "", "", edtavSerasanumeroproposta3_Visible, edtavSerasanumeroproposta3_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SerasaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_SerasaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_89_7W2e( true) ;
         }
         else
         {
            wb_table3_89_7W2e( false) ;
         }
      }

      protected void wb_table2_67_7W2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfilters2_Internalname, tblTablemergeddynamicfilters2_Internalname, "", "Table", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersoperator2_Internalname, "Dynamic Filters Operator2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "", true, 0, "HLP_SerasaWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_serasanumeroproposta2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSerasanumeroproposta2_Internalname, "Serasa Numero Proposta2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSerasanumeroproposta2_Internalname, AV22SerasaNumeroProposta2, StringUtil.RTrim( context.localUtil.Format( AV22SerasaNumeroProposta2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSerasanumeroproposta2_Jsonclick, 0, "Attribute", "", "", "", "", edtavSerasanumeroproposta2_Visible, edtavSerasanumeroproposta2_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SerasaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_SerasaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_SerasaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_67_7W2e( true) ;
         }
         else
         {
            wb_table2_67_7W2e( false) ;
         }
      }

      protected void wb_table1_45_7W2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfilters1_Internalname, tblTablemergeddynamicfilters1_Internalname, "", "Table", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersoperator1_Internalname, "Dynamic Filters Operator1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 0, "HLP_SerasaWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_serasanumeroproposta1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSerasanumeroproposta1_Internalname, "Serasa Numero Proposta1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSerasanumeroproposta1_Internalname, AV18SerasaNumeroProposta1, StringUtil.RTrim( context.localUtil.Format( AV18SerasaNumeroProposta1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSerasanumeroproposta1_Jsonclick, 0, "Attribute", "", "", "", "", edtavSerasanumeroproposta1_Visible, edtavSerasanumeroproposta1_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SerasaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_SerasaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_SerasaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_45_7W2e( true) ;
         }
         else
         {
            wb_table1_45_7W2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV54ClientesIds = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV54ClientesIds", AV54ClientesIds);
         AV56PropostaId = Convert.ToInt32(getParm(obj,1));
         AssignAttri(sPrefix, false, "AV56PropostaId", StringUtil.LTrimStr( (decimal)(AV56PropostaId), 9, 0));
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
         PA7W2( ) ;
         WS7W2( ) ;
         WE7W2( ) ;
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
         sCtrlAV54ClientesIds = (string)((string)getParm(obj,0));
         sCtrlAV56PropostaId = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA7W2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "serasaww", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA7W2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV54ClientesIds = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV54ClientesIds", AV54ClientesIds);
            AV56PropostaId = Convert.ToInt32(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV56PropostaId", StringUtil.LTrimStr( (decimal)(AV56PropostaId), 9, 0));
         }
         wcpOAV54ClientesIds = cgiGet( sPrefix+"wcpOAV54ClientesIds");
         wcpOAV56PropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV56PropostaId"), ",", "."), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV54ClientesIds, wcpOAV54ClientesIds) != 0 ) || ( AV56PropostaId != wcpOAV56PropostaId ) ) )
         {
            setjustcreated();
         }
         wcpOAV54ClientesIds = AV54ClientesIds;
         wcpOAV56PropostaId = AV56PropostaId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV54ClientesIds = cgiGet( sPrefix+"AV54ClientesIds_CTRL");
         if ( StringUtil.Len( sCtrlAV54ClientesIds) > 0 )
         {
            AV54ClientesIds = cgiGet( sCtrlAV54ClientesIds);
            AssignAttri(sPrefix, false, "AV54ClientesIds", AV54ClientesIds);
         }
         else
         {
            AV54ClientesIds = cgiGet( sPrefix+"AV54ClientesIds_PARM");
         }
         sCtrlAV56PropostaId = cgiGet( sPrefix+"AV56PropostaId_CTRL");
         if ( StringUtil.Len( sCtrlAV56PropostaId) > 0 )
         {
            AV56PropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV56PropostaId), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV56PropostaId", StringUtil.LTrimStr( (decimal)(AV56PropostaId), 9, 0));
         }
         else
         {
            AV56PropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV56PropostaId_PARM"), ",", "."), 18, MidpointRounding.ToEven));
         }
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
         PA7W2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS7W2( ) ;
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
         WS7W2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV54ClientesIds_PARM", AV54ClientesIds);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV54ClientesIds)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV54ClientesIds_CTRL", StringUtil.RTrim( sCtrlAV54ClientesIds));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV56PropostaId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV56PropostaId), 9, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV56PropostaId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV56PropostaId_CTRL", StringUtil.RTrim( sCtrlAV56PropostaId));
         }
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
         WE7W2( ) ;
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
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("DVelop/DVPaginationBar/DVPaginationBar.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019202850", true, true);
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
         context.AddJavascriptSource("serasaww.js", "?202561019202853", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1072( )
      {
         edtavDisplay_Internalname = sPrefix+"vDISPLAY_"+sGXsfl_107_idx;
         edtSerasaId_Internalname = sPrefix+"SERASAID_"+sGXsfl_107_idx;
         edtClienteId_Internalname = sPrefix+"CLIENTEID_"+sGXsfl_107_idx;
         edtClienteRazaoSocial_Internalname = sPrefix+"CLIENTERAZAOSOCIAL_"+sGXsfl_107_idx;
         edtSerasaNumeroProposta_Internalname = sPrefix+"SERASANUMEROPROPOSTA_"+sGXsfl_107_idx;
         edtSerasaPolitica_Internalname = sPrefix+"SERASAPOLITICA_"+sGXsfl_107_idx;
         edtSerasaCreatedAt_Internalname = sPrefix+"SERASACREATEDAT_"+sGXsfl_107_idx;
         edtSerasaTipoVenda_Internalname = sPrefix+"SERASATIPOVENDA_"+sGXsfl_107_idx;
      }

      protected void SubsflControlProps_fel_1072( )
      {
         edtavDisplay_Internalname = sPrefix+"vDISPLAY_"+sGXsfl_107_fel_idx;
         edtSerasaId_Internalname = sPrefix+"SERASAID_"+sGXsfl_107_fel_idx;
         edtClienteId_Internalname = sPrefix+"CLIENTEID_"+sGXsfl_107_fel_idx;
         edtClienteRazaoSocial_Internalname = sPrefix+"CLIENTERAZAOSOCIAL_"+sGXsfl_107_fel_idx;
         edtSerasaNumeroProposta_Internalname = sPrefix+"SERASANUMEROPROPOSTA_"+sGXsfl_107_fel_idx;
         edtSerasaPolitica_Internalname = sPrefix+"SERASAPOLITICA_"+sGXsfl_107_fel_idx;
         edtSerasaCreatedAt_Internalname = sPrefix+"SERASACREATEDAT_"+sGXsfl_107_fel_idx;
         edtSerasaTipoVenda_Internalname = sPrefix+"SERASATIPOVENDA_"+sGXsfl_107_fel_idx;
      }

      protected void sendrow_1072( )
      {
         sGXsfl_107_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_107_idx), 4, 0), 4, "0");
         SubsflControlProps_1072( ) ;
         WB7W0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_107_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_107_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar GridWithBorderColor WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_107_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',107)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDisplay_Internalname,StringUtil.RTrim( AV51Display),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,108);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtavDisplay_Link,(string)"",(string)"Mostrar",(string)"",(string)edtavDisplay_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavDisplay_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)107,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSerasaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A662SerasaId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A662SerasaId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSerasaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A168ClienteId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteRazaoSocial_Internalname,(string)A170ClienteRazaoSocial,StringUtil.RTrim( context.localUtil.Format( A170ClienteRazaoSocial, "@!")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteRazaoSocial_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSerasaNumeroProposta_Internalname,(string)A663SerasaNumeroProposta,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtSerasaNumeroProposta_Link,(string)"",(string)"",(string)"",(string)edtSerasaNumeroProposta_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSerasaPolitica_Internalname,StringUtil.LTrim( StringUtil.NToC( A664SerasaPolitica, 15, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A664SerasaPolitica, "ZZZZZZZZZZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSerasaPolitica_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)15,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSerasaCreatedAt_Internalname,context.localUtil.TToC( A665SerasaCreatedAt, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A665SerasaCreatedAt, "99/99/99 99:99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSerasaCreatedAt_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSerasaTipoVenda_Internalname,(string)A666SerasaTipoVenda,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSerasaTipoVenda_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes7W2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_107_idx = ((subGrid_Islastpage==1)&&(nGXsfl_107_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_107_idx+1);
            sGXsfl_107_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_107_idx), 4, 0), 4, "0");
            SubsflControlProps_1072( ) ;
         }
         /* End function sendrow_1072 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("SERASANUMEROPROPOSTA", "Numero Proposta", 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
         }
         cmbavDynamicfiltersoperator1.Name = "vDYNAMICFILTERSOPERATOR1";
         cmbavDynamicfiltersoperator1.WebTags = "";
         cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("SERASANUMEROPROPOSTA", "Numero Proposta", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("SERASANUMEROPROPOSTA", "Numero Proposta", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl107( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"107\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "GridWithPaginationBar GridWithBorderColor WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Nome") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Identificador") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Política") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Data") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Tipo de venda") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridContainer = new GXWebGrid( context);
            }
            else
            {
               GridContainer.Clear();
            }
            GridContainer.SetWrapped(nGXWrapped);
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "GridWithPaginationBar GridWithBorderColor WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", sPrefix);
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV51Display)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDisplay_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDisplay_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A662SerasaId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A170ClienteRazaoSocial));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A663SerasaNumeroProposta));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtSerasaNumeroProposta_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A664SerasaPolitica, 15, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A665SerasaCreatedAt, 10, 8, 0, 3, "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A666SerasaTipoVenda));
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
         bttBtnconsultaserasa_Internalname = sPrefix+"BTNCONSULTASERASA";
         bttBtnexport_Internalname = sPrefix+"BTNEXPORT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         Ddo_managefilters_Internalname = sPrefix+"DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = sPrefix+"vFILTERFULLTEXT";
         divTablefilters_Internalname = sPrefix+"TABLEFILTERS";
         divTablerightheader_Internalname = sPrefix+"TABLERIGHTHEADER";
         divTableheadercontent_Internalname = sPrefix+"TABLEHEADERCONTENT";
         lblDynamicfiltersprefix1_Internalname = sPrefix+"DYNAMICFILTERSPREFIX1";
         cmbavDynamicfiltersselector1_Internalname = sPrefix+"vDYNAMICFILTERSSELECTOR1";
         lblDynamicfiltersmiddle1_Internalname = sPrefix+"DYNAMICFILTERSMIDDLE1";
         cmbavDynamicfiltersoperator1_Internalname = sPrefix+"vDYNAMICFILTERSOPERATOR1";
         edtavSerasanumeroproposta1_Internalname = sPrefix+"vSERASANUMEROPROPOSTA1";
         cellFilter_serasanumeroproposta1_cell_Internalname = sPrefix+"FILTER_SERASANUMEROPROPOSTA1_CELL";
         imgAdddynamicfilters1_Internalname = sPrefix+"ADDDYNAMICFILTERS1";
         cellDynamicfilters_addfilter1_cell_Internalname = sPrefix+"DYNAMICFILTERS_ADDFILTER1_CELL";
         imgRemovedynamicfilters1_Internalname = sPrefix+"REMOVEDYNAMICFILTERS1";
         cellDynamicfilters_removefilter1_cell_Internalname = sPrefix+"DYNAMICFILTERS_REMOVEFILTER1_CELL";
         tblTablemergeddynamicfilters1_Internalname = sPrefix+"TABLEMERGEDDYNAMICFILTERS1";
         divTabledynamicfiltersrow1_Internalname = sPrefix+"TABLEDYNAMICFILTERSROW1";
         lblDynamicfiltersprefix2_Internalname = sPrefix+"DYNAMICFILTERSPREFIX2";
         cmbavDynamicfiltersselector2_Internalname = sPrefix+"vDYNAMICFILTERSSELECTOR2";
         lblDynamicfiltersmiddle2_Internalname = sPrefix+"DYNAMICFILTERSMIDDLE2";
         cmbavDynamicfiltersoperator2_Internalname = sPrefix+"vDYNAMICFILTERSOPERATOR2";
         edtavSerasanumeroproposta2_Internalname = sPrefix+"vSERASANUMEROPROPOSTA2";
         cellFilter_serasanumeroproposta2_cell_Internalname = sPrefix+"FILTER_SERASANUMEROPROPOSTA2_CELL";
         imgAdddynamicfilters2_Internalname = sPrefix+"ADDDYNAMICFILTERS2";
         cellDynamicfilters_addfilter2_cell_Internalname = sPrefix+"DYNAMICFILTERS_ADDFILTER2_CELL";
         imgRemovedynamicfilters2_Internalname = sPrefix+"REMOVEDYNAMICFILTERS2";
         cellDynamicfilters_removefilter2_cell_Internalname = sPrefix+"DYNAMICFILTERS_REMOVEFILTER2_CELL";
         tblTablemergeddynamicfilters2_Internalname = sPrefix+"TABLEMERGEDDYNAMICFILTERS2";
         divTabledynamicfiltersrow2_Internalname = sPrefix+"TABLEDYNAMICFILTERSROW2";
         lblDynamicfiltersprefix3_Internalname = sPrefix+"DYNAMICFILTERSPREFIX3";
         cmbavDynamicfiltersselector3_Internalname = sPrefix+"vDYNAMICFILTERSSELECTOR3";
         lblDynamicfiltersmiddle3_Internalname = sPrefix+"DYNAMICFILTERSMIDDLE3";
         cmbavDynamicfiltersoperator3_Internalname = sPrefix+"vDYNAMICFILTERSOPERATOR3";
         edtavSerasanumeroproposta3_Internalname = sPrefix+"vSERASANUMEROPROPOSTA3";
         cellFilter_serasanumeroproposta3_cell_Internalname = sPrefix+"FILTER_SERASANUMEROPROPOSTA3_CELL";
         imgRemovedynamicfilters3_Internalname = sPrefix+"REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = sPrefix+"DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = sPrefix+"TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = sPrefix+"TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = sPrefix+"TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = sPrefix+"ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = sPrefix+"TABLEHEADER";
         Dvpanel_tableheader_Internalname = sPrefix+"DVPANEL_TABLEHEADER";
         edtavDisplay_Internalname = sPrefix+"vDISPLAY";
         edtSerasaId_Internalname = sPrefix+"SERASAID";
         edtClienteId_Internalname = sPrefix+"CLIENTEID";
         edtClienteRazaoSocial_Internalname = sPrefix+"CLIENTERAZAOSOCIAL";
         edtSerasaNumeroProposta_Internalname = sPrefix+"SERASANUMEROPROPOSTA";
         edtSerasaPolitica_Internalname = sPrefix+"SERASAPOLITICA";
         edtSerasaCreatedAt_Internalname = sPrefix+"SERASACREATEDAT";
         edtSerasaTipoVenda_Internalname = sPrefix+"SERASATIPOVENDA";
         Gridpaginationbar_Internalname = sPrefix+"GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = sPrefix+"GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         lblJsdynamicfilters_Internalname = sPrefix+"JSDYNAMICFILTERS";
         Ddo_grid_Internalname = sPrefix+"DDO_GRID";
         Dvelop_confirmpanel_consultaserasa_Internalname = sPrefix+"DVELOP_CONFIRMPANEL_CONSULTASERASA";
         tblTabledvelop_confirmpanel_consultaserasa_Internalname = sPrefix+"TABLEDVELOP_CONFIRMPANEL_CONSULTASERASA";
         Grid_empowerer_Internalname = sPrefix+"GRID_EMPOWERER";
         edtavDdo_serasacreatedatauxdatetext_Internalname = sPrefix+"vDDO_SERASACREATEDATAUXDATETEXT";
         Tfserasacreatedat_rangepicker_Internalname = sPrefix+"TFSERASACREATEDAT_RANGEPICKER";
         divDdo_serasacreatedatauxdates_Internalname = sPrefix+"DDO_SERASACREATEDATAUXDATES";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGrid_Internalname = sPrefix+"GRID";
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
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         edtSerasaTipoVenda_Jsonclick = "";
         edtSerasaCreatedAt_Jsonclick = "";
         edtSerasaPolitica_Jsonclick = "";
         edtSerasaNumeroProposta_Jsonclick = "";
         edtSerasaNumeroProposta_Link = "";
         edtClienteRazaoSocial_Jsonclick = "";
         edtClienteId_Jsonclick = "";
         edtSerasaId_Jsonclick = "";
         edtavDisplay_Jsonclick = "";
         edtavDisplay_Link = "";
         edtavDisplay_Enabled = 0;
         subGrid_Class = "GridWithPaginationBar GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavSerasanumeroproposta1_Jsonclick = "";
         edtavSerasanumeroproposta1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavSerasanumeroproposta2_Jsonclick = "";
         edtavSerasanumeroproposta2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavSerasanumeroproposta3_Jsonclick = "";
         edtavSerasanumeroproposta3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavSerasanumeroproposta3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavSerasanumeroproposta2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavSerasanumeroproposta1_Visible = 1;
         edtSerasaTipoVenda_Enabled = 0;
         edtSerasaCreatedAt_Enabled = 0;
         edtSerasaPolitica_Enabled = 0;
         edtSerasaNumeroProposta_Enabled = 0;
         edtClienteRazaoSocial_Enabled = 0;
         edtClienteId_Enabled = 0;
         edtSerasaId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_serasacreatedatauxdatetext_Jsonclick = "";
         lblJsdynamicfilters_Caption = "JSDynamicFilters";
         cmbavDynamicfiltersselector3_Jsonclick = "";
         cmbavDynamicfiltersselector3.Enabled = 1;
         cmbavDynamicfiltersselector2_Jsonclick = "";
         cmbavDynamicfiltersselector2.Enabled = 1;
         cmbavDynamicfiltersselector1_Jsonclick = "";
         cmbavDynamicfiltersselector1.Enabled = 1;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Dvelop_confirmpanel_consultaserasa_Confirmtype = "2";
         Dvelop_confirmpanel_consultaserasa_Yesbuttonposition = "left";
         Dvelop_confirmpanel_consultaserasa_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_consultaserasa_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_consultaserasa_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_consultaserasa_Confirmationtext = "";
         Dvelop_confirmpanel_consultaserasa_Title = "Consulta Serasa";
         Ddo_grid_Format = "||15.2||";
         Ddo_grid_Datalistproc = "SerasaWWGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|||Dynamic";
         Ddo_grid_Includedatalist = "T|T|||T";
         Ddo_grid_Filterisrange = "||T|P|";
         Ddo_grid_Filtertype = "Character|Character|Numeric|Date|Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|1|3|4|5";
         Ddo_grid_Columnids = "3:ClienteRazaoSocial|4:SerasaNumeroProposta|5:SerasaPolitica|6:SerasaCreatedAt|7:SerasaTipoVenda";
         Ddo_grid_Gridinternalname = "";
         Gridpaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridpaginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Gridpaginationbar_Caption = "Página <CURRENT_PAGE> de <TOTAL_PAGES>";
         Gridpaginationbar_Next = "WWP_PagingNextCaption";
         Gridpaginationbar_Previous = "WWP_PagingPreviousCaption";
         Gridpaginationbar_Rowsperpageoptions = "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50";
         Gridpaginationbar_Rowsperpageselectedvalue = 10;
         Gridpaginationbar_Rowsperpageselector = Convert.ToBoolean( -1);
         Gridpaginationbar_Emptygridclass = "PaginationBarEmptyGrid";
         Gridpaginationbar_Pagingcaptionposition = "Left";
         Gridpaginationbar_Pagingbuttonsposition = "Right";
         Gridpaginationbar_Pagestoshow = 5;
         Gridpaginationbar_Showlast = Convert.ToBoolean( 0);
         Gridpaginationbar_Shownext = Convert.ToBoolean( -1);
         Gridpaginationbar_Showprevious = Convert.ToBoolean( -1);
         Gridpaginationbar_Showfirst = Convert.ToBoolean( 0);
         Gridpaginationbar_Class = "PaginationBar";
         Dvpanel_tableheader_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableheader_Iconposition = "Right";
         Dvpanel_tableheader_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableheader_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableheader_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_tableheader_Title = "Opções";
         Dvpanel_tableheader_Cls = "PanelNoHeader";
         Dvpanel_tableheader_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableheader_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableheader_Width = "100%";
         Ddo_managefilters_Cls = "ManageFilters";
         Ddo_managefilters_Tooltip = "WWP_ManageFiltersTooltip";
         Ddo_managefilters_Icon = "fas fa-filter";
         Ddo_managefilters_Icontype = "FontIcon";
         subGrid_Rows = 0;
         context.GX_msglist.DisplayMode = 1;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV55Array_ClienteId","fld":"vARRAY_CLIENTEID","type":""},{"av":"sPrefix","type":"char"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18SerasaNumeroProposta1","fld":"vSERASANUMEROPROPOSTA1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22SerasaNumeroProposta2","fld":"vSERASANUMEROPROPOSTA2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26SerasaNumeroProposta3","fld":"vSERASANUMEROPROPOSTA3","type":"svchar"},{"av":"AV62Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV52TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV53TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV35TFSerasaNumeroProposta","fld":"vTFSERASANUMEROPROPOSTA","type":"svchar"},{"av":"AV36TFSerasaNumeroProposta_Sel","fld":"vTFSERASANUMEROPROPOSTA_SEL","type":"svchar"},{"av":"AV37TFSerasaPolitica","fld":"vTFSERASAPOLITICA","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV38TFSerasaPolitica_To","fld":"vTFSERASAPOLITICA_TO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV39TFSerasaCreatedAt","fld":"vTFSERASACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV40TFSerasaCreatedAt_To","fld":"vTFSERASACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV44TFSerasaTipoVenda","fld":"vTFSERASATIPOVENDA","type":"svchar"},{"av":"AV45TFSerasaTipoVenda_Sel","fld":"vTFSERASATIPOVENDA_SEL","type":"svchar"},{"av":"AV54ClientesIds","fld":"vCLIENTESIDS","type":"svchar"},{"av":"AV56PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV59PropostaResponsavelId","fld":"vPROPOSTARESPONSAVELID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV48GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV49GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV50GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E137W2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18SerasaNumeroProposta1","fld":"vSERASANUMEROPROPOSTA1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22SerasaNumeroProposta2","fld":"vSERASANUMEROPROPOSTA2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26SerasaNumeroProposta3","fld":"vSERASANUMEROPROPOSTA3","type":"svchar"},{"av":"AV55Array_ClienteId","fld":"vARRAY_CLIENTEID","type":""},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV62Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV52TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV53TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV35TFSerasaNumeroProposta","fld":"vTFSERASANUMEROPROPOSTA","type":"svchar"},{"av":"AV36TFSerasaNumeroProposta_Sel","fld":"vTFSERASANUMEROPROPOSTA_SEL","type":"svchar"},{"av":"AV37TFSerasaPolitica","fld":"vTFSERASAPOLITICA","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV38TFSerasaPolitica_To","fld":"vTFSERASAPOLITICA_TO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV39TFSerasaCreatedAt","fld":"vTFSERASACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV40TFSerasaCreatedAt_To","fld":"vTFSERASACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV44TFSerasaTipoVenda","fld":"vTFSERASATIPOVENDA","type":"svchar"},{"av":"AV45TFSerasaTipoVenda_Sel","fld":"vTFSERASATIPOVENDA_SEL","type":"svchar"},{"av":"AV54ClientesIds","fld":"vCLIENTESIDS","type":"svchar"},{"av":"AV56PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV59PropostaResponsavelId","fld":"vPROPOSTARESPONSAVELID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"sPrefix","type":"char"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E147W2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18SerasaNumeroProposta1","fld":"vSERASANUMEROPROPOSTA1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22SerasaNumeroProposta2","fld":"vSERASANUMEROPROPOSTA2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26SerasaNumeroProposta3","fld":"vSERASANUMEROPROPOSTA3","type":"svchar"},{"av":"AV55Array_ClienteId","fld":"vARRAY_CLIENTEID","type":""},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV62Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV52TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV53TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV35TFSerasaNumeroProposta","fld":"vTFSERASANUMEROPROPOSTA","type":"svchar"},{"av":"AV36TFSerasaNumeroProposta_Sel","fld":"vTFSERASANUMEROPROPOSTA_SEL","type":"svchar"},{"av":"AV37TFSerasaPolitica","fld":"vTFSERASAPOLITICA","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV38TFSerasaPolitica_To","fld":"vTFSERASAPOLITICA_TO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV39TFSerasaCreatedAt","fld":"vTFSERASACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV40TFSerasaCreatedAt_To","fld":"vTFSERASACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV44TFSerasaTipoVenda","fld":"vTFSERASATIPOVENDA","type":"svchar"},{"av":"AV45TFSerasaTipoVenda_Sel","fld":"vTFSERASATIPOVENDA_SEL","type":"svchar"},{"av":"AV54ClientesIds","fld":"vCLIENTESIDS","type":"svchar"},{"av":"AV56PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV59PropostaResponsavelId","fld":"vPROPOSTARESPONSAVELID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"sPrefix","type":"char"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E157W2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18SerasaNumeroProposta1","fld":"vSERASANUMEROPROPOSTA1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22SerasaNumeroProposta2","fld":"vSERASANUMEROPROPOSTA2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26SerasaNumeroProposta3","fld":"vSERASANUMEROPROPOSTA3","type":"svchar"},{"av":"AV55Array_ClienteId","fld":"vARRAY_CLIENTEID","type":""},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV62Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV52TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV53TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV35TFSerasaNumeroProposta","fld":"vTFSERASANUMEROPROPOSTA","type":"svchar"},{"av":"AV36TFSerasaNumeroProposta_Sel","fld":"vTFSERASANUMEROPROPOSTA_SEL","type":"svchar"},{"av":"AV37TFSerasaPolitica","fld":"vTFSERASAPOLITICA","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV38TFSerasaPolitica_To","fld":"vTFSERASAPOLITICA_TO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV39TFSerasaCreatedAt","fld":"vTFSERASACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV40TFSerasaCreatedAt_To","fld":"vTFSERASACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV44TFSerasaTipoVenda","fld":"vTFSERASATIPOVENDA","type":"svchar"},{"av":"AV45TFSerasaTipoVenda_Sel","fld":"vTFSERASATIPOVENDA_SEL","type":"svchar"},{"av":"AV54ClientesIds","fld":"vCLIENTESIDS","type":"svchar"},{"av":"AV56PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV59PropostaResponsavelId","fld":"vPROPOSTARESPONSAVELID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"sPrefix","type":"char"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV52TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV53TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV35TFSerasaNumeroProposta","fld":"vTFSERASANUMEROPROPOSTA","type":"svchar"},{"av":"AV36TFSerasaNumeroProposta_Sel","fld":"vTFSERASANUMEROPROPOSTA_SEL","type":"svchar"},{"av":"AV37TFSerasaPolitica","fld":"vTFSERASAPOLITICA","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV38TFSerasaPolitica_To","fld":"vTFSERASAPOLITICA_TO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV39TFSerasaCreatedAt","fld":"vTFSERASACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV40TFSerasaCreatedAt_To","fld":"vTFSERASACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV44TFSerasaTipoVenda","fld":"vTFSERASATIPOVENDA","type":"svchar"},{"av":"AV45TFSerasaTipoVenda_Sel","fld":"vTFSERASATIPOVENDA_SEL","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E287W2","iparms":[{"av":"A662SerasaId","fld":"SERASAID","pic":"ZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV51Display","fld":"vDISPLAY","type":"char"},{"av":"edtavDisplay_Link","ctrl":"vDISPLAY","prop":"Link"},{"av":"edtSerasaNumeroProposta_Link","ctrl":"SERASANUMEROPROPOSTA","prop":"Link"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E217W2","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E177W2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18SerasaNumeroProposta1","fld":"vSERASANUMEROPROPOSTA1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22SerasaNumeroProposta2","fld":"vSERASANUMEROPROPOSTA2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26SerasaNumeroProposta3","fld":"vSERASANUMEROPROPOSTA3","type":"svchar"},{"av":"AV55Array_ClienteId","fld":"vARRAY_CLIENTEID","type":""},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV62Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV52TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV53TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV35TFSerasaNumeroProposta","fld":"vTFSERASANUMEROPROPOSTA","type":"svchar"},{"av":"AV36TFSerasaNumeroProposta_Sel","fld":"vTFSERASANUMEROPROPOSTA_SEL","type":"svchar"},{"av":"AV37TFSerasaPolitica","fld":"vTFSERASAPOLITICA","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV38TFSerasaPolitica_To","fld":"vTFSERASAPOLITICA_TO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV39TFSerasaCreatedAt","fld":"vTFSERASACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV40TFSerasaCreatedAt_To","fld":"vTFSERASACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV44TFSerasaTipoVenda","fld":"vTFSERASATIPOVENDA","type":"svchar"},{"av":"AV45TFSerasaTipoVenda_Sel","fld":"vTFSERASATIPOVENDA_SEL","type":"svchar"},{"av":"AV54ClientesIds","fld":"vCLIENTESIDS","type":"svchar"},{"av":"AV56PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV59PropostaResponsavelId","fld":"vPROPOSTARESPONSAVELID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22SerasaNumeroProposta2","fld":"vSERASANUMEROPROPOSTA2","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26SerasaNumeroProposta3","fld":"vSERASANUMEROPROPOSTA3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18SerasaNumeroProposta1","fld":"vSERASANUMEROPROPOSTA1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavSerasanumeroproposta2_Visible","ctrl":"vSERASANUMEROPROPOSTA2","prop":"Visible"},{"av":"edtavSerasanumeroproposta3_Visible","ctrl":"vSERASANUMEROPROPOSTA3","prop":"Visible"},{"av":"edtavSerasanumeroproposta1_Visible","ctrl":"vSERASANUMEROPROPOSTA1","prop":"Visible"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV48GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV49GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV50GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E227W2","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"edtavSerasanumeroproposta1_Visible","ctrl":"vSERASANUMEROPROPOSTA1","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator1"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E237W2","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E187W2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18SerasaNumeroProposta1","fld":"vSERASANUMEROPROPOSTA1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22SerasaNumeroProposta2","fld":"vSERASANUMEROPROPOSTA2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26SerasaNumeroProposta3","fld":"vSERASANUMEROPROPOSTA3","type":"svchar"},{"av":"AV55Array_ClienteId","fld":"vARRAY_CLIENTEID","type":""},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV62Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV52TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV53TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV35TFSerasaNumeroProposta","fld":"vTFSERASANUMEROPROPOSTA","type":"svchar"},{"av":"AV36TFSerasaNumeroProposta_Sel","fld":"vTFSERASANUMEROPROPOSTA_SEL","type":"svchar"},{"av":"AV37TFSerasaPolitica","fld":"vTFSERASAPOLITICA","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV38TFSerasaPolitica_To","fld":"vTFSERASAPOLITICA_TO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV39TFSerasaCreatedAt","fld":"vTFSERASACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV40TFSerasaCreatedAt_To","fld":"vTFSERASACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV44TFSerasaTipoVenda","fld":"vTFSERASATIPOVENDA","type":"svchar"},{"av":"AV45TFSerasaTipoVenda_Sel","fld":"vTFSERASATIPOVENDA_SEL","type":"svchar"},{"av":"AV54ClientesIds","fld":"vCLIENTESIDS","type":"svchar"},{"av":"AV56PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV59PropostaResponsavelId","fld":"vPROPOSTARESPONSAVELID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22SerasaNumeroProposta2","fld":"vSERASANUMEROPROPOSTA2","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26SerasaNumeroProposta3","fld":"vSERASANUMEROPROPOSTA3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18SerasaNumeroProposta1","fld":"vSERASANUMEROPROPOSTA1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavSerasanumeroproposta2_Visible","ctrl":"vSERASANUMEROPROPOSTA2","prop":"Visible"},{"av":"edtavSerasanumeroproposta3_Visible","ctrl":"vSERASANUMEROPROPOSTA3","prop":"Visible"},{"av":"edtavSerasanumeroproposta1_Visible","ctrl":"vSERASANUMEROPROPOSTA1","prop":"Visible"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV48GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV49GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV50GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E247W2","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"edtavSerasanumeroproposta2_Visible","ctrl":"vSERASANUMEROPROPOSTA2","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator2"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E197W2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18SerasaNumeroProposta1","fld":"vSERASANUMEROPROPOSTA1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22SerasaNumeroProposta2","fld":"vSERASANUMEROPROPOSTA2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26SerasaNumeroProposta3","fld":"vSERASANUMEROPROPOSTA3","type":"svchar"},{"av":"AV55Array_ClienteId","fld":"vARRAY_CLIENTEID","type":""},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV62Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV52TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV53TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV35TFSerasaNumeroProposta","fld":"vTFSERASANUMEROPROPOSTA","type":"svchar"},{"av":"AV36TFSerasaNumeroProposta_Sel","fld":"vTFSERASANUMEROPROPOSTA_SEL","type":"svchar"},{"av":"AV37TFSerasaPolitica","fld":"vTFSERASAPOLITICA","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV38TFSerasaPolitica_To","fld":"vTFSERASAPOLITICA_TO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV39TFSerasaCreatedAt","fld":"vTFSERASACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV40TFSerasaCreatedAt_To","fld":"vTFSERASACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV44TFSerasaTipoVenda","fld":"vTFSERASATIPOVENDA","type":"svchar"},{"av":"AV45TFSerasaTipoVenda_Sel","fld":"vTFSERASATIPOVENDA_SEL","type":"svchar"},{"av":"AV54ClientesIds","fld":"vCLIENTESIDS","type":"svchar"},{"av":"AV56PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV59PropostaResponsavelId","fld":"vPROPOSTARESPONSAVELID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22SerasaNumeroProposta2","fld":"vSERASANUMEROPROPOSTA2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26SerasaNumeroProposta3","fld":"vSERASANUMEROPROPOSTA3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18SerasaNumeroProposta1","fld":"vSERASANUMEROPROPOSTA1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavSerasanumeroproposta2_Visible","ctrl":"vSERASANUMEROPROPOSTA2","prop":"Visible"},{"av":"edtavSerasanumeroproposta3_Visible","ctrl":"vSERASANUMEROPROPOSTA3","prop":"Visible"},{"av":"edtavSerasanumeroproposta1_Visible","ctrl":"vSERASANUMEROPROPOSTA1","prop":"Visible"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV48GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV49GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV50GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E257W2","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"edtavSerasanumeroproposta3_Visible","ctrl":"vSERASANUMEROPROPOSTA3","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator3"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E127W2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18SerasaNumeroProposta1","fld":"vSERASANUMEROPROPOSTA1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22SerasaNumeroProposta2","fld":"vSERASANUMEROPROPOSTA2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26SerasaNumeroProposta3","fld":"vSERASANUMEROPROPOSTA3","type":"svchar"},{"av":"AV55Array_ClienteId","fld":"vARRAY_CLIENTEID","type":""},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV62Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV52TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV53TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV35TFSerasaNumeroProposta","fld":"vTFSERASANUMEROPROPOSTA","type":"svchar"},{"av":"AV36TFSerasaNumeroProposta_Sel","fld":"vTFSERASANUMEROPROPOSTA_SEL","type":"svchar"},{"av":"AV37TFSerasaPolitica","fld":"vTFSERASAPOLITICA","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV38TFSerasaPolitica_To","fld":"vTFSERASAPOLITICA_TO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV39TFSerasaCreatedAt","fld":"vTFSERASACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV40TFSerasaCreatedAt_To","fld":"vTFSERASACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV44TFSerasaTipoVenda","fld":"vTFSERASATIPOVENDA","type":"svchar"},{"av":"AV45TFSerasaTipoVenda_Sel","fld":"vTFSERASATIPOVENDA_SEL","type":"svchar"},{"av":"AV54ClientesIds","fld":"vCLIENTESIDS","type":"svchar"},{"av":"AV56PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV59PropostaResponsavelId","fld":"vPROPOSTARESPONSAVELID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"sPrefix","type":"char"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV41DDO_SerasaCreatedAtAuxDate","fld":"vDDO_SERASACREATEDATAUXDATE","type":"date"},{"av":"AV42DDO_SerasaCreatedAtAuxDateTo","fld":"vDDO_SERASACREATEDATAUXDATETO","type":"date"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV52TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV53TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV35TFSerasaNumeroProposta","fld":"vTFSERASANUMEROPROPOSTA","type":"svchar"},{"av":"AV36TFSerasaNumeroProposta_Sel","fld":"vTFSERASANUMEROPROPOSTA_SEL","type":"svchar"},{"av":"AV37TFSerasaPolitica","fld":"vTFSERASAPOLITICA","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV38TFSerasaPolitica_To","fld":"vTFSERASAPOLITICA_TO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV39TFSerasaCreatedAt","fld":"vTFSERASACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV40TFSerasaCreatedAt_To","fld":"vTFSERASACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV44TFSerasaTipoVenda","fld":"vTFSERASATIPOVENDA","type":"svchar"},{"av":"AV45TFSerasaTipoVenda_Sel","fld":"vTFSERASATIPOVENDA_SEL","type":"svchar"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18SerasaNumeroProposta1","fld":"vSERASANUMEROPROPOSTA1","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV41DDO_SerasaCreatedAtAuxDate","fld":"vDDO_SERASACREATEDATAUXDATE","type":"date"},{"av":"AV42DDO_SerasaCreatedAtAuxDateTo","fld":"vDDO_SERASACREATEDATAUXDATETO","type":"date"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22SerasaNumeroProposta2","fld":"vSERASANUMEROPROPOSTA2","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26SerasaNumeroProposta3","fld":"vSERASANUMEROPROPOSTA3","type":"svchar"},{"av":"edtavSerasanumeroproposta1_Visible","ctrl":"vSERASANUMEROPROPOSTA1","prop":"Visible"},{"av":"edtavSerasanumeroproposta2_Visible","ctrl":"vSERASANUMEROPROPOSTA2","prop":"Visible"},{"av":"edtavSerasanumeroproposta3_Visible","ctrl":"vSERASANUMEROPROPOSTA3","prop":"Visible"},{"av":"AV48GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV49GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV50GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("'DOCONSULTASERASA'","""{"handler":"E117W1","iparms":[]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_CONSULTASERASA.CLOSE","""{"handler":"E167W2","iparms":[{"av":"Dvelop_confirmpanel_consultaserasa_Result","ctrl":"DVELOP_CONFIRMPANEL_CONSULTASERASA","prop":"Result"},{"av":"AV59PropostaResponsavelId","fld":"vPROPOSTARESPONSAVELID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18SerasaNumeroProposta1","fld":"vSERASANUMEROPROPOSTA1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22SerasaNumeroProposta2","fld":"vSERASANUMEROPROPOSTA2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26SerasaNumeroProposta3","fld":"vSERASANUMEROPROPOSTA3","type":"svchar"},{"av":"AV55Array_ClienteId","fld":"vARRAY_CLIENTEID","type":""},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV62Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV52TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV53TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV35TFSerasaNumeroProposta","fld":"vTFSERASANUMEROPROPOSTA","type":"svchar"},{"av":"AV36TFSerasaNumeroProposta_Sel","fld":"vTFSERASANUMEROPROPOSTA_SEL","type":"svchar"},{"av":"AV37TFSerasaPolitica","fld":"vTFSERASAPOLITICA","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV38TFSerasaPolitica_To","fld":"vTFSERASAPOLITICA_TO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV39TFSerasaCreatedAt","fld":"vTFSERASACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV40TFSerasaCreatedAt_To","fld":"vTFSERASACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV44TFSerasaTipoVenda","fld":"vTFSERASATIPOVENDA","type":"svchar"},{"av":"AV45TFSerasaTipoVenda_Sel","fld":"vTFSERASATIPOVENDA_SEL","type":"svchar"},{"av":"AV54ClientesIds","fld":"vCLIENTESIDS","type":"svchar"},{"av":"AV56PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"},{"av":"AV60Tipo","fld":"vTIPO","type":"svchar"}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_CONSULTASERASA.CLOSE",""","oparms":[{"av":"AV60Tipo","fld":"vTIPO","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV48GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV49GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV50GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'DOEXPORT'","""{"handler":"E207W2","iparms":[]}""");
         setEventMetadata("VALID_CLIENTEID","""{"handler":"Valid_Clienteid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Serasatipovenda","iparms":[]}""");
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
         wcpOAV54ClientesIds = "";
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Filteredtextto_get = "";
         Ddo_managefilters_Activeeventkey = "";
         Dvelop_confirmpanel_consultaserasa_Result = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV15FilterFullText = "";
         AV16DynamicFiltersSelector1 = "";
         AV18SerasaNumeroProposta1 = "";
         AV20DynamicFiltersSelector2 = "";
         AV22SerasaNumeroProposta2 = "";
         AV24DynamicFiltersSelector3 = "";
         AV26SerasaNumeroProposta3 = "";
         AV55Array_ClienteId = new GxSimpleCollection<int>();
         AV62Pgmname = "";
         AV52TFClienteRazaoSocial = "";
         AV53TFClienteRazaoSocial_Sel = "";
         AV35TFSerasaNumeroProposta = "";
         AV36TFSerasaNumeroProposta_Sel = "";
         AV39TFSerasaCreatedAt = (DateTime)(DateTime.MinValue);
         AV40TFSerasaCreatedAt_To = (DateTime)(DateTime.MinValue);
         AV44TFSerasaTipoVenda = "";
         AV45TFSerasaTipoVenda_Sel = "";
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV32ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV50GridAppliedFilters = "";
         AV46DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV41DDO_SerasaCreatedAtAuxDate = DateTime.MinValue;
         AV42DDO_SerasaCreatedAtAuxDateTo = DateTime.MinValue;
         AV60Tipo = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         ucDvpanel_tableheader = new GXUserControl();
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnconsultaserasa_Jsonclick = "";
         bttBtnexport_Jsonclick = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         lblDynamicfiltersprefix1_Jsonclick = "";
         lblDynamicfiltersmiddle1_Jsonclick = "";
         lblDynamicfiltersprefix2_Jsonclick = "";
         lblDynamicfiltersmiddle2_Jsonclick = "";
         lblDynamicfiltersprefix3_Jsonclick = "";
         lblDynamicfiltersmiddle3_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         lblJsdynamicfilters_Jsonclick = "";
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         AV43DDO_SerasaCreatedAtAuxDateText = "";
         ucTfserasacreatedat_rangepicker = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV51Display = "";
         A170ClienteRazaoSocial = "";
         A663SerasaNumeroProposta = "";
         A665SerasaCreatedAt = (DateTime)(DateTime.MinValue);
         A666SerasaTipoVenda = "";
         GXDecQS = "";
         lV63Serasawwds_1_filterfulltext = "";
         lV66Serasawwds_4_serasanumeroproposta1 = "";
         lV70Serasawwds_8_serasanumeroproposta2 = "";
         lV74Serasawwds_12_serasanumeroproposta3 = "";
         lV75Serasawwds_13_tfclienterazaosocial = "";
         lV77Serasawwds_15_tfserasanumeroproposta = "";
         lV83Serasawwds_21_tfserasatipovenda = "";
         AV63Serasawwds_1_filterfulltext = "";
         AV64Serasawwds_2_dynamicfiltersselector1 = "";
         AV66Serasawwds_4_serasanumeroproposta1 = "";
         AV68Serasawwds_6_dynamicfiltersselector2 = "";
         AV70Serasawwds_8_serasanumeroproposta2 = "";
         AV72Serasawwds_10_dynamicfiltersselector3 = "";
         AV74Serasawwds_12_serasanumeroproposta3 = "";
         AV76Serasawwds_14_tfclienterazaosocial_sel = "";
         AV75Serasawwds_13_tfclienterazaosocial = "";
         AV78Serasawwds_16_tfserasanumeroproposta_sel = "";
         AV77Serasawwds_15_tfserasanumeroproposta = "";
         AV81Serasawwds_19_tfserasacreatedat = (DateTime)(DateTime.MinValue);
         AV82Serasawwds_20_tfserasacreatedat_to = (DateTime)(DateTime.MinValue);
         AV84Serasawwds_22_tfserasatipovenda_sel = "";
         AV83Serasawwds_21_tfserasatipovenda = "";
         H007W2_A666SerasaTipoVenda = new string[] {""} ;
         H007W2_n666SerasaTipoVenda = new bool[] {false} ;
         H007W2_A665SerasaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         H007W2_n665SerasaCreatedAt = new bool[] {false} ;
         H007W2_A664SerasaPolitica = new decimal[1] ;
         H007W2_n664SerasaPolitica = new bool[] {false} ;
         H007W2_A663SerasaNumeroProposta = new string[] {""} ;
         H007W2_n663SerasaNumeroProposta = new bool[] {false} ;
         H007W2_A170ClienteRazaoSocial = new string[] {""} ;
         H007W2_n170ClienteRazaoSocial = new bool[] {false} ;
         H007W2_A168ClienteId = new int[1] ;
         H007W2_n168ClienteId = new bool[] {false} ;
         H007W2_A662SerasaId = new int[1] ;
         H007W3_AGRID_nRecordCount = new long[1] ;
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         H007W4_A323PropostaId = new int[1] ;
         H007W4_A553PropostaResponsavelId = new int[1] ;
         H007W4_n553PropostaResponsavelId = new bool[] {false} ;
         ucDvelop_confirmpanel_consultaserasa = new GXUserControl();
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV33ManageFiltersXml = "";
         AV29ExcelFilename = "";
         AV30ErrorMessage = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV58SdConteudoRecomendaPF = new SdtSdConteudoRecomendaPF(context);
         AV31Session = context.GetSession();
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char5 = "";
         GXt_char4 = "";
         GXt_char2 = "";
         AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         imgRemovedynamicfilters3_gximage = "";
         sImgUrl = "";
         imgAdddynamicfilters2_gximage = "";
         imgRemovedynamicfilters2_gximage = "";
         imgAdddynamicfilters1_gximage = "";
         imgRemovedynamicfilters1_gximage = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV54ClientesIds = "";
         sCtrlAV56PropostaId = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.serasaww__default(),
            new Object[][] {
                new Object[] {
               H007W2_A666SerasaTipoVenda, H007W2_n666SerasaTipoVenda, H007W2_A665SerasaCreatedAt, H007W2_n665SerasaCreatedAt, H007W2_A664SerasaPolitica, H007W2_n664SerasaPolitica, H007W2_A663SerasaNumeroProposta, H007W2_n663SerasaNumeroProposta, H007W2_A170ClienteRazaoSocial, H007W2_n170ClienteRazaoSocial,
               H007W2_A168ClienteId, H007W2_n168ClienteId, H007W2_A662SerasaId
               }
               , new Object[] {
               H007W3_AGRID_nRecordCount
               }
               , new Object[] {
               H007W4_A323PropostaId, H007W4_A553PropostaResponsavelId, H007W4_n553PropostaResponsavelId
               }
            }
         );
         AV62Pgmname = "SerasaWW";
         /* GeneXus formulas. */
         AV62Pgmname = "SerasaWW";
         edtavDisplay_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV13OrderedBy ;
      private short AV17DynamicFiltersOperator1 ;
      private short AV21DynamicFiltersOperator2 ;
      private short AV25DynamicFiltersOperator3 ;
      private short AV34ManageFiltersExecutionStep ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV65Serasawwds_3_dynamicfiltersoperator1 ;
      private short AV69Serasawwds_7_dynamicfiltersoperator2 ;
      private short AV73Serasawwds_11_dynamicfiltersoperator3 ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int AV56PropostaId ;
      private int wcpOAV56PropostaId ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_107 ;
      private int nGXsfl_107_idx=1 ;
      private int AV59PropostaResponsavelId ;
      private int edtavDisplay_Enabled ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int A662SerasaId ;
      private int A168ClienteId ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtSerasaId_Enabled ;
      private int edtClienteId_Enabled ;
      private int edtClienteRazaoSocial_Enabled ;
      private int edtSerasaNumeroProposta_Enabled ;
      private int edtSerasaPolitica_Enabled ;
      private int edtSerasaCreatedAt_Enabled ;
      private int edtSerasaTipoVenda_Enabled ;
      private int A323PropostaId ;
      private int A553PropostaResponsavelId ;
      private int AV47PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavSerasanumeroproposta1_Visible ;
      private int edtavSerasanumeroproposta2_Visible ;
      private int edtavSerasanumeroproposta3_Visible ;
      private int AV85GXV1 ;
      private int edtavSerasanumeroproposta3_Enabled ;
      private int edtavSerasanumeroproposta2_Enabled ;
      private int edtavSerasanumeroproposta1_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV48GridCurrentPage ;
      private long AV49GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal AV37TFSerasaPolitica ;
      private decimal AV38TFSerasaPolitica_To ;
      private decimal A664SerasaPolitica ;
      private decimal AV79Serasawwds_17_tfserasapolitica ;
      private decimal AV80Serasawwds_18_tfserasapolitica_to ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Dvelop_confirmpanel_consultaserasa_Result ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_107_idx="0001" ;
      private string AV62Pgmname ;
      private string edtavDisplay_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Ddo_managefilters_Icontype ;
      private string Ddo_managefilters_Icon ;
      private string Ddo_managefilters_Tooltip ;
      private string Ddo_managefilters_Cls ;
      private string Dvpanel_tableheader_Width ;
      private string Dvpanel_tableheader_Cls ;
      private string Dvpanel_tableheader_Title ;
      private string Dvpanel_tableheader_Iconposition ;
      private string Gridpaginationbar_Class ;
      private string Gridpaginationbar_Pagingbuttonsposition ;
      private string Gridpaginationbar_Pagingcaptionposition ;
      private string Gridpaginationbar_Emptygridclass ;
      private string Gridpaginationbar_Rowsperpageoptions ;
      private string Gridpaginationbar_Previous ;
      private string Gridpaginationbar_Next ;
      private string Gridpaginationbar_Caption ;
      private string Gridpaginationbar_Emptygridcaption ;
      private string Gridpaginationbar_Rowsperpagecaption ;
      private string Ddo_grid_Caption ;
      private string Ddo_grid_Filteredtext_set ;
      private string Ddo_grid_Filteredtextto_set ;
      private string Ddo_grid_Selectedvalue_set ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_grid_Includefilter ;
      private string Ddo_grid_Filtertype ;
      private string Ddo_grid_Filterisrange ;
      private string Ddo_grid_Includedatalist ;
      private string Ddo_grid_Datalisttype ;
      private string Ddo_grid_Datalistproc ;
      private string Ddo_grid_Format ;
      private string Dvelop_confirmpanel_consultaserasa_Title ;
      private string Dvelop_confirmpanel_consultaserasa_Confirmationtext ;
      private string Dvelop_confirmpanel_consultaserasa_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_consultaserasa_Nobuttoncaption ;
      private string Dvelop_confirmpanel_consultaserasa_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_consultaserasa_Yesbuttonposition ;
      private string Dvelop_confirmpanel_consultaserasa_Confirmtype ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string Dvpanel_tableheader_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnconsultaserasa_Internalname ;
      private string bttBtnconsultaserasa_Jsonclick ;
      private string bttBtnexport_Internalname ;
      private string bttBtnexport_Jsonclick ;
      private string divTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string divTablefilters_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string divAdvancedfilterscontainer_Internalname ;
      private string divTabledynamicfilters_Internalname ;
      private string divTabledynamicfiltersrow1_Internalname ;
      private string lblDynamicfiltersprefix1_Internalname ;
      private string lblDynamicfiltersprefix1_Jsonclick ;
      private string cmbavDynamicfiltersselector1_Internalname ;
      private string cmbavDynamicfiltersselector1_Jsonclick ;
      private string lblDynamicfiltersmiddle1_Internalname ;
      private string lblDynamicfiltersmiddle1_Jsonclick ;
      private string divTabledynamicfiltersrow2_Internalname ;
      private string lblDynamicfiltersprefix2_Internalname ;
      private string lblDynamicfiltersprefix2_Jsonclick ;
      private string cmbavDynamicfiltersselector2_Internalname ;
      private string cmbavDynamicfiltersselector2_Jsonclick ;
      private string lblDynamicfiltersmiddle2_Internalname ;
      private string lblDynamicfiltersmiddle2_Jsonclick ;
      private string divTabledynamicfiltersrow3_Internalname ;
      private string lblDynamicfiltersprefix3_Internalname ;
      private string lblDynamicfiltersprefix3_Jsonclick ;
      private string cmbavDynamicfiltersselector3_Internalname ;
      private string cmbavDynamicfiltersselector3_Jsonclick ;
      private string lblDynamicfiltersmiddle3_Internalname ;
      private string lblDynamicfiltersmiddle3_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string lblJsdynamicfilters_Internalname ;
      private string lblJsdynamicfilters_Caption ;
      private string lblJsdynamicfilters_Jsonclick ;
      private string Ddo_grid_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDdo_serasacreatedatauxdates_Internalname ;
      private string edtavDdo_serasacreatedatauxdatetext_Internalname ;
      private string edtavDdo_serasacreatedatauxdatetext_Jsonclick ;
      private string Tfserasacreatedat_rangepicker_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV51Display ;
      private string edtSerasaId_Internalname ;
      private string edtClienteId_Internalname ;
      private string edtClienteRazaoSocial_Internalname ;
      private string edtSerasaNumeroProposta_Internalname ;
      private string edtSerasaPolitica_Internalname ;
      private string edtSerasaCreatedAt_Internalname ;
      private string edtSerasaTipoVenda_Internalname ;
      private string GXDecQS ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string edtavSerasanumeroproposta1_Internalname ;
      private string edtavSerasanumeroproposta2_Internalname ;
      private string edtavSerasanumeroproposta3_Internalname ;
      private string imgAdddynamicfilters1_Jsonclick ;
      private string imgAdddynamicfilters1_Internalname ;
      private string imgRemovedynamicfilters1_Jsonclick ;
      private string imgRemovedynamicfilters1_Internalname ;
      private string imgAdddynamicfilters2_Jsonclick ;
      private string imgAdddynamicfilters2_Internalname ;
      private string imgRemovedynamicfilters2_Jsonclick ;
      private string imgRemovedynamicfilters2_Internalname ;
      private string imgRemovedynamicfilters3_Jsonclick ;
      private string imgRemovedynamicfilters3_Internalname ;
      private string Dvelop_confirmpanel_consultaserasa_Internalname ;
      private string edtavDisplay_Link ;
      private string edtSerasaNumeroProposta_Link ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string GXt_char2 ;
      private string tblTabledvelop_confirmpanel_consultaserasa_Internalname ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_serasanumeroproposta3_cell_Internalname ;
      private string edtavSerasanumeroproposta3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_serasanumeroproposta2_cell_Internalname ;
      private string edtavSerasanumeroproposta2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_serasanumeroproposta1_cell_Internalname ;
      private string edtavSerasanumeroproposta1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string sCtrlAV54ClientesIds ;
      private string sCtrlAV56PropostaId ;
      private string sGXsfl_107_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavDisplay_Jsonclick ;
      private string edtSerasaId_Jsonclick ;
      private string edtClienteId_Jsonclick ;
      private string edtClienteRazaoSocial_Jsonclick ;
      private string edtSerasaNumeroProposta_Jsonclick ;
      private string edtSerasaPolitica_Jsonclick ;
      private string edtSerasaCreatedAt_Jsonclick ;
      private string edtSerasaTipoVenda_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV39TFSerasaCreatedAt ;
      private DateTime AV40TFSerasaCreatedAt_To ;
      private DateTime A665SerasaCreatedAt ;
      private DateTime AV81Serasawwds_19_tfserasacreatedat ;
      private DateTime AV82Serasawwds_20_tfserasacreatedat_to ;
      private DateTime AV41DDO_SerasaCreatedAtAuxDate ;
      private DateTime AV42DDO_SerasaCreatedAtAuxDateTo ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV19DynamicFiltersEnabled2 ;
      private bool AV23DynamicFiltersEnabled3 ;
      private bool AV28DynamicFiltersIgnoreFirst ;
      private bool AV27DynamicFiltersRemoving ;
      private bool bGXsfl_107_Refreshing=false ;
      private bool Dvpanel_tableheader_Autowidth ;
      private bool Dvpanel_tableheader_Autoheight ;
      private bool Dvpanel_tableheader_Collapsible ;
      private bool Dvpanel_tableheader_Collapsed ;
      private bool Dvpanel_tableheader_Showcollapseicon ;
      private bool Dvpanel_tableheader_Autoscroll ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n168ClienteId ;
      private bool n170ClienteRazaoSocial ;
      private bool n663SerasaNumeroProposta ;
      private bool n664SerasaPolitica ;
      private bool n665SerasaCreatedAt ;
      private bool n666SerasaTipoVenda ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV67Serasawwds_5_dynamicfiltersenabled2 ;
      private bool AV71Serasawwds_9_dynamicfiltersenabled3 ;
      private bool returnInSub ;
      private bool n553PropostaResponsavelId ;
      private bool gx_refresh_fired ;
      private string AV33ManageFiltersXml ;
      private string AV54ClientesIds ;
      private string wcpOAV54ClientesIds ;
      private string AV15FilterFullText ;
      private string AV16DynamicFiltersSelector1 ;
      private string AV18SerasaNumeroProposta1 ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV22SerasaNumeroProposta2 ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV26SerasaNumeroProposta3 ;
      private string AV52TFClienteRazaoSocial ;
      private string AV53TFClienteRazaoSocial_Sel ;
      private string AV35TFSerasaNumeroProposta ;
      private string AV36TFSerasaNumeroProposta_Sel ;
      private string AV44TFSerasaTipoVenda ;
      private string AV45TFSerasaTipoVenda_Sel ;
      private string AV50GridAppliedFilters ;
      private string AV60Tipo ;
      private string AV43DDO_SerasaCreatedAtAuxDateText ;
      private string A170ClienteRazaoSocial ;
      private string A663SerasaNumeroProposta ;
      private string A666SerasaTipoVenda ;
      private string lV63Serasawwds_1_filterfulltext ;
      private string lV66Serasawwds_4_serasanumeroproposta1 ;
      private string lV70Serasawwds_8_serasanumeroproposta2 ;
      private string lV74Serasawwds_12_serasanumeroproposta3 ;
      private string lV75Serasawwds_13_tfclienterazaosocial ;
      private string lV77Serasawwds_15_tfserasanumeroproposta ;
      private string lV83Serasawwds_21_tfserasatipovenda ;
      private string AV63Serasawwds_1_filterfulltext ;
      private string AV64Serasawwds_2_dynamicfiltersselector1 ;
      private string AV66Serasawwds_4_serasanumeroproposta1 ;
      private string AV68Serasawwds_6_dynamicfiltersselector2 ;
      private string AV70Serasawwds_8_serasanumeroproposta2 ;
      private string AV72Serasawwds_10_dynamicfiltersselector3 ;
      private string AV74Serasawwds_12_serasanumeroproposta3 ;
      private string AV76Serasawwds_14_tfclienterazaosocial_sel ;
      private string AV75Serasawwds_13_tfclienterazaosocial ;
      private string AV78Serasawwds_16_tfserasanumeroproposta_sel ;
      private string AV77Serasawwds_15_tfserasanumeroproposta ;
      private string AV84Serasawwds_22_tfserasatipovenda_sel ;
      private string AV83Serasawwds_21_tfserasatipovenda ;
      private string AV29ExcelFilename ;
      private string AV30ErrorMessage ;
      private IGxSession AV31Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfserasacreatedat_rangepicker ;
      private GXUserControl ucDvelop_confirmpanel_consultaserasa ;
      private GXWebForm Form ;
      private GxHttpRequest AV7HTTPRequest ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GxSimpleCollection<int> AV55Array_ClienteId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV32ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV46DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private string[] H007W2_A666SerasaTipoVenda ;
      private bool[] H007W2_n666SerasaTipoVenda ;
      private DateTime[] H007W2_A665SerasaCreatedAt ;
      private bool[] H007W2_n665SerasaCreatedAt ;
      private decimal[] H007W2_A664SerasaPolitica ;
      private bool[] H007W2_n664SerasaPolitica ;
      private string[] H007W2_A663SerasaNumeroProposta ;
      private bool[] H007W2_n663SerasaNumeroProposta ;
      private string[] H007W2_A170ClienteRazaoSocial ;
      private bool[] H007W2_n170ClienteRazaoSocial ;
      private int[] H007W2_A168ClienteId ;
      private bool[] H007W2_n168ClienteId ;
      private int[] H007W2_A662SerasaId ;
      private long[] H007W3_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private int[] H007W4_A323PropostaId ;
      private int[] H007W4_A553PropostaResponsavelId ;
      private bool[] H007W4_n553PropostaResponsavelId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private SdtSdConteudoRecomendaPF AV58SdConteudoRecomendaPF ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV12GridStateDynamicFilter ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class serasaww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H007W2( IGxContext context ,
                                             int A168ClienteId ,
                                             GxSimpleCollection<int> AV55Array_ClienteId ,
                                             string AV63Serasawwds_1_filterfulltext ,
                                             string AV64Serasawwds_2_dynamicfiltersselector1 ,
                                             short AV65Serasawwds_3_dynamicfiltersoperator1 ,
                                             string AV66Serasawwds_4_serasanumeroproposta1 ,
                                             bool AV67Serasawwds_5_dynamicfiltersenabled2 ,
                                             string AV68Serasawwds_6_dynamicfiltersselector2 ,
                                             short AV69Serasawwds_7_dynamicfiltersoperator2 ,
                                             string AV70Serasawwds_8_serasanumeroproposta2 ,
                                             bool AV71Serasawwds_9_dynamicfiltersenabled3 ,
                                             string AV72Serasawwds_10_dynamicfiltersselector3 ,
                                             short AV73Serasawwds_11_dynamicfiltersoperator3 ,
                                             string AV74Serasawwds_12_serasanumeroproposta3 ,
                                             string AV76Serasawwds_14_tfclienterazaosocial_sel ,
                                             string AV75Serasawwds_13_tfclienterazaosocial ,
                                             string AV78Serasawwds_16_tfserasanumeroproposta_sel ,
                                             string AV77Serasawwds_15_tfserasanumeroproposta ,
                                             decimal AV79Serasawwds_17_tfserasapolitica ,
                                             decimal AV80Serasawwds_18_tfserasapolitica_to ,
                                             DateTime AV81Serasawwds_19_tfserasacreatedat ,
                                             DateTime AV82Serasawwds_20_tfserasacreatedat_to ,
                                             string AV84Serasawwds_22_tfserasatipovenda_sel ,
                                             string AV83Serasawwds_21_tfserasatipovenda ,
                                             string A170ClienteRazaoSocial ,
                                             string A663SerasaNumeroProposta ,
                                             decimal A664SerasaPolitica ,
                                             string A666SerasaTipoVenda ,
                                             DateTime A665SerasaCreatedAt ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[23];
         Object[] GXv_Object7 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.SerasaTipoVenda, T1.SerasaCreatedAt, T1.SerasaPolitica, T1.SerasaNumeroProposta, T2.ClienteRazaoSocial, T1.ClienteId, T1.SerasaId";
         sFromString = " FROM (Serasa T1 LEFT JOIN Cliente T2 ON T2.ClienteId = T1.ClienteId)";
         sOrderString = "";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV55Array_ClienteId, "T1.ClienteId IN (", ")")+")");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Serasawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.ClienteRazaoSocial like '%' || :lV63Serasawwds_1_filterfulltext) or ( T1.SerasaNumeroProposta like '%' || :lV63Serasawwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.SerasaPolitica,'999999999990.99'), 2) like '%' || :lV63Serasawwds_1_filterfulltext) or ( T1.SerasaTipoVenda like '%' || :lV63Serasawwds_1_filterfulltext))");
         }
         else
         {
            GXv_int6[0] = 1;
            GXv_int6[1] = 1;
            GXv_int6[2] = 1;
            GXv_int6[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV64Serasawwds_2_dynamicfiltersselector1, "SERASANUMEROPROPOSTA") == 0 ) && ( AV65Serasawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Serasawwds_4_serasanumeroproposta1)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta like :lV66Serasawwds_4_serasanumeroproposta1)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV64Serasawwds_2_dynamicfiltersselector1, "SERASANUMEROPROPOSTA") == 0 ) && ( AV65Serasawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Serasawwds_4_serasanumeroproposta1)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta like '%' || :lV66Serasawwds_4_serasanumeroproposta1)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( AV67Serasawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Serasawwds_6_dynamicfiltersselector2, "SERASANUMEROPROPOSTA") == 0 ) && ( AV69Serasawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Serasawwds_8_serasanumeroproposta2)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta like :lV70Serasawwds_8_serasanumeroproposta2)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( AV67Serasawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Serasawwds_6_dynamicfiltersselector2, "SERASANUMEROPROPOSTA") == 0 ) && ( AV69Serasawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Serasawwds_8_serasanumeroproposta2)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta like '%' || :lV70Serasawwds_8_serasanumeroproposta2)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( AV71Serasawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Serasawwds_10_dynamicfiltersselector3, "SERASANUMEROPROPOSTA") == 0 ) && ( AV73Serasawwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Serasawwds_12_serasanumeroproposta3)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta like :lV74Serasawwds_12_serasanumeroproposta3)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( AV71Serasawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Serasawwds_10_dynamicfiltersselector3, "SERASANUMEROPROPOSTA") == 0 ) && ( AV73Serasawwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Serasawwds_12_serasanumeroproposta3)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta like '%' || :lV74Serasawwds_12_serasanumeroproposta3)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Serasawwds_14_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Serasawwds_13_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial like :lV75Serasawwds_13_tfclienterazaosocial)");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Serasawwds_14_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV76Serasawwds_14_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial = ( :AV76Serasawwds_14_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( StringUtil.StrCmp(AV76Serasawwds_14_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T2.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Serasawwds_16_tfserasanumeroproposta_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Serasawwds_15_tfserasanumeroproposta)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta like :lV77Serasawwds_15_tfserasanumeroproposta)");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Serasawwds_16_tfserasanumeroproposta_sel)) && ! ( StringUtil.StrCmp(AV78Serasawwds_16_tfserasanumeroproposta_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta = ( :AV78Serasawwds_16_tfserasanumeroproposta_sel))");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( StringUtil.StrCmp(AV78Serasawwds_16_tfserasanumeroproposta_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta IS NULL or (char_length(trim(trailing ' ' from T1.SerasaNumeroProposta))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV79Serasawwds_17_tfserasapolitica) )
         {
            AddWhere(sWhereString, "(T1.SerasaPolitica >= :AV79Serasawwds_17_tfserasapolitica)");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV80Serasawwds_18_tfserasapolitica_to) )
         {
            AddWhere(sWhereString, "(T1.SerasaPolitica <= :AV80Serasawwds_18_tfserasapolitica_to)");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV81Serasawwds_19_tfserasacreatedat) )
         {
            AddWhere(sWhereString, "(T1.SerasaCreatedAt >= :AV81Serasawwds_19_tfserasacreatedat)");
         }
         else
         {
            GXv_int6[16] = 1;
         }
         if ( ! (DateTime.MinValue==AV82Serasawwds_20_tfserasacreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.SerasaCreatedAt <= :AV82Serasawwds_20_tfserasacreatedat_to)");
         }
         else
         {
            GXv_int6[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Serasawwds_22_tfserasatipovenda_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Serasawwds_21_tfserasatipovenda)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaTipoVenda like :lV83Serasawwds_21_tfserasatipovenda)");
         }
         else
         {
            GXv_int6[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Serasawwds_22_tfserasatipovenda_sel)) && ! ( StringUtil.StrCmp(AV84Serasawwds_22_tfserasatipovenda_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SerasaTipoVenda = ( :AV84Serasawwds_22_tfserasatipovenda_sel))");
         }
         else
         {
            GXv_int6[19] = 1;
         }
         if ( StringUtil.StrCmp(AV84Serasawwds_22_tfserasatipovenda_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SerasaTipoVenda IS NULL or (char_length(trim(trailing ' ' from T1.SerasaTipoVenda))=0))");
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.SerasaNumeroProposta, T1.SerasaId";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.SerasaNumeroProposta DESC, T1.SerasaId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T2.ClienteRazaoSocial, T1.SerasaId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.ClienteRazaoSocial DESC, T1.SerasaId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.SerasaPolitica, T1.SerasaId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.SerasaPolitica DESC, T1.SerasaId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.SerasaCreatedAt, T1.SerasaId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.SerasaCreatedAt DESC, T1.SerasaId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.SerasaTipoVenda, T1.SerasaId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.SerasaTipoVenda DESC, T1.SerasaId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.SerasaId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_H007W3( IGxContext context ,
                                             int A168ClienteId ,
                                             GxSimpleCollection<int> AV55Array_ClienteId ,
                                             string AV63Serasawwds_1_filterfulltext ,
                                             string AV64Serasawwds_2_dynamicfiltersselector1 ,
                                             short AV65Serasawwds_3_dynamicfiltersoperator1 ,
                                             string AV66Serasawwds_4_serasanumeroproposta1 ,
                                             bool AV67Serasawwds_5_dynamicfiltersenabled2 ,
                                             string AV68Serasawwds_6_dynamicfiltersselector2 ,
                                             short AV69Serasawwds_7_dynamicfiltersoperator2 ,
                                             string AV70Serasawwds_8_serasanumeroproposta2 ,
                                             bool AV71Serasawwds_9_dynamicfiltersenabled3 ,
                                             string AV72Serasawwds_10_dynamicfiltersselector3 ,
                                             short AV73Serasawwds_11_dynamicfiltersoperator3 ,
                                             string AV74Serasawwds_12_serasanumeroproposta3 ,
                                             string AV76Serasawwds_14_tfclienterazaosocial_sel ,
                                             string AV75Serasawwds_13_tfclienterazaosocial ,
                                             string AV78Serasawwds_16_tfserasanumeroproposta_sel ,
                                             string AV77Serasawwds_15_tfserasanumeroproposta ,
                                             decimal AV79Serasawwds_17_tfserasapolitica ,
                                             decimal AV80Serasawwds_18_tfserasapolitica_to ,
                                             DateTime AV81Serasawwds_19_tfserasacreatedat ,
                                             DateTime AV82Serasawwds_20_tfserasacreatedat_to ,
                                             string AV84Serasawwds_22_tfserasatipovenda_sel ,
                                             string AV83Serasawwds_21_tfserasatipovenda ,
                                             string A170ClienteRazaoSocial ,
                                             string A663SerasaNumeroProposta ,
                                             decimal A664SerasaPolitica ,
                                             string A666SerasaTipoVenda ,
                                             DateTime A665SerasaCreatedAt ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[20];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (Serasa T1 LEFT JOIN Cliente T2 ON T2.ClienteId = T1.ClienteId)";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV55Array_ClienteId, "T1.ClienteId IN (", ")")+")");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Serasawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.ClienteRazaoSocial like '%' || :lV63Serasawwds_1_filterfulltext) or ( T1.SerasaNumeroProposta like '%' || :lV63Serasawwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.SerasaPolitica,'999999999990.99'), 2) like '%' || :lV63Serasawwds_1_filterfulltext) or ( T1.SerasaTipoVenda like '%' || :lV63Serasawwds_1_filterfulltext))");
         }
         else
         {
            GXv_int8[0] = 1;
            GXv_int8[1] = 1;
            GXv_int8[2] = 1;
            GXv_int8[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV64Serasawwds_2_dynamicfiltersselector1, "SERASANUMEROPROPOSTA") == 0 ) && ( AV65Serasawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Serasawwds_4_serasanumeroproposta1)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta like :lV66Serasawwds_4_serasanumeroproposta1)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV64Serasawwds_2_dynamicfiltersselector1, "SERASANUMEROPROPOSTA") == 0 ) && ( AV65Serasawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Serasawwds_4_serasanumeroproposta1)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta like '%' || :lV66Serasawwds_4_serasanumeroproposta1)");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( AV67Serasawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Serasawwds_6_dynamicfiltersselector2, "SERASANUMEROPROPOSTA") == 0 ) && ( AV69Serasawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Serasawwds_8_serasanumeroproposta2)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta like :lV70Serasawwds_8_serasanumeroproposta2)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( AV67Serasawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Serasawwds_6_dynamicfiltersselector2, "SERASANUMEROPROPOSTA") == 0 ) && ( AV69Serasawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Serasawwds_8_serasanumeroproposta2)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta like '%' || :lV70Serasawwds_8_serasanumeroproposta2)");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( AV71Serasawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Serasawwds_10_dynamicfiltersselector3, "SERASANUMEROPROPOSTA") == 0 ) && ( AV73Serasawwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Serasawwds_12_serasanumeroproposta3)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta like :lV74Serasawwds_12_serasanumeroproposta3)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( AV71Serasawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Serasawwds_10_dynamicfiltersselector3, "SERASANUMEROPROPOSTA") == 0 ) && ( AV73Serasawwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Serasawwds_12_serasanumeroproposta3)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta like '%' || :lV74Serasawwds_12_serasanumeroproposta3)");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Serasawwds_14_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Serasawwds_13_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial like :lV75Serasawwds_13_tfclienterazaosocial)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Serasawwds_14_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV76Serasawwds_14_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial = ( :AV76Serasawwds_14_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( StringUtil.StrCmp(AV76Serasawwds_14_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T2.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Serasawwds_16_tfserasanumeroproposta_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Serasawwds_15_tfserasanumeroproposta)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta like :lV77Serasawwds_15_tfserasanumeroproposta)");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Serasawwds_16_tfserasanumeroproposta_sel)) && ! ( StringUtil.StrCmp(AV78Serasawwds_16_tfserasanumeroproposta_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta = ( :AV78Serasawwds_16_tfserasanumeroproposta_sel))");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( StringUtil.StrCmp(AV78Serasawwds_16_tfserasanumeroproposta_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta IS NULL or (char_length(trim(trailing ' ' from T1.SerasaNumeroProposta))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV79Serasawwds_17_tfserasapolitica) )
         {
            AddWhere(sWhereString, "(T1.SerasaPolitica >= :AV79Serasawwds_17_tfserasapolitica)");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV80Serasawwds_18_tfserasapolitica_to) )
         {
            AddWhere(sWhereString, "(T1.SerasaPolitica <= :AV80Serasawwds_18_tfserasapolitica_to)");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV81Serasawwds_19_tfserasacreatedat) )
         {
            AddWhere(sWhereString, "(T1.SerasaCreatedAt >= :AV81Serasawwds_19_tfserasacreatedat)");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         if ( ! (DateTime.MinValue==AV82Serasawwds_20_tfserasacreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.SerasaCreatedAt <= :AV82Serasawwds_20_tfserasacreatedat_to)");
         }
         else
         {
            GXv_int8[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Serasawwds_22_tfserasatipovenda_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Serasawwds_21_tfserasatipovenda)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaTipoVenda like :lV83Serasawwds_21_tfserasatipovenda)");
         }
         else
         {
            GXv_int8[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Serasawwds_22_tfserasatipovenda_sel)) && ! ( StringUtil.StrCmp(AV84Serasawwds_22_tfserasatipovenda_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SerasaTipoVenda = ( :AV84Serasawwds_22_tfserasatipovenda_sel))");
         }
         else
         {
            GXv_int8[19] = 1;
         }
         if ( StringUtil.StrCmp(AV84Serasawwds_22_tfserasatipovenda_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SerasaTipoVenda IS NULL or (char_length(trim(trailing ' ' from T1.SerasaTipoVenda))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H007W2(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (decimal)dynConstraints[18] , (decimal)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (decimal)dynConstraints[26] , (string)dynConstraints[27] , (DateTime)dynConstraints[28] , (short)dynConstraints[29] , (bool)dynConstraints[30] );
               case 1 :
                     return conditional_H007W3(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (decimal)dynConstraints[18] , (decimal)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (decimal)dynConstraints[26] , (string)dynConstraints[27] , (DateTime)dynConstraints[28] , (short)dynConstraints[29] , (bool)dynConstraints[30] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmH007W4;
          prmH007W4 = new Object[] {
          new ParDef("AV56PropostaId",GXType.Int32,9,0)
          };
          Object[] prmH007W2;
          prmH007W2 = new Object[] {
          new ParDef("lV63Serasawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Serasawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Serasawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Serasawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Serasawwds_4_serasanumeroproposta1",GXType.VarChar,40,0) ,
          new ParDef("lV66Serasawwds_4_serasanumeroproposta1",GXType.VarChar,40,0) ,
          new ParDef("lV70Serasawwds_8_serasanumeroproposta2",GXType.VarChar,40,0) ,
          new ParDef("lV70Serasawwds_8_serasanumeroproposta2",GXType.VarChar,40,0) ,
          new ParDef("lV74Serasawwds_12_serasanumeroproposta3",GXType.VarChar,40,0) ,
          new ParDef("lV74Serasawwds_12_serasanumeroproposta3",GXType.VarChar,40,0) ,
          new ParDef("lV75Serasawwds_13_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV76Serasawwds_14_tfclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV77Serasawwds_15_tfserasanumeroproposta",GXType.VarChar,40,0) ,
          new ParDef("AV78Serasawwds_16_tfserasanumeroproposta_sel",GXType.VarChar,40,0) ,
          new ParDef("AV79Serasawwds_17_tfserasapolitica",GXType.Number,15,2) ,
          new ParDef("AV80Serasawwds_18_tfserasapolitica_to",GXType.Number,15,2) ,
          new ParDef("AV81Serasawwds_19_tfserasacreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV82Serasawwds_20_tfserasacreatedat_to",GXType.DateTime,8,5) ,
          new ParDef("lV83Serasawwds_21_tfserasatipovenda",GXType.VarChar,40,0) ,
          new ParDef("AV84Serasawwds_22_tfserasatipovenda_sel",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH007W3;
          prmH007W3 = new Object[] {
          new ParDef("lV63Serasawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Serasawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Serasawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Serasawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Serasawwds_4_serasanumeroproposta1",GXType.VarChar,40,0) ,
          new ParDef("lV66Serasawwds_4_serasanumeroproposta1",GXType.VarChar,40,0) ,
          new ParDef("lV70Serasawwds_8_serasanumeroproposta2",GXType.VarChar,40,0) ,
          new ParDef("lV70Serasawwds_8_serasanumeroproposta2",GXType.VarChar,40,0) ,
          new ParDef("lV74Serasawwds_12_serasanumeroproposta3",GXType.VarChar,40,0) ,
          new ParDef("lV74Serasawwds_12_serasanumeroproposta3",GXType.VarChar,40,0) ,
          new ParDef("lV75Serasawwds_13_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV76Serasawwds_14_tfclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV77Serasawwds_15_tfserasanumeroproposta",GXType.VarChar,40,0) ,
          new ParDef("AV78Serasawwds_16_tfserasanumeroproposta_sel",GXType.VarChar,40,0) ,
          new ParDef("AV79Serasawwds_17_tfserasapolitica",GXType.Number,15,2) ,
          new ParDef("AV80Serasawwds_18_tfserasapolitica_to",GXType.Number,15,2) ,
          new ParDef("AV81Serasawwds_19_tfserasacreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV82Serasawwds_20_tfserasacreatedat_to",GXType.DateTime,8,5) ,
          new ParDef("lV83Serasawwds_21_tfserasatipovenda",GXType.VarChar,40,0) ,
          new ParDef("AV84Serasawwds_22_tfserasatipovenda_sel",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("H007W2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007W2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H007W3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007W3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H007W4", "SELECT PropostaId, PropostaResponsavelId FROM Proposta WHERE PropostaId = :AV56PropostaId ORDER BY PropostaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007W4,1, GxCacheFrequency.OFF ,false,true )
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
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

 }

}
