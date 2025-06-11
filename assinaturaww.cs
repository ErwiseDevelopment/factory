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
   public class assinaturaww : GXDataArea
   {
      public assinaturaww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public assinaturaww( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_AssinaturaStatus ,
                           bool aP1_Vigente )
      {
         this.AV68AssinaturaStatus = aP0_AssinaturaStatus;
         this.AV69Vigente = aP1_Vigente;
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
         cmbavAssinaturastatus1 = new GXCombobox();
         cmbavDynamicfiltersselector2 = new GXCombobox();
         cmbavDynamicfiltersoperator2 = new GXCombobox();
         cmbavAssinaturastatus2 = new GXCombobox();
         cmbavDynamicfiltersselector3 = new GXCombobox();
         cmbavDynamicfiltersoperator3 = new GXCombobox();
         cmbavAssinaturastatus3 = new GXCombobox();
         cmbAssinaturaStatus = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "AssinaturaStatus");
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
               gxfirstwebparm = GetFirstPar( "AssinaturaStatus");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "AssinaturaStatus");
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
         AV13OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV14OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         cmbavDynamicfiltersselector1.FromJSonString( GetNextPar( ));
         AV16DynamicFiltersSelector1 = GetPar( "DynamicFiltersSelector1");
         cmbavDynamicfiltersoperator1.FromJSonString( GetNextPar( ));
         AV17DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator1"), "."), 18, MidpointRounding.ToEven));
         cmbavAssinaturastatus1.FromJSonString( GetNextPar( ));
         AV18AssinaturaStatus1 = GetPar( "AssinaturaStatus1");
         AV19ContratoNome1 = GetPar( "ContratoNome1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV21DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV22DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         cmbavAssinaturastatus2.FromJSonString( GetNextPar( ));
         AV23AssinaturaStatus2 = GetPar( "AssinaturaStatus2");
         AV24ContratoNome2 = GetPar( "ContratoNome2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV26DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         cmbavAssinaturastatus3.FromJSonString( GetNextPar( ));
         AV28AssinaturaStatus3 = GetPar( "AssinaturaStatus3");
         AV29ContratoNome3 = GetPar( "ContratoNome3");
         AV68AssinaturaStatus = GetPar( "AssinaturaStatus");
         AV37ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV73Pgmname = GetPar( "Pgmname");
         AV15FilterFullText = GetPar( "FilterFullText");
         AV20DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV25DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV38TFContratoNome = GetPar( "TFContratoNome");
         AV39TFContratoNome_Sel = GetPar( "TFContratoNome_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV41TFAssinaturaStatus_Sels);
         AV57TFContratoDataInicial = context.localUtil.ParseDateParm( GetPar( "TFContratoDataInicial"));
         AV58TFContratoDataInicial_To = context.localUtil.ParseDateParm( GetPar( "TFContratoDataInicial_To"));
         AV62TFContratoDataFinal = context.localUtil.ParseDateParm( GetPar( "TFContratoDataFinal"));
         AV63TFContratoDataFinal_To = context.localUtil.ParseDateParm( GetPar( "TFContratoDataFinal_To"));
         AV42TFAssinaturaFinalizadoData = context.localUtil.ParseDTimeParm( GetPar( "TFAssinaturaFinalizadoData"));
         AV43TFAssinaturaFinalizadoData_To = context.localUtil.ParseDTimeParm( GetPar( "TFAssinaturaFinalizadoData_To"));
         AV47TFAssinaturaParticipantes_F = (short)(Math.Round(NumberUtil.Val( GetPar( "TFAssinaturaParticipantes_F"), "."), 18, MidpointRounding.ToEven));
         AV48TFAssinaturaParticipantes_F_To = (short)(Math.Round(NumberUtil.Val( GetPar( "TFAssinaturaParticipantes_F_To"), "."), 18, MidpointRounding.ToEven));
         AV69Vigente = StringUtil.StrToBool( GetPar( "Vigente"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridState);
         AV31DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV30DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         AV100Clienteid = (int)(Math.Round(NumberUtil.Val( GetPar( "Clienteid"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18AssinaturaStatus1, AV19ContratoNome1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23AssinaturaStatus2, AV24ContratoNome2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28AssinaturaStatus3, AV29ContratoNome3, AV68AssinaturaStatus, AV37ManageFiltersExecutionStep, AV73Pgmname, AV15FilterFullText, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV38TFContratoNome, AV39TFContratoNome_Sel, AV41TFAssinaturaStatus_Sels, AV57TFContratoDataInicial, AV58TFContratoDataInicial_To, AV62TFContratoDataFinal, AV63TFContratoDataFinal_To, AV42TFAssinaturaFinalizadoData, AV43TFAssinaturaFinalizadoData_To, AV47TFAssinaturaParticipantes_F, AV48TFAssinaturaParticipantes_F_To, AV69Vigente, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, AV100Clienteid) ;
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
         PA5F2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5F2( ) ;
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
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
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
         GXEncryptionTmp = "assinaturaww"+UrlEncode(StringUtil.RTrim(AV68AssinaturaStatus)) + "," + UrlEncode(StringUtil.BoolToStr(AV69Vigente));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("assinaturaww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV73Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV73Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vASSINATURASTATUS", AV68AssinaturaStatus);
         GxWebStd.gx_hidden_field( context, "gxhash_vASSINATURASTATUS", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV68AssinaturaStatus, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vVIGENTE", AV69Vigente);
         GxWebStd.gx_hidden_field( context, "gxhash_vVIGENTE", GetSecureSignedToken( "", AV69Vigente, context));
         GxWebStd.gx_hidden_field( context, "vCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV100Clienteid), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV100Clienteid), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV14OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV16DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17DynamicFiltersOperator1), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vASSINATURASTATUS1", AV18AssinaturaStatus1);
         GxWebStd.gx_hidden_field( context, "GXH_vCONTRATONOME1", AV19ContratoNome1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV21DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vASSINATURASTATUS2", AV23AssinaturaStatus2);
         GxWebStd.gx_hidden_field( context, "GXH_vCONTRATONOME2", AV24ContratoNome2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV26DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vASSINATURASTATUS3", AV28AssinaturaStatus3);
         GxWebStd.gx_hidden_field( context, "GXH_vCONTRATONOME3", AV29ContratoNome3);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_116", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_116), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV35ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV35ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV51GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV52GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV53GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV49DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV49DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_CONTRATODATAINICIALAUXDATE", context.localUtil.DToC( AV59DDO_ContratoDataInicialAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_CONTRATODATAINICIALAUXDATETO", context.localUtil.DToC( AV60DDO_ContratoDataInicialAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_CONTRATODATAFINALAUXDATE", context.localUtil.DToC( AV64DDO_ContratoDataFinalAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_CONTRATODATAFINALAUXDATETO", context.localUtil.DToC( AV65DDO_ContratoDataFinalAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_ASSINATURAFINALIZADODATAAUXDATE", context.localUtil.DToC( AV44DDO_AssinaturaFinalizadoDataAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_ASSINATURAFINALIZADODATAAUXDATETO", context.localUtil.DToC( AV45DDO_AssinaturaFinalizadoDataAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV73Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV73Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV20DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV25DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vTFCONTRATONOME", AV38TFContratoNome);
         GxWebStd.gx_hidden_field( context, "vTFCONTRATONOME_SEL", AV39TFContratoNome_Sel);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFASSINATURASTATUS_SELS", AV41TFAssinaturaStatus_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFASSINATURASTATUS_SELS", AV41TFAssinaturaStatus_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFCONTRATODATAINICIAL", context.localUtil.DToC( AV57TFContratoDataInicial, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFCONTRATODATAINICIAL_TO", context.localUtil.DToC( AV58TFContratoDataInicial_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFCONTRATODATAFINAL", context.localUtil.DToC( AV62TFContratoDataFinal, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFCONTRATODATAFINAL_TO", context.localUtil.DToC( AV63TFContratoDataFinal_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFASSINATURAFINALIZADODATA", context.localUtil.TToC( AV42TFAssinaturaFinalizadoData, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFASSINATURAFINALIZADODATA_TO", context.localUtil.TToC( AV43TFAssinaturaFinalizadoData_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFASSINATURAPARTICIPANTES_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV47TFAssinaturaParticipantes_F), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFASSINATURAPARTICIPANTES_F_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV48TFAssinaturaParticipantes_F_To), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         GxWebStd.gx_hidden_field( context, "vASSINATURASTATUS", AV68AssinaturaStatus);
         GxWebStd.gx_hidden_field( context, "gxhash_vASSINATURASTATUS", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV68AssinaturaStatus, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vVIGENTE", AV69Vigente);
         GxWebStd.gx_hidden_field( context, "gxhash_vVIGENTE", GetSecureSignedToken( "", AV69Vigente, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV10GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV10GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV31DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV30DynamicFiltersRemoving);
         GxWebStd.gx_hidden_field( context, "vTFASSINATURASTATUS_SELSJSON", AV40TFAssinaturaStatus_SelsJson);
         GxWebStd.gx_hidden_field( context, "vCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV100Clienteid), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV100Clienteid), "ZZZZZZZZ9"), context));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
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
            WE5F2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5F2( ) ;
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
         GXEncryptionTmp = "assinaturaww"+UrlEncode(StringUtil.RTrim(AV68AssinaturaStatus)) + "," + UrlEncode(StringUtil.BoolToStr(AV69Vigente));
         return formatLink("assinaturaww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "AssinaturaWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Assinatura" ;
      }

      protected void WB5F0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(116), 3, 0)+","+"null"+");", "Nova assinatura", bttBtninsert_Jsonclick, 5, "Inserir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_AssinaturaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "ButtonExcel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(116), 3, 0)+","+"null"+");", "Excel", bttBtnexport_Jsonclick, 5, "Exportar para Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_AssinaturaWW.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV35ManageFiltersData);
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
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_AssinaturaWW.htm");
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_AssinaturaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'" + sGXsfl_116_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV16DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "", true, 0, "HLP_AssinaturaWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_AssinaturaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_45_5F2( true) ;
         }
         else
         {
            wb_table1_45_5F2( false) ;
         }
         return  ;
      }

      protected void wb_table1_45_5F2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_AssinaturaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_116_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV21DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "", true, 0, "HLP_AssinaturaWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_AssinaturaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_70_5F2( true) ;
         }
         else
         {
            wb_table2_70_5F2( false) ;
         }
         return  ;
      }

      protected void wb_table2_70_5F2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_AssinaturaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'" + sGXsfl_116_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV26DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "", true, 0, "HLP_AssinaturaWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_AssinaturaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_95_5F2( true) ;
         }
         else
         {
            wb_table3_95_5F2( false) ;
         }
         return  ;
      }

      protected void wb_table3_95_5F2e( bool wbgen )
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV51GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV52GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV53GridAppliedFilters);
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
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_AssinaturaWW.htm");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV49DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_contratodatainicialauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 137,'',false,'" + sGXsfl_116_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_contratodatainicialauxdatetext_Internalname, AV61DDO_ContratoDataInicialAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV61DDO_ContratoDataInicialAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,137);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_contratodatainicialauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_AssinaturaWW.htm");
            /* User Defined Control */
            ucTfcontratodatainicial_rangepicker.SetProperty("Start Date", AV59DDO_ContratoDataInicialAuxDate);
            ucTfcontratodatainicial_rangepicker.SetProperty("End Date", AV60DDO_ContratoDataInicialAuxDateTo);
            ucTfcontratodatainicial_rangepicker.Render(context, "wwp.daterangepicker", Tfcontratodatainicial_rangepicker_Internalname, "TFCONTRATODATAINICIAL_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_contratodatafinalauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 140,'',false,'" + sGXsfl_116_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_contratodatafinalauxdatetext_Internalname, AV66DDO_ContratoDataFinalAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV66DDO_ContratoDataFinalAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,140);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_contratodatafinalauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_AssinaturaWW.htm");
            /* User Defined Control */
            ucTfcontratodatafinal_rangepicker.SetProperty("Start Date", AV64DDO_ContratoDataFinalAuxDate);
            ucTfcontratodatafinal_rangepicker.SetProperty("End Date", AV65DDO_ContratoDataFinalAuxDateTo);
            ucTfcontratodatafinal_rangepicker.Render(context, "wwp.daterangepicker", Tfcontratodatafinal_rangepicker_Internalname, "TFCONTRATODATAFINAL_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_assinaturafinalizadodataauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 143,'',false,'" + sGXsfl_116_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_assinaturafinalizadodataauxdatetext_Internalname, AV46DDO_AssinaturaFinalizadoDataAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV46DDO_AssinaturaFinalizadoDataAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,143);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_assinaturafinalizadodataauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_AssinaturaWW.htm");
            /* User Defined Control */
            ucTfassinaturafinalizadodata_rangepicker.SetProperty("Start Date", AV44DDO_AssinaturaFinalizadoDataAuxDate);
            ucTfassinaturafinalizadodata_rangepicker.SetProperty("End Date", AV45DDO_AssinaturaFinalizadoDataAuxDateTo);
            ucTfassinaturafinalizadodata_rangepicker.Render(context, "wwp.daterangepicker", Tfassinaturafinalizadodata_rangepicker_Internalname, "TFASSINATURAFINALIZADODATA_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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

      protected void START5F2( )
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
         Form.Meta.addItem("description", " Assinatura", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP5F0( ) ;
      }

      protected void WS5F2( )
      {
         START5F2( ) ;
         EVT5F2( ) ;
      }

      protected void EVT5F2( )
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
                              E115F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E125F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E135F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E145F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E155F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E165F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E175F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E185F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E195F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E205F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E215F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E225F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E235F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E245F2 ();
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
                              AV67Consultar = cgiGet( edtavConsultar_Internalname);
                              AssignAttri("", false, edtavConsultar_Internalname, AV67Consultar);
                              A238AssinaturaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtAssinaturaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n238AssinaturaId = false;
                              A227ContratoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtContratoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n227ContratoId = false;
                              A228ContratoNome = cgiGet( edtContratoNome_Internalname);
                              n228ContratoNome = false;
                              cmbAssinaturaStatus.Name = cmbAssinaturaStatus_Internalname;
                              cmbAssinaturaStatus.CurrentValue = cgiGet( cmbAssinaturaStatus_Internalname);
                              A239AssinaturaStatus = cgiGet( cmbAssinaturaStatus_Internalname);
                              n239AssinaturaStatus = false;
                              A362ContratoDataInicial = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtContratoDataInicial_Internalname), 0));
                              n362ContratoDataInicial = false;
                              A363ContratoDataFinal = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtContratoDataFinal_Internalname), 0));
                              n363ContratoDataFinal = false;
                              A231ArquivoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtArquivoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n231ArquivoId = false;
                              A366AssinaturaFinalizadoData = context.localUtil.CToT( cgiGet( edtAssinaturaFinalizadoData_Internalname), 0);
                              n366AssinaturaFinalizadoData = false;
                              A367AssinaturaParticipantes_F = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtAssinaturaParticipantes_F_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n367AssinaturaParticipantes_F = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E255F2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E265F2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E275F2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV13OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV14OrderedDsc )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV16DynamicFiltersSelector1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator1 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV17DynamicFiltersOperator1 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Assinaturastatus1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vASSINATURASTATUS1"), AV18AssinaturaStatus1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Contratonome1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATONOME1"), AV19ContratoNome1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV21DynamicFiltersSelector2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV22DynamicFiltersOperator2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Assinaturastatus2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vASSINATURASTATUS2"), AV23AssinaturaStatus2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Contratonome2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATONOME2"), AV24ContratoNome2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV26DynamicFiltersSelector3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV27DynamicFiltersOperator3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Assinaturastatus3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vASSINATURASTATUS3"), AV28AssinaturaStatus3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Contratonome3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATONOME3"), AV29ContratoNome3) != 0 )
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

      protected void WE5F2( )
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

      protected void PA5F2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "assinaturaww")), "assinaturaww") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "assinaturaww")))) ;
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
                  gxfirstwebparm = GetFirstPar( "AssinaturaStatus");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV68AssinaturaStatus = gxfirstwebparm;
                     AssignAttri("", false, "AV68AssinaturaStatus", AV68AssinaturaStatus);
                     GxWebStd.gx_hidden_field( context, "gxhash_vASSINATURASTATUS", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV68AssinaturaStatus, "")), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV69Vigente = StringUtil.StrToBool( GetPar( "Vigente"));
                        AssignAttri("", false, "AV69Vigente", AV69Vigente);
                        GxWebStd.gx_hidden_field( context, "gxhash_vVIGENTE", GetSecureSignedToken( "", AV69Vigente, context));
                     }
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
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       string AV16DynamicFiltersSelector1 ,
                                       short AV17DynamicFiltersOperator1 ,
                                       string AV18AssinaturaStatus1 ,
                                       string AV19ContratoNome1 ,
                                       string AV21DynamicFiltersSelector2 ,
                                       short AV22DynamicFiltersOperator2 ,
                                       string AV23AssinaturaStatus2 ,
                                       string AV24ContratoNome2 ,
                                       string AV26DynamicFiltersSelector3 ,
                                       short AV27DynamicFiltersOperator3 ,
                                       string AV28AssinaturaStatus3 ,
                                       string AV29ContratoNome3 ,
                                       string AV68AssinaturaStatus ,
                                       short AV37ManageFiltersExecutionStep ,
                                       string AV73Pgmname ,
                                       string AV15FilterFullText ,
                                       bool AV20DynamicFiltersEnabled2 ,
                                       bool AV25DynamicFiltersEnabled3 ,
                                       string AV38TFContratoNome ,
                                       string AV39TFContratoNome_Sel ,
                                       GxSimpleCollection<string> AV41TFAssinaturaStatus_Sels ,
                                       DateTime AV57TFContratoDataInicial ,
                                       DateTime AV58TFContratoDataInicial_To ,
                                       DateTime AV62TFContratoDataFinal ,
                                       DateTime AV63TFContratoDataFinal_To ,
                                       DateTime AV42TFAssinaturaFinalizadoData ,
                                       DateTime AV43TFAssinaturaFinalizadoData_To ,
                                       short AV47TFAssinaturaParticipantes_F ,
                                       short AV48TFAssinaturaParticipantes_F_To ,
                                       bool AV69Vigente ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV31DynamicFiltersIgnoreFirst ,
                                       bool AV30DynamicFiltersRemoving ,
                                       int AV100Clienteid )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF5F2( ) ;
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
            AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV17DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         }
         if ( cmbavAssinaturastatus1.ItemCount > 0 )
         {
            AV18AssinaturaStatus1 = cmbavAssinaturastatus1.getValidValue(AV18AssinaturaStatus1);
            AssignAttri("", false, "AV18AssinaturaStatus1", AV18AssinaturaStatus1);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavAssinaturastatus1.CurrentValue = StringUtil.RTrim( AV18AssinaturaStatus1);
            AssignProp("", false, cmbavAssinaturastatus1_Internalname, "Values", cmbavAssinaturastatus1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV21DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV21DynamicFiltersSelector2);
            AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV22DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         }
         if ( cmbavAssinaturastatus2.ItemCount > 0 )
         {
            AV23AssinaturaStatus2 = cmbavAssinaturastatus2.getValidValue(AV23AssinaturaStatus2);
            AssignAttri("", false, "AV23AssinaturaStatus2", AV23AssinaturaStatus2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavAssinaturastatus2.CurrentValue = StringUtil.RTrim( AV23AssinaturaStatus2);
            AssignProp("", false, cmbavAssinaturastatus2_Internalname, "Values", cmbavAssinaturastatus2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV26DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV26DynamicFiltersSelector3);
            AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
         if ( cmbavAssinaturastatus3.ItemCount > 0 )
         {
            AV28AssinaturaStatus3 = cmbavAssinaturastatus3.getValidValue(AV28AssinaturaStatus3);
            AssignAttri("", false, "AV28AssinaturaStatus3", AV28AssinaturaStatus3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavAssinaturastatus3.CurrentValue = StringUtil.RTrim( AV28AssinaturaStatus3);
            AssignProp("", false, cmbavAssinaturastatus3_Internalname, "Values", cmbavAssinaturastatus3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF5F2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV73Pgmname = "AssinaturaWW";
         Gx_date = DateTimeUtil.Today( context);
         edtavConsultar_Enabled = 0;
      }

      protected void RF5F2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 116;
         /* Execute user event: Refresh */
         E265F2 ();
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
                                                 A239AssinaturaStatus ,
                                                 AV91Assinaturawwds_18_tfassinaturastatus_sels ,
                                                 AV75Assinaturawwds_2_dynamicfiltersselector1 ,
                                                 AV77Assinaturawwds_4_assinaturastatus1 ,
                                                 AV76Assinaturawwds_3_dynamicfiltersoperator1 ,
                                                 AV78Assinaturawwds_5_contratonome1 ,
                                                 AV79Assinaturawwds_6_dynamicfiltersenabled2 ,
                                                 AV80Assinaturawwds_7_dynamicfiltersselector2 ,
                                                 AV82Assinaturawwds_9_assinaturastatus2 ,
                                                 AV81Assinaturawwds_8_dynamicfiltersoperator2 ,
                                                 AV83Assinaturawwds_10_contratonome2 ,
                                                 AV84Assinaturawwds_11_dynamicfiltersenabled3 ,
                                                 AV85Assinaturawwds_12_dynamicfiltersselector3 ,
                                                 AV87Assinaturawwds_14_assinaturastatus3 ,
                                                 AV86Assinaturawwds_13_dynamicfiltersoperator3 ,
                                                 AV88Assinaturawwds_15_contratonome3 ,
                                                 AV90Assinaturawwds_17_tfcontratonome_sel ,
                                                 AV89Assinaturawwds_16_tfcontratonome ,
                                                 AV91Assinaturawwds_18_tfassinaturastatus_sels.Count ,
                                                 AV92Assinaturawwds_19_tfcontratodatainicial ,
                                                 AV93Assinaturawwds_20_tfcontratodatainicial_to ,
                                                 AV94Assinaturawwds_21_tfcontratodatafinal ,
                                                 AV95Assinaturawwds_22_tfcontratodatafinal_to ,
                                                 AV96Assinaturawwds_23_tfassinaturafinalizadodata ,
                                                 AV97Assinaturawwds_24_tfassinaturafinalizadodata_to ,
                                                 AV68AssinaturaStatus ,
                                                 A228ContratoNome ,
                                                 A362ContratoDataInicial ,
                                                 A363ContratoDataFinal ,
                                                 A366AssinaturaFinalizadoData ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc ,
                                                 AV74Assinaturawwds_1_filterfulltext ,
                                                 A367AssinaturaParticipantes_F ,
                                                 AV98Assinaturawwds_25_tfassinaturaparticipantes_f ,
                                                 AV99Assinaturawwds_26_tfassinaturaparticipantes_f_to } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV74Assinaturawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Assinaturawwds_1_filterfulltext), "%", "");
            lV74Assinaturawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Assinaturawwds_1_filterfulltext), "%", "");
            lV74Assinaturawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Assinaturawwds_1_filterfulltext), "%", "");
            lV74Assinaturawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Assinaturawwds_1_filterfulltext), "%", "");
            lV74Assinaturawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Assinaturawwds_1_filterfulltext), "%", "");
            lV74Assinaturawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Assinaturawwds_1_filterfulltext), "%", "");
            lV74Assinaturawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Assinaturawwds_1_filterfulltext), "%", "");
            lV78Assinaturawwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV78Assinaturawwds_5_contratonome1), "%", "");
            lV78Assinaturawwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV78Assinaturawwds_5_contratonome1), "%", "");
            lV83Assinaturawwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV83Assinaturawwds_10_contratonome2), "%", "");
            lV83Assinaturawwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV83Assinaturawwds_10_contratonome2), "%", "");
            lV88Assinaturawwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV88Assinaturawwds_15_contratonome3), "%", "");
            lV88Assinaturawwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV88Assinaturawwds_15_contratonome3), "%", "");
            lV89Assinaturawwds_16_tfcontratonome = StringUtil.Concat( StringUtil.RTrim( AV89Assinaturawwds_16_tfcontratonome), "%", "");
            /* Using cursor H005F3 */
            pr_default.execute(0, new Object[] {AV74Assinaturawwds_1_filterfulltext, lV74Assinaturawwds_1_filterfulltext, lV74Assinaturawwds_1_filterfulltext, lV74Assinaturawwds_1_filterfulltext, lV74Assinaturawwds_1_filterfulltext, lV74Assinaturawwds_1_filterfulltext, lV74Assinaturawwds_1_filterfulltext, lV74Assinaturawwds_1_filterfulltext, AV98Assinaturawwds_25_tfassinaturaparticipantes_f, AV98Assinaturawwds_25_tfassinaturaparticipantes_f, AV99Assinaturawwds_26_tfassinaturaparticipantes_f_to, AV99Assinaturawwds_26_tfassinaturaparticipantes_f_to, AV77Assinaturawwds_4_assinaturastatus1, lV78Assinaturawwds_5_contratonome1, lV78Assinaturawwds_5_contratonome1, AV82Assinaturawwds_9_assinaturastatus2, lV83Assinaturawwds_10_contratonome2, lV83Assinaturawwds_10_contratonome2, AV87Assinaturawwds_14_assinaturastatus3, lV88Assinaturawwds_15_contratonome3, lV88Assinaturawwds_15_contratonome3, lV89Assinaturawwds_16_tfcontratonome, AV90Assinaturawwds_17_tfcontratonome_sel, AV92Assinaturawwds_19_tfcontratodatainicial, AV93Assinaturawwds_20_tfcontratodatainicial_to, AV94Assinaturawwds_21_tfcontratodatafinal, AV95Assinaturawwds_22_tfcontratodatafinal_to, AV96Assinaturawwds_23_tfassinaturafinalizadodata, AV97Assinaturawwds_24_tfassinaturafinalizadodata_to, AV68AssinaturaStatus, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_116_idx = 1;
            sGXsfl_116_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_116_idx), 4, 0), 4, "0");
            SubsflControlProps_1162( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A366AssinaturaFinalizadoData = H005F3_A366AssinaturaFinalizadoData[0];
               n366AssinaturaFinalizadoData = H005F3_n366AssinaturaFinalizadoData[0];
               A231ArquivoId = H005F3_A231ArquivoId[0];
               n231ArquivoId = H005F3_n231ArquivoId[0];
               A363ContratoDataFinal = H005F3_A363ContratoDataFinal[0];
               n363ContratoDataFinal = H005F3_n363ContratoDataFinal[0];
               A362ContratoDataInicial = H005F3_A362ContratoDataInicial[0];
               n362ContratoDataInicial = H005F3_n362ContratoDataInicial[0];
               A239AssinaturaStatus = H005F3_A239AssinaturaStatus[0];
               n239AssinaturaStatus = H005F3_n239AssinaturaStatus[0];
               A228ContratoNome = H005F3_A228ContratoNome[0];
               n228ContratoNome = H005F3_n228ContratoNome[0];
               A227ContratoId = H005F3_A227ContratoId[0];
               n227ContratoId = H005F3_n227ContratoId[0];
               A238AssinaturaId = H005F3_A238AssinaturaId[0];
               n238AssinaturaId = H005F3_n238AssinaturaId[0];
               A367AssinaturaParticipantes_F = H005F3_A367AssinaturaParticipantes_F[0];
               n367AssinaturaParticipantes_F = H005F3_n367AssinaturaParticipantes_F[0];
               A363ContratoDataFinal = H005F3_A363ContratoDataFinal[0];
               n363ContratoDataFinal = H005F3_n363ContratoDataFinal[0];
               A362ContratoDataInicial = H005F3_A362ContratoDataInicial[0];
               n362ContratoDataInicial = H005F3_n362ContratoDataInicial[0];
               A228ContratoNome = H005F3_A228ContratoNome[0];
               n228ContratoNome = H005F3_n228ContratoNome[0];
               A367AssinaturaParticipantes_F = H005F3_A367AssinaturaParticipantes_F[0];
               n367AssinaturaParticipantes_F = H005F3_n367AssinaturaParticipantes_F[0];
               /* Execute user event: Grid.Load */
               E275F2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 116;
            WB5F0( ) ;
         }
         bGXsfl_116_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes5F2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV73Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV73Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV100Clienteid), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV100Clienteid), "ZZZZZZZZ9"), context));
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
         AV74Assinaturawwds_1_filterfulltext = AV15FilterFullText;
         AV75Assinaturawwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV76Assinaturawwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV77Assinaturawwds_4_assinaturastatus1 = AV18AssinaturaStatus1;
         AV78Assinaturawwds_5_contratonome1 = AV19ContratoNome1;
         AV79Assinaturawwds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV80Assinaturawwds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV81Assinaturawwds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV82Assinaturawwds_9_assinaturastatus2 = AV23AssinaturaStatus2;
         AV83Assinaturawwds_10_contratonome2 = AV24ContratoNome2;
         AV84Assinaturawwds_11_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV85Assinaturawwds_12_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV86Assinaturawwds_13_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV87Assinaturawwds_14_assinaturastatus3 = AV28AssinaturaStatus3;
         AV88Assinaturawwds_15_contratonome3 = AV29ContratoNome3;
         AV89Assinaturawwds_16_tfcontratonome = AV38TFContratoNome;
         AV90Assinaturawwds_17_tfcontratonome_sel = AV39TFContratoNome_Sel;
         AV91Assinaturawwds_18_tfassinaturastatus_sels = AV41TFAssinaturaStatus_Sels;
         AV92Assinaturawwds_19_tfcontratodatainicial = AV57TFContratoDataInicial;
         AV93Assinaturawwds_20_tfcontratodatainicial_to = AV58TFContratoDataInicial_To;
         AV94Assinaturawwds_21_tfcontratodatafinal = AV62TFContratoDataFinal;
         AV95Assinaturawwds_22_tfcontratodatafinal_to = AV63TFContratoDataFinal_To;
         AV96Assinaturawwds_23_tfassinaturafinalizadodata = AV42TFAssinaturaFinalizadoData;
         AV97Assinaturawwds_24_tfassinaturafinalizadodata_to = AV43TFAssinaturaFinalizadoData_To;
         AV98Assinaturawwds_25_tfassinaturaparticipantes_f = AV47TFAssinaturaParticipantes_F;
         AV99Assinaturawwds_26_tfassinaturaparticipantes_f_to = AV48TFAssinaturaParticipantes_F_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A239AssinaturaStatus ,
                                              AV91Assinaturawwds_18_tfassinaturastatus_sels ,
                                              AV75Assinaturawwds_2_dynamicfiltersselector1 ,
                                              AV77Assinaturawwds_4_assinaturastatus1 ,
                                              AV76Assinaturawwds_3_dynamicfiltersoperator1 ,
                                              AV78Assinaturawwds_5_contratonome1 ,
                                              AV79Assinaturawwds_6_dynamicfiltersenabled2 ,
                                              AV80Assinaturawwds_7_dynamicfiltersselector2 ,
                                              AV82Assinaturawwds_9_assinaturastatus2 ,
                                              AV81Assinaturawwds_8_dynamicfiltersoperator2 ,
                                              AV83Assinaturawwds_10_contratonome2 ,
                                              AV84Assinaturawwds_11_dynamicfiltersenabled3 ,
                                              AV85Assinaturawwds_12_dynamicfiltersselector3 ,
                                              AV87Assinaturawwds_14_assinaturastatus3 ,
                                              AV86Assinaturawwds_13_dynamicfiltersoperator3 ,
                                              AV88Assinaturawwds_15_contratonome3 ,
                                              AV90Assinaturawwds_17_tfcontratonome_sel ,
                                              AV89Assinaturawwds_16_tfcontratonome ,
                                              AV91Assinaturawwds_18_tfassinaturastatus_sels.Count ,
                                              AV92Assinaturawwds_19_tfcontratodatainicial ,
                                              AV93Assinaturawwds_20_tfcontratodatainicial_to ,
                                              AV94Assinaturawwds_21_tfcontratodatafinal ,
                                              AV95Assinaturawwds_22_tfcontratodatafinal_to ,
                                              AV96Assinaturawwds_23_tfassinaturafinalizadodata ,
                                              AV97Assinaturawwds_24_tfassinaturafinalizadodata_to ,
                                              AV68AssinaturaStatus ,
                                              A228ContratoNome ,
                                              A362ContratoDataInicial ,
                                              A363ContratoDataFinal ,
                                              A366AssinaturaFinalizadoData ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc ,
                                              AV74Assinaturawwds_1_filterfulltext ,
                                              A367AssinaturaParticipantes_F ,
                                              AV98Assinaturawwds_25_tfassinaturaparticipantes_f ,
                                              AV99Assinaturawwds_26_tfassinaturaparticipantes_f_to } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV74Assinaturawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Assinaturawwds_1_filterfulltext), "%", "");
         lV74Assinaturawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Assinaturawwds_1_filterfulltext), "%", "");
         lV74Assinaturawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Assinaturawwds_1_filterfulltext), "%", "");
         lV74Assinaturawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Assinaturawwds_1_filterfulltext), "%", "");
         lV74Assinaturawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Assinaturawwds_1_filterfulltext), "%", "");
         lV74Assinaturawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Assinaturawwds_1_filterfulltext), "%", "");
         lV74Assinaturawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Assinaturawwds_1_filterfulltext), "%", "");
         lV78Assinaturawwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV78Assinaturawwds_5_contratonome1), "%", "");
         lV78Assinaturawwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV78Assinaturawwds_5_contratonome1), "%", "");
         lV83Assinaturawwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV83Assinaturawwds_10_contratonome2), "%", "");
         lV83Assinaturawwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV83Assinaturawwds_10_contratonome2), "%", "");
         lV88Assinaturawwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV88Assinaturawwds_15_contratonome3), "%", "");
         lV88Assinaturawwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV88Assinaturawwds_15_contratonome3), "%", "");
         lV89Assinaturawwds_16_tfcontratonome = StringUtil.Concat( StringUtil.RTrim( AV89Assinaturawwds_16_tfcontratonome), "%", "");
         /* Using cursor H005F5 */
         pr_default.execute(1, new Object[] {AV74Assinaturawwds_1_filterfulltext, lV74Assinaturawwds_1_filterfulltext, lV74Assinaturawwds_1_filterfulltext, lV74Assinaturawwds_1_filterfulltext, lV74Assinaturawwds_1_filterfulltext, lV74Assinaturawwds_1_filterfulltext, lV74Assinaturawwds_1_filterfulltext, lV74Assinaturawwds_1_filterfulltext, AV98Assinaturawwds_25_tfassinaturaparticipantes_f, AV98Assinaturawwds_25_tfassinaturaparticipantes_f, AV99Assinaturawwds_26_tfassinaturaparticipantes_f_to, AV99Assinaturawwds_26_tfassinaturaparticipantes_f_to, AV77Assinaturawwds_4_assinaturastatus1, lV78Assinaturawwds_5_contratonome1, lV78Assinaturawwds_5_contratonome1, AV82Assinaturawwds_9_assinaturastatus2, lV83Assinaturawwds_10_contratonome2, lV83Assinaturawwds_10_contratonome2, AV87Assinaturawwds_14_assinaturastatus3, lV88Assinaturawwds_15_contratonome3, lV88Assinaturawwds_15_contratonome3, lV89Assinaturawwds_16_tfcontratonome, AV90Assinaturawwds_17_tfcontratonome_sel, AV92Assinaturawwds_19_tfcontratodatainicial, AV93Assinaturawwds_20_tfcontratodatainicial_to, AV94Assinaturawwds_21_tfcontratodatafinal, AV95Assinaturawwds_22_tfcontratodatafinal_to, AV96Assinaturawwds_23_tfassinaturafinalizadodata, AV97Assinaturawwds_24_tfassinaturafinalizadodata_to, AV68AssinaturaStatus});
         GRID_nRecordCount = H005F5_AGRID_nRecordCount[0];
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
         AV74Assinaturawwds_1_filterfulltext = AV15FilterFullText;
         AV75Assinaturawwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV76Assinaturawwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV77Assinaturawwds_4_assinaturastatus1 = AV18AssinaturaStatus1;
         AV78Assinaturawwds_5_contratonome1 = AV19ContratoNome1;
         AV79Assinaturawwds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV80Assinaturawwds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV81Assinaturawwds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV82Assinaturawwds_9_assinaturastatus2 = AV23AssinaturaStatus2;
         AV83Assinaturawwds_10_contratonome2 = AV24ContratoNome2;
         AV84Assinaturawwds_11_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV85Assinaturawwds_12_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV86Assinaturawwds_13_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV87Assinaturawwds_14_assinaturastatus3 = AV28AssinaturaStatus3;
         AV88Assinaturawwds_15_contratonome3 = AV29ContratoNome3;
         AV89Assinaturawwds_16_tfcontratonome = AV38TFContratoNome;
         AV90Assinaturawwds_17_tfcontratonome_sel = AV39TFContratoNome_Sel;
         AV91Assinaturawwds_18_tfassinaturastatus_sels = AV41TFAssinaturaStatus_Sels;
         AV92Assinaturawwds_19_tfcontratodatainicial = AV57TFContratoDataInicial;
         AV93Assinaturawwds_20_tfcontratodatainicial_to = AV58TFContratoDataInicial_To;
         AV94Assinaturawwds_21_tfcontratodatafinal = AV62TFContratoDataFinal;
         AV95Assinaturawwds_22_tfcontratodatafinal_to = AV63TFContratoDataFinal_To;
         AV96Assinaturawwds_23_tfassinaturafinalizadodata = AV42TFAssinaturaFinalizadoData;
         AV97Assinaturawwds_24_tfassinaturafinalizadodata_to = AV43TFAssinaturaFinalizadoData_To;
         AV98Assinaturawwds_25_tfassinaturaparticipantes_f = AV47TFAssinaturaParticipantes_F;
         AV99Assinaturawwds_26_tfassinaturaparticipantes_f_to = AV48TFAssinaturaParticipantes_F_To;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18AssinaturaStatus1, AV19ContratoNome1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23AssinaturaStatus2, AV24ContratoNome2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28AssinaturaStatus3, AV29ContratoNome3, AV68AssinaturaStatus, AV37ManageFiltersExecutionStep, AV73Pgmname, AV15FilterFullText, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV38TFContratoNome, AV39TFContratoNome_Sel, AV41TFAssinaturaStatus_Sels, AV57TFContratoDataInicial, AV58TFContratoDataInicial_To, AV62TFContratoDataFinal, AV63TFContratoDataFinal_To, AV42TFAssinaturaFinalizadoData, AV43TFAssinaturaFinalizadoData_To, AV47TFAssinaturaParticipantes_F, AV48TFAssinaturaParticipantes_F_To, AV69Vigente, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, AV100Clienteid) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV74Assinaturawwds_1_filterfulltext = AV15FilterFullText;
         AV75Assinaturawwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV76Assinaturawwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV77Assinaturawwds_4_assinaturastatus1 = AV18AssinaturaStatus1;
         AV78Assinaturawwds_5_contratonome1 = AV19ContratoNome1;
         AV79Assinaturawwds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV80Assinaturawwds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV81Assinaturawwds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV82Assinaturawwds_9_assinaturastatus2 = AV23AssinaturaStatus2;
         AV83Assinaturawwds_10_contratonome2 = AV24ContratoNome2;
         AV84Assinaturawwds_11_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV85Assinaturawwds_12_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV86Assinaturawwds_13_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV87Assinaturawwds_14_assinaturastatus3 = AV28AssinaturaStatus3;
         AV88Assinaturawwds_15_contratonome3 = AV29ContratoNome3;
         AV89Assinaturawwds_16_tfcontratonome = AV38TFContratoNome;
         AV90Assinaturawwds_17_tfcontratonome_sel = AV39TFContratoNome_Sel;
         AV91Assinaturawwds_18_tfassinaturastatus_sels = AV41TFAssinaturaStatus_Sels;
         AV92Assinaturawwds_19_tfcontratodatainicial = AV57TFContratoDataInicial;
         AV93Assinaturawwds_20_tfcontratodatainicial_to = AV58TFContratoDataInicial_To;
         AV94Assinaturawwds_21_tfcontratodatafinal = AV62TFContratoDataFinal;
         AV95Assinaturawwds_22_tfcontratodatafinal_to = AV63TFContratoDataFinal_To;
         AV96Assinaturawwds_23_tfassinaturafinalizadodata = AV42TFAssinaturaFinalizadoData;
         AV97Assinaturawwds_24_tfassinaturafinalizadodata_to = AV43TFAssinaturaFinalizadoData_To;
         AV98Assinaturawwds_25_tfassinaturaparticipantes_f = AV47TFAssinaturaParticipantes_F;
         AV99Assinaturawwds_26_tfassinaturaparticipantes_f_to = AV48TFAssinaturaParticipantes_F_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18AssinaturaStatus1, AV19ContratoNome1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23AssinaturaStatus2, AV24ContratoNome2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28AssinaturaStatus3, AV29ContratoNome3, AV68AssinaturaStatus, AV37ManageFiltersExecutionStep, AV73Pgmname, AV15FilterFullText, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV38TFContratoNome, AV39TFContratoNome_Sel, AV41TFAssinaturaStatus_Sels, AV57TFContratoDataInicial, AV58TFContratoDataInicial_To, AV62TFContratoDataFinal, AV63TFContratoDataFinal_To, AV42TFAssinaturaFinalizadoData, AV43TFAssinaturaFinalizadoData_To, AV47TFAssinaturaParticipantes_F, AV48TFAssinaturaParticipantes_F_To, AV69Vigente, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, AV100Clienteid) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV74Assinaturawwds_1_filterfulltext = AV15FilterFullText;
         AV75Assinaturawwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV76Assinaturawwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV77Assinaturawwds_4_assinaturastatus1 = AV18AssinaturaStatus1;
         AV78Assinaturawwds_5_contratonome1 = AV19ContratoNome1;
         AV79Assinaturawwds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV80Assinaturawwds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV81Assinaturawwds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV82Assinaturawwds_9_assinaturastatus2 = AV23AssinaturaStatus2;
         AV83Assinaturawwds_10_contratonome2 = AV24ContratoNome2;
         AV84Assinaturawwds_11_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV85Assinaturawwds_12_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV86Assinaturawwds_13_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV87Assinaturawwds_14_assinaturastatus3 = AV28AssinaturaStatus3;
         AV88Assinaturawwds_15_contratonome3 = AV29ContratoNome3;
         AV89Assinaturawwds_16_tfcontratonome = AV38TFContratoNome;
         AV90Assinaturawwds_17_tfcontratonome_sel = AV39TFContratoNome_Sel;
         AV91Assinaturawwds_18_tfassinaturastatus_sels = AV41TFAssinaturaStatus_Sels;
         AV92Assinaturawwds_19_tfcontratodatainicial = AV57TFContratoDataInicial;
         AV93Assinaturawwds_20_tfcontratodatainicial_to = AV58TFContratoDataInicial_To;
         AV94Assinaturawwds_21_tfcontratodatafinal = AV62TFContratoDataFinal;
         AV95Assinaturawwds_22_tfcontratodatafinal_to = AV63TFContratoDataFinal_To;
         AV96Assinaturawwds_23_tfassinaturafinalizadodata = AV42TFAssinaturaFinalizadoData;
         AV97Assinaturawwds_24_tfassinaturafinalizadodata_to = AV43TFAssinaturaFinalizadoData_To;
         AV98Assinaturawwds_25_tfassinaturaparticipantes_f = AV47TFAssinaturaParticipantes_F;
         AV99Assinaturawwds_26_tfassinaturaparticipantes_f_to = AV48TFAssinaturaParticipantes_F_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18AssinaturaStatus1, AV19ContratoNome1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23AssinaturaStatus2, AV24ContratoNome2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28AssinaturaStatus3, AV29ContratoNome3, AV68AssinaturaStatus, AV37ManageFiltersExecutionStep, AV73Pgmname, AV15FilterFullText, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV38TFContratoNome, AV39TFContratoNome_Sel, AV41TFAssinaturaStatus_Sels, AV57TFContratoDataInicial, AV58TFContratoDataInicial_To, AV62TFContratoDataFinal, AV63TFContratoDataFinal_To, AV42TFAssinaturaFinalizadoData, AV43TFAssinaturaFinalizadoData_To, AV47TFAssinaturaParticipantes_F, AV48TFAssinaturaParticipantes_F_To, AV69Vigente, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, AV100Clienteid) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV74Assinaturawwds_1_filterfulltext = AV15FilterFullText;
         AV75Assinaturawwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV76Assinaturawwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV77Assinaturawwds_4_assinaturastatus1 = AV18AssinaturaStatus1;
         AV78Assinaturawwds_5_contratonome1 = AV19ContratoNome1;
         AV79Assinaturawwds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV80Assinaturawwds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV81Assinaturawwds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV82Assinaturawwds_9_assinaturastatus2 = AV23AssinaturaStatus2;
         AV83Assinaturawwds_10_contratonome2 = AV24ContratoNome2;
         AV84Assinaturawwds_11_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV85Assinaturawwds_12_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV86Assinaturawwds_13_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV87Assinaturawwds_14_assinaturastatus3 = AV28AssinaturaStatus3;
         AV88Assinaturawwds_15_contratonome3 = AV29ContratoNome3;
         AV89Assinaturawwds_16_tfcontratonome = AV38TFContratoNome;
         AV90Assinaturawwds_17_tfcontratonome_sel = AV39TFContratoNome_Sel;
         AV91Assinaturawwds_18_tfassinaturastatus_sels = AV41TFAssinaturaStatus_Sels;
         AV92Assinaturawwds_19_tfcontratodatainicial = AV57TFContratoDataInicial;
         AV93Assinaturawwds_20_tfcontratodatainicial_to = AV58TFContratoDataInicial_To;
         AV94Assinaturawwds_21_tfcontratodatafinal = AV62TFContratoDataFinal;
         AV95Assinaturawwds_22_tfcontratodatafinal_to = AV63TFContratoDataFinal_To;
         AV96Assinaturawwds_23_tfassinaturafinalizadodata = AV42TFAssinaturaFinalizadoData;
         AV97Assinaturawwds_24_tfassinaturafinalizadodata_to = AV43TFAssinaturaFinalizadoData_To;
         AV98Assinaturawwds_25_tfassinaturaparticipantes_f = AV47TFAssinaturaParticipantes_F;
         AV99Assinaturawwds_26_tfassinaturaparticipantes_f_to = AV48TFAssinaturaParticipantes_F_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18AssinaturaStatus1, AV19ContratoNome1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23AssinaturaStatus2, AV24ContratoNome2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28AssinaturaStatus3, AV29ContratoNome3, AV68AssinaturaStatus, AV37ManageFiltersExecutionStep, AV73Pgmname, AV15FilterFullText, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV38TFContratoNome, AV39TFContratoNome_Sel, AV41TFAssinaturaStatus_Sels, AV57TFContratoDataInicial, AV58TFContratoDataInicial_To, AV62TFContratoDataFinal, AV63TFContratoDataFinal_To, AV42TFAssinaturaFinalizadoData, AV43TFAssinaturaFinalizadoData_To, AV47TFAssinaturaParticipantes_F, AV48TFAssinaturaParticipantes_F_To, AV69Vigente, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, AV100Clienteid) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV74Assinaturawwds_1_filterfulltext = AV15FilterFullText;
         AV75Assinaturawwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV76Assinaturawwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV77Assinaturawwds_4_assinaturastatus1 = AV18AssinaturaStatus1;
         AV78Assinaturawwds_5_contratonome1 = AV19ContratoNome1;
         AV79Assinaturawwds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV80Assinaturawwds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV81Assinaturawwds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV82Assinaturawwds_9_assinaturastatus2 = AV23AssinaturaStatus2;
         AV83Assinaturawwds_10_contratonome2 = AV24ContratoNome2;
         AV84Assinaturawwds_11_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV85Assinaturawwds_12_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV86Assinaturawwds_13_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV87Assinaturawwds_14_assinaturastatus3 = AV28AssinaturaStatus3;
         AV88Assinaturawwds_15_contratonome3 = AV29ContratoNome3;
         AV89Assinaturawwds_16_tfcontratonome = AV38TFContratoNome;
         AV90Assinaturawwds_17_tfcontratonome_sel = AV39TFContratoNome_Sel;
         AV91Assinaturawwds_18_tfassinaturastatus_sels = AV41TFAssinaturaStatus_Sels;
         AV92Assinaturawwds_19_tfcontratodatainicial = AV57TFContratoDataInicial;
         AV93Assinaturawwds_20_tfcontratodatainicial_to = AV58TFContratoDataInicial_To;
         AV94Assinaturawwds_21_tfcontratodatafinal = AV62TFContratoDataFinal;
         AV95Assinaturawwds_22_tfcontratodatafinal_to = AV63TFContratoDataFinal_To;
         AV96Assinaturawwds_23_tfassinaturafinalizadodata = AV42TFAssinaturaFinalizadoData;
         AV97Assinaturawwds_24_tfassinaturafinalizadodata_to = AV43TFAssinaturaFinalizadoData_To;
         AV98Assinaturawwds_25_tfassinaturaparticipantes_f = AV47TFAssinaturaParticipantes_F;
         AV99Assinaturawwds_26_tfassinaturaparticipantes_f_to = AV48TFAssinaturaParticipantes_F_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18AssinaturaStatus1, AV19ContratoNome1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23AssinaturaStatus2, AV24ContratoNome2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28AssinaturaStatus3, AV29ContratoNome3, AV68AssinaturaStatus, AV37ManageFiltersExecutionStep, AV73Pgmname, AV15FilterFullText, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV38TFContratoNome, AV39TFContratoNome_Sel, AV41TFAssinaturaStatus_Sels, AV57TFContratoDataInicial, AV58TFContratoDataInicial_To, AV62TFContratoDataFinal, AV63TFContratoDataFinal_To, AV42TFAssinaturaFinalizadoData, AV43TFAssinaturaFinalizadoData_To, AV47TFAssinaturaParticipantes_F, AV48TFAssinaturaParticipantes_F_To, AV69Vigente, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, AV100Clienteid) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV73Pgmname = "AssinaturaWW";
         Gx_date = DateTimeUtil.Today( context);
         edtavConsultar_Enabled = 0;
         edtAssinaturaId_Enabled = 0;
         edtContratoId_Enabled = 0;
         edtContratoNome_Enabled = 0;
         cmbAssinaturaStatus.Enabled = 0;
         edtContratoDataInicial_Enabled = 0;
         edtContratoDataFinal_Enabled = 0;
         edtArquivoId_Enabled = 0;
         edtAssinaturaFinalizadoData_Enabled = 0;
         edtAssinaturaParticipantes_F_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5F0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E255F2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV35ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV49DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_116 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_116"), ",", "."), 18, MidpointRounding.ToEven));
            AV51GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV52GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV53GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV59DDO_ContratoDataInicialAuxDate = context.localUtil.CToD( cgiGet( "vDDO_CONTRATODATAINICIALAUXDATE"), 0);
            AV60DDO_ContratoDataInicialAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_CONTRATODATAINICIALAUXDATETO"), 0);
            AV64DDO_ContratoDataFinalAuxDate = context.localUtil.CToD( cgiGet( "vDDO_CONTRATODATAFINALAUXDATE"), 0);
            AV65DDO_ContratoDataFinalAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_CONTRATODATAFINALAUXDATETO"), 0);
            AV44DDO_AssinaturaFinalizadoDataAuxDate = context.localUtil.CToD( cgiGet( "vDDO_ASSINATURAFINALIZADODATAAUXDATE"), 0);
            AssignAttri("", false, "AV44DDO_AssinaturaFinalizadoDataAuxDate", context.localUtil.Format(AV44DDO_AssinaturaFinalizadoDataAuxDate, "99/99/99"));
            AV45DDO_AssinaturaFinalizadoDataAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_ASSINATURAFINALIZADODATAAUXDATETO"), 0);
            AssignAttri("", false, "AV45DDO_AssinaturaFinalizadoDataAuxDateTo", context.localUtil.Format(AV45DDO_AssinaturaFinalizadoDataAuxDateTo, "99/99/99"));
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
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV15FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            cmbavDynamicfiltersselector1.Name = cmbavDynamicfiltersselector1_Internalname;
            cmbavDynamicfiltersselector1.CurrentValue = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AV16DynamicFiltersSelector1 = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
            cmbavDynamicfiltersoperator1.Name = cmbavDynamicfiltersoperator1_Internalname;
            cmbavDynamicfiltersoperator1.CurrentValue = cgiGet( cmbavDynamicfiltersoperator1_Internalname);
            AV17DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator1_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
            cmbavAssinaturastatus1.Name = cmbavAssinaturastatus1_Internalname;
            cmbavAssinaturastatus1.CurrentValue = cgiGet( cmbavAssinaturastatus1_Internalname);
            AV18AssinaturaStatus1 = cgiGet( cmbavAssinaturastatus1_Internalname);
            AssignAttri("", false, "AV18AssinaturaStatus1", AV18AssinaturaStatus1);
            AV19ContratoNome1 = cgiGet( edtavContratonome1_Internalname);
            AssignAttri("", false, "AV19ContratoNome1", AV19ContratoNome1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV21DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV22DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
            cmbavAssinaturastatus2.Name = cmbavAssinaturastatus2_Internalname;
            cmbavAssinaturastatus2.CurrentValue = cgiGet( cmbavAssinaturastatus2_Internalname);
            AV23AssinaturaStatus2 = cgiGet( cmbavAssinaturastatus2_Internalname);
            AssignAttri("", false, "AV23AssinaturaStatus2", AV23AssinaturaStatus2);
            AV24ContratoNome2 = cgiGet( edtavContratonome2_Internalname);
            AssignAttri("", false, "AV24ContratoNome2", AV24ContratoNome2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV26DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
            cmbavAssinaturastatus3.Name = cmbavAssinaturastatus3_Internalname;
            cmbavAssinaturastatus3.CurrentValue = cgiGet( cmbavAssinaturastatus3_Internalname);
            AV28AssinaturaStatus3 = cgiGet( cmbavAssinaturastatus3_Internalname);
            AssignAttri("", false, "AV28AssinaturaStatus3", AV28AssinaturaStatus3);
            AV29ContratoNome3 = cgiGet( edtavContratonome3_Internalname);
            AssignAttri("", false, "AV29ContratoNome3", AV29ContratoNome3);
            AV61DDO_ContratoDataInicialAuxDateText = cgiGet( edtavDdo_contratodatainicialauxdatetext_Internalname);
            AssignAttri("", false, "AV61DDO_ContratoDataInicialAuxDateText", AV61DDO_ContratoDataInicialAuxDateText);
            AV66DDO_ContratoDataFinalAuxDateText = cgiGet( edtavDdo_contratodatafinalauxdatetext_Internalname);
            AssignAttri("", false, "AV66DDO_ContratoDataFinalAuxDateText", AV66DDO_ContratoDataFinalAuxDateText);
            AV46DDO_AssinaturaFinalizadoDataAuxDateText = cgiGet( edtavDdo_assinaturafinalizadodataauxdatetext_Internalname);
            AssignAttri("", false, "AV46DDO_AssinaturaFinalizadoDataAuxDateText", AV46DDO_AssinaturaFinalizadoDataAuxDateText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV13OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV14OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV16DynamicFiltersSelector1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV17DynamicFiltersOperator1 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vASSINATURASTATUS1"), AV18AssinaturaStatus1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATONOME1"), AV19ContratoNome1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV21DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV22DynamicFiltersOperator2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vASSINATURASTATUS2"), AV23AssinaturaStatus2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATONOME2"), AV24ContratoNome2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV26DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV27DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vASSINATURASTATUS3"), AV28AssinaturaStatus3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCONTRATONOME3"), AV29ContratoNome3) != 0 )
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
         E255F2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E255F2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV70VigenciaData = DateTimeUtil.AddMth( Gx_date, 30);
         this.executeUsercontrolMethod("", false, "TFASSINATURAFINALIZADODATA_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_assinaturafinalizadodataauxdatetext_Internalname});
         this.executeUsercontrolMethod("", false, "TFCONTRATODATAFINAL_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_contratodatafinalauxdatetext_Internalname});
         this.executeUsercontrolMethod("", false, "TFCONTRATODATAINICIAL_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_contratodatainicialauxdatetext_Internalname});
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
         AV18AssinaturaStatus1 = "";
         AssignAttri("", false, "AV18AssinaturaStatus1", AV18AssinaturaStatus1);
         AV16DynamicFiltersSelector1 = "ASSINATURASTATUS";
         AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV23AssinaturaStatus2 = "";
         AssignAttri("", false, "AV23AssinaturaStatus2", AV23AssinaturaStatus2);
         AV21DynamicFiltersSelector2 = "ASSINATURASTATUS";
         AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV28AssinaturaStatus3 = "";
         AssignAttri("", false, "AV28AssinaturaStatus3", AV28AssinaturaStatus3);
         AV26DynamicFiltersSelector3 = "ASSINATURASTATUS";
         AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
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
         Form.Caption = " Assinatura";
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
         if ( AV13OrderedBy < 1 )
         {
            AV13OrderedBy = 1;
            AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV49DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV49DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E265F2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         if ( AV37ManageFiltersExecutionStep == 1 )
         {
            AV37ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV37ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV37ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV37ManageFiltersExecutionStep == 2 )
         {
            AV37ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV37ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV37ManageFiltersExecutionStep), 1, 0));
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
         AV51GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV51GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV51GridCurrentPage), 10, 0));
         AV52GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV52GridPageCount", StringUtil.LTrimStr( (decimal)(AV52GridPageCount), 10, 0));
         GXt_char2 = AV53GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV73Pgmname, out  GXt_char2) ;
         AV53GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV53GridAppliedFilters", AV53GridAppliedFilters);
         AV74Assinaturawwds_1_filterfulltext = AV15FilterFullText;
         AV75Assinaturawwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV76Assinaturawwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV77Assinaturawwds_4_assinaturastatus1 = AV18AssinaturaStatus1;
         AV78Assinaturawwds_5_contratonome1 = AV19ContratoNome1;
         AV79Assinaturawwds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV80Assinaturawwds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV81Assinaturawwds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV82Assinaturawwds_9_assinaturastatus2 = AV23AssinaturaStatus2;
         AV83Assinaturawwds_10_contratonome2 = AV24ContratoNome2;
         AV84Assinaturawwds_11_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV85Assinaturawwds_12_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV86Assinaturawwds_13_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV87Assinaturawwds_14_assinaturastatus3 = AV28AssinaturaStatus3;
         AV88Assinaturawwds_15_contratonome3 = AV29ContratoNome3;
         AV89Assinaturawwds_16_tfcontratonome = AV38TFContratoNome;
         AV90Assinaturawwds_17_tfcontratonome_sel = AV39TFContratoNome_Sel;
         AV91Assinaturawwds_18_tfassinaturastatus_sels = AV41TFAssinaturaStatus_Sels;
         AV92Assinaturawwds_19_tfcontratodatainicial = AV57TFContratoDataInicial;
         AV93Assinaturawwds_20_tfcontratodatainicial_to = AV58TFContratoDataInicial_To;
         AV94Assinaturawwds_21_tfcontratodatafinal = AV62TFContratoDataFinal;
         AV95Assinaturawwds_22_tfcontratodatafinal_to = AV63TFContratoDataFinal_To;
         AV96Assinaturawwds_23_tfassinaturafinalizadodata = AV42TFAssinaturaFinalizadoData;
         AV97Assinaturawwds_24_tfassinaturafinalizadodata_to = AV43TFAssinaturaFinalizadoData_To;
         AV98Assinaturawwds_25_tfassinaturaparticipantes_f = AV47TFAssinaturaParticipantes_F;
         AV99Assinaturawwds_26_tfassinaturaparticipantes_f_to = AV48TFAssinaturaParticipantes_F_To;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ManageFiltersData", AV35ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E125F2( )
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
            AV50PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV50PageToGo) ;
         }
      }

      protected void E135F2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E145F2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV13OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            AV14OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
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
               AV38TFContratoNome = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV38TFContratoNome", AV38TFContratoNome);
               AV39TFContratoNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV39TFContratoNome_Sel", AV39TFContratoNome_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "AssinaturaStatus") == 0 )
            {
               AV40TFAssinaturaStatus_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV40TFAssinaturaStatus_SelsJson", AV40TFAssinaturaStatus_SelsJson);
               AV41TFAssinaturaStatus_Sels.FromJSonString(AV40TFAssinaturaStatus_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ContratoDataInicial") == 0 )
            {
               AV57TFContratoDataInicial = context.localUtil.CToD( Ddo_grid_Filteredtext_get, 4);
               AssignAttri("", false, "AV57TFContratoDataInicial", context.localUtil.Format(AV57TFContratoDataInicial, "99/99/99"));
               AV58TFContratoDataInicial_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri("", false, "AV58TFContratoDataInicial_To", context.localUtil.Format(AV58TFContratoDataInicial_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ContratoDataFinal") == 0 )
            {
               AV62TFContratoDataFinal = context.localUtil.CToD( Ddo_grid_Filteredtext_get, 4);
               AssignAttri("", false, "AV62TFContratoDataFinal", context.localUtil.Format(AV62TFContratoDataFinal, "99/99/99"));
               AV63TFContratoDataFinal_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri("", false, "AV63TFContratoDataFinal_To", context.localUtil.Format(AV63TFContratoDataFinal_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "AssinaturaFinalizadoData") == 0 )
            {
               AV42TFAssinaturaFinalizadoData = context.localUtil.CToT( Ddo_grid_Filteredtext_get, 4);
               AssignAttri("", false, "AV42TFAssinaturaFinalizadoData", context.localUtil.TToC( AV42TFAssinaturaFinalizadoData, 8, 5, 0, 3, "/", ":", " "));
               AV43TFAssinaturaFinalizadoData_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri("", false, "AV43TFAssinaturaFinalizadoData_To", context.localUtil.TToC( AV43TFAssinaturaFinalizadoData_To, 8, 5, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV43TFAssinaturaFinalizadoData_To) )
               {
                  AV43TFAssinaturaFinalizadoData_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV43TFAssinaturaFinalizadoData_To)), (short)(DateTimeUtil.Month( AV43TFAssinaturaFinalizadoData_To)), (short)(DateTimeUtil.Day( AV43TFAssinaturaFinalizadoData_To)), 23, 59, 59);
                  AssignAttri("", false, "AV43TFAssinaturaFinalizadoData_To", context.localUtil.TToC( AV43TFAssinaturaFinalizadoData_To, 8, 5, 0, 3, "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "AssinaturaParticipantes_F") == 0 )
            {
               AV47TFAssinaturaParticipantes_F = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV47TFAssinaturaParticipantes_F", StringUtil.LTrimStr( (decimal)(AV47TFAssinaturaParticipantes_F), 4, 0));
               AV48TFAssinaturaParticipantes_F_To = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV48TFAssinaturaParticipantes_F_To", StringUtil.LTrimStr( (decimal)(AV48TFAssinaturaParticipantes_F_To), 4, 0));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41TFAssinaturaStatus_Sels", AV41TFAssinaturaStatus_Sels);
      }

      private void E275F2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV67Consultar = "<i class=\"fas fa-search\"></i>";
         AssignAttri("", false, edtavConsultar_Internalname, AV67Consultar);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpassinaturas"+UrlEncode(StringUtil.LTrimStr(A238AssinaturaId,10,0));
         edtavConsultar_Link = formatLink("wpassinaturas") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
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

      protected void E205F2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV20DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E155F2( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV30DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         AV31DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV31DynamicFiltersIgnoreFirst", AV31DynamicFiltersIgnoreFirst);
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
         AV30DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         AV31DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV31DynamicFiltersIgnoreFirst", AV31DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18AssinaturaStatus1, AV19ContratoNome1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23AssinaturaStatus2, AV24ContratoNome2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28AssinaturaStatus3, AV29ContratoNome3, AV68AssinaturaStatus, AV37ManageFiltersExecutionStep, AV73Pgmname, AV15FilterFullText, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV38TFContratoNome, AV39TFContratoNome_Sel, AV41TFAssinaturaStatus_Sels, AV57TFContratoDataInicial, AV58TFContratoDataInicial_To, AV62TFContratoDataFinal, AV63TFContratoDataFinal_To, AV42TFAssinaturaFinalizadoData, AV43TFAssinaturaFinalizadoData_To, AV47TFAssinaturaParticipantes_F, AV48TFAssinaturaParticipantes_F_To, AV69Vigente, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, AV100Clienteid) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavAssinaturastatus2.CurrentValue = StringUtil.RTrim( AV23AssinaturaStatus2);
         AssignProp("", false, cmbavAssinaturastatus2_Internalname, "Values", cmbavAssinaturastatus2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavAssinaturastatus3.CurrentValue = StringUtil.RTrim( AV28AssinaturaStatus3);
         AssignProp("", false, cmbavAssinaturastatus3_Internalname, "Values", cmbavAssinaturastatus3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavAssinaturastatus1.CurrentValue = StringUtil.RTrim( AV18AssinaturaStatus1);
         AssignProp("", false, cmbavAssinaturastatus1_Internalname, "Values", cmbavAssinaturastatus1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ManageFiltersData", AV35ManageFiltersData);
      }

      protected void E215F2( )
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

      protected void E225F2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV25DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E165F2( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV30DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         AV20DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
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
         AV30DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18AssinaturaStatus1, AV19ContratoNome1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23AssinaturaStatus2, AV24ContratoNome2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28AssinaturaStatus3, AV29ContratoNome3, AV68AssinaturaStatus, AV37ManageFiltersExecutionStep, AV73Pgmname, AV15FilterFullText, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV38TFContratoNome, AV39TFContratoNome_Sel, AV41TFAssinaturaStatus_Sels, AV57TFContratoDataInicial, AV58TFContratoDataInicial_To, AV62TFContratoDataFinal, AV63TFContratoDataFinal_To, AV42TFAssinaturaFinalizadoData, AV43TFAssinaturaFinalizadoData_To, AV47TFAssinaturaParticipantes_F, AV48TFAssinaturaParticipantes_F_To, AV69Vigente, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, AV100Clienteid) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavAssinaturastatus2.CurrentValue = StringUtil.RTrim( AV23AssinaturaStatus2);
         AssignProp("", false, cmbavAssinaturastatus2_Internalname, "Values", cmbavAssinaturastatus2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavAssinaturastatus3.CurrentValue = StringUtil.RTrim( AV28AssinaturaStatus3);
         AssignProp("", false, cmbavAssinaturastatus3_Internalname, "Values", cmbavAssinaturastatus3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavAssinaturastatus1.CurrentValue = StringUtil.RTrim( AV18AssinaturaStatus1);
         AssignProp("", false, cmbavAssinaturastatus1_Internalname, "Values", cmbavAssinaturastatus1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ManageFiltersData", AV35ManageFiltersData);
      }

      protected void E235F2( )
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

      protected void E175F2( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV30DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         AV25DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
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
         AV30DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18AssinaturaStatus1, AV19ContratoNome1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23AssinaturaStatus2, AV24ContratoNome2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28AssinaturaStatus3, AV29ContratoNome3, AV68AssinaturaStatus, AV37ManageFiltersExecutionStep, AV73Pgmname, AV15FilterFullText, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV38TFContratoNome, AV39TFContratoNome_Sel, AV41TFAssinaturaStatus_Sels, AV57TFContratoDataInicial, AV58TFContratoDataInicial_To, AV62TFContratoDataFinal, AV63TFContratoDataFinal_To, AV42TFAssinaturaFinalizadoData, AV43TFAssinaturaFinalizadoData_To, AV47TFAssinaturaParticipantes_F, AV48TFAssinaturaParticipantes_F_To, AV69Vigente, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, AV100Clienteid) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavAssinaturastatus2.CurrentValue = StringUtil.RTrim( AV23AssinaturaStatus2);
         AssignProp("", false, cmbavAssinaturastatus2_Internalname, "Values", cmbavAssinaturastatus2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavAssinaturastatus3.CurrentValue = StringUtil.RTrim( AV28AssinaturaStatus3);
         AssignProp("", false, cmbavAssinaturastatus3_Internalname, "Values", cmbavAssinaturastatus3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavAssinaturastatus1.CurrentValue = StringUtil.RTrim( AV18AssinaturaStatus1);
         AssignProp("", false, cmbavAssinaturastatus1_Internalname, "Values", cmbavAssinaturastatus1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ManageFiltersData", AV35ManageFiltersData);
      }

      protected void E245F2( )
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

      protected void E115F2( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("AssinaturaWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV73Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV37ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV37ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV37ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("AssinaturaWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV37ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV37ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV37ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV36ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "AssinaturaWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV36ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV36ManageFiltersXml)) )
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV73Pgmname+"GridState",  AV36ManageFiltersXml) ;
               AV10GridState.FromXml(AV36ManageFiltersXml, null, "", "");
               AV13OrderedBy = AV10GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
               AV14OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41TFAssinaturaStatus_Sels", AV41TFAssinaturaStatus_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavAssinaturastatus1.CurrentValue = StringUtil.RTrim( AV18AssinaturaStatus1);
         AssignProp("", false, cmbavAssinaturastatus1_Internalname, "Values", cmbavAssinaturastatus1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavAssinaturastatus2.CurrentValue = StringUtil.RTrim( AV23AssinaturaStatus2);
         AssignProp("", false, cmbavAssinaturastatus2_Internalname, "Values", cmbavAssinaturastatus2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavAssinaturastatus3.CurrentValue = StringUtil.RTrim( AV28AssinaturaStatus3);
         AssignProp("", false, cmbavAssinaturastatus3_Internalname, "Values", cmbavAssinaturastatus3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ManageFiltersData", AV35ManageFiltersData);
      }

      protected void E185F2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "assinarcontrato"+UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("assinarcontrato") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E195F2( )
      {
         /* 'DoExport' Routine */
         returnInSub = false;
         new assinaturawwexport(context ).execute( out  AV32ExcelFilename, out  AV33ErrorMessage) ;
         if ( StringUtil.StrCmp(AV32ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV32ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV33ErrorMessage);
         }
      }

      protected void S172( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV13OrderedBy), 4, 0))+":"+(AV14OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         cmbavAssinaturastatus1.Visible = 0;
         AssignProp("", false, cmbavAssinaturastatus1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavAssinaturastatus1.Visible), 5, 0), true);
         edtavContratonome1_Visible = 0;
         AssignProp("", false, edtavContratonome1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContratonome1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "ASSINATURASTATUS") == 0 )
         {
            cmbavAssinaturastatus1.Visible = 1;
            AssignProp("", false, cmbavAssinaturastatus1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavAssinaturastatus1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CONTRATONOME") == 0 )
         {
            edtavContratonome1_Visible = 1;
            AssignProp("", false, edtavContratonome1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContratonome1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         cmbavAssinaturastatus2.Visible = 0;
         AssignProp("", false, cmbavAssinaturastatus2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavAssinaturastatus2.Visible), 5, 0), true);
         edtavContratonome2_Visible = 0;
         AssignProp("", false, edtavContratonome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContratonome2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "ASSINATURASTATUS") == 0 )
         {
            cmbavAssinaturastatus2.Visible = 1;
            AssignProp("", false, cmbavAssinaturastatus2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavAssinaturastatus2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "CONTRATONOME") == 0 )
         {
            edtavContratonome2_Visible = 1;
            AssignProp("", false, edtavContratonome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContratonome2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         cmbavAssinaturastatus3.Visible = 0;
         AssignProp("", false, cmbavAssinaturastatus3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavAssinaturastatus3.Visible), 5, 0), true);
         edtavContratonome3_Visible = 0;
         AssignProp("", false, edtavContratonome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContratonome3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "ASSINATURASTATUS") == 0 )
         {
            cmbavAssinaturastatus3.Visible = 1;
            AssignProp("", false, cmbavAssinaturastatus3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavAssinaturastatus3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CONTRATONOME") == 0 )
         {
            edtavContratonome3_Visible = 1;
            AssignProp("", false, edtavContratonome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContratonome3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S202( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV20DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
         AV21DynamicFiltersSelector2 = "ASSINATURASTATUS";
         AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         AV23AssinaturaStatus2 = "";
         AssignAttri("", false, "AV23AssinaturaStatus2", AV23AssinaturaStatus2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV25DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
         AV26DynamicFiltersSelector3 = "ASSINATURASTATUS";
         AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
         AV28AssinaturaStatus3 = "";
         AssignAttri("", false, "AV28AssinaturaStatus3", AV28AssinaturaStatus3);
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
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV35ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "AssinaturaWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV35ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S222( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
         AV38TFContratoNome = "";
         AssignAttri("", false, "AV38TFContratoNome", AV38TFContratoNome);
         AV39TFContratoNome_Sel = "";
         AssignAttri("", false, "AV39TFContratoNome_Sel", AV39TFContratoNome_Sel);
         AV41TFAssinaturaStatus_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV57TFContratoDataInicial = DateTime.MinValue;
         AssignAttri("", false, "AV57TFContratoDataInicial", context.localUtil.Format(AV57TFContratoDataInicial, "99/99/99"));
         AV58TFContratoDataInicial_To = DateTime.MinValue;
         AssignAttri("", false, "AV58TFContratoDataInicial_To", context.localUtil.Format(AV58TFContratoDataInicial_To, "99/99/99"));
         AV62TFContratoDataFinal = DateTime.MinValue;
         AssignAttri("", false, "AV62TFContratoDataFinal", context.localUtil.Format(AV62TFContratoDataFinal, "99/99/99"));
         AV63TFContratoDataFinal_To = DateTime.MinValue;
         AssignAttri("", false, "AV63TFContratoDataFinal_To", context.localUtil.Format(AV63TFContratoDataFinal_To, "99/99/99"));
         AV42TFAssinaturaFinalizadoData = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV42TFAssinaturaFinalizadoData", context.localUtil.TToC( AV42TFAssinaturaFinalizadoData, 8, 5, 0, 3, "/", ":", " "));
         AV43TFAssinaturaFinalizadoData_To = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV43TFAssinaturaFinalizadoData_To", context.localUtil.TToC( AV43TFAssinaturaFinalizadoData_To, 8, 5, 0, 3, "/", ":", " "));
         AV47TFAssinaturaParticipantes_F = 0;
         AssignAttri("", false, "AV47TFAssinaturaParticipantes_F", StringUtil.LTrimStr( (decimal)(AV47TFAssinaturaParticipantes_F), 4, 0));
         AV48TFAssinaturaParticipantes_F_To = 0;
         AssignAttri("", false, "AV48TFAssinaturaParticipantes_F_To", StringUtil.LTrimStr( (decimal)(AV48TFAssinaturaParticipantes_F_To), 4, 0));
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV16DynamicFiltersSelector1 = "ASSINATURASTATUS";
         AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         AV18AssinaturaStatus1 = "";
         AssignAttri("", false, "AV18AssinaturaStatus1", AV18AssinaturaStatus1);
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
         if ( StringUtil.StrCmp(AV34Session.Get(AV73Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV73Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV34Session.Get(AV73Pgmname+"GridState"), null, "", "");
         }
         AV13OrderedBy = AV10GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
         AV14OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
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
         AV101GXV1 = 1;
         while ( AV101GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV101GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCONTRATONOME") == 0 )
            {
               AV38TFContratoNome = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV38TFContratoNome", AV38TFContratoNome);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCONTRATONOME_SEL") == 0 )
            {
               AV39TFContratoNome_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV39TFContratoNome_Sel", AV39TFContratoNome_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFASSINATURASTATUS_SEL") == 0 )
            {
               AV40TFAssinaturaStatus_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV40TFAssinaturaStatus_SelsJson", AV40TFAssinaturaStatus_SelsJson);
               AV41TFAssinaturaStatus_Sels.FromJSonString(AV40TFAssinaturaStatus_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCONTRATODATAINICIAL") == 0 )
            {
               AV57TFContratoDataInicial = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri("", false, "AV57TFContratoDataInicial", context.localUtil.Format(AV57TFContratoDataInicial, "99/99/99"));
               AV58TFContratoDataInicial_To = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri("", false, "AV58TFContratoDataInicial_To", context.localUtil.Format(AV58TFContratoDataInicial_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCONTRATODATAFINAL") == 0 )
            {
               AV62TFContratoDataFinal = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri("", false, "AV62TFContratoDataFinal", context.localUtil.Format(AV62TFContratoDataFinal, "99/99/99"));
               AV63TFContratoDataFinal_To = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri("", false, "AV63TFContratoDataFinal_To", context.localUtil.Format(AV63TFContratoDataFinal_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFASSINATURAFINALIZADODATA") == 0 )
            {
               AV42TFAssinaturaFinalizadoData = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri("", false, "AV42TFAssinaturaFinalizadoData", context.localUtil.TToC( AV42TFAssinaturaFinalizadoData, 8, 5, 0, 3, "/", ":", " "));
               AV43TFAssinaturaFinalizadoData_To = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri("", false, "AV43TFAssinaturaFinalizadoData_To", context.localUtil.TToC( AV43TFAssinaturaFinalizadoData_To, 8, 5, 0, 3, "/", ":", " "));
               AV44DDO_AssinaturaFinalizadoDataAuxDate = DateTimeUtil.ResetTime(AV42TFAssinaturaFinalizadoData);
               AssignAttri("", false, "AV44DDO_AssinaturaFinalizadoDataAuxDate", context.localUtil.Format(AV44DDO_AssinaturaFinalizadoDataAuxDate, "99/99/99"));
               AV45DDO_AssinaturaFinalizadoDataAuxDateTo = DateTimeUtil.ResetTime(AV43TFAssinaturaFinalizadoData_To);
               AssignAttri("", false, "AV45DDO_AssinaturaFinalizadoDataAuxDateTo", context.localUtil.Format(AV45DDO_AssinaturaFinalizadoDataAuxDateTo, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFASSINATURAPARTICIPANTES_F") == 0 )
            {
               AV47TFAssinaturaParticipantes_F = (short)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV47TFAssinaturaParticipantes_F", StringUtil.LTrimStr( (decimal)(AV47TFAssinaturaParticipantes_F), 4, 0));
               AV48TFAssinaturaParticipantes_F_To = (short)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV48TFAssinaturaParticipantes_F_To", StringUtil.LTrimStr( (decimal)(AV48TFAssinaturaParticipantes_F_To), 4, 0));
            }
            AV101GXV1 = (int)(AV101GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV39TFContratoNome_Sel)),  AV39TFContratoNome_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV41TFAssinaturaStatus_Sels.Count==0),  AV40TFAssinaturaStatus_SelsJson, out  GXt_char4) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char4+"||||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV38TFContratoNome)),  AV38TFContratoNome, out  GXt_char4) ;
         Ddo_grid_Filteredtext_set = GXt_char4+"||"+((DateTime.MinValue==AV57TFContratoDataInicial) ? "" : context.localUtil.DToC( AV57TFContratoDataInicial, 4, "/"))+"|"+((DateTime.MinValue==AV62TFContratoDataFinal) ? "" : context.localUtil.DToC( AV62TFContratoDataFinal, 4, "/"))+"|"+((DateTime.MinValue==AV42TFAssinaturaFinalizadoData) ? "" : context.localUtil.DToC( AV44DDO_AssinaturaFinalizadoDataAuxDate, 4, "/"))+"|"+((0==AV47TFAssinaturaParticipantes_F) ? "" : StringUtil.Str( (decimal)(AV47TFAssinaturaParticipantes_F), 4, 0));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "||"+((DateTime.MinValue==AV58TFContratoDataInicial_To) ? "" : context.localUtil.DToC( AV58TFContratoDataInicial_To, 4, "/"))+"|"+((DateTime.MinValue==AV63TFContratoDataFinal_To) ? "" : context.localUtil.DToC( AV63TFContratoDataFinal_To, 4, "/"))+"|"+((DateTime.MinValue==AV43TFAssinaturaFinalizadoData_To) ? "" : context.localUtil.DToC( AV45DDO_AssinaturaFinalizadoDataAuxDateTo, 4, "/"))+"|"+((0==AV48TFAssinaturaParticipantes_F_To) ? "" : StringUtil.Str( (decimal)(AV48TFAssinaturaParticipantes_F_To), 4, 0));
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
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         imgAdddynamicfilters2_Visible = 1;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 0;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( AV10GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(1));
            AV16DynamicFiltersSelector1 = AV12GridStateDynamicFilter.gxTpr_Selected;
            AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
            if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "ASSINATURASTATUS") == 0 )
            {
               AV18AssinaturaStatus1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV18AssinaturaStatus1", AV18AssinaturaStatus1);
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CONTRATONOME") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV19ContratoNome1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV19ContratoNome1", AV19ContratoNome1);
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
               AV20DynamicFiltersEnabled2 = true;
               AssignAttri("", false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
               AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(2));
               AV21DynamicFiltersSelector2 = AV12GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "ASSINATURASTATUS") == 0 )
               {
                  AV23AssinaturaStatus2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV23AssinaturaStatus2", AV23AssinaturaStatus2);
               }
               else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "CONTRATONOME") == 0 )
               {
                  AV22DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
                  AV24ContratoNome2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV24ContratoNome2", AV24ContratoNome2);
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
                  AV25DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
                  AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV12GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "ASSINATURASTATUS") == 0 )
                  {
                     AV28AssinaturaStatus3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV28AssinaturaStatus3", AV28AssinaturaStatus3);
                  }
                  else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CONTRATONOME") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
                     AV29ContratoNome3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV29ContratoNome3", AV29ContratoNome3);
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
         if ( AV30DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S182( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV34Session.Get(AV73Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCONTRATONOME",  "Contrato",  !String.IsNullOrEmpty(StringUtil.RTrim( AV38TFContratoNome)),  0,  AV38TFContratoNome,  AV38TFContratoNome,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV39TFContratoNome_Sel)),  AV39TFContratoNome_Sel,  AV39TFContratoNome_Sel) ;
         AV56AuxText = ((AV41TFAssinaturaStatus_Sels.Count==1) ? "["+((string)AV41TFAssinaturaStatus_Sels.Item(1))+"]" : "Vários valores");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFASSINATURASTATUS_SEL",  "Situação",  !(AV41TFAssinaturaStatus_Sels.Count==0),  0,  AV41TFAssinaturaStatus_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV56AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( AV56AuxText, "[ENVIADO]", "Enviado"), "[REJEITADO]", "Rejeitado"), "[CANCELADO]", "Cancelado"), "[ASSINADO]", "Assinado"), "[AGUARDANDO_ENVIO]", "Aguardando envio")),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCONTRATODATAINICIAL",  "Vigência inicial",  !((DateTime.MinValue==AV57TFContratoDataInicial)&&(DateTime.MinValue==AV58TFContratoDataInicial_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV57TFContratoDataInicial, 4, "/")),  ((DateTime.MinValue==AV57TFContratoDataInicial) ? "" : StringUtil.Trim( context.localUtil.Format( AV57TFContratoDataInicial, "99/99/99"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV58TFContratoDataInicial_To, 4, "/")),  ((DateTime.MinValue==AV58TFContratoDataInicial_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV58TFContratoDataInicial_To, "99/99/99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCONTRATODATAFINAL",  "Final",  !((DateTime.MinValue==AV62TFContratoDataFinal)&&(DateTime.MinValue==AV63TFContratoDataFinal_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV62TFContratoDataFinal, 4, "/")),  ((DateTime.MinValue==AV62TFContratoDataFinal) ? "" : StringUtil.Trim( context.localUtil.Format( AV62TFContratoDataFinal, "99/99/99"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV63TFContratoDataFinal_To, 4, "/")),  ((DateTime.MinValue==AV63TFContratoDataFinal_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV63TFContratoDataFinal_To, "99/99/99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFASSINATURAFINALIZADODATA",  "Assinatura finalizada",  !((DateTime.MinValue==AV42TFAssinaturaFinalizadoData)&&(DateTime.MinValue==AV43TFAssinaturaFinalizadoData_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV42TFAssinaturaFinalizadoData, 8, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV42TFAssinaturaFinalizadoData) ? "" : StringUtil.Trim( context.localUtil.Format( AV42TFAssinaturaFinalizadoData, "99/99/99 99:99"))),  true,  StringUtil.Trim( context.localUtil.TToC( AV43TFAssinaturaFinalizadoData_To, 8, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV43TFAssinaturaFinalizadoData_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV43TFAssinaturaFinalizadoData_To, "99/99/99 99:99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFASSINATURAPARTICIPANTES_F",  "Participantes",  !((0==AV47TFAssinaturaParticipantes_F)&&(0==AV48TFAssinaturaParticipantes_F_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV47TFAssinaturaParticipantes_F), 4, 0)),  ((0==AV47TFAssinaturaParticipantes_F) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV47TFAssinaturaParticipantes_F), "ZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV48TFAssinaturaParticipantes_F_To), 4, 0)),  ((0==AV48TFAssinaturaParticipantes_F_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV48TFAssinaturaParticipantes_F_To), "ZZZ9")))) ;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68AssinaturaStatus)) )
         {
            AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV11GridStateFilterValue.gxTpr_Name = "PARM_&ASSINATURASTATUS";
            AV11GridStateFilterValue.gxTpr_Value = AV68AssinaturaStatus;
            AV10GridState.gxTpr_Filtervalues.Add(AV11GridStateFilterValue, 0);
         }
         if ( ! (false==AV69Vigente) )
         {
            AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV11GridStateFilterValue.gxTpr_Name = "PARM_&VIGENTE";
            AV11GridStateFilterValue.gxTpr_Value = StringUtil.BoolToStr( AV69Vigente);
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
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV73Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S192( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV10GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV31DynamicFiltersIgnoreFirst )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV16DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "ASSINATURASTATUS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV18AssinaturaStatus1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Status",  0,  AV18AssinaturaStatus1,  StringUtil.Trim( gxdomaindmassinaturastatus.getDescription(context,AV18AssinaturaStatus1)),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CONTRATONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV19ContratoNome1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Contrato",  AV17DynamicFiltersOperator1,  AV19ContratoNome1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV19ContratoNome1, "Contém"+" "+AV19ContratoNome1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV30DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV20DynamicFiltersEnabled2 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV21DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "ASSINATURASTATUS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV23AssinaturaStatus2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Status",  0,  AV23AssinaturaStatus2,  StringUtil.Trim( gxdomaindmassinaturastatus.getDescription(context,AV23AssinaturaStatus2)),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "CONTRATONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV24ContratoNome2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Contrato",  AV22DynamicFiltersOperator2,  AV24ContratoNome2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV24ContratoNome2, "Contém"+" "+AV24ContratoNome2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV30DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV25DynamicFiltersEnabled3 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV26DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "ASSINATURASTATUS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV28AssinaturaStatus3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Status",  0,  AV28AssinaturaStatus3,  StringUtil.Trim( gxdomaindmassinaturastatus.getDescription(context,AV28AssinaturaStatus3)),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CONTRATONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV29ContratoNome3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Contrato",  AV27DynamicFiltersOperator3,  AV29ContratoNome3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV29ContratoNome3, "Contém"+" "+AV29ContratoNome3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV30DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
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
         AV8TrnContext.gxTpr_Callerobject = AV73Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Assinatura";
         AV34Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table3_95_5F2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "", true, 0, "HLP_AssinaturaWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_assinaturastatus3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavAssinaturastatus3_Internalname, "Assinatura Status3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'" + sGXsfl_116_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavAssinaturastatus3, cmbavAssinaturastatus3_Internalname, StringUtil.RTrim( AV28AssinaturaStatus3), 1, cmbavAssinaturastatus3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", cmbavAssinaturastatus3.Visible, cmbavAssinaturastatus3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,102);\"", "", true, 0, "HLP_AssinaturaWW.htm");
            cmbavAssinaturastatus3.CurrentValue = StringUtil.RTrim( AV28AssinaturaStatus3);
            AssignProp("", false, cmbavAssinaturastatus3_Internalname, "Values", (string)(cmbavAssinaturastatus3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_contratonome3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContratonome3_Internalname, "Contrato Nome3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'" + sGXsfl_116_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContratonome3_Internalname, AV29ContratoNome3, StringUtil.RTrim( context.localUtil.Format( AV29ContratoNome3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,105);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContratonome3_Jsonclick, 0, "Attribute", "", "", "", "", edtavContratonome3_Visible, edtavContratonome3_Enabled, 0, "text", "", 80, "chr", 1, "row", 125, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_AssinaturaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_AssinaturaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_95_5F2e( true) ;
         }
         else
         {
            wb_table3_95_5F2e( false) ;
         }
      }

      protected void wb_table2_70_5F2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "", true, 0, "HLP_AssinaturaWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_assinaturastatus2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavAssinaturastatus2_Internalname, "Assinatura Status2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'" + sGXsfl_116_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavAssinaturastatus2, cmbavAssinaturastatus2_Internalname, StringUtil.RTrim( AV23AssinaturaStatus2), 1, cmbavAssinaturastatus2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", cmbavAssinaturastatus2.Visible, cmbavAssinaturastatus2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"", "", true, 0, "HLP_AssinaturaWW.htm");
            cmbavAssinaturastatus2.CurrentValue = StringUtil.RTrim( AV23AssinaturaStatus2);
            AssignProp("", false, cmbavAssinaturastatus2_Internalname, "Values", (string)(cmbavAssinaturastatus2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_contratonome2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContratonome2_Internalname, "Contrato Nome2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'" + sGXsfl_116_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContratonome2_Internalname, AV24ContratoNome2, StringUtil.RTrim( context.localUtil.Format( AV24ContratoNome2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,80);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContratonome2_Jsonclick, 0, "Attribute", "", "", "", "", edtavContratonome2_Visible, edtavContratonome2_Enabled, 0, "text", "", 80, "chr", 1, "row", 125, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_AssinaturaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_AssinaturaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_AssinaturaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_70_5F2e( true) ;
         }
         else
         {
            wb_table2_70_5F2e( false) ;
         }
      }

      protected void wb_table1_45_5F2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 0, "HLP_AssinaturaWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_assinaturastatus1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavAssinaturastatus1_Internalname, "Assinatura Status1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'" + sGXsfl_116_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavAssinaturastatus1, cmbavAssinaturastatus1_Internalname, StringUtil.RTrim( AV18AssinaturaStatus1), 1, cmbavAssinaturastatus1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", cmbavAssinaturastatus1.Visible, cmbavAssinaturastatus1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "", true, 0, "HLP_AssinaturaWW.htm");
            cmbavAssinaturastatus1.CurrentValue = StringUtil.RTrim( AV18AssinaturaStatus1);
            AssignProp("", false, cmbavAssinaturastatus1_Internalname, "Values", (string)(cmbavAssinaturastatus1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_contratonome1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContratonome1_Internalname, "Contrato Nome1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'" + sGXsfl_116_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContratonome1_Internalname, AV19ContratoNome1, StringUtil.RTrim( context.localUtil.Format( AV19ContratoNome1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContratonome1_Jsonclick, 0, "Attribute", "", "", "", "", edtavContratonome1_Visible, edtavContratonome1_Enabled, 0, "text", "", 80, "chr", 1, "row", 125, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_AssinaturaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_AssinaturaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_AssinaturaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_45_5F2e( true) ;
         }
         else
         {
            wb_table1_45_5F2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV68AssinaturaStatus = (string)getParm(obj,0);
         AssignAttri("", false, "AV68AssinaturaStatus", AV68AssinaturaStatus);
         GxWebStd.gx_hidden_field( context, "gxhash_vASSINATURASTATUS", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV68AssinaturaStatus, "")), context));
         AV69Vigente = (bool)getParm(obj,1);
         AssignAttri("", false, "AV69Vigente", AV69Vigente);
         GxWebStd.gx_hidden_field( context, "gxhash_vVIGENTE", GetSecureSignedToken( "", AV69Vigente, context));
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
         PA5F2( ) ;
         WS5F2( ) ;
         WE5F2( ) ;
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
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019253230", true, true);
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
         context.AddJavascriptSource("assinaturaww.js", "?202561019253230", false, true);
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
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1162( )
      {
         edtavConsultar_Internalname = "vCONSULTAR_"+sGXsfl_116_idx;
         edtAssinaturaId_Internalname = "ASSINATURAID_"+sGXsfl_116_idx;
         edtContratoId_Internalname = "CONTRATOID_"+sGXsfl_116_idx;
         edtContratoNome_Internalname = "CONTRATONOME_"+sGXsfl_116_idx;
         cmbAssinaturaStatus_Internalname = "ASSINATURASTATUS_"+sGXsfl_116_idx;
         edtContratoDataInicial_Internalname = "CONTRATODATAINICIAL_"+sGXsfl_116_idx;
         edtContratoDataFinal_Internalname = "CONTRATODATAFINAL_"+sGXsfl_116_idx;
         edtArquivoId_Internalname = "ARQUIVOID_"+sGXsfl_116_idx;
         edtAssinaturaFinalizadoData_Internalname = "ASSINATURAFINALIZADODATA_"+sGXsfl_116_idx;
         edtAssinaturaParticipantes_F_Internalname = "ASSINATURAPARTICIPANTES_F_"+sGXsfl_116_idx;
      }

      protected void SubsflControlProps_fel_1162( )
      {
         edtavConsultar_Internalname = "vCONSULTAR_"+sGXsfl_116_fel_idx;
         edtAssinaturaId_Internalname = "ASSINATURAID_"+sGXsfl_116_fel_idx;
         edtContratoId_Internalname = "CONTRATOID_"+sGXsfl_116_fel_idx;
         edtContratoNome_Internalname = "CONTRATONOME_"+sGXsfl_116_fel_idx;
         cmbAssinaturaStatus_Internalname = "ASSINATURASTATUS_"+sGXsfl_116_fel_idx;
         edtContratoDataInicial_Internalname = "CONTRATODATAINICIAL_"+sGXsfl_116_fel_idx;
         edtContratoDataFinal_Internalname = "CONTRATODATAFINAL_"+sGXsfl_116_fel_idx;
         edtArquivoId_Internalname = "ARQUIVOID_"+sGXsfl_116_fel_idx;
         edtAssinaturaFinalizadoData_Internalname = "ASSINATURAFINALIZADODATA_"+sGXsfl_116_fel_idx;
         edtAssinaturaParticipantes_F_Internalname = "ASSINATURAPARTICIPANTES_F_"+sGXsfl_116_fel_idx;
      }

      protected void sendrow_1162( )
      {
         sGXsfl_116_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_116_idx), 4, 0), 4, "0");
         SubsflControlProps_1162( ) ;
         WB5F0( ) ;
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 117,'',false,'" + sGXsfl_116_idx + "',116)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavConsultar_Internalname,StringUtil.RTrim( AV67Consultar),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,117);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavConsultar_Link,(string)"",(string)"",(string)"",(string)edtavConsultar_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavConsultar_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)116,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAssinaturaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A238AssinaturaId), 10, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A238AssinaturaId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAssinaturaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)116,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
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
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtContratoNome_Internalname,(string)A228ContratoNome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtContratoNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)125,(short)0,(short)0,(short)116,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbAssinaturaStatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "ASSINATURASTATUS_" + sGXsfl_116_idx;
               cmbAssinaturaStatus.Name = GXCCtl;
               cmbAssinaturaStatus.WebTags = "";
               cmbAssinaturaStatus.addItem("ENVIADO", "Enviado", 0);
               cmbAssinaturaStatus.addItem("REJEITADO", "Rejeitado", 0);
               cmbAssinaturaStatus.addItem("CANCELADO", "Cancelado", 0);
               cmbAssinaturaStatus.addItem("ASSINADO", "Assinado", 0);
               cmbAssinaturaStatus.addItem("AGUARDANDO_ENVIO", "Aguardando envio", 0);
               if ( cmbAssinaturaStatus.ItemCount > 0 )
               {
                  A239AssinaturaStatus = cmbAssinaturaStatus.getValidValue(A239AssinaturaStatus);
                  n239AssinaturaStatus = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbAssinaturaStatus,(string)cmbAssinaturaStatus_Internalname,StringUtil.RTrim( A239AssinaturaStatus),(short)1,(string)cmbAssinaturaStatus_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbAssinaturaStatus.CurrentValue = StringUtil.RTrim( A239AssinaturaStatus);
            AssignProp("", false, cmbAssinaturaStatus_Internalname, "Values", (string)(cmbAssinaturaStatus.ToJavascriptSource()), !bGXsfl_116_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtContratoDataInicial_Internalname,context.localUtil.Format(A362ContratoDataInicial, "99/99/99"),context.localUtil.Format( A362ContratoDataInicial, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtContratoDataInicial_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)116,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtContratoDataFinal_Internalname,context.localUtil.Format(A363ContratoDataFinal, "99/99/99"),context.localUtil.Format( A363ContratoDataFinal, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtContratoDataFinal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)116,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtArquivoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A231ArquivoId), 8, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A231ArquivoId), "ZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtArquivoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)116,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAssinaturaFinalizadoData_Internalname,context.localUtil.TToC( A366AssinaturaFinalizadoData, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A366AssinaturaFinalizadoData, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAssinaturaFinalizadoData_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)116,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAssinaturaParticipantes_F_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A367AssinaturaParticipantes_F), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A367AssinaturaParticipantes_F), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAssinaturaParticipantes_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)116,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes5F2( ) ;
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
         cmbavDynamicfiltersselector1.addItem("ASSINATURASTATUS", "Status", 0);
         cmbavDynamicfiltersselector1.addItem("CONTRATONOME", "Contrato", 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV16DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV16DynamicFiltersSelector1);
            AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         }
         cmbavDynamicfiltersoperator1.Name = "vDYNAMICFILTERSOPERATOR1";
         cmbavDynamicfiltersoperator1.WebTags = "";
         cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV17DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         }
         cmbavAssinaturastatus1.Name = "vASSINATURASTATUS1";
         cmbavAssinaturastatus1.WebTags = "";
         cmbavAssinaturastatus1.addItem("", "Todos", 0);
         cmbavAssinaturastatus1.addItem("ENVIADO", "Enviado", 0);
         cmbavAssinaturastatus1.addItem("REJEITADO", "Rejeitado", 0);
         cmbavAssinaturastatus1.addItem("CANCELADO", "Cancelado", 0);
         cmbavAssinaturastatus1.addItem("ASSINADO", "Assinado", 0);
         cmbavAssinaturastatus1.addItem("AGUARDANDO_ENVIO", "Aguardando envio", 0);
         if ( cmbavAssinaturastatus1.ItemCount > 0 )
         {
            AV18AssinaturaStatus1 = cmbavAssinaturastatus1.getValidValue(AV18AssinaturaStatus1);
            AssignAttri("", false, "AV18AssinaturaStatus1", AV18AssinaturaStatus1);
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("ASSINATURASTATUS", "Status", 0);
         cmbavDynamicfiltersselector2.addItem("CONTRATONOME", "Contrato", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV21DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV21DynamicFiltersSelector2);
            AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV22DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         }
         cmbavAssinaturastatus2.Name = "vASSINATURASTATUS2";
         cmbavAssinaturastatus2.WebTags = "";
         cmbavAssinaturastatus2.addItem("", "Todos", 0);
         cmbavAssinaturastatus2.addItem("ENVIADO", "Enviado", 0);
         cmbavAssinaturastatus2.addItem("REJEITADO", "Rejeitado", 0);
         cmbavAssinaturastatus2.addItem("CANCELADO", "Cancelado", 0);
         cmbavAssinaturastatus2.addItem("ASSINADO", "Assinado", 0);
         cmbavAssinaturastatus2.addItem("AGUARDANDO_ENVIO", "Aguardando envio", 0);
         if ( cmbavAssinaturastatus2.ItemCount > 0 )
         {
            AV23AssinaturaStatus2 = cmbavAssinaturastatus2.getValidValue(AV23AssinaturaStatus2);
            AssignAttri("", false, "AV23AssinaturaStatus2", AV23AssinaturaStatus2);
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("ASSINATURASTATUS", "Status", 0);
         cmbavDynamicfiltersselector3.addItem("CONTRATONOME", "Contrato", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV26DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV26DynamicFiltersSelector3);
            AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         }
         cmbavAssinaturastatus3.Name = "vASSINATURASTATUS3";
         cmbavAssinaturastatus3.WebTags = "";
         cmbavAssinaturastatus3.addItem("", "Todos", 0);
         cmbavAssinaturastatus3.addItem("ENVIADO", "Enviado", 0);
         cmbavAssinaturastatus3.addItem("REJEITADO", "Rejeitado", 0);
         cmbavAssinaturastatus3.addItem("CANCELADO", "Cancelado", 0);
         cmbavAssinaturastatus3.addItem("ASSINADO", "Assinado", 0);
         cmbavAssinaturastatus3.addItem("AGUARDANDO_ENVIO", "Aguardando envio", 0);
         if ( cmbavAssinaturastatus3.ItemCount > 0 )
         {
            AV28AssinaturaStatus3 = cmbavAssinaturastatus3.getValidValue(AV28AssinaturaStatus3);
            AssignAttri("", false, "AV28AssinaturaStatus3", AV28AssinaturaStatus3);
         }
         GXCCtl = "ASSINATURASTATUS_" + sGXsfl_116_idx;
         cmbAssinaturaStatus.Name = GXCCtl;
         cmbAssinaturaStatus.WebTags = "";
         cmbAssinaturaStatus.addItem("ENVIADO", "Enviado", 0);
         cmbAssinaturaStatus.addItem("REJEITADO", "Rejeitado", 0);
         cmbAssinaturaStatus.addItem("CANCELADO", "Cancelado", 0);
         cmbAssinaturaStatus.addItem("ASSINADO", "Assinado", 0);
         cmbAssinaturaStatus.addItem("AGUARDANDO_ENVIO", "Aguardando envio", 0);
         if ( cmbAssinaturaStatus.ItemCount > 0 )
         {
            A239AssinaturaStatus = cmbAssinaturaStatus.getValidValue(A239AssinaturaStatus);
            n239AssinaturaStatus = false;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Assinatura Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Contrato") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Situação") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Vigência inicial") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Final") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Assinatura finalizada") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV67Consultar)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavConsultar_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavConsultar_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A238AssinaturaId), 10, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A228ContratoNome));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A239AssinaturaStatus));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A362ContratoDataInicial, "99/99/99")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A363ContratoDataFinal, "99/99/99")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A231ArquivoId), 8, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A366AssinaturaFinalizadoData, 10, 8, 0, 3, "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A367AssinaturaParticipantes_F), 4, 0, ".", ""))));
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
         cmbavAssinaturastatus1_Internalname = "vASSINATURASTATUS1";
         cellFilter_assinaturastatus1_cell_Internalname = "FILTER_ASSINATURASTATUS1_CELL";
         edtavContratonome1_Internalname = "vCONTRATONOME1";
         cellFilter_contratonome1_cell_Internalname = "FILTER_CONTRATONOME1_CELL";
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
         cmbavAssinaturastatus2_Internalname = "vASSINATURASTATUS2";
         cellFilter_assinaturastatus2_cell_Internalname = "FILTER_ASSINATURASTATUS2_CELL";
         edtavContratonome2_Internalname = "vCONTRATONOME2";
         cellFilter_contratonome2_cell_Internalname = "FILTER_CONTRATONOME2_CELL";
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
         cmbavAssinaturastatus3_Internalname = "vASSINATURASTATUS3";
         cellFilter_assinaturastatus3_cell_Internalname = "FILTER_ASSINATURASTATUS3_CELL";
         edtavContratonome3_Internalname = "vCONTRATONOME3";
         cellFilter_contratonome3_cell_Internalname = "FILTER_CONTRATONOME3_CELL";
         imgRemovedynamicfilters3_Internalname = "REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = "TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = "TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = "TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = "ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = "TABLEHEADER";
         Dvpanel_tableheader_Internalname = "DVPANEL_TABLEHEADER";
         edtavConsultar_Internalname = "vCONSULTAR";
         edtAssinaturaId_Internalname = "ASSINATURAID";
         edtContratoId_Internalname = "CONTRATOID";
         edtContratoNome_Internalname = "CONTRATONOME";
         cmbAssinaturaStatus_Internalname = "ASSINATURASTATUS";
         edtContratoDataInicial_Internalname = "CONTRATODATAINICIAL";
         edtContratoDataFinal_Internalname = "CONTRATODATAFINAL";
         edtArquivoId_Internalname = "ARQUIVOID";
         edtAssinaturaFinalizadoData_Internalname = "ASSINATURAFINALIZADODATA";
         edtAssinaturaParticipantes_F_Internalname = "ASSINATURAPARTICIPANTES_F";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         lblJsdynamicfilters_Internalname = "JSDYNAMICFILTERS";
         Ddo_grid_Internalname = "DDO_GRID";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         edtavDdo_contratodatainicialauxdatetext_Internalname = "vDDO_CONTRATODATAINICIALAUXDATETEXT";
         Tfcontratodatainicial_rangepicker_Internalname = "TFCONTRATODATAINICIAL_RANGEPICKER";
         divDdo_contratodatainicialauxdates_Internalname = "DDO_CONTRATODATAINICIALAUXDATES";
         edtavDdo_contratodatafinalauxdatetext_Internalname = "vDDO_CONTRATODATAFINALAUXDATETEXT";
         Tfcontratodatafinal_rangepicker_Internalname = "TFCONTRATODATAFINAL_RANGEPICKER";
         divDdo_contratodatafinalauxdates_Internalname = "DDO_CONTRATODATAFINALAUXDATES";
         edtavDdo_assinaturafinalizadodataauxdatetext_Internalname = "vDDO_ASSINATURAFINALIZADODATAAUXDATETEXT";
         Tfassinaturafinalizadodata_rangepicker_Internalname = "TFASSINATURAFINALIZADODATA_RANGEPICKER";
         divDdo_assinaturafinalizadodataauxdates_Internalname = "DDO_ASSINATURAFINALIZADODATAAUXDATES";
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
         edtAssinaturaParticipantes_F_Jsonclick = "";
         edtAssinaturaFinalizadoData_Jsonclick = "";
         edtArquivoId_Jsonclick = "";
         edtContratoDataFinal_Jsonclick = "";
         edtContratoDataInicial_Jsonclick = "";
         cmbAssinaturaStatus_Jsonclick = "";
         edtContratoNome_Jsonclick = "";
         edtContratoId_Jsonclick = "";
         edtAssinaturaId_Jsonclick = "";
         edtavConsultar_Jsonclick = "";
         edtavConsultar_Link = "";
         edtavConsultar_Enabled = 0;
         subGrid_Class = "GridWithPaginationBar GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavContratonome1_Jsonclick = "";
         edtavContratonome1_Enabled = 1;
         cmbavAssinaturastatus1_Jsonclick = "";
         cmbavAssinaturastatus1.Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavContratonome2_Jsonclick = "";
         edtavContratonome2_Enabled = 1;
         cmbavAssinaturastatus2_Jsonclick = "";
         cmbavAssinaturastatus2.Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavContratonome3_Jsonclick = "";
         edtavContratonome3_Enabled = 1;
         cmbavAssinaturastatus3_Jsonclick = "";
         cmbavAssinaturastatus3.Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavContratonome3_Visible = 1;
         cmbavAssinaturastatus3.Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavContratonome2_Visible = 1;
         cmbavAssinaturastatus2.Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavContratonome1_Visible = 1;
         cmbavAssinaturastatus1.Visible = 1;
         edtAssinaturaParticipantes_F_Enabled = 0;
         edtAssinaturaFinalizadoData_Enabled = 0;
         edtArquivoId_Enabled = 0;
         edtContratoDataFinal_Enabled = 0;
         edtContratoDataInicial_Enabled = 0;
         cmbAssinaturaStatus.Enabled = 0;
         edtContratoNome_Enabled = 0;
         edtContratoId_Enabled = 0;
         edtAssinaturaId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_assinaturafinalizadodataauxdatetext_Jsonclick = "";
         edtavDdo_contratodatafinalauxdatetext_Jsonclick = "";
         edtavDdo_contratodatainicialauxdatetext_Jsonclick = "";
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
         Ddo_grid_Format = "|||||4.0";
         Ddo_grid_Datalistproc = "AssinaturaWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|ENVIADO:Enviado,REJEITADO:Rejeitado,CANCELADO:Cancelado,ASSINADO:Assinado,AGUARDANDO_ENVIO:Aguardando envio||||";
         Ddo_grid_Allowmultipleselection = "|T||||";
         Ddo_grid_Datalisttype = "Dynamic|FixedValues||||";
         Ddo_grid_Includedatalist = "T|T||||";
         Ddo_grid_Filterisrange = "||P|P|P|T";
         Ddo_grid_Filtertype = "Character||Date|Date|Date|Numeric";
         Ddo_grid_Includefilter = "T||T|T|T|T";
         Ddo_grid_Includesortasc = "T|T|T|T|T|";
         Ddo_grid_Columnssortvalues = "2|3|4|5|6|";
         Ddo_grid_Columnids = "3:ContratoNome|4:AssinaturaStatus|5:ContratoDataInicial|6:ContratoDataFinal|8:AssinaturaFinalizadoData|9:AssinaturaParticipantes_F";
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
         Form.Caption = " Assinatura";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturastatus1"},{"av":"AV18AssinaturaStatus1","fld":"vASSINATURASTATUS1","type":"svchar"},{"av":"AV19ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturastatus2"},{"av":"AV23AssinaturaStatus2","fld":"vASSINATURASTATUS2","type":"svchar"},{"av":"AV24ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturastatus3"},{"av":"AV28AssinaturaStatus3","fld":"vASSINATURASTATUS3","type":"svchar"},{"av":"AV29ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV68AssinaturaStatus","fld":"vASSINATURASTATUS","hsh":true,"type":"svchar"},{"av":"AV73Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV38TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV39TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV41TFAssinaturaStatus_Sels","fld":"vTFASSINATURASTATUS_SELS","type":""},{"av":"AV57TFContratoDataInicial","fld":"vTFCONTRATODATAINICIAL","type":"date"},{"av":"AV58TFContratoDataInicial_To","fld":"vTFCONTRATODATAINICIAL_TO","type":"date"},{"av":"AV62TFContratoDataFinal","fld":"vTFCONTRATODATAFINAL","type":"date"},{"av":"AV63TFContratoDataFinal_To","fld":"vTFCONTRATODATAFINAL_TO","type":"date"},{"av":"AV42TFAssinaturaFinalizadoData","fld":"vTFASSINATURAFINALIZADODATA","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV43TFAssinaturaFinalizadoData_To","fld":"vTFASSINATURAFINALIZADODATA_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV47TFAssinaturaParticipantes_F","fld":"vTFASSINATURAPARTICIPANTES_F","pic":"ZZZ9","type":"int"},{"av":"AV48TFAssinaturaParticipantes_F_To","fld":"vTFASSINATURAPARTICIPANTES_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV69Vigente","fld":"vVIGENTE","hsh":true,"type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV100Clienteid","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV51GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV52GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV53GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E125F2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturastatus1"},{"av":"AV18AssinaturaStatus1","fld":"vASSINATURASTATUS1","type":"svchar"},{"av":"AV19ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturastatus2"},{"av":"AV23AssinaturaStatus2","fld":"vASSINATURASTATUS2","type":"svchar"},{"av":"AV24ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturastatus3"},{"av":"AV28AssinaturaStatus3","fld":"vASSINATURASTATUS3","type":"svchar"},{"av":"AV29ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV68AssinaturaStatus","fld":"vASSINATURASTATUS","hsh":true,"type":"svchar"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV73Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV38TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV39TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV41TFAssinaturaStatus_Sels","fld":"vTFASSINATURASTATUS_SELS","type":""},{"av":"AV57TFContratoDataInicial","fld":"vTFCONTRATODATAINICIAL","type":"date"},{"av":"AV58TFContratoDataInicial_To","fld":"vTFCONTRATODATAINICIAL_TO","type":"date"},{"av":"AV62TFContratoDataFinal","fld":"vTFCONTRATODATAFINAL","type":"date"},{"av":"AV63TFContratoDataFinal_To","fld":"vTFCONTRATODATAFINAL_TO","type":"date"},{"av":"AV42TFAssinaturaFinalizadoData","fld":"vTFASSINATURAFINALIZADODATA","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV43TFAssinaturaFinalizadoData_To","fld":"vTFASSINATURAFINALIZADODATA_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV47TFAssinaturaParticipantes_F","fld":"vTFASSINATURAPARTICIPANTES_F","pic":"ZZZ9","type":"int"},{"av":"AV48TFAssinaturaParticipantes_F_To","fld":"vTFASSINATURAPARTICIPANTES_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV69Vigente","fld":"vVIGENTE","hsh":true,"type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV100Clienteid","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E135F2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturastatus1"},{"av":"AV18AssinaturaStatus1","fld":"vASSINATURASTATUS1","type":"svchar"},{"av":"AV19ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturastatus2"},{"av":"AV23AssinaturaStatus2","fld":"vASSINATURASTATUS2","type":"svchar"},{"av":"AV24ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturastatus3"},{"av":"AV28AssinaturaStatus3","fld":"vASSINATURASTATUS3","type":"svchar"},{"av":"AV29ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV68AssinaturaStatus","fld":"vASSINATURASTATUS","hsh":true,"type":"svchar"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV73Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV38TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV39TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV41TFAssinaturaStatus_Sels","fld":"vTFASSINATURASTATUS_SELS","type":""},{"av":"AV57TFContratoDataInicial","fld":"vTFCONTRATODATAINICIAL","type":"date"},{"av":"AV58TFContratoDataInicial_To","fld":"vTFCONTRATODATAINICIAL_TO","type":"date"},{"av":"AV62TFContratoDataFinal","fld":"vTFCONTRATODATAFINAL","type":"date"},{"av":"AV63TFContratoDataFinal_To","fld":"vTFCONTRATODATAFINAL_TO","type":"date"},{"av":"AV42TFAssinaturaFinalizadoData","fld":"vTFASSINATURAFINALIZADODATA","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV43TFAssinaturaFinalizadoData_To","fld":"vTFASSINATURAFINALIZADODATA_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV47TFAssinaturaParticipantes_F","fld":"vTFASSINATURAPARTICIPANTES_F","pic":"ZZZ9","type":"int"},{"av":"AV48TFAssinaturaParticipantes_F_To","fld":"vTFASSINATURAPARTICIPANTES_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV69Vigente","fld":"vVIGENTE","hsh":true,"type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV100Clienteid","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E145F2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturastatus1"},{"av":"AV18AssinaturaStatus1","fld":"vASSINATURASTATUS1","type":"svchar"},{"av":"AV19ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturastatus2"},{"av":"AV23AssinaturaStatus2","fld":"vASSINATURASTATUS2","type":"svchar"},{"av":"AV24ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturastatus3"},{"av":"AV28AssinaturaStatus3","fld":"vASSINATURASTATUS3","type":"svchar"},{"av":"AV29ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV68AssinaturaStatus","fld":"vASSINATURASTATUS","hsh":true,"type":"svchar"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV73Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV38TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV39TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV41TFAssinaturaStatus_Sels","fld":"vTFASSINATURASTATUS_SELS","type":""},{"av":"AV57TFContratoDataInicial","fld":"vTFCONTRATODATAINICIAL","type":"date"},{"av":"AV58TFContratoDataInicial_To","fld":"vTFCONTRATODATAINICIAL_TO","type":"date"},{"av":"AV62TFContratoDataFinal","fld":"vTFCONTRATODATAFINAL","type":"date"},{"av":"AV63TFContratoDataFinal_To","fld":"vTFCONTRATODATAFINAL_TO","type":"date"},{"av":"AV42TFAssinaturaFinalizadoData","fld":"vTFASSINATURAFINALIZADODATA","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV43TFAssinaturaFinalizadoData_To","fld":"vTFASSINATURAFINALIZADODATA_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV47TFAssinaturaParticipantes_F","fld":"vTFASSINATURAPARTICIPANTES_F","pic":"ZZZ9","type":"int"},{"av":"AV48TFAssinaturaParticipantes_F_To","fld":"vTFASSINATURAPARTICIPANTES_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV69Vigente","fld":"vVIGENTE","hsh":true,"type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV100Clienteid","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV47TFAssinaturaParticipantes_F","fld":"vTFASSINATURAPARTICIPANTES_F","pic":"ZZZ9","type":"int"},{"av":"AV48TFAssinaturaParticipantes_F_To","fld":"vTFASSINATURAPARTICIPANTES_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV42TFAssinaturaFinalizadoData","fld":"vTFASSINATURAFINALIZADODATA","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV43TFAssinaturaFinalizadoData_To","fld":"vTFASSINATURAFINALIZADODATA_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV62TFContratoDataFinal","fld":"vTFCONTRATODATAFINAL","type":"date"},{"av":"AV63TFContratoDataFinal_To","fld":"vTFCONTRATODATAFINAL_TO","type":"date"},{"av":"AV57TFContratoDataInicial","fld":"vTFCONTRATODATAINICIAL","type":"date"},{"av":"AV58TFContratoDataInicial_To","fld":"vTFCONTRATODATAINICIAL_TO","type":"date"},{"av":"AV40TFAssinaturaStatus_SelsJson","fld":"vTFASSINATURASTATUS_SELSJSON","type":"vchar"},{"av":"AV41TFAssinaturaStatus_Sels","fld":"vTFASSINATURASTATUS_SELS","type":""},{"av":"AV38TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV39TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E275F2","iparms":[{"av":"A238AssinaturaId","fld":"ASSINATURAID","pic":"ZZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV67Consultar","fld":"vCONSULTAR","type":"char"},{"av":"edtavConsultar_Link","ctrl":"vCONSULTAR","prop":"Link"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E205F2","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E155F2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturastatus1"},{"av":"AV18AssinaturaStatus1","fld":"vASSINATURASTATUS1","type":"svchar"},{"av":"AV19ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturastatus2"},{"av":"AV23AssinaturaStatus2","fld":"vASSINATURASTATUS2","type":"svchar"},{"av":"AV24ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturastatus3"},{"av":"AV28AssinaturaStatus3","fld":"vASSINATURASTATUS3","type":"svchar"},{"av":"AV29ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV68AssinaturaStatus","fld":"vASSINATURASTATUS","hsh":true,"type":"svchar"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV73Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV38TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV39TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV41TFAssinaturaStatus_Sels","fld":"vTFASSINATURASTATUS_SELS","type":""},{"av":"AV57TFContratoDataInicial","fld":"vTFCONTRATODATAINICIAL","type":"date"},{"av":"AV58TFContratoDataInicial_To","fld":"vTFCONTRATODATAINICIAL_TO","type":"date"},{"av":"AV62TFContratoDataFinal","fld":"vTFCONTRATODATAFINAL","type":"date"},{"av":"AV63TFContratoDataFinal_To","fld":"vTFCONTRATODATAFINAL_TO","type":"date"},{"av":"AV42TFAssinaturaFinalizadoData","fld":"vTFASSINATURAFINALIZADODATA","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV43TFAssinaturaFinalizadoData_To","fld":"vTFASSINATURAFINALIZADODATA_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV47TFAssinaturaParticipantes_F","fld":"vTFASSINATURAPARTICIPANTES_F","pic":"ZZZ9","type":"int"},{"av":"AV48TFAssinaturaParticipantes_F_To","fld":"vTFASSINATURAPARTICIPANTES_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV69Vigente","fld":"vVIGENTE","hsh":true,"type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV100Clienteid","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavAssinaturastatus2"},{"av":"AV23AssinaturaStatus2","fld":"vASSINATURASTATUS2","type":"svchar"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavAssinaturastatus3"},{"av":"AV28AssinaturaStatus3","fld":"vASSINATURASTATUS3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavAssinaturastatus1"},{"av":"AV18AssinaturaStatus1","fld":"vASSINATURASTATUS1","type":"svchar"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"edtavContratonome2_Visible","ctrl":"vCONTRATONOME2","prop":"Visible"},{"av":"edtavContratonome3_Visible","ctrl":"vCONTRATONOME3","prop":"Visible"},{"av":"edtavContratonome1_Visible","ctrl":"vCONTRATONOME1","prop":"Visible"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV51GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV52GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV53GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E215F2","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"cmbavAssinaturastatus1"},{"av":"edtavContratonome1_Visible","ctrl":"vCONTRATONOME1","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator1"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E225F2","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E165F2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturastatus1"},{"av":"AV18AssinaturaStatus1","fld":"vASSINATURASTATUS1","type":"svchar"},{"av":"AV19ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturastatus2"},{"av":"AV23AssinaturaStatus2","fld":"vASSINATURASTATUS2","type":"svchar"},{"av":"AV24ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturastatus3"},{"av":"AV28AssinaturaStatus3","fld":"vASSINATURASTATUS3","type":"svchar"},{"av":"AV29ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV68AssinaturaStatus","fld":"vASSINATURASTATUS","hsh":true,"type":"svchar"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV73Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV38TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV39TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV41TFAssinaturaStatus_Sels","fld":"vTFASSINATURASTATUS_SELS","type":""},{"av":"AV57TFContratoDataInicial","fld":"vTFCONTRATODATAINICIAL","type":"date"},{"av":"AV58TFContratoDataInicial_To","fld":"vTFCONTRATODATAINICIAL_TO","type":"date"},{"av":"AV62TFContratoDataFinal","fld":"vTFCONTRATODATAFINAL","type":"date"},{"av":"AV63TFContratoDataFinal_To","fld":"vTFCONTRATODATAFINAL_TO","type":"date"},{"av":"AV42TFAssinaturaFinalizadoData","fld":"vTFASSINATURAFINALIZADODATA","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV43TFAssinaturaFinalizadoData_To","fld":"vTFASSINATURAFINALIZADODATA_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV47TFAssinaturaParticipantes_F","fld":"vTFASSINATURAPARTICIPANTES_F","pic":"ZZZ9","type":"int"},{"av":"AV48TFAssinaturaParticipantes_F_To","fld":"vTFASSINATURAPARTICIPANTES_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV69Vigente","fld":"vVIGENTE","hsh":true,"type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV100Clienteid","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavAssinaturastatus2"},{"av":"AV23AssinaturaStatus2","fld":"vASSINATURASTATUS2","type":"svchar"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavAssinaturastatus3"},{"av":"AV28AssinaturaStatus3","fld":"vASSINATURASTATUS3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavAssinaturastatus1"},{"av":"AV18AssinaturaStatus1","fld":"vASSINATURASTATUS1","type":"svchar"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"edtavContratonome2_Visible","ctrl":"vCONTRATONOME2","prop":"Visible"},{"av":"edtavContratonome3_Visible","ctrl":"vCONTRATONOME3","prop":"Visible"},{"av":"edtavContratonome1_Visible","ctrl":"vCONTRATONOME1","prop":"Visible"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV51GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV52GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV53GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E235F2","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"cmbavAssinaturastatus2"},{"av":"edtavContratonome2_Visible","ctrl":"vCONTRATONOME2","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator2"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E175F2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturastatus1"},{"av":"AV18AssinaturaStatus1","fld":"vASSINATURASTATUS1","type":"svchar"},{"av":"AV19ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturastatus2"},{"av":"AV23AssinaturaStatus2","fld":"vASSINATURASTATUS2","type":"svchar"},{"av":"AV24ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturastatus3"},{"av":"AV28AssinaturaStatus3","fld":"vASSINATURASTATUS3","type":"svchar"},{"av":"AV29ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV68AssinaturaStatus","fld":"vASSINATURASTATUS","hsh":true,"type":"svchar"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV73Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV38TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV39TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV41TFAssinaturaStatus_Sels","fld":"vTFASSINATURASTATUS_SELS","type":""},{"av":"AV57TFContratoDataInicial","fld":"vTFCONTRATODATAINICIAL","type":"date"},{"av":"AV58TFContratoDataInicial_To","fld":"vTFCONTRATODATAINICIAL_TO","type":"date"},{"av":"AV62TFContratoDataFinal","fld":"vTFCONTRATODATAFINAL","type":"date"},{"av":"AV63TFContratoDataFinal_To","fld":"vTFCONTRATODATAFINAL_TO","type":"date"},{"av":"AV42TFAssinaturaFinalizadoData","fld":"vTFASSINATURAFINALIZADODATA","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV43TFAssinaturaFinalizadoData_To","fld":"vTFASSINATURAFINALIZADODATA_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV47TFAssinaturaParticipantes_F","fld":"vTFASSINATURAPARTICIPANTES_F","pic":"ZZZ9","type":"int"},{"av":"AV48TFAssinaturaParticipantes_F_To","fld":"vTFASSINATURAPARTICIPANTES_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV69Vigente","fld":"vVIGENTE","hsh":true,"type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV100Clienteid","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavAssinaturastatus2"},{"av":"AV23AssinaturaStatus2","fld":"vASSINATURASTATUS2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavAssinaturastatus3"},{"av":"AV28AssinaturaStatus3","fld":"vASSINATURASTATUS3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavAssinaturastatus1"},{"av":"AV18AssinaturaStatus1","fld":"vASSINATURASTATUS1","type":"svchar"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"edtavContratonome2_Visible","ctrl":"vCONTRATONOME2","prop":"Visible"},{"av":"edtavContratonome3_Visible","ctrl":"vCONTRATONOME3","prop":"Visible"},{"av":"edtavContratonome1_Visible","ctrl":"vCONTRATONOME1","prop":"Visible"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV51GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV52GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV53GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E245F2","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"cmbavAssinaturastatus3"},{"av":"edtavContratonome3_Visible","ctrl":"vCONTRATONOME3","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator3"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E115F2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturastatus1"},{"av":"AV18AssinaturaStatus1","fld":"vASSINATURASTATUS1","type":"svchar"},{"av":"AV19ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturastatus2"},{"av":"AV23AssinaturaStatus2","fld":"vASSINATURASTATUS2","type":"svchar"},{"av":"AV24ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"cmbavAssinaturastatus3"},{"av":"AV28AssinaturaStatus3","fld":"vASSINATURASTATUS3","type":"svchar"},{"av":"AV29ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"AV68AssinaturaStatus","fld":"vASSINATURASTATUS","hsh":true,"type":"svchar"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV73Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV38TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV39TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV41TFAssinaturaStatus_Sels","fld":"vTFASSINATURASTATUS_SELS","type":""},{"av":"AV57TFContratoDataInicial","fld":"vTFCONTRATODATAINICIAL","type":"date"},{"av":"AV58TFContratoDataInicial_To","fld":"vTFCONTRATODATAINICIAL_TO","type":"date"},{"av":"AV62TFContratoDataFinal","fld":"vTFCONTRATODATAFINAL","type":"date"},{"av":"AV63TFContratoDataFinal_To","fld":"vTFCONTRATODATAFINAL_TO","type":"date"},{"av":"AV42TFAssinaturaFinalizadoData","fld":"vTFASSINATURAFINALIZADODATA","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV43TFAssinaturaFinalizadoData_To","fld":"vTFASSINATURAFINALIZADODATA_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV47TFAssinaturaParticipantes_F","fld":"vTFASSINATURAPARTICIPANTES_F","pic":"ZZZ9","type":"int"},{"av":"AV48TFAssinaturaParticipantes_F_To","fld":"vTFASSINATURAPARTICIPANTES_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV69Vigente","fld":"vVIGENTE","hsh":true,"type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV100Clienteid","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV40TFAssinaturaStatus_SelsJson","fld":"vTFASSINATURASTATUS_SELSJSON","type":"vchar"},{"av":"AV44DDO_AssinaturaFinalizadoDataAuxDate","fld":"vDDO_ASSINATURAFINALIZADODATAAUXDATE","type":"date"},{"av":"AV45DDO_AssinaturaFinalizadoDataAuxDateTo","fld":"vDDO_ASSINATURAFINALIZADODATAAUXDATETO","type":"date"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV38TFContratoNome","fld":"vTFCONTRATONOME","type":"svchar"},{"av":"AV39TFContratoNome_Sel","fld":"vTFCONTRATONOME_SEL","type":"svchar"},{"av":"AV41TFAssinaturaStatus_Sels","fld":"vTFASSINATURASTATUS_SELS","type":""},{"av":"AV57TFContratoDataInicial","fld":"vTFCONTRATODATAINICIAL","type":"date"},{"av":"AV58TFContratoDataInicial_To","fld":"vTFCONTRATODATAINICIAL_TO","type":"date"},{"av":"AV62TFContratoDataFinal","fld":"vTFCONTRATODATAFINAL","type":"date"},{"av":"AV63TFContratoDataFinal_To","fld":"vTFCONTRATODATAFINAL_TO","type":"date"},{"av":"AV42TFAssinaturaFinalizadoData","fld":"vTFASSINATURAFINALIZADODATA","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV43TFAssinaturaFinalizadoData_To","fld":"vTFASSINATURAFINALIZADODATA_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV47TFAssinaturaParticipantes_F","fld":"vTFASSINATURAPARTICIPANTES_F","pic":"ZZZ9","type":"int"},{"av":"AV48TFAssinaturaParticipantes_F_To","fld":"vTFASSINATURAPARTICIPANTES_F_TO","pic":"ZZZ9","type":"int"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavAssinaturastatus1"},{"av":"AV18AssinaturaStatus1","fld":"vASSINATURASTATUS1","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV44DDO_AssinaturaFinalizadoDataAuxDate","fld":"vDDO_ASSINATURAFINALIZADODATAAUXDATE","type":"date"},{"av":"AV45DDO_AssinaturaFinalizadoDataAuxDateTo","fld":"vDDO_ASSINATURAFINALIZADODATAAUXDATETO","type":"date"},{"av":"AV40TFAssinaturaStatus_SelsJson","fld":"vTFASSINATURASTATUS_SELSJSON","type":"vchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19ContratoNome1","fld":"vCONTRATONOME1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavAssinaturastatus2"},{"av":"AV23AssinaturaStatus2","fld":"vASSINATURASTATUS2","type":"svchar"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24ContratoNome2","fld":"vCONTRATONOME2","type":"svchar"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavAssinaturastatus3"},{"av":"AV28AssinaturaStatus3","fld":"vASSINATURASTATUS3","type":"svchar"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29ContratoNome3","fld":"vCONTRATONOME3","type":"svchar"},{"av":"edtavContratonome1_Visible","ctrl":"vCONTRATONOME1","prop":"Visible"},{"av":"edtavContratonome2_Visible","ctrl":"vCONTRATONOME2","prop":"Visible"},{"av":"edtavContratonome3_Visible","ctrl":"vCONTRATONOME3","prop":"Visible"},{"av":"AV51GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV52GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV53GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E185F2","iparms":[{"av":"AV100Clienteid","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("'DOEXPORT'","""{"handler":"E195F2","iparms":[]}""");
         setEventMetadata("VALIDV_ASSINATURASTATUS1","""{"handler":"Validv_Assinaturastatus1","iparms":[]}""");
         setEventMetadata("VALIDV_ASSINATURASTATUS2","""{"handler":"Validv_Assinaturastatus2","iparms":[]}""");
         setEventMetadata("VALIDV_ASSINATURASTATUS3","""{"handler":"Validv_Assinaturastatus3","iparms":[]}""");
         setEventMetadata("VALID_ASSINATURAID","""{"handler":"Valid_Assinaturaid","iparms":[]}""");
         setEventMetadata("VALID_CONTRATOID","""{"handler":"Valid_Contratoid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Assinaturaparticipantes_f","iparms":[]}""");
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
         wcpOAV68AssinaturaStatus = "";
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Filteredtextto_get = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV16DynamicFiltersSelector1 = "";
         AV18AssinaturaStatus1 = "";
         AV19ContratoNome1 = "";
         AV21DynamicFiltersSelector2 = "";
         AV23AssinaturaStatus2 = "";
         AV24ContratoNome2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28AssinaturaStatus3 = "";
         AV29ContratoNome3 = "";
         AV73Pgmname = "";
         AV15FilterFullText = "";
         AV38TFContratoNome = "";
         AV39TFContratoNome_Sel = "";
         AV41TFAssinaturaStatus_Sels = new GxSimpleCollection<string>();
         AV57TFContratoDataInicial = DateTime.MinValue;
         AV58TFContratoDataInicial_To = DateTime.MinValue;
         AV62TFContratoDataFinal = DateTime.MinValue;
         AV63TFContratoDataFinal_To = DateTime.MinValue;
         AV42TFAssinaturaFinalizadoData = (DateTime)(DateTime.MinValue);
         AV43TFAssinaturaFinalizadoData_To = (DateTime)(DateTime.MinValue);
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV35ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV53GridAppliedFilters = "";
         AV49DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV59DDO_ContratoDataInicialAuxDate = DateTime.MinValue;
         AV60DDO_ContratoDataInicialAuxDateTo = DateTime.MinValue;
         AV64DDO_ContratoDataFinalAuxDate = DateTime.MinValue;
         AV65DDO_ContratoDataFinalAuxDateTo = DateTime.MinValue;
         AV44DDO_AssinaturaFinalizadoDataAuxDate = DateTime.MinValue;
         AV45DDO_AssinaturaFinalizadoDataAuxDateTo = DateTime.MinValue;
         AV40TFAssinaturaStatus_SelsJson = "";
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
         AV61DDO_ContratoDataInicialAuxDateText = "";
         ucTfcontratodatainicial_rangepicker = new GXUserControl();
         AV66DDO_ContratoDataFinalAuxDateText = "";
         ucTfcontratodatafinal_rangepicker = new GXUserControl();
         AV46DDO_AssinaturaFinalizadoDataAuxDateText = "";
         ucTfassinaturafinalizadodata_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV67Consultar = "";
         A228ContratoNome = "";
         A239AssinaturaStatus = "";
         A362ContratoDataInicial = DateTime.MinValue;
         A363ContratoDataFinal = DateTime.MinValue;
         A366AssinaturaFinalizadoData = (DateTime)(DateTime.MinValue);
         GXDecQS = "";
         Gx_date = DateTime.MinValue;
         AV91Assinaturawwds_18_tfassinaturastatus_sels = new GxSimpleCollection<string>();
         lV74Assinaturawwds_1_filterfulltext = "";
         lV78Assinaturawwds_5_contratonome1 = "";
         lV83Assinaturawwds_10_contratonome2 = "";
         lV88Assinaturawwds_15_contratonome3 = "";
         lV89Assinaturawwds_16_tfcontratonome = "";
         AV75Assinaturawwds_2_dynamicfiltersselector1 = "";
         AV77Assinaturawwds_4_assinaturastatus1 = "";
         AV78Assinaturawwds_5_contratonome1 = "";
         AV80Assinaturawwds_7_dynamicfiltersselector2 = "";
         AV82Assinaturawwds_9_assinaturastatus2 = "";
         AV83Assinaturawwds_10_contratonome2 = "";
         AV85Assinaturawwds_12_dynamicfiltersselector3 = "";
         AV87Assinaturawwds_14_assinaturastatus3 = "";
         AV88Assinaturawwds_15_contratonome3 = "";
         AV90Assinaturawwds_17_tfcontratonome_sel = "";
         AV89Assinaturawwds_16_tfcontratonome = "";
         AV92Assinaturawwds_19_tfcontratodatainicial = DateTime.MinValue;
         AV93Assinaturawwds_20_tfcontratodatainicial_to = DateTime.MinValue;
         AV94Assinaturawwds_21_tfcontratodatafinal = DateTime.MinValue;
         AV95Assinaturawwds_22_tfcontratodatafinal_to = DateTime.MinValue;
         AV96Assinaturawwds_23_tfassinaturafinalizadodata = (DateTime)(DateTime.MinValue);
         AV97Assinaturawwds_24_tfassinaturafinalizadodata_to = (DateTime)(DateTime.MinValue);
         AV74Assinaturawwds_1_filterfulltext = "";
         H005F3_A366AssinaturaFinalizadoData = new DateTime[] {DateTime.MinValue} ;
         H005F3_n366AssinaturaFinalizadoData = new bool[] {false} ;
         H005F3_A231ArquivoId = new int[1] ;
         H005F3_n231ArquivoId = new bool[] {false} ;
         H005F3_A363ContratoDataFinal = new DateTime[] {DateTime.MinValue} ;
         H005F3_n363ContratoDataFinal = new bool[] {false} ;
         H005F3_A362ContratoDataInicial = new DateTime[] {DateTime.MinValue} ;
         H005F3_n362ContratoDataInicial = new bool[] {false} ;
         H005F3_A239AssinaturaStatus = new string[] {""} ;
         H005F3_n239AssinaturaStatus = new bool[] {false} ;
         H005F3_A228ContratoNome = new string[] {""} ;
         H005F3_n228ContratoNome = new bool[] {false} ;
         H005F3_A227ContratoId = new int[1] ;
         H005F3_n227ContratoId = new bool[] {false} ;
         H005F3_A238AssinaturaId = new long[1] ;
         H005F3_n238AssinaturaId = new bool[] {false} ;
         H005F3_A367AssinaturaParticipantes_F = new short[1] ;
         H005F3_n367AssinaturaParticipantes_F = new bool[] {false} ;
         H005F5_AGRID_nRecordCount = new long[1] ;
         AV70VigenciaData = DateTime.MinValue;
         AV7HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV36ManageFiltersXml = "";
         AV32ExcelFilename = "";
         AV33ErrorMessage = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV34Session = context.GetSession();
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         GXt_char4 = "";
         AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV56AuxText = "";
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.assinaturaww__default(),
            new Object[][] {
                new Object[] {
               H005F3_A366AssinaturaFinalizadoData, H005F3_n366AssinaturaFinalizadoData, H005F3_A231ArquivoId, H005F3_n231ArquivoId, H005F3_A363ContratoDataFinal, H005F3_n363ContratoDataFinal, H005F3_A362ContratoDataInicial, H005F3_n362ContratoDataInicial, H005F3_A239AssinaturaStatus, H005F3_n239AssinaturaStatus,
               H005F3_A228ContratoNome, H005F3_n228ContratoNome, H005F3_A227ContratoId, H005F3_n227ContratoId, H005F3_A238AssinaturaId, H005F3_A367AssinaturaParticipantes_F, H005F3_n367AssinaturaParticipantes_F
               }
               , new Object[] {
               H005F5_AGRID_nRecordCount
               }
            }
         );
         AV73Pgmname = "AssinaturaWW";
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         AV73Pgmname = "AssinaturaWW";
         Gx_date = DateTimeUtil.Today( context);
         edtavConsultar_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV13OrderedBy ;
      private short AV17DynamicFiltersOperator1 ;
      private short AV22DynamicFiltersOperator2 ;
      private short AV27DynamicFiltersOperator3 ;
      private short AV37ManageFiltersExecutionStep ;
      private short AV47TFAssinaturaParticipantes_F ;
      private short AV48TFAssinaturaParticipantes_F_To ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A367AssinaturaParticipantes_F ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV76Assinaturawwds_3_dynamicfiltersoperator1 ;
      private short AV81Assinaturawwds_8_dynamicfiltersoperator2 ;
      private short AV86Assinaturawwds_13_dynamicfiltersoperator3 ;
      private short AV98Assinaturawwds_25_tfassinaturaparticipantes_f ;
      private short AV99Assinaturawwds_26_tfassinaturaparticipantes_f_to ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_116 ;
      private int nGXsfl_116_idx=1 ;
      private int AV100Clienteid ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int A227ContratoId ;
      private int A231ArquivoId ;
      private int subGrid_Islastpage ;
      private int edtavConsultar_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV91Assinaturawwds_18_tfassinaturastatus_sels_Count ;
      private int edtAssinaturaId_Enabled ;
      private int edtContratoId_Enabled ;
      private int edtContratoNome_Enabled ;
      private int edtContratoDataInicial_Enabled ;
      private int edtContratoDataFinal_Enabled ;
      private int edtArquivoId_Enabled ;
      private int edtAssinaturaFinalizadoData_Enabled ;
      private int edtAssinaturaParticipantes_F_Enabled ;
      private int AV50PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavContratonome1_Visible ;
      private int edtavContratonome2_Visible ;
      private int edtavContratonome3_Visible ;
      private int AV101GXV1 ;
      private int edtavContratonome3_Enabled ;
      private int edtavContratonome2_Enabled ;
      private int edtavContratonome1_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV51GridCurrentPage ;
      private long AV52GridPageCount ;
      private long A238AssinaturaId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_116_idx="0001" ;
      private string AV73Pgmname ;
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
      private string divDdo_contratodatainicialauxdates_Internalname ;
      private string edtavDdo_contratodatainicialauxdatetext_Internalname ;
      private string edtavDdo_contratodatainicialauxdatetext_Jsonclick ;
      private string Tfcontratodatainicial_rangepicker_Internalname ;
      private string divDdo_contratodatafinalauxdates_Internalname ;
      private string edtavDdo_contratodatafinalauxdatetext_Internalname ;
      private string edtavDdo_contratodatafinalauxdatetext_Jsonclick ;
      private string Tfcontratodatafinal_rangepicker_Internalname ;
      private string divDdo_assinaturafinalizadodataauxdates_Internalname ;
      private string edtavDdo_assinaturafinalizadodataauxdatetext_Internalname ;
      private string edtavDdo_assinaturafinalizadodataauxdatetext_Jsonclick ;
      private string Tfassinaturafinalizadodata_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV67Consultar ;
      private string edtavConsultar_Internalname ;
      private string edtAssinaturaId_Internalname ;
      private string edtContratoId_Internalname ;
      private string edtContratoNome_Internalname ;
      private string cmbAssinaturaStatus_Internalname ;
      private string edtContratoDataInicial_Internalname ;
      private string edtContratoDataFinal_Internalname ;
      private string edtArquivoId_Internalname ;
      private string edtAssinaturaFinalizadoData_Internalname ;
      private string edtAssinaturaParticipantes_F_Internalname ;
      private string GXDecQS ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavAssinaturastatus1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavAssinaturastatus2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string cmbavAssinaturastatus3_Internalname ;
      private string edtavContratonome1_Internalname ;
      private string edtavContratonome2_Internalname ;
      private string edtavContratonome3_Internalname ;
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
      private string edtavConsultar_Link ;
      private string GXt_char2 ;
      private string GXt_char4 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_assinaturastatus3_cell_Internalname ;
      private string cmbavAssinaturastatus3_Jsonclick ;
      private string cellFilter_contratonome3_cell_Internalname ;
      private string edtavContratonome3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_assinaturastatus2_cell_Internalname ;
      private string cmbavAssinaturastatus2_Jsonclick ;
      private string cellFilter_contratonome2_cell_Internalname ;
      private string edtavContratonome2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_assinaturastatus1_cell_Internalname ;
      private string cmbavAssinaturastatus1_Jsonclick ;
      private string cellFilter_contratonome1_cell_Internalname ;
      private string edtavContratonome1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string sGXsfl_116_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavConsultar_Jsonclick ;
      private string edtAssinaturaId_Jsonclick ;
      private string edtContratoId_Jsonclick ;
      private string edtContratoNome_Jsonclick ;
      private string GXCCtl ;
      private string cmbAssinaturaStatus_Jsonclick ;
      private string edtContratoDataInicial_Jsonclick ;
      private string edtContratoDataFinal_Jsonclick ;
      private string edtArquivoId_Jsonclick ;
      private string edtAssinaturaFinalizadoData_Jsonclick ;
      private string edtAssinaturaParticipantes_F_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV42TFAssinaturaFinalizadoData ;
      private DateTime AV43TFAssinaturaFinalizadoData_To ;
      private DateTime A366AssinaturaFinalizadoData ;
      private DateTime AV96Assinaturawwds_23_tfassinaturafinalizadodata ;
      private DateTime AV97Assinaturawwds_24_tfassinaturafinalizadodata_to ;
      private DateTime AV57TFContratoDataInicial ;
      private DateTime AV58TFContratoDataInicial_To ;
      private DateTime AV62TFContratoDataFinal ;
      private DateTime AV63TFContratoDataFinal_To ;
      private DateTime AV59DDO_ContratoDataInicialAuxDate ;
      private DateTime AV60DDO_ContratoDataInicialAuxDateTo ;
      private DateTime AV64DDO_ContratoDataFinalAuxDate ;
      private DateTime AV65DDO_ContratoDataFinalAuxDateTo ;
      private DateTime AV44DDO_AssinaturaFinalizadoDataAuxDate ;
      private DateTime AV45DDO_AssinaturaFinalizadoDataAuxDateTo ;
      private DateTime A362ContratoDataInicial ;
      private DateTime A363ContratoDataFinal ;
      private DateTime Gx_date ;
      private DateTime AV92Assinaturawwds_19_tfcontratodatainicial ;
      private DateTime AV93Assinaturawwds_20_tfcontratodatainicial_to ;
      private DateTime AV94Assinaturawwds_21_tfcontratodatafinal ;
      private DateTime AV95Assinaturawwds_22_tfcontratodatafinal_to ;
      private DateTime AV70VigenciaData ;
      private bool AV69Vigente ;
      private bool wcpOAV69Vigente ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV20DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV31DynamicFiltersIgnoreFirst ;
      private bool AV30DynamicFiltersRemoving ;
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
      private bool n238AssinaturaId ;
      private bool n227ContratoId ;
      private bool n228ContratoNome ;
      private bool n239AssinaturaStatus ;
      private bool n362ContratoDataInicial ;
      private bool n363ContratoDataFinal ;
      private bool n231ArquivoId ;
      private bool n366AssinaturaFinalizadoData ;
      private bool n367AssinaturaParticipantes_F ;
      private bool bGXsfl_116_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV79Assinaturawwds_6_dynamicfiltersenabled2 ;
      private bool AV84Assinaturawwds_11_dynamicfiltersenabled3 ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV40TFAssinaturaStatus_SelsJson ;
      private string AV36ManageFiltersXml ;
      private string AV68AssinaturaStatus ;
      private string wcpOAV68AssinaturaStatus ;
      private string AV16DynamicFiltersSelector1 ;
      private string AV18AssinaturaStatus1 ;
      private string AV19ContratoNome1 ;
      private string AV21DynamicFiltersSelector2 ;
      private string AV23AssinaturaStatus2 ;
      private string AV24ContratoNome2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV28AssinaturaStatus3 ;
      private string AV29ContratoNome3 ;
      private string AV15FilterFullText ;
      private string AV38TFContratoNome ;
      private string AV39TFContratoNome_Sel ;
      private string AV53GridAppliedFilters ;
      private string AV61DDO_ContratoDataInicialAuxDateText ;
      private string AV66DDO_ContratoDataFinalAuxDateText ;
      private string AV46DDO_AssinaturaFinalizadoDataAuxDateText ;
      private string A228ContratoNome ;
      private string A239AssinaturaStatus ;
      private string lV74Assinaturawwds_1_filterfulltext ;
      private string lV78Assinaturawwds_5_contratonome1 ;
      private string lV83Assinaturawwds_10_contratonome2 ;
      private string lV88Assinaturawwds_15_contratonome3 ;
      private string lV89Assinaturawwds_16_tfcontratonome ;
      private string AV75Assinaturawwds_2_dynamicfiltersselector1 ;
      private string AV77Assinaturawwds_4_assinaturastatus1 ;
      private string AV78Assinaturawwds_5_contratonome1 ;
      private string AV80Assinaturawwds_7_dynamicfiltersselector2 ;
      private string AV82Assinaturawwds_9_assinaturastatus2 ;
      private string AV83Assinaturawwds_10_contratonome2 ;
      private string AV85Assinaturawwds_12_dynamicfiltersselector3 ;
      private string AV87Assinaturawwds_14_assinaturastatus3 ;
      private string AV88Assinaturawwds_15_contratonome3 ;
      private string AV90Assinaturawwds_17_tfcontratonome_sel ;
      private string AV89Assinaturawwds_16_tfcontratonome ;
      private string AV74Assinaturawwds_1_filterfulltext ;
      private string AV32ExcelFilename ;
      private string AV33ErrorMessage ;
      private string AV56AuxText ;
      private IGxSession AV34Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfcontratodatainicial_rangepicker ;
      private GXUserControl ucTfcontratodatafinal_rangepicker ;
      private GXUserControl ucTfassinaturafinalizadodata_rangepicker ;
      private GxHttpRequest AV7HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavAssinaturastatus1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavAssinaturastatus2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCombobox cmbavAssinaturastatus3 ;
      private GXCombobox cmbAssinaturaStatus ;
      private GxSimpleCollection<string> AV41TFAssinaturaStatus_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV35ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV49DDO_TitleSettingsIcons ;
      private GxSimpleCollection<string> AV91Assinaturawwds_18_tfassinaturastatus_sels ;
      private IDataStoreProvider pr_default ;
      private DateTime[] H005F3_A366AssinaturaFinalizadoData ;
      private bool[] H005F3_n366AssinaturaFinalizadoData ;
      private int[] H005F3_A231ArquivoId ;
      private bool[] H005F3_n231ArquivoId ;
      private DateTime[] H005F3_A363ContratoDataFinal ;
      private bool[] H005F3_n363ContratoDataFinal ;
      private DateTime[] H005F3_A362ContratoDataInicial ;
      private bool[] H005F3_n362ContratoDataInicial ;
      private string[] H005F3_A239AssinaturaStatus ;
      private bool[] H005F3_n239AssinaturaStatus ;
      private string[] H005F3_A228ContratoNome ;
      private bool[] H005F3_n228ContratoNome ;
      private int[] H005F3_A227ContratoId ;
      private bool[] H005F3_n227ContratoId ;
      private long[] H005F3_A238AssinaturaId ;
      private bool[] H005F3_n238AssinaturaId ;
      private short[] H005F3_A367AssinaturaParticipantes_F ;
      private bool[] H005F3_n367AssinaturaParticipantes_F ;
      private long[] H005F5_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV12GridStateDynamicFilter ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class assinaturaww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H005F3( IGxContext context ,
                                             string A239AssinaturaStatus ,
                                             GxSimpleCollection<string> AV91Assinaturawwds_18_tfassinaturastatus_sels ,
                                             string AV75Assinaturawwds_2_dynamicfiltersselector1 ,
                                             string AV77Assinaturawwds_4_assinaturastatus1 ,
                                             short AV76Assinaturawwds_3_dynamicfiltersoperator1 ,
                                             string AV78Assinaturawwds_5_contratonome1 ,
                                             bool AV79Assinaturawwds_6_dynamicfiltersenabled2 ,
                                             string AV80Assinaturawwds_7_dynamicfiltersselector2 ,
                                             string AV82Assinaturawwds_9_assinaturastatus2 ,
                                             short AV81Assinaturawwds_8_dynamicfiltersoperator2 ,
                                             string AV83Assinaturawwds_10_contratonome2 ,
                                             bool AV84Assinaturawwds_11_dynamicfiltersenabled3 ,
                                             string AV85Assinaturawwds_12_dynamicfiltersselector3 ,
                                             string AV87Assinaturawwds_14_assinaturastatus3 ,
                                             short AV86Assinaturawwds_13_dynamicfiltersoperator3 ,
                                             string AV88Assinaturawwds_15_contratonome3 ,
                                             string AV90Assinaturawwds_17_tfcontratonome_sel ,
                                             string AV89Assinaturawwds_16_tfcontratonome ,
                                             int AV91Assinaturawwds_18_tfassinaturastatus_sels_Count ,
                                             DateTime AV92Assinaturawwds_19_tfcontratodatainicial ,
                                             DateTime AV93Assinaturawwds_20_tfcontratodatainicial_to ,
                                             DateTime AV94Assinaturawwds_21_tfcontratodatafinal ,
                                             DateTime AV95Assinaturawwds_22_tfcontratodatafinal_to ,
                                             DateTime AV96Assinaturawwds_23_tfassinaturafinalizadodata ,
                                             DateTime AV97Assinaturawwds_24_tfassinaturafinalizadodata_to ,
                                             string AV68AssinaturaStatus ,
                                             string A228ContratoNome ,
                                             DateTime A362ContratoDataInicial ,
                                             DateTime A363ContratoDataFinal ,
                                             DateTime A366AssinaturaFinalizadoData ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             string AV74Assinaturawwds_1_filterfulltext ,
                                             short A367AssinaturaParticipantes_F ,
                                             short AV98Assinaturawwds_25_tfassinaturaparticipantes_f ,
                                             short AV99Assinaturawwds_26_tfassinaturaparticipantes_f_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[33];
         Object[] GXv_Object6 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.AssinaturaFinalizadoData, T1.ArquivoId, T2.ContratoDataFinal, T2.ContratoDataInicial, T1.AssinaturaStatus, T2.ContratoNome, T1.ContratoId, T1.AssinaturaId, COALESCE( T3.AssinaturaParticipantes_F, 0) AS AssinaturaParticipantes_F";
         sFromString = " FROM ((Assinatura T1 LEFT JOIN Contrato T2 ON T2.ContratoId = T1.ContratoId) LEFT JOIN LATERAL (SELECT COUNT(*) AS AssinaturaParticipantes_F, AssinaturaId FROM AssinaturaParticipante WHERE T1.AssinaturaId = AssinaturaId GROUP BY AssinaturaId ) T3 ON T3.AssinaturaId = T1.AssinaturaId)";
         sOrderString = "";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV74Assinaturawwds_1_filterfulltext))=0) or ( ( T2.ContratoNome like '%' || :lV74Assinaturawwds_1_filterfulltext) or ( 'enviado' like '%' || LOWER(:lV74Assinaturawwds_1_filterfulltext) and T1.AssinaturaStatus = ( 'ENVIADO')) or ( 'rejeitado' like '%' || LOWER(:lV74Assinaturawwds_1_filterfulltext) and T1.AssinaturaStatus = ( 'REJEITADO')) or ( 'cancelado' like '%' || LOWER(:lV74Assinaturawwds_1_filterfulltext) and T1.AssinaturaStatus = ( 'CANCELADO')) or ( 'assinado' like '%' || LOWER(:lV74Assinaturawwds_1_filterfulltext) and T1.AssinaturaStatus = ( 'ASSINADO')) or ( 'aguardando envio' like '%' || LOWER(:lV74Assinaturawwds_1_filterfulltext) and T1.AssinaturaStatus = ( 'AGUARDANDO_ENVIO')) or ( SUBSTR(TO_CHAR(COALESCE( T3.AssinaturaParticipantes_F, 0),'9999'), 2) like '%' || :lV74Assinaturawwds_1_filterfulltext)))");
         AddWhere(sWhereString, "((:AV98Assinaturawwds_25_tfassinaturaparticipantes_f = 0) or ( COALESCE( T3.AssinaturaParticipantes_F, 0) >= :AV98Assinaturawwds_25_tfassinaturaparticipantes_f))");
         AddWhere(sWhereString, "((:AV99Assinaturawwds_26_tfassinaturaparticipantes_f_to = 0) or ( COALESCE( T3.AssinaturaParticipantes_F, 0) <= :AV99Assinaturawwds_26_tfassinaturaparticipantes_f_to))");
         if ( ( StringUtil.StrCmp(AV75Assinaturawwds_2_dynamicfiltersselector1, "ASSINATURASTATUS") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Assinaturawwds_4_assinaturastatus1)) ) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaStatus = ( :AV77Assinaturawwds_4_assinaturastatus1))");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV75Assinaturawwds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV76Assinaturawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Assinaturawwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV78Assinaturawwds_5_contratonome1)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV75Assinaturawwds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV76Assinaturawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Assinaturawwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV78Assinaturawwds_5_contratonome1)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( AV79Assinaturawwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Assinaturawwds_7_dynamicfiltersselector2, "ASSINATURASTATUS") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Assinaturawwds_9_assinaturastatus2)) ) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaStatus = ( :AV82Assinaturawwds_9_assinaturastatus2))");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( AV79Assinaturawwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Assinaturawwds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV81Assinaturawwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Assinaturawwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV83Assinaturawwds_10_contratonome2)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( AV79Assinaturawwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Assinaturawwds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV81Assinaturawwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Assinaturawwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV83Assinaturawwds_10_contratonome2)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( AV84Assinaturawwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Assinaturawwds_12_dynamicfiltersselector3, "ASSINATURASTATUS") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Assinaturawwds_14_assinaturastatus3)) ) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaStatus = ( :AV87Assinaturawwds_14_assinaturastatus3))");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( AV84Assinaturawwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Assinaturawwds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV86Assinaturawwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Assinaturawwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV88Assinaturawwds_15_contratonome3)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( AV84Assinaturawwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Assinaturawwds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV86Assinaturawwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Assinaturawwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV88Assinaturawwds_15_contratonome3)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Assinaturawwds_17_tfcontratonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Assinaturawwds_16_tfcontratonome)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV89Assinaturawwds_16_tfcontratonome)");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Assinaturawwds_17_tfcontratonome_sel)) && ! ( StringUtil.StrCmp(AV90Assinaturawwds_17_tfcontratonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome = ( :AV90Assinaturawwds_17_tfcontratonome_sel))");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( StringUtil.StrCmp(AV90Assinaturawwds_17_tfcontratonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ContratoNome IS NULL or (char_length(trim(trailing ' ' from T2.ContratoNome))=0))");
         }
         if ( AV91Assinaturawwds_18_tfassinaturastatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV91Assinaturawwds_18_tfassinaturastatus_sels, "T1.AssinaturaStatus IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV92Assinaturawwds_19_tfcontratodatainicial) )
         {
            AddWhere(sWhereString, "(T2.ContratoDataInicial >= :AV92Assinaturawwds_19_tfcontratodatainicial)");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( ! (DateTime.MinValue==AV93Assinaturawwds_20_tfcontratodatainicial_to) )
         {
            AddWhere(sWhereString, "(T2.ContratoDataInicial <= :AV93Assinaturawwds_20_tfcontratodatainicial_to)");
         }
         else
         {
            GXv_int5[24] = 1;
         }
         if ( ! (DateTime.MinValue==AV94Assinaturawwds_21_tfcontratodatafinal) )
         {
            AddWhere(sWhereString, "(T2.ContratoDataFinal >= :AV94Assinaturawwds_21_tfcontratodatafinal)");
         }
         else
         {
            GXv_int5[25] = 1;
         }
         if ( ! (DateTime.MinValue==AV95Assinaturawwds_22_tfcontratodatafinal_to) )
         {
            AddWhere(sWhereString, "(T2.ContratoDataFinal <= :AV95Assinaturawwds_22_tfcontratodatafinal_to)");
         }
         else
         {
            GXv_int5[26] = 1;
         }
         if ( ! (DateTime.MinValue==AV96Assinaturawwds_23_tfassinaturafinalizadodata) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaFinalizadoData >= :AV96Assinaturawwds_23_tfassinaturafinalizadodata)");
         }
         else
         {
            GXv_int5[27] = 1;
         }
         if ( ! (DateTime.MinValue==AV97Assinaturawwds_24_tfassinaturafinalizadodata_to) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaFinalizadoData <= :AV97Assinaturawwds_24_tfassinaturafinalizadodata_to)");
         }
         else
         {
            GXv_int5[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68AssinaturaStatus)) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaStatus = ( :AV68AssinaturaStatus))");
         }
         else
         {
            GXv_int5[29] = 1;
         }
         if ( AV13OrderedBy == 1 )
         {
            sOrderString += " ORDER BY T1.AssinaturaId DESC";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T2.ContratoNome, T1.AssinaturaId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.ContratoNome DESC, T1.AssinaturaId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.AssinaturaStatus, T1.AssinaturaId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.AssinaturaStatus DESC, T1.AssinaturaId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T2.ContratoDataInicial, T1.AssinaturaId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.ContratoDataInicial DESC, T1.AssinaturaId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T2.ContratoDataFinal, T1.AssinaturaId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.ContratoDataFinal DESC, T1.AssinaturaId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.AssinaturaFinalizadoData, T1.AssinaturaId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.AssinaturaFinalizadoData DESC, T1.AssinaturaId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.AssinaturaId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_H005F5( IGxContext context ,
                                             string A239AssinaturaStatus ,
                                             GxSimpleCollection<string> AV91Assinaturawwds_18_tfassinaturastatus_sels ,
                                             string AV75Assinaturawwds_2_dynamicfiltersselector1 ,
                                             string AV77Assinaturawwds_4_assinaturastatus1 ,
                                             short AV76Assinaturawwds_3_dynamicfiltersoperator1 ,
                                             string AV78Assinaturawwds_5_contratonome1 ,
                                             bool AV79Assinaturawwds_6_dynamicfiltersenabled2 ,
                                             string AV80Assinaturawwds_7_dynamicfiltersselector2 ,
                                             string AV82Assinaturawwds_9_assinaturastatus2 ,
                                             short AV81Assinaturawwds_8_dynamicfiltersoperator2 ,
                                             string AV83Assinaturawwds_10_contratonome2 ,
                                             bool AV84Assinaturawwds_11_dynamicfiltersenabled3 ,
                                             string AV85Assinaturawwds_12_dynamicfiltersselector3 ,
                                             string AV87Assinaturawwds_14_assinaturastatus3 ,
                                             short AV86Assinaturawwds_13_dynamicfiltersoperator3 ,
                                             string AV88Assinaturawwds_15_contratonome3 ,
                                             string AV90Assinaturawwds_17_tfcontratonome_sel ,
                                             string AV89Assinaturawwds_16_tfcontratonome ,
                                             int AV91Assinaturawwds_18_tfassinaturastatus_sels_Count ,
                                             DateTime AV92Assinaturawwds_19_tfcontratodatainicial ,
                                             DateTime AV93Assinaturawwds_20_tfcontratodatainicial_to ,
                                             DateTime AV94Assinaturawwds_21_tfcontratodatafinal ,
                                             DateTime AV95Assinaturawwds_22_tfcontratodatafinal_to ,
                                             DateTime AV96Assinaturawwds_23_tfassinaturafinalizadodata ,
                                             DateTime AV97Assinaturawwds_24_tfassinaturafinalizadodata_to ,
                                             string AV68AssinaturaStatus ,
                                             string A228ContratoNome ,
                                             DateTime A362ContratoDataInicial ,
                                             DateTime A363ContratoDataFinal ,
                                             DateTime A366AssinaturaFinalizadoData ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             string AV74Assinaturawwds_1_filterfulltext ,
                                             short A367AssinaturaParticipantes_F ,
                                             short AV98Assinaturawwds_25_tfassinaturaparticipantes_f ,
                                             short AV99Assinaturawwds_26_tfassinaturaparticipantes_f_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[30];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ((Assinatura T1 LEFT JOIN Contrato T2 ON T2.ContratoId = T1.ContratoId) LEFT JOIN LATERAL (SELECT COUNT(*) AS AssinaturaParticipantes_F, AssinaturaId FROM AssinaturaParticipante WHERE T1.AssinaturaId = AssinaturaId GROUP BY AssinaturaId ) T3 ON T3.AssinaturaId = T1.AssinaturaId)";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV74Assinaturawwds_1_filterfulltext))=0) or ( ( T2.ContratoNome like '%' || :lV74Assinaturawwds_1_filterfulltext) or ( 'enviado' like '%' || LOWER(:lV74Assinaturawwds_1_filterfulltext) and T1.AssinaturaStatus = ( 'ENVIADO')) or ( 'rejeitado' like '%' || LOWER(:lV74Assinaturawwds_1_filterfulltext) and T1.AssinaturaStatus = ( 'REJEITADO')) or ( 'cancelado' like '%' || LOWER(:lV74Assinaturawwds_1_filterfulltext) and T1.AssinaturaStatus = ( 'CANCELADO')) or ( 'assinado' like '%' || LOWER(:lV74Assinaturawwds_1_filterfulltext) and T1.AssinaturaStatus = ( 'ASSINADO')) or ( 'aguardando envio' like '%' || LOWER(:lV74Assinaturawwds_1_filterfulltext) and T1.AssinaturaStatus = ( 'AGUARDANDO_ENVIO')) or ( SUBSTR(TO_CHAR(COALESCE( T3.AssinaturaParticipantes_F, 0),'9999'), 2) like '%' || :lV74Assinaturawwds_1_filterfulltext)))");
         AddWhere(sWhereString, "((:AV98Assinaturawwds_25_tfassinaturaparticipantes_f = 0) or ( COALESCE( T3.AssinaturaParticipantes_F, 0) >= :AV98Assinaturawwds_25_tfassinaturaparticipantes_f))");
         AddWhere(sWhereString, "((:AV99Assinaturawwds_26_tfassinaturaparticipantes_f_to = 0) or ( COALESCE( T3.AssinaturaParticipantes_F, 0) <= :AV99Assinaturawwds_26_tfassinaturaparticipantes_f_to))");
         if ( ( StringUtil.StrCmp(AV75Assinaturawwds_2_dynamicfiltersselector1, "ASSINATURASTATUS") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Assinaturawwds_4_assinaturastatus1)) ) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaStatus = ( :AV77Assinaturawwds_4_assinaturastatus1))");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV75Assinaturawwds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV76Assinaturawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Assinaturawwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV78Assinaturawwds_5_contratonome1)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV75Assinaturawwds_2_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV76Assinaturawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Assinaturawwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV78Assinaturawwds_5_contratonome1)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( AV79Assinaturawwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Assinaturawwds_7_dynamicfiltersselector2, "ASSINATURASTATUS") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Assinaturawwds_9_assinaturastatus2)) ) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaStatus = ( :AV82Assinaturawwds_9_assinaturastatus2))");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( AV79Assinaturawwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Assinaturawwds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV81Assinaturawwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Assinaturawwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV83Assinaturawwds_10_contratonome2)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( AV79Assinaturawwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Assinaturawwds_7_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV81Assinaturawwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Assinaturawwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV83Assinaturawwds_10_contratonome2)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( AV84Assinaturawwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Assinaturawwds_12_dynamicfiltersselector3, "ASSINATURASTATUS") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Assinaturawwds_14_assinaturastatus3)) ) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaStatus = ( :AV87Assinaturawwds_14_assinaturastatus3))");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( AV84Assinaturawwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Assinaturawwds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV86Assinaturawwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Assinaturawwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV88Assinaturawwds_15_contratonome3)");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( AV84Assinaturawwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Assinaturawwds_12_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV86Assinaturawwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Assinaturawwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like '%' || :lV88Assinaturawwds_15_contratonome3)");
         }
         else
         {
            GXv_int7[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Assinaturawwds_17_tfcontratonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Assinaturawwds_16_tfcontratonome)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV89Assinaturawwds_16_tfcontratonome)");
         }
         else
         {
            GXv_int7[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Assinaturawwds_17_tfcontratonome_sel)) && ! ( StringUtil.StrCmp(AV90Assinaturawwds_17_tfcontratonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome = ( :AV90Assinaturawwds_17_tfcontratonome_sel))");
         }
         else
         {
            GXv_int7[22] = 1;
         }
         if ( StringUtil.StrCmp(AV90Assinaturawwds_17_tfcontratonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ContratoNome IS NULL or (char_length(trim(trailing ' ' from T2.ContratoNome))=0))");
         }
         if ( AV91Assinaturawwds_18_tfassinaturastatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV91Assinaturawwds_18_tfassinaturastatus_sels, "T1.AssinaturaStatus IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV92Assinaturawwds_19_tfcontratodatainicial) )
         {
            AddWhere(sWhereString, "(T2.ContratoDataInicial >= :AV92Assinaturawwds_19_tfcontratodatainicial)");
         }
         else
         {
            GXv_int7[23] = 1;
         }
         if ( ! (DateTime.MinValue==AV93Assinaturawwds_20_tfcontratodatainicial_to) )
         {
            AddWhere(sWhereString, "(T2.ContratoDataInicial <= :AV93Assinaturawwds_20_tfcontratodatainicial_to)");
         }
         else
         {
            GXv_int7[24] = 1;
         }
         if ( ! (DateTime.MinValue==AV94Assinaturawwds_21_tfcontratodatafinal) )
         {
            AddWhere(sWhereString, "(T2.ContratoDataFinal >= :AV94Assinaturawwds_21_tfcontratodatafinal)");
         }
         else
         {
            GXv_int7[25] = 1;
         }
         if ( ! (DateTime.MinValue==AV95Assinaturawwds_22_tfcontratodatafinal_to) )
         {
            AddWhere(sWhereString, "(T2.ContratoDataFinal <= :AV95Assinaturawwds_22_tfcontratodatafinal_to)");
         }
         else
         {
            GXv_int7[26] = 1;
         }
         if ( ! (DateTime.MinValue==AV96Assinaturawwds_23_tfassinaturafinalizadodata) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaFinalizadoData >= :AV96Assinaturawwds_23_tfassinaturafinalizadodata)");
         }
         else
         {
            GXv_int7[27] = 1;
         }
         if ( ! (DateTime.MinValue==AV97Assinaturawwds_24_tfassinaturafinalizadodata_to) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaFinalizadoData <= :AV97Assinaturawwds_24_tfassinaturafinalizadodata_to)");
         }
         else
         {
            GXv_int7[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68AssinaturaStatus)) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaStatus = ( :AV68AssinaturaStatus))");
         }
         else
         {
            GXv_int7[29] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV13OrderedBy == 1 )
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
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
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
                     return conditional_H005F3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (int)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (DateTime)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (short)dynConstraints[30] , (bool)dynConstraints[31] , (string)dynConstraints[32] , (short)dynConstraints[33] , (short)dynConstraints[34] , (short)dynConstraints[35] );
               case 1 :
                     return conditional_H005F5(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (int)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (DateTime)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (short)dynConstraints[30] , (bool)dynConstraints[31] , (string)dynConstraints[32] , (short)dynConstraints[33] , (short)dynConstraints[34] , (short)dynConstraints[35] );
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
          Object[] prmH005F3;
          prmH005F3 = new Object[] {
          new ParDef("AV74Assinaturawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV74Assinaturawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV74Assinaturawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV74Assinaturawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV74Assinaturawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV74Assinaturawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV74Assinaturawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV74Assinaturawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV98Assinaturawwds_25_tfassinaturaparticipantes_f",GXType.Int16,4,0) ,
          new ParDef("AV98Assinaturawwds_25_tfassinaturaparticipantes_f",GXType.Int16,4,0) ,
          new ParDef("AV99Assinaturawwds_26_tfassinaturaparticipantes_f_to",GXType.Int16,4,0) ,
          new ParDef("AV99Assinaturawwds_26_tfassinaturaparticipantes_f_to",GXType.Int16,4,0) ,
          new ParDef("AV77Assinaturawwds_4_assinaturastatus1",GXType.VarChar,40,0) ,
          new ParDef("lV78Assinaturawwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV78Assinaturawwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("AV82Assinaturawwds_9_assinaturastatus2",GXType.VarChar,40,0) ,
          new ParDef("lV83Assinaturawwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV83Assinaturawwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("AV87Assinaturawwds_14_assinaturastatus3",GXType.VarChar,40,0) ,
          new ParDef("lV88Assinaturawwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV88Assinaturawwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV89Assinaturawwds_16_tfcontratonome",GXType.VarChar,125,0) ,
          new ParDef("AV90Assinaturawwds_17_tfcontratonome_sel",GXType.VarChar,125,0) ,
          new ParDef("AV92Assinaturawwds_19_tfcontratodatainicial",GXType.Date,8,0) ,
          new ParDef("AV93Assinaturawwds_20_tfcontratodatainicial_to",GXType.Date,8,0) ,
          new ParDef("AV94Assinaturawwds_21_tfcontratodatafinal",GXType.Date,8,0) ,
          new ParDef("AV95Assinaturawwds_22_tfcontratodatafinal_to",GXType.Date,8,0) ,
          new ParDef("AV96Assinaturawwds_23_tfassinaturafinalizadodata",GXType.DateTime,8,5) ,
          new ParDef("AV97Assinaturawwds_24_tfassinaturafinalizadodata_to",GXType.DateTime,8,5) ,
          new ParDef("AV68AssinaturaStatus",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH005F5;
          prmH005F5 = new Object[] {
          new ParDef("AV74Assinaturawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV74Assinaturawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV74Assinaturawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV74Assinaturawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV74Assinaturawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV74Assinaturawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV74Assinaturawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV74Assinaturawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV98Assinaturawwds_25_tfassinaturaparticipantes_f",GXType.Int16,4,0) ,
          new ParDef("AV98Assinaturawwds_25_tfassinaturaparticipantes_f",GXType.Int16,4,0) ,
          new ParDef("AV99Assinaturawwds_26_tfassinaturaparticipantes_f_to",GXType.Int16,4,0) ,
          new ParDef("AV99Assinaturawwds_26_tfassinaturaparticipantes_f_to",GXType.Int16,4,0) ,
          new ParDef("AV77Assinaturawwds_4_assinaturastatus1",GXType.VarChar,40,0) ,
          new ParDef("lV78Assinaturawwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV78Assinaturawwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("AV82Assinaturawwds_9_assinaturastatus2",GXType.VarChar,40,0) ,
          new ParDef("lV83Assinaturawwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV83Assinaturawwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("AV87Assinaturawwds_14_assinaturastatus3",GXType.VarChar,40,0) ,
          new ParDef("lV88Assinaturawwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV88Assinaturawwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV89Assinaturawwds_16_tfcontratonome",GXType.VarChar,125,0) ,
          new ParDef("AV90Assinaturawwds_17_tfcontratonome_sel",GXType.VarChar,125,0) ,
          new ParDef("AV92Assinaturawwds_19_tfcontratodatainicial",GXType.Date,8,0) ,
          new ParDef("AV93Assinaturawwds_20_tfcontratodatainicial_to",GXType.Date,8,0) ,
          new ParDef("AV94Assinaturawwds_21_tfcontratodatafinal",GXType.Date,8,0) ,
          new ParDef("AV95Assinaturawwds_22_tfcontratodatafinal_to",GXType.Date,8,0) ,
          new ParDef("AV96Assinaturawwds_23_tfassinaturafinalizadodata",GXType.DateTime,8,5) ,
          new ParDef("AV97Assinaturawwds_24_tfassinaturafinalizadodata_to",GXType.DateTime,8,5) ,
          new ParDef("AV68AssinaturaStatus",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("H005F3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005F3,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005F5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005F5,1, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((long[]) buf[14])[0] = rslt.getLong(8);
                ((short[]) buf[15])[0] = rslt.getShort(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
