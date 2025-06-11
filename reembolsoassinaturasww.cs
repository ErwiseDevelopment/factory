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
   public class reembolsoassinaturasww : GXWebComponent
   {
      public reembolsoassinaturasww( )
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

      public reembolsoassinaturasww( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_PropostaId ,
                           int aP1_ReembolsoId )
      {
         this.AV44PropostaId = aP0_PropostaId;
         this.AV45ReembolsoId = aP1_ReembolsoId;
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
         cmbPropostaAssinaturaStatus = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
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
                  AV44PropostaId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV44PropostaId", StringUtil.LTrimStr( (decimal)(AV44PropostaId), 9, 0));
                  AV45ReembolsoId = (int)(Math.Round(NumberUtil.Val( GetPar( "ReembolsoId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV45ReembolsoId", StringUtil.LTrimStr( (decimal)(AV45ReembolsoId), 9, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(int)AV44PropostaId,(int)AV45ReembolsoId});
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
         nRC_GXsfl_104 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_104"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_104_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_104_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_104_idx = GetPar( "sGXsfl_104_idx");
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
         AV18ReembolsoAssinaturasNome1 = GetPar( "ReembolsoAssinaturasNome1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV20DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV21DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV22ReembolsoAssinaturasNome2 = GetPar( "ReembolsoAssinaturasNome2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV24DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV25DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV26ReembolsoAssinaturasNome3 = GetPar( "ReembolsoAssinaturasNome3");
         AV34ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV45ReembolsoId = (int)(Math.Round(NumberUtil.Val( GetPar( "ReembolsoId"), "."), 18, MidpointRounding.ToEven));
         AV19DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV23DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV35TFReembolsoAssinaturasNome = GetPar( "TFReembolsoAssinaturasNome");
         AV36TFReembolsoAssinaturasNome_Sel = GetPar( "TFReembolsoAssinaturasNome_Sel");
         AV37TFReembolsoAssinaturasEmissao = context.localUtil.ParseDTimeParm( GetPar( "TFReembolsoAssinaturasEmissao"));
         AV38TFReembolsoAssinaturasEmissao_To = context.localUtil.ParseDTimeParm( GetPar( "TFReembolsoAssinaturasEmissao_To"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV47TFPropostaAssinaturaStatus_Sels);
         AV67Pgmname = GetPar( "Pgmname");
         AV44PropostaId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaId"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridState);
         AV28DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV27DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ReembolsoAssinaturasNome1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22ReembolsoAssinaturasNome2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26ReembolsoAssinaturasNome3, AV34ManageFiltersExecutionStep, AV45ReembolsoId, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV35TFReembolsoAssinaturasNome, AV36TFReembolsoAssinaturasNome_Sel, AV37TFReembolsoAssinaturasEmissao, AV38TFReembolsoAssinaturasEmissao_To, AV47TFPropostaAssinaturaStatus_Sels, AV67Pgmname, AV44PropostaId, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, sPrefix) ;
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
            PA7T2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV67Pgmname = "ReembolsoAssinaturasWW";
               edtavDisplay_Enabled = 0;
               AssignProp(sPrefix, false, edtavDisplay_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDisplay_Enabled), 5, 0), !bGXsfl_104_Refreshing);
               WS7T2( ) ;
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
            context.SendWebValue( " Reembolso Assinaturas") ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
            GXEncryptionTmp = "reembolsoassinaturasww"+UrlEncode(StringUtil.LTrimStr(AV44PropostaId,9,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV45ReembolsoId,9,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("reembolsoassinaturasww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV67Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV67Pgmname, "")), context));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vREEMBOLSOASSINATURASNOME1", AV18ReembolsoAssinaturasNome1);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSSELECTOR2", AV20DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vREEMBOLSOASSINATURASNOME2", AV22ReembolsoAssinaturasNome2);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSSELECTOR3", AV24DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vREEMBOLSOASSINATURASNOME3", AV26ReembolsoAssinaturasNome3);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_104", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_104), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vMANAGEFILTERSDATA", AV32ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vMANAGEFILTERSDATA", AV32ManageFiltersData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV42DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV42DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_REEMBOLSOASSINATURASEMISSAOAUXDATE", context.localUtil.DToC( AV39DDO_ReembolsoAssinaturasEmissaoAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_REEMBOLSOASSINATURASEMISSAOAUXDATETO", context.localUtil.DToC( AV40DDO_ReembolsoAssinaturasEmissaoAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV44PropostaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV44PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV45ReembolsoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV45ReembolsoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vREEMBOLSOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV45ReembolsoId), 9, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSENABLED2", AV19DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSENABLED3", AV23DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFREEMBOLSOASSINATURASNOME", AV35TFReembolsoAssinaturasNome);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFREEMBOLSOASSINATURASNOME_SEL", AV36TFReembolsoAssinaturasNome_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFREEMBOLSOASSINATURASEMISSAO", context.localUtil.TToC( AV37TFReembolsoAssinaturasEmissao, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFREEMBOLSOASSINATURASEMISSAO_TO", context.localUtil.TToC( AV38TFReembolsoAssinaturasEmissao_To, 10, 8, 0, 0, "/", ":", " "));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTFPROPOSTAASSINATURASTATUS_SELS", AV47TFPropostaAssinaturaStatus_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTFPROPOSTAASSINATURASTATUS_SELS", AV47TFPropostaAssinaturaStatus_Sels);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV67Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV67Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vORDEREDDSC", AV14OrderedDsc);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44PropostaId), 9, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROPOSTAASSINATURASTATUS_SELSJSON", AV46TFPropostaAssinaturaStatus_SelsJson);
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
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Allowmultipleselection", StringUtil.RTrim( Ddo_grid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalistfixedvalues", StringUtil.RTrim( Ddo_grid_Datalistfixedvalues));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm7T2( )
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
         return "ReembolsoAssinaturasWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Reembolso Assinaturas" ;
      }

      protected void WB7T0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "reembolsoassinaturasww");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
            ClassString = "Button ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(104), 3, 0)+","+"null"+");", "Inserir", bttBtninsert_Jsonclick, 5, "Inserir", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ReembolsoAssinaturasWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonExcel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(104), 3, 0)+","+"null"+");", "Excel", bttBtnexport_Jsonclick, 5, "Exportar para Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ReembolsoAssinaturasWW.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'" + sGXsfl_104_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_ReembolsoAssinaturasWW.htm");
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_ReembolsoAssinaturasWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'" + sPrefix + "',false,'" + sGXsfl_104_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV16DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "", true, 0, "HLP_ReembolsoAssinaturasWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_ReembolsoAssinaturasWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_45_7T2( true) ;
         }
         else
         {
            wb_table1_45_7T2( false) ;
         }
         return  ;
      }

      protected void wb_table1_45_7T2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_ReembolsoAssinaturasWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'" + sPrefix + "',false,'" + sGXsfl_104_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV20DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "", true, 0, "HLP_ReembolsoAssinaturasWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_ReembolsoAssinaturasWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_67_7T2( true) ;
         }
         else
         {
            wb_table2_67_7T2( false) ;
         }
         return  ;
      }

      protected void wb_table2_67_7T2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_ReembolsoAssinaturasWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'" + sPrefix + "',false,'" + sGXsfl_104_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV24DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,85);\"", "", true, 0, "HLP_ReembolsoAssinaturasWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_ReembolsoAssinaturasWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_89_7T2( true) ;
         }
         else
         {
            wb_table3_89_7T2( false) ;
         }
         return  ;
      }

      protected void wb_table3_89_7T2e( bool wbgen )
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
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl104( ) ;
         }
         if ( wbEnd == 104 )
         {
            wbEnd = 0;
            nRC_GXsfl_104 = (int)(nGXsfl_104_idx-1);
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
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_ReembolsoAssinaturasWW.htm");
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
            ucDdo_grid.SetProperty("AllowMultipleSelection", Ddo_grid_Allowmultipleselection);
            ucDdo_grid.SetProperty("DataListFixedValues", Ddo_grid_Datalistfixedvalues);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV42DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, sPrefix+"DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, sPrefix+"GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_reembolsoassinaturasemissaoauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'" + sPrefix + "',false,'" + sGXsfl_104_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_reembolsoassinaturasemissaoauxdatetext_Internalname, AV41DDO_ReembolsoAssinaturasEmissaoAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV41DDO_ReembolsoAssinaturasEmissaoAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,120);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_reembolsoassinaturasemissaoauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ReembolsoAssinaturasWW.htm");
            /* User Defined Control */
            ucTfreembolsoassinaturasemissao_rangepicker.SetProperty("Start Date", AV39DDO_ReembolsoAssinaturasEmissaoAuxDate);
            ucTfreembolsoassinaturasemissao_rangepicker.SetProperty("End Date", AV40DDO_ReembolsoAssinaturasEmissaoAuxDateTo);
            ucTfreembolsoassinaturasemissao_rangepicker.Render(context, "wwp.daterangepicker", Tfreembolsoassinaturasemissao_rangepicker_Internalname, sPrefix+"TFREEMBOLSOASSINATURASEMISSAO_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 104 )
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

      protected void START7T2( )
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
            Form.Meta.addItem("description", " Reembolso Assinaturas", 0) ;
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
               STRUP7T0( ) ;
            }
         }
      }

      protected void WS7T2( )
      {
         START7T2( ) ;
         EVT7T2( ) ;
      }

      protected void EVT7T2( )
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
                                 STRUP7T0( ) ;
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
                                 STRUP7T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_managefilters.Onoptionclicked */
                                    E117T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_grid.Onoptionclicked */
                                    E127T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'RemoveDynamicFilters1' */
                                    E137T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'RemoveDynamicFilters2' */
                                    E147T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'RemoveDynamicFilters3' */
                                    E157T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoInsert' */
                                    E167T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoExport' */
                                    E177T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'AddDynamicFilters1' */
                                    E187T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E197T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'AddDynamicFilters2' */
                                    E207T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E217T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E227T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7T0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7T0( ) ;
                              }
                              AV49Reembolsoassinaturaswwds_1_reembolsoid = AV45ReembolsoId;
                              AV50Reembolsoassinaturaswwds_2_filterfulltext = AV15FilterFullText;
                              AV51Reembolsoassinaturaswwds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
                              AV52Reembolsoassinaturaswwds_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
                              AV53Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1 = AV18ReembolsoAssinaturasNome1;
                              AV54Reembolsoassinaturaswwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
                              AV55Reembolsoassinaturaswwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
                              AV56Reembolsoassinaturaswwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
                              AV57Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2 = AV22ReembolsoAssinaturasNome2;
                              AV58Reembolsoassinaturaswwds_10_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
                              AV59Reembolsoassinaturaswwds_11_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
                              AV60Reembolsoassinaturaswwds_12_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
                              AV61Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3 = AV26ReembolsoAssinaturasNome3;
                              AV62Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome = AV35TFReembolsoAssinaturasNome;
                              AV63Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel = AV36TFReembolsoAssinaturasNome_Sel;
                              AV64Reembolsoassinaturaswwds_16_tfreembolsoassinaturasemissao = AV37TFReembolsoAssinaturasEmissao;
                              AV65Reembolsoassinaturaswwds_17_tfreembolsoassinaturasemissao_to = AV38TFReembolsoAssinaturasEmissao_To;
                              AV66Reembolsoassinaturaswwds_18_tfpropostaassinaturastatus_sels = AV47TFPropostaAssinaturaStatus_Sels;
                              sEvt = cgiGet( sPrefix+"GRIDPAGING");
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7T0( ) ;
                              }
                              nGXsfl_104_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_104_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_104_idx), 4, 0), 4, "0");
                              SubsflControlProps_1042( ) ;
                              AV43Display = cgiGet( edtavDisplay_Internalname);
                              AssignAttri(sPrefix, false, edtavDisplay_Internalname, AV43Display);
                              A631ReembolsoAssinaturasId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtReembolsoAssinaturasId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A518ReembolsoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtReembolsoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n518ReembolsoId = false;
                              A572PropostaContratoAssinaturaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaContratoAssinaturaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n572PropostaContratoAssinaturaId = false;
                              A571PropostaAssinatura = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaAssinatura_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n571PropostaAssinatura = false;
                              A632ReembolsoAssinaturasNome = cgiGet( edtReembolsoAssinaturasNome_Internalname);
                              n632ReembolsoAssinaturasNome = false;
                              A633ReembolsoAssinaturasEmissao = context.localUtil.CToT( cgiGet( edtReembolsoAssinaturasEmissao_Internalname), 0);
                              n633ReembolsoAssinaturasEmissao = false;
                              cmbPropostaAssinaturaStatus.Name = cmbPropostaAssinaturaStatus_Internalname;
                              cmbPropostaAssinaturaStatus.CurrentValue = cgiGet( cmbPropostaAssinaturaStatus_Internalname);
                              A574PropostaAssinaturaStatus = cgiGet( cmbPropostaAssinaturaStatus_Internalname);
                              n574PropostaAssinaturaStatus = false;
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
                                          E237T2 ();
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
                                          E247T2 ();
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
                                          E257T2 ();
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
                                             /* Set Refresh If Reembolsoassinaturasnome1 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vREEMBOLSOASSINATURASNOME1"), AV18ReembolsoAssinaturasNome1) != 0 )
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
                                             /* Set Refresh If Reembolsoassinaturasnome2 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vREEMBOLSOASSINATURASNOME2"), AV22ReembolsoAssinaturasNome2) != 0 )
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
                                             /* Set Refresh If Reembolsoassinaturasnome3 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vREEMBOLSOASSINATURASNOME3"), AV26ReembolsoAssinaturasNome3) != 0 )
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
                                       STRUP7T0( ) ;
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

      protected void WE7T2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm7T2( ) ;
            }
         }
      }

      protected void PA7T2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "reembolsoassinaturasww")), "reembolsoassinaturasww") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "reembolsoassinaturasww")))) ;
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
                     gxfirstwebparm = GetFirstPar( "PropostaId");
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
         SubsflControlProps_1042( ) ;
         while ( nGXsfl_104_idx <= nRC_GXsfl_104 )
         {
            sendrow_1042( ) ;
            nGXsfl_104_idx = ((subGrid_Islastpage==1)&&(nGXsfl_104_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_104_idx+1);
            sGXsfl_104_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_104_idx), 4, 0), 4, "0");
            SubsflControlProps_1042( ) ;
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
                                       string AV18ReembolsoAssinaturasNome1 ,
                                       string AV20DynamicFiltersSelector2 ,
                                       short AV21DynamicFiltersOperator2 ,
                                       string AV22ReembolsoAssinaturasNome2 ,
                                       string AV24DynamicFiltersSelector3 ,
                                       short AV25DynamicFiltersOperator3 ,
                                       string AV26ReembolsoAssinaturasNome3 ,
                                       short AV34ManageFiltersExecutionStep ,
                                       int AV45ReembolsoId ,
                                       bool AV19DynamicFiltersEnabled2 ,
                                       bool AV23DynamicFiltersEnabled3 ,
                                       string AV35TFReembolsoAssinaturasNome ,
                                       string AV36TFReembolsoAssinaturasNome_Sel ,
                                       DateTime AV37TFReembolsoAssinaturasEmissao ,
                                       DateTime AV38TFReembolsoAssinaturasEmissao_To ,
                                       GxSimpleCollection<string> AV47TFPropostaAssinaturaStatus_Sels ,
                                       string AV67Pgmname ,
                                       int AV44PropostaId ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV28DynamicFiltersIgnoreFirst ,
                                       bool AV27DynamicFiltersRemoving ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF7T2( ) ;
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
         RF7T2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV67Pgmname = "ReembolsoAssinaturasWW";
         edtavDisplay_Enabled = 0;
      }

      protected void RF7T2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 104;
         /* Execute user event: Refresh */
         E247T2 ();
         nGXsfl_104_idx = 1;
         sGXsfl_104_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_104_idx), 4, 0), 4, "0");
         SubsflControlProps_1042( ) ;
         bGXsfl_104_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", sPrefix);
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithBorderColor WorkWith");
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
            SubsflControlProps_1042( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A574PropostaAssinaturaStatus ,
                                                 AV66Reembolsoassinaturaswwds_18_tfpropostaassinaturastatus_sels ,
                                                 AV50Reembolsoassinaturaswwds_2_filterfulltext ,
                                                 AV51Reembolsoassinaturaswwds_3_dynamicfiltersselector1 ,
                                                 AV52Reembolsoassinaturaswwds_4_dynamicfiltersoperator1 ,
                                                 AV53Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1 ,
                                                 AV54Reembolsoassinaturaswwds_6_dynamicfiltersenabled2 ,
                                                 AV55Reembolsoassinaturaswwds_7_dynamicfiltersselector2 ,
                                                 AV56Reembolsoassinaturaswwds_8_dynamicfiltersoperator2 ,
                                                 AV57Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2 ,
                                                 AV58Reembolsoassinaturaswwds_10_dynamicfiltersenabled3 ,
                                                 AV59Reembolsoassinaturaswwds_11_dynamicfiltersselector3 ,
                                                 AV60Reembolsoassinaturaswwds_12_dynamicfiltersoperator3 ,
                                                 AV61Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3 ,
                                                 AV63Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel ,
                                                 AV62Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome ,
                                                 AV64Reembolsoassinaturaswwds_16_tfreembolsoassinaturasemissao ,
                                                 AV65Reembolsoassinaturaswwds_17_tfreembolsoassinaturasemissao_to ,
                                                 AV66Reembolsoassinaturaswwds_18_tfpropostaassinaturastatus_sels.Count ,
                                                 A632ReembolsoAssinaturasNome ,
                                                 A633ReembolsoAssinaturasEmissao ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc ,
                                                 A518ReembolsoId ,
                                                 AV49Reembolsoassinaturaswwds_1_reembolsoid } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.BOOLEAN,
                                                 TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                                 }
            });
            lV50Reembolsoassinaturaswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Reembolsoassinaturaswwds_2_filterfulltext), "%", "");
            lV50Reembolsoassinaturaswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Reembolsoassinaturaswwds_2_filterfulltext), "%", "");
            lV50Reembolsoassinaturaswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Reembolsoassinaturaswwds_2_filterfulltext), "%", "");
            lV50Reembolsoassinaturaswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Reembolsoassinaturaswwds_2_filterfulltext), "%", "");
            lV50Reembolsoassinaturaswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Reembolsoassinaturaswwds_2_filterfulltext), "%", "");
            lV50Reembolsoassinaturaswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Reembolsoassinaturaswwds_2_filterfulltext), "%", "");
            lV53Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1 = StringUtil.Concat( StringUtil.RTrim( AV53Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1), "%", "");
            lV53Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1 = StringUtil.Concat( StringUtil.RTrim( AV53Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1), "%", "");
            lV57Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2 = StringUtil.Concat( StringUtil.RTrim( AV57Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2), "%", "");
            lV57Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2 = StringUtil.Concat( StringUtil.RTrim( AV57Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2), "%", "");
            lV61Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3 = StringUtil.Concat( StringUtil.RTrim( AV61Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3), "%", "");
            lV61Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3 = StringUtil.Concat( StringUtil.RTrim( AV61Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3), "%", "");
            lV62Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome = StringUtil.Concat( StringUtil.RTrim( AV62Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome), "%", "");
            /* Using cursor H007T2 */
            pr_default.execute(0, new Object[] {AV49Reembolsoassinaturaswwds_1_reembolsoid, lV50Reembolsoassinaturaswwds_2_filterfulltext, lV50Reembolsoassinaturaswwds_2_filterfulltext, lV50Reembolsoassinaturaswwds_2_filterfulltext, lV50Reembolsoassinaturaswwds_2_filterfulltext, lV50Reembolsoassinaturaswwds_2_filterfulltext, lV50Reembolsoassinaturaswwds_2_filterfulltext, lV53Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1, lV53Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1, lV57Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2, lV57Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2, lV61Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3, lV61Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3, lV62Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome, AV63Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel, AV64Reembolsoassinaturaswwds_16_tfreembolsoassinaturasemissao, AV65Reembolsoassinaturaswwds_17_tfreembolsoassinaturasemissao_to, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_104_idx = 1;
            sGXsfl_104_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_104_idx), 4, 0), 4, "0");
            SubsflControlProps_1042( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A574PropostaAssinaturaStatus = H007T2_A574PropostaAssinaturaStatus[0];
               n574PropostaAssinaturaStatus = H007T2_n574PropostaAssinaturaStatus[0];
               A633ReembolsoAssinaturasEmissao = H007T2_A633ReembolsoAssinaturasEmissao[0];
               n633ReembolsoAssinaturasEmissao = H007T2_n633ReembolsoAssinaturasEmissao[0];
               A632ReembolsoAssinaturasNome = H007T2_A632ReembolsoAssinaturasNome[0];
               n632ReembolsoAssinaturasNome = H007T2_n632ReembolsoAssinaturasNome[0];
               A571PropostaAssinatura = H007T2_A571PropostaAssinatura[0];
               n571PropostaAssinatura = H007T2_n571PropostaAssinatura[0];
               A572PropostaContratoAssinaturaId = H007T2_A572PropostaContratoAssinaturaId[0];
               n572PropostaContratoAssinaturaId = H007T2_n572PropostaContratoAssinaturaId[0];
               A518ReembolsoId = H007T2_A518ReembolsoId[0];
               n518ReembolsoId = H007T2_n518ReembolsoId[0];
               A631ReembolsoAssinaturasId = H007T2_A631ReembolsoAssinaturasId[0];
               A571PropostaAssinatura = H007T2_A571PropostaAssinatura[0];
               n571PropostaAssinatura = H007T2_n571PropostaAssinatura[0];
               A574PropostaAssinaturaStatus = H007T2_A574PropostaAssinaturaStatus[0];
               n574PropostaAssinaturaStatus = H007T2_n574PropostaAssinaturaStatus[0];
               /* Execute user event: Grid.Load */
               E257T2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 104;
            WB7T0( ) ;
         }
         bGXsfl_104_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes7T2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV67Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV67Pgmname, "")), context));
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
         AV49Reembolsoassinaturaswwds_1_reembolsoid = AV45ReembolsoId;
         AV50Reembolsoassinaturaswwds_2_filterfulltext = AV15FilterFullText;
         AV51Reembolsoassinaturaswwds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV52Reembolsoassinaturaswwds_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV53Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1 = AV18ReembolsoAssinaturasNome1;
         AV54Reembolsoassinaturaswwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV55Reembolsoassinaturaswwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV56Reembolsoassinaturaswwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV57Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2 = AV22ReembolsoAssinaturasNome2;
         AV58Reembolsoassinaturaswwds_10_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV59Reembolsoassinaturaswwds_11_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV60Reembolsoassinaturaswwds_12_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV61Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3 = AV26ReembolsoAssinaturasNome3;
         AV62Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome = AV35TFReembolsoAssinaturasNome;
         AV63Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel = AV36TFReembolsoAssinaturasNome_Sel;
         AV64Reembolsoassinaturaswwds_16_tfreembolsoassinaturasemissao = AV37TFReembolsoAssinaturasEmissao;
         AV65Reembolsoassinaturaswwds_17_tfreembolsoassinaturasemissao_to = AV38TFReembolsoAssinaturasEmissao_To;
         AV66Reembolsoassinaturaswwds_18_tfpropostaassinaturastatus_sels = AV47TFPropostaAssinaturaStatus_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A574PropostaAssinaturaStatus ,
                                              AV66Reembolsoassinaturaswwds_18_tfpropostaassinaturastatus_sels ,
                                              AV50Reembolsoassinaturaswwds_2_filterfulltext ,
                                              AV51Reembolsoassinaturaswwds_3_dynamicfiltersselector1 ,
                                              AV52Reembolsoassinaturaswwds_4_dynamicfiltersoperator1 ,
                                              AV53Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1 ,
                                              AV54Reembolsoassinaturaswwds_6_dynamicfiltersenabled2 ,
                                              AV55Reembolsoassinaturaswwds_7_dynamicfiltersselector2 ,
                                              AV56Reembolsoassinaturaswwds_8_dynamicfiltersoperator2 ,
                                              AV57Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2 ,
                                              AV58Reembolsoassinaturaswwds_10_dynamicfiltersenabled3 ,
                                              AV59Reembolsoassinaturaswwds_11_dynamicfiltersselector3 ,
                                              AV60Reembolsoassinaturaswwds_12_dynamicfiltersoperator3 ,
                                              AV61Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3 ,
                                              AV63Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel ,
                                              AV62Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome ,
                                              AV64Reembolsoassinaturaswwds_16_tfreembolsoassinaturasemissao ,
                                              AV65Reembolsoassinaturaswwds_17_tfreembolsoassinaturasemissao_to ,
                                              AV66Reembolsoassinaturaswwds_18_tfpropostaassinaturastatus_sels.Count ,
                                              A632ReembolsoAssinaturasNome ,
                                              A633ReembolsoAssinaturasEmissao ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc ,
                                              A518ReembolsoId ,
                                              AV49Reembolsoassinaturaswwds_1_reembolsoid } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV50Reembolsoassinaturaswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Reembolsoassinaturaswwds_2_filterfulltext), "%", "");
         lV50Reembolsoassinaturaswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Reembolsoassinaturaswwds_2_filterfulltext), "%", "");
         lV50Reembolsoassinaturaswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Reembolsoassinaturaswwds_2_filterfulltext), "%", "");
         lV50Reembolsoassinaturaswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Reembolsoassinaturaswwds_2_filterfulltext), "%", "");
         lV50Reembolsoassinaturaswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Reembolsoassinaturaswwds_2_filterfulltext), "%", "");
         lV50Reembolsoassinaturaswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Reembolsoassinaturaswwds_2_filterfulltext), "%", "");
         lV53Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1 = StringUtil.Concat( StringUtil.RTrim( AV53Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1), "%", "");
         lV53Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1 = StringUtil.Concat( StringUtil.RTrim( AV53Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1), "%", "");
         lV57Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2 = StringUtil.Concat( StringUtil.RTrim( AV57Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2), "%", "");
         lV57Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2 = StringUtil.Concat( StringUtil.RTrim( AV57Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2), "%", "");
         lV61Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3 = StringUtil.Concat( StringUtil.RTrim( AV61Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3), "%", "");
         lV61Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3 = StringUtil.Concat( StringUtil.RTrim( AV61Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3), "%", "");
         lV62Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome = StringUtil.Concat( StringUtil.RTrim( AV62Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome), "%", "");
         /* Using cursor H007T3 */
         pr_default.execute(1, new Object[] {AV49Reembolsoassinaturaswwds_1_reembolsoid, lV50Reembolsoassinaturaswwds_2_filterfulltext, lV50Reembolsoassinaturaswwds_2_filterfulltext, lV50Reembolsoassinaturaswwds_2_filterfulltext, lV50Reembolsoassinaturaswwds_2_filterfulltext, lV50Reembolsoassinaturaswwds_2_filterfulltext, lV50Reembolsoassinaturaswwds_2_filterfulltext, lV53Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1, lV53Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1, lV57Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2, lV57Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2, lV61Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3, lV61Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3, lV62Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome, AV63Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel, AV64Reembolsoassinaturaswwds_16_tfreembolsoassinaturasemissao, AV65Reembolsoassinaturaswwds_17_tfreembolsoassinaturasemissao_to});
         GRID_nRecordCount = H007T3_AGRID_nRecordCount[0];
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
         AV49Reembolsoassinaturaswwds_1_reembolsoid = AV45ReembolsoId;
         AV50Reembolsoassinaturaswwds_2_filterfulltext = AV15FilterFullText;
         AV51Reembolsoassinaturaswwds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV52Reembolsoassinaturaswwds_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV53Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1 = AV18ReembolsoAssinaturasNome1;
         AV54Reembolsoassinaturaswwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV55Reembolsoassinaturaswwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV56Reembolsoassinaturaswwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV57Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2 = AV22ReembolsoAssinaturasNome2;
         AV58Reembolsoassinaturaswwds_10_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV59Reembolsoassinaturaswwds_11_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV60Reembolsoassinaturaswwds_12_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV61Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3 = AV26ReembolsoAssinaturasNome3;
         AV62Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome = AV35TFReembolsoAssinaturasNome;
         AV63Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel = AV36TFReembolsoAssinaturasNome_Sel;
         AV64Reembolsoassinaturaswwds_16_tfreembolsoassinaturasemissao = AV37TFReembolsoAssinaturasEmissao;
         AV65Reembolsoassinaturaswwds_17_tfreembolsoassinaturasemissao_to = AV38TFReembolsoAssinaturasEmissao_To;
         AV66Reembolsoassinaturaswwds_18_tfpropostaassinaturastatus_sels = AV47TFPropostaAssinaturaStatus_Sels;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ReembolsoAssinaturasNome1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22ReembolsoAssinaturasNome2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26ReembolsoAssinaturasNome3, AV34ManageFiltersExecutionStep, AV45ReembolsoId, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV35TFReembolsoAssinaturasNome, AV36TFReembolsoAssinaturasNome_Sel, AV37TFReembolsoAssinaturasEmissao, AV38TFReembolsoAssinaturasEmissao_To, AV47TFPropostaAssinaturaStatus_Sels, AV67Pgmname, AV44PropostaId, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV49Reembolsoassinaturaswwds_1_reembolsoid = AV45ReembolsoId;
         AV50Reembolsoassinaturaswwds_2_filterfulltext = AV15FilterFullText;
         AV51Reembolsoassinaturaswwds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV52Reembolsoassinaturaswwds_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV53Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1 = AV18ReembolsoAssinaturasNome1;
         AV54Reembolsoassinaturaswwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV55Reembolsoassinaturaswwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV56Reembolsoassinaturaswwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV57Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2 = AV22ReembolsoAssinaturasNome2;
         AV58Reembolsoassinaturaswwds_10_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV59Reembolsoassinaturaswwds_11_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV60Reembolsoassinaturaswwds_12_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV61Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3 = AV26ReembolsoAssinaturasNome3;
         AV62Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome = AV35TFReembolsoAssinaturasNome;
         AV63Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel = AV36TFReembolsoAssinaturasNome_Sel;
         AV64Reembolsoassinaturaswwds_16_tfreembolsoassinaturasemissao = AV37TFReembolsoAssinaturasEmissao;
         AV65Reembolsoassinaturaswwds_17_tfreembolsoassinaturasemissao_to = AV38TFReembolsoAssinaturasEmissao_To;
         AV66Reembolsoassinaturaswwds_18_tfpropostaassinaturastatus_sels = AV47TFPropostaAssinaturaStatus_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ReembolsoAssinaturasNome1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22ReembolsoAssinaturasNome2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26ReembolsoAssinaturasNome3, AV34ManageFiltersExecutionStep, AV45ReembolsoId, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV35TFReembolsoAssinaturasNome, AV36TFReembolsoAssinaturasNome_Sel, AV37TFReembolsoAssinaturasEmissao, AV38TFReembolsoAssinaturasEmissao_To, AV47TFPropostaAssinaturaStatus_Sels, AV67Pgmname, AV44PropostaId, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV49Reembolsoassinaturaswwds_1_reembolsoid = AV45ReembolsoId;
         AV50Reembolsoassinaturaswwds_2_filterfulltext = AV15FilterFullText;
         AV51Reembolsoassinaturaswwds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV52Reembolsoassinaturaswwds_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV53Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1 = AV18ReembolsoAssinaturasNome1;
         AV54Reembolsoassinaturaswwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV55Reembolsoassinaturaswwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV56Reembolsoassinaturaswwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV57Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2 = AV22ReembolsoAssinaturasNome2;
         AV58Reembolsoassinaturaswwds_10_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV59Reembolsoassinaturaswwds_11_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV60Reembolsoassinaturaswwds_12_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV61Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3 = AV26ReembolsoAssinaturasNome3;
         AV62Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome = AV35TFReembolsoAssinaturasNome;
         AV63Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel = AV36TFReembolsoAssinaturasNome_Sel;
         AV64Reembolsoassinaturaswwds_16_tfreembolsoassinaturasemissao = AV37TFReembolsoAssinaturasEmissao;
         AV65Reembolsoassinaturaswwds_17_tfreembolsoassinaturasemissao_to = AV38TFReembolsoAssinaturasEmissao_To;
         AV66Reembolsoassinaturaswwds_18_tfpropostaassinaturastatus_sels = AV47TFPropostaAssinaturaStatus_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ReembolsoAssinaturasNome1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22ReembolsoAssinaturasNome2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26ReembolsoAssinaturasNome3, AV34ManageFiltersExecutionStep, AV45ReembolsoId, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV35TFReembolsoAssinaturasNome, AV36TFReembolsoAssinaturasNome_Sel, AV37TFReembolsoAssinaturasEmissao, AV38TFReembolsoAssinaturasEmissao_To, AV47TFPropostaAssinaturaStatus_Sels, AV67Pgmname, AV44PropostaId, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV49Reembolsoassinaturaswwds_1_reembolsoid = AV45ReembolsoId;
         AV50Reembolsoassinaturaswwds_2_filterfulltext = AV15FilterFullText;
         AV51Reembolsoassinaturaswwds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV52Reembolsoassinaturaswwds_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV53Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1 = AV18ReembolsoAssinaturasNome1;
         AV54Reembolsoassinaturaswwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV55Reembolsoassinaturaswwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV56Reembolsoassinaturaswwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV57Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2 = AV22ReembolsoAssinaturasNome2;
         AV58Reembolsoassinaturaswwds_10_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV59Reembolsoassinaturaswwds_11_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV60Reembolsoassinaturaswwds_12_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV61Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3 = AV26ReembolsoAssinaturasNome3;
         AV62Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome = AV35TFReembolsoAssinaturasNome;
         AV63Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel = AV36TFReembolsoAssinaturasNome_Sel;
         AV64Reembolsoassinaturaswwds_16_tfreembolsoassinaturasemissao = AV37TFReembolsoAssinaturasEmissao;
         AV65Reembolsoassinaturaswwds_17_tfreembolsoassinaturasemissao_to = AV38TFReembolsoAssinaturasEmissao_To;
         AV66Reembolsoassinaturaswwds_18_tfpropostaassinaturastatus_sels = AV47TFPropostaAssinaturaStatus_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ReembolsoAssinaturasNome1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22ReembolsoAssinaturasNome2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26ReembolsoAssinaturasNome3, AV34ManageFiltersExecutionStep, AV45ReembolsoId, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV35TFReembolsoAssinaturasNome, AV36TFReembolsoAssinaturasNome_Sel, AV37TFReembolsoAssinaturasEmissao, AV38TFReembolsoAssinaturasEmissao_To, AV47TFPropostaAssinaturaStatus_Sels, AV67Pgmname, AV44PropostaId, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV49Reembolsoassinaturaswwds_1_reembolsoid = AV45ReembolsoId;
         AV50Reembolsoassinaturaswwds_2_filterfulltext = AV15FilterFullText;
         AV51Reembolsoassinaturaswwds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV52Reembolsoassinaturaswwds_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV53Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1 = AV18ReembolsoAssinaturasNome1;
         AV54Reembolsoassinaturaswwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV55Reembolsoassinaturaswwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV56Reembolsoassinaturaswwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV57Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2 = AV22ReembolsoAssinaturasNome2;
         AV58Reembolsoassinaturaswwds_10_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV59Reembolsoassinaturaswwds_11_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV60Reembolsoassinaturaswwds_12_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV61Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3 = AV26ReembolsoAssinaturasNome3;
         AV62Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome = AV35TFReembolsoAssinaturasNome;
         AV63Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel = AV36TFReembolsoAssinaturasNome_Sel;
         AV64Reembolsoassinaturaswwds_16_tfreembolsoassinaturasemissao = AV37TFReembolsoAssinaturasEmissao;
         AV65Reembolsoassinaturaswwds_17_tfreembolsoassinaturasemissao_to = AV38TFReembolsoAssinaturasEmissao_To;
         AV66Reembolsoassinaturaswwds_18_tfpropostaassinaturastatus_sels = AV47TFPropostaAssinaturaStatus_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ReembolsoAssinaturasNome1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22ReembolsoAssinaturasNome2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26ReembolsoAssinaturasNome3, AV34ManageFiltersExecutionStep, AV45ReembolsoId, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV35TFReembolsoAssinaturasNome, AV36TFReembolsoAssinaturasNome_Sel, AV37TFReembolsoAssinaturasEmissao, AV38TFReembolsoAssinaturasEmissao_To, AV47TFPropostaAssinaturaStatus_Sels, AV67Pgmname, AV44PropostaId, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV67Pgmname = "ReembolsoAssinaturasWW";
         edtavDisplay_Enabled = 0;
         edtReembolsoAssinaturasId_Enabled = 0;
         edtReembolsoId_Enabled = 0;
         edtPropostaContratoAssinaturaId_Enabled = 0;
         edtPropostaAssinatura_Enabled = 0;
         edtReembolsoAssinaturasNome_Enabled = 0;
         edtReembolsoAssinaturasEmissao_Enabled = 0;
         cmbPropostaAssinaturaStatus.Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP7T0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E237T2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vMANAGEFILTERSDATA"), AV32ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV42DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_104 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_104"), ",", "."), 18, MidpointRounding.ToEven));
            AV39DDO_ReembolsoAssinaturasEmissaoAuxDate = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_REEMBOLSOASSINATURASEMISSAOAUXDATE"), 0);
            AssignAttri(sPrefix, false, "AV39DDO_ReembolsoAssinaturasEmissaoAuxDate", context.localUtil.Format(AV39DDO_ReembolsoAssinaturasEmissaoAuxDate, "99/99/99"));
            AV40DDO_ReembolsoAssinaturasEmissaoAuxDateTo = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_REEMBOLSOASSINATURASEMISSAOAUXDATETO"), 0);
            AssignAttri(sPrefix, false, "AV40DDO_ReembolsoAssinaturasEmissaoAuxDateTo", context.localUtil.Format(AV40DDO_ReembolsoAssinaturasEmissaoAuxDateTo, "99/99/99"));
            wcpOAV44PropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV44PropostaId"), ",", "."), 18, MidpointRounding.ToEven));
            wcpOAV45ReembolsoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV45ReembolsoId"), ",", "."), 18, MidpointRounding.ToEven));
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
            Ddo_grid_Allowmultipleselection = cgiGet( sPrefix+"DDO_GRID_Allowmultipleselection");
            Ddo_grid_Datalistfixedvalues = cgiGet( sPrefix+"DDO_GRID_Datalistfixedvalues");
            Ddo_grid_Datalistproc = cgiGet( sPrefix+"DDO_GRID_Datalistproc");
            Grid_empowerer_Gridinternalname = cgiGet( sPrefix+"GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( sPrefix+"GRID_EMPOWERER_Hastitlesettings"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_grid_Activeeventkey = cgiGet( sPrefix+"DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_get");
            Ddo_grid_Selectedcolumn = cgiGet( sPrefix+"DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( sPrefix+"DDO_GRID_Filteredtext_get");
            Ddo_grid_Filteredtextto_get = cgiGet( sPrefix+"DDO_GRID_Filteredtextto_get");
            Ddo_managefilters_Activeeventkey = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
            AV18ReembolsoAssinaturasNome1 = cgiGet( edtavReembolsoassinaturasnome1_Internalname);
            AssignAttri(sPrefix, false, "AV18ReembolsoAssinaturasNome1", AV18ReembolsoAssinaturasNome1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV20DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri(sPrefix, false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV21DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
            AV22ReembolsoAssinaturasNome2 = cgiGet( edtavReembolsoassinaturasnome2_Internalname);
            AssignAttri(sPrefix, false, "AV22ReembolsoAssinaturasNome2", AV22ReembolsoAssinaturasNome2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV24DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri(sPrefix, false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV25DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
            AV26ReembolsoAssinaturasNome3 = cgiGet( edtavReembolsoassinaturasnome3_Internalname);
            AssignAttri(sPrefix, false, "AV26ReembolsoAssinaturasNome3", AV26ReembolsoAssinaturasNome3);
            AV41DDO_ReembolsoAssinaturasEmissaoAuxDateText = cgiGet( edtavDdo_reembolsoassinaturasemissaoauxdatetext_Internalname);
            AssignAttri(sPrefix, false, "AV41DDO_ReembolsoAssinaturasEmissaoAuxDateText", AV41DDO_ReembolsoAssinaturasEmissaoAuxDateText);
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
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vREEMBOLSOASSINATURASNOME1"), AV18ReembolsoAssinaturasNome1) != 0 )
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
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vREEMBOLSOASSINATURASNOME2"), AV22ReembolsoAssinaturasNome2) != 0 )
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
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vREEMBOLSOASSINATURASNOME3"), AV26ReembolsoAssinaturasNome3) != 0 )
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
         E237T2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E237T2( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod(sPrefix, false, "TFREEMBOLSOASSINATURASEMISSAO_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_reembolsoassinaturasemissaoauxdatetext_Internalname});
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
         AV16DynamicFiltersSelector1 = "REEMBOLSOASSINATURASNOME";
         AssignAttri(sPrefix, false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV20DynamicFiltersSelector2 = "REEMBOLSOASSINATURASNOME";
         AssignAttri(sPrefix, false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV24DynamicFiltersSelector3 = "REEMBOLSOASSINATURASNOME";
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV42DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV42DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
      }

      protected void E247T2( )
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
         cmbPropostaAssinaturaStatus_Columnheaderclass = "WWColumn";
         AssignProp(sPrefix, false, cmbPropostaAssinaturaStatus_Internalname, "Columnheaderclass", cmbPropostaAssinaturaStatus_Columnheaderclass, !bGXsfl_104_Refreshing);
         AV49Reembolsoassinaturaswwds_1_reembolsoid = AV45ReembolsoId;
         AV50Reembolsoassinaturaswwds_2_filterfulltext = AV15FilterFullText;
         AV51Reembolsoassinaturaswwds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV52Reembolsoassinaturaswwds_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV53Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1 = AV18ReembolsoAssinaturasNome1;
         AV54Reembolsoassinaturaswwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV55Reembolsoassinaturaswwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV56Reembolsoassinaturaswwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV57Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2 = AV22ReembolsoAssinaturasNome2;
         AV58Reembolsoassinaturaswwds_10_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV59Reembolsoassinaturaswwds_11_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV60Reembolsoassinaturaswwds_12_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV61Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3 = AV26ReembolsoAssinaturasNome3;
         AV62Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome = AV35TFReembolsoAssinaturasNome;
         AV63Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel = AV36TFReembolsoAssinaturasNome_Sel;
         AV64Reembolsoassinaturaswwds_16_tfreembolsoassinaturasemissao = AV37TFReembolsoAssinaturasEmissao;
         AV65Reembolsoassinaturaswwds_17_tfreembolsoassinaturasemissao_to = AV38TFReembolsoAssinaturasEmissao_To;
         AV66Reembolsoassinaturaswwds_18_tfpropostaassinaturastatus_sels = AV47TFPropostaAssinaturaStatus_Sels;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32ManageFiltersData", AV32ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
      }

      protected void E127T2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ReembolsoAssinaturasNome") == 0 )
            {
               AV35TFReembolsoAssinaturasNome = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV35TFReembolsoAssinaturasNome", AV35TFReembolsoAssinaturasNome);
               AV36TFReembolsoAssinaturasNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV36TFReembolsoAssinaturasNome_Sel", AV36TFReembolsoAssinaturasNome_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ReembolsoAssinaturasEmissao") == 0 )
            {
               AV37TFReembolsoAssinaturasEmissao = context.localUtil.CToT( Ddo_grid_Filteredtext_get, 4);
               AssignAttri(sPrefix, false, "AV37TFReembolsoAssinaturasEmissao", context.localUtil.TToC( AV37TFReembolsoAssinaturasEmissao, 8, 5, 0, 3, "/", ":", " "));
               AV38TFReembolsoAssinaturasEmissao_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri(sPrefix, false, "AV38TFReembolsoAssinaturasEmissao_To", context.localUtil.TToC( AV38TFReembolsoAssinaturasEmissao_To, 8, 5, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV38TFReembolsoAssinaturasEmissao_To) )
               {
                  AV38TFReembolsoAssinaturasEmissao_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV38TFReembolsoAssinaturasEmissao_To)), (short)(DateTimeUtil.Month( AV38TFReembolsoAssinaturasEmissao_To)), (short)(DateTimeUtil.Day( AV38TFReembolsoAssinaturasEmissao_To)), 23, 59, 59);
                  AssignAttri(sPrefix, false, "AV38TFReembolsoAssinaturasEmissao_To", context.localUtil.TToC( AV38TFReembolsoAssinaturasEmissao_To, 8, 5, 0, 3, "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PropostaAssinaturaStatus") == 0 )
            {
               AV46TFPropostaAssinaturaStatus_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV46TFPropostaAssinaturaStatus_SelsJson", AV46TFPropostaAssinaturaStatus_SelsJson);
               AV47TFPropostaAssinaturaStatus_Sels.FromJSonString(AV46TFPropostaAssinaturaStatus_SelsJson, null);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV47TFPropostaAssinaturaStatus_Sels", AV47TFPropostaAssinaturaStatus_Sels);
      }

      private void E257T2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV43Display = "<i class=\"fa fa-search\"></i>";
         AssignAttri(sPrefix, false, edtavDisplay_Internalname, AV43Display);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpassinaturas"+UrlEncode(StringUtil.LTrimStr(A571PropostaAssinatura,10,0));
         edtavDisplay_Link = formatLink("wpassinaturas") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "reembolsoassinaturas"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A631ReembolsoAssinaturasId,9,0));
         edtReembolsoAssinaturasNome_Link = formatLink("reembolsoassinaturas") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         if ( StringUtil.StrCmp(A574PropostaAssinaturaStatus, "ENVIADO") == 0 )
         {
            cmbPropostaAssinaturaStatus_Columnclass = "WWColumn WWColumnTag WWColumnTagInfoLight WWColumnTagInfoLightSingleCell";
         }
         else if ( StringUtil.StrCmp(A574PropostaAssinaturaStatus, "REJEITADO") == 0 )
         {
            cmbPropostaAssinaturaStatus_Columnclass = "WWColumn WWColumnTag WWColumnTagDanger WWColumnTagDangerSingleCell";
         }
         else if ( StringUtil.StrCmp(A574PropostaAssinaturaStatus, "CANCELADO") == 0 )
         {
            cmbPropostaAssinaturaStatus_Columnclass = "WWColumn WWColumnTag WWColumnTagDanger WWColumnTagDangerSingleCell";
         }
         else if ( StringUtil.StrCmp(A574PropostaAssinaturaStatus, "ASSINADO") == 0 )
         {
            cmbPropostaAssinaturaStatus_Columnclass = "WWColumn WWColumnTag WWColumnTagSuccess WWColumnTagSuccessSingleCell";
         }
         else if ( StringUtil.StrCmp(A574PropostaAssinaturaStatus, "AGUARDANDO_ENVIO") == 0 )
         {
            cmbPropostaAssinaturaStatus_Columnclass = "WWColumn WWColumnTag WWColumnTagInfo WWColumnTagInfoSingleCell";
         }
         else
         {
            cmbPropostaAssinaturaStatus_Columnclass = "WWColumn";
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 104;
         }
         sendrow_1042( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_104_Refreshing )
         {
            DoAjaxLoad(104, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E187T2( )
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

      protected void E137T2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ReembolsoAssinaturasNome1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22ReembolsoAssinaturasNome2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26ReembolsoAssinaturasNome3, AV34ManageFiltersExecutionStep, AV45ReembolsoId, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV35TFReembolsoAssinaturasNome, AV36TFReembolsoAssinaturasNome_Sel, AV37TFReembolsoAssinaturasEmissao, AV38TFReembolsoAssinaturasEmissao_To, AV47TFPropostaAssinaturaStatus_Sels, AV67Pgmname, AV44PropostaId, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, sPrefix) ;
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

      protected void E197T2( )
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

      protected void E207T2( )
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

      protected void E147T2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ReembolsoAssinaturasNome1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22ReembolsoAssinaturasNome2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26ReembolsoAssinaturasNome3, AV34ManageFiltersExecutionStep, AV45ReembolsoId, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV35TFReembolsoAssinaturasNome, AV36TFReembolsoAssinaturasNome_Sel, AV37TFReembolsoAssinaturasEmissao, AV38TFReembolsoAssinaturasEmissao_To, AV47TFPropostaAssinaturaStatus_Sels, AV67Pgmname, AV44PropostaId, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, sPrefix) ;
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

      protected void E217T2( )
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

      protected void E157T2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ReembolsoAssinaturasNome1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22ReembolsoAssinaturasNome2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26ReembolsoAssinaturasNome3, AV34ManageFiltersExecutionStep, AV45ReembolsoId, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV35TFReembolsoAssinaturasNome, AV36TFReembolsoAssinaturasNome_Sel, AV37TFReembolsoAssinaturasEmissao, AV38TFReembolsoAssinaturasEmissao_To, AV47TFPropostaAssinaturaStatus_Sels, AV67Pgmname, AV44PropostaId, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, sPrefix) ;
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

      protected void E227T2( )
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

      protected void E117T2( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("ReembolsoAssinaturasWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV67Pgmname+"GridState"));
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
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("ReembolsoAssinaturasWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV34ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV34ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV34ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else
         {
            GXt_char2 = AV33ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "ReembolsoAssinaturasWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV67Pgmname+"GridState",  AV33ManageFiltersXml) ;
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV47TFPropostaAssinaturaStatus_Sels", AV47TFPropostaAssinaturaStatus_Sels);
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

      protected void E167T2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "assinarcontratoproposta"+UrlEncode(StringUtil.LTrimStr(AV44PropostaId,9,0)) + "," + UrlEncode(StringUtil.RTrim("Documento")) + "," + UrlEncode(StringUtil.LTrimStr(AV45ReembolsoId,9,0));
         CallWebObject(formatLink("assinarcontratoproposta") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E177T2( )
      {
         /* 'DoExport' Routine */
         returnInSub = false;
         new reembolsoassinaturaswwexport(context ).execute( out  AV29ExcelFilename, out  AV30ErrorMessage) ;
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
         edtavReembolsoassinaturasnome1_Visible = 0;
         AssignProp(sPrefix, false, edtavReembolsoassinaturasnome1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavReembolsoassinaturasnome1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "REEMBOLSOASSINATURASNOME") == 0 )
         {
            edtavReembolsoassinaturasnome1_Visible = 1;
            AssignProp(sPrefix, false, edtavReembolsoassinaturasnome1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavReembolsoassinaturasnome1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavReembolsoassinaturasnome2_Visible = 0;
         AssignProp(sPrefix, false, edtavReembolsoassinaturasnome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavReembolsoassinaturasnome2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "REEMBOLSOASSINATURASNOME") == 0 )
         {
            edtavReembolsoassinaturasnome2_Visible = 1;
            AssignProp(sPrefix, false, edtavReembolsoassinaturasnome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavReembolsoassinaturasnome2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavReembolsoassinaturasnome3_Visible = 0;
         AssignProp(sPrefix, false, edtavReembolsoassinaturasnome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavReembolsoassinaturasnome3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "REEMBOLSOASSINATURASNOME") == 0 )
         {
            edtavReembolsoassinaturasnome3_Visible = 1;
            AssignProp(sPrefix, false, edtavReembolsoassinaturasnome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavReembolsoassinaturasnome3_Visible), 5, 0), true);
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
         AV20DynamicFiltersSelector2 = "REEMBOLSOASSINATURASNOME";
         AssignAttri(sPrefix, false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         AV21DynamicFiltersOperator2 = 0;
         AssignAttri(sPrefix, false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AV22ReembolsoAssinaturasNome2 = "";
         AssignAttri(sPrefix, false, "AV22ReembolsoAssinaturasNome2", AV22ReembolsoAssinaturasNome2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV23DynamicFiltersEnabled3 = false;
         AssignAttri(sPrefix, false, "AV23DynamicFiltersEnabled3", AV23DynamicFiltersEnabled3);
         AV24DynamicFiltersSelector3 = "REEMBOLSOASSINATURASNOME";
         AssignAttri(sPrefix, false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
         AV25DynamicFiltersOperator3 = 0;
         AssignAttri(sPrefix, false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AV26ReembolsoAssinaturasNome3 = "";
         AssignAttri(sPrefix, false, "AV26ReembolsoAssinaturasNome3", AV26ReembolsoAssinaturasNome3);
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
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "ReembolsoAssinaturasWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV32ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S222( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri(sPrefix, false, "AV15FilterFullText", AV15FilterFullText);
         AV35TFReembolsoAssinaturasNome = "";
         AssignAttri(sPrefix, false, "AV35TFReembolsoAssinaturasNome", AV35TFReembolsoAssinaturasNome);
         AV36TFReembolsoAssinaturasNome_Sel = "";
         AssignAttri(sPrefix, false, "AV36TFReembolsoAssinaturasNome_Sel", AV36TFReembolsoAssinaturasNome_Sel);
         AV37TFReembolsoAssinaturasEmissao = (DateTime)(DateTime.MinValue);
         AssignAttri(sPrefix, false, "AV37TFReembolsoAssinaturasEmissao", context.localUtil.TToC( AV37TFReembolsoAssinaturasEmissao, 8, 5, 0, 3, "/", ":", " "));
         AV38TFReembolsoAssinaturasEmissao_To = (DateTime)(DateTime.MinValue);
         AssignAttri(sPrefix, false, "AV38TFReembolsoAssinaturasEmissao_To", context.localUtil.TToC( AV38TFReembolsoAssinaturasEmissao_To, 8, 5, 0, 3, "/", ":", " "));
         AV47TFPropostaAssinaturaStatus_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV16DynamicFiltersSelector1 = "REEMBOLSOASSINATURASNOME";
         AssignAttri(sPrefix, false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         AV17DynamicFiltersOperator1 = 0;
         AssignAttri(sPrefix, false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AV18ReembolsoAssinaturasNome1 = "";
         AssignAttri(sPrefix, false, "AV18ReembolsoAssinaturasNome1", AV18ReembolsoAssinaturasNome1);
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

      protected void S162( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV31Session.Get(AV67Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV67Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV31Session.Get(AV67Pgmname+"GridState"), null, "", "");
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
         AV68GXV1 = 1;
         while ( AV68GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV68GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOASSINATURASNOME") == 0 )
            {
               AV35TFReembolsoAssinaturasNome = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV35TFReembolsoAssinaturasNome", AV35TFReembolsoAssinaturasNome);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOASSINATURASNOME_SEL") == 0 )
            {
               AV36TFReembolsoAssinaturasNome_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV36TFReembolsoAssinaturasNome_Sel", AV36TFReembolsoAssinaturasNome_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOASSINATURASEMISSAO") == 0 )
            {
               AV37TFReembolsoAssinaturasEmissao = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri(sPrefix, false, "AV37TFReembolsoAssinaturasEmissao", context.localUtil.TToC( AV37TFReembolsoAssinaturasEmissao, 8, 5, 0, 3, "/", ":", " "));
               AV38TFReembolsoAssinaturasEmissao_To = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri(sPrefix, false, "AV38TFReembolsoAssinaturasEmissao_To", context.localUtil.TToC( AV38TFReembolsoAssinaturasEmissao_To, 8, 5, 0, 3, "/", ":", " "));
               AV39DDO_ReembolsoAssinaturasEmissaoAuxDate = DateTimeUtil.ResetTime(AV37TFReembolsoAssinaturasEmissao);
               AssignAttri(sPrefix, false, "AV39DDO_ReembolsoAssinaturasEmissaoAuxDate", context.localUtil.Format(AV39DDO_ReembolsoAssinaturasEmissaoAuxDate, "99/99/99"));
               AV40DDO_ReembolsoAssinaturasEmissaoAuxDateTo = DateTimeUtil.ResetTime(AV38TFReembolsoAssinaturasEmissao_To);
               AssignAttri(sPrefix, false, "AV40DDO_ReembolsoAssinaturasEmissaoAuxDateTo", context.localUtil.Format(AV40DDO_ReembolsoAssinaturasEmissaoAuxDateTo, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROPOSTAASSINATURASTATUS_SEL") == 0 )
            {
               AV46TFPropostaAssinaturaStatus_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV46TFPropostaAssinaturaStatus_SelsJson", AV46TFPropostaAssinaturaStatus_SelsJson);
               AV47TFPropostaAssinaturaStatus_Sels.FromJSonString(AV46TFPropostaAssinaturaStatus_SelsJson, null);
            }
            AV68GXV1 = (int)(AV68GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV36TFReembolsoAssinaturasNome_Sel)),  AV36TFReembolsoAssinaturasNome_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV47TFPropostaAssinaturaStatus_Sels.Count==0),  AV46TFPropostaAssinaturaStatus_SelsJson, out  GXt_char4) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"||"+GXt_char4;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV35TFReembolsoAssinaturasNome)),  AV35TFReembolsoAssinaturasNome, out  GXt_char4) ;
         Ddo_grid_Filteredtext_set = GXt_char4+"|"+((DateTime.MinValue==AV37TFReembolsoAssinaturasEmissao) ? "" : context.localUtil.DToC( AV39DDO_ReembolsoAssinaturasEmissaoAuxDate, 4, "/"))+"|";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "|"+((DateTime.MinValue==AV38TFReembolsoAssinaturasEmissao_To) ? "" : context.localUtil.DToC( AV40DDO_ReembolsoAssinaturasEmissaoAuxDateTo, 4, "/"))+"|";
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
            if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "REEMBOLSOASSINATURASNOME") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri(sPrefix, false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV18ReembolsoAssinaturasNome1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV18ReembolsoAssinaturasNome1", AV18ReembolsoAssinaturasNome1);
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
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "REEMBOLSOASSINATURASNOME") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri(sPrefix, false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
                  AV22ReembolsoAssinaturasNome2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri(sPrefix, false, "AV22ReembolsoAssinaturasNome2", AV22ReembolsoAssinaturasNome2);
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
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "REEMBOLSOASSINATURASNOME") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri(sPrefix, false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
                     AV26ReembolsoAssinaturasNome3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri(sPrefix, false, "AV26ReembolsoAssinaturasNome3", AV26ReembolsoAssinaturasNome3);
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
         AV10GridState.FromXml(AV31Session.Get(AV67Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFREEMBOLSOASSINATURASNOME",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV35TFReembolsoAssinaturasNome)),  0,  AV35TFReembolsoAssinaturasNome,  AV35TFReembolsoAssinaturasNome,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV36TFReembolsoAssinaturasNome_Sel)),  AV36TFReembolsoAssinaturasNome_Sel,  AV36TFReembolsoAssinaturasNome_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFREEMBOLSOASSINATURASEMISSAO",  "",  !((DateTime.MinValue==AV37TFReembolsoAssinaturasEmissao)&&(DateTime.MinValue==AV38TFReembolsoAssinaturasEmissao_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV37TFReembolsoAssinaturasEmissao, 8, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV37TFReembolsoAssinaturasEmissao) ? "" : StringUtil.Trim( context.localUtil.Format( AV37TFReembolsoAssinaturasEmissao, "99/99/99 99:99"))),  true,  StringUtil.Trim( context.localUtil.TToC( AV38TFReembolsoAssinaturasEmissao_To, 8, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV38TFReembolsoAssinaturasEmissao_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV38TFReembolsoAssinaturasEmissao_To, "99/99/99 99:99")))) ;
         AV48AuxText = ((AV47TFPropostaAssinaturaStatus_Sels.Count==1) ? "["+((string)AV47TFPropostaAssinaturaStatus_Sels.Item(1))+"]" : "Vários valores");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFPROPOSTAASSINATURASTATUS_SEL",  "",  !(AV47TFPropostaAssinaturaStatus_Sels.Count==0),  0,  AV47TFPropostaAssinaturaStatus_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV48AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( AV48AuxText, "[ENVIADO]", "Enviado"), "[REJEITADO]", "Rejeitado"), "[CANCELADO]", "Cancelado"), "[ASSINADO]", "Assinado"), "[AGUARDANDO_ENVIO]", "Aguardando envio")),  false,  "",  "") ;
         if ( ! (0==AV44PropostaId) )
         {
            AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV11GridStateFilterValue.gxTpr_Name = "PARM_&PROPOSTAID";
            AV11GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV44PropostaId), 9, 0);
            AV10GridState.gxTpr_Filtervalues.Add(AV11GridStateFilterValue, 0);
         }
         if ( ! (0==AV45ReembolsoId) )
         {
            AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV11GridStateFilterValue.gxTpr_Name = "PARM_&REEMBOLSOID";
            AV11GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV45ReembolsoId), 9, 0);
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
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV67Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
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
            if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "REEMBOLSOASSINATURASNOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV18ReembolsoAssinaturasNome1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Nome amigável do arquivo/documento",  AV17DynamicFiltersOperator1,  AV18ReembolsoAssinaturasNome1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV18ReembolsoAssinaturasNome1, "Contém"+" "+AV18ReembolsoAssinaturasNome1, "", "", "", "", "", "", ""),  false,  "",  "") ;
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
            if ( ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "REEMBOLSOASSINATURASNOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV22ReembolsoAssinaturasNome2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Nome amigável do arquivo/documento",  AV21DynamicFiltersOperator2,  AV22ReembolsoAssinaturasNome2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV22ReembolsoAssinaturasNome2, "Contém"+" "+AV22ReembolsoAssinaturasNome2, "", "", "", "", "", "", ""),  false,  "",  "") ;
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
            if ( ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "REEMBOLSOASSINATURASNOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV26ReembolsoAssinaturasNome3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Nome amigável do arquivo/documento",  AV25DynamicFiltersOperator3,  AV26ReembolsoAssinaturasNome3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV26ReembolsoAssinaturasNome3, "Contém"+" "+AV26ReembolsoAssinaturasNome3, "", "", "", "", "", "", ""),  false,  "",  "") ;
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
         AV8TrnContext.gxTpr_Callerobject = AV67Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "ReembolsoAssinaturas";
         AV9TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV9TrnContextAtt.gxTpr_Attributename = "ReembolsoId";
         AV9TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV45ReembolsoId), 9, 0);
         AV8TrnContext.gxTpr_Attributes.Add(AV9TrnContextAtt, 0);
         AV31Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table3_89_7T2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'" + sPrefix + "',false,'" + sGXsfl_104_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,93);\"", "", true, 0, "HLP_ReembolsoAssinaturasWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_reembolsoassinaturasnome3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavReembolsoassinaturasnome3_Internalname, "Reembolso Assinaturas Nome3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'" + sPrefix + "',false,'" + sGXsfl_104_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavReembolsoassinaturasnome3_Internalname, AV26ReembolsoAssinaturasNome3, StringUtil.RTrim( context.localUtil.Format( AV26ReembolsoAssinaturasNome3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReembolsoassinaturasnome3_Jsonclick, 0, "Attribute", "", "", "", "", edtavReembolsoassinaturasnome3_Visible, edtavReembolsoassinaturasnome3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ReembolsoAssinaturasWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ReembolsoAssinaturasWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_89_7T2e( true) ;
         }
         else
         {
            wb_table3_89_7T2e( false) ;
         }
      }

      protected void wb_table2_67_7T2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'" + sPrefix + "',false,'" + sGXsfl_104_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "", true, 0, "HLP_ReembolsoAssinaturasWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_reembolsoassinaturasnome2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavReembolsoassinaturasnome2_Internalname, "Reembolso Assinaturas Nome2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'" + sPrefix + "',false,'" + sGXsfl_104_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavReembolsoassinaturasnome2_Internalname, AV22ReembolsoAssinaturasNome2, StringUtil.RTrim( context.localUtil.Format( AV22ReembolsoAssinaturasNome2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReembolsoassinaturasnome2_Jsonclick, 0, "Attribute", "", "", "", "", edtavReembolsoassinaturasnome2_Visible, edtavReembolsoassinaturasnome2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ReembolsoAssinaturasWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ReembolsoAssinaturasWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ReembolsoAssinaturasWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_67_7T2e( true) ;
         }
         else
         {
            wb_table2_67_7T2e( false) ;
         }
      }

      protected void wb_table1_45_7T2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'" + sPrefix + "',false,'" + sGXsfl_104_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 0, "HLP_ReembolsoAssinaturasWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_reembolsoassinaturasnome1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavReembolsoassinaturasnome1_Internalname, "Reembolso Assinaturas Nome1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'" + sPrefix + "',false,'" + sGXsfl_104_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavReembolsoassinaturasnome1_Internalname, AV18ReembolsoAssinaturasNome1, StringUtil.RTrim( context.localUtil.Format( AV18ReembolsoAssinaturasNome1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReembolsoassinaturasnome1_Jsonclick, 0, "Attribute", "", "", "", "", edtavReembolsoassinaturasnome1_Visible, edtavReembolsoassinaturasnome1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ReembolsoAssinaturasWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ReembolsoAssinaturasWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ReembolsoAssinaturasWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_45_7T2e( true) ;
         }
         else
         {
            wb_table1_45_7T2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV44PropostaId = Convert.ToInt32(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV44PropostaId", StringUtil.LTrimStr( (decimal)(AV44PropostaId), 9, 0));
         AV45ReembolsoId = Convert.ToInt32(getParm(obj,1));
         AssignAttri(sPrefix, false, "AV45ReembolsoId", StringUtil.LTrimStr( (decimal)(AV45ReembolsoId), 9, 0));
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
         PA7T2( ) ;
         WS7T2( ) ;
         WE7T2( ) ;
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
         sCtrlAV44PropostaId = (string)((string)getParm(obj,0));
         sCtrlAV45ReembolsoId = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA7T2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "reembolsoassinaturasww", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA7T2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV44PropostaId = Convert.ToInt32(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV44PropostaId", StringUtil.LTrimStr( (decimal)(AV44PropostaId), 9, 0));
            AV45ReembolsoId = Convert.ToInt32(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV45ReembolsoId", StringUtil.LTrimStr( (decimal)(AV45ReembolsoId), 9, 0));
         }
         wcpOAV44PropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV44PropostaId"), ",", "."), 18, MidpointRounding.ToEven));
         wcpOAV45ReembolsoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV45ReembolsoId"), ",", "."), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( AV44PropostaId != wcpOAV44PropostaId ) || ( AV45ReembolsoId != wcpOAV45ReembolsoId ) ) )
         {
            setjustcreated();
         }
         wcpOAV44PropostaId = AV44PropostaId;
         wcpOAV45ReembolsoId = AV45ReembolsoId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV44PropostaId = cgiGet( sPrefix+"AV44PropostaId_CTRL");
         if ( StringUtil.Len( sCtrlAV44PropostaId) > 0 )
         {
            AV44PropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV44PropostaId), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV44PropostaId", StringUtil.LTrimStr( (decimal)(AV44PropostaId), 9, 0));
         }
         else
         {
            AV44PropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV44PropostaId_PARM"), ",", "."), 18, MidpointRounding.ToEven));
         }
         sCtrlAV45ReembolsoId = cgiGet( sPrefix+"AV45ReembolsoId_CTRL");
         if ( StringUtil.Len( sCtrlAV45ReembolsoId) > 0 )
         {
            AV45ReembolsoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV45ReembolsoId), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV45ReembolsoId", StringUtil.LTrimStr( (decimal)(AV45ReembolsoId), 9, 0));
         }
         else
         {
            AV45ReembolsoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV45ReembolsoId_PARM"), ",", "."), 18, MidpointRounding.ToEven));
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
         PA7T2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS7T2( ) ;
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
         WS7T2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV44PropostaId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44PropostaId), 9, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV44PropostaId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV44PropostaId_CTRL", StringUtil.RTrim( sCtrlAV44PropostaId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV45ReembolsoId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV45ReembolsoId), 9, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV45ReembolsoId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV45ReembolsoId_CTRL", StringUtil.RTrim( sCtrlAV45ReembolsoId));
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
         WE7T2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019194929", true, true);
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
         context.AddJavascriptSource("reembolsoassinaturasww.js", "?202561019194930", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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

      protected void SubsflControlProps_1042( )
      {
         edtavDisplay_Internalname = sPrefix+"vDISPLAY_"+sGXsfl_104_idx;
         edtReembolsoAssinaturasId_Internalname = sPrefix+"REEMBOLSOASSINATURASID_"+sGXsfl_104_idx;
         edtReembolsoId_Internalname = sPrefix+"REEMBOLSOID_"+sGXsfl_104_idx;
         edtPropostaContratoAssinaturaId_Internalname = sPrefix+"PROPOSTACONTRATOASSINATURAID_"+sGXsfl_104_idx;
         edtPropostaAssinatura_Internalname = sPrefix+"PROPOSTAASSINATURA_"+sGXsfl_104_idx;
         edtReembolsoAssinaturasNome_Internalname = sPrefix+"REEMBOLSOASSINATURASNOME_"+sGXsfl_104_idx;
         edtReembolsoAssinaturasEmissao_Internalname = sPrefix+"REEMBOLSOASSINATURASEMISSAO_"+sGXsfl_104_idx;
         cmbPropostaAssinaturaStatus_Internalname = sPrefix+"PROPOSTAASSINATURASTATUS_"+sGXsfl_104_idx;
      }

      protected void SubsflControlProps_fel_1042( )
      {
         edtavDisplay_Internalname = sPrefix+"vDISPLAY_"+sGXsfl_104_fel_idx;
         edtReembolsoAssinaturasId_Internalname = sPrefix+"REEMBOLSOASSINATURASID_"+sGXsfl_104_fel_idx;
         edtReembolsoId_Internalname = sPrefix+"REEMBOLSOID_"+sGXsfl_104_fel_idx;
         edtPropostaContratoAssinaturaId_Internalname = sPrefix+"PROPOSTACONTRATOASSINATURAID_"+sGXsfl_104_fel_idx;
         edtPropostaAssinatura_Internalname = sPrefix+"PROPOSTAASSINATURA_"+sGXsfl_104_fel_idx;
         edtReembolsoAssinaturasNome_Internalname = sPrefix+"REEMBOLSOASSINATURASNOME_"+sGXsfl_104_fel_idx;
         edtReembolsoAssinaturasEmissao_Internalname = sPrefix+"REEMBOLSOASSINATURASEMISSAO_"+sGXsfl_104_fel_idx;
         cmbPropostaAssinaturaStatus_Internalname = sPrefix+"PROPOSTAASSINATURASTATUS_"+sGXsfl_104_fel_idx;
      }

      protected void sendrow_1042( )
      {
         sGXsfl_104_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_104_idx), 4, 0), 4, "0");
         SubsflControlProps_1042( ) ;
         WB7T0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_104_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_104_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_104_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'" + sPrefix + "',false,'" + sGXsfl_104_idx + "',104)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDisplay_Internalname,StringUtil.RTrim( AV43Display),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,105);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtavDisplay_Link,(string)"",(string)"Mostrar",(string)"",(string)edtavDisplay_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavDisplay_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)104,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtReembolsoAssinaturasId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A631ReembolsoAssinaturasId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A631ReembolsoAssinaturasId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtReembolsoAssinaturasId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)104,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtReembolsoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A518ReembolsoId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A518ReembolsoId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtReembolsoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)104,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaContratoAssinaturaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A572PropostaContratoAssinaturaId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A572PropostaContratoAssinaturaId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaContratoAssinaturaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)104,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaAssinatura_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A571PropostaAssinatura), 10, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A571PropostaAssinatura), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaAssinatura_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)104,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtReembolsoAssinaturasNome_Internalname,(string)A632ReembolsoAssinaturasNome,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtReembolsoAssinaturasNome_Link,(string)"",(string)"",(string)"",(string)edtReembolsoAssinaturasNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)104,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtReembolsoAssinaturasEmissao_Internalname,context.localUtil.TToC( A633ReembolsoAssinaturasEmissao, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A633ReembolsoAssinaturasEmissao, "99/99/99 99:99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtReembolsoAssinaturasEmissao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)104,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            GXCCtl = "PROPOSTAASSINATURASTATUS_" + sGXsfl_104_idx;
            cmbPropostaAssinaturaStatus.Name = GXCCtl;
            cmbPropostaAssinaturaStatus.WebTags = "";
            cmbPropostaAssinaturaStatus.addItem("ENVIADO", "Enviado", 0);
            cmbPropostaAssinaturaStatus.addItem("REJEITADO", "Rejeitado", 0);
            cmbPropostaAssinaturaStatus.addItem("CANCELADO", "Cancelado", 0);
            cmbPropostaAssinaturaStatus.addItem("ASSINADO", "Assinado", 0);
            cmbPropostaAssinaturaStatus.addItem("AGUARDANDO_ENVIO", "Aguardando envio", 0);
            if ( cmbPropostaAssinaturaStatus.ItemCount > 0 )
            {
               A574PropostaAssinaturaStatus = cmbPropostaAssinaturaStatus.getValidValue(A574PropostaAssinaturaStatus);
               n574PropostaAssinaturaStatus = false;
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbPropostaAssinaturaStatus,(string)cmbPropostaAssinaturaStatus_Internalname,StringUtil.RTrim( A574PropostaAssinaturaStatus),(short)1,(string)cmbPropostaAssinaturaStatus_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,(short)0,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)cmbPropostaAssinaturaStatus_Columnclass,(string)cmbPropostaAssinaturaStatus_Columnheaderclass,(string)"",(string)"",(bool)true,(short)0});
            cmbPropostaAssinaturaStatus.CurrentValue = StringUtil.RTrim( A574PropostaAssinaturaStatus);
            AssignProp(sPrefix, false, cmbPropostaAssinaturaStatus_Internalname, "Values", (string)(cmbPropostaAssinaturaStatus.ToJavascriptSource()), !bGXsfl_104_Refreshing);
            send_integrity_lvl_hashes7T2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_104_idx = ((subGrid_Islastpage==1)&&(nGXsfl_104_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_104_idx+1);
            sGXsfl_104_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_104_idx), 4, 0), 4, "0");
            SubsflControlProps_1042( ) ;
         }
         /* End function sendrow_1042 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("REEMBOLSOASSINATURASNOME", "Nome amigável do arquivo/documento", 0);
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
         cmbavDynamicfiltersselector2.addItem("REEMBOLSOASSINATURASNOME", "Nome amigável do arquivo/documento", 0);
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
         cmbavDynamicfiltersselector3.addItem("REEMBOLSOASSINATURASNOME", "Nome amigável do arquivo/documento", 0);
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
         GXCCtl = "PROPOSTAASSINATURASTATUS_" + sGXsfl_104_idx;
         cmbPropostaAssinaturaStatus.Name = GXCCtl;
         cmbPropostaAssinaturaStatus.WebTags = "";
         cmbPropostaAssinaturaStatus.addItem("ENVIADO", "Enviado", 0);
         cmbPropostaAssinaturaStatus.addItem("REJEITADO", "Rejeitado", 0);
         cmbPropostaAssinaturaStatus.addItem("CANCELADO", "Cancelado", 0);
         cmbPropostaAssinaturaStatus.addItem("ASSINADO", "Assinado", 0);
         cmbPropostaAssinaturaStatus.addItem("AGUARDANDO_ENVIO", "Aguardando envio", 0);
         if ( cmbPropostaAssinaturaStatus.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl104( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"104\">") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Assinaturas Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Assinatura Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Proposta Assinatura") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Documento") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Data/hora de emissão") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Status") ;
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
            GridContainer.AddObjectProperty("Class", "GridWithBorderColor WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", sPrefix);
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV43Display)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDisplay_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDisplay_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A631ReembolsoAssinaturasId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A518ReembolsoId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A572PropostaContratoAssinaturaId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A571PropostaAssinatura), 10, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A632ReembolsoAssinaturasNome));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtReembolsoAssinaturasNome_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A633ReembolsoAssinaturasEmissao, 10, 8, 0, 3, "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A574PropostaAssinaturaStatus));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbPropostaAssinaturaStatus_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbPropostaAssinaturaStatus_Columnheaderclass));
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
         bttBtninsert_Internalname = sPrefix+"BTNINSERT";
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
         edtavReembolsoassinaturasnome1_Internalname = sPrefix+"vREEMBOLSOASSINATURASNOME1";
         cellFilter_reembolsoassinaturasnome1_cell_Internalname = sPrefix+"FILTER_REEMBOLSOASSINATURASNOME1_CELL";
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
         edtavReembolsoassinaturasnome2_Internalname = sPrefix+"vREEMBOLSOASSINATURASNOME2";
         cellFilter_reembolsoassinaturasnome2_cell_Internalname = sPrefix+"FILTER_REEMBOLSOASSINATURASNOME2_CELL";
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
         edtavReembolsoassinaturasnome3_Internalname = sPrefix+"vREEMBOLSOASSINATURASNOME3";
         cellFilter_reembolsoassinaturasnome3_cell_Internalname = sPrefix+"FILTER_REEMBOLSOASSINATURASNOME3_CELL";
         imgRemovedynamicfilters3_Internalname = sPrefix+"REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = sPrefix+"DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = sPrefix+"TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = sPrefix+"TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = sPrefix+"TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = sPrefix+"ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = sPrefix+"TABLEHEADER";
         Dvpanel_tableheader_Internalname = sPrefix+"DVPANEL_TABLEHEADER";
         edtavDisplay_Internalname = sPrefix+"vDISPLAY";
         edtReembolsoAssinaturasId_Internalname = sPrefix+"REEMBOLSOASSINATURASID";
         edtReembolsoId_Internalname = sPrefix+"REEMBOLSOID";
         edtPropostaContratoAssinaturaId_Internalname = sPrefix+"PROPOSTACONTRATOASSINATURAID";
         edtPropostaAssinatura_Internalname = sPrefix+"PROPOSTAASSINATURA";
         edtReembolsoAssinaturasNome_Internalname = sPrefix+"REEMBOLSOASSINATURASNOME";
         edtReembolsoAssinaturasEmissao_Internalname = sPrefix+"REEMBOLSOASSINATURASEMISSAO";
         cmbPropostaAssinaturaStatus_Internalname = sPrefix+"PROPOSTAASSINATURASTATUS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         lblJsdynamicfilters_Internalname = sPrefix+"JSDYNAMICFILTERS";
         Ddo_grid_Internalname = sPrefix+"DDO_GRID";
         Grid_empowerer_Internalname = sPrefix+"GRID_EMPOWERER";
         edtavDdo_reembolsoassinaturasemissaoauxdatetext_Internalname = sPrefix+"vDDO_REEMBOLSOASSINATURASEMISSAOAUXDATETEXT";
         Tfreembolsoassinaturasemissao_rangepicker_Internalname = sPrefix+"TFREEMBOLSOASSINATURASEMISSAO_RANGEPICKER";
         divDdo_reembolsoassinaturasemissaoauxdates_Internalname = sPrefix+"DDO_REEMBOLSOASSINATURASEMISSAOAUXDATES";
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
         cmbPropostaAssinaturaStatus_Jsonclick = "";
         cmbPropostaAssinaturaStatus_Columnclass = "WWColumn";
         edtReembolsoAssinaturasEmissao_Jsonclick = "";
         edtReembolsoAssinaturasNome_Jsonclick = "";
         edtReembolsoAssinaturasNome_Link = "";
         edtPropostaAssinatura_Jsonclick = "";
         edtPropostaContratoAssinaturaId_Jsonclick = "";
         edtReembolsoId_Jsonclick = "";
         edtReembolsoAssinaturasId_Jsonclick = "";
         edtavDisplay_Jsonclick = "";
         edtavDisplay_Link = "";
         edtavDisplay_Enabled = 0;
         subGrid_Class = "GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavReembolsoassinaturasnome1_Jsonclick = "";
         edtavReembolsoassinaturasnome1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavReembolsoassinaturasnome2_Jsonclick = "";
         edtavReembolsoassinaturasnome2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavReembolsoassinaturasnome3_Jsonclick = "";
         edtavReembolsoassinaturasnome3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavReembolsoassinaturasnome3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavReembolsoassinaturasnome2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavReembolsoassinaturasnome1_Visible = 1;
         cmbPropostaAssinaturaStatus_Columnheaderclass = "";
         cmbPropostaAssinaturaStatus.Enabled = 0;
         edtReembolsoAssinaturasEmissao_Enabled = 0;
         edtReembolsoAssinaturasNome_Enabled = 0;
         edtPropostaAssinatura_Enabled = 0;
         edtPropostaContratoAssinaturaId_Enabled = 0;
         edtReembolsoId_Enabled = 0;
         edtReembolsoAssinaturasId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_reembolsoassinaturasemissaoauxdatetext_Jsonclick = "";
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
         Ddo_grid_Datalistproc = "ReembolsoAssinaturasWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "||ENVIADO:Enviado,REJEITADO:Rejeitado,CANCELADO:Cancelado,ASSINADO:Assinado,AGUARDANDO_ENVIO:Aguardando envio";
         Ddo_grid_Allowmultipleselection = "||T";
         Ddo_grid_Datalisttype = "Dynamic||FixedValues";
         Ddo_grid_Includedatalist = "T||T";
         Ddo_grid_Filterisrange = "|P|";
         Ddo_grid_Filtertype = "Character|Date|";
         Ddo_grid_Includefilter = "T|T|";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|1|3";
         Ddo_grid_Columnids = "5:ReembolsoAssinaturasNome|6:ReembolsoAssinaturasEmissao|7:PropostaAssinaturaStatus";
         Ddo_grid_Gridinternalname = "";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV45ReembolsoId","fld":"vREEMBOLSOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ReembolsoAssinaturasNome1","fld":"vREEMBOLSOASSINATURASNOME1","type":"svchar"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22ReembolsoAssinaturasNome2","fld":"vREEMBOLSOASSINATURASNOME2","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26ReembolsoAssinaturasNome3","fld":"vREEMBOLSOASSINATURASNOME3","type":"svchar"},{"av":"AV35TFReembolsoAssinaturasNome","fld":"vTFREEMBOLSOASSINATURASNOME","type":"svchar"},{"av":"AV36TFReembolsoAssinaturasNome_Sel","fld":"vTFREEMBOLSOASSINATURASNOME_SEL","type":"svchar"},{"av":"AV37TFReembolsoAssinaturasEmissao","fld":"vTFREEMBOLSOASSINATURASEMISSAO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV38TFReembolsoAssinaturasEmissao_To","fld":"vTFREEMBOLSOASSINATURASEMISSAO_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV47TFPropostaAssinaturaStatus_Sels","fld":"vTFPROPOSTAASSINATURASTATUS_SELS","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV44PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV67Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbPropostaAssinaturaStatus"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E127T2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ReembolsoAssinaturasNome1","fld":"vREEMBOLSOASSINATURASNOME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22ReembolsoAssinaturasNome2","fld":"vREEMBOLSOASSINATURASNOME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26ReembolsoAssinaturasNome3","fld":"vREEMBOLSOASSINATURASNOME3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV45ReembolsoId","fld":"vREEMBOLSOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV35TFReembolsoAssinaturasNome","fld":"vTFREEMBOLSOASSINATURASNOME","type":"svchar"},{"av":"AV36TFReembolsoAssinaturasNome_Sel","fld":"vTFREEMBOLSOASSINATURASNOME_SEL","type":"svchar"},{"av":"AV37TFReembolsoAssinaturasEmissao","fld":"vTFREEMBOLSOASSINATURASEMISSAO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV38TFReembolsoAssinaturasEmissao_To","fld":"vTFREEMBOLSOASSINATURASEMISSAO_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV47TFPropostaAssinaturaStatus_Sels","fld":"vTFPROPOSTAASSINATURASTATUS_SELS","type":""},{"av":"AV67Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV44PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV35TFReembolsoAssinaturasNome","fld":"vTFREEMBOLSOASSINATURASNOME","type":"svchar"},{"av":"AV36TFReembolsoAssinaturasNome_Sel","fld":"vTFREEMBOLSOASSINATURASNOME_SEL","type":"svchar"},{"av":"AV37TFReembolsoAssinaturasEmissao","fld":"vTFREEMBOLSOASSINATURASEMISSAO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV38TFReembolsoAssinaturasEmissao_To","fld":"vTFREEMBOLSOASSINATURASEMISSAO_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV46TFPropostaAssinaturaStatus_SelsJson","fld":"vTFPROPOSTAASSINATURASTATUS_SELSJSON","type":"vchar"},{"av":"AV47TFPropostaAssinaturaStatus_Sels","fld":"vTFPROPOSTAASSINATURASTATUS_SELS","type":""},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E257T2","iparms":[{"av":"A571PropostaAssinatura","fld":"PROPOSTAASSINATURA","pic":"ZZZZZZZZZ9","type":"int"},{"av":"A631ReembolsoAssinaturasId","fld":"REEMBOLSOASSINATURASID","pic":"ZZZZZZZZ9","type":"int"},{"av":"cmbPropostaAssinaturaStatus"},{"av":"A574PropostaAssinaturaStatus","fld":"PROPOSTAASSINATURASTATUS","type":"svchar"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV43Display","fld":"vDISPLAY","type":"char"},{"av":"edtavDisplay_Link","ctrl":"vDISPLAY","prop":"Link"},{"av":"edtReembolsoAssinaturasNome_Link","ctrl":"REEMBOLSOASSINATURASNOME","prop":"Link"},{"av":"cmbPropostaAssinaturaStatus"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E187T2","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E137T2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ReembolsoAssinaturasNome1","fld":"vREEMBOLSOASSINATURASNOME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22ReembolsoAssinaturasNome2","fld":"vREEMBOLSOASSINATURASNOME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26ReembolsoAssinaturasNome3","fld":"vREEMBOLSOASSINATURASNOME3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV45ReembolsoId","fld":"vREEMBOLSOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV35TFReembolsoAssinaturasNome","fld":"vTFREEMBOLSOASSINATURASNOME","type":"svchar"},{"av":"AV36TFReembolsoAssinaturasNome_Sel","fld":"vTFREEMBOLSOASSINATURASNOME_SEL","type":"svchar"},{"av":"AV37TFReembolsoAssinaturasEmissao","fld":"vTFREEMBOLSOASSINATURASEMISSAO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV38TFReembolsoAssinaturasEmissao_To","fld":"vTFREEMBOLSOASSINATURASEMISSAO_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV47TFPropostaAssinaturaStatus_Sels","fld":"vTFPROPOSTAASSINATURASTATUS_SELS","type":""},{"av":"AV67Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV44PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22ReembolsoAssinaturasNome2","fld":"vREEMBOLSOASSINATURASNOME2","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26ReembolsoAssinaturasNome3","fld":"vREEMBOLSOASSINATURASNOME3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ReembolsoAssinaturasNome1","fld":"vREEMBOLSOASSINATURASNOME1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavReembolsoassinaturasnome2_Visible","ctrl":"vREEMBOLSOASSINATURASNOME2","prop":"Visible"},{"av":"edtavReembolsoassinaturasnome3_Visible","ctrl":"vREEMBOLSOASSINATURASNOME3","prop":"Visible"},{"av":"edtavReembolsoassinaturasnome1_Visible","ctrl":"vREEMBOLSOASSINATURASNOME1","prop":"Visible"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbPropostaAssinaturaStatus"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E197T2","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"edtavReembolsoassinaturasnome1_Visible","ctrl":"vREEMBOLSOASSINATURASNOME1","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator1"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E207T2","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E147T2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ReembolsoAssinaturasNome1","fld":"vREEMBOLSOASSINATURASNOME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22ReembolsoAssinaturasNome2","fld":"vREEMBOLSOASSINATURASNOME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26ReembolsoAssinaturasNome3","fld":"vREEMBOLSOASSINATURASNOME3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV45ReembolsoId","fld":"vREEMBOLSOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV35TFReembolsoAssinaturasNome","fld":"vTFREEMBOLSOASSINATURASNOME","type":"svchar"},{"av":"AV36TFReembolsoAssinaturasNome_Sel","fld":"vTFREEMBOLSOASSINATURASNOME_SEL","type":"svchar"},{"av":"AV37TFReembolsoAssinaturasEmissao","fld":"vTFREEMBOLSOASSINATURASEMISSAO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV38TFReembolsoAssinaturasEmissao_To","fld":"vTFREEMBOLSOASSINATURASEMISSAO_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV47TFPropostaAssinaturaStatus_Sels","fld":"vTFPROPOSTAASSINATURASTATUS_SELS","type":""},{"av":"AV67Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV44PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22ReembolsoAssinaturasNome2","fld":"vREEMBOLSOASSINATURASNOME2","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26ReembolsoAssinaturasNome3","fld":"vREEMBOLSOASSINATURASNOME3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ReembolsoAssinaturasNome1","fld":"vREEMBOLSOASSINATURASNOME1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavReembolsoassinaturasnome2_Visible","ctrl":"vREEMBOLSOASSINATURASNOME2","prop":"Visible"},{"av":"edtavReembolsoassinaturasnome3_Visible","ctrl":"vREEMBOLSOASSINATURASNOME3","prop":"Visible"},{"av":"edtavReembolsoassinaturasnome1_Visible","ctrl":"vREEMBOLSOASSINATURASNOME1","prop":"Visible"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbPropostaAssinaturaStatus"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E217T2","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"edtavReembolsoassinaturasnome2_Visible","ctrl":"vREEMBOLSOASSINATURASNOME2","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator2"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E157T2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ReembolsoAssinaturasNome1","fld":"vREEMBOLSOASSINATURASNOME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22ReembolsoAssinaturasNome2","fld":"vREEMBOLSOASSINATURASNOME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26ReembolsoAssinaturasNome3","fld":"vREEMBOLSOASSINATURASNOME3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV45ReembolsoId","fld":"vREEMBOLSOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV35TFReembolsoAssinaturasNome","fld":"vTFREEMBOLSOASSINATURASNOME","type":"svchar"},{"av":"AV36TFReembolsoAssinaturasNome_Sel","fld":"vTFREEMBOLSOASSINATURASNOME_SEL","type":"svchar"},{"av":"AV37TFReembolsoAssinaturasEmissao","fld":"vTFREEMBOLSOASSINATURASEMISSAO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV38TFReembolsoAssinaturasEmissao_To","fld":"vTFREEMBOLSOASSINATURASEMISSAO_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV47TFPropostaAssinaturaStatus_Sels","fld":"vTFPROPOSTAASSINATURASTATUS_SELS","type":""},{"av":"AV67Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV44PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22ReembolsoAssinaturasNome2","fld":"vREEMBOLSOASSINATURASNOME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26ReembolsoAssinaturasNome3","fld":"vREEMBOLSOASSINATURASNOME3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ReembolsoAssinaturasNome1","fld":"vREEMBOLSOASSINATURASNOME1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavReembolsoassinaturasnome2_Visible","ctrl":"vREEMBOLSOASSINATURASNOME2","prop":"Visible"},{"av":"edtavReembolsoassinaturasnome3_Visible","ctrl":"vREEMBOLSOASSINATURASNOME3","prop":"Visible"},{"av":"edtavReembolsoassinaturasnome1_Visible","ctrl":"vREEMBOLSOASSINATURASNOME1","prop":"Visible"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbPropostaAssinaturaStatus"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E227T2","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"edtavReembolsoassinaturasnome3_Visible","ctrl":"vREEMBOLSOASSINATURASNOME3","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator3"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E117T2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ReembolsoAssinaturasNome1","fld":"vREEMBOLSOASSINATURASNOME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22ReembolsoAssinaturasNome2","fld":"vREEMBOLSOASSINATURASNOME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26ReembolsoAssinaturasNome3","fld":"vREEMBOLSOASSINATURASNOME3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV45ReembolsoId","fld":"vREEMBOLSOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV35TFReembolsoAssinaturasNome","fld":"vTFREEMBOLSOASSINATURASNOME","type":"svchar"},{"av":"AV36TFReembolsoAssinaturasNome_Sel","fld":"vTFREEMBOLSOASSINATURASNOME_SEL","type":"svchar"},{"av":"AV37TFReembolsoAssinaturasEmissao","fld":"vTFREEMBOLSOASSINATURASEMISSAO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV38TFReembolsoAssinaturasEmissao_To","fld":"vTFREEMBOLSOASSINATURASEMISSAO_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV47TFPropostaAssinaturaStatus_Sels","fld":"vTFPROPOSTAASSINATURASTATUS_SELS","type":""},{"av":"AV67Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV44PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV46TFPropostaAssinaturaStatus_SelsJson","fld":"vTFPROPOSTAASSINATURASTATUS_SELSJSON","type":"vchar"},{"av":"AV39DDO_ReembolsoAssinaturasEmissaoAuxDate","fld":"vDDO_REEMBOLSOASSINATURASEMISSAOAUXDATE","type":"date"},{"av":"AV40DDO_ReembolsoAssinaturasEmissaoAuxDateTo","fld":"vDDO_REEMBOLSOASSINATURASEMISSAOAUXDATETO","type":"date"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV35TFReembolsoAssinaturasNome","fld":"vTFREEMBOLSOASSINATURASNOME","type":"svchar"},{"av":"AV36TFReembolsoAssinaturasNome_Sel","fld":"vTFREEMBOLSOASSINATURASNOME_SEL","type":"svchar"},{"av":"AV37TFReembolsoAssinaturasEmissao","fld":"vTFREEMBOLSOASSINATURASEMISSAO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV38TFReembolsoAssinaturasEmissao_To","fld":"vTFREEMBOLSOASSINATURASEMISSAO_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV47TFPropostaAssinaturaStatus_Sels","fld":"vTFPROPOSTAASSINATURASTATUS_SELS","type":""},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ReembolsoAssinaturasNome1","fld":"vREEMBOLSOASSINATURASNOME1","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV39DDO_ReembolsoAssinaturasEmissaoAuxDate","fld":"vDDO_REEMBOLSOASSINATURASEMISSAOAUXDATE","type":"date"},{"av":"AV40DDO_ReembolsoAssinaturasEmissaoAuxDateTo","fld":"vDDO_REEMBOLSOASSINATURASEMISSAOAUXDATETO","type":"date"},{"av":"AV46TFPropostaAssinaturaStatus_SelsJson","fld":"vTFPROPOSTAASSINATURASTATUS_SELSJSON","type":"vchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22ReembolsoAssinaturasNome2","fld":"vREEMBOLSOASSINATURASNOME2","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26ReembolsoAssinaturasNome3","fld":"vREEMBOLSOASSINATURASNOME3","type":"svchar"},{"av":"edtavReembolsoassinaturasnome1_Visible","ctrl":"vREEMBOLSOASSINATURASNOME1","prop":"Visible"},{"av":"edtavReembolsoassinaturasnome2_Visible","ctrl":"vREEMBOLSOASSINATURASNOME2","prop":"Visible"},{"av":"edtavReembolsoassinaturasnome3_Visible","ctrl":"vREEMBOLSOASSINATURASNOME3","prop":"Visible"},{"av":"cmbPropostaAssinaturaStatus"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E167T2","iparms":[{"av":"AV44PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV45ReembolsoId","fld":"vREEMBOLSOID","pic":"ZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("'DOEXPORT'","""{"handler":"E177T2","iparms":[]}""");
         setEventMetadata("GRID_FIRSTPAGE","""{"handler":"subgrid_firstpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV45ReembolsoId","fld":"vREEMBOLSOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ReembolsoAssinaturasNome1","fld":"vREEMBOLSOASSINATURASNOME1","type":"svchar"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22ReembolsoAssinaturasNome2","fld":"vREEMBOLSOASSINATURASNOME2","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26ReembolsoAssinaturasNome3","fld":"vREEMBOLSOASSINATURASNOME3","type":"svchar"},{"av":"AV35TFReembolsoAssinaturasNome","fld":"vTFREEMBOLSOASSINATURASNOME","type":"svchar"},{"av":"AV36TFReembolsoAssinaturasNome_Sel","fld":"vTFREEMBOLSOASSINATURASNOME_SEL","type":"svchar"},{"av":"AV37TFReembolsoAssinaturasEmissao","fld":"vTFREEMBOLSOASSINATURASEMISSAO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV38TFReembolsoAssinaturasEmissao_To","fld":"vTFREEMBOLSOASSINATURASEMISSAO_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV47TFPropostaAssinaturaStatus_Sels","fld":"vTFPROPOSTAASSINATURASTATUS_SELS","type":""},{"av":"AV67Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV44PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("GRID_FIRSTPAGE",""","oparms":[{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbPropostaAssinaturaStatus"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRID_PREVPAGE","""{"handler":"subgrid_previouspage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV45ReembolsoId","fld":"vREEMBOLSOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ReembolsoAssinaturasNome1","fld":"vREEMBOLSOASSINATURASNOME1","type":"svchar"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22ReembolsoAssinaturasNome2","fld":"vREEMBOLSOASSINATURASNOME2","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26ReembolsoAssinaturasNome3","fld":"vREEMBOLSOASSINATURASNOME3","type":"svchar"},{"av":"AV35TFReembolsoAssinaturasNome","fld":"vTFREEMBOLSOASSINATURASNOME","type":"svchar"},{"av":"AV36TFReembolsoAssinaturasNome_Sel","fld":"vTFREEMBOLSOASSINATURASNOME_SEL","type":"svchar"},{"av":"AV37TFReembolsoAssinaturasEmissao","fld":"vTFREEMBOLSOASSINATURASEMISSAO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV38TFReembolsoAssinaturasEmissao_To","fld":"vTFREEMBOLSOASSINATURASEMISSAO_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV47TFPropostaAssinaturaStatus_Sels","fld":"vTFPROPOSTAASSINATURASTATUS_SELS","type":""},{"av":"AV67Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV44PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("GRID_PREVPAGE",""","oparms":[{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbPropostaAssinaturaStatus"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRID_NEXTPAGE","""{"handler":"subgrid_nextpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV45ReembolsoId","fld":"vREEMBOLSOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ReembolsoAssinaturasNome1","fld":"vREEMBOLSOASSINATURASNOME1","type":"svchar"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22ReembolsoAssinaturasNome2","fld":"vREEMBOLSOASSINATURASNOME2","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26ReembolsoAssinaturasNome3","fld":"vREEMBOLSOASSINATURASNOME3","type":"svchar"},{"av":"AV35TFReembolsoAssinaturasNome","fld":"vTFREEMBOLSOASSINATURASNOME","type":"svchar"},{"av":"AV36TFReembolsoAssinaturasNome_Sel","fld":"vTFREEMBOLSOASSINATURASNOME_SEL","type":"svchar"},{"av":"AV37TFReembolsoAssinaturasEmissao","fld":"vTFREEMBOLSOASSINATURASEMISSAO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV38TFReembolsoAssinaturasEmissao_To","fld":"vTFREEMBOLSOASSINATURASEMISSAO_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV47TFPropostaAssinaturaStatus_Sels","fld":"vTFPROPOSTAASSINATURASTATUS_SELS","type":""},{"av":"AV67Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV44PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("GRID_NEXTPAGE",""","oparms":[{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbPropostaAssinaturaStatus"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRID_LASTPAGE","""{"handler":"subgrid_lastpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV45ReembolsoId","fld":"vREEMBOLSOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ReembolsoAssinaturasNome1","fld":"vREEMBOLSOASSINATURASNOME1","type":"svchar"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22ReembolsoAssinaturasNome2","fld":"vREEMBOLSOASSINATURASNOME2","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26ReembolsoAssinaturasNome3","fld":"vREEMBOLSOASSINATURASNOME3","type":"svchar"},{"av":"AV35TFReembolsoAssinaturasNome","fld":"vTFREEMBOLSOASSINATURASNOME","type":"svchar"},{"av":"AV36TFReembolsoAssinaturasNome_Sel","fld":"vTFREEMBOLSOASSINATURASNOME_SEL","type":"svchar"},{"av":"AV37TFReembolsoAssinaturasEmissao","fld":"vTFREEMBOLSOASSINATURASEMISSAO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV38TFReembolsoAssinaturasEmissao_To","fld":"vTFREEMBOLSOASSINATURASEMISSAO_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV47TFPropostaAssinaturaStatus_Sels","fld":"vTFPROPOSTAASSINATURASTATUS_SELS","type":""},{"av":"AV67Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV44PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("GRID_LASTPAGE",""","oparms":[{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbPropostaAssinaturaStatus"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("VALID_PROPOSTACONTRATOASSINATURAID","""{"handler":"Valid_Propostacontratoassinaturaid","iparms":[]}""");
         setEventMetadata("VALID_PROPOSTAASSINATURA","""{"handler":"Valid_Propostaassinatura","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Propostaassinaturastatus","iparms":[]}""");
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
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Filteredtextto_get = "";
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV15FilterFullText = "";
         AV16DynamicFiltersSelector1 = "";
         AV18ReembolsoAssinaturasNome1 = "";
         AV20DynamicFiltersSelector2 = "";
         AV22ReembolsoAssinaturasNome2 = "";
         AV24DynamicFiltersSelector3 = "";
         AV26ReembolsoAssinaturasNome3 = "";
         AV35TFReembolsoAssinaturasNome = "";
         AV36TFReembolsoAssinaturasNome_Sel = "";
         AV37TFReembolsoAssinaturasEmissao = (DateTime)(DateTime.MinValue);
         AV38TFReembolsoAssinaturasEmissao_To = (DateTime)(DateTime.MinValue);
         AV47TFPropostaAssinaturaStatus_Sels = new GxSimpleCollection<string>();
         AV67Pgmname = "";
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV32ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV42DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV39DDO_ReembolsoAssinaturasEmissaoAuxDate = DateTime.MinValue;
         AV40DDO_ReembolsoAssinaturasEmissaoAuxDateTo = DateTime.MinValue;
         AV46TFPropostaAssinaturaStatus_SelsJson = "";
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
         bttBtninsert_Jsonclick = "";
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
         lblJsdynamicfilters_Jsonclick = "";
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         AV41DDO_ReembolsoAssinaturasEmissaoAuxDateText = "";
         ucTfreembolsoassinaturasemissao_rangepicker = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV50Reembolsoassinaturaswwds_2_filterfulltext = "";
         AV51Reembolsoassinaturaswwds_3_dynamicfiltersselector1 = "";
         AV53Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1 = "";
         AV55Reembolsoassinaturaswwds_7_dynamicfiltersselector2 = "";
         AV57Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2 = "";
         AV59Reembolsoassinaturaswwds_11_dynamicfiltersselector3 = "";
         AV61Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3 = "";
         AV62Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome = "";
         AV63Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel = "";
         AV64Reembolsoassinaturaswwds_16_tfreembolsoassinaturasemissao = (DateTime)(DateTime.MinValue);
         AV65Reembolsoassinaturaswwds_17_tfreembolsoassinaturasemissao_to = (DateTime)(DateTime.MinValue);
         AV66Reembolsoassinaturaswwds_18_tfpropostaassinaturastatus_sels = new GxSimpleCollection<string>();
         AV43Display = "";
         A632ReembolsoAssinaturasNome = "";
         A633ReembolsoAssinaturasEmissao = (DateTime)(DateTime.MinValue);
         A574PropostaAssinaturaStatus = "";
         GXDecQS = "";
         lV50Reembolsoassinaturaswwds_2_filterfulltext = "";
         lV53Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1 = "";
         lV57Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2 = "";
         lV61Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3 = "";
         lV62Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome = "";
         H007T2_A574PropostaAssinaturaStatus = new string[] {""} ;
         H007T2_n574PropostaAssinaturaStatus = new bool[] {false} ;
         H007T2_A633ReembolsoAssinaturasEmissao = new DateTime[] {DateTime.MinValue} ;
         H007T2_n633ReembolsoAssinaturasEmissao = new bool[] {false} ;
         H007T2_A632ReembolsoAssinaturasNome = new string[] {""} ;
         H007T2_n632ReembolsoAssinaturasNome = new bool[] {false} ;
         H007T2_A571PropostaAssinatura = new long[1] ;
         H007T2_n571PropostaAssinatura = new bool[] {false} ;
         H007T2_A572PropostaContratoAssinaturaId = new int[1] ;
         H007T2_n572PropostaContratoAssinaturaId = new bool[] {false} ;
         H007T2_A518ReembolsoId = new int[1] ;
         H007T2_n518ReembolsoId = new bool[] {false} ;
         H007T2_A631ReembolsoAssinaturasId = new int[1] ;
         H007T3_AGRID_nRecordCount = new long[1] ;
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV33ManageFiltersXml = "";
         AV29ExcelFilename = "";
         AV30ErrorMessage = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV31Session = context.GetSession();
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         GXt_char4 = "";
         AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV48AuxText = "";
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         AV9TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         imgRemovedynamicfilters3_gximage = "";
         sImgUrl = "";
         imgAdddynamicfilters2_gximage = "";
         imgRemovedynamicfilters2_gximage = "";
         imgAdddynamicfilters1_gximage = "";
         imgRemovedynamicfilters1_gximage = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV44PropostaId = "";
         sCtrlAV45ReembolsoId = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reembolsoassinaturasww__default(),
            new Object[][] {
                new Object[] {
               H007T2_A574PropostaAssinaturaStatus, H007T2_n574PropostaAssinaturaStatus, H007T2_A633ReembolsoAssinaturasEmissao, H007T2_n633ReembolsoAssinaturasEmissao, H007T2_A632ReembolsoAssinaturasNome, H007T2_n632ReembolsoAssinaturasNome, H007T2_A571PropostaAssinatura, H007T2_n571PropostaAssinatura, H007T2_A572PropostaContratoAssinaturaId, H007T2_n572PropostaContratoAssinaturaId,
               H007T2_A518ReembolsoId, H007T2_n518ReembolsoId, H007T2_A631ReembolsoAssinaturasId
               }
               , new Object[] {
               H007T3_AGRID_nRecordCount
               }
            }
         );
         AV67Pgmname = "ReembolsoAssinaturasWW";
         /* GeneXus formulas. */
         AV67Pgmname = "ReembolsoAssinaturasWW";
         edtavDisplay_Enabled = 0;
      }

      private short GRID_nEOF ;
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
      private short AV52Reembolsoassinaturaswwds_4_dynamicfiltersoperator1 ;
      private short AV56Reembolsoassinaturaswwds_8_dynamicfiltersoperator2 ;
      private short AV60Reembolsoassinaturaswwds_12_dynamicfiltersoperator3 ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int AV44PropostaId ;
      private int AV45ReembolsoId ;
      private int wcpOAV44PropostaId ;
      private int wcpOAV45ReembolsoId ;
      private int subGrid_Rows ;
      private int nRC_GXsfl_104 ;
      private int nGXsfl_104_idx=1 ;
      private int edtavDisplay_Enabled ;
      private int edtavFilterfulltext_Enabled ;
      private int AV49Reembolsoassinaturaswwds_1_reembolsoid ;
      private int A631ReembolsoAssinaturasId ;
      private int A518ReembolsoId ;
      private int A572PropostaContratoAssinaturaId ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV66Reembolsoassinaturaswwds_18_tfpropostaassinaturastatus_sels_Count ;
      private int edtReembolsoAssinaturasId_Enabled ;
      private int edtReembolsoId_Enabled ;
      private int edtPropostaContratoAssinaturaId_Enabled ;
      private int edtPropostaAssinatura_Enabled ;
      private int edtReembolsoAssinaturasNome_Enabled ;
      private int edtReembolsoAssinaturasEmissao_Enabled ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavReembolsoassinaturasnome1_Visible ;
      private int edtavReembolsoassinaturasnome2_Visible ;
      private int edtavReembolsoassinaturasnome3_Visible ;
      private int AV68GXV1 ;
      private int edtavReembolsoassinaturasnome3_Enabled ;
      private int edtavReembolsoassinaturasnome2_Enabled ;
      private int edtavReembolsoassinaturasnome1_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long A571PropostaAssinatura ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_104_idx="0001" ;
      private string AV67Pgmname ;
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
      private string Ddo_grid_Allowmultipleselection ;
      private string Ddo_grid_Datalistfixedvalues ;
      private string Ddo_grid_Datalistproc ;
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
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
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
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string lblJsdynamicfilters_Internalname ;
      private string lblJsdynamicfilters_Caption ;
      private string lblJsdynamicfilters_Jsonclick ;
      private string Ddo_grid_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDdo_reembolsoassinaturasemissaoauxdates_Internalname ;
      private string edtavDdo_reembolsoassinaturasemissaoauxdatetext_Internalname ;
      private string edtavDdo_reembolsoassinaturasemissaoauxdatetext_Jsonclick ;
      private string Tfreembolsoassinaturasemissao_rangepicker_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV43Display ;
      private string edtReembolsoAssinaturasId_Internalname ;
      private string edtReembolsoId_Internalname ;
      private string edtPropostaContratoAssinaturaId_Internalname ;
      private string edtPropostaAssinatura_Internalname ;
      private string edtReembolsoAssinaturasNome_Internalname ;
      private string edtReembolsoAssinaturasEmissao_Internalname ;
      private string cmbPropostaAssinaturaStatus_Internalname ;
      private string GXDecQS ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string edtavReembolsoassinaturasnome1_Internalname ;
      private string edtavReembolsoassinaturasnome2_Internalname ;
      private string edtavReembolsoassinaturasnome3_Internalname ;
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
      private string cmbPropostaAssinaturaStatus_Columnheaderclass ;
      private string edtavDisplay_Link ;
      private string edtReembolsoAssinaturasNome_Link ;
      private string cmbPropostaAssinaturaStatus_Columnclass ;
      private string GXt_char2 ;
      private string GXt_char4 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_reembolsoassinaturasnome3_cell_Internalname ;
      private string edtavReembolsoassinaturasnome3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_reembolsoassinaturasnome2_cell_Internalname ;
      private string edtavReembolsoassinaturasnome2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_reembolsoassinaturasnome1_cell_Internalname ;
      private string edtavReembolsoassinaturasnome1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string sCtrlAV44PropostaId ;
      private string sCtrlAV45ReembolsoId ;
      private string sGXsfl_104_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavDisplay_Jsonclick ;
      private string edtReembolsoAssinaturasId_Jsonclick ;
      private string edtReembolsoId_Jsonclick ;
      private string edtPropostaContratoAssinaturaId_Jsonclick ;
      private string edtPropostaAssinatura_Jsonclick ;
      private string edtReembolsoAssinaturasNome_Jsonclick ;
      private string edtReembolsoAssinaturasEmissao_Jsonclick ;
      private string GXCCtl ;
      private string cmbPropostaAssinaturaStatus_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV37TFReembolsoAssinaturasEmissao ;
      private DateTime AV38TFReembolsoAssinaturasEmissao_To ;
      private DateTime AV64Reembolsoassinaturaswwds_16_tfreembolsoassinaturasemissao ;
      private DateTime AV65Reembolsoassinaturaswwds_17_tfreembolsoassinaturasemissao_to ;
      private DateTime A633ReembolsoAssinaturasEmissao ;
      private DateTime AV39DDO_ReembolsoAssinaturasEmissaoAuxDate ;
      private DateTime AV40DDO_ReembolsoAssinaturasEmissaoAuxDateTo ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV19DynamicFiltersEnabled2 ;
      private bool AV23DynamicFiltersEnabled3 ;
      private bool AV28DynamicFiltersIgnoreFirst ;
      private bool AV27DynamicFiltersRemoving ;
      private bool bGXsfl_104_Refreshing=false ;
      private bool Dvpanel_tableheader_Autowidth ;
      private bool Dvpanel_tableheader_Autoheight ;
      private bool Dvpanel_tableheader_Collapsible ;
      private bool Dvpanel_tableheader_Collapsed ;
      private bool Dvpanel_tableheader_Showcollapseicon ;
      private bool Dvpanel_tableheader_Autoscroll ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool AV54Reembolsoassinaturaswwds_6_dynamicfiltersenabled2 ;
      private bool AV58Reembolsoassinaturaswwds_10_dynamicfiltersenabled3 ;
      private bool n518ReembolsoId ;
      private bool n572PropostaContratoAssinaturaId ;
      private bool n571PropostaAssinatura ;
      private bool n632ReembolsoAssinaturasNome ;
      private bool n633ReembolsoAssinaturasEmissao ;
      private bool n574PropostaAssinaturaStatus ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV46TFPropostaAssinaturaStatus_SelsJson ;
      private string AV33ManageFiltersXml ;
      private string AV15FilterFullText ;
      private string AV16DynamicFiltersSelector1 ;
      private string AV18ReembolsoAssinaturasNome1 ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV22ReembolsoAssinaturasNome2 ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV26ReembolsoAssinaturasNome3 ;
      private string AV35TFReembolsoAssinaturasNome ;
      private string AV36TFReembolsoAssinaturasNome_Sel ;
      private string AV41DDO_ReembolsoAssinaturasEmissaoAuxDateText ;
      private string AV50Reembolsoassinaturaswwds_2_filterfulltext ;
      private string AV51Reembolsoassinaturaswwds_3_dynamicfiltersselector1 ;
      private string AV53Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1 ;
      private string AV55Reembolsoassinaturaswwds_7_dynamicfiltersselector2 ;
      private string AV57Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2 ;
      private string AV59Reembolsoassinaturaswwds_11_dynamicfiltersselector3 ;
      private string AV61Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3 ;
      private string AV62Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome ;
      private string AV63Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel ;
      private string A632ReembolsoAssinaturasNome ;
      private string A574PropostaAssinaturaStatus ;
      private string lV50Reembolsoassinaturaswwds_2_filterfulltext ;
      private string lV53Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1 ;
      private string lV57Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2 ;
      private string lV61Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3 ;
      private string lV62Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome ;
      private string AV29ExcelFilename ;
      private string AV30ErrorMessage ;
      private string AV48AuxText ;
      private IGxSession AV31Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfreembolsoassinaturasemissao_rangepicker ;
      private GXWebForm Form ;
      private GxHttpRequest AV7HTTPRequest ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCombobox cmbPropostaAssinaturaStatus ;
      private GxSimpleCollection<string> AV47TFPropostaAssinaturaStatus_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV32ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV42DDO_TitleSettingsIcons ;
      private GxSimpleCollection<string> AV66Reembolsoassinaturaswwds_18_tfpropostaassinaturastatus_sels ;
      private IDataStoreProvider pr_default ;
      private string[] H007T2_A574PropostaAssinaturaStatus ;
      private bool[] H007T2_n574PropostaAssinaturaStatus ;
      private DateTime[] H007T2_A633ReembolsoAssinaturasEmissao ;
      private bool[] H007T2_n633ReembolsoAssinaturasEmissao ;
      private string[] H007T2_A632ReembolsoAssinaturasNome ;
      private bool[] H007T2_n632ReembolsoAssinaturasNome ;
      private long[] H007T2_A571PropostaAssinatura ;
      private bool[] H007T2_n571PropostaAssinatura ;
      private int[] H007T2_A572PropostaContratoAssinaturaId ;
      private bool[] H007T2_n572PropostaContratoAssinaturaId ;
      private int[] H007T2_A518ReembolsoId ;
      private bool[] H007T2_n518ReembolsoId ;
      private int[] H007T2_A631ReembolsoAssinaturasId ;
      private long[] H007T3_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV12GridStateDynamicFilter ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV9TrnContextAtt ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class reembolsoassinaturasww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H007T2( IGxContext context ,
                                             string A574PropostaAssinaturaStatus ,
                                             GxSimpleCollection<string> AV66Reembolsoassinaturaswwds_18_tfpropostaassinaturastatus_sels ,
                                             string AV50Reembolsoassinaturaswwds_2_filterfulltext ,
                                             string AV51Reembolsoassinaturaswwds_3_dynamicfiltersselector1 ,
                                             short AV52Reembolsoassinaturaswwds_4_dynamicfiltersoperator1 ,
                                             string AV53Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1 ,
                                             bool AV54Reembolsoassinaturaswwds_6_dynamicfiltersenabled2 ,
                                             string AV55Reembolsoassinaturaswwds_7_dynamicfiltersselector2 ,
                                             short AV56Reembolsoassinaturaswwds_8_dynamicfiltersoperator2 ,
                                             string AV57Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2 ,
                                             bool AV58Reembolsoassinaturaswwds_10_dynamicfiltersenabled3 ,
                                             string AV59Reembolsoassinaturaswwds_11_dynamicfiltersselector3 ,
                                             short AV60Reembolsoassinaturaswwds_12_dynamicfiltersoperator3 ,
                                             string AV61Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3 ,
                                             string AV63Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel ,
                                             string AV62Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome ,
                                             DateTime AV64Reembolsoassinaturaswwds_16_tfreembolsoassinaturasemissao ,
                                             DateTime AV65Reembolsoassinaturaswwds_17_tfreembolsoassinaturasemissao_to ,
                                             int AV66Reembolsoassinaturaswwds_18_tfpropostaassinaturastatus_sels_Count ,
                                             string A632ReembolsoAssinaturasNome ,
                                             DateTime A633ReembolsoAssinaturasEmissao ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             int A518ReembolsoId ,
                                             int AV49Reembolsoassinaturaswwds_1_reembolsoid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[20];
         Object[] GXv_Object6 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T3.AssinaturaStatus AS PropostaAssinaturaStatus, T1.ReembolsoAssinaturasEmissao, T1.ReembolsoAssinaturasNome, T2.PropostaAssinatura AS PropostaAssinatura, T1.PropostaContratoAssinaturaId, T1.ReembolsoId, T1.ReembolsoAssinaturasId";
         sFromString = " FROM ((ReembolsoAssinaturas T1 LEFT JOIN PropostaContratoAssinatura T2 ON T2.PropostaContratoAssinaturaId = T1.PropostaContratoAssinaturaId) LEFT JOIN Assinatura T3 ON T3.AssinaturaId = T2.PropostaAssinatura)";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.ReembolsoId = :AV49Reembolsoassinaturaswwds_1_reembolsoid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Reembolsoassinaturaswwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.ReembolsoAssinaturasNome like '%' || :lV50Reembolsoassinaturaswwds_2_filterfulltext) or ( 'enviado' like '%' || LOWER(:lV50Reembolsoassinaturaswwds_2_filterfulltext) and T3.AssinaturaStatus = ( 'ENVIADO')) or ( 'rejeitado' like '%' || LOWER(:lV50Reembolsoassinaturaswwds_2_filterfulltext) and T3.AssinaturaStatus = ( 'REJEITADO')) or ( 'cancelado' like '%' || LOWER(:lV50Reembolsoassinaturaswwds_2_filterfulltext) and T3.AssinaturaStatus = ( 'CANCELADO')) or ( 'assinado' like '%' || LOWER(:lV50Reembolsoassinaturaswwds_2_filterfulltext) and T3.AssinaturaStatus = ( 'ASSINADO')) or ( 'aguardando envio' like '%' || LOWER(:lV50Reembolsoassinaturaswwds_2_filterfulltext) and T3.AssinaturaStatus = ( 'AGUARDANDO_ENVIO')))");
         }
         else
         {
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
            GXv_int5[5] = 1;
            GXv_int5[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV51Reembolsoassinaturaswwds_3_dynamicfiltersselector1, "REEMBOLSOASSINATURASNOME") == 0 ) && ( AV52Reembolsoassinaturaswwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1)) ) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoAssinaturasNome like :lV53Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV51Reembolsoassinaturaswwds_3_dynamicfiltersselector1, "REEMBOLSOASSINATURASNOME") == 0 ) && ( AV52Reembolsoassinaturaswwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1)) ) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoAssinaturasNome like '%' || :lV53Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( AV54Reembolsoassinaturaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Reembolsoassinaturaswwds_7_dynamicfiltersselector2, "REEMBOLSOASSINATURASNOME") == 0 ) && ( AV56Reembolsoassinaturaswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2)) ) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoAssinaturasNome like :lV57Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( AV54Reembolsoassinaturaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Reembolsoassinaturaswwds_7_dynamicfiltersselector2, "REEMBOLSOASSINATURASNOME") == 0 ) && ( AV56Reembolsoassinaturaswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2)) ) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoAssinaturasNome like '%' || :lV57Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( AV58Reembolsoassinaturaswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Reembolsoassinaturaswwds_11_dynamicfiltersselector3, "REEMBOLSOASSINATURASNOME") == 0 ) && ( AV60Reembolsoassinaturaswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3)) ) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoAssinaturasNome like :lV61Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( AV58Reembolsoassinaturaswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Reembolsoassinaturaswwds_11_dynamicfiltersselector3, "REEMBOLSOASSINATURASNOME") == 0 ) && ( AV60Reembolsoassinaturaswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3)) ) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoAssinaturasNome like '%' || :lV61Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome)) ) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoAssinaturasNome like :lV62Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel)) && ! ( StringUtil.StrCmp(AV63Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoAssinaturasNome = ( :AV63Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel))");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( StringUtil.StrCmp(AV63Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ReembolsoAssinaturasNome IS NULL or (char_length(trim(trailing ' ' from T1.ReembolsoAssinaturasNome))=0))");
         }
         if ( ! (DateTime.MinValue==AV64Reembolsoassinaturaswwds_16_tfreembolsoassinaturasemissao) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoAssinaturasEmissao >= :AV64Reembolsoassinaturaswwds_16_tfreembolsoassinaturasemissao)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV65Reembolsoassinaturaswwds_17_tfreembolsoassinaturasemissao_to) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoAssinaturasEmissao <= :AV65Reembolsoassinaturaswwds_17_tfreembolsoassinaturasemissao_t)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( AV66Reembolsoassinaturaswwds_18_tfpropostaassinaturastatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV66Reembolsoassinaturaswwds_18_tfpropostaassinaturastatus_sels, "T3.AssinaturaStatus IN (", ")")+")");
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ReembolsoId, T1.ReembolsoAssinaturasEmissao, T1.ReembolsoAssinaturasId";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ReembolsoId DESC, T1.ReembolsoAssinaturasEmissao DESC, T1.ReembolsoAssinaturasId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ReembolsoId, T1.ReembolsoAssinaturasNome, T1.ReembolsoAssinaturasId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ReembolsoId DESC, T1.ReembolsoAssinaturasNome DESC, T1.ReembolsoAssinaturasId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ReembolsoId, T3.AssinaturaStatus, T1.ReembolsoAssinaturasId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ReembolsoId DESC, T3.AssinaturaStatus DESC, T1.ReembolsoAssinaturasId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.ReembolsoAssinaturasId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_H007T3( IGxContext context ,
                                             string A574PropostaAssinaturaStatus ,
                                             GxSimpleCollection<string> AV66Reembolsoassinaturaswwds_18_tfpropostaassinaturastatus_sels ,
                                             string AV50Reembolsoassinaturaswwds_2_filterfulltext ,
                                             string AV51Reembolsoassinaturaswwds_3_dynamicfiltersselector1 ,
                                             short AV52Reembolsoassinaturaswwds_4_dynamicfiltersoperator1 ,
                                             string AV53Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1 ,
                                             bool AV54Reembolsoassinaturaswwds_6_dynamicfiltersenabled2 ,
                                             string AV55Reembolsoassinaturaswwds_7_dynamicfiltersselector2 ,
                                             short AV56Reembolsoassinaturaswwds_8_dynamicfiltersoperator2 ,
                                             string AV57Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2 ,
                                             bool AV58Reembolsoassinaturaswwds_10_dynamicfiltersenabled3 ,
                                             string AV59Reembolsoassinaturaswwds_11_dynamicfiltersselector3 ,
                                             short AV60Reembolsoassinaturaswwds_12_dynamicfiltersoperator3 ,
                                             string AV61Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3 ,
                                             string AV63Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel ,
                                             string AV62Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome ,
                                             DateTime AV64Reembolsoassinaturaswwds_16_tfreembolsoassinaturasemissao ,
                                             DateTime AV65Reembolsoassinaturaswwds_17_tfreembolsoassinaturasemissao_to ,
                                             int AV66Reembolsoassinaturaswwds_18_tfpropostaassinaturastatus_sels_Count ,
                                             string A632ReembolsoAssinaturasNome ,
                                             DateTime A633ReembolsoAssinaturasEmissao ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             int A518ReembolsoId ,
                                             int AV49Reembolsoassinaturaswwds_1_reembolsoid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[17];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ((ReembolsoAssinaturas T1 LEFT JOIN PropostaContratoAssinatura T2 ON T2.PropostaContratoAssinaturaId = T1.PropostaContratoAssinaturaId) LEFT JOIN Assinatura T3 ON T3.AssinaturaId = T2.PropostaAssinatura)";
         AddWhere(sWhereString, "(T1.ReembolsoId = :AV49Reembolsoassinaturaswwds_1_reembolsoid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Reembolsoassinaturaswwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.ReembolsoAssinaturasNome like '%' || :lV50Reembolsoassinaturaswwds_2_filterfulltext) or ( 'enviado' like '%' || LOWER(:lV50Reembolsoassinaturaswwds_2_filterfulltext) and T3.AssinaturaStatus = ( 'ENVIADO')) or ( 'rejeitado' like '%' || LOWER(:lV50Reembolsoassinaturaswwds_2_filterfulltext) and T3.AssinaturaStatus = ( 'REJEITADO')) or ( 'cancelado' like '%' || LOWER(:lV50Reembolsoassinaturaswwds_2_filterfulltext) and T3.AssinaturaStatus = ( 'CANCELADO')) or ( 'assinado' like '%' || LOWER(:lV50Reembolsoassinaturaswwds_2_filterfulltext) and T3.AssinaturaStatus = ( 'ASSINADO')) or ( 'aguardando envio' like '%' || LOWER(:lV50Reembolsoassinaturaswwds_2_filterfulltext) and T3.AssinaturaStatus = ( 'AGUARDANDO_ENVIO')))");
         }
         else
         {
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
            GXv_int7[4] = 1;
            GXv_int7[5] = 1;
            GXv_int7[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV51Reembolsoassinaturaswwds_3_dynamicfiltersselector1, "REEMBOLSOASSINATURASNOME") == 0 ) && ( AV52Reembolsoassinaturaswwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1)) ) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoAssinaturasNome like :lV53Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV51Reembolsoassinaturaswwds_3_dynamicfiltersselector1, "REEMBOLSOASSINATURASNOME") == 0 ) && ( AV52Reembolsoassinaturaswwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1)) ) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoAssinaturasNome like '%' || :lV53Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( AV54Reembolsoassinaturaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Reembolsoassinaturaswwds_7_dynamicfiltersselector2, "REEMBOLSOASSINATURASNOME") == 0 ) && ( AV56Reembolsoassinaturaswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2)) ) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoAssinaturasNome like :lV57Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( AV54Reembolsoassinaturaswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Reembolsoassinaturaswwds_7_dynamicfiltersselector2, "REEMBOLSOASSINATURASNOME") == 0 ) && ( AV56Reembolsoassinaturaswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2)) ) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoAssinaturasNome like '%' || :lV57Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( AV58Reembolsoassinaturaswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Reembolsoassinaturaswwds_11_dynamicfiltersselector3, "REEMBOLSOASSINATURASNOME") == 0 ) && ( AV60Reembolsoassinaturaswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3)) ) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoAssinaturasNome like :lV61Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( AV58Reembolsoassinaturaswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Reembolsoassinaturaswwds_11_dynamicfiltersselector3, "REEMBOLSOASSINATURASNOME") == 0 ) && ( AV60Reembolsoassinaturaswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3)) ) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoAssinaturasNome like '%' || :lV61Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome)) ) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoAssinaturasNome like :lV62Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel)) && ! ( StringUtil.StrCmp(AV63Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoAssinaturasNome = ( :AV63Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel))");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( StringUtil.StrCmp(AV63Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ReembolsoAssinaturasNome IS NULL or (char_length(trim(trailing ' ' from T1.ReembolsoAssinaturasNome))=0))");
         }
         if ( ! (DateTime.MinValue==AV64Reembolsoassinaturaswwds_16_tfreembolsoassinaturasemissao) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoAssinaturasEmissao >= :AV64Reembolsoassinaturaswwds_16_tfreembolsoassinaturasemissao)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV65Reembolsoassinaturaswwds_17_tfreembolsoassinaturasemissao_to) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoAssinaturasEmissao <= :AV65Reembolsoassinaturaswwds_17_tfreembolsoassinaturasemissao_t)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( AV66Reembolsoassinaturaswwds_18_tfpropostaassinaturastatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV66Reembolsoassinaturaswwds_18_tfpropostaassinaturastatus_sels, "T3.AssinaturaStatus IN (", ")")+")");
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
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H007T2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (int)dynConstraints[18] , (string)dynConstraints[19] , (DateTime)dynConstraints[20] , (short)dynConstraints[21] , (bool)dynConstraints[22] , (int)dynConstraints[23] , (int)dynConstraints[24] );
               case 1 :
                     return conditional_H007T3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (int)dynConstraints[18] , (string)dynConstraints[19] , (DateTime)dynConstraints[20] , (short)dynConstraints[21] , (bool)dynConstraints[22] , (int)dynConstraints[23] , (int)dynConstraints[24] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmH007T2;
          prmH007T2 = new Object[] {
          new ParDef("AV49Reembolsoassinaturaswwds_1_reembolsoid",GXType.Int32,9,0) ,
          new ParDef("lV50Reembolsoassinaturaswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Reembolsoassinaturaswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Reembolsoassinaturaswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Reembolsoassinaturaswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Reembolsoassinaturaswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Reembolsoassinaturaswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1",GXType.VarChar,100,0) ,
          new ParDef("lV53Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1",GXType.VarChar,100,0) ,
          new ParDef("lV57Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2",GXType.VarChar,100,0) ,
          new ParDef("lV57Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2",GXType.VarChar,100,0) ,
          new ParDef("lV61Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3",GXType.VarChar,100,0) ,
          new ParDef("lV61Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3",GXType.VarChar,100,0) ,
          new ParDef("lV62Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome",GXType.VarChar,100,0) ,
          new ParDef("AV63Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel",GXType.VarChar,100,0) ,
          new ParDef("AV64Reembolsoassinaturaswwds_16_tfreembolsoassinaturasemissao",GXType.DateTime,8,5) ,
          new ParDef("AV65Reembolsoassinaturaswwds_17_tfreembolsoassinaturasemissao_t",GXType.DateTime,8,5) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH007T3;
          prmH007T3 = new Object[] {
          new ParDef("AV49Reembolsoassinaturaswwds_1_reembolsoid",GXType.Int32,9,0) ,
          new ParDef("lV50Reembolsoassinaturaswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Reembolsoassinaturaswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Reembolsoassinaturaswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Reembolsoassinaturaswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Reembolsoassinaturaswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Reembolsoassinaturaswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1",GXType.VarChar,100,0) ,
          new ParDef("lV53Reembolsoassinaturaswwds_5_reembolsoassinaturasnome1",GXType.VarChar,100,0) ,
          new ParDef("lV57Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2",GXType.VarChar,100,0) ,
          new ParDef("lV57Reembolsoassinaturaswwds_9_reembolsoassinaturasnome2",GXType.VarChar,100,0) ,
          new ParDef("lV61Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3",GXType.VarChar,100,0) ,
          new ParDef("lV61Reembolsoassinaturaswwds_13_reembolsoassinaturasnome3",GXType.VarChar,100,0) ,
          new ParDef("lV62Reembolsoassinaturaswwds_14_tfreembolsoassinaturasnome",GXType.VarChar,100,0) ,
          new ParDef("AV63Reembolsoassinaturaswwds_15_tfreembolsoassinaturasnome_sel",GXType.VarChar,100,0) ,
          new ParDef("AV64Reembolsoassinaturaswwds_16_tfreembolsoassinaturasemissao",GXType.DateTime,8,5) ,
          new ParDef("AV65Reembolsoassinaturaswwds_17_tfreembolsoassinaturasemissao_t",GXType.DateTime,8,5)
          };
          def= new CursorDef[] {
              new CursorDef("H007T2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007T2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H007T3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007T3,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((long[]) buf[6])[0] = rslt.getLong(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
