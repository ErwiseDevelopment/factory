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
   public class contratoww : GXDataArea
   {
      public contratoww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public contratoww( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_ContratoClienteId )
      {
         this.AV50ContratoClienteId = aP0_ContratoClienteId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavDynamicfiltersselector1 = new GXCombobox();
         cmbavDynamicfiltersoperator1 = new GXCombobox();
         cmbavDynamicfiltersselector2 = new GXCombobox();
         cmbavDynamicfiltersoperator2 = new GXCombobox();
         cmbavDynamicfiltersselector3 = new GXCombobox();
         cmbavDynamicfiltersoperator3 = new GXCombobox();
         cmbContratoClienteTipoPessoa = new GXCombobox();
         cmbContratoSituacao = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "ContratoClienteId");
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
               gxfirstwebparm = GetFirstPar( "ContratoClienteId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "ContratoClienteId");
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
         nRC_GXsfl_119 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_119"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_119_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_119_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_119_idx = GetPar( "sGXsfl_119_idx");
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
         AV45OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV13OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV14FilterFullText = GetPar( "FilterFullText");
         cmbavDynamicfiltersselector1.FromJSonString( GetNextPar( ));
         AV15DynamicFiltersSelector1 = GetPar( "DynamicFiltersSelector1");
         cmbavDynamicfiltersoperator1.FromJSonString( GetNextPar( ));
         AV16DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator1"), "."), 18, MidpointRounding.ToEven));
         AV17ContratoNome1 = GetPar( "ContratoNome1");
         AV54ContratoClienteDocumento1 = GetPar( "ContratoClienteDocumento1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV19DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV20DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV21ContratoNome2 = GetPar( "ContratoNome2");
         AV55ContratoClienteDocumento2 = GetPar( "ContratoClienteDocumento2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV23DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV24DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV25ContratoNome3 = GetPar( "ContratoNome3");
         AV56ContratoClienteDocumento3 = GetPar( "ContratoClienteDocumento3");
         AV33ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV18DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV22DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV57Pgmname = GetPar( "Pgmname");
         AV50ContratoClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "ContratoClienteId"), "."), 18, MidpointRounding.ToEven));
         AV34TFContratoNome = GetPar( "TFContratoNome");
         AV35TFContratoNome_Sel = GetPar( "TFContratoNome_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV47TFContratoSituacao_Sels);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridState);
         AV27DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV26DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV53Cliente);
         A473ContratoClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "ContratoClienteId"), "."), 18, MidpointRounding.ToEven));
         n473ContratoClienteId = false;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV45OrderedBy, AV13OrderedDsc, AV14FilterFullText, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17ContratoNome1, AV54ContratoClienteDocumento1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21ContratoNome2, AV55ContratoClienteDocumento2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25ContratoNome3, AV56ContratoClienteDocumento3, AV33ManageFiltersExecutionStep, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV57Pgmname, AV50ContratoClienteId, AV34TFContratoNome, AV35TFContratoNome_Sel, AV47TFContratoSituacao_Sels, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, AV53Cliente, A473ContratoClienteId) ;
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
         PA4F2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START4F2( ) ;
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
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
         GXEncryptionTmp = "contratoww"+UrlEncode(StringUtil.LTrimStr(AV50ContratoClienteId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("contratoww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV57Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV57Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vCONTRATOCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV50ContratoClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCONTRATOCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV50ContratoClienteId), "ZZZZZZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCLIENTE", AV53Cliente);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCLIENTE", AV53Cliente);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTE", GetSecureSignedToken( "", AV53Cliente, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"ContratoWW");
         forbiddenHiddens.Add("ContratoClienteId", context.localUtil.Format( (decimal)(A473ContratoClienteId), "ZZZZZZZZ9"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("contratoww:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV45OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV13OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV14FilterFullText);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV15DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16DynamicFiltersOperator1), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCONTRATONOME1", AV17ContratoNome1);
         GxWebStd.gx_hidden_field( context, "GXH_vCONTRATOCLIENTEDOCUMENTO1", AV54ContratoClienteDocumento1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV19DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCONTRATONOME2", AV21ContratoNome2);
         GxWebStd.gx_hidden_field( context, "GXH_vCONTRATOCLIENTEDOCUMENTO2", AV55ContratoClienteDocumento2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV23DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCONTRATONOME3", AV25ContratoNome3);
         GxWebStd.gx_hidden_field( context, "GXH_vCONTRATOCLIENTEDOCUMENTO3", AV56ContratoClienteDocumento3);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_119", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_119), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV31ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV31ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV38GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV40GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV36DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV36DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV18DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV22DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV57Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV57Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vCONTRATOCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV50ContratoClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCONTRATOCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV50ContratoClienteId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTFCONTRATONOME", AV34TFContratoNome);
         GxWebStd.gx_hidden_field( context, "vTFCONTRATONOME_SEL", AV35TFContratoNome_Sel);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFCONTRATOSITUACAO_SELS", AV47TFContratoSituacao_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFCONTRATOSITUACAO_SELS", AV47TFContratoSituacao_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV45OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV13OrderedDsc);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV10GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV10GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV27DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV26DynamicFiltersRemoving);
         GxWebStd.gx_hidden_field( context, "vTFCONTRATOSITUACAO_SELSJSON", AV46TFContratoSituacao_SelsJson);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCLIENTE", AV53Cliente);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCLIENTE", AV53Cliente);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTE", GetSecureSignedToken( "", AV53Cliente, context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icontype", StringUtil.RTrim( Ddo_managefilters_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icon", StringUtil.RTrim( Ddo_managefilters_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Tooltip", StringUtil.RTrim( Ddo_managefilters_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Cls", StringUtil.RTrim( Ddo_managefilters_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Width", StringUtil.RTrim( Dvpanel_tableheader_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Autowidth", StringUtil.BoolToStr( Dvpanel_tableheader_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Autoheight", StringUtil.BoolToStr( Dvpanel_tableheader_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Cls", StringUtil.RTrim( Dvpanel_tableheader_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Title", StringUtil.RTrim( Dvpanel_tableheader_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Collapsible", StringUtil.BoolToStr( Dvpanel_tableheader_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Collapsed", StringUtil.BoolToStr( Dvpanel_tableheader_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableheader_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Iconposition", StringUtil.RTrim( Dvpanel_tableheader_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableheader_Autoscroll));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Class", StringUtil.RTrim( Gridpaginationbar_Class));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridpaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridpaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridpaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridpaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridpaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridpaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridpaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridpaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridpaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Previous", StringUtil.RTrim( Gridpaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Next", StringUtil.RTrim( Gridpaginationbar_Next));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Caption", StringUtil.RTrim( Gridpaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridpaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridpaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Allowmultipleselection", StringUtil.RTrim( Ddo_grid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistfixedvalues", StringUtil.RTrim( Ddo_grid_Datalistfixedvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Fixedcolumns", StringUtil.RTrim( Grid_empowerer_Fixedcolumns));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
            WE4F2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT4F2( ) ;
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
         GXEncryptionTmp = "contratoww"+UrlEncode(StringUtil.LTrimStr(AV50ContratoClienteId,9,0));
         return formatLink("contratoww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "ContratoWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Contrato" ;
      }

      protected void WB4F0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(119), 3, 0)+","+"null"+");", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ContratoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            ucDvpanel_tableheader.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableheader_Internalname, "DVPANEL_TABLEHEADERContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEHEADERContainer"+"TableHeader"+"\" style=\"display:none;\">") ;
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
            ClassString = "Button ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(119), 3, 0)+","+"null"+");", "Inserir", bttBtninsert_Jsonclick, 5, "Inserir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ContratoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
            ClassString = "ButtonExcel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(119), 3, 0)+","+"null"+");", "Excel", bttBtnexport_Jsonclick, 5, "Exportar para Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ContratoWW.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV31ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, "DDO_MANAGEFILTERSContainer");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV14FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV14FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_ContratoWW.htm");
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_ContratoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'" + sGXsfl_119_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV15DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "", true, 0, "HLP_ContratoWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_ContratoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_48_4F2( true) ;
         }
         else
         {
            wb_table1_48_4F2( false) ;
         }
         return  ;
      }

      protected void wb_table1_48_4F2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_ContratoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'" + sGXsfl_119_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV19DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "", true, 0, "HLP_ContratoWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_ContratoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_73_4F2( true) ;
         }
         else
         {
            wb_table2_73_4F2( false) ;
         }
         return  ;
      }

      protected void wb_table2_73_4F2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_ContratoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'" + sGXsfl_119_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV23DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,94);\"", "", true, 0, "HLP_ContratoWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_ContratoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_98_4F2( true) ;
         }
         else
         {
            wb_table3_98_4F2( false) ;
         }
         return  ;
      }

      protected void wb_table3_98_4F2e( bool wbgen )
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
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
            StartGridControl119( ) ;
         }
         if ( wbEnd == 119 )
         {
            wbEnd = 0;
            nRC_GXsfl_119 = (int)(nGXsfl_119_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV38GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV39GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV40GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, "GRIDPAGINATIONBARContainer");
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
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_ContratoWW.htm");
            /* User Defined Control */
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("AllowMultipleSelection", Ddo_grid_Allowmultipleselection);
            ucDdo_grid.SetProperty("DataListFixedValues", Ddo_grid_Datalistfixedvalues);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV36DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtContratoClienteId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A473ContratoClienteId), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A473ContratoClienteId), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtContratoClienteId_Jsonclick, 0, "Attribute", "", "", "", "", edtContratoClienteId_Visible, 0, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ContratoWW.htm");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("FixedColumns", Grid_empowerer_Fixedcolumns);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 119 )
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

      protected void START4F2( )
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
         Form.Meta.addItem("description", " Contrato", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4F0( ) ;
      }

      protected void WS4F2( )
      {
         START4F2( ) ;
         EVT4F2( ) ;
      }

      protected void EVT4F2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "DDO_MANAGEFILTERS.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_managefilters.Onoptionclicked */
                              E114F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E124F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E134F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E144F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E154F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E164F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E174F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E184F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E194F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E204F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E214F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E224F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E234F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E244F2 ();
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
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) )
                           {
                              nGXsfl_119_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_119_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_119_idx), 4, 0), 4, "0");
                              SubsflControlProps_1192( ) ;
                              AV41Display = cgiGet( edtavDisplay_Internalname);
                              AssignAttri("", false, edtavDisplay_Internalname, AV41Display);
                              AV42Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV42Update);
                              AV51EnviarAssinatura = cgiGet( edtavEnviarassinatura_Internalname);
                              AssignAttri("", false, edtavEnviarassinatura_Internalname, AV51EnviarAssinatura);
                              AV52Assinatura = cgiGet( edtavAssinatura_Internalname);
                              AssignAttri("", false, edtavAssinatura_Internalname, AV52Assinatura);
                              A227ContratoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtContratoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n227ContratoId = false;
                              A228ContratoNome = cgiGet( edtContratoNome_Internalname);
                              n228ContratoNome = false;
                              A477ContratoClienteRepresentanteCPF = cgiGet( edtContratoClienteRepresentanteCPF_Internalname);
                              n477ContratoClienteRepresentanteCPF = false;
                              cmbContratoClienteTipoPessoa.Name = cmbContratoClienteTipoPessoa_Internalname;
                              cmbContratoClienteTipoPessoa.CurrentValue = cgiGet( cmbContratoClienteTipoPessoa_Internalname);
                              A561ContratoClienteTipoPessoa = cgiGet( cmbContratoClienteTipoPessoa_Internalname);
                              n561ContratoClienteTipoPessoa = false;
                              cmbContratoSituacao.Name = cmbContratoSituacao_Internalname;
                              cmbContratoSituacao.CurrentValue = cgiGet( cmbContratoSituacao_Internalname);
                              A471ContratoSituacao = cgiGet( cmbContratoSituacao_Internalname);
                              n471ContratoSituacao = false;
                              A483AssinaturaUltId_F = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtAssinaturaUltId_F_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n483AssinaturaUltId_F = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E254F2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E264F2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E274F2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV45OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV13OrderedDsc )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV14FilterFullText) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV15DynamicFiltersSelector1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator1 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV16DynamicFiltersOperator1 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Contratonome1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATONOME1"), AV17ContratoNome1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Contratoclientedocumento1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATOCLIENTEDOCUMENTO1"), AV54ContratoClienteDocumento1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV19DynamicFiltersSelector2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV20DynamicFiltersOperator2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Contratonome2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATONOME2"), AV21ContratoNome2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Contratoclientedocumento2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATOCLIENTEDOCUMENTO2"), AV55ContratoClienteDocumento2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV23DynamicFiltersSelector3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV24DynamicFiltersOperator3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Contratonome3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATONOME3"), AV25ContratoNome3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Contratoclientedocumento3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATOCLIENTEDOCUMENTO3"), AV56ContratoClienteDocumento3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
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

      protected void WE4F2( )
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

      protected void PA4F2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contratoww")), "contratoww") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contratoww")))) ;
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
                  gxfirstwebparm = GetFirstPar( "ContratoClienteId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV50ContratoClienteId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV50ContratoClienteId", StringUtil.LTrimStr( (decimal)(AV50ContratoClienteId), 9, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vCONTRATOCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV50ContratoClienteId), "ZZZZZZZZ9"), context));
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
               GX_FocusControl = edtavFilterfulltext_Internalname;
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
         SubsflControlProps_1192( ) ;
         while ( nGXsfl_119_idx <= nRC_GXsfl_119 )
         {
            sendrow_1192( ) ;
            nGXsfl_119_idx = ((subGrid_Islastpage==1)&&(nGXsfl_119_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_119_idx+1);
            sGXsfl_119_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_119_idx), 4, 0), 4, "0");
            SubsflControlProps_1192( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV45OrderedBy ,
                                       bool AV13OrderedDsc ,
                                       string AV14FilterFullText ,
                                       string AV15DynamicFiltersSelector1 ,
                                       short AV16DynamicFiltersOperator1 ,
                                       string AV17ContratoNome1 ,
                                       string AV54ContratoClienteDocumento1 ,
                                       string AV19DynamicFiltersSelector2 ,
                                       short AV20DynamicFiltersOperator2 ,
                                       string AV21ContratoNome2 ,
                                       string AV55ContratoClienteDocumento2 ,
                                       string AV23DynamicFiltersSelector3 ,
                                       short AV24DynamicFiltersOperator3 ,
                                       string AV25ContratoNome3 ,
                                       string AV56ContratoClienteDocumento3 ,
                                       short AV33ManageFiltersExecutionStep ,
                                       bool AV18DynamicFiltersEnabled2 ,
                                       bool AV22DynamicFiltersEnabled3 ,
                                       string AV57Pgmname ,
                                       int AV50ContratoClienteId ,
                                       string AV34TFContratoNome ,
                                       string AV35TFContratoNome_Sel ,
                                       GxSimpleCollection<string> AV47TFContratoSituacao_Sels ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV27DynamicFiltersIgnoreFirst ,
                                       bool AV26DynamicFiltersRemoving ,
                                       SdtCliente AV53Cliente ,
                                       int A473ContratoClienteId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF4F2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"ContratoWW");
         forbiddenHiddens.Add("ContratoClienteId", context.localUtil.Format( (decimal)(A473ContratoClienteId), "ZZZZZZZZ9"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("contratoww:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CONTRATOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A227ContratoId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "CONTRATOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", "")));
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
            AV15DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV15DynamicFiltersSelector1);
            AssignAttri("", false, "AV15DynamicFiltersSelector1", AV15DynamicFiltersSelector1);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV16DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV19DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV19DynamicFiltersSelector2);
            AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV20DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV20DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV23DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV23DynamicFiltersSelector3);
            AssignAttri("", false, "AV23DynamicFiltersSelector3", AV23DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV24DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF4F2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV57Pgmname = "ContratoWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavEnviarassinatura_Enabled = 0;
         edtavAssinatura_Enabled = 0;
      }

      protected void RF4F2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 119;
         /* Execute user event: Refresh */
         E264F2 ();
         nGXsfl_119_idx = 1;
         sGXsfl_119_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_119_idx), 4, 0), 4, "0");
         SubsflControlProps_1192( ) ;
         bGXsfl_119_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
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
            SubsflControlProps_1192( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A471ContratoSituacao ,
                                                 AV76Contratowwds_19_tfcontratosituacao_sels ,
                                                 AV59Contratowwds_2_filterfulltext ,
                                                 AV60Contratowwds_3_dynamicfiltersselector1 ,
                                                 AV61Contratowwds_4_dynamicfiltersoperator1 ,
                                                 AV62Contratowwds_5_contratonome1 ,
                                                 AV63Contratowwds_6_contratoclientedocumento1 ,
                                                 AV64Contratowwds_7_dynamicfiltersenabled2 ,
                                                 AV65Contratowwds_8_dynamicfiltersselector2 ,
                                                 AV66Contratowwds_9_dynamicfiltersoperator2 ,
                                                 AV67Contratowwds_10_contratonome2 ,
                                                 AV68Contratowwds_11_contratoclientedocumento2 ,
                                                 AV69Contratowwds_12_dynamicfiltersenabled3 ,
                                                 AV70Contratowwds_13_dynamicfiltersselector3 ,
                                                 AV71Contratowwds_14_dynamicfiltersoperator3 ,
                                                 AV72Contratowwds_15_contratonome3 ,
                                                 AV73Contratowwds_16_contratoclientedocumento3 ,
                                                 AV75Contratowwds_18_tfcontratonome_sel ,
                                                 AV74Contratowwds_17_tfcontratonome ,
                                                 AV76Contratowwds_19_tfcontratosituacao_sels.Count ,
                                                 A228ContratoNome ,
                                                 A475ContratoClienteDocumento ,
                                                 AV45OrderedBy ,
                                                 AV13OrderedDsc ,
                                                 A473ContratoClienteId ,
                                                 AV58Contratowwds_1_contratoclienteid } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                                 TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                                 }
            });
            lV59Contratowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Contratowwds_2_filterfulltext), "%", "");
            lV59Contratowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Contratowwds_2_filterfulltext), "%", "");
            lV59Contratowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Contratowwds_2_filterfulltext), "%", "");
            lV59Contratowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Contratowwds_2_filterfulltext), "%", "");
            lV62Contratowwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV62Contratowwds_5_contratonome1), "%", "");
            lV62Contratowwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV62Contratowwds_5_contratonome1), "%", "");
            lV63Contratowwds_6_contratoclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV63Contratowwds_6_contratoclientedocumento1), "%", "");
            lV63Contratowwds_6_contratoclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV63Contratowwds_6_contratoclientedocumento1), "%", "");
            lV67Contratowwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV67Contratowwds_10_contratonome2), "%", "");
            lV67Contratowwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV67Contratowwds_10_contratonome2), "%", "");
            lV68Contratowwds_11_contratoclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV68Contratowwds_11_contratoclientedocumento2), "%", "");
            lV68Contratowwds_11_contratoclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV68Contratowwds_11_contratoclientedocumento2), "%", "");
            lV72Contratowwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV72Contratowwds_15_contratonome3), "%", "");
            lV72Contratowwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV72Contratowwds_15_contratonome3), "%", "");
            lV73Contratowwds_16_contratoclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV73Contratowwds_16_contratoclientedocumento3), "%", "");
            lV73Contratowwds_16_contratoclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV73Contratowwds_16_contratoclientedocumento3), "%", "");
            lV74Contratowwds_17_tfcontratonome = StringUtil.Concat( StringUtil.RTrim( AV74Contratowwds_17_tfcontratonome), "%", "");
            /* Using cursor H004F3 */
            pr_default.execute(0, new Object[] {AV58Contratowwds_1_contratoclienteid, lV59Contratowwds_2_filterfulltext, lV59Contratowwds_2_filterfulltext, lV59Contratowwds_2_filterfulltext, lV59Contratowwds_2_filterfulltext, lV62Contratowwds_5_contratonome1, lV62Contratowwds_5_contratonome1, lV63Contratowwds_6_contratoclientedocumento1, lV63Contratowwds_6_contratoclientedocumento1, lV67Contratowwds_10_contratonome2, lV67Contratowwds_10_contratonome2, lV68Contratowwds_11_contratoclientedocumento2, lV68Contratowwds_11_contratoclientedocumento2, lV72Contratowwds_15_contratonome3, lV72Contratowwds_15_contratonome3, lV73Contratowwds_16_contratoclientedocumento3, lV73Contratowwds_16_contratoclientedocumento3, lV74Contratowwds_17_tfcontratonome, AV75Contratowwds_18_tfcontratonome_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_119_idx = 1;
            sGXsfl_119_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_119_idx), 4, 0), 4, "0");
            SubsflControlProps_1192( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A475ContratoClienteDocumento = H004F3_A475ContratoClienteDocumento[0];
               n475ContratoClienteDocumento = H004F3_n475ContratoClienteDocumento[0];
               A473ContratoClienteId = H004F3_A473ContratoClienteId[0];
               n473ContratoClienteId = H004F3_n473ContratoClienteId[0];
               AssignAttri("", false, "A473ContratoClienteId", StringUtil.LTrimStr( (decimal)(A473ContratoClienteId), 9, 0));
               A471ContratoSituacao = H004F3_A471ContratoSituacao[0];
               n471ContratoSituacao = H004F3_n471ContratoSituacao[0];
               A561ContratoClienteTipoPessoa = H004F3_A561ContratoClienteTipoPessoa[0];
               n561ContratoClienteTipoPessoa = H004F3_n561ContratoClienteTipoPessoa[0];
               A477ContratoClienteRepresentanteCPF = H004F3_A477ContratoClienteRepresentanteCPF[0];
               n477ContratoClienteRepresentanteCPF = H004F3_n477ContratoClienteRepresentanteCPF[0];
               A228ContratoNome = H004F3_A228ContratoNome[0];
               n228ContratoNome = H004F3_n228ContratoNome[0];
               A227ContratoId = H004F3_A227ContratoId[0];
               n227ContratoId = H004F3_n227ContratoId[0];
               A483AssinaturaUltId_F = H004F3_A483AssinaturaUltId_F[0];
               n483AssinaturaUltId_F = H004F3_n483AssinaturaUltId_F[0];
               A475ContratoClienteDocumento = H004F3_A475ContratoClienteDocumento[0];
               n475ContratoClienteDocumento = H004F3_n475ContratoClienteDocumento[0];
               A561ContratoClienteTipoPessoa = H004F3_A561ContratoClienteTipoPessoa[0];
               n561ContratoClienteTipoPessoa = H004F3_n561ContratoClienteTipoPessoa[0];
               A477ContratoClienteRepresentanteCPF = H004F3_A477ContratoClienteRepresentanteCPF[0];
               n477ContratoClienteRepresentanteCPF = H004F3_n477ContratoClienteRepresentanteCPF[0];
               A483AssinaturaUltId_F = H004F3_A483AssinaturaUltId_F[0];
               n483AssinaturaUltId_F = H004F3_n483AssinaturaUltId_F[0];
               /* Execute user event: Grid.Load */
               E274F2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 119;
            WB4F0( ) ;
         }
         bGXsfl_119_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes4F2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV57Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV57Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCLIENTE", AV53Cliente);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCLIENTE", AV53Cliente);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTE", GetSecureSignedToken( "", AV53Cliente, context));
         GxWebStd.gx_hidden_field( context, "gxhash_CONTRATOID"+"_"+sGXsfl_119_idx, GetSecureSignedToken( sGXsfl_119_idx, context.localUtil.Format( (decimal)(A227ContratoId), "ZZZZZ9"), context));
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
         AV58Contratowwds_1_contratoclienteid = AV50ContratoClienteId;
         AV59Contratowwds_2_filterfulltext = AV14FilterFullText;
         AV60Contratowwds_3_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV61Contratowwds_4_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV62Contratowwds_5_contratonome1 = AV17ContratoNome1;
         AV63Contratowwds_6_contratoclientedocumento1 = AV54ContratoClienteDocumento1;
         AV64Contratowwds_7_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV65Contratowwds_8_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV66Contratowwds_9_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV67Contratowwds_10_contratonome2 = AV21ContratoNome2;
         AV68Contratowwds_11_contratoclientedocumento2 = AV55ContratoClienteDocumento2;
         AV69Contratowwds_12_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV70Contratowwds_13_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV71Contratowwds_14_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV72Contratowwds_15_contratonome3 = AV25ContratoNome3;
         AV73Contratowwds_16_contratoclientedocumento3 = AV56ContratoClienteDocumento3;
         AV74Contratowwds_17_tfcontratonome = AV34TFContratoNome;
         AV75Contratowwds_18_tfcontratonome_sel = AV35TFContratoNome_Sel;
         AV76Contratowwds_19_tfcontratosituacao_sels = AV47TFContratoSituacao_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A471ContratoSituacao ,
                                              AV76Contratowwds_19_tfcontratosituacao_sels ,
                                              AV59Contratowwds_2_filterfulltext ,
                                              AV60Contratowwds_3_dynamicfiltersselector1 ,
                                              AV61Contratowwds_4_dynamicfiltersoperator1 ,
                                              AV62Contratowwds_5_contratonome1 ,
                                              AV63Contratowwds_6_contratoclientedocumento1 ,
                                              AV64Contratowwds_7_dynamicfiltersenabled2 ,
                                              AV65Contratowwds_8_dynamicfiltersselector2 ,
                                              AV66Contratowwds_9_dynamicfiltersoperator2 ,
                                              AV67Contratowwds_10_contratonome2 ,
                                              AV68Contratowwds_11_contratoclientedocumento2 ,
                                              AV69Contratowwds_12_dynamicfiltersenabled3 ,
                                              AV70Contratowwds_13_dynamicfiltersselector3 ,
                                              AV71Contratowwds_14_dynamicfiltersoperator3 ,
                                              AV72Contratowwds_15_contratonome3 ,
                                              AV73Contratowwds_16_contratoclientedocumento3 ,
                                              AV75Contratowwds_18_tfcontratonome_sel ,
                                              AV74Contratowwds_17_tfcontratonome ,
                                              AV76Contratowwds_19_tfcontratosituacao_sels.Count ,
                                              A228ContratoNome ,
                                              A475ContratoClienteDocumento ,
                                              AV45OrderedBy ,
                                              AV13OrderedDsc ,
                                              A473ContratoClienteId ,
                                              AV58Contratowwds_1_contratoclienteid } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV59Contratowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Contratowwds_2_filterfulltext), "%", "");
         lV59Contratowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Contratowwds_2_filterfulltext), "%", "");
         lV59Contratowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Contratowwds_2_filterfulltext), "%", "");
         lV59Contratowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Contratowwds_2_filterfulltext), "%", "");
         lV62Contratowwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV62Contratowwds_5_contratonome1), "%", "");
         lV62Contratowwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV62Contratowwds_5_contratonome1), "%", "");
         lV63Contratowwds_6_contratoclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV63Contratowwds_6_contratoclientedocumento1), "%", "");
         lV63Contratowwds_6_contratoclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV63Contratowwds_6_contratoclientedocumento1), "%", "");
         lV67Contratowwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV67Contratowwds_10_contratonome2), "%", "");
         lV67Contratowwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV67Contratowwds_10_contratonome2), "%", "");
         lV68Contratowwds_11_contratoclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV68Contratowwds_11_contratoclientedocumento2), "%", "");
         lV68Contratowwds_11_contratoclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV68Contratowwds_11_contratoclientedocumento2), "%", "");
         lV72Contratowwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV72Contratowwds_15_contratonome3), "%", "");
         lV72Contratowwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV72Contratowwds_15_contratonome3), "%", "");
         lV73Contratowwds_16_contratoclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV73Contratowwds_16_contratoclientedocumento3), "%", "");
         lV73Contratowwds_16_contratoclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV73Contratowwds_16_contratoclientedocumento3), "%", "");
         lV74Contratowwds_17_tfcontratonome = StringUtil.Concat( StringUtil.RTrim( AV74Contratowwds_17_tfcontratonome), "%", "");
         /* Using cursor H004F5 */
         pr_default.execute(1, new Object[] {AV58Contratowwds_1_contratoclienteid, lV59Contratowwds_2_filterfulltext, lV59Contratowwds_2_filterfulltext, lV59Contratowwds_2_filterfulltext, lV59Contratowwds_2_filterfulltext, lV62Contratowwds_5_contratonome1, lV62Contratowwds_5_contratonome1, lV63Contratowwds_6_contratoclientedocumento1, lV63Contratowwds_6_contratoclientedocumento1, lV67Contratowwds_10_contratonome2, lV67Contratowwds_10_contratonome2, lV68Contratowwds_11_contratoclientedocumento2, lV68Contratowwds_11_contratoclientedocumento2, lV72Contratowwds_15_contratonome3, lV72Contratowwds_15_contratonome3, lV73Contratowwds_16_contratoclientedocumento3, lV73Contratowwds_16_contratoclientedocumento3, lV74Contratowwds_17_tfcontratonome, AV75Contratowwds_18_tfcontratonome_sel});
         GRID_nRecordCount = H004F5_AGRID_nRecordCount[0];
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
         AV58Contratowwds_1_contratoclienteid = AV50ContratoClienteId;
         AV59Contratowwds_2_filterfulltext = AV14FilterFullText;
         AV60Contratowwds_3_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV61Contratowwds_4_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV62Contratowwds_5_contratonome1 = AV17ContratoNome1;
         AV63Contratowwds_6_contratoclientedocumento1 = AV54ContratoClienteDocumento1;
         AV64Contratowwds_7_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV65Contratowwds_8_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV66Contratowwds_9_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV67Contratowwds_10_contratonome2 = AV21ContratoNome2;
         AV68Contratowwds_11_contratoclientedocumento2 = AV55ContratoClienteDocumento2;
         AV69Contratowwds_12_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV70Contratowwds_13_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV71Contratowwds_14_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV72Contratowwds_15_contratonome3 = AV25ContratoNome3;
         AV73Contratowwds_16_contratoclientedocumento3 = AV56ContratoClienteDocumento3;
         AV74Contratowwds_17_tfcontratonome = AV34TFContratoNome;
         AV75Contratowwds_18_tfcontratonome_sel = AV35TFContratoNome_Sel;
         AV76Contratowwds_19_tfcontratosituacao_sels = AV47TFContratoSituacao_Sels;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV45OrderedBy, AV13OrderedDsc, AV14FilterFullText, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17ContratoNome1, AV54ContratoClienteDocumento1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21ContratoNome2, AV55ContratoClienteDocumento2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25ContratoNome3, AV56ContratoClienteDocumento3, AV33ManageFiltersExecutionStep, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV57Pgmname, AV50ContratoClienteId, AV34TFContratoNome, AV35TFContratoNome_Sel, AV47TFContratoSituacao_Sels, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, AV53Cliente, A473ContratoClienteId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV58Contratowwds_1_contratoclienteid = AV50ContratoClienteId;
         AV59Contratowwds_2_filterfulltext = AV14FilterFullText;
         AV60Contratowwds_3_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV61Contratowwds_4_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV62Contratowwds_5_contratonome1 = AV17ContratoNome1;
         AV63Contratowwds_6_contratoclientedocumento1 = AV54ContratoClienteDocumento1;
         AV64Contratowwds_7_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV65Contratowwds_8_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV66Contratowwds_9_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV67Contratowwds_10_contratonome2 = AV21ContratoNome2;
         AV68Contratowwds_11_contratoclientedocumento2 = AV55ContratoClienteDocumento2;
         AV69Contratowwds_12_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV70Contratowwds_13_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV71Contratowwds_14_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV72Contratowwds_15_contratonome3 = AV25ContratoNome3;
         AV73Contratowwds_16_contratoclientedocumento3 = AV56ContratoClienteDocumento3;
         AV74Contratowwds_17_tfcontratonome = AV34TFContratoNome;
         AV75Contratowwds_18_tfcontratonome_sel = AV35TFContratoNome_Sel;
         AV76Contratowwds_19_tfcontratosituacao_sels = AV47TFContratoSituacao_Sels;
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV45OrderedBy, AV13OrderedDsc, AV14FilterFullText, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17ContratoNome1, AV54ContratoClienteDocumento1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21ContratoNome2, AV55ContratoClienteDocumento2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25ContratoNome3, AV56ContratoClienteDocumento3, AV33ManageFiltersExecutionStep, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV57Pgmname, AV50ContratoClienteId, AV34TFContratoNome, AV35TFContratoNome_Sel, AV47TFContratoSituacao_Sels, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, AV53Cliente, A473ContratoClienteId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV58Contratowwds_1_contratoclienteid = AV50ContratoClienteId;
         AV59Contratowwds_2_filterfulltext = AV14FilterFullText;
         AV60Contratowwds_3_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV61Contratowwds_4_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV62Contratowwds_5_contratonome1 = AV17ContratoNome1;
         AV63Contratowwds_6_contratoclientedocumento1 = AV54ContratoClienteDocumento1;
         AV64Contratowwds_7_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV65Contratowwds_8_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV66Contratowwds_9_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV67Contratowwds_10_contratonome2 = AV21ContratoNome2;
         AV68Contratowwds_11_contratoclientedocumento2 = AV55ContratoClienteDocumento2;
         AV69Contratowwds_12_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV70Contratowwds_13_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV71Contratowwds_14_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV72Contratowwds_15_contratonome3 = AV25ContratoNome3;
         AV73Contratowwds_16_contratoclientedocumento3 = AV56ContratoClienteDocumento3;
         AV74Contratowwds_17_tfcontratonome = AV34TFContratoNome;
         AV75Contratowwds_18_tfcontratonome_sel = AV35TFContratoNome_Sel;
         AV76Contratowwds_19_tfcontratosituacao_sels = AV47TFContratoSituacao_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV45OrderedBy, AV13OrderedDsc, AV14FilterFullText, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17ContratoNome1, AV54ContratoClienteDocumento1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21ContratoNome2, AV55ContratoClienteDocumento2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25ContratoNome3, AV56ContratoClienteDocumento3, AV33ManageFiltersExecutionStep, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV57Pgmname, AV50ContratoClienteId, AV34TFContratoNome, AV35TFContratoNome_Sel, AV47TFContratoSituacao_Sels, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, AV53Cliente, A473ContratoClienteId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV58Contratowwds_1_contratoclienteid = AV50ContratoClienteId;
         AV59Contratowwds_2_filterfulltext = AV14FilterFullText;
         AV60Contratowwds_3_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV61Contratowwds_4_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV62Contratowwds_5_contratonome1 = AV17ContratoNome1;
         AV63Contratowwds_6_contratoclientedocumento1 = AV54ContratoClienteDocumento1;
         AV64Contratowwds_7_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV65Contratowwds_8_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV66Contratowwds_9_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV67Contratowwds_10_contratonome2 = AV21ContratoNome2;
         AV68Contratowwds_11_contratoclientedocumento2 = AV55ContratoClienteDocumento2;
         AV69Contratowwds_12_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV70Contratowwds_13_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV71Contratowwds_14_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV72Contratowwds_15_contratonome3 = AV25ContratoNome3;
         AV73Contratowwds_16_contratoclientedocumento3 = AV56ContratoClienteDocumento3;
         AV74Contratowwds_17_tfcontratonome = AV34TFContratoNome;
         AV75Contratowwds_18_tfcontratonome_sel = AV35TFContratoNome_Sel;
         AV76Contratowwds_19_tfcontratosituacao_sels = AV47TFContratoSituacao_Sels;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV45OrderedBy, AV13OrderedDsc, AV14FilterFullText, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17ContratoNome1, AV54ContratoClienteDocumento1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21ContratoNome2, AV55ContratoClienteDocumento2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25ContratoNome3, AV56ContratoClienteDocumento3, AV33ManageFiltersExecutionStep, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV57Pgmname, AV50ContratoClienteId, AV34TFContratoNome, AV35TFContratoNome_Sel, AV47TFContratoSituacao_Sels, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, AV53Cliente, A473ContratoClienteId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV58Contratowwds_1_contratoclienteid = AV50ContratoClienteId;
         AV59Contratowwds_2_filterfulltext = AV14FilterFullText;
         AV60Contratowwds_3_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV61Contratowwds_4_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV62Contratowwds_5_contratonome1 = AV17ContratoNome1;
         AV63Contratowwds_6_contratoclientedocumento1 = AV54ContratoClienteDocumento1;
         AV64Contratowwds_7_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV65Contratowwds_8_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV66Contratowwds_9_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV67Contratowwds_10_contratonome2 = AV21ContratoNome2;
         AV68Contratowwds_11_contratoclientedocumento2 = AV55ContratoClienteDocumento2;
         AV69Contratowwds_12_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV70Contratowwds_13_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV71Contratowwds_14_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV72Contratowwds_15_contratonome3 = AV25ContratoNome3;
         AV73Contratowwds_16_contratoclientedocumento3 = AV56ContratoClienteDocumento3;
         AV74Contratowwds_17_tfcontratonome = AV34TFContratoNome;
         AV75Contratowwds_18_tfcontratonome_sel = AV35TFContratoNome_Sel;
         AV76Contratowwds_19_tfcontratosituacao_sels = AV47TFContratoSituacao_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV45OrderedBy, AV13OrderedDsc, AV14FilterFullText, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17ContratoNome1, AV54ContratoClienteDocumento1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21ContratoNome2, AV55ContratoClienteDocumento2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25ContratoNome3, AV56ContratoClienteDocumento3, AV33ManageFiltersExecutionStep, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV57Pgmname, AV50ContratoClienteId, AV34TFContratoNome, AV35TFContratoNome_Sel, AV47TFContratoSituacao_Sels, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, AV53Cliente, A473ContratoClienteId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV57Pgmname = "ContratoWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavEnviarassinatura_Enabled = 0;
         edtavAssinatura_Enabled = 0;
         edtContratoId_Enabled = 0;
         edtContratoNome_Enabled = 0;
         edtContratoClienteRepresentanteCPF_Enabled = 0;
         cmbContratoClienteTipoPessoa.Enabled = 0;
         cmbContratoSituacao.Enabled = 0;
         edtAssinaturaUltId_F_Enabled = 0;
         edtContratoClienteId_Enabled = 0;
         AssignProp("", false, edtContratoClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtContratoClienteId_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4F0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E254F2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV31ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV36DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_119 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_119"), ",", "."), 18, MidpointRounding.ToEven));
            AV38GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV39GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV40GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_managefilters_Icontype = cgiGet( "DDO_MANAGEFILTERS_Icontype");
            Ddo_managefilters_Icon = cgiGet( "DDO_MANAGEFILTERS_Icon");
            Ddo_managefilters_Tooltip = cgiGet( "DDO_MANAGEFILTERS_Tooltip");
            Ddo_managefilters_Cls = cgiGet( "DDO_MANAGEFILTERS_Cls");
            Dvpanel_tableheader_Width = cgiGet( "DVPANEL_TABLEHEADER_Width");
            Dvpanel_tableheader_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Autowidth"));
            Dvpanel_tableheader_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Autoheight"));
            Dvpanel_tableheader_Cls = cgiGet( "DVPANEL_TABLEHEADER_Cls");
            Dvpanel_tableheader_Title = cgiGet( "DVPANEL_TABLEHEADER_Title");
            Dvpanel_tableheader_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Collapsible"));
            Dvpanel_tableheader_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Collapsed"));
            Dvpanel_tableheader_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Showcollapseicon"));
            Dvpanel_tableheader_Iconposition = cgiGet( "DVPANEL_TABLEHEADER_Iconposition");
            Dvpanel_tableheader_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Autoscroll"));
            Gridpaginationbar_Class = cgiGet( "GRIDPAGINATIONBAR_Class");
            Gridpaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showfirst"));
            Gridpaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showprevious"));
            Gridpaginationbar_Shownext = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Shownext"));
            Gridpaginationbar_Showlast = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showlast"));
            Gridpaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Pagestoshow"), ",", "."), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Pagingbuttonsposition = cgiGet( "GRIDPAGINATIONBAR_Pagingbuttonsposition");
            Gridpaginationbar_Pagingcaptionposition = cgiGet( "GRIDPAGINATIONBAR_Pagingcaptionposition");
            Gridpaginationbar_Emptygridclass = cgiGet( "GRIDPAGINATIONBAR_Emptygridclass");
            Gridpaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselector"));
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Rowsperpageoptions = cgiGet( "GRIDPAGINATIONBAR_Rowsperpageoptions");
            Gridpaginationbar_Previous = cgiGet( "GRIDPAGINATIONBAR_Previous");
            Gridpaginationbar_Next = cgiGet( "GRIDPAGINATIONBAR_Next");
            Gridpaginationbar_Caption = cgiGet( "GRIDPAGINATIONBAR_Caption");
            Gridpaginationbar_Emptygridcaption = cgiGet( "GRIDPAGINATIONBAR_Emptygridcaption");
            Gridpaginationbar_Rowsperpagecaption = cgiGet( "GRIDPAGINATIONBAR_Rowsperpagecaption");
            Ddo_grid_Caption = cgiGet( "DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( "DDO_GRID_Filteredtext_set");
            Ddo_grid_Selectedvalue_set = cgiGet( "DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( "DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( "DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( "DDO_GRID_Filtertype");
            Ddo_grid_Includedatalist = cgiGet( "DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( "DDO_GRID_Datalisttype");
            Ddo_grid_Allowmultipleselection = cgiGet( "DDO_GRID_Allowmultipleselection");
            Ddo_grid_Datalistfixedvalues = cgiGet( "DDO_GRID_Datalistfixedvalues");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Fixedcolumns = cgiGet( "GRID_EMPOWERER_Fixedcolumns");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV14FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV14FilterFullText", AV14FilterFullText);
            cmbavDynamicfiltersselector1.Name = cmbavDynamicfiltersselector1_Internalname;
            cmbavDynamicfiltersselector1.CurrentValue = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AV15DynamicFiltersSelector1 = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AssignAttri("", false, "AV15DynamicFiltersSelector1", AV15DynamicFiltersSelector1);
            cmbavDynamicfiltersoperator1.Name = cmbavDynamicfiltersoperator1_Internalname;
            cmbavDynamicfiltersoperator1.CurrentValue = cgiGet( cmbavDynamicfiltersoperator1_Internalname);
            AV16DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator1_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
            AV17ContratoNome1 = cgiGet( edtavContratonome1_Internalname);
            AssignAttri("", false, "AV17ContratoNome1", AV17ContratoNome1);
            AV54ContratoClienteDocumento1 = cgiGet( edtavContratoclientedocumento1_Internalname);
            AssignAttri("", false, "AV54ContratoClienteDocumento1", AV54ContratoClienteDocumento1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV19DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV20DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV20DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
            AV21ContratoNome2 = cgiGet( edtavContratonome2_Internalname);
            AssignAttri("", false, "AV21ContratoNome2", AV21ContratoNome2);
            AV55ContratoClienteDocumento2 = cgiGet( edtavContratoclientedocumento2_Internalname);
            AssignAttri("", false, "AV55ContratoClienteDocumento2", AV55ContratoClienteDocumento2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV23DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV23DynamicFiltersSelector3", AV23DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV24DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
            AV25ContratoNome3 = cgiGet( edtavContratonome3_Internalname);
            AssignAttri("", false, "AV25ContratoNome3", AV25ContratoNome3);
            AV56ContratoClienteDocumento3 = cgiGet( edtavContratoclientedocumento3_Internalname);
            AssignAttri("", false, "AV56ContratoClienteDocumento3", AV56ContratoClienteDocumento3);
            A473ContratoClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtContratoClienteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            n473ContratoClienteId = false;
            AssignAttri("", false, "A473ContratoClienteId", StringUtil.LTrimStr( (decimal)(A473ContratoClienteId), 9, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"ContratoWW");
            A473ContratoClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtContratoClienteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            n473ContratoClienteId = false;
            AssignAttri("", false, "A473ContratoClienteId", StringUtil.LTrimStr( (decimal)(A473ContratoClienteId), 9, 0));
            forbiddenHiddens.Add("ContratoClienteId", context.localUtil.Format( (decimal)(A473ContratoClienteId), "ZZZZZZZZ9"));
            hsh = cgiGet( "hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("contratoww:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               return  ;
            }
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV45OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV13OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV14FilterFullText) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV15DynamicFiltersSelector1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV16DynamicFiltersOperator1 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATONOME1"), AV17ContratoNome1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATOCLIENTEDOCUMENTO1"), AV54ContratoClienteDocumento1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV19DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV20DynamicFiltersOperator2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATONOME2"), AV21ContratoNome2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATOCLIENTEDOCUMENTO2"), AV55ContratoClienteDocumento2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV23DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV24DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATONOME3"), AV25ContratoNome3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATOCLIENTEDOCUMENTO3"), AV56ContratoClienteDocumento3) != 0 )
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
         E254F2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E254F2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV53Cliente.Load(AV50ContratoClienteId);
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         if ( StringUtil.StrCmp(AV7HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         lblJsdynamicfilters_Caption = "";
         AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         AV15DynamicFiltersSelector1 = "CONTRATONOME";
         AssignAttri("", false, "AV15DynamicFiltersSelector1", AV15DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV19DynamicFiltersSelector2 = "CONTRATONOME";
         AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV23DynamicFiltersSelector3 = "CONTRATONOME";
         AssignAttri("", false, "AV23DynamicFiltersSelector3", AV23DynamicFiltersSelector3);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         imgAdddynamicfilters1_Jsonclick = StringUtil.Format( "WWPDynFilterShow_AL('%1', 2, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Jsonclick", imgAdddynamicfilters1_Jsonclick, true);
         imgRemovedynamicfilters1_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Jsonclick", imgRemovedynamicfilters1_Jsonclick, true);
         imgAdddynamicfilters2_Jsonclick = StringUtil.Format( "WWPDynFilterShow_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Jsonclick", imgAdddynamicfilters2_Jsonclick, true);
         imgRemovedynamicfilters2_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Jsonclick", imgRemovedynamicfilters2_Jsonclick, true);
         imgRemovedynamicfilters3_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgRemovedynamicfilters3_Internalname, "Jsonclick", imgRemovedynamicfilters3_Jsonclick, true);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = " Contrato";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         edtContratoClienteId_Visible = 0;
         AssignProp("", false, edtContratoClienteId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtContratoClienteId_Visible), 5, 0), true);
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
         if ( AV45OrderedBy < 1 )
         {
            AV45OrderedBy = 1;
            AssignAttri("", false, "AV45OrderedBy", StringUtil.LTrimStr( (decimal)(AV45OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV36DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV36DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E264F2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         if ( AV33ManageFiltersExecutionStep == 1 )
         {
            AV33ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV33ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV33ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV33ManageFiltersExecutionStep == 2 )
         {
            AV33ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV33ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV33ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         cmbavDynamicfiltersoperator1.removeAllItems();
         if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "CONTRATONOME") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "CONTRATOCLIENTEDOCUMENTO") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         if ( AV18DynamicFiltersEnabled2 )
         {
            cmbavDynamicfiltersoperator2.removeAllItems();
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "CONTRATONOME") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "CONTRATOCLIENTEDOCUMENTO") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            if ( AV22DynamicFiltersEnabled3 )
            {
               cmbavDynamicfiltersoperator3.removeAllItems();
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "CONTRATONOME") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "CONTRATOCLIENTEDOCUMENTO") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV38GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV38GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV38GridCurrentPage), 10, 0));
         AV39GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV39GridPageCount", StringUtil.LTrimStr( (decimal)(AV39GridPageCount), 10, 0));
         GXt_char2 = AV40GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV57Pgmname, out  GXt_char2) ;
         AV40GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV40GridAppliedFilters", AV40GridAppliedFilters);
         cmbContratoSituacao_Columnheaderclass = "WWColumn hidden-xs";
         AssignProp("", false, cmbContratoSituacao_Internalname, "Columnheaderclass", cmbContratoSituacao_Columnheaderclass, !bGXsfl_119_Refreshing);
         AV58Contratowwds_1_contratoclienteid = AV50ContratoClienteId;
         AV59Contratowwds_2_filterfulltext = AV14FilterFullText;
         AV60Contratowwds_3_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV61Contratowwds_4_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV62Contratowwds_5_contratonome1 = AV17ContratoNome1;
         AV63Contratowwds_6_contratoclientedocumento1 = AV54ContratoClienteDocumento1;
         AV64Contratowwds_7_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV65Contratowwds_8_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV66Contratowwds_9_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV67Contratowwds_10_contratonome2 = AV21ContratoNome2;
         AV68Contratowwds_11_contratoclientedocumento2 = AV55ContratoClienteDocumento2;
         AV69Contratowwds_12_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV70Contratowwds_13_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV71Contratowwds_14_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV72Contratowwds_15_contratonome3 = AV25ContratoNome3;
         AV73Contratowwds_16_contratoclientedocumento3 = AV56ContratoClienteDocumento3;
         AV74Contratowwds_17_tfcontratonome = AV34TFContratoNome;
         AV75Contratowwds_18_tfcontratonome_sel = AV35TFContratoNome_Sel;
         AV76Contratowwds_19_tfcontratosituacao_sels = AV47TFContratoSituacao_Sels;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV31ManageFiltersData", AV31ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E124F2( )
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
            AV37PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV37PageToGo) ;
         }
      }

      protected void E134F2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E144F2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV45OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV45OrderedBy", StringUtil.LTrimStr( (decimal)(AV45OrderedBy), 4, 0));
            AV13OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV13OrderedDsc", AV13OrderedDsc);
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ContratoNome") == 0 )
            {
               AV34TFContratoNome = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV34TFContratoNome", AV34TFContratoNome);
               AV35TFContratoNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV35TFContratoNome_Sel", AV35TFContratoNome_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ContratoSituacao") == 0 )
            {
               AV46TFContratoSituacao_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV46TFContratoSituacao_SelsJson", AV46TFContratoSituacao_SelsJson);
               AV47TFContratoSituacao_Sels.FromJSonString(AV46TFContratoSituacao_SelsJson, null);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV47TFContratoSituacao_Sels", AV47TFContratoSituacao_Sels);
      }

      private void E274F2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV41Display = "<i class=\"fa fa-search\"></i>";
         AssignAttri("", false, edtavDisplay_Internalname, AV41Display);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wcontrato"+UrlEncode(StringUtil.LTrimStr(A473ContratoClienteId,9,0)) + "," + UrlEncode(StringUtil.LTrimStr(A227ContratoId,6,0)) + "," + UrlEncode(StringUtil.RTrim("DSP"));
         edtavDisplay_Link = formatLink("wcontrato") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         AV42Update = "<i class=\"fa fa-pen\"></i>";
         AssignAttri("", false, edtavUpdate_Internalname, AV42Update);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wcontrato"+UrlEncode(StringUtil.LTrimStr(A473ContratoClienteId,9,0)) + "," + UrlEncode(StringUtil.LTrimStr(A227ContratoId,6,0)) + "," + UrlEncode(StringUtil.RTrim("UPD"));
         edtavUpdate_Link = formatLink("wcontrato") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         AV51EnviarAssinatura = "<i class=\"fas fa-share\"></i>";
         AssignAttri("", false, edtavEnviarassinatura_Internalname, AV51EnviarAssinatura);
         if ( StringUtil.StrCmp(A471ContratoSituacao, "EmElaboracao") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wpiniciarassinatura"+UrlEncode(StringUtil.LTrimStr(A227ContratoId,6,0));
            edtavEnviarassinatura_Link = formatLink("wpiniciarassinatura") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            edtavEnviarassinatura_Class = "Attribute";
         }
         else
         {
            edtavEnviarassinatura_Link = "";
            edtavEnviarassinatura_Class = "Invisible";
         }
         AV52Assinatura = "<i class=\"fas fa-file-signature\"></i>";
         AssignAttri("", false, edtavAssinatura_Internalname, AV52Assinatura);
         if ( A483AssinaturaUltId_F > 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wpassinaturas"+UrlEncode(StringUtil.LTrimStr(A483AssinaturaUltId_F,4,0));
            edtavAssinatura_Link = formatLink("wpassinaturas") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            edtavAssinatura_Class = "Attribute";
         }
         else
         {
            edtavAssinatura_Link = "";
            edtavAssinatura_Class = "Invisible";
         }
         if ( StringUtil.StrCmp(A471ContratoSituacao, "EmElaboracao") == 0 )
         {
            cmbContratoSituacao_Columnclass = "WWColumn hidden-xs WWColumnTag WWColumnTagInfoLight WWColumnTagInfoLightSingleCell";
         }
         else if ( StringUtil.StrCmp(A471ContratoSituacao, "ColetandoAssinatura") == 0 )
         {
            cmbContratoSituacao_Columnclass = "WWColumn hidden-xs WWColumnTag WWColumnTagInfo WWColumnTagInfoSingleCell";
         }
         else if ( StringUtil.StrCmp(A471ContratoSituacao, "Assinado") == 0 )
         {
            cmbContratoSituacao_Columnclass = "WWColumn hidden-xs WWColumnTag WWColumnTagSuccess WWColumnTagSuccessSingleCell";
         }
         else
         {
            cmbContratoSituacao_Columnclass = "WWColumn hidden-xs";
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 119;
         }
         sendrow_1192( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_119_Refreshing )
         {
            DoAjaxLoad(119, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E204F2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV18DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV18DynamicFiltersEnabled2", AV18DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV45OrderedBy, AV13OrderedDsc, AV14FilterFullText, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17ContratoNome1, AV54ContratoClienteDocumento1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21ContratoNome2, AV55ContratoClienteDocumento2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25ContratoNome3, AV56ContratoClienteDocumento3, AV33ManageFiltersExecutionStep, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV57Pgmname, AV50ContratoClienteId, AV34TFContratoNome, AV35TFContratoNome_Sel, AV47TFContratoSituacao_Sels, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, AV53Cliente, A473ContratoClienteId) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV31ManageFiltersData", AV31ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E154F2( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV26DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV26DynamicFiltersRemoving", AV26DynamicFiltersRemoving);
         AV27DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV27DynamicFiltersIgnoreFirst", AV27DynamicFiltersIgnoreFirst);
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
         AV26DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV26DynamicFiltersRemoving", AV26DynamicFiltersRemoving);
         AV27DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV27DynamicFiltersIgnoreFirst", AV27DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV45OrderedBy, AV13OrderedDsc, AV14FilterFullText, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17ContratoNome1, AV54ContratoClienteDocumento1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21ContratoNome2, AV55ContratoClienteDocumento2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25ContratoNome3, AV56ContratoClienteDocumento3, AV33ManageFiltersExecutionStep, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV57Pgmname, AV50ContratoClienteId, AV34TFContratoNome, AV35TFContratoNome_Sel, AV47TFContratoSituacao_Sels, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, AV53Cliente, A473ContratoClienteId) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV31ManageFiltersData", AV31ManageFiltersData);
      }

      protected void E214F2( )
      {
         /* Dynamicfiltersselector1_Click Routine */
         returnInSub = false;
         AV16DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
      }

      protected void E224F2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV22DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV22DynamicFiltersEnabled3", AV22DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV45OrderedBy, AV13OrderedDsc, AV14FilterFullText, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17ContratoNome1, AV54ContratoClienteDocumento1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21ContratoNome2, AV55ContratoClienteDocumento2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25ContratoNome3, AV56ContratoClienteDocumento3, AV33ManageFiltersExecutionStep, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV57Pgmname, AV50ContratoClienteId, AV34TFContratoNome, AV35TFContratoNome_Sel, AV47TFContratoSituacao_Sels, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, AV53Cliente, A473ContratoClienteId) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV31ManageFiltersData", AV31ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E164F2( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV26DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV26DynamicFiltersRemoving", AV26DynamicFiltersRemoving);
         AV18DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV18DynamicFiltersEnabled2", AV18DynamicFiltersEnabled2);
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
         AV26DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV26DynamicFiltersRemoving", AV26DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV45OrderedBy, AV13OrderedDsc, AV14FilterFullText, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17ContratoNome1, AV54ContratoClienteDocumento1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21ContratoNome2, AV55ContratoClienteDocumento2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25ContratoNome3, AV56ContratoClienteDocumento3, AV33ManageFiltersExecutionStep, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV57Pgmname, AV50ContratoClienteId, AV34TFContratoNome, AV35TFContratoNome_Sel, AV47TFContratoSituacao_Sels, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, AV53Cliente, A473ContratoClienteId) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV31ManageFiltersData", AV31ManageFiltersData);
      }

      protected void E234F2( )
      {
         /* Dynamicfiltersselector2_Click Routine */
         returnInSub = false;
         AV20DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV20DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
      }

      protected void E174F2( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV26DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV26DynamicFiltersRemoving", AV26DynamicFiltersRemoving);
         AV22DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV22DynamicFiltersEnabled3", AV22DynamicFiltersEnabled3);
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
         AV26DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV26DynamicFiltersRemoving", AV26DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV45OrderedBy, AV13OrderedDsc, AV14FilterFullText, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17ContratoNome1, AV54ContratoClienteDocumento1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21ContratoNome2, AV55ContratoClienteDocumento2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25ContratoNome3, AV56ContratoClienteDocumento3, AV33ManageFiltersExecutionStep, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV57Pgmname, AV50ContratoClienteId, AV34TFContratoNome, AV35TFContratoNome_Sel, AV47TFContratoSituacao_Sels, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, AV53Cliente, A473ContratoClienteId) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV31ManageFiltersData", AV31ManageFiltersData);
      }

      protected void E244F2( )
      {
         /* Dynamicfiltersselector3_Click Routine */
         returnInSub = false;
         AV24DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV24DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E114F2( )
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
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("ContratoWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV57Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV33ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV33ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV33ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("ContratoWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV33ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV33ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV33ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV32ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "ContratoWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV32ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV32ManageFiltersXml)) )
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV57Pgmname+"GridState",  AV32ManageFiltersXml) ;
               AV10GridState.FromXml(AV32ManageFiltersXml, null, "", "");
               AV45OrderedBy = AV10GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV45OrderedBy", StringUtil.LTrimStr( (decimal)(AV45OrderedBy), 4, 0));
               AV13OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV13OrderedDsc", AV13OrderedDsc);
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV47TFContratoSituacao_Sels", AV47TFContratoSituacao_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV31ManageFiltersData", AV31ManageFiltersData);
      }

      protected void E184F2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Cliente.gxTpr_Responsavelcpf)) && ( StringUtil.StrCmp(AV53Cliente.gxTpr_Clientetipopessoa, "JURIDICA") == 0 ) )
         {
            GXt_char2 = "Cadastre um responsável para iniciar um contrato!";
            new message(context ).gxep_erro( ref  GXt_char2) ;
         }
         else
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wcontrato"+UrlEncode(StringUtil.LTrimStr(AV50ContratoClienteId,9,0)) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.RTrim("INS"));
            CallWebObject(formatLink("wcontrato") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
      }

      protected void E194F2( )
      {
         /* 'DoExport' Routine */
         returnInSub = false;
         new contratowwexport(context ).execute( out  AV28ExcelFilename, out  AV29ErrorMessage) ;
         if ( StringUtil.StrCmp(AV28ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV28ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV29ErrorMessage);
         }
      }

      protected void S172( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV45OrderedBy), 4, 0))+":"+(AV13OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         edtavContratonome1_Visible = 0;
         AssignProp("", false, edtavContratonome1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContratonome1_Visible), 5, 0), true);
         edtavContratoclientedocumento1_Visible = 0;
         AssignProp("", false, edtavContratoclientedocumento1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContratoclientedocumento1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "CONTRATONOME") == 0 )
         {
            edtavContratonome1_Visible = 1;
            AssignProp("", false, edtavContratonome1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContratonome1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "CONTRATOCLIENTEDOCUMENTO") == 0 )
         {
            edtavContratoclientedocumento1_Visible = 1;
            AssignProp("", false, edtavContratoclientedocumento1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContratoclientedocumento1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavContratonome2_Visible = 0;
         AssignProp("", false, edtavContratonome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContratonome2_Visible), 5, 0), true);
         edtavContratoclientedocumento2_Visible = 0;
         AssignProp("", false, edtavContratoclientedocumento2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContratoclientedocumento2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "CONTRATONOME") == 0 )
         {
            edtavContratonome2_Visible = 1;
            AssignProp("", false, edtavContratonome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContratonome2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "CONTRATOCLIENTEDOCUMENTO") == 0 )
         {
            edtavContratoclientedocumento2_Visible = 1;
            AssignProp("", false, edtavContratoclientedocumento2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContratoclientedocumento2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavContratonome3_Visible = 0;
         AssignProp("", false, edtavContratonome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContratonome3_Visible), 5, 0), true);
         edtavContratoclientedocumento3_Visible = 0;
         AssignProp("", false, edtavContratoclientedocumento3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContratoclientedocumento3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "CONTRATONOME") == 0 )
         {
            edtavContratonome3_Visible = 1;
            AssignProp("", false, edtavContratonome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContratonome3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "CONTRATOCLIENTEDOCUMENTO") == 0 )
         {
            edtavContratoclientedocumento3_Visible = 1;
            AssignProp("", false, edtavContratoclientedocumento3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContratoclientedocumento3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S202( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV18DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV18DynamicFiltersEnabled2", AV18DynamicFiltersEnabled2);
         AV19DynamicFiltersSelector2 = "CONTRATONOME";
         AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
         AV20DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV20DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AV21ContratoNome2 = "";
         AssignAttri("", false, "AV21ContratoNome2", AV21ContratoNome2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV22DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV22DynamicFiltersEnabled3", AV22DynamicFiltersEnabled3);
         AV23DynamicFiltersSelector3 = "CONTRATONOME";
         AssignAttri("", false, "AV23DynamicFiltersSelector3", AV23DynamicFiltersSelector3);
         AV24DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV24DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AV25ContratoNome3 = "";
         AssignAttri("", false, "AV25ContratoNome3", AV25ContratoNome3);
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
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV31ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "ContratoWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV31ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S222( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV14FilterFullText = "";
         AssignAttri("", false, "AV14FilterFullText", AV14FilterFullText);
         AV34TFContratoNome = "";
         AssignAttri("", false, "AV34TFContratoNome", AV34TFContratoNome);
         AV35TFContratoNome_Sel = "";
         AssignAttri("", false, "AV35TFContratoNome_Sel", AV35TFContratoNome_Sel);
         AV47TFContratoSituacao_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         AV15DynamicFiltersSelector1 = "CONTRATONOME";
         AssignAttri("", false, "AV15DynamicFiltersSelector1", AV15DynamicFiltersSelector1);
         AV16DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AV17ContratoNome1 = "";
         AssignAttri("", false, "AV17ContratoNome1", AV17ContratoNome1);
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
         if ( StringUtil.StrCmp(AV30Session.Get(AV57Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV57Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV30Session.Get(AV57Pgmname+"GridState"), null, "", "");
         }
         AV45OrderedBy = AV10GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV45OrderedBy", StringUtil.LTrimStr( (decimal)(AV45OrderedBy), 4, 0));
         AV13OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV13OrderedDsc", AV13OrderedDsc);
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
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV10GridState.gxTpr_Currentpage) ;
      }

      protected void S232( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV77GXV1 = 1;
         while ( AV77GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV77GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV14FilterFullText = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV14FilterFullText", AV14FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCONTRATONOME") == 0 )
            {
               AV34TFContratoNome = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV34TFContratoNome", AV34TFContratoNome);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCONTRATONOME_SEL") == 0 )
            {
               AV35TFContratoNome_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV35TFContratoNome_Sel", AV35TFContratoNome_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCONTRATOSITUACAO_SEL") == 0 )
            {
               AV46TFContratoSituacao_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV46TFContratoSituacao_SelsJson", AV46TFContratoSituacao_SelsJson);
               AV47TFContratoSituacao_Sels.FromJSonString(AV46TFContratoSituacao_SelsJson, null);
            }
            AV77GXV1 = (int)(AV77GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV35TFContratoNome_Sel)),  AV35TFContratoNome_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV47TFContratoSituacao_Sels.Count==0),  AV46TFContratoSituacao_SelsJson, out  GXt_char4) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char4;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV34TFContratoNome)),  AV34TFContratoNome, out  GXt_char4) ;
         Ddo_grid_Filteredtext_set = GXt_char4+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S212( )
      {
         /* 'LOADDYNFILTERSSTATE' Routine */
         returnInSub = false;
         imgAdddynamicfilters1_Visible = 1;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 0;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         imgAdddynamicfilters2_Visible = 1;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 0;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         if ( AV10GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(1));
            AV15DynamicFiltersSelector1 = AV12GridStateDynamicFilter.gxTpr_Selected;
            AssignAttri("", false, "AV15DynamicFiltersSelector1", AV15DynamicFiltersSelector1);
            if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "CONTRATONOME") == 0 )
            {
               AV16DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
               AV17ContratoNome1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV17ContratoNome1", AV17ContratoNome1);
            }
            else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "CONTRATOCLIENTEDOCUMENTO") == 0 )
            {
               AV16DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
               AV54ContratoClienteDocumento1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV54ContratoClienteDocumento1", AV54ContratoClienteDocumento1);
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
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
               lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+StringUtil.Format( "WWPDynFilterShow_AL('%1', 2, 0);", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
               imgAdddynamicfilters1_Visible = 0;
               AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
               imgRemovedynamicfilters1_Visible = 1;
               AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
               AV18DynamicFiltersEnabled2 = true;
               AssignAttri("", false, "AV18DynamicFiltersEnabled2", AV18DynamicFiltersEnabled2);
               AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(2));
               AV19DynamicFiltersSelector2 = AV12GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "CONTRATONOME") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV20DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
                  AV21ContratoNome2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV21ContratoNome2", AV21ContratoNome2);
               }
               else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "CONTRATOCLIENTEDOCUMENTO") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV20DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
                  AV55ContratoClienteDocumento2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV55ContratoClienteDocumento2", AV55ContratoClienteDocumento2);
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
                  AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
                  imgAdddynamicfilters2_Visible = 0;
                  AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
                  imgRemovedynamicfilters2_Visible = 1;
                  AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
                  AV22DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV22DynamicFiltersEnabled3", AV22DynamicFiltersEnabled3);
                  AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(3));
                  AV23DynamicFiltersSelector3 = AV12GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV23DynamicFiltersSelector3", AV23DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "CONTRATONOME") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV24DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
                     AV25ContratoNome3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV25ContratoNome3", AV25ContratoNome3);
                  }
                  else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "CONTRATOCLIENTEDOCUMENTO") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV24DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
                     AV56ContratoClienteDocumento3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV56ContratoClienteDocumento3", AV56ContratoClienteDocumento3);
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
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
            }
         }
         if ( AV26DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S182( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV30Session.Get(AV57Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV45OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV13OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV14FilterFullText)),  0,  AV14FilterFullText,  AV14FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCONTRATONOME",  "Contrato",  !String.IsNullOrEmpty(StringUtil.RTrim( AV34TFContratoNome)),  0,  AV34TFContratoNome,  AV34TFContratoNome,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV35TFContratoNome_Sel)),  AV35TFContratoNome_Sel,  AV35TFContratoNome_Sel) ;
         AV48AuxText = ((AV47TFContratoSituacao_Sels.Count==1) ? "["+((string)AV47TFContratoSituacao_Sels.Item(1))+"]" : "Vários valores");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCONTRATOSITUACAO_SEL",  "Situação",  !(AV47TFContratoSituacao_Sels.Count==0),  0,  AV47TFContratoSituacao_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV48AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( AV48AuxText, "[EmElaboracao]", "Em elaboração"), "[ColetandoAssinatura]", "Coletando assinaturas"), "[Assinado]", "Assinado")),  false,  "",  "") ;
         if ( ! (0==AV50ContratoClienteId) )
         {
            AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV11GridStateFilterValue.gxTpr_Name = "PARM_&CONTRATOCLIENTEID";
            AV11GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV50ContratoClienteId), 9, 0);
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
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV57Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S192( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV10GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV27DynamicFiltersIgnoreFirst )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV15DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "CONTRATONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV17ContratoNome1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Contrato",  AV16DynamicFiltersOperator1,  AV17ContratoNome1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV17ContratoNome1, "Contém"+" "+AV17ContratoNome1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV54ContratoClienteDocumento1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Cliente Documento",  AV16DynamicFiltersOperator1,  AV54ContratoClienteDocumento1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV54ContratoClienteDocumento1, "Contém"+" "+AV54ContratoClienteDocumento1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV26DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV18DynamicFiltersEnabled2 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV19DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "CONTRATONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV21ContratoNome2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Contrato",  AV20DynamicFiltersOperator2,  AV21ContratoNome2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV21ContratoNome2, "Contém"+" "+AV21ContratoNome2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV55ContratoClienteDocumento2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Cliente Documento",  AV20DynamicFiltersOperator2,  AV55ContratoClienteDocumento2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV55ContratoClienteDocumento2, "Contém"+" "+AV55ContratoClienteDocumento2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV26DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV22DynamicFiltersEnabled3 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV23DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "CONTRATONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV25ContratoNome3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Contrato",  AV24DynamicFiltersOperator3,  AV25ContratoNome3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV25ContratoNome3, "Contém"+" "+AV25ContratoNome3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV56ContratoClienteDocumento3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Cliente Documento",  AV24DynamicFiltersOperator3,  AV56ContratoClienteDocumento3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV56ContratoClienteDocumento3, "Contém"+" "+AV56ContratoClienteDocumento3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV26DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
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
         AV8TrnContext.gxTpr_Callerobject = AV57Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Contrato";
         AV9TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV9TrnContextAtt.gxTpr_Attributename = "ContratoClienteId";
         AV9TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV50ContratoClienteId), 9, 0);
         AV8TrnContext.gxTpr_Attributes.Add(AV9TrnContextAtt, 0);
         AV30Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void S242( )
      {
         /* 'DOEXPORT' Routine */
         returnInSub = false;
      }

      protected void wb_table3_98_4F2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'" + sGXsfl_119_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,102);\"", "", true, 0, "HLP_ContratoWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_contratonome3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContratonome3_Internalname, "Contrato Nome3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContratonome3_Internalname, AV25ContratoNome3, StringUtil.RTrim( context.localUtil.Format( AV25ContratoNome3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,105);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContratonome3_Jsonclick, 0, "Attribute", "", "", "", "", edtavContratonome3_Visible, edtavContratonome3_Enabled, 0, "text", "", 80, "chr", 1, "row", 125, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ContratoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_contratoclientedocumento3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContratoclientedocumento3_Internalname, "Contrato Cliente Documento3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContratoclientedocumento3_Internalname, AV56ContratoClienteDocumento3, StringUtil.RTrim( context.localUtil.Format( AV56ContratoClienteDocumento3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,108);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContratoclientedocumento3_Jsonclick, 0, "Attribute", "", "", "", "", edtavContratoclientedocumento3_Visible, edtavContratoclientedocumento3_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ContratoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ContratoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_98_4F2e( true) ;
         }
         else
         {
            wb_table3_98_4F2e( false) ;
         }
      }

      protected void wb_table2_73_4F2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'" + sGXsfl_119_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"", "", true, 0, "HLP_ContratoWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_contratonome2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContratonome2_Internalname, "Contrato Nome2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContratonome2_Internalname, AV21ContratoNome2, StringUtil.RTrim( context.localUtil.Format( AV21ContratoNome2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,80);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContratonome2_Jsonclick, 0, "Attribute", "", "", "", "", edtavContratonome2_Visible, edtavContratonome2_Enabled, 0, "text", "", 80, "chr", 1, "row", 125, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ContratoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_contratoclientedocumento2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContratoclientedocumento2_Internalname, "Contrato Cliente Documento2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContratoclientedocumento2_Internalname, AV55ContratoClienteDocumento2, StringUtil.RTrim( context.localUtil.Format( AV55ContratoClienteDocumento2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,83);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContratoclientedocumento2_Jsonclick, 0, "Attribute", "", "", "", "", edtavContratoclientedocumento2_Visible, edtavContratoclientedocumento2_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ContratoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ContratoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ContratoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_73_4F2e( true) ;
         }
         else
         {
            wb_table2_73_4F2e( false) ;
         }
      }

      protected void wb_table1_48_4F2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'" + sGXsfl_119_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "", true, 0, "HLP_ContratoWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_contratonome1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContratonome1_Internalname, "Contrato Nome1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContratonome1_Internalname, AV17ContratoNome1, StringUtil.RTrim( context.localUtil.Format( AV17ContratoNome1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContratonome1_Jsonclick, 0, "Attribute", "", "", "", "", edtavContratonome1_Visible, edtavContratonome1_Enabled, 0, "text", "", 80, "chr", 1, "row", 125, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ContratoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_contratoclientedocumento1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContratoclientedocumento1_Internalname, "Contrato Cliente Documento1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContratoclientedocumento1_Internalname, AV54ContratoClienteDocumento1, StringUtil.RTrim( context.localUtil.Format( AV54ContratoClienteDocumento1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContratoclientedocumento1_Jsonclick, 0, "Attribute", "", "", "", "", edtavContratoclientedocumento1_Visible, edtavContratoclientedocumento1_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ContratoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ContratoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ContratoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_48_4F2e( true) ;
         }
         else
         {
            wb_table1_48_4F2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV50ContratoClienteId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV50ContratoClienteId", StringUtil.LTrimStr( (decimal)(AV50ContratoClienteId), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vCONTRATOCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV50ContratoClienteId), "ZZZZZZZZ9"), context));
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
         PA4F2( ) ;
         WS4F2( ) ;
         WE4F2( ) ;
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
         AddStyleSheetFile("DVelop/DVPaginationBar/DVPaginationBar.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019245259", true, true);
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
         context.AddJavascriptSource("contratoww.js", "?202561019245260", false, true);
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
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1192( )
      {
         edtavDisplay_Internalname = "vDISPLAY_"+sGXsfl_119_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_119_idx;
         edtavEnviarassinatura_Internalname = "vENVIARASSINATURA_"+sGXsfl_119_idx;
         edtavAssinatura_Internalname = "vASSINATURA_"+sGXsfl_119_idx;
         edtContratoId_Internalname = "CONTRATOID_"+sGXsfl_119_idx;
         edtContratoNome_Internalname = "CONTRATONOME_"+sGXsfl_119_idx;
         edtContratoClienteRepresentanteCPF_Internalname = "CONTRATOCLIENTEREPRESENTANTECPF_"+sGXsfl_119_idx;
         cmbContratoClienteTipoPessoa_Internalname = "CONTRATOCLIENTETIPOPESSOA_"+sGXsfl_119_idx;
         cmbContratoSituacao_Internalname = "CONTRATOSITUACAO_"+sGXsfl_119_idx;
         edtAssinaturaUltId_F_Internalname = "ASSINATURAULTID_F_"+sGXsfl_119_idx;
      }

      protected void SubsflControlProps_fel_1192( )
      {
         edtavDisplay_Internalname = "vDISPLAY_"+sGXsfl_119_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_119_fel_idx;
         edtavEnviarassinatura_Internalname = "vENVIARASSINATURA_"+sGXsfl_119_fel_idx;
         edtavAssinatura_Internalname = "vASSINATURA_"+sGXsfl_119_fel_idx;
         edtContratoId_Internalname = "CONTRATOID_"+sGXsfl_119_fel_idx;
         edtContratoNome_Internalname = "CONTRATONOME_"+sGXsfl_119_fel_idx;
         edtContratoClienteRepresentanteCPF_Internalname = "CONTRATOCLIENTEREPRESENTANTECPF_"+sGXsfl_119_fel_idx;
         cmbContratoClienteTipoPessoa_Internalname = "CONTRATOCLIENTETIPOPESSOA_"+sGXsfl_119_fel_idx;
         cmbContratoSituacao_Internalname = "CONTRATOSITUACAO_"+sGXsfl_119_fel_idx;
         edtAssinaturaUltId_F_Internalname = "ASSINATURAULTID_F_"+sGXsfl_119_fel_idx;
      }

      protected void sendrow_1192( )
      {
         sGXsfl_119_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_119_idx), 4, 0), 4, "0");
         SubsflControlProps_1192( ) ;
         WB4F0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_119_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_119_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_119_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'',false,'" + sGXsfl_119_idx + "',119)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDisplay_Internalname,StringUtil.RTrim( AV41Display),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,120);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDisplay_Link,(string)"",(string)"Mostrar",(string)"",(string)edtavDisplay_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavDisplay_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)119,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'" + sGXsfl_119_idx + "',119)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV42Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,121);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",(string)"Modifica",(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)119,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 122,'',false,'" + sGXsfl_119_idx + "',119)\"";
            ROClassString = edtavEnviarassinatura_Class;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavEnviarassinatura_Internalname,StringUtil.RTrim( AV51EnviarAssinatura),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,122);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavEnviarassinatura_Link,(string)"",(string)"Enviar para assinatura",(string)"",(string)edtavEnviarassinatura_Jsonclick,(short)0,(string)edtavEnviarassinatura_Class,(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavEnviarassinatura_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)119,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 123,'',false,'" + sGXsfl_119_idx + "',119)\"";
            ROClassString = edtavAssinatura_Class;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavAssinatura_Internalname,StringUtil.RTrim( AV52Assinatura),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,123);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavAssinatura_Link,(string)"",(string)"Assinaturas",(string)"",(string)edtavAssinatura_Jsonclick,(short)0,(string)edtavAssinatura_Class,(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavAssinatura_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)119,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtContratoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A227ContratoId), "ZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtContratoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)119,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtContratoNome_Internalname,(string)A228ContratoNome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtContratoNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)125,(short)0,(short)0,(short)119,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtContratoClienteRepresentanteCPF_Internalname,(string)A477ContratoClienteRepresentanteCPF,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtContratoClienteRepresentanteCPF_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)119,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            GXCCtl = "CONTRATOCLIENTETIPOPESSOA_" + sGXsfl_119_idx;
            cmbContratoClienteTipoPessoa.Name = GXCCtl;
            cmbContratoClienteTipoPessoa.WebTags = "";
            cmbContratoClienteTipoPessoa.addItem("FISICA", "Física", 0);
            cmbContratoClienteTipoPessoa.addItem("JURIDICA", "Jurídica", 0);
            if ( cmbContratoClienteTipoPessoa.ItemCount > 0 )
            {
               A561ContratoClienteTipoPessoa = cmbContratoClienteTipoPessoa.getValidValue(A561ContratoClienteTipoPessoa);
               n561ContratoClienteTipoPessoa = false;
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbContratoClienteTipoPessoa,(string)cmbContratoClienteTipoPessoa_Internalname,StringUtil.RTrim( A561ContratoClienteTipoPessoa),(short)1,(string)cmbContratoClienteTipoPessoa_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)0,(short)0,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbContratoClienteTipoPessoa.CurrentValue = StringUtil.RTrim( A561ContratoClienteTipoPessoa);
            AssignProp("", false, cmbContratoClienteTipoPessoa_Internalname, "Values", (string)(cmbContratoClienteTipoPessoa.ToJavascriptSource()), !bGXsfl_119_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbContratoSituacao.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "CONTRATOSITUACAO_" + sGXsfl_119_idx;
               cmbContratoSituacao.Name = GXCCtl;
               cmbContratoSituacao.WebTags = "";
               cmbContratoSituacao.addItem("EmElaboracao", "Em elaboração", 0);
               cmbContratoSituacao.addItem("ColetandoAssinatura", "Coletando assinaturas", 0);
               cmbContratoSituacao.addItem("Assinado", "Assinado", 0);
               if ( cmbContratoSituacao.ItemCount > 0 )
               {
                  A471ContratoSituacao = cmbContratoSituacao.getValidValue(A471ContratoSituacao);
                  n471ContratoSituacao = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbContratoSituacao,(string)cmbContratoSituacao_Internalname,StringUtil.RTrim( A471ContratoSituacao),(short)1,(string)cmbContratoSituacao_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)cmbContratoSituacao_Columnclass,(string)cmbContratoSituacao_Columnheaderclass,(string)"",(string)"",(bool)true,(short)0});
            cmbContratoSituacao.CurrentValue = StringUtil.RTrim( A471ContratoSituacao);
            AssignProp("", false, cmbContratoSituacao_Internalname, "Values", (string)(cmbContratoSituacao.ToJavascriptSource()), !bGXsfl_119_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAssinaturaUltId_F_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A483AssinaturaUltId_F), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A483AssinaturaUltId_F), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAssinaturaUltId_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)119,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes4F2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_119_idx = ((subGrid_Islastpage==1)&&(nGXsfl_119_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_119_idx+1);
            sGXsfl_119_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_119_idx), 4, 0), 4, "0");
            SubsflControlProps_1192( ) ;
         }
         /* End function sendrow_1192 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("CONTRATONOME", "Contrato", 0);
         cmbavDynamicfiltersselector1.addItem("CONTRATOCLIENTEDOCUMENTO", "Cliente Documento", 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV15DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV15DynamicFiltersSelector1);
            AssignAttri("", false, "AV15DynamicFiltersSelector1", AV15DynamicFiltersSelector1);
         }
         cmbavDynamicfiltersoperator1.Name = "vDYNAMICFILTERSOPERATOR1";
         cmbavDynamicfiltersoperator1.WebTags = "";
         cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV16DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("CONTRATONOME", "Contrato", 0);
         cmbavDynamicfiltersselector2.addItem("CONTRATOCLIENTEDOCUMENTO", "Cliente Documento", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV19DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV19DynamicFiltersSelector2);
            AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV20DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV20DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("CONTRATONOME", "Contrato", 0);
         cmbavDynamicfiltersselector3.addItem("CONTRATOCLIENTEDOCUMENTO", "Cliente Documento", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV23DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV23DynamicFiltersSelector3);
            AssignAttri("", false, "AV23DynamicFiltersSelector3", AV23DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV24DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         }
         GXCCtl = "CONTRATOCLIENTETIPOPESSOA_" + sGXsfl_119_idx;
         cmbContratoClienteTipoPessoa.Name = GXCCtl;
         cmbContratoClienteTipoPessoa.WebTags = "";
         cmbContratoClienteTipoPessoa.addItem("FISICA", "Física", 0);
         cmbContratoClienteTipoPessoa.addItem("JURIDICA", "Jurídica", 0);
         if ( cmbContratoClienteTipoPessoa.ItemCount > 0 )
         {
            A561ContratoClienteTipoPessoa = cmbContratoClienteTipoPessoa.getValidValue(A561ContratoClienteTipoPessoa);
            n561ContratoClienteTipoPessoa = false;
         }
         GXCCtl = "CONTRATOSITUACAO_" + sGXsfl_119_idx;
         cmbContratoSituacao.Name = GXCCtl;
         cmbContratoSituacao.WebTags = "";
         cmbContratoSituacao.addItem("EmElaboracao", "Em elaboração", 0);
         cmbContratoSituacao.addItem("ColetandoAssinatura", "Coletando assinaturas", 0);
         cmbContratoSituacao.addItem("Assinado", "Assinado", 0);
         if ( cmbContratoSituacao.ItemCount > 0 )
         {
            A471ContratoSituacao = cmbContratoSituacao.getValidValue(A471ContratoSituacao);
            n471ContratoSituacao = false;
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl119( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"119\">") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavEnviarassinatura_Class+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavAssinatura_Class+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Contrato") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Representante CPF") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Tipo Pessoa") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Situação") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Ult Id_F") ;
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
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV41Display)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDisplay_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDisplay_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV42Update)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV51EnviarAssinatura)));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavEnviarassinatura_Class));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavEnviarassinatura_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavEnviarassinatura_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV52Assinatura)));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavAssinatura_Class));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavAssinatura_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavAssinatura_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A228ContratoNome));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A477ContratoClienteRepresentanteCPF));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A561ContratoClienteTipoPessoa));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A471ContratoSituacao));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbContratoSituacao_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbContratoSituacao_Columnheaderclass));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A483AssinaturaUltId_F), 4, 0, ".", ""))));
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
         bttBtninsert_Internalname = "BTNINSERT";
         bttBtnexport_Internalname = "BTNEXPORT";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         divTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         lblDynamicfiltersprefix1_Internalname = "DYNAMICFILTERSPREFIX1";
         cmbavDynamicfiltersselector1_Internalname = "vDYNAMICFILTERSSELECTOR1";
         lblDynamicfiltersmiddle1_Internalname = "DYNAMICFILTERSMIDDLE1";
         cmbavDynamicfiltersoperator1_Internalname = "vDYNAMICFILTERSOPERATOR1";
         edtavContratonome1_Internalname = "vCONTRATONOME1";
         cellFilter_contratonome1_cell_Internalname = "FILTER_CONTRATONOME1_CELL";
         edtavContratoclientedocumento1_Internalname = "vCONTRATOCLIENTEDOCUMENTO1";
         cellFilter_contratoclientedocumento1_cell_Internalname = "FILTER_CONTRATOCLIENTEDOCUMENTO1_CELL";
         imgAdddynamicfilters1_Internalname = "ADDDYNAMICFILTERS1";
         cellDynamicfilters_addfilter1_cell_Internalname = "DYNAMICFILTERS_ADDFILTER1_CELL";
         imgRemovedynamicfilters1_Internalname = "REMOVEDYNAMICFILTERS1";
         cellDynamicfilters_removefilter1_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER1_CELL";
         tblTablemergeddynamicfilters1_Internalname = "TABLEMERGEDDYNAMICFILTERS1";
         divTabledynamicfiltersrow1_Internalname = "TABLEDYNAMICFILTERSROW1";
         lblDynamicfiltersprefix2_Internalname = "DYNAMICFILTERSPREFIX2";
         cmbavDynamicfiltersselector2_Internalname = "vDYNAMICFILTERSSELECTOR2";
         lblDynamicfiltersmiddle2_Internalname = "DYNAMICFILTERSMIDDLE2";
         cmbavDynamicfiltersoperator2_Internalname = "vDYNAMICFILTERSOPERATOR2";
         edtavContratonome2_Internalname = "vCONTRATONOME2";
         cellFilter_contratonome2_cell_Internalname = "FILTER_CONTRATONOME2_CELL";
         edtavContratoclientedocumento2_Internalname = "vCONTRATOCLIENTEDOCUMENTO2";
         cellFilter_contratoclientedocumento2_cell_Internalname = "FILTER_CONTRATOCLIENTEDOCUMENTO2_CELL";
         imgAdddynamicfilters2_Internalname = "ADDDYNAMICFILTERS2";
         cellDynamicfilters_addfilter2_cell_Internalname = "DYNAMICFILTERS_ADDFILTER2_CELL";
         imgRemovedynamicfilters2_Internalname = "REMOVEDYNAMICFILTERS2";
         cellDynamicfilters_removefilter2_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER2_CELL";
         tblTablemergeddynamicfilters2_Internalname = "TABLEMERGEDDYNAMICFILTERS2";
         divTabledynamicfiltersrow2_Internalname = "TABLEDYNAMICFILTERSROW2";
         lblDynamicfiltersprefix3_Internalname = "DYNAMICFILTERSPREFIX3";
         cmbavDynamicfiltersselector3_Internalname = "vDYNAMICFILTERSSELECTOR3";
         lblDynamicfiltersmiddle3_Internalname = "DYNAMICFILTERSMIDDLE3";
         cmbavDynamicfiltersoperator3_Internalname = "vDYNAMICFILTERSOPERATOR3";
         edtavContratonome3_Internalname = "vCONTRATONOME3";
         cellFilter_contratonome3_cell_Internalname = "FILTER_CONTRATONOME3_CELL";
         edtavContratoclientedocumento3_Internalname = "vCONTRATOCLIENTEDOCUMENTO3";
         cellFilter_contratoclientedocumento3_cell_Internalname = "FILTER_CONTRATOCLIENTEDOCUMENTO3_CELL";
         imgRemovedynamicfilters3_Internalname = "REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = "TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = "TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = "TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = "ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = "TABLEHEADER";
         Dvpanel_tableheader_Internalname = "DVPANEL_TABLEHEADER";
         edtavDisplay_Internalname = "vDISPLAY";
         edtavUpdate_Internalname = "vUPDATE";
         edtavEnviarassinatura_Internalname = "vENVIARASSINATURA";
         edtavAssinatura_Internalname = "vASSINATURA";
         edtContratoId_Internalname = "CONTRATOID";
         edtContratoNome_Internalname = "CONTRATONOME";
         edtContratoClienteRepresentanteCPF_Internalname = "CONTRATOCLIENTEREPRESENTANTECPF";
         cmbContratoClienteTipoPessoa_Internalname = "CONTRATOCLIENTETIPOPESSOA";
         cmbContratoSituacao_Internalname = "CONTRATOSITUACAO";
         edtAssinaturaUltId_F_Internalname = "ASSINATURAULTID_F";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         lblJsdynamicfilters_Internalname = "JSDYNAMICFILTERS";
         Ddo_grid_Internalname = "DDO_GRID";
         edtContratoClienteId_Internalname = "CONTRATOCLIENTEID";
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
         edtAssinaturaUltId_F_Jsonclick = "";
         cmbContratoSituacao_Jsonclick = "";
         cmbContratoSituacao_Columnclass = "WWColumn hidden-xs";
         cmbContratoClienteTipoPessoa_Jsonclick = "";
         edtContratoClienteRepresentanteCPF_Jsonclick = "";
         edtContratoNome_Jsonclick = "";
         edtContratoId_Jsonclick = "";
         edtavAssinatura_Jsonclick = "";
         edtavAssinatura_Class = "Attribute";
         edtavAssinatura_Link = "";
         edtavAssinatura_Enabled = 0;
         edtavEnviarassinatura_Jsonclick = "";
         edtavEnviarassinatura_Class = "Attribute";
         edtavEnviarassinatura_Link = "";
         edtavEnviarassinatura_Enabled = 0;
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Link = "";
         edtavUpdate_Enabled = 0;
         edtavDisplay_Jsonclick = "";
         edtavDisplay_Link = "";
         edtavDisplay_Enabled = 0;
         subGrid_Class = "GridWithPaginationBar GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavContratoclientedocumento1_Jsonclick = "";
         edtavContratoclientedocumento1_Enabled = 1;
         edtavContratonome1_Jsonclick = "";
         edtavContratonome1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavContratoclientedocumento2_Jsonclick = "";
         edtavContratoclientedocumento2_Enabled = 1;
         edtavContratonome2_Jsonclick = "";
         edtavContratonome2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavContratoclientedocumento3_Jsonclick = "";
         edtavContratoclientedocumento3_Enabled = 1;
         edtavContratonome3_Jsonclick = "";
         edtavContratonome3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavContratoclientedocumento3_Visible = 1;
         edtavContratonome3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavContratoclientedocumento2_Visible = 1;
         edtavContratonome2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavContratoclientedocumento1_Visible = 1;
         edtavContratonome1_Visible = 1;
         cmbContratoSituacao_Columnheaderclass = "";
         edtContratoClienteId_Enabled = 0;
         edtAssinaturaUltId_F_Enabled = 0;
         cmbContratoSituacao.Enabled = 0;
         cmbContratoClienteTipoPessoa.Enabled = 0;
         edtContratoClienteRepresentanteCPF_Enabled = 0;
         edtContratoNome_Enabled = 0;
         edtContratoId_Enabled = 0;
         subGrid_Sortable = 0;
         edtContratoClienteId_Jsonclick = "";
         edtContratoClienteId_Visible = 1;
         lblJsdynamicfilters_Caption = "JSDynamicFilters";
         cmbavDynamicfiltersselector3_Jsonclick = "";
         cmbavDynamicfiltersselector3.Enabled = 1;
         cmbavDynamicfiltersselector2_Jsonclick = "";
         cmbavDynamicfiltersselector2.Enabled = 1;
         cmbavDynamicfiltersselector1_Jsonclick = "";
         cmbavDynamicfiltersselector1.Enabled = 1;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         Grid_empowerer_Fixedcolumns = ";L;;;;;;;;";
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Datalistproc = "ContratoWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|EmElaboracao:Em elaboração,ColetandoAssinatura:Coletando assinaturas,Assinado:Assinado";
         Ddo_grid_Allowmultipleselection = "|T";
         Ddo_grid_Datalisttype = "Dynamic|FixedValues";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character|";
         Ddo_grid_Includefilter = "T|";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2";
         Ddo_grid_Columnids = "5:ContratoNome|8:ContratoSituacao";
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = " Contrato";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV15DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"AV22DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV23DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV45OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV16DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV17ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV54ContratoClienteDocumento1","fld":"vCONTRATOCLIENTEDOCUMENTO1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV20DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV21ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV55ContratoClienteDocumento2","fld":"vCONTRATOCLIENTEDOCUMENTO2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV24DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV25ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV56ContratoClienteDocumento3","fld":"vCONTRATOCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV57Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV50ContratoClienteId","fld":"vCONTRATOCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV34TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV35TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV47TFContratoSituacao_Sels","fld":"vTFCONTRATOSITUACAO_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV27DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV26DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV53Cliente","fld":"vCLIENTE","hsh":true,"type":""},{"av":"A473ContratoClienteId","fld":"CONTRATOCLIENTEID","pic":"ZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV16DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV20DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV24DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV38GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV39GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV40GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbContratoSituacao"},{"av":"AV31ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E124F2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV45OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV15DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV16DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV17ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV54ContratoClienteDocumento1","fld":"vCONTRATOCLIENTEDOCUMENTO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV20DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV21ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV55ContratoClienteDocumento2","fld":"vCONTRATOCLIENTEDOCUMENTO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV23DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV24DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV25ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV56ContratoClienteDocumento3","fld":"vCONTRATOCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV22DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV57Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV50ContratoClienteId","fld":"vCONTRATOCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV34TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV35TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV47TFContratoSituacao_Sels","fld":"vTFCONTRATOSITUACAO_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV27DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV26DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV53Cliente","fld":"vCLIENTE","hsh":true,"type":""},{"av":"A473ContratoClienteId","fld":"CONTRATOCLIENTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E134F2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV45OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV15DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV16DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV17ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV54ContratoClienteDocumento1","fld":"vCONTRATOCLIENTEDOCUMENTO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV20DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV21ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV55ContratoClienteDocumento2","fld":"vCONTRATOCLIENTEDOCUMENTO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV23DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV24DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV25ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV56ContratoClienteDocumento3","fld":"vCONTRATOCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV22DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV57Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV50ContratoClienteId","fld":"vCONTRATOCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV34TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV35TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV47TFContratoSituacao_Sels","fld":"vTFCONTRATOSITUACAO_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV27DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV26DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV53Cliente","fld":"vCLIENTE","hsh":true,"type":""},{"av":"A473ContratoClienteId","fld":"CONTRATOCLIENTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E144F2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV45OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV15DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV16DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV17ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV54ContratoClienteDocumento1","fld":"vCONTRATOCLIENTEDOCUMENTO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV20DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV21ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV55ContratoClienteDocumento2","fld":"vCONTRATOCLIENTEDOCUMENTO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV23DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV24DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV25ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV56ContratoClienteDocumento3","fld":"vCONTRATOCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV22DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV57Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV50ContratoClienteId","fld":"vCONTRATOCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV34TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV35TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV47TFContratoSituacao_Sels","fld":"vTFCONTRATOSITUACAO_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV27DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV26DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV53Cliente","fld":"vCLIENTE","hsh":true,"type":""},{"av":"A473ContratoClienteId","fld":"CONTRATOCLIENTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV45OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV34TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV35TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV46TFContratoSituacao_SelsJson","fld":"vTFCONTRATOSITUACAO_SELSJSON","type":"vchar"},{"av":"AV47TFContratoSituacao_Sels","fld":"vTFCONTRATOSITUACAO_SELS","type":""},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E274F2","iparms":[{"av":"A473ContratoClienteId","fld":"CONTRATOCLIENTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A227ContratoId","fld":"CONTRATOID","pic":"ZZZZZ9","hsh":true,"type":"int"},{"av":"cmbContratoSituacao"},{"av":"A471ContratoSituacao","fld":"CONTRATOSITUACAO","type":"svchar"},{"av":"A483AssinaturaUltId_F","fld":"ASSINATURAULTID_F","pic":"ZZZ9","type":"int"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV41Display","fld":"vDISPLAY","type":"char"},{"av":"edtavDisplay_Link","ctrl":"vDISPLAY","prop":"Link"},{"av":"AV42Update","fld":"vUPDATE","type":"char"},{"av":"edtavUpdate_Link","ctrl":"vUPDATE","prop":"Link"},{"av":"AV51EnviarAssinatura","fld":"vENVIARASSINATURA","type":"char"},{"av":"edtavEnviarassinatura_Link","ctrl":"vENVIARASSINATURA","prop":"Link"},{"av":"edtavEnviarassinatura_Class","ctrl":"vENVIARASSINATURA","prop":"Class"},{"av":"AV52Assinatura","fld":"vASSINATURA","type":"char"},{"av":"edtavAssinatura_Link","ctrl":"vASSINATURA","prop":"Link"},{"av":"edtavAssinatura_Class","ctrl":"vASSINATURA","prop":"Class"},{"av":"cmbContratoSituacao"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E204F2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV45OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV15DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV16DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV17ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV54ContratoClienteDocumento1","fld":"vCONTRATOCLIENTEDOCUMENTO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV20DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV21ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV55ContratoClienteDocumento2","fld":"vCONTRATOCLIENTEDOCUMENTO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV23DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV24DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV25ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV56ContratoClienteDocumento3","fld":"vCONTRATOCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV22DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV57Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV50ContratoClienteId","fld":"vCONTRATOCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV34TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV35TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV47TFContratoSituacao_Sels","fld":"vTFCONTRATOSITUACAO_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV27DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV26DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV53Cliente","fld":"vCLIENTE","hsh":true,"type":""},{"av":"A473ContratoClienteId","fld":"CONTRATOCLIENTEID","pic":"ZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV16DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV20DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV24DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV38GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV39GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV40GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbContratoSituacao"},{"av":"AV31ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E154F2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV45OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV15DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV16DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV17ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV54ContratoClienteDocumento1","fld":"vCONTRATOCLIENTEDOCUMENTO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV20DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV21ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV55ContratoClienteDocumento2","fld":"vCONTRATOCLIENTEDOCUMENTO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV23DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV24DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV25ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV56ContratoClienteDocumento3","fld":"vCONTRATOCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV22DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV57Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV50ContratoClienteId","fld":"vCONTRATOCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV34TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV35TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV47TFContratoSituacao_Sels","fld":"vTFCONTRATOSITUACAO_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV27DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV26DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV53Cliente","fld":"vCLIENTE","hsh":true,"type":""},{"av":"A473ContratoClienteId","fld":"CONTRATOCLIENTEID","pic":"ZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV26DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV27DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV20DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV21ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV22DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV23DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV24DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV25ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV15DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV16DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV17ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV54ContratoClienteDocumento1","fld":"vCONTRATOCLIENTEDOCUMENTO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV55ContratoClienteDocumento2","fld":"vCONTRATOCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV56ContratoClienteDocumento3","fld":"vCONTRATOCLIENTEDOCUMENTO3","type":"svchar"},{"av":"edtavContratonome2_Visible","ctrl":"vCONTRATONOME2","prop":"Visible"},{"av":"edtavContratoclientedocumento2_Visible","ctrl":"vCONTRATOCLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavContratonome3_Visible","ctrl":"vCONTRATONOME3","prop":"Visible"},{"av":"edtavContratoclientedocumento3_Visible","ctrl":"vCONTRATOCLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavContratonome1_Visible","ctrl":"vCONTRATONOME1","prop":"Visible"},{"av":"edtavContratoclientedocumento1_Visible","ctrl":"vCONTRATOCLIENTEDOCUMENTO1","prop":"Visible"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV38GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV39GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV40GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbContratoSituacao"},{"av":"AV31ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E214F2","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV15DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV16DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"edtavContratonome1_Visible","ctrl":"vCONTRATONOME1","prop":"Visible"},{"av":"edtavContratoclientedocumento1_Visible","ctrl":"vCONTRATOCLIENTEDOCUMENTO1","prop":"Visible"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E224F2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV45OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV15DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV16DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV17ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV54ContratoClienteDocumento1","fld":"vCONTRATOCLIENTEDOCUMENTO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV20DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV21ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV55ContratoClienteDocumento2","fld":"vCONTRATOCLIENTEDOCUMENTO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV23DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV24DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV25ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV56ContratoClienteDocumento3","fld":"vCONTRATOCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV22DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV57Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV50ContratoClienteId","fld":"vCONTRATOCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV34TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV35TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV47TFContratoSituacao_Sels","fld":"vTFCONTRATOSITUACAO_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV27DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV26DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV53Cliente","fld":"vCLIENTE","hsh":true,"type":""},{"av":"A473ContratoClienteId","fld":"CONTRATOCLIENTEID","pic":"ZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV22DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV16DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV20DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV24DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV38GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV39GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV40GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbContratoSituacao"},{"av":"AV31ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E164F2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV45OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV15DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV16DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV17ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV54ContratoClienteDocumento1","fld":"vCONTRATOCLIENTEDOCUMENTO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV20DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV21ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV55ContratoClienteDocumento2","fld":"vCONTRATOCLIENTEDOCUMENTO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV23DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV24DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV25ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV56ContratoClienteDocumento3","fld":"vCONTRATOCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV22DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV57Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV50ContratoClienteId","fld":"vCONTRATOCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV34TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV35TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV47TFContratoSituacao_Sels","fld":"vTFCONTRATOSITUACAO_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV27DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV26DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV53Cliente","fld":"vCLIENTE","hsh":true,"type":""},{"av":"A473ContratoClienteId","fld":"CONTRATOCLIENTEID","pic":"ZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV26DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV20DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV21ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV22DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV23DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV24DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV25ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV15DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV16DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV17ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV54ContratoClienteDocumento1","fld":"vCONTRATOCLIENTEDOCUMENTO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV55ContratoClienteDocumento2","fld":"vCONTRATOCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV56ContratoClienteDocumento3","fld":"vCONTRATOCLIENTEDOCUMENTO3","type":"svchar"},{"av":"edtavContratonome2_Visible","ctrl":"vCONTRATONOME2","prop":"Visible"},{"av":"edtavContratoclientedocumento2_Visible","ctrl":"vCONTRATOCLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavContratonome3_Visible","ctrl":"vCONTRATONOME3","prop":"Visible"},{"av":"edtavContratoclientedocumento3_Visible","ctrl":"vCONTRATOCLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavContratonome1_Visible","ctrl":"vCONTRATONOME1","prop":"Visible"},{"av":"edtavContratoclientedocumento1_Visible","ctrl":"vCONTRATOCLIENTEDOCUMENTO1","prop":"Visible"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV38GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV39GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV40GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbContratoSituacao"},{"av":"AV31ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E234F2","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV20DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"edtavContratonome2_Visible","ctrl":"vCONTRATONOME2","prop":"Visible"},{"av":"edtavContratoclientedocumento2_Visible","ctrl":"vCONTRATOCLIENTEDOCUMENTO2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E174F2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV45OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV15DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV16DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV17ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV54ContratoClienteDocumento1","fld":"vCONTRATOCLIENTEDOCUMENTO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV20DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV21ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV55ContratoClienteDocumento2","fld":"vCONTRATOCLIENTEDOCUMENTO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV23DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV24DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV25ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV56ContratoClienteDocumento3","fld":"vCONTRATOCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV22DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV57Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV50ContratoClienteId","fld":"vCONTRATOCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV34TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV35TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV47TFContratoSituacao_Sels","fld":"vTFCONTRATOSITUACAO_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV27DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV26DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV53Cliente","fld":"vCLIENTE","hsh":true,"type":""},{"av":"A473ContratoClienteId","fld":"CONTRATOCLIENTEID","pic":"ZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV26DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV22DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV20DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV21ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV23DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV24DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV25ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV15DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV16DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV17ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV54ContratoClienteDocumento1","fld":"vCONTRATOCLIENTEDOCUMENTO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV55ContratoClienteDocumento2","fld":"vCONTRATOCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV56ContratoClienteDocumento3","fld":"vCONTRATOCLIENTEDOCUMENTO3","type":"svchar"},{"av":"edtavContratonome2_Visible","ctrl":"vCONTRATONOME2","prop":"Visible"},{"av":"edtavContratoclientedocumento2_Visible","ctrl":"vCONTRATOCLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavContratonome3_Visible","ctrl":"vCONTRATONOME3","prop":"Visible"},{"av":"edtavContratoclientedocumento3_Visible","ctrl":"vCONTRATOCLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavContratonome1_Visible","ctrl":"vCONTRATONOME1","prop":"Visible"},{"av":"edtavContratoclientedocumento1_Visible","ctrl":"vCONTRATOCLIENTEDOCUMENTO1","prop":"Visible"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV38GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV39GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV40GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbContratoSituacao"},{"av":"AV31ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E244F2","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV23DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV24DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"edtavContratonome3_Visible","ctrl":"vCONTRATONOME3","prop":"Visible"},{"av":"edtavContratoclientedocumento3_Visible","ctrl":"vCONTRATOCLIENTEDOCUMENTO3","prop":"Visible"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E114F2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV45OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV15DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV16DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV17ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV54ContratoClienteDocumento1","fld":"vCONTRATOCLIENTEDOCUMENTO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV20DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV21ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV55ContratoClienteDocumento2","fld":"vCONTRATOCLIENTEDOCUMENTO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV23DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV24DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV25ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV56ContratoClienteDocumento3","fld":"vCONTRATOCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV22DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV57Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV50ContratoClienteId","fld":"vCONTRATOCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV34TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV35TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV47TFContratoSituacao_Sels","fld":"vTFCONTRATOSITUACAO_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV27DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV26DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV53Cliente","fld":"vCLIENTE","hsh":true,"type":""},{"av":"A473ContratoClienteId","fld":"CONTRATOCLIENTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV46TFContratoSituacao_SelsJson","fld":"vTFCONTRATOSITUACAO_SELSJSON","type":"vchar"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV45OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV34TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV35TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV47TFContratoSituacao_Sels","fld":"vTFCONTRATOSITUACAO_SELS","type":""},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV15DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV16DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV17ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV46TFContratoSituacao_SelsJson","fld":"vTFCONTRATOSITUACAO_SELSJSON","type":"vchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"AV54ContratoClienteDocumento1","fld":"vCONTRATOCLIENTEDOCUMENTO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV20DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV21ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV55ContratoClienteDocumento2","fld":"vCONTRATOCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV22DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV23DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV24DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV25ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV56ContratoClienteDocumento3","fld":"vCONTRATOCLIENTEDOCUMENTO3","type":"svchar"},{"av":"edtavContratonome1_Visible","ctrl":"vCONTRATONOME1","prop":"Visible"},{"av":"edtavContratoclientedocumento1_Visible","ctrl":"vCONTRATOCLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavContratonome2_Visible","ctrl":"vCONTRATONOME2","prop":"Visible"},{"av":"edtavContratoclientedocumento2_Visible","ctrl":"vCONTRATOCLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavContratonome3_Visible","ctrl":"vCONTRATONOME3","prop":"Visible"},{"av":"edtavContratoclientedocumento3_Visible","ctrl":"vCONTRATOCLIENTEDOCUMENTO3","prop":"Visible"},{"av":"AV38GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV39GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV40GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbContratoSituacao"},{"av":"AV31ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E184F2","iparms":[{"av":"AV53Cliente","fld":"vCLIENTE","hsh":true,"type":""},{"av":"AV50ContratoClienteId","fld":"vCONTRATOCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A227ContratoId","fld":"CONTRATOID","pic":"ZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("'DOEXPORT'","""{"handler":"E194F2","iparms":[]}""");
         setEventMetadata("VALID_CONTRATOCLIENTEID","""{"handler":"Valid_Contratoclienteid","iparms":[]}""");
         setEventMetadata("VALID_CONTRATOID","""{"handler":"Valid_Contratoid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Assinaturaultid_f","iparms":[]}""");
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
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV14FilterFullText = "";
         AV15DynamicFiltersSelector1 = "";
         AV17ContratoNome1 = "";
         AV54ContratoClienteDocumento1 = "";
         AV19DynamicFiltersSelector2 = "";
         AV21ContratoNome2 = "";
         AV55ContratoClienteDocumento2 = "";
         AV23DynamicFiltersSelector3 = "";
         AV25ContratoNome3 = "";
         AV56ContratoClienteDocumento3 = "";
         AV57Pgmname = "";
         AV34TFContratoNome = "";
         AV35TFContratoNome_Sel = "";
         AV47TFContratoSituacao_Sels = new GxSimpleCollection<string>();
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV53Cliente = new SdtCliente(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         forbiddenHiddens = new GXProperties();
         AV31ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV40GridAppliedFilters = "";
         AV36DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV46TFContratoSituacao_SelsJson = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtn_cancel_Jsonclick = "";
         ucDvpanel_tableheader = new GXUserControl();
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
         ucGridpaginationbar = new GXUserControl();
         lblJsdynamicfilters_Jsonclick = "";
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV41Display = "";
         AV42Update = "";
         AV51EnviarAssinatura = "";
         AV52Assinatura = "";
         A228ContratoNome = "";
         A477ContratoClienteRepresentanteCPF = "";
         A561ContratoClienteTipoPessoa = "";
         A471ContratoSituacao = "";
         GXDecQS = "";
         AV76Contratowwds_19_tfcontratosituacao_sels = new GxSimpleCollection<string>();
         lV59Contratowwds_2_filterfulltext = "";
         lV62Contratowwds_5_contratonome1 = "";
         lV63Contratowwds_6_contratoclientedocumento1 = "";
         lV67Contratowwds_10_contratonome2 = "";
         lV68Contratowwds_11_contratoclientedocumento2 = "";
         lV72Contratowwds_15_contratonome3 = "";
         lV73Contratowwds_16_contratoclientedocumento3 = "";
         lV74Contratowwds_17_tfcontratonome = "";
         AV59Contratowwds_2_filterfulltext = "";
         AV60Contratowwds_3_dynamicfiltersselector1 = "";
         AV62Contratowwds_5_contratonome1 = "";
         AV63Contratowwds_6_contratoclientedocumento1 = "";
         AV65Contratowwds_8_dynamicfiltersselector2 = "";
         AV67Contratowwds_10_contratonome2 = "";
         AV68Contratowwds_11_contratoclientedocumento2 = "";
         AV70Contratowwds_13_dynamicfiltersselector3 = "";
         AV72Contratowwds_15_contratonome3 = "";
         AV73Contratowwds_16_contratoclientedocumento3 = "";
         AV75Contratowwds_18_tfcontratonome_sel = "";
         AV74Contratowwds_17_tfcontratonome = "";
         A475ContratoClienteDocumento = "";
         H004F3_A475ContratoClienteDocumento = new string[] {""} ;
         H004F3_n475ContratoClienteDocumento = new bool[] {false} ;
         H004F3_A473ContratoClienteId = new int[1] ;
         H004F3_n473ContratoClienteId = new bool[] {false} ;
         H004F3_A471ContratoSituacao = new string[] {""} ;
         H004F3_n471ContratoSituacao = new bool[] {false} ;
         H004F3_A561ContratoClienteTipoPessoa = new string[] {""} ;
         H004F3_n561ContratoClienteTipoPessoa = new bool[] {false} ;
         H004F3_A477ContratoClienteRepresentanteCPF = new string[] {""} ;
         H004F3_n477ContratoClienteRepresentanteCPF = new bool[] {false} ;
         H004F3_A228ContratoNome = new string[] {""} ;
         H004F3_n228ContratoNome = new bool[] {false} ;
         H004F3_A227ContratoId = new int[1] ;
         H004F3_n227ContratoId = new bool[] {false} ;
         H004F3_A483AssinaturaUltId_F = new short[1] ;
         H004F3_n483AssinaturaUltId_F = new bool[] {false} ;
         H004F5_AGRID_nRecordCount = new long[1] ;
         hsh = "";
         AV7HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV32ManageFiltersXml = "";
         AV28ExcelFilename = "";
         AV29ErrorMessage = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV30Session = context.GetSession();
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         GXt_char4 = "";
         AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV48AuxText = "";
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV9TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         imgRemovedynamicfilters3_gximage = "";
         sImgUrl = "";
         imgAdddynamicfilters2_gximage = "";
         imgRemovedynamicfilters2_gximage = "";
         imgAdddynamicfilters1_gximage = "";
         imgRemovedynamicfilters1_gximage = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contratoww__default(),
            new Object[][] {
                new Object[] {
               H004F3_A475ContratoClienteDocumento, H004F3_n475ContratoClienteDocumento, H004F3_A473ContratoClienteId, H004F3_n473ContratoClienteId, H004F3_A471ContratoSituacao, H004F3_n471ContratoSituacao, H004F3_A561ContratoClienteTipoPessoa, H004F3_n561ContratoClienteTipoPessoa, H004F3_A477ContratoClienteRepresentanteCPF, H004F3_n477ContratoClienteRepresentanteCPF,
               H004F3_A228ContratoNome, H004F3_n228ContratoNome, H004F3_A227ContratoId, H004F3_A483AssinaturaUltId_F, H004F3_n483AssinaturaUltId_F
               }
               , new Object[] {
               H004F5_AGRID_nRecordCount
               }
            }
         );
         AV57Pgmname = "ContratoWW";
         /* GeneXus formulas. */
         AV57Pgmname = "ContratoWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavEnviarassinatura_Enabled = 0;
         edtavAssinatura_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV45OrderedBy ;
      private short AV16DynamicFiltersOperator1 ;
      private short AV20DynamicFiltersOperator2 ;
      private short AV24DynamicFiltersOperator3 ;
      private short AV33ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A483AssinaturaUltId_F ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV61Contratowwds_4_dynamicfiltersoperator1 ;
      private short AV66Contratowwds_9_dynamicfiltersoperator2 ;
      private short AV71Contratowwds_14_dynamicfiltersoperator3 ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int AV50ContratoClienteId ;
      private int wcpOAV50ContratoClienteId ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_119 ;
      private int nGXsfl_119_idx=1 ;
      private int A473ContratoClienteId ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int edtContratoClienteId_Visible ;
      private int A227ContratoId ;
      private int subGrid_Islastpage ;
      private int edtavDisplay_Enabled ;
      private int edtavUpdate_Enabled ;
      private int edtavEnviarassinatura_Enabled ;
      private int edtavAssinatura_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV76Contratowwds_19_tfcontratosituacao_sels_Count ;
      private int AV58Contratowwds_1_contratoclienteid ;
      private int edtContratoId_Enabled ;
      private int edtContratoNome_Enabled ;
      private int edtContratoClienteRepresentanteCPF_Enabled ;
      private int edtAssinaturaUltId_F_Enabled ;
      private int edtContratoClienteId_Enabled ;
      private int AV37PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavContratonome1_Visible ;
      private int edtavContratoclientedocumento1_Visible ;
      private int edtavContratonome2_Visible ;
      private int edtavContratoclientedocumento2_Visible ;
      private int edtavContratonome3_Visible ;
      private int edtavContratoclientedocumento3_Visible ;
      private int AV77GXV1 ;
      private int edtavContratonome3_Enabled ;
      private int edtavContratoclientedocumento3_Enabled ;
      private int edtavContratonome2_Enabled ;
      private int edtavContratoclientedocumento2_Enabled ;
      private int edtavContratonome1_Enabled ;
      private int edtavContratoclientedocumento1_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV38GridCurrentPage ;
      private long AV39GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_119_idx="0001" ;
      private string AV57Pgmname ;
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
      private string Ddo_grid_Selectedvalue_set ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_grid_Includefilter ;
      private string Ddo_grid_Filtertype ;
      private string Ddo_grid_Includedatalist ;
      private string Ddo_grid_Datalisttype ;
      private string Ddo_grid_Allowmultipleselection ;
      private string Ddo_grid_Datalistfixedvalues ;
      private string Ddo_grid_Datalistproc ;
      private string Grid_empowerer_Gridinternalname ;
      private string Grid_empowerer_Fixedcolumns ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string Dvpanel_tableheader_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
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
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string lblJsdynamicfilters_Internalname ;
      private string lblJsdynamicfilters_Caption ;
      private string lblJsdynamicfilters_Jsonclick ;
      private string Ddo_grid_Internalname ;
      private string edtContratoClienteId_Internalname ;
      private string edtContratoClienteId_Jsonclick ;
      private string Grid_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV41Display ;
      private string edtavDisplay_Internalname ;
      private string AV42Update ;
      private string edtavUpdate_Internalname ;
      private string AV51EnviarAssinatura ;
      private string edtavEnviarassinatura_Internalname ;
      private string AV52Assinatura ;
      private string edtavAssinatura_Internalname ;
      private string edtContratoId_Internalname ;
      private string edtContratoNome_Internalname ;
      private string edtContratoClienteRepresentanteCPF_Internalname ;
      private string cmbContratoClienteTipoPessoa_Internalname ;
      private string cmbContratoSituacao_Internalname ;
      private string edtAssinaturaUltId_F_Internalname ;
      private string GXDecQS ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string edtavContratonome1_Internalname ;
      private string edtavContratoclientedocumento1_Internalname ;
      private string edtavContratonome2_Internalname ;
      private string edtavContratoclientedocumento2_Internalname ;
      private string edtavContratonome3_Internalname ;
      private string edtavContratoclientedocumento3_Internalname ;
      private string hsh ;
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
      private string cmbContratoSituacao_Columnheaderclass ;
      private string edtavDisplay_Link ;
      private string edtavUpdate_Link ;
      private string edtavEnviarassinatura_Link ;
      private string edtavEnviarassinatura_Class ;
      private string edtavAssinatura_Link ;
      private string edtavAssinatura_Class ;
      private string cmbContratoSituacao_Columnclass ;
      private string GXt_char2 ;
      private string GXt_char4 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_contratonome3_cell_Internalname ;
      private string edtavContratonome3_Jsonclick ;
      private string cellFilter_contratoclientedocumento3_cell_Internalname ;
      private string edtavContratoclientedocumento3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_contratonome2_cell_Internalname ;
      private string edtavContratonome2_Jsonclick ;
      private string cellFilter_contratoclientedocumento2_cell_Internalname ;
      private string edtavContratoclientedocumento2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_contratonome1_cell_Internalname ;
      private string edtavContratonome1_Jsonclick ;
      private string cellFilter_contratoclientedocumento1_cell_Internalname ;
      private string edtavContratoclientedocumento1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string sGXsfl_119_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavDisplay_Jsonclick ;
      private string edtavUpdate_Jsonclick ;
      private string edtavEnviarassinatura_Jsonclick ;
      private string edtavAssinatura_Jsonclick ;
      private string edtContratoId_Jsonclick ;
      private string edtContratoNome_Jsonclick ;
      private string edtContratoClienteRepresentanteCPF_Jsonclick ;
      private string GXCCtl ;
      private string cmbContratoClienteTipoPessoa_Jsonclick ;
      private string cmbContratoSituacao_Jsonclick ;
      private string edtAssinaturaUltId_F_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV13OrderedDsc ;
      private bool AV18DynamicFiltersEnabled2 ;
      private bool AV22DynamicFiltersEnabled3 ;
      private bool AV27DynamicFiltersIgnoreFirst ;
      private bool AV26DynamicFiltersRemoving ;
      private bool n473ContratoClienteId ;
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
      private bool n227ContratoId ;
      private bool n228ContratoNome ;
      private bool n477ContratoClienteRepresentanteCPF ;
      private bool n561ContratoClienteTipoPessoa ;
      private bool n471ContratoSituacao ;
      private bool n483AssinaturaUltId_F ;
      private bool bGXsfl_119_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV64Contratowwds_7_dynamicfiltersenabled2 ;
      private bool AV69Contratowwds_12_dynamicfiltersenabled3 ;
      private bool n475ContratoClienteDocumento ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV46TFContratoSituacao_SelsJson ;
      private string AV32ManageFiltersXml ;
      private string AV14FilterFullText ;
      private string AV15DynamicFiltersSelector1 ;
      private string AV17ContratoNome1 ;
      private string AV54ContratoClienteDocumento1 ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV21ContratoNome2 ;
      private string AV55ContratoClienteDocumento2 ;
      private string AV23DynamicFiltersSelector3 ;
      private string AV25ContratoNome3 ;
      private string AV56ContratoClienteDocumento3 ;
      private string AV34TFContratoNome ;
      private string AV35TFContratoNome_Sel ;
      private string AV40GridAppliedFilters ;
      private string A228ContratoNome ;
      private string A477ContratoClienteRepresentanteCPF ;
      private string A561ContratoClienteTipoPessoa ;
      private string A471ContratoSituacao ;
      private string lV59Contratowwds_2_filterfulltext ;
      private string lV62Contratowwds_5_contratonome1 ;
      private string lV63Contratowwds_6_contratoclientedocumento1 ;
      private string lV67Contratowwds_10_contratonome2 ;
      private string lV68Contratowwds_11_contratoclientedocumento2 ;
      private string lV72Contratowwds_15_contratonome3 ;
      private string lV73Contratowwds_16_contratoclientedocumento3 ;
      private string lV74Contratowwds_17_tfcontratonome ;
      private string AV59Contratowwds_2_filterfulltext ;
      private string AV60Contratowwds_3_dynamicfiltersselector1 ;
      private string AV62Contratowwds_5_contratonome1 ;
      private string AV63Contratowwds_6_contratoclientedocumento1 ;
      private string AV65Contratowwds_8_dynamicfiltersselector2 ;
      private string AV67Contratowwds_10_contratonome2 ;
      private string AV68Contratowwds_11_contratoclientedocumento2 ;
      private string AV70Contratowwds_13_dynamicfiltersselector3 ;
      private string AV72Contratowwds_15_contratonome3 ;
      private string AV73Contratowwds_16_contratoclientedocumento3 ;
      private string AV75Contratowwds_18_tfcontratonome_sel ;
      private string AV74Contratowwds_17_tfcontratonome ;
      private string A475ContratoClienteDocumento ;
      private string AV28ExcelFilename ;
      private string AV29ErrorMessage ;
      private string AV48AuxText ;
      private IGxSession AV30Session ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GxHttpRequest AV7HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCombobox cmbContratoClienteTipoPessoa ;
      private GXCombobox cmbContratoSituacao ;
      private GxSimpleCollection<string> AV47TFContratoSituacao_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private SdtCliente AV53Cliente ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV31ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV36DDO_TitleSettingsIcons ;
      private GxSimpleCollection<string> AV76Contratowwds_19_tfcontratosituacao_sels ;
      private IDataStoreProvider pr_default ;
      private string[] H004F3_A475ContratoClienteDocumento ;
      private bool[] H004F3_n475ContratoClienteDocumento ;
      private int[] H004F3_A473ContratoClienteId ;
      private bool[] H004F3_n473ContratoClienteId ;
      private string[] H004F3_A471ContratoSituacao ;
      private bool[] H004F3_n471ContratoSituacao ;
      private string[] H004F3_A561ContratoClienteTipoPessoa ;
      private bool[] H004F3_n561ContratoClienteTipoPessoa ;
      private string[] H004F3_A477ContratoClienteRepresentanteCPF ;
      private bool[] H004F3_n477ContratoClienteRepresentanteCPF ;
      private string[] H004F3_A228ContratoNome ;
      private bool[] H004F3_n228ContratoNome ;
      private int[] H004F3_A227ContratoId ;
      private bool[] H004F3_n227ContratoId ;
      private short[] H004F3_A483AssinaturaUltId_F ;
      private bool[] H004F3_n483AssinaturaUltId_F ;
      private long[] H004F5_AGRID_nRecordCount ;
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

   public class contratoww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H004F3( IGxContext context ,
                                             string A471ContratoSituacao ,
                                             GxSimpleCollection<string> AV76Contratowwds_19_tfcontratosituacao_sels ,
                                             string AV59Contratowwds_2_filterfulltext ,
                                             string AV60Contratowwds_3_dynamicfiltersselector1 ,
                                             short AV61Contratowwds_4_dynamicfiltersoperator1 ,
                                             string AV62Contratowwds_5_contratonome1 ,
                                             string AV63Contratowwds_6_contratoclientedocumento1 ,
                                             bool AV64Contratowwds_7_dynamicfiltersenabled2 ,
                                             string AV65Contratowwds_8_dynamicfiltersselector2 ,
                                             short AV66Contratowwds_9_dynamicfiltersoperator2 ,
                                             string AV67Contratowwds_10_contratonome2 ,
                                             string AV68Contratowwds_11_contratoclientedocumento2 ,
                                             bool AV69Contratowwds_12_dynamicfiltersenabled3 ,
                                             string AV70Contratowwds_13_dynamicfiltersselector3 ,
                                             short AV71Contratowwds_14_dynamicfiltersoperator3 ,
                                             string AV72Contratowwds_15_contratonome3 ,
                                             string AV73Contratowwds_16_contratoclientedocumento3 ,
                                             string AV75Contratowwds_18_tfcontratonome_sel ,
                                             string AV74Contratowwds_17_tfcontratonome ,
                                             int AV76Contratowwds_19_tfcontratosituacao_sels_Count ,
                                             string A228ContratoNome ,
                                             string A475ContratoClienteDocumento ,
                                             short AV45OrderedBy ,
                                             bool AV13OrderedDsc ,
                                             int A473ContratoClienteId ,
                                             int AV58Contratowwds_1_contratoclienteid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[22];
         Object[] GXv_Object6 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T2.ClienteDocumento AS ContratoClienteDocumento, T1.ContratoClienteId AS ContratoClienteId, T1.ContratoSituacao, T2.ClienteTipoPessoa AS ContratoClienteTipoPessoa, T2.ResponsavelCPF AS ContratoClienteRepresentanteCPF, T1.ContratoNome, T1.ContratoId, COALESCE( T3.AssinaturaUltId_F, 0) AS AssinaturaUltId_F";
         sFromString = " FROM ((Contrato T1 LEFT JOIN Cliente T2 ON T2.ClienteId = T1.ContratoClienteId) LEFT JOIN LATERAL (SELECT MAX(AssinaturaId) AS AssinaturaUltId_F, ContratoId FROM Assinatura WHERE T1.ContratoId = ContratoId GROUP BY ContratoId ) T3 ON T3.ContratoId = T1.ContratoId)";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.ContratoClienteId = :AV58Contratowwds_1_contratoclienteid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Contratowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.ContratoNome like '%' || :lV59Contratowwds_2_filterfulltext) or ( 'em elaboração' like '%' || LOWER(:lV59Contratowwds_2_filterfulltext) and T1.ContratoSituacao = ( 'EmElaboracao')) or ( 'coletando assinaturas' like '%' || LOWER(:lV59Contratowwds_2_filterfulltext) and T1.ContratoSituacao = ( 'ColetandoAssinatura')) or ( 'assinado' like '%' || LOWER(:lV59Contratowwds_2_filterfulltext) and T1.ContratoSituacao = ( 'Assinado')))");
         }
         else
         {
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Contratowwds_3_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV61Contratowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Contratowwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like :lV62Contratowwds_5_contratonome1)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Contratowwds_3_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV61Contratowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Contratowwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like '%' || :lV62Contratowwds_5_contratonome1)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Contratowwds_3_dynamicfiltersselector1, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV61Contratowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Contratowwds_6_contratoclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV63Contratowwds_6_contratoclientedocumento1)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Contratowwds_3_dynamicfiltersselector1, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV61Contratowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Contratowwds_6_contratoclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV63Contratowwds_6_contratoclientedocumento1)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( AV64Contratowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Contratowwds_8_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV66Contratowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Contratowwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like :lV67Contratowwds_10_contratonome2)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( AV64Contratowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Contratowwds_8_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV66Contratowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Contratowwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like '%' || :lV67Contratowwds_10_contratonome2)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( AV64Contratowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Contratowwds_8_dynamicfiltersselector2, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV66Contratowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Contratowwds_11_contratoclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV68Contratowwds_11_contratoclientedocumento2)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( AV64Contratowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Contratowwds_8_dynamicfiltersselector2, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV66Contratowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Contratowwds_11_contratoclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV68Contratowwds_11_contratoclientedocumento2)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( AV69Contratowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Contratowwds_13_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV71Contratowwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Contratowwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like :lV72Contratowwds_15_contratonome3)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( AV69Contratowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Contratowwds_13_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV71Contratowwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Contratowwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like '%' || :lV72Contratowwds_15_contratonome3)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( AV69Contratowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Contratowwds_13_dynamicfiltersselector3, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV71Contratowwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Contratowwds_16_contratoclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV73Contratowwds_16_contratoclientedocumento3)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( AV69Contratowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Contratowwds_13_dynamicfiltersselector3, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV71Contratowwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Contratowwds_16_contratoclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV73Contratowwds_16_contratoclientedocumento3)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Contratowwds_18_tfcontratonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Contratowwds_17_tfcontratonome)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like :lV74Contratowwds_17_tfcontratonome)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Contratowwds_18_tfcontratonome_sel)) && ! ( StringUtil.StrCmp(AV75Contratowwds_18_tfcontratonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome = ( :AV75Contratowwds_18_tfcontratonome_sel))");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( StringUtil.StrCmp(AV75Contratowwds_18_tfcontratonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ContratoNome IS NULL or (char_length(trim(trailing ' ' from T1.ContratoNome))=0))");
         }
         if ( AV76Contratowwds_19_tfcontratosituacao_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV76Contratowwds_19_tfcontratosituacao_sels, "T1.ContratoSituacao IN (", ")")+")");
         }
         if ( ( AV45OrderedBy == 1 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ContratoClienteId, T1.ContratoNome, T1.ContratoId";
         }
         else if ( ( AV45OrderedBy == 1 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ContratoClienteId DESC, T1.ContratoNome DESC, T1.ContratoId";
         }
         else if ( ( AV45OrderedBy == 2 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ContratoClienteId, T1.ContratoSituacao, T1.ContratoId";
         }
         else if ( ( AV45OrderedBy == 2 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ContratoClienteId DESC, T1.ContratoSituacao DESC, T1.ContratoId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.ContratoId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_H004F5( IGxContext context ,
                                             string A471ContratoSituacao ,
                                             GxSimpleCollection<string> AV76Contratowwds_19_tfcontratosituacao_sels ,
                                             string AV59Contratowwds_2_filterfulltext ,
                                             string AV60Contratowwds_3_dynamicfiltersselector1 ,
                                             short AV61Contratowwds_4_dynamicfiltersoperator1 ,
                                             string AV62Contratowwds_5_contratonome1 ,
                                             string AV63Contratowwds_6_contratoclientedocumento1 ,
                                             bool AV64Contratowwds_7_dynamicfiltersenabled2 ,
                                             string AV65Contratowwds_8_dynamicfiltersselector2 ,
                                             short AV66Contratowwds_9_dynamicfiltersoperator2 ,
                                             string AV67Contratowwds_10_contratonome2 ,
                                             string AV68Contratowwds_11_contratoclientedocumento2 ,
                                             bool AV69Contratowwds_12_dynamicfiltersenabled3 ,
                                             string AV70Contratowwds_13_dynamicfiltersselector3 ,
                                             short AV71Contratowwds_14_dynamicfiltersoperator3 ,
                                             string AV72Contratowwds_15_contratonome3 ,
                                             string AV73Contratowwds_16_contratoclientedocumento3 ,
                                             string AV75Contratowwds_18_tfcontratonome_sel ,
                                             string AV74Contratowwds_17_tfcontratonome ,
                                             int AV76Contratowwds_19_tfcontratosituacao_sels_Count ,
                                             string A228ContratoNome ,
                                             string A475ContratoClienteDocumento ,
                                             short AV45OrderedBy ,
                                             bool AV13OrderedDsc ,
                                             int A473ContratoClienteId ,
                                             int AV58Contratowwds_1_contratoclienteid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[19];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ((Contrato T1 LEFT JOIN Cliente T2 ON T2.ClienteId = T1.ContratoClienteId) LEFT JOIN LATERAL (SELECT MAX(AssinaturaId) AS AssinaturaUltId_F, ContratoId FROM Assinatura WHERE T1.ContratoId = ContratoId GROUP BY ContratoId ) T3 ON T3.ContratoId = T1.ContratoId)";
         AddWhere(sWhereString, "(T1.ContratoClienteId = :AV58Contratowwds_1_contratoclienteid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Contratowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.ContratoNome like '%' || :lV59Contratowwds_2_filterfulltext) or ( 'em elaboração' like '%' || LOWER(:lV59Contratowwds_2_filterfulltext) and T1.ContratoSituacao = ( 'EmElaboracao')) or ( 'coletando assinaturas' like '%' || LOWER(:lV59Contratowwds_2_filterfulltext) and T1.ContratoSituacao = ( 'ColetandoAssinatura')) or ( 'assinado' like '%' || LOWER(:lV59Contratowwds_2_filterfulltext) and T1.ContratoSituacao = ( 'Assinado')))");
         }
         else
         {
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
            GXv_int7[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Contratowwds_3_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV61Contratowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Contratowwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like :lV62Contratowwds_5_contratonome1)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Contratowwds_3_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV61Contratowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Contratowwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like '%' || :lV62Contratowwds_5_contratonome1)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Contratowwds_3_dynamicfiltersselector1, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV61Contratowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Contratowwds_6_contratoclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV63Contratowwds_6_contratoclientedocumento1)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Contratowwds_3_dynamicfiltersselector1, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV61Contratowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Contratowwds_6_contratoclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV63Contratowwds_6_contratoclientedocumento1)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( AV64Contratowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Contratowwds_8_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV66Contratowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Contratowwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like :lV67Contratowwds_10_contratonome2)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( AV64Contratowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Contratowwds_8_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV66Contratowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Contratowwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like '%' || :lV67Contratowwds_10_contratonome2)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( AV64Contratowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Contratowwds_8_dynamicfiltersselector2, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV66Contratowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Contratowwds_11_contratoclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV68Contratowwds_11_contratoclientedocumento2)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( AV64Contratowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Contratowwds_8_dynamicfiltersselector2, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV66Contratowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Contratowwds_11_contratoclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV68Contratowwds_11_contratoclientedocumento2)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( AV69Contratowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Contratowwds_13_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV71Contratowwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Contratowwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like :lV72Contratowwds_15_contratonome3)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( AV69Contratowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Contratowwds_13_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV71Contratowwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Contratowwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like '%' || :lV72Contratowwds_15_contratonome3)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( AV69Contratowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Contratowwds_13_dynamicfiltersselector3, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV71Contratowwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Contratowwds_16_contratoclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV73Contratowwds_16_contratoclientedocumento3)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( AV69Contratowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Contratowwds_13_dynamicfiltersselector3, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV71Contratowwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Contratowwds_16_contratoclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV73Contratowwds_16_contratoclientedocumento3)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Contratowwds_18_tfcontratonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Contratowwds_17_tfcontratonome)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like :lV74Contratowwds_17_tfcontratonome)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Contratowwds_18_tfcontratonome_sel)) && ! ( StringUtil.StrCmp(AV75Contratowwds_18_tfcontratonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome = ( :AV75Contratowwds_18_tfcontratonome_sel))");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( StringUtil.StrCmp(AV75Contratowwds_18_tfcontratonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ContratoNome IS NULL or (char_length(trim(trailing ' ' from T1.ContratoNome))=0))");
         }
         if ( AV76Contratowwds_19_tfcontratosituacao_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV76Contratowwds_19_tfcontratosituacao_sels, "T1.ContratoSituacao IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV45OrderedBy == 1 ) && ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV45OrderedBy == 1 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV45OrderedBy == 2 ) && ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV45OrderedBy == 2 ) && ( AV13OrderedDsc ) )
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
                     return conditional_H004F3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (short)dynConstraints[22] , (bool)dynConstraints[23] , (int)dynConstraints[24] , (int)dynConstraints[25] );
               case 1 :
                     return conditional_H004F5(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (short)dynConstraints[22] , (bool)dynConstraints[23] , (int)dynConstraints[24] , (int)dynConstraints[25] );
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
          Object[] prmH004F3;
          prmH004F3 = new Object[] {
          new ParDef("AV58Contratowwds_1_contratoclienteid",GXType.Int32,9,0) ,
          new ParDef("lV59Contratowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Contratowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Contratowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Contratowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Contratowwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV62Contratowwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV63Contratowwds_6_contratoclientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV63Contratowwds_6_contratoclientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV67Contratowwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV67Contratowwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV68Contratowwds_11_contratoclientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV68Contratowwds_11_contratoclientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV72Contratowwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV72Contratowwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV73Contratowwds_16_contratoclientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV73Contratowwds_16_contratoclientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV74Contratowwds_17_tfcontratonome",GXType.VarChar,125,0) ,
          new ParDef("AV75Contratowwds_18_tfcontratonome_sel",GXType.VarChar,125,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH004F5;
          prmH004F5 = new Object[] {
          new ParDef("AV58Contratowwds_1_contratoclienteid",GXType.Int32,9,0) ,
          new ParDef("lV59Contratowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Contratowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Contratowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Contratowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Contratowwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV62Contratowwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV63Contratowwds_6_contratoclientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV63Contratowwds_6_contratoclientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV67Contratowwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV67Contratowwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV68Contratowwds_11_contratoclientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV68Contratowwds_11_contratoclientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV72Contratowwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV72Contratowwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV73Contratowwds_16_contratoclientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV73Contratowwds_16_contratoclientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV74Contratowwds_17_tfcontratonome",GXType.VarChar,125,0) ,
          new ParDef("AV75Contratowwds_18_tfcontratonome_sel",GXType.VarChar,125,0)
          };
          def= new CursorDef[] {
              new CursorDef("H004F3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004F3,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004F5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004F5,1, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
