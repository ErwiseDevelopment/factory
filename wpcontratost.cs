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
   public class wpcontratost : GXDataArea
   {
      public wpcontratost( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpcontratost( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_ClienteId )
      {
         this.AV7ClienteId = aP0_ClienteId;
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
         cmbContratoSituacao = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "ClienteId");
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
               gxfirstwebparm = GetFirstPar( "ClienteId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "ClienteId");
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
         nRC_GXsfl_116 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_116"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_116_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_116_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_116_idx = GetPar( "sGXsfl_116_idx");
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
         AV14OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV15OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         cmbavDynamicfiltersselector1.FromJSonString( GetNextPar( ));
         AV17DynamicFiltersSelector1 = GetPar( "DynamicFiltersSelector1");
         cmbavDynamicfiltersoperator1.FromJSonString( GetNextPar( ));
         AV18DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator1"), "."), 18, MidpointRounding.ToEven));
         AV19ContratoNome1 = GetPar( "ContratoNome1");
         AV20ContratoClienteDocumento1 = GetPar( "ContratoClienteDocumento1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV22DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV23DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV24ContratoNome2 = GetPar( "ContratoNome2");
         AV25ContratoClienteDocumento2 = GetPar( "ContratoClienteDocumento2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV27DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV28DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV29ContratoNome3 = GetPar( "ContratoNome3");
         AV30ContratoClienteDocumento3 = GetPar( "ContratoClienteDocumento3");
         AV7ClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "ClienteId"), "."), 18, MidpointRounding.ToEven));
         AV38ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV21DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV26DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV64Pgmname = GetPar( "Pgmname");
         AV16FilterFullText = GetPar( "FilterFullText");
         AV39TFContratoNome = GetPar( "TFContratoNome");
         AV40TFContratoNome_Sel = GetPar( "TFContratoNome_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV60TFContratoSituacao_Sels);
         AV62TFContratoCountAssinantes_F = (short)(Math.Round(NumberUtil.Val( GetPar( "TFContratoCountAssinantes_F"), "."), 18, MidpointRounding.ToEven));
         AV63TFContratoCountAssinantes_F_To = (short)(Math.Round(NumberUtil.Val( GetPar( "TFContratoCountAssinantes_F_To"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV11GridState);
         AV32DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV31DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19ContratoNome1, AV20ContratoClienteDocumento1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24ContratoNome2, AV25ContratoClienteDocumento2, AV27DynamicFiltersSelector3, AV28DynamicFiltersOperator3, AV29ContratoNome3, AV30ContratoClienteDocumento3, AV7ClienteId, AV38ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV26DynamicFiltersEnabled3, AV64Pgmname, AV16FilterFullText, AV39TFContratoNome, AV40TFContratoNome_Sel, AV60TFContratoSituacao_Sels, AV62TFContratoCountAssinantes_F, AV63TFContratoCountAssinantes_F_To, AV11GridState, AV32DynamicFiltersIgnoreFirst, AV31DynamicFiltersRemoving) ;
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
         PA9Q2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START9Q2( ) ;
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
         GXEncryptionTmp = "wpcontratost"+UrlEncode(StringUtil.LTrimStr(AV7ClienteId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpcontratost") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV64Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV64Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ClienteId), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV15OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV17DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18DynamicFiltersOperator1), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCONTRATONOME1", AV19ContratoNome1);
         GxWebStd.gx_hidden_field( context, "GXH_vCONTRATOCLIENTEDOCUMENTO1", AV20ContratoClienteDocumento1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV22DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCONTRATONOME2", AV24ContratoNome2);
         GxWebStd.gx_hidden_field( context, "GXH_vCONTRATOCLIENTEDOCUMENTO2", AV25ContratoClienteDocumento2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV27DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCONTRATONOME3", AV29ContratoNome3);
         GxWebStd.gx_hidden_field( context, "GXH_vCONTRATOCLIENTEDOCUMENTO3", AV30ContratoClienteDocumento3);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_116", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_116), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV36ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV36ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV54GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV55GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV56GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV52DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV52DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV38ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV21DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV26DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV64Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV64Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFCONTRATONOME", AV39TFContratoNome);
         GxWebStd.gx_hidden_field( context, "vTFCONTRATONOME_SEL", AV40TFContratoNome_Sel);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFCONTRATOSITUACAO_SELS", AV60TFContratoSituacao_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFCONTRATOSITUACAO_SELS", AV60TFContratoSituacao_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFCONTRATOCOUNTASSINANTES_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV62TFContratoCountAssinantes_F), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFCONTRATOCOUNTASSINANTES_F_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV63TFContratoCountAssinantes_F_To), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV15OrderedDsc);
         GxWebStd.gx_hidden_field( context, "vCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ClienteId), "ZZZZZZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV32DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV31DynamicFiltersRemoving);
         GxWebStd.gx_hidden_field( context, "vTFCONTRATOSITUACAO_SELSJSON", AV59TFContratoSituacao_SelsJson);
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_set", StringUtil.RTrim( Ddo_grid_Filteredtextto_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filterisrange", StringUtil.RTrim( Ddo_grid_Filterisrange));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Allowmultipleselection", StringUtil.RTrim( Ddo_grid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistfixedvalues", StringUtil.RTrim( Ddo_grid_Datalistfixedvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
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
            WE9Q2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT9Q2( ) ;
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
         GXEncryptionTmp = "wpcontratost"+UrlEncode(StringUtil.LTrimStr(AV7ClienteId,9,0));
         return formatLink("wpcontratost") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WpContratosT" ;
      }

      public override string GetPgmdesc( )
      {
         return " Contrato" ;
      }

      protected void WB9Q0( )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "Button ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(116), 3, 0)+","+"null"+");", "Inserir", bttBtninsert_Jsonclick, 5, "Inserir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpContratosT.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "ButtonExcel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(116), 3, 0)+","+"null"+");", "Excel", bttBtnexport_Jsonclick, 5, "Exportar para Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpContratosT.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV36ManageFiltersData);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'" + sGXsfl_116_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV16FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV16FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_WpContratosT.htm");
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WpContratosT.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'" + sGXsfl_116_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV17DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "", true, 0, "HLP_WpContratosT.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV17DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WpContratosT.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_45_9Q2( true) ;
         }
         else
         {
            wb_table1_45_9Q2( false) ;
         }
         return  ;
      }

      protected void wb_table1_45_9Q2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WpContratosT.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_116_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV22DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "", true, 0, "HLP_WpContratosT.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WpContratosT.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_70_9Q2( true) ;
         }
         else
         {
            wb_table2_70_9Q2( false) ;
         }
         return  ;
      }

      protected void wb_table2_70_9Q2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WpContratosT.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'" + sGXsfl_116_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV27DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "", true, 0, "HLP_WpContratosT.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV27DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WpContratosT.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_95_9Q2( true) ;
         }
         else
         {
            wb_table3_95_9Q2( false) ;
         }
         return  ;
      }

      protected void wb_table3_95_9Q2e( bool wbgen )
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
            StartGridControl116( ) ;
         }
         if ( wbEnd == 116 )
         {
            wbEnd = 0;
            nRC_GXsfl_116 = (int)(nGXsfl_116_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV54GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV55GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV56GridAppliedFilters);
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
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_WpContratosT.htm");
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
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV52DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 116 )
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

      protected void START9Q2( )
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
         STRUP9Q0( ) ;
      }

      protected void WS9Q2( )
      {
         START9Q2( ) ;
         EVT9Q2( ) ;
      }

      protected void EVT9Q2( )
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
                              E119Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E129Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E139Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E149Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E159Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E169Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E179Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E189Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E199Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E209Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E219Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E229Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E239Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E249Q2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_116_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_116_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_116_idx), 4, 0), 4, "0");
                              SubsflControlProps_1162( ) ;
                              A227ContratoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtContratoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n227ContratoId = false;
                              A228ContratoNome = cgiGet( edtContratoNome_Internalname);
                              n228ContratoNome = false;
                              cmbContratoSituacao.Name = cmbContratoSituacao_Internalname;
                              cmbContratoSituacao.CurrentValue = cgiGet( cmbContratoSituacao_Internalname);
                              A471ContratoSituacao = cgiGet( cmbContratoSituacao_Internalname);
                              n471ContratoSituacao = false;
                              A1007ContratoCountAssinantes_F = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtContratoCountAssinantes_F_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n1007ContratoCountAssinantes_F = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E259Q2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E269Q2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E279Q2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV14OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV15OrderedDsc )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV17DynamicFiltersSelector1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator1 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV18DynamicFiltersOperator1 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Contratonome1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATONOME1"), AV19ContratoNome1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Contratoclientedocumento1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATOCLIENTEDOCUMENTO1"), AV20ContratoClienteDocumento1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV22DynamicFiltersSelector2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV23DynamicFiltersOperator2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Contratonome2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATONOME2"), AV24ContratoNome2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Contratoclientedocumento2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATOCLIENTEDOCUMENTO2"), AV25ContratoClienteDocumento2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV27DynamicFiltersSelector3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV28DynamicFiltersOperator3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Contratonome3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATONOME3"), AV29ContratoNome3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Contratoclientedocumento3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATOCLIENTEDOCUMENTO3"), AV30ContratoClienteDocumento3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
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
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE9Q2( )
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

      protected void PA9Q2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpcontratost")), "wpcontratost") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpcontratost")))) ;
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
                  gxfirstwebparm = GetFirstPar( "ClienteId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV7ClienteId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV7ClienteId", StringUtil.LTrimStr( (decimal)(AV7ClienteId), 9, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ClienteId), "ZZZZZZZZ9"), context));
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
         SubsflControlProps_1162( ) ;
         while ( nGXsfl_116_idx <= nRC_GXsfl_116 )
         {
            sendrow_1162( ) ;
            nGXsfl_116_idx = ((subGrid_Islastpage==1)&&(nGXsfl_116_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_116_idx+1);
            sGXsfl_116_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_116_idx), 4, 0), 4, "0");
            SubsflControlProps_1162( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV14OrderedBy ,
                                       bool AV15OrderedDsc ,
                                       string AV17DynamicFiltersSelector1 ,
                                       short AV18DynamicFiltersOperator1 ,
                                       string AV19ContratoNome1 ,
                                       string AV20ContratoClienteDocumento1 ,
                                       string AV22DynamicFiltersSelector2 ,
                                       short AV23DynamicFiltersOperator2 ,
                                       string AV24ContratoNome2 ,
                                       string AV25ContratoClienteDocumento2 ,
                                       string AV27DynamicFiltersSelector3 ,
                                       short AV28DynamicFiltersOperator3 ,
                                       string AV29ContratoNome3 ,
                                       string AV30ContratoClienteDocumento3 ,
                                       int AV7ClienteId ,
                                       short AV38ManageFiltersExecutionStep ,
                                       bool AV21DynamicFiltersEnabled2 ,
                                       bool AV26DynamicFiltersEnabled3 ,
                                       string AV64Pgmname ,
                                       string AV16FilterFullText ,
                                       string AV39TFContratoNome ,
                                       string AV40TFContratoNome_Sel ,
                                       GxSimpleCollection<string> AV60TFContratoSituacao_Sels ,
                                       short AV62TFContratoCountAssinantes_F ,
                                       short AV63TFContratoCountAssinantes_F_To ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ,
                                       bool AV32DynamicFiltersIgnoreFirst ,
                                       bool AV31DynamicFiltersRemoving )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF9Q2( ) ;
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
            AV17DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV17DynamicFiltersSelector1);
            AssignAttri("", false, "AV17DynamicFiltersSelector1", AV17DynamicFiltersSelector1);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV17DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV18DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV18DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV22DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV22DynamicFiltersSelector2);
            AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV23DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV27DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV27DynamicFiltersSelector3);
            AssignAttri("", false, "AV27DynamicFiltersSelector3", AV27DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV27DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV28DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV28DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV28DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF9Q2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV64Pgmname = "WpContratosT";
      }

      protected void RF9Q2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 116;
         /* Execute user event: Refresh */
         E269Q2 ();
         nGXsfl_116_idx = 1;
         sGXsfl_116_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_116_idx), 4, 0), 4, "0");
         SubsflControlProps_1162( ) ;
         bGXsfl_116_Refreshing = true;
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
            SubsflControlProps_1162( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A471ContratoSituacao ,
                                                 AV82Wpcontratostds_18_tfcontratosituacao_sels ,
                                                 AV66Wpcontratostds_2_dynamicfiltersselector1 ,
                                                 AV67Wpcontratostds_3_dynamicfiltersoperator1 ,
                                                 AV68Wpcontratostds_4_contratonome1 ,
                                                 AV69Wpcontratostds_5_contratoclientedocumento1 ,
                                                 AV70Wpcontratostds_6_dynamicfiltersenabled2 ,
                                                 AV71Wpcontratostds_7_dynamicfiltersselector2 ,
                                                 AV72Wpcontratostds_8_dynamicfiltersoperator2 ,
                                                 AV73Wpcontratostds_9_contratonome2 ,
                                                 AV74Wpcontratostds_10_contratoclientedocumento2 ,
                                                 AV75Wpcontratostds_11_dynamicfiltersenabled3 ,
                                                 AV76Wpcontratostds_12_dynamicfiltersselector3 ,
                                                 AV77Wpcontratostds_13_dynamicfiltersoperator3 ,
                                                 AV78Wpcontratostds_14_contratonome3 ,
                                                 AV79Wpcontratostds_15_contratoclientedocumento3 ,
                                                 AV81Wpcontratostds_17_tfcontratonome_sel ,
                                                 AV80Wpcontratostds_16_tfcontratonome ,
                                                 AV82Wpcontratostds_18_tfcontratosituacao_sels.Count ,
                                                 A228ContratoNome ,
                                                 A475ContratoClienteDocumento ,
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc ,
                                                 AV65Wpcontratostds_1_filterfulltext ,
                                                 A1007ContratoCountAssinantes_F ,
                                                 AV83Wpcontratostds_19_tfcontratocountassinantes_f ,
                                                 AV84Wpcontratostds_20_tfcontratocountassinantes_f_to ,
                                                 A473ContratoClienteId ,
                                                 AV7ClienteId } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                                 }
            });
            lV65Wpcontratostds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wpcontratostds_1_filterfulltext), "%", "");
            lV65Wpcontratostds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wpcontratostds_1_filterfulltext), "%", "");
            lV65Wpcontratostds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wpcontratostds_1_filterfulltext), "%", "");
            lV65Wpcontratostds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wpcontratostds_1_filterfulltext), "%", "");
            lV65Wpcontratostds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wpcontratostds_1_filterfulltext), "%", "");
            lV68Wpcontratostds_4_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV68Wpcontratostds_4_contratonome1), "%", "");
            lV68Wpcontratostds_4_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV68Wpcontratostds_4_contratonome1), "%", "");
            lV69Wpcontratostds_5_contratoclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV69Wpcontratostds_5_contratoclientedocumento1), "%", "");
            lV69Wpcontratostds_5_contratoclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV69Wpcontratostds_5_contratoclientedocumento1), "%", "");
            lV73Wpcontratostds_9_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV73Wpcontratostds_9_contratonome2), "%", "");
            lV73Wpcontratostds_9_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV73Wpcontratostds_9_contratonome2), "%", "");
            lV74Wpcontratostds_10_contratoclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV74Wpcontratostds_10_contratoclientedocumento2), "%", "");
            lV74Wpcontratostds_10_contratoclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV74Wpcontratostds_10_contratoclientedocumento2), "%", "");
            lV78Wpcontratostds_14_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV78Wpcontratostds_14_contratonome3), "%", "");
            lV78Wpcontratostds_14_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV78Wpcontratostds_14_contratonome3), "%", "");
            lV79Wpcontratostds_15_contratoclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV79Wpcontratostds_15_contratoclientedocumento3), "%", "");
            lV79Wpcontratostds_15_contratoclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV79Wpcontratostds_15_contratoclientedocumento3), "%", "");
            lV80Wpcontratostds_16_tfcontratonome = StringUtil.Concat( StringUtil.RTrim( AV80Wpcontratostds_16_tfcontratonome), "%", "");
            /* Using cursor H009Q3 */
            pr_default.execute(0, new Object[] {AV65Wpcontratostds_1_filterfulltext, lV65Wpcontratostds_1_filterfulltext, lV65Wpcontratostds_1_filterfulltext, lV65Wpcontratostds_1_filterfulltext, lV65Wpcontratostds_1_filterfulltext, lV65Wpcontratostds_1_filterfulltext, AV83Wpcontratostds_19_tfcontratocountassinantes_f, AV83Wpcontratostds_19_tfcontratocountassinantes_f, AV84Wpcontratostds_20_tfcontratocountassinantes_f_to, AV84Wpcontratostds_20_tfcontratocountassinantes_f_to, AV7ClienteId, lV68Wpcontratostds_4_contratonome1, lV68Wpcontratostds_4_contratonome1, lV69Wpcontratostds_5_contratoclientedocumento1, lV69Wpcontratostds_5_contratoclientedocumento1, lV73Wpcontratostds_9_contratonome2, lV73Wpcontratostds_9_contratonome2, lV74Wpcontratostds_10_contratoclientedocumento2, lV74Wpcontratostds_10_contratoclientedocumento2, lV78Wpcontratostds_14_contratonome3, lV78Wpcontratostds_14_contratonome3, lV79Wpcontratostds_15_contratoclientedocumento3, lV79Wpcontratostds_15_contratoclientedocumento3, lV80Wpcontratostds_16_tfcontratonome, AV81Wpcontratostds_17_tfcontratonome_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_116_idx = 1;
            sGXsfl_116_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_116_idx), 4, 0), 4, "0");
            SubsflControlProps_1162( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A473ContratoClienteId = H009Q3_A473ContratoClienteId[0];
               n473ContratoClienteId = H009Q3_n473ContratoClienteId[0];
               A475ContratoClienteDocumento = H009Q3_A475ContratoClienteDocumento[0];
               n475ContratoClienteDocumento = H009Q3_n475ContratoClienteDocumento[0];
               A471ContratoSituacao = H009Q3_A471ContratoSituacao[0];
               n471ContratoSituacao = H009Q3_n471ContratoSituacao[0];
               A228ContratoNome = H009Q3_A228ContratoNome[0];
               n228ContratoNome = H009Q3_n228ContratoNome[0];
               A227ContratoId = H009Q3_A227ContratoId[0];
               n227ContratoId = H009Q3_n227ContratoId[0];
               A1007ContratoCountAssinantes_F = H009Q3_A1007ContratoCountAssinantes_F[0];
               n1007ContratoCountAssinantes_F = H009Q3_n1007ContratoCountAssinantes_F[0];
               A475ContratoClienteDocumento = H009Q3_A475ContratoClienteDocumento[0];
               n475ContratoClienteDocumento = H009Q3_n475ContratoClienteDocumento[0];
               A1007ContratoCountAssinantes_F = H009Q3_A1007ContratoCountAssinantes_F[0];
               n1007ContratoCountAssinantes_F = H009Q3_n1007ContratoCountAssinantes_F[0];
               /* Execute user event: Grid.Load */
               E279Q2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 116;
            WB9Q0( ) ;
         }
         bGXsfl_116_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes9Q2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV64Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV64Pgmname, "")), context));
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
         AV65Wpcontratostds_1_filterfulltext = AV16FilterFullText;
         AV66Wpcontratostds_2_dynamicfiltersselector1 = AV17DynamicFiltersSelector1;
         AV67Wpcontratostds_3_dynamicfiltersoperator1 = AV18DynamicFiltersOperator1;
         AV68Wpcontratostds_4_contratonome1 = AV19ContratoNome1;
         AV69Wpcontratostds_5_contratoclientedocumento1 = AV20ContratoClienteDocumento1;
         AV70Wpcontratostds_6_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV71Wpcontratostds_7_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV72Wpcontratostds_8_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV73Wpcontratostds_9_contratonome2 = AV24ContratoNome2;
         AV74Wpcontratostds_10_contratoclientedocumento2 = AV25ContratoClienteDocumento2;
         AV75Wpcontratostds_11_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV76Wpcontratostds_12_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV77Wpcontratostds_13_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV78Wpcontratostds_14_contratonome3 = AV29ContratoNome3;
         AV79Wpcontratostds_15_contratoclientedocumento3 = AV30ContratoClienteDocumento3;
         AV80Wpcontratostds_16_tfcontratonome = AV39TFContratoNome;
         AV81Wpcontratostds_17_tfcontratonome_sel = AV40TFContratoNome_Sel;
         AV82Wpcontratostds_18_tfcontratosituacao_sels = AV60TFContratoSituacao_Sels;
         AV83Wpcontratostds_19_tfcontratocountassinantes_f = AV62TFContratoCountAssinantes_F;
         AV84Wpcontratostds_20_tfcontratocountassinantes_f_to = AV63TFContratoCountAssinantes_F_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A471ContratoSituacao ,
                                              AV82Wpcontratostds_18_tfcontratosituacao_sels ,
                                              AV66Wpcontratostds_2_dynamicfiltersselector1 ,
                                              AV67Wpcontratostds_3_dynamicfiltersoperator1 ,
                                              AV68Wpcontratostds_4_contratonome1 ,
                                              AV69Wpcontratostds_5_contratoclientedocumento1 ,
                                              AV70Wpcontratostds_6_dynamicfiltersenabled2 ,
                                              AV71Wpcontratostds_7_dynamicfiltersselector2 ,
                                              AV72Wpcontratostds_8_dynamicfiltersoperator2 ,
                                              AV73Wpcontratostds_9_contratonome2 ,
                                              AV74Wpcontratostds_10_contratoclientedocumento2 ,
                                              AV75Wpcontratostds_11_dynamicfiltersenabled3 ,
                                              AV76Wpcontratostds_12_dynamicfiltersselector3 ,
                                              AV77Wpcontratostds_13_dynamicfiltersoperator3 ,
                                              AV78Wpcontratostds_14_contratonome3 ,
                                              AV79Wpcontratostds_15_contratoclientedocumento3 ,
                                              AV81Wpcontratostds_17_tfcontratonome_sel ,
                                              AV80Wpcontratostds_16_tfcontratonome ,
                                              AV82Wpcontratostds_18_tfcontratosituacao_sels.Count ,
                                              A228ContratoNome ,
                                              A475ContratoClienteDocumento ,
                                              AV14OrderedBy ,
                                              AV15OrderedDsc ,
                                              AV65Wpcontratostds_1_filterfulltext ,
                                              A1007ContratoCountAssinantes_F ,
                                              AV83Wpcontratostds_19_tfcontratocountassinantes_f ,
                                              AV84Wpcontratostds_20_tfcontratocountassinantes_f_to ,
                                              A473ContratoClienteId ,
                                              AV7ClienteId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV65Wpcontratostds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wpcontratostds_1_filterfulltext), "%", "");
         lV65Wpcontratostds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wpcontratostds_1_filterfulltext), "%", "");
         lV65Wpcontratostds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wpcontratostds_1_filterfulltext), "%", "");
         lV65Wpcontratostds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wpcontratostds_1_filterfulltext), "%", "");
         lV65Wpcontratostds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wpcontratostds_1_filterfulltext), "%", "");
         lV68Wpcontratostds_4_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV68Wpcontratostds_4_contratonome1), "%", "");
         lV68Wpcontratostds_4_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV68Wpcontratostds_4_contratonome1), "%", "");
         lV69Wpcontratostds_5_contratoclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV69Wpcontratostds_5_contratoclientedocumento1), "%", "");
         lV69Wpcontratostds_5_contratoclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV69Wpcontratostds_5_contratoclientedocumento1), "%", "");
         lV73Wpcontratostds_9_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV73Wpcontratostds_9_contratonome2), "%", "");
         lV73Wpcontratostds_9_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV73Wpcontratostds_9_contratonome2), "%", "");
         lV74Wpcontratostds_10_contratoclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV74Wpcontratostds_10_contratoclientedocumento2), "%", "");
         lV74Wpcontratostds_10_contratoclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV74Wpcontratostds_10_contratoclientedocumento2), "%", "");
         lV78Wpcontratostds_14_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV78Wpcontratostds_14_contratonome3), "%", "");
         lV78Wpcontratostds_14_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV78Wpcontratostds_14_contratonome3), "%", "");
         lV79Wpcontratostds_15_contratoclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV79Wpcontratostds_15_contratoclientedocumento3), "%", "");
         lV79Wpcontratostds_15_contratoclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV79Wpcontratostds_15_contratoclientedocumento3), "%", "");
         lV80Wpcontratostds_16_tfcontratonome = StringUtil.Concat( StringUtil.RTrim( AV80Wpcontratostds_16_tfcontratonome), "%", "");
         /* Using cursor H009Q5 */
         pr_default.execute(1, new Object[] {AV65Wpcontratostds_1_filterfulltext, lV65Wpcontratostds_1_filterfulltext, lV65Wpcontratostds_1_filterfulltext, lV65Wpcontratostds_1_filterfulltext, lV65Wpcontratostds_1_filterfulltext, lV65Wpcontratostds_1_filterfulltext, AV83Wpcontratostds_19_tfcontratocountassinantes_f, AV83Wpcontratostds_19_tfcontratocountassinantes_f, AV84Wpcontratostds_20_tfcontratocountassinantes_f_to, AV84Wpcontratostds_20_tfcontratocountassinantes_f_to, AV7ClienteId, lV68Wpcontratostds_4_contratonome1, lV68Wpcontratostds_4_contratonome1, lV69Wpcontratostds_5_contratoclientedocumento1, lV69Wpcontratostds_5_contratoclientedocumento1, lV73Wpcontratostds_9_contratonome2, lV73Wpcontratostds_9_contratonome2, lV74Wpcontratostds_10_contratoclientedocumento2, lV74Wpcontratostds_10_contratoclientedocumento2, lV78Wpcontratostds_14_contratonome3, lV78Wpcontratostds_14_contratonome3, lV79Wpcontratostds_15_contratoclientedocumento3, lV79Wpcontratostds_15_contratoclientedocumento3, lV80Wpcontratostds_16_tfcontratonome, AV81Wpcontratostds_17_tfcontratonome_sel});
         GRID_nRecordCount = H009Q5_AGRID_nRecordCount[0];
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
         AV65Wpcontratostds_1_filterfulltext = AV16FilterFullText;
         AV66Wpcontratostds_2_dynamicfiltersselector1 = AV17DynamicFiltersSelector1;
         AV67Wpcontratostds_3_dynamicfiltersoperator1 = AV18DynamicFiltersOperator1;
         AV68Wpcontratostds_4_contratonome1 = AV19ContratoNome1;
         AV69Wpcontratostds_5_contratoclientedocumento1 = AV20ContratoClienteDocumento1;
         AV70Wpcontratostds_6_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV71Wpcontratostds_7_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV72Wpcontratostds_8_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV73Wpcontratostds_9_contratonome2 = AV24ContratoNome2;
         AV74Wpcontratostds_10_contratoclientedocumento2 = AV25ContratoClienteDocumento2;
         AV75Wpcontratostds_11_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV76Wpcontratostds_12_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV77Wpcontratostds_13_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV78Wpcontratostds_14_contratonome3 = AV29ContratoNome3;
         AV79Wpcontratostds_15_contratoclientedocumento3 = AV30ContratoClienteDocumento3;
         AV80Wpcontratostds_16_tfcontratonome = AV39TFContratoNome;
         AV81Wpcontratostds_17_tfcontratonome_sel = AV40TFContratoNome_Sel;
         AV82Wpcontratostds_18_tfcontratosituacao_sels = AV60TFContratoSituacao_Sels;
         AV83Wpcontratostds_19_tfcontratocountassinantes_f = AV62TFContratoCountAssinantes_F;
         AV84Wpcontratostds_20_tfcontratocountassinantes_f_to = AV63TFContratoCountAssinantes_F_To;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19ContratoNome1, AV20ContratoClienteDocumento1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24ContratoNome2, AV25ContratoClienteDocumento2, AV27DynamicFiltersSelector3, AV28DynamicFiltersOperator3, AV29ContratoNome3, AV30ContratoClienteDocumento3, AV7ClienteId, AV38ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV26DynamicFiltersEnabled3, AV64Pgmname, AV16FilterFullText, AV39TFContratoNome, AV40TFContratoNome_Sel, AV60TFContratoSituacao_Sels, AV62TFContratoCountAssinantes_F, AV63TFContratoCountAssinantes_F_To, AV11GridState, AV32DynamicFiltersIgnoreFirst, AV31DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV65Wpcontratostds_1_filterfulltext = AV16FilterFullText;
         AV66Wpcontratostds_2_dynamicfiltersselector1 = AV17DynamicFiltersSelector1;
         AV67Wpcontratostds_3_dynamicfiltersoperator1 = AV18DynamicFiltersOperator1;
         AV68Wpcontratostds_4_contratonome1 = AV19ContratoNome1;
         AV69Wpcontratostds_5_contratoclientedocumento1 = AV20ContratoClienteDocumento1;
         AV70Wpcontratostds_6_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV71Wpcontratostds_7_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV72Wpcontratostds_8_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV73Wpcontratostds_9_contratonome2 = AV24ContratoNome2;
         AV74Wpcontratostds_10_contratoclientedocumento2 = AV25ContratoClienteDocumento2;
         AV75Wpcontratostds_11_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV76Wpcontratostds_12_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV77Wpcontratostds_13_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV78Wpcontratostds_14_contratonome3 = AV29ContratoNome3;
         AV79Wpcontratostds_15_contratoclientedocumento3 = AV30ContratoClienteDocumento3;
         AV80Wpcontratostds_16_tfcontratonome = AV39TFContratoNome;
         AV81Wpcontratostds_17_tfcontratonome_sel = AV40TFContratoNome_Sel;
         AV82Wpcontratostds_18_tfcontratosituacao_sels = AV60TFContratoSituacao_Sels;
         AV83Wpcontratostds_19_tfcontratocountassinantes_f = AV62TFContratoCountAssinantes_F;
         AV84Wpcontratostds_20_tfcontratocountassinantes_f_to = AV63TFContratoCountAssinantes_F_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19ContratoNome1, AV20ContratoClienteDocumento1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24ContratoNome2, AV25ContratoClienteDocumento2, AV27DynamicFiltersSelector3, AV28DynamicFiltersOperator3, AV29ContratoNome3, AV30ContratoClienteDocumento3, AV7ClienteId, AV38ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV26DynamicFiltersEnabled3, AV64Pgmname, AV16FilterFullText, AV39TFContratoNome, AV40TFContratoNome_Sel, AV60TFContratoSituacao_Sels, AV62TFContratoCountAssinantes_F, AV63TFContratoCountAssinantes_F_To, AV11GridState, AV32DynamicFiltersIgnoreFirst, AV31DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV65Wpcontratostds_1_filterfulltext = AV16FilterFullText;
         AV66Wpcontratostds_2_dynamicfiltersselector1 = AV17DynamicFiltersSelector1;
         AV67Wpcontratostds_3_dynamicfiltersoperator1 = AV18DynamicFiltersOperator1;
         AV68Wpcontratostds_4_contratonome1 = AV19ContratoNome1;
         AV69Wpcontratostds_5_contratoclientedocumento1 = AV20ContratoClienteDocumento1;
         AV70Wpcontratostds_6_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV71Wpcontratostds_7_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV72Wpcontratostds_8_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV73Wpcontratostds_9_contratonome2 = AV24ContratoNome2;
         AV74Wpcontratostds_10_contratoclientedocumento2 = AV25ContratoClienteDocumento2;
         AV75Wpcontratostds_11_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV76Wpcontratostds_12_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV77Wpcontratostds_13_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV78Wpcontratostds_14_contratonome3 = AV29ContratoNome3;
         AV79Wpcontratostds_15_contratoclientedocumento3 = AV30ContratoClienteDocumento3;
         AV80Wpcontratostds_16_tfcontratonome = AV39TFContratoNome;
         AV81Wpcontratostds_17_tfcontratonome_sel = AV40TFContratoNome_Sel;
         AV82Wpcontratostds_18_tfcontratosituacao_sels = AV60TFContratoSituacao_Sels;
         AV83Wpcontratostds_19_tfcontratocountassinantes_f = AV62TFContratoCountAssinantes_F;
         AV84Wpcontratostds_20_tfcontratocountassinantes_f_to = AV63TFContratoCountAssinantes_F_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19ContratoNome1, AV20ContratoClienteDocumento1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24ContratoNome2, AV25ContratoClienteDocumento2, AV27DynamicFiltersSelector3, AV28DynamicFiltersOperator3, AV29ContratoNome3, AV30ContratoClienteDocumento3, AV7ClienteId, AV38ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV26DynamicFiltersEnabled3, AV64Pgmname, AV16FilterFullText, AV39TFContratoNome, AV40TFContratoNome_Sel, AV60TFContratoSituacao_Sels, AV62TFContratoCountAssinantes_F, AV63TFContratoCountAssinantes_F_To, AV11GridState, AV32DynamicFiltersIgnoreFirst, AV31DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV65Wpcontratostds_1_filterfulltext = AV16FilterFullText;
         AV66Wpcontratostds_2_dynamicfiltersselector1 = AV17DynamicFiltersSelector1;
         AV67Wpcontratostds_3_dynamicfiltersoperator1 = AV18DynamicFiltersOperator1;
         AV68Wpcontratostds_4_contratonome1 = AV19ContratoNome1;
         AV69Wpcontratostds_5_contratoclientedocumento1 = AV20ContratoClienteDocumento1;
         AV70Wpcontratostds_6_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV71Wpcontratostds_7_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV72Wpcontratostds_8_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV73Wpcontratostds_9_contratonome2 = AV24ContratoNome2;
         AV74Wpcontratostds_10_contratoclientedocumento2 = AV25ContratoClienteDocumento2;
         AV75Wpcontratostds_11_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV76Wpcontratostds_12_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV77Wpcontratostds_13_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV78Wpcontratostds_14_contratonome3 = AV29ContratoNome3;
         AV79Wpcontratostds_15_contratoclientedocumento3 = AV30ContratoClienteDocumento3;
         AV80Wpcontratostds_16_tfcontratonome = AV39TFContratoNome;
         AV81Wpcontratostds_17_tfcontratonome_sel = AV40TFContratoNome_Sel;
         AV82Wpcontratostds_18_tfcontratosituacao_sels = AV60TFContratoSituacao_Sels;
         AV83Wpcontratostds_19_tfcontratocountassinantes_f = AV62TFContratoCountAssinantes_F;
         AV84Wpcontratostds_20_tfcontratocountassinantes_f_to = AV63TFContratoCountAssinantes_F_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19ContratoNome1, AV20ContratoClienteDocumento1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24ContratoNome2, AV25ContratoClienteDocumento2, AV27DynamicFiltersSelector3, AV28DynamicFiltersOperator3, AV29ContratoNome3, AV30ContratoClienteDocumento3, AV7ClienteId, AV38ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV26DynamicFiltersEnabled3, AV64Pgmname, AV16FilterFullText, AV39TFContratoNome, AV40TFContratoNome_Sel, AV60TFContratoSituacao_Sels, AV62TFContratoCountAssinantes_F, AV63TFContratoCountAssinantes_F_To, AV11GridState, AV32DynamicFiltersIgnoreFirst, AV31DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV65Wpcontratostds_1_filterfulltext = AV16FilterFullText;
         AV66Wpcontratostds_2_dynamicfiltersselector1 = AV17DynamicFiltersSelector1;
         AV67Wpcontratostds_3_dynamicfiltersoperator1 = AV18DynamicFiltersOperator1;
         AV68Wpcontratostds_4_contratonome1 = AV19ContratoNome1;
         AV69Wpcontratostds_5_contratoclientedocumento1 = AV20ContratoClienteDocumento1;
         AV70Wpcontratostds_6_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV71Wpcontratostds_7_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV72Wpcontratostds_8_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV73Wpcontratostds_9_contratonome2 = AV24ContratoNome2;
         AV74Wpcontratostds_10_contratoclientedocumento2 = AV25ContratoClienteDocumento2;
         AV75Wpcontratostds_11_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV76Wpcontratostds_12_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV77Wpcontratostds_13_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV78Wpcontratostds_14_contratonome3 = AV29ContratoNome3;
         AV79Wpcontratostds_15_contratoclientedocumento3 = AV30ContratoClienteDocumento3;
         AV80Wpcontratostds_16_tfcontratonome = AV39TFContratoNome;
         AV81Wpcontratostds_17_tfcontratonome_sel = AV40TFContratoNome_Sel;
         AV82Wpcontratostds_18_tfcontratosituacao_sels = AV60TFContratoSituacao_Sels;
         AV83Wpcontratostds_19_tfcontratocountassinantes_f = AV62TFContratoCountAssinantes_F;
         AV84Wpcontratostds_20_tfcontratocountassinantes_f_to = AV63TFContratoCountAssinantes_F_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19ContratoNome1, AV20ContratoClienteDocumento1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24ContratoNome2, AV25ContratoClienteDocumento2, AV27DynamicFiltersSelector3, AV28DynamicFiltersOperator3, AV29ContratoNome3, AV30ContratoClienteDocumento3, AV7ClienteId, AV38ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV26DynamicFiltersEnabled3, AV64Pgmname, AV16FilterFullText, AV39TFContratoNome, AV40TFContratoNome_Sel, AV60TFContratoSituacao_Sels, AV62TFContratoCountAssinantes_F, AV63TFContratoCountAssinantes_F_To, AV11GridState, AV32DynamicFiltersIgnoreFirst, AV31DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV64Pgmname = "WpContratosT";
         edtContratoId_Enabled = 0;
         edtContratoNome_Enabled = 0;
         cmbContratoSituacao.Enabled = 0;
         edtContratoCountAssinantes_F_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP9Q0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E259Q2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV36ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV52DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_116 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_116"), ",", "."), 18, MidpointRounding.ToEven));
            AV54GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV55GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV56GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            Ddo_grid_Filteredtextto_set = cgiGet( "DDO_GRID_Filteredtextto_set");
            Ddo_grid_Selectedvalue_set = cgiGet( "DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( "DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( "DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( "DDO_GRID_Filtertype");
            Ddo_grid_Filterisrange = cgiGet( "DDO_GRID_Filterisrange");
            Ddo_grid_Includedatalist = cgiGet( "DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( "DDO_GRID_Datalisttype");
            Ddo_grid_Allowmultipleselection = cgiGet( "DDO_GRID_Allowmultipleselection");
            Ddo_grid_Datalistfixedvalues = cgiGet( "DDO_GRID_Datalistfixedvalues");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Ddo_grid_Format = cgiGet( "DDO_GRID_Format");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV16FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
            cmbavDynamicfiltersselector1.Name = cmbavDynamicfiltersselector1_Internalname;
            cmbavDynamicfiltersselector1.CurrentValue = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AV17DynamicFiltersSelector1 = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AssignAttri("", false, "AV17DynamicFiltersSelector1", AV17DynamicFiltersSelector1);
            cmbavDynamicfiltersoperator1.Name = cmbavDynamicfiltersoperator1_Internalname;
            cmbavDynamicfiltersoperator1.CurrentValue = cgiGet( cmbavDynamicfiltersoperator1_Internalname);
            AV18DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator1_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV18DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
            AV19ContratoNome1 = cgiGet( edtavContratonome1_Internalname);
            AssignAttri("", false, "AV19ContratoNome1", AV19ContratoNome1);
            AV20ContratoClienteDocumento1 = cgiGet( edtavContratoclientedocumento1_Internalname);
            AssignAttri("", false, "AV20ContratoClienteDocumento1", AV20ContratoClienteDocumento1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV22DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV23DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
            AV24ContratoNome2 = cgiGet( edtavContratonome2_Internalname);
            AssignAttri("", false, "AV24ContratoNome2", AV24ContratoNome2);
            AV25ContratoClienteDocumento2 = cgiGet( edtavContratoclientedocumento2_Internalname);
            AssignAttri("", false, "AV25ContratoClienteDocumento2", AV25ContratoClienteDocumento2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV27DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV27DynamicFiltersSelector3", AV27DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV28DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV28DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
            AV29ContratoNome3 = cgiGet( edtavContratonome3_Internalname);
            AssignAttri("", false, "AV29ContratoNome3", AV29ContratoNome3);
            AV30ContratoClienteDocumento3 = cgiGet( edtavContratoclientedocumento3_Internalname);
            AssignAttri("", false, "AV30ContratoClienteDocumento3", AV30ContratoClienteDocumento3);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV14OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV15OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV17DynamicFiltersSelector1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV18DynamicFiltersOperator1 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATONOME1"), AV19ContratoNome1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATOCLIENTEDOCUMENTO1"), AV20ContratoClienteDocumento1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV22DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV23DynamicFiltersOperator2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATONOME2"), AV24ContratoNome2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATOCLIENTEDOCUMENTO2"), AV25ContratoClienteDocumento2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV27DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV28DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATONOME3"), AV29ContratoNome3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATOCLIENTEDOCUMENTO3"), AV30ContratoClienteDocumento3) != 0 )
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
         E259Q2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E259Q2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         if ( StringUtil.StrCmp(AV8HTTPRequest.Method, "GET") == 0 )
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
         AV17DynamicFiltersSelector1 = "CONTRATONOME";
         AssignAttri("", false, "AV17DynamicFiltersSelector1", AV17DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV22DynamicFiltersSelector2 = "CONTRATONOME";
         AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV27DynamicFiltersSelector3 = "CONTRATONOME";
         AssignAttri("", false, "AV27DynamicFiltersSelector3", AV27DynamicFiltersSelector3);
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
         if ( AV14OrderedBy < 1 )
         {
            AV14OrderedBy = 1;
            AssignAttri("", false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV52DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV52DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E269Q2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         if ( AV38ManageFiltersExecutionStep == 1 )
         {
            AV38ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV38ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV38ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV38ManageFiltersExecutionStep == 2 )
         {
            AV38ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV38ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV38ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         cmbavDynamicfiltersoperator1.removeAllItems();
         if ( StringUtil.StrCmp(AV17DynamicFiltersSelector1, "CONTRATONOME") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         else if ( StringUtil.StrCmp(AV17DynamicFiltersSelector1, "CONTRATOCLIENTEDOCUMENTO") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         if ( AV21DynamicFiltersEnabled2 )
         {
            cmbavDynamicfiltersoperator2.removeAllItems();
            if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CONTRATONOME") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CONTRATOCLIENTEDOCUMENTO") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            if ( AV26DynamicFiltersEnabled3 )
            {
               cmbavDynamicfiltersoperator3.removeAllItems();
               if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "CONTRATONOME") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "CONTRATOCLIENTEDOCUMENTO") == 0 )
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
         AV54GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV54GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV54GridCurrentPage), 10, 0));
         AV55GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV55GridPageCount", StringUtil.LTrimStr( (decimal)(AV55GridPageCount), 10, 0));
         GXt_char2 = AV56GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV64Pgmname, out  GXt_char2) ;
         AV56GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV56GridAppliedFilters", AV56GridAppliedFilters);
         cmbContratoSituacao_Columnheaderclass = "WWColumn";
         AssignProp("", false, cmbContratoSituacao_Internalname, "Columnheaderclass", cmbContratoSituacao_Columnheaderclass, !bGXsfl_116_Refreshing);
         AV65Wpcontratostds_1_filterfulltext = AV16FilterFullText;
         AV66Wpcontratostds_2_dynamicfiltersselector1 = AV17DynamicFiltersSelector1;
         AV67Wpcontratostds_3_dynamicfiltersoperator1 = AV18DynamicFiltersOperator1;
         AV68Wpcontratostds_4_contratonome1 = AV19ContratoNome1;
         AV69Wpcontratostds_5_contratoclientedocumento1 = AV20ContratoClienteDocumento1;
         AV70Wpcontratostds_6_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV71Wpcontratostds_7_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV72Wpcontratostds_8_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV73Wpcontratostds_9_contratonome2 = AV24ContratoNome2;
         AV74Wpcontratostds_10_contratoclientedocumento2 = AV25ContratoClienteDocumento2;
         AV75Wpcontratostds_11_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV76Wpcontratostds_12_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV77Wpcontratostds_13_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV78Wpcontratostds_14_contratonome3 = AV29ContratoNome3;
         AV79Wpcontratostds_15_contratoclientedocumento3 = AV30ContratoClienteDocumento3;
         AV80Wpcontratostds_16_tfcontratonome = AV39TFContratoNome;
         AV81Wpcontratostds_17_tfcontratonome_sel = AV40TFContratoNome_Sel;
         AV82Wpcontratostds_18_tfcontratosituacao_sels = AV60TFContratoSituacao_Sels;
         AV83Wpcontratostds_19_tfcontratocountassinantes_f = AV62TFContratoCountAssinantes_F;
         AV84Wpcontratostds_20_tfcontratocountassinantes_f_to = AV63TFContratoCountAssinantes_F_To;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV36ManageFiltersData", AV36ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E129Q2( )
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
            AV53PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV53PageToGo) ;
         }
      }

      protected void E139Q2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E149Q2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV14OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
            AV15OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV15OrderedDsc", AV15OrderedDsc);
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
               AV39TFContratoNome = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV39TFContratoNome", AV39TFContratoNome);
               AV40TFContratoNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV40TFContratoNome_Sel", AV40TFContratoNome_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ContratoSituacao") == 0 )
            {
               AV59TFContratoSituacao_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV59TFContratoSituacao_SelsJson", AV59TFContratoSituacao_SelsJson);
               AV60TFContratoSituacao_Sels.FromJSonString(AV59TFContratoSituacao_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ContratoCountAssinantes_F") == 0 )
            {
               AV62TFContratoCountAssinantes_F = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV62TFContratoCountAssinantes_F", StringUtil.LTrimStr( (decimal)(AV62TFContratoCountAssinantes_F), 4, 0));
               AV63TFContratoCountAssinantes_F_To = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV63TFContratoCountAssinantes_F_To", StringUtil.LTrimStr( (decimal)(AV63TFContratoCountAssinantes_F_To), 4, 0));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV60TFContratoSituacao_Sels", AV60TFContratoSituacao_Sels);
      }

      private void E279Q2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "contrato"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A227ContratoId,6,0));
         edtContratoNome_Link = formatLink("contrato") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         if ( StringUtil.StrCmp(A471ContratoSituacao, "EmElaboracao") == 0 )
         {
            cmbContratoSituacao_Columnclass = "WWColumn WWColumnGray WWColumnGraySingleCell";
         }
         else if ( StringUtil.StrCmp(A471ContratoSituacao, "ColetandoAssinatura") == 0 )
         {
            cmbContratoSituacao_Columnclass = "WWColumn WWColumnInfo WWColumnInfoSingleCell";
         }
         else if ( StringUtil.StrCmp(A471ContratoSituacao, "Assinado") == 0 )
         {
            cmbContratoSituacao_Columnclass = "WWColumn WWColumnSuccess WWColumnSuccessSingleCell";
         }
         else
         {
            cmbContratoSituacao_Columnclass = "WWColumn";
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 116;
         }
         sendrow_1162( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_116_Refreshing )
         {
            DoAjaxLoad(116, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E209Q2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV21DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV21DynamicFiltersEnabled2", AV21DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19ContratoNome1, AV20ContratoClienteDocumento1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24ContratoNome2, AV25ContratoClienteDocumento2, AV27DynamicFiltersSelector3, AV28DynamicFiltersOperator3, AV29ContratoNome3, AV30ContratoClienteDocumento3, AV7ClienteId, AV38ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV26DynamicFiltersEnabled3, AV64Pgmname, AV16FilterFullText, AV39TFContratoNome, AV40TFContratoNome_Sel, AV60TFContratoSituacao_Sels, AV62TFContratoCountAssinantes_F, AV63TFContratoCountAssinantes_F_To, AV11GridState, AV32DynamicFiltersIgnoreFirst, AV31DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV36ManageFiltersData", AV36ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E159Q2( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV31DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV31DynamicFiltersRemoving", AV31DynamicFiltersRemoving);
         AV32DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV32DynamicFiltersIgnoreFirst", AV32DynamicFiltersIgnoreFirst);
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
         AV31DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV31DynamicFiltersRemoving", AV31DynamicFiltersRemoving);
         AV32DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV32DynamicFiltersIgnoreFirst", AV32DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19ContratoNome1, AV20ContratoClienteDocumento1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24ContratoNome2, AV25ContratoClienteDocumento2, AV27DynamicFiltersSelector3, AV28DynamicFiltersOperator3, AV29ContratoNome3, AV30ContratoClienteDocumento3, AV7ClienteId, AV38ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV26DynamicFiltersEnabled3, AV64Pgmname, AV16FilterFullText, AV39TFContratoNome, AV40TFContratoNome_Sel, AV60TFContratoSituacao_Sels, AV62TFContratoCountAssinantes_F, AV63TFContratoCountAssinantes_F_To, AV11GridState, AV32DynamicFiltersIgnoreFirst, AV31DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV27DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV17DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV36ManageFiltersData", AV36ManageFiltersData);
      }

      protected void E219Q2( )
      {
         /* Dynamicfiltersselector1_Click Routine */
         returnInSub = false;
         AV18DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV18DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
      }

      protected void E229Q2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV26DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV26DynamicFiltersEnabled3", AV26DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19ContratoNome1, AV20ContratoClienteDocumento1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24ContratoNome2, AV25ContratoClienteDocumento2, AV27DynamicFiltersSelector3, AV28DynamicFiltersOperator3, AV29ContratoNome3, AV30ContratoClienteDocumento3, AV7ClienteId, AV38ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV26DynamicFiltersEnabled3, AV64Pgmname, AV16FilterFullText, AV39TFContratoNome, AV40TFContratoNome_Sel, AV60TFContratoSituacao_Sels, AV62TFContratoCountAssinantes_F, AV63TFContratoCountAssinantes_F_To, AV11GridState, AV32DynamicFiltersIgnoreFirst, AV31DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV36ManageFiltersData", AV36ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E169Q2( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV31DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV31DynamicFiltersRemoving", AV31DynamicFiltersRemoving);
         AV21DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV21DynamicFiltersEnabled2", AV21DynamicFiltersEnabled2);
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
         AV31DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV31DynamicFiltersRemoving", AV31DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19ContratoNome1, AV20ContratoClienteDocumento1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24ContratoNome2, AV25ContratoClienteDocumento2, AV27DynamicFiltersSelector3, AV28DynamicFiltersOperator3, AV29ContratoNome3, AV30ContratoClienteDocumento3, AV7ClienteId, AV38ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV26DynamicFiltersEnabled3, AV64Pgmname, AV16FilterFullText, AV39TFContratoNome, AV40TFContratoNome_Sel, AV60TFContratoSituacao_Sels, AV62TFContratoCountAssinantes_F, AV63TFContratoCountAssinantes_F_To, AV11GridState, AV32DynamicFiltersIgnoreFirst, AV31DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV27DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV17DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV36ManageFiltersData", AV36ManageFiltersData);
      }

      protected void E239Q2( )
      {
         /* Dynamicfiltersselector2_Click Routine */
         returnInSub = false;
         AV23DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
      }

      protected void E179Q2( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV31DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV31DynamicFiltersRemoving", AV31DynamicFiltersRemoving);
         AV26DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV26DynamicFiltersEnabled3", AV26DynamicFiltersEnabled3);
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
         AV31DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV31DynamicFiltersRemoving", AV31DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19ContratoNome1, AV20ContratoClienteDocumento1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24ContratoNome2, AV25ContratoClienteDocumento2, AV27DynamicFiltersSelector3, AV28DynamicFiltersOperator3, AV29ContratoNome3, AV30ContratoClienteDocumento3, AV7ClienteId, AV38ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV26DynamicFiltersEnabled3, AV64Pgmname, AV16FilterFullText, AV39TFContratoNome, AV40TFContratoNome_Sel, AV60TFContratoSituacao_Sels, AV62TFContratoCountAssinantes_F, AV63TFContratoCountAssinantes_F_To, AV11GridState, AV32DynamicFiltersIgnoreFirst, AV31DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV27DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV17DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV36ManageFiltersData", AV36ManageFiltersData);
      }

      protected void E249Q2( )
      {
         /* Dynamicfiltersselector3_Click Routine */
         returnInSub = false;
         AV28DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV28DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E119Q2( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("WpContratosTFilters")) + "," + UrlEncode(StringUtil.RTrim(AV64Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV38ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV38ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV38ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("WpContratosTFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV38ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV38ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV38ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV37ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "WpContratosTFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV37ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV37ManageFiltersXml)) )
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV64Pgmname+"GridState",  AV37ManageFiltersXml) ;
               AV11GridState.FromXml(AV37ManageFiltersXml, null, "", "");
               AV14OrderedBy = AV11GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
               AV15OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV15OrderedDsc", AV15OrderedDsc);
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV60TFContratoSituacao_Sels", AV60TFContratoSituacao_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV17DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV27DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV36ManageFiltersData", AV36ManageFiltersData);
      }

      protected void E189Q2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "assinarcontrato"+UrlEncode(StringUtil.LTrimStr(AV7ClienteId,9,0));
         CallWebObject(formatLink("assinarcontrato") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E199Q2( )
      {
         /* 'DoExport' Routine */
         returnInSub = false;
         new wpcontratostexport(context ).execute( out  AV33ExcelFilename, out  AV34ErrorMessage) ;
         if ( StringUtil.StrCmp(AV33ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV33ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV34ErrorMessage);
         }
      }

      protected void S172( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV14OrderedBy), 4, 0))+":"+(AV15OrderedDsc ? "DSC" : "ASC");
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
         if ( StringUtil.StrCmp(AV17DynamicFiltersSelector1, "CONTRATONOME") == 0 )
         {
            edtavContratonome1_Visible = 1;
            AssignProp("", false, edtavContratonome1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContratonome1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV17DynamicFiltersSelector1, "CONTRATOCLIENTEDOCUMENTO") == 0 )
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
         if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CONTRATONOME") == 0 )
         {
            edtavContratonome2_Visible = 1;
            AssignProp("", false, edtavContratonome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContratonome2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CONTRATOCLIENTEDOCUMENTO") == 0 )
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
         if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "CONTRATONOME") == 0 )
         {
            edtavContratonome3_Visible = 1;
            AssignProp("", false, edtavContratonome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContratonome3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "CONTRATOCLIENTEDOCUMENTO") == 0 )
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
         AV21DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV21DynamicFiltersEnabled2", AV21DynamicFiltersEnabled2);
         AV22DynamicFiltersSelector2 = "CONTRATONOME";
         AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
         AV23DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AV24ContratoNome2 = "";
         AssignAttri("", false, "AV24ContratoNome2", AV24ContratoNome2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV26DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV26DynamicFiltersEnabled3", AV26DynamicFiltersEnabled3);
         AV27DynamicFiltersSelector3 = "CONTRATONOME";
         AssignAttri("", false, "AV27DynamicFiltersSelector3", AV27DynamicFiltersSelector3);
         AV28DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV28DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
         AV29ContratoNome3 = "";
         AssignAttri("", false, "AV29ContratoNome3", AV29ContratoNome3);
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
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV36ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "WpContratosTFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV36ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S222( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV16FilterFullText = "";
         AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
         AV39TFContratoNome = "";
         AssignAttri("", false, "AV39TFContratoNome", AV39TFContratoNome);
         AV40TFContratoNome_Sel = "";
         AssignAttri("", false, "AV40TFContratoNome_Sel", AV40TFContratoNome_Sel);
         AV60TFContratoSituacao_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV62TFContratoCountAssinantes_F = 0;
         AssignAttri("", false, "AV62TFContratoCountAssinantes_F", StringUtil.LTrimStr( (decimal)(AV62TFContratoCountAssinantes_F), 4, 0));
         AV63TFContratoCountAssinantes_F_To = 0;
         AssignAttri("", false, "AV63TFContratoCountAssinantes_F_To", StringUtil.LTrimStr( (decimal)(AV63TFContratoCountAssinantes_F_To), 4, 0));
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV17DynamicFiltersSelector1 = "CONTRATONOME";
         AssignAttri("", false, "AV17DynamicFiltersSelector1", AV17DynamicFiltersSelector1);
         AV18DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV18DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
         AV19ContratoNome1 = "";
         AssignAttri("", false, "AV19ContratoNome1", AV19ContratoNome1);
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
         AV11GridState.gxTpr_Dynamicfilters.Clear();
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
         if ( StringUtil.StrCmp(AV35Session.Get(AV64Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV64Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV35Session.Get(AV64Pgmname+"GridState"), null, "", "");
         }
         AV14OrderedBy = AV11GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
         AV15OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV15OrderedDsc", AV15OrderedDsc);
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV11GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV11GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV11GridState.gxTpr_Currentpage) ;
      }

      protected void S232( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV85GXV1 = 1;
         while ( AV85GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV85GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV16FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCONTRATONOME") == 0 )
            {
               AV39TFContratoNome = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV39TFContratoNome", AV39TFContratoNome);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCONTRATONOME_SEL") == 0 )
            {
               AV40TFContratoNome_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV40TFContratoNome_Sel", AV40TFContratoNome_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCONTRATOSITUACAO_SEL") == 0 )
            {
               AV59TFContratoSituacao_SelsJson = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV59TFContratoSituacao_SelsJson", AV59TFContratoSituacao_SelsJson);
               AV60TFContratoSituacao_Sels.FromJSonString(AV59TFContratoSituacao_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCONTRATOCOUNTASSINANTES_F") == 0 )
            {
               AV62TFContratoCountAssinantes_F = (short)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV62TFContratoCountAssinantes_F", StringUtil.LTrimStr( (decimal)(AV62TFContratoCountAssinantes_F), 4, 0));
               AV63TFContratoCountAssinantes_F_To = (short)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV63TFContratoCountAssinantes_F_To", StringUtil.LTrimStr( (decimal)(AV63TFContratoCountAssinantes_F_To), 4, 0));
            }
            AV85GXV1 = (int)(AV85GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV40TFContratoNome_Sel)),  AV40TFContratoNome_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV60TFContratoSituacao_Sels.Count==0),  AV59TFContratoSituacao_SelsJson, out  GXt_char4) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char4+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV39TFContratoNome)),  AV39TFContratoNome, out  GXt_char4) ;
         Ddo_grid_Filteredtext_set = GXt_char4+"||"+((0==AV62TFContratoCountAssinantes_F) ? "" : StringUtil.Str( (decimal)(AV62TFContratoCountAssinantes_F), 4, 0));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "||"+((0==AV63TFContratoCountAssinantes_F_To) ? "" : StringUtil.Str( (decimal)(AV63TFContratoCountAssinantes_F_To), 4, 0));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
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
         if ( AV11GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(1));
            AV17DynamicFiltersSelector1 = AV13GridStateDynamicFilter.gxTpr_Selected;
            AssignAttri("", false, "AV17DynamicFiltersSelector1", AV17DynamicFiltersSelector1);
            if ( StringUtil.StrCmp(AV17DynamicFiltersSelector1, "CONTRATONOME") == 0 )
            {
               AV18DynamicFiltersOperator1 = AV13GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV18DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
               AV19ContratoNome1 = AV13GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV19ContratoNome1", AV19ContratoNome1);
            }
            else if ( StringUtil.StrCmp(AV17DynamicFiltersSelector1, "CONTRATOCLIENTEDOCUMENTO") == 0 )
            {
               AV18DynamicFiltersOperator1 = AV13GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV18DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
               AV20ContratoClienteDocumento1 = AV13GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV20ContratoClienteDocumento1", AV20ContratoClienteDocumento1);
            }
            /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
            S122 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            if ( AV11GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               lblJsdynamicfilters_Caption = "<script type=\"text/javascript\">$(document).ready(function() {";
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
               lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+StringUtil.Format( "WWPDynFilterShow_AL('%1', 2, 0);", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
               imgAdddynamicfilters1_Visible = 0;
               AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
               imgRemovedynamicfilters1_Visible = 1;
               AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
               AV21DynamicFiltersEnabled2 = true;
               AssignAttri("", false, "AV21DynamicFiltersEnabled2", AV21DynamicFiltersEnabled2);
               AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV13GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CONTRATONOME") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV13GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
                  AV24ContratoNome2 = AV13GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV24ContratoNome2", AV24ContratoNome2);
               }
               else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CONTRATOCLIENTEDOCUMENTO") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV13GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
                  AV25ContratoClienteDocumento2 = AV13GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV25ContratoClienteDocumento2", AV25ContratoClienteDocumento2);
               }
               /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
               S132 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               if ( AV11GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+StringUtil.Format( "WWPDynFilterShow_AL('%1', 3, 0);", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
                  AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
                  imgAdddynamicfilters2_Visible = 0;
                  AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
                  imgRemovedynamicfilters2_Visible = 1;
                  AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
                  AV26DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV26DynamicFiltersEnabled3", AV26DynamicFiltersEnabled3);
                  AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(3));
                  AV27DynamicFiltersSelector3 = AV13GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV27DynamicFiltersSelector3", AV27DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "CONTRATONOME") == 0 )
                  {
                     AV28DynamicFiltersOperator3 = AV13GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV28DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
                     AV29ContratoNome3 = AV13GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV29ContratoNome3", AV29ContratoNome3);
                  }
                  else if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "CONTRATOCLIENTEDOCUMENTO") == 0 )
                  {
                     AV28DynamicFiltersOperator3 = AV13GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV28DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
                     AV30ContratoClienteDocumento3 = AV13GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV30ContratoClienteDocumento3", AV30ContratoClienteDocumento3);
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
         if ( AV31DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S182( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV35Session.Get(AV64Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)),  0,  AV16FilterFullText,  AV16FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFCONTRATONOME",  "Nome",  !String.IsNullOrEmpty(StringUtil.RTrim( AV39TFContratoNome)),  0,  AV39TFContratoNome,  AV39TFContratoNome,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV40TFContratoNome_Sel)),  AV40TFContratoNome_Sel,  AV40TFContratoNome_Sel) ;
         AV61AuxText = ((AV60TFContratoSituacao_Sels.Count==1) ? "["+((string)AV60TFContratoSituacao_Sels.Item(1))+"]" : "Vários valores");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFCONTRATOSITUACAO_SEL",  "Situação",  !(AV60TFContratoSituacao_Sels.Count==0),  0,  AV60TFContratoSituacao_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV61AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( AV61AuxText, "[EmElaboracao]", "Em elaboração"), "[ColetandoAssinatura]", "Coletando assinaturas"), "[Assinado]", "Assinado")),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFCONTRATOCOUNTASSINANTES_F",  "Participantes",  !((0==AV62TFContratoCountAssinantes_F)&&(0==AV63TFContratoCountAssinantes_F_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV62TFContratoCountAssinantes_F), 4, 0)),  ((0==AV62TFContratoCountAssinantes_F) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV62TFContratoCountAssinantes_F), "ZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV63TFContratoCountAssinantes_F_To), 4, 0)),  ((0==AV63TFContratoCountAssinantes_F_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV63TFContratoCountAssinantes_F_To), "ZZZ9")))) ;
         if ( ! (0==AV7ClienteId) )
         {
            AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV12GridStateFilterValue.gxTpr_Name = "PARM_&CLIENTEID";
            AV12GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV7ClienteId), 9, 0);
            AV11GridState.gxTpr_Filtervalues.Add(AV12GridStateFilterValue, 0);
         }
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV64Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S192( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV11GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV32DynamicFiltersIgnoreFirst )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV17DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV17DynamicFiltersSelector1, "CONTRATONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV19ContratoNome1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV13GridStateDynamicFilter,  "Nome",  AV18DynamicFiltersOperator1,  AV19ContratoNome1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV19ContratoNome1, "Contém"+" "+AV19ContratoNome1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV17DynamicFiltersSelector1, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV20ContratoClienteDocumento1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV13GridStateDynamicFilter,  "Cliente Documento",  AV18DynamicFiltersOperator1,  AV20ContratoClienteDocumento1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV20ContratoClienteDocumento1, "Contém"+" "+AV20ContratoClienteDocumento1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV31DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
         if ( AV21DynamicFiltersEnabled2 )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV22DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CONTRATONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV24ContratoNome2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV13GridStateDynamicFilter,  "Nome",  AV23DynamicFiltersOperator2,  AV24ContratoNome2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV24ContratoNome2, "Contém"+" "+AV24ContratoNome2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV25ContratoClienteDocumento2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV13GridStateDynamicFilter,  "Cliente Documento",  AV23DynamicFiltersOperator2,  AV25ContratoClienteDocumento2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV25ContratoClienteDocumento2, "Contém"+" "+AV25ContratoClienteDocumento2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV31DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
         if ( AV26DynamicFiltersEnabled3 )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV27DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "CONTRATONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV29ContratoNome3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV13GridStateDynamicFilter,  "Nome",  AV28DynamicFiltersOperator3,  AV29ContratoNome3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV28DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV29ContratoNome3, "Contém"+" "+AV29ContratoNome3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV30ContratoClienteDocumento3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV13GridStateDynamicFilter,  "Cliente Documento",  AV28DynamicFiltersOperator3,  AV30ContratoClienteDocumento3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV28DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV30ContratoClienteDocumento3, "Contém"+" "+AV30ContratoClienteDocumento3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV31DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
      }

      protected void S152( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV64Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "Contrato";
         AV35Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table3_95_9Q2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'" + sGXsfl_116_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV28DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "", true, 0, "HLP_WpContratosT.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_contratonome3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContratonome3_Internalname, "Contrato Nome3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'" + sGXsfl_116_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContratonome3_Internalname, AV29ContratoNome3, StringUtil.RTrim( context.localUtil.Format( AV29ContratoNome3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,102);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContratonome3_Jsonclick, 0, "Attribute", "", "", "", "", edtavContratonome3_Visible, edtavContratonome3_Enabled, 0, "text", "", 80, "chr", 1, "row", 125, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpContratosT.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_contratoclientedocumento3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContratoclientedocumento3_Internalname, "Contrato Cliente Documento3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'" + sGXsfl_116_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContratoclientedocumento3_Internalname, AV30ContratoClienteDocumento3, StringUtil.RTrim( context.localUtil.Format( AV30ContratoClienteDocumento3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,105);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContratoclientedocumento3_Jsonclick, 0, "Attribute", "", "", "", "", edtavContratoclientedocumento3_Visible, edtavContratoclientedocumento3_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpContratosT.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WpContratosT.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_95_9Q2e( true) ;
         }
         else
         {
            wb_table3_95_9Q2e( false) ;
         }
      }

      protected void wb_table2_70_9Q2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'" + sGXsfl_116_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "", true, 0, "HLP_WpContratosT.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_contratonome2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContratonome2_Internalname, "Contrato Nome2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'" + sGXsfl_116_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContratonome2_Internalname, AV24ContratoNome2, StringUtil.RTrim( context.localUtil.Format( AV24ContratoNome2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContratonome2_Jsonclick, 0, "Attribute", "", "", "", "", edtavContratonome2_Visible, edtavContratonome2_Enabled, 0, "text", "", 80, "chr", 1, "row", 125, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpContratosT.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_contratoclientedocumento2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContratoclientedocumento2_Internalname, "Contrato Cliente Documento2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'" + sGXsfl_116_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContratoclientedocumento2_Internalname, AV25ContratoClienteDocumento2, StringUtil.RTrim( context.localUtil.Format( AV25ContratoClienteDocumento2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,80);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContratoclientedocumento2_Jsonclick, 0, "Attribute", "", "", "", "", edtavContratoclientedocumento2_Visible, edtavContratoclientedocumento2_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpContratosT.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WpContratosT.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WpContratosT.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_70_9Q2e( true) ;
         }
         else
         {
            wb_table2_70_9Q2e( false) ;
         }
      }

      protected void wb_table1_45_9Q2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_116_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 0, "HLP_WpContratosT.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_contratonome1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContratonome1_Internalname, "Contrato Nome1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'" + sGXsfl_116_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContratonome1_Internalname, AV19ContratoNome1, StringUtil.RTrim( context.localUtil.Format( AV19ContratoNome1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContratonome1_Jsonclick, 0, "Attribute", "", "", "", "", edtavContratonome1_Visible, edtavContratonome1_Enabled, 0, "text", "", 80, "chr", 1, "row", 125, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpContratosT.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_contratoclientedocumento1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContratoclientedocumento1_Internalname, "Contrato Cliente Documento1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'" + sGXsfl_116_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContratoclientedocumento1_Internalname, AV20ContratoClienteDocumento1, StringUtil.RTrim( context.localUtil.Format( AV20ContratoClienteDocumento1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContratoclientedocumento1_Jsonclick, 0, "Attribute", "", "", "", "", edtavContratoclientedocumento1_Visible, edtavContratoclientedocumento1_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpContratosT.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WpContratosT.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WpContratosT.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_45_9Q2e( true) ;
         }
         else
         {
            wb_table1_45_9Q2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV7ClienteId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV7ClienteId", StringUtil.LTrimStr( (decimal)(AV7ClienteId), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ClienteId), "ZZZZZZZZ9"), context));
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
         PA9Q2( ) ;
         WS9Q2( ) ;
         WE9Q2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019285435", true, true);
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
         context.AddJavascriptSource("wpcontratost.js", "?202561019285436", false, true);
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

      protected void SubsflControlProps_1162( )
      {
         edtContratoId_Internalname = "CONTRATOID_"+sGXsfl_116_idx;
         edtContratoNome_Internalname = "CONTRATONOME_"+sGXsfl_116_idx;
         cmbContratoSituacao_Internalname = "CONTRATOSITUACAO_"+sGXsfl_116_idx;
         edtContratoCountAssinantes_F_Internalname = "CONTRATOCOUNTASSINANTES_F_"+sGXsfl_116_idx;
      }

      protected void SubsflControlProps_fel_1162( )
      {
         edtContratoId_Internalname = "CONTRATOID_"+sGXsfl_116_fel_idx;
         edtContratoNome_Internalname = "CONTRATONOME_"+sGXsfl_116_fel_idx;
         cmbContratoSituacao_Internalname = "CONTRATOSITUACAO_"+sGXsfl_116_fel_idx;
         edtContratoCountAssinantes_F_Internalname = "CONTRATOCOUNTASSINANTES_F_"+sGXsfl_116_fel_idx;
      }

      protected void sendrow_1162( )
      {
         sGXsfl_116_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_116_idx), 4, 0), 4, "0");
         SubsflControlProps_1162( ) ;
         WB9Q0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_116_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_116_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_116_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtContratoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A227ContratoId), "ZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtContratoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)116,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtContratoNome_Internalname,(string)A228ContratoNome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtContratoNome_Link,(string)"",(string)"",(string)"",(string)edtContratoNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)125,(short)0,(short)0,(short)116,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbContratoSituacao.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "CONTRATOSITUACAO_" + sGXsfl_116_idx;
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
            AssignProp("", false, cmbContratoSituacao_Internalname, "Values", (string)(cmbContratoSituacao.ToJavascriptSource()), !bGXsfl_116_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtContratoCountAssinantes_F_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A1007ContratoCountAssinantes_F), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A1007ContratoCountAssinantes_F), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtContratoCountAssinantes_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)116,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes9Q2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_116_idx = ((subGrid_Islastpage==1)&&(nGXsfl_116_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_116_idx+1);
            sGXsfl_116_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_116_idx), 4, 0), 4, "0");
            SubsflControlProps_1162( ) ;
         }
         /* End function sendrow_1162 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("CONTRATONOME", "Nome", 0);
         cmbavDynamicfiltersselector1.addItem("CONTRATOCLIENTEDOCUMENTO", "Cliente Documento", 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV17DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV17DynamicFiltersSelector1);
            AssignAttri("", false, "AV17DynamicFiltersSelector1", AV17DynamicFiltersSelector1);
         }
         cmbavDynamicfiltersoperator1.Name = "vDYNAMICFILTERSOPERATOR1";
         cmbavDynamicfiltersoperator1.WebTags = "";
         cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV18DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV18DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("CONTRATONOME", "Nome", 0);
         cmbavDynamicfiltersselector2.addItem("CONTRATOCLIENTEDOCUMENTO", "Cliente Documento", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV22DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV22DynamicFiltersSelector2);
            AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV23DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("CONTRATONOME", "Nome", 0);
         cmbavDynamicfiltersselector3.addItem("CONTRATOCLIENTEDOCUMENTO", "Cliente Documento", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV27DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV27DynamicFiltersSelector3);
            AssignAttri("", false, "AV27DynamicFiltersSelector3", AV27DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV28DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV28DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV28DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
         }
         GXCCtl = "CONTRATOSITUACAO_" + sGXsfl_116_idx;
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

      protected void StartGridControl116( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"116\">") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Nome") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Situação") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Participantes") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A228ContratoNome));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtContratoNome_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A471ContratoSituacao));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbContratoSituacao_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbContratoSituacao_Columnheaderclass));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1007ContratoCountAssinantes_F), 4, 0, ".", ""))));
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
         edtContratoId_Internalname = "CONTRATOID";
         edtContratoNome_Internalname = "CONTRATONOME";
         cmbContratoSituacao_Internalname = "CONTRATOSITUACAO";
         edtContratoCountAssinantes_F_Internalname = "CONTRATOCOUNTASSINANTES_F";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         lblJsdynamicfilters_Internalname = "JSDYNAMICFILTERS";
         Ddo_grid_Internalname = "DDO_GRID";
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
         edtContratoCountAssinantes_F_Jsonclick = "";
         cmbContratoSituacao_Jsonclick = "";
         cmbContratoSituacao_Columnclass = "WWColumn";
         edtContratoNome_Jsonclick = "";
         edtContratoNome_Link = "";
         edtContratoId_Jsonclick = "";
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
         edtContratoCountAssinantes_F_Enabled = 0;
         cmbContratoSituacao.Enabled = 0;
         edtContratoNome_Enabled = 0;
         edtContratoId_Enabled = 0;
         subGrid_Sortable = 0;
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
         Ddo_grid_Format = "||4.0";
         Ddo_grid_Datalistproc = "WpContratosTGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|EmElaboracao:Em elaboração,ColetandoAssinatura:Coletando assinaturas,Assinado:Assinado|";
         Ddo_grid_Allowmultipleselection = "|T|";
         Ddo_grid_Datalisttype = "Dynamic|FixedValues|";
         Ddo_grid_Includedatalist = "T|T|";
         Ddo_grid_Filterisrange = "||T";
         Ddo_grid_Filtertype = "Character||Numeric";
         Ddo_grid_Includefilter = "T||T";
         Ddo_grid_Includesortasc = "T|T|";
         Ddo_grid_Columnssortvalues = "1|2|";
         Ddo_grid_Columnids = "1:ContratoNome|2:ContratoSituacao|3:ContratoCountAssinantes_F";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV38ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"AV26DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV27DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV20ContratoClienteDocumento1","fld":"vCONTRATOCLIENTEDOCUMENTO1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV25ContratoClienteDocumento2","fld":"vCONTRATOCLIENTEDOCUMENTO2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV28DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV30ContratoClienteDocumento3","fld":"vCONTRATOCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV7ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV64Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV39TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV40TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV60TFContratoSituacao_Sels","fld":"vTFCONTRATOSITUACAO_SELS","type":""},{"av":"AV62TFContratoCountAssinantes_F","fld":"vTFCONTRATOCOUNTASSINANTES_F","pic":"ZZZ9","type":"int"},{"av":"AV63TFContratoCountAssinantes_F_To","fld":"vTFCONTRATOCOUNTASSINANTES_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV32DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV31DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV38ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV28DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV54GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV55GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV56GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbContratoSituacao"},{"av":"AV36ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E129Q2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV20ContratoClienteDocumento1","fld":"vCONTRATOCLIENTEDOCUMENTO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV25ContratoClienteDocumento2","fld":"vCONTRATOCLIENTEDOCUMENTO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV27DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV28DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV30ContratoClienteDocumento3","fld":"vCONTRATOCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV7ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV38ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV26DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV64Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV39TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV40TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV60TFContratoSituacao_Sels","fld":"vTFCONTRATOSITUACAO_SELS","type":""},{"av":"AV62TFContratoCountAssinantes_F","fld":"vTFCONTRATOCOUNTASSINANTES_F","pic":"ZZZ9","type":"int"},{"av":"AV63TFContratoCountAssinantes_F_To","fld":"vTFCONTRATOCOUNTASSINANTES_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV32DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV31DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E139Q2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV20ContratoClienteDocumento1","fld":"vCONTRATOCLIENTEDOCUMENTO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV25ContratoClienteDocumento2","fld":"vCONTRATOCLIENTEDOCUMENTO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV27DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV28DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV30ContratoClienteDocumento3","fld":"vCONTRATOCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV7ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV38ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV26DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV64Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV39TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV40TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV60TFContratoSituacao_Sels","fld":"vTFCONTRATOSITUACAO_SELS","type":""},{"av":"AV62TFContratoCountAssinantes_F","fld":"vTFCONTRATOCOUNTASSINANTES_F","pic":"ZZZ9","type":"int"},{"av":"AV63TFContratoCountAssinantes_F_To","fld":"vTFCONTRATOCOUNTASSINANTES_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV32DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV31DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E149Q2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV20ContratoClienteDocumento1","fld":"vCONTRATOCLIENTEDOCUMENTO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV25ContratoClienteDocumento2","fld":"vCONTRATOCLIENTEDOCUMENTO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV27DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV28DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV30ContratoClienteDocumento3","fld":"vCONTRATOCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV7ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV38ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV26DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV64Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV39TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV40TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV60TFContratoSituacao_Sels","fld":"vTFCONTRATOSITUACAO_SELS","type":""},{"av":"AV62TFContratoCountAssinantes_F","fld":"vTFCONTRATOCOUNTASSINANTES_F","pic":"ZZZ9","type":"int"},{"av":"AV63TFContratoCountAssinantes_F_To","fld":"vTFCONTRATOCOUNTASSINANTES_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV32DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV31DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV39TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV40TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV59TFContratoSituacao_SelsJson","fld":"vTFCONTRATOSITUACAO_SELSJSON","type":"vchar"},{"av":"AV60TFContratoSituacao_Sels","fld":"vTFCONTRATOSITUACAO_SELS","type":""},{"av":"AV62TFContratoCountAssinantes_F","fld":"vTFCONTRATOCOUNTASSINANTES_F","pic":"ZZZ9","type":"int"},{"av":"AV63TFContratoCountAssinantes_F_To","fld":"vTFCONTRATOCOUNTASSINANTES_F_TO","pic":"ZZZ9","type":"int"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E279Q2","iparms":[{"av":"A227ContratoId","fld":"CONTRATOID","pic":"ZZZZZ9","type":"int"},{"av":"cmbContratoSituacao"},{"av":"A471ContratoSituacao","fld":"CONTRATOSITUACAO","type":"svchar"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"edtContratoNome_Link","ctrl":"CONTRATONOME","prop":"Link"},{"av":"cmbContratoSituacao"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E209Q2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV20ContratoClienteDocumento1","fld":"vCONTRATOCLIENTEDOCUMENTO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV25ContratoClienteDocumento2","fld":"vCONTRATOCLIENTEDOCUMENTO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV27DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV28DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV30ContratoClienteDocumento3","fld":"vCONTRATOCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV7ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV38ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV26DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV64Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV39TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV40TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV60TFContratoSituacao_Sels","fld":"vTFCONTRATOSITUACAO_SELS","type":""},{"av":"AV62TFContratoCountAssinantes_F","fld":"vTFCONTRATOCOUNTASSINANTES_F","pic":"ZZZ9","type":"int"},{"av":"AV63TFContratoCountAssinantes_F_To","fld":"vTFCONTRATOCOUNTASSINANTES_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV32DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV31DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"AV38ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV28DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV54GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV55GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV56GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbContratoSituacao"},{"av":"AV36ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E159Q2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV20ContratoClienteDocumento1","fld":"vCONTRATOCLIENTEDOCUMENTO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV25ContratoClienteDocumento2","fld":"vCONTRATOCLIENTEDOCUMENTO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV27DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV28DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV30ContratoClienteDocumento3","fld":"vCONTRATOCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV7ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV38ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV26DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV64Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV39TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV40TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV60TFContratoSituacao_Sels","fld":"vTFCONTRATOSITUACAO_SELS","type":""},{"av":"AV62TFContratoCountAssinantes_F","fld":"vTFCONTRATOCOUNTASSINANTES_F","pic":"ZZZ9","type":"int"},{"av":"AV63TFContratoCountAssinantes_F_To","fld":"vTFCONTRATOCOUNTASSINANTES_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV32DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV31DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV31DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV32DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV26DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV27DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV28DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV20ContratoClienteDocumento1","fld":"vCONTRATOCLIENTEDOCUMENTO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV25ContratoClienteDocumento2","fld":"vCONTRATOCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV30ContratoClienteDocumento3","fld":"vCONTRATOCLIENTEDOCUMENTO3","type":"svchar"},{"av":"edtavContratonome2_Visible","ctrl":"vCONTRATONOME2","prop":"Visible"},{"av":"edtavContratoclientedocumento2_Visible","ctrl":"vCONTRATOCLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavContratonome3_Visible","ctrl":"vCONTRATONOME3","prop":"Visible"},{"av":"edtavContratoclientedocumento3_Visible","ctrl":"vCONTRATOCLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavContratonome1_Visible","ctrl":"vCONTRATONOME1","prop":"Visible"},{"av":"edtavContratoclientedocumento1_Visible","ctrl":"vCONTRATOCLIENTEDOCUMENTO1","prop":"Visible"},{"av":"AV38ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV54GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV55GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV56GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbContratoSituacao"},{"av":"AV36ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E219Q2","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"edtavContratonome1_Visible","ctrl":"vCONTRATONOME1","prop":"Visible"},{"av":"edtavContratoclientedocumento1_Visible","ctrl":"vCONTRATOCLIENTEDOCUMENTO1","prop":"Visible"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E229Q2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV20ContratoClienteDocumento1","fld":"vCONTRATOCLIENTEDOCUMENTO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV25ContratoClienteDocumento2","fld":"vCONTRATOCLIENTEDOCUMENTO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV27DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV28DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV30ContratoClienteDocumento3","fld":"vCONTRATOCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV7ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV38ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV26DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV64Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV39TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV40TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV60TFContratoSituacao_Sels","fld":"vTFCONTRATOSITUACAO_SELS","type":""},{"av":"AV62TFContratoCountAssinantes_F","fld":"vTFCONTRATOCOUNTASSINANTES_F","pic":"ZZZ9","type":"int"},{"av":"AV63TFContratoCountAssinantes_F_To","fld":"vTFCONTRATOCOUNTASSINANTES_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV32DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV31DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV26DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"AV38ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV28DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV54GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV55GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV56GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbContratoSituacao"},{"av":"AV36ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E169Q2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV20ContratoClienteDocumento1","fld":"vCONTRATOCLIENTEDOCUMENTO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV25ContratoClienteDocumento2","fld":"vCONTRATOCLIENTEDOCUMENTO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV27DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV28DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV30ContratoClienteDocumento3","fld":"vCONTRATOCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV7ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV38ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV26DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV64Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV39TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV40TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV60TFContratoSituacao_Sels","fld":"vTFCONTRATOSITUACAO_SELS","type":""},{"av":"AV62TFContratoCountAssinantes_F","fld":"vTFCONTRATOCOUNTASSINANTES_F","pic":"ZZZ9","type":"int"},{"av":"AV63TFContratoCountAssinantes_F_To","fld":"vTFCONTRATOCOUNTASSINANTES_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV32DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV31DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV31DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV26DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV27DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV28DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV20ContratoClienteDocumento1","fld":"vCONTRATOCLIENTEDOCUMENTO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV25ContratoClienteDocumento2","fld":"vCONTRATOCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV30ContratoClienteDocumento3","fld":"vCONTRATOCLIENTEDOCUMENTO3","type":"svchar"},{"av":"edtavContratonome2_Visible","ctrl":"vCONTRATONOME2","prop":"Visible"},{"av":"edtavContratoclientedocumento2_Visible","ctrl":"vCONTRATOCLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavContratonome3_Visible","ctrl":"vCONTRATONOME3","prop":"Visible"},{"av":"edtavContratoclientedocumento3_Visible","ctrl":"vCONTRATOCLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavContratonome1_Visible","ctrl":"vCONTRATONOME1","prop":"Visible"},{"av":"edtavContratoclientedocumento1_Visible","ctrl":"vCONTRATOCLIENTEDOCUMENTO1","prop":"Visible"},{"av":"AV38ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV54GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV55GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV56GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbContratoSituacao"},{"av":"AV36ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E239Q2","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"edtavContratonome2_Visible","ctrl":"vCONTRATONOME2","prop":"Visible"},{"av":"edtavContratoclientedocumento2_Visible","ctrl":"vCONTRATOCLIENTEDOCUMENTO2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E179Q2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV20ContratoClienteDocumento1","fld":"vCONTRATOCLIENTEDOCUMENTO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV25ContratoClienteDocumento2","fld":"vCONTRATOCLIENTEDOCUMENTO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV27DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV28DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV30ContratoClienteDocumento3","fld":"vCONTRATOCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV7ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV38ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV26DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV64Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV39TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV40TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV60TFContratoSituacao_Sels","fld":"vTFCONTRATOSITUACAO_SELS","type":""},{"av":"AV62TFContratoCountAssinantes_F","fld":"vTFCONTRATOCOUNTASSINANTES_F","pic":"ZZZ9","type":"int"},{"av":"AV63TFContratoCountAssinantes_F_To","fld":"vTFCONTRATOCOUNTASSINANTES_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV32DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV31DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV31DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV26DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV27DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV28DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV20ContratoClienteDocumento1","fld":"vCONTRATOCLIENTEDOCUMENTO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV25ContratoClienteDocumento2","fld":"vCONTRATOCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV30ContratoClienteDocumento3","fld":"vCONTRATOCLIENTEDOCUMENTO3","type":"svchar"},{"av":"edtavContratonome2_Visible","ctrl":"vCONTRATONOME2","prop":"Visible"},{"av":"edtavContratoclientedocumento2_Visible","ctrl":"vCONTRATOCLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavContratonome3_Visible","ctrl":"vCONTRATONOME3","prop":"Visible"},{"av":"edtavContratoclientedocumento3_Visible","ctrl":"vCONTRATOCLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavContratonome1_Visible","ctrl":"vCONTRATONOME1","prop":"Visible"},{"av":"edtavContratoclientedocumento1_Visible","ctrl":"vCONTRATOCLIENTEDOCUMENTO1","prop":"Visible"},{"av":"AV38ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV54GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV55GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV56GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbContratoSituacao"},{"av":"AV36ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E249Q2","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV27DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV28DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"edtavContratonome3_Visible","ctrl":"vCONTRATONOME3","prop":"Visible"},{"av":"edtavContratoclientedocumento3_Visible","ctrl":"vCONTRATOCLIENTEDOCUMENTO3","prop":"Visible"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E119Q2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"AV20ContratoClienteDocumento1","fld":"vCONTRATOCLIENTEDOCUMENTO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV25ContratoClienteDocumento2","fld":"vCONTRATOCLIENTEDOCUMENTO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV27DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV28DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV30ContratoClienteDocumento3","fld":"vCONTRATOCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV7ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV38ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV26DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV64Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV39TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV40TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV60TFContratoSituacao_Sels","fld":"vTFCONTRATOSITUACAO_SELS","type":""},{"av":"AV62TFContratoCountAssinantes_F","fld":"vTFCONTRATOCOUNTASSINANTES_F","pic":"ZZZ9","type":"int"},{"av":"AV63TFContratoCountAssinantes_F_To","fld":"vTFCONTRATOCOUNTASSINANTES_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV32DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV31DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV59TFContratoSituacao_SelsJson","fld":"vTFCONTRATOSITUACAO_SELSJSON","type":"vchar"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV38ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV39TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV40TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV60TFContratoSituacao_Sels","fld":"vTFCONTRATOSITUACAO_SELS","type":""},{"av":"AV62TFContratoCountAssinantes_F","fld":"vTFCONTRATOCOUNTASSINANTES_F","pic":"ZZZ9","type":"int"},{"av":"AV63TFContratoCountAssinantes_F_To","fld":"vTFCONTRATOCOUNTASSINANTES_F_TO","pic":"ZZZ9","type":"int"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV59TFContratoSituacao_SelsJson","fld":"vTFCONTRATOSITUACAO_SELSJSON","type":"vchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"AV20ContratoClienteDocumento1","fld":"vCONTRATOCLIENTEDOCUMENTO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV25ContratoClienteDocumento2","fld":"vCONTRATOCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV26DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV27DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV28DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV30ContratoClienteDocumento3","fld":"vCONTRATOCLIENTEDOCUMENTO3","type":"svchar"},{"av":"edtavContratonome1_Visible","ctrl":"vCONTRATONOME1","prop":"Visible"},{"av":"edtavContratoclientedocumento1_Visible","ctrl":"vCONTRATOCLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavContratonome2_Visible","ctrl":"vCONTRATONOME2","prop":"Visible"},{"av":"edtavContratoclientedocumento2_Visible","ctrl":"vCONTRATOCLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavContratonome3_Visible","ctrl":"vCONTRATONOME3","prop":"Visible"},{"av":"edtavContratoclientedocumento3_Visible","ctrl":"vCONTRATOCLIENTEDOCUMENTO3","prop":"Visible"},{"av":"AV54GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV55GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV56GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbContratoSituacao"},{"av":"AV36ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E189Q2","iparms":[{"av":"AV7ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("'DOEXPORT'","""{"handler":"E199Q2","iparms":[]}""");
         setEventMetadata("VALID_CONTRATOID","""{"handler":"Valid_Contratoid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Contratocountassinantes_f","iparms":[]}""");
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
         Ddo_grid_Filteredtextto_get = "";
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV17DynamicFiltersSelector1 = "";
         AV19ContratoNome1 = "";
         AV20ContratoClienteDocumento1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV24ContratoNome2 = "";
         AV25ContratoClienteDocumento2 = "";
         AV27DynamicFiltersSelector3 = "";
         AV29ContratoNome3 = "";
         AV30ContratoClienteDocumento3 = "";
         AV64Pgmname = "";
         AV16FilterFullText = "";
         AV39TFContratoNome = "";
         AV40TFContratoNome_Sel = "";
         AV60TFContratoSituacao_Sels = new GxSimpleCollection<string>();
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV36ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV56GridAppliedFilters = "";
         AV52DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV59TFContratoSituacao_SelsJson = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
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
         ucGridpaginationbar = new GXUserControl();
         lblJsdynamicfilters_Jsonclick = "";
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A228ContratoNome = "";
         A471ContratoSituacao = "";
         GXDecQS = "";
         AV82Wpcontratostds_18_tfcontratosituacao_sels = new GxSimpleCollection<string>();
         lV65Wpcontratostds_1_filterfulltext = "";
         lV68Wpcontratostds_4_contratonome1 = "";
         lV69Wpcontratostds_5_contratoclientedocumento1 = "";
         lV73Wpcontratostds_9_contratonome2 = "";
         lV74Wpcontratostds_10_contratoclientedocumento2 = "";
         lV78Wpcontratostds_14_contratonome3 = "";
         lV79Wpcontratostds_15_contratoclientedocumento3 = "";
         lV80Wpcontratostds_16_tfcontratonome = "";
         AV66Wpcontratostds_2_dynamicfiltersselector1 = "";
         AV68Wpcontratostds_4_contratonome1 = "";
         AV69Wpcontratostds_5_contratoclientedocumento1 = "";
         AV71Wpcontratostds_7_dynamicfiltersselector2 = "";
         AV73Wpcontratostds_9_contratonome2 = "";
         AV74Wpcontratostds_10_contratoclientedocumento2 = "";
         AV76Wpcontratostds_12_dynamicfiltersselector3 = "";
         AV78Wpcontratostds_14_contratonome3 = "";
         AV79Wpcontratostds_15_contratoclientedocumento3 = "";
         AV81Wpcontratostds_17_tfcontratonome_sel = "";
         AV80Wpcontratostds_16_tfcontratonome = "";
         A475ContratoClienteDocumento = "";
         AV65Wpcontratostds_1_filterfulltext = "";
         H009Q3_A473ContratoClienteId = new int[1] ;
         H009Q3_n473ContratoClienteId = new bool[] {false} ;
         H009Q3_A475ContratoClienteDocumento = new string[] {""} ;
         H009Q3_n475ContratoClienteDocumento = new bool[] {false} ;
         H009Q3_A471ContratoSituacao = new string[] {""} ;
         H009Q3_n471ContratoSituacao = new bool[] {false} ;
         H009Q3_A228ContratoNome = new string[] {""} ;
         H009Q3_n228ContratoNome = new bool[] {false} ;
         H009Q3_A227ContratoId = new int[1] ;
         H009Q3_n227ContratoId = new bool[] {false} ;
         H009Q3_A1007ContratoCountAssinantes_F = new short[1] ;
         H009Q3_n1007ContratoCountAssinantes_F = new bool[] {false} ;
         H009Q5_AGRID_nRecordCount = new long[1] ;
         AV8HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV37ManageFiltersXml = "";
         AV33ExcelFilename = "";
         AV34ErrorMessage = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV35Session = context.GetSession();
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         GXt_char4 = "";
         AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV61AuxText = "";
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpcontratost__default(),
            new Object[][] {
                new Object[] {
               H009Q3_A473ContratoClienteId, H009Q3_n473ContratoClienteId, H009Q3_A475ContratoClienteDocumento, H009Q3_n475ContratoClienteDocumento, H009Q3_A471ContratoSituacao, H009Q3_n471ContratoSituacao, H009Q3_A228ContratoNome, H009Q3_n228ContratoNome, H009Q3_A227ContratoId, H009Q3_A1007ContratoCountAssinantes_F,
               H009Q3_n1007ContratoCountAssinantes_F
               }
               , new Object[] {
               H009Q5_AGRID_nRecordCount
               }
            }
         );
         AV64Pgmname = "WpContratosT";
         /* GeneXus formulas. */
         AV64Pgmname = "WpContratosT";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV14OrderedBy ;
      private short AV18DynamicFiltersOperator1 ;
      private short AV23DynamicFiltersOperator2 ;
      private short AV28DynamicFiltersOperator3 ;
      private short AV38ManageFiltersExecutionStep ;
      private short AV62TFContratoCountAssinantes_F ;
      private short AV63TFContratoCountAssinantes_F_To ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A1007ContratoCountAssinantes_F ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV67Wpcontratostds_3_dynamicfiltersoperator1 ;
      private short AV72Wpcontratostds_8_dynamicfiltersoperator2 ;
      private short AV77Wpcontratostds_13_dynamicfiltersoperator3 ;
      private short AV83Wpcontratostds_19_tfcontratocountassinantes_f ;
      private short AV84Wpcontratostds_20_tfcontratocountassinantes_f_to ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int AV7ClienteId ;
      private int wcpOAV7ClienteId ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_116 ;
      private int nGXsfl_116_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int A227ContratoId ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV82Wpcontratostds_18_tfcontratosituacao_sels_Count ;
      private int A473ContratoClienteId ;
      private int edtContratoId_Enabled ;
      private int edtContratoNome_Enabled ;
      private int edtContratoCountAssinantes_F_Enabled ;
      private int AV53PageToGo ;
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
      private int AV85GXV1 ;
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
      private long AV54GridCurrentPage ;
      private long AV55GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_116_idx="0001" ;
      private string AV64Pgmname ;
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
      private string Ddo_grid_Allowmultipleselection ;
      private string Ddo_grid_Datalistfixedvalues ;
      private string Ddo_grid_Datalistproc ;
      private string Ddo_grid_Format ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
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
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtContratoId_Internalname ;
      private string edtContratoNome_Internalname ;
      private string cmbContratoSituacao_Internalname ;
      private string edtContratoCountAssinantes_F_Internalname ;
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
      private string edtContratoNome_Link ;
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
      private string sGXsfl_116_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtContratoId_Jsonclick ;
      private string edtContratoNome_Jsonclick ;
      private string GXCCtl ;
      private string cmbContratoSituacao_Jsonclick ;
      private string edtContratoCountAssinantes_F_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15OrderedDsc ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV26DynamicFiltersEnabled3 ;
      private bool AV32DynamicFiltersIgnoreFirst ;
      private bool AV31DynamicFiltersRemoving ;
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
      private bool n471ContratoSituacao ;
      private bool n1007ContratoCountAssinantes_F ;
      private bool bGXsfl_116_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV70Wpcontratostds_6_dynamicfiltersenabled2 ;
      private bool AV75Wpcontratostds_11_dynamicfiltersenabled3 ;
      private bool n473ContratoClienteId ;
      private bool n475ContratoClienteDocumento ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV59TFContratoSituacao_SelsJson ;
      private string AV37ManageFiltersXml ;
      private string AV17DynamicFiltersSelector1 ;
      private string AV19ContratoNome1 ;
      private string AV20ContratoClienteDocumento1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV24ContratoNome2 ;
      private string AV25ContratoClienteDocumento2 ;
      private string AV27DynamicFiltersSelector3 ;
      private string AV29ContratoNome3 ;
      private string AV30ContratoClienteDocumento3 ;
      private string AV16FilterFullText ;
      private string AV39TFContratoNome ;
      private string AV40TFContratoNome_Sel ;
      private string AV56GridAppliedFilters ;
      private string A228ContratoNome ;
      private string A471ContratoSituacao ;
      private string lV65Wpcontratostds_1_filterfulltext ;
      private string lV68Wpcontratostds_4_contratonome1 ;
      private string lV69Wpcontratostds_5_contratoclientedocumento1 ;
      private string lV73Wpcontratostds_9_contratonome2 ;
      private string lV74Wpcontratostds_10_contratoclientedocumento2 ;
      private string lV78Wpcontratostds_14_contratonome3 ;
      private string lV79Wpcontratostds_15_contratoclientedocumento3 ;
      private string lV80Wpcontratostds_16_tfcontratonome ;
      private string AV66Wpcontratostds_2_dynamicfiltersselector1 ;
      private string AV68Wpcontratostds_4_contratonome1 ;
      private string AV69Wpcontratostds_5_contratoclientedocumento1 ;
      private string AV71Wpcontratostds_7_dynamicfiltersselector2 ;
      private string AV73Wpcontratostds_9_contratonome2 ;
      private string AV74Wpcontratostds_10_contratoclientedocumento2 ;
      private string AV76Wpcontratostds_12_dynamicfiltersselector3 ;
      private string AV78Wpcontratostds_14_contratonome3 ;
      private string AV79Wpcontratostds_15_contratoclientedocumento3 ;
      private string AV81Wpcontratostds_17_tfcontratonome_sel ;
      private string AV80Wpcontratostds_16_tfcontratonome ;
      private string A475ContratoClienteDocumento ;
      private string AV65Wpcontratostds_1_filterfulltext ;
      private string AV33ExcelFilename ;
      private string AV34ErrorMessage ;
      private string AV61AuxText ;
      private IGxSession AV35Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCombobox cmbContratoSituacao ;
      private GxSimpleCollection<string> AV60TFContratoSituacao_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV36ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV52DDO_TitleSettingsIcons ;
      private GxSimpleCollection<string> AV82Wpcontratostds_18_tfcontratosituacao_sels ;
      private IDataStoreProvider pr_default ;
      private int[] H009Q3_A473ContratoClienteId ;
      private bool[] H009Q3_n473ContratoClienteId ;
      private string[] H009Q3_A475ContratoClienteDocumento ;
      private bool[] H009Q3_n475ContratoClienteDocumento ;
      private string[] H009Q3_A471ContratoSituacao ;
      private bool[] H009Q3_n471ContratoSituacao ;
      private string[] H009Q3_A228ContratoNome ;
      private bool[] H009Q3_n228ContratoNome ;
      private int[] H009Q3_A227ContratoId ;
      private bool[] H009Q3_n227ContratoId ;
      private short[] H009Q3_A1007ContratoCountAssinantes_F ;
      private bool[] H009Q3_n1007ContratoCountAssinantes_F ;
      private long[] H009Q5_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV13GridStateDynamicFilter ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpcontratost__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H009Q3( IGxContext context ,
                                             string A471ContratoSituacao ,
                                             GxSimpleCollection<string> AV82Wpcontratostds_18_tfcontratosituacao_sels ,
                                             string AV66Wpcontratostds_2_dynamicfiltersselector1 ,
                                             short AV67Wpcontratostds_3_dynamicfiltersoperator1 ,
                                             string AV68Wpcontratostds_4_contratonome1 ,
                                             string AV69Wpcontratostds_5_contratoclientedocumento1 ,
                                             bool AV70Wpcontratostds_6_dynamicfiltersenabled2 ,
                                             string AV71Wpcontratostds_7_dynamicfiltersselector2 ,
                                             short AV72Wpcontratostds_8_dynamicfiltersoperator2 ,
                                             string AV73Wpcontratostds_9_contratonome2 ,
                                             string AV74Wpcontratostds_10_contratoclientedocumento2 ,
                                             bool AV75Wpcontratostds_11_dynamicfiltersenabled3 ,
                                             string AV76Wpcontratostds_12_dynamicfiltersselector3 ,
                                             short AV77Wpcontratostds_13_dynamicfiltersoperator3 ,
                                             string AV78Wpcontratostds_14_contratonome3 ,
                                             string AV79Wpcontratostds_15_contratoclientedocumento3 ,
                                             string AV81Wpcontratostds_17_tfcontratonome_sel ,
                                             string AV80Wpcontratostds_16_tfcontratonome ,
                                             int AV82Wpcontratostds_18_tfcontratosituacao_sels_Count ,
                                             string A228ContratoNome ,
                                             string A475ContratoClienteDocumento ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             string AV65Wpcontratostds_1_filterfulltext ,
                                             short A1007ContratoCountAssinantes_F ,
                                             short AV83Wpcontratostds_19_tfcontratocountassinantes_f ,
                                             short AV84Wpcontratostds_20_tfcontratocountassinantes_f_to ,
                                             int A473ContratoClienteId ,
                                             int AV7ClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[28];
         Object[] GXv_Object6 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.ContratoClienteId AS ContratoClienteId, T2.ClienteDocumento AS ContratoClienteDocumento, T1.ContratoSituacao, T1.ContratoNome, T1.ContratoId, COALESCE( T3.ContratoCountAssinantes_F, 0) AS ContratoCountAssinantes_F";
         sFromString = " FROM ((Contrato T1 LEFT JOIN Cliente T2 ON T2.ClienteId = T1.ContratoClienteId) LEFT JOIN LATERAL (SELECT COUNT(*) AS ContratoCountAssinantes_F, T5.ContratoId, T4.ClienteId FROM (AssinaturaParticipante T4 LEFT JOIN Assinatura T5 ON T5.AssinaturaId = T4.AssinaturaId) WHERE T1.ContratoId = T5.ContratoId and T1.ContratoClienteId = T4.ClienteId GROUP BY T5.ContratoId, T4.ClienteId ) T3 ON T3.ContratoId = T1.ContratoId AND T3.ClienteId = T1.ContratoClienteId)";
         sOrderString = "";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV65Wpcontratostds_1_filterfulltext))=0) or ( ( T1.ContratoNome like '%' || :lV65Wpcontratostds_1_filterfulltext) or ( 'em elaboração' like '%' || LOWER(:lV65Wpcontratostds_1_filterfulltext) and T1.ContratoSituacao = ( 'EmElaboracao')) or ( 'coletando assinaturas' like '%' || LOWER(:lV65Wpcontratostds_1_filterfulltext) and T1.ContratoSituacao = ( 'ColetandoAssinatura')) or ( 'assinado' like '%' || LOWER(:lV65Wpcontratostds_1_filterfulltext) and T1.ContratoSituacao = ( 'Assinado')) or ( SUBSTR(TO_CHAR(COALESCE( T3.ContratoCountAssinantes_F, 0),'9999'), 2) like '%' || :lV65Wpcontratostds_1_filterfulltext)))");
         AddWhere(sWhereString, "((:AV83Wpcontratostds_19_tfcontratocountassinantes_f = 0) or ( COALESCE( T3.ContratoCountAssinantes_F, 0) >= :AV83Wpcontratostds_19_tfcontratocountassinantes_f))");
         AddWhere(sWhereString, "((:AV84Wpcontratostds_20_tfcontratocountassinantes_f_to = 0) or ( COALESCE( T3.ContratoCountAssinantes_F, 0) <= :AV84Wpcontratostds_20_tfcontratocountassinantes_f_to))");
         AddWhere(sWhereString, "(T1.ContratoClienteId = :AV7ClienteId)");
         if ( ( StringUtil.StrCmp(AV66Wpcontratostds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV67Wpcontratostds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Wpcontratostds_4_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like :lV68Wpcontratostds_4_contratonome1)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Wpcontratostds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV67Wpcontratostds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Wpcontratostds_4_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like '%' || :lV68Wpcontratostds_4_contratonome1)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Wpcontratostds_2_dynamicfiltersselector1, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV67Wpcontratostds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wpcontratostds_5_contratoclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV69Wpcontratostds_5_contratoclientedocumento1)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Wpcontratostds_2_dynamicfiltersselector1, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV67Wpcontratostds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wpcontratostds_5_contratoclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV69Wpcontratostds_5_contratoclientedocumento1)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( AV70Wpcontratostds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Wpcontratostds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV72Wpcontratostds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Wpcontratostds_9_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like :lV73Wpcontratostds_9_contratonome2)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( AV70Wpcontratostds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Wpcontratostds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV72Wpcontratostds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Wpcontratostds_9_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like '%' || :lV73Wpcontratostds_9_contratonome2)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( AV70Wpcontratostds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Wpcontratostds_7_dynamicfiltersselector2, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV72Wpcontratostds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Wpcontratostds_10_contratoclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV74Wpcontratostds_10_contratoclientedocumento2)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( AV70Wpcontratostds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Wpcontratostds_7_dynamicfiltersselector2, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV72Wpcontratostds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Wpcontratostds_10_contratoclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV74Wpcontratostds_10_contratoclientedocumento2)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( AV75Wpcontratostds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Wpcontratostds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV77Wpcontratostds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wpcontratostds_14_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like :lV78Wpcontratostds_14_contratonome3)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( AV75Wpcontratostds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Wpcontratostds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV77Wpcontratostds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wpcontratostds_14_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like '%' || :lV78Wpcontratostds_14_contratonome3)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( AV75Wpcontratostds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Wpcontratostds_12_dynamicfiltersselector3, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV77Wpcontratostds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wpcontratostds_15_contratoclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV79Wpcontratostds_15_contratoclientedocumento3)");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( AV75Wpcontratostds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Wpcontratostds_12_dynamicfiltersselector3, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV77Wpcontratostds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wpcontratostds_15_contratoclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV79Wpcontratostds_15_contratoclientedocumento3)");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Wpcontratostds_17_tfcontratonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wpcontratostds_16_tfcontratonome)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like :lV80Wpcontratostds_16_tfcontratonome)");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Wpcontratostds_17_tfcontratonome_sel)) && ! ( StringUtil.StrCmp(AV81Wpcontratostds_17_tfcontratonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome = ( :AV81Wpcontratostds_17_tfcontratonome_sel))");
         }
         else
         {
            GXv_int5[24] = 1;
         }
         if ( StringUtil.StrCmp(AV81Wpcontratostds_17_tfcontratonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ContratoNome IS NULL or (char_length(trim(trailing ' ' from T1.ContratoNome))=0))");
         }
         if ( AV82Wpcontratostds_18_tfcontratosituacao_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV82Wpcontratostds_18_tfcontratosituacao_sels, "T1.ContratoSituacao IN (", ")")+")");
         }
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ContratoNome, T1.ContratoId";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ContratoNome DESC, T1.ContratoId";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ContratoSituacao, T1.ContratoId";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ContratoSituacao DESC, T1.ContratoId";
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

      protected Object[] conditional_H009Q5( IGxContext context ,
                                             string A471ContratoSituacao ,
                                             GxSimpleCollection<string> AV82Wpcontratostds_18_tfcontratosituacao_sels ,
                                             string AV66Wpcontratostds_2_dynamicfiltersselector1 ,
                                             short AV67Wpcontratostds_3_dynamicfiltersoperator1 ,
                                             string AV68Wpcontratostds_4_contratonome1 ,
                                             string AV69Wpcontratostds_5_contratoclientedocumento1 ,
                                             bool AV70Wpcontratostds_6_dynamicfiltersenabled2 ,
                                             string AV71Wpcontratostds_7_dynamicfiltersselector2 ,
                                             short AV72Wpcontratostds_8_dynamicfiltersoperator2 ,
                                             string AV73Wpcontratostds_9_contratonome2 ,
                                             string AV74Wpcontratostds_10_contratoclientedocumento2 ,
                                             bool AV75Wpcontratostds_11_dynamicfiltersenabled3 ,
                                             string AV76Wpcontratostds_12_dynamicfiltersselector3 ,
                                             short AV77Wpcontratostds_13_dynamicfiltersoperator3 ,
                                             string AV78Wpcontratostds_14_contratonome3 ,
                                             string AV79Wpcontratostds_15_contratoclientedocumento3 ,
                                             string AV81Wpcontratostds_17_tfcontratonome_sel ,
                                             string AV80Wpcontratostds_16_tfcontratonome ,
                                             int AV82Wpcontratostds_18_tfcontratosituacao_sels_Count ,
                                             string A228ContratoNome ,
                                             string A475ContratoClienteDocumento ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             string AV65Wpcontratostds_1_filterfulltext ,
                                             short A1007ContratoCountAssinantes_F ,
                                             short AV83Wpcontratostds_19_tfcontratocountassinantes_f ,
                                             short AV84Wpcontratostds_20_tfcontratocountassinantes_f_to ,
                                             int A473ContratoClienteId ,
                                             int AV7ClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[25];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ((Contrato T1 LEFT JOIN Cliente T2 ON T2.ClienteId = T1.ContratoClienteId) LEFT JOIN LATERAL (SELECT COUNT(*) AS ContratoCountAssinantes_F, T5.ContratoId, T4.ClienteId FROM (AssinaturaParticipante T4 LEFT JOIN Assinatura T5 ON T5.AssinaturaId = T4.AssinaturaId) WHERE T1.ContratoId = T5.ContratoId and T1.ContratoClienteId = T4.ClienteId GROUP BY T5.ContratoId, T4.ClienteId ) T3 ON T3.ContratoId = T1.ContratoId AND T3.ClienteId = T1.ContratoClienteId)";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV65Wpcontratostds_1_filterfulltext))=0) or ( ( T1.ContratoNome like '%' || :lV65Wpcontratostds_1_filterfulltext) or ( 'em elaboração' like '%' || LOWER(:lV65Wpcontratostds_1_filterfulltext) and T1.ContratoSituacao = ( 'EmElaboracao')) or ( 'coletando assinaturas' like '%' || LOWER(:lV65Wpcontratostds_1_filterfulltext) and T1.ContratoSituacao = ( 'ColetandoAssinatura')) or ( 'assinado' like '%' || LOWER(:lV65Wpcontratostds_1_filterfulltext) and T1.ContratoSituacao = ( 'Assinado')) or ( SUBSTR(TO_CHAR(COALESCE( T3.ContratoCountAssinantes_F, 0),'9999'), 2) like '%' || :lV65Wpcontratostds_1_filterfulltext)))");
         AddWhere(sWhereString, "((:AV83Wpcontratostds_19_tfcontratocountassinantes_f = 0) or ( COALESCE( T3.ContratoCountAssinantes_F, 0) >= :AV83Wpcontratostds_19_tfcontratocountassinantes_f))");
         AddWhere(sWhereString, "((:AV84Wpcontratostds_20_tfcontratocountassinantes_f_to = 0) or ( COALESCE( T3.ContratoCountAssinantes_F, 0) <= :AV84Wpcontratostds_20_tfcontratocountassinantes_f_to))");
         AddWhere(sWhereString, "(T1.ContratoClienteId = :AV7ClienteId)");
         if ( ( StringUtil.StrCmp(AV66Wpcontratostds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV67Wpcontratostds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Wpcontratostds_4_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like :lV68Wpcontratostds_4_contratonome1)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Wpcontratostds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV67Wpcontratostds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Wpcontratostds_4_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like '%' || :lV68Wpcontratostds_4_contratonome1)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Wpcontratostds_2_dynamicfiltersselector1, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV67Wpcontratostds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wpcontratostds_5_contratoclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV69Wpcontratostds_5_contratoclientedocumento1)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Wpcontratostds_2_dynamicfiltersselector1, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV67Wpcontratostds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wpcontratostds_5_contratoclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV69Wpcontratostds_5_contratoclientedocumento1)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( AV70Wpcontratostds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Wpcontratostds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV72Wpcontratostds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Wpcontratostds_9_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like :lV73Wpcontratostds_9_contratonome2)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( AV70Wpcontratostds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Wpcontratostds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV72Wpcontratostds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Wpcontratostds_9_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like '%' || :lV73Wpcontratostds_9_contratonome2)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( AV70Wpcontratostds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Wpcontratostds_7_dynamicfiltersselector2, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV72Wpcontratostds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Wpcontratostds_10_contratoclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV74Wpcontratostds_10_contratoclientedocumento2)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( AV70Wpcontratostds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Wpcontratostds_7_dynamicfiltersselector2, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV72Wpcontratostds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Wpcontratostds_10_contratoclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV74Wpcontratostds_10_contratoclientedocumento2)");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( AV75Wpcontratostds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Wpcontratostds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV77Wpcontratostds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wpcontratostds_14_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like :lV78Wpcontratostds_14_contratonome3)");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( AV75Wpcontratostds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Wpcontratostds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV77Wpcontratostds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wpcontratostds_14_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like '%' || :lV78Wpcontratostds_14_contratonome3)");
         }
         else
         {
            GXv_int7[20] = 1;
         }
         if ( AV75Wpcontratostds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Wpcontratostds_12_dynamicfiltersselector3, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV77Wpcontratostds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wpcontratostds_15_contratoclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV79Wpcontratostds_15_contratoclientedocumento3)");
         }
         else
         {
            GXv_int7[21] = 1;
         }
         if ( AV75Wpcontratostds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Wpcontratostds_12_dynamicfiltersselector3, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV77Wpcontratostds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wpcontratostds_15_contratoclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV79Wpcontratostds_15_contratoclientedocumento3)");
         }
         else
         {
            GXv_int7[22] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Wpcontratostds_17_tfcontratonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wpcontratostds_16_tfcontratonome)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like :lV80Wpcontratostds_16_tfcontratonome)");
         }
         else
         {
            GXv_int7[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Wpcontratostds_17_tfcontratonome_sel)) && ! ( StringUtil.StrCmp(AV81Wpcontratostds_17_tfcontratonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome = ( :AV81Wpcontratostds_17_tfcontratonome_sel))");
         }
         else
         {
            GXv_int7[24] = 1;
         }
         if ( StringUtil.StrCmp(AV81Wpcontratostds_17_tfcontratonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ContratoNome IS NULL or (char_length(trim(trailing ' ' from T1.ContratoNome))=0))");
         }
         if ( AV82Wpcontratostds_18_tfcontratosituacao_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV82Wpcontratostds_18_tfcontratosituacao_sels, "T1.ContratoSituacao IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
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
                     return conditional_H009Q3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (int)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (bool)dynConstraints[22] , (string)dynConstraints[23] , (short)dynConstraints[24] , (short)dynConstraints[25] , (short)dynConstraints[26] , (int)dynConstraints[27] , (int)dynConstraints[28] );
               case 1 :
                     return conditional_H009Q5(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (int)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (bool)dynConstraints[22] , (string)dynConstraints[23] , (short)dynConstraints[24] , (short)dynConstraints[25] , (short)dynConstraints[26] , (int)dynConstraints[27] , (int)dynConstraints[28] );
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
          Object[] prmH009Q3;
          prmH009Q3 = new Object[] {
          new ParDef("AV65Wpcontratostds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Wpcontratostds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Wpcontratostds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Wpcontratostds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Wpcontratostds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Wpcontratostds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV83Wpcontratostds_19_tfcontratocountassinantes_f",GXType.Int16,4,0) ,
          new ParDef("AV83Wpcontratostds_19_tfcontratocountassinantes_f",GXType.Int16,4,0) ,
          new ParDef("AV84Wpcontratostds_20_tfcontratocountassinantes_f_to",GXType.Int16,4,0) ,
          new ParDef("AV84Wpcontratostds_20_tfcontratocountassinantes_f_to",GXType.Int16,4,0) ,
          new ParDef("AV7ClienteId",GXType.Int32,9,0) ,
          new ParDef("lV68Wpcontratostds_4_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV68Wpcontratostds_4_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV69Wpcontratostds_5_contratoclientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV69Wpcontratostds_5_contratoclientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV73Wpcontratostds_9_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV73Wpcontratostds_9_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV74Wpcontratostds_10_contratoclientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV74Wpcontratostds_10_contratoclientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV78Wpcontratostds_14_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV78Wpcontratostds_14_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV79Wpcontratostds_15_contratoclientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV79Wpcontratostds_15_contratoclientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV80Wpcontratostds_16_tfcontratonome",GXType.VarChar,125,0) ,
          new ParDef("AV81Wpcontratostds_17_tfcontratonome_sel",GXType.VarChar,125,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH009Q5;
          prmH009Q5 = new Object[] {
          new ParDef("AV65Wpcontratostds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Wpcontratostds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Wpcontratostds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Wpcontratostds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Wpcontratostds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Wpcontratostds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV83Wpcontratostds_19_tfcontratocountassinantes_f",GXType.Int16,4,0) ,
          new ParDef("AV83Wpcontratostds_19_tfcontratocountassinantes_f",GXType.Int16,4,0) ,
          new ParDef("AV84Wpcontratostds_20_tfcontratocountassinantes_f_to",GXType.Int16,4,0) ,
          new ParDef("AV84Wpcontratostds_20_tfcontratocountassinantes_f_to",GXType.Int16,4,0) ,
          new ParDef("AV7ClienteId",GXType.Int32,9,0) ,
          new ParDef("lV68Wpcontratostds_4_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV68Wpcontratostds_4_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV69Wpcontratostds_5_contratoclientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV69Wpcontratostds_5_contratoclientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV73Wpcontratostds_9_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV73Wpcontratostds_9_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV74Wpcontratostds_10_contratoclientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV74Wpcontratostds_10_contratoclientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV78Wpcontratostds_14_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV78Wpcontratostds_14_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV79Wpcontratostds_15_contratoclientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV79Wpcontratostds_15_contratoclientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV80Wpcontratostds_16_tfcontratonome",GXType.VarChar,125,0) ,
          new ParDef("AV81Wpcontratostds_17_tfcontratonome_sel",GXType.VarChar,125,0)
          };
          def= new CursorDef[] {
              new CursorDef("H009Q3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009Q3,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H009Q5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009Q5,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((short[]) buf[9])[0] = rslt.getShort(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
